Imports Microsoft.VisualBasic
Imports System.Data
Imports DBConexion

Namespace DBManager

#Region "Enumeradores"

    Public Enum ETipo
        Numerico = 1
        Cadena
        Fecha
        FechaHora
        Binario
        Bit
        MFechaHora
        MUsuarioId
    End Enum

    Public Enum eEstado
        Vacio = 0
        Nuevo
        Modificado
        Recuperado
        Eliminado
    End Enum

#End Region

    '    Public Class cClaseNodo

    '#Region "Variables"
    '        Private oTabla As cTabla
    '        Private tEstado As eEstado
    '        'Private htArrHijos As Hashtable
    '        'Protected htDTHijos As Hashtable
    '#End Region

    '#Region "Propiedades"

    '        Public Property Tabla() As cTabla
    '            Get
    '                Return oTabla
    '            End Get
    '            Set(ByVal Value As cTabla)
    '                oTabla = Value
    '            End Set
    '        End Property

    '        Public Property Status() As eEstado
    '            Get
    '                Return tEstado
    '            End Get
    '            Set(ByVal Value As eEstado)
    '                Me.tEstado = Value
    '            End Set
    '        End Property

    '#End Region

    '#Region "Funciones"
    '        Public Sub Limpiar()
    '            For Each vlCampo As cCampo In oTabla.Campos
    '                If vlCampo.Tipo = ETipo.Numerico Then
    '                    vlCampo.Valor = System.DBNull.Value
    '                Else
    '                    vlCampo.Valor = Nothing
    '                End If
    '            Next

    '            'For Each sNombreHijoEspecifico In htArrHijos.Keys
    '            '    RegresaArregloHijo(sNombreHijoEspecifico).Clear()
    '            '    RegresaDataTableHijo(sNombreHijoEspecifico).Clear()
    '            'Next

    '            tEstado = eEstado.Vacio
    '        End Sub

    '        'Public Sub Recuperar()
    '        '    Dim vlDT As New DataTable
    '        '    Dim vlCampo As cCampo

    '        '    Try
    '        '        vlDT = oTabla.Seleccionar(GenerarFiltroLlave)
    '        '    Catch ex As cError
    '        '        Throw ex
    '        '    End Try

    '        '    If vlDT.Rows.Count = 0 Then
    '        '        Throw New cError("BE0003", New cParametroMSG() {New cParametroMSG("C" & oTabla.NombreTabla, True)})
    '        '    End If

    '        '    For Each vlCampo In oTabla.Campos
    '        '        vlCampo.Valor = vlDT.Rows(0)(vlCampo.Nombre)
    '        '    Next

    '        '    'For Each sNombreHijoEspecifico In htArrHijos.Keys
    '        '    '    RecuperarHijos(sNombreHijoEspecifico)
    '        '    'Next

    '        '    tEstado = eEstado.Recuperado

    '        'End Sub

    '        'Private Function RegresaArregloHijo(ByVal pvNombreHijo As String) As ArrayList
    '        '    Dim oTemp As Object

    '        '    oTemp = htArrHijos(pvNombreHijo)

    '        '    Return CType(oTemp, ArrayList)
    '        'End Function

    '        'Protected Function RegresaDataTableHijo(ByVal pvNombreHijo As String) As DataTable
    '        '    Dim oTemp As Object

    '        '    oTemp = htDTHijos(pvNombreHijo)

    '        '    Return CType(oTemp, DataTable)

    '        'End Function
    '        'Protected Sub RecuperarHijos(ByVal pvNombreHijo As String)
    '        '    Dim oArrHijo As ArrayList
    '        '    Dim oDTHijo, oDTAux As DataTable
    '        '    Dim rHijo As DataRow
    '        '    Dim vlCampo As DBManager.cCampo
    '        '    Dim vlHijo As cClaseNodo
    '        '    Dim vlNombreClaseHijo As String

    '        '    vlNombreClaseHijo = "c" & pvNombreHijo

    '        '    oArrHijo = RegresaArregloHijo(pvNombreHijo)
    '        '    oDTHijo = RegresaDataTableHijo(pvNombreHijo)

    '        '    oArrHijo.Clear()
    '        '    oDTHijo.Clear()

    '        '    vlHijo = CrearInstanciaHijo(vlNombreClaseHijo)

    '        '    oDTAux = vlHijo.Tabla.Seleccionar(GenerarFiltroLlave)

    '        '    For Each rHijo In oDTAux.Rows

    '        '        vlHijo = CrearInstanciaHijo(vlNombreClaseHijo)

    '        '        For Each vlCampo In vlHijo.Tabla.Campos
    '        '            If (vlCampo.LLavePrimaria) Then
    '        '                vlCampo.Valor = rHijo(vlCampo.Nombre)
    '        '            End If
    '        '        Next

    '        '        vlHijo.Recuperar()

    '        '        oArrHijo.Add(vlHijo)
    '        '        oDTHijo.ImportRow(rHijo)

    '        '    Next

    '        'End Sub

    '        'Protected Function CrearInstanciaHijo(ByVal pvNombreClase As String) As cClaseNodo

    '        '    Dim vlEnsamblado As System.Reflection.Assembly
    '        '    Dim vlTipoHijo, vlTipo As Type
    '        '    Dim vlObject As [Object]
    '        '    Dim vlHijo As cClaseNodo

    '        '    'vlEnsamblado = System.Reflection.Assembly.GetExecutingAssembly()
    '        '    'vlEnsamblado = Me.EnsambladoActual

    '        '    'For Each vlTipo In vlEnsamblado.GetTypes
    '        '    '    If (vlTipo.Name.ToLower() = pvNombreClase.ToLower()) Then
    '        '    '        vlTipoHijo = vlTipo
    '        '    '        Exit For
    '        '    '    End If
    '        '    'Next

    '        '    If (Not vlTipoHijo Is Nothing) Then

    '        '        'vlTipoHijo = vlEnsamblado.GetType(pvNombreClase)
    '        '        vlObject = Activator.CreateInstance(vlTipoHijo, New Object() {Me})

    '        '        vlHijo = CType(vlObject, cClaseNodo)

    '        '    End If

    '        '    Return vlHijo

    '        'End Function

    '        Public Overloads Sub Insertar(Optional ByVal pvCampo() As String = Nothing)
    '            Try
    '                ValidarClase(pvCampo)
    '            Catch ex As DBConexion.cError
    '                Throw ex
    '            End Try

    '            tEstado = eEstado.Nuevo
    '        End Sub

    '        Public Sub ValidarClase(ByVal pvCampo() As String)
    '            ValidarCampos(pvCampo)

    '            If (Me.Status = eEstado.Vacio) Then

    '                'If (Me.Tabla.Seleccionar(GenerarFiltroLlave).Rows.Count > 0) Then
    '                '    Throw New DBConexion.cError("BE0002")
    '                'End If

    '            End If

    '        End Sub
    '        Public Sub ValidarCampos(ByVal pvCampo() As String)

    '            If IsNothing(pvCampo) Then
    '                Dim i As Integer

    '                With oTabla
    '                    For i = 0 To .Campos.Count - 1
    '                        Try
    '                            Call ValidaCampo(.Campos(i).Nombre)
    '                        Catch ex As DBConexion.cError
    '                            Throw ex
    '                        End Try
    '                    Next
    '                End With
    '            Else
    '                For Each vlCampo As String In pvCampo
    '                    Try
    '                        Call ValidaCampo(vlCampo)
    '                    Catch ex As DBConexion.cError
    '                        Throw ex
    '                    End Try
    '                Next
    '            End If

    '        End Sub
    '        Protected Sub ValidaCampo(ByVal pvNombre As String)

    '            With oTabla

    '                If .Campos(pvNombre).Requerido Then
    '                    If IsDBNull(.Campos(pvNombre).Valor) Or .Campos(pvNombre).Valor Is Nothing Then
    '                        Throw New DBConexion.cError("BE0001", New DBConexion.cParametroMSG() {New DBConexion.cParametroMSG(.Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
    '                    End If
    '                    If .Campos(pvNombre).Tipo = ETipo.Cadena Then
    '                        If .Campos(pvNombre).Valor = "" Then
    '                            Throw New DBConexion.cError("BE0001", New DBConexion.cParametroMSG() {New DBConexion.cParametroMSG(.Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
    '                        End If
    '                    End If
    '                End If

    '            End With

    '        End Sub

    '        'Protected Overridable Function GenerarFiltroLlave1() As String
    '        '    Dim vlCampo As cCampo
    '        '    Dim bMasDeUnaLlave As Boolean
    '        '    Dim sBuff As System.Text.StringBuilder

    '        '    sBuff = New System.Text.StringBuilder(200)

    '        '    For Each vlCampo In oTabla.Campos

    '        '        If (vlCampo.LlavePrimaria) Then
    '        '            If (bMasDeUnaLlave) Then
    '        '                sBuff.Append(" AND ")
    '        '            End If

    '        '            sBuff.Append(vlCampo.Nombre)
    '        '            sBuff.Append(" = ")
    '        '            sBuff.Append(vlCampo.aFormato(""))

    '        '            bMasDeUnaLlave = True
    '        '        End If

    '        '    Next

    '        '    Return sBuff.ToString
    '        'End Function

    '#End Region

    '    End Class

    '    Public Class cTabla

    '#Region "Variables"
    '        Private vcCampos As New ArrayList
    '        Private sNombreTabla As String

    '#End Region

    '        Public Sub New(ByVal pvNombre As String)
    '            NombreTabla = pvNombre
    '        End Sub

    '#Region "Propiedades"
    '        Public Property Campos(ByVal pvNombre As String) As cCampo
    '            Get
    '                Dim pos As Integer = Posicion(pvNombre)
    '                If pos = -1 Then Return Nothing
    '                Return Campos(pos)
    '            End Get
    '            Set(ByVal Value As cCampo)
    '                Dim pos As Integer = Posicion(pvNombre)
    '                If pos = -1 Then Exit Property
    '                Campos(pos) = Value
    '            End Set
    '        End Property
    '        Public Property Campos() As ArrayList
    '            Get
    '                Return Me.vcCampos
    '            End Get
    '            Set(ByVal Value As ArrayList)
    '                Me.vcCampos = Value
    '            End Set
    '        End Property
    '        Public Property NombreTabla() As String
    '            Get
    '                Return Me.sNombreTabla
    '            End Get
    '            Set(ByVal value As String)
    '                Me.sNombreTabla = value
    '            End Set
    '        End Property
    '#End Region

    '#Region "Funciones"
    '        Private Function Posicion(ByVal pvNombre As String) As Integer
    '            Dim n As Integer
    '            For n = 0 To vcCampos.Count - 1
    '                If TypeOf vcCampos.Item(n) Is cCampo Then
    '                    If CType(vcCampos.Item(n), cCampo).Nombre.ToLower = pvNombre.ToLower Then
    '                        Return n
    '                    End If
    '                End If
    '            Next
    '            Return -1
    '        End Function

    '        Public Function AgregarCampo(ByVal pvCampo As cCampo) As Boolean
    '            vcCampos.Add(pvCampo)
    '        End Function

    '        Public Function Seleccionar(ByVal pvFiltro As String, ByVal pvCampos As String) As DataTable
    '            Try
    '                Dim vlSQL As String = "SELECT " & pvCampos & " FROM " & NombreTabla
    '                If pvFiltro <> "" Then
    '                    vlSQL &= " WHERE " & pvFiltro
    '                End If
    '                'If Conexion.Estado = ConnectionState.Open Then
    '                Dim ins As New DBConexion.cConexionSQL
    '                Dim dt As DataTable = ins.RealizarConsulta(vlSQL)
    '                dt.TableName = NombreTabla
    '                Return dt
    '                'Else
    '                ''     Return Nothing
    '                'Throw New DBConexion.cError("", , "Seleccionar", "La Conexion esta Cerrada", Me.Conexion)
    '                'End If
    '            Catch ex As Exception
    '                Throw New DBConexion.cError("", , "Seleccionar", ex.Message)
    '            End Try
    '        End Function

    '        Public Function Seleccionar(ByVal pvFiltro As String) As DataTable
    '            Return Seleccionar(pvFiltro, "*")
    '        End Function
    '#End Region

    '    End Class


    '    Public Class cCampo

    '#Region "Variables"
    '        Private sNombre As String
    '        Private oValorCampo As Object
    '        Private eTipo As ETipo
    '        Private bLlavePrimaria As Boolean
    '        Private bRequerido As Boolean
    '        Private bUsaDefault As Boolean
    '        Private bLlaveForanea As Boolean
    '#End Region

    '        Public Sub New(ByVal pvNombre As String, ByVal pvTipo As ETipo, ByVal pvValor As Object, _
    '                Optional ByVal pvLlavePrimaria As Boolean = False, Optional ByVal pvRequerido As Boolean = False, _
    '                Optional ByVal pvUsaDefault As Boolean = True, Optional ByVal pvLlaveForanea As Boolean = False)
    '            Nombre = pvNombre
    '            Tipo = pvTipo
    '            Valor = pvValor
    '            LlavePrimaria = pvLlavePrimaria
    '            Requerido = pvRequerido
    '            UsaDefault = pvUsaDefault
    '            LlaveForanea = pvLlaveForanea

    '        End Sub

    '#Region "Propiedades"
    '        Public Property Valor() As Object
    '            Get
    '                Return oValorCampo
    '            End Get
    '            Set(ByVal Value As Object)
    '                oValorCampo = Value
    '            End Set
    '        End Property
    '        Public Property Nombre() As String
    '            Get
    '                Return sNombre
    '            End Get
    '            Set(ByVal value As String)
    '                sNombre = value
    '            End Set
    '        End Property
    '        Public Property Tipo() As ETipo
    '            Get
    '                Return Me.eTipo
    '            End Get
    '            Set(ByVal value As ETipo)
    '                Me.eTipo = value
    '            End Set
    '        End Property
    '        Public Property LlavePrimaria() As Boolean
    '            Get
    '                Return Me.bLlavePrimaria
    '            End Get
    '            Set(ByVal value As Boolean)
    '                Me.bLlavePrimaria = value
    '            End Set
    '        End Property
    '        Public Property Requerido() As Boolean
    '            Get
    '                Return Me.bRequerido
    '            End Get
    '            Set(ByVal value As Boolean)
    '                Me.bRequerido = value
    '            End Set
    '        End Property
    '        Private Property UsaDefault() As Boolean
    '            Get
    '                Return Me.bUsaDefault
    '            End Get
    '            Set(ByVal value As Boolean)
    '                Me.bUsaDefault = value
    '            End Set
    '        End Property
    '        Private Property LlaveForanea() As Boolean
    '            Get
    '                Return Me.bLlaveForanea
    '            End Get
    '            Set(ByVal value As Boolean)
    '                Me.bLlaveForanea = value
    '            End Set
    '        End Property
    '#End Region

    '#Region "Funciones"
    '        'Public Function aFormato1() As String
    '        '    Select Case Tipo
    '        '        Case eTipo.Numerico
    '        '            If IsNumeric(Valor) Then
    '        '                Return CDbl(Valor).ToString.Replace(",", ".")
    '        '            ElseIf UsaDefault Then
    '        '                Return 0
    '        '            Else
    '        '                Return "NULL"
    '        '            End If
    '        '        Case eTipo.Cadena
    '        '            Try
    '        '                If IsDBNull(Valor) Then
    '        '                    Return "NULL"
    '        '                ElseIf IsNothing(Valor) Or Valor = "" Then
    '        '                    If LlaveForanea = True Then
    '        '                        Return "NULL"
    '        '                    Else
    '        '                        Return "''"
    '        '                    End If
    '        '                Else
    '        '                    Return "'" & Valor.ToString & "'"
    '        '                End If
    '        '            Catch ex As Exception
    '        '                If UsaDefault Then
    '        '                    Return "''"
    '        '                Else
    '        '                    Return "Null"
    '        '                End If
    '        '            End Try
    '        '        Case eTipo.Fecha
    '        '            Try
    '        '                Dim vldate As Date
    '        '                vldate = CDate(Valor.ToString)
    '        '                Return "'" & vldate.ToString("yyyy-MM-dd") & "T00:00:00.000'"
    '        '            Catch ex As Exception
    '        '                If UsaDefault Then
    '        '                    Return "'1900-01-01T00:00:00.000'"
    '        '                Else
    '        '                    Return "Null"
    '        '                End If
    '        '            End Try
    '        '        Case eTipo.MFechaHora, eTipo.FechaHora

    '        '            If Me.Tipo = eTipo.MFechaHora Then Me.Valor = DBConexion.cConexionSQL.ObtenerFecha

    '        '            Try
    '        '                If Not Me.Valor Is Nothing Then
    '        '                    Dim vldate As Date
    '        '                    vldate = CDate(Me.Valor)
    '        '                    Return "'" & vldate.ToString("yyyy-MM-dd") & "T" & vldate.ToString("HH:mm:ss.") & vldate.Millisecond.ToString("000") & "'"
    '        '                Else
    '        '                    Throw New Exception
    '        '                End If
    '        '            Catch ex As Exception
    '        '                If UsaDefault Then
    '        '                    Return "'1900-01-01T00:00:00.000'"
    '        '                Else
    '        '                    Return "Null"
    '        '                End If
    '        '            End Try
    '        '        Case eTipo.Bit
    '        '            Try
    '        '                If Valor Then
    '        '                    Return 1
    '        '                Else
    '        '                    Return 0
    '        '                End If
    '        '            Catch ex As Exception
    '        '                Return 0
    '        '            End Try
    '        '        Case eTipo.Binario
    '        '            Try
    '        '                Dim vlBit As Byte
    '        '                If Not IsArray(Valor) OrElse CType(Valor, Array).GetUpperBound(0) < 0 OrElse Not TypeOf CType(Valor, Array)(0) Is Byte Then Return "0x0"
    '        '                Dim vlHex As String
    '        '                Dim vlStrHex As String
    '        '                For Each vlBit In Valor
    '        '                    vlHex &= vlBit.ToString("X2")
    '        '                    'System.Windows.Forms.Application.DoEvents()
    '        '                Next
    '        '                Return "0x" & vlHex
    '        '            Catch ex As Exception
    '        '                Return "0x0"
    '        '            End Try
    '        '        Case eTipo.MUsuarioId

    '        '            Me.Valor = Session("UsuarioID")
    '        '            Try
    '        '                If IsDBNull(Valor) Then
    '        '                    Return "NULL"
    '        '                ElseIf IsNothing(Valor) Or Valor = "" Then
    '        '                    Return "''"
    '        '                Else
    '        '                    Return "'" & Valor.ToString & "'"
    '        '                End If
    '        '            Catch ex As Exception
    '        '                If UsaDefault Then
    '        '                    Return "''"
    '        '                Else
    '        '                    Return "Null"
    '        '                End If
    '        '            End Try
    '        '    End Select
    '        'End Function
    '#End Region

    '    End Class

    Public Class cUsuario
