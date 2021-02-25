Public Class FrmPagoCXC
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.


    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label



    Friend WithEvents GridMovAlm As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpMovAlm As System.Windows.Forms.GroupBox
    Friend WithEvents grpMovAlmDet As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridResumen As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GridAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GridLiquidacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblIngresos As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblLiquidado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTotalAbonos As System.Windows.Forms.Label
    Friend WithEvents LblTotalLiquidar As System.Windows.Forms.Label
    Friend WithEvents LblEgresos As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionProd As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionVta As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblTotalComision As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalirLiq As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSalirCxC As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GridCxC As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblTot As System.Windows.Forms.Label
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMovAlmDet As Janus.Windows.GridEX.GridEX

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoCXC))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.grpMovAlmDet = New System.Windows.Forms.GroupBox()
        Me.GridMovAlmDet = New Janus.Windows.GridEX.GridEX()
        Me.grpMovAlm = New System.Windows.Forms.GroupBox()
        Me.GridMovAlm = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridResumen = New Janus.Windows.GridEX.GridEX()
        Me.LblTotalComision = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GridComisionProd = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GridComisionVta = New Janus.Windows.GridEX.GridEX()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblLiquidado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblTotalAbonos = New System.Windows.Forms.Label()
        Me.LblTotalLiquidar = New System.Windows.Forms.Label()
        Me.LblEgresos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblIngresos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GridLiquidacion = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX()
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblTot = New System.Windows.Forms.Label()
        Me.BtnSalirCxC = New Janus.Windows.EditControls.UIButton()
        Me.BtnPago = New Janus.Windows.EditControls.UIButton()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalirLiq = New Janus.Windows.EditControls.UIButton()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.grpMovAlmDet.SuspendLayout()
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovAlm.SuspendLayout()
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 328)
        Me.Panel1.TabIndex = 1
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(174, 17)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(609, 22)
        Me.TxtRazonSocial.TabIndex = 5
        '
        'LblClave
        '
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblClave.Location = New System.Drawing.Point(115, 21)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(53, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Cliente"
        '
        'grpMovAlmDet
        '
        Me.grpMovAlmDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMovAlmDet.Controls.Add(Me.GridMovAlmDet)
        Me.grpMovAlmDet.Location = New System.Drawing.Point(234, 1)
        Me.grpMovAlmDet.Name = "grpMovAlmDet"
        Me.grpMovAlmDet.Size = New System.Drawing.Size(534, 331)
        Me.grpMovAlmDet.TabIndex = 5
        Me.grpMovAlmDet.TabStop = False
        Me.grpMovAlmDet.Text = "Detalle"
        '
        'GridMovAlmDet
        '
        Me.GridMovAlmDet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMovAlmDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMovAlmDet.ColumnAutoResize = True
        Me.GridMovAlmDet.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMovAlmDet.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMovAlmDet.GroupByBoxVisible = False
        Me.GridMovAlmDet.Location = New System.Drawing.Point(6, 15)
        Me.GridMovAlmDet.Name = "GridMovAlmDet"
        Me.GridMovAlmDet.RecordNavigator = True
        Me.GridMovAlmDet.Size = New System.Drawing.Size(522, 309)
        Me.GridMovAlmDet.TabIndex = 3
        Me.GridMovAlmDet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpMovAlm
        '
        Me.grpMovAlm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpMovAlm.Controls.Add(Me.GridMovAlm)
        Me.grpMovAlm.Location = New System.Drawing.Point(0, 1)
        Me.grpMovAlm.Name = "grpMovAlm"
        Me.grpMovAlm.Size = New System.Drawing.Size(231, 330)
        Me.grpMovAlm.TabIndex = 4
        Me.grpMovAlm.TabStop = False
        Me.grpMovAlm.Text = "Documentos"
        '
        'GridMovAlm
        '
        Me.GridMovAlm.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMovAlm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMovAlm.ColumnAutoResize = True
        Me.GridMovAlm.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMovAlm.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMovAlm.GroupByBoxVisible = False
        Me.GridMovAlm.Location = New System.Drawing.Point(6, 15)
        Me.GridMovAlm.Name = "GridMovAlm"
        Me.GridMovAlm.RecordNavigator = True
        Me.GridMovAlm.Size = New System.Drawing.Size(219, 308)
        Me.GridMovAlm.TabIndex = 3
        Me.GridMovAlm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GridResumen)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(758, 366)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'GridResumen
        '
        Me.GridResumen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridResumen.ColumnAutoResize = True
        Me.GridResumen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridResumen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridResumen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridResumen.GroupByBoxVisible = False
        Me.GridResumen.Location = New System.Drawing.Point(6, 15)
        Me.GridResumen.Name = "GridResumen"
        Me.GridResumen.RecordNavigator = True
        Me.GridResumen.Size = New System.Drawing.Size(746, 344)
        Me.GridResumen.TabIndex = 3
        Me.GridResumen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblTotalComision
        '
        Me.LblTotalComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComision.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalComision.Location = New System.Drawing.Point(650, 339)
        Me.LblTotalComision.Name = "LblTotalComision"
        Me.LblTotalComision.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalComision.TabIndex = 87
        Me.LblTotalComision.Text = "0,0"
        Me.LblTotalComision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(531, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 15)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "T. a Comsión"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.GridComisionProd)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 128)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(758, 202)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Comisión por Producto"
        '
        'GridComisionProd
        '
        Me.GridComisionProd.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisionProd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisionProd.ColumnAutoResize = True
        Me.GridComisionProd.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisionProd.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisionProd.GroupByBoxVisible = False
        Me.GridComisionProd.Location = New System.Drawing.Point(6, 15)
        Me.GridComisionProd.Name = "GridComisionProd"
        Me.GridComisionProd.RecordNavigator = True
        Me.GridComisionProd.Size = New System.Drawing.Size(746, 180)
        Me.GridComisionProd.TabIndex = 3
        Me.GridComisionProd.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.GridComisionVta)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(758, 119)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Comisión por Venta"
        '
        'GridComisionVta
        '
        Me.GridComisionVta.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisionVta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisionVta.ColumnAutoResize = True
        Me.GridComisionVta.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisionVta.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisionVta.GroupByBoxVisible = False
        Me.GridComisionVta.Location = New System.Drawing.Point(6, 15)
        Me.GridComisionVta.Name = "GridComisionVta"
        Me.GridComisionVta.RecordNavigator = True
        Me.GridComisionVta.Size = New System.Drawing.Size(746, 97)
        Me.GridComisionVta.TabIndex = 3
        Me.GridComisionVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblSaldo.Location = New System.Drawing.Point(0, 0)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(113, 15)
        Me.LblSaldo.TabIndex = 90
        Me.LblSaldo.Text = "0.0"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(525, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 15)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "Saldo"
        '
        'LblLiquidado
        '
        Me.LblLiquidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLiquidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLiquidado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblLiquidado.Location = New System.Drawing.Point(644, 234)
        Me.LblLiquidado.Name = "LblLiquidado"
        Me.LblLiquidado.Size = New System.Drawing.Size(113, 15)
        Me.LblLiquidado.TabIndex = 88
        Me.LblLiquidado.Text = "0.0"
        Me.LblLiquidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(525, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 15)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Liquidado"
        '
        'LblTotalAbonos
        '
        Me.LblTotalAbonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalAbonos.Location = New System.Drawing.Point(87, 234)
        Me.LblTotalAbonos.Name = "LblTotalAbonos"
        Me.LblTotalAbonos.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalAbonos.TabIndex = 86
        Me.LblTotalAbonos.Text = "0,0"
        Me.LblTotalAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalLiquidar
        '
        Me.LblTotalLiquidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalLiquidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalLiquidar.Location = New System.Drawing.Point(328, 282)
        Me.LblTotalLiquidar.Name = "LblTotalLiquidar"
        Me.LblTotalLiquidar.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalLiquidar.TabIndex = 85
        Me.LblTotalLiquidar.Text = "0,0"
        Me.LblTotalLiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblEgresos
        '
        Me.LblEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEgresos.Location = New System.Drawing.Point(328, 254)
        Me.LblEgresos.Name = "LblEgresos"
        Me.LblEgresos.Size = New System.Drawing.Size(113, 15)
        Me.LblEgresos.TabIndex = 84
        Me.LblEgresos.Text = "0,0"
        Me.LblEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "T. Abonos"
        '
        'LblIngresos
        '
        Me.LblIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblIngresos.Location = New System.Drawing.Point(329, 234)
        Me.LblIngresos.Name = "LblIngresos"
        Me.LblIngresos.Size = New System.Drawing.Size(113, 15)
        Me.LblIngresos.TabIndex = 82
        Me.LblIngresos.Text = "0,0"
        Me.LblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(209, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "T. a Liquidar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(209, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "T. Egreso"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(210, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "T. Ingreso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.GridLiquidacion)
        Me.GroupBox4.Location = New System.Drawing.Point(206, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(557, 223)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resumen"
        '
        'GridLiquidacion
        '
        Me.GridLiquidacion.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLiquidacion.ColumnAutoResize = True
        Me.GridLiquidacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLiquidacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLiquidacion.GroupByBoxVisible = False
        Me.GridLiquidacion.Location = New System.Drawing.Point(6, 15)
        Me.GridLiquidacion.Name = "GridLiquidacion"
        Me.GridLiquidacion.RecordNavigator = True
        Me.GridLiquidacion.Size = New System.Drawing.Size(545, 201)
        Me.GridLiquidacion.TabIndex = 3
        Me.GridLiquidacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.GridAbonos)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(195, 223)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Abonos"
        '
        'GridAbonos
        '
        Me.GridAbonos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAbonos.ColumnAutoResize = True
        Me.GridAbonos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAbonos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAbonos.GroupByBoxVisible = False
        Me.GridAbonos.Location = New System.Drawing.Point(6, 15)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(183, 201)
        Me.GridAbonos.TabIndex = 3
        Me.GridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.BtnConsultar)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.LblClave)
        Me.GrpTickets.Controls.Add(Me.LblTot)
        Me.GrpTickets.Controls.Add(Me.BtnSalirCxC)
        Me.GrpTickets.Controls.Add(Me.BtnPago)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Controls.Add(Me.TxtRazonSocial)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(789, 473)
        Me.GrpTickets.TabIndex = 82
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cuentas por Cobrar"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Image = CType(resources.GetObject("BtnConsultar.Image"), System.Drawing.Image)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnConsultar.Location = New System.Drawing.Point(546, 432)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(116, 37)
        Me.BtnConsultar.TabIndex = 55
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.ToolTipText = "Consultar documento"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTotal.Location = New System.Drawing.Point(207, 432)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(214, 35)
        Me.LblTotal.TabIndex = 54
        Me.LblTotal.Text = "0.00"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTot
        '
        Me.LblTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTot.Location = New System.Drawing.Point(6, 439)
        Me.LblTot.Name = "LblTot"
        Me.LblTot.Size = New System.Drawing.Size(195, 28)
        Me.LblTot.TabIndex = 53
        Me.LblTot.Text = "TOTAL A PAGAR"
        '
        'BtnSalirCxC
        '
        Me.BtnSalirCxC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirCxC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirCxC.Image = CType(resources.GetObject("BtnSalirCxC.Image"), System.Drawing.Image)
        Me.BtnSalirCxC.Location = New System.Drawing.Point(427, 432)
        Me.BtnSalirCxC.Name = "BtnSalirCxC"
        Me.BtnSalirCxC.Size = New System.Drawing.Size(116, 37)
        Me.BtnSalirCxC.TabIndex = 52
        Me.BtnSalirCxC.Text = "&Salir"
        Me.BtnSalirCxC.ToolTipText = "Salir"
        Me.BtnSalirCxC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnPago
        '
        Me.BtnPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPago.Icon = CType(resources.GetObject("BtnPago.Icon"), System.Drawing.Icon)
        Me.BtnPago.Location = New System.Drawing.Point(666, 432)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(116, 37)
        Me.BtnPago.TabIndex = 51
        Me.BtnPago.Text = "Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago de registros seleccionados"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 21)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(94, 20)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(154, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 45)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(776, 383)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(318, 335)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(108, 32)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nuevo transferencia"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(431, 335)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(108, 32)
        Me.BtnModificar.TabIndex = 16
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar transferencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(543, 335)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(108, 32)
        Me.BtnEliminar.TabIndex = 15
        Me.BtnEliminar.Text = "&Salir"
        Me.BtnEliminar.ToolTipText = "Cancelar transferencia seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(205, 335)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(108, 32)
        Me.BtnReimpresion.TabIndex = 14
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de transferencia seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(657, 335)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(108, 32)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalirLiq
        '
        Me.BtnSalirLiq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirLiq.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirLiq.Image = CType(resources.GetObject("BtnSalirLiq.Image"), System.Drawing.Image)
        Me.BtnSalirLiq.Location = New System.Drawing.Point(655, 329)
        Me.BtnSalirLiq.Name = "BtnSalirLiq"
        Me.BtnSalirLiq.Size = New System.Drawing.Size(108, 32)
        Me.BtnSalirLiq.TabIndex = 92
        Me.BtnSalirLiq.Text = "&Salir"
        Me.BtnSalirLiq.ToolTipText = "Salir"
        Me.BtnSalirLiq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.Location = New System.Drawing.Point(539, 331)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(110, 30)
        Me.BtnCerrar.TabIndex = 91
        Me.BtnCerrar.Text = "F9- Cerrar"
        Me.BtnCerrar.ToolTipText = "Cierra el Documento Actual"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(650, 326)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(108, 32)
        Me.UiButton1.TabIndex = 52
        Me.UiButton1.Text = "&Salir"
        Me.UiButton1.ToolTipText = "Salir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPagoCXC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmPagoCXC"
        Me.Text = "Cobranza"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpMovAlmDet.ResumeLayout(False)
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovAlm.ResumeLayout(False)
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private bLoad As Boolean = False
    Public TallaColor As Integer
    Public TICDevolucion As String
    Public InterfazSalida As String = ""
    Public RefMoneda As String
    Public sCTEClave As String
    Public sRazonSocial As String = ""
    Public Cajon As Boolean = False
    Public CAJClave As String
    Public Impresora, ClaveCaja As String
    Public SUCClave As String = ""
    Public FormatoFactura As String = ""
    Public FormatoPedido, FormatoRecibo As String
    Public reciboTicket As Integer = 0
    Public PrintGeneric As Boolean = False
    Public Recibo As String
    Public ConfirmarAbono As Integer = 0
    Public idCorte As String = ""
    Public LimitarCobrosFactura As Integer = 0

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private dtCxC As DataTable
    Private SaldoBase As Decimal
    Private idEvento As String



    Private Sub FrmPagoCXC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        ClaveCaja = dt.Rows(0)("Clave")
        dt.Dispose()

        alerta(0) = Me.PictureBox2

        Me.StartPosition = FormStartPosition.CenterScreen

        TxtRazonSocial.Text = sRazonSocial

        LblTot.Text = "TOTAL A PAGAR: " & RefMoneda

        ActualizaGridCxC()

    End Sub

    Private Sub FrmPagoCXC_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoCXC.actualizaGridCreditos()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Public Sub ActualizaGridCxC()

        If Not dtCxC Is Nothing Then
            dtCxC.Dispose()
        End If

        Cursor.Current = Cursors.WaitCursor

        dtCxC = ModPOS.Recupera_Tabla("sp_recupera_cte_cxc", "@CTEClave", sCTEClave)
        GridCxC.DataSource = dtCxC
        GridCxC.RetrieveStructure()
        GridCxC.AutoSizeColumns()
        GridCxC.RootTable.Columns("MONClave").Visible = False
        GridCxC.RootTable.Columns("SaldoBase").Visible = False
        GridCxC.RootTable.Columns("ID").Visible = False
        GridCxC.CurrentTable.Columns(2).Selectable = False
        GridCxC.CurrentTable.Columns(3).Selectable = False
        GridCxC.CurrentTable.Columns(4).Selectable = False
        GridCxC.CurrentTable.Columns(5).Selectable = False
        GridCxC.CurrentTable.Columns(6).Selectable = False
        GridCxC.CurrentTable.Columns(7).Selectable = False
        GridCxC.CurrentTable.Columns(8).Selectable = False
        GridCxC.CurrentTable.Columns("Vencido").Visible = False
        GridCxC.CurrentTable.Columns("TipoCF").Visible = False
        GridCxC.CurrentTable.Columns("TipoDocumento").Visible = False
        GridCxC.CurrentTable.Columns("Logo").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCxC.RootTable.Columns("Vencido"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.ForeColor = Color.Red
        GridCxC.RootTable.FormatConditions.Add(fc)

        SaldoBase = 0
        ChkMarcaTodos.Enabled = True

        Cursor.Current = Cursors.Default

    End Sub


    Private Sub BtnSalirCxC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub BtnPago_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        Dim idEvento As String = ""
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtCxC.Select("Marca ='True' and Saldo > 0")

            If foundRows.GetLength(0) > 0 Then


                If LimitarCobrosFactura = 1 Then
                    Dim fr() As DataRow
                    fr = dtCxC.Select("Marca ='True' and TipoDocumento = 1 and Tipo <> 'Contado'")

                    If fr.GetLength(0) >= 1 Then
                        MessageBox.Show("No es posible aplicar pagos o vales a ventas de crédito no facturadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If


                Dim dtDoctos, dtAbnSaldo As DataTable
                dtDoctos = foundRows.CopyToDataTable()


                Dim foundRowsFac() As DataRow
                foundRowsFac = dtDoctos.Select("TipoDocumento=2")
                If foundRowsFac.GetLength(0) > 0 AndAlso Me.LimitarCobrosFactura = 1 Then
                    If ModPOS.ValidaCobroFactura(foundRowsFac.CopyToDataTable(), idCorte) = False Then
                        Exit Sub
                    End If
                End If

                dtAbnSaldo = Recupera_Tabla("sp_aplicar_abn", "@CTEClave", sCTEClave)
                If dtAbnSaldo.Rows.Count > 0 Then


                    'Validar Promociones Pago
                    Dim i As Integer
                    Dim dtPromo As DataTable
                    Dim AplicaAnticipos As Boolean = True

                    If dtDoctos.Rows.Count > 1 Then
                        For i = 0 To dtDoctos.Rows.Count - 1
                            If CInt(dtDoctos.Rows(i)("TipoDocumento")) = 1 Then
                                dtPromo = ModPOS.Recupera_Tabla("st_valida_pago_promo", "@VENClave", CStr(dtDoctos.Rows(i)("ID")))

                                If dtPromo.Rows.Count > 0 Then
                                    MessageBox.Show("El documento: " & CStr(dtDoctos.Rows(i)("Folio")) & ", tiene promociones que limitan esta forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Next
                    Else
                        If CInt(dtDoctos.Rows(0)("TipoDocumento")) = 1 Then
                            dtPromo = ModPOS.Recupera_Tabla("st_valida_pago_promo", "@VENClave", CStr(dtDoctos.Rows(0)("ID")))
                            If dtPromo.Rows.Count > 0 Then
                                MessageBox.Show("El documento: " & CStr(dtDoctos.Rows(0)("Folio")) & ", tiene promociones que limitan esta forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                AplicaAnticipos = False
                            End If
                        End If
                    End If

                    If AplicaAnticipos = True Then
                        Dim b As New FrmAbnPendiente
                        b.BtnCancel.Text = "Ignorar"
                        b.Abonos = dtAbnSaldo
                        b.MonRef =
                        b.SaldoDocumento = SaldoBase
                        b.ShowDialog()
                        If b.DialogResult = DialogResult.OK Then
                            If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                                idEvento = obtenerLlave()

                                Dim sFolio, sFecha As String
                                Dim dtInterfaz As DataTable = Nothing

                                If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "AplicacionNC", "@COMClave", ModPOS.CompanyActual)
                                End If

                                For i = 0 To b.drAbonos.Length - 1
                                    ModPOS.Aplica_Pagos(dtDoctos, sCTEClave, b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("SaldoBase"), CAJClave, b.drAbonos(i)("Tipo"), b.drAbonos(i)("Fecha"), idEvento, TallaColor)


                                    Try
                                        If b.drAbonos(i)("Vale") = 1 AndAlso TallaColor = 1 Then
                                            ImprimeVale(b.drAbonos(i)("ID"), Impresora, TICDevolucion, True, b.drAbonos(i)("Tipo"), True, True)
                                        End If

                                        If b.drAbonos(i)("Tipo") <> -1 AndAlso TallaColor = 1 Then
                                            imprimirRecibo(b.drAbonos(i)("ID"), FormatoRecibo, True, Impresora, 0, " ")
                                        End If



                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message)
                                    End Try


                                    Try
                                        If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 1 OrElse dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                            sFolio = b.drAbonos(i)("ID")
                                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                                            If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", b.drAbonos(i)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                            End If
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message)
                                    End Try



                                Next
                            End If
                        End If
                    End If
                End If
                dtAbnSaldo.Dispose()

                Dim SaldoDoctos As Decimal = IIf(dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0") Is System.DBNull.Value, 0, dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0"))

                If SaldoDoctos > 0 Then
                    Dim a As New FrmAbono
                    a.SUCClave = SUCClave
                    a.dtDocumentos = dtDoctos
                    a.VariosPagos = IIf(dtDoctos.Rows.Count = 1, False, True)
                    a.TipoDocumento = dtDoctos.Rows(0)("TipoDocumento")
                    a.CAJA = CAJClave
                    a.ClaveCaja = ClaveCaja
                    a.ClaveCte = sCTEClave
                    a.ClaveDocumento = dtDoctos.Rows(0)("ID")
                    a.SaldoAcumulado = SaldoDoctos
                    a.AperturaCajon = Cajon
                    a.ImpresoraCajon = Impresora
                    a.ConfirmarAbono = ConfirmarAbono
                    a.PagoCXC = True
                    a.ShowDialog()

                    If a.DialogResult = DialogResult.OK Then
                        If a.detallePago.Rows.Count > 0 Then
                            Dim i As Integer
                            Dim sFolio, sFecha As String
                            Dim dtInterfaz As DataTable = Nothing
                            idEvento = IIf(idEvento = "", a.id_evento, idEvento)

                            If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)
                            End If

                            For i = 0 To a.detallePago.Rows.Count - 1
                                ModPOS.Aplica_Pagos(dtDoctos, sCTEClave, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("SaldoBase"), CAJClave, 1, a.detallePago.Rows(i)("FechaPago"), idEvento)

                                If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) AndAlso TallaColor = 0 Then
                                    sFolio = a.detallePago.Rows(i)("ABNClave")
                                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                                    If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", a.detallePago.Rows(i)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                    End If
                                End If


                            Next

                            If TallaColor AndAlso InterfazSalida <> "" Then
                                If dtDoctos.Rows(0)("TipoDocumento") = 1 Then
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Pedidos", "@COMClave", ModPOS.CompanyActual)
                                    If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                        For i = 0 To dtDoctos.Rows.Count - 1
                                            sFecha = DateTime.Now.AddSeconds(i).ToString("yyyyMMdd_HHmmssfff")
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("ID"), "@TipoDocumento", dtDoctos.Rows(i)("TipoDocumento"), "@Path", InterfazSalida, "@Fecha", sFecha)
                                        Next
                                    End If

                                End If

                            End If

                            If a.TotalAbono > 0 Then

                                If ConfirmarAbono = 1 Then
                                    Dim msg As New FrmMeMsg
                                    msg.TxtTiulo = "Su Cambio es:"
                                    msg.TxtMsg = RefMoneda & " " & Format(CStr(Math.Round(a.TotalCambio, 2)), "Currency")
                                    msg.TxtMsg2 = Letras(CStr(Math.Round(a.TotalCambio, 2))).ToUpper & " " & RefMoneda

                                    msg.StartPosition = FormStartPosition.CenterScreen
                                    msg.BringToFront()
                                    msg.ShowDialog()
                                    msg.Dispose()

                                End If

                                If reciboTicket = 1 Then

                                    Select Case MessageBox.Show("¿Desea imprimir comprobante de Pago?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Case DialogResult.Yes
                                            imprimeRecibo(a.detallePago, a.TotalAbono, Math.Round(a.TotalCambio, 2), Impresora, PrintGeneric, Recibo, MPrincipal.StUsuario.Text, a.ClaveCliente, a.NombreCliente, a.Nota)
                                            Dim reimprimir As Boolean = True

                                            Do
                                                Select Case MessageBox.Show("¿Desea reimprimir Comprobante?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                    Case DialogResult.Yes
                                                        imprimeRecibo(a.detallePago, a.TotalAbono, Math.Round(a.TotalCambio, 2), Impresora, PrintGeneric, Recibo, MPrincipal.StUsuario.Text, a.ClaveCliente, a.NombreCliente, a.Nota)
                                                    Case System.Windows.Forms.DialogResult.No
                                                        reimprimir = False
                                                End Select
                                            Loop While reimprimir = True
                                    End Select

                                ElseIf FormatoRecibo <> "Carta" Then
                                    For i = 0 To a.detallePago.Rows.Count - 1
                                        ModPOS.imprimirRecibo(a.detallePago.Rows(i)("ABNClave"), FormatoRecibo, True, Impresora, Math.Round(a.TotalCambio, 2), " ")
                                    Next

                                ElseIf FormatoRecibo = "Carta" Then
                                    If MessageBox.Show("¿Desea reimprimir Comprobante?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.OK Then
                                        For i = 0 To a.detallePago.Rows.Count - 1
                                            ModPOS.imprimirRecibo(a.detallePago.Rows(i)("ABNClave"), FormatoRecibo, True, Impresora, Math.Round(a.TotalCambio, 2), "REIMPRESIÓN")
                                        Next
                                    End If
                                End If

                            End If

                            dtCxC.Dispose()
                            ActualizaGridCxC()
                        End If
                    End If
                Else
                    ActualizaGridCxC()
                End If
                If TallaColor AndAlso idEvento <> "" AndAlso InterfazSalida <> "" Then
                    Dim dtInterfaz As DataTable = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)

                    If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                        'For i = 0 To dtDoctos.Rows.Count - 1
                        Dim sFecha As String = DateTime.Now.AddSeconds(dtDoctos.Rows.Count + 1).ToString("yyyyMMdd_HHmmssfff")
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", idEvento, "@TipoDocumento", dtDoctos.Rows(0)("TipoDocumento"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                        'Next

                    End If

                End If
            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub GridCxC_CellValueChanged1(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        If GridCxC.GetValue("Marca") = True Then
            SaldoBase += CDbl(GridCxC.GetValue("SaldoBase"))
        Else
            SaldoBase -= CDbl(GridCxC.GetValue("SaldoBase"))
        End If

        Me.LblTotal.Text = Format(CStr(ModPOS.Redondear(SaldoBase, 2)), "Currency")

    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxC.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                SaldoBase = 0
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtCxC.AcceptChanges()
            
            SaldoBase = IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True"))
            Me.LblTotal.Text = Format(CStr(ModPOS.Redondear(SaldoBase, 2)), "Currency")
        End If

    End Sub

    Private Sub BtnSalirCxC_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirCxC.Click
        Me.Close()
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtCxC.Select("Marca ='True' and Saldo > 0")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)

                    Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                    Dim MonRef, MonDesc, sVersionCF As String
                    Dim TipoCambio As Double
                    Dim dt As DataTable

                    Select Case CInt(foundRows(i)("TipoDocumento"))
                        Case Is = 1 ' Venta
                            
                            previewPedido(FormatoPedido, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave)

                        Case Is = 2 'FAC
                            Dim sFormato As String
                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
                            sVersionCF = dt.Rows(0)("VersionCF")

                            dt.Dispose()


                            ModPOS.previewFactura(iTipoCF, sFormato, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF, foundRows(i)("Logo"))


                        Case Is = 6 'Nota de Cargo
                            Dim sFormato As String
                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
                            sVersionCF = dt.Rows(0)("VersionCF")
                            dt.Dispose()

                            ModPOS.previewCargo(sFormato, foundRows(i)("ID"), foundRows(i)("Total"), TipoCambio, MonDesc, MonRef, sVersionCF, foundRows(i)("Logo"))


                    End Select


                Next

                ChkMarcaTodos.Checked = False

            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub
End Class
