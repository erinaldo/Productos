Public Class FrmAjustar
    Public Padre As String
    Public CONClave As String
    Public SUCClave As String

    Private Forma As Integer

    Private dtConteo, dtConteoDetalle As DataTable
    Private LoadDif As Boolean = False

    Private Sub FrmAjustar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoConteo Is Nothing Then
            ModPOS.MtoConteo.ActualizarGrid()
        End If
        ModPOS.Ajustar.Dispose()
        ModPOS.Ajustar = Nothing
        End Sub

    Private Sub FrmAjustar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Padre = "Ajustar" Then
            Me.Text = "Ajustar"
            Forma = 2
            lblGuardando.Visible = False
            PBarGuardando.Visible = False
            lblPorc.Visible = False
        Else
            Me.Text = "Resumen del Conteo"
            BtnGuardar.Text = "Guardar"
            Forma = 1
        End If


        obtenerResumen()
        LoadDif = True

        If LoadDif AndAlso Not Me.GridResumen.GetValue(0) Is Nothing Then
            obtenerDetalle(GridResumen.GetValue(0))
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub obtenerResumen()
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        dtConteo = ModPOS.Recupera_Tabla("sp_dif_conteo", "@CONClave", CONClave, "@Forma", Forma)

        If Not dtConteo Is Nothing Then
            GridResumen.DataSource = dtConteo
            GridResumen.RetrieveStructure()
            GridResumen.AutoSizeColumns()
            GridResumen.RootTable.Columns("PROClave").Visible = False

            GridResumen.RootTable.Columns("Clave").Width = 70
            GridResumen.RootTable.Columns("Nombre").Width = 160
            GridResumen.RootTable.Columns("Fisica").Width = 30
            GridResumen.RootTable.Columns("Teorica").Width = 30
            GridResumen.RootTable.Columns("Dif").Width = 20

            If Forma = 1 Then
                Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridResumen.RootTable.Columns("Dif"), Janus.Windows.GridEX.ConditionOperator.NotEqual, 0)
                fc.FormatStyle.ForeColor = System.Drawing.Color.Red
                GridResumen.RootTable.FormatConditions.Add(fc)
            End If

        End If

    End Sub


    Private Sub obtenerDetalle(ByVal sPROClave As String)
        If Not dtConteoDetalle Is Nothing Then
            dtConteoDetalle.Dispose()
        End If

        dtConteoDetalle = ModPOS.Recupera_Tabla("sp_dif_conteo_det", "@CONClave", CONClave, "@PROClave", sPROClave, "@Forma", Forma)

        If Not dtConteoDetalle Is Nothing Then
            GridDetalle.DataSource = dtConteoDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
            GridDetalle.RootTable.Columns("CNDClave").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("UBCClave").Visible = False
            GridDetalle.RootTable.Columns("Modificado").Visible = False

            GridDetalle.RootTable.Columns("Clave").Width = 70
            GridDetalle.RootTable.Columns("Nombre").Width = 160
            GridDetalle.RootTable.Columns("Fisica").Width = 30
            GridDetalle.RootTable.Columns("Teorica").Width = 30
        End If

        lblPorc.Text = "0 %"
        PBarGuardando.Value = 0
    End Sub

    Private Sub GridResumen_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridResumen.CurrentCellChanged
        GridResumen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub



    Private Sub GridDiferencias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridResumen.SelectionChanged
        If LoadDif AndAlso Not Me.GridResumen.GetValue(0) Is Nothing Then
            obtenerDetalle(GridResumen.GetValue(0))
        End If
    End Sub


    Private Sub GridDetalle_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellUpdated
        If GridDetalle.CurrentColumn.Caption = "Fisica" Then
            If IsNumeric(GridDetalle.GetValue("Fisica")) Then
                If CDbl(GridDetalle.GetValue("Fisica")) < 0 Then
                    MessageBox.Show("¡La cantidad Fisica debe ser mayor o igual a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Fisica", 0)
                End If
            Else
                MessageBox.Show("¡La cantidad Fisica de producto debe ser numerica!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                GridDetalle.SetValue("Fisica", 0)
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Forma = 1 Then
            'Opcion para finalizar
            If Not dtConteoDetalle Is Nothing AndAlso dtConteoDetalle.Rows.Count > 0 Then
                Dim foundRows() As DataRow
                foundRows = dtConteoDetalle.Select("Modificado <> Fisica")
                If foundRows.GetLength(0) > 0 Then

                    Dim i As Integer
                    PBarGuardando.Maximum = foundRows.GetLength(0)
                    Cursor.Current = Cursors.WaitCursor
                    For i = 0 To foundRows.GetUpperBound(0)

                        ModPOS.Ejecuta("sp_act_conteodet", _
                                   "@CONClave", CONClave, _
                                   "@UBCClave", foundRows(i)("UBCClave"), _
                                   "@PROClave", foundRows(i)("PROClave"), _
                                   "@Cantidad", foundRows(i)("Fisica"), _
                                   "@Usuario", ModPOS.UsuarioActual)


                        PBarGuardando.Value = i + 1
                        lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBarGuardando.Maximum, 2)) & "%"
                        lblPorc.Refresh()
                    Next

                    obtenerResumen()

                    Cursor.Current = Cursors.Default



                End If
            Else
                MessageBox.Show("¡No hay productos disponibles para actualizar en la ubicación seleccionada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf Forma = 2 Then
            If Not dtConteo Is Nothing AndAlso dtConteo.Rows.Count > 0 Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("st_costo_ajuste", "@CONClave", CONClave)

                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.MontodeAutorizacion = CDec(dt.Rows(0)("Costo"))
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado Then
                        Cursor.Current = Cursors.WaitCursor
                        ModPOS.Ejecuta("sp_ajusta_conteo", "@CONClave", CONClave, "@Usuario", a.Autoriza)
                        Cursor.Current = Cursors.Default
                        Me.Close()
                    End If
                End If

            Else
                MessageBox.Show("¡No hay productos disponibles para realizar ajuste o ya fueron ajustados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "reportDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ajustes", "@CONClave", CONClave, "@Forma", Forma))

        If Forma = 1 Then

            OpenReport.PrintPreview("Conteo de Inventario", "CRAjustes.rpt", pvtaDataSet, "")
        Else

            OpenReport.PrintPreview("Ajustes de Inventario", "CRAjustes.rpt", pvtaDataSet, "")
        End If

    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Forma = 1 Then
            If Not GridDetalle.CurrentColumn Is Nothing Then
                If GridDetalle.CurrentColumn.Caption = "Fisica" Then
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                Else
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                End If
            End If
        Else
            GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        End If

    End Sub
End Class