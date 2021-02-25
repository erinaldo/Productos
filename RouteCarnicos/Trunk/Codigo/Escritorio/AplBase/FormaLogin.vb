Imports System.Drawing
Imports System.Windows.Forms

Public Class FormaLogin
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ebLogin As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents lbLogin As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormaLogin))
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.lbPassword = New System.Windows.Forms.Label
        Me.lbLogin = New System.Windows.Forms.Label
        Me.ebLogin = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(268, 112)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btAceptar.TabIndex = 5
        Me.btAceptar.Text = "OK"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(360, 112)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btCancelar.TabIndex = 6
        Me.btCancelar.Text = "Cancel"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbPassword
        '
        Me.lbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPassword.Location = New System.Drawing.Point(144, 64)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(132, 20)
        Me.lbPassword.TabIndex = 3
        Me.lbPassword.Text = "Password"
        Me.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLogin
        '
        Me.lbLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLogin.Location = New System.Drawing.Point(144, 36)
        Me.lbLogin.Name = "lbLogin"
        Me.lbLogin.Size = New System.Drawing.Size(132, 20)
        Me.lbLogin.TabIndex = 1
        Me.lbLogin.Text = "Login"
        Me.lbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebLogin
        '
        Me.ebLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLogin.Location = New System.Drawing.Point(280, 36)
        Me.ebLogin.MaxLength = 40
        Me.ebLogin.Name = "ebLogin"
        Me.ebLogin.Size = New System.Drawing.Size(160, 20)
        Me.ebLogin.TabIndex = 2
        Me.ebLogin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLogin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebPassword
        '
        Me.ebPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassword.Location = New System.Drawing.Point(280, 64)
        Me.ebPassword.MaxLength = 40
        Me.ebPassword.Name = "ebPassword"
        Me.ebPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassword.Size = New System.Drawing.Size(160, 20)
        Me.ebPassword.TabIndex = 4
        Me.ebPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 35
        Me.PictureBox1.TabStop = False
        '
        'FormaLogin
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(450, 144)
        Me.Controls.Add(Me.ebPassword)
        Me.Controls.Add(Me.ebLogin)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.lbLogin)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormaLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AMESOL México"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcMensaje As BASMENLOG.CMensaje
    Private vcParametros As New lbGeneral.cParametros
    Private vcUsuario As BASUSULOG.cUsuario

    Private Sub FormaLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim vlIcon1 As New Icon(System.Windows.Forms.Application.StartupPath + "\Imagenes\Icono.dat")
        Dim vlIcon1 As New Icon(sRutaInicio + "\Imagenes\Icono.dat")
        Me.Icon = vlIcon1

        vcParametros.TipoAplicacion = lbGeneral.TipoAplicacion.Escritorio
        vcParametros.CargarParametros()
        vcConexion.Conectar(LbConexion.ModoConexion.INI)
        '#If DEBUG Then
        '        vcConexion.Conectar("Provider=SQLOLEDB;Data Source='PUMBA';user id=sa;password='dbsa';initial catalog = WHS;Connect Timeout=120")
        '#Else
        '        vcParametros.CargarParametros()
        '        vcConexion.Conectar(LbConexion.ModoConexion.INI)
        '#End If
        vcMensaje = New BASMENLOG.CMensaje
        vcMensaje.LlenarDataSet()
        vcUsuario = New BASUSULOG.cUsuario

        Dim vlToolTip As New ToolTip

        lbLogin.Text = vcMensaje.RecuperarDescripcion("XUsuario")
        lbPassword.Text = vcMensaje.RecuperarDescripcion("XContraseña")
        btAceptar.Text = vcMensaje.RecuperarDescripcion("btAceptar")
        btCancelar.Text = vcMensaje.RecuperarDescripcion("btCancelar")

        vlToolTip.SetToolTip(ebLogin, vcMensaje.RecuperarDescripcion("XUsuario"))
        vlToolTip.SetToolTip(ebPassword, vcMensaje.RecuperarDescripcion("XContraseña"))
        vlToolTip.SetToolTip(btAceptar, vcMensaje.RecuperarDescripcion("btAceptar"))
        vlToolTip.SetToolTip(btCancelar, vcMensaje.RecuperarDescripcion("btCancelar"))

        '****************************************
