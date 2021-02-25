Public Class FrmNCProvedor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdjuntar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridNCProveedor As Janus.Windows.GridEX.GridEX

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Clock As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNCProvedor))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.btnAdjuntar = New Janus.Windows.EditControls.UIButton()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnNC = New Janus.Windows.EditControls.UIButton()
        Me.GridNCProveedor = New Janus.Windows.GridEX.GridEX()
        Me.GrpTickets.SuspendLayout()
        CType(Me.GridNCProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.btnAdjuntar)
        Me.GrpTickets.Controls.Add(Me.BtnRefresh)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.BtnEliminar)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.BtnNC)
        Me.GrpTickets.Controls.Add(Me.GridNCProveedor)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(799, 473)
        Me.GrpTickets.TabIndex = 2
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Notas de Crédito"
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjuntar.Icon = CType(resources.GetObject("btnAdjuntar.Icon"), System.Drawing.Icon)
        Me.btnAdjuntar.Location = New System.Drawing.Point(513, 430)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(90, 37)
        Me.btnAdjuntar.TabIndex = 140
        Me.btnAdjuntar.Text = "Adjuntar"
        Me.btnAdjuntar.ToolTipText = "Adjuntar (*.PDF y *.XML)"
        Me.btnAdjuntar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(7, 17)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 51
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(417, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir "
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(609, 429)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 11
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar documento seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(607, 16)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 130
        '
        'BtnNC
        '
        Me.BtnNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNC.Image = CType(resources.GetObject("BtnNC.Image"), System.Drawing.Image)
        Me.BtnNC.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnNC.Location = New System.Drawing.Point(703, 429)
        Me.BtnNC.Name = "BtnNC"
        Me.BtnNC.Size = New System.Drawing.Size(90, 37)
        Me.BtnNC.TabIndex = 6
        Me.BtnNC.Text = "&NC"
        Me.BtnNC.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnNC.ToolTipText = "Nuevo documento"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridNCProveedor
        '
        Me.GridNCProveedor.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridNCProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridNCProveedor.ColumnAutoResize = True
        Me.GridNCProveedor.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridNCProveedor.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridNCProveedor.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridNCProveedor.Location = New System.Drawing.Point(7, 44)
        Me.GridNCProveedor.Name = "GridNCProveedor"
        Me.GridNCProveedor.RecordNavigator = True
        Me.GridNCProveedor.Size = New System.Drawing.Size(785, 379)
        Me.GridNCProveedor.TabIndex = 2
        Me.GridNCProveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmNCProvedor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(799, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmNCProvedor"
        Me.Text = "Notas de Crédito de Proveedor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.GridNCProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sNCSelected As String
    Public Mes As Integer
    Public Periodo As Integer
    Private sSUCClave As String


    Private bLoad As Boolean = False

    Public Sub refrescaGrid()
        Cursor.Current = Cursors.WaitCursor


        ModPOS.ActualizaGrid(False, Me.GridNCProveedor, "sp_muestra_ncproveedor", "@COMClave", ModPOS.CompanyActual, "@Periodo", Periodo, "@Mes", Mes)
        GridNCProveedor.RootTable.Columns("NCPClave").Visible = False
        GridNCProveedor.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridNCProveedor.RootTable.Columns("Disponible").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        Cursor.Current = Cursors.Default

    End Sub


    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        If sNCSelected <> "" Then
            Dim a As New FrmAdjuntar
            a.TipoDocumento = "NC"
            a.COMClave = sNCSelected
            a.Text = GridNCProveedor.GetValue("Folio")
            a.ShowDialog()
            a.Dispose()
        Else
            MessageBox.Show("¡No se ha seleccionado un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If bLoad = True Then

            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()

        End If
    End Sub

    Private Sub FrmNCProvedor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        refrescaGrid()

        bLoad = True
    End Sub

    Private Sub GridCompras_SelectionChanged(sender As Object, e As EventArgs) Handles GridNCProveedor.SelectionChanged
        If Not GridNCProveedor.GetValue(0) Is Nothing Then
            sNCSelected = GridNCProveedor.GetValue("NCPClave")
        Else
            sNCSelected = ""
        End If
    End Sub

    Private Sub FrmNCProveedor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.NCProveedor.Dispose()
        ModPOS.NCProveedor = Nothing
    End Sub

    Private Sub dtPicker_ValueChanged(sender As Object, e As EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub


    Private Sub BtnNC_Click(sender As Object, e As EventArgs) Handles BtnNC.Click
        If ModPOS.NCP Is Nothing Then
            ModPOS.NCP = New FrmNCP
            ModPOS.NCP.Padre = "Nuevo"
        End If
        ModPOS.NCP.StartPosition = FormStartPosition.CenterScreen
        ModPOS.NCP.Show()
        ModPOS.NCP.BringToFront()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If sNCSelected <> "" Then
            If GridNCProveedor.GetValue("Total") = GridNCProveedor.GetValue("Disponible") Then
                Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & CStr(GridNCProveedor.GetValue("Folio")) & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Ejecuta("st_elimina_ncproveedor", "@NCPClave", sNCSelected)
                        refrescaGrid()
                End Select
            Else
                MessageBox.Show("No es posible cancelar el documento seleccionado ya que se encuentra aplicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
