<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HSubEmpresa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HSubEmpresa))
        Me.btsalir = New Janus.Windows.EditControls.UIButton
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX
        Me.LbFecha = New System.Windows.Forms.Label
        Me.LbUsuario = New System.Windows.Forms.Label
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btsalir
        '
        Me.btsalir.Icon = CType(resources.GetObject("btsalir.Icon"), System.Drawing.Icon)
        Me.btsalir.Location = New System.Drawing.Point(739, 403)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(104, 24)
        Me.btsalir.TabIndex = 4
        Me.btsalir.Text = "Salir"
        Me.btsalir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'GridEX1
        '
        Me.GridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.Location = New System.Drawing.Point(3, 3)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Size = New System.Drawing.Size(840, 368)
        Me.GridEX1.TabIndex = 3
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LbFecha
        '
        Me.LbFecha.Location = New System.Drawing.Point(620, 374)
        Me.LbFecha.Name = "LbFecha"
        Me.LbFecha.Size = New System.Drawing.Size(220, 20)
        Me.LbFecha.TabIndex = 6
        Me.LbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LbUsuario
        '
        Me.LbUsuario.Location = New System.Drawing.Point(0, 374)
        Me.LbUsuario.Name = "LbUsuario"
        Me.LbUsuario.Size = New System.Drawing.Size(176, 20)
        Me.LbUsuario.TabIndex = 5
        '
        'HSubEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 444)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.LbUsuario)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.GridEX1)
        Me.Name = "HSubEmpresa"
        Me.Text = "HSubEmpresa"
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btsalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
End Class
