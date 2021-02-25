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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblMsg2 As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblMsg1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMeMsg))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblMsg2 = New System.Windows.Forms.Label
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.LblMsg1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Name = "Label1"
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
        'FrmMeMsg
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LblMsg1)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.LblMsg2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
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
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub



   
    Private Sub FrmMeMsg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Close()
        End If
    End Sub

End Class


