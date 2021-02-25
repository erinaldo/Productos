Public Class MeAutorizacion
    Inherits System.Windows.Forms.Form

    Public Autorizado As Boolean
    Public Autoriza As String
    Public NivelSucursal As Integer = 1
    Public sp As String = "sp_filtra_autoriza"

    Private SUCClave As String
    Private Monto As Double
    Private Firma As String
    Private bError As Boolean = False
    Private alerta(1) As PictureBox
    Private reloj As parpadea


    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox

    Public WriteOnly Property StoreProcedure() As String
        Set(ByVal Value As String)
            sp = Value
        End Set
    End Property

    Public WriteOnly Property MontodeAutorizacion() As Double
        Set(ByVal Value As Double)
            Monto = Value
        End Set
    End Property

    Public WriteOnly Property Sucursal() As String
        Set(ByVal Value As String)
            SUCClave = Value
        End Set
    End Property



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbAutoriza As Selling.StoreCombo
    Friend WithEvents TxtFirma As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeAutorizacion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtFirma = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmbAutoriza = New Selling.StoreCombo
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.picKeyboard)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.TxtFirma)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 44)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Firma"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picKeyboard.Location = New System.Drawing.Point(345, 9)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 33)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 68
        Me.picKeyboard.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(71, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 67
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtFirma
        '
        Me.TxtFirma.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFirma.Location = New System.Drawing.Point(7, 15)
        Me.TxtFirma.Name = "TxtFirma"
        Me.TxtFirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtFirma.Size = New System.Drawing.Size(327, 20)
        Me.TxtFirma.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.cmbAutoriza)
        Me.GroupBox2.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(394, 45)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Autoriza:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(372, 107)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 66
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cmbAutoriza
        '
        Me.cmbAutoriza.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAutoriza.Location = New System.Drawing.Point(7, 13)
        Me.cmbAutoriza.Name = "cmbAutoriza"
        Me.cmbAutoriza.Size = New System.Drawing.Size(365, 21)
        Me.cmbAutoriza.TabIndex = 65
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(306, 100)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Autorizar transacción"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(210, 100)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'MeAutorizacion
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(400, 147)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(208, 149)
        Me.Name = "MeAutorizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtFirma.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbAutoriza.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Autorizado = False
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            If NivelSucursal = 1 Then

                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_valida_autorizacion", "@SUCClave", SUCClave, "@Usuario", cmbAutoriza.SelectedValue)

                If dt Is Nothing Then
                    MsgBox("Autorización Denegada", MsgBoxStyle.Critical, "Error")
                    Autorizado = False
                    bError = True
                Else
                    If TxtFirma.Text.Trim = ModPOS.DecryptText(dt.Rows(0)("Firma"), "AlpeGroup") Then
                        Autorizado = True
                        bError = False
                        Autoriza = cmbAutoriza.SelectedValue

                        Dim Renovacion As Integer = IIf(dt.Rows(0)("Renovacion").GetType.Name = "DBNull", 0, dt.Rows(0)("Renovacion"))
                        Dim FechaInicio As Date = IIf(dt.Rows(0)("FechaInicio").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("FechaInicio"))
                        Dim FechaHoy As Date = Today.Date

                        Dim Vigencia As Integer = DateDiff(DateInterval.Day, FechaInicio, FechaHoy)

                        If Renovacion > 0 AndAlso Vigencia > Renovacion Then
                            Dim a As New MeFirma
                            a.SUCClave = SUCClave
                            a.USRClave = Autoriza
                            a.Firma = dt.Rows(0)("Firma")
                            a.TxtMensaje.Text = Me.cmbAutoriza.SelectedItem(1) & ", han transcurrido más de " & CStr(Renovacion) & " dias, con la misma Firma por lo que debes cambiarla por una nueva"
                            a.StartPosition = FormStartPosition.CenterScreen
                            a.ShowDialog()
                            If a.DialogResult = DialogResult.OK Then
                                If Not a.Autorizado Then
                                    MsgBox("La Firma no ha sido Actualizada. Se recordara en la siguiente autorización", MsgBoxStyle.Critical, "Error")
                                End If
                            Else
                                MsgBox("La Firma no ha sido Actualizada. Se recordara en la siguiente autorización", MsgBoxStyle.Critical, "Error")
                            End If
                        End If

                        dt.Dispose()
                        Me.Close()
                    Else
                        MsgBox("Autorización Denegada", MsgBoxStyle.Critical, "Error")
                        Autorizado = False
                        bError = True
                        dt.Dispose()
                    End If
                End If
            Else

                Dim dtUsuario As DataTable
                dtUsuario = ModPOS.Recupera_Tabla("sp_recupera_UsuarioActual", "@Usuario", cmbAutoriza.SelectedValue)
                If EW.Encrypt.HashPass.ValidatePassword(TxtFirma.Text.Trim, dtUsuario.Rows(0)("Password")) Then
                    Autorizado = True
                    bError = False
                    Autoriza = cmbAutoriza.SelectedValue
                Else
                    MsgBox("Autorización Denegada", MsgBoxStyle.Critical, "Error")
                    Autorizado = False
                    bError = True
                End If
                dtUsuario.Dispose()
            End If
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub MeAutorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2


        With cmbAutoriza
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = sp
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .NombreParametro2 = "Monto"
            .Parametro2 = Monto
            .llenar()
        End With

    End Sub

    Private Sub MeAutorizacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        Process.Start("osk.exe")
    End Sub
End Class
