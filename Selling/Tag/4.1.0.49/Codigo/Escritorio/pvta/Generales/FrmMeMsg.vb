Public Class FrmMeMsg
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
    Friend WithEvents lblPie As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblMsg2 As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblMsg1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMeMsg))
        Me.lblPie = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblMsg2 = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblMsg1 = New System.Windows.Forms.Label()
        Me.btnOK = New Janus.Windows.EditControls.UIButton()
        Me.SuspendLayout()
        '
        'lblPie
        '
        Me.lblPie.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.lblPie, "lblPie")
        Me.lblPie.ForeColor = System.Drawing.Color.Navy
        Me.lblPie.Name = "lblPie"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'LblMsg2
        '
        resources.ApplyResources(Me.LblMsg2, "LblMsg2")
        Me.LblMsg2.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg2.Name = "LblMsg2"
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.LblTitulo, "LblTitulo")
        Me.LblTitulo.ForeColor = System.Drawing.Color.Navy
        Me.LblTitulo.Name = "LblTitulo"
        '
        'LblMsg1
        '
        Me.LblMsg1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LblMsg1, "LblMsg1")
        Me.LblMsg1.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg1.Name = "LblMsg1"
        '
        'btnOK
        '
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Icon = CType(resources.GetObject("btnOK.Icon"), System.Drawing.Icon)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnOK.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMeMsg
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.LblMsg1)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.LblMsg2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMeMsg"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Titulo As String
    Private Msg As String
    Private Msg2 As String

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

    Public WriteOnly Property TxtMsg2() As String
        Set(ByVal Value As String)
            Msg2 = Value
        End Set
    End Property

    Private Sub FrmMeMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblTitulo.Text = Titulo
        LblMsg1.Text = Msg
        LblMsg2.Text = Msg2
       
    End Sub



   
    Private Sub FrmMeMsg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class


