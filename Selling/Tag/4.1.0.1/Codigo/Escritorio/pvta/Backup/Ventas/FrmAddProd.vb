Public Class FrmAddProd
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents CmbFiltro As StoreCombo
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddProd))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.CmbCampo = New Selling.StoreCombo
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.TxtSearch = New System.Windows.Forms.TextBox
        Me.CmbFiltro = New Selling.StoreCombo
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridProductos)
        Me.GroupBox1.Controls.Add(Me.CmbCampo)
        Me.GroupBox1.Controls.Add(Me.ChkMarcaTodos)
        Me.GroupBox1.Controls.Add(Me.TxtSearch)
        Me.GroupBox1.Controls.Add(Me.CmbFiltro)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 313)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Productos"
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(5, 70)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(668, 237)
        Me.GridProductos.TabIndex = 20
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(8, 18)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(127, 21)
        Me.CmbCampo.TabIndex = 13
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 50)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(127, 15)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Location = New System.Drawing.Point(275, 18)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(385, 20)
        Me.TxtSearch.TabIndex = 4
        '
        'CmbFiltro
        '
        Me.CmbFiltro.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFiltro.Location = New System.Drawing.Point(142, 18)
        Me.CmbFiltro.Name = "CmbFiltro"
        Me.CmbFiltro.Size = New System.Drawing.Size(126, 21)
        Me.CmbFiltro.TabIndex = 3
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(595, 326)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(499, 326)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 27
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddProd
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 365)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(580, 364)
        Me.Name = "FrmAddProd"
        Me.Text = "Agregar Productos No Manejados en Almacén"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ALMClave As String
    Private dtProductos As DataTable


    Private Sub FrmAddPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With Me.CmbCampo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "AddClass"
            .NombreParametro2 = "campo"
            .Parametro2 = "CampoProducto"
            .llenar()
        End With

        With Me.CmbFiltro
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "AddClass"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

    End Sub

    Private Sub FrmAddProd_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddProd.Dispose()
        ModPOS.AddProd = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtProductos.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtProductos.Rows.Count - 1
                    dtProductos.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtProductos.Rows.Count - 1
                    dtProductos.Rows(i)("Marca") = False
                Next

            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dtProductos Is Nothing Then

            Dim i As Integer

            If Not ModPOS.CrearAlm Is Nothing Then

                Dim foundRows() As DataRow
                foundRows = dtProductos.Select("Marca = 1")

                If foundRows.GetLength(0) > 0 Then

                    Cursor.Current = Cursors.WaitCursor


                    For i = 0 To foundRows.GetUpperBound(0)

                        ModPOS.CrearAlm.agregaProducto(foundRows(i)("PROClave"), foundRows(i)("Clave"), foundRows(i)("Nombre"))


                    Next

                    dtProductos.Dispose()
                    Cursor.Current = Cursors.Default
                Else
                    Beep()
                    MessageBox.Show("¡No se encontraron registros marcados para agregar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            Beep()
            MessageBox.Show("¡No hay productos disponibles para agregar. utilice los filtros de busqueda nuevamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

  
    Private Sub TxtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyUp
        If CmbCampo.SelectedValue = Nothing OrElse CmbFiltro.SelectedValue = Nothing Then
            MsgBox("Los parametros de busqueda son requeridos", MsgBoxStyle.Critical, "Error")
        ElseIf TxtSearch.Text <> "" Then
            If Not dtProductos Is Nothing Then
                dtProductos.Dispose()
            End If
            dtProductos = ModPOS.Recupera_Tabla("sp_filtra_almacen_producto", "@ALMClave", ALMClave, "@Campo", Me.CmbCampo.SelectedValue, "@Filtro", Me.CmbFiltro.SelectedValue, "@Busca", Me.TxtSearch.Text.Replace("'", "''"))
            GridProductos.DataSource = dtProductos
            GridProductos.RetrieveStructure()
            GridProductos.AutoSizeColumns()
            GridProductos.RootTable.Columns("PROClave").Visible = False
            GridProductos.CurrentTable.Columns("Clave").Selectable = False
            GridProductos.CurrentTable.Columns("Nombre").Selectable = False
            GridProductos.CurrentTable.Columns("Descripcion").Selectable = False

            If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
                Me.ChkMarcaTodos.Enabled = True
            Else
                Me.ChkMarcaTodos.Enabled = False
            End If

        End If
    End Sub

End Class
