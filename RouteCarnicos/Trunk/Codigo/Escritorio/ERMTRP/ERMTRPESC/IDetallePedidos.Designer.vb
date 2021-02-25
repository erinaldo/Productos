<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IDetallePedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IDetallePedidos))
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridex1
        '
        Gridex1_DesignTimeLayout.LayoutString = resources.GetString("Gridex1_DesignTimeLayout.LayoutString")
        Me.Gridex1.DesignTimeLayout = Gridex1_DesignTimeLayout
        Me.Gridex1.Location = New System.Drawing.Point(8, 12)
        Me.Gridex1.Size = New System.Drawing.Size(616, 285)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(520, 304)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(12, 304)
        Me.BtCancelar.Visible = False
        '
        'IDetallePedidos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(636, 340)
        Me.Name = "IDetallePedidos"
        Me.Text = "IDetallePedidos"
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
