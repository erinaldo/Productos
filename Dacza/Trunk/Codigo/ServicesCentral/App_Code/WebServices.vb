Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports MobileClient
Imports System.Collections

Public Class WebServices

#Region "Metodos usados para compilar y llamar WebServices"

    Private Shared WSAsswmbly As New Hashtable 'dlls compiladas
    Private Shared WSClasses As New Hashtable 'clases
    Private Shared TiposNoKeepAlive As New Hashtable 'tipos sobreescritos

    Public Class NoKeepAliveClass
        'clase usada para sobreescribir el metodo GetWebRequest y poder quitar el KeepAlive
        Private Shared _credenciales As Net.NetworkCredential = Nothing

        Public Shared Property Credenciales() As Net.NetworkCredential
            Get
                Return _credenciales
            End Get
            Set(ByVal value As Net.NetworkCredential)
                _credenciales = value
            End Set
        End Property

        Public Shared Function GetWebRequest(ByVal uri As System.Uri) As System.Net.WebRequest
            Dim req As Net.HttpWebRequest = Net.WebRequest.Create(uri)
            req.KeepAlive = False
            If Not IsNothing(Credenciales) Then
                req.Credentials = Credenciales
            End If
            Return req
        End Function
    End Class

    Public Shared Function OverrideGetWebRequest(ByVal clase As Type, ByVal Wsdll As System.Reflection.Assembly) As Type
        Dim typeofOriginal As Type = clase

        If Not TiposNoKeepAlive.Contains(Wsdll.FullName) Then
            Dim asmName As New System.Reflection.AssemblyName(Wsdll.FullName)
            Dim asmBuilder As System.Reflection.Emit.AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, Reflection.Emit.AssemblyBuilderAccess.RunAndSave)
            Dim modBuilder As System.Reflection.Emit.ModuleBuilder = asmBuilder.DefineDynamicModule(asmName.Name, asmName.Name & ".dll")

            Dim typeBuilder As System.Reflection.Emit.TypeBuilder = modBuilder.DefineType(typeofOriginal.Name & "WithoutKeepAlive", Reflection.TypeAttributes.Public Or Reflection.TypeAttributes.Sealed Or Reflection.TypeAttributes.Class, typeofOriginal)

            Dim methodBuilder As Reflection.Emit.MethodBuilder = typeBuilder.DefineMethod("GetWebRequest", Reflection.MethodAttributes.Public Or Reflection.MethodAttributes.ReuseSlot Or Reflection.MethodAttributes.HideBySig Or Reflection.MethodAttributes.Virtual, GetType(System.Net.WebRequest), New Type() {GetType(Uri)})
            Dim ilgen As Reflection.Emit.ILGenerator = methodBuilder.GetILGenerator()
            Dim localBuilder As Reflection.Emit.LocalBuilder = ilgen.DeclareLocal(GetType(System.Net.WebRequest))
            ilgen.Emit(Reflection.Emit.OpCodes.Ldarg_1)
            ilgen.Emit(Reflection.Emit.OpCodes.Call, GetType(NoKeepAliveClass).GetMethod("GetWebRequest", Reflection.BindingFlags.Static Or Reflection.BindingFlags.Public)) ', Reflection.BindingFlags.Static Or Reflection.BindingFlags.Public))
            ilgen.Emit(Reflection.Emit.OpCodes.Stloc_0)
            ilgen.Emit(Reflection.Emit.OpCodes.Ldloc_0)
            ilgen.Emit(Reflection.Emit.OpCodes.Ret)

            Dim newType As Type = typeBuilder.CreateType

            TiposNoKeepAlive.Add(Wsdll.FullName, newType)

            Return newType
        Else
            Dim tipo As Type = TiposNoKeepAlive.Item(typeofOriginal.Name & "WithoutKeepAlive")

            Return tipo
        End If

    End Function

    Public Shared Function CompilarWS(ByVal WebServiceAsmxURL As String, ByRef WebServiceClass As System.Type, Optional ByVal Credential As System.Net.NetworkCredential = Nothing, Optional ByVal OverrideGetWebRequestMethod As Boolean = False) As System.Reflection.Assembly

        If Not WSAsswmbly.Contains(WebServiceAsmxURL) Then

            Dim cliente As New System.Net.WebClient()

            If Not IsNothing(Credential) Then
                'asignar credenciales para obtener acceso al WSDL para compilar
                cliente.Credentials = Credential
            End If

            '-Connect To the web service
            Using stream As System.IO.Stream = cliente.OpenRead(WebServiceAsmxURL & "?wsdl")
                '-Now read the WSDL file describing a service.
                Dim descripcion As System.Web.Services.Description.ServiceDescription = System.Web.Services.Description.ServiceDescription.Read(stream)
                '///// LOAD THE DOM /////////
                '--Initialize a service description importer.
                Dim importer As New System.Web.Services.Description.ServiceDescriptionImporter()
                importer.ProtocolName = "Soap12" ' Use SOAP 1.2.
                importer.AddServiceDescription(descripcion, Nothing, Nothing)
                '--Generate a proxy client. importer.Style = ServiceDescriptionImportStyle.Client;
                '--Generate properties to represent primitive values.
                importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties
                '--Initialize a Code-DOM tree into which we will import the service.
                Dim nmspace As New System.CodeDom.CodeNamespace()
                Dim unit1 As New System.CodeDom.CodeCompileUnit()
                unit1.Namespaces.Add(nmspace)
                '--Import the service into the Code-DOM tree. This creates proxy code
                '--that uses the service.
                Dim warning As System.Web.Services.Description.ServiceDescriptionImportWarnings = importer.Import(nmspace, unit1)
                If warning = 0 Or warning = 2 Then '-If zero then we are good to go
                    '--Generate the proxy code 
                    Dim provider1 As System.CodeDom.Compiler.CodeDomProvider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp")
                    '--Compile the assembly proxy with the appropriate references
                    Dim assemblyReferences As String() = New String() {"System.dll", "System.Web.Services.dll", "System.Web.dll", "System.Xml.dll", "System.Data.dll"}
                    Dim params As New System.CodeDom.Compiler.CompilerParameters(assemblyReferences)
                    Dim results As System.CodeDom.Compiler.CompilerResults = provider1.CompileAssemblyFromDom(params, unit1)
                    '-Check For Errors
                    If results.Errors.Count > 0 Then
                        Dim sb As New System.Text.StringBuilder
                        For Each oops As System.CodeDom.Compiler.CompilerError In results.Errors
                            sb.AppendLine("========Compiler error============")
                            sb.AppendLine(oops.ErrorText)
                        Next
                        Throw New System.ApplicationException("Ocurrio un error al compilar el WerbService." & vbCrLf & sb.ToString())
                    End If

                    Dim foundtype As System.Type = Nothing
                    Dim types As System.Type() = results.CompiledAssembly.GetTypes()
                    For Each t As System.Type In types
                        Dim x As Type = GetType(System.Web.Services.Protocols.SoapHttpClientProtocol)
                        Dim y As Type = t.BaseType
                        If y.Equals(x) Then
                            WebServiceClass = t
                        End If
                    Next

                    'si se va a sobreescribir el metodo, reemplazar la clase del web service por la que tiene el metodo sobreescrito
                    If OverrideGetWebRequestMethod Then WebServiceClass = OverrideGetWebRequest(WebServiceClass, results.CompiledAssembly)

                    WSAsswmbly.Add(WebServiceAsmxURL, results.CompiledAssembly)
                    WSClasses.Add(WebServiceAsmxURL, WebServiceClass)

                    'regresar el webservice compilado
                    Return results.CompiledAssembly
                Else
                    Return Nothing
                End If
            End Using

        Else
            'si ya fue compilado regresar el assembly y la clase
            WebServiceClass = WSClasses.Item(WebServiceAsmxURL)
            Dim dll As System.Reflection.Assembly = WSAsswmbly.Item(WebServiceAsmxURL)

            Return dll

        End If

    End Function

    Public Shared Function LlamarWS(ByVal CompiledWebService As System.Reflection.Assembly, ByVal WebServiceClass As System.Type, ByVal MethodName As String, ByVal args As Object(), Optional ByVal Credential As System.Net.NetworkCredential = Nothing, Optional ByVal GetWebResquestOverriden As Boolean = False) As Object
        'crear instancia del ws
        Dim wsvClass As Object
        If GetWebResquestOverriden Then
            'si el metodo fue sobreescrito, crear la instancia de la dll generada
            wsvClass = WebServiceClass.Assembly.CreateInstance(WebServiceClass.ToString())
            'pasar las credenciales a la clase con el metodo sobreescrito ya que no toma las del wsvClass
            NoKeepAliveClass.Credenciales = Credential
        Else
            'sino, generar la instancia del webservice compilado
            wsvClass = CompiledWebService.CreateInstance(WebServiceClass.ToString())
        End If

        'obtener el metodo
        Dim mi As System.Reflection.MethodInfo = wsvClass.GetType().GetMethod(MethodName)

        If IsNothing(mi) Then
            Throw New System.ApplicationException("Error WS. El metodo """ & MethodName & """ no existe.")
        End If

        If Not IsNothing(Credential) Then
            'asignar las credenciales al ws
            wsvClass.GetType().GetProperty("Credentials").SetValue(wsvClass, Credential, Nothing)
        End If

        'invocar el metodo con los parametros
        Return mi.Invoke(wsvClass, args)
    End Function

    Public Shared Function LlamarWS(ByVal endPointURL As String, ByVal CompiledWebService As System.Reflection.Assembly, ByVal WebServiceClass As System.Type, ByVal MethodName As String, ByVal args As Object(), Optional ByVal Credential As System.Net.NetworkCredential = Nothing, Optional ByVal GetWebResquestOverriden As Boolean = False) As Object
        'crear instancia del ws
        Dim wsvClass As Object
        If GetWebResquestOverriden Then
            'si el metodo fue sobreescrito, crear la instancia de la dll generada
            wsvClass = WebServiceClass.Assembly.CreateInstance(WebServiceClass.ToString())
            'pasar las credenciales a la clase con el metodo sobreescrito ya que no toma las del wsvClass
            NoKeepAliveClass.Credenciales = Credential
        Else
            'sino, generar la instancia del webservice compilado
            wsvClass = CompiledWebService.CreateInstance(WebServiceClass.ToString())
        End If

        'obtener la url del endpoint
        Dim _url As String = wsvClass.GetType().GetProperty("Url").GetGetMethod().Invoke(wsvClass, Nothing)

        Dim i As Integer = _url.IndexOf("/")
        Dim y As Integer
        If i = 5 Then
            y = _url.IndexOf("/", i + 2)
            _url = _url.Substring(y, _url.Length - y)
        End If

        _url = endPointURL & _url

        'asignar la url del endpoint
        wsvClass.GetType().GetProperty("Url").SetValue(wsvClass, _url, Nothing)

        'obtener el metodo
        Dim mi As System.Reflection.MethodInfo = wsvClass.GetType().GetMethod(MethodName)

        If IsNothing(mi) Then
            Throw New System.ApplicationException("Error WS. El metodo """ & MethodName & """ no existe.")
        End If

        If Not IsNothing(Credential) Then
            'asignar las credenciales al ws
            wsvClass.GetType().GetProperty("Credentials").SetValue(wsvClass, Credential, Nothing)
        End If

        'invocar el metodo con los parametros
        Return mi.Invoke(wsvClass, args)
    End Function

    Public Shared Function LlamarWS(ByVal WebServiceAsmxURL As String, ByVal MethodName As String, ByVal args As Object()) As Object
        Dim t As System.Type = GetType(Object)
        Return LlamarWS(CompilarWS(WebServiceAsmxURL, t), t, MethodName, args)
    End Function

    Public Shared Function ObtenerParametrosWS(ByVal CompiledWebService As System.Reflection.Assembly, ByVal WsClass As System.Type, ByVal metodo As String, ByVal interfaz As Integer, Optional ByVal dr As DataRow = Nothing, Optional ByVal dt As DataTable = Nothing) As Object()
        'IMPLEMENTAR AQUI LA OBTENCION DE LOS PARAMETROS
        'Dim msj As String = ""
        Try
            If interfaz = 69 Or interfaz = 72 Then
                Dim param As Object = CompiledWebService.CreateInstance(ObtenerTipoParametroWS(CompiledWebService, WsClass, metodo, True))
                'msj &= "param creado ok"
                'If interfaz = 69 Then
                '    param = CompiledWebService.CreateInstance("Z41_PEDIDOS_ROUTE")
                'Else
                '    param = CompiledWebService.CreateInstance("Z41_DEVOLUCION_ROUTE")
                'End If
                Dim cabecero As Object = CompiledWebService.CreateInstance("ZSTR_41_PEDIDOS_ROUTE_01")
                Dim adetalle As New System.Collections.ArrayList
                'msj &= ",cabecero creado ok"

                'llenar el cabecero
                For Each col As DataColumn In dr.Table.Columns
                    Dim prop As System.Reflection.PropertyInfo = cabecero.GetType().GetProperty(col.ColumnName)
                    If Not IsNothing(prop) And Not dr(col).Equals(DBNull.Value) Then
                        'si existe la propiedad y el valor no es nulo, asigna el valor
                        prop.SetValue(cabecero, dr(col), Nothing)
                    End If
                Next
                'msj &= ",cabecero llenado ok"

                'obtener los detalles del cabecero, llenarlos y agregarlos al array
                'Dim drs As DataRow() = dt.Select("PURCH_NO_C = '" & dr("PURCH_NO_C") & "'", "PURCH_NO_C,Orden,HG_LV_ITEM,ITM_NUMBER")
                Dim drs As DataRow() = dt.Select("TransProdID = '" & dr("TransProdID") & "'", "TransProdID,Orden,HG_LV_ITEM,ITM_NUMBER")
                For Each dtrs As DataRow In drs
                    Dim detalle As Object = CompiledWebService.CreateInstance("ZSTR_41_PEDIDOS_ROUTE_POS")
                    For Each col As DataColumn In dt.Columns
                        Dim prop As System.Reflection.PropertyInfo = detalle.GetType().GetProperty(col.ColumnName)
                        If Not IsNothing(prop) And Not IsNothing(dtrs(col)) Then
                            'si existe la propiedad y el valor no es nulo, asigna el valor
                            prop.SetValue(detalle, dtrs(col), Nothing)
                        End If
                    Next
                    'agregar el detalle al array
                    adetalle.Add(detalle)
                Next
                'msj &= ",detalles llenados ok"

                'agregar los detalles al cabecero
                Dim pos As System.Reflection.PropertyInfo = cabecero.GetType().GetProperty("POSICIONES")
                If Not IsNothing(pos) Then
                    pos.SetValue(cabecero, adetalle.ToArray(CompiledWebService.CreateInstance("ZSTR_41_PEDIDOS_ROUTE_POS").GetType()), Nothing)
                End If
                'msj &= ",detalles agregados al cabecero ok"

                'agregar al parametro de envio el cabecero
                Dim pedido As System.Reflection.PropertyInfo = param.GetType().GetProperty("I_PEDIDO")
                If Not IsNothing(pedido) Then
                    pedido.SetValue(param, cabecero, Nothing)
                End If
                'msj &= ",estructura agregada al param ok"

                Return New Object() {param}
            ElseIf interfaz = 71 Then
                Dim param As Object = CompiledWebService.CreateInstance(ObtenerTipoParametroWS(CompiledWebService, WsClass, metodo, True))
                '= CompiledWebService.CreateInstance("Z41_CANCELACION_ROUTE")
                Dim cancelar As Object = CompiledWebService.CreateInstance("ZSTR_41_CANCELA_ROUTE")

                For Each col As DataColumn In dr.Table.Columns
                    Dim prop As System.Reflection.PropertyInfo = cancelar.GetType().GetProperty(col.ColumnName)
                    If Not IsNothing(prop) And Not dr(col).Equals(DBNull.Value) Then
                        'si existe la propiedad y el valor no es nulo, asigna el valor
                        prop.SetValue(cancelar, dr(col), Nothing)
                    End If
                Next

                Dim pedido As System.Reflection.PropertyInfo = param.GetType().GetProperty("I_PEDIDO")
                If Not IsNothing(pedido) Then
                    pedido.SetValue(param, cancelar, Nothing)
                End If

                Return New Object() {param}
            Else
                Return New Object() {}
            End If
        Catch ex As Exception
            'Throw New Exception(msj)
            Throw New Exception("Error WS. Obtener Parametros " & interfaz & ". " & ex.Message)
        End Try
    End Function

    Private Shared Function ObtenerTipoParametroWS(ByVal CompiledWebService As System.Reflection.Assembly, ByVal WebServiceClass As System.Type, ByVal MethodName As String, Optional ByVal GetWebResquestOverriden As Boolean = False) As String
        Dim wsvClass As Object
        If GetWebResquestOverriden Then
            wsvClass = WebServiceClass.Assembly.CreateInstance(WebServiceClass.ToString())
        Else
            wsvClass = CompiledWebService.CreateInstance(WebServiceClass.ToString())
        End If
        Dim mi As System.Reflection.MethodInfo = wsvClass.GetType().GetMethod(MethodName)
        If Not IsNothing(mi) Then
            If mi.GetParameters.Length = 1 Then
                For Each p As System.Reflection.ParameterInfo In mi.GetParameters
                    Return p.ParameterType.FullName
                Next
            End If
        Else
            Throw New System.ApplicationException("Error WS. El metodo """ & MethodName & """ no existe.")
        End If
        Return Nothing
    End Function
#End Region
    
#Region "Metodos para llamar los WebServices de Chocolate Ibarra"
    Public Shared Sub EjecutarWSCancelacionCHO(ByVal endPointURL As String, ByVal Wsdll As System.Reflection.Assembly, ByVal WsClass As System.Type, ByVal metodo As String, ByVal usuario As String, ByVal passwd As String, ByRef refparsMensaje As String, ByVal INSTipoInterfaz As String, ByVal sp As String, ByVal Clave As String)
        Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSet(String.Format("{0} '{1}','{2}','{3}'", sp, New Date(9999, 12, 31).ToString("s"), Now.ToString("s"), Clave))
        For Each dtr As DataRow In ds.Tables(0).Rows
            Dim args As Object() = ObtenerParametrosWS(Wsdll, WsClass, metodo, INSTipoInterfaz, dtr)
            Dim res = Wsdll.CreateInstance("Z41_CANCELACION_ROUTEResponse")
            Try
                res = WebServices.LlamarWS(endPointURL, Wsdll, WsClass, metodo, args, New System.Net.NetworkCredential(usuario, passwd), True)
                Dim respuesta = Wsdll.CreateInstance("ZSTR_41_CANCELA_ROUTE_EXPORT")
                respuesta = res.GetType().GetProperty("E_RETURN").GetValue(res, Nothing)

                Dim hubo_error As Boolean = False

                Dim mensajes_respuesta As String = Nothing
                For Each p As System.Reflection.PropertyInfo In respuesta.GetType().GetProperties()
                    If p.Name.ToLower = "error" Then
                        hubo_error = p.GetValue(respuesta, Nothing).ToString().ToLower().Trim().Equals("x")
                    End If
                    mensajes_respuesta &= p.Name & ": " & p.GetValue(respuesta, Nothing) & ", "
                Next
                If mensajes_respuesta.Length > 1 Then mensajes_respuesta = mensajes_respuesta.Substring(0, mensajes_respuesta.Length - 2)
                If hubo_error Then
                    refparsMensaje &= mensajes_respuesta & vbCrLf
                Else 'Todo salio OK,actualizar TipoFaseIntSal en transprod para que no vuelva a obtener el registro y asignar VBELN en notas
                    ConexionSQL.EjecutarComando("UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdId = '" & dtr("TransProdId") & "'")
                End If
                'guardar en la tmp la fecha,intentos y la respuesta del ws
                ConexionSQL.EjecutarComando("UPDATE tmp_expCancelacionesCHO SET Intentos = Intentos + 1,Fecha = GETDATE(),Respuesta = '" & mensajes_respuesta & "' WHERE TransProdId = '" & dtr("TransProdId") & "'")
            Catch ex As Exception
                Dim inner As String
                If Not IsNothing(ex.InnerException) Then inner = ex.InnerException.Message
                refparsMensaje &= "VBELN: " & dtr("VBELN") & ", " & ex.Message & vbCrLf & inner
                'guardar en la tmp la fecha,intentos y la respuesta del ws
                ConexionSQL.EjecutarComando("UPDATE tmp_expCancelacionesCHO SET Intentos = Intentos + 1,Fecha = GETDATE(),Respuesta = '" & "VBELN: " & dtr("VBELN") & ", " & ex.Message & vbCrLf & inner & "' WHERE TransProdId = '" & dtr("TransProdId") & "'")
            End Try
        Next
        If refparsMensaje.Length > 0 Then
            'Throw New Exception(refparsMensaje)
            Throw New Exception("Error WS " & INSTipoInterfaz & ".")
        End If
    End Sub

    Public Shared Sub EjecutarWSCHO(ByVal endPointURL As String, ByVal Wsdll As System.Reflection.Assembly, ByVal WsClass As System.Type, ByVal metodo As String, ByVal usuario As String, ByVal passwd As String, ByRef refparsMensaje As String, ByVal INSTipoInterfaz As String, ByVal sp As String, ByVal Clave As String)
        Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSet(String.Format("{0} '{1}','{2}','{3}'", sp, New Date(9999, 12, 31).ToString("s"), Now.ToString("s"), Clave))
        For Each dtr As DataRow In ds.Tables(0).Rows
            Dim args As Object() = ObtenerParametrosWS(Wsdll, WsClass, metodo, INSTipoInterfaz, dtr, ds.Tables(1))
            Dim res As Object
            If INSTipoInterfaz = 69 Then
                res = Wsdll.CreateInstance("Z41_PEDIDOS_ROUTEResponse")
            ElseIf INSTipoInterfaz = 72 Then
                res = Wsdll.CreateInstance("Z41_DEVOLUCION_ROUTEResponse")
            End If
            Try
                res = WebServices.LlamarWS(endPointURL, Wsdll, WsClass, metodo, args, New System.Net.NetworkCredential(usuario, passwd), True)
                Dim respuesta = Wsdll.CreateInstance("ZSTR_41_PEDIDOS_ROUTE_EXPORT")
                respuesta = res.GetType().GetProperty("E_RETURN").GetValue(res, Nothing)

                Dim hubo_error As Boolean = False

                Dim mensajes_respuesta As String = Nothing, vbeln As String = ""
                For Each p As System.Reflection.PropertyInfo In respuesta.GetType().GetProperties()
                    If p.Name.ToLower = "mensaje" Then
                        hubo_error = p.GetValue(respuesta, Nothing).ToString().Trim().Length > 0
                    ElseIf p.Name.ToLower = "vbeln" Then
                        vbeln = p.GetValue(respuesta, Nothing).ToString()
                    End If
                    mensajes_respuesta &= p.Name & ": " & p.GetValue(respuesta, Nothing) & ", "
                Next
                If mensajes_respuesta.Length > 1 Then mensajes_respuesta = mensajes_respuesta.Substring(0, mensajes_respuesta.Length - 2)
                If hubo_error Then
                    'si hubo error pero regresa folio SAP marcar como OK y no agregar mensaje de error
                    If vbeln.Length > 0 Then
                        ConexionSQL.EjecutarComando("UPDATE TransProd SET TipoFaseIntSal = 1,Notas = '" & vbeln & "' WHERE TransProdId = '" & dtr("TransProdId") & "'")
                    Else
                        refparsMensaje &= mensajes_respuesta & vbCrLf
                    End If
                Else 'Todo salio OK,actualizar TipoFaseIntSal en transprod para que no vuelva a obtener el registro y asignar VBELN en notas
                    ConexionSQL.EjecutarComando("UPDATE TransProd SET TipoFaseIntSal = 1,Notas = '" & vbeln & "' WHERE TransProdId = '" & dtr("TransProdId") & "'")
                End If
                'guardar en la tmp la fecha,intentos y la respuesta del ws
                ConexionSQL.EjecutarComando("UPDATE tmp_exppedidosdevolucioneschoh SET Intentos = Intentos + 1,Fecha = GETDATE(),Respuesta = '" & mensajes_respuesta & "' WHERE TransProdId = '" & dtr("TransProdId") & "'")
            Catch ex As Exception
                Dim inner As String
                If Not IsNothing(ex.InnerException) Then inner = ex.InnerException.Message
                refparsMensaje &= "PURCH_NO_C: " & dtr("PURCH_NO_C") & ",VERSION: " & dtr("VERSION") & ", " & ex.Message & vbCrLf & inner
                'guardar en la tmp la fecha,intentos y la respuesta del ws
                ConexionSQL.EjecutarComando("UPDATE tmp_exppedidosdevolucioneschoh SET Intentos = Intentos + 1,Fecha = GETDATE(),Respuesta = '" & "PURCH_NO_C: " & dtr("PURCH_NO_C") & ",VERSION: " & dtr("VERSION") & ", " & ex.Message & vbCrLf & inner & "' WHERE TransProdId = '" & dtr("TransProdId") & "'")
            End Try
        Next
        If refparsMensaje.Length > 0 Then
            'Throw New Exception(refparsMensaje)
            Throw New Exception("Error WS " & INSTipoInterfaz & ".")
        End If
    End Sub
#End Region

End Class
