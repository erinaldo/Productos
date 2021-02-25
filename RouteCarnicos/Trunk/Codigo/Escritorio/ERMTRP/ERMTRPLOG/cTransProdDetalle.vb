Imports BASLOG

Public Class cTransProdDetalle
    Inherits BASLOG.cClaseNodo

    Protected oColTPDImp As cCollectionTPDImp
    Protected oColTrpPrp As cCollectionTrpPrp
    Protected oColTpdPun As cCollectionTpdPun
    Protected oColTPDDesProdVendedor As cCollectionTPDDesProdVendedor

    Private bSeleccionado As Boolean

    'Private aPromocionRegalo As ArrayList

#Region "Propiedades"

    Public ReadOnly Property TransProdID() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("TransProdID")
        End Get
    End Property

    Public Property TransProdDetalleID() As String
        Get
            Return Me.Tabla.Campos("TransProdDetalleID").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("TransProdDetalleID").Valor = Value
            End If
        End Set
    End Property

    Public Property ProductoClave() As String
        Get
            Return Me.Tabla.Campos("ProductoClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ProductoClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DescuentoClave() As String
        Get
            Return Me.Tabla.Campos("DescuentoClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("DescuentoClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Partida() As Integer
        Get
            Return Me.Tabla.Campos("Partida").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("Partida").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoUnidad() As Integer
        Get
            Return Me.Tabla.Campos("TipoUnidad").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoUnidad").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Cantidad() As Double
        Get
            Return Me.Tabla.Campos("Cantidad").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Cantidad").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Precio() As Double
        Get
            Return Me.Tabla.Campos("Precio").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Precio").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DescuentoPor() As Double
        Get
            Return Math.Round(Me.Tabla.Campos("DescuentoPor").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("DescuentoPor").Valor = Math.Round(Value, 2)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DescuentoImp() As Double
        Get
            Return Math.Round(Me.Tabla.Campos("DescuentoImp").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("DescuentoImp").Valor = Math.Round(Value, 2)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Subtotal() As Double
        Get
            Return Math.Round(Me.Tabla.Campos("Subtotal").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Subtotal").Valor = Math.Round(Value, 2)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Impuesto() As Double
        Get
            Return Math.Round(Me.Tabla.Campos("Impuesto").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Impuesto").Valor = Math.Round(Value, 2)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return Math.Round(Me.Tabla.Campos("Total").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Total").Valor = Math.Round(Value, 2)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Promocion() As Integer
        Get
            Return Me.Tabla.Campos("Promocion").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("Promocion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property PromocionClave() As String
        Get
            Return Me.Tabla.Campos("PromocionClave").Valor
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("PromocionClave").Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property TPDImpuesto() As cCollectionTPDImp
        Get
            Return oColTPDImp
        End Get
    End Property

    Public ReadOnly Property TPDImpuesto(ByVal pvIndex As Integer) As cTPDImpuesto
        Get
            Return oColTPDImp.ToArrayList(pvIndex)
        End Get
    End Property

    Public ReadOnly Property TPDImpuesto(ByVal pvTPDImpuestoID As String) As cTPDImpuesto
        Get
            Dim oArr As ArrayList
            Dim oTDI As cTPDImpuesto

            oArr = Me.RegresaArregloHijo("TPDImpuesto")

            For Each oTDI In oArr
                If oTDI.TPDImpuestoID = pvTPDImpuestoID And oTDI.Status <> eEstado.Eliminado Then
                    Return oTDI
                End If
            Next
            Return Nothing
        End Get
    End Property

    'Public ReadOnly Property TrpPrp() As cCollectionTrpPrp
    '    Get
    '        Return oColTrpPrp
    '    End Get
    'End Property

    'Public ReadOnly Property TrpPrp(ByVal pvTransProdDetalleId As String) As cCollectionTrpPrp
    '    Get
    '        Dim oArr As ArrayList
    '        Dim oTrpPrp As cTrpPrp
    '        Dim oColTP As cCollectionTrpPrp = oColTrpPrp.ToArrayList.Clone()

    '        oArr = Me.RegresaArregloHijo("TrpPrp")

    '        For Each oTrpPrp In oArr
    '            If oTrpPrp.TransProdDetalleID = pvTransProdDetalleId And oTrpPrp.Status <> eEstado.Eliminado Then
    '                oColTP.Insertar(oTrpPrp)
    '            End If
    '        Next

    '        If oColTP.Count > 0 Then
    '            Return oColTP
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property

    Public Function TrpPrp() As cCollectionTrpPrp
        Return oColTrpPrp
    End Function

    Public Function TrpPrp(ByVal pvTransProdId As String, ByVal pvTransProdDetalleId As String, ByVal pvPromocionClave As String) As cTrpPrp
        Dim oArr As ArrayList
        Dim oTrpPrp As cTrpPrp

        oArr = Me.RegresaArregloHijo("TrpPrp")

        For Each oTrpPrp In oArr
            If oTrpPrp.TransProdId = pvTransProdId And oTrpPrp.TransProdDetalleID = pvTransProdDetalleId And oTrpPrp.PromocionClave = pvPromocionClave And oTrpPrp.Status <> eEstado.Eliminado Then
                Return oTrpPrp
            End If
        Next

        Return Nothing
    End Function

    Public Function TPDDesProdVendedor() As cCollectionTPDDesProdVendedor
        Return oColTPDDesProdVendedor
    End Function

    Public Function TPDDesProdVendedor(ByVal pvTransProdId As String, ByVal pvTransProdDetalleId As String) As cTPDDesProdVendedor
        Dim oArr As ArrayList
        Dim oTPDDesProdVendedor As cTPDDesProdVendedor

        oArr = Me.RegresaArregloHijo("TPDDesProdVendedor")

        For Each oTPDDesProdVendedor In oArr
            If oTPDDesProdVendedor.TransProdId = pvTransProdId And oTPDDesProdVendedor.TransProdDetalleID = pvTransProdDetalleId And oTPDDesProdVendedor.Status <> eEstado.Eliminado Then
                Return oTPDDesProdVendedor
            End If
        Next

        Return Nothing
    End Function

    Public Function InsertarTDV(ByVal pvTransProdID As String, ByVal pvTransProdDetalleID As String, ByVal pvDesPor As Decimal, ByVal pvDesImporte As Decimal) As Boolean
        If Me.TransProdDetalleID <> "" Then
            Dim vlTDV As New cTPDDesProdVendedor(Me)
            vlTDV.TransProdId = Me.TransProdID
            If Not vlTDV.Existe(pvTransProdID, pvTransProdDetalleID) Then
                If (IsNothing(TPDDesProdVendedor(pvTransProdID, pvTransProdDetalleID))) Then
                    vlTDV.DesPor = pvDesPor
                    vlTDV.DesImporte = pvDesImporte
                    vlTDV.Insertar(New String(-1) {})
                    TPDDesProdVendedor.Insertar(vlTDV)
                End If
            End If
        End If
        Return True
    End Function

    'Public ReadOnly Property TpdPun() As cCollectionTpdPun
    '    Get
    '        Return oColTpdPun
    '    End Get
    'End Property

    'Public ReadOnly Property TpdPun(ByVal pvTransProdDetalleId As String) As cCollectionTpdPun
    '    Get
    '        Dim oArr As ArrayList
    '        Dim oTpdPun As cTpdPun

    '        Dim oColTP As cCollectionTpdPun = oColTpdPun.ToArrayList.Clone()

    '        oArr = Me.RegresaArregloHijo("TpdPun")

    '        For Each oTpdPun In oArr
    '            If oTpdPun.TransProdDetalleID = pvTransProdDetalleId And oTpdPun.Status <> eEstado.Eliminado Then
    '                oColTP.Insertar(oTpdPun)
    '            End If
    '        Next

    '        If oColTP.Count > 0 Then
    '            Return oColTP
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property

    Public Function TpdPun() As cCollectionTpdPun
        Return oColTpdPun
    End Function


    Public Function TpdPun(ByVal pvTransProdId As String, ByVal pvTransProdDetalleId As String, ByVal pvPromocionClave As String) As cTpdPun
        Dim oArr As ArrayList
        Dim oTpdPun As cTpdPun

        oArr = Me.RegresaArregloHijo("TpdPun")

        For Each oTpdPun In oArr
            If oTpdPun.TransProdId = pvTransProdId And oTpdPun.TransProdDetalleID = pvTransProdDetalleId And oTpdPun.PromocionClave = pvPromocionClave And oTpdPun.Status <> eEstado.Eliminado Then
                Return oTpdPun
            End If
        Next

        Return Nothing
    End Function

    Public Property Seleccionado() As Boolean
        Get
            Return bSeleccionado
        End Get
        Set(ByVal value As Boolean)
            bSeleccionado = value
        End Set
    End Property

    'Public ReadOnly Property PromocionRegalo() As ArrayList
    '    Get
    '        Return aPromocionRegalo
    '    End Get
    'End Property

#End Region

#Region "Constructores"

    Public Sub New(ByRef prPadre As cTransProd)
        MyBase.New(prPadre)
        bSeleccionado = False
    End Sub

#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("TransProdDetalleID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("ProductoClave", LbDatos.ETipo.Cadena, "", False, True, True, True))
            .AgregarCampo(New LbDatos.cCampo("DescuentoClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("TipoUnidad", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Partida", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Cantidad", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Precio", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("DescuentoPor", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("DescuentoImp", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Subtotal", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Impuesto", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Total", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Promocion", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("PromocionClave", LbDatos.ETipo.Cadena, DBNull.Value, False, False, True, False))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()
        Dim vlHijoTPD As cClaseNodo
        Dim vlHijoTRP As cClaseNodo
        Dim vlHijoTPUN As cClaseNodo
        Dim vlHijoTPV As cClaseNodo

        vlHijoTPD = New cTPDImpuesto(Me)
        Me.AgregarHijo(vlHijoTPD.Tabla)
        oColTPDImp = New cCollectionTPDImp(Me.RegresaArregloHijo(vlHijoTPD.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijoTPD.Tabla.NombreTabla), vlHijoTPD.TablaNodo)


        vlHijoTRP = New cTrpPrp(Me)
        Me.AgregarHijo(vlHijoTRP.Tabla)
        oColTrpPrp = New cCollectionTrpPrp(Me.RegresaArregloHijo(vlHijoTRP.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijoTRP.Tabla.NombreTabla), vlHijoTRP.TablaNodo)


        vlHijoTPUN = New cTpdPun(Me)
        Me.AgregarHijo(vlHijoTPUN.Tabla)
        oColTpdPun = New cCollectionTpdPun(Me.RegresaArregloHijo(vlHijoTPUN.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijoTPUN.Tabla.NombreTabla), vlHijoTPUN.TablaNodo)

        vlHijoTPV = New cTPDDesProdVendedor(Me)
        Me.AgregarHijo(vlHijoTPV.Tabla)
        oColTPDDesProdVendedor = New cCollectionTPDDesProdVendedor(Me.RegresaArregloHijo(vlHijoTPV.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijoTPV.Tabla.NombreTabla), vlHijoTPV.TablaNodo)


    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TPD"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TransProdDetalle"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String, ByVal pvTransProdDetalleID As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdID").Valor = pvTransProdID
        Me.TransProdDetalleID = pvTransProdDetalleID
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String, ByVal pvTransProdDetalleID As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "' AND TransProdDetalleID='" & pvTransProdDetalleID & "'").Rows.Count > 0)
    End Function

    Public Overloads Sub Insertar(ByVal pvTransProdDetalleID As String, ByVal pvProductoClave As String, ByVal pvDescuentoClave As String, ByVal pvPartida As Integer, ByVal pvTipoUnidad As Integer, ByVal pvCantidad As Double, ByVal pvPrecio As Double, ByVal pvDescuentoPor As Double, ByVal pvDescuentoImp As Double, ByVal pvSubtotal As Double, ByVal pvImpuesto As Double, ByVal pvTotal As Double, ByVal pvPromocion As Boolean, Optional ByVal pvCampo() As String = Nothing)
        Me.Limpiar()
        Me.TransProdDetalleID = pvTransProdDetalleID
        Me.ProductoClave = pvProductoClave
        Me.DescuentoClave = pvDescuentoClave
        Me.Partida = pvPartida
        Me.TipoUnidad = pvTipoUnidad
        Me.Cantidad = pvCantidad
        Me.Precio = pvPrecio
        Me.DescuentoPor = pvDescuentoPor
        Me.DescuentoImp = pvDescuentoImp
        Me.Subtotal = pvSubtotal
        Me.Impuesto = pvImpuesto
        Me.Total = pvTotal
        Me.Promocion = pvPromocion
        Me.Insertar(pvCampo)
    End Sub

#End Region

#Region "Funciones"
    Public Function ValidarCantidadMax(ByVal pvUsuarioId As String, ByVal pvDiaClave As String, ByVal pvClaveCedi As String, ByRef prCantidadMax As Integer) As Boolean
        Dim sConsulta As String
        sConsulta = "select isnull(sum(TPD.Cantidad), 0) - "
        sConsulta &= "(select isnull(sum(TPD1.Cantidad),0) from TransProd TRP1 inner join TransProdDetalle TPD1 on TRP1.TransProdId = TPD1.TransProdId "
        sConsulta &= "where TRP1.Tipo = 22 and TRP1.TipoFase <> 0 and TRP1.TransProdId <> '" & Me.TransProdID & "' and TRP1.MUsuarioId = '" & pvUsuarioId & "' and TRP1.DiaClave = '" & lbGeneral.ValidaFormatoSQLString(pvDiaClave) & "' and TRP1.Notas = '" & lbGeneral.ValidaFormatoSQLString(pvClaveCedi) & "' "
        sConsulta &= "and TPD1.ProductoClave = TPD.ProductoClave and TPD1.TipoUnidad = TPD.TipoUnidad) as Cantidad "
        sConsulta &= "from TransProd TRP "
        sConsulta &= "inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId "
        sConsulta &= "where (TRP.Tipo = 3 or TRP.Tipo = 9) and TRP.TipoFase = 1 "
        sConsulta &= "and TRP.MUsuarioId = '" & pvUsuarioId & "' and TRP.DiaClave = '" & lbGeneral.ValidaFormatoSQLString(pvDiaClave) & "' "
        sConsulta &= "and TRP.TipoMotivo in (select VAVClave from VARValor where VARCodigo = 'TRPMOT' and Grupo = 'No Venta') "
        sConsulta &= "and ((TRP.Tipo = 9 and TRP.TipoMovimiento = 1) or (TRP.Tipo <> 9)) "
        sConsulta &= "and TPD.ProductoClave = '" & lbGeneral.ValidaFormatoSQLString(Me.ProductoClave) & "' and TPD.TipoUnidad = " & Me.TipoUnidad & " "
        sConsulta &= "group by TPD.ProductoClave, TPD.TipoUnidad "

        prCantidadMax = Me.Tabla.Conexion.EjecutarComandoScalar(sConsulta)
        Return Not (Me.Cantidad > prCantidadMax)
    End Function

    Public Sub TPDImpuestoEliminar()
        Dim arr As ArrayList = Me.TPDImpuesto().ToArrayList().Clone()
        For Each tpdimp As ERMTRPLOG.cTPDImpuesto In arr
            If tpdimp.Status <> eEstado.Eliminado Then
                Me.TPDImpuesto(tpdimp.TPDImpuestoID).Eliminar()
            End If
        Next
    End Sub

    Public Sub EliminarHijos()
        Dim indice As Integer = 0
        If Me.TPDImpuesto.ToArrayList.Count > 0 Then
            For indice = Me.TPDImpuesto.ToArrayList().Count - 1 To 0 Step -1
                Me.TPDImpuesto(indice).Eliminar()
                'Me.TPDImpuesto.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TPDImpuesto().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TPDImpuesto().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TPDImpuesto().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If
        'Dim dt As DataTable = Me.TPDImpuesto().ToDataTable.Copy
        'For Each dr As DataRow In dt.Rows
        '    Me.TPDImpuesto().ToDataTable.Rows.Remove(dr)
        'Next

        If Me.TrpPrp.ToArrayList.Count > 0 Then
            For indice = Me.TrpPrp.ToArrayList().Count - 1 To 0 Step -1
                Dim oTrpPrp As cTrpPrp = Me.TrpPrp.ToArrayList()(indice)
                Me.TrpPrp(oTrpPrp.TransProdId, oTrpPrp.TransProdDetalleID, oTrpPrp.PromocionClave).Eliminar()
                'Me.TrpPrp.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TrpPrp().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TrpPrp().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TrpPrp().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If
        'dt = Me.TrpPrp().ToDataTable.Copy()
        'For Each dr As DataRow In dt.Rows
        '    Me.TrpPrp().ToDataTable.Rows.Remove(dr)
        'Next


        If Me.TpdPun.ToArrayList.Count > 0 Then
            For indice = Me.TpdPun.ToArrayList().Count - 1 To 0 Step -1
                Dim oTpdPun As cTpdPun = Me.TpdPun.ToArrayList()(indice)
                Me.TpdPun(oTpdPun.TransProdId, oTpdPun.TransProdDetalleID, oTpdPun.PromocionClave).Eliminar()
                'Me.TpdPun.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TpdPun().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TpdPun().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TpdPun().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If
        'dt = Me.TpdPun().ToDataTable.Copy()
        'For Each dr As DataRow In dt.Rows
        '    Me.TpdPun().ToDataTable.Rows.Remove(dr)
        'Next
        If Me.TPDDesProdVendedor.ToArrayList.Count > 0 Then
            For indice = Me.TPDDesProdVendedor.ToArrayList().Count - 1 To 0 Step -1
                Dim oTpdDesProdVendedor As cTPDDesProdVendedor = Me.TPDDesProdVendedor.ToArrayList()(indice)
                Me.TPDDesProdVendedor(oTpdDesProdVendedor.TransProdId, oTpdDesProdVendedor.TransProdDetalleID).Eliminar()
                'Me.TpdPun.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TPDDesProdVendedor().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TPDDesProdVendedor().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TPDDesProdVendedor().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If

    End Sub

    Public Sub EliminarHijosSinDesVendedor()
        Dim indice As Integer = 0
        If Me.TPDImpuesto.ToArrayList.Count > 0 Then
            For indice = Me.TPDImpuesto.ToArrayList().Count - 1 To 0 Step -1
                Me.TPDImpuesto(indice).Eliminar()
                'Me.TPDImpuesto.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TPDImpuesto().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TPDImpuesto().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TPDImpuesto().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If
        'Dim dt As DataTable = Me.TPDImpuesto().ToDataTable.Copy
        'For Each dr As DataRow In dt.Rows
        '    Me.TPDImpuesto().ToDataTable.Rows.Remove(dr)
        'Next

        If Me.TrpPrp.ToArrayList.Count > 0 Then
            For indice = Me.TrpPrp.ToArrayList().Count - 1 To 0 Step -1
                Dim oTrpPrp As cTrpPrp = Me.TrpPrp.ToArrayList()(indice)
                Me.TrpPrp(oTrpPrp.TransProdId, oTrpPrp.TransProdDetalleID, oTrpPrp.PromocionClave).Eliminar()
                'Me.TrpPrp.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TrpPrp().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TrpPrp().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TrpPrp().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If
        'dt = Me.TrpPrp().ToDataTable.Copy()
        'For Each dr As DataRow In dt.Rows
        '    Me.TrpPrp().ToDataTable.Rows.Remove(dr)
        'Next


        If Me.TpdPun.ToArrayList.Count > 0 Then
            For indice = Me.TpdPun.ToArrayList().Count - 1 To 0 Step -1
                Dim oTpdPun As cTpdPun = Me.TpdPun.ToArrayList()(indice)
                Me.TpdPun(oTpdPun.TransProdId, oTpdPun.TransProdDetalleID, oTpdPun.PromocionClave).Eliminar()
                'Me.TpdPun.ToArrayList().RemoveAt(indice)
            Next
        End If
        If Me.TpdPun().ToDataTable.Rows.Count > 0 Then
            For indice = Me.TpdPun().ToDataTable.Rows.Count - 1 To 0 Step -1
                Me.TpdPun().ToDataTable.Rows.RemoveAt(indice)
            Next
        End If
        'dt = Me.TpdPun().ToDataTable.Copy()
        'For Each dr As DataRow In dt.Rows
        '    Me.TpdPun().ToDataTable.Rows.Remove(dr)
        'Next

    End Sub

    'Public Function TPDImpuesto2(ByVal pvTPDImpuestoId As String) As cTPDImpuesto
    '    Dim oArr As ArrayList
    '    Dim oTPDImp As cTPDImpuesto

    '    oArr = Me.RegresaArregloHijo("TPDImpuesto")

    '    For Each oTPDImp In oArr
    '        If oTPDImp.TPDImpuestoID = pvTPDImpuestoId And oTPDImp.Status <> eEstado.Eliminado Then
    '            Return oTPDImp
    '        End If
    '    Next

    '    Return Nothing
    'End Function

    Public Shared Function CalcularImpuesto(ByVal pvCliente As ERMCLILOG.cCliente, ByVal sProductoClave As String, ByVal nSubtotal As Double) As Double
        Dim impuesto As New ERMIMPLOG.CImpuesto()

        Dim dtImpuesto As DataTable = impuesto.Tabla.RecuperarTabla(" ImpuestoClave in (select ImpuestoClave from ProductoImpuesto where ProductoClave ='" & sProductoClave & "' and TipoEstado =1 group by ImpuestoClave)  and TipoEstado =1 order by Jerarquia ", "*")
        Dim nTotalImpuesto As Double = 0

        For Each dr As DataRow In dtImpuesto.Rows
            'Dim lTRP As ERMTRPLOG.cTransProd = DirectCast(pvTPD.Padre, ERMTRPLOG.cTransProd)
            'Dim TPDImpuesto As New ERMTRPLOG.cTPDImpuesto(pvTPD)
            'TPDImpuesto.TPDImpuestoID = lbGeneral.cKeyGen.KEYGEN(0)
            'TPDImpuesto.TransProdID = pvTPD.TransProdID

            impuesto.Recuperar(dr("ImpuestoClave").ToString())
            Dim dtImpuestoVig As DataTable = impuesto.Vigencias.RecuperarVigenciasActuales()

            'TPDImpuesto.ImpuestoClave = impuesto.Clave
            If (dtImpuestoVig.Rows.Count > 0) Then
                'Dim sImpuestoPor As String
                Dim nImpuestoImp As Double
                'sImpuestoPor = dtImpuestoVig.Rows(0)("valor").ToString()

                If pvCliente.TipoImpuesto = Convert.ToInt32(dtImpuestoVig.Rows(0)("TipoImpuesto")) Then
                    Select Case impuesto.TipoValor
                        Case 1
                            'Porcentaje
                            Select Case impuesto.TipoAplicacion
                                Case 1
                                    'SubtotalSinImpuestos
                                    nImpuestoImp = (nSubtotal) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100)
                                Case 2
                                    'SubtotalConImpuestos
                                    nImpuestoImp = ((nSubtotal) + nTotalImpuesto) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100)
                            End Select

                        Case 2
                            'Importe
                            nImpuestoImp = dtImpuestoVig.Rows(0)("Valor")
                    End Select
                    nTotalImpuesto += nImpuestoImp
                End If
                'End If
            End If
            impuesto.Limpiar()
        Next

        Return nTotalImpuesto
    End Function


    Public Shared Function CalcularImpuesto(ByVal pvCliente As ERMCLILOG.cCliente, ByVal sProductoClave As String, ByVal nSubtotal As Double, ByVal bSumarImpuestosNoDesglosados As Boolean) As Double
        Dim impuesto As New ERMIMPLOG.CImpuesto()
        Dim nSubtotalTemp As Double = nSubtotal
        Dim dtImpuesto As DataTable = impuesto.Tabla.RecuperarTabla(" ImpuestoClave in (select ImpuestoClave from ProductoImpuesto where ProductoClave ='" & sProductoClave & "' and TipoEstado =1 group by ImpuestoClave)  and TipoEstado =1 order by Jerarquia ", "*")
        Dim nTotalImpuesto As Double = 0

        For Each dr As DataRow In dtImpuesto.Rows
            'Dim lTRP As ERMTRPLOG.cTransProd = DirectCast(pvTPD.Padre, ERMTRPLOG.cTransProd)
            'Dim TPDImpuesto As New ERMTRPLOG.cTPDImpuesto(pvTPD)
            'TPDImpuesto.TPDImpuestoID = lbGeneral.cKeyGen.KEYGEN(0)
            'TPDImpuesto.TransProdID = pvTPD.TransProdID

            impuesto.Recuperar(dr("ImpuestoClave").ToString())
            Dim dtImpuestoVig As DataTable = impuesto.Vigencias.RecuperarVigenciasActuales()

            'TPDImpuesto.ImpuestoClave = impuesto.Clave
            If (dtImpuestoVig.Rows.Count > 0) Then
                'Dim sImpuestoPor As String
                Dim nImpuestoImp As Double
                'sImpuestoPor = dtImpuestoVig.Rows(0)("valor").ToString()

                If pvCliente.TipoImpuesto = Convert.ToInt32(dtImpuestoVig.Rows(0)("TipoImpuesto")) Then

                    Select Case impuesto.TipoValor
                        Case 1
                            'Porcentaje
                            Select Case impuesto.TipoAplicacion
                                Case 1
                                    'SubtotalSinImpuestos
                                    nImpuestoImp = (nSubtotal) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100)
                                Case 2
                                    'SubtotalConImpuestos
                                    nImpuestoImp = ((nSubtotal) + nTotalImpuesto) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100)
                            End Select

                            If pvCliente.CLINoDesImp().ToDataTable.Select("Impuestoclave='" + dr("ImpuestoClave") + "' and       '" + LbConexion.cConexion.Instancia.ObtenerFecha().ToString("s") + "'  >= FechaInicio   and     '" + LbConexion.cConexion.Instancia.ObtenerFecha().ToString("s") + "' <= FechaFin  ").Length > 0 Then
                                If (bSumarImpuestosNoDesglosados) Then
                                    nSubtotal += nImpuestoImp
                                End If

                                nImpuestoImp = 0


                            End If

                        Case 2
                            'Importe
                            nImpuestoImp = dtImpuestoVig.Rows(0)("Valor")
                    End Select
                    nTotalImpuesto += nImpuestoImp
                End If
                'End If
            End If
            impuesto.Limpiar()
        Next

        Return nTotalImpuesto
    End Function

    Public Function CalcularImpuesto(ByVal pvCliente As ERMCLILOG.cCliente, ByVal pvTPD As ERMTRPLOG.cTransProdDetalle) As Double
        Dim impuesto As New ERMIMPLOG.CImpuesto()

        Dim dtImpuesto As DataTable = impuesto.Tabla.RecuperarTabla(" ImpuestoClave in (select ImpuestoClave from ProductoImpuesto where ProductoClave ='" & Convert.ToString(pvTPD.ProductoClave) & "' and TipoEstado =1 group by ImpuestoClave)  and TipoEstado =1 order by Jerarquia ", "*")
        Dim nTotalImpuesto As Double = 0
        Dim nTotalImpuestoPU As Double = 0

        For Each dr As DataRow In dtImpuesto.Rows
            Dim lTRP As ERMTRPLOG.cTransProd = DirectCast(pvTPD.Padre, ERMTRPLOG.cTransProd)
            Dim TPDImpuesto As New ERMTRPLOG.cTPDImpuesto(pvTPD)
            TPDImpuesto.TPDImpuestoID = lbGeneral.cKeyGen.KEYGEN(0)
            TPDImpuesto.TransProdID = pvTPD.TransProdID

            impuesto.Recuperar(dr("ImpuestoClave").ToString())
            Dim dtImpuestoVig As DataTable = impuesto.Vigencias.RecuperarVigenciasActuales()

            TPDImpuesto.ImpuestoClave = impuesto.Clave
            If (dtImpuestoVig.Rows.Count > 0) Then
                TPDImpuesto.ImpuestoPor = dtImpuestoVig.Rows(0)("valor").ToString()

                If pvCliente.TipoImpuesto = Convert.ToInt32(dtImpuestoVig.Rows(0)("TipoImpuesto")) Then
                    Select Case impuesto.TipoValor
                        Case 1
                            'Porcentaje
                            Select Case impuesto.TipoAplicacion
                                Case 1
                                    'SubtotalSinImpuestos
                                    TPDImpuesto.ImpuestoImp = Convert.ToString((pvTPD.Subtotal) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    TPDImpuesto.ImpuestoPU = Convert.ToString((pvTPD.Precio) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    Exit Select
                                Case 2
                                    'SubtotalConImpuestos
                                    TPDImpuesto.ImpuestoImp = Convert.ToString(((pvTPD.Subtotal) + nTotalImpuesto) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    TPDImpuesto.ImpuestoPU = Convert.ToString(((pvTPD.Precio) + nTotalImpuestoPU) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    Exit Select
                            End Select
                            Exit Select

                        Case 2
                            'Importe
                            TPDImpuesto.ImpuestoImp = dtImpuestoVig.Rows(0)("Valor").ToString()
                            TPDImpuesto.ImpuestoPU = dtImpuestoVig.Rows(0)("Valor").ToString()
                            Exit Select
                    End Select

                    'If pvCliente.CLINoDesImp().ToDataTable.Select("Impuestoclave='" + dr("ImpuestoClave") + "' and       '" + LbConexion.cConexion.Instancia.ObtenerFecha().ToString("s") + "'  >= FechaInicio   and     '" + LbConexion.cConexion.Instancia.ObtenerFecha().ToString("s") + "' <= FechaFin  ").Length = 0 Then
                    nTotalImpuesto += Convert.ToDouble(TPDImpuesto.ImpuestoImp)
                    nTotalImpuestoPU += Convert.ToDouble(TPDImpuesto.ImpuestoPU)
                    'End If

                    TPDImpuesto.ImpDesGlb = TPDImpuesto.ImpuestoImp
                    TPDImpuesto.Insertar(New String(-1) {})
                    pvTPD.TPDImpuesto.Insertar(TPDImpuesto)
                End If
                'End If
            End If
            impuesto.Limpiar()
        Next

        Return nTotalImpuesto
    End Function

    Public Function CalcularImpuesto(ByVal pvCliente As ERMCLILOG.cCliente, ByVal pvTPD As ERMTRPLOG.cTransProdDetalle, ByVal sProductoClave As String, ByVal nSubtotal As Double, ByVal nPrecio As Double) As Double
        Dim impuesto As New ERMIMPLOG.CImpuesto()

        Dim dtImpuesto As DataTable = impuesto.Tabla.RecuperarTabla(" ImpuestoClave in (select ImpuestoClave from ProductoImpuesto where ProductoClave ='" & sProductoClave & "' and TipoEstado =1 group by ImpuestoClave)  and TipoEstado =1 order by Jerarquia ", "*")
        Dim nTotalImpuesto As Double = 0
        Dim nTotalImpuestoPU As Double = 0

        For Each dr As DataRow In dtImpuesto.Rows
            Dim lTRP As ERMTRPLOG.cTransProd = DirectCast(pvTPD.Padre, ERMTRPLOG.cTransProd)
            Dim TPDImpuesto As New ERMTRPLOG.cTPDImpuesto(pvTPD)
            TPDImpuesto.TPDImpuestoID = lbGeneral.cKeyGen.KEYGEN(0)
            TPDImpuesto.TransProdID = pvTPD.TransProdID

            impuesto.Recuperar(dr("ImpuestoClave").ToString())
            Dim dtImpuestoVig As DataTable = impuesto.Vigencias.RecuperarVigenciasActuales()

            TPDImpuesto.ImpuestoClave = impuesto.Clave
            If (dtImpuestoVig.Rows.Count > 0) Then
                TPDImpuesto.ImpuestoPor = dtImpuestoVig.Rows(0)("valor").ToString()

                If pvCliente.TipoImpuesto = Convert.ToInt32(dtImpuestoVig.Rows(0)("TipoImpuesto")) Then
                    Select Case impuesto.TipoValor
                        Case 1
                            'Porcentaje
                            Select Case impuesto.TipoAplicacion
                                Case 1
                                    'SubtotalSinImpuestos
                                    TPDImpuesto.ImpuestoImp = Convert.ToString(nSubtotal * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    TPDImpuesto.ImpuestoPU = Convert.ToString(nPrecio * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    Exit Select
                                Case 2
                                    'SubtotalConImpuestos
                                    TPDImpuesto.ImpuestoImp = Convert.ToString((nSubtotal + nTotalImpuesto) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    TPDImpuesto.ImpuestoPU = Convert.ToString((nPrecio + nTotalImpuestoPU) * (Convert.ToDouble(dtImpuestoVig.Rows(0)("Valor")) / 100))
                                    Exit Select
                            End Select
                            Exit Select

                        Case 2
                            'Importe
                            TPDImpuesto.ImpuestoImp = dtImpuestoVig.Rows(0)("Valor").ToString()
                            TPDImpuesto.ImpuestoPU = dtImpuestoVig.Rows(0)("Valor").ToString()
                            Exit Select
                    End Select
                    nTotalImpuesto += Convert.ToDouble(TPDImpuesto.ImpuestoImp)
                    nTotalImpuestoPU += Convert.ToDouble(TPDImpuesto.ImpuestoPU)

                    TPDImpuesto.ImpDesGlb = TPDImpuesto.ImpuestoImp
                    TPDImpuesto.Insertar(New String(-1) {})
                    pvTPD.TPDImpuesto.Insertar(TPDImpuesto)
                End If
                'End If
            End If
            impuesto.Limpiar()
        Next

        Return nTotalImpuesto
    End Function

    Public Function Factor() As Integer
        Dim iFactor As Integer = LbConexion.cConexion.Instancia().EjecutarComandoScalar("Select Factor from ProductoDetalle where ProductoClave ='" + Me.ProductoClave + "' and ProductoDetClave ='" + Me.ProductoClave + "' AND PRUTipoUnidad ='" + Me.TipoUnidad.ToString().Trim() + "' ")

        Return iFactor
    End Function

    Public Sub CrearDetallePedido(ByVal pvProductoClave As String)

    End Sub

    Public Sub ObtenerPrecio()

    End Sub

    'Public Sub AgregarPromocionRegalo(ByVal pvTransProdDetalleRegId As String)
    '    If aPromocionRegalo Is Nothing Then aPromocionRegalo = New ArrayList
    '    If Not aPromocionRegalo.Contains(pvTransProdDetalleRegId) Then
    '        aPromocionRegalo.Add(pvTransProdDetalleRegId)
    '    End If
    'End Sub
#End Region

End Class

Public Class cCollectionTPD
    Inherits cCollectionClaseNodo

    Public Sub New(ByRef prArreglo As ArrayList, ByRef prDT As DataTable, ByRef prTablaTPD As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaTPD)
    End Sub

    Public Overloads Function Insertar(ByRef prTPD As cTransProdDetalle) As Integer
        Return MyBase.Insertar(CType(prTPD, cClaseNodo))
    End Function

    Public Function ValidarCantidades(ByVal pvUsuarioId As String, ByVal pvDiaClave As String, ByVal pvClaveCedi As String, ByRef prPoductoClave As String, ByRef prCantidadMax As Integer) As Boolean
        For Each oTPD As cTransProdDetalle In Me.ToArrayList
            If Not oTPD.ValidarCantidadMax(pvUsuarioId, pvDiaClave, pvClaveCedi, prCantidadMax) Then
                prPoductoClave = oTPD.ProductoClave
                Return False
            End If
        Next
        Return True
    End Function

    Public Function RecuperarTablaConDesVendedor(ByVal parsTransProdID As String) As DataTable
        Dim sConsulta As String
        sConsulta = "Select TPD.*, isnull(TDV.DesPor/100,0) as DesPor, isnull(TDV.DesImporte,0) as DesImporte "
        sConsulta &= "from TransProdDetalle TPD left join TPDDesProdVendedor TDV on TPD.TransProdID = TDV.TransProdId and TPD.TransProdDetalleID = TDV.TransProdDetalleID "
        sConsulta &= "where TPD.TransProdID ='" & parsTransProdID & "'"

        Return MyBase.TablaNodo.Tabla.Conexion.EjecutarConsulta(sConsulta)

    End Function

End Class