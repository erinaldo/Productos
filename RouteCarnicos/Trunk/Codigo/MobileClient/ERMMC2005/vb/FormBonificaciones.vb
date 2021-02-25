Public Class FormBonificaciones
    Public Event GuardarDetalleBonificacion(ByRef refparoFormBonificaciones As FormBonificaciones)

    Private _tipoBonificacion As TipoBonificacion
    Private _ProductoClave As String
    Private _CodigoSKU As String
    Private _TipoUnidad As Integer
    Private _Precio As Decimal
    Private _CantidadPedido As Decimal
    Private _Cantidad1Pedido As Decimal
    Private _FactorPedido As Decimal
    Private _Factor1Pedido As Decimal
    Private _TotalPedido As Decimal
    Private _TransProdIDPedido As String
    Private _TransProdDetalleIDPedido As String
    Private _sTransProdIDBon As String
    Private _tipoPedido As TipoPedido
    Private _MermaSKU As Decimal = 0
    Private _DescuentoInicial As Decimal = 0
    Private _ImpuestoPedido As Decimal
    Private _UnidadCobranza As Integer
    Private _MonedaId As String
    Private blnEditandoDescuento As Boolean = False
    Private blnIniciandoCampos As Boolean = False

    Private refaVista As Vista

    Public ReadOnly Property TipoBonificacion() As TipoBonificacion
        Get
            Return _tipoBonificacion
        End Get
    End Property

    Public Property TipoPedido() As TipoPedido
        Get
            Return _tipoPedido
        End Get
        Set(ByVal value As TipoPedido)
            _tipoPedido = value
        End Set
    End Property

    Public Property TransProdDetalleIDPedido() As String
        Get
            Return _TransProdDetalleIDPedido
        End Get
        Set(ByVal value As String)
            _TransProdDetalleIDPedido = value
        End Set
    End Property

    Public Property TransProdIDPedido() As String
        Get
            Return _TransProdIDPedido
        End Get
        Set(ByVal value As String)
            _TransProdIDPedido = value
        End Set
    End Property

    Public Property ProductoClave() As String
        Get
            Return _ProductoClave
        End Get
        Set(ByVal value As String)
            _ProductoClave = value
        End Set
    End Property

    Public Property CodigoSKU() As String
        Get
            Return _CodigoSKU
        End Get
        Set(ByVal value As String)
            _CodigoSKU = value
        End Set
    End Property

    Public Property TipoUnidad() As Integer
        Get
            Return _TipoUnidad
        End Get
        Set(ByVal value As Integer)
            _TipoUnidad = value
        End Set
    End Property

    Public Property CantidadPedido() As Decimal
        Get
            Return _CantidadPedido
        End Get
        Set(ByVal value As Decimal)
            _CantidadPedido = value
        End Set
    End Property

    Public Property Cantidad1Pedido() As Decimal
        Get
            Return _Cantidad1Pedido
        End Get
        Set(ByVal value As Decimal)
            _Cantidad1Pedido = value
        End Set
    End Property
    Public Property UnidadCobranza() As Integer
        Get
            Return _UnidadCobranza
        End Get
        Set(ByVal value As Integer)
            _UnidadCobranza = value
        End Set
    End Property
    Public Property MonedaID() As String
        Get
            Return _MonedaId
        End Get
        Set(ByVal value As String)
            _MonedaId = value
        End Set
    End Property
    Public Property FactorPedido() As Decimal
        Get
            Return _FactorPedido
        End Get
        Set(ByVal value As Decimal)
            _FactorPedido = value
        End Set
    End Property

    Public Property Factor1Pedido() As Decimal
        Get
            Return _Factor1Pedido
        End Get
        Set(ByVal value As Decimal)
            _Factor1Pedido = value
        End Set
    End Property
    Public Property TotalPedido() As Decimal
        Get
            Return _TotalPedido
        End Get
        Set(ByVal value As Decimal)
            _TotalPedido = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property

    Public Property Merma() As Decimal
        Get
            Return _MermaSKU
        End Get
        Set(ByVal value As Decimal)
            _MermaSKU = value
        End Set
    End Property

    Public Property ImpuestoPedido() As Decimal
        Get
            Return _ImpuestoPedido
        End Get
        Set(ByVal value As Decimal)
            _ImpuestoPedido = value
        End Set
    End Property

    Public Sub New(ByVal partTipoBonificacion As TipoBonificacion)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _tipoBonificacion = partTipoBonificacion
    End Sub


    Private Sub ConfiguracionInicial()
        blnIniciandoCampos = True
        Me.txtCantidad.Formato = "##0.00"
        Me.txtCantidad1.Formato = "##0"

        Me.txtDescuentoPor.Formato = "##0.0000"
        Me.txtDescuentoImp.Formato = "#,##0.00"

        Dim dtTransProdPedido As DataTable = oDBVen.RealizarConsultaSQL("Select TPD.ProductoClave,PRO.Nombre,TPD.CodigoSKU,TPD.TipoUnidad, TPD.Cantidad, TPD.Cantidad1,TPD.Factor, TPD.Factor1,TPD.UnidadCobranza, TRP.MonedaID, TPD.DescuentoPor, TPD.DescuentoImp, TPD.Precio, TPD.Impuesto , TPD.Total from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdID = TRP.TransProdID inner join Producto PRO on TPD.ProductoClave=PRO.ProductoClave where TPD.TransProdID ='" & _TransProdIDPedido & "' and TPD.TransProdDetalleID='" & _TransProdDetalleIDPedido & "'", "TransProdDetalle")
        _ProductoClave = dtTransProdPedido.Rows(0)("ProductoClave")
        _CodigoSKU = IIf(IsDBNull(dtTransProdPedido.Rows(0)("CodigoSKU")), "", dtTransProdPedido.Rows(0)("CodigoSKU"))
        _TipoUnidad = dtTransProdPedido.Rows(0)("TipoUnidad")
        If _tipoPedido = MobileClient.TipoPedido.Reparto Then
            _CantidadPedido = dtTransProdPedido.Rows(0)("Cantidad")
        Else
            _CantidadPedido = dtTransProdPedido.Rows(0)("Cantidad")
            _MermaSKU = oDBVen.EjecutarCmdScalardblSQL("Select Disponible - Apartado from SKUInventario where CodigoSKU ='" & _CodigoSKU & "'")
            Dim dTotalOriginal As Decimal = RedondeoAritmetico((dtTransProdPedido.Rows(0)("Total") * 100) / (100 - dtTransProdPedido.Rows(0)("DescuentoPor")), 2)
            _DescuentoInicial = dTotalOriginal * (dtTransProdPedido.Rows(0)("DescuentoPor") / 100)
        End If
        _Cantidad1Pedido = dtTransProdPedido.Rows(0)("Cantidad1")
        _FactorPedido = dtTransProdPedido.Rows(0)("Factor")
        _Factor1Pedido = dtTransProdPedido.Rows(0)("Factor1")
        _Precio = dtTransProdPedido.Rows(0)("Precio")
        _UnidadCobranza = dtTransProdPedido.Rows(0)("UnidadCobranza")
        _MonedaId = dtTransProdPedido.Rows(0)("MonedaID")
        _ImpuestoPedido = dtTransProdPedido.Rows(0)("Impuesto")
        _TotalPedido = dtTransProdPedido.Rows(0)("Total")
        Me.LabelProductoClave.Text = _ProductoClave
        Me.LabelNombreProducto.Text = dtTransProdPedido.Rows(0)("Nombre")
        Me.LabelTotalImporte.Text = Format(_TotalPedido, oApp.FormatoDinero)

        Me.txtCantidad.TextAlign = HorizontalAlignment.Right
        Me.txtCantidad1.TextAlign = HorizontalAlignment.Right

        Select Case _tipoBonificacion
            Case TipoBonificacion.Devolucion
                Me.PanelCambioCantidades.Enabled = False
                Me.PanelCambioCantidades.Visible = True
                Me.PanelDescuentos.Visible = False
                Me.PanelPie.Visible = False
                Me.txtCantidad.DecimalValue = Me.CantidadPedido
                Me.txtCantidad1.DecimalValue = Me.Cantidad1Pedido
                Me.lblUnidad.Text = ValorReferencia.BuscarEquivalente("UNIDADV", Me.TipoUnidad)

            Case MobileClient.TipoBonificacion.PesoReal
                Me.PanelDescuentos.Visible = False
                Me.PanelCambioCantidades.Enabled = True
                Me.PanelCambioCantidades.Visible = True
                Me.PanelPie.Visible = True
                Me.txtCantidad.DecimalValue = Me.CantidadPedido
                Me.txtCantidad1.DecimalValue = Me.Cantidad1Pedido
                Me.txtCantidad1.Enabled = IIf(Me.CodigoSKU = "", True, False)
                Me.lblUnidad.Text = ValorReferencia.BuscarEquivalente("UNIDADV", Me.TipoUnidad)

            Case MobileClient.TipoBonificacion.BonificacionImporte
                Me.PanelDescuentos.Visible = True
                Me.PanelCambioCantidades.Visible = False
                Me.PanelPie.Visible = True
                Me.txtDescuentoPor.DecimalValue = dtTransProdPedido.Rows(0)("DescuentoPor")
                Me.txtDescuentoPor.Maximo = oVendedor.LimiteDescuento
                If _tipoPedido = MobileClient.TipoPedido.Reparto Then
                    Me.txtDescuentoImp.DecimalValue = dtTransProdPedido.Rows(0)("DescuentoImp")
                    Me.txtDescuentoImp.Maximo = ((dtTransProdPedido.Rows(0)("Total") + dtTransProdPedido.Rows(0)("DescuentoImp")) * IIf(oVendedor.LimiteDescuento <= 0, 0, (oVendedor.LimiteDescuento / 100)))
                Else
                    Me.txtDescuentoImp.DecimalValue = _DescuentoInicial
                    Me.txtDescuentoImp.Maximo = ((dtTransProdPedido.Rows(0)("Total") + _DescuentoInicial) * IIf(oVendedor.LimiteDescuento <= 0, 0, (oVendedor.LimiteDescuento / 100)))
                End If

                'Me.txtDescuentoImp.Maximo = ((dtTransProdPedido.Rows(0)("Total") + dtTransProdPedido.Rows(0)("DescuentoImp")) * IIf(oVendedor.LimiteDescuento <= 0, 0, (oVendedor.LimiteDescuento / 100)))

        End Select
        Me.ComboBoxMotivo.Focus()
        blnIniciandoCampos = False
    End Sub

    Private Sub FormBonificaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Vista.Buscar("FormBonificaciones", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        Me.refaVista.ColocarEtiquetasForma(Me)
        If Me.ComboBoxMotivo.Items.Count <= 0 Then
            With ComboBoxMotivo
                Dim aGrupo As New ArrayList()
                aGrupo.Add("Bonificacion")
                .DataSource = ValorReferencia.RecuperaVARVGrupo("TPDMOT", aGrupo)

                If .Items.Count > 0 Then
                    .DisplayMember = "Cadena"
                    .ValueMember = "Id"
                    .SelectedIndex = 0
                Else
                    ComboBoxMotivo.Enabled = False
                End If
            End With
        End If

        ConfiguracionInicial()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        blnIniciandoCampos = True
        Select Case _tipoBonificacion
            Case MobileClient.TipoBonificacion.PesoReal
                If Decimal.Round(txtCantidad.DecimalValue, 2) > Me.CantidadPedido + _MermaSKU Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0727").Replace("$0$", Me.lblUnidad.Text).Replace("$1$", _CantidadPedido + _MermaSKU), MsgBoxStyle.Exclamation)
                    txtCantidad.DecimalValue = Me.CantidadPedido + _MermaSKU
                    txtCantidad.Focus()
                    txtCantidad.SelectAll()
                    blnIniciandoCampos = False
                    Exit Sub
                End If


                If Decimal.Round(txtCantidad1.DecimalValue, 2) > Me.Cantidad1Pedido Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0727").Replace("$0$", Me.lblUnidad2.Text).Replace("$1$", _Cantidad1Pedido), MsgBoxStyle.Exclamation)
                    txtCantidad1.DecimalValue = Me.Cantidad1Pedido
                    txtCantidad1.Focus()
                    txtCantidad1.SelectAll()
                    blnIniciandoCampos = False
                    Exit Sub
                End If

                If Me.txtCantidad1.DecimalValue = 0 And Me.txtCantidad.DecimalValue > 0 Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0750").Replace("$0$", Me.lblUnidad2.Text).Replace("$1$", Me.lblUnidad.Text), MsgBoxStyle.Exclamation)
                    Me.txtCantidad1.DecimalValue = Me.Cantidad1Pedido
                    txtCantidad1.Focus()
                    txtCantidad1.SelectAll()
                    blnIniciandoCampos = False
                    Exit Sub
                End If

                If Me.txtCantidad.DecimalValue = 0 And Me.txtCantidad1.DecimalValue > 0 Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0750").Replace("$0$", Me.lblUnidad.Text).Replace("$1$", Me.lblUnidad2.Text), MsgBoxStyle.Exclamation)
                    Me.txtCantidad.DecimalValue = Me.CantidadPedido + _MermaSKU
                    txtCantidad.Focus()
                    txtCantidad.SelectAll()
                    blnIniciandoCampos = False
                    Exit Sub
                End If

            Case MobileClient.TipoBonificacion.BonificacionImporte

                If Me.txtDescuentoImp.DecimalValue > Me.txtDescuentoImp.Maximo Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0333").Replace("$0$", Me.LabelSimboloMoneda.Text).Replace("$1$", Me.txtDescuentoImp.Maximo), MsgBoxStyle.Critical)
                    txtDescuentoImp.DecimalValue = txtDescuentoImp.Maximo
                    If Not txtDescuentoImp.Focused Then
                        txtDescuentoImp.Focus()
                    End If
                    blnIniciandoCampos = False
                    Exit Sub
                End If

                If Me.txtDescuentoPor.DecimalValue > Me.txtDescuentoPor.Maximo Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0333").Replace("$0$", "%").Replace("$1$", Me.txtDescuentoPor.Maximo), MsgBoxStyle.Critical)
                    txtDescuentoPor.DecimalValue = txtDescuentoPor.Maximo
                    If Not txtDescuentoPor.Focused Then
                        txtDescuentoPor.Focus()
                    End If
                    blnIniciandoCampos = False
                    Exit Sub
                End If
        End Select
        blnIniciandoCampos = False

        If _tipoPedido = MobileClient.TipoPedido.Reparto Then
            If _tipoBonificacion = MobileClient.TipoBonificacion.Devolucion OrElse Math.Round(_TotalPedido, 2) > Math.Round(CDec(IIf(IsNumeric(Me.LabelTotalImporte.Text), Me.LabelTotalImporte.Text, 0)), 2) Then
                RaiseEvent GuardarDetalleBonificacion(Me)
            End If
        ElseIf _tipoPedido = MobileClient.TipoPedido.VentaDirecta Then
            If Math.Round(_TotalPedido, 2) <> Math.Round(CDec(IIf(IsNumeric(Me.LabelTotalImporte.Text), Me.LabelTotalImporte.Text, 0)), 2) Then
                RaiseEvent GuardarDetalleBonificacion(Me)
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                If txtCantidad1.Enabled Then
                    txtCantidad1.Focus()
                Else
                    ButtonContinuar_Click(Nothing, Nothing)
                End If
        End Select
    End Sub
    Private Sub txtCantidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCantidad.Validating
        If blnIniciandoCampos Then Exit Sub
        If Decimal.Round(txtCantidad.DecimalValue, 2) > Me.CantidadPedido + _MermaSKU Then
            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0727").Replace("$0$", Me.lblUnidad.Text).Replace("$1$", _CantidadPedido + _MermaSKU), MsgBoxStyle.Exclamation)
            txtCantidad.DecimalValue = Me.CantidadPedido
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtCantidad1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad1.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                ButtonContinuar_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub txtCantidad1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad1.LostFocus
        If blnIniciandoCampos Then Exit Sub
        If Decimal.Round(txtCantidad1.DecimalValue, 2) > Me.Cantidad1Pedido Then
            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0727").Replace("$0$", Me.lblUnidad2.Text).Replace("$1$", _Cantidad1Pedido), MsgBoxStyle.Exclamation)
            txtCantidad1.DecimalValue = Me.Cantidad1Pedido
            txtCantidad1.Focus()
        End If
    End Sub

    Private Sub txtDescuentoPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuentoPor.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                txtDescuentoImp.Focus()
        End Select
    End Sub

    Private Sub txtDescuentoPor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescuentoPor.TextChanged
        If blnIniciandoCampos Then Exit Sub
        If blnEditandoDescuento Then Exit Sub
        blnEditandoDescuento = True
        txtDescuentoImp.DecimalValue = (_TotalPedido + _DescuentoInicial) * (txtDescuentoPor.DecimalValue / 100)
        Me.LabelTotalImporte.Text = Format((_TotalPedido + _DescuentoInicial) - Me.txtDescuentoImp.DecimalValue, oApp.FormatoDinero)
        blnEditandoDescuento = False
    End Sub

    Private Sub txtDescuentoImp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuentoImp.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                ButtonContinuar_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub txtDescuentoImp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescuentoImp.TextChanged
        If blnIniciandoCampos Then Exit Sub
        If blnEditandoDescuento Then Exit Sub
        blnEditandoDescuento = True
        txtDescuentoPor.DecimalValue = (txtDescuentoImp.DecimalValue * 100) / (_TotalPedido + _DescuentoInicial)
        Me.LabelTotalImporte.Text = Format((_TotalPedido + _DescuentoInicial) - Me.txtDescuentoImp.DecimalValue, oApp.FormatoDinero)
        blnEditandoDescuento = False
    End Sub

    Private Sub ComboBoxMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBoxMotivo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                If Me.PanelCambioCantidades.Visible = True AndAlso Me.PanelCambioCantidades.Enabled Then
                    Me.txtCantidad.Focus()
                ElseIf Me.PanelDescuentos.Visible = True Then
                    Me.txtDescuentoPor.Focus()
                Else
                    ButtonContinuar_Click(Nothing, Nothing)
                End If
        End Select
    End Sub

    Private Sub txtDescuentoImp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDescuentoImp.Validating
        If blnIniciandoCampos Then Exit Sub
        If Me.txtDescuentoImp.DecimalValue > Me.txtDescuentoImp.Maximo Then
            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0333").Replace("$0$", Me.LabelSimboloMoneda.Text).Replace("$1$", Me.txtDescuentoImp.Maximo), MsgBoxStyle.Critical)
            txtDescuentoImp.DecimalValue = txtDescuentoImp.Maximo
            txtDescuentoImp.Focus()
        End If
    End Sub

    Private Sub txtDescuentoPor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDescuentoPor.Validating
        If blnIniciandoCampos Then Exit Sub
        If Me.txtDescuentoPor.DecimalValue > Me.txtDescuentoPor.Maximo Then
            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0333").Replace("$0$", "%").Replace("$1$", Me.txtDescuentoPor.Maximo), MsgBoxStyle.Critical)
            txtDescuentoPor.DecimalValue = txtDescuentoPor.Maximo
            txtDescuentoPor.Focus()
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If FactorPedido > 0 Then
            Dim dPorc As Decimal = (((txtCantidad.DecimalValue * FactorPedido) + (txtCantidad1.DecimalValue * Factor1Pedido)) * 100) / ((_CantidadPedido * _FactorPedido) + (_Cantidad1Pedido * _Factor1Pedido))
            dPorc = dPorc / 100
            Dim dSubtotal As Decimal = RedondeoAritmetico((((_CantidadPedido * _FactorPedido) + (_Cantidad1Pedido * _Factor1Pedido)) * _Precio) * dPorc, 2)
            Me.LabelTotalImporte.Text = Format((_ImpuestoPedido * dPorc) + dSubtotal, oApp.FormatoDinero)
        End If
    End Sub


    Private Sub txtCantidad1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad1.TextChanged
        If Factor1Pedido > 0 Then
            Dim dPorc As Decimal = (((txtCantidad.DecimalValue * FactorPedido) + (txtCantidad1.DecimalValue * Factor1Pedido) * 100)) / ((_CantidadPedido * _FactorPedido) + (_Cantidad1Pedido * _Factor1Pedido))
            dPorc = dPorc / 100
            Dim dSubtotal As Decimal = RedondeoAritmetico((((_CantidadPedido * _FactorPedido) + (_Cantidad1Pedido * _Factor1Pedido)) * _Precio) * dPorc, 2)
            Me.LabelTotalImporte.Text = Format((_ImpuestoPedido * dPorc) + dSubtotal, oApp.FormatoDinero)
        End If
    End Sub
End Class


Public Enum TipoBonificacion
    Devolucion = 0
    BonificacionImporte = 1
    PesoReal = 2
End Enum


Public Enum TipoPedido
    Reparto = 0
    VentaDirecta = 1
End Enum