Public Class MeFiltroExist
    Inherits System.Windows.Forms.Form

    Private Almacen As String
    Private Linea As String
    Private Sublinea As String
    Public Titulo As String
    Private PROClave, Lista As String
    Private Todos As Integer
    Private Agotados As Integer
    Private Existencia As Integer
    Private bError As Boolean = False
    Private LineaCargada As Boolean

    Public bLista As Boolean = False

    Private alerta(4) As PictureBox

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkAgotados As System.Windows.Forms.CheckBox
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkToda As System.Windows.Forms.CheckBox
    Friend WithEvents GrpLinea As System.Windows.Forms.GroupBox
    Friend WithEvents ChkSublinea As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLinea As System.Windows.Forms.CheckBox
    Friend WithEvents CmbSubLinea As Selling.StoreCombo
    Friend WithEvents CmbLinea As Selling.StoreCombo
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkExistencia As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbListaPrecio As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label

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


    Public ReadOnly Property MostrarAgotados() As Integer
        Get
            MostrarAgotados = Agotados
        End Get
    End Property

    Public ReadOnly Property MostrarSoloConExistencia() As Integer
        Get
            MostrarSoloConExistencia = Existencia
        End Get
    End Property


    Public ReadOnly Property PREClave() As Integer
        Get
            PREClave = Lista
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
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroExist))
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.ChkAgotados = New System.Windows.Forms.CheckBox
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.ChkToda = New System.Windows.Forms.CheckBox
        Me.GrpLinea = New System.Windows.Forms.GroupBox
        Me.ChkSublinea = New System.Windows.Forms.CheckBox
        Me.ChkLinea = New System.Windows.Forms.CheckBox
        Me.CmbSubLinea = New Selling.StoreCombo
        Me.CmbLinea = New Selling.StoreCombo
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ChkExistencia = New System.Windows.Forms.CheckBox
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.CmbListaPrecio = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpLinea.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(251, 301)
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
        Me.Label3.Location = New System.Drawing.Point(2, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Almacén"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(428, 13)
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
        Me.ChkTodos.Location = New System.Drawing.Point(2, 149)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(112, 19)
        Me.ChkTodos.TabIndex = 80
        Me.ChkTodos.Text = "Todos los productos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaProd)
        Me.GroupBox2.Controls.Add(Me.TxtClaveProd)
        Me.GroupBox2.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox2.Controls.Add(Me.PictureBox4)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(2, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 45)
        Me.GroupBox2.TabIndex = 73
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(413, 17)
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
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(101, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(420, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 73
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'ChkAgotados
        '
        Me.ChkAgotados.Location = New System.Drawing.Point(3, 229)
        Me.ChkAgotados.Name = "ChkAgotados"
        Me.ChkAgotados.Size = New System.Drawing.Size(164, 20)
        Me.ChkAgotados.TabIndex = 81
        Me.ChkAgotados.Text = "Solo existencias agotadas"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(347, 301)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 82
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkToda
        '
        Me.ChkToda.Checked = True
        Me.ChkToda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkToda.Location = New System.Drawing.Point(7, 40)
        Me.ChkToda.Name = "ChkToda"
        Me.ChkToda.Size = New System.Drawing.Size(142, 22)
        Me.ChkToda.TabIndex = 84
        Me.ChkToda.Text = "Todas las lineas"
        '
        'GrpLinea
        '
        Me.GrpLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpLinea.Controls.Add(Me.PictureBox2)
        Me.GrpLinea.Controls.Add(Me.ChkSublinea)
        Me.GrpLinea.Controls.Add(Me.ChkLinea)
        Me.GrpLinea.Controls.Add(Me.CmbSubLinea)
        Me.GrpLinea.Controls.Add(Me.CmbLinea)
        Me.GrpLinea.Controls.Add(Me.PictureBox3)
        Me.GrpLinea.Enabled = False
        Me.GrpLinea.Location = New System.Drawing.Point(2, 64)
        Me.GrpLinea.Name = "GrpLinea"
        Me.GrpLinea.Size = New System.Drawing.Size(438, 74)
        Me.GrpLinea.TabIndex = 83
        Me.GrpLinea.TabStop = False
        '
        'ChkSublinea
        '
        Me.ChkSublinea.Location = New System.Drawing.Point(10, 48)
        Me.ChkSublinea.Name = "ChkSublinea"
        Me.ChkSublinea.Size = New System.Drawing.Size(73, 23)
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
        Me.CmbSubLinea.Location = New System.Drawing.Point(80, 48)
        Me.CmbSubLinea.Name = "CmbSubLinea"
        Me.CmbSubLinea.Size = New System.Drawing.Size(335, 21)
        Me.CmbSubLinea.TabIndex = 72
        '
        'CmbLinea
        '
        Me.CmbLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbLinea.BackColor = System.Drawing.SystemColors.Window
        Me.CmbLinea.Location = New System.Drawing.Point(80, 19)
        Me.CmbLinea.Name = "CmbLinea"
        Me.CmbLinea.Size = New System.Drawing.Size(335, 21)
        Me.CmbLinea.TabIndex = 71
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(420, 52)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 16)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'ChkExistencia
        '
        Me.ChkExistencia.Location = New System.Drawing.Point(3, 250)
        Me.ChkExistencia.Name = "ChkExistencia"
        Me.ChkExistencia.Size = New System.Drawing.Size(226, 19)
        Me.ChkExistencia.TabIndex = 85
        Me.ChkExistencia.Text = "Solo con existencias diferentes de cero"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlmacen.Location = New System.Drawing.Point(48, 11)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(376, 21)
        Me.CmbAlmacen.TabIndex = 38
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(363, 278)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 88
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'CmbListaPrecio
        '
        Me.CmbListaPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbListaPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.CmbListaPrecio.Location = New System.Drawing.Point(68, 275)
        Me.CmbListaPrecio.Name = "CmbListaPrecio"
        Me.CmbListaPrecio.Size = New System.Drawing.Size(276, 21)
        Me.CmbListaPrecio.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(4, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Lista"
        '
        'MeFiltroExist
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(442, 343)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.CmbListaPrecio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkExistencia)
        Me.Controls.Add(Me.ChkToda)
        Me.Controls.Add(Me.GrpLinea)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.ChkAgotados)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbAlmacen)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(458, 382)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(458, 305)
        Me.Name = "MeFiltroExist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpLinea.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltroExist_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

       
        If Me.CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If



        If ChkLinea.Checked AndAlso Me.CmbLinea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkSublinea.Checked AndAlso Me.CmbSubLinea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Not Me.ChkTodos.Checked AndAlso PROClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()

        End If


        If bLista = True AndAlso Me.CmbListaPrecio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
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

        If bLista = True Then
            Me.Width = 550
            Me.Height = 411

            With Me.CmbListaPrecio
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_lista"
                .NombreParametro1 = "COMClave"
                .Parametro1 = ModPOS.CompanyActual
                .llenar()
            End With

        End If

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        alerta(2) = Me.PictureBox2
        alerta(3) = Me.PictureBox3
        alerta(4) = Me.PictureBox5

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
            Almacen = CmbAlmacen.SelectedValue

            If ChkTodos.Checked Then
                Todos = 1
                PROClave = ""
            Else
                Todos = 0
            End If

            If ChkAgotados.Checked Then
                Agotados = 1
            Else
                Agotados = 0
            End If

            If ChkExistencia.Checked Then
                Existencia = 1
            Else
                Existencia = 0
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

            If bLista = True Then
                Lista = CmbListaPrecio.SelectedValue
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
