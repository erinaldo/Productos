Imports BASLOG
Imports LbDatos

Namespace Amesol
   
    Public Class CFOSHist
        Inherits cClaseNodo

        Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia

        Public Sub New()
            MyBase.New()
        End Sub

        Private DescripcionTerminal As String
        Private NombreVendedor As String
        Private vlUsuario As String = ""
        Private vlCentroExpIDNombre As String = ""

        Public ReadOnly Property CentroExpIDNombre() As String
            Get
                Return vlCentroExpIDNombre
            End Get
        End Property

        Public ReadOnly Property FechaHora() As DateTime
            Get
                Return MFechaHora
            End Get
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return vlUsuario
            End Get
        End Property


        Public Property Descripcion() As String
            Get
                Return DescripcionTerminal
            End Get
            Set(ByVal Value As String)
                DescripcionTerminal = Value
            End Set
        End Property

        Public Property Vendedor() As String
            Get
                Return NombreVendedor
            End Get
            Set(ByVal Value As String)
                NombreVendedor = Value
            End Set
        End Property

        Public ReadOnly Property estado() As eEstado
            Get
                Return Status
            End Get
        End Property

        Public Property FolioID() As String
            Get
                Return Me.Tabla.Campos("FolioID").Valor
            End Get
            Set(ByVal Value As String)
                If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                    Me.Tabla.Campos("FolioID").Valor = Value
                End If
                Verificar_Estatus()
            End Set
        End Property

        Public Property FOSId() As String
            Get
                Return Me.Tabla.Campos("FOSId").Valor
            End Get
            Set(ByVal Value As String)
                If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                    Me.Tabla.Campos("FOSId").Valor = Value
                End If
                Verificar_Estatus()
            End Set
        End Property

        Public Property FSHFechaInicio() As Date
            Get
                Return Me.Tabla.Campos("FSHFechaInicio").Valor
            End Get
            Set(ByVal Value As Date)
                If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                    Me.Tabla.Campos("FSHFechaInicio").Valor = Value
                End If
                Verificar_Estatus()
            End Set
        End Property

        Public Property VendedorID() As String
            Get
                If Me.Tabla.Campos("VendedorID").Valor Is System.DBNull.Value Then
                    Return ""
                End If
                Return Me.Tabla.Campos("VendedorID").Valor
            End Get
            Set(ByVal Value As String)
                Me.Tabla.Campos("VendedorID").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property TerminalClave() As String
            Get
                If Me.Tabla.Campos("TerminalClave").Valor Is System.DBNull.Value Then
                    Return ""
                End If
                Return Me.Tabla.Campos("TerminalClave").Valor
            End Get
            Set(ByVal Value As String)
                Me.Tabla.Campos("TerminalClave").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property NumCertificado() As String
            Get
                Return Me.Tabla.Campos("NumCertificado").Valor
            End Get
            Set(ByVal Value As String)
                Me.Tabla.Campos("NumCertificado").Valor = Value

                Verificar_Estatus()
            End Set
        End Property
        Public Property CentroExpID() As String
            Get
                Return Me.Tabla.Campos("CentroExpID").Valor
            End Get
            Set(ByVal Value As String)
                Me.Tabla.Campos("CentroExpID").Valor = Value
                vlCentroExpIDNombre = FSHCentroExpNombre(Value)
                Verificar_Estatus()
            End Set
        End Property

        Public Property Inicio() As Integer
            Get
                Return Me.Tabla.Campos("Inicio").Valor
            End Get
            Set(ByVal Value As Integer)
                Me.Tabla.Campos("Inicio").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property Fin() As Integer
            Get
                Return Me.Tabla.Campos("Fin").Valor
            End Get
            Set(ByVal Value As Integer)
                Me.Tabla.Campos("Fin").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Protected Overrides Sub CrearEstructuraTabla()
            With Me.Tabla
                .AgregarCampo(New LbDatos.cCampo("FolioID", LbDatos.ETipo.Cadena, "", True, True))
                .AgregarCampo(New LbDatos.cCampo("FOSId", LbDatos.ETipo.Cadena, "", True, True))
                .AgregarCampo(New LbDatos.cCampo("FSHFechaInicio", LbDatos.ETipo.FechaHora, "", True, True))
                .AgregarCampo(New LbDatos.cCampo("VendedorID", LbDatos.ETipo.Cadena, "", False, False, False, True))
                .AgregarCampo(New LbDatos.cCampo("TerminalClave", LbDatos.ETipo.Cadena, "", False, False, False, True))
                .AgregarCampo(New LbDatos.cCampo("NumCertificado", LbDatos.ETipo.Cadena, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("CentroExpID", LbDatos.ETipo.Cadena, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("Inicio", LbDatos.ETipo.Numerico, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("Fin", LbDatos.ETipo.Numerico, "", False, True))

            End With
        End Sub

        Public Overridable Sub Verificar_Estatus()

            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Sub

        Public Overridable Overloads Function Existe(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvFSHFechaInicio As Date) As Boolean
            Return (Me.Tabla.Seleccionar("FolioID='" & pvFolioID.Replace("'", "''") & "',FOSId='" & pvFOSId.Replace("'", "''") & "',FSHFechaInicio='" & pvFSHFechaInicio & "'").Rows.Count > 0)
        End Function

        Public Overridable Overloads Function Existe(ByVal pvFolioID As String) As Boolean
            Return (Me.Tabla.Seleccionar("FolioID='" & pvFolioID.Replace("'", "''") & "'").Rows.Count > 0)
        End Function

        Public Overridable Overloads Function ExisteNombre(ByVal pvNombre As String) As Boolean
            Return (Me.Tabla.Seleccionar("Nombre='" & pvNombre.Replace("'", "''") & "'").Rows.Count > 0)
        End Function

        Public Overridable Overloads Sub Recuperar(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvFSHFechaInicio As Date)
            Me.Limpiar()
            Me.FolioID = pvFolioID
            Me.FOSId = pvFOSId
            Me.FSHFechaInicio = pvFSHFechaInicio
            Me.Recuperar()

            Dim dt As DataTable = vcConexion.EjecutarConsulta("Select Descripcion from Terminal where TerminalClave = '" & Me.TerminalClave.Replace("'", "''") & "'")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.Descripcion = dt.Rows(0).Item("Descripcion")
            End If

            dt = vcConexion.EjecutarConsulta("Select Nombre from Vendedor where VendedorId = '" & Me.VendedorID.Replace("'", "''") & "'")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.Vendedor = dt.Rows(0).Item("Nombre")
            End If

            dt = vcConexion.EjecutarConsulta("Select Nombre from usuario where USUId = '" & MUsuarioID.Replace("'", "''") & "'")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                vlUsuario = dt.Rows(0).Item("Nombre")
            End If

            vlCentroExpIDNombre = FSHCentroExpNombre(CentroExpID)
        End Sub

        Public Overloads Sub Insertar(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvFSHFechaInicio As Date, ByVal pvVendedorID As String, ByVal pvTerminalClave As String, ByVal pvNumCertificado As String, ByVal pvCentroExpID As String, ByVal pvInicio As Integer, ByVal pvFin As Integer)

            Me.FolioID = pvFolioID
            Me.FOSId = pvFOSId
            Me.FSHFechaInicio = pvFSHFechaInicio
            Me.VendedorID = pvVendedorID
            Me.TerminalClave = pvTerminalClave
            Me.NumCertificado = pvNumCertificado
            Me.CentroExpID = pvCentroExpID
            Me.Inicio = pvInicio
            Me.Fin = pvFin
            Me.Insertar()
        End Sub

        Public Overloads Sub Actualizar(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvFSHFechaInicio As Date, ByVal pvVendedorID As String, ByVal pvTerminalClave As String, ByVal pvNumCertificado As String, ByVal pvCentroExpID As String, ByVal pvInicio As Integer, ByVal pvFin As Integer, ByVal pvMUsuarioId As String)

            Me.FolioID = pvFolioID
            Me.FOSId = pvFOSId
            Me.FSHFechaInicio = pvFSHFechaInicio
            Me.VendedorID = pvVendedorID
            Me.TerminalClave = pvTerminalClave
            Me.NumCertificado = pvNumCertificado
            Me.CentroExpID = pvCentroExpID
            Me.Inicio = pvInicio
            Me.Fin = pvFin
            'Me.MUsuarioIdFSH = pvMUsuarioId
            Me.tEstado = eEstado.Modificado
        End Sub

        Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
            Return System.Reflection.Assembly.GetExecutingAssembly()
        End Function

        Protected Overrides Function RegresaMnemonico() As String
            'TODO:Cambiar al nemonico correcto 
            Return "FSH"
        End Function

        Protected Overrides Function RegresaNombreTabla() As String
            Return "FOSHist"
        End Function

        Protected Overrides Sub CrearHijos()
            'TODO: Crear los hijos si es necesario
        End Sub

        Public Function FSHCentroExpNombre(ByVal pvCentroExpId As String) As String
            Dim dt As DataTable = vcConexion.EjecutarConsulta("select * from centroexpedicion Where CentroExpId = '" & pvCentroExpId.Replace("'", "''") & "' ")
            dt.TableName = "centroexpedicion"
            If dt Is Nothing Or dt.Rows.Count <= 0 Then Return ""
            Return dt.Rows(0).Item("CentroExpId") + " " + dt.Rows(0).Item("Nombre")

        End Function

        'Public Overrides Function Grabar() As BASLOG.eEstado
        '    If Me.estado = eEstado.Modificado Then
        '        Dim historico As New CFOSHist

        '    End If

        '    Return MyBase.Grabar()
        'End Function

    End Class
End Namespace
