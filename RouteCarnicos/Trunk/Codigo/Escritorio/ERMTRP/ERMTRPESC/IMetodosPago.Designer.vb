<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMetodosPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMetodosPago))
        Dim grCapturaMetodosPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.btCrear = New Janus.Windows.EditControls.UIButton
        Me.btEliminar = New Janus.Windows.EditControls.UIButton
        Me.grCapturaMetodosPago = New Janus.Windows.GridEX.GridEX
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grCapturaMetodosPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridex1
        '
        Gridex1_DesignTimeLayout.LayoutString = resources.GetString("Gridex1_DesignTimeLayout.LayoutString")
        Me.Gridex1.DesignTimeLayout = Gridex1_DesignTimeLayout
        Me.Gridex1.FilterMode = Janus.Windows.GridEX.FilterMode.None
        Me.Gridex1.Hierarchical = True
        Me.Gridex1.Size = New System.Drawing.Size(455, 327)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(247, 343)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(359, 343)
        '
        'btCrear
        '
        Me.btCrear.BackColor = System.Drawing.Color.Transparent
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Location = New System.Drawing.Point(429, 7)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.Size = New System.Drawing.Size(33, 24)
        Me.btCrear.TabIndex = 44
        Me.btCrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btEliminar
        '
        Me.btEliminar.CausesValidation = False
        Me.btEliminar.Icon = CType(resources.GetObject("btEliminar.Icon"), System.Drawing.Icon)
        Me.btEliminar.Location = New System.Drawing.Point(429, 37)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(33, 24)
        Me.btEliminar.TabIndex = 42
        Me.btEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grCapturaMetodosPago
        '
        grCapturaMetodosPago_DesignTimeLayout.LayoutString = resources.GetString("grCapturaMetodosPago_DesignTimeLayout.LayoutString")
        Me.grCapturaMetodosPago.DesignTimeLayout = grCapturaMetodosPago_DesignTimeLayout
        Me.grCapturaMetodosPago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grCapturaMetodosPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grCapturaMetodosPago.GroupByBoxVisible = False
        Me.grCapturaMetodosPago.Location = New System.Drawing.Point(8, 7)
        Me.grCapturaMetodosPago.Name = "grCapturaMetodosPago"
        Me.grCapturaMetodosPago.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grCapturaMetodosPago.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grCapturaMetodosPago.Size = New System.Drawing.Size(416, 327)
        Me.grCapturaMetodosPago.TabIndex = 43
        Me.grCapturaMetodosPago.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grCapturaMetodosPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'IMetodosPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 378)
        Me.Controls.Add(Me.btCrear)
        Me.Controls.Add(Me.btEliminar)
        Me.Controls.Add(Me.grCapturaMetodosPago)
        Me.Name = "IMetodosPago"
        Me.Text = "IMetodosPago"
        Me.Controls.SetChildIndex(Me.grCapturaMetodosPago, 0)
        Me.Controls.SetChildIndex(Me.Gridex1, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.btEliminar, 0)
        Me.Controls.SetChildIndex(Me.btCrear, 0)
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grCapturaMetodosPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btCrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grCapturaMetodosPago As Janus.Windows.GridEX.GridEX
End Class
