Imports BASMENLOG

Public Class Fechas
    Inherits System.Windows.Forms.Form
    Enum TipoFecha
        FechaCaptura = 1
        FechaEntrega = 2
    End Enum

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
    Friend WithEvents GroupBoxSelFecha As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents chbFecha As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbTipoFiltro As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents calFechaIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents calFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents rbtFechaEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFechaCaptura As System.Windows.Forms.RadioButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fechas))
        Me.calFechaIni = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.calFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.GroupBoxSelFecha = New Janus.Windows.EditControls.UIGroupBox
        Me.rbtFechaEntrega = New System.Windows.Forms.RadioButton
        Me.rbtFechaCaptura = New System.Windows.Forms.RadioButton
        Me.cbTipoFiltro = New Janus.Windows.EditControls.UIComboBox
        Me.chbFecha = New Janus.Windows.EditControls.UICheckBox
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        CType(Me.GroupBoxSelFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSelFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'calFechaIni
        '
        '
        '
        '
        Me.calFechaIni.DropDownCalendar.FirstMonth = New Date(2008, 10, 1, 0, 0, 0, 0)
        Me.calFechaIni.DropDownCalendar.Name = ""
        Me.calFechaIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.calFechaIni.Location = New System.Drawing.Point(16, 77)
        Me.calFechaIni.Name = "calFechaIni"
        Me.calFechaIni.Size = New System.Drawing.Size(128, 20)
        Me.calFechaIni.TabIndex = 0
        '
        'calFechaFin
        '
        '
        '
        '
        Me.calFechaFin.DropDownCalendar.FirstMonth = New Date(2008, 10, 1, 0, 0, 0, 0)
        Me.calFechaFin.DropDownCalendar.Name = ""
        Me.calFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.calFechaFin.Location = New System.Drawing.Point(160, 77)
        Me.calFechaFin.Name = "calFechaFin"
        Me.calFechaFin.Size = New System.Drawing.Size(128, 20)
        Me.calFechaFin.TabIndex = 1
        '
        'GroupBoxSelFecha
        '
        Me.GroupBoxSelFecha.Controls.Add(Me.rbtFechaEntrega)
        Me.GroupBoxSelFecha.Controls.Add(Me.rbtFechaCaptura)
        Me.GroupBoxSelFecha.Controls.Add(Me.cbTipoFiltro)
        Me.GroupBoxSelFecha.Controls.Add(Me.chbFecha)
        Me.GroupBoxSelFecha.Controls.Add(Me.calFechaIni)
        Me.GroupBoxSelFecha.Controls.Add(Me.calFechaFin)
        Me.GroupBoxSelFecha.Location = New System.Drawing.Point(8, 8)
        Me.GroupBoxSelFecha.Name = "GroupBoxSelFecha"
        Me.GroupBoxSelFecha.Size = New System.Drawing.Size(304, 120)
        Me.GroupBoxSelFecha.TabIndex = 2
        Me.GroupBoxSelFecha.Text = "Seleccionfecha"
        Me.GroupBoxSelFecha.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbtFechaEntrega
        '
        Me.rbtFechaEntrega.AutoSize = True
        Me.rbtFechaEntrega.Location = New System.Drawing.Point(184, 17)
        Me.rbtFechaEntrega.Name = "rbtFechaEntrega"
        Me.rbtFechaEntrega.Size = New System.Drawing.Size(104, 17)
        Me.rbtFechaEntrega.TabIndex = 5
        Me.rbtFechaEntrega.Text = "rbtFechaEntrega"
        Me.rbtFechaEntrega.UseVisualStyleBackColor = True
        Me.rbtFechaEntrega.Visible = False
        '
        'rbtFechaCaptura
        '
        Me.rbtFechaCaptura.AutoSize = True
        Me.rbtFechaCaptura.Checked = True
        Me.rbtFechaCaptura.Location = New System.Drawing.Point(48, 17)
        Me.rbtFechaCaptura.Name = "rbtFechaCaptura"
        Me.rbtFechaCaptura.Size = New System.Drawing.Size(104, 17)
        Me.rbtFechaCaptura.TabIndex = 4
        Me.rbtFechaCaptura.TabStop = True
        Me.rbtFechaCaptura.Text = "rbtFechaCaptura"
        Me.rbtFechaCaptura.UseVisualStyleBackColor = True
        Me.rbtFechaCaptura.Visible = False
        '
        'cbTipoFiltro
        '
        Me.cbTipoFiltro.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoFiltro.Location = New System.Drawing.Point(48, 39)
        Me.cbTipoFiltro.Name = "cbTipoFiltro"
        Me.cbTipoFiltro.Size = New System.Drawing.Size(240, 20)
        Me.cbTipoFiltro.TabIndex = 3
        '
        'chbFecha
        '
        Me.chbFecha.Location = New System.Drawing.Point(17, 38)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(32, 23)
        Me.chbFecha.TabIndex = 2
        '
        'btAceptar
        '
        Me.btAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(144, 136)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btAceptar.TabIndex = 3
        Me.btAceptar.Text = "Aceptar"
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(232, 136)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btCancelar.TabIndex = 4
        Me.btCancelar.Text = "Cancelar"
        '
        'Fechas
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(322, 168)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.GroupBoxSelFecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fechas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fechas"
        CType(Me.GroupBoxSelFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSelFecha.ResumeLayout(False)
        Me.GroupBoxSelFecha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oMensaje As New CMensaje
    Private sComponente As String = "ERMTRPESC"

    Public Property FechaSeleccion() As TipoFecha
        Get
            If Me.rbtFechaCaptura.Checked Then
                Return TipoFecha.FechaCaptura
            End If

            Return TipoFecha.FechaEntrega
        End Get
        Set(ByVal value As TipoFecha)
            Select Case value
                Case TipoFecha.FechaEntrega
                    Me.rbtFechaEntrega.Checked = True
                Case TipoFecha.FechaCaptura
                    Me.rbtFechaCaptura.Checked = True
            End Select
        End Set
    End Property

    Public WriteOnly Property MostrarFechaSeleccion() As Boolean
        Set(ByVal value As Boolean)
            Me.rbtFechaEntrega.Visible = value
            Me.rbtFechaCaptura.Visible = value
        End Set
    End Property



    Public Function SELECCIONAR(ByRef prTipo As Integer, ByRef prFechaIni As String, ByRef prFechaFin As String) As Boolean
        chbFecha.Checked = (prTipo <> 0)
        If prTipo <> 0 Then
            cbTipoFiltro.SelectedValue = prTipo
            cbTipoFiltro.Enabled = True
            calFechaIni.Enabled = True
            calFechaFin.Enabled = (prTipo = 7)
        Else
            cbTipoFiltro.SelectedValue = 1
            cbTipoFiltro.Enabled = False
            calFechaIni.Enabled = False
            calFechaFin.Enabled = False
        End If
        ConfigurarInterfaz()
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If chbFecha.Checked Then
                prTipo = cbTipoFiltro.SelectedValue
                prFechaIni = calFechaIni.Value.ToString("dd/MM/yyyy")
                prFechaFin = calFechaFin.Value.ToString("dd/MM/yyyy")
            Else
                prTipo = 0
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ConfigurarInterfaz()
        Dim lTootTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & "FFechas")
        lbGeneral.LlenarComboBox(cbTipoFiltro, "BFNUMERI", 1)

        'Titulos Botones
        Me.btAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        Me.btCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        'Titulo Agrupador
        Me.GroupBoxSelFecha.Text = oMensaje.RecuperarDescripcion("XSeleccionarFecha")
        Me.rbtFechaEntrega.Text = oMensaje.RecuperarDescripcion("TRPFechaEntrega")
        Me.rbtFechaCaptura.Text = oMensaje.RecuperarDescripcion("TRPFechaCaptura")

        Dim oToolTip As New ToolTip
        oToolTip.SetToolTip(btAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        oToolTip.SetToolTip(btCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        If chbFecha.Checked Then
            If cbTipoFiltro.SelectedValue = 7 Then
                If calFechaIni.Value > calFechaFin.Value Then
                    MsgBox(oMensaje.RecuperarDescripcion("E0377"), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, oMensaje.RecuperarDescripcion("XMensajeE"))
                    calFechaFin.Focus()
                    Exit Sub
                End If
            End If
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub chbFecha_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged
        cbTipoFiltro.Enabled = chbFecha.Checked
        calFechaIni.Enabled = chbFecha.Checked
        calFechaFin.Enabled = (chbFecha.Checked And cbTipoFiltro.SelectedValue = 7)
    End Sub

    Private Sub cbTipoFiltro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoFiltro.SelectedValueChanged
        calFechaFin.Enabled = cbTipoFiltro.SelectedValue = 7
    End Sub
End Class
