
Public Class FrmLogin
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
    Friend WithEvents LblVersion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'LblVersion
        '
        Me.LblVersion.BackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.LblVersion, "LblVersion")
        Me.LblVersion.ForeColor = System.Drawing.Color.White
        Me.LblVersion.Name = "LblVersion"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TxtPassword
        '
        resources.ApplyResources(Me.TxtPassword, "TxtPassword")
        Me.TxtPassword.Name = "TxtPassword"
        '
        'TxtLogin
        '
        resources.ApplyResources(Me.TxtLogin, "TxtLogin")
        Me.TxtLogin.Name = "TxtLogin"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.Name = "BtnCancelar"
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.Name = "BtnOk"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'FrmLogin
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmLogin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private BDServidor, BDCatalogo As String
    Private Cnx As System.Data.SqlClient.SqlConnection
    Private da As System.Data.SqlClient.SqlDataAdapter
    Private ds As DataTable
    Private bError As Boolean = False

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        LblVersion.Text = ModPOS.Version

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Entrar()
        Cursor.Current = Cursors.Default
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function validaConexionEncripatada(ByVal sCon As String) As Boolean
        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = sCon
            Cnx.Open()
            Cnx.Close()
            Return False
        Catch ex As Exception
            Return True
        End Try

    End Function



    Private Sub Entrar()


        Dim Con As String = ""
        Dim CnxExitosa As Boolean = True
        Dim El_Archivo As String

        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName()

        pathActual = dir & "\"

        El_Archivo = dir & "\AplPOS.ini"

        Dim frmStatusMessage As New frmStatus


        Try
            Dim file As New System.IO.StreamReader(El_Archivo)
            Con = file.ReadLine()
            file.Close()

            If validaConexionEncripatada(Con) = False Then
                Dim CnxArchivo As String = Con

                Dim sPw As String = Con.Split("=")(4).Split(";")(0)
                Dim sPwe As String = ModPOS.EncryptText(sPw, "AlpeGroup")
                
                Con = CnxArchivo.Replace(sPw, sPwe)

                'Actualiza el Archivo 
                Dim File2 As New System.IO.StreamWriter(El_Archivo)
                File2.WriteLine(Con)
                File2.Close()

            End If


            BDServidor = Con.Split("=")(1).Split(";")(0)
            BDCatalogo = Con.Split("=")(2).Split(";")(0)

            Dim pwEncrypted As String = Con.Split("=")(4).Split(";")(0)
            Dim pwDecrypted As String = ModPOS.DecryptText(pwEncrypted, "AlpeGroup")

            Con = Con.Replace(pwEncrypted, pwDecrypted)

         

            Cnx = New System.Data.SqlClient.SqlConnection




            Try
                Cnx.ConnectionString = Con


                BDServidor = Cnx.DataSource
                BDCatalogo = Cnx.Database
                frmStatusMessage.Show("Estableciendo conexión...")
                Cnx.Open()

            Catch ex As Exception
                Beep()
                CnxExitosa = False
                MsgBox("No se pudo establecer conexión con el Servidor", MsgBoxStyle.Critical, "Error")
            End Try


            Cnx.Close()

            If Not CnxExitosa Then
                Dim CnxArchivo As String = ""
                'Solicta nuevos datos de conexión
                Dim a As New FrmConexion
                a.BDCatalogo = Me.BDCatalogo
                a.BDServidor = Me.BDServidor
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Con = "data source=" & a.BDServidor & ";initial catalog=" & a.BDCatalogo & "; user id=" & a.BDUsuario & "; password=" & a.BDContraseña & "; TimeOut=60;"
                    CnxArchivo = "data source=" & a.BDServidor & ";initial catalog=" & a.BDCatalogo & "; user id=" & a.BDUsuario & "; password=" & ModPOS.EncryptText(a.BDContraseña, "AlpeGroup") & "; TimeOut=60;"
                Else
                    Exit Sub
                End If
                a.Dispose()

                'Actualiza el Archivo 
                Dim File2 As New System.IO.StreamWriter(El_Archivo)
                File2.WriteLine(CnxArchivo)
                File2.Close()
            End If


        Catch ex As System.IO.FileNotFoundException
            MsgBox(ex.Message)
        End Try

        frmStatusMessage.Dispose()

        'pwd 12345
        Dim dtUsuario As DataTable

        dtUsuario = ModPOS.SiExisteRecuperaT(Con, "sp_valida_Usr", "@Login", UCase(Trim(Me.TxtLogin.Text.Replace("'", "''"))))
        If Not dtUsuario Is Nothing Then

            If EW.Encrypt.HashPass.ValidatePassword(TxtPassword.Text.Trim, dtUsuario.Rows(0)("Password")) Then
                ModPOS.UsuarioLogin = UCase(Trim(Me.TxtLogin.Text))
                ModPOS.BDConexion = Con

                If dtUsuario.Columns.Contains("Renovacion") = True Then
                    If dtUsuario.Rows(0)("Renovacion") > 0 Then
                        Dim Vigencia As Integer = DateDiff(DateInterval.Day, dtUsuario.Rows(0)("FechaInicio"), Today.Date)

                        If Vigencia > dtUsuario.Rows(0)("Renovacion") Then
                            Dim bCambio As Boolean = False
                            Do
                                Dim a As New MeFirma
                                a.Text = "Actualización de Seguridad"
                                a.GroupBox1.Text = "Nueva Contraseña"
                                a.Label1.Text = "Contraseña"
                                a.SUCClave = ""
                                a.USRClave = dtUsuario.Rows(0)("USRClave")
                                a.Firma = dtUsuario.Rows(0)("Password")
                                a.TxtMensaje.Text = "han transcurrido más de " & CStr(dtUsuario.Rows(0)("Renovacion")) & " dias, con la misma Contraseña por lo que debes cambiarla por una nueva"
                                a.StartPosition = FormStartPosition.CenterScreen
                                a.ShowDialog()
                                If a.DialogResult = DialogResult.OK Then
                                    If a.Autorizado Then
                                        bCambio = True
                                        MsgBox("La Contraseña ha sido Actualizada", MsgBoxStyle.Information, "Información")
                                    End If
                                End If
                            Loop While bCambio = False
                        End If
                    End If
                End If

                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", "%")

                If dt.Rows.Count = 1 Then
                    ModPOS.CompanyActual = dt.Rows(0)("COMClave")
                    ModPOS.TituloMain = "Selling  " & ModPOS.Version & " - " & dt.Rows(0)("Nombre") & " [" & BDServidor & "\" & BDCatalogo & "]"
                    ModPOS.CompanyName = dt.Rows(0)("Nombre")
                    ModPOS.VersionActual = IIf(dt.Rows(0)("Version").GetType.Name = "DBNull", VersionSelling, dt.Rows(0)("Version"))
                Else
                    Dim a As New MeFiltroCompania
                    a.Titulo = "Selección de Compañia"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        ModPOS.CompanyActual = a.Origen
                        ModPOS.TituloMain = "Selling  " & ModPOS.Version & " - " & a.Texto & " [" & BDServidor & "\" & BDCatalogo & "]"
                        ModPOS.CompanyName = a.Texto
                        ModPOS.VersionActual = a.Version
                    Else
                        bError = True
                        Exit Sub
                    End If
                    a.Dispose()
                End If



                'Obtener IP de Equipo

                Dim host As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)


                Dim IP As System.Net.IPAddress() = host.AddressList

                Dim index As Integer

                For index = 0 To IP.Length - 1
                    If IP(index).AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                        If IP(index).IsIPv6LinkLocal = False Then
                            IPAddress = IP(index).ToString
                            Exit For
                        End If
                    End If
                Next

                If IPAddress = "" Then
                    IPAddress = System.Net.Dns.GetHostName
                End If




                '  ModPOS.myTimeOut = Con.Substring(Con.Length - 1, 2)

                Dim dtParam As DataTable

                dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
                With Me
                    Dim i As Integer
                    For i = 0 To dtParam.Rows.Count - 1
                        Select Case CStr(dtParam.Rows(i)("PARClave"))
                            Case "Aplicacion"
                                ModPOS.AplicacionAutomotriz = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                                Exit Select
                        End Select
                    Next
                End With
                dtParam.Dispose()

                'Valida Licencia
                If Not ModPOS.ValidaLicencia() Then
                    AccesoAutorizado = False
                End If
                bError = False
            Else
                bError = True
                Beep()
                MessageBox.Show("El Usuario o la Contraseña no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            dtUsuario.Dispose()
        Else
            bError = True
            Beep()
            MessageBox.Show("El Usuario o la Contraseña no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.Close()
    End Sub


    Private Sub FrmLogin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPassword.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.BtnOk.PerformClick()
        End Select

    End Sub

End Class


