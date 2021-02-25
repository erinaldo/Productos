Public Class cClientePago
    Private vcCliente As cCliente
    Private vcClientePago As LbDatos.cTabla
    Private vcEstado As eEstado

    Private sGrupo As String

#Region "Propiedades"
    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCliente.ClienteClave
        End Get
    End Property

    Public Property ClientePagoId() As String
        Get
            Return vcClientePago.Campos("ClientePagoId").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcClientePago.Campos("ClientePagoId").Valor = Value
            End If
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return vcClientePago.Campos("Tipo").Valor
        End Get
        Set(ByVal Value As Integer)
            vcClientePago.Campos("Tipo").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Grupo() As String
        Get
            Return sGrupo
        End Get
        Set(ByVal Value As String)
            sGrupo = Value
        End Set
    End Property

    Public Property TipoBanco() As Integer
        Get
            Return vcClientePago.Campos("TipoBanco").Valor
        End Get
        Set(ByVal Value As Integer)
            vcClientePago.Campos("TipoBanco").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Cuenta() As String
        Get
            Return vcClientePago.Campos("Cuenta").Valor
        End Get
        Set(ByVal Value As String)
            vcClientePago.Campos("Cuenta").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcClientePago.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcClientePago.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClientePago.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcClientePago.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcClientePago.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcClientePago
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
        vcClientePago = New LbDatos.cTabla("ClientePago")
        vcClientePago.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("ClientePagoId", LbDatos.ETipo.Cadena, "", True))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, True))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("TipoBanco", LbDatos.ETipo.Numerico, System.DBNull.Value, False, False, False))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("Cuenta", LbDatos.ETipo.Cadena, False))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, True))
        vcClientePago.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))
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

    Friend Sub Recuperar(ByVal pvClientePagoId As String)
        Dim vlCLPDataTable As New DataTable
        Dim vlCLPDataRow As DataRow

        Try
            vlCLPDataTable = vcClientePago.Seleccionar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' AND ClientePagoId='" + lbGeneral.ValidaFormatoSQLString(pvClientePagoId) + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vlCLPDataTable.Rows.Count = 0) Then
            Exit Sub
        End If
        vlCLPDataRow = vlCLPDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcClientePago.Campos
            vlCampo.Valor = vlCLPDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcClientePago.Campos("ClienteClave").Valor = vcCliente.ClienteClave
                    vcClientePago.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcClientePago.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcClientePago.Eliminar()
                    vcCliente.ClientePago.Eliminar(Me)
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcCliente.ClientePago.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcClientePago
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
        With vcClientePago

            If .Campos(pvNombre).Requerido Or (Grupo <> "E" And (pvNombre = "TipoBanco" Or pvNombre = "Cuenta")) Then
                If IsDBNull(.Campos(pvNombre).Valor) = True Or IsNothing(.Campos(pvNombre).Valor) = True Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLP" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLP" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                End If
            End If
            Select Case .Campos(pvNombre).Tipo
                Case LbDatos.ETipo.Numerico
                    If IsDBNull(.Campos(pvNombre).Valor) = False Then
                        If .Campos(pvNombre).Valor < 0 Then
                            Throw New LbControlError.cError("E0007", , .Campos(pvNombre).Nombre)
                        End If
                    End If
            End Select
        End With
    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcClientePago.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcClientePago.Modificar(prDataTable)
    End Sub
#End Region
End Class


Public Class cCLPTabla
    Private vcCliente As cCliente
    Private vcClientePago As cClientePago
    Public Tabla As cCLPDataTable

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcClientePago = New cClientePago(vcCliente)
        Tabla = New cCLPDataTable(vcClientePago)
    End Sub

    Public Property ClientePagoId() As String
        Get
            Return vcClientePago.ClientePagoId
        End Get
        Set(ByVal Value As String)
            vcClientePago.ClientePagoId = Value
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return vcClientePago.Tipo
        End Get
        Set(ByVal Value As Integer)
            vcClientePago.Tipo = Value
        End Set
    End Property

    Public Property Grupo() As String
        Get
            Return vcClientePago.Grupo
        End Get
        Set(ByVal Value As String)
            vcClientePago.Grupo = Value
        End Set
    End Property
    Public Property TipoBanco() As Integer
        Get
            Return vcClientePago.TipoBanco
        End Get
        Set(ByVal Value As Integer)
            vcClientePago.TipoBanco = Value
        End Set
    End Property

    Public Property Cuenta() As String
        Get
            Return vcClientePago.Cuenta
        End Get
        Set(ByVal Value As String)
            vcClientePago.Cuenta = Value
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcClientePago.TipoEstado
        End Get
        Set(ByVal Value As Integer)
            vcClientePago.TipoEstado = Value
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcClientePago.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcClientePago.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCliente.vcCLpArrayList.Count
        End Get
    End Property

    Public Function Insertar(ByVal pvClientePagoId As String, ByVal pvTipo As Integer, ByVal pvTipoBanco As Integer, ByVal pvCuenta As String, ByVal pvTipoEstado As Integer, ByVal pvMUsuarioId As String) As Integer
        ClientePagoId = pvClientePagoId
        Tipo = pvTipo
        TipoBanco = pvTipoBanco
        Cuenta = pvCuenta
        TipoEstado = pvTipoEstado
        MUsuarioId = pvMUsuarioId
        Try
            Return Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Function Insertar() As Integer
        Try
            vcClientePago.Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcCliente.vcCLPArrayList.Add(vcClientePago)
        vcClientePago = New cClientePago(vcCliente)
    End Function

    Friend Sub Eliminar(ByVal pvClientePago As cClientePago)
        vcCliente.vcCLPArrayList.Remove(pvClientePago)
    End Sub

    Public Function ToDataTable() As DataTable
        Return vcCliente.vcCLPDataTable
    End Function
End Class

Public Class cCLPDataTable
    Private vcClientePago As cClientePago

    Public Sub New(ByRef prClientePago As cClientePago)
        vcClientePago = prClientePago
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcClientePago.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcClientePago.cTabla.GrabarTabla(prDataTable, vcClientePago.cTabla.Campos)
    End Sub
End Class
