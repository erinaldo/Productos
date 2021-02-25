

Public Class PRepXMLFiltro
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
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbRFC As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbRazonSocial As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbFechaExpedicion As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbFolio As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbSerie As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebRazonSocial As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSerie As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chRFC As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chRazonSocial As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chSerie As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chFolio As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chEnviarFactura As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chFechaExpedicion As Janus.Windows.EditControls.UICheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRepXMLFiltro))
        Me.cbRFC = New Janus.Windows.EditControls.UIComboBox
        Me.cbRazonSocial = New Janus.Windows.EditControls.UIComboBox
        Me.cbFechaExpedicion = New Janus.Windows.EditControls.UIComboBox
        Me.cbFolio = New Janus.Windows.EditControls.UIComboBox
        Me.cbSerie = New Janus.Windows.EditControls.UIComboBox
        Me.btGuardar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebRazonSocial = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebSerie = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.ebFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.chRFC = New Janus.Windows.EditControls.UICheckBox
        Me.chRazonSocial = New Janus.Windows.EditControls.UICheckBox
        Me.chSerie = New Janus.Windows.EditControls.UICheckBox
        Me.chFolio = New Janus.Windows.EditControls.UICheckBox
        Me.chFechaExpedicion = New Janus.Windows.EditControls.UICheckBox
        Me.chEnviarFactura = New Janus.Windows.EditControls.UICheckBox
        Me.SuspendLayout()
        '
        'cbRFC
        '
        Me.cbRFC.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbRFC.Location = New System.Drawing.Point(128, 16)
        Me.cbRFC.Name = "cbRFC"
        Me.cbRFC.Size = New System.Drawing.Size(128, 20)
        Me.cbRFC.TabIndex = 18
        Me.cbRFC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbRazonSocial
        '
        Me.cbRazonSocial.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbRazonSocial.Location = New System.Drawing.Point(128, 48)
        Me.cbRazonSocial.Name = "cbRazonSocial"
        Me.cbRazonSocial.Size = New System.Drawing.Size(128, 20)
        Me.cbRazonSocial.TabIndex = 20
        Me.cbRazonSocial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbFechaExpedicion
        '
        Me.cbFechaExpedicion.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFechaExpedicion.Location = New System.Drawing.Point(128, 144)
        Me.cbFechaExpedicion.Name = "cbFechaExpedicion"
        Me.cbFechaExpedicion.Size = New System.Drawing.Size(128, 20)
        Me.cbFechaExpedicion.TabIndex = 26
        Me.cbFechaExpedicion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbFolio
        '
        Me.cbFolio.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFolio.Location = New System.Drawing.Point(128, 112)
        Me.cbFolio.Name = "cbFolio"
        Me.cbFolio.Size = New System.Drawing.Size(128, 20)
        Me.cbFolio.TabIndex = 28
        Me.cbFolio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbSerie
        '
        Me.cbSerie.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbSerie.Location = New System.Drawing.Point(128, 80)
        Me.cbSerie.Name = "cbSerie"
        Me.cbSerie.Size = New System.Drawing.Size(128, 20)
        Me.cbSerie.TabIndex = 30
        Me.cbSerie.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btGuardar
        '
        Me.btGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGuardar.Icon = CType(resources.GetObject("btGuardar.Icon"), System.Drawing.Icon)
        Me.btGuardar.Location = New System.Drawing.Point(384, 214)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(104, 24)
        Me.btGuardar.TabIndex = 53
        Me.btGuardar.Text = "btGuardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(494, 214)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 54
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebRFC
        '
        Me.ebRFC.Location = New System.Drawing.Point(264, 16)
        Me.ebRFC.MaxLength = 64
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.Size = New System.Drawing.Size(328, 20)
        Me.ebRFC.TabIndex = 55
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebRazonSocial
        '
        Me.ebRazonSocial.Location = New System.Drawing.Point(264, 48)
        Me.ebRazonSocial.MaxLength = 64
        Me.ebRazonSocial.Name = "ebRazonSocial"
        Me.ebRazonSocial.Size = New System.Drawing.Size(328, 20)
        Me.ebRazonSocial.TabIndex = 56
        Me.ebRazonSocial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRazonSocial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebSerie
        '
        Me.ebSerie.Location = New System.Drawing.Point(264, 80)
        Me.ebSerie.MaxLength = 64
        Me.ebSerie.Name = "ebSerie"
        Me.ebSerie.Size = New System.Drawing.Size(328, 20)
        Me.ebSerie.TabIndex = 57
        Me.ebSerie.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSerie.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebFolio
        '
        Me.ebFolio.Location = New System.Drawing.Point(264, 112)
        Me.ebFolio.MaxLength = 64
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(328, 20)
        Me.ebFolio.TabIndex = 58
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebFechaInicio
        '
        Me.ebFechaInicio.CustomFormat = "dd/mm/yyyy"
        '
        '
        '
        Me.ebFechaInicio.DropDownCalendar.FirstMonth = New Date(2007, 8, 1, 0, 0, 0, 0)
        Me.ebFechaInicio.DropDownCalendar.Name = ""
        Me.ebFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ebFechaInicio.Location = New System.Drawing.Point(264, 144)
        Me.ebFechaInicio.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.ebFechaInicio.Name = "ebFechaInicio"
        Me.ebFechaInicio.Size = New System.Drawing.Size(155, 20)
        Me.ebFechaInicio.TabIndex = 59
        Me.ebFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'ebFechaFin
        '
        Me.ebFechaFin.CustomFormat = "dd/mm/yyyy"
        '
        '
        '
        Me.ebFechaFin.DropDownCalendar.FirstMonth = New Date(2007, 8, 1, 0, 0, 0, 0)
        Me.ebFechaFin.DropDownCalendar.Name = ""
        Me.ebFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ebFechaFin.Enabled = False
        Me.ebFechaFin.Location = New System.Drawing.Point(436, 144)
        Me.ebFechaFin.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.ebFechaFin.Name = "ebFechaFin"
        Me.ebFechaFin.Size = New System.Drawing.Size(155, 20)
        Me.ebFechaFin.TabIndex = 60
        Me.ebFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(14, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(584, 3)
        Me.Label1.TabIndex = 61
        '
        'chRFC
        '
        Me.chRFC.BackColor = System.Drawing.Color.Transparent
        Me.chRFC.Location = New System.Drawing.Point(16, 16)
        Me.chRFC.Name = "chRFC"
        Me.chRFC.Size = New System.Drawing.Size(112, 23)
        Me.chRFC.TabIndex = 62
        Me.chRFC.Text = "chRFC"
        Me.chRFC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chRazonSocial
        '
        Me.chRazonSocial.BackColor = System.Drawing.Color.Transparent
        Me.chRazonSocial.Location = New System.Drawing.Point(16, 48)
        Me.chRazonSocial.Name = "chRazonSocial"
        Me.chRazonSocial.Size = New System.Drawing.Size(112, 23)
        Me.chRazonSocial.TabIndex = 63
        Me.chRazonSocial.Text = "chRazonSocial"
        Me.chRazonSocial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chSerie
        '
        Me.chSerie.BackColor = System.Drawing.Color.Transparent
        Me.chSerie.Location = New System.Drawing.Point(16, 80)
        Me.chSerie.Name = "chSerie"
        Me.chSerie.Size = New System.Drawing.Size(112, 23)
        Me.chSerie.TabIndex = 64
        Me.chSerie.Text = "chSerie"
        Me.chSerie.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chFolio
        '
        Me.chFolio.BackColor = System.Drawing.Color.Transparent
        Me.chFolio.Location = New System.Drawing.Point(16, 112)
        Me.chFolio.Name = "chFolio"
        Me.chFolio.Size = New System.Drawing.Size(112, 23)
        Me.chFolio.TabIndex = 65
        Me.chFolio.Text = "chFolio"
        Me.chFolio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chFechaExpedicion
        '
        Me.chFechaExpedicion.BackColor = System.Drawing.Color.Transparent
        Me.chFechaExpedicion.Location = New System.Drawing.Point(16, 144)
        Me.chFechaExpedicion.Name = "chFechaExpedicion"
        Me.chFechaExpedicion.Size = New System.Drawing.Size(112, 23)
        Me.chFechaExpedicion.TabIndex = 66
        Me.chFechaExpedicion.Text = "chFechaExpedicion"
        Me.chFechaExpedicion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chEnviarFactura
        '
        Me.chEnviarFactura.BackColor = System.Drawing.Color.Transparent
        Me.chEnviarFactura.Location = New System.Drawing.Point(16, 173)
        Me.chEnviarFactura.Name = "chEnviarFactura"
        Me.chEnviarFactura.Size = New System.Drawing.Size(112, 23)
        Me.chEnviarFactura.TabIndex = 67
        Me.chEnviarFactura.Text = "chEnviarFactura"
        Me.chEnviarFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PRepXMLFiltro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(610, 250)
        Me.Controls.Add(Me.chEnviarFactura)
        Me.Controls.Add(Me.chFechaExpedicion)
        Me.Controls.Add(Me.chFolio)
        Me.Controls.Add(Me.chSerie)
        Me.Controls.Add(Me.chRazonSocial)
        Me.Controls.Add(Me.chRFC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ebFechaFin)
        Me.Controls.Add(Me.ebFechaInicio)
        Me.Controls.Add(Me.ebFolio)
        Me.Controls.Add(Me.ebSerie)
        Me.Controls.Add(Me.ebRazonSocial)
        Me.Controls.Add(Me.ebRFC)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.cbSerie)
        Me.Controls.Add(Me.cbFolio)
        Me.Controls.Add(Me.cbFechaExpedicion)
        Me.Controls.Add(Me.cbRazonSocial)
        Me.Controls.Add(Me.cbRFC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(616, 276)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(616, 276)
        Me.Name = "PRepXMLFiltro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PRepXMLFiltro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private vcMensaje As BASMENLOG.CMensaje
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private Shared gInstance As PRepXMLFiltro = Nothing
#Region "FUNCIONES GENERALES"

    Public Shared ReadOnly Property Instance() As PRepXMLFiltro
        Get
            If gInstance Is Nothing OrElse gInstance.IsDisposed Then
                gInstance = New PRepXMLFiltro
            End If
            gInstance.BringToFront()
            Return gInstance
        End Get
    End Property

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        Me.ShowDialog()
    End Sub

    Private Sub PRepXMLFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.179\SQL2008b;user id=sa;password=dbsa;initial catalog=Route")
                lbGeneral.cParametros.UsuarioID = "Admin"
#End If
        vcMensaje = New BASMENLOG.CMensaje
        vcMensaje.LlenarDataSet()
        IniciarPantalla()
        LimpiarCampos()
    End Sub

    Private Sub IniciarPantalla()
        Me.Text = vcMensaje.RecuperarDescripcion("ERMTRPESC_PRepXMLFiltro")
        Me.chRFC.Text = vcMensaje.RecuperarDescripcion("CEERFC")
        Me.chRazonSocial.Text = vcMensaje.RecuperarDescripcion("TRPRazonSocial")
        Me.chSerie.Text = vcMensaje.RecuperarDescripcion("FOSSerie")
        Me.chFolio.Text = vcMensaje.RecuperarDescripcion("TRPFolio")
        Me.chFechaExpedicion.Text = vcMensaje.RecuperarDescripcion("TRPFechaExpedicion")
        Me.chEnviarFactura.Text = vcMensaje.RecuperarDescripcion("CEFEnviarAdenda")

        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")
        Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtCancelarT")
        Me.btGuardar.Text = vcMensaje.RecuperarDescripcion("BtAceptar")
        Me.btGuardar.ToolTipText = vcMensaje.RecuperarDescripcion("BtAceptarT")

        lbGeneral.LlenarComboBox(cbRFC, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cbRazonSocial, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cbSerie, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cbFolio, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cbFechaExpedicion, "BFNUMERI", 1)

        Dim vlToolTip As New ToolTip
        With vlToolTip
            .SetToolTip(Me.cbRFC, vcMensaje.RecuperarDescripcion("CRSTipoCondicionT"))
            .SetToolTip(Me.cbRazonSocial, vcMensaje.RecuperarDescripcion("CRSTipoCondicionT"))
            .SetToolTip(Me.cbSerie, vcMensaje.RecuperarDescripcion("CRSTipoCondicionT"))
            .SetToolTip(Me.cbFolio, vcMensaje.RecuperarDescripcion("CRSTipoCondicionT"))
            .SetToolTip(Me.cbFechaExpedicion, vcMensaje.RecuperarDescripcion("CRSTipoCondicionT"))

            .SetToolTip(Me.ebRFC, vcMensaje.RecuperarDescripcion("ROCTipoCondicionT"))
            .SetToolTip(Me.ebRazonSocial, vcMensaje.RecuperarDescripcion("ROCTipoCondicionT"))
            .SetToolTip(Me.ebSerie, vcMensaje.RecuperarDescripcion("ROCTipoCondicionT"))
            .SetToolTip(Me.ebFolio, vcMensaje.RecuperarDescripcion("ROCTipoCondicionT"))
            .SetToolTip(Me.ebFechaInicio, vcMensaje.RecuperarDescripcion("CEFFechaInicialFiltro"))
            .SetToolTip(Me.ebFechaFin, vcMensaje.RecuperarDescripcion("CEFFechaFinalFiltro"))
        End With

        Me.chRFC.ToolTipText = vcMensaje.RecuperarDescripcion("CEFRFCT")
        Me.chRazonSocial.ToolTipText = vcMensaje.RecuperarDescripcion("CEFRazonSocialT")
        Me.chSerie.ToolTipText = vcMensaje.RecuperarDescripcion("CEFSerieT")
        Me.chFolio.ToolTipText = vcMensaje.RecuperarDescripcion("CEFFolioT")
        Me.chFechaExpedicion.ToolTipText = vcMensaje.RecuperarDescripcion("CEFFechaExpedicionT")
        Me.chEnviarFactura.ToolTipText = vcMensaje.RecuperarDescripcion("CEFEnviarAdendaT")
    End Sub

    Private Sub LimpiarCampos()
        chRFC.Checked = False
        chRazonSocial.Checked = False
        chSerie.Checked = False
        chFolio.Checked = False
        chFechaExpedicion.Checked = False

        cbRFC.SelectedValue = 1
        cbRazonSocial.SelectedValue = 1
        cbSerie.SelectedValue = 1
        cbFolio.SelectedValue = 1
        cbFechaExpedicion.SelectedValue = 1

        ebRFC.Text = String.Empty
        ebRazonSocial.Text = String.Empty
        ebSerie.Text = String.Empty
        ebFolio.Text = String.Empty
        ebFechaInicio.Value = Today
        ebFechaFin.Value = Today
    End Sub

    Public Function ValidarCampos() As String
        Dim vlFiltro As String = ""
        Dim oTransProd As New ERMTRPLOG.cTransProd

        If Me.chRFC.Checked Then
            If Me.ebRFC.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.chRFC.Text, False)}, Me.ebRFC.Name)
            Else
                vlFiltro = " AND TDF.RFC " & oTransProd.Operador(Me.cbRFC.SelectedValue, Me.ebRFC.Text, String.Empty, ERMTRPLOG.cTransProd.TipoDato.Cadena)
            End If
        End If

        If Me.chRazonSocial.Checked Then
            If Me.ebRazonSocial.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.chRazonSocial.Text, False)}, Me.ebRazonSocial.Name)
            Else
                vlFiltro &= " AND TDF.RazonSocial " & oTransProd.Operador(Me.cbRazonSocial.SelectedValue, Me.ebRazonSocial.Text, String.Empty, ERMTRPLOG.cTransProd.TipoDato.Cadena)
            End If
        End If

        If Me.chSerie.Checked Then
            If Me.ebSerie.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.chSerie.Text, False)}, Me.ebSerie.Name)
            Else
                vlFiltro &= " AND TDF.serie " & oTransProd.Operador(Me.cbSerie.SelectedValue, Me.ebSerie.Text, String.Empty, ERMTRPLOG.cTransProd.TipoDato.Cadena)
            End If
        End If

        If Me.chFolio.Checked Then
            If Me.ebFolio.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.chFolio.Text, False)}, Me.ebFolio.Name)
            Else
                vlFiltro &= " AND substring(TRP.folio, datalength(TDF.serie)+1, datalength(TRP.folio)) " & oTransProd.Operador(Me.cbFolio.SelectedValue, Me.ebFolio.Text, String.Empty, ERMTRPLOG.cTransProd.TipoDato.Cadena)
            End If
        End If

        If Me.chFechaExpedicion.Checked Then

            If Me.ebFechaInicio.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.chFechaExpedicion.Text, False)}, Me.ebFechaInicio.Name)
            ElseIf Me.cbFechaExpedicion.SelectedValue = 7 AndAlso Me.ebFechaInicio.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.chFechaExpedicion.Text, False)}, Me.ebFechaFin.Name)
            End If

            vlFiltro &= " AND TRP.FechaHoraAlta " & oTransProd.Operador(Me.cbFechaExpedicion.SelectedValue, Me.ebFechaInicio.Value, Me.ebFechaFin.Value, ERMTRPLOG.cTransProd.TipoDato.Fecha)
        End If

        Return vlFiltro
    End Function

    Private Sub PonerFoco(ByVal pvNombre As String)
        For Each obj As Object In Me.Controls
            Select Case obj.GetType.Name
                Case "EditBox"
                    If obj.name = pvNombre Then
                        obj.focus()
                        Exit For
                    End If
            End Select
        Next
    End Sub
#End Region

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Dim filtro As String
        Try
            filtro = validarCampos()
        Catch ex As LbControlError.cError
            ex.Mostrar()
            ponerFoco(ex.Source)
            Exit Sub
        End Try

        Dim oTransprod As New ERMTRPLOG.cTransProd
        Dim oMensaje As New BASMENLOG.CMensaje
        Dim vlDt As DataTable = oTransprod.obtenerFacturasElectronicas(filtro)

        If vlDt.Rows.Count <= 0 Then
            MsgBox(oMensaje.RecuperarDescripcion("E0034"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeP"))
            Exit Sub
        End If
        If filtro = "" Then
            If MsgBox(oMensaje.RecuperarDescripcion("P0201"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim rep As New RRepXMLFiltro(chEnviarFactura.Checked)
        rep.CargarForma(vlDt.Rows.Count, filtro)

    End Sub

    Private Sub cbFechaExpedicion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFechaExpedicion.SelectedIndexChanged
        If cbFechaExpedicion.SelectedValue = 7 Then
            Me.ebFechaFin.Enabled = True
        Else
            Me.ebFechaFin.Enabled = False
        End If
    End Sub
End Class
