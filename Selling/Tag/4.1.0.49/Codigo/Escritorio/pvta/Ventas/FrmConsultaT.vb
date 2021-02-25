Public Class FrmConsultaT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaT))
        Me.GridConsultaGen = New Janus.Windows.GridEX.GridEX()
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridConsultaGen
        '
        Me.GridConsultaGen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConsultaGen.ColumnAutoResize = True
        Me.GridConsultaGen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridConsultaGen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridConsultaGen.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridConsultaGen.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.GridConsultaGen.Location = New System.Drawing.Point(6, 6)
        Me.GridConsultaGen.Name = "GridConsultaGen"
        Me.GridConsultaGen.RecordNavigator = True
        Me.GridConsultaGen.Size = New System.Drawing.Size(705, 329)
        Me.GridConsultaGen.TabIndex = 3
        Me.GridConsultaGen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmConsultaT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(716, 347)
        Me.Controls.Add(Me.GridConsultaGen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmConsultaT"
        Me.Text = "Consulta "
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Intro As Boolean = True

    Public foundRows() As DataRow

    Private bError As Boolean = False
    Public ID As String
    Public Campo As String
    Public ID2 As String = ""
    Public Campo2 As String = ""
    Public AutoSizeForm As Boolean = True

    Private Sub FrmConsultaT_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmConsultaT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridConsultaGen.ColumnAutoResize = AutoSizeForm
        If AutoSizeForm = True Then
            Me.GridConsultaGen.AutoSizeColumns()
        End If
    End Sub

    Private Sub GridConsultaGen_Click(sender As Object, e As EventArgs) Handles GridConsultaGen.Click
        If ID <> "" Then

            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            bError = True
        End If
    End Sub

    Private Sub GridConsultaGen_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridConsultaGen.CurrentCellChanged
        If Not GridConsultaGen.CurrentColumn Is Nothing Then
            GridConsultaGen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub

    Private Sub GridConsultaGen_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridConsultaGen.SelectionChanged
        If Not GridConsultaGen.GetValue(0) Is Nothing Then
            ID = GridConsultaGen.GetValue(Campo)
            If Campo2 <> "" Then
                ID2 = GridConsultaGen.GetValue(Campo2)
            End If
        Else
            ID = ""
            ID2 = ""
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs)

    End Sub
End Class