#If WAREHOUSE = 1 AndAlso SINLICENCIA = 0 Then
        Try
            Dim oDt As DataTable = vcConexion.EjecutarConsulta("Select isnull(Registro,'') as Registro from Compania")
            If oDt.Rows.Count > 0 Then
                Dim sRegistro As String = oDt.Rows(0)(0)
                If Trim(sRegistro).Length <> 16 Then
                    MsgBox(vcMensaje.RecuperarDescripcion("F0009"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    Me.DialogResult = DialogResult.Abort
                    Me.Close()
                    Exit Sub
                Else
                    Dim cLetras As Char() = sRegistro.ToCharArray
                    Dim i As Integer = 0
                    Dim sFecha As String = String.Empty
                    For Each cLetra As Char In cLetras
                        If i Mod 2 = 0 Then
                            sFecha &= cLetra
                            If (i = 2) OrElse (i = 6) Then
                                sFecha &= "/"
                            End If
                        End If
                        i += 1
                    Next
                    Try
                        'Dim dFecha, dFechaServ As Date
                        'dFechaServ = vcConexion.ObtenerFecha
                        'dFechaServ = dFechaServ.AddMilliseconds(-dFechaServ.Millisecond)
                        'dFechaServ = dFechaServ.AddSeconds(-dFechaServ.Second)
                        'dFechaServ = dFechaServ.AddMinutes(-dFechaServ.Minute)
                        'dFechaServ = dFechaServ.AddHours(-dFechaServ.Hour)

                        'dFecha = CDate(sFecha)
                        'dFecha = dFecha.AddMilliseconds(-dFecha.Millisecond)
                        'dFecha = dFecha.AddSeconds(-dFecha.Second)
                        'dFecha = dFecha.AddMinutes(-dFecha.Minute)
                        'dFecha = dFecha.AddHours(-dFecha.Hour)

                        Dim dFecha, dFechaServ, dFechaServ1 As Date
                        dFechaServ1 = vcConexion.ObtenerFecha
                        dFechaServ = dFechaServ.AddYears(dFechaServ1.Year - 1)
                        dFechaServ = dFechaServ.AddMonths(dFechaServ1.Month - 1)
                        dFechaServ = dFechaServ.AddDays(dFechaServ1.Day - 1)
                        dFechaServ = dFechaServ.AddMilliseconds(-dFechaServ.Millisecond)
                        dFechaServ = dFechaServ.AddSeconds(-dFechaServ.Second)
                        dFechaServ = dFechaServ.AddMinutes(-dFechaServ.Minute)
                        dFechaServ = dFechaServ.AddHours(-dFechaServ.Hour)

                        dFecha = dFecha.AddYears(CInt(sFecha.Substring(6, 4)) - 1)
                        dFecha = dFecha.AddMonths(CInt(sFecha.Substring(3, 2)) - 1)
                        dFecha = dFecha.AddDays(CInt(sFecha.Substring(0, 2)) - 1)
                        dFecha = dFecha.AddMilliseconds(-dFecha.Millisecond)
                        dFecha = dFecha.AddSeconds(-dFecha.Second)
                        dFecha = dFecha.AddMinutes(-dFecha.Minute)
                        dFecha = dFecha.AddHours(-dFecha.Hour)

                        If dFecha < dFechaServ Then
                            MsgBox(vcMensaje.RecuperarDescripcion("F0010"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            Me.DialogResult = DialogResult.Abort
                            Me.Close()
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MsgBox(vcMensaje.RecuperarDescripcion("F0009"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                        Me.DialogResult = DialogResult.Abort
                        Me.Close()
                        Exit Sub
                    End Try
                End If
            Else
                MsgBox(vcMensaje.RecuperarDescripcion("F0009"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Me.DialogResult = DialogResult.Abort
                Me.Close()
                Exit Sub
            End If
            oDt = Nothing
        Catch ex As Exception
            MsgBox(vcMensaje.RecuperarDescripcion("F0009"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            Me.DialogResult = DialogResult.Abort
            Me.Close()
            Exit Sub
        End Try
#End If
        '****************************************
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None
        If ebLogin.Text = "" Then
            MsgBox(vcMensaje.RecuperarDescripcion("E0288"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            ebLogin.Focus()
            Exit Sub
        End If

        If vcUsuario.RecuperarClave(ebLogin.Text) = True Then
            Dim vlPassword As String = lbGeneral.SimpleCrypt(vcUsuario.ClaveAcceso)
            If ebPassword.Text = vlPassword Then
                vcParametros.UsuarioID = vcUsuario.USUId

#If Warehouse = 1 Then
                Dim vlConexionString As String = vcConexion.Conexion.ConnectionString.ToLower
                If vlConexionString.IndexOf("data source") >= 0 Then
                    vlConexionString = vlConexionString.Substring(0, vlConexionString.IndexOf("data source")) & "Data Source=" & vcUsuario.DBServidor & vlConexionString.Substring(vlConexionString.IndexOf("data source")).Substring(vlConexionString.Substring(vlConexionString.IndexOf("data source")).IndexOf(";"))
                End If

                If vlConexionString.IndexOf("server") >= 0 Then
                    vlConexionString = vlConexionString.Substring(0, vlConexionString.IndexOf("server")) & "Server=" & vcUsuario.DBServidor & vlConexionString.Substring(vlConexionString.IndexOf("server")).Substring(vlConexionString.Substring(vlConexionString.IndexOf("server")).IndexOf(";"))
                End If

                If vlConexionString.IndexOf("initial catalog") >= 0 Then
                    vlConexionString = vlConexionString.Substring(0, vlConexionString.IndexOf("initial catalog")) & "Initial Catalog=" & vcUsuario.DBBaseDeDatos & vlConexionString.Substring(vlConexionString.IndexOf("initial catalog")).Substring(vlConexionString.Substring(vlConexionString.IndexOf("initial catalog")).IndexOf(";"))
                End If

                If vlConexionString.IndexOf("user id") >= 0 Then
                    vlConexionString = vlConexionString.Substring(0, vlConexionString.IndexOf("user id")) & "User Id=" & vcUsuario.DBUsuario & vlConexionString.Substring(vlConexionString.IndexOf("user id")).Substring(vlConexionString.Substring(vlConexionString.IndexOf("user id")).IndexOf(";"))
                End If

                If vlConexionString.IndexOf("password") >= 0 Then
                    vlConexionString = vlConexionString.Substring(0, vlConexionString.IndexOf("password")) & "Password=" & vcUsuario.DBContrasenia & vlConexionString.Substring(vlConexionString.IndexOf("password")).Substring(vlConexionString.Substring(vlConexionString.IndexOf("password")).IndexOf(";"))
                End If

#End If

                vcConexion.ConfirmarTran()
                vcConexion.Desconectar()


#If Warehouse = 1 Then
                vcConexion.Conectar(vlConexionString)
                vcParametros.Lenguaje = vcUsuario.TipoLenguaje
#Else

                vcConexion.Conectar()
#End If


                vcMensaje = New BASMENLOG.CMensaje
                vcMensaje.LlenarDataSet()

                If vcUsuario.DiasLimite > 0 Then
                    If Now > vcUsuario.FechaMod.AddDays(vcUsuario.DiasLimite) Then
                        Dim oCambiarClave As New FormaCambioClave
                        If oCambiarClave.CambiarClaves(vcUsuario) = False Then
                            Me.Close()
                            Exit Sub
                        End If
                    End If
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox(vcMensaje.RecuperarDescripcion("E0288"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                ebPassword.SelectionStart = 0
                ebPassword.SelectionLength = ebPassword.Text.Length
                ebPassword.Focus()
                Exit Sub
            End If
        Else
            MsgBox(vcMensaje.RecuperarDescripcion("E0288"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            ebLogin.SelectionStart = 0
            ebLogin.SelectionLength = ebLogin.Text.Length
            ebLogin.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub FormaLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ebLogin.Focus()
    End Sub
End Class
