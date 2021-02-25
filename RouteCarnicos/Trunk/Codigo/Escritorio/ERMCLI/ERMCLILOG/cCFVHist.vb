Public Class cCFVHist
    Private vcCLIFormaVenta As cCLIFormaVenta
    Private vcCFVHist As LbDatos.cTabla
    Private vcEstado As eEstado

#Region "Propiedades"
    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCLIFormaVenta.ClienteClave
        End Get
    End Property

    Friend ReadOnly Property CFVTipo() As Integer
        Get
            Return vcCLIFormaVenta.CFVTipo
        End Get
    End Property

    Public Property CFHFechaInicio() As Date
        Get
            Return vcCFVHist.Campos("CFHFechaInicio").Valor
        End Get
        Set(ByVal Value As Date)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcCFVHist.Campos("CFHFechaInicio").Valor = Value
            End If
        End Set
    End Property

    Public Property LimiteCredito() As Double
        Get
            Return vcCFVHist.Campos("LimiteCredito").Valor
        End Get
        Set(ByVal Value As Double)
            vcCFVHist.Campos("LimiteCredito").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DiasCredito() As Integer
        Get
            Return vcCFVHist.Campos("DiasCredito").Valor
        End Get
        Set(ByVal Value As Integer)
            vcCFVHist.Campos("DiasCredito").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CapturaDias() As Boolean
        Get
            Return vcCFVHist.Campos("CapturaDias").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCFVHist.Campos("CapturaDias").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ValidaLimite() As Boolean
        Get
            Return vcCFVHist.Campos("ValidaLimite").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCFVHist.Campos("ValidaLimite").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ValidaPago() As Boolean
        Get
            Return vcCFVHist.Campos("ValidaPago").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCFVHist.Campos("ValidaPago").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcCFVHist.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcCFVHist.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcCFVHist.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcCFVHist
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

