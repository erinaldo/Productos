Public Class cVendedorDescuento
    Private vcVendedor As cVendedor
    Private vcTbVENDescuento As LbDatos.cTabla
    Private vcEstado As eEstado

#Region "Propiedades"

    Public ReadOnly Property VendedorID() As String
        Get
            Return vcVendedor.VendedorID
        End Get
    End Property

    Public Property ModuloMovDetalleClave() As String
        Get
            Return vcTbVENDescuento.Campos("ModuloMovDetalleClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTbVENDescuento.Campos("ModuloMovDetalleClave").Valor = Value
            End If
        End Set
    End Property

    Public Property AplicaProducto() As Boolean
        Get
            Return vcTbVENDescuento.Campos("AplicaProducto").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVENDescuento.Campos("AplicaProducto").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property AplicaVendedor() As Boolean
        Get
            Return vcTbVENDescuento.Campos("AplicaVendedor").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVENDescuento.Campos("AplicaVendedor").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property AplicaCliente() As Boolean
        Get
            Return vcTbVENDescuento.Campos("AplicaCliente").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVENDescuento.Campos("AplicaCliente").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcTbVENDescuento.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbVENDescuento.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vcTbVENDescuento.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vcTbVENDescuento.Campos("MUsuarioID").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As DateTime
        Get
            Return vcTbVENDescuento.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcTbVENDescuento
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

#Region "Funciones"

    Public Sub New(ByRef prVendedor As cVendedor)
        vcVendedor = prVendedor
        vcTbVENDescuento = New LbDatos.cTabla("VendedorDescuento")
        With vcTbVENDescuento
            .AgregarCampo(New LbDatos.cCampo("VendedorID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("ModuloMovDetalleClave", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("AplicaProducto", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("AplicaVendedor", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("AplicaCliente", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.Cadena, True))
        End With
        vcEstado = eEstado.Vacio
    End Sub

    Friend Sub Insertar(Optional ByVal pvCampo() As String = Nothing)
        Try
            ValidarCampos(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
    End Sub


    Friend Sub Recuperar(ByVal pvModuloMovDetalleClave As String)
        Dim vlVEDDataTable As New DataTable
        Dim vlVEDDataRow As DataRow

        Try
            vlVEDDataTable = vcTbVENDescuento.Seleccionar("VendedorID='" + vcVendedor.VendedorID + "' AND ModuloMovDetalleClave='" + pvModuloMovDetalleClave + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If (vlVEDDataTable.Rows.Count = 0) Then
            Exit Sub
        End If
        vlVEDDataRow = vlVEDDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcTbVENDescuento.Campos
            vlCampo.Valor = vlVEDDataRow(vlCampo.Nombre)
        Next
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Grabar()
        Try
            If vcEstado = eEstado.Nuevo Then
                vcTbVENDescuento.Campos("VendedorId").Valor = vcVendedor.VendedorID
            End If
            ValidarCampos()
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcTbVENDescuento.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcTbVENDescuento.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcTbVENDescuento.Eliminar()
                    vcVendedor.VendedorDescuento.Eliminar(Me)
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        If vcEstado = eEstado.Nuevo Then
            vcVendedor.VendedorDescuento.Eliminar(Me)
        Else
            vcEstado = eEstado.Eliminado
        End If
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcTbVENDescuento
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
        With vcTbVENDescuento
            If .Campos(pvNombre).Requerido Then
                If .Campos(pvNombre).Valor Is Nothing Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VED" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    Return False
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VED" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
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
        vcTbVENDescuento.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcTbVENDescuento.Modificar(prDataTable)
    End Sub
#End Region
End Class


Public Class cVEDTabla
    Private vcVendedor As cVendedor
    Private vcVendedorDescuento As cVendedorDescuento
    Public Tabla As cVEDDataTable

    Public Sub New(ByRef prVendedor As cVendedor)
        vcVendedor = prVendedor
        vcVendedorDescuento = New cVendedorDescuento(vcVendedor)
        Tabla = New cVEDDataTable(vcVendedorDescuento)
    End Sub

    Public Property ModuloMovDetalleClave() As String
        Get
            Return vcVendedorDescuento.ModuloMovDetalleClave
        End Get
        Set(ByVal Value As String)
            vcVendedorDescuento.ModuloMovDetalleClave = Value
        End Set
    End Property

    Public Property AplicaProducto() As Boolean
        Get
            Return vcVendedorDescuento.AplicaProducto
        End Get
        Set(ByVal Value As Boolean)
            vcVendedorDescuento.AplicaProducto = Value
        End Set
    End Property

    Public Property AplicaVendedor() As Boolean
        Get
            Return vcVendedorDescuento.AplicaVendedor
        End Get
        Set(ByVal Value As Boolean)
            vcVendedorDescuento.AplicaVendedor = Value
        End Set
    End Property

    Public Property AplicaCliente() As Boolean
        Get
            Return vcVendedorDescuento.AplicaCliente
        End Get
        Set(ByVal Value As Boolean)
            vcVendedorDescuento.AplicaCliente = Value
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcVendedorDescuento.TipoEstado
        End Get
        Set(ByVal Value As Integer)
            vcVendedorDescuento.TipoEstado = Value
        End Set
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vcVendedorDescuento.MUsuarioID
        End Get
        Set(ByVal Value As String)
            vcVendedorDescuento.MUsuarioID = Value
        End Set
    End Property

    Public ReadOnly Property Conteo() As Integer
        Get
            Return vcVendedor.vcVEDArrayList.Count
        End Get
    End Property


    Public Function Insertar(ByVal pvVendedorID As String, ByVal pvModuloMovDetalleClave As String, _
                             ByVal pvAplicaProducto As Boolean, ByVal pvAplicaVendedor As Boolean, ByVal pvAplicaCliente As Boolean, _
                             ByVal pvTipoEstado As Integer, ByVal pvMUsuarioId As String, Optional ByVal pvCampo() As String = Nothing) As Integer
        Me.ModuloMovDetalleClave = pvModuloMovDetalleClave
        Me.AplicaProducto = pvAplicaProducto
        Me.AplicaVendedor = pvAplicaVendedor
        Me.AplicaCliente = pvAplicaCliente
        Me.TipoEstado = pvTipoEstado
        Me.MUsuarioID = pvMUsuarioId
        Try
            Return Insertar(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Function

    Public Function Insertar(Optional ByVal pvCampo() As String = Nothing) As Integer
        Try
            vcVendedorDescuento.Insertar(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Insertar = vcVendedor.vcVEDArrayList.Add(vcVendedorDescuento)
        vcVendedorDescuento = New cVendedorDescuento(vcVendedor)
        Return True
    End Function

    Public Function Existe(ByVal pvModuloMovDetalleClave As String) As Boolean
        Dim vlDtVENDescuento As DataTable

        vlDtVENDescuento = vcVendedorDescuento.cTabla.Seleccionar("VendedorID='" & vcVendedor.VendedorID & "' AND ModuloMovDetalleClave='" & pvModuloMovDetalleClave & "'")
        If vlDtVENDescuento.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Friend Function Eliminar(ByVal pvVendedorDescuento As cVendedorDescuento) As Boolean
        vcVendedor.vcVEDArrayList.Remove(pvVendedorDescuento)
        Return True
    End Function

    Public Function ToDataTable() As DataTable
        Return vcVendedor.vcVEDDataTable
    End Function
End Class


Public Class cVEDDataTable
    Private vcVendedorDescuento As cVendedorDescuento

    Public Sub New(ByRef prVendedorDescuento As cVendedorDescuento)
        vcVendedorDescuento = prVendedorDescuento
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As DataTable

        vlDataTable = vcVendedorDescuento.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcVendedorDescuento.cTabla.GrabarTabla(prDataTable, vcVendedorDescuento.cTabla.Campos)
    End Sub
End Class
