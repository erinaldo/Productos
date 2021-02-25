Public Class cClienteMensaje
    Private vcClienteMensaje As LbDatos.cTabla
    Public Tabla As cCLMTabla
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcEstado As eEstado

#Region "Propiedades"
    Public Property ClienteClave() As String
        Get
            Return vcClienteMensaje.Campos("ClienteClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteMensaje.Campos("ClienteClave").Valor = Value
            End If
        End Set
    End Property

    Public Property MDBMensajeId() As String
        Get
            Return vcClienteMensaje.Campos("MDBMensajeId").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteMensaje.Campos("MDBMensajeId").Valor = Value
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcClienteMensaje.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcClienteMensaje.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClienteMensaje.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcClienteMensaje.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcClienteMensaje.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcClienteMensaje
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

#Region "Funciones"
    Public Sub New()
        vcClienteMensaje = New LbDatos.cTabla("ClienteMensaje")
        Tabla = New cCLMTabla(Me)
        vcClienteMensaje.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True, True))
        vcClienteMensaje.AgregarCampo(New LbDatos.cCampo("MDBMensajeId", LbDatos.ETipo.Cadena, "", True, True))
        vcClienteMensaje.AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
        vcClienteMensaje.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, "", False, True))
        vcClienteMensaje.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Limpiar()
        For Each vlCampo As LbDatos.cCampo In vcClienteMensaje.Campos
            If vlCampo.Tipo = LbDatos.ETipo.Numerico Then
                vlCampo.Valor = System.DBNull.Value
            Else
                vlCampo.Valor = Nothing
            End If
        Next
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Insertar(ByVal pvClienteClave As String, ByVal pvMDBMensajeId As String, ByVal pvTipoEstado As Integer, ByVal pvMUsuarioId As String)
        Call Limpiar()
        ClienteClave = pvClienteClave
        MDBMensajeId = pvMDBMensajeId
        TipoEstado = pvTipoEstado
        MUsuarioId = pvMUsuarioId
        Call Insertar()
    End Sub

    Public Sub Insertar()
        Try
            ValidarCampos()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
    End Sub

    Public Sub Recuperar(ByVal pvClienteClave As String, ByVal pvMDBMensajeId As String)
        Dim vlCLMDataTable As New DataTable
        Dim vlCLMDataRow As DataRow

        Call Limpiar()
        Try
            vlCLMDataTable = vcClienteMensaje.Seleccionar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "' AND MDBMensajeId='" + lbGeneral.ValidaFormatoSQLString(pvMDBMensajeId) + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        If vlCLMDataTable.Rows.Count <= 0 Then
            Exit Sub
        End If
        vlCLMDataRow = vlCLMDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcClienteMensaje.Campos
            vlCampo.Valor = vlCLMDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcClienteMensaje.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcClienteMensaje.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcClienteMensaje.Eliminar()
                    Call Limpiar()
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        vcEstado = eEstado.Eliminado
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcClienteMensaje
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

        With vcClienteMensaje
            If .Campos(pvNombre).Requerido Then
                If IsDBNull(.Campos(pvNombre).Valor) = True Or IsNothing(.Campos(pvNombre).Valor) = True Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLM" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLM" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
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
        vcClienteMensaje.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcClienteMensaje.Modificar(prDataTable)
    End Sub
#End Region
End Class


Public Class cCLMTabla
    Private vcClienteMensaje As cClienteMensaje

    Public Sub New(ByRef prClienteMensaje As cClienteMensaje)
        vcClienteMensaje = prClienteMensaje
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String) As DataTable
        Dim vlDataTable As New DataTable
        vlDataTable = vcClienteMensaje.cTabla.Seleccionar(pvFiltro)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcClienteMensaje.cTabla.GrabarTabla(prDataTable, vcClienteMensaje.cTabla.Campos)
    End Sub
End Class
