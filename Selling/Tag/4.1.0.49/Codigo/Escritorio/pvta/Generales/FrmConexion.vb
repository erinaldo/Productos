Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Sdk.Sfc
Imports Microsoft.SqlServer.Management.Common

Public Class FrmConexion
    Inherits System.Windows.Forms.Form

    Public BDServidor As String = ""
    Public BDCatalogo As String = ""
    Public BDUsuario As String = ""
    Public BDContraseña As String = ""


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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpConexion As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents cbDB As System.Windows.Forms.ComboBox
    Friend WithEvents lblDB As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents cbOrigenDB As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrigenDB As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConexion))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.GrpConexion = New System.Windows.Forms.GroupBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.cbDB = New System.Windows.Forms.ComboBox
        Me.lblDB = New System.Windows.Forms.Label
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.cbOrigenDB = New System.Windows.Forms.ComboBox
        Me.lblOrigenDB = New System.Windows.Forms.Label
        Me.GrpConexion.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(203, 143)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(300, 143)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 4
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpConexion
        '
        Me.GrpConexion.Controls.Add(Me.PictureBox9)
        Me.GrpConexion.Controls.Add(Me.BtnCancelar)
        Me.GrpConexion.Controls.Add(Me.PictureBox8)
        Me.GrpConexion.Controls.Add(Me.BtnOk)
        Me.GrpConexion.Controls.Add(Me.PictureBox7)
        Me.GrpConexion.Controls.Add(Me.PictureBox6)
        Me.GrpConexion.Controls.Add(Me.cbDB)
        Me.GrpConexion.Controls.Add(Me.lblDB)
        Me.GrpConexion.Controls.Add(Me.txtPass)
        Me.GrpConexion.Controls.Add(Me.txtUser)
        Me.GrpConexion.Controls.Add(Me.lblPass)
        Me.GrpConexion.Controls.Add(Me.lblUserName)
        Me.GrpConexion.Controls.Add(Me.cbOrigenDB)
        Me.GrpConexion.Controls.Add(Me.lblOrigenDB)
        Me.GrpConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpConexion.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpConexion.Location = New System.Drawing.Point(0, 0)
        Me.GrpConexion.Name = "GrpConexion"
        Me.GrpConexion.Size = New System.Drawing.Size(397, 186)
        Me.GrpConexion.TabIndex = 4
        Me.GrpConexion.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(348, 114)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox9.TabIndex = 41
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(348, 71)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox8.TabIndex = 40
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(185, 67)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox7.TabIndex = 39
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(348, 24)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox6.TabIndex = 38
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'cbDB
        '
        Me.cbDB.Location = New System.Drawing.Point(99, 111)
        Me.cbDB.Name = "cbDB"
        Me.cbDB.Size = New System.Drawing.Size(243, 21)
        Me.cbDB.TabIndex = 4
        '
        'lblDB
        '
        Me.lblDB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDB.Location = New System.Drawing.Point(6, 117)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(87, 15)
        Me.lblDB.TabIndex = 17
        Me.lblDB.Text = "Base de Datos"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(244, 69)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(98, 20)
        Me.txtPass.TabIndex = 3
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(99, 69)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(80, 20)
        Me.txtUser.TabIndex = 2
        '
        'lblPass
        '
        Me.lblPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPass.Location = New System.Drawing.Point(179, 74)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(72, 15)
        Me.lblPass.TabIndex = 14
        Me.lblPass.Text = "Contraseña"
        '
        'lblUserName
        '
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUserName.Location = New System.Drawing.Point(7, 74)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(86, 15)
        Me.lblUserName.TabIndex = 13
        Me.lblUserName.Text = "Usuario"
        '
        'cbOrigenDB
        '
        Me.cbOrigenDB.Location = New System.Drawing.Point(99, 24)
        Me.cbOrigenDB.Name = "cbOrigenDB"
        Me.cbOrigenDB.Size = New System.Drawing.Size(243, 21)
        Me.cbOrigenDB.TabIndex = 1
        '
        'lblOrigenDB
        '
        Me.lblOrigenDB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOrigenDB.Location = New System.Drawing.Point(7, 30)
        Me.lblOrigenDB.Name = "lblOrigenDB"
        Me.lblOrigenDB.Size = New System.Drawing.Size(46, 15)
        Me.lblOrigenDB.TabIndex = 11
        Me.lblOrigenDB.Text = "Servidor"
        '
        'FrmConexion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(397, 186)
        Me.Controls.Add(Me.GrpConexion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(340, 211)
        Me.Name = "FrmConexion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar Conexión a Base de Datos"
        Me.GrpConexion.ResumeLayout(False)
        Me.GrpConexion.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Padre As String

    Private dtlstDB As Object '' para listar las bases de datos

    Private sServer As String = ""
    Private sUser As String = ""
    Private sPassword As String = ""

    Private alerta(3) As PictureBox
    Private reloj As parpadea
    Private PorComision, PorDescMax As Double






    Private Sub ListaServer()

        If cbOrigenDB.Items.Count = 0 Then

            Dim dtLstSQL As DataTable

            dtLstSQL = SmoApplication.EnumAvailableSqlServers(False)

            If dtLstSQL.Rows.Count > 0 Then
                Dim i As Integer
                cbOrigenDB.Items.Clear()
                For i = 0 To dtLstSQL.Rows.Count - 1
                    cbOrigenDB.Items.Add(dtLstSQL.Rows(i)("Name"))
                Next
            End If
        End If
    End Sub

    Private Sub ListaDB()
        If cbOrigenDB.Text <> sServer OrElse txtUser.Text <> sUser OrElse txtPass.Text <> sPassword Then

            sServer = cbOrigenDB.Text
            sUser = txtUser.Text
            sPassword = txtPass.Text

            Dim instance As Server = New Server

            Try
                ''primero Conectamos

                instance.ConnectionContext.AutoDisconnectMode = AutoDisconnectMode.NoAutoDisconnect

                instance.ConnectionContext.ServerInstance = sServer
                instance.ConnectionContext.LoginSecure = False
                instance.ConnectionContext.Login = sUser
                instance.ConnectionContext.Password = sPassword

                instance.ConnectionContext.Connect()

                cbDB.Items.Clear()
                For Each db As Database In instance.Databases
                    ' en esta parte nos aseguramos que todo este correcto,
                    '' y cargamos las bases de datos
                    cbDB.Items.Add(db.Name)
                Next

                instance.ConnectionContext.Disconnect()

            Catch
                cbDB.Items.Clear()
            End Try
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub




    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cbOrigenDB.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.txtUser.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.txtPass.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cbDB.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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

    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        
        Me.cbOrigenDB.Text = BDServidor
        Me.cbDB.Text = BDCatalogo

        alerta(0) = Me.PictureBox6
        alerta(1) = Me.PictureBox7
        alerta(2) = Me.PictureBox8
        alerta(3) = Me.PictureBox9
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If validaForm() Then
            Me.BDServidor = Me.cbOrigenDB.Text
            Me.BDCatalogo = Me.cbDB.Text
            Me.BDUsuario = Me.txtUser.Text
            Me.BDContraseña = Me.txtPass.Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub cbOrigenDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOrigenDB.Click
        'Try
        '    ListaServer()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub cbDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDB.Click
        ListaDB()
    End Sub


End Class
