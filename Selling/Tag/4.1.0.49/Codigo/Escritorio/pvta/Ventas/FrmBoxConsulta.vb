Public Class FrmBoxConsulta
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GridConsultaGen As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBoxConsulta))
        Me.GridConsultaGen = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
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
        Me.GridConsultaGen.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.GridConsultaGen.Location = New System.Drawing.Point(6, 67)
        Me.GridConsultaGen.Name = "GridConsultaGen"
        Me.GridConsultaGen.RecordNavigator = True
        Me.GridConsultaGen.Size = New System.Drawing.Size(873, 268)
        Me.GridConsultaGen.TabIndex = 3
        Me.GridConsultaGen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(789, 12)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(87, 22)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(242, 20)
        Me.txtClave.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(3, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 15)
        Me.Label17.TabIndex = 122
        Me.Label17.Text = "Clave"
        '
        'FrmBoxConsulta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 347)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GridConsultaGen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmBoxConsulta"
        Me.Text = "Consulta "
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Intro As Boolean = True
    Public dtConsulta As DataTable

    Private bError As Boolean = False
    Public ObjetoCaptura As String
    Public ID, ID2 As String
    Public Campo As String
    Public Campo2 As String = ""
    Public AutoSizeForm As Boolean = True

    Private Sub FrmBoxConsulta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmBoxConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GridConsultaGen.DataSource = dtConsulta
        GridConsultaGen.RetrieveStructure(True)
        GridConsultaGen.GroupByBoxVisible = False
        GridConsultaGen.RootTable.Columns(Campo).Visible = False
        GridConsultaGen.ColumnAutoResize = AutoSizeForm
        If AutoSizeForm = True Then
            Me.GridConsultaGen.AutoSizeColumns()
        End If
    End Sub

    Private Sub GridConsultaGen_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridConsultaGen.CurrentCellChanged
        If Not GridConsultaGen.CurrentColumn Is Nothing Then
            GridConsultaGen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub


    Private Sub recuperaProveedor(ByVal sClave As String)
        Dim foundRows() As Data.DataRow
        foundRows = dtConsulta.Select("Clave = '" & txtClave.Text.Trim & "'")

        If foundRows.Length = 1 Then
            ID = foundRows(0)(Campo)

            If Campo2 <> "" Then
                ID2 = foundRows(0)(Campo2)
            End If
        Else
            MessageBox.Show("La Clave de " & ObjetoCaptura & " no se encuentra dentro del listado de elegibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bError = True
        End If
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If txtClave.Text <> "" AndAlso ID = "" Then
            recuperaProveedor(txtClave.Text)
        End If

        If ID <> "" Then

            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Else
            bError = True
            MessageBox.Show("Debe capturar la Clave del " & ObjetoCaptura, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

   

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnGuardar.PerformClick()
        End If
    End Sub

   
End Class
