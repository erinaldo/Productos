
Public Class FrmSolicitaNIP
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
    Friend WithEvents BtnIngresar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents PictIcono2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtNIP As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaNIP))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNota = New System.Windows.Forms.Label()
        Me.txtNIP = New System.Windows.Forms.TextBox()
        Me.BtnIngresar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.PictIcono2 = New System.Windows.Forms.PictureBox()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        CType(Me.PictIcono2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'LblNota
        '
        resources.ApplyResources(Me.LblNota, "LblNota")
        Me.LblNota.Name = "LblNota"
        '
        'txtNIP
        '
        resources.ApplyResources(Me.txtNIP, "txtNIP")
        Me.txtNIP.Name = "txtNIP"
        '
        'BtnIngresar
        '
        resources.ApplyResources(Me.BtnIngresar, "BtnIngresar")
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue
        Me.BtnIngresar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Red
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'lblMensaje
        '
        resources.ApplyResources(Me.lblMensaje, "lblMensaje")
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Name = "lblMensaje"
        '
        'PictIcono2
        '
        resources.ApplyResources(Me.PictIcono2, "PictIcono2")
        Me.PictIcono2.BackColor = System.Drawing.Color.Transparent
        Me.PictIcono2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono2.Name = "PictIcono2"
        Me.PictIcono2.TabStop = False
        '
        'btnSalir
        '
        resources.ApplyResources(Me.btnSalir, "btnSalir")
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnSalir.Office2007CustomColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmSolicitaNIP
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.PictIcono2)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblNota)
        Me.Controls.Add(Me.txtNIP)
        Me.Controls.Add(Me.BtnIngresar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaNIP"
        CType(Me.PictIcono2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private bError As Boolean = False
    Private Contador As Integer = 0

    Public Imagen As Image
    Public Acceso As Boolean = False
    Public CTEClave As String
    Private NIP As String

    Private Sub FrmSolicitaNIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Imagen Is Nothing Then
            PictIcono2.Image = Imagen
        End If

        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_pass_cte", "@CTEClave", CTEClave, "@Pass", "Duxst4r.")
        NIP = formateaNIP(dt.Rows(0)("Password"))
        dt.Dispose()


        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmSolicitaNIP_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub BtnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresar.Click
        If txtNIP.Text <> "" Then


            If txtNIP.Text.Trim = NIP Then
                lblMensaje.Text = ""
                Acceso = True
                bError = False
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                Contador += 1
                If Contador = 3 Then
                    Acceso = False
                    bError = False
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    lblMensaje.Text = "NIP incorrecto"
                    txtNIP.Text = ""
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
            End If
        Else

            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            TxtNIP_Click(Me, New KeyEventArgs(Keys.Space))
        End If
    End Sub

    Private Sub TxtNIP_Click(sender As Object, e As EventArgs) Handles txtNIP.Click

        Dim a As New FrmTecladoNum
        a.PasswordChar = True
        a.OcultarSignos = True
        a.Text = "NIP"
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtNIP.Text = CStr(a.Cantidad)
            BtnIngresar.PerformClick()
        End If
    End Sub

    Private Sub txtNIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIP.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BtnIngresar.PerformClick()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Acceso = False
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
    End Sub
End Class


