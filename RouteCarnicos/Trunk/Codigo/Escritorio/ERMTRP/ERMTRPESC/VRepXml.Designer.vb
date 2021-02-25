<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VRepXml
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VRepXml))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btRegresar = New Janus.Windows.EditControls.UIButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(10, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 3)
        Me.Label1.TabIndex = 57
        '
        'btRegresar
        '
        Me.btRegresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btRegresar.Icon = CType(resources.GetObject("btRegresar.Icon"), System.Drawing.Icon)
        Me.btRegresar.Location = New System.Drawing.Point(496, 230)
        Me.btRegresar.Name = "btRegresar"
        Me.btRegresar.Size = New System.Drawing.Size(104, 24)
        Me.btRegresar.TabIndex = 56
        Me.btRegresar.Text = "btRegresar"
        Me.btRegresar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'VRepXml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btRegresar)
        Me.Name = "VRepXml"
        Me.Text = "VRepXml"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btRegresar As Janus.Windows.EditControls.UIButton
End Class
