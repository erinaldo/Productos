Imports System.Data.SqlClient

Public Class FrmCrearAlm
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
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblAlto As System.Windows.Forms.Label
    Friend WithEvents LblLargo As System.Windows.Forms.Label
    Friend WithEvents LblAncho As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAncho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtLargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtAlto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabEstrategia As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnAddEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridEstrategia As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabProductos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkPredeterminado As Selling.ChkStatus
    Friend WithEvents btnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnImpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbEstrategia As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkBloqueado As Selling.ChkStatus


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCrearAlm))
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtAlto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtLargo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtAncho = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblAncho = New System.Windows.Forms.Label()
        Me.LblLargo = New System.Windows.Forms.Label()
        Me.LblAlto = New System.Windows.Forms.Label()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage()
        Me.cmbEstrategia = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkPredeterminado = New Selling.ChkStatus(Me.components)
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.ChkBloqueado = New Selling.ChkStatus(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmbTipoEstado = New Selling.StoreCombo()
        Me.UiTabEstrategia = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnImpresion = New Janus.Windows.EditControls.UIButton()
        Me.btnImportar = New Janus.Windows.EditControls.UIButton()
        Me.btnAddEst = New Janus.Windows.EditControls.UIButton()
        Me.btnDelEst = New Janus.Windows.EditControls.UIButton()
        Me.GridEstrategia = New Janus.Windows.GridEX.GridEX()
        Me.UiTabProductos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCompania.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabEstrategia.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridEstrategia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabProductos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.Transparent
        Me.LblEstado.Location = New System.Drawing.Point(15, 197)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(49, 15)
        Me.LblEstado.TabIndex = 20
        Me.LblEstado.Text = "Estado"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(112, 66)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(314, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Location = New System.Drawing.Point(15, 69)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 2
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(112, 34)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(135, 20)
        Me.TxtClave.TabIndex = 0
        '
        'LblClave
        '
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Location = New System.Drawing.Point(15, 37)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 0
        Me.LblClave.Text = "Clave"
        '
        'TxtAlto
        '
        Me.TxtAlto.DecimalDigits = 2
        Me.TxtAlto.Location = New System.Drawing.Point(112, 98)
        Me.TxtAlto.Name = "TxtAlto"
        Me.TxtAlto.Size = New System.Drawing.Size(140, 20)
        Me.TxtAlto.TabIndex = 9
        Me.TxtAlto.Text = "0.00"
        Me.TxtAlto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAlto.Value = 0.0R
        Me.TxtAlto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtLargo
        '
        Me.TxtLargo.DecimalDigits = 2
        Me.TxtLargo.Location = New System.Drawing.Point(112, 130)
        Me.TxtLargo.Name = "TxtLargo"
        Me.TxtLargo.Size = New System.Drawing.Size(140, 20)
        Me.TxtLargo.TabIndex = 10
        Me.TxtLargo.Text = "0.00"
        Me.TxtLargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtLargo.Value = 0.0R
        Me.TxtLargo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtAncho
        '
        Me.TxtAncho.DecimalDigits = 2
        Me.TxtAncho.Location = New System.Drawing.Point(112, 162)
        Me.TxtAncho.Name = "TxtAncho"
        Me.TxtAncho.Size = New System.Drawing.Size(140, 20)
        Me.TxtAncho.TabIndex = 11
        Me.TxtAncho.Text = "0.00"
        Me.TxtAncho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAncho.Value = 0.0R
        Me.TxtAncho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(256, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "mts"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(255, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "mts"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(256, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "mts"
        '
        'LblAncho
        '
        Me.LblAncho.BackColor = System.Drawing.Color.Transparent
        Me.LblAncho.Location = New System.Drawing.Point(15, 165)
        Me.LblAncho.Name = "LblAncho"
        Me.LblAncho.Size = New System.Drawing.Size(55, 15)
        Me.LblAncho.TabIndex = 10
        Me.LblAncho.Text = "Ancho"
        '
        'LblLargo
        '
        Me.LblLargo.BackColor = System.Drawing.Color.Transparent
        Me.LblLargo.Location = New System.Drawing.Point(15, 128)
        Me.LblLargo.Name = "LblLargo"
        Me.LblLargo.Size = New System.Drawing.Size(81, 15)
        Me.LblLargo.TabIndex = 8
        Me.LblLargo.Text = "Largo"
        '
        'LblAlto
        '
        Me.LblAlto.BackColor = System.Drawing.Color.Transparent
        Me.LblAlto.Location = New System.Drawing.Point(15, 101)
        Me.LblAlto.Name = "LblAlto"
        Me.LblAlto.Size = New System.Drawing.Size(81, 15)
        Me.LblAlto.TabIndex = 6
        Me.LblAlto.Text = "Altura"
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Icon = CType(resources.GetObject("BtnOk.Icon"), System.Drawing.Icon)
        Me.BtnOk.Location = New System.Drawing.Point(661, 403)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 3
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar los cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(565, 403)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 44)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(730, 314)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.BackColor = System.Drawing.Color.Transparent
        Me.UiTab1.Location = New System.Drawing.Point(1, 5)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(750, 392)
        Me.UiTab1.TabIndex = 22
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabEstrategia, Me.UiTabProductos})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Controls.Add(Me.PictureBox1)
        Me.UiTabCompania.Controls.Add(Me.cmbEstrategia)
        Me.UiTabCompania.Controls.Add(Me.Label4)
        Me.UiTabCompania.Controls.Add(Me.ChkPredeterminado)
        Me.UiTabCompania.Controls.Add(Me.PictureBox6)
        Me.UiTabCompania.Controls.Add(Me.ChkBloqueado)
        Me.UiTabCompania.Controls.Add(Me.PictureBox5)
        Me.UiTabCompania.Controls.Add(Me.PictureBox3)
        Me.UiTabCompania.Controls.Add(Me.PictureBox4)
        Me.UiTabCompania.Controls.Add(Me.TxtAlto)
        Me.UiTabCompania.Controls.Add(Me.PictureBox2)
        Me.UiTabCompania.Controls.Add(Me.TxtLargo)
        Me.UiTabCompania.Controls.Add(Me.TxtAncho)
        Me.UiTabCompania.Controls.Add(Me.TxtClave)
        Me.UiTabCompania.Controls.Add(Me.Label3)
        Me.UiTabCompania.Controls.Add(Me.cmbTipoEstado)
        Me.UiTabCompania.Controls.Add(Me.Label2)
        Me.UiTabCompania.Controls.Add(Me.LblClave)
        Me.UiTabCompania.Controls.Add(Me.Label1)
        Me.UiTabCompania.Controls.Add(Me.LblEstado)
        Me.UiTabCompania.Controls.Add(Me.LblAncho)
        Me.UiTabCompania.Controls.Add(Me.LblNombre)
        Me.UiTabCompania.Controls.Add(Me.LblLargo)
        Me.UiTabCompania.Controls.Add(Me.TxtNombre)
        Me.UiTabCompania.Controls.Add(Me.LblAlto)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(748, 370)
        Me.UiTabCompania.TabStop = True
        Me.UiTabCompania.Text = "General"
        '
        'cmbEstrategia
        '
        Me.cmbEstrategia.Location = New System.Drawing.Point(112, 231)
        Me.cmbEstrategia.Name = "cmbEstrategia"
        Me.cmbEstrategia.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstrategia.TabIndex = 112
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(15, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 15)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Estrategia Surtido"
        '
        'ChkPredeterminado
        '
        Me.ChkPredeterminado.BackColor = System.Drawing.Color.Transparent
        Me.ChkPredeterminado.Checked = True
        Me.ChkPredeterminado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPredeterminado.Location = New System.Drawing.Point(112, 307)
        Me.ChkPredeterminado.Name = "ChkPredeterminado"
        Me.ChkPredeterminado.Size = New System.Drawing.Size(138, 22)
        Me.ChkPredeterminado.TabIndex = 111
        Me.ChkPredeterminado.Text = "Predeterminado"
        Me.ChkPredeterminado.UseVisualStyleBackColor = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(282, 162)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(21, 18)
        Me.PictureBox6.TabIndex = 86
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'ChkBloqueado
        '
        Me.ChkBloqueado.BackColor = System.Drawing.Color.Transparent
        Me.ChkBloqueado.Checked = True
        Me.ChkBloqueado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBloqueado.Location = New System.Drawing.Point(112, 279)
        Me.ChkBloqueado.Name = "ChkBloqueado"
        Me.ChkBloqueado.Size = New System.Drawing.Size(138, 22)
        Me.ChkBloqueado.TabIndex = 110
        Me.ChkBloqueado.Text = "Bloqueado para Vta"
        Me.ChkBloqueado.UseVisualStyleBackColor = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(282, 128)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox5.TabIndex = 85
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(432, 65)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox3.TabIndex = 108
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(282, 96)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox4.TabIndex = 84
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(253, 34)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox2.TabIndex = 82
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Location = New System.Drawing.Point(112, 194)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoEstado.TabIndex = 1
        '
        'UiTabEstrategia
        '
        Me.UiTabEstrategia.Controls.Add(Me.GroupBox1)
        Me.UiTabEstrategia.Location = New System.Drawing.Point(1, 21)
        Me.UiTabEstrategia.Name = "UiTabEstrategia"
        Me.UiTabEstrategia.Size = New System.Drawing.Size(748, 370)
        Me.UiTabEstrategia.TabStop = True
        Me.UiTabEstrategia.Text = "Estrategia de Almacenaje"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnImpresion)
        Me.GroupBox1.Controls.Add(Me.btnImportar)
        Me.GroupBox1.Controls.Add(Me.btnAddEst)
        Me.GroupBox1.Controls.Add(Me.btnDelEst)
        Me.GroupBox1.Controls.Add(Me.GridEstrategia)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(743, 343)
        Me.GroupBox1.TabIndex = 139
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos"
        '
        'BtnImpresion
        '
        Me.BtnImpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpresion.Icon = CType(resources.GetObject("BtnImpresion.Icon"), System.Drawing.Icon)
        Me.BtnImpresion.Location = New System.Drawing.Point(531, 15)
        Me.BtnImpresion.Name = "BtnImpresion"
        Me.BtnImpresion.Size = New System.Drawing.Size(47, 23)
        Me.BtnImpresion.TabIndex = 158
        Me.BtnImpresion.ToolTipText = "Impresión de Estrategia de Almacenaje"
        Me.BtnImpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportar.Location = New System.Drawing.Point(584, 15)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(47, 23)
        Me.btnImportar.TabIndex = 157
        Me.btnImportar.ToolTipText = "Importar estrategia"
        Me.btnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddEst
        '
        Me.btnAddEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddEst.Icon = CType(resources.GetObject("btnAddEst.Icon"), System.Drawing.Icon)
        Me.btnAddEst.Location = New System.Drawing.Point(637, 15)
        Me.btnAddEst.Name = "btnAddEst"
        Me.btnAddEst.Size = New System.Drawing.Size(47, 23)
        Me.btnAddEst.TabIndex = 156
        Me.btnAddEst.ToolTipText = "Agregar estrategia"
        Me.btnAddEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelEst
        '
        Me.btnDelEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelEst.Icon = CType(resources.GetObject("btnDelEst.Icon"), System.Drawing.Icon)
        Me.btnDelEst.Location = New System.Drawing.Point(690, 15)
        Me.btnDelEst.Name = "btnDelEst"
        Me.btnDelEst.Size = New System.Drawing.Size(47, 23)
        Me.btnDelEst.TabIndex = 156
        Me.btnDelEst.ToolTipText = "Eliminar estrategia seleccionada"
        Me.btnDelEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEstrategia
        '
        Me.GridEstrategia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEstrategia.AutoEdit = True
        Me.GridEstrategia.ColumnAutoResize = True
        Me.GridEstrategia.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEstrategia.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEstrategia.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEstrategia.GroupByBoxVisible = False
        Me.GridEstrategia.Location = New System.Drawing.Point(7, 44)
        Me.GridEstrategia.Name = "GridEstrategia"
        Me.GridEstrategia.RecordNavigator = True
        Me.GridEstrategia.Size = New System.Drawing.Size(731, 292)
        Me.GridEstrategia.TabIndex = 1
        Me.GridEstrategia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabProductos
        '
        Me.UiTabProductos.Controls.Add(Me.GroupBox2)
        Me.UiTabProductos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabProductos.Name = "UiTabProductos"
        Me.UiTabProductos.Size = New System.Drawing.Size(748, 370)
        Me.UiTabProductos.TabStop = True
        Me.UiTabProductos.Text = "Productos No Manejados"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.BtnAdd)
        Me.GroupBox2.Controls.Add(Me.BtnDel)
        Me.GroupBox2.Controls.Add(Me.GridDetalle)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(743, 364)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos"
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Icon = CType(resources.GetObject("BtnAdd.Icon"), System.Drawing.Icon)
        Me.BtnAdd.Location = New System.Drawing.Point(636, 15)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(47, 23)
        Me.BtnAdd.TabIndex = 157
        Me.BtnAdd.ToolTipText = "Agregar productos No Manejados"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Icon = CType(resources.GetObject("BtnDel.Icon"), System.Drawing.Icon)
        Me.BtnDel.Location = New System.Drawing.Point(689, 15)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(47, 23)
        Me.BtnDel.TabIndex = 158
        Me.BtnDel.ToolTipText = "Elimina producto seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(259, 234)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 18)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'FrmCrearAlm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(761, 447)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(635, 422)
        Me.Name = "FrmCrearAlm"
        Me.Text = "Crear Almacen"
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCompania.ResumeLayout(False)
        Me.UiTabCompania.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabEstrategia.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridEstrategia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabProductos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Public ALMClave As String
    Public Clave As String
    Public Nombre As String
    Public SUCClave As String
    Public BloqueoVta As Boolean = False
    Public Predeterminado As Boolean = False
    Public Largo As Double = 0
    Public Ancho As Double = 0
    Public Alto As Double = 0
    Public Estado As Integer = 1
    Public Escala As Integer
    Public TipoSurtido As Integer = 1

    Public Padre As String

    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private cargado As Boolean = False

    Private dtDetalle, dtBorrados, dtEstrategia As DataTable
    Private DetalleEdited As Boolean = False
    Private sProductoSelected As String
    Private sClaveSelected As String

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Private sId As String

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)

        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)

        End If

        If Me.TxtAlto.Text = "" OrElse CDbl(Me.TxtAlto.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLargo.Text = "" OrElse CDbl(Me.TxtLargo.Text) = 0 OrElse CDbl(Me.TxtLargo.Text) < Largo Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtAncho.Text = "" OrElse CDbl(Me.TxtAncho.Text) = 0 OrElse CDbl(Me.TxtAncho.Text) < Ancho Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbEstrategia.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Nuevo" Then
            Dim Con As String = ModPOS.BDConexion


            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Almacen", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If

        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Public Sub agregaProducto(ByVal PROClave As String, ByVal Clave As String, ByVal Nombre As String)

        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("PROClave Like '" & PROClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("PROClave") = PROClave
            row1.Item("Clave") = Clave
            row1.Item("Descripcion") = Nombre
            row1.Item("Agregar") = 1
            'agrega la fila completo a la tabla
            dtDetalle.Rows.Add(row1)
            DetalleEdited = True
        End If

    End Sub

    Private Sub ActualizaEstrategia()
        dtEstrategia = ModPOS.Recupera_Tabla("sp_muestra_estrategia", "@ALMClave", ALMClave)

        Me.GridEstrategia.DataSource = dtEstrategia
        GridEstrategia.RetrieveStructure()
        GridEstrategia.GroupByBoxVisible = False
        GridEstrategia.RootTable.Columns("id").Visible = False
        GridEstrategia.RootTable.Columns("PROClave").Visible = False
        GridEstrategia.RootTable.Columns("AREClave").Visible = False
        GridEstrategia.RootTable.Columns("UBCClave").Visible = False
        GridEstrategia.RootTable.Columns("Update").Visible = False
        GridEstrategia.RootTable.Columns("Baja").Visible = False

        GridEstrategia.RootTable.Columns("Capacidad").FormatString = "0.00"

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridEstrategia.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridEstrategia.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub FrmCrearAlm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.CrearAlm.Dispose()
        ModPOS.CrearAlm = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        If validaForm() Then
            Dim i As Integer
            Dim foundRows() As DataRow

            Select Case Me.Padre
                Case "Nuevo"

                    If Not ModPOS.Superficie Is Nothing Then
                        ModPOS.Graba_Layout_Activo()
                        ModPOS.Almacen_Activo = ""
                        ModPOS.Superficie.Close()
                    End If

                    ModPOS.Superficie = New FrmCanvas
                    With ModPOS.Superficie
                        .StartPosition = FormStartPosition.CenterScreen
                        .MdiParent = ModPOS.Principal
                        .Show()
                        .ALMClave = Me.ALMClave
                        ModPOS.Almacen_Activo = Me.ALMClave

                        'Modificar valores del almacen
                        .SUCClave = SUCClave
                        .Referencia = UCase(Trim(Me.TxtClave.Text))
                        .Nombre = UCase(Trim(Me.TxtNombre.Text))
                        .Escala = ModPOS.EscalaActual
                        .Alto = CDbl(Me.TxtAlto.Text)
                        .Largo = CDbl(Me.TxtLargo.Text)
                        .Ancho = CDbl(Me.TxtAncho.Text)
                        .Width = CInt(CDbl(Me.TxtLargo.Text) * ModPOS.EscalaActual)
                        .Height = CInt(CDbl(Me.TxtAncho.Text) * ModPOS.EscalaActual)
                        .TipoSurtido = cmbEstrategia.SelectedValue
                        .Estado = 1
                        .BloqueoVta = ChkBloqueado.GetEstado
                        .Predeterminado = ChkPredeterminado.GetEstado
                        .Refresh()
                    End With

                    ModPOS.Graba_Superficie(ModPOS.Superficie)

                    ModPOS.Principal.Cerrar.Enabled = Janus.Windows.UI.InheritableBoolean.True
                    ModPOS.Principal.Zoom.Enabled = Janus.Windows.UI.InheritableBoolean.True
                    ModPOS.Principal.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.True
                    ModPOS.Principal.Buscar.Enabled = Janus.Windows.UI.InheritableBoolean.True

                Case "Modificar"

                    If Not (Nombre = UCase(Trim(Me.TxtNombre.Text)) AndAlso _
                            Estado = CInt(Me.cmbTipoEstado.SelectedValue) AndAlso _
                            Largo = CDbl(Me.TxtLargo.Text) AndAlso _
                            Alto = CDbl(Me.TxtAlto.Text) AndAlso _
                            Ancho = CDbl(Me.TxtAncho.Text) AndAlso _
                            Predeterminado = CBool(ChkPredeterminado.GetEstado) AndAlso _
                            BloqueoVta = CBool(ChkBloqueado.GetEstado) AndAlso _
                            TipoSurtido = cmbEstrategia.SelectedValue AndAlso _
                            DetalleEdited = False) Then

                        Nombre = UCase(Trim(Me.TxtNombre.Text))
                        Estado = CInt(Me.cmbTipoEstado.SelectedValue)
                        Largo = CDbl(Me.TxtLargo.Text)
                        Alto = CDbl(Me.TxtAlto.Text)
                        Ancho = CDbl(Me.TxtAncho.Text)
                        BloqueoVta = CBool(ChkBloqueado.GetEstado)
                        Predeterminado = CBool(ChkPredeterminado.GetEstado)
                        TipoSurtido = cmbEstrategia.SelectedValue

                        ModPOS.Update_Almacen(Me)


                        If Not ModPOS.Superficie Is Nothing Then
                            If ModPOS.Superficie.ALMClave = Me.ALMClave Then
                                With ModPOS.Superficie
                                    .Nombre = Nombre
                                    .SUCClave = SUCClave
                                    .BloqueoVta = BloqueoVta
                                    .Predeterminado = Predeterminado
                                    .Estado = Estado
                                    .Largo = Largo
                                    .Alto = Alto
                                    .Ancho = Ancho
                                    .TipoSurtido = TipoSurtido
                                    .Width = CInt(Largo * Escala)
                                    .Height = CInt(Ancho * Escala)
                                End With
                            End If
                        End If



                        If Not ModPOS.Almacenes Is Nothing Then
                            ModPOS.Almacenes.refrescaGrid()
                        End If
                    End If


                    If DetalleEdited Then

                        Dim fila As Integer

                        Cursor.Current = Cursors.WaitCursor

                        For fila = 0 To dtBorrados.Rows.Count - 1
                            ModPOS.Ejecuta("sp_elimina_almacen_producto", _
                                        "@ALMClave", ALMClave, _
                                        "@PROClave", dtBorrados.Rows(fila)("PROClave"))
                        Next

                        foundRows = dtDetalle.Select("Agregar = 1")

                        If foundRows.GetLength(0) > 0 Then
                            For fila = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_almacen_producto", _
                                            "@ALMClave", ALMClave, _
                                            "@PROClave", foundRows(fila)("PROClave"))
                            Next
                        End If

                        Cursor.Current = Cursors.Default

                    End If


                    foundRows = dtEstrategia.Select("Baja = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_estrategia", "@Id", foundRows(i)("id"))
                        Next
                    End If


                    foundRows = dtEstrategia.Select("Update=1 and Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_modifica_estrategia", "@Id", foundRows(i)("id"), "@PROClave", foundRows(i)("PROClave"), "@ALMClave", ALMClave, "@AREClave", foundRows(i)("AREClave"), "@UBCClave", foundRows(i)("UBCClave"), "@Capacidad", foundRows(i)("Capacidad"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


            End Select




            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmCrearAlm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox2
        alerta(1) = Me.PictureBox3
        alerta(2) = Me.PictureBox4
        alerta(3) = Me.PictureBox5
        alerta(4) = Me.PictureBox6
        alerta(5) = Me.PictureBox1

        With ModPOS.CrearAlm.cmbTipoEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Almacen"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With

        With ModPOS.CrearAlm.cmbEstrategia
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Almacen"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estrategia"
            .llenar()
        End With

        dtBorrados = ModPOS.CrearTabla("AlmacenDetalle", _
                            "PROClave", "System.String")

        If Padre <> "Nuevo" Then

            TxtClave.ReadOnly = True

            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_almacen_producto", "@ALMClave", ALMClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("Agregar").Visible = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Descripcion").Selectable = False

            ActualizaEstrategia()
        Else

            UiTabEstrategia.TabVisible = False
            UiTabProductos.TabVisible = False
            cmbTipoEstado.Enabled = False
            ALMClave = ModPOS.obtenerLlave
        End If

        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        TxtLargo.Text = Largo
        TxtAncho.Text = Ancho
        TxtAlto.Text = Alto
        cmbTipoEstado.SelectedValue = Estado
        ChkBloqueado.Estado = Math.Abs(CInt(BloqueoVta))
        ChkPredeterminado.Estado = Math.Abs(CInt(Predeterminado))
        cmbEstrategia.SelectedValue = TipoSurtido
        cargado = True

    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        If Not GridDetalle.GetValue(0) Is Nothing Then
            Me.BtnDel.Enabled = True
            Me.sProductoSelected = GridDetalle.GetValue("PROClave")
            Me.sClaveSelected = GridDetalle.GetValue("Clave")
        Else
            BtnDel.Enabled = False
            Me.sProductoSelected = ""
            Me.sClaveSelected = ""
        End If
    End Sub

    Public Sub setEstrategia(ByVal sPROClave As String, ByVal sAREClave As String, ByVal sUBCClave As String, ByVal Area As String, ByVal Ubicacion As String, ByVal Producto As String, ByVal Capacidad As Double)
        Dim frEstrategia() As DataRow
        frEstrategia = dtEstrategia.Select("PROClave = '" & sPROClave & "' and Baja = 0")
        If frEstrategia.Length = 0 Then
            'Agrega estrategia

            Dim row1 As DataRow
            row1 = dtEstrategia.NewRow()
            'declara el nombre de la fila
            row1.Item("id") = ModPOS.obtenerLlave
            row1.Item("PROClave") = sPROClave
            row1.Item("AREClave") = sAREClave
            row1.Item("UBCClave") = sUBCClave
            row1.Item("Area") = Area
            row1.Item("Ubicación") = Ubicacion
            row1.Item("Producto") = Producto
            row1.Item("Capacidad") = Capacidad
            row1.Item("Update") = 1
            row1.Item("Baja") = 0
            'agrega la fila completo a la tabla
            dtEstrategia.Rows.Add(row1)
        Else

            frEstrategia(0)("AREClave") = sAREClave
            frEstrategia(0)("UBCClave") = sUBCClave
            frEstrategia(0)("Area") = Area
            frEstrategia(0)("Ubicación") = Ubicacion
            frEstrategia(0)("Capacidad") = Capacidad
            frEstrategia(0)("Update") = 1

        End If
    End Sub


    Private Sub btnDelEst_Click(sender As Object, e As EventArgs) Handles btnDelEst.Click
        If Me.sId <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la estrategia para el producto: " & CStr(GridEstrategia.GetValue("Producto")), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtEstrategia.Select("Id = '" & sId & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                        foundRows(0)("Update") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se removera el producto " & sClaveSelected & " de la lista de no manejados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow

                    foundRows = dtBorrados.Select("PROClave Like '" & sProductoSelected & "'")

                    If foundRows.Length = 0 Then
                        Dim row1 As DataRow
                        row1 = dtBorrados.NewRow()
                        row1.Item("PROClave") = sProductoSelected
                        dtBorrados.Rows.Add(row1)
                    End If


                    foundRows = dtDetalle.Select(" PROClave Like '" & sProductoSelected & "'")
                    dtDetalle.Rows.Remove(foundRows(0))


                    DetalleEdited = True

            End Select
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If ModPOS.AddProd Is Nothing Then
            ModPOS.AddProd = New FrmAddProd
            With ModPOS.AddProd
                .StartPosition = FormStartPosition.CenterScreen
                .ALMClave = ALMClave
            End With
        End If
        ModPOS.AddProd.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddProd.Show()
        ModPOS.AddProd.BringToFront()
    End Sub

    Private Sub btnAddEst_Click(sender As Object, e As EventArgs) Handles btnAddEst.Click
        If ModPOS.AddEstrategia Is Nothing Then
            ModPOS.AddEstrategia = New FrmAddEstrategia
            With ModPOS.AddEstrategia
                .StartPosition = FormStartPosition.CenterScreen
                .ALMClave = ALMClave
            End With
        End If
        ModPOS.AddEstrategia.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddEstrategia.Show()
        ModPOS.AddEstrategia.BringToFront()
    End Sub


    Private Sub GridEstrategia_SelectionChanged(sender As Object, e As EventArgs) Handles GridEstrategia.SelectionChanged
        If Not GridEstrategia.GetValue(0) Is Nothing Then
            Me.btnDelEst.Enabled = True
            Me.sId = GridEstrategia.GetValue("Id")
        Else
            btnDelEst.Enabled = False
            Me.sId = ""
        End If
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim curFileName As String = ""
        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de CSV o TXT"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 4)

                If dtTemporal.Rows.Count > 0 Then


                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.BringToFront()

                    Dim i As Integer
                    Dim AREClave, UBCClave, PROClave As String
                    Dim Capacidad As Double

                    Dim dt As DataTable

                    For i = 0 To dtTemporal.Rows.Count - 1
                        frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")

                        ' valida el area
                        If dtTemporal.Rows(i)("Area").GetType.FullName <> "System.DBNull" Then
                            dt = Recupera_Tabla("st_valida_area_alm", "@ALMClave", ALMClave, "@Nombre", CStr(dtTemporal.Rows(i)("Area")).Trim)
                            If dt.Rows.Count = 1 Then
                                AREClave = dt.Rows(0)("AREClave")
                                dt.Dispose()

                                ' valida ubicacion
                                If dtTemporal.Rows(i)("Ubicacion").GetType.FullName <> "System.DBNull" Then
                                    dt = Recupera_Tabla("sp_valida_ubicacion_are", "@AREClave", AREClave, "@Ubicacion", dtTemporal.Rows(i)("Ubicacion").ToString.Trim)
                                    If dt.Rows.Count = 1 Then
                                        UBCClave = dt.Rows(0)("UBCClave")
                                        dt.Dispose()

                                        ' valida el producto
                                        If dtTemporal.Rows(i)("Producto").GetType.FullName <> "System.DBNull" Then
                                            dt = Recupera_Tabla("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", dtTemporal.Rows(i)("Producto").ToString.Replace("'", "''").Trim, "@Char", cReplace)
                                            If dt.Rows.Count = 1 Then
                                                PROClave = dt.Rows(0)("PROClave")
                                                dt.Dispose()

                                                ' valida la capacidad 
                                                If dtTemporal.Rows(i)("Capacidad").GetType.FullName <> "System.DBNull" Then
                                                    If IsNumeric(dtTemporal.Rows(i)("Capacidad")) AndAlso CDbl(dtTemporal.Rows(i)("Capacidad")) > 0 Then
                                                        Capacidad = CDbl(dtTemporal.Rows(i)("Capacidad"))

                                                        setEstrategia(PROClave, AREClave, UBCClave, dtTemporal.Rows(i)("Area"), dtTemporal.Rows(i)("Ubicacion"), dtTemporal.Rows(i)("Producto"), Capacidad)
                                                    Else
                                                        MessageBox.Show("El registro actual no cuenta con una capacidad de almacenaje valida " & dtTemporal.Rows(i)("Capacidad").ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If
                                                Else
                                                    MessageBox.Show("La capacidad de almacenaje del registro actual se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If

                                            Else
                                                dt.Dispose()
                                                MessageBox.Show("El Producto " & dtTemporal.Rows(i)("Producto").ToString & " no existe en el catálogo de la compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        Else
                                            MessageBox.Show("La clave de producto del registro actual se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    Else
                                        dt.Dispose()
                                        MessageBox.Show("La ubicación " & dtTemporal.Rows(i)("Ubicacion").ToString & " no se encuentra en el area " & dtTemporal.Rows(i)("Area").ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("La Ubicación del registro actual se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If

                            Else
                                dt.Dispose()
                                MessageBox.Show("El area " & dtTemporal.Rows(i)("Area").ToString & " no es valida para el almacén actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El nombre de area del registro actual se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Next
                    frmStatusMessage.Close()
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("El archivo no cuenta con el formato: Area,Ubicacion,Producto,Capacidad o se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnImpresion_Click(sender As Object, e As EventArgs) Handles BtnImpresion.Click
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "reportDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_estrategia", "@ALMClave", ALMClave))
        OpenReport.PrintPreview("Reporte de Estrategia de Almacenaje", "CREstrategia.rpt", pvtaDataSet, "")
    End Sub

   
End Class
