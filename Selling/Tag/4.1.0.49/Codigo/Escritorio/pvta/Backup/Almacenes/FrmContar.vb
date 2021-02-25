Public Class FrmContar

    Public CONClave As String
    Public Tipo As String
    Public ALMClave As String
    Public SUCClave As String

    Private EstLoad As Boolean = False
    Private UbcLoad As Boolean = False
    Private sESTClave As String
    Private sUBCClave As String
    Private ubcclave As String
    Private dtConteo As DataTable
    Private Clave As String
    Private Nombre As String
    Private PROClave As String
    Private Cantidad As Double
    Private NumDecimales As Integer
    Private dtTemporal, dtConteoTemp As DataTable

    Private Sub FrmContar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Contar.Dispose()
        ModPOS.Contar = Nothing
    End Sub

    Private Sub FrmContar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModPOS.ActualizaGrid(False, GridEstructura, "sp_conteo_estructura", "@CONClave", CONClave, "@Tipo", Tipo)
        Me.GridEstructura.RootTable.Columns("ESTClave").Visible = False
        EstLoad = True

        If GridEstructura.RowCount > 0 Then
            ModPOS.ActualizaGrid(False, GridUbicaciones, "sp_conteo_ubicacion", "@ESTClave", GridEstructura.GetValue(0))

        End If

        UbcLoad = True
        If GridUbicaciones.RowCount > 0 Then
            ActualizaDetalle(GridUbicaciones.GetValue("Ubicación"))
        End If

        'If Tipo = 2 Then
        '    LblFile.Visible = False
        '    BtnFile.Visible = False
        'End If
    End Sub

    Private Sub GridEstructura_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstructura.SelectionChanged
        If EstLoad = True AndAlso Not Me.GridEstructura.GetValue(0) Is Nothing Then
            sESTClave = Me.GridEstructura.GetValue(0)
            UbcLoad = False
            ModPOS.ActualizaGrid(False, GridUbicaciones, "sp_conteo_ubicacion", "@ESTClave", sESTClave)
            If Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
                sUBCClave = Me.GridUbicaciones.GetValue("Ubicación")
                TxtUbicacion.Text = sUBCClave
                ubcclave = sUBCClave
            Else
                sUBCClave = ""
                ubcclave = ""
                TxtUbicacion.Text = ""
            End If

            ActualizaDetalle(sUBCClave)

            UbcLoad = True
        Else
            sESTClave = ""
            UbcLoad = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GridUbicaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUbicaciones.DoubleClick
        If Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            recuperaUbicacion(Me.GridUbicaciones.GetValue("Ubicación"))
        End If
    End Sub

    Private Sub GridUbicaciones_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUbicaciones.SelectionChanged
        If UbcLoad = True AndAlso Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            sUBCClave = Me.GridUbicaciones.GetValue("Ubicación")
            ActualizaDetalle(sUBCClave)
            TxtUbicacion.Text = sUBCClave
            ubcclave = sUBCClave
        Else
            sUBCClave = ""
            ubcclave = ""
            TxtUbicacion.Text = ""
        End If
    End Sub

    Private Sub ActualizaDetalle(ByVal sUBCClave As String)
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        dtConteo = ModPOS.Recupera_Tabla("sp_muestra_conteo_det", "@CONClave", CONClave, "@UBCClave", sUBCClave)

        If Not dtConteo Is Nothing Then
            GridConteo.DataSource = dtConteo
            GridConteo.RetrieveStructure()
            GridConteo.AutoSizeColumns()
            GridConteo.RootTable.Columns(0).Visible = False
            GridConteo.RootTable.Columns(1).Visible = False
            GridConteo.RootTable.Columns(2).Visible = False
            GridConteo.CurrentTable.Columns(3).Selectable = False
            GridConteo.CurrentTable.Columns(4).Selectable = False
            GridConteo.CurrentTable.Columns(5).Selectable = False
            GridConteo.CurrentTable.Columns(6).Selectable = False
            GridConteo.CurrentTable.Columns(8).Visible = False

        End If
        Me.ubcclave = sUBCClave
        LblUbicacion.Text = sUBCClave
        lblPorc.Text = "0 %"
        PBar.Value = 0
    End Sub

    Private Sub TxtClaveProd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClaveProd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub recuperaUbicacion(ByVal sClave As String)
        If ModPOS.SiExite(ModPOS.BDConexion, "sp_recupera_ubicacion", "@UBCClave", sClave.Replace("'", "''")) <> 0 Then
            ubcclave = sClave
            ActualizaDetalle(ubcclave)
            TxtClaveProd.Focus()
            LblUbicacion.Text = sClave
        Else
            MessageBox.Show("¡La Clave de Ubicación no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            LblUbicacion.Text = ""
        End If
    End Sub

    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"))
        If Not dtProducto Is Nothing Then
            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            NumDecimales = dtProducto.Rows(0)("Num_Decimales")

            dtProducto.Dispose()
            Me.TxtDescripcion.Text = Nombre
            TxtCantidad.DecimalDigits = NumDecimales
            TxtCantidad.Focus()

        Else
            PROClave = ""
            Cantidad = 0
            Clave = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cantidad = CDbl(TxtCantidad.Text)
            If System.String.IsNullOrEmpty(ubcclave) Then
                Beep()
                MessageBox.Show("¡La Clave de Ubicación es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If System.String.IsNullOrEmpty(PROClave) Then
                    Beep()
                    MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtConteo.Select("PROClave Like '" & PROClave & "'")

                    If foundRows.Length = 0 Then
                        If Cantidad > 0 Then
                            Dim row1 As DataRow
                            row1 = dtConteo.NewRow()
                            'declara el nombre de la fila
                            row1.Item("PROClave") = PROClave
                            row1.Item("UBCClave") = ubcclave
                            row1.Item("Origen") = 0.0
                            row1.Item("Clave") = Clave
                            row1.Item("Nombre") = Nombre
                            row1.Item("Existencia") = 0.0
                            row1.Item("Cantidad") = Cantidad
                            row1.Item("Procesado") = False
                            dtConteo.Rows.Add(row1)
                            'agrega la fila completo a la tabla

                            'Inserta en prd_exist_uba
                            ModPOS.Ejecuta("sp_inserta_exist_uba", "@PROClave", PROClave, "@UBCClave", ubcclave, "@Existencia", 0, "@Usuario", ModPOS.UsuarioActual)

                            TxtClaveProd.Text = ""
                            TxtDescripcion.Text = ""
                            TxtCantidad.Text = 0
                            PROClave = ""
                            Cantidad = 0
                            Clave = ""
                            Nombre = ""
                            TxtClaveProd.Focus()
                         Else
                            MessageBox.Show("¡La Cantidad de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else 'actualiza
                        foundRows(0)("Cantidad") = Cantidad
                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        Cantidad = 0
                        Clave = ""
                        Nombre = ""
                        TxtClaveProd.Focus()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtClaveProd.Text = a.valor
            TxtDescripcion.Text = a.Descripcion
            recuperaProducto(a.valor)
            TxtCantidad.Focus()
        End If
        a.Dispose()
    End Sub

    Private Sub TxtUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUbicacion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtUbicacion.Text = vbNullString Then
                recuperaUbicacion(TxtUbicacion.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dtConteo Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtConteo.Select("Origen <> Cantidad or (Existencia > 0 and Cantidad=0)")
            Cursor.Current = Cursors.WaitCursor
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                For i = 0 To foundRows.GetUpperBound(0)
                    If foundRows(i)("Cantidad") <> foundRows(i)("Origen") Then
                        If foundRows(i)("Origen") = 0.0 Then
                            '   Inserta
                            ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Existencia", foundRows(i)("Existencia"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                            foundRows(i)("Procesado") = True
                        Else
                            '   Actualiza
                            ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                        foundRows(i)("Origen") = foundRows(i)("Cantidad")
                    ElseIf foundRows(i)("Procesado") = False Then
                        '   Inserta
                        ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Existencia", foundRows(i)("Existencia"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        foundRows(i)("Procesado") = True
                    End If
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                Next

            End If
            'Elimina vacios
            foundRows = dtConteo.Select("Origen = Cantidad = Existencia = 0 and Procesado=False")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    '   Elimina Prd_exist_uba
                    ModPOS.Ejecuta("sp_borra_exist_uba", "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"))
                    foundRows(i)("Procesado") = True
                Next
            End If
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub GridConteo_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridConteo.CellEdited
        If GridConteo.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridConteo.GetValue("Cantidad")) Then
                If GridConteo.GetValue("Cantidad") < 0 Then
                    Dim Actual As Double
                    Actual = Math.Abs(CDbl(GridConteo.GetValue("Cantidad")))
                    GridConteo.SetValue(7, Actual)
                End If
            Else
                GridConteo.SetValue("Cantidad", 0)
            End If
        End If

    End Sub

    Private Sub GridConteo_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridConteo.CellValueChanged
        PBar.Value = 0
        lblPorc.Text = "0 %"
    End Sub

    Private Sub guardarconteo()
        If Not dtConteoTemp Is Nothing Then

            Dim foundRows() As DataRow
            foundRows = dtConteoTemp.Select("Existencia <> Cantidad")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                Dim dtContDet As DataTable
            
                For i = 0 To foundRows.GetUpperBound(0)

                    dtContDet = ModPOS.Recupera_Tabla("sp_existe_conteo_detalle", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"))

                    If Not dtContDet Is Nothing Then

                        If dtContDet.Rows.Count = 0 Then
                            '   Inserta
                            ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Existencia", foundRows(i)("Existencia"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        ElseIf dtContDet.Rows.Count > 0 Then
                            '   Actualiza
                            ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If
                Next
            End If
            'Elimina vacios
            foundRows = dtConteoTemp.Select("Cantidad = Existencia = 0")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    '   Elimina Prd_exist_uba
                    ModPOS.Ejecuta("sp_borra_exist_uba", "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"))
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

                dtTemporal = ReadCSV(FullPath, 3)

                If Not dtConteoTemp Is Nothing Then
                    dtConteoTemp.Dispose()
                End If

                dtConteoTemp = ModPOS.CrearTabla("ConteoDetalle", _
                                                  "PROClave", "System.String", _
                                                  "UBCClave", "System.String", _
                                                  "Existencia", "System.Double", _
                                                  "Cantidad", "System.Double")

                Dim i As Integer

                Dim dtProducto, dtUbicacion As DataTable

                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Procesando Archivo...")

                PBar.Maximum = dtTemporal.Rows.Count

                For i = 0 To dtTemporal.Rows.Count - 1
                    'Valida si existen datos para comparar
                    If Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" AndAlso Not dtTemporal.Rows(i)(0).GetType.FullName = "System.DBNull" Then
                        'Verifica que exista la ubicación
                        dtUbicacion = ModPOS.Recupera_Tabla("sp_exist_ubc", "@ALMClave", ALMClave, "@UBCClave", dtTemporal.Rows(i)(0).ToString.Trim)
                        If Not dtUbicacion Is Nothing AndAlso dtUbicacion.Rows.Count = 1 Then
                            'Verifica que exista el producto
                            dtProducto = ModPOS.Recupera_Tabla("sp_recupera_prod_gtin", "@UBCClave", dtTemporal.Rows(i)(0).ToString.Trim, "@GTIN", dtTemporal.Rows(i)(1).ToString.Trim)
                            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count = 1 Then
                                'Verifica que la cantidad sea numerica
                                If IsNumeric(dtTemporal.Rows(i)(2)) Then
                                    'Verifica que el producto no se encuentre repetido en el mismo archivo en la misma ubicación
                                    Dim foundRows() As System.Data.DataRow
                                    foundRows = dtConteoTemp.Select("PROClave = '" & dtProducto.Rows(0)("PROClave") & "' and UBCClave ='" & dtUbicacion.Rows(0)("UBCClave") & "'")

                                    If foundRows.Length = 0 Then

                                        Dim row1 As DataRow
                                        row1 = dtConteoTemp.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("PROClave") = dtProducto.Rows(0)("PROClave")
                                        row1.Item("UBCClave") = dtUbicacion.Rows(0)("UBCClave")
                                        row1.Item("Existencia") = dtProducto.Rows(0)("Origen")
                                        row1.Item("Cantidad") = CDbl(dtTemporal.Rows(i)(2))
                                        dtConteoTemp.Rows.Add(row1)
                                    Else
                                        foundRows(0)("Cantidad") = CDbl(dtTemporal.Rows(i)(2))
                                    End If
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

    Private Sub LblFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblFile.Click

    End Sub
End Class