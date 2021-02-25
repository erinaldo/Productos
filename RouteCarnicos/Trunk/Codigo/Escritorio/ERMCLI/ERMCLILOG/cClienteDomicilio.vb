Public Class cClienteDomicilio
    Private vcCliente As cCliente
    Private vcClienteDomicilio As LbDatos.cTabla
    Private vcEstado As eEstado

#Region "Propiedades"
    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCliente.ClienteClave
        End Get
    End Property

    Public Property ClienteDomicilioId() As String
        Get
            Return vcClienteDomicilio.Campos("ClienteDomicilioId").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteDomicilio.Campos("ClienteDomicilioId").Valor = Value
            End If
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return vcClienteDomicilio.Campos("Tipo").Valor
        End Get
        Set(ByVal Value As Integer)
            vcClienteDomicilio.Campos("Tipo").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Calle() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("Calle").Valor), String.Empty, vcClienteDomicilio.Campos("Calle").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Calle").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Numero() As String
        Get
            'Return IIf(IsDBNull(vcCliente.Campos("Numero").Valor), String.Empty, vcCliente.Campos("IdElectronico").Valor)
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("Numero").Valor), String.Empty, vcClienteDomicilio.Campos("Numero").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Numero").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumInt() As String
        Get
            'Return IIf(IsDBNull(vcCliente.Campos("Numero").Valor), String.Empty, vcCliente.Campos("IdElectronico").Valor)
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("NumInt").Valor), String.Empty, vcClienteDomicilio.Campos("NumInt").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("NumInt").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CodigoPostal() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("CodigoPostal").Valor), String.Empty, vcClienteDomicilio.Campos("CodigoPostal").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("CodigoPostal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ReferenciaDom() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("ReferenciaDom").Valor), String.Empty, vcClienteDomicilio.Campos("ReferenciaDom").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("ReferenciaDom").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("Colonia").Valor), String.Empty, vcClienteDomicilio.Campos("Colonia").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Colonia").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("Localidad").Valor), String.Empty, vcClienteDomicilio.Campos("Localidad").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Localidad").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Poblacion() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("Poblacion").Valor), String.Empty, vcClienteDomicilio.Campos("Poblacion").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Poblacion").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Entidad() As String
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("Entidad").Valor), String.Empty, vcClienteDomicilio.Campos("Entidad").Valor)
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Entidad").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Pais() As String
        Get
            Return vcClienteDomicilio.Campos("Pais").Valor
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("Pais").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CoordenadaX() As Double
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("CoordenadaX").Valor), Nothing, vcClienteDomicilio.Campos("CoordenadaX").Valor)
        End Get
        Set(ByVal Value As Double)
            If Value = 0.0 Then
                vcClienteDomicilio.Campos("CoordenadaX").Valor = System.DBNull.Value
            Else
                vcClienteDomicilio.Campos("CoordenadaX").Valor = Value
            End If
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CoordenadaY() As Double
        Get
            Return IIf(IsDBNull(vcClienteDomicilio.Campos("CoordenadaY").Valor), Nothing, vcClienteDomicilio.Campos("CoordenadaY").Valor)
        End Get
        Set(ByVal Value As Double)
            If Value = 0.0 Then
                vcClienteDomicilio.Campos("CoordenadaY").Valor = System.DBNull.Value
            Else
                vcClienteDomicilio.Campos("CoordenadaY").Valor = Value
            End If
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClienteDomicilio.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcClienteDomicilio.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcClienteDomicilio
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

