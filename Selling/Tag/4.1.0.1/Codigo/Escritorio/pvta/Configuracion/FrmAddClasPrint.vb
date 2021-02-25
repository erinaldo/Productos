Public Class FrmAddClasPrint
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClientes As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GridClientes As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddClasPrint))
        Me.GrpClientes = New System.Windows.Forms.GroupBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.lblPorc = New System.Windows.Forms.Label
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.GridClientes = New Janus.Windows.GridEX.GridEX
        Me.GrpClientes.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClientes
        '
        Me.GrpClientes.Controls.Add(Me.BtnCancelar)
        Me.GrpClientes.Controls.Add(Me.lblPorc)
        Me.GrpClientes.Controls.Add(Me.BtnAgregar)
        Me.GrpClientes.Controls.Add(Me.PBar)
        Me.GrpClientes.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpClientes.Controls.Add(Me.GridClientes)
        Me.GrpClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClientes.Location = New System.Drawing.Point(0, 0)
        Me.GrpClientes.Name = "GrpClientes"
        Me.GrpClientes.Size = New System.Drawing.Size(742, 473)
        Me.GrpClientes.TabIndex = 1
        Me.GrpClientes.TabStop = False
        Me.GrpClientes.Text = "Clientes"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(550, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(697, 16)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(37, 16)
        Me.lblPorc.TabIndex = 121
        Me.lblPorc.Text = "0 %"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(646, 430)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PBar
        '
        Me.PBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBar.Location = New System.Drawing.Point(112, 13)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(580, 21)
        Me.PBar.TabIndex = 120
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 13)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(99, 23)
        Me.ChkMarcaTodos.TabIndex = 7
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'GridClientes
        '
        Me.GridClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClientes.ColumnAutoResize = True
        Me.GridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClientes.GroupByBoxVisible = False
        Me.GridClientes.Location = New System.Drawing.Point(7, 38)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.RecordNavigator = True
        Me.GridClientes.Size = New System.Drawing.Size(729, 386)
        Me.GridClientes.TabIndex = 2
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmAddClasPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpClientes)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmAddClasPrint"
        Me.Text = "Agregar de Lineas"
        Me.GrpClientes.ResumeLayout(False)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String

    Private dtLineas As DataTable

   
    Private Sub ActualizaGrid(ByVal sSUCClave As String)

        dtLineas = ModPOS.Recupera_Tabla("sp_recupera_clasprint", "@SUCClave", SUCClave)

        If Not dtLineas Is Nothing Then
            GridClientes.DataSource = dtLineas
            GridClientes.RetrieveStructure()
            '  GridClientes.AutoSizeColumns()
            GridClientes.RootTable.Columns("CLAClave").Visible = False
            GridClientes.CurrentTable.Columns("Marca").Selectable = True

            If dtLineas.Rows.Count > 0 Then
                Me.ChkMarcaTodos.Enabled = True
            Else
                Me.ChkMarcaTodos.Enabled = False
            End If

            ChkMarcaTodos.Checked = False
        End If
        lblPorc.Text = "0 %"
        PBar.Value = 0
    End Sub

    Private Sub FrmAddClasPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ActualizaGrid(SUCClave)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmAddClasPrint_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddClasPrint.Dispose()
        ModPOS.AddClasPrint = Nothing
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not dtLineas Is Nothing AndAlso dtLineas.Rows.Count > 0 Then
            Dim foundRows() As DataRow
            foundRows = dtLineas.Select("Marca=True")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                Cursor.Current = Cursors.WaitCursor
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Printer.AddClase(foundRows(i)("CLAClave"), foundRows(i)("Clave").ToString, foundRows(i)("Nombre"))
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                Next
                Cursor.Current = Cursors.Default
                Me.Close()
            Else
                MessageBox.Show("¡Debe marcar las Lineas que desea agregar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("¡No hay lineas disponibles para agreagar o ya fueron agregados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtLineas.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridClientes.GetDataRows.Length - 1
                    GridClientes.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridClientes.GetDataRows.Length - 1
                    GridClientes.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            
            PBar.Value = 0
            lblPorc.Text = "0 %"
            Cursor.Current = Cursors.Default
        End If
    End Sub

  
End Class
