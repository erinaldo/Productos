Public Class cCLINoDesImp
    Private vcCliente As cCliente
    Private vcCLINoDesImp As LbDatos.cTabla
    Private vcEstado As eEstado
  
    'CNDI
#Region "Propiedades"
    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCliente.ClienteClave
        End Get
    End Property

    Public Property ImpuestoClave() As String
        Get
            Return vcCLINoDesImp.Campos("ImpuestoClave").Valor
        End Get
        Set(ByVal value As String)
            vcCLINoDesImp.Campos("ImpuestoClave").Valor = value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            ElseIf vcEstado = eEstado.Vacio Then
                vcEstado = eEstado.Nuevo
            End If
        End Set
    End Property

    Public Property CNDIID() As String
        Get
            Return vcCLINoDesImp.Campos("CNDIID").Valor
        End Get
        Set(ByVal Value As String)
            vcCLINoDesImp.Campos("CNDIID").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            ElseIf vcEstado = eEstado.Vacio Then
                vcEstado = eEstado.Nuevo
            End If
        End Set
    End Property


    Public Property FechaInicio() As DateTime
        Get
            Return vcCLINoDesImp.Campos("FechaInicio").Valor
        End Get
        Set(ByVal Value As DateTime)
            vcCLINoDesImp.Campos("FechaInicio").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            ElseIf vcEstado = eEstado.Vacio Then
                vcEstado = eEstado.Nuevo
            End If
        End Set
    End Property


    Public Property FechaFin() As DateTime
        Get
            Return vcCLINoDesImp.Campos("FechaFin").Valor
        End Get
        Set(ByVal Value As DateTime)
            vcCLINoDesImp.Campos("FechaFin").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            ElseIf vcEstado = eEstado.Vacio Then
                vcEstado = eEstado.Nuevo
            End If
        End Set
    End Property


    Public Property MUsuarioId() As String
        Get
            Return vcCLINoDesImp.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcCLINoDesImp.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            ElseIf vcEstado = eEstado.Vacio Then
                vcEstado = eEstado.Nuevo
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As DateTime
        Get
            Return vcCLINoDesImp.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcCLINoDesImp
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
        'CNDIID               ClienteClave     ImpuestoClave FechaInicio             FechaFin                MFechaHora              MUsuarioID
        vcCLINoDesImp = New LbDatos.cTabla("CLINoDesImp")
        With vcCLINoDesImp
            .AgregarCampo(New LbDatos.cCampo("CNDIID", LbDatos.ETipo.Cadena, True, True, True, ))
            .AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("ImpuestoClave", LbDatos.ETipo.Cadena, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("FechaInicio", LbDatos.ETipo.FechaHora, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("FechaFin", LbDatos.ETipo.FechaHora, True, False, True))
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

    Public Sub Recuperar(ByVal parsCNDIID As String)
        Dim vlCNDIDataTable As New DataTable
        Dim vlCNDIDataRow As DataRow


        Try
            vlCNDIDataTable = vcCLINoDesImp.Seleccionar("CNDIID='" & parsCNDIID & "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vlCNDIDataTable.Rows.Count = 0) Then
            Exit Sub
        End If

        vlCNDIDataRow = vlCNDIDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcCLINoDesImp.Campos
            vlCampo.Valor = vlCNDIDataRow(vlCampo.Nombre)
        Next



        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcCLINoDesImp.Campos("ClienteClave").Valor = vcCliente.ClienteClave
                    vcCLINoDesImp.Campos("MUsuarioID").Valor = lbGeneral.cParametros.UsuarioID
                    vcCLINoDesImp.Insertar()
                    
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcCLINoDesImp.Campos("MUsuarioID").Valor = lbGeneral.cParametros.UsuarioID
                    vcCLINoDesImp.Modificar()

                    vcEstado = eEstado.Recuperado
                Case eEstado.Recuperado
                  
                    'Case eEstado.Eliminado

                    '    vcCLINoDesImp.Eliminar()
                    '    vcCliente.CLINoDesImp.Eliminar(Me)
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    'Public Sub Eliminar()
    '    If vcEstado = eEstado.Nuevo Then
    '        vcCliente.CLINoDesImp.Eliminar(Me)
    '    Else
    '        vcEstado = eEstado.Eliminado
    '    End If
    'End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcCLINoDesImp
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
        With vcCLINoDesImp
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
        vcCLINoDesImp.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcCLINoDesImp.Modificar(prDataTable)
    End Sub

#End Region
End Class

Public Class cCNDITabla
    Private vcCliente As cCliente
    Private vcCLINoDesImp As cCLINoDesImp
    Public Tabla As cCNDIDataTable

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcCLINoDesImp = New cCLINoDesImp(vcCliente)
        Tabla = New cCNDIDataTable(vcCLINoDesImp)
    End Sub

    Public Property ImpuestoClave() As String
        Get
            Return vcCLINoDesImp.ImpuestoClave
        End Get
        'Set(ByVal Value As String)
        '    vcCLINoDesImp.ImpuestoClave = Value
        'End Set
        Set(ByVal value As String)

        End Set
    End Property


    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCliente.ClienteClave
        End Get
    End Property

    

    Public Property CNDIID() As String
        Get
            Return vcCLINoDesImp.CNDIID
        End Get
        Set(ByVal Value As String)
            vcCLINoDesImp.CNDIID = Value
        End Set
    End Property


    Public Property FechaInicio() As DateTime
        Get
            Return vcCLINoDesImp.FechaInicio
        End Get
        Set(ByVal Value As DateTime)
            vcCLINoDesImp.FechaInicio = Value
        End Set
    End Property


    Public Property FechaFin() As DateTime
        Get
            Return vcCLINoDesImp.FechaFin
        End Get
        Set(ByVal Value As DateTime)
            vcCLINoDesImp.FechaFin = Value
        End Set
    End Property
  
    Public Property MUsuarioId() As String
        Get
            Return vcCLINoDesImp.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcCLINoDesImp.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCliente.vcCFVArrayList.Count
        End Get
    End Property

    'Public Function Insertar(ByVal pvImpuestoClave As String, ByVal pvMUsuarioId As String) As Integer
    '    Me.ImpuestoClave = pvImpuestoClave
    '    'Me.LimiteCredito = pvLimiteCredito
    '    'Me.DiasCredito = pvDiasCredito
    '    'Me.Inicial = pvInicial
    '    'Me.CapturaDias = pvCapturaDias
    '    'Me.ValidaLimite = pvValidaLimite
    '    'Me.ValidaPago = pvValidaPago

    '    Me.MUsuarioId = pvMUsuarioId
    '    Try
    '        Return Insertar()
    '    Catch ex As LbControlError.cError
    '        Throw ex
    '    End Try
    'End Function

    'Public Function Insertar() As Integer
    '    Try
    '        vcCLINoDesImp.Insertar()
    '    Catch ex As LbControlError.cError
    '        Throw ex
    '    End Try
    '    Insertar = vcCliente.vcCFVArrayList.Add(vcCLINoDesImp)
    '    vcCLINoDesImp = New cCLINoDesImp(vcCliente)
    'End Function

    'Friend Sub Eliminar(ByVal pvCLINoDesImp As cCLINoDesImp)
    '    vcCliente.vcCFVArrayList.Remove(pvCLINoDesImp)
    'End Sub

    Public Function ToDataTable() As DataTable
        Return vcCliente.vcCNDIDataTable
    End Function
End Class

Public Class cCNDIDataTable
    Private vcCLINoDesImp As cCLINoDesImp

    Public Sub New(ByRef pvCLINoDesImp As cCLINoDesImp)
        vcCLINoDesImp = pvCLINoDesImp
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcCLINoDesImp.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcCLINoDesImp.cTabla.GrabarTabla(prDataTable, vcCLINoDesImp.cTabla.Campos)
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        vcCLINoDesImp.ValidarCampos(pvCampo)
    End Sub
End Class
