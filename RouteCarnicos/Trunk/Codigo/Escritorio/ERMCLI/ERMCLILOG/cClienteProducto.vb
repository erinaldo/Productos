Public Class cClienteProducto
    Private vcClienteProducto As LbDatos.cTabla
    Public Tabla As cCPRTabla
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcEstado As eEstado

#Region "Propiedades"
    Public Property ClienteClave() As String
        Get
            Return vcClienteProducto.Campos("ClienteClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteProducto.Campos("ClienteClave").Valor = Value
            End If
        End Set
    End Property

    Public Property ProductoClave() As String
        Get
            Return vcClienteProducto.Campos("ProductoClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClienteProducto.Campos("ProductoClave").Valor = Value
            End If
        End Set
    End Property

    Public Property Saldo() As Integer
        Get
            Return vcClienteProducto.Campos("Saldo").Valor
        End Get
        Set(ByVal Value As Integer)
            vcClienteProducto.Campos("Saldo").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClienteProducto.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcClienteProducto.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcClienteProducto.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcClienteProducto
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

    Public Sub New()
        vcClienteProducto = New LbDatos.cTabla("ClienteProducto")
        Tabla = New cCPRTabla(Me)
        vcClienteProducto.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True, True))
        vcClienteProducto.AgregarCampo(New LbDatos.cCampo("ProductoClave", LbDatos.ETipo.Cadena, "", True, True))
        vcClienteProducto.AgregarCampo(New LbDatos.cCampo("Saldo", LbDatos.ETipo.Numerico, True))
        vcClienteProducto.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, "", False, True))
        vcClienteProducto.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Limpiar()
        For Each vlCampo As LbDatos.cCampo In vcClienteProducto.Campos
            If vlCampo.Tipo = LbDatos.ETipo.Numerico Then
                vlCampo.Valor = System.DBNull.Value
            Else
                vlCampo.Valor = Nothing
            End If
        Next
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Insertar(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvSaldo As Double, ByVal pvMUsuarioId As String)
        Call Limpiar()
        ClienteClave = pvClienteClave
        ProductoClave = pvProductoClave
        Saldo = pvSaldo
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

    Public Sub Recuperar(ByVal pvClienteClave As String, ByVal pvProductoClave As String)
        Dim vlCPRDataTable As New DataTable
        Dim vlCPRDataRow As DataRow

        Call Limpiar()
        Try
            vlCPRDataTable = vcClienteProducto.Seleccionar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "' AND ProductoClave='" + lbGeneral.ValidaFormatoSQLString(pvProductoClave) + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        If vlCPRDataTable.Rows.Count <= 0 Then
            Exit Sub
        End If
        vlCPRDataRow = vlCPRDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcClienteProducto.Campos
            vlCampo.Valor = vlCPRDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcClienteProducto.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcClienteProducto.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcClienteProducto.Eliminar()
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
            With vcClienteProducto
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

        With vcClienteProducto
            If .Campos(pvNombre).Requerido Then
                If IsDBNull(.Campos(pvNombre).Valor) = True Or IsNothing(.Campos(pvNombre).Valor) = True Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CPR" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CPR" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
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
        vcClienteProducto.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcClienteProducto.Modificar(prDataTable)
    End Sub
End Class


Public Class cCPRTabla
    Private vcClienteProducto As cClienteProducto

    Public Sub New(ByRef prClienteProducto As cClienteProducto)
        vcClienteProducto = prClienteProducto
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String) As DataTable
        Dim vlDataTable As New DataTable
        vlDataTable = vcClienteProducto.cTabla.Seleccionar(pvFiltro)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcClienteProducto.cTabla.GrabarTabla(prDataTable, vcClienteProducto.cTabla.Campos)
    End Sub
End Class
