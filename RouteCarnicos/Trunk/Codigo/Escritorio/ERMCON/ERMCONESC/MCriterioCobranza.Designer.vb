<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MCriterioCobranza
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MCriterioCobranza))
        Dim grdAsignadasVta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdNoAsignadasVta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdNoAsignadasFac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdAsignadasFac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.tbCriterioCobranza = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnVenta = New System.Windows.Forms.Panel
        Me.grdAsignadasVta = New Janus.Windows.GridEX.GridEX
        Me.btAbajoVta = New Janus.Windows.EditControls.UIButton
        Me.btArribaVta = New Janus.Windows.EditControls.UIButton
        Me.btDesasignarVta = New Janus.Windows.EditControls.UIButton
        Me.btAsignarVta = New Janus.Windows.EditControls.UIButton
        Me.grdNoAsignadasVta = New Janus.Windows.GridEX.GridEX
        Me.lbNoAsignadasVta = New System.Windows.Forms.Label
        Me.lbAsignadasVta = New System.Windows.Forms.Label
        Me.tpVenta = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnFactura = New System.Windows.Forms.Panel
        Me.grdNoAsignadasFac = New Janus.Windows.GridEX.GridEX
        Me.grdAsignadasFac = New Janus.Windows.GridEX.GridEX
        Me.btAbajoFac = New Janus.Windows.EditControls.UIButton
        Me.btArribaFac = New Janus.Windows.EditControls.UIButton
        Me.btDesasignarFac = New Janus.Windows.EditControls.UIButton
        Me.btAsignarFac = New Janus.Windows.EditControls.UIButton
        Me.lbNoAsignadasFac = New System.Windows.Forms.Label
        Me.lbAsignadasFac = New System.Windows.Forms.Label
        Me.tpFactura = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.tbCriterioCobranza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCriterioCobranza.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.pnVenta.SuspendLayout()
        CType(Me.grdAsignadasVta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNoAsignadasVta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel2.SuspendLayout()
        Me.pnFactura.SuspendLayout()
        CType(Me.grdNoAsignadasFac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAsignadasFac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(455, 449)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 42
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(565, 449)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 43
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'tbCriterioCobranza
        '
        Me.tbCriterioCobranza.CanReorderTabs = False
        Me.tbCriterioCobranza.Controls.Add(Me.TabControlPanel1)
        Me.tbCriterioCobranza.Controls.Add(Me.TabControlPanel2)
        Me.tbCriterioCobranza.Location = New System.Drawing.Point(12, 12)
        Me.tbCriterioCobranza.Name = "tbCriterioCobranza"
        Me.tbCriterioCobranza.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbCriterioCobranza.SelectedTabIndex = 0
        Me.tbCriterioCobranza.Size = New System.Drawing.Size(657, 431)
        Me.tbCriterioCobranza.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.tbCriterioCobranza.TabIndex = 44
        Me.tbCriterioCobranza.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tbCriterioCobranza.Tabs.Add(Me.tpVenta)
        Me.tbCriterioCobranza.Tabs.Add(Me.tpFactura)
        Me.tbCriterioCobranza.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.pnVenta)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(657, 405)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.tpVenta
        '
        'pnVenta
        '
        Me.pnVenta.BackColor = System.Drawing.Color.Transparent
        Me.pnVenta.Controls.Add(Me.grdAsignadasVta)
        Me.pnVenta.Controls.Add(Me.btAbajoVta)
        Me.pnVenta.Controls.Add(Me.btArribaVta)
        Me.pnVenta.Controls.Add(Me.btDesasignarVta)
        Me.pnVenta.Controls.Add(Me.btAsignarVta)
        Me.pnVenta.Controls.Add(Me.grdNoAsignadasVta)
        Me.pnVenta.Controls.Add(Me.lbNoAsignadasVta)
        Me.pnVenta.Controls.Add(Me.lbAsignadasVta)
        Me.pnVenta.Location = New System.Drawing.Point(4, 2)
        Me.pnVenta.Name = "pnVenta"
        Me.pnVenta.Size = New System.Drawing.Size(646, 396)
        Me.pnVenta.TabIndex = 0
        '
        'grdAsignadasVta
        '
        grdAsignadasVta_DesignTimeLayout.LayoutString = resources.GetString("grdAsignadasVta_DesignTimeLayout.LayoutString")
        Me.grdAsignadasVta.DesignTimeLayout = grdAsignadasVta_DesignTimeLayout
        Me.grdAsignadasVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAsignadasVta.GroupByBoxVisible = False
        Me.grdAsignadasVta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdAsignadasVta.Location = New System.Drawing.Point(250, 28)
        Me.grdAsignadasVta.Name = "grdAsignadasVta"
        Me.grdAsignadasVta.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdAsignadasVta.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdAsignadasVta.Size = New System.Drawing.Size(357, 346)
        Me.grdAsignadasVta.TabIndex = 17
        Me.grdAsignadasVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btAbajoVta
        '
        Me.btAbajoVta.Enabled = False
        Me.btAbajoVta.Icon = CType(resources.GetObject("btAbajoVta.Icon"), System.Drawing.Icon)
        Me.btAbajoVta.Location = New System.Drawing.Point(613, 192)
        Me.btAbajoVta.Name = "btAbajoVta"
        Me.btAbajoVta.Size = New System.Drawing.Size(24, 23)
        Me.btAbajoVta.TabIndex = 16
        Me.btAbajoVta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btArribaVta
        '
        Me.btArribaVta.Enabled = False
        Me.btArribaVta.Icon = CType(resources.GetObject("btArribaVta.Icon"), System.Drawing.Icon)
        Me.btArribaVta.Location = New System.Drawing.Point(613, 163)
        Me.btArribaVta.Name = "btArribaVta"
        Me.btArribaVta.Size = New System.Drawing.Size(24, 23)
        Me.btArribaVta.TabIndex = 15
        Me.btArribaVta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btDesasignarVta
        '
        Me.btDesasignarVta.Enabled = False
        Me.btDesasignarVta.Icon = CType(resources.GetObject("btDesasignarVta.Icon"), System.Drawing.Icon)
        Me.btDesasignarVta.Location = New System.Drawing.Point(220, 192)
        Me.btDesasignarVta.Name = "btDesasignarVta"
        Me.btDesasignarVta.Size = New System.Drawing.Size(24, 23)
        Me.btDesasignarVta.TabIndex = 12
        Me.btDesasignarVta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btAsignarVta
        '
        Me.btAsignarVta.Enabled = False
        Me.btAsignarVta.Icon = CType(resources.GetObject("btAsignarVta.Icon"), System.Drawing.Icon)
        Me.btAsignarVta.Location = New System.Drawing.Point(220, 163)
        Me.btAsignarVta.Name = "btAsignarVta"
        Me.btAsignarVta.Size = New System.Drawing.Size(24, 23)
        Me.btAsignarVta.TabIndex = 11
        Me.btAsignarVta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'grdNoAsignadasVta
        '
        Me.grdNoAsignadasVta.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdNoAsignadasVta.AutomaticSort = False
        Me.grdNoAsignadasVta.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        grdNoAsignadasVta_DesignTimeLayout.LayoutString = resources.GetString("grdNoAsignadasVta_DesignTimeLayout.LayoutString")
        Me.grdNoAsignadasVta.DesignTimeLayout = grdNoAsignadasVta_DesignTimeLayout
        Me.grdNoAsignadasVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdNoAsignadasVta.GroupByBoxVisible = False
        Me.grdNoAsignadasVta.Location = New System.Drawing.Point(10, 28)
        Me.grdNoAsignadasVta.Name = "grdNoAsignadasVta"
        Me.grdNoAsignadasVta.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdNoAsignadasVta.Size = New System.Drawing.Size(204, 346)
        Me.grdNoAsignadasVta.TabIndex = 10
        Me.grdNoAsignadasVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNoAsignadasVta
        '
        Me.lbNoAsignadasVta.AutoSize = True
        Me.lbNoAsignadasVta.Location = New System.Drawing.Point(7, 12)
        Me.lbNoAsignadasVta.Name = "lbNoAsignadasVta"
        Me.lbNoAsignadasVta.Size = New System.Drawing.Size(94, 13)
        Me.lbNoAsignadasVta.TabIndex = 9
        Me.lbNoAsignadasVta.Text = "lbNoAsignadasVta"
        '
        'lbAsignadasVta
        '
        Me.lbAsignadasVta.AutoSize = True
        Me.lbAsignadasVta.Location = New System.Drawing.Point(247, 12)
        Me.lbAsignadasVta.Name = "lbAsignadasVta"
        Me.lbAsignadasVta.Size = New System.Drawing.Size(80, 13)
        Me.lbAsignadasVta.TabIndex = 13
        Me.lbAsignadasVta.Text = "lbAsignadasVta"
        '
        'tpVenta
        '
        Me.tpVenta.AttachedControl = Me.TabControlPanel1
        Me.tpVenta.Name = "tpVenta"
        Me.tpVenta.Text = "tpVenta"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.pnFactura)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(657, 405)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.tpFactura
        '
        'pnFactura
        '
        Me.pnFactura.BackColor = System.Drawing.Color.Transparent
        Me.pnFactura.Controls.Add(Me.grdNoAsignadasFac)
        Me.pnFactura.Controls.Add(Me.grdAsignadasFac)
        Me.pnFactura.Controls.Add(Me.btAbajoFac)
        Me.pnFactura.Controls.Add(Me.btArribaFac)
        Me.pnFactura.Controls.Add(Me.btDesasignarFac)
        Me.pnFactura.Controls.Add(Me.btAsignarFac)
        Me.pnFactura.Controls.Add(Me.lbNoAsignadasFac)
        Me.pnFactura.Controls.Add(Me.lbAsignadasFac)
        Me.pnFactura.Location = New System.Drawing.Point(4, 2)
        Me.pnFactura.Name = "pnFactura"
        Me.pnFactura.Size = New System.Drawing.Size(646, 396)
        Me.pnFactura.TabIndex = 1
        '
        'grdNoAsignadasFac
        '
        Me.grdNoAsignadasFac.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdNoAsignadasFac.AutomaticSort = False
        Me.grdNoAsignadasFac.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        grdNoAsignadasFac_DesignTimeLayout.LayoutString = resources.GetString("grdNoAsignadasFac_DesignTimeLayout.LayoutString")
        Me.grdNoAsignadasFac.DesignTimeLayout = grdNoAsignadasFac_DesignTimeLayout
        Me.grdNoAsignadasFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdNoAsignadasFac.GroupByBoxVisible = False
        Me.grdNoAsignadasFac.Location = New System.Drawing.Point(10, 28)
        Me.grdNoAsignadasFac.Name = "grdNoAsignadasFac"
        Me.grdNoAsignadasFac.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdNoAsignadasFac.Size = New System.Drawing.Size(204, 346)
        Me.grdNoAsignadasFac.TabIndex = 19
        Me.grdNoAsignadasFac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grdAsignadasFac
        '
        Me.grdAsignadasFac.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        grdAsignadasFac_DesignTimeLayout.LayoutString = resources.GetString("grdAsignadasFac_DesignTimeLayout.LayoutString")
        Me.grdAsignadasFac.DesignTimeLayout = grdAsignadasFac_DesignTimeLayout
        Me.grdAsignadasFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdAsignadasFac.GroupByBoxVisible = False
        Me.grdAsignadasFac.Location = New System.Drawing.Point(250, 28)
        Me.grdAsignadasFac.Name = "grdAsignadasFac"
        Me.grdAsignadasFac.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdAsignadasFac.Size = New System.Drawing.Size(357, 346)
        Me.grdAsignadasFac.TabIndex = 18
        Me.grdAsignadasFac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btAbajoFac
        '
        Me.btAbajoFac.Enabled = False
        Me.btAbajoFac.Icon = CType(resources.GetObject("btAbajoFac.Icon"), System.Drawing.Icon)
        Me.btAbajoFac.Location = New System.Drawing.Point(613, 192)
        Me.btAbajoFac.Name = "btAbajoFac"
        Me.btAbajoFac.Size = New System.Drawing.Size(24, 23)
        Me.btAbajoFac.TabIndex = 16
        Me.btAbajoFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btArribaFac
        '
        Me.btArribaFac.Enabled = False
        Me.btArribaFac.Icon = CType(resources.GetObject("btArribaFac.Icon"), System.Drawing.Icon)
        Me.btArribaFac.Location = New System.Drawing.Point(613, 163)
        Me.btArribaFac.Name = "btArribaFac"
        Me.btArribaFac.Size = New System.Drawing.Size(24, 23)
        Me.btArribaFac.TabIndex = 15
        Me.btArribaFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btDesasignarFac
        '
        Me.btDesasignarFac.Enabled = False
        Me.btDesasignarFac.Icon = CType(resources.GetObject("btDesasignarFac.Icon"), System.Drawing.Icon)
        Me.btDesasignarFac.Location = New System.Drawing.Point(220, 192)
        Me.btDesasignarFac.Name = "btDesasignarFac"
        Me.btDesasignarFac.Size = New System.Drawing.Size(24, 23)
        Me.btDesasignarFac.TabIndex = 12
        Me.btDesasignarFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btAsignarFac
        '
        Me.btAsignarFac.Enabled = False
        Me.btAsignarFac.Icon = CType(resources.GetObject("btAsignarFac.Icon"), System.Drawing.Icon)
        Me.btAsignarFac.Location = New System.Drawing.Point(220, 163)
        Me.btAsignarFac.Name = "btAsignarFac"
        Me.btAsignarFac.Size = New System.Drawing.Size(24, 23)
        Me.btAsignarFac.TabIndex = 11
        Me.btAsignarFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'lbNoAsignadasFac
        '
        Me.lbNoAsignadasFac.AutoSize = True
        Me.lbNoAsignadasFac.Location = New System.Drawing.Point(7, 12)
        Me.lbNoAsignadasFac.Name = "lbNoAsignadasFac"
        Me.lbNoAsignadasFac.Size = New System.Drawing.Size(96, 13)
        Me.lbNoAsignadasFac.TabIndex = 9
        Me.lbNoAsignadasFac.Text = "lbNoAsignadasFac"
        '
        'lbAsignadasFac
        '
        Me.lbAsignadasFac.AutoSize = True
        Me.lbAsignadasFac.Location = New System.Drawing.Point(247, 12)
        Me.lbAsignadasFac.Name = "lbAsignadasFac"
        Me.lbAsignadasFac.Size = New System.Drawing.Size(82, 13)
        Me.lbAsignadasFac.TabIndex = 13
        Me.lbAsignadasFac.Text = "lbAsignadasFac"
        '
        'tpFactura
        '
        Me.tpFactura.AttachedControl = Me.TabControlPanel2
        Me.tpFactura.Name = "tpFactura"
        Me.tpFactura.Text = "tpFactura"
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        '
        'MCriterioCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 484)
        Me.Controls.Add(Me.tbCriterioCobranza)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MCriterioCobranza"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MCriterioCobranza"
        CType(Me.tbCriterioCobranza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCriterioCobranza.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.pnVenta.ResumeLayout(False)
        Me.pnVenta.PerformLayout()
        CType(Me.grdAsignadasVta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNoAsignadasVta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.pnFactura.ResumeLayout(False)
        Me.pnFactura.PerformLayout()
        CType(Me.grdNoAsignadasFac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAsignadasFac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents tbCriterioCobranza As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents pnVenta As System.Windows.Forms.Panel
    Friend WithEvents btAbajoVta As Janus.Windows.EditControls.UIButton
    Friend WithEvents btArribaVta As Janus.Windows.EditControls.UIButton
    Friend WithEvents btDesasignarVta As Janus.Windows.EditControls.UIButton
    Friend WithEvents btAsignarVta As Janus.Windows.EditControls.UIButton
    Friend WithEvents grdNoAsignadasVta As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbNoAsignadasVta As System.Windows.Forms.Label
    Friend WithEvents lbAsignadasVta As System.Windows.Forms.Label
    Friend WithEvents tpVenta As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tpFactura As DevComponents.DotNetBar.TabItem
    Friend WithEvents pnFactura As System.Windows.Forms.Panel
    Friend WithEvents btAbajoFac As Janus.Windows.EditControls.UIButton
    Friend WithEvents btArribaFac As Janus.Windows.EditControls.UIButton
    Friend WithEvents btDesasignarFac As Janus.Windows.EditControls.UIButton
    Friend WithEvents btAsignarFac As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbNoAsignadasFac As System.Windows.Forms.Label
    Friend WithEvents lbAsignadasFac As System.Windows.Forms.Label
    Friend WithEvents grdAsignadasVta As Janus.Windows.GridEX.GridEX
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grdAsignadasFac As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdNoAsignadasFac As Janus.Windows.GridEX.GridEX
End Class
