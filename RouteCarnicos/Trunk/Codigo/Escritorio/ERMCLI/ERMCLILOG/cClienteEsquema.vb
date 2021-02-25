Public Class cClienteEsquema
    Private vcCliente As cCliente
    Private vcClienteEsquema As LbDatos.cTabla
    Private vcEstado As eEstado

#Region "Propiedades"
    Public Property ClienteClave() As String
        Get
            Return vcClienteEsquema.Campos("ClienteClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteEsquema.Campos("ClienteClave").Valor = Value
            End If
        End Set
    End Property

    Public Property EsquemaId() As String
        Get
            Return vcClienteEsquema.Campos("EsquemaId").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteEsquema.Campos("EsquemaId").Valor = Value
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClienteEsquema.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcClienteEsquema.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return IIf(IsDBNull(vcClienteEsquema.Campos("TipoEstado").Valor), 0, vcClienteEsquema.Campos("TipoEstado").Valor)
        End Get
        Set(ByVal Value As Integer)
            vcClienteEsquema.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcClienteEsquema.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcClienteEsquema
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
        vcClienteEsquema = New LbDatos.cTabla("ClienteEsquema")
        vcClienteEsquema.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True, True))
        vcClienteEsquema.AgregarCampo(New LbDatos.cCampo("EsquemaId", LbDatos.ETipo.Cadena, "", True, True))
        vcClienteEsquema.AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
        vcClienteEsquema.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, "", False, True))
        vcClienteEsquema.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))
        vcEstado = eEstado.Vacio
    End Sub

    Friend Sub Insertar(Optional ByVal pvCampo() As String = Nothing)
        Try
            If pvCampo.Length > 0 Then
                ValidarCampos(pvCampo)
            Else
                ValidarCampos()
            End If
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
    End Sub

    Public Sub Recuperar(ByVal pvEsquemaId As String)
        Dim vlCLEDataTable As New DataTable
        Dim vlCLEDataRow As DataRow

        Try
            vlCLEDataTable = vcClienteEsquema.Seleccionar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' AND EsquemaId='" + pvEsquemaId + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        If vlCLEDataTable.Rows.Count <= 0 Then
            Exit Sub
        End If
        vlCLEDataRow = vlCLEDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcClienteEsquema.Campos
            vlCampo.Valor = vlCLEDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcClienteEsquema.Campos("ClienteClave").Valor = vcCliente.ClienteClave
                    vcClienteEsquema.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcClienteEsquema.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcClienteEsquema.Eliminar()
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcCliente.ClienteEsquema.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcClienteEsquema
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

        With vcClienteEsquema
            If .Campos(pvNombre).Requerido Then
                If IsDBNull(.Campos(pvNombre).Valor) = True Or IsNothing(.Campos(pvNombre).Valor) = True Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLE" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLE" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                End If
            End If
            Select Case .Campos(pvNombre).Tipo
                Case LbDatos.ETipo.Numerico
                    If .Campos(pvNombre).Valor < 0 Then
                        Throw New LbControlError.cError("E0007", , .Campos(pvNombre).Nombre)
                    End If
            End Select
        End With
    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcClienteEsquema.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcClienteEsquema.Modificar(prDataTable)
    End Sub
#End Region
End Class


Public Class cCLETabla
    Private vcCliente As cCliente
    Private vcClienteEsquema As cClienteEsquema
    Public Tabla As cCLEDataTable

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcClienteEsquema = New cClienteEsquema(vcCliente)
        Tabla = New cCLEDataTable(vcClienteEsquema)
    End Sub

    Public Property EsquemaId() As String
        Get
            Return vcClienteEsquema.EsquemaId
        End Get
        Set(ByVal Value As String)
            vcClienteEsquema.EsquemaId = Value
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcClienteEsquema.TipoEstado
        End Get
        Set(ByVal Value As Integer)
            vcClienteEsquema.TipoEstado = Value
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClienteEsquema.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcClienteEsquema.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCliente.vcCLEArrayList.Count
        End Get
    End Property

    Public Function Insertar(ByVal pvEsquemaId As String, ByVal pvTipoEstado As Integer, ByVal pvMUsuarioId As String, Optional ByVal pvCampo() As String = Nothing) As Integer
        EsquemaId = pvEsquemaId
        TipoEstado = pvTipoEstado
        MUsuarioId = pvMUsuarioId
        Return Insertar(pvCampo)
    End Function

    Public Function Insertar(Optional ByVal pvCampo() As String = Nothing) As Integer
        Try
            vcClienteEsquema.Insertar(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcCliente.vcCLEArrayList.Add(vcClienteEsquema)
        vcClienteEsquema = New cClienteEsquema(vcCliente)
    End Function

    Friend Sub Eliminar(ByVal pvClienteEsquema As cClienteEsquema)
        vcCliente.vcCLEArrayList.Remove(pvClienteEsquema)
    End Sub

    Public Function ToDataTable() As DataTable
        Return vcCliente.vcCLEDataTable
    End Function
End Class

Public Class cCLEDataTable
    Private vcClienteEsquema As cClienteEsquema

    Public Sub New(ByRef prClienteEsquema As cClienteEsquema)
        vcClienteEsquema = prClienteEsquema
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcClienteEsquema.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcClienteEsquema.cTabla.GrabarTabla(prDataTable, vcClienteEsquema.cTabla.Campos)
    End Sub
End Class
