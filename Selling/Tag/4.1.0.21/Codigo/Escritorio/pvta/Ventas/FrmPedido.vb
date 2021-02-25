Public Class FrmPedido
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnBusquedaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedido))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.cmbEstado = New Selling.StoreCombo()
        Me.cmbTipo = New Selling.StoreCombo()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.BtnBusquedaProducto = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GrpCliente.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(789, 519)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 1
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(693, 519)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar sin guardar cambios"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.LblTipoCambio)
        Me.GrpCliente.Controls.Add(Me.cmbEstado)
        Me.GrpCliente.Controls.Add(Me.cmbTipo)
        Me.GrpCliente.Controls.Add(Me.TxtFolio)
        Me.GrpCliente.Controls.Add(Me.TxtVendedor)
        Me.GrpCliente.Controls.Add(Me.BtnTC)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.TxtFecha)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.Label12)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.TxtCliente)
        Me.GrpCliente.Location = New System.Drawing.Point(12, 12)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(867, 100)
        Me.GrpCliente.TabIndex = 121
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "General"
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.Location = New System.Drawing.Point(773, 41)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(88, 15)
        Me.LblTipoCambio.TabIndex = 115
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.Location = New System.Drawing.Point(636, 14)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(131, 21)
        Me.cmbEstado.TabIndex = 114
        '
        'cmbTipo
        '
        Me.cmbTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.Location = New System.Drawing.Point(499, 14)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(131, 21)
        Me.cmbTipo.TabIndex = 113
        '
        'TxtFolio
        '
        Me.TxtFolio.Enabled = False
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(81, 15)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(186, 21)
        Me.TxtFolio.TabIndex = 112
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtVendedor.Enabled = False
        Me.TxtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor.Location = New System.Drawing.Point(81, 41)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(308, 21)
        Me.TxtVendedor.TabIndex = 3
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Enabled = False
        Me.BtnTC.Location = New System.Drawing.Point(773, 11)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(88, 28)
        Me.BtnTC.TabIndex = 110
        Me.BtnTC.Text = "MXN"
        Me.BtnTC.ToolTipText = "Elejir Moneda"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(412, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Tipo/Estado"
        '
        'TxtFecha
        '
        Me.TxtFecha.Enabled = False
        Me.TxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Location = New System.Drawing.Point(273, 15)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(116, 21)
        Me.TxtFecha.TabIndex = 94
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(7, 72)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "Cliente"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 17)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Atendio"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Folio/Fecha"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(273, 67)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(494, 21)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCliente.Location = New System.Drawing.Point(81, 67)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(186, 21)
        Me.TxtCliente.TabIndex = 3
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtProducto.Location = New System.Drawing.Point(273, 17)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(141, 21)
        Me.TxtProducto.TabIndex = 0
        '
        'BtnBusquedaProducto
        '
        Me.BtnBusquedaProducto.Image = CType(resources.GetObject("BtnBusquedaProducto.Image"), System.Drawing.Image)
        Me.BtnBusquedaProducto.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaProducto.Location = New System.Drawing.Point(426, 14)
        Me.BtnBusquedaProducto.Name = "BtnBusquedaProducto"
        Me.BtnBusquedaProducto.Size = New System.Drawing.Size(58, 24)
        Me.BtnBusquedaProducto.TabIndex = 1
        Me.BtnBusquedaProducto.ToolTipText = "Busqueda de Producto"
        Me.BtnBusquedaProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Cantidad"
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.Label1)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.BtnBusquedaProducto)
        Me.GrpDetalle.Controls.Add(Me.Label2)
        Me.GrpDetalle.Location = New System.Drawing.Point(12, 118)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(867, 383)
        Me.GrpDetalle.TabIndex = 0
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(177, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Producto"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(81, 18)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.TxtCantidad.TabIndex = 2
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 47)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(854, 328)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmPedido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmPedido"
        Me.Text = "Pedido"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
  

    Private bError As Boolean = False
    Public VENClave As String
    Public CAJClave As String

    Private SUCClave As String
    Private ALMClave As String
    Private StageLU, StageCancelacion As String
  
    Private TallaColor As Integer = 0
    Private CTECLave As String
    Private ListaPrecio As String
    Private TImpuesto As Integer
    Private Estado As Integer
    Private Cantidad As Double
    Private MONClave As String
    Private TipoCambio As Double
    Private TipoDocumento As Integer

    Private dtDetalle As DataTable

    Private Sub FrmPedido_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim i As Integer
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        StageLU = IIf(dt.Rows(0)("StageLU").GetType.Name = "DBNull", "", dt.Rows(i)("StageLU"))
        StageCancelacion = IIf(dt.Rows(0)("StageCancelacion").GetType.Name = "DBNull", "", dt.Rows(i)("StageCancelacion"))

        SUCClave = dt.Rows(0)("SUCClave")
        ALMClave = dt.Rows(0)("ALMClave")
        dt.Dispose()


        If StageLU = "" OrElse StageCancelacion = "" Then
            MessageBox.Show("La Caja Actual no cuenta con Ubicación de Libre Utilización o de Cancelación Asociada.")
            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me

            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                End Select
            Next
        End With
        dt.Dispose()


        With cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With cmbEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With


        dt = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", VENClave)

        TxtFolio.Text = dt.Rows(0)("Folio")
        TxtFecha.Text = CDate(dt.Rows(0)("Fecha")).ToShortDateString
        TxtVendedor.Text = dt.Rows(0)("NombreUsuario")
        TipoDocumento = dt.Rows(0)("Tipo")
        cmbTipo.SelectedValue = TipoDocumento
        Estado = dt.Rows(0)("Estado")
        cmbEstado.SelectedValue = Estado
        CTECLave = dt.Rows(0)("Cliente")
        MONClave = dt.Rows(0)("MONClave")
        TipoCambio = dt.Rows(0)("TipoCambio")

        Dim dtMon As DataTable = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MONClave)
        BtnTC.Text = dtMon.Rows(0)("Referencia")
        dtMon.Dispose()
        LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")

        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTECLave)
        TxtCliente.Text = dt.Rows(0)("Clave")
        TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
        dt.Dispose()

        Dim dtCliente As DataTable
        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", CTECLave)
        ListaPrecio = dtCliente.Rows(0)("PREClave")
        TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
        dtCliente.Dispose()


        dtDetalle = ModPOS.Recupera_Tabla("st_muestra_ventaDet", "@VENClave", VENClave)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure()
        GridDetalle.RootTable.Columns("DVEClave").Visible = False
        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("KgLt").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("PorcDesc").Visible = False
        GridDetalle.RootTable.Columns("GrupoMaterial").Visible = False
        GridDetalle.RootTable.Columns("Sector").Visible = False

        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("Precio Unitario").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Dscto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"
      

        GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Dscto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum


        GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Dscto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Nuevo"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Gray
        GridDetalle.RootTable.FormatConditions.Add(fc)


        If Estado = 4 Then
            GrpDetalle.Enabled = False
        End If


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Estado <> 4 Then
            Dim i As Integer
            Dim ImporteCancelar As Decimal = 0
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("Cancelar >  0 ")

            'Cancela producto
            If foundRows.Length >= 1 Then

                For i = 0 To foundRows.Length - 1
                    ImporteCancelar += foundRows(i)("Cancelar") * foundRows(i)("Precio Unitario")
                Next

                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.MontodeAutorizacion = ImporteCancelar * TipoCambio
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado Then

                        Dim dtVentaDetalle As DataTable
                        For i = 0 To foundRows.Length - 1
                          
                           
                            dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", 1, "@DOCClave", VENClave, "@PROClave", foundRows(i)("PROClave"))
                            recalculaPartidaPedido(dtVentaDetalle, VENClave, foundRows(i)("DVEClave"), foundRows(i)("Cantidad"), foundRows(i)("Cancelar"), foundRows(i)("KgLt"), foundRows(i)("UndKilo"))
                            ModPOS.Ejecuta("st_cancelar_producto_vta", "@VENClave", VENClave, "@ALMClave", ALMClave, "TProducto", foundRows(i)("TProducto"), "@PROClave", foundRows(i)("PROClave"), "@UBCClave", StageCancelacion, "@Cancelar", foundRows(i)("Cancelar"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual, "@Autoriza", a.Autoriza)

                           
                        Next

                        ModPOS.Ejecuta("sp_elimina_detalle_picking", "@Tipo", 1, "@DOCClave", VENClave)
                    End If
                End If

            End If


            ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", VENClave, "@Estado", 2, "@ActSaldo", 1)



        End If
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Cancelar" Then
            If IsNumeric(GridDetalle.GetValue("Cancelar")) AndAlso GridDetalle.GetValue("Nuevo") = 0 Then
                If CDbl(GridDetalle.GetValue("Cancelar")) > CDbl(GridDetalle.GetValue("Cantidad")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad a cancelar no de ser mayor a la actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Cancelar", GridDetalle.GetValue("Cantidad"))
                ElseIf CDbl(GridDetalle.GetValue("Cancelar")) < 0 Then
                    GridDetalle.SetValue("Cancelar", 0)
                End If
            Else
                GridDetalle.SetValue("Cancelar", 0)
            End If
     
        End If
    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Cancelar" Then
                If GridDetalle.GetValue("Nuevo") = 0 Then
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                Else
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                End If
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridDetalle_FormattingRow(sender As Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridDetalle.FormattingRow
        Dim row As Janus.Windows.GridEX.GridEXRow = e.Row
        row.RowStyle = New Janus.Windows.GridEX.GridEXFormatStyle

        If row.Cells("Nuevo").Value = 0 Then
            row.RowStyle.ForeColor = Color.Gray
        Else
            row.RowStyle.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) = 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                Else
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If
            TxtProducto.Focus()

        End If
    End Sub

    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) = 0 Then
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            Else
                Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            Cantidad = 1
            TxtCantidad.Text = CStr(Cantidad)
        End If

        TxtProducto.Focus()
    End Sub

    Public Sub AgregarProducto(ByVal DVEClave As String, ByVal TProducto As Integer, ByVal PROClave As String, ByVal kglt As Integer, ByVal UnidadesKilo As Double, ByVal GrupoMaterial As Integer, ByVal Sector As Integer, ByVal Partida As Integer, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Decimal, ByVal Precio As Decimal, ByVal ImpuestoPor As Decimal, ByVal Descuento As Decimal)
        Dim dBase, dImpts, dTotal, DescPor As Decimal

        dBase = Math.Round(Precio * Cantidad, 2)
        dImpts = Math.Round((dBase - Descuento) * ImpuestoPor, 2)
        dTotal = dBase - Descuento + dImpts

        DescPor = (Descuento / dBase) * 100

        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select(" DVEClave = '" & DVEClave & "'")

        If foundRows.Length = 1 Then

            If kglt = 1 Then
                Nombre &= " " & CStr(UnidadesKilo) & "Unds"
            End If


            foundRows(0)("Nombre") = Nombre
            foundRows(0)("Cantidad") = Cantidad
            foundRows(0)("UndKilo") = UnidadesKilo

            foundRows(0)("Precio Unitario") = TruncateToDecimal(Precio, 2)
            foundRows(0)("Subtotal") = dBase
            foundRows(0)("PorcDesc") = TruncateToDecimal(DescPor, 2)
            foundRows(0)("Dscto") = Descuento
            foundRows(0)("Impuesto") = dImpts
            foundRows(0)("Total") = dTotal

        Else

            If kglt = 1 Then
                Nombre &= " " & CStr(UnidadesKilo) & "Unds"
            End If

            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("DVEClave") = DVEClave
            row1.Item("TProducto") = TProducto
            row1.Item("KgLt") = kglt
            row1.Item("PROClave") = PROClave
            row1.Item("UndKilo") = UnidadesKilo
            row1.Item("GrupoMaterial") = GrupoMaterial
            row1.Item("Sector") = Sector
            row1.Item("Partida") = Partida
            row1.Item("Clave") = GTIN
            row1.Item("Nombre") = Nombre
            row1.Item("Cantidad") = Cantidad
            row1.Item("Cancelar") = 0
            row1.Item("Precio Unitario") = TruncateToDecimal(Precio, 2)
            row1.Item("Subtotal") = dBase
            row1.Item("PorcDesc") = TruncateToDecimal(DescPor, 2)
            row1.Item("Dscto") = Descuento
            row1.Item("Impuesto") = dImpts
            row1.Item("Total") = dTotal
            row1.Item("Nuevo") = 1
            dtDetalle.Rows.Add(row1)
        End If




    End Sub

 
    Public Function AgregaPartida(ByVal dtProducto As DataTable, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bCopy As Boolean, ByVal bRecalculaInventario As Boolean, ByVal bShortCut As Boolean) As Boolean
       
        If Not dtProducto Is Nothing Then
            Dim YaExiste As Boolean = False
            Dim DVEClave As String = ""
            Dim sAutoriza As String = Nothing
            Dim sSUCClave As String = dtProducto.Rows(0)("SUCClave")
            Dim sPROClave As String = dtProducto.Rows(0)("PROClave")
            Dim sClave As String = dtProducto.Rows(0)("Clave")
            Dim sNombre As String = dtProducto.Rows(0)("Nombre")
            Dim dCosto As Decimal = dtProducto.Rows(0)("Costo") / TipoCambio
            Dim dCantidad As Decimal = dtProducto.Rows(0)("Cantidad")
            Dim dApartar As Decimal = dCantidad
            Dim dPrecioUnitario As Decimal = dtProducto.Rows(0)("PrecioBruto") / TipoCambio
            Dim dDescPorc As Decimal = dtProducto.Rows(0)("DescPorc")
            Dim dDescGeneralPor As Decimal = dtProducto.Rows(0)("DescGeneral")

            Dim iTProducto As Integer = dtProducto.Rows(0)("TProducto")
            Dim iSeguimiento As Integer = dtProducto.Rows(0)("Seguimiento")
            Dim iDiasGarantia As Integer = dtProducto.Rows(0)("DiasGarantia")
            Dim iNumDecimales As Integer = dtProducto.Rows(0)("Num_Decimales")

            Dim dGeneralNeto As Decimal = TruncateToDecimal(dtProducto.Rows(0)("PrecioNeto") / TipoCambio, 6)
            Dim dMinimoNeto As Decimal = TruncateToDecimal(dtProducto.Rows(0)("MinimoNeto") / TipoCambio, 6)

            Dim iKgLt As Integer = IIf(dtProducto.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("KgLt"))
            Dim dPeso As Decimal = IIf(dtProducto.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("Peso"))

            dtProducto.Dispose()

            If dCantidad <= 0 Then
                TxtProducto.Text = ""
                Cantidad = 1
                TxtCantidad.Text = "1"
                MessageBox.Show("El producto " & sClave & " no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If dPrecioUnitario = 0 Then
                MessageBox.Show("El producto " & sClave & " no cuenta con precio definido en la lista de precios actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Dim Disponible, Existencia, Apartado, Bloqueado As Double
            Dim dtDisponible As DataTable
            dtDisponible = ModPOS.SiExisteRecupera("st_recupera_peu", "@PROClave", sPROClave, "@UBCClave", StageLU)
            If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                Existencia = dtDisponible.Rows(0)("Existencia")
                Apartado = dtDisponible.Rows(0)("Apartado")
                Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                dtDisponible.Dispose()

                Disponible = Existencia - Apartado - Bloqueado
            Else
                Disponible = 0
            End If

            If dCantidad > Disponible Then
                MessageBox.Show("El producto " & sClave & " no cuenta con existencia disponible en la ubicación de Caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

         
            'Aparta producto en Ubicacion de Caja

            ModPOS.Ejecuta("st_act_existencia_pue", _
                          "@VENClave", VENClave,
                          "@ALMClave", ALMClave, _
                          "@UBCClave", StageLU, _
                          "@PROClave", sPROClave, _
                          "@TProducto", iTProducto, _
                          "@Cantidad", dCantidad, _
                          "@Usuario", ModPOS.UsuarioActual
                           )


            Dim UnidadesKilo As Double

            If iKgLt = 1 Then
                If dPeso > 0 Then
                    UnidadesKilo = dCantidad / dPeso
                Else
                    UnidadesKilo = 1
                End If
            Else
                UnidadesKilo = 0
            End If

            Dim iGrupoMaterial As Integer = 0
            Dim iSector As Integer = 0
            Dim iPartida As Integer
            Dim dVolumen As Decimal = 0
            Dim dVolumenImp As Decimal = 0
            Dim PorcImpProducto As Decimal = ModPOS.RecuperaImpuesto(sSUCClave, sPROClave, TImpuesto)

            'Recupera GrupoMaterial
            dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 1, "@PROClave", sPROClave) 'GrupoMaterial
            If dtProducto.Rows.Count = 1 Then
                iGrupoMaterial = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
            End If
            dtProducto.Dispose()
            'Recupera Sector
            dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 3, "@PROClave", sPROClave) 'Sector
            If dtProducto.Rows.Count = 1 Then
                iSector = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
            End If
            dtProducto.Dispose()

            Dim dOriginal As Decimal

            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select(" PROClave = '" & sPROClave & "'")

            If foundRows.Length = 1 Then
                YaExiste = True
                DVEClave = foundRows(0)("DVEClave")

                dOriginal = foundRows(0)("Cantidad")

                If Suma = True Then
                    dCantidad += foundRows(0)("Cantidad")
                    UnidadesKilo += foundRows(0)("UndKilo")
                ElseIf bShortCut = False Then
                    dCantidad = foundRows(0)("Cantidad")
                    UnidadesKilo = foundRows(0)("UndKilo")
                End If

                dPrecioUnitario = foundRows(0)("Precio Unitario")
             
                If foundRows(0)("PorcDesc") > 0 Then
                    Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", DVEClave)
                    If Not dtDescuento Is Nothing Then
                        'Descuento General
                        foundRows = dtDescuento.Select(" Tipo = 1 ")
                        If foundRows.Length = 1 Then
                            dDescGeneralPor = foundRows(0)("DescuentoPorc") * 100
                        End If

                        'Descuento Volumen
                        foundRows = dtDescuento.Select(" Tipo = 2")
                        If foundRows.Length = 1 Then
                            dVolumen = foundRows(0)("DescuentoPorc") * 100
                        End If


                        'Descuento Gerencial
                        foundRows = dtDescuento.Select(" Tipo = 3 ")
                        If foundRows.Length = 1 Then
                            dDescPorc = foundRows(0)("DescuentoPorc") * 100
                        End If
                        dtDescuento.Dispose()
                    End If
                End If
            Else
                YaExiste = False
                dOriginal = 0
            End If

            Dim oVolumen As Decimal = dVolumen

            Dim StrucVol As DescVol
            Dim sTipoDesc As String

            Dim dBase As Decimal

            dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

            Dim dDescGeneralImp As Decimal = Math.Round(dBase * (dDescGeneralPor / 100), 2)

            StrucVol = obtenerDescuentoVolumen(CTECLave, iGrupoMaterial, iSector, VENClave, sPROClave, dBase - dDescGeneralImp, True)

            dVolumen = StrucVol.Descuento
            sTipoDesc = StrucVol.Tipo

            If dVolumen > 0 Then
                dVolumenImp = Math.Round((dBase - dDescGeneralImp) * (dVolumen / 100), 2)
            Else
                dVolumenImp = 0
            End If

            Dim dDescuentoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * (dDescPorc / 100), 2)
            Dim dImpuestoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * PorcImpProducto, 2)

            Dim dImporteNeto As Decimal = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


            'Modifica pedido

            If YaExiste Then

                'Actualiza Cantidad de producto
                'IIf(dOriginal >= dCantidad, dCantidad, dCantidad - dOriginal), _
                ModPOS.Ejecuta("sp_actualiza_detalle", _
                "@ALMClave", ALMClave, _
                "@VENTA", VENClave, _
                "@PROClave", sPROClave, _
                "@PrecioBruto", dPrecioUnitario, _
                "@Cantidad", dCantidad, _
                "@Importe", dBase, _
                "@DescGenPor", dDescGeneralPor / 100, _
                "@DescGenImp", dDescGeneralImp, _
                "@DescVolPor", dVolumen / 100, _
                "@DescVolImp", dVolumenImp, _
                "@DescuentoPor", dDescPorc / 100, _
                "@DescuentoImp", dDescuentoImp, _
                "@ImpuestoImp", dImpuestoImp, _
                "@TProducto", iTProducto, _
                "@TipoDoc", TipoDocumento, _
                "@Picking", Picking, _
                "@UndKilo", UnidadesKilo, _
                "@DVEClave", DVEClave, _
                "@PorcImp", PorcImpProducto, _
                "@Usuario", ModPOS.UsuarioActual, _
                "@TipoDesc", sTipoDesc, _
                "@Autoriza", sAutoriza, _
                "@Total", dImporteNeto,
                "@Cerrado", 1)

                Dim dtDet As DataTable
                dtDet = ModPOS.SiExisteRecupera("st_vent_det_closed", "@DVEClave", DVEClave)
                If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                    ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 1)
                    dtDet.Dispose()
                End If


            Else
                'Inserta Producto
                DVEClave = ModPOS.obtenerLlave

                If dtDetalle.Compute("MAX(Partida)", "").GetType.FullName = "System.DBNull" Then
                    iPartida = 10
                Else
                    iPartida = CInt(dtDetalle.Compute("MAX(Partida)", "")) + 10
                End If

                ModPOS.Ejecuta("sp_inserta_detalle", _
                "@DVEClave", DVEClave, _
                "@VENTA", VENClave, _
                "@PROClave", sPROClave, _
                "@Costo", dCosto, _
                "@PREClave", ListaPrecio, _
                "@PrecioBruto", dPrecioUnitario, _
                "@Cantidad", dCantidad, _
                "@Importe", dBase, _
                "@DescGenPor", dDescGeneralPor / 100, _
                "@DescGenImp", dDescGeneralImp, _
                "@DescVolPor", dVolumen / 100, _
                "@DescVolImp", dVolumenImp, _
                "@DescuentoPor", dDescPorc / 100, _
                "@DescuentoImp", dDescuentoImp, _
                "@PorcImp", PorcImpProducto, _
                "@ImpuestoImp", dImpuestoImp, _
                "@Total", dImporteNeto, _
                "@ALMClave", ALMClave, _
                "@TipoDoc", TipoDocumento, _
                "@TProducto", iTProducto, _
                "@Picking", Picking, _
                "@Autoriza", sAutoriza, _
                "@UndKilo", UnidadesKilo, _
                "@GrupoMaterial", iGrupoMaterial, _
                "@Sector", iSector, _
                "@Partida", iPartida, _
                "@TipoDesc", sTipoDesc, _
                "@Usuario", ModPOS.UsuarioActual,
                "@Cerrado", 1)

                'Inserta detalle de Impuestos por partida
                ModPOS.InsertaImpuesto(DVEClave, sPROClave, (dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp), TImpuesto, sSUCClave, 1)

            End If


            'SI REQUIERE SEGUIMIENTO DE SERIAL
            If iSeguimiento = 2 Then
                Dim SerialReg As Integer = 0
                Dim PorRegistrar As Double
                PorRegistrar = dCantidad
                Do
                    Dim a As New FrmSerial
                    a.DOCClave = VENClave
                    a.PROClave = sPROClave
                    a.Clave = sClave
                    a.Nombre = sNombre
                    a.Cantidad = PorRegistrar
                    a.Dias = iDiasGarantia
                    a.TipoDoc = 1
                    a.TipoMov = 2
                    a.ShowDialog()
                    SerialReg = SerialReg + a.NumSerialRegistrados
                    PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                    a.Dispose()
                Loop Until SerialReg = dCantidad OrElse PorRegistrar = 0
            End If

            'SI REQUIERE SEGUIMIENTO DE LOTE
            If iSeguimiento = 3 Then
                Dim LoteReg As Integer = 0
                Dim PorRegistrar As Double
                PorRegistrar = dCantidad
                Do
                    Dim a As New FrmLote
                    a.DOCClave = VENClave
                    a.PROClave = sPROClave
                    a.Clave = sClave
                    a.Nombre = sNombre
                    a.CantXRegistrar = PorRegistrar
                    a.TipoDoc = 1
                    a.TipoMov = 2
                    a.ShowDialog()
                    LoteReg = LoteReg + a.NumSerialRegistrados
                    PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                    a.Dispose()
                Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
            End If


            'recalcula productos que tengan descuento de volumen
            If oVolumen <> dVolumen Then
                Dim dtVolumen As DataTable
                dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "", "@Cerrado", 1)
                If dtVolumen.Rows.Count > 0 Then
                    Dim y As Integer
                    For y = 0 To dtVolumen.Rows.Count - 1
                        ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)
                    Next
                End If
            End If


            ' AGREGAR PRODUCTO A LISTA
            AgregarProducto(DVEClave, iTProducto, sPROClave, iKgLt, UnidadesKilo, iGrupoMaterial, iSector, iPartida, sClave, sNombre, dCantidad, dPrecioUnitario, PorcImpProducto, dDescGeneralImp + dVolumenImp + dDescuentoImp)

        Else
            Beep()
            MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TxtProducto.Text = ""
        Cantidad = 1
        TxtCantidad.Text = "1"
        Return False
    End Function

    Private Sub recalculaPartidaPedido(ByVal dtDetalle As DataTable, ByVal DOCClave As String, ByVal DETClave As String, ByVal dCantidadOriginal As Decimal, ByVal dFaltante As Decimal, ByVal iKgLt As Integer, ByVal PesoUnidad As Double)
        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("DETClave = '" & DETClave & "'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer

            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer

            Dim sTipoDesc As String = ""

            Dim TImpuesto As Integer
            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", foundRows(0)("Cliente"))
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()

            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")


                dCantidad = dCantidadOriginal - dFaltante



                dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

                Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", foundRows(i)("DETClave"))
                If Not dtDescuento Is Nothing Then
                    'Descuento General
                    Dim foundRows1() As DataRow = dtDescuento.Select(" Tipo = 1 ")
                    If foundRows1.Length = 1 Then
                        dDescGeneralPorc = foundRows1(0)("DescuentoPorc")
                    Else
                        dDescGeneralPorc = 0
                    End If

                    'Descuento Volumen
                    foundRows1 = dtDescuento.Select(" Tipo = 2")
                    If foundRows1.Length = 1 Then
                        oVolumen = foundRows1(0)("DescuentoPorc")
                    Else
                        oVolumen = 0
                    End If


                    'Descuento Gerencial
                    foundRows1 = dtDescuento.Select(" Tipo = 3 ")
                    If foundRows1.Length = 1 Then
                        dDescPorc = foundRows1(0)("DescuentoPorc")
                    Else
                        dDescPorc = 0
                    End If
                    dtDescuento.Dispose()
                Else
                    dDescPorc = 0
                    oVolumen = 0
                    dDescGeneralPorc = 0
                End If

                dDescGeneralImp = Math.Round(dBase * dDescGeneralPorc, 2)

                If oVolumen > 0 Then

                    Dim StrucVol As DescVol

                    StrucVol = obtenerDescuentoVolumen(foundRows(i)("Cliente"), iGrupoMaterial, iSector, DOCClave, foundRows(i)("PROClave"), dBase - dDescGeneralImp)

                    dVolumen = StrucVol.Descuento
                    sTipoDesc = StrucVol.Tipo

                    If dVolumen > 0 Then
                        dVolumenImp = Math.Round((dBase - dDescGeneralImp) * dVolumen, 2)
                    Else
                        dVolumenImp = 0
                    End If


                    'recalcula productos que tengan descuento de volumen
                    If oVolumen <> dVolumen Then
                        Dim dtVolumen As DataTable
                        dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", DOCClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "", "@Cerrado", 1)
                        If dtVolumen.Rows.Count > 0 Then
                            Dim y As Integer
                            For y = 0 To dtVolumen.Rows.Count - 1
                                ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)
                            Next


                        End If
                    End If
                End If

                dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


                Select Case dFaltante

                    Case Is = dCantidadOriginal
                        'Elimina partida y libera apartado
                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                        "@ALMClave", ALMClave, _
                                        "@VENTA", DOCClave, _
                                        "@PROClave", foundRows(i)("PROClave"), _
                                        "@PrecioBruto", dPrecioUnitario, _
                                        "@Cantidad", 0, _
                                        "@Importe", dBase, _
                                        "@DescGenPor", dDescGeneralPorc, _
                                        "@DescGenImp", dDescGeneralImp, _
                                        "@DescVolPor", dVolumen, _
                                        "@DescVolImp", dVolumenImp, _
                                        "@DescuentoPor", dDescPorc, _
                                        "@DescuentoImp", dDescuentoImp, _
                                        "@ImpuestoImp", dImpuestoImp, _
                                        "@TProducto", foundRows(i)("TProducto"), _
                                        "@TipoDoc", 1, _
                                        "@Picking", Picking, _
                                        "@UndKilo", 0, _
                                        "@DVEClave", foundRows(i)("DVEClave"), _
                                        "@PorcImp", dPorcImp, _
                                        "@Usuario", ModPOS.UsuarioActual, _
                                        "@TipoDesc", sTipoDesc, _
                                        "@Autoriza", "", _
                                        "@Total", dImporteNeto, _
                                        "@Cerrado", 1)

                    Case Else
                        'Actualiza total de la partida y libera apartado

                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                          "@ALMClave", ALMClave, _
                                          "@VENTA", DOCClave, _
                                          "@PROClave", foundRows(i)("PROClave"), _
                                          "@PrecioBruto", dPrecioUnitario, _
                                          "@Cantidad", dCantidad, _
                                          "@Importe", dBase, _
                                          "@DescGenPor", dDescGeneralPorc, _
                                          "@DescGenImp", dDescGeneralImp, _
                                          "@DescVolPor", dVolumen, _
                                          "@DescVolImp", dVolumenImp, _
                                          "@DescuentoPor", dDescPorc, _
                                          "@DescuentoImp", dDescuentoImp, _
                                          "@ImpuestoImp", dImpuestoImp, _
                                          "@TProducto", foundRows(i)("TProducto"), _
                                          "@TipoDoc", 1, _
                                          "@Picking", Picking, _
                                          "@UndKilo", dCantidad / PesoUnidad, _
                                          "@DVEClave", foundRows(i)("DVEClave"), _
                                          "@PorcImp", dPorcImp, _
                                          "@Usuario", ModPOS.UsuarioActual, _
                                          "@TipoDesc", sTipoDesc, _
                                          "@Autoriza", "", _
                                          "@Total", dImporteNeto, _
                                          "@Cerrado", 1)




                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("st_vent_det_closed", "@DVEClave", foundRows(i)("DVEClave"))
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 1)
                            dtDet.Dispose()
                        End If


                End Select






            Next



        End If
    End Sub

    Private Function leeCodigoBarras(ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bCopy As Boolean, ByVal bRecalcular As Boolean, ByVal bValidaOpen As Boolean, ByVal bShortCut As Boolean) As Boolean
        'Valida que el campo producto no se encuentre vacio
        If Not Codigo = vbNullString Then

            'Si el campo cantidad esta vacio lo cambia a 1 por defecto
            If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                Cantidad = 1
                TxtCantidad.Text = "1"
            Else
                Cantidad = CDbl(TxtCantidad.Text)
            End If
            Dim dt As DataTable = Nothing


            'Busca y recupera los datos del producto
            Dim BacktoSearh As Boolean

            'Si Modulo TallaColor 
            If TallaColor = 1 Then
                Dim dtModelo As DataTable = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Codigo)
                If dtModelo.Rows.Count > 0 Then
                    Dim a As New FrmTallaColor
                    a.sModelo = dtModelo.Rows(0)("Modelo")
                    a.ALMClave = ALMClave
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then

                        dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", a.Clave, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTECLave, "@Cantidad", Cantidad, "@Char", cReplace, "@Servicio", False)

                    End If
                    dtModelo.Dispose()
                Else
                    dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTECLave, "@Cantidad", Cantidad, "@Char", cReplace, "@Servicio", False)
                End If
            Else
                dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTECLave, "@Cantidad", Cantidad, "@Char", cReplace, "@Servicio", False)

            End If



            If dt Is Nothing Then
                Beep()
                MessageBox.Show("El Código " & Codigo & " no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else

                BacktoSearh = AgregaPartida(dt, Suma, Busca, bCopy, bRecalcular, bShortCut)
               

                dt.Dispose()

                Return BacktoSearh

            End If


        End If
    End Function



    Private Sub TxtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), True, False, False, True, True, False)
        End If
    End Sub

    Private Sub BtnBusquedaProducto_Click(sender As Object, e As EventArgs) Handles BtnBusquedaProducto.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_producto_ubc"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.AlmRequerido = True
        a.ALMClave = StageLU
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            leeCodigoBarras(a.valor, True, False, False, True, True, False)
        End If
        a.Dispose()
    End Sub
End Class
