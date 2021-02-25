
Public Class FrmConfirmaDatos
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
    Friend WithEvents BtnContinuar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfirmaDatos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNota = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.BtnContinuar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'LblNota
        '
        resources.ApplyResources(Me.LblNota, "LblNota")
        Me.LblNota.Name = "LblNota"
        '
        'txtTelefono
        '
        resources.ApplyResources(Me.txtTelefono, "txtTelefono")
        Me.txtTelefono.Name = "txtTelefono"
        '
        'BtnContinuar
        '
        resources.ApplyResources(Me.BtnContinuar, "BtnContinuar")
        Me.BtnContinuar.Name = "BtnContinuar"
        Me.BtnContinuar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue
        Me.BtnContinuar.Office2007CustomColor = System.Drawing.Color.Red
        Me.BtnContinuar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtCorreo
        '
        resources.ApplyResources(Me.txtCorreo, "txtCorreo")
        Me.txtCorreo.Name = "txtCorreo"
        '
        'FrmConfirmaDatos
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblNota)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.BtnContinuar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmConfirmaDatos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private bError As Boolean = False

    Public CTEClave As String
    Public Telefono As String
    Public Correo As String

    Private oskID As Integer = -1

    Private Sub FrmObtieneAfiliado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmObtieneAfiliado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub BtnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinuar.Click
        Correo = txtCorreo.Text
        Telefono = txtTelefono.Text
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If oskID <> -1 Then
            Try
                Process.GetProcessesByName("osk")(0).Kill()
            Catch ex As Exception
            End Try
            oskID = -1
        End If
    End Sub

    Private Sub txtTelefono_Click(sender As Object, e As EventArgs) Handles txtTelefono.Click
        Dim a As New FrmTecladoNum
        a.Text = "Télefono"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtTelefono.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Ctrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnContinuar.KeyUp, txtCorreo.KeyUp, txtTelefono.KeyUp
        If e.KeyCode = Keys.Enter Then
            bError = False
            If oskID <> -1 Then
                Try
                    Process.GetProcessesByName("osk")(0).Kill()
                Catch ex As Exception

                End Try

                oskID = -1
            End If
        End If
    End Sub

    Private Sub Ctrl_Click(sender As Object, e As EventArgs) Handles txtCorreo.Click
        If oskID = -1 Then
            oskID = Process.Start("osk.exe").Id
        End If
    End Sub

   
End Class


