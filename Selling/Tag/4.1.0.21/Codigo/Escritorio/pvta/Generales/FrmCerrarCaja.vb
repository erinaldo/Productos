Public Class FrmCerrarCaja
    Inherits System.Windows.Forms.Form

    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtLeyenda As System.Windows.Forms.TextBox
    Friend WithEvents grpPrecorte As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPreCorte As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox

    Public Accion As String = ""
    Public Transferencia As Integer = 0

    Private bPreCorte As Boolean = False
    Private bRetiroCorte As Boolean = False

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCorte As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSinCorte As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCerrarCaja))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.BtnSinCorte = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnCorte = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtLeyenda = New System.Windows.Forms.TextBox()
        Me.grpPrecorte = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.BtnPreCorte = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPrecorte.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.BtnSinCorte)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 59)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox3.Image = Global.Selling.My.Resources.Resources.Spell
        Me.PictureBox3.Location = New System.Drawing.Point(7, 14)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        '
        'BtnSinCorte
        '
        Me.BtnSinCorte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSinCorte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSinCorte.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSinCorte.Location = New System.Drawing.Point(120, 14)
        Me.BtnSinCorte.Name = "BtnSinCorte"
        Me.BtnSinCorte.Size = New System.Drawing.Size(346, 39)
        Me.BtnSinCorte.TabIndex = 4
        Me.BtnSinCorte.Text = "CONTINUAR SIN REALIZAR CORTE"
        Me.BtnSinCorte.ToolTipText = "Continua con el registro actual de apertura de Caja"
        Me.BtnSinCorte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.BtnCorte)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(475, 67)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox2.Image = Global.Selling.My.Resources.Resources.Security
        Me.PictureBox2.Location = New System.Drawing.Point(7, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 67
        Me.PictureBox2.TabStop = False
        '
        'BtnCorte
        '
        Me.BtnCorte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCorte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCorte.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnCorte.Location = New System.Drawing.Point(120, 18)
        Me.BtnCorte.Name = "BtnCorte"
        Me.BtnCorte.Size = New System.Drawing.Size(346, 39)
        Me.BtnCorte.TabIndex = 3
        Me.BtnCorte.Text = "REALIZAR CORTE DE CAJA"
        Me.BtnCorte.ToolTipText = "Cierra el registro actual de apertura de Caja y realiza el Corte"
        Me.BtnCorte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(452, 107)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 66
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtLeyenda
        '
        Me.TxtLeyenda.Enabled = False
        Me.TxtLeyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeyenda.Location = New System.Drawing.Point(2, 11)
        Me.TxtLeyenda.Multiline = True
        Me.TxtLeyenda.Name = "TxtLeyenda"
        Me.TxtLeyenda.Size = New System.Drawing.Size(466, 47)
        Me.TxtLeyenda.TabIndex = 3
        '
        'grpPrecorte
        '
        Me.grpPrecorte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPrecorte.Controls.Add(Me.PictureBox4)
        Me.grpPrecorte.Controls.Add(Me.BtnPreCorte)
        Me.grpPrecorte.Controls.Add(Me.PictureBox5)
        Me.grpPrecorte.Location = New System.Drawing.Point(3, 58)
        Me.grpPrecorte.Name = "grpPrecorte"
        Me.grpPrecorte.Size = New System.Drawing.Size(474, 66)
        Me.grpPrecorte.TabIndex = 4
        Me.grpPrecorte.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox4.Image = Global.Selling.My.Resources.Resources._1323061435_ticket
        Me.PictureBox4.Location = New System.Drawing.Point(7, 18)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 67
        Me.PictureBox4.TabStop = False
        '
        'BtnPreCorte
        '
        Me.BtnPreCorte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPreCorte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPreCorte.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnPreCorte.Location = New System.Drawing.Point(120, 18)
        Me.BtnPreCorte.Name = "BtnPreCorte"
        Me.BtnPreCorte.Size = New System.Drawing.Size(346, 39)
        Me.BtnPreCorte.TabIndex = 3
        Me.BtnPreCorte.Text = "PRE- CORTE DE CAJA"
        Me.BtnPreCorte.ToolTipText = "Realiza el Pre-Corte de Caja"
        Me.BtnPreCorte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(452, 107)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 66
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'FrmCerrarCaja
        '
        Me.AcceptButton = Me.BtnCorte
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnSinCorte
        Me.ClientSize = New System.Drawing.Size(481, 258)
        Me.Controls.Add(Me.grpPrecorte)
        Me.Controls.Add(Me.TxtLeyenda)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(342, 156)
        Me.Name = "FrmCerrarCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apertura y Cierre de Caja"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPrecorte.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnPreCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreCorte.Click
        Accion = "PreCorte"
    End Sub

  
    Private Sub BtnSinCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSinCorte.Click
        Accion = "SinCorte"
    End Sub

    Private Sub BtnCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCorte.Click
        Accion = "Corte"
    End Sub

    Private Sub FrmCerrarCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Transferencia = 1 Then
            TxtLeyenda.Height = 113
            grpPrecorte.Visible = False
        End If

    End Sub
End Class
