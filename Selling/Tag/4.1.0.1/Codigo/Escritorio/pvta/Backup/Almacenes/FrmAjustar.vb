Public Class FrmAjustar

    Public CONClave As String
    Public ALMClave As String
    Public TipoConteo As Integer

    Private SUCClave As String
    Private dtConteo As DataTable
    Private LoadDif As Boolean = False

    Private Sub FrmAjustar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoConteo Is Nothing Then
            ModPOS.MtoConteo.ActualizarGrid()
        End If
        ModPOS.Ajustar.Dispose()
        ModPOS.Ajustar = Nothing
        End Sub

    Private Sub FrmAjustar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", ALMClave)
        If dt.Rows.Count > 0 Then
            SUCClave = dt.Rows(0)("SUCClave")
        End If
        dt.Dispose()

        ActualizaDiferencia()
        LoadDif = True
        If LoadDif AndAlso Not Me.GridDiferencias.GetValue(0) Is Nothing Then
            ModPOS.ActualizaGrid(False, GridUbicaciones, "sp_dif_conteo_det", "@CONClave", CONClave, "@PROClave", Me.GridDiferencias.GetValue(0))
            GridUbicaciones.RootTable.Columns(0).Visible = False
            GridUbicaciones.CurrentTable.Columns(1).Selectable = False
            GridUbicaciones.CurrentTable.Columns(2).Selectable = False
            GridUbicaciones.CurrentTable.Columns(3).Selectable = False
            GridUbicaciones.CurrentTable.Columns(4).Selectable = False
            GridUbicaciones.CurrentTable.Columns(5).Selectable = False
            GridUbicaciones.CurrentTable.Columns(7).Selectable = False
            GridUbicaciones.CurrentTable.Columns(8).Selectable = False



        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub ActualizaDiferencia()
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        dtConteo = ModPOS.Recupera_Tabla("sp_dif_conteo", "@CONClave", CONClave, "@Forma", TipoConteo)

        If Not dtConteo Is Nothing Then
            GridDiferencias.DataSource = dtConteo
            GridDiferencias.RetrieveStructure()
            GridDiferencias.AutoSizeColumns()
            GridDiferencias.RootTable.Columns(0).Visible = False
            GridDiferencias.RootTable.Columns("Estado").Visible = False
            GridDiferencias.CurrentTable.Columns(2).Selectable = False
            GridDiferencias.CurrentTable.Columns(3).Selectable = False
            GridDiferencias.CurrentTable.Columns(4).Selectable = False
            GridDiferencias.CurrentTable.Columns(5).Selectable = False
            GridDiferencias.CurrentTable.Columns(6).Selectable = False
            GridDiferencias.CurrentTable.Columns(7).Selectable = False
            GridDiferencias.CurrentTable.Columns(8).Visible = False

            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDiferencias.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "2")

            fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
            fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            GridDiferencias.RootTable.FormatConditions.Add(fc)

        End If

        lblPorc.Text = "0 %"
        PBar.Value = 0
    End Sub

    Private Sub GridDiferencias_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDiferencias.CellValueChanged
        PBar.Value = 0
        lblPorc.Text = "0 %"
    End Sub

    Private Sub GridDiferencias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDiferencias.SelectionChanged
        If LoadDif AndAlso Not Me.GridDiferencias.GetValue(0) Is Nothing Then
            ModPOS.ActualizaGrid(False, GridUbicaciones, "sp_dif_conteo_det", "@CONClave", CONClave, "@PROClave", Me.GridDiferencias.GetValue(0))
            GridUbicaciones.RootTable.Columns(0).Visible = False
            GridUbicaciones.CurrentTable.Columns(1).Selectable = False
            GridUbicaciones.CurrentTable.Columns(2).Selectable = False
            GridUbicaciones.CurrentTable.Columns(3).Selectable = False
            GridUbicaciones.CurrentTable.Columns(4).Selectable = False
            GridUbicaciones.CurrentTable.Columns(5).Selectable = False
            GridUbicaciones.CurrentTable.Columns(7).Selectable = False
            GridUbicaciones.CurrentTable.Columns(8).Selectable = False
        End If
    End Sub

   
    Private Sub GridUbicaciones_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridUbicaciones.CellUpdated
        If GridUbicaciones.CurrentColumn.Caption = "Fisica" Then
            If IsNumeric(GridUbicaciones.GetValue("Fisica")) Then
                If GridUbicaciones.GetValue("Fisica") = GridUbicaciones.GetValue("Teorica") Then
                    If MessageBox.Show("Se eliminara la diferencia registrada durante el conteo, Esta deacuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        GridUbicaciones.SetValue(7, GridUbicaciones.GetValue("Fisica") - GridUbicaciones.GetValue("Teorica"))
                        ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", GridUbicaciones.GetValue("Ubicación"), "@PROClave", GridUbicaciones.GetValue("PROClave"), "@Cantidad", GridUbicaciones.GetValue("Fisica"), "@Usuario", ModPOS.UsuarioActual)
                    End If
                Else
                    GridUbicaciones.SetValue(7, GridUbicaciones.GetValue("Fisica") - GridUbicaciones.GetValue("Teorica"))
                    ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", GridUbicaciones.GetValue("Ubicación"), "@PROClave", GridUbicaciones.GetValue("PROClave"), "@Cantidad", GridUbicaciones.GetValue("Fisica"), "@Usuario", ModPOS.UsuarioActual)
                End If
            Else
                MessageBox.Show("¡La cantidad Fisica de producto debe ser numerica!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                GridUbicaciones.SetValue("Fisica", 0)
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dtConteo Is Nothing AndAlso dtConteo.Rows.Count > 0 Then
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
                            ModPOS.Ejecuta("sp_ajusta_conteo", "@Forma", TipoConteo, "@ALMClave", ALMClave, "@CONClave", CONClave, "@PROClave", foundRows(i)("PROClave"), "@Usuario", ModPOS.UsuarioActual)
                            PBar.Value = i + 1
                            lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                            lblPorc.Refresh()
                        Next
                        Cursor.Current = Cursors.Default
                        ' ActualizaDiferencia()
                    End If
                End If
                a.Dispose()
            Else
                MessageBox.Show("¡Debe marcar los productos que desea ajustar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("¡No hay productos disponibles para realizar ajuste o ya fueron ajustados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "reportDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ajustes", "@CONClave", CONClave))
        OpenReport.PrintPreview("Ajustes de Inventario", "CRAjustes.rpt", pvtaDataSet, "")
    End Sub
End Class