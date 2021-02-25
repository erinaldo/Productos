<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MNotasCredito
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim grProductos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grMetodosPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MNotasCredito))
        Me.TabFacturacion = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.btMetodoPago = New Janus.Windows.EditControls.UIButton
        Me.lbMetodoPago = New System.Windows.Forms.Label
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebTotalDisp = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebFolioFactura = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbFactura = New System.Windows.Forms.Label
        Me.lbTotalDisp = New System.Windows.Forms.Label
        Me.btBuscarFactura = New Janus.Windows.EditControls.UIButton
        Me.ebTotalFAC = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbTotalFAC = New System.Windows.Forms.Label
        Me.ebPorcDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cbFolio = New Janus.Windows.EditControls.UIComboBox
        Me.cbTipoNota = New Janus.Windows.EditControls.UIComboBox
        Me.cbSubEmpresa = New Janus.Windows.EditControls.UIComboBox
        Me.lbTotal = New System.Windows.Forms.Label
        Me.ebTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbImpuesto = New System.Windows.Forms.Label
        Me.ebImpuesto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbSubtotal = New System.Windows.Forms.Label
        Me.ebSubTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbDescuento = New System.Windows.Forms.Label
        Me.ebDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbImporte = New System.Windows.Forms.Label
        Me.lbPorcDescuento = New System.Windows.Forms.Label
        Me.lbFolio = New System.Windows.Forms.Label
        Me.ebImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.gbProductos = New Janus.Windows.EditControls.UIGroupBox
        Me.grProductos = New Janus.Windows.GridEX.GridEX
        Me.lbFecha = New System.Windows.Forms.Label
        Me.lbSubEmpresa = New System.Windows.Forms.Label
        Me.lbTipoNota = New System.Windows.Forms.Label
        Me.TpGenerales = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.lbClienteDatos = New System.Windows.Forms.Label
        Me.ebClienteDatos = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPais = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbFolioDatos = New System.Windows.Forms.Label
        Me.lbPais = New System.Windows.Forms.Label
        Me.lbRazonSocial = New System.Windows.Forms.Label
        Me.ebEntidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFolioDatos = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbEntidad = New System.Windows.Forms.Label
        Me.ebRazonSocial = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebMunicipio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbRFC = New System.Windows.Forms.Label
        Me.lbMunicipio = New System.Windows.Forms.Label
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebLocalidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCalle = New System.Windows.Forms.Label
        Me.lbLocalidad = New System.Windows.Forms.Label
        Me.ebCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbExterior = New System.Windows.Forms.Label
        Me.lbReferencia = New System.Windows.Forms.Label
        Me.ebExterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCodigoPostal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbInterior = New System.Windows.Forms.Label
        Me.lbCodigoPostal = New System.Windows.Forms.Label
        Me.ebInterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbColonia = New System.Windows.Forms.Label
        Me.TpDatosFiscales = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.BtAceptar = New Janus.Windows.EditControls.UIButton
        Me.BtCancelar = New Janus.Windows.EditControls.UIButton
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grMetodosPago = New Janus.Windows.GridEX.GridEX
        CType(Me.TabFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFacturacion.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.gbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProductos.SuspendLayout()
        CType(Me.grProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grMetodosPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabFacturacion
        '
        Me.TabFacturacion.CanReorderTabs = False
        Me.TabFacturacion.Controls.Add(Me.TabControlPanel1)
        Me.TabFacturacion.Controls.Add(Me.TabControlPanel2)
        Me.TabFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabFacturacion.Location = New System.Drawing.Point(3, 2)
        Me.TabFacturacion.Name = "TabFacturacion"
        Me.TabFacturacion.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabFacturacion.SelectedTabIndex = 1
        Me.TabFacturacion.Size = New System.Drawing.Size(824, 573)
        Me.TabFacturacion.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabFacturacion.TabIndex = 7
        Me.TabFacturacion.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabFacturacion.Tabs.Add(Me.TpGenerales)
        Me.TabFacturacion.Tabs.Add(Me.TpDatosFiscales)
        Me.TabFacturacion.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.grMetodosPago)
        Me.TabControlPanel1.Controls.Add(Me.btMetodoPago)
        Me.TabControlPanel1.Controls.Add(Me.lbMetodoPago)
        Me.TabControlPanel1.Controls.Add(Me.ebFecha)
        Me.TabControlPanel1.Controls.Add(Me.ebTotalDisp)
        Me.TabControlPanel1.Controls.Add(Me.ebFolioFactura)
        Me.TabControlPanel1.Controls.Add(Me.lbFactura)
        Me.TabControlPanel1.Controls.Add(Me.lbTotalDisp)
        Me.TabControlPanel1.Controls.Add(Me.btBuscarFactura)
        Me.TabControlPanel1.Controls.Add(Me.ebTotalFAC)
        Me.TabControlPanel1.Controls.Add(Me.lbTotalFAC)
        Me.TabControlPanel1.Controls.Add(Me.ebPorcDescuento)
        Me.TabControlPanel1.Controls.Add(Me.cbFolio)
        Me.TabControlPanel1.Controls.Add(Me.cbTipoNota)
        Me.TabControlPanel1.Controls.Add(Me.cbSubEmpresa)
        Me.TabControlPanel1.Controls.Add(Me.lbTotal)
        Me.TabControlPanel1.Controls.Add(Me.ebTotal)
        Me.TabControlPanel1.Controls.Add(Me.lbImpuesto)
        Me.TabControlPanel1.Controls.Add(Me.ebImpuesto)
        Me.TabControlPanel1.Controls.Add(Me.lbSubtotal)
        Me.TabControlPanel1.Controls.Add(Me.ebSubTotal)
        Me.TabControlPanel1.Controls.Add(Me.lbDescuento)
        Me.TabControlPanel1.Controls.Add(Me.ebDescuento)
        Me.TabControlPanel1.Controls.Add(Me.lbImporte)
        Me.TabControlPanel1.Controls.Add(Me.lbPorcDescuento)
        Me.TabControlPanel1.Controls.Add(Me.lbFolio)
        Me.TabControlPanel1.Controls.Add(Me.ebImporte)
        Me.TabControlPanel1.Controls.Add(Me.gbProductos)
        Me.TabControlPanel1.Controls.Add(Me.lbFecha)
        Me.TabControlPanel1.Controls.Add(Me.lbSubEmpresa)
        Me.TabControlPanel1.Controls.Add(Me.lbTipoNota)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(824, 547)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TpGenerales
        '
        'btMetodoPago
        '
        Me.btMetodoPago.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btMetodoPago.Location = New System.Drawing.Point(114, 76)
        Me.btMetodoPago.Name = "btMetodoPago"
        Me.btMetodoPago.Size = New System.Drawing.Size(24, 20)
        Me.btMetodoPago.TabIndex = 11
        Me.btMetodoPago.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbMetodoPago
        '
        Me.lbMetodoPago.BackColor = System.Drawing.Color.Transparent
        Me.lbMetodoPago.Location = New System.Drawing.Point(11, 76)
        Me.lbMetodoPago.Name = "lbMetodoPago"
        Me.lbMetodoPago.Size = New System.Drawing.Size(120, 20)
        Me.lbMetodoPago.TabIndex = 50
        Me.lbMetodoPago.Text = "Metodo de Pago"
        Me.lbMetodoPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebFecha
        '
        Me.ebFecha.Enabled = False
        Me.ebFecha.Location = New System.Drawing.Point(655, 4)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(151, 20)
        Me.ebFecha.TabIndex = 3
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebTotalDisp
        '
        Me.ebTotalDisp.DecimalDigits = 2
        Me.ebTotalDisp.Enabled = False
        Me.ebTotalDisp.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotalDisp.Location = New System.Drawing.Point(384, 52)
        Me.ebTotalDisp.MaxLength = 100
        Me.ebTotalDisp.Name = "ebTotalDisp"
        Me.ebTotalDisp.Size = New System.Drawing.Size(151, 20)
        Me.ebTotalDisp.TabIndex = 9
        Me.ebTotalDisp.Text = "$0.00"
        Me.ebTotalDisp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalDisp.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebTotalDisp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebFolioFactura
        '
        Me.ebFolioFactura.Location = New System.Drawing.Point(114, 28)
        Me.ebFolioFactura.Name = "ebFolioFactura"
        Me.ebFolioFactura.Size = New System.Drawing.Size(128, 20)
        Me.ebFolioFactura.TabIndex = 4
        Me.ebFolioFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbFactura
        '
        Me.lbFactura.BackColor = System.Drawing.Color.Transparent
        Me.lbFactura.Location = New System.Drawing.Point(11, 28)
        Me.lbFactura.Name = "lbFactura"
        Me.lbFactura.Size = New System.Drawing.Size(104, 20)
        Me.lbFactura.TabIndex = 22
        Me.lbFactura.Text = "Factura"
        Me.lbFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTotalDisp
        '
        Me.lbTotalDisp.BackColor = System.Drawing.Color.Transparent
        Me.lbTotalDisp.Location = New System.Drawing.Point(281, 52)
        Me.lbTotalDisp.Name = "lbTotalDisp"
        Me.lbTotalDisp.Size = New System.Drawing.Size(104, 20)
        Me.lbTotalDisp.TabIndex = 46
        Me.lbTotalDisp.Text = "Total Disponible"
        Me.lbTotalDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btBuscarFactura
        '
        Me.btBuscarFactura.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btBuscarFactura.Location = New System.Drawing.Point(241, 28)
        Me.btBuscarFactura.Name = "btBuscarFactura"
        Me.btBuscarFactura.Size = New System.Drawing.Size(24, 20)
        Me.btBuscarFactura.TabIndex = 5
        Me.btBuscarFactura.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebTotalFAC
        '
        Me.ebTotalFAC.DecimalDigits = 2
        Me.ebTotalFAC.Enabled = False
        Me.ebTotalFAC.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotalFAC.Location = New System.Drawing.Point(114, 52)
        Me.ebTotalFAC.MaxLength = 100
        Me.ebTotalFAC.Name = "ebTotalFAC"
        Me.ebTotalFAC.Size = New System.Drawing.Size(151, 20)
        Me.ebTotalFAC.TabIndex = 8
        Me.ebTotalFAC.Text = "$0.00"
        Me.ebTotalFAC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalFAC.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebTotalFAC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbTotalFAC
        '
        Me.lbTotalFAC.BackColor = System.Drawing.Color.Transparent
        Me.lbTotalFAC.Location = New System.Drawing.Point(11, 52)
        Me.lbTotalFAC.Name = "lbTotalFAC"
        Me.lbTotalFAC.Size = New System.Drawing.Size(104, 20)
        Me.lbTotalFAC.TabIndex = 42
        Me.lbTotalFAC.Text = "Total Facturado"
        Me.lbTotalFAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPorcDescuento
        '
        Me.ebPorcDescuento.DecimalDigits = 3
        Me.ebPorcDescuento.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.ebPorcDescuento.Location = New System.Drawing.Point(655, 28)
        Me.ebPorcDescuento.MaxLength = 100
        Me.ebPorcDescuento.Name = "ebPorcDescuento"
        Me.ebPorcDescuento.Size = New System.Drawing.Size(151, 20)
        Me.ebPorcDescuento.TabIndex = 7
        Me.ebPorcDescuento.Text = "0.000 %"
        Me.ebPorcDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPorcDescuento.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebPorcDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbFolio
        '
        Me.cbFolio.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFolio.Location = New System.Drawing.Point(384, 4)
        Me.cbFolio.Name = "cbFolio"
        Me.cbFolio.Size = New System.Drawing.Size(151, 20)
        Me.cbFolio.TabIndex = 2
        Me.cbFolio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbTipoNota
        '
        Me.cbTipoNota.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoNota.Location = New System.Drawing.Point(384, 28)
        Me.cbTipoNota.Name = "cbTipoNota"
        Me.cbTipoNota.Size = New System.Drawing.Size(151, 20)
        Me.cbTipoNota.TabIndex = 6
        Me.cbTipoNota.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbSubEmpresa
        '
        Me.cbSubEmpresa.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbSubEmpresa.Location = New System.Drawing.Point(114, 4)
        Me.cbSubEmpresa.Name = "cbSubEmpresa"
        Me.cbSubEmpresa.Size = New System.Drawing.Size(151, 20)
        Me.cbSubEmpresa.TabIndex = 1
        Me.cbSubEmpresa.Tag = "SubEmpresaId"
        Me.cbSubEmpresa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbTotal
        '
        Me.lbTotal.BackColor = System.Drawing.Color.Transparent
        Me.lbTotal.Location = New System.Drawing.Point(526, 522)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(95, 20)
        Me.lbTotal.TabIndex = 31
        Me.lbTotal.Text = "Total"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebTotal
        '
        Me.ebTotal.DecimalDigits = 2
        Me.ebTotal.Enabled = False
        Me.ebTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotal.Location = New System.Drawing.Point(662, 522)
        Me.ebTotal.Name = "ebTotal"
        Me.ebTotal.Size = New System.Drawing.Size(144, 20)
        Me.ebTotal.TabIndex = 17
        Me.ebTotal.Text = "$0.00"
        Me.ebTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotal.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbImpuesto
        '
        Me.lbImpuesto.BackColor = System.Drawing.Color.Transparent
        Me.lbImpuesto.Location = New System.Drawing.Point(526, 500)
        Me.lbImpuesto.Name = "lbImpuesto"
        Me.lbImpuesto.Size = New System.Drawing.Size(95, 20)
        Me.lbImpuesto.TabIndex = 29
        Me.lbImpuesto.Text = "Impuesto"
        Me.lbImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebImpuesto
        '
        Me.ebImpuesto.DecimalDigits = 2
        Me.ebImpuesto.Enabled = False
        Me.ebImpuesto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImpuesto.Location = New System.Drawing.Point(662, 500)
        Me.ebImpuesto.Name = "ebImpuesto"
        Me.ebImpuesto.Size = New System.Drawing.Size(144, 20)
        Me.ebImpuesto.TabIndex = 16
        Me.ebImpuesto.Text = "$0.00"
        Me.ebImpuesto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImpuesto.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebImpuesto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbSubtotal
        '
        Me.lbSubtotal.BackColor = System.Drawing.Color.Transparent
        Me.lbSubtotal.Location = New System.Drawing.Point(526, 478)
        Me.lbSubtotal.Name = "lbSubtotal"
        Me.lbSubtotal.Size = New System.Drawing.Size(95, 20)
        Me.lbSubtotal.TabIndex = 27
        Me.lbSubtotal.Text = "Subtotal"
        Me.lbSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebSubTotal
        '
        Me.ebSubTotal.DecimalDigits = 2
        Me.ebSubTotal.Enabled = False
        Me.ebSubTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSubTotal.Location = New System.Drawing.Point(662, 478)
        Me.ebSubTotal.Name = "ebSubTotal"
        Me.ebSubTotal.Size = New System.Drawing.Size(144, 20)
        Me.ebSubTotal.TabIndex = 15
        Me.ebSubTotal.Text = "$0.00"
        Me.ebSubTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSubTotal.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbDescuento
        '
        Me.lbDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lbDescuento.Location = New System.Drawing.Point(526, 456)
        Me.lbDescuento.Name = "lbDescuento"
        Me.lbDescuento.Size = New System.Drawing.Size(95, 20)
        Me.lbDescuento.TabIndex = 25
        Me.lbDescuento.Text = "Descuento"
        Me.lbDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDescuento
        '
        Me.ebDescuento.DecimalDigits = 2
        Me.ebDescuento.Enabled = False
        Me.ebDescuento.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebDescuento.Location = New System.Drawing.Point(662, 456)
        Me.ebDescuento.Name = "ebDescuento"
        Me.ebDescuento.Size = New System.Drawing.Size(144, 20)
        Me.ebDescuento.TabIndex = 14
        Me.ebDescuento.Text = "$0.00"
        Me.ebDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDescuento.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbImporte
        '
        Me.lbImporte.BackColor = System.Drawing.Color.Transparent
        Me.lbImporte.Location = New System.Drawing.Point(526, 434)
        Me.lbImporte.Name = "lbImporte"
        Me.lbImporte.Size = New System.Drawing.Size(95, 20)
        Me.lbImporte.TabIndex = 3
        Me.lbImporte.Text = "Importe"
        Me.lbImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPorcDescuento
        '
        Me.lbPorcDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lbPorcDescuento.Location = New System.Drawing.Point(552, 28)
        Me.lbPorcDescuento.Name = "lbPorcDescuento"
        Me.lbPorcDescuento.Size = New System.Drawing.Size(104, 20)
        Me.lbPorcDescuento.TabIndex = 23
        Me.lbPorcDescuento.Text = "% Descuento"
        Me.lbPorcDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFolio
        '
        Me.lbFolio.BackColor = System.Drawing.Color.Transparent
        Me.lbFolio.Location = New System.Drawing.Point(281, 4)
        Me.lbFolio.Name = "lbFolio"
        Me.lbFolio.Size = New System.Drawing.Size(104, 20)
        Me.lbFolio.TabIndex = 0
        Me.lbFolio.Text = "Folio"
        Me.lbFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebImporte
        '
        Me.ebImporte.DecimalDigits = 2
        Me.ebImporte.Enabled = False
        Me.ebImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImporte.Location = New System.Drawing.Point(662, 434)
        Me.ebImporte.Name = "ebImporte"
        Me.ebImporte.Size = New System.Drawing.Size(144, 20)
        Me.ebImporte.TabIndex = 13
        Me.ebImporte.Text = "$0.00"
        Me.ebImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporte.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbProductos
        '
        Me.gbProductos.BackColor = System.Drawing.Color.Transparent
        Me.gbProductos.Controls.Add(Me.grProductos)
        Me.gbProductos.Location = New System.Drawing.Point(14, 178)
        Me.gbProductos.Name = "gbProductos"
        Me.gbProductos.Size = New System.Drawing.Size(792, 252)
        Me.gbProductos.TabIndex = 12
        Me.gbProductos.Text = "Productos"
        Me.gbProductos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'grProductos
        '
        grProductos_DesignTimeLayout.LayoutString = resources.GetString("grProductos_DesignTimeLayout.LayoutString")
        Me.grProductos.DesignTimeLayout = grProductos_DesignTimeLayout
        Me.grProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grProductos.GroupByBoxVisible = False
        Me.grProductos.Location = New System.Drawing.Point(11, 17)
        Me.grProductos.Name = "grProductos"
        Me.grProductos.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grProductos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grProductos.Size = New System.Drawing.Size(770, 229)
        Me.grProductos.TabIndex = 0
        Me.grProductos.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbFecha
        '
        Me.lbFecha.BackColor = System.Drawing.Color.Transparent
        Me.lbFecha.Location = New System.Drawing.Point(552, 4)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(104, 20)
        Me.lbFecha.TabIndex = 2
        Me.lbFecha.Text = "Fecha"
        Me.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbSubEmpresa
        '
        Me.lbSubEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lbSubEmpresa.Location = New System.Drawing.Point(11, 4)
        Me.lbSubEmpresa.Name = "lbSubEmpresa"
        Me.lbSubEmpresa.Size = New System.Drawing.Size(104, 20)
        Me.lbSubEmpresa.TabIndex = 11
        Me.lbSubEmpresa.Text = "SubEmpresa"
        Me.lbSubEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTipoNota
        '
        Me.lbTipoNota.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoNota.Location = New System.Drawing.Point(281, 28)
        Me.lbTipoNota.Name = "lbTipoNota"
        Me.lbTipoNota.Size = New System.Drawing.Size(104, 20)
        Me.lbTipoNota.TabIndex = 11
        Me.lbTipoNota.Text = "Tipo"
        Me.lbTipoNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TpGenerales
        '
        Me.TpGenerales.AttachedControl = Me.TabControlPanel1
        Me.TpGenerales.Name = "TpGenerales"
        Me.TpGenerales.Text = "TpGenerales"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.lbClienteDatos)
        Me.TabControlPanel2.Controls.Add(Me.ebClienteDatos)
        Me.TabControlPanel2.Controls.Add(Me.ebPais)
        Me.TabControlPanel2.Controls.Add(Me.lbFolioDatos)
        Me.TabControlPanel2.Controls.Add(Me.lbPais)
        Me.TabControlPanel2.Controls.Add(Me.lbRazonSocial)
        Me.TabControlPanel2.Controls.Add(Me.ebEntidad)
        Me.TabControlPanel2.Controls.Add(Me.ebFolioDatos)
        Me.TabControlPanel2.Controls.Add(Me.lbEntidad)
        Me.TabControlPanel2.Controls.Add(Me.ebRazonSocial)
        Me.TabControlPanel2.Controls.Add(Me.ebMunicipio)
        Me.TabControlPanel2.Controls.Add(Me.lbRFC)
        Me.TabControlPanel2.Controls.Add(Me.lbMunicipio)
        Me.TabControlPanel2.Controls.Add(Me.ebRFC)
        Me.TabControlPanel2.Controls.Add(Me.ebLocalidad)
        Me.TabControlPanel2.Controls.Add(Me.lbCalle)
        Me.TabControlPanel2.Controls.Add(Me.lbLocalidad)
        Me.TabControlPanel2.Controls.Add(Me.ebCalle)
        Me.TabControlPanel2.Controls.Add(Me.ebReferencia)
        Me.TabControlPanel2.Controls.Add(Me.lbExterior)
        Me.TabControlPanel2.Controls.Add(Me.lbReferencia)
        Me.TabControlPanel2.Controls.Add(Me.ebExterior)
        Me.TabControlPanel2.Controls.Add(Me.ebCodigoPostal)
        Me.TabControlPanel2.Controls.Add(Me.lbInterior)
        Me.TabControlPanel2.Controls.Add(Me.lbCodigoPostal)
        Me.TabControlPanel2.Controls.Add(Me.ebInterior)
        Me.TabControlPanel2.Controls.Add(Me.ebColonia)
        Me.TabControlPanel2.Controls.Add(Me.lbColonia)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(824, 547)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TpDatosFiscales
        '
        'lbClienteDatos
        '
        Me.lbClienteDatos.BackColor = System.Drawing.Color.Transparent
        Me.lbClienteDatos.Location = New System.Drawing.Point(24, 55)
        Me.lbClienteDatos.Name = "lbClienteDatos"
        Me.lbClienteDatos.Size = New System.Drawing.Size(132, 20)
        Me.lbClienteDatos.TabIndex = 26
        Me.lbClienteDatos.Text = "Cliente"
        Me.lbClienteDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebClienteDatos
        '
        Me.ebClienteDatos.Enabled = False
        Me.ebClienteDatos.Location = New System.Drawing.Point(168, 55)
        Me.ebClienteDatos.MaxLength = 128
        Me.ebClienteDatos.Name = "ebClienteDatos"
        Me.ebClienteDatos.Size = New System.Drawing.Size(624, 20)
        Me.ebClienteDatos.TabIndex = 2
        Me.ebClienteDatos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebPais
        '
        Me.ebPais.Enabled = False
        Me.ebPais.Location = New System.Drawing.Point(608, 344)
        Me.ebPais.MaxLength = 32
        Me.ebPais.Name = "ebPais"
        Me.ebPais.Size = New System.Drawing.Size(184, 20)
        Me.ebPais.TabIndex = 25
        Me.ebPais.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPais.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbFolioDatos
        '
        Me.lbFolioDatos.BackColor = System.Drawing.Color.Transparent
        Me.lbFolioDatos.Location = New System.Drawing.Point(24, 24)
        Me.lbFolioDatos.Name = "lbFolioDatos"
        Me.lbFolioDatos.Size = New System.Drawing.Size(132, 20)
        Me.lbFolioDatos.TabIndex = 0
        Me.lbFolioDatos.Text = "Folio"
        Me.lbFolioDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPais
        '
        Me.lbPais.BackColor = System.Drawing.Color.Transparent
        Me.lbPais.Location = New System.Drawing.Point(464, 344)
        Me.lbPais.Name = "lbPais"
        Me.lbPais.Size = New System.Drawing.Size(132, 20)
        Me.lbPais.TabIndex = 24
        Me.lbPais.Text = "País"
        Me.lbPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.BackColor = System.Drawing.Color.Transparent
        Me.lbRazonSocial.Location = New System.Drawing.Point(24, 88)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(132, 20)
        Me.lbRazonSocial.TabIndex = 2
        Me.lbRazonSocial.Text = "Razon Social"
        Me.lbRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebEntidad
        '
        Me.ebEntidad.Enabled = False
        Me.ebEntidad.Location = New System.Drawing.Point(168, 344)
        Me.ebEntidad.MaxLength = 32
        Me.ebEntidad.Name = "ebEntidad"
        Me.ebEntidad.Size = New System.Drawing.Size(184, 20)
        Me.ebEntidad.TabIndex = 23
        Me.ebEntidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEntidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebFolioDatos
        '
        Me.ebFolioDatos.Enabled = False
        Me.ebFolioDatos.Location = New System.Drawing.Point(168, 24)
        Me.ebFolioDatos.Name = "ebFolioDatos"
        Me.ebFolioDatos.Size = New System.Drawing.Size(184, 20)
        Me.ebFolioDatos.TabIndex = 1
        Me.ebFolioDatos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbEntidad
        '
        Me.lbEntidad.BackColor = System.Drawing.Color.Transparent
        Me.lbEntidad.Location = New System.Drawing.Point(24, 344)
        Me.lbEntidad.Name = "lbEntidad"
        Me.lbEntidad.Size = New System.Drawing.Size(132, 20)
        Me.lbEntidad.TabIndex = 22
        Me.lbEntidad.Text = "Entidad"
        Me.lbEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebRazonSocial
        '
        Me.ebRazonSocial.Enabled = False
        Me.ebRazonSocial.Location = New System.Drawing.Point(168, 88)
        Me.ebRazonSocial.MaxLength = 128
        Me.ebRazonSocial.Name = "ebRazonSocial"
        Me.ebRazonSocial.Size = New System.Drawing.Size(624, 20)
        Me.ebRazonSocial.TabIndex = 3
        Me.ebRazonSocial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRazonSocial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebMunicipio
        '
        Me.ebMunicipio.Enabled = False
        Me.ebMunicipio.Location = New System.Drawing.Point(608, 312)
        Me.ebMunicipio.MaxLength = 64
        Me.ebMunicipio.Name = "ebMunicipio"
        Me.ebMunicipio.Size = New System.Drawing.Size(184, 20)
        Me.ebMunicipio.TabIndex = 21
        Me.ebMunicipio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMunicipio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbRFC
        '
        Me.lbRFC.BackColor = System.Drawing.Color.Transparent
        Me.lbRFC.Location = New System.Drawing.Point(24, 120)
        Me.lbRFC.Name = "lbRFC"
        Me.lbRFC.Size = New System.Drawing.Size(132, 20)
        Me.lbRFC.TabIndex = 4
        Me.lbRFC.Text = "RFC"
        Me.lbRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMunicipio
        '
        Me.lbMunicipio.BackColor = System.Drawing.Color.Transparent
        Me.lbMunicipio.Location = New System.Drawing.Point(464, 312)
        Me.lbMunicipio.Name = "lbMunicipio"
        Me.lbMunicipio.Size = New System.Drawing.Size(132, 20)
        Me.lbMunicipio.TabIndex = 20
        Me.lbMunicipio.Text = "Municipio"
        Me.lbMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebRFC
        '
        Me.ebRFC.Enabled = False
        Me.ebRFC.Location = New System.Drawing.Point(168, 120)
        Me.ebRFC.MaxLength = 20
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.Size = New System.Drawing.Size(184, 20)
        Me.ebRFC.TabIndex = 5
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebLocalidad
        '
        Me.ebLocalidad.Enabled = False
        Me.ebLocalidad.Location = New System.Drawing.Point(168, 312)
        Me.ebLocalidad.MaxLength = 40
        Me.ebLocalidad.Name = "ebLocalidad"
        Me.ebLocalidad.Size = New System.Drawing.Size(184, 20)
        Me.ebLocalidad.TabIndex = 19
        Me.ebLocalidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLocalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCalle
        '
        Me.lbCalle.BackColor = System.Drawing.Color.Transparent
        Me.lbCalle.Location = New System.Drawing.Point(24, 152)
        Me.lbCalle.Name = "lbCalle"
        Me.lbCalle.Size = New System.Drawing.Size(132, 20)
        Me.lbCalle.TabIndex = 6
        Me.lbCalle.Text = "Calle"
        Me.lbCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLocalidad
        '
        Me.lbLocalidad.BackColor = System.Drawing.Color.Transparent
        Me.lbLocalidad.Location = New System.Drawing.Point(24, 312)
        Me.lbLocalidad.Name = "lbLocalidad"
        Me.lbLocalidad.Size = New System.Drawing.Size(132, 20)
        Me.lbLocalidad.TabIndex = 18
        Me.lbLocalidad.Text = "Localidad"
        Me.lbLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCalle
        '
        Me.ebCalle.Enabled = False
        Me.ebCalle.Location = New System.Drawing.Point(168, 152)
        Me.ebCalle.MaxLength = 64
        Me.ebCalle.Name = "ebCalle"
        Me.ebCalle.Size = New System.Drawing.Size(624, 20)
        Me.ebCalle.TabIndex = 7
        Me.ebCalle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebReferencia
        '
        Me.ebReferencia.Enabled = False
        Me.ebReferencia.Location = New System.Drawing.Point(168, 280)
        Me.ebReferencia.MaxLength = 100
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.Size = New System.Drawing.Size(624, 20)
        Me.ebReferencia.TabIndex = 17
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbExterior
        '
        Me.lbExterior.BackColor = System.Drawing.Color.Transparent
        Me.lbExterior.Location = New System.Drawing.Point(24, 184)
        Me.lbExterior.Name = "lbExterior"
        Me.lbExterior.Size = New System.Drawing.Size(132, 20)
        Me.lbExterior.TabIndex = 8
        Me.lbExterior.Text = "Exterior"
        Me.lbExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbReferencia
        '
        Me.lbReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lbReferencia.Location = New System.Drawing.Point(24, 280)
        Me.lbReferencia.Name = "lbReferencia"
        Me.lbReferencia.Size = New System.Drawing.Size(132, 20)
        Me.lbReferencia.TabIndex = 16
        Me.lbReferencia.Text = "Referencia"
        Me.lbReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebExterior
        '
        Me.ebExterior.Enabled = False
        Me.ebExterior.Location = New System.Drawing.Point(168, 184)
        Me.ebExterior.MaxLength = 16
        Me.ebExterior.Name = "ebExterior"
        Me.ebExterior.Size = New System.Drawing.Size(184, 20)
        Me.ebExterior.TabIndex = 9
        Me.ebExterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebExterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebCodigoPostal
        '
        Me.ebCodigoPostal.Enabled = False
        Me.ebCodigoPostal.Location = New System.Drawing.Point(168, 248)
        Me.ebCodigoPostal.MaxLength = 16
        Me.ebCodigoPostal.Name = "ebCodigoPostal"
        Me.ebCodigoPostal.Size = New System.Drawing.Size(184, 20)
        Me.ebCodigoPostal.TabIndex = 15
        Me.ebCodigoPostal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoPostal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbInterior
        '
        Me.lbInterior.BackColor = System.Drawing.Color.Transparent
        Me.lbInterior.Location = New System.Drawing.Point(464, 184)
        Me.lbInterior.Name = "lbInterior"
        Me.lbInterior.Size = New System.Drawing.Size(132, 20)
        Me.lbInterior.TabIndex = 10
        Me.lbInterior.Text = "Interior"
        Me.lbInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCodigoPostal
        '
        Me.lbCodigoPostal.BackColor = System.Drawing.Color.Transparent
        Me.lbCodigoPostal.Location = New System.Drawing.Point(24, 248)
        Me.lbCodigoPostal.Name = "lbCodigoPostal"
        Me.lbCodigoPostal.Size = New System.Drawing.Size(132, 20)
        Me.lbCodigoPostal.TabIndex = 14
        Me.lbCodigoPostal.Text = "Código Postal"
        Me.lbCodigoPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebInterior
        '
        Me.ebInterior.Enabled = False
        Me.ebInterior.Location = New System.Drawing.Point(608, 184)
        Me.ebInterior.MaxLength = 16
        Me.ebInterior.Name = "ebInterior"
        Me.ebInterior.Size = New System.Drawing.Size(184, 20)
        Me.ebInterior.TabIndex = 11
        Me.ebInterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebInterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebColonia
        '
        Me.ebColonia.Enabled = False
        Me.ebColonia.Location = New System.Drawing.Point(168, 216)
        Me.ebColonia.MaxLength = 64
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(624, 20)
        Me.ebColonia.TabIndex = 13
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbColonia
        '
        Me.lbColonia.BackColor = System.Drawing.Color.Transparent
        Me.lbColonia.Location = New System.Drawing.Point(24, 216)
        Me.lbColonia.Name = "lbColonia"
        Me.lbColonia.Size = New System.Drawing.Size(132, 20)
        Me.lbColonia.TabIndex = 12
        Me.lbColonia.Text = "Colonia"
        Me.lbColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TpDatosFiscales
        '
        Me.TpDatosFiscales.AttachedControl = Me.TabControlPanel2
        Me.TpDatosFiscales.Name = "TpDatosFiscales"
        Me.TpDatosFiscales.Text = "TpDatosFiscales"
        '
        'BtAceptar
        '
        Me.BtAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAceptar.Icon = CType(resources.GetObject("BtAceptar.Icon"), System.Drawing.Icon)
        Me.BtAceptar.Location = New System.Drawing.Point(603, 587)
        Me.BtAceptar.Name = "BtAceptar"
        Me.BtAceptar.Size = New System.Drawing.Size(104, 24)
        Me.BtAceptar.TabIndex = 5
        Me.BtAceptar.Text = "Aceptar"
        Me.BtAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'BtCancelar
        '
        Me.BtCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancelar.CausesValidation = False
        Me.BtCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancelar.Icon = CType(resources.GetObject("BtCancelar.Icon"), System.Drawing.Icon)
        Me.BtCancelar.Location = New System.Drawing.Point(715, 587)
        Me.BtCancelar.Name = "BtCancelar"
        Me.BtCancelar.Size = New System.Drawing.Size(104, 24)
        Me.BtCancelar.TabIndex = 6
        Me.BtCancelar.Text = "Cancelar"
        Me.BtCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'grMetodosPago
        '
        grMetodosPago_DesignTimeLayout.LayoutString = resources.GetString("grMetodosPago_DesignTimeLayout.LayoutString")
        Me.grMetodosPago.DesignTimeLayout = grMetodosPago_DesignTimeLayout
        Me.grMetodosPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grMetodosPago.GroupByBoxVisible = False
        Me.grMetodosPago.Location = New System.Drawing.Point(14, 101)
        Me.grMetodosPago.Name = "grMetodosPago"
        Me.grMetodosPago.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grMetodosPago.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grMetodosPago.Size = New System.Drawing.Size(399, 71)
        Me.grMetodosPago.TabIndex = 51
        Me.grMetodosPago.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grMetodosPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MNotasCredito
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(836, 618)
        Me.Controls.Add(Me.TabFacturacion)
        Me.Controls.Add(Me.BtAceptar)
        Me.Controls.Add(Me.BtCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MNotasCredito"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MNotasCredito"
        CType(Me.TabFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFacturacion.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.gbProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProductos.ResumeLayout(False)
        CType(Me.grProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grMetodosPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabFacturacion As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents lbFactura As System.Windows.Forms.Label
    Friend WithEvents lbFolio As System.Windows.Forms.Label
    Friend WithEvents gbProductos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lbImporte As System.Windows.Forms.Label
    Friend WithEvents grProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbFolio As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents btBuscarFactura As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioFactura As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbSubEmpresa As System.Windows.Forms.Label
    Friend WithEvents lbTipoNota As System.Windows.Forms.Label
    Friend WithEvents cbSubEmpresa As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbTipoNota As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents TpGenerales As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ebPais As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbFolioDatos As System.Windows.Forms.Label
    Friend WithEvents lbPais As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents ebEntidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioDatos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbEntidad As System.Windows.Forms.Label
    Friend WithEvents ebRazonSocial As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMunicipio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbRFC As System.Windows.Forms.Label
    Friend WithEvents lbMunicipio As System.Windows.Forms.Label
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebLocalidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCalle As System.Windows.Forms.Label
    Friend WithEvents lbLocalidad As System.Windows.Forms.Label
    Friend WithEvents ebCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbExterior As System.Windows.Forms.Label
    Friend WithEvents lbReferencia As System.Windows.Forms.Label
    Friend WithEvents ebExterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoPostal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbInterior As System.Windows.Forms.Label
    Friend WithEvents lbCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents ebInterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbColonia As System.Windows.Forms.Label
    Friend WithEvents TpDatosFiscales As DevComponents.DotNetBar.TabItem
    Public WithEvents BtAceptar As Janus.Windows.EditControls.UIButton
    Public WithEvents BtCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbPorcDescuento As System.Windows.Forms.Label
    Friend WithEvents lbSubtotal As System.Windows.Forms.Label
    Friend WithEvents ebSubTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbDescuento As System.Windows.Forms.Label
    Friend WithEvents ebDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbTotal As System.Windows.Forms.Label
    Friend WithEvents ebTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbImpuesto As System.Windows.Forms.Label
    Friend WithEvents ebImpuesto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebPorcDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents ebTotalFAC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbTotalFAC As System.Windows.Forms.Label
    Friend WithEvents ebTotalDisp As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbTotalDisp As System.Windows.Forms.Label
    Friend WithEvents lbClienteDatos As System.Windows.Forms.Label
    Friend WithEvents ebClienteDatos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btMetodoPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbMetodoPago As System.Windows.Forms.Label
    Friend WithEvents grMetodosPago As Janus.Windows.GridEX.GridEX
End Class
