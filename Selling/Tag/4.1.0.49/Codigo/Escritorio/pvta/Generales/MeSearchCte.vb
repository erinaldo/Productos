Public Class MeSearchCte
    Inherits System.Windows.Forms.Form

    Public MaskCte As Integer = 0
    Public Prefijo As String = ""

    Public CompaniaRequerido As Boolean = False
    Public valor As Object
    Public Descripcion As String
    Public RequiereCaja As Boolean = False
    Public Caja As Boolean

    Private sp, Campo, Tabla As String
    Public OcultaID As Boolean = False
    Private bError As Boolean = False
    Private bLoad As Boolean = False
    Private FechaIni, FechaFin As DateTime

    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Clock As System.Windows.Forms.Timer




    Public WriteOnly Property ProcedimientoAlmacenado() As String
        Set(ByVal Value As String)
            sp = Value
        End Set
    End Property


    Public WriteOnly Property TablaCmb() As String
        Set(ByVal Value As String)
            Tabla = Value
        End Set
    End Property

    Public WriteOnly Property CampoCmb() As String
        Set(ByVal Value As String)
            Campo = Value
        End Set
    End Property

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeSearchCte))
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridSearch = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbInicial = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbFinal = New System.Windows.Forms.DateTimePicker()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Location = New System.Drawing.Point(160, 18)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(307, 20)
        Me.TxtSearch.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 226)
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
        Me.GridSearch.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridSearch.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSearch.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSearch.GroupByBoxVisible = False
        Me.GridSearch.Location = New System.Drawing.Point(3, 9)
        Me.GridSearch.Name = "GridSearch"
        Me.GridSearch.RecordNavigator = True
        Me.GridSearch.Size = New System.Drawing.Size(702, 212)
        Me.GridSearch.TabIndex = 2
        Me.GridSearch.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CmbCampo)
        Me.GroupBox2.Controls.Add(Me.TxtSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(234, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 45)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Todos los que comiencen con:"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(4, 17)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(153, 21)
        Me.CmbCampo.TabIndex = 1
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(621, 283)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(525, 283)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbInicial)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(110, 45)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inicio"
        '
        'cmbInicial
        '
        Me.cmbInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbInicial.CustomFormat = "yyyyMMdd"
        Me.cmbInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbInicial.Location = New System.Drawing.Point(5, 18)
        Me.cmbInicial.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbInicial.Name = "cmbInicial"
        Me.cmbInicial.Size = New System.Drawing.Size(100, 20)
        Me.cmbInicial.TabIndex = 48
        Me.cmbInicial.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbFinal)
        Me.GroupBox4.Location = New System.Drawing.Point(118, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(110, 45)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Final"
        '
        'cmbFinal
        '
        Me.cmbFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFinal.CustomFormat = "yyyyMMdd"
        Me.cmbFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFinal.Location = New System.Drawing.Point(5, 18)
        Me.cmbFinal.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFinal.Name = "cmbFinal"
        Me.cmbFinal.Size = New System.Drawing.Size(100, 20)
        Me.cmbFinal.TabIndex = 48
        Me.cmbFinal.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-1, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(131, 298)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 20)
        Me.TxtMaxHits.TabIndex = 86
        Me.TxtMaxHits.Text = "1,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 1000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'MeSearchCte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(713, 326)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMaxHits)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(180, 126)
        Me.Name = "MeSearchCte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub loadPage()

        If Not CmbCampo.SelectedValue Is Nothing Then
            If cmbInicial.Value <= cmbFinal.Value Then
                If TxtSearch.Text <> "" Then

                    Clock.Stop()

                    FechaIni = cmbInicial.Value
                    FechaFin = cmbFinal.Value.AddHours(23.9999)


                    If MaskCte = 1 AndAlso CmbCampo.SelectedValue = "1" Then
                        If TxtSearch.Text.Split("-").Length = 2 Then
                            If IsNumeric(TxtSearch.Text.Split("-")(0)) AndAlso IsNumeric(TxtSearch.Text.Split("-")(1)) Then

                                Dim sSucursal As String
                                Dim sClaveCte As String

                                sSucursal = String.Format("{0:000}", Val(CDbl(TxtSearch.Text.Split("-")(0))))
                                sClaveCte = String.Format("{0:0000000}", Val(CDbl(TxtSearch.Text.Split("-")(1))))


                                TxtSearch.Text = sSucursal & "-" & sClaveCte
                            End If
                        End If
                    End If


                    If CompaniaRequerido Then
                        If RequiereCaja = True Then
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", CmbCampo.SelectedValue, "@Busqueda", TxtSearch.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@Caja", Caja, "@FechaIni", FechaIni, "@FechaFin", FechaFin, "@Max", CInt(TxtMaxHits.Text))
                        Else
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", CmbCampo.SelectedValue, "@Busqueda", TxtSearch.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@FechaIni", FechaIni, "@FechaFin", FechaFin, "@Max", CInt(TxtMaxHits.Text))
                        End If
                    Else
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", CmbCampo.SelectedValue, "@Busqueda", TxtSearch.Text.ToUpper.Trim.Replace("'", "''"), "@FechaIni", FechaIni, "@FechaFin", FechaFin, "@Max", CInt(TxtMaxHits.Text))
                    End If
                    If OcultaID AndAlso GridSearch.RootTable.Columns.Count > 0 Then
                        Me.GridSearch.RootTable.Columns("ID").Visible = False
                    End If
                End If
            Else
                Clock.Stop()
                Beep()
                MessageBox.Show("¡La fecha final, es menor a la inicial!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Clock.Stop()
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub MeSearchDate_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If Not GridSearch.DataSource Is Nothing Then
            If Not GridSearch.GetValue(0) Is Nothing Then
                valor = GridSearch.GetValue(0)
                Descripcion = GridSearch.GetValue(1)
            End If
            bError = False
            Me.Close()
        Else
            bError = True
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        cmbInicial.Value = Today.Date
        cmbFinal.Value = Today.Date

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = Tabla
            .NombreParametro2 = "campo"
            .Parametro2 = Campo
            .llenar()
        End With

        Me.GridSearch.AutoSizeColumns()

        If MaskCte = 1 AndAlso TxtSearch.Text = "" Then
            If Not CmbCampo.SelectedValue Is Nothing Then
                If CmbCampo.SelectedValue = 1 Then
                    TxtSearch.Text = Prefijo & "-"
                End If
            End If
        End If

        bLoad = True
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyUp
        Clock.Start()
    End Sub

    Private Sub GridSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSearch.DoubleClick
        If Not GridSearch.GetValue(0) Is Nothing Then
            valor = GridSearch.GetValue(0)
            Descripcion = GridSearch.GetValue(1)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub GridSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnOK.PerformClick()
        End If
    End Sub

    Private Sub GridSearch_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSearch.SelectionChanged
        If GridSearch.RowCount > 0 AndAlso Not GridSearch.GetValue(0) Is Nothing Then
            Me.BtnOK.Enabled = True
        Else
            Me.BtnOK.Enabled = False
        End If
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        loadPage()
    End Sub

    Private Sub CmbCampo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCampo.SelectedValueChanged
        If bLoad Then
             loadPage()
        End If
    End Sub

    Private Sub cmbInicial_ValueChanged(sender As Object, e As EventArgs) Handles cmbInicial.ValueChanged
        If bLoad Then
            loadPage()
        End If
    End Sub


    Private Sub cmbFinal_ValueChanged(sender As Object, e As EventArgs) Handles cmbFinal.ValueChanged
        If bLoad Then
            loadPage()
        End If
    End Sub

    Private Sub TxtMaxHits_Leave(sender As Object, e As EventArgs) Handles TxtMaxHits.Leave
        If TxtSearch.Text <> "" Then
            loadPage()
        End If
    End Sub
End Class
