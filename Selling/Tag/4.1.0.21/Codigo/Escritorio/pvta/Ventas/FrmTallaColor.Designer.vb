<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTallaColor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTallaColor))
        Me.grpTallas = New System.Windows.Forms.GroupBox()
        Me.btnUltTallas = New Janus.Windows.EditControls.UIButton()
        Me.btnIniTallas = New Janus.Windows.EditControls.UIButton()
        Me.btnAntTallas = New Janus.Windows.EditControls.UIButton()
        Me.btnSigTallas = New Janus.Windows.EditControls.UIButton()
        Me.pnlTallas = New System.Windows.Forms.Panel()
        Me.grpColores = New System.Windows.Forms.GroupBox()
        Me.btnIzqColores = New Janus.Windows.EditControls.UIButton()
        Me.btnDerColores = New Janus.Windows.EditControls.UIButton()
        Me.pnlColores = New System.Windows.Forms.Panel()
        Me.grpTallas.SuspendLayout()
        Me.grpColores.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpTallas
        '
        Me.grpTallas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTallas.Controls.Add(Me.btnUltTallas)
        Me.grpTallas.Controls.Add(Me.btnIniTallas)
        Me.grpTallas.Controls.Add(Me.btnAntTallas)
        Me.grpTallas.Controls.Add(Me.btnSigTallas)
        Me.grpTallas.Controls.Add(Me.pnlTallas)
        Me.grpTallas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTallas.ForeColor = System.Drawing.Color.Black
        Me.grpTallas.Location = New System.Drawing.Point(11, 110)
        Me.grpTallas.MinimumSize = New System.Drawing.Size(625, 379)
        Me.grpTallas.Name = "grpTallas"
        Me.grpTallas.Size = New System.Drawing.Size(657, 379)
        Me.grpTallas.TabIndex = 70
        Me.grpTallas.TabStop = False
        Me.grpTallas.Text = "TALLAS"
        '
        'btnUltTallas
        '
        Me.btnUltTallas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUltTallas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltTallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUltTallas.Icon = CType(resources.GetObject("btnUltTallas.Icon"), System.Drawing.Icon)
        Me.btnUltTallas.Location = New System.Drawing.Point(600, 274)
        Me.btnUltTallas.Name = "btnUltTallas"
        Me.btnUltTallas.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnUltTallas.Size = New System.Drawing.Size(50, 77)
        Me.btnUltTallas.TabIndex = 63
        Me.btnUltTallas.ToolTipText = "Ir al Ultimo"
        Me.btnUltTallas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnIniTallas
        '
        Me.btnIniTallas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIniTallas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIniTallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniTallas.Icon = CType(resources.GetObject("btnIniTallas.Icon"), System.Drawing.Icon)
        Me.btnIniTallas.Location = New System.Drawing.Point(600, 19)
        Me.btnIniTallas.Name = "btnIniTallas"
        Me.btnIniTallas.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnIniTallas.Size = New System.Drawing.Size(50, 77)
        Me.btnIniTallas.TabIndex = 62
        Me.btnIniTallas.ToolTipText = "Ir al Primero"
        Me.btnIniTallas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAntTallas
        '
        Me.btnAntTallas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAntTallas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAntTallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAntTallas.Icon = CType(resources.GetObject("btnAntTallas.Icon"), System.Drawing.Icon)
        Me.btnAntTallas.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnAntTallas.Location = New System.Drawing.Point(600, 104)
        Me.btnAntTallas.Name = "btnAntTallas"
        Me.btnAntTallas.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnAntTallas.Size = New System.Drawing.Size(50, 77)
        Me.btnAntTallas.TabIndex = 61
        Me.btnAntTallas.ToolTipText = "Anterior"
        Me.btnAntTallas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSigTallas
        '
        Me.btnSigTallas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSigTallas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSigTallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSigTallas.Icon = CType(resources.GetObject("btnSigTallas.Icon"), System.Drawing.Icon)
        Me.btnSigTallas.Location = New System.Drawing.Point(600, 189)
        Me.btnSigTallas.Name = "btnSigTallas"
        Me.btnSigTallas.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnSigTallas.Size = New System.Drawing.Size(50, 77)
        Me.btnSigTallas.TabIndex = 60
        Me.btnSigTallas.ToolTipText = "Siguiente"
        Me.btnSigTallas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlTallas
        '
        Me.pnlTallas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTallas.AutoScroll = True
        Me.pnlTallas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTallas.Location = New System.Drawing.Point(7, 19)
        Me.pnlTallas.Name = "pnlTallas"
        Me.pnlTallas.Size = New System.Drawing.Size(578, 349)
        Me.pnlTallas.TabIndex = 0
        '
        'grpColores
        '
        Me.grpColores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpColores.Controls.Add(Me.btnIzqColores)
        Me.grpColores.Controls.Add(Me.btnDerColores)
        Me.grpColores.Controls.Add(Me.pnlColores)
        Me.grpColores.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpColores.ForeColor = System.Drawing.Color.Black
        Me.grpColores.Location = New System.Drawing.Point(12, 4)
        Me.grpColores.Name = "grpColores"
        Me.grpColores.Size = New System.Drawing.Size(657, 102)
        Me.grpColores.TabIndex = 71
        Me.grpColores.TabStop = False
        Me.grpColores.Text = "COLORES"
        '
        'btnIzqColores
        '
        Me.btnIzqColores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIzqColores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzqColores.Icon = CType(resources.GetObject("btnIzqColores.Icon"), System.Drawing.Icon)
        Me.btnIzqColores.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnIzqColores.Location = New System.Drawing.Point(2, 20)
        Me.btnIzqColores.Name = "btnIzqColores"
        Me.btnIzqColores.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnIzqColores.Size = New System.Drawing.Size(52, 77)
        Me.btnIzqColores.TabIndex = 61
        Me.btnIzqColores.ToolTipText = "Anterior"
        Me.btnIzqColores.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDerColores
        '
        Me.btnDerColores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDerColores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerColores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerColores.Icon = CType(resources.GetObject("btnDerColores.Icon"), System.Drawing.Icon)
        Me.btnDerColores.Location = New System.Drawing.Point(603, 20)
        Me.btnDerColores.Name = "btnDerColores"
        Me.btnDerColores.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnDerColores.Size = New System.Drawing.Size(50, 77)
        Me.btnDerColores.TabIndex = 60
        Me.btnDerColores.ToolTipText = "Siguiente"
        Me.btnDerColores.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlColores
        '
        Me.pnlColores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlColores.AutoScroll = True
        Me.pnlColores.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlColores.Location = New System.Drawing.Point(57, 20)
        Me.pnlColores.Name = "pnlColores"
        Me.pnlColores.Size = New System.Drawing.Size(544, 77)
        Me.pnlColores.TabIndex = 0
        '
        'FrmTallaColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(681, 493)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpColores)
        Me.Controls.Add(Me.grpTallas)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTallaColor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "FrmTallaColor"
        Me.grpTallas.ResumeLayout(False)
        Me.grpColores.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpTallas As System.Windows.Forms.GroupBox
    Friend WithEvents btnUltTallas As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnIniTallas As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAntTallas As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSigTallas As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlTallas As System.Windows.Forms.Panel
    Friend WithEvents grpColores As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqColores As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerColores As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlColores As System.Windows.Forms.Panel
End Class
