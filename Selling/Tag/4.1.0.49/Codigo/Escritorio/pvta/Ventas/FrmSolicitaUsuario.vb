
Public Class FrmSolicitaUsuario
    Inherits System.Windows.Forms.Form
    Implements ITeclado

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
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblAtiende As System.Windows.Forms.Label
    Friend WithEvents LblInfo As System.Windows.Forms.Label
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents txtQR As System.Windows.Forms.TextBox
    Friend WithEvents lblPicking As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaUsuario))
        Me.lblNota = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblAtiende = New System.Windows.Forms.Label()
        Me.LblInfo = New System.Windows.Forms.Label()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.txtQR = New System.Windows.Forms.TextBox()
        Me.lblPicking = New System.Windows.Forms.Label()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNota
        '
        Me.lblNota.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.lblNota, "lblNota")
        Me.lblNota.ForeColor = System.Drawing.Color.White
        Me.lblNota.Name = "lblNota"
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
        'txtQR
        '
        resources.ApplyResources(Me.txtQR, "txtQR")
        Me.txtQR.Name = "txtQR"
        '
        'lblPicking
        '
        resources.ApplyResources(Me.lblPicking, "lblPicking")
        Me.lblPicking.Name = "lblPicking"
        '
        'FrmSolicitaUsuario
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtQR)
        Me.Controls.Add(Me.lblPicking)
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.LblInfo)
        Me.Controls.Add(Me.LblAtiende)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNota)
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
    Public ReferenciaUsr As String = ""

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


    Private Sub validaUsuario()
        If TxtClave.Text <> "" Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", TxtClave.Text.Trim.ToUpper.Replace("'", "''"))
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                AtiendeClave = dt.Rows(0)("USRClave")
                ReferenciaUsr = dt.Rows(0)("Referencia")
                AtiendeNombre = dt.Rows(0)("Nombre")
                dt.Dispose()

                If txtQR.Visible = True Then
                    SendKeys.Send("{TAB}")
                    LblInfo.Text = AtiendeNombre
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    bError = False
                End If


            Else
                TxtClave.Text = ""
                LblInfo.Text = "Información: ¡Clave de Usuario No Existe!"
                bError = True
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End If
        Else
            TxtClave.Text = ""
            LblInfo.Text = "Información: ¡Clave de Usuario No Valida!"
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
                validaUsuario()
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
                validaUsuario()
        End Select
    End Sub


    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        If AbrirTeclado(Me) Then
            validaUsuario()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            bError = False
            Me.Close()
        End If
    End Sub

    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar
        If dato = "DESHACER" OrElse dato = "" And TxtClave.TextLength > 0 Then
            TxtClave.Text = TxtClave.Text.Remove(TxtClave.TextLength - 1, 1)
        Else
            TxtClave.Text &= dato
        End If
    End Sub

    
    Private Sub txtQR_KeyUp(sender As Object, e As KeyEventArgs) Handles txtQR.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                bError = False
                Me.Close()
            Case Is = Keys.Enter
                If AtiendeClave <> "" Then
                    Dim sChar As String = "&"

                    If txtQR.Text.Split(sChar).Length = 1 Then
                        If txtQR.Text.Split("\").Length = 2 Then
                            sChar = "\"
                        ElseIf txtQR.Text.Split("/").Length = 2 Then
                            sChar = "/"
                        End If
                    End If

                    If txtQR.Text <> "" AndAlso txtQR.Text.Split(sChar).Length = 2 Then
                        Dim dt As DataTable
                        Dim DOCClave As String = txtQR.Text.Split(sChar)(1)
                        Dim AREClave As String = txtQR.Text.Split(sChar)(0)

                        dt = ModPOS.Recupera_Tabla("st_valida_recolector", "@AREClave", AREClave, "@DOCClave", DOCClave)
                        If dt.Rows.Count > 0 Then

                            ModPOS.Ejecuta("st_inicia_surtido", "@AREClave", AREClave, "@DOCClave", DOCClave, "@USRClave", AtiendeClave)
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            bError = False
                            Me.Close()

                        Else
                            txtQR.Text = ""
                            LblInfo.Text = "El documento ya se encuentra siendo surtido"
                            bError = True
                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        End If
                        dt.Dispose()
                    Else
                        txtQR.Text = ""
                        LblInfo.Text = "Información: ¡Código QR No Valido!"
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    TxtClave.Text = ""
                    TxtClave.Focus()
                    LblInfo.Text = "Información: ¡Clave de usuario requerida!"
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
        End Select
    End Sub
End Class


