Public Class cCLIConfNumCta
    Private vcCliente As cCliente
    Private vcCLIConfNumCta As LbDatos.cTabla
    Private vcEstado As eEstado
    Private bSeleccionado As Boolean

#Region "Propiedades"

    Friend ReadOnly Property ClienteClave() As String
        Get
            Return vcCliente.ClienteClave
        End Get
    End Property
    'Public Property ClienteClave() As String
    '    Get
    '        Return vcCLIConfNumCta.Campos("ClienteClave").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
    '            vcCLIConfNumCta.Campos("ClienteClave").Valor = Value
    '        End If
    '    End Set
    'End Property

    Public Property Campo() As Integer
        Get
            Return vcCLIConfNumCta.Campos("Campo").Valor
        End Get
        Set(ByVal Value As Integer)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcCLIConfNumCta.Campos("Campo").Valor = Value
            End If
        End Set
    End Property

    Public Property Orden() As Integer
        Get
            Return vcCLIConfNumCta.Campos("Orden").Valor
        End Get
        Set(ByVal Value As Integer)
            vcCLIConfNumCta.Campos("Orden").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcCLIConfNumCta.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcCLIConfNumCta.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcCLIConfNumCta.Campos("MFechaHora").Valor
        End Get
    End Property

    Public Property Seleccionado() As Boolean
        Get
            Return bSeleccionado
        End Get
        Set(ByVal Value As Boolean)
            bSeleccionado = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Estado() As eEstado
        Get
            Return vcEstado
        End Get
        Set(ByVal value As eEstado)
            vcEstado = value
        End Set
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcCLIConfNumCta
        End Get
    End Property


#End Region

#Region "Funciones"
    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcCLIConfNumCta = New LbDatos.cTabla("CLIConfNumCta")
        vcCLIConfNumCta.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True, True))
        vcCLIConfNumCta.AgregarCampo(New LbDatos.cCampo("Campo", LbDatos.ETipo.Numerico, True, True))
        vcCLIConfNumCta.AgregarCampo(New LbDatos.cCampo("Orden", LbDatos.ETipo.Numerico, True))
        vcCLIConfNumCta.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, "", False, True))
        vcCLIConfNumCta.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))

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

    Public Sub Recuperar(ByVal pvCampoC As String)
        Dim vlCCNCDataTable As New DataTable
        Dim vlCCNCDataRow As DataRow

        Try
            Dim lsQuery As String

            lsQuery = "select '" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' as ClienteClave,isnull(CNC.Campo,Val.VavClave) as Campo,CNC.Orden as Orden,isnull(CNC.MFechaHora,getdate()) as MFechaHora,isnull(CNC.MUsuarioId,'Admin') as MUsuarioId,case when (Val.VavClave=1 or Val.VavClave=3) then 1 else cast(case when CNC.Campo is null then 0 else 1 end as bit) end as Seleccion, case when CNC.Campo is null then 0 else 1 end as Recuperado " & _
            "from VarValor VAL " & _
            "left join CliConfNumCta CNC on CNC.campo = VAL.VavClave and CNC.ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "'" & _
            "where Val.VarCodigo='CONFCTA' and isnull(CNC.Campo,Val.VavClave)='" + pvCampoC + "'"

            vlCCNCDataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(lsQuery)

        Catch ex As LbControlError.cError
            Throw ex
        End Try
        If vlCCNCDataTable.Rows.Count <= 0 Then
            Exit Sub
        End If
        vlCCNCDataRow = vlCCNCDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcCLIConfNumCta.Campos
            vlCampo.Valor = vlCCNCDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcCLIConfNumCta.Campos("ClienteClave").Valor = vcCliente.ClienteClave
                    vcCLIConfNumCta.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcCLIConfNumCta.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcCLIConfNumCta.Eliminar()
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcCliente.CLIConfNumCta().Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcCLIConfNumCta
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
        With vcCLIConfNumCta
            If .Campos(pvNombre).Requerido Then
                If IsDBNull(.Campos(pvNombre).Valor) = True Or IsNothing(.Campos(pvNombre).Valor) = True Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CCNC" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CCNC" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                End If
            End If
            Select Case .Campos(pvNombre).Tipo
                Case LbDatos.ETipo.Numerico
                    If .Campos(pvNombre).Valor < 0 Then
                        Throw New LbControlError.cError("E0553", , .Campos(pvNombre).Nombre)
                    End If
            End Select
        End With
    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcCLIConfNumCta.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcCLIConfNumCta.Modificar(prDataTable)
    End Sub
