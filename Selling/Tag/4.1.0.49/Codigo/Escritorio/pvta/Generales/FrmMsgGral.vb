Public Class FrmMsgGral
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnOk2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblPie As System.Windows.Forms.Label
    Friend WithEvents btnOK As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMsgGral))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.btnOK = New Janus.Windows.EditControls.UIButton()
        Me.btnOk2 = New Janus.Windows.EditControls.UIButton()
        Me.lblPie = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'LblMsg
        '
        resources.ApplyResources(Me.LblMsg, "LblMsg")
        Me.LblMsg.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg.Name = "LblMsg"
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.LblTitulo, "LblTitulo")
        Me.LblTitulo.ForeColor = System.Drawing.Color.Navy
        Me.LblTitulo.Name = "LblTitulo"
        '
        'btnOK
        '
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnOK.Office2007CustomColor = System.Drawing.Color.LimeGreen
        Me.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnOk2
        '
        Me.btnOk2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk2.DialogResult = System.Windows.Forms.DialogResult.OK
        resources.ApplyResources(Me.btnOk2, "btnOk2")
        Me.btnOk2.Name = "btnOk2"
        Me.btnOk2.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnOk2.Office2007CustomColor = System.Drawing.Color.LightSkyBlue
        Me.btnOk2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblPie
        '
        Me.lblPie.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.lblPie, "lblPie")
        Me.lblPie.ForeColor = System.Drawing.Color.Navy
        Me.lblPie.Name = "lblPie"
        '
        'FrmMsgGral
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnOk2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMsgGral"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Titulo As String
    Private Msg As String
    Public Dividir As Boolean = False

    Public WriteOnly Property TxtTiulo() As String
        Set(ByVal Value As String)
            Titulo = Value
        End Set
    End Property

    Public WriteOnly Property TxtMsg() As String
        Set(ByVal Value As String)
            Msg = Value
        End Set
    End Property

   

    Private Sub FrmMeMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LblTitulo.Text = Titulo

        'LblMsg.Text = Msg
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub




    Private Sub FrmMeMsg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dividir = True
        Me.Close()
    End Sub

    
    Private Sub btnOk2_Click(sender As Object, e As EventArgs) Handles btnOk2.Click
        Dividir = False
        Me.Close()
    End Sub
End Class


