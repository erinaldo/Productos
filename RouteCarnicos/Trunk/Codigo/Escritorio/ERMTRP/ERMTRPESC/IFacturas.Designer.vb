<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IFacturas
    Inherits FormasBase.Seleccionar01

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Gridex1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IFacturas))
        Me.btFiltrar = New Janus.Windows.EditControls.UIButton
        Me.lblFecha = New System.Windows.Forms.Label
        Me.cbTipoFiltro = New Janus.Windows.EditControls.UIComboBox
        Me.calFechaIni = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.calFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridex1
        '
        Gridex1_DesignTimeLayout.LayoutString = resources.GetString("Gridex1_DesignTimeLayout.LayoutString")
        Me.Gridex1.DesignTimeLayout = Gridex1_DesignTimeLayout
        Me.Gridex1.Location = New System.Drawing.Point(8, 41)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(408, 303)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(520, 303)
        '
        'btFiltrar
        '
        Me.btFiltrar.Icon = CType(resources.GetObject("btFiltrar.Icon"), System.Drawing.Icon)
        Me.btFiltrar.Location = New System.Drawing.Point(551, 12)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(23, 23)
        Me.btFiltrar.TabIndex = 34
        Me.btFiltrar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Location = New System.Drawing.Point(5, 12)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(118, 20)
        Me.lblFecha.TabIndex = 33
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTipoFiltro
        '
        Me.cbTipoFiltro.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoFiltro.Location = New System.Drawing.Point(129, 12)
        Me.cbTipoFiltro.Name = "cbTipoFiltro"
        Me.cbTipoFiltro.Size = New System.Drawing.Size(152, 20)
        Me.cbTipoFiltro.TabIndex = 32
        '
        'calFechaIni
        '
        '
        '
        '
        Me.calFechaIni.DropDownCalendar.FirstMonth = New Date(2008, 10, 1, 0, 0, 0, 0)
        Me.calFechaIni.DropDownCalendar.Name = ""
        Me.calFechaIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.calFechaIni.Location = New System.Drawing.Point(287, 12)
        Me.calFechaIni.Name = "calFechaIni"
        Me.calFechaIni.Size = New System.Drawing.Size(128, 20)
        Me.calFechaIni.TabIndex = 30
        '
        'calFechaFin
        '
        '
        '
        '
        Me.calFechaFin.DropDownCalendar.FirstMonth = New Date(2008, 10, 1, 0, 0, 0, 0)
        Me.calFechaFin.DropDownCalendar.Name = ""
        Me.calFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.calFechaFin.Enabled = False
        Me.calFechaFin.Location = New System.Drawing.Point(421, 12)
        Me.calFechaFin.Name = "calFechaFin"
        Me.calFechaFin.Size = New System.Drawing.Size(128, 20)
        Me.calFechaFin.TabIndex = 31
        '
        'IFacturas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(636, 340)
        Me.Controls.Add(Me.btFiltrar)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.cbTipoFiltro)
        Me.Controls.Add(Me.calFechaIni)
        Me.Controls.Add(Me.calFechaFin)
        Me.Name = "IFacturas"
        Me.Text = "IFacturas"
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.Gridex1, 0)
        Me.Controls.SetChildIndex(Me.calFechaFin, 0)
        Me.Controls.SetChildIndex(Me.calFechaIni, 0)
        Me.Controls.SetChildIndex(Me.cbTipoFiltro, 0)
        Me.Controls.SetChildIndex(Me.lblFecha, 0)
        Me.Controls.SetChildIndex(Me.btFiltrar, 0)
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btFiltrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cbTipoFiltro As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents calFechaIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents calFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
End Class
