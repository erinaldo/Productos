Public Class cVENCentroDistHist
    Private vcPadre As cVendedor
    Private vcTabla As LbDatos.cTabla
    Private vcEstado As eEstado

    Public Sub New(ByRef prVendedor As cVendedor)
        vcPadre = prVendedor
        vcTabla = New LbDatos.cTabla("VENCentroDistHist")

        With vcTabla
            .AgregarCampo(New LbDatos.cCampo("VendedorId", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("AlmacenId", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("VCHFechaInicial", LbDatos.ETipo.FechaHora, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("FechaFinal", LbDatos.ETipo.FechaHora, ""))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.MUsuarioId, True))
        End With

        vcEstado = eEstado.Vacio
    End Sub

#Region "Propiedades"

    Public ReadOnly Property VendedorId() As String
        Get
            Return vcPadre.VendedorID
        End Get
    End Property

    Public Property AlmacenId() As String
        Get
            Return vcTabla.Campos("AlmacenId").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTabla.Campos("AlmacenId").Valor = Value
            End If
        End Set
    End Property

    Public Property VCHFechaInicial() As Date
        Get
            Return vcTabla.Campos("VCHFechaInicial").Valor
        End Get
        Set(ByVal Value As Date)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTabla.Campos("VCHFechaInicial").Valor = Value
            End If
        End Set
    End Property

    Public Property FechaFinal() As Date
        Get
            Return vcTabla.Campos("FechaFinal").Valor
        End Get
        Set(ByVal Value As Date)
            vcTabla.Campos("FechaFinal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As DateTime
        Get
            Return vcTabla.Campos("MFechaHora").Valor
        End Get
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vcTabla.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vcTabla.Campos("MUsuarioID").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

#End Region

#Region "Funciones"
    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcTabla
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property

    Friend Sub Insertar(Optional ByVal pvCampo() As String = Nothing)
        Try
            ValidarCampos(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
    End Sub

    Friend Sub Recuperar(ByVal pvAlmacenId As String, ByVal pvVCHFechaInicial As Date)
        Dim vcDataTable As DataTable

        Try
            vcDataTable = vcTabla.Seleccionar("VendedorId='" & vcPadre.VendedorID & "' AND AlmacenId='" & pvAlmacenId & "' AND VCHFechaInicial=" & LbConexion.cConexion.Instancia.UniFechaSQL(pvVCHFechaInicial, , "dd/MM/yyyy HH:mm:ss.fff"))
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vcDataTable.Rows.Count = 0) Then
            Exit Sub
        End If

        For Each vlCampo As LbDatos.cCampo In vcTabla.Campos
            vlCampo.Valor = vcDataTable.Rows(0)(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Function Grabar() As eEstado
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcTabla.Campos("VendedorId").Valor = vcPadre.VendedorID
                    vcTabla.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcTabla.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcTabla.Eliminar()
                    vcPadre.VENCentroDistHist.Eliminar(Me)
            End Select
            Return vcEstado
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcPadre.VENCentroDistHist.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcTabla
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


    Private Function ValidaCampo(ByVal pvNombre As String) As Boolean
        With vcTabla
            If .Campos(pvNombre).Requerido Then
                If .Campos(pvNombre).Valor Is Nothing Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VCH" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    Return False
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VCH" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
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
        Return True
    End Function

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcTabla.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcTabla.Modificar(prDataTable)
    End Sub
#End Region

End Class

Public Class cVCHTabla
    Private vcPadre As cVendedor
    Private vcHijo As cVENCentroDistHist
    Public Tabla As cVCHDataTable

    Public Sub New(ByRef prVendedor As cVendedor)
        vcPadre = prVendedor
        vcHijo = New cVENCentroDistHist(vcPadre)
        Tabla = New cVCHDataTable(vcHijo)
    End Sub

#Region "Propiedades"
    Public Property AlmacenId() As String
        Get
            Return vcHijo.AlmacenId
        End Get
        Set(ByVal Value As String)
            vcHijo.AlmacenId = Value
        End Set
    End Property

    Public Property VCHFechaInicial() As Date
        Get
            Return vcHijo.VCHFechaInicial
        End Get
        Set(ByVal Value As Date)
            vcHijo.VCHFechaInicial = Value
        End Set
    End Property

    Public Property FechaFinal() As Date
        Get
            Return vcHijo.FechaFinal
        End Get
        Set(ByVal Value As Date)
            vcHijo.FechaFinal = Value
        End Set
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vcHijo.MUsuarioID
        End Get
        Set(ByVal Value As String)
            vcHijo.MUsuarioID = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcPadre.vcVCHArrayList.Count
        End Get
    End Property
#End Region

#Region "Funciones"

    Public Function Insertar(ByVal pvAlmacenId As String, ByVal pvVCHFechaInicial As Date, ByVal pvFechaFinal As Date, Optional ByVal pvCampo() As String = Nothing) As Boolean
        Me.AlmacenId = pvAlmacenId
        Me.VCHFechaInicial = pvVCHFechaInicial
        Me.FechaFinal = pvFechaFinal
        Try
            Return Insertar(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Function Insertar(Optional ByVal pvCampo() As String = Nothing) As Boolean
        Try
            vcHijo.Insertar(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcPadre.vcVCHArrayList.Add(vcHijo)
        vcHijo = New cVENCentroDistHist(vcPadre)

        Return True
    End Function

    Friend Function Eliminar(ByVal pvVENCentroDistHist As cVENCentroDistHist) As Boolean
        vcPadre.vcVCHArrayList.Remove(pvVENCentroDistHist)
        Return True
    End Function

    Public Function ToDataTable() As DataTable
        Return vcPadre.vcVCHDataTable
    End Function
#End Region

End Class

Public Class cVCHDataTable
    Private vcClase As cVENCentroDistHist

    Public Sub New(ByRef prVENCentroDistHist As cVENCentroDistHist)
        vcClase = prVENCentroDistHist
    End Sub

    Public Function Existe(ByVal pvVendedorId As String, ByVal pvAlmacenId As String, ByVal pvVCHFechaInicial As DateTime) As Boolean
        Dim vlDataTable As DataTable

        vlDataTable = vcClase.cTabla.Seleccionar("VendedorId='" & pvVendedorId & "' AND AlmacenId='" & pvAlmacenId & "' AND VCHFechaInicial=" & LbConexion.cConexion.Instancia.UniFechaSQL(pvVCHFechaInicial, , "dd/MM/yyyy HH:mm:ss.fff"))
        If vlDataTable.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcClase.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcClase.cTabla.GrabarTabla(prDataTable, vcClase.cTabla.Campos)
    End Sub
End Class