#Region "Variables"
        Private sClave As String
        Private sPERClave As String
        Private sUSUId As String
        Private sClaveAcceso As String
#End Region

#Region "Propiedades"
        Public ReadOnly Property Clave() As String
            Get
                Return sClave
            End Get
        End Property
        Public ReadOnly Property PERClave() As String
            Get
                Return sPERClave
            End Get
        End Property
        Public ReadOnly Property USUId() As String
            Get
                Return sUSUId
            End Get
        End Property
        Public ReadOnly Property ClaveAcceso() As String
            Get
                Return sClaveAcceso
            End Get
        End Property
#End Region

        Public Function RecuperarClave(ByVal pvClave As String) As Boolean
            Dim vlDataTable As DataTable
            Dim ins As New DBConexion.cConexionSQL
            vlDataTable = ins.EjecutarConsulta("Select * from usuario where Clave ='" & pvClave & "'")
            If vlDataTable.Rows.Count > 0 Then
                Return Recuperar(vlDataTable.Rows(0).Item("USUId"))
            Else
                Return False
            End If
        End Function

        Public Function Recuperar(ByVal pvUSUid As String) As Boolean
            Dim ins As New DBConexion.cConexionSQL
            Dim dt As DataTable = ins.EjecutarConsulta("Select * from usuario where USUId ='" & pvUSUid & "' ")

            If dt.Rows.Count <= 0 Then Return False
            With dt.Rows(0)
                sClave = .Item("Clave")
                sPERClave = .Item("PERClave")
                sUSUId = .Item("USUId")
                sClaveAcceso = .Item("ClaveAcceso")
            End With

            Return True
        End Function

        Public Shared Function SimpleCrypt(ByVal Text As String) As String
            ' Encrypts/decrypts the passed string using 
            ' a simple ASCII value-swapping algorithm
            Dim strTempChar As String = ""
            Dim i As Integer
            For i = 1 To Len(Text)
                If Asc(Mid$(Text, i, 1)) < 128 Then
                    strTempChar = CType(Asc(Mid$(Text, i, 1)) + 128, String)
                ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                    strTempChar = CType(Asc(Mid$(Text, i, 1)) - 128, String)
                End If

                Mid$(Text, i, 1) = Chr(CType(strTempChar, Integer))
            Next i
            Return Text
        End Function

    End Class

End Namespace