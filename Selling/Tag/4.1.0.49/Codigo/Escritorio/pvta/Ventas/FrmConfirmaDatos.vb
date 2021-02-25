
Public Class FrmConfirmaDatos
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnContinuar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNIP As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblConfirmar As System.Windows.Forms.Label
    Friend WithEvents txtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents lblCorreo As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents cmbGenero As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMes As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAno As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbTipoTel1 As Selling.StoreCombo
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtNIP As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfirmaDatos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNIP = New System.Windows.Forms.Label()
        Me.txtNIP = New System.Windows.Forms.TextBox()
        Me.BtnContinuar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblConfirmar = New System.Windows.Forms.Label()
        Me.txtConfirmar = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMes = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAno = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbGenero = New Selling.StoreCombo()
        Me.cmbTipoTel1 = New Selling.StoreCombo()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
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
        'LblNIP
        '
        resources.ApplyResources(Me.LblNIP, "LblNIP")
        Me.LblNIP.Name = "LblNIP"
        '
        'txtNIP
        '
        resources.ApplyResources(Me.txtNIP, "txtNIP")
        Me.txtNIP.Name = "txtNIP"
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
        Me.Label3.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'lblConfirmar
        '
        resources.ApplyResources(Me.lblConfirmar, "lblConfirmar")
        Me.lblConfirmar.Name = "lblConfirmar"
        '
        'txtConfirmar
        '
        resources.ApplyResources(Me.txtConfirmar, "txtConfirmar")
        Me.txtConfirmar.Name = "txtConfirmar"
        '
        'txtCorreo
        '
        resources.ApplyResources(Me.txtCorreo, "txtCorreo")
        Me.txtCorreo.Name = "txtCorreo"
        '
        'lblCorreo
        '
        resources.ApplyResources(Me.lblCorreo, "lblCorreo")
        Me.lblCorreo.Name = "lblCorreo"
        '
        'lblTelefono
        '
        resources.ApplyResources(Me.lblTelefono, "lblTelefono")
        Me.lblTelefono.Name = "lblTelefono"
        '
        'txtTelefono
        '
        resources.ApplyResources(Me.txtTelefono, "txtTelefono")
        Me.txtTelefono.Name = "txtTelefono"
        '
        'lblMensaje
        '
        resources.ApplyResources(Me.lblMensaje, "lblMensaje")
        Me.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMensaje.Name = "lblMensaje"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtDia
        '
        resources.ApplyResources(Me.txtDia, "txtDia")
        Me.txtDia.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtDia.Name = "txtDia"
        Me.txtDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDia.Value = 31
        Me.txtDia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtMes
        '
        resources.ApplyResources(Me.txtMes, "txtMes")
        Me.txtMes.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtMes.Name = "txtMes"
        Me.txtMes.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMes.Value = 12
        Me.txtMes.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txtAno
        '
        resources.ApplyResources(Me.txtAno, "txtAno")
        Me.txtAno.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtAno.Name = "txtAno"
        Me.txtAno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtAno.Value = 2000
        Me.txtAno.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'cmbGenero
        '
        Me.cmbGenero.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbGenero, "cmbGenero")
        Me.cmbGenero.Name = "cmbGenero"
        '
        'cmbTipoTel1
        '
        resources.ApplyResources(Me.cmbTipoTel1, "cmbTipoTel1")
        Me.cmbTipoTel1.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoTel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTel1.Name = "cmbTipoTel1"
        '
        'txtCodigoPostal
        '
        resources.ApplyResources(Me.txtCodigoPostal, "txtCodigoPostal")
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'btnSalir
        '
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.btnSalir, "btnSalir")
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnSalir.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmConfirmaDatos
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCodigoPostal)
        Me.Controls.Add(Me.cmbTipoTel1)
        Me.Controls.Add(Me.txtAno)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbGenero)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.lblCorreo)
        Me.Controls.Add(Me.lblTelefono)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtConfirmar)
        Me.Controls.Add(Me.lblConfirmar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblNIP)
        Me.Controls.Add(Me.txtNIP)
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
    Public Genero As Integer
    Public FecNacimiento As Date
    Public TipoTel As Integer
    Public Telefono As String
    Public Correo As String
    Public CodigoPostal As String
    Public NIP As String
    Private bTechadoTouch As Boolean = False
    Private oskID As Integer = -1

    Private Sub FrmConfirmaDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_pass_cte", "@CTEClave", CTEClave, "@Pass", "Duxst4r.")
        NIP = formateaNIP(dt.Rows(0)("Password"))
        dt.Dispose()

        With cmbGenero
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Genero"
            .llenar()
        End With

        With cmbTipoTel1
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "Campo"
            .Parametro2 = "TipoTelefono"
            .llenar()
        End With

        cmbGenero.SelectedValue = Genero

        Dim sFecha As String
        sFecha = Format(FecNacimiento, "dd/MM/yyy")


        txtDia.Text = sFecha.Split("/")(0)
        txtMes.Text = sFecha.Split("/")(1)
        txtAno.Text = sFecha.Split("/")(2)
        cmbTipoTel1.SelectedValue = TipoTel

        txtTelefono.Text = Telefono
        txtCorreo.Text = Correo
        txtNIP.Text = NIP
        txtConfirmar.Text = NIP

        txtCodigoPostal.Text = CodigoPostal

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmConfirmaDatos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinuar.Click

        If txtConfirmar.Text.Trim <> txtNIP.Text.Trim Or txtNIP.Text.Trim = "" Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "El NIP no es igual ó es requerido"
        ElseIf IsNumeric(txtNIP.Text.Trim) = False Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "El NIP debe ser numérico"
        ElseIf txtNIP.Text.Length <> 4 Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "El NIP debe ser 4 digitos"
        ElseIf cmbGenero.SelectedValue Is Nothing Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "Seleccionar Genero"
        ElseIf cmbTipoTel1.SelectedValue Is Nothing AndAlso txtTelefono.Text <> "" Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "Seleccionar Tipo de Teléfono"

        ElseIf DateTime.TryParseExact(IIf(txtDia.Text.Length = 1, "0", "") & txtDia.Text & "/" & IIf(txtMes.Text.Length = 1, "0", "") & txtMes.Text & "/" & txtAno.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, FecNacimiento) = False Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "La Fecha de Nacimiento es invalida"
        ElseIf txtCodigoPostal.Text <> "" AndAlso txtCodigoPostal.Text.Length <> 5 Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "El código postal debe ser de 5 digitos"
        ElseIf txtCorreo.Text <> "" AndAlso IsValidEmail(txtCorreo.Text) = False Then
            'If IsValidEmail(txtCorreo.Text) = False Then
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            lblMensaje.Text = "El formato del correo electronico no es valido"
            'End If

        Else

            CodigoPostal = txtCodigoPostal.Text
            Genero = cmbGenero.SelectedValue
            FecNacimiento = DateTime.ParseExact(IIf(txtDia.Text.Length = 1, "0", "") & txtDia.Text & "/" & IIf(txtMes.Text.Length = 1, "0", "") & txtMes.Text & "/" & txtAno.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None)
            NIP = txtNIP.Text.Trim
            Telefono = txtTelefono.Text.Trim
            Correo = txtCorreo.Text.Trim
            TipoTel = IIf(cmbTipoTel1.SelectedValue Is Nothing, 1, cmbTipoTel1.SelectedValue)
            lblMensaje.Text = ""
            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            If oskID <> -1 Then
                Try

                    If bTechadoTouch = False Then
                        Process.GetProcessesByName("osk")(0).Kill()
                    Else
                        Process.GetProcessesByName("TabTip")(0).Kill()
                    End If

                Catch ex As Exception
                End Try
                oskID = -1
            End If
        End If
    End Sub

    Private Sub txtTelefono_Click(sender As Object, e As EventArgs) Handles txtTelefono.Click
        Dim a As New FrmTecladoNum

        a.Text = "Télefono"
        a.OcultarSignos = True
        a.TxtCantidad.Text = txtTelefono.Text
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtTelefono.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPIN_Click(sender As Object, e As EventArgs) Handles txtNIP.Click
        Dim a As New FrmTecladoNum
        a.Text = "PIN"
        a.OcultarSignos = True
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtNIP.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtConfirmar_Click(sender As Object, e As EventArgs) Handles txtConfirmar.Click
        Dim a As New FrmTecladoNum
        a.Text = "Confirmar PIN"
        a.OcultarSignos = True
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtConfirmar.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Ctrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnContinuar.KeyUp, txtNIP.KeyUp, txtTelefono.KeyUp, txtCorreo.KeyUp, txtConfirmar.KeyUp
        If e.KeyCode = Keys.Enter Then
            bError = False
            If oskID <> -1 Then
                Try

                    If bTechadoTouch = False Then
                        Process.GetProcessesByName("osk")(0).Kill()
                    Else
                        Process.GetProcessesByName("TabTip")(0).Kill()
                    End If

                Catch ex As Exception

                End Try

                oskID = -1
            End If
        End If
    End Sub

    Private Sub Ctrl_Click(sender As Object, e As EventArgs) Handles txtCorreo.Click
        AbrirTeclado(Me, txtCorreo.Text)
        'If oskID = -1 Then

        '    Dim TabTip As String = "C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe"

        '    Try
        '        If IO.File.Exists(TabTip) Then
        '            Using myProcess As Process = New Process()
        '                myProcess.StartInfo.FileName = TabTip
        '                myProcess.StartInfo.CreateNoWindow = True
        '                myProcess.Start()
        '                oskID = myProcess.Id
        '                bTechadoTouch = True
        '            End Using
        '        Else
        '            oskID = Process.Start("osk.exe").Id
        '            bTechadoTouch = False
        '        End If
        '    Catch ex As Exception
        '        oskID = Process.Start("osk.exe").Id
        '        bTechadoTouch = False
        '    End Try


        'End If
    End Sub

    Private Sub txtDia_Click(sender As Object, e As EventArgs) Handles txtDia.Click
        Dim a As New FrmTecladoNum
        a.Text = "Día"
        a.OcultarSignos = True
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtDia.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMes_Click(sender As Object, e As EventArgs) Handles txtMes.Click
        Dim a As New FrmTecladoNum
        a.Text = "Mes"
        a.OcultarSignos = True
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtMes.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtAno_Click(sender As Object, e As EventArgs) Handles txtAno.Click
        Dim a As New FrmTecladoNum
        a.Text = "Año"
        a.OcultarSignos = True
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtAno.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodigoPostal_Click(sender As Object, e As EventArgs) Handles txtCodigoPostal.Click
        Dim a As New FrmTecladoNum
        a.Text = "Código Postal"
        a.OcultarSignos = True
        a.TxtCantidad.Text = txtCodigoPostal.Text
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtCodigoPostal.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar
        If dato = "DESHACER" OrElse dato = "" Then
            If txtCorreo.TextLength > 0 Then
                txtCorreo.Text = txtCorreo.Text.Remove(txtCorreo.TextLength - 1, 1)
            End If
        Else
            txtCorreo.Text &= dato
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class


