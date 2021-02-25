Public Class FrmAddCteProm
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents GrpClientes As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents GridClientes As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddCteProm))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpClientes = New System.Windows.Forms.GroupBox
        Me.lblPorc = New System.Windows.Forms.Label
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.GridClientes = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.cmbGrupo = New Selling.StoreCombo
        Me.GrpClas.SuspendLayout()
        Me.GrpClientes.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 0)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(200, 424)
        Me.GrpClas.TabIndex = 0
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 38)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(186, 379)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpClientes
        '
        Me.GrpClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClientes.Controls.Add(Me.lblPorc)
        Me.GrpClientes.Controls.Add(Me.PBar)
        Me.GrpClientes.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpClientes.Controls.Add(Me.GridClientes)
        Me.GrpClientes.Location = New System.Drawing.Point(207, 0)
        Me.GrpClientes.Name = "GrpClientes"
        Me.GrpClientes.Size = New System.Drawing.Size(531, 424)
        Me.GrpClientes.TabIndex = 1
        Me.GrpClientes.TabStop = False
        Me.GrpClientes.Text = "Clientes"
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(486, 16)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(37, 16)
        Me.lblPorc.TabIndex = 121
        Me.lblPorc.Text = "0 %"
        '
        'PBar
        '
        Me.PBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBar.Location = New System.Drawing.Point(102, 13)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(379, 21)
        Me.PBar.TabIndex = 120
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 17)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(97, 16)
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
        Me.GridClientes.Size = New System.Drawing.Size(518, 379)
        Me.GridClientes.TabIndex = 2
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(552, 431)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(648, 431)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(7, 14)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(186, 21)
        Me.cmbGrupo.TabIndex = 39
        '
        'FrmAddCteProm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpClientes)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmAddCteProm"
        Me.Text = "Agregar de Clientes"
        Me.GrpClas.ResumeLayout(False)
        Me.GrpClientes.ResumeLayout(False)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public PRMClave As String
    Private dtClientes As DataTable
    Private dataSetArbol As Data.DataSet
    Private bCargado As Boolean = False

    Private Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 1, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACIÓN"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()


    End Sub

    Private Sub ActualizaGrid(ByVal tag As Integer)
        If Not dtClientes Is Nothing Then
            dtClientes.Dispose()
        End If

        dtClientes = ModPOS.Recupera_Tabla("sp_muestra_SinPromocion", "@Promocion", PRMClave, "@Class", tag, "@Tipo", 2, "@COMClave", ModPOS.CompanyActual)

        If Not dtClientes Is Nothing Then
            GridClientes.DataSource = dtClientes
            GridClientes.RetrieveStructure()
            '  GridClientes.AutoSizeColumns()
            GridClientes.RootTable.Columns("ID").Visible = False
            GridClientes.CurrentTable.Columns("Marca").Selectable = True

            If dtClientes.Rows.Count > 0 Then
                Me.ChkMarcaTodos.Enabled = True
            Else
                Me.ChkMarcaTodos.Enabled = False
            End If

            ChkMarcaTodos.Checked = False
        End If
        lblPorc.Text = "0 %"
        PBar.Value = 0
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

    Private Sub FrmMtoCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "1"
            .llenar()
        End With

        actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        ActualizaGrid(TreeViewClass.TopNode.Tag)
        bCargado = True
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmAddCteProm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddCteProm.Dispose()
        ModPOS.AddCteProm = Nothing
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not ModPOS.Promocion Is Nothing AndAlso Not dtClientes Is Nothing AndAlso dtClientes.Rows.Count > 0 Then
            Dim foundRows() As DataRow
            foundRows = dtClientes.Select("Marca=True")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                Cursor.Current = Cursors.WaitCursor
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Promocion.addClienteDetalle(foundRows(i)("ID"), foundRows(i)("Clave").ToString, foundRows(i)("Razón Social"), IIf(foundRows(i)("RFC").GetType.FullName = "System.DBNull", "", foundRows(i)("RFC")))
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                Next
                Cursor.Current = Cursors.Default

                Me.Close()

            Else
                MessageBox.Show("¡Debe marcar los clientes que desea agregar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("¡No hay clientes disponibles para agreagar o ya fueron agregados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub


    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtClientes.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtClientes.Rows.Count - 1
                    dtClientes.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtClientes.Rows.Count - 1
                    dtClientes.Rows(i)("Marca") = False
                Next

            End If
            PBar.Value = 0
            lblPorc.Text = "0 %"
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            ActualizaGrid(e.Node.Tag)
        End If
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bCargado = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub
End Class
