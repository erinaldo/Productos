Imports System.Data.SqlClient

Public Class FrmArea
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
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblTArea As System.Windows.Forms.Label
    Friend WithEvents LblColor As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents BtnColor As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PnlColor As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbTipoArea As Selling.StoreCombo
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents UiTabTipoDoc As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabImpresoras As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpImpresora As System.Windows.Forms.GroupBox
    Friend WithEvents GridImpresora As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbImpresora As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpEstructuras As System.Windows.Forms.GroupBox
    Friend WithEvents GridEstructuras As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArea))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbTipoEstado = New Selling.StoreCombo()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.CmbTipoArea = New Selling.StoreCombo()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PnlColor = New System.Windows.Forms.Panel()
        Me.BtnColor = New Janus.Windows.EditControls.UIButton()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblColor = New System.Windows.Forms.Label()
        Me.LblTArea = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.UiTabTipoDoc = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiTabImpresoras = New Janus.Windows.UI.Tab.UITabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbImpresora = New Selling.StoreCombo()
        Me.GrpImpresora = New System.Windows.Forms.GroupBox()
        Me.GridImpresora = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpEstructuras = New System.Windows.Forms.GroupBox()
        Me.GridEstructuras = New Janus.Windows.GridEX.GridEX()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTabTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabTipoDoc.SuspendLayout()
        Me.UiTabCompania.SuspendLayout()
        Me.UiTabImpresoras.SuspendLayout()
        Me.GrpImpresora.SuspendLayout()
        CType(Me.GridImpresora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage1.SuspendLayout()
        Me.GrpEstructuras.SuspendLayout()
        CType(Me.GridEstructuras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.BackColor = System.Drawing.Color.Transparent
        Me.GrpGeneral.Controls.Add(Me.cmbTipoEstado)
        Me.GrpGeneral.Controls.Add(Me.LblEstado)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoArea)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.PnlColor)
        Me.GrpGeneral.Controls.Add(Me.BtnColor)
        Me.GrpGeneral.Controls.Add(Me.TxtNombre)
        Me.GrpGeneral.Controls.Add(Me.TxtClave)
        Me.GrpGeneral.Controls.Add(Me.LblColor)
        Me.GrpGeneral.Controls.Add(Me.LblTArea)
        Me.GrpGeneral.Controls.Add(Me.LblNombre)
        Me.GrpGeneral.Controls.Add(Me.LblClave)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 12)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(689, 242)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "General"
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Location = New System.Drawing.Point(95, 203)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoEstado.TabIndex = 5
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(7, 206)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(80, 15)
        Me.LblEstado.TabIndex = 17
        Me.LblEstado.Text = "Estado"
        '
        'CmbTipoArea
        '
        Me.CmbTipoArea.Location = New System.Drawing.Point(94, 110)
        Me.CmbTipoArea.Name = "CmbTipoArea"
        Me.CmbTipoArea.Size = New System.Drawing.Size(140, 21)
        Me.CmbTipoArea.TabIndex = 3
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(134, 163)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(240, 110)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(319, 66)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(241, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PnlColor
        '
        Me.PnlColor.BackColor = System.Drawing.Color.White
        Me.PnlColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlColor.Location = New System.Drawing.Point(94, 156)
        Me.PnlColor.Name = "PnlColor"
        Me.PnlColor.Size = New System.Drawing.Size(33, 30)
        Me.PnlColor.TabIndex = 9
        '
        'BtnColor
        '
        Me.BtnColor.Location = New System.Drawing.Point(154, 156)
        Me.BtnColor.Name = "BtnColor"
        Me.BtnColor.Size = New System.Drawing.Size(90, 30)
        Me.BtnColor.TabIndex = 4
        Me.BtnColor.Text = "Ca&mbiar Color"
        Me.BtnColor.ToolTipText = "Modificar el color del area"
        Me.BtnColor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(94, 66)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(227, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(95, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblColor
        '
        Me.LblColor.Location = New System.Drawing.Point(6, 163)
        Me.LblColor.Name = "LblColor"
        Me.LblColor.Size = New System.Drawing.Size(80, 15)
        Me.LblColor.TabIndex = 3
        Me.LblColor.Text = "Color"
        '
        'LblTArea
        '
        Me.LblTArea.Location = New System.Drawing.Point(6, 118)
        Me.LblTArea.Name = "LblTArea"
        Me.LblTArea.Size = New System.Drawing.Size(80, 15)
        Me.LblTArea.TabIndex = 2
        Me.LblTArea.Text = "Tipo de Area"
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(6, 73)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 1
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 22)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 0
        Me.LblClave.Text = "Referencia"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(241, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Max. 10 Caracteres"
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Icon = CType(resources.GetObject("BtnOk.Icon"), System.Drawing.Icon)
        Me.BtnOk.Location = New System.Drawing.Point(616, 302)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 6
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar los cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(521, 302)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar la ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabTipoDoc
        '
        Me.UiTabTipoDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabTipoDoc.BackColor = System.Drawing.Color.Transparent
        Me.UiTabTipoDoc.Location = New System.Drawing.Point(2, 7)
        Me.UiTabTipoDoc.Name = "UiTabTipoDoc"
        Me.UiTabTipoDoc.Size = New System.Drawing.Size(704, 289)
        Me.UiTabTipoDoc.TabIndex = 21
        Me.UiTabTipoDoc.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabImpresoras, Me.UiTabPage1})
        Me.UiTabTipoDoc.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabCompania.Controls.Add(Me.GrpGeneral)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(702, 267)
        Me.UiTabCompania.TabStop = True
        Me.UiTabCompania.Text = "General"
        '
        'UiTabImpresoras
        '
        Me.UiTabImpresoras.Controls.Add(Me.Label2)
        Me.UiTabImpresoras.Controls.Add(Me.cmbImpresora)
        Me.UiTabImpresoras.Controls.Add(Me.GrpImpresora)
        Me.UiTabImpresoras.Controls.Add(Me.BtnEliminar)
        Me.UiTabImpresoras.Controls.Add(Me.BtnAgregar)
        Me.UiTabImpresoras.Location = New System.Drawing.Point(1, 21)
        Me.UiTabImpresoras.Name = "UiTabImpresoras"
        Me.UiTabImpresoras.Size = New System.Drawing.Size(702, 267)
        Me.UiTabImpresoras.TabStop = True
        Me.UiTabImpresoras.Text = "Impresoras"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 14)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Impresora"
        '
        'cmbImpresora
        '
        Me.cmbImpresora.Location = New System.Drawing.Point(90, 14)
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(227, 21)
        Me.cmbImpresora.TabIndex = 9
        '
        'GrpImpresora
        '
        Me.GrpImpresora.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpImpresora.BackColor = System.Drawing.Color.Transparent
        Me.GrpImpresora.Controls.Add(Me.GridImpresora)
        Me.GrpImpresora.Location = New System.Drawing.Point(2, 37)
        Me.GrpImpresora.Name = "GrpImpresora"
        Me.GrpImpresora.Size = New System.Drawing.Size(697, 225)
        Me.GrpImpresora.TabIndex = 8
        Me.GrpImpresora.TabStop = False
        Me.GrpImpresora.Text = "Impresora"
        '
        'GridImpresora
        '
        Me.GridImpresora.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridImpresora.ColumnAutoResize = True
        Me.GridImpresora.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridImpresora.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridImpresora.GroupByBoxVisible = False
        Me.GridImpresora.Location = New System.Drawing.Point(7, 15)
        Me.GridImpresora.Name = "GridImpresora"
        Me.GridImpresora.RecordNavigator = True
        Me.GridImpresora.Size = New System.Drawing.Size(685, 203)
        Me.GridImpresora.TabIndex = 1
        Me.GridImpresora.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(563, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 30)
        Me.BtnEliminar.TabIndex = 7
        Me.BtnEliminar.ToolTipText = "Eliminar personal para Autorización"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(631, 5)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(63, 30)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.ToolTipText = "Agregar personal para Autorización"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.GrpEstructuras)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(702, 267)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Estructuras "
        '
        'GrpEstructuras
        '
        Me.GrpEstructuras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEstructuras.BackColor = System.Drawing.Color.Transparent
        Me.GrpEstructuras.Controls.Add(Me.GridEstructuras)
        Me.GrpEstructuras.Location = New System.Drawing.Point(3, 15)
        Me.GrpEstructuras.Name = "GrpEstructuras"
        Me.GrpEstructuras.Size = New System.Drawing.Size(693, 237)
        Me.GrpEstructuras.TabIndex = 2
        Me.GrpEstructuras.TabStop = False
        Me.GrpEstructuras.Text = "Estructuras Asignadas"
        '
        'GridEstructuras
        '
        Me.GridEstructuras.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEstructuras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEstructuras.ColumnAutoResize = True
        Me.GridEstructuras.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEstructuras.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEstructuras.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEstructuras.Location = New System.Drawing.Point(8, 16)
        Me.GridEstructuras.Name = "GridEstructuras"
        Me.GridEstructuras.RecordNavigator = True
        Me.GridEstructuras.Size = New System.Drawing.Size(677, 213)
        Me.GridEstructuras.TabIndex = 2
        Me.GridEstructuras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmArea
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(711, 344)
        Me.Controls.Add(Me.UiTabTipoDoc)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArea"
        Me.Text = "Area"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTabTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabTipoDoc.ResumeLayout(False)
        Me.UiTabCompania.ResumeLayout(False)
        Me.UiTabImpresoras.ResumeLayout(False)
        Me.GrpImpresora.ResumeLayout(False)
        CType(Me.GridImpresora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage1.ResumeLayout(False)
        Me.GrpEstructuras.ResumeLayout(False)
        CType(Me.GridEstructuras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Forma As String = ""
    Public AREClave As String
    Public Clave As String = ""
    Public Nombre As String = ""
    Public Tipo As Integer = 0
    Public Color As Integer = 0
    Public Estado As Integer = 1
    Public SUCClave, ALMClave As String
    Public sIdSelected As String = ""

    Public Padre As String

    Private dtImpresora, dtPrinter, dtFormaEnvio As DataTable
    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private Sub FrmArea_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.Areas.Dispose()
        ModPOS.Areas = Nothing
    End Sub

    Private Sub BtnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnColor.Click
        Me.ColorDialog1.Color = Me.PnlColor.BackColor
        Me.ColorDialog1.ShowDialog()
        Me.PnlColor.BackColor = Me.ColorDialog1.Color
    End Sub

    Private Sub FrmArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4


        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With CmbTipoArea
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Area"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        With cmbTipoEstado
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Area"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With

        With cmbImpresora
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        If Padre = "Modificar" Then
            TxtClave.ReadOnly = True
            cmbTipoEstado.Enabled = True


            dtImpresora = ModPOS.Recupera_Tabla("st_obtener_printerarea", "@AREClave", AREClave)
        Else

            AREClave = ModPOS.obtenerLlave

            dtImpresora = ModPOS.CrearTabla("PrinterArea", _
                                          "idPrinter", "System.String", _
                                          "Impresora", "System.String", _
                                          "Inicial", "System.Int32", _
                                          "Final", "System.Int32", _
                                          "Impresiones", "System.Int32", _
                                          "Modificado", "System.Int32", _
                                          "Baja", "System.Int32")

        End If

        cmbTipoEstado.SelectedValue = Estado
        PnlColor.BackColor = System.Drawing.Color.FromArgb(Color)
        CmbTipoArea.SelectedValue = CInt(Tipo)

        TxtNombre.Text = Nombre
        TxtClave.Text = Clave


        GridImpresora.DataSource = dtImpresora
        GridImpresora.RetrieveStructure(True)
        GridImpresora.GroupByBoxVisible = False
        GridImpresora.RootTable.Columns("idPrinter").Visible = False
        GridImpresora.RootTable.Columns("Modificado").Visible = False
        GridImpresora.RootTable.Columns("Baja").Visible = False


        GridImpresora.CurrentTable.Columns("Impresora").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridImpresora.Tables(0).Columns("Impresora").ValueList
        With AircraftTypeValueListItemCollection

            dtPrinter = ModPOS.Recupera_Tabla("sp_filtra_impresora", "@SUCClave", SUCClave)

            Dim i As Integer
            For i = 0 To dtprinter.Rows.Count - 1
                .Add(dtprinter.Rows(i)("PRNClave"), DTPRINTER.Rows(i)("Referencia"))
            Next

        End With
        GridImpresora.CurrentTable.Columns("Impresora").EditType = Janus.Windows.GridEX.EditType.Combo


        GridImpresora.CurrentTable.Columns("Inicial").HasValueList = True
        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = GridImpresora.Tables(0).Columns("Inicial").ValueList
        With AircraftTypeValueListItemCollection2

            dtPrinter = ModPOS.Recupera_Tabla("sp_filtra_valorref_concat", "@Tabla", "Venta", "@Campo", "formaEnvio")

            Dim i As Integer
            For i = 0 To dtPrinter.Rows.Count - 1
                .Add(dtPrinter.Rows(i)("valor"), dtPrinter.Rows(i)("descripcion"))
            Next

        End With
        GridImpresora.CurrentTable.Columns("Inicial").EditType = Janus.Windows.GridEX.EditType.Combo



        GridImpresora.CurrentTable.Columns("Final").HasValueList = True
        Dim AircraftTypeValueListItemCollection3 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection3 = GridImpresora.Tables(0).Columns("Final").ValueList
        With AircraftTypeValueListItemCollection3

            Dim i As Integer
            For i = 0 To dtPrinter.Rows.Count - 1
                .Add(dtPrinter.Rows(i)("valor"), dtPrinter.Rows(i)("descripcion"))
            Next

        End With
        GridImpresora.CurrentTable.Columns("Final").EditType = Janus.Windows.GridEX.EditType.Combo



        ModPOS.ActualizaGrid(True, GridEstructuras, "sp_muestra_estructuras", "@almacen", "Todos", "@area", Me.AREClave)
        GridEstructuras.RootTable.Columns("ESTClave").Visible = False

    End Sub

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

        If Me.CmbTipoArea.Text = "" OrElse CmbTipoArea.FindString(CmbTipoArea.Text) = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        Dim iColor As Integer
        iColor = Me.PnlColor.BackColor.ToArgb
        If iColor = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()

        End If





        If i > 0 Then
            Return False

        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Area", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If validaForm() Then
            Dim i As Integer
            Dim foundRows() As DataRow

            Select Case ModPOS.Areas.Padre
                Case "Agregar"

                    Me.Clave = UCase(Trim(Me.TxtClave.Text))
                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Tipo = Me.CmbTipoArea.SelectedValue
                    Me.Color = Me.PnlColor.BackColor.ToArgb
                    Me.Estado = 1


                    ModPOS.Graba_Area(ModPOS.Areas)

                    foundRows = dtImpresora.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_printerarea", _
                                                  "@idPrinter", foundRows(i)("idPrinter"), _
                                                  "@AREClave", AREClave, _
                                                  "@PRNClave", foundRows(i)("Impresora"), _
                                                  "@Inicial", foundRows(i)("Inicial"), _
                                                  "@Final", foundRows(i)("Final"), _
                                                  "@Impresiones", foundRows(i)("Impresiones"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If



                    If Not ModPOS.MtoArea Is Nothing Then
                        ModPOS.MtoArea.refrescaGrid()

                    Else
                        If Forma = "Estructura" Then
                            With ModPOS.Estructuras
                                With .CmbArea
                                    .Conexion = ModPOS.BDConexion
                                    .ProcedimientoAlmacenado = "sp_filtra_areas"
                                    .NombreParametro1 = "ALMClave"
                                    .Parametro1 = ALMClave
                                    .llenar()
                                End With
                            End With
                        End If
                    End If
                    Me.Close()

                Case "Modificar"
                    If Not (Me.Clave = UCase(Trim(Me.TxtClave.Text)) AndAlso _
                        Me.Nombre = UCase(Trim(Me.TxtNombre.Text)) AndAlso _
                        Me.Tipo = Me.CmbTipoArea.SelectedValue AndAlso _
                        Me.Color = Me.PnlColor.BackColor.ToArgb AndAlso _
                        Me.Estado = cmbTipoEstado.SelectedValue) Then

                        Me.Clave = UCase(Trim(Me.TxtClave.Text))
                        Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                        Me.Tipo = Me.CmbTipoArea.SelectedValue
                        Me.Estado = cmbTipoEstado.SelectedValue


                        If Me.Color <> Me.PnlColor.BackColor.ToArgb Then


                            Me.Color = Me.PnlColor.BackColor.ToArgb


                            ModPOS.Update_Area(ModPOS.Areas, True)

                            If ModPOS.numEst_Vector > 0 Then

                                While i < ModPOS.vector.Length
                                    If ModPOS.vector(i).AREClave = Me.AREClave Then
                                        ModPOS.vector(i).Color = Me.Color
                                        ModPOS.vector(i).BackColor = System.Drawing.Color.FromArgb(Me.Color)
                                    End If
                                    i += 1
                                End While
                                ModPOS.Superficie.Refresh()
                            End If

                        Else

                            Me.Color = Me.PnlColor.BackColor.ToArgb


                            ModPOS.Update_Area(ModPOS.Areas, False)
                        End If

                        ModPOS.MtoArea.refrescaGrid()

                    End If


                    foundRows = dtImpresora.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_printerarea", _
                                                  "@idPrinter", foundRows(i)("idPrinter"), _
                                                  "@AREClave", AREClave, _
                                                  "@PRNClave", foundRows(i)("Impresora"), _
                                                  "@Inicial", foundRows(i)("Inicial"), _
                                                  "@Final", foundRows(i)("Final"), _
                                                  "@Impresiones", foundRows(i)("Impresiones"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub




    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        
            If Not cmbImpresora.SelectedValue Is Nothing Then

            Dim foundRows() As System.Data.DataRow
            foundRows = dtImpresora.Select(" Impresora = '" & cmbImpresora.SelectedValue & "' and Baja = 0 ")

            If foundRows.GetLength(0) > 0 Then
                MessageBox.Show("¡La Impresora que intenta agregar ya existe en la configuración de area actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Dim row1 As DataRow
                row1 = dtImpresora.NewRow()
                'Valor,Descripcion,Orden,0 as Modificado,Baja 
                row1.Item("idPrinter") = obtenerLlave()
                row1.Item("Inicial") = 0
                row1.Item("Final") = 98
                row1.Item("Impresora") = cmbImpresora.SelectedValue
                row1.Item("Impresiones") = 1
                row1.Item("Modificado") = 1
                row1.Item("Baja") = 0
                dtImpresora.Rows.Add(row1)
            End If
        Else
            MessageBox.Show("Debe seleccionar una impresora valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If sIdSelected <> "" Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtImpresora.Select(" idPrinter = '" & sIdSelected & "'")
            foundRows(0)("Baja") = 1
            foundRows(0)("Modificado") = 1

        End If
    End Sub

    Private Sub GridImpresora_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridImpresora.CellEdited
        Select Case GridImpresora.CurrentColumn.Caption
            Case "Inicial"
                If Not (IsNumeric(GridImpresora.GetValue("Inicial")) AndAlso CDbl(GridImpresora.GetValue("Inicial")) >= 0) Then
                    GridImpresora.SetValue("Inicial", 0)
                    GridImpresora.SetValue("Modificado", 1)
                Else
                    GridImpresora.SetValue("Modificado", 1)

                End If

            Case "Final"
                If (IsNumeric(GridImpresora.GetValue("Final")) AndAlso CDbl(GridImpresora.GetValue("Final")) < GridImpresora.GetValue("Inicial")) Then
                    GridImpresora.SetValue("Final", 98)
                    GridImpresora.SetValue("Modificado", 1)
                Else
                    GridImpresora.SetValue("Modificado", 1)
                End If

            Case "Impresiones"
                If Not (IsNumeric(GridImpresora.GetValue("Impresiones")) OrElse CDbl(GridImpresora.GetValue("Impresiones")) < 1) Then
                    GridImpresora.SetValue("Impresiones", 1)
                    GridImpresora.SetValue("Modificado", 1)
                Else
                    GridImpresora.SetValue("Modificado", 1)

                End If

            Case "Impresora"
                If GridImpresora.GetValue("Impresora").GetType.Name = "DBNull" OrElse CStr(GridImpresora.GetValue("Impresora")).Length = 0 Then
                    GridImpresora.SetValue("Impresora", "ERROR")
                    GridImpresora.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtImpresora.Select(" Impresora <> '" & GridImpresora.GetValue("idPrinter") & "' and Baja = 0 and Impresora = '" & CStr(GridImpresora.GetValue("Impresora")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La impresora que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridImpresora.SetValue("Impresora", "ERROR")
                        GridImpresora.SetValue("Modificado", 0)
                    Else
                        GridImpresora.SetValue("Impresora", CStr(GridImpresora.GetValue("Impresora")).Trim)
                        GridImpresora.SetValue("Modificado", 1)
                    End If
                End If

        End Select
    End Sub


  

    Private Sub GridImpresora_SelectionChanged(sender As Object, e As EventArgs) Handles GridImpresora.SelectionChanged
        If Not GridImpresora.GetValue("idPrinter") Is Nothing Then
            Me.BtnEliminar.Enabled = True
            sIdSelected = GridImpresora.GetValue("idPrinter")
        Else
            Me.BtnEliminar.Enabled = False
            sIdSelected = ""
        End If
    End Sub
End Class