#Region "Funciones"
    Public Sub New(ByRef prCLIFormaVenta As cCLIFormaVenta)
        vcCLIFormaVenta = prCLIFormaVenta
        vcCFVHist = New LbDatos.cTabla("CFVHist")
        With vcCFVHist
            .AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True))
            .AgregarCampo(New LbDatos.cCampo("CFVTipo", LbDatos.ETipo.Numerico, DBNull.Value, True))
            .AgregarCampo(New LbDatos.cCampo("CFHFechaInicio", LbDatos.ETipo.Fecha, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("LimiteCredito", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("DiasCredito", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("CapturaDias", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("ValidaLimite", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("ValidaPago", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))
        End With
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

    Friend Sub Recuperar(ByVal pvCFHfechaInicio As Date)
        Dim vlCFHDataTable As New DataTable
        Dim vlCFHDataRow As DataRow

        Try
            'vlCFHDataTable = vcCFVHist.Seleccionar("ClienteClave='" & vcCLIFormaVenta.ClienteClave & "' AND CFVTipo='" & vcCLIFormaVenta.CFVTipo & "' AND CFHFechaInicio=" & LbConexion.cConexion.Instancia.UniFechaSQL(pvCFHfechaInicio) + "")
            vlCFHDataTable = vcCFVHist.Seleccionar("ClienteClave='" & lbGeneral.ValidaFormatoSQLString(vcCLIFormaVenta.ClienteClave) & "' AND CFVTipo='" & lbGeneral.ValidaFormatoSQLString(vcCLIFormaVenta.CFVTipo) & "' AND CFHFechaInicio='" & pvCFHfechaInicio.ToString("s") + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vlCFHDataTable.Rows.Count = 0) Then
            Exit Sub
        End If

        vlCFHDataRow = vlCFHDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcCFVHist.Campos
            vlCampo.Valor = vlCFHDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcCFVHist.Campos("ClienteClave").Valor = vcCLIFormaVenta.ClienteClave
                    vcCFVHist.Campos("CFVTipo").Valor = vcCLIFormaVenta.CFVTipo
                    vcCFVHist.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcCFVHist.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcCFVHist.Eliminar()
                    vcCLIFormaVenta.CFVHist.Eliminar(Me)
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcCLIFormaVenta.CFVHist.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcCFVHist
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
        With vcCFVHist
            If .Campos(pvNombre).Requerido Then
                If IsDBNull(.Campos(pvNombre).Valor) = True Or IsNothing(.Campos(pvNombre).Valor) = True Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CFV" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CFV" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
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
        vcCFVHist.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcCFVHist.Modificar(prDataTable)
    End Sub
#End Region
End Class


Public Class cCFHTabla
    Private vcCLIFormaVenta As cCLIFormaVenta
    Private vcCFVHist As cCFVHist
    Public Tabla As cCFHDataTable

    Public Sub New(ByRef prCLIFormaVenta As cCLIFormaVenta)
        vcCLIFormaVenta = prCLIFormaVenta
        vcCFVHist = New cCFVHist(vcCLIFormaVenta)
        Tabla = New cCFHDataTable(vcCFVHist)
    End Sub

    Public Property CFHFechaInicio() As Date
        Get
            Return vcCFVHist.CFHFechaInicio
        End Get
        Set(ByVal Value As Date)
            vcCFVHist.CFHFechaInicio = Value
        End Set
    End Property

    Public Property LimiteCredito() As Double
        Get
            Return vcCFVHist.LimiteCredito
        End Get
        Set(ByVal Value As Double)
            vcCFVHist.LimiteCredito = Value
        End Set
    End Property

    Public Property DiasCredito() As Integer
        Get
            Return vcCFVHist.DiasCredito
        End Get
        Set(ByVal Value As Integer)
            vcCFVHist.DiasCredito = Value
        End Set
    End Property

    Public Property CapturaDias() As Boolean
        Get
            Return vcCFVHist.CapturaDias
        End Get
        Set(ByVal Value As Boolean)
            vcCFVHist.CapturaDias = Value
        End Set
    End Property

    Public Property ValidaLimite() As Boolean
        Get
            Return vcCFVHist.ValidaLimite
        End Get
        Set(ByVal Value As Boolean)
            vcCFVHist.ValidaLimite = Value
        End Set
    End Property

    Public Property ValidaPago() As Boolean
        Get
            Return vcCFVHist.ValidaPago
        End Get
        Set(ByVal Value As Boolean)
            vcCFVHist.ValidaPago = Value
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcCFVHist.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcCFVHist.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCLIFormaVenta.vcCFHArrayList.Count
        End Get
    End Property

    Public Function Insertar(ByVal pvCFHFechaInicio As Date, ByVal pvLimiteCredito As Double, ByVal pvDiasCredito As Integer, ByVal pvCapturaDias As Boolean, ByVal pvValidaLimite As Boolean, ByVal pvValidaPago As Boolean, ByVal pvMUsuarioId As String) As Integer
        Me.CFHFechaInicio = pvCFHFechaInicio
        Me.LimiteCredito = pvLimiteCredito
        Me.DiasCredito = pvDiasCredito
        Me.CapturaDias = pvCapturaDias
        Me.ValidaLimite = pvValidaLimite
        Me.ValidaPago = pvValidaPago
        Me.MUsuarioId = pvMUsuarioId
        Try
            Return Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Function Insertar() As Integer
        Try
            vcCFVHist.Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcCLIFormaVenta.vcCFHArrayList.Add(vcCFVHist)
        vcCFVHist = New cCFVHist(vcCLIFormaVenta)
    End Function

    Friend Sub Eliminar(ByVal pvCFVHist As cCFVHist)
        vcCLIFormaVenta.vcCFHArrayList.Remove(pvCFVHist)
    End Sub

    Public Function ToDataTable() As DataTable
        Return vcCLIFormaVenta.vcCFHDataTable
    End Function
End Class

Public Class cCFHDataTable
    Private vcCFVHist As cCFVHist

    Public Sub New(ByRef prCFVHist As cCFVHist)
        vcCFVHist = prCFVHist
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcCFVHist.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcCFVHist.cTabla.GrabarTabla(prDataTable, vcCFVHist.cTabla.Campos)
    End Sub
End Class
