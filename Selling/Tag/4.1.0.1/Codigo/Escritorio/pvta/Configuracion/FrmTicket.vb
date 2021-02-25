Public Class FrmTicket
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
    Friend WithEvents GrpAlmacen As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents GrpImagen As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PicEncabezado As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents BtnFuente As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtFontSize As System.Windows.Forms.TextBox
    Friend WithEvents TxtFontName As System.Windows.Forms.TextBox
    Friend WithEvents NumMaxChar As System.Windows.Forms.NumericUpDown
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpMultiproducto As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbTipoTicket As Selling.StoreCombo
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAddHead As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddFoot As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridEncabezado As Janus.Windows.GridEX.GridEX
    Friend WithEvents GridPie As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnModHead As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDelHead As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModPie As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDelPie As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTicket))
        Me.GrpAlmacen = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.CmbTipoTicket = New Selling.StoreCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumMaxChar = New System.Windows.Forms.NumericUpDown()
        Me.TxtFontSize = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFontName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnFuente = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpImagen = New System.Windows.Forms.GroupBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PicEncabezado = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.GrpMultiproducto = New System.Windows.Forms.GroupBox()
        Me.BtnModHead = New Janus.Windows.EditControls.UIButton()
        Me.BtnDelHead = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddHead = New Janus.Windows.EditControls.UIButton()
        Me.GridEncabezado = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnModPie = New Janus.Windows.EditControls.UIButton()
        Me.BtnDelPie = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddFoot = New Janus.Windows.EditControls.UIButton()
        Me.GridPie = New Janus.Windows.GridEX.GridEX()
        Me.GrpAlmacen.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumMaxChar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpImagen.SuspendLayout()
        CType(Me.PicEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMultiproducto.SuspendLayout()
        CType(Me.GridEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridPie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpAlmacen
        '
        Me.GrpAlmacen.Controls.Add(Me.PictureBox5)
        Me.GrpAlmacen.Controls.Add(Me.CmbSucursal)
        Me.GrpAlmacen.Controls.Add(Me.Label12)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox3)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox4)
        Me.GrpAlmacen.Controls.Add(Me.CmbTipoTicket)
        Me.GrpAlmacen.Controls.Add(Me.Label6)
        Me.GrpAlmacen.Controls.Add(Me.Label5)
        Me.GrpAlmacen.Controls.Add(Me.NumMaxChar)
        Me.GrpAlmacen.Controls.Add(Me.TxtFontSize)
        Me.GrpAlmacen.Controls.Add(Me.Label3)
        Me.GrpAlmacen.Controls.Add(Me.TxtFontName)
        Me.GrpAlmacen.Controls.Add(Me.Label1)
        Me.GrpAlmacen.Controls.Add(Me.ChkEstado)
        Me.GrpAlmacen.Controls.Add(Me.TxtNombre)
        Me.GrpAlmacen.Controls.Add(Me.LblNombre)
        Me.GrpAlmacen.Controls.Add(Me.TxtClave)
        Me.GrpAlmacen.Controls.Add(Me.LblClave)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox1)
        Me.GrpAlmacen.Controls.Add(Me.Label4)
        Me.GrpAlmacen.Controls.Add(Me.BtnFuente)
        Me.GrpAlmacen.Location = New System.Drawing.Point(7, 7)
        Me.GrpAlmacen.Name = "GrpAlmacen"
        Me.GrpAlmacen.Size = New System.Drawing.Size(510, 173)
        Me.GrpAlmacen.TabIndex = 1
        Me.GrpAlmacen.TabStop = False
        Me.GrpAlmacen.Text = "General"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(323, 16)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(23, 19)
        Me.PictureBox5.TabIndex = 123
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(92, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(227, 21)
        Me.CmbSucursal.TabIndex = 121
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Sucursal"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(320, 104)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(23, 19)
        Me.PictureBox3.TabIndex = 44
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(253, 146)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 19)
        Me.PictureBox4.TabIndex = 43
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'CmbTipoTicket
        '
        Me.CmbTipoTicket.Location = New System.Drawing.Point(92, 146)
        Me.CmbTipoTicket.Name = "CmbTipoTicket"
        Me.CmbTipoTicket.Size = New System.Drawing.Size(154, 21)
        Me.CmbTipoTicket.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Tipo"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 15)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Maximo Num. Caracteres por Linea"
        '
        'NumMaxChar
        '
        Me.NumMaxChar.Location = New System.Drawing.Point(227, 124)
        Me.NumMaxChar.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.NumMaxChar.Minimum = New Decimal(New Integer() {27, 0, 0, 0})
        Me.NumMaxChar.Name = "NumMaxChar"
        Me.NumMaxChar.Size = New System.Drawing.Size(60, 20)
        Me.NumMaxChar.TabIndex = 4
        Me.NumMaxChar.Value = New Decimal(New Integer() {27, 0, 0, 0})
        '
        'TxtFontSize
        '
        Me.TxtFontSize.Location = New System.Drawing.Point(227, 99)
        Me.TxtFontSize.Name = "TxtFontSize"
        Me.TxtFontSize.ReadOnly = True
        Me.TxtFontSize.Size = New System.Drawing.Size(60, 20)
        Me.TxtFontSize.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Fuente"
        '
        'TxtFontName
        '
        Me.TxtFontName.Location = New System.Drawing.Point(92, 99)
        Me.TxtFontName.Name = "TxtFontName"
        Me.TxtFontName.ReadOnly = True
        Me.TxtFontName.Size = New System.Drawing.Size(127, 20)
        Me.TxtFontName.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(137, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Max. 20 Caracteres"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(347, 13)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(60, 22)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(92, 71)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(227, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(12, 73)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(92, 43)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(120, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(12, 43)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(220, 43)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 19)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(227, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 20 Caracteres"
        '
        'BtnFuente
        '
        Me.BtnFuente.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFuente.Location = New System.Drawing.Point(293, 96)
        Me.BtnFuente.Name = "BtnFuente"
        Me.BtnFuente.Size = New System.Drawing.Size(27, 28)
        Me.BtnFuente.TabIndex = 3
        Me.BtnFuente.Text = "A"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(327, 78)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 19)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(524, 63)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(524, 11)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 30)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpImagen
        '
        Me.GrpImagen.Controls.Add(Me.UiButton1)
        Me.GrpImagen.Controls.Add(Me.Label2)
        Me.GrpImagen.Controls.Add(Me.PicEncabezado)
        Me.GrpImagen.Location = New System.Drawing.Point(7, 186)
        Me.GrpImagen.Name = "GrpImagen"
        Me.GrpImagen.Size = New System.Drawing.Size(613, 103)
        Me.GrpImagen.TabIndex = 30
        Me.GrpImagen.TabStop = False
        Me.GrpImagen.Text = "Imagen"
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(435, 37)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(90, 30)
        Me.UiButton1.TabIndex = 33
        Me.UiButton1.Text = "&Quitar"
        Me.UiButton1.ToolTipText = "Remover Imagen"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(209, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(269, 14)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Doble click sobre el recuadro de imagen para modificar"
        '
        'PicEncabezado
        '
        Me.PicEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicEncabezado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicEncabezado.Location = New System.Drawing.Point(11, 15)
        Me.PicEncabezado.Name = "PicEncabezado"
        Me.PicEncabezado.Size = New System.Drawing.Size(184, 77)
        Me.PicEncabezado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEncabezado.TabIndex = 0
        Me.PicEncabezado.TabStop = False
        '
        'GrpMultiproducto
        '
        Me.GrpMultiproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMultiproducto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMultiproducto.Controls.Add(Me.BtnModHead)
        Me.GrpMultiproducto.Controls.Add(Me.BtnDelHead)
        Me.GrpMultiproducto.Controls.Add(Me.BtnAddHead)
        Me.GrpMultiproducto.Controls.Add(Me.GridEncabezado)
        Me.GrpMultiproducto.Location = New System.Drawing.Point(7, 294)
        Me.GrpMultiproducto.Name = "GrpMultiproducto"
        Me.GrpMultiproducto.Size = New System.Drawing.Size(613, 212)
        Me.GrpMultiproducto.TabIndex = 31
        Me.GrpMultiproducto.TabStop = False
        Me.GrpMultiproducto.Text = "Encabezado"
        '
        'BtnModHead
        '
        Me.BtnModHead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModHead.Image = CType(resources.GetObject("BtnModHead.Image"), System.Drawing.Image)
        Me.BtnModHead.Location = New System.Drawing.Point(516, 49)
        Me.BtnModHead.Name = "BtnModHead"
        Me.BtnModHead.Size = New System.Drawing.Size(90, 30)
        Me.BtnModHead.TabIndex = 7
        Me.BtnModHead.Text = "&Modificar"
        Me.BtnModHead.ToolTipText = "Modificar linea seleccionada"
        Me.BtnModHead.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDelHead
        '
        Me.BtnDelHead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelHead.Image = CType(resources.GetObject("BtnDelHead.Image"), System.Drawing.Image)
        Me.BtnDelHead.Location = New System.Drawing.Point(516, 83)
        Me.BtnDelHead.Name = "BtnDelHead"
        Me.BtnDelHead.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelHead.TabIndex = 8
        Me.BtnDelHead.Text = "&Eliminar"
        Me.BtnDelHead.ToolTipText = "Eliminar linea seleccionada"
        Me.BtnDelHead.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddHead
        '
        Me.BtnAddHead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddHead.Image = CType(resources.GetObject("BtnAddHead.Image"), System.Drawing.Image)
        Me.BtnAddHead.Location = New System.Drawing.Point(516, 15)
        Me.BtnAddHead.Name = "BtnAddHead"
        Me.BtnAddHead.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddHead.TabIndex = 6
        Me.BtnAddHead.Text = "&Agregar "
        Me.BtnAddHead.ToolTipText = "Agregar nueva linea de encabezado"
        Me.BtnAddHead.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEncabezado
        '
        Me.GridEncabezado.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEncabezado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEncabezado.ColumnAutoResize = True
        Me.GridEncabezado.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEncabezado.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEncabezado.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEncabezado.Location = New System.Drawing.Point(7, 15)
        Me.GridEncabezado.Name = "GridEncabezado"
        Me.GridEncabezado.RecordNavigator = True
        Me.GridEncabezado.Size = New System.Drawing.Size(503, 189)
        Me.GridEncabezado.TabIndex = 1
        Me.GridEncabezado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.BtnModPie)
        Me.GroupBox1.Controls.Add(Me.BtnDelPie)
        Me.GroupBox1.Controls.Add(Me.BtnAddFoot)
        Me.GroupBox1.Controls.Add(Me.GridPie)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 512)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(613, 153)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pie"
        '
        'BtnModPie
        '
        Me.BtnModPie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModPie.Image = CType(resources.GetObject("BtnModPie.Image"), System.Drawing.Image)
        Me.BtnModPie.Location = New System.Drawing.Point(516, 55)
        Me.BtnModPie.Name = "BtnModPie"
        Me.BtnModPie.Size = New System.Drawing.Size(90, 30)
        Me.BtnModPie.TabIndex = 7
        Me.BtnModPie.Text = "&Modificar"
        Me.BtnModPie.ToolTipText = "Modificar linea seleccionada"
        Me.BtnModPie.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDelPie
        '
        Me.BtnDelPie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelPie.Image = CType(resources.GetObject("BtnDelPie.Image"), System.Drawing.Image)
        Me.BtnDelPie.Location = New System.Drawing.Point(515, 91)
        Me.BtnDelPie.Name = "BtnDelPie"
        Me.BtnDelPie.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelPie.TabIndex = 8
        Me.BtnDelPie.Text = "&Eliminar"
        Me.BtnDelPie.ToolTipText = "Eliminar linea seleccionada"
        Me.BtnDelPie.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddFoot
        '
        Me.BtnAddFoot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddFoot.Image = CType(resources.GetObject("BtnAddFoot.Image"), System.Drawing.Image)
        Me.BtnAddFoot.Location = New System.Drawing.Point(515, 19)
        Me.BtnAddFoot.Name = "BtnAddFoot"
        Me.BtnAddFoot.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddFoot.TabIndex = 6
        Me.BtnAddFoot.Text = "&Agregar "
        Me.BtnAddFoot.ToolTipText = "Agregar nueva linea a pie"
        Me.BtnAddFoot.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPie
        '
        Me.GridPie.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPie.ColumnAutoResize = True
        Me.GridPie.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPie.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPie.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPie.Location = New System.Drawing.Point(7, 19)
        Me.GridPie.Name = "GridPie"
        Me.GridPie.RecordNavigator = True
        Me.GridPie.Size = New System.Drawing.Size(503, 126)
        Me.GridPie.TabIndex = 1
        Me.GridPie.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmTicket
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(620, 674)
        Me.Controls.Add(Me.GrpMultiproducto)
        Me.Controls.Add(Me.GrpImagen)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GrpAlmacen)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTicket"
        Me.Text = "Ticket"
        Me.GrpAlmacen.ResumeLayout(False)
        Me.GrpAlmacen.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumMaxChar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpImagen.ResumeLayout(False)
        CType(Me.PicEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMultiproducto.ResumeLayout(False)
        CType(Me.GridEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridPie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public TIKClave As String = ""
    Public Clave As String
    Public Nombre As String
    Public FontName As String
    Public FontSize As Integer
    Public url_imagen As String = ""
    Public Tipo As Integer
    Public MaxChar As Integer = 27
    Public Estado As Integer
    Public ImgCambio As Boolean = True
    Public SUCClave As String = ""


    Private dtEncabezado, dtPie As DataTable
    Private bModificaEncabezado, bModificaPie As Boolean


    Private sEncabezado, sNombreHead, sPie, sNombrePie As String
    Private SourceToImage As Bitmap
    Private PicLoad As Boolean = False
    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)

        End If

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)

        End If

        If Me.TxtFontName.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CmbTipoTicket.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Ticket", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub reinicializa()

        Nombre = ""
        Clave = ""
        FontName = ""
        Estado = 1
        FontSize = 0
        MaxChar = 27
        Tipo = 1

        TxtNombre.Text = Nombre
        TxtClave.Text = Clave
        TxtFontName.Text = FontName
        TxtFontSize.Text = FontSize
        NumMaxChar.Value = MaxChar
        CmbTipoTicket.SelectedValue = Tipo
        ChkEstado.Estado = Estado

        dtEncabezado.Dispose()

        dtEncabezado = ModPOS.CrearTabla("Encabezado", _
               "ID", "System.String", _
               "Linea", "System.Int32", _
               "Texto", "System.String", _
               "Negrita", "System.Int32", _
               "Alinear", "System.Int32")

        dtPie.Dispose()
        dtPie = ModPOS.CrearTabla("Pie", _
                        "ID", "System.String", _
                        "Linea", "System.Int32", _
                        "Texto", "System.String", _
                        "Negrita", "System.Int32", _
                        "Alinear", "System.Int32")

        GridEncabezado.DataSource = dtEncabezado
        GridEncabezado.RetrieveStructure(True)
        GridEncabezado.GroupByBoxVisible = False
        GridEncabezado.RootTable.Columns("ID").Visible = False
        GridEncabezado.RootTable.Columns("Negrita").Visible = False
        GridEncabezado.RootTable.Columns("Alinear").Visible = False

        GridPie.DataSource = dtPie
        GridPie.RetrieveStructure(True)
        GridPie.GroupByBoxVisible = False
        GridPie.RootTable.Columns("ID").Visible = False
        GridPie.RootTable.Columns("Negrita").Visible = False
        GridPie.RootTable.Columns("Alinear").Visible = False

        url_imagen = ""
        ImgCambio = False
        PicEncabezado.Image = Nothing
    End Sub

    Private Sub FrmTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        With Me.CmbTipoTicket
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Ticket"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        TxtNombre.Text = Nombre
        TxtClave.Text = Clave
        TxtFontName.Text = FontName
        TxtFontSize.Text = FontSize
        NumMaxChar.Value = MaxChar
        CmbTipoTicket.SelectedValue = Tipo
        ChkEstado.Estado = Estado
        CmbSucursal.SelectedValue = SUCClave

        If url_imagen <> "" Then
            Me.RecuperaImagen(url_imagen)
        End If

        If Padre = "Agregar" Then
            dtEncabezado = ModPOS.CrearTabla("Encabezado", _
                "ID", "System.String", _
                "Linea", "System.Int32", _
                "Texto", "System.String", _
                "Negrita", "System.Int32", _
                "Alinear", "System.Int32")

            dtPie = ModPOS.CrearTabla("Pie", _
                            "ID", "System.String", _
                            "Linea", "System.Int32", _
                            "Texto", "System.String", _
                            "Negrita", "System.Int32", _
                            "Alinear", "System.Int32")


        Else
            dtEncabezado = ModPOS.Recupera_Tabla("sp_muestra_encabezado", "@TIKClave", TIKClave)
            dtPie = ModPOS.Recupera_Tabla("sp_muestra_pie", "@TIKClave", TIKClave)
        End If

        GridEncabezado.DataSource = dtEncabezado
        GridEncabezado.RetrieveStructure(True)
        GridEncabezado.GroupByBoxVisible = False
        GridEncabezado.RootTable.Columns("ID").Visible = False
        GridEncabezado.RootTable.Columns("Negrita").Visible = False
        GridEncabezado.RootTable.Columns("Alinear").Visible = False

        GridPie.DataSource = dtPie
        GridPie.RetrieveStructure(True)
        GridPie.GroupByBoxVisible = False
        GridPie.RootTable.Columns("ID").Visible = False
        GridPie.RootTable.Columns("Negrita").Visible = False
        GridPie.RootTable.Columns("Alinear").Visible = False

        bModificaEncabezado = True
        bModificaPie = True
    End Sub

    Public Sub addTexto(ByVal Tipo As String, ByVal Texto As String, ByVal Negrita As Integer, ByVal Alinear As Integer)
        Dim row1 As DataRow
        If Tipo = "Encabezado" Then

            row1 = dtEncabezado.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("Linea") = dtEncabezado.Rows.Count + 1
            row1.Item("Texto") = Texto
            row1.Item("Negrita") = Negrita
            row1.Item("Alinear") = Alinear
            dtEncabezado.Rows.Add(row1)
            bModificaEncabezado = False
        Else
            row1 = dtPie.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("Linea") = dtPie.Rows.Count + 1
            row1.Item("Texto") = Texto
            row1.Item("Negrita") = Negrita
            row1.Item("Alinear") = Alinear
            dtPie.Rows.Add(row1)
            bModificaPie = False
        End If
    End Sub


    Public Sub updateTexto(ByVal Tipo As String, ByVal ID As String, ByVal Linea As Integer, ByVal Texto As String, ByVal Negrita As Integer, ByVal Alinear As Integer)

        Dim foundRows() As System.Data.DataRow

        If Tipo = "Encabezado" Then
            foundRows = dtEncabezado.Select("ID Like '" & ID & "'")
            bModificaEncabezado = False
        Else
            foundRows = dtPie.Select("ID Like '" & ID & "'")
            bModificaPie = False
        End If

        foundRows(0)("Linea") = Linea
        foundRows(0)("Texto") = Texto
        foundRows(0)("Negrita") = Negrita
        foundRows(0)("Alinear") = Alinear

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    TIKClave = ModPOS.obtenerLlave
                    Clave = TxtClave.Text.Trim.ToUpper
                    Nombre = TxtNombre.Text.Trim.ToUpper
                    FontName = TxtFontName.Text
                    FontSize = CInt(TxtFontSize.Text)
                    Tipo = CmbTipoTicket.SelectedValue
                    MaxChar = NumMaxChar.Value
                    SUCClave = CmbSucursal.SelectedValue

                    Dim dt As DataTable

                    If PicLoad Then

                        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Imagenes", "@COMClave", ModPOS.CompanyActual)
                        url_imagen = dt.Rows(0)("Valor")
                        url_imagen = url_imagen & "\Ticket\"

                        Try
                            If Not System.IO.Directory.Exists(url_imagen) Then
                                System.IO.Directory.CreateDirectory(url_imagen)
                            End If
                        Catch ex As Exception
                        End Try


                        url_imagen = url_imagen & Clave & ".jpg"
                        dt.Dispose()
                        Try
                            FileCopy(Application.StartupPath & "\Temp\" & "ticket.jpg", url_imagen)
                            PicLoad = False
                        Catch exc As Exception
                            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If


                    ModPOS.Ejecuta("sp_inserta_ticket", _
                    "@TIKClave", TIKClave, _
                    "@Clave", Clave, _
                    "@Nombre", Nombre, _
                    "@FontName", FontName, _
                    "@FontSize", FontSize, _
                    "@url_imagen", url_imagen, _
                    "@Tipo", Tipo, _
                    "@MaxChar", MaxChar, _
                    "@SUCClave", SUCClave, _
                    "@Usuario", ModPOS.UsuarioActual)


                    Dim fila As Integer

                    For fila = 0 To dtEncabezado.Rows.Count - 1

                        ModPOS.Ejecuta("sp_inserta_texto", _
                        "@Tipo", "Encabezado", _
                        "@TIKClave", TIKClave, _
                        "@ID", dtEncabezado.Rows(fila)("ID"), _
                        "@Linea", dtEncabezado.Rows(fila)("Linea"), _
                        "@Texto", dtEncabezado.Rows(fila)("Texto"), _
                        "@Negrita", dtEncabezado.Rows(fila)("Negrita"), _
                        "@Alinear", dtEncabezado.Rows(fila)("Alinear"), _
                        "@Usuario", ModPOS.UsuarioActual)
                    Next


                    For fila = 0 To dtPie.Rows.Count - 1

                        ModPOS.Ejecuta("sp_inserta_texto", _
                        "@Tipo", "Pie", _
                        "@TIKClave", TIKClave, _
                        "@ID", dtPie.Rows(fila)("ID"), _
                        "@Linea", dtPie.Rows(fila)("Linea"), _
                        "@Texto", dtPie.Rows(fila)("Texto"), _
                        "@Negrita", dtPie.Rows(fila)("Negrita"), _
                        "@Alinear", dtPie.Rows(fila)("Alinear"), _
                        "@Usuario", ModPOS.UsuarioActual)
                    Next


                    If Not ModPOS.MtoTicket Is Nothing Then
                        ModPOS.ActualizaGrid(True, MtoTicket.GridTickets, "sp_muestra_tickets", "@COMClave", ModPOS.CompanyActual)
                        MtoTicket.GridTickets.RootTable.Columns("ID").Visible = False
                    End If

                    reinicializa()

                Case "Modificar"
                    If Not (Nombre = TxtNombre.Text.Trim.ToUpper AndAlso _
                        FontName = TxtFontName.Text AndAlso _
                        FontSize = CInt(TxtFontSize.Text) AndAlso _
                        Tipo = CmbTipoTicket.SelectedValue AndAlso _
                        MaxChar = NumMaxChar.Value AndAlso _
                        ImgCambio = False AndAlso _
                        bModificaEncabezado AndAlso _
                        bModificaPie AndAlso _
                        SUCClave = CmbSucursal.SelectedValue AndAlso _
                        Estado = ChkEstado.GetEstado) Then

                        Nombre = TxtNombre.Text.Trim.ToUpper
                        FontName = TxtFontName.Text
                        FontSize = CInt(TxtFontSize.Text)
                        Tipo = CmbTipoTicket.SelectedValue
                        MaxChar = NumMaxChar.Value
                        Estado = ChkEstado.GetEstado
                        SUCClave = CmbSucursal.SelectedValue

                        If PicLoad Then

                            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Imagenes", "@COMClave", ModPOS.CompanyActual)
                            url_imagen = dt.Rows(0)("Valor")
                            url_imagen = url_imagen & "\Ticket\"

                            Try
                                If Not System.IO.Directory.Exists(url_imagen) Then
                                    System.IO.Directory.CreateDirectory(url_imagen)
                                End If
                            Catch ex As Exception
                            End Try


                            url_imagen = url_imagen & Clave & ".jpg"

                            dt.Dispose()
                            Try
                                FileCopy(Application.StartupPath & "\Temp\" & "ticket.jpg", url_imagen)
                                PicLoad = False
                            Catch exc As Exception
                                MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End If

                        ModPOS.Ejecuta("sp_actualiza_ticket", _
                        "@TIKClave", TIKClave, _
                        "@Nombre", Nombre, _
                        "@FontName", FontName, _
                        "@FontSize", FontSize, _
                        "@url_imagen", url_imagen, _
                        "@Tipo", Tipo, _
                        "@MaxChar", MaxChar, _
                        "@Estado", Estado, _
                        "@SUCClave", SUCClave, _
                        "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Ejecuta("sp_actualiza_texto", _
                        "@TIKClave", TIKClave)

                        Dim fila As Integer

                        For fila = 0 To dtEncabezado.Rows.Count - 1

                            ModPOS.Ejecuta("sp_inserta_texto", _
                            "@Tipo", "Encabezado", _
                            "@TIKClave", TIKClave, _
                            "@ID", dtEncabezado.Rows(fila)("ID"), _
                            "@Linea", dtEncabezado.Rows(fila)("Linea"), _
                            "@Texto", dtEncabezado.Rows(fila)("Texto"), _
                            "@Negrita", dtEncabezado.Rows(fila)("Negrita"), _
                            "@Alinear", dtEncabezado.Rows(fila)("Alinear"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next

                        For fila = 0 To dtPie.Rows.Count - 1

                            ModPOS.Ejecuta("sp_inserta_texto", _
                            "@Tipo", "Pie", _
                            "@TIKClave", TIKClave, _
                            "@ID", dtPie.Rows(fila)("ID"), _
                            "@Linea", dtPie.Rows(fila)("Linea"), _
                            "@Texto", dtPie.Rows(fila)("Texto"), _
                            "@Negrita", dtPie.Rows(fila)("Negrita"), _
                            "@Alinear", dtPie.Rows(fila)("Alinear"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next

                        If Not ModPOS.MtoTicket Is Nothing Then
                            ModPOS.ActualizaGrid(True, MtoTicket.GridTickets, "sp_muestra_tickets", "@COMClave", ModPOS.CompanyActual)
                            MtoTicket.GridTickets.RootTable.Columns("ID").Visible = False
                        End If

                    End If
                    Me.Close()

            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmTicket_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Ticket.Dispose()
        ModPOS.Ticket = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub PicEncabezado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicEncabezado.DoubleClick
        Dim FileName As String
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If (result = DialogResult.OK) Then

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Me.SuspendLayout()

            FileName = OpenFileDialog1.FileName

            'Generar un bitmap para el origen
            Dim SourceImage As Bitmap
            SourceImage = New Bitmap(FileName)

            ' Generar un bitmap para el resultado
            SourceToImage = New Bitmap(SourceImage.Width, SourceImage.Height)

            ' Generar un objeto Gráfico para el Bitmap resultante
            Dim gr_source As Graphics = Graphics.FromImage(SourceToImage)

            ' Copiar la imagen origen al Bitmap destino
            gr_source.DrawImage(SourceImage, 0, 0, _
                SourceToImage.Width, _
                SourceToImage.Height)


            'Liberar recursos
            gr_source.Dispose()

            SourceImage.Dispose()


            If IsNothing(PicEncabezado.Image) = False Then
                PicEncabezado.Image = Nothing
            End If

            ObtenerResultado()
            PicLoad = True
            ImgCambio = True

        End If

    End Sub

    Private Sub ObtenerResultado()

        Dim NeedsHorizontalCrop As Boolean = True
        Dim NeedsVerticalCrop As Boolean = False

        'Determina si la imagen es Landscape o Portrait
        If SourceToImage.Height > SourceToImage.Width Then
            NeedsHorizontalCrop = False
            NeedsVerticalCrop = True
        End If

        'Determina si la imagen excede el ancho del PictureBox
        If SourceToImage.Width < 300 Then
            NeedsHorizontalCrop = False
            If SourceToImage.Height > 60 Then
                NeedsVerticalCrop = True
            End If
        End If

        'Calcula el Factor de Ajuste
        Dim scale_factor As Single = 1
        If SourceToImage.Width > 0 Then
            If NeedsHorizontalCrop = True Then
                ' Obtiene el Factor de Ajuste
                scale_factor = 300 / SourceToImage.Width
            End If
        End If

        If SourceToImage.Height > 0 Then
            If NeedsVerticalCrop = True Then
                ' Obtiene el Factor de Ajuste
                scale_factor = 60 / SourceToImage.Height
            End If
        End If

        ' Generar un bitmap tmp para el resultado. Ajuste Proporcional
        Dim DestTmpImage As New Bitmap( _
            CInt(SourceToImage.Width * scale_factor), _
            CInt(SourceToImage.Height * scale_factor))

        ' Generar un objeto Gráfico para el bitmap tmp resultante
        Dim gr_desttmp As Graphics = Graphics.FromImage(DestTmpImage)

        ' Copiar la imagen origen al bitmap tmp destino
        gr_desttmp.DrawImage(SourceToImage, 0, 0, _
            DestTmpImage.Width, _
            DestTmpImage.Height)

        'Comprime y Guarda un Archivo Temporal para calcular su peso en Kb
        Try
            ImageManipulation.SaveJPGWithCompressionSetting(DestTmpImage, Application.StartupPath & "\Temp\" & "ticket.jpg", 70)
        Catch exc As Exception
            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        PicEncabezado.SizeMode = PictureBoxSizeMode.StretchImage

        'La lectura del nuevo archivo no se puede hacer en forma directa y repetitiva
        'ya que está bloqueado por GDI+ la 1era vez que se lo utiliza,
        'por lo tanto resulta necesario resolver en varios pasos. 
        'Al efectuar el Dispose() se libera el recurso

        Dim DestImage As Bitmap
        DestImage = New Bitmap(Application.StartupPath & "\Temp\" & "ticket.jpg")

        ' Generar un bitmap para el resultado
        Dim DestToImage As New Bitmap(DestImage.Width, DestImage.Height)

        ' Generar un objeto Grafico para el bitmap resultante
        Dim gr_dest As Graphics = Graphics.FromImage(DestToImage)

        ' Copiar la imagen origen al bitmap destino
        gr_dest.DrawImage(DestImage, 0, 0, _
            DestToImage.Width, _
            DestToImage.Height)

        'Muestra imagen comprimida
        PicEncabezado.Image = CType(DestToImage, Image)

        'Liberar recursos
        gr_dest.Dispose()
        DestImage.Dispose()

        gr_desttmp.Dispose()


    End Sub

    Private Sub RecuperaImagen(ByVal File As String)
        'Generar un bitmap para el origen
        Dim SourceImage As Bitmap
        Try
            SourceImage = New Bitmap(File)


            ' Generar un bitmap para el resultado
            SourceToImage = New Bitmap(SourceImage.Width, SourceImage.Height)

            ' Generar un objeto Gráfico para el Bitmap resultante
            Dim gr_source As Graphics = Graphics.FromImage(SourceToImage)

            ' Copiar la imagen origen al Bitmap destino
            gr_source.DrawImage(SourceImage, 0, 0, _
                SourceToImage.Width, _
                SourceToImage.Height)

            PicEncabezado.SizeMode = PictureBoxSizeMode.StretchImage

            'Muestra imagen origen
            PicEncabezado.Image = CType(SourceToImage, Image)

            'Liberar recursos
            gr_source.Dispose()

            SourceImage.Dispose()

        Catch ex As Exception
            MessageBox.Show("No se pudo recuperar la imagen del producto", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BtnFuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFuente.Click
        'Dim Font As String
        'Dim size As Integer
        FontDialog1.ShowColor = False
        FontDialog1.ShowEffects = False

        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            TxtFontName.Text = FontDialog1.Font.Name
            TxtFontSize.Text = CStr(FontDialog1.Font.Size)
        End If

    End Sub

    Private Sub BtnAddHead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddHead.Click
        If ModPOS.Texto Is Nothing Then
            ModPOS.Texto = New FrmTextoTicket
            With ModPOS.Texto
                .Text = "Agregar Texto al Encabezado"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .Tipo = "Encabezado"
                .MaxChar = Me.MaxChar
                .TIKClave = Me.TIKClave
            End With
        End If
        ModPOS.Texto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Texto.Show()
        ModPOS.Texto.BringToFront()
    End Sub

    Private Sub BtnAddFoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFoot.Click
        If ModPOS.Texto Is Nothing Then
            ModPOS.Texto = New FrmTextoTicket
            With ModPOS.Texto
                .Text = "Agregar Texto al Pie"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .Tipo = "Pie"
                .MaxChar = Me.MaxChar
                .TIKClave = Me.TIKClave
            End With
        End If
        ModPOS.Texto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Texto.Show()
        ModPOS.Texto.BringToFront()
    End Sub

    Private Sub GridEncabezado_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEncabezado.SelectionChanged
        If Not GridEncabezado.GetValue(0) Is Nothing Then
            BtnModHead.Enabled = True
            BtnDelHead.Enabled = True
            sEncabezado = GridEncabezado.GetValue(0)
            sNombreHead = GridEncabezado.GetValue("linea")
        Else
            sEncabezado = ""
            sNombreHead = ""
            BtnModHead.Enabled = False
            BtnDelHead.Enabled = False
        End If
    End Sub

    Private Sub GridPie_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPie.SelectionChanged
        If Not GridPie.GetValue(0) Is Nothing Then
            BtnModPie.Enabled = True
            BtnDelPie.Enabled = True
            sPie = GridPie.GetValue(0)
            sNombrePie = GridPie.GetValue("linea")
        Else
            sPie = ""
            sNombrePie = ""
            BtnModPie.Enabled = False
            BtnDelPie.Enabled = False
        End If
    End Sub

    Private Sub BtnDelHead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelHead.Click
        If sEncabezado <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la linea: " & sNombreHead & " del Encabezado", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtEncabezado.Select("ID Like '" & sEncabezado & "'")
                    dtEncabezado.Rows.Remove(foundRows(0))
                    bModificaEncabezado = False

            End Select
        End If
    End Sub

    Private Sub BtnDelPie_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelPie.Click
        If sPie <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la linea: " & sNombreHead & " del Pie", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtPie.Select("ID Like '" & sPie & "'")
                    dtPie.Rows.Remove(foundRows(0))
                    bModificaPie = False
            End Select
        End If
    End Sub

    Private Sub BtnModHead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModHead.Click
        modificaHead()
    End Sub

    Private Sub BtnModPie_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModPie.Click
        modificaPie()
    End Sub

    Public Sub modificaHead()
        If sEncabezado <> "" Then

            If ModPOS.Texto Is Nothing Then

                ModPOS.Texto = New FrmTextoTicket
                With ModPOS.Texto
                    .Text = "Modificar Texto al Encabezado"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .Tipo = "Encabezado"

                    .TIKClave = TIKClave
                    .ID = sEncabezado
                    .Texto = GridEncabezado.GetValue("Texto")
                    .Negrita = GridEncabezado.GetValue("Negrita")
                    .Alinear = GridEncabezado.GetValue("Alinear")
                    .Linea = GridEncabezado.GetValue("Linea")
                    .MaxChar = Me.MaxChar


                End With
            End If

            ModPOS.Texto.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Texto.Show()
            ModPOS.Texto.BringToFront()

        End If
    End Sub

    Public Sub modificaPie()
        If sPie <> "" Then

            If ModPOS.Texto Is Nothing Then

                ModPOS.Texto = New FrmTextoTicket
                With ModPOS.Texto
                    .Text = "Modificar Texto al Pie"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .Tipo = "Pie"
                    .TIKClave = TIKClave
                    .ID = sPie
                    .Texto = GridPie.GetValue("Texto")
                    .Negrita = GridPie.GetValue("Negrita")
                    .Alinear = GridPie.GetValue("Alinear")
                    .Linea = GridPie.GetValue("Linea")
                    .MaxChar = Me.MaxChar
                End With
            End If
            ModPOS.Texto.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Texto.Show()
            ModPOS.Texto.BringToFront()
        End If
    End Sub

    Private Sub GridEncabezado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEncabezado.DoubleClick
        modificaHead()
    End Sub

    Private Sub GridPie_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPie.DoubleClick
        modificaPie()
    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        url_imagen = ""
        ImgCambio = False
        PicEncabezado.Image = Nothing
    End Sub

    Private Sub PicEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEncabezado.Click

    End Sub
End Class
