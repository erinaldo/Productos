Public Class PRepMensualHacienda
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
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbAño As System.Windows.Forms.Label
    Friend WithEvents LbMes As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAnio As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbSubempresa As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbSubEmpresa As System.Windows.Forms.Label
    Friend WithEvents cbMes As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRepMensualHacienda))
        Dim UiComboBoxItem37 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem38 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem39 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem40 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem41 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem42 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem43 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem44 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem45 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem46 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem47 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem48 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Me.lbAño = New System.Windows.Forms.Label
        Me.LbMes = New System.Windows.Forms.Label
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbAnio = New Janus.Windows.EditControls.UIComboBox
        Me.cbMes = New Janus.Windows.EditControls.UIComboBox
        Me.cbSubempresa = New Janus.Windows.EditControls.UIComboBox
        Me.lbSubEmpresa = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lbAño
        '
        Me.lbAño.Location = New System.Drawing.Point(352, 48)
        Me.lbAño.Name = "lbAño"
        Me.lbAño.Size = New System.Drawing.Size(104, 20)
        Me.lbAño.TabIndex = 8
        Me.lbAño.Text = "lbAño"
        Me.lbAño.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbMes
        '
        Me.LbMes.Location = New System.Drawing.Point(23, 48)
        Me.LbMes.Name = "LbMes"
        Me.LbMes.Size = New System.Drawing.Size(121, 20)
        Me.LbMes.TabIndex = 6
        Me.LbMes.Text = "LbMes"
        Me.LbMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(396, 100)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 32
        Me.btAceptar.Text = "btAceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(508, 100)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 33
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 3)
        Me.Label1.TabIndex = 34
        '
        'cbAnio
        '
        Me.cbAnio.AutoComplete = False
        Me.cbAnio.Location = New System.Drawing.Point(416, 48)
        Me.cbAnio.Name = "cbAnio"
        Me.cbAnio.Size = New System.Drawing.Size(136, 20)
        Me.cbAnio.TabIndex = 35
        Me.cbAnio.Text = "cbAnio"
        Me.cbAnio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbMes
        '
        UiComboBoxItem37.FormatStyle.Alpha = 0
        UiComboBoxItem37.IsSeparator = False
        UiComboBoxItem37.Text = "Enero"
        UiComboBoxItem37.Value = "01"
        UiComboBoxItem38.FormatStyle.Alpha = 0
        UiComboBoxItem38.IsSeparator = False
        UiComboBoxItem38.Text = "Febrero"
        UiComboBoxItem38.Value = "02"
        UiComboBoxItem39.FormatStyle.Alpha = 0
        UiComboBoxItem39.IsSeparator = False
        UiComboBoxItem39.Text = "Marzo"
        UiComboBoxItem39.Value = "03"
        UiComboBoxItem40.FormatStyle.Alpha = 0
        UiComboBoxItem40.IsSeparator = False
        UiComboBoxItem40.Text = "Abril"
        UiComboBoxItem40.Value = "04"
        UiComboBoxItem41.FormatStyle.Alpha = 0
        UiComboBoxItem41.IsSeparator = False
        UiComboBoxItem41.Text = "Mayo"
        UiComboBoxItem41.Value = "05"
        UiComboBoxItem42.FormatStyle.Alpha = 0
        UiComboBoxItem42.IsSeparator = False
        UiComboBoxItem42.Text = "Junio"
        UiComboBoxItem42.Value = "06"
        UiComboBoxItem43.FormatStyle.Alpha = 0
        UiComboBoxItem43.IsSeparator = False
        UiComboBoxItem43.Text = "Julio"
        UiComboBoxItem43.Value = "07"
        UiComboBoxItem44.FormatStyle.Alpha = 0
        UiComboBoxItem44.IsSeparator = False
        UiComboBoxItem44.Text = "Agosto"
        UiComboBoxItem44.Value = "08"
        UiComboBoxItem45.FormatStyle.Alpha = 0
        UiComboBoxItem45.IsSeparator = False
        UiComboBoxItem45.Text = "Septiembre"
        UiComboBoxItem45.Value = "09"
        UiComboBoxItem46.FormatStyle.Alpha = 0
        UiComboBoxItem46.IsSeparator = False
        UiComboBoxItem46.Text = "Octubre"
        UiComboBoxItem46.Value = CType(10, Short)
        UiComboBoxItem47.FormatStyle.Alpha = 0
        UiComboBoxItem47.IsSeparator = False
        UiComboBoxItem47.Text = "Noviembre"
        UiComboBoxItem47.Value = CType(11, Short)
        UiComboBoxItem48.FormatStyle.Alpha = 0
        UiComboBoxItem48.IsSeparator = False
        UiComboBoxItem48.Text = "Diciembre"
        UiComboBoxItem48.Value = CType(12, Short)
        Me.cbMes.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem37, UiComboBoxItem38, UiComboBoxItem39, UiComboBoxItem40, UiComboBoxItem41, UiComboBoxItem42, UiComboBoxItem43, UiComboBoxItem44, UiComboBoxItem45, UiComboBoxItem46, UiComboBoxItem47, UiComboBoxItem48})
        Me.cbMes.Location = New System.Drawing.Point(128, 48)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(136, 20)
        Me.cbMes.TabIndex = 36
        Me.cbMes.Text = "cbMes"
        Me.cbMes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbSubempresa
        '
        Me.cbSubempresa.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbSubempresa.Location = New System.Drawing.Point(128, 12)
        Me.cbSubempresa.Name = "cbSubempresa"
        Me.cbSubempresa.Size = New System.Drawing.Size(136, 20)
        Me.cbSubempresa.TabIndex = 38
        Me.cbSubempresa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbSubEmpresa
        '
        Me.lbSubEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lbSubEmpresa.Location = New System.Drawing.Point(23, 12)
        Me.lbSubEmpresa.Name = "lbSubEmpresa"
        Me.lbSubEmpresa.Size = New System.Drawing.Size(78, 20)
        Me.lbSubEmpresa.TabIndex = 37
        Me.lbSubEmpresa.Text = "lbSubEmpresa"
        Me.lbSubEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRepMensualHacienda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 132)
        Me.Controls.Add(Me.cbSubempresa)
        Me.Controls.Add(Me.lbSubEmpresa)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.cbAnio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.lbAño)
        Me.Controls.Add(Me.LbMes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(630, 164)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(630, 164)
        Me.Name = "PRepMensualHacienda"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PRepMensualHacienda"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared gInstance As PRepMensualHacienda = Nothing
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcMensaje As New BASMENLOG.CMensaje
    Public oAcceso As LbAcceso.cAcceso

#Region "FUNCIONES GENERALES"
    Public Shared ReadOnly Property Instance() As PRepMensualHacienda
        Get
            If gInstance Is Nothing OrElse gInstance.IsDisposed Then
                gInstance = New PRepMensualHacienda
            End If
            gInstance.BringToFront()
            Return gInstance
        End Get
    End Property

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        oAcceso = pvAcceso
        Me.ShowDialog()
    End Sub

    Private Sub PRepMensualHacienda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        vcConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.76\sql2008;user id=sa;password='dbsa';initial catalog=PANQUE3.12.0.0")
        vcMensaje = New BASMENLOG.CMensaje
        vcMensaje.LlenarDataSet()
        lbGeneral.cParametros.UsuarioID = "Admin"
        oAcceso = New LbAcceso.cAcceso
        oAcceso.Ejecutar = True
#End If
        iniciarPantalla()
        If oAcceso.Ejecutar = False Then
            btAceptar.Visible = False
            btCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
            btCancelar.Icon = btAceptar.Icon
            cbAnio.Enabled = False
            cbMes.Enabled = False
        End If
    End Sub

    Private Sub LlenarCbSubEmpresa()
        Dim subempresa As New ERMSEMLOG.cSubEmpresa()

        cbSubempresa.Items.Clear()

        For Each R As DataRow In subempresa.RecuperarTabla().Rows
            cbSubempresa.Items.Add(R!NombreEmpresa, R!SubEmpresaID)
        Next


        cbSubempresa.SelectedIndex = 0

    End Sub
    Private Sub iniciarPantalla()
        Me.Text = vcMensaje.RecuperarDescripcion("ERMCEFESC_PRepMensualHacienda")
        Me.LbMes.Text = vcMensaje.RecuperarDescripcion("XMes")
        Me.lbAño.Text = vcMensaje.RecuperarDescripcion("XAnio")
        lbSubEmpresa.Text = vcMensaje.RecuperarDescripcion("XSubEmpresa")

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.cbMes, vcMensaje.RecuperarDescripcion("CEFMesT"))
            .SetToolTip(Me.cbAnio, vcMensaje.RecuperarDescripcion("CEFAnioT"))
            .SetToolTip(Me.cbSubempresa, vcMensaje.RecuperarDescripcion("SEMNombreEmpresaT"))

        End With

        Me.btAceptar.Text = vcMensaje.RecuperarDescripcion("BtAceptar")
        Me.btAceptar.ToolTipText = vcMensaje.RecuperarDescripcion("BtAceptarT")
        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")
        If oAcceso.Ejecutar = False Then
            Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtRegresar")
        Else
            Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtCancelarT")
        End If


        For vlAnio As Integer = 2005 To CInt(Format(Date.Today, "yyyy"))
            Me.cbAnio.Items.Add(vlAnio)
        Next
        LlenarCbSubEmpresa()

        Me.cbAnio.SelectedIndex = Me.cbAnio.Items.Count - 1
        Me.cbMes.SelectedValue = Format(Date.Today, "MM")
    End Sub
#End Region

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Dim vcRRep As New RRepMensualHacienda
        vcRRep.mes = Me.cbMes.SelectedValue
        vcRRep.anio = Me.cbAnio.SelectedValue
        vcRRep.SubEmpresaId = cbSubempresa.SelectedValue
        vcRRep.lbPeriodo.Text = Me.cbMes.SelectedItem.Text & " " & cbAnio.SelectedValue
        vcRRep.CargarForma()
    End Sub

    Private Sub cb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbMes.KeyPress, cbAnio.KeyPress
        e.Handled = True
    End Sub

End Class
