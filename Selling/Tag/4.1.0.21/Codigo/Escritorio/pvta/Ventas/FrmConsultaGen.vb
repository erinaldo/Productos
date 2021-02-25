Public Class FrmConsultaGen
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents GridConsultaGen As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaGen))
        Me.GridConsultaGen = New Janus.Windows.GridEX.GridEX()
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridConsultaGen
        '
        Me.GridConsultaGen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridConsultaGen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConsultaGen.ColumnAutoResize = True
        Me.GridConsultaGen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridConsultaGen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridConsultaGen.Location = New System.Drawing.Point(0, 0)
        Me.GridConsultaGen.Name = "GridConsultaGen"
        Me.GridConsultaGen.RecordNavigator = True
        Me.GridConsultaGen.Size = New System.Drawing.Size(782, 561)
        Me.GridConsultaGen.TabIndex = 3
        Me.GridConsultaGen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmConsultaGen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GridConsultaGen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmConsultaGen"
        Me.Text = "Consulta "
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

 
End Class