#End Region
End Class


Public Class cCCNCTabla
    Private vcCliente As cCliente
    Private vcCLIConfNumCta As cCLIConfNumCta
    Public Tabla As cCCNCDataTable

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
        vcCLIConfNumCta = New cCLIConfNumCta(vcCliente)
        Tabla = New cCCNCDataTable(vcCLIConfNumCta)
    End Sub

    Public Property CampoC() As String
        Get
            Return vcCLIConfNumCta.Campo
        End Get
        Set(ByVal Value As String)
            vcCLIConfNumCta.Campo = Value
        End Set
    End Property

    Public Property Orden() As Integer
        Get
            Return vcCLIConfNumCta.Orden
        End Get
        Set(ByVal Value As Integer)
            vcCLIConfNumCta.Orden = Value
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcCLIConfNumCta.MUsuarioId
        End Get
        Set(ByVal Value As String)
            vcCLIConfNumCta.MUsuarioId = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcCliente.vcCCNCArrayList.Count
        End Get
    End Property

    Public Function Insertar(ByVal pvCampoC As String, ByVal pvOrden As Integer, ByVal pvMUsuarioId As String, Optional ByVal pvCampo() As String = Nothing) As Integer
        CampoC = pvCampoC
        Orden = pvOrden
        MUsuarioId = pvMUsuarioId
        Return Insertar(pvCampo)
    End Function

    Public Function Insertar(Optional ByVal pvCampo() As String = Nothing) As Integer
        Try
            vcCLIConfNumCta.Insertar(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcCliente.vcCCNCArrayList.Add(vcCLIConfNumCta)
        vcCLIConfNumCta = New cCLIConfNumCta(vcCliente)
    End Function

    Friend Sub Eliminar(ByVal pvCLIConfNumCta As cCLIConfNumCta)
        vcCliente.vcCCNCArrayList.Remove(pvCLIConfNumCta)
    End Sub

    Public Function ToDataTable() As DataTable
        Return vcCliente.vcCCNCDataTable
    End Function
End Class

Public Class cCCNCDataTable
    Private vcCLIConfNumCta As cCLIConfNumCta

    Public Sub New(ByRef prCLIConfNumCta As cCLIConfNumCta)
        vcCLIConfNumCta = prCLIConfNumCta
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        Dim lsQuery As String
        lsQuery = "select '" + lbGeneral.ValidaFormatoSQLString(pvFiltro) + "' as ClienteClave,isnull(CNC.Campo,Val.VavClave) as Campo,CNC.Orden as Orden,isnull(CNC.MFechaHora,getdate()) as MFechaHora,isnull(CNC.MUsuarioId,'Admin') as MUsuarioId,case when (Val.VavClave=1 or Val.VavClave=3) then 1 else cast(case when CNC.Campo is null then 0 else 1 end as bit) end as Seleccion, case when CNC.Campo is null then 0 else 1 end as Recuperado " & _
        "from VarValor Val " & _
        "left join CliConfNumCta CNC on CNC.campo = VAL.VavClave and CNC.ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvFiltro) + "'" & _
        "where Val.VarCodigo='CONFCTA' "

        vlDataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(lsQuery)
        Return vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcCLIConfNumCta.cTabla.GrabarTabla(prDataTable, vcCLIConfNumCta.cTabla.Campos)
    End Sub
End Class