#Region "Funciones"
    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcClienteDomicilio = New LbDatos.cTabla("ClienteDomicilio")
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("ClienteDomicilioId", LbDatos.ETipo.Cadena, "", True))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, True))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Calle", LbDatos.ETipo.Cadena, True))        
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Numero", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("NumInt", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("CodigoPostal", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("ReferenciaDom", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Colonia", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Localidad", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Poblacion", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Entidad", LbDatos.ETipo.Cadena, False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("Pais", LbDatos.ETipo.Cadena, True))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("CoordenadaX", LbDatos.ETipo.Numerico, False, , , False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("CoordenadaY", LbDatos.ETipo.Numerico, False, , , False))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, True))
        vcClienteDomicilio.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))
        vcEstado = eEstado.Vacio
    End Sub

    Friend Sub Insertar()
        Try
            ValidarCampos()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
    End Sub

    Friend Sub Recuperar(ByVal pvClienteDomicilioId As String)
        Dim vlCLDDataTable As New DataTable
        Dim vlCLDDataRow As DataRow

        Try
            vlCLDDataTable = vcClienteDomicilio.Seleccionar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' AND ClienteDomicilioId='" + lbGeneral.ValidaFormatoSQLString(pvClienteDomicilioId) + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vlCLDDataTable.Rows.Count = 0) Then
            Exit Sub
        End If
        vlCLDDataRow = vlCLDDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcClienteDomicilio.Campos
            If (vlCampo.Nombre = "CoordenadaX" Or vlCampo.Nombre = "CoordenadaY") AndAlso Not IsDBNull(vlCLDDataRow(vlCampo.Nombre)) AndAlso vlCLDDataRow(vlCampo.Nombre) = 0.0 Then
                vlCampo.Valor = System.DBNull.Value
            Else
                vlCampo.Valor = vlCLDDataRow(vlCampo.Nombre)
            End If
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcClienteDomicilio.Campos("ClienteClave").Valor = vcCliente.ClienteClave
                    vcClienteDomicilio.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcClienteDomicilio.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcClienteDomicilio.Eliminar()
                    vcCliente.ClienteDomicilio.Eliminar(Me)
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcCliente.ClienteDomicilio.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcClienteDomicilio
                For i = 0 To .Campos.Count - 1
                    Try
                        Call ValidaCampo(.Campos(i).Nombre)
                    Catch ex As LbControlError.cError
                        Throw ex
                    End Try
                Next
            End With
        Else
            For Each vlCampo As String In pvCampo
                Try
                    Call ValidaCampo(vlCampo)
                Catch ex As LbControlError.cError
                    Throw ex
                End Try
            Next
        End If
    End Sub

    Private Sub ValidaCampo(ByVal pvNombre As String)

        'TODO: modificado
        If vcClienteDomicilio.Campos(pvNombre).Nombre = "Tipo" Then
            Select Case vcClienteDomicilio.Campos(pvNombre).Valor.ToString()
                Case "1"
                    vcClienteDomicilio.Campos("CodigoPostal").Requerido = True
                    vcClienteDomicilio.Campos("Poblacion").Requerido = True
                    vcClienteDomicilio.Campos("Entidad").Requerido = True
                Case "2"
                    vcClienteDomicilio.Campos("CodigoPostal").Requerido = False
                    vcClienteDomicilio.Campos("Poblacion").Requerido = False
                    vcClienteDomicilio.Campos("Entidad").Requerido = False
            End Select
        End If

        If vcClienteDomicilio.Campos(pvNombre).Requerido Then
            If IsDBNull(vcClienteDomicilio.Campos(pvNombre).Valor) = True Or IsNothing(vcClienteDomicilio.Campos(pvNombre).Valor) = True Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLD" + vcClienteDomicilio.Campos(pvNombre).Nombre, True)}, vcClienteDomicilio.Campos(pvNombre).Nombre)
            End If
            If vcClienteDomicilio.Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                If vcClienteDomicilio.Campos(pvNombre).Valor = "" Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLD" + vcClienteDomicilio.Campos(pvNombre).Nombre, True)}, vcClienteDomicilio.Campos(pvNombre).Nombre)
                End If
            End If
        End If
        Select Case vcClienteDomicilio.Campos(pvNombre).Tipo
            Case LbDatos.ETipo.Numerico
                If Not IsNumeric(vcClienteDomicilio.Campos(pvNombre).Valor) And Not IsDBNull(vcClienteDomicilio.Campos(pvNombre).Valor) Then
                    Throw New LbControlError.cError("E0553", , vcClienteDomicilio.Campos(pvNombre).Nombre)
                End If
                If pvNombre <> "CoordenadaX" AndAlso pvNombre <> "CoordenadaY" AndAlso vcClienteDomicilio.Campos(pvNombre).Valor < 0 Then
                    Throw New LbControlError.cError("E0007", , vcClienteDomicilio.Campos(pvNombre).Nombre)
                End If
        End Select

    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcClienteDomicilio.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcClienteDomicilio.Modificar(prDataTable)
    End Sub
#End Region
End Class

