Public Class FrmConsultaTouch
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAbrir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GridConsultaGen As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaTouch))
        Me.GridConsultaGen = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAbrir = New Janus.Windows.EditControls.UIButton()
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
        Me.GridConsultaGen.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridConsultaGen.Location = New System.Drawing.Point(0, 0)
        Me.GridConsultaGen.Name = "GridConsultaGen"
        Me.GridConsultaGen.RecordNavigator = True
        Me.GridConsultaGen.Size = New System.Drawing.Size(782, 484)
        Me.GridConsultaGen.TabIndex = 3
        Me.GridConsultaGen.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridConsultaGen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(339, 490)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCancelar.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.BtnCancelar.Size = New System.Drawing.Size(206, 68)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "Cerrar"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAbrir
        '
        Me.btnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbrir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAbrir.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrir.Location = New System.Drawing.Point(576, 490)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnAbrir.Office2007CustomColor = System.Drawing.Color.LightGreen
        Me.btnAbrir.Size = New System.Drawing.Size(206, 68)
        Me.btnAbrir.TabIndex = 7
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.ToolTipText = "Abrir el documento seleccionado"
        Me.btnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmConsultaTouch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GridConsultaGen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmConsultaTouch"
        Me.Text = "Consulta "
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public VENClave As String

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub agregar()
        If Not GridConsultaGen.GetValue(0) Is Nothing Then
            VENClave = GridConsultaGen.GetValue("VENClave")
        End If
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        agregar()
    End Sub

    Private Sub GridConsultaGen_DoubleClick(sender As Object, e As EventArgs) Handles GridConsultaGen.DoubleClick
        agregar()
    End Sub
End Class
