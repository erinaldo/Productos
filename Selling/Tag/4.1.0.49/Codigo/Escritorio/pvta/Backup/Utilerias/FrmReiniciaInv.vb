Public Class FrmReiniciaInv
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
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbCampo As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReiniciaInv))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpProductos = New System.Windows.Forms.GroupBox
        Me.lblPorc = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.GrpClas.SuspendLayout()
        Me.GrpProductos.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 0)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(200, 470)
        Me.GrpClas.TabIndex = 1
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Lineas"
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 15)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(186, 448)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.Controls.Add(Me.lblPorc)
        Me.GrpProductos.Controls.Add(Me.Label2)
        Me.GrpProductos.Controls.Add(Me.PBar)
        Me.GrpProductos.Controls.Add(Me.BtnGuardar)
        Me.GrpProductos.Controls.Add(Me.BtnCancelar)
        Me.GrpProductos.Controls.Add(Me.CmbAlmacen)
        Me.GrpProductos.Controls.Add(Me.Label9)
        Me.GrpProductos.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpProductos.Controls.Add(Me.CmbCampo)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Location = New System.Drawing.Point(207, 0)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(580, 470)
        Me.GrpProductos.TabIndex = 0
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(352, 443)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(37, 16)
        Me.lblPorc.TabIndex = 122
        Me.lblPorc.Text = "100 %"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(4, 443)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Guardando"
        '
        'PBar
        '
        Me.PBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBar.Location = New System.Drawing.Point(72, 440)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(275, 21)
        Me.PBar.TabIndex = 120
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(484, 427)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(388, 427)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(91, 16)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(351, 21)
        Me.CmbAlmacen.TabIndex = 114
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(7, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 14)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Almacén"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 66)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(124, 19)
        Me.ChkMarcaTodos.TabIndex = 113
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 43)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 7
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(173, 43)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(401, 20)
        Me.TxtBuscar.TabIndex = 1
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
        Me.GridProductos.Location = New System.Drawing.Point(7, 91)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(567, 330)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmReiniciaInv
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.GrpProductos)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmReiniciaInv"
        Me.Text = "Reiniciar Inventario"
        Me.GrpClas.ResumeLayout(False)
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private sProdSelected As String

    Private sNombre As String
    Private dtConteo As DataTable
    Public Almacen As String
    Private Cargado As Boolean = False
    Private SUCClave As String
    Private dataSetArbol As Data.DataSet

    Private Sub ActualizaDetalle(ByVal Tipo As Integer)

        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        If Tipo = 1 Then
            If TreeViewClass.SelectedNode Is Nothing Then
                dtConteo = ModPOS.Recupera_Tabla("sp_consulta_productos", "@Class", TreeViewClass.TopNode.Tag, "@ALMClave", CmbAlmacen.SelectedValue)
            Else
                dtConteo = ModPOS.Recupera_Tabla("sp_consulta_productos", "@Class", TreeViewClass.SelectedNode.Tag, "@ALMClave", CmbAlmacen.SelectedValue)
            End If
        Else
            dtConteo = ModPOS.Recupera_Tabla("sp_busca_prod", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim, "@ALMClave", CmbAlmacen.SelectedValue)
        End If

        If dtConteo.Rows.Count > 0 Then

            GridProductos.DataSource = dtConteo
            GridProductos.RetrieveStructure()
            GridProductos.AutoSizeColumns()
            GridProductos.RootTable.Columns("ID").Visible = False
            GridProductos.CurrentTable.Columns("C.BARRAS").Selectable = False
            GridProductos.CurrentTable.Columns("Clave").Selectable = False
            GridProductos.CurrentTable.Columns("Num. de Parte").Selectable = False
            GridProductos.CurrentTable.Columns("Nombre Comun").Selectable = False
            GridProductos.RootTable.Columns("Exist").Selectable = False
            GridProductos.RootTable.Columns("Costo").Visible = False
            PBar.Value = 0
            lblPorc.Text = "0 %"
        End If
    End Sub

    Private Sub actualizaTree()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 4, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACIÓN"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()
    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("Clasificacion"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("Clasificacion").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeViewClass.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent



    End Sub

    Private Sub FrmReinicaInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        actualizaTree()

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        Cargado = True
        ActualizaDetalle(1)

        ChkMarcaTodos.Enabled = True
        GridProductos.Enabled = True
        TreeViewClass.Enabled = True

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmReiniciaInv_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ReiniciaInv.Dispose()
        ModPOS.ReiniciaInv = Nothing
    End Sub

    Private Sub GridProductos_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridProductos.CellValueChanged
        PBar.Value = 0
        lblPorc.Text = "0 %"
    End Sub

    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If Not GridProductos.GetValue(0) Is Nothing Then
            Me.sProdSelected = GridProductos.GetValue(0)
            Me.sNombre = GridProductos.GetValue(1)
        Else
            Me.sProdSelected = ""
            Me.sNombre = ""
        End If
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                ActualizaDetalle(2)
            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If CmbAlmacen.SelectedValue Is Nothing Then
            MessageBox.Show("¡Verifique que el Almacén este seleccionado correctamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            If Not dtConteo Is Nothing AndAlso dtConteo.Rows.Count > 0 Then

                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", CmbAlmacen.SelectedValue)

                If dt.Rows.Count > 0 Then
                    SUCClave = dt.Rows(0)("SUCClave")
                End If
                dt.Dispose()


                Dim foundRows() As DataRow
                foundRows = dtConteo.Select("Marca=True")
                If foundRows.GetLength(0) > 0 Then
                    Dim dMonto As Double
                    dMonto = IIf(dtConteo.Compute("Sum(Costo)", "Marca = True") Is System.DBNull.Value, 0, dtConteo.Compute("Sum(Costo)", "Marca = True"))
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = Math.Abs(dMonto)
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim i As Integer
                            PBar.Maximum = foundRows.GetLength(0)
                            Cursor.Current = Cursors.WaitCursor
                            For i = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_reinicia_inv", "@ALMClave", CmbAlmacen.SelectedValue, "@PROClave", foundRows(i)("ID"), "@Usuario", ModPOS.UsuarioActual)
                                PBar.Value = i + 1
                                lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                            Next
                            Cursor.Current = Cursors.Default
                        End If
                    End If
                    a.Dispose()
                Else
                    MessageBox.Show("¡Debe marcar los productos que desea reiniciar el inventario a cero!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("¡No hay productos disponibles!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtConteo.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtConteo.Rows.Count - 1
                    dtConteo.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtConteo.Rows.Count - 1
                    dtConteo.Rows(i)("Marca") = False
                Next

            End If
            PBar.Value = 0
            lblPorc.Text = "0 %"
            Cursor.Current = Cursors.Default
        End If
    End Sub

  

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            ActualizaDetalle(1)
        End If
    End Sub


End Class
