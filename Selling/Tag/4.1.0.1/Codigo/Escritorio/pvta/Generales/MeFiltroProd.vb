Public Class MeFiltroProd
    Inherits System.Windows.Forms.Form

    Private FechaIni As String
    Private FechaFin As String
    Private AlmSuc As String
    Private Prod As String
    Private UOrigen As String
    Private UDestino As String
    Public Titulo As String
    Private PROClave As String
    Private bError As Boolean = False
    Private txtLabel As String
    Private sp As String

    ' Public Reporte As String

    Private alerta(1) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox

    Private reloj As parpadea


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

    Public ReadOnly Property Producto() As String
        Get
            Producto = Prod
        End Get
    End Property
    Public WriteOnly Property textolbl() As String
        Set(ByVal Value As String)
            txtLabel = Value
        End Set
    End Property

    Public WriteOnly Property StoreProcedure() As String
        Set(ByVal Value As String)
            sp = Value
        End Set
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
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroProd))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.TxtClaveProd = New System.Windows.Forms.TextBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.CmbFechaFin)
        Me.GroupBox1.Controls.Add(Me.cmbFechaInicio)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Name = "Label1"
        '
        'PictureBox4
        '
        resources.ApplyResources(Me.PictureBox4, "PictureBox4")
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'CmbFechaFin
        '
        resources.ApplyResources(Me.CmbFechaFin, "CmbFechaFin")
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaFin.Name = "CmbFechaFin"
        Me.CmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbFechaInicio
        '
        resources.ApplyResources(Me.cmbFechaInicio, "cmbFechaInicio")
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.BtnBuscaProd)
        Me.GroupBox3.Controls.Add(Me.TxtClaveProd)
        Me.GroupBox3.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'BtnBuscaProd
        '
        resources.ApplyResources(Me.BtnBuscaProd, "BtnBuscaProd")
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClaveProd
        '
        resources.ApplyResources(Me.TxtClaveProd, "TxtClaveProd")
        Me.TxtClaveProd.Name = "TxtClaveProd"
        '
        'TxtDescripcion
        '
        resources.ApplyResources(Me.TxtDescripcion, "TxtDescripcion")
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        '
        'BtnOK
        '
        resources.ApplyResources(Me.BtnOK, "BtnOK")
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'MeFiltroProd
        '
        Me.AcceptButton = Me.BtnOK
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MeFiltroProd"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltroAlm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

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

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            Prod = TxtClaveProd.Text
            bError = False
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4

        Me.Text = Titulo

        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today

        Me.GroupBox3.Enabled = True

    End Sub

    Private Sub BtnBuscaProd_Click(sender As Object, e As EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
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

    Private Sub TxtClaveProv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClaveProd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper.Replace("'", "''"))
            End If
        End If
    End Sub

End Class
