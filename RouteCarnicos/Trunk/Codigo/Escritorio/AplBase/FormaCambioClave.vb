Imports System.Drawing
Imports System.Windows.Forms

Public Class FormaCambioClave
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
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents ebNewPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbNewPassword As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormaCambioClave))
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.lbPassword = New System.Windows.Forms.Label
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ebNewPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNewPassword = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(268, 112)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btAceptar.TabIndex = 7
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
        Me.btCancelar.TabIndex = 8
        Me.btCancelar.Text = "Cancel"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbPassword
        '
        Me.lbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPassword.Location = New System.Drawing.Point(144, 36)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(132, 20)
        Me.lbPassword.TabIndex = 3
        Me.lbPassword.Text = "Password"
        Me.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPassword
        '
        Me.ebPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassword.Location = New System.Drawing.Point(280, 36)
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
        'ebNewPassword
        '
        Me.ebNewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNewPassword.Location = New System.Drawing.Point(280, 76)
        Me.ebNewPassword.MaxLength = 40
        Me.ebNewPassword.Name = "ebNewPassword"
        Me.ebNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebNewPassword.Size = New System.Drawing.Size(160, 20)
        Me.ebNewPassword.TabIndex = 6
        Me.ebNewPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNewPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNewPassword
        '
        Me.lbNewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNewPassword.Location = New System.Drawing.Point(144, 64)
        Me.lbNewPassword.Name = "lbNewPassword"
        Me.lbNewPassword.Size = New System.Drawing.Size(132, 32)
        Me.lbNewPassword.TabIndex = 5
        Me.lbNewPassword.Text = "Confirm Password"
        Me.lbNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormaCambioClave
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(450, 144)
        Me.Controls.Add(Me.ebNewPassword)
        Me.Controls.Add(Me.lbNewPassword)
        Me.Controls.Add(Me.ebPassword)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormaCambioClave"
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

    Public Function CambiarClaves(ByVal prUsuario As BASUSULOG.cUsuario) As Boolean
        vcUsuario = prUsuario

        Dim vlIcon1 As New Icon(sRutaInicio + "\Imagenes\Icono.dat")
        Me.Icon = vlIcon1

        vcMensaje = New BASMENLOG.CMensaje

        Dim vlToolTip As New ToolTip

        Me.Text = vcMensaje.RecuperarDescripcion("APLBase_FormaCambioClave")
        lbPassword.Text = vcMensaje.RecuperarDescripcion("XContraseñaNueva")
        lbNewPassword.Text = vcMensaje.RecuperarDescripcion("XConfContraseñaNueva")
        btAceptar.Text = vcMensaje.RecuperarDescripcion("btAceptar")
        btCancelar.Text = vcMensaje.RecuperarDescripcion("btCancelar")

        vlToolTip.SetToolTip(ebPassword, vcMensaje.RecuperarDescripcion("XContraseñaNueva"))
        vlToolTip.SetToolTip(ebNewPassword, vcMensaje.RecuperarDescripcion("XConfContraseñaNueva"))
        vlToolTip.SetToolTip(btAceptar, vcMensaje.RecuperarDescripcion("btAceptar"))
        vlToolTip.SetToolTip(btCancelar, vcMensaje.RecuperarDescripcion("btCancelar"))

        If Me.ShowDialog = DialogResult.OK Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None
        If ebPassword.Text = "" Then
            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {lbPassword.Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            ebPassword.Focus()
            Exit Sub
        End If

        If ebPassword.Text <> ebNewPassword.Text Then
            MsgBox(vcMensaje.RecuperarDescripcion("E0636"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            ebPassword.Focus()
            Exit Sub
        End If

        vcUsuario.ClaveAcceso = lbGeneral.SimpleCrypt(ebPassword.Text)
        vcUsuario.FechaMod = Now
        vcUsuario.Grabar()

        vcConexion.ConfirmarTran()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub FormaLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ebPassword.Focus()
    End Sub


End Class
