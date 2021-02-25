Public Class FrmFiltroNC
    Inherits System.Windows.Forms.Form

    Public Tipo As Integer = 1

    Friend WithEvents rdSin As System.Windows.Forms.RadioButton
    Friend WithEvents rdBon As System.Windows.Forms.RadioButton
    Friend WithEvents rdNC As System.Windows.Forms.RadioButton

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiltroNC))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdBon = New System.Windows.Forms.RadioButton()
        Me.rdSin = New System.Windows.Forms.RadioButton()
        Me.rdNC = New System.Windows.Forms.RadioButton()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdBon)
        Me.GroupBox1.Controls.Add(Me.rdSin)
        Me.GroupBox1.Controls.Add(Me.rdNC)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 91)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo "
        '
        'rdBon
        '
        Me.rdBon.AutoSize = True
        Me.rdBon.Location = New System.Drawing.Point(94, 64)
        Me.rdBon.Name = "rdBon"
        Me.rdBon.Size = New System.Drawing.Size(83, 17)
        Me.rdBon.TabIndex = 2
        Me.rdBon.Text = "Bonificación"
        Me.rdBon.UseVisualStyleBackColor = True
        '
        'rdSin
        '
        Me.rdSin.AutoSize = True
        Me.rdSin.Location = New System.Drawing.Point(94, 41)
        Me.rdSin.Name = "rdSin"
        Me.rdSin.Size = New System.Drawing.Size(152, 17)
        Me.rdSin.TabIndex = 1
        Me.rdSin.Text = "Devolución Sin Referencia"
        Me.rdSin.UseVisualStyleBackColor = True
        '
        'rdNC
        '
        Me.rdNC.AutoSize = True
        Me.rdNC.Checked = True
        Me.rdNC.Location = New System.Drawing.Point(94, 19)
        Me.rdNC.Name = "rdNC"
        Me.rdNC.Size = New System.Drawing.Size(79, 17)
        Me.rdNC.TabIndex = 0
        Me.rdNC.TabStop = True
        Me.rdNC.Text = "Devolución"
        Me.rdNC.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(274, 103)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmFiltroNC
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(369, 145)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 157)
        Me.Name = "FrmFiltroNC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Crédito"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmFiltroNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub rdNC_CheckedChanged(sender As Object, e As EventArgs) Handles rdNC.CheckedChanged
        If rdNC.Checked = True Then
            rdSin.Checked = False
            rdBon.Checked = False
            Tipo = 1
        End If
    End Sub

    Private Sub rdSin_CheckedChanged(sender As Object, e As EventArgs) Handles rdSin.CheckedChanged
        If rdSin.Checked = True Then
            rdNC.Checked = False
            rdBon.Checked = False
            Tipo = 2
        End If
    End Sub

    Private Sub rdBon_CheckedChanged(sender As Object, e As EventArgs) Handles rdBon.CheckedChanged
        If rdBon.Checked = True Then
            rdNC.Checked = False
            rdSin.Checked = False
            Tipo = 3
        End If
    End Sub

 
End Class
