Public Class MeFiltroMov
    Inherits System.Windows.Forms.Form

    Private FechaIni As String
    Private FechaFin As String
    Private Almacen As String
    Private Linea As String
    Private Sublinea As String
    Public Titulo As String
    Private PROClave As String
    Private Todos As Integer
    Private bError As Boolean = False
    Private LineaCargada As Boolean


    ' Public Reporte As String

    Private alerta(5) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkToda As System.Windows.Forms.CheckBox
    Friend WithEvents GrpLinea As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkSublinea As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLinea As System.Windows.Forms.CheckBox
    Friend WithEvents CmbSubLinea As Selling.StoreCombo
    Friend WithEvents CmbLinea As Selling.StoreCombo
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox

    Private reloj As parpadea

    Public ReadOnly Property AlmacenOrigen() As String
        Get
            AlmacenOrigen = Almacen
        End Get
    End Property


    Public ReadOnly Property Grupo() As String
        Get
            Grupo = Linea
        End Get
    End Property

    Public ReadOnly Property Subgrupo() As String
        Get
            Subgrupo = Sublinea
        End Get
    End Property

    Public ReadOnly Property FechaInicio() As String
        Get
            FechaInicio = FechaIni
        End Get
    End Property

    Public ReadOnly Property FechaFinal() As String
        Get
            FechaFinal = FechaFin
        End Get
    End Property


    Public ReadOnly Property ClaveProducto() As String
        Get
            ClaveProducto = PROClave
        End Get
    End Property

    Public ReadOnly Property MostrarTodos() As Integer
        Get
            MostrarTodos = Todos
        End Get
    End Property


    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_found_producto", "@Clave", sClave)
        If Not dtProducto Is Nothing Then
            'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta

            PROClave = dtProducto.Rows(0)("PROClave")
            TxtClaveProd.Text = dtProducto.Rows(0)("Clave")
            TxtDescripcion.Text = dtProducto.Rows(0)("Nombre")
            dtProducto.Dispose()
        Else
            PROClave = ""
            TxtClaveProd.Text = ""
            TxtDescripcion.Text = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroMov))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.ChkToda = New System.Windows.Forms.CheckBox
        Me.GrpLinea = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.ChkSublinea = New System.Windows.Forms.CheckBox
        Me.ChkLinea = New System.Windows.Forms.CheckBox
        Me.CmbSubLinea = New Selling.StoreCombo
        Me.CmbLinea = New Selling.StoreCombo
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpLinea.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.CmbFechaFin)
        Me.GroupBox1.Controls.Add(Me.cmbFechaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(436, 44)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(195, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "AL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "DEL"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(375, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(166, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbFechaFin
        '
        Me.CmbFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.Location = New System.Drawing.Point(242, 15)
        Me.CmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaFin.Name = "CmbFechaFin"
        Me.CmbFechaFin.Size = New System.Drawing.Size(119, 20)
        Me.CmbFechaFin.TabIndex = 69
        Me.CmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(46, 15)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(125, 20)
        Me.cmbFechaInicio.TabIndex = 68
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(249, 252)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(2, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Almacén"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(427, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkTodos
        '
        Me.ChkTodos.Checked = True
        Me.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodos.Location = New System.Drawing.Point(8, 134)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(174, 20)
        Me.ChkTodos.TabIndex = 80
        Me.ChkTodos.Text = "Todos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaProd)
        Me.GroupBox2.Controls.Add(Me.TxtClaveProd)
        Me.GroupBox2.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(2, 155)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(438, 44)
        Me.GroupBox2.TabIndex = 73
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(38, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 73
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(412, 17)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaProd.TabIndex = 84
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(4, 18)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(113, 21)
        Me.TxtClaveProd.TabIndex = 83
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(121, 18)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(288, 19)
        Me.TxtDescripcion.TabIndex = 85
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlmacen.Location = New System.Drawing.Point(48, 8)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(375, 21)
        Me.CmbAlmacen.TabIndex = 38
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(345, 252)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 84
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkToda
        '
        Me.ChkToda.Checked = True
        Me.ChkToda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkToda.Location = New System.Drawing.Point(6, 34)
        Me.ChkToda.Name = "ChkToda"
        Me.ChkToda.Size = New System.Drawing.Size(142, 22)
        Me.ChkToda.TabIndex = 86
        Me.ChkToda.Text = "Todas las lineas"
        '
        'GrpLinea
        '
        Me.GrpLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpLinea.Controls.Add(Me.PictureBox5)
        Me.GrpLinea.Controls.Add(Me.ChkSublinea)
        Me.GrpLinea.Controls.Add(Me.ChkLinea)
        Me.GrpLinea.Controls.Add(Me.CmbSubLinea)
        Me.GrpLinea.Controls.Add(Me.CmbLinea)
        Me.GrpLinea.Controls.Add(Me.PictureBox6)
        Me.GrpLinea.Enabled = False
        Me.GrpLinea.Location = New System.Drawing.Point(2, 55)
        Me.GrpLinea.Name = "GrpLinea"
        Me.GrpLinea.Size = New System.Drawing.Size(438, 75)
        Me.GrpLinea.TabIndex = 85
        Me.GrpLinea.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(421, 20)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 73
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'ChkSublinea
        '
        Me.ChkSublinea.Location = New System.Drawing.Point(10, 48)
        Me.ChkSublinea.Name = "ChkSublinea"
        Me.ChkSublinea.Size = New System.Drawing.Size(67, 23)
        Me.ChkSublinea.TabIndex = 74
        Me.ChkSublinea.Text = "Sublinea"
        '
        'ChkLinea
        '
        Me.ChkLinea.Location = New System.Drawing.Point(10, 20)
        Me.ChkLinea.Name = "ChkLinea"
        Me.ChkLinea.Size = New System.Drawing.Size(57, 23)
        Me.ChkLinea.TabIndex = 73
        Me.ChkLinea.Text = "Linea"
        '
        'CmbSubLinea
        '
        Me.CmbSubLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSubLinea.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSubLinea.Location = New System.Drawing.Point(82, 48)
        Me.CmbSubLinea.Name = "CmbSubLinea"
        Me.CmbSubLinea.Size = New System.Drawing.Size(334, 21)
        Me.CmbSubLinea.TabIndex = 72
        '
        'CmbLinea
        '
        Me.CmbLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbLinea.BackColor = System.Drawing.SystemColors.Window
        Me.CmbLinea.Location = New System.Drawing.Point(82, 19)
        Me.CmbLinea.Name = "CmbLinea"
        Me.CmbLinea.Size = New System.Drawing.Size(334, 21)
        Me.CmbLinea.TabIndex = 71
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(421, 52)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(14, 16)
        Me.PictureBox6.TabIndex = 68
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'MeFiltroMov
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(441, 291)
        Me.Controls.Add(Me.ChkToda)
        Me.Controls.Add(Me.GrpLinea)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbAlmacen)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(457, 330)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(457, 227)
        Me.Name = "MeFiltroMov"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpLinea.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltroMov_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Not Me.ChkTodos.Checked AndAlso PROClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()

        End If

        If Me.CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkLinea.Checked AndAlso Me.CmbLinea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkSublinea.Checked AndAlso Me.CmbSubLinea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbFechaInicio.Value > CmbFechaFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub



    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox1
        alerta(3) = Me.PictureBox2
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        With Me.CmbLinea
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_linea"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
            LineaCargada = True
        End With

        Me.Text = Titulo

        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today
    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper.Replace("'", "''"))
            End If
        End If
    End Sub

    Private Sub TxtClaveProv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClaveProd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtClaveProd.Text = a.valor
            recuperaProducto(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.Checked Then
            PROClave = ""
            Me.GroupBox2.Enabled = False
            TxtClaveProd.Text = ""
            TxtDescripcion.Text = ""
        Else
            Me.GroupBox2.Enabled = True
            TxtClaveProd.Text = ""
            TxtDescripcion.Text = ""
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If validaForm() Then
            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            Almacen = CmbAlmacen.SelectedValue

            If ChkTodos.Checked Then
                Todos = 1
                PROClave = ""
            Else
                Todos = 0
            End If


            If ChkToda.Checked Then
                Linea = ""
                Sublinea = ""
            Else
                If ChkLinea.Checked Then
                    Linea = CStr(CmbLinea.SelectedValue)
                Else
                    Linea = ""
                End If

                If ChkSublinea.Checked Then
                    Sublinea = CStr(CmbSubLinea.SelectedValue)
                Else
                    Sublinea = ""
                End If
            End If


            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If

    End Sub

    Private Sub CmbLinea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLinea.SelectedIndexChanged
        If Not CmbLinea.SelectedValue Is Nothing AndAlso LineaCargada Then
            With Me.CmbSubLinea
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_sublinea"
                .NombreParametro1 = "CLAClavePadre"
                .Parametro1 = CmbLinea.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub ChkToda_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkToda.CheckedChanged
        If ChkToda.Checked Then
            GrpLinea.Enabled = False
            ChkLinea.Checked = False
            ChkSublinea.Checked = False
        Else
            GrpLinea.Enabled = True
            ChkLinea.Checked = True
            ChkSublinea.Checked = True
        End If
    End Sub
End Class
