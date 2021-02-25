Public Class MeSearchAgrega
    Inherits System.Windows.Forms.Form

    Private bError As Boolean = False
    Friend WithEvents lblEtiqueta As System.Windows.Forms.Label
    Friend WithEvents Clock As System.Windows.Forms.Timer
    
    
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents GridSearch As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeSearch))
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridSearch = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.lblEtiqueta = New System.Windows.Forms.Label()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Location = New System.Drawing.Point(166, 15)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(605, 20)
        Me.TxtSearch.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 476)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GridSearch
        '
        Me.GridSearch.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSearch.ColumnAutoResize = True
        Me.GridSearch.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSearch.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSearch.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSearch.GroupByBoxVisible = False
        Me.GridSearch.Location = New System.Drawing.Point(3, 9)
        Me.GridSearch.Name = "GridSearch"
        Me.GridSearch.RecordNavigator = True
        Me.GridSearch.Size = New System.Drawing.Size(773, 462)
        Me.GridSearch.TabIndex = 2
        Me.GridSearch.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CmbCampo)
        Me.GroupBox2.Controls.Add(Me.TxtSearch)
        Me.GroupBox2.Controls.Add(Me.lblEtiqueta)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(780, 45)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Todos los que comiencen con:"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 14)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(153, 21)
        Me.CmbCampo.TabIndex = 1
        '
        'lblEtiqueta
        '
        Me.lblEtiqueta.AutoSize = True
        Me.lblEtiqueta.Location = New System.Drawing.Point(30, 18)
        Me.lblEtiqueta.Name = "lblEtiqueta"
        Me.lblEtiqueta.Size = New System.Drawing.Size(103, 13)
        Me.lblEtiqueta.TabIndex = 2
        Me.lblEtiqueta.Text = "Busqueda por Clave"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(688, 527)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar [ F9]"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(592, 527)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir [Esc]"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'MeSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(784, 566)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(180, 126)
        Me.Name = "MeSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeSearch_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub GridSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnOK.PerformClick()
        End If
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        Clock.Stop()
    End Sub

    Private Sub MeSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, GridSearch.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.BtnCancel.PerformClick()
            Case Is = Keys.F9
                Me.BtnOK.PerformClick()
        End Select
    End Sub

    Private Sub TxtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Clock.Stop()
                Me.BtnCancel.PerformClick()
            Case Is = Keys.F9
                Clock.Stop()
                Me.BtnOK.PerformClick()
            Case Else
                Clock.Start()
        End Select

    End Sub

    Private Sub GridSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSearch.DoubleClick
        If Not GridSearch.GetValue(0) Is Nothing Then
            valor = GridSearch.GetValue(0)
            Descripcion = IIf(GridSearch.GetValue(NumColDes).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes))
            Descripcion2 = IIf(GridSearch.GetValue(NumColDes2).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes2))
            If OcultaCol Then
                Columna = GridSearch.GetValue(OcultaColNum)
            End If
            If GridSearch.Tables(0).Columns.Count >= NumColDes3 Then
                Descripcion3 = IIf(GridSearch.GetValue(NumColDes3).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes3))
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub GridSearch_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSearch.SelectionChanged
        If Not GridSearch Is Nothing Then
            If Not GridSearch.GetValue(0) Is Nothing Then
                Me.BtnOK.Enabled = True
            Else
                Me.BtnOK.Enabled = False
            End If
        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not CmbCampo.SelectedValue Is Nothing OrElse Tabla = "" Then
            queryGrid(sp, CmbCampo.SelectedValue, TxtSearch.Text.ToUpper.Trim.Replace("'", "''"), ALMClave, Tipo, ModPOS.CompanyActual, ListaPrecio)
        Else
            Beep()
            MessageBox.Show("�No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
