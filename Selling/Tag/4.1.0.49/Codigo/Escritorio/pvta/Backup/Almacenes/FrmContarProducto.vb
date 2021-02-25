Public Class FrmContarProducto

    Public CONClave As String
    Public Tipo As Integer
    Public ALMClave As String
    Private dataSetArbol As Data.DataSet
    Private dtConteo As DataTable
    Private dtTemporal, dtConteoTemp As DataTable

    Private Sub FrmContarProducto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ContarProducto.Dispose()
        ModPOS.ContarProducto = Nothing
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

    Private Sub actualizaTree()

        If Tipo = 2 Then
            dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion_conteo", "Clasificacion", "@CONClave", CONClave)
        Else
            dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 4, "@COMClave", ModPOS.CompanyActual)
        End If

        CrearNodosDelPadre(0, Nothing)
        dataSetArbol.Dispose()
    End Sub

    Private Sub FrmContarProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        actualizaTree()

        ActualizaDetalle(1)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ActualizaDetalle(ByVal Tipo As Integer)
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        If Tipo = 1 Then
            If TreeViewClass.SelectedNode Is Nothing Then
                dtConteo = ModPOS.Recupera_Tabla("sp_conteo_linea_productos", "@Class", TreeViewClass.TopNode.Tag, "@CONClave", CONClave)
            Else
                dtConteo = ModPOS.Recupera_Tabla("sp_conteo_linea_productos", "@Class", TreeViewClass.SelectedNode.Tag, "@CONClave", CONClave)
            End If
        Else
            dtConteo = ModPOS.Recupera_Tabla("sp_muestra_conteo_producto", "@CONClave", CONClave, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.Trim.Replace("'", ""))
        End If

        If Not dtConteo Is Nothing AndAlso dtConteo.Rows.Count > 0 Then

            GridProductos.DataSource = dtConteo
            GridProductos.RetrieveStructure()
            GridProductos.AutoSizeColumns()
            Me.GridProductos.RootTable.Columns("PROClave").Visible = False
            Me.GridProductos.RootTable.Columns("Procesado").Visible = False
            Me.GridProductos.RootTable.Columns("Teorica").Visible = False
            Me.GridProductos.RootTable.Columns("Conteo").Visible = False
            GridProductos.CurrentTable.Columns("Clave").Selectable = False
            GridProductos.CurrentTable.Columns("C.BARRAS").Selectable = False
            GridProductos.CurrentTable.Columns("Nombre").Selectable = False
            Me.GridProductos.RootTable.Columns("Clave").Width = 70
            Me.GridProductos.RootTable.Columns("C.BARRAS").Width = 50
            Me.GridProductos.RootTable.Columns("Nombre").Width = 270
            Me.GridProductos.RootTable.Columns("Cantidad").Width = 25

            PBar.Value = 0
            lblPorc.Text = "0 %"
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

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            ActualizaDetalle(1)
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dtConteo Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtConteo.Select("Conteo <> Cantidad or (Teorica > 0 and Cantidad=0)")
            Cursor.Current = Cursors.WaitCursor
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                For i = 0 To foundRows.GetUpperBound(0)
                    If foundRows(i)("Conteo") <> foundRows(i)("Cantidad") Then
                        If foundRows(i)("Procesado") = 0 Then
                            '   Inserta
                            ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"), "@Existencia", foundRows(i)("Teorica"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                            foundRows(i)("Procesado") = 1
                        Else
                            '   Actualiza
                            ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                        foundRows(i)("Conteo") = foundRows(i)("Cantidad")
                    ElseIf foundRows(i)("Procesado") = 0 Then
                        '   Inserta
                        ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"), "@Existencia", foundRows(i)("Teorica"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        foundRows(i)("Procesado") = 1
                    Else
                        '   Actualiza
                        ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                    End If
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                    lblPorc.Refresh()
                Next

            End If
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GridProductos_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridProductos.CellEdited
        Select Case GridProductos.CurrentColumn.Caption
            Case "Cantidad"
                If Not (IsNumeric(GridProductos.GetValue("Cantidad")) AndAlso CDbl(GridProductos.GetValue("Cantidad")) >= 0) Then
                    GridProductos.SetValue("Cantidad", 0)
                End If
        End Select
    End Sub

    Private Sub guardarconteo()
        If Not dtConteoTemp Is Nothing Then

            Dim foundRows() As DataRow
            foundRows = dtConteoTemp.Select("Existencia <> Cantidad")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                Dim dtContDet As DataTable

                For i = 0 To foundRows.GetUpperBound(0)

                    dtContDet = ModPOS.Recupera_Tabla("sp_existe_conteo_detalle", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"))

                    If Not dtContDet Is Nothing Then

                        If dtContDet.Rows.Count = 0 Then
                            '   Inserta
                            ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"), "@Existencia", foundRows(i)("Existencia"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        ElseIf dtContDet.Rows.Count > 0 Then
                            '   Actualiza
                            ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", "", "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If
                Next
            End If
        End If

        MessageBox.Show("El Conteo ha sido procesado exitosamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Dim result As OpenFileDialog = New OpenFileDialog
        result.Filter = "Todos los archivos de CSV|*.CSV"
        result.Title = "Importar archivo CSV"

        If (result.ShowDialog() = DialogResult.OK) Then

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim FullPath As String = result.FileName

            If FullPath.Contains(".CSV") Then

                dtTemporal = ReadCSV(FullPath, 2)

                If Not dtConteoTemp Is Nothing Then
                    dtConteoTemp.Dispose()
                End If

                dtConteoTemp = ModPOS.CrearTabla("ConteoDetalle", _
                                                  "PROClave", "System.String", _
                                                  "Existencia", "System.Double", _
                                                  "Cantidad", "System.Double")

                Dim i As Integer

                Dim dtProducto As DataTable

                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Procesando Archivo...")

                PBar.Maximum = dtTemporal.Rows.Count

                For i = 0 To dtTemporal.Rows.Count - 1
                    'Valida si existen datos para comparar
                    If Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" AndAlso Not dtTemporal.Rows(i)(0).GetType.FullName = "System.DBNull" Then
                        'Verifica que exista el producto
                        dtProducto = ModPOS.Recupera_Tabla("sp_recupera_prod_conteo", "@ALMClave", ALMClave, "@CONClave", CONClave, "@GTIN", dtTemporal.Rows(i)(0).ToString.Trim)
                        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count = 1 Then
                            'Verifica que la cantidad sea numerica
                            If IsNumeric(dtTemporal.Rows(i)(1)) Then
                                'Verifica que el producto no se encuentre repetido en el mismo archivo en la misma ubicación
                                Dim foundRows() As System.Data.DataRow
                                foundRows = dtConteoTemp.Select("PROClave = '" & dtProducto.Rows(0)("PROClave") & "'")

                                If foundRows.Length = 0 Then

                                    Dim row1 As DataRow
                                    row1 = dtConteoTemp.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("PROClave") = dtProducto.Rows(0)("PROClave")
                                    row1.Item("Existencia") = dtProducto.Rows(0)("Origen")
                                    row1.Item("Cantidad") = CDbl(dtTemporal.Rows(i)(2))
                                    dtConteoTemp.Rows.Add(row1)
                                Else
                                    foundRows(0)("Cantidad") = CDbl(dtTemporal.Rows(i)(2))
                                End If
                            End If
                        End If

                    End If

                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                    lblPorc.Refresh()

                Next

                guardarconteo()

                frmStatusMessage.Close()

                Cursor.Current = Cursors.Default

                Me.Close()

            End If

        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub
End Class