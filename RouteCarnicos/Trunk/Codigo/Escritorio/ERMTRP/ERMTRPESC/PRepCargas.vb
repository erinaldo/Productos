Public Class PRepCargas
    Inherits FormasBase.Mantenimiento01

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
    Friend WithEvents gbRepVenta As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebProductoClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbNombre As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbEsquema As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cboFiltrosProductoClave As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cboFiltrosNombre As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cboFiltrosEsquema As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebEsquema As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbFecha As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbFolio As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cboFecha As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbProductoClave As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents calFecha As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gbRepVenta = New Janus.Windows.EditControls.UIGroupBox
        Me.cbFecha = New Janus.Windows.EditControls.UICheckBox
        Me.cbFolio = New Janus.Windows.EditControls.UICheckBox
        Me.cboFecha = New Janus.Windows.EditControls.UIComboBox
        Me.calFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cbProductoClave = New Janus.Windows.EditControls.UICheckBox
        Me.cboFiltrosEsquema = New Janus.Windows.EditControls.UIComboBox
        Me.cbEsquema = New Janus.Windows.EditControls.UICheckBox
        Me.ebEsquema = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cboFiltrosNombre = New Janus.Windows.EditControls.UIComboBox
        Me.cbNombre = New Janus.Windows.EditControls.UICheckBox
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cboFiltrosProductoClave = New Janus.Windows.EditControls.UIComboBox
        Me.ebProductoClave = New Janus.Windows.GridEX.EditControls.EditBox
        CType(Me.gbRepVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRepVenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(360, 160)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(472, 160)
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(12, 104)
        Me.lbLinea.Size = New System.Drawing.Size(548, 3)
        Me.lbLinea.Visible = False
        '
        'gbRepVenta
        '
        Me.gbRepVenta.Controls.Add(Me.cbFecha)
        Me.gbRepVenta.Controls.Add(Me.cbFolio)
        Me.gbRepVenta.Controls.Add(Me.cboFecha)
        Me.gbRepVenta.Controls.Add(Me.calFecha)
        Me.gbRepVenta.Controls.Add(Me.ebFolio)
        Me.gbRepVenta.Controls.Add(Me.cbProductoClave)
        Me.gbRepVenta.Controls.Add(Me.cboFiltrosEsquema)
        Me.gbRepVenta.Controls.Add(Me.cbEsquema)
        Me.gbRepVenta.Controls.Add(Me.ebEsquema)
        Me.gbRepVenta.Controls.Add(Me.cboFiltrosNombre)
        Me.gbRepVenta.Controls.Add(Me.cbNombre)
        Me.gbRepVenta.Controls.Add(Me.ebNombre)
        Me.gbRepVenta.Controls.Add(Me.cboFiltrosProductoClave)
        Me.gbRepVenta.Controls.Add(Me.ebProductoClave)
        Me.gbRepVenta.Location = New System.Drawing.Point(12, 8)
        Me.gbRepVenta.Name = "gbRepVenta"
        Me.gbRepVenta.Size = New System.Drawing.Size(564, 144)
        Me.gbRepVenta.TabIndex = 20
        Me.gbRepVenta.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbFecha
        '
        Me.cbFecha.Location = New System.Drawing.Point(8, 16)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(132, 20)
        Me.cbFecha.TabIndex = 29
        Me.cbFecha.Text = "cbFecha"
        '
        'cbFolio
        '
        Me.cbFolio.Location = New System.Drawing.Point(8, 40)
        Me.cbFolio.Name = "cbFolio"
        Me.cbFolio.Size = New System.Drawing.Size(132, 20)
        Me.cbFolio.TabIndex = 30
        Me.cbFolio.Text = "cbFolio"
        '
        'cboFecha
        '
        Me.cboFecha.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboFecha.Location = New System.Drawing.Point(144, 16)
        Me.cboFecha.Name = "cboFecha"
        Me.cboFecha.Size = New System.Drawing.Size(128, 20)
        Me.cboFecha.TabIndex = 28
        Me.cboFecha.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'calFecha
        '
        Me.calFecha.CustomFormat = "dd/mm/yyyy"
        '
        '
        '
        Me.calFecha.DropDownCalendar.Name = ""
        Me.calFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.calFecha.Location = New System.Drawing.Point(280, 16)
        Me.calFecha.Name = "calFecha"
        Me.calFecha.Size = New System.Drawing.Size(152, 20)
        Me.calFecha.TabIndex = 29
        Me.calFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.Enabled = False
        Me.ebFolio.Location = New System.Drawing.Point(280, 40)
        Me.ebFolio.MaxLength = 16
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(152, 20)
        Me.ebFolio.TabIndex = 27
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbProductoClave
        '
        Me.cbProductoClave.Location = New System.Drawing.Point(8, 64)
        Me.cbProductoClave.Name = "cbProductoClave"
        Me.cbProductoClave.Size = New System.Drawing.Size(132, 20)
        Me.cbProductoClave.TabIndex = 22
        Me.cbProductoClave.Text = "cbProductoClave"
        '
        'cboFiltrosEsquema
        '
        Me.cboFiltrosEsquema.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboFiltrosEsquema.Location = New System.Drawing.Point(144, 112)
        Me.cboFiltrosEsquema.Name = "cboFiltrosEsquema"
        Me.cboFiltrosEsquema.Size = New System.Drawing.Size(128, 20)
        Me.cboFiltrosEsquema.TabIndex = 26
        Me.cboFiltrosEsquema.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'cbEsquema
        '
        Me.cbEsquema.Location = New System.Drawing.Point(8, 112)
        Me.cbEsquema.Name = "cbEsquema"
        Me.cbEsquema.Size = New System.Drawing.Size(132, 20)
        Me.cbEsquema.TabIndex = 25
        Me.cbEsquema.Text = "cbEsquema"
        '
        'ebEsquema
        '
        Me.ebEsquema.Enabled = False
        Me.ebEsquema.Location = New System.Drawing.Point(280, 112)
        Me.ebEsquema.MaxLength = 32
        Me.ebEsquema.Name = "ebEsquema"
        Me.ebEsquema.Size = New System.Drawing.Size(272, 20)
        Me.ebEsquema.TabIndex = 24
        Me.ebEsquema.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEsquema.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cboFiltrosNombre
        '
        Me.cboFiltrosNombre.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboFiltrosNombre.Location = New System.Drawing.Point(144, 88)
        Me.cboFiltrosNombre.Name = "cboFiltrosNombre"
        Me.cboFiltrosNombre.Size = New System.Drawing.Size(128, 20)
        Me.cboFiltrosNombre.TabIndex = 23
        Me.cboFiltrosNombre.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'cbNombre
        '
        Me.cbNombre.Location = New System.Drawing.Point(8, 88)
        Me.cbNombre.Name = "cbNombre"
        Me.cbNombre.Size = New System.Drawing.Size(132, 20)
        Me.cbNombre.TabIndex = 22
        Me.cbNombre.Text = "cbNombre"
        '
        'ebNombre
        '
        Me.ebNombre.Enabled = False
        Me.ebNombre.Location = New System.Drawing.Point(280, 88)
        Me.ebNombre.MaxLength = 32
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(272, 20)
        Me.ebNombre.TabIndex = 21
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cboFiltrosProductoClave
        '
        Me.cboFiltrosProductoClave.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboFiltrosProductoClave.Location = New System.Drawing.Point(144, 64)
        Me.cboFiltrosProductoClave.Name = "cboFiltrosProductoClave"
        Me.cboFiltrosProductoClave.Size = New System.Drawing.Size(128, 20)
        Me.cboFiltrosProductoClave.TabIndex = 20
        Me.cboFiltrosProductoClave.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebProductoClave
        '
        Me.ebProductoClave.Enabled = False
        Me.ebProductoClave.Location = New System.Drawing.Point(280, 64)
        Me.ebProductoClave.MaxLength = 10
        Me.ebProductoClave.Name = "ebProductoClave"
        Me.ebProductoClave.Size = New System.Drawing.Size(152, 20)
        Me.ebProductoClave.TabIndex = 18
        Me.ebProductoClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebProductoClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PRepCargas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(586, 192)
        Me.Controls.Add(Me.gbRepVenta)
        Me.Name = "PRepCargas"
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.gbRepVenta, 0)
        CType(Me.gbRepVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRepVenta.ResumeLayout(False)
        Me.gbRepVenta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Property CargaID() As String
        Get
            Return sCargaID
        End Get
        Set(ByVal Value As String)
            sCargaID = Value
        End Set
    End Property

    Property UsuID() As String
        Get
            Return sUsuID
        End Get
        Set(ByVal Value As String)
            sUsuID = Value
        End Set
    End Property

    Private sCargaID As String = String.Empty
    Private sUsuID As String = String.Empty
    Private Shared gInstance As PRepCobranza = Nothing
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oMensaje As New BASMENLOG.CMensaje
    Private bClienteCambio As Boolean = False

    Public Shared ReadOnly Property Instance() As PRepCobranza
        Get
            If gInstance Is Nothing OrElse gInstance.IsDisposed Then
                gInstance = New PRepCobranza
            End If
            gInstance.BringToFront()
            Return gInstance
        End Get
    End Property

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        Me.ShowDialog()
    End Sub


    Private Sub PRepCargas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        ' ''<Quitar>
        If oConexion.Estado <> ConnectionState.Open Then
            oConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\sqlexpress;user id=sa;password=dbsa;initial catalog=panque2.28.2")
        End If
        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        lbGeneral.cParametros.UsuarioID = "Admin"
        ' ''<\Quitar>
#End If

        Me.Text = oMensaje.RecuperarDescripcion("ERMReportes_PRepCargas")

        cbFecha.Text = oMensaje.RecuperarDescripcion("XFecha")
        cbFolio.Text = oMensaje.RecuperarDescripcion("XFolio")
        cbProductoClave.Text = oMensaje.RecuperarDescripcion("PROProductoClave")
        cbNombre.Text = oMensaje.RecuperarDescripcion("PRONombre")
        cbEsquema.Text = oMensaje.RecuperarDescripcion("XEsquema")
        Dim loToolTip As New ToolTip
        loToolTip.SetToolTip(calFecha, oMensaje.RecuperarDescripcion("XCamposFiltro").Replace("$0", oMensaje.RecuperarDescripcion("XFecha")))
        loToolTip.SetToolTip(ebFolio, oMensaje.RecuperarDescripcion("XCamposFiltro").Replace("$0", oMensaje.RecuperarDescripcion("XFolio")))
        loToolTip.SetToolTip(ebProductoClave, oMensaje.RecuperarDescripcion("XCamposFiltro").Replace("$0$", oMensaje.RecuperarDescripcion("PROProductoClave")))
        loToolTip.SetToolTip(ebNombre, oMensaje.RecuperarDescripcion("XCamposFiltro").Replace("$0$", oMensaje.RecuperarDescripcion("PRONombre")))
        loToolTip.SetToolTip(ebEsquema, oMensaje.RecuperarDescripcion("XCamposFiltro").Replace("$0$", oMensaje.RecuperarDescripcion("XEsquema")))

        cbFecha.Checked = True
        cbFolio.Checked = False
        cbProductoClave.Checked = False
        cbNombre.Checked = False
        cbEsquema.Checked = False
        cboFecha.Enabled = False
        cboFiltrosProductoClave.Enabled = False
        cboFiltrosNombre.Enabled = False
        cboFiltrosEsquema.Enabled = False
        calFecha.Enabled = True
        ebFolio.Enabled = False
        ebProductoClave.Enabled = False
        ebNombre.Enabled = False
        ebEsquema.Enabled = False
        calFecha.Value = Today.Date

        BtAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        lbGeneral.LlenarComboBox(cboFecha, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cboFiltrosProductoClave, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cboFiltrosNombre, "BFSTRING", 1)
        lbGeneral.LlenarComboBox(cboFiltrosEsquema, "BFSTRING", 1)

    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Try
            Dim oReporte As New RRepCargas
            If Not Validar() Then Exit Sub

            BtAceptar.Enabled = False
            Dim sFecha As String = String.Empty
            Dim sFiltros As String = String.Empty

            If cbFecha.Checked Then
                sFecha = calFecha.Value.ToString("s")
            End If
            CreaCondiciones(sFiltros)
            oReporte.CONSULTAR(sFecha, sCargaID, sFiltros)

            BtAceptar.Enabled = True
        Catch ex As LbControlError.cError
            ex.Mostrar()
            BtAceptar.Enabled = True
        End Try
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub cbProductoClave_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProductoClave.CheckedChanged
        ebProductoClave.Enabled = cbProductoClave.Checked
        cboFiltrosProductoClave.Enabled = cbProductoClave.Checked
    End Sub

    Private Sub cbNombre_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNombre.CheckedChanged
        ebNombre.Enabled = cbNombre.Checked
        cboFiltrosNombre.Enabled = cbNombre.Checked
    End Sub

    Private Sub cbEsquema_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEsquema.CheckedChanged
        ebEsquema.Enabled = cbEsquema.Checked
        cboFiltrosEsquema.Enabled = cbEsquema.Checked
    End Sub

    Private Sub cbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFecha.CheckedChanged
        calFecha.Enabled = cbFecha.Checked
        cbFolio.Checked = Not cbFecha.Checked
    End Sub

    Private Sub cbFolio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFolio.CheckedChanged
        ebFolio.Enabled = cbFolio.Checked
        cbFecha.Checked = Not cbFolio.Checked
    End Sub

    Private Function Validar() As Boolean
        sCargaID = ""
        If cbFolio.Checked Then
            If ebFolio.Text.Trim = String.Empty Then
                MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("XFolio")), MsgBoxStyle.Critical)
                Me.ebFolio.Focus()
                Return False
            Else
                sCargaID = LbConexion.cConexion.Instancia.EjecutarComandoScalar("select TransProdId from TransProd where Folio = '" & ebFolio.Text.Replace("'", "''").Trim & "' and Tipo = 2")
                If sCargaID Is Nothing Then
                    sCargaID = String.Empty
                    MsgBox(oMensaje.RecuperarDescripcion("I0139").Replace("$0$", oMensaje.RecuperarDescripcion("XFolio")).Replace("$1$", oMensaje.RecuperarDescripcion("XCarga")), MsgBoxStyle.Critical)
                    Me.ebFolio.Focus()
                    Return False
                End If
            End If
        End If

        If cbProductoClave.Checked And ebProductoClave.Text.Trim = String.Empty Then
            MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("PROProductoClave")), MsgBoxStyle.Critical)
            Me.ebProductoClave.Focus()
            Return False
        End If

        If cbNombre.Checked And ebNombre.Text.Trim = String.Empty Then
            MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("PRONombre")), MsgBoxStyle.Critical)
            Me.ebNombre.Focus()
            Return False
        End If

        If cbEsquema.Checked And ebEsquema.Text.Trim = String.Empty Then
            MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("XEsquema")), MsgBoxStyle.Critical)
            Me.ebEsquema.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub CreaCondiciones(ByRef parsCondicion As String)
        parsCondicion = String.Empty

        If cbProductoClave.Checked Then
            If parsCondicion.Trim <> String.Empty Then
                parsCondicion &= " and "
            End If
            parsCondicion &= " PRO.ProductoClave " & Operador(cboFiltrosProductoClave.SelectedValue, ebProductoClave.Text.Replace("'", "''"), String.Empty, General.TipoDato.Cadena)
        End If

        If cbNombre.Checked Then
            If parsCondicion.Trim <> String.Empty Then
                parsCondicion &= " and "
            End If
            parsCondicion &= " PRO.Nombre " & Operador(cboFiltrosNombre.SelectedValue, ebNombre.Text.Replace("'", "''"), String.Empty, General.TipoDato.Cadena)
        End If

        If cbEsquema.Checked Then
            If parsCondicion.Trim <> String.Empty Then
                parsCondicion &= " and "
            End If
            parsCondicion &= " ESQ.Nombre " & Operador(cboFiltrosEsquema.SelectedValue, ebEsquema.Text.Replace("'", "''"), String.Empty, General.TipoDato.Cadena)
        End If
    End Sub
End Class