Public Class cCLDTabla
    Private vcCliente As cCliente
    Private vcClienteDomicilio As cClienteDomicilio
    Public Tabla As cCLDDataTable

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcClienteDomicilio = New cClienteDomicilio(vcCliente)
        Tabla = New cCLDDataTable(vcClienteDomicilio)
    End Sub

    Public Property ClienteDomicilioId() As String
        Get
            Return vcClienteDomicilio.ClienteDomicilioId
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.ClienteDomicilioId = Value
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return vcClienteDomicilio.Tipo
        End Get
        Set(ByVal Value As Integer)
            vcClienteDomicilio.Tipo = Value
        End Set
    End Property

    Public Property Calle() As String
        Get
            Return vcClienteDomicilio.Calle
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Calle = Value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return vcClienteDomicilio.Numero
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Numero = Value
        End Set
    End Property

    Public Property NumInt() As String
        Get
            Return vcClienteDomicilio.NumInt
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.NumInt = Value
        End Set
    End Property

    Public Property CodigoPostal() As String
        Get
            Return vcClienteDomicilio.CodigoPostal
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.CodigoPostal = Value
        End Set
    End Property
    Public Property ReferenciaDom() As String
        Get
            Return vcClienteDomicilio.ReferenciaDom
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.ReferenciaDom = Value
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return vcClienteDomicilio.Colonia
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Colonia = Value
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return vcClienteDomicilio.Localidad
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Localidad = Value
        End Set
    End Property
    Public Property Poblacion() As String
        Get
            Return vcClienteDomicilio.Poblacion
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Poblacion = Value
        End Set
    End Property
    Public Property Entidad() As String
        Get
            Return vcClienteDomicilio.Entidad
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Entidad = Value
        End Set
    End Property
    Public Property Pais() As String
        Get
            Return vcClienteDomicilio.Pais
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.Pais = Value
        End Set
    End Property

    Public Property CoordenadaX() As Double
        Get
            Return vcClienteDomicilio.CoordenadaX
        End Get
        Set(ByVal Value As Double)
            If Value = 0.0 Then
                vcClienteDomicilio.CoordenadaX = Nothing
            Else
                vcClienteDomicilio.CoordenadaX = Value
            End If
        End Set
    End Property

    Public Property CoordenadaY() As Double
        Get
            Return vcClienteDomicilio.CoordenadaY
        End Get
        Set(ByVal Value As Double)
            If Value = 0.0 Then
                vcClienteDomicilio.CoordenadaY = Nothing
            Else
                vcClienteDomicilio.CoordenadaY = Value
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClienteDomicilio.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcClienteDomicilio.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCliente.vcCLDArrayList.Count
        End Get
    End Property

    Public Function Insertar(ByVal pvClienteDomicilioId As String, ByVal pvTipo As Integer, ByVal pvCalle As String, ByVal pvNumero As String, ByVal pvCodigoPostal As String, ByVal pvColonia As String, _
    ByVal pvPoblacion As String, ByVal pvEntidad As String, ByVal pvPais As String, ByVal pvMUsuarioId As String) As Integer
        ClienteDomicilioId = pvClienteDomicilioId
        Tipo = pvTipo
        Calle = pvCalle
        Numero = pvNumero
        CodigoPostal = pvCodigoPostal
        Colonia = pvColonia
        Poblacion = pvPoblacion
        Entidad = pvEntidad
        Pais = pvPais
        MUsuarioId = pvMUsuarioId
        Try
            Return Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Function Insertar() As Integer
        Try
            If (vcCliente.VerificarDomicilioFiscalUnico Or vcClienteDomicilio.Tipo <> 1) Then

                vcClienteDomicilio.Insertar()
            Else
                Throw New LbControlError.cError("E0479")
            End If

        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcCliente.vcCLDArrayList.Add(vcClienteDomicilio)
        vcClienteDomicilio = New cClienteDomicilio(vcCliente)
    End Function

    Friend Sub Eliminar(ByVal pvClienteDomicilio As cClienteDomicilio)
        vcCliente.vcCLDArrayList.Remove(pvClienteDomicilio)
    End Sub

    Public Function ToDataTable() As DataTable
        Return vcCliente.vcCLDDataTable
    End Function
End Class

Public Class cCLDDataTable
    Private vcClienteDomicilio As cClienteDomicilio

    Public Sub New(ByRef prClienteDomicilio As cClienteDomicilio)
        vcClienteDomicilio = prClienteDomicilio
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcClienteDomicilio.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcClienteDomicilio.cTabla.GrabarTabla(prDataTable, vcClienteDomicilio.cTabla.Campos)
    End Sub
End Class
