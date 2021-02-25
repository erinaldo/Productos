Public Class cCLIFormaVenta
    Private vcCliente As cCliente
    Private vcCLIFormaVenta As LbDatos.cTabla
    Private vcEstado As eEstado
    Friend vcCFHArrayList As New ArrayList
    Friend vcCFHDataTable As New DataTable
    Private vcCFHTabla As cCFHTabla

#Region "Propiedades"
    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCliente.ClienteClave
        End Get
    End Property

    Public Property CFVTipo() As Integer
        Get
            Return vcCLIFormaVenta.Campos("CFVTipo").Valor
        End Get
        Set(ByVal Value As Integer)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcCLIFormaVenta.Campos("CFVTipo").Valor = Value
            End If
        End Set
    End Property

    Public Property LimiteCredito() As Double
        Get
            Return vcCLIFormaVenta.Campos("LimiteCredito").Valor
        End Get
        Set(ByVal Value As Double)
            vcCLIFormaVenta.Campos("LimiteCredito").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DiasCredito() As Integer
        Get
            Return vcCLIFormaVenta.Campos("DiasCredito").Valor
        End Get
        Set(ByVal Value As Integer)
            vcCLIFormaVenta.Campos("DiasCredito").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Inicial() As Boolean
        Get
            Return vcCLIFormaVenta.Campos("Inicial").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.Campos("Inicial").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CapturaDias() As Boolean
        Get
            Return vcCLIFormaVenta.Campos("CapturaDias").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.Campos("CapturaDias").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ValidaLimite() As Boolean
        Get
            Return vcCLIFormaVenta.Campos("ValidaLimite").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.Campos("ValidaLimite").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ValidaPago() As Boolean
        Get
            Return vcCLIFormaVenta.Campos("ValidaPago").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.Campos("ValidaPago").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Estado() As Integer
        Get
            Return vcCLIFormaVenta.Campos("Estado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcCLIFormaVenta.Campos("Estado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcCLIFormaVenta.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcCLIFormaVenta.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcCLIFormaVenta.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcCLIFormaVenta
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
        vcCFHTabla = New cCFHTabla(Me)
        vcCFHDataTable = CFVHist.Tabla.Recuperar("ClienteClave=''")
        vcCLIFormaVenta = New LbDatos.cTabla("CLIFormaVenta")
        With vcCLIFormaVenta
            .AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True))
            .AgregarCampo(New LbDatos.cCampo("CFVTipo", LbDatos.ETipo.Numerico, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("LimiteCredito", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("DiasCredito", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Inicial", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("CapturaDias", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("ValidaLimite", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("ValidaPago", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("Estado", LbDatos.ETipo.Numerico, True))
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

    Friend Sub Recuperar(ByVal pvCFVTipo As Integer)
        Dim vlCFVDataTable As New DataTable
        Dim vlCFVDataRow As DataRow
        Dim vlCFVHist As New cCFVHist(Me)
        Dim vlCFVHistDT As New cCFHDataTable(vlCFVHist)

        Try
            vlCFVDataTable = vcCLIFormaVenta.Seleccionar("ClienteClave='" & lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) & "' AND CFVTipo='" & lbGeneral.ValidaFormatoSQLString(pvCFVTipo) & "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vlCFVDataTable.Rows.Count = 0) Then
            Exit Sub
        End If

        vlCFVDataRow = vlCFVDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcCLIFormaVenta.Campos
            vlCampo.Valor = vlCFVDataRow(vlCampo.Nombre)
        Next

        vcCFHArrayList.Clear()
        vcCFHDataTable.Clear()
        vcCFHDataTable = vlCFVHistDT.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' AND CFVTipo='" & lbGeneral.ValidaFormatoSQLString(pvCFVTipo) & "'")
        For Each vlCFHDataRow As DataRow In vcCFHDataTable.Rows
            Dim vlCFHDataRow1 As New cCFVHist(Me)
            vlCFHDataRow1.Recuperar(vlCFHDataRow("CFHFechaInicio"))
            vcCFHArrayList.Add(vlCFHDataRow1)
        Next

        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcCLIFormaVenta.Campos("ClienteClave").Valor = vcCliente.ClienteClave
                    vcCLIFormaVenta.Insertar()
                    For Each vlCFVHist As cCFVHist In vcCFHArrayList
                        vlCFVHist.Grabar()
                    Next
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcCLIFormaVenta.Modificar()
                    For i As Integer = 0 To vcCFHArrayList.Count - 1
                        If vcCFHArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCFHArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    vcEstado = eEstado.Recuperado
                Case eEstado.Recuperado
                    For i As Integer = 0 To vcCFHArrayList.Count - 1
                        If vcCFHArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCFHArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                Case eEstado.Eliminado
                    For i As Integer = 0 To vcCFHArrayList.Count - 1
                        If vcCFHArrayList(i).cEstado = eEstado.Modificado Or vcCFHArrayList(i).cEstado = eEstado.Recuperado Or vcCFHArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCFHArrayList(i).Eliminar()
                            If vcCFHArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCFHArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    vcCLIFormaVenta.Eliminar()
                    vcCliente.CLIFormaVenta.Eliminar(Me)
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcCliente.CLIFormaVenta.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcCLIFormaVenta
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
        With vcCLIFormaVenta
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
        vcCLIFormaVenta.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcCLIFormaVenta.Modificar(prDataTable)
    End Sub

    Function CFVHist() As cCFHTabla
        Return vcCFHTabla
    End Function

    Function CFVHist(ByVal pvIndex As Integer) As cCFVHist
        Dim vlCFVHist As cCFVHist
        While 1
            vlCFVHist = vcCFHArrayList(pvIndex)
            If vlCFVHist.cEstado <> eEstado.Eliminado Then
                Return vcCFHArrayList(pvIndex)
            Else
                pvIndex = pvIndex + 1
            End If
        End While
        Return Nothing
    End Function

    Function CFVHist(ByVal pvCFHFechaInicio As Date) As cCFVHist
        For Each vcCFVHist As cCFVHist In vcCFHArrayList
            If vcCFVHist.CFHFechaInicio = pvCFHFechaInicio Then
                Return vcCFVHist
            End If
        Next
        Return Nothing
    End Function
#End Region
End Class

Public Class cCFVTabla
    Private vcCliente As cCliente
    Private vcCLIFormaVenta As cCLIFormaVenta
    Public Tabla As cCFVDataTable

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcCLIFormaVenta = New cCLIFormaVenta(vcCliente)
        Tabla = New cCFVDataTable(vcCLIFormaVenta)
    End Sub

    Public Property CFVTipo() As Integer
        Get
            Return vcCLIFormaVenta.CFVTipo
        End Get
        Set(ByVal Value As Integer)
            vcCLIFormaVenta.CFVTipo = Value
        End Set
    End Property

    Public Property LimiteCredito() As Double
        Get
            Return vcCLIFormaVenta.LimiteCredito
        End Get
        Set(ByVal Value As Double)
            vcCLIFormaVenta.LimiteCredito = Value
        End Set
    End Property

    Public Property DiasCredito() As Integer
        Get
            Return vcCLIFormaVenta.DiasCredito
        End Get
        Set(ByVal Value As Integer)
            vcCLIFormaVenta.DiasCredito = Value
        End Set
    End Property

    Public Property Inicial() As Boolean
        Get
            Return vcCLIFormaVenta.Inicial
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.Inicial = Value
        End Set
    End Property

    Public Property CapturaDias() As Boolean
        Get
            Return vcCLIFormaVenta.CapturaDias
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.CapturaDias = Value
        End Set
    End Property

    Public Property ValidaLimite() As Boolean
        Get
            Return vcCLIFormaVenta.ValidaLimite
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.ValidaLimite = Value
        End Set
    End Property

    Public Property ValidaPago() As Boolean
        Get
            Return vcCLIFormaVenta.ValidaPago
        End Get
        Set(ByVal Value As Boolean)
            vcCLIFormaVenta.ValidaPago = Value
        End Set
    End Property
    Public Property Estado() As Integer
        Get
            Return vcCLIFormaVenta.Estado
        End Get
        Set(ByVal Value As Integer)
            vcCLIFormaVenta.Estado = Value
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcCLIFormaVenta.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcCLIFormaVenta.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCliente.vcCFVArrayList.Count
        End Get
    End Property

    Public Function Insertar(ByVal pvCFVTipo As Integer, ByVal pvLimiteCredito As Double, ByVal pvDiasCredito As Integer, ByVal pvInicial As Boolean, ByVal pvCapturaDias As Boolean, ByVal pvValidaLimite As Boolean, ByVal pvValidaPago As Boolean, ByVal pvEstado As Integer, ByVal pvMUsuarioId As String) As Integer
        Me.CFVTipo = pvCFVTipo
        Me.LimiteCredito = pvLimiteCredito
        Me.DiasCredito = pvDiasCredito
        Me.Inicial = pvInicial
        Me.CapturaDias = pvCapturaDias
        Me.ValidaLimite = pvValidaLimite
        Me.ValidaPago = pvValidaPago
        Me.Estado = pvEstado
        Me.MUsuarioId = pvMUsuarioId
        Try
            Return Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Function Insertar() As Integer
        Try
            vcCLIFormaVenta.Insertar()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcCliente.vcCFVArrayList.Add(vcCLIFormaVenta)
        vcCLIFormaVenta = New cCLIFormaVenta(vcCliente)
    End Function

    Friend Sub Eliminar(ByVal pvCLIFormaVenta As cCLIFormaVenta)
        vcCliente.vcCFVArrayList.Remove(pvCLIFormaVenta)
    End Sub

    Public Function ToDataTable() As DataTable
        Return vcCliente.vcCFVDataTable
    End Function
End Class

Public Class cCFVDataTable
    Private vcCLIFormaVenta As cCLIFormaVenta

    Public Sub New(ByRef prCLIFormaVenta As cCLIFormaVenta)
        vcCLIFormaVenta = prCLIFormaVenta
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcCLIFormaVenta.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcCLIFormaVenta.cTabla.GrabarTabla(prDataTable, vcCLIFormaVenta.cTabla.Campos)
    End Sub
End Class
