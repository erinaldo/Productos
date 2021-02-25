
Public Class FrmSolicitaUsuario
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblAtiende As System.Windows.Forms.Label
    Friend WithEvents LblInfo As System.Windows.Forms.Label
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaUsuario))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblAtiende = New System.Windows.Forms.Label
        Me.LblInfo = New System.Windows.Forms.Label
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'TxtClave
        '
        resources.ApplyResources(Me.TxtClave, "TxtClave")
        Me.TxtClave.Name = "TxtClave"
        '
        'LblAtiende
        '
        Me.LblAtiende.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LblAtiende, "LblAtiende")
        Me.LblAtiende.ForeColor = System.Drawing.Color.White
        Me.LblAtiende.Name = "LblAtiende"
        '
        'LblInfo
        '
        resources.ApplyResources(Me.LblInfo, "LblInfo")
        Me.LblInfo.Name = "LblInfo"
        '
        'picKeyboard
        '
        resources.ApplyResources(Me.picKeyboard, "picKeyboard")
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.TabStop = False
        '
        'FrmSolicitaUsuario
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.LblInfo)
        Me.Controls.Add(Me.LblAtiende)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaUsuario"
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Cnx As System.Data.SqlClient.SqlConnection
    Private da As System.Data.SqlClient.SqlDataAdapter

    Private ds As DataTable
    Private bError As Boolean = False

    Public bTouch As Boolean = False

    Public AtiendeClave As String = ""
    Public AtiendeNombre As String = ""

    Private Sub FrmSolicitaUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub FrmSolicitaUsuario_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtClave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtClave.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Clave Usuario"
            a.TxtCantidad.Text = TxtClave.Text
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtClave.Text = a.Cantidad
                If TxtClave.Text <> "" Then
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", TxtClave.Text.Trim.ToUpper.Replace("'", "''"))
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        AtiendeClave = dt.Rows(0)("USRClave")
                        AtiendeNombre = dt.Rows(0)("Nombre")
                        dt.Dispose()
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        bError = False
                    Else
                        LblInfo.Text = "Información: ¡Clave de Usuario No Existe!"
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    LblInfo.Text = "Información: ¡Clave de Usuario No Valida!"
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
            End If
        End If
    End Sub

    Private Sub TxtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                bError = False
                Me.Close()
            Case Is = Keys.Enter
                If TxtClave.Text <> "" Then
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", TxtClave.Text.Trim.ToUpper.Replace("'", "''"))
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        AtiendeClave = dt.Rows(0)("USRClave")
                        AtiendeNombre = dt.Rows(0)("Nombre")
                        dt.Dispose()
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        bError = False
                    Else
                        LblInfo.Text = "Información: ¡Clave de Usuario No Existe!"
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    LblInfo.Text = "Información: ¡Clave de Usuario No Valida!"
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
        End Select
    End Sub


    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        Process.Start("osk.exe")
    End Sub
End Class


