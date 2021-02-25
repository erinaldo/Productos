Public Class FrmMtoIngreso

    Public Mes As Integer
    Public Periodo As Integer

    Private sALMClave As String

    Private sIngresoSelected, sReferencia As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private Impresora As String

    Private bLoad As Boolean = False

    Private Sub FrmMtoIngreso_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoIngresos.Dispose()
        ModPOS.MtoIngresos = Nothing
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Public Sub modificarIngreso()
        If sIngresoSelected <> "" Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_ingreso", "@INGClave", Me.sIngresoSelected)
            If dt.Rows(0)("Estado") = 1 Then
                If ModPOS.Ingreso Is Nothing Then
                    ModPOS.Ingreso = New FrmIngreso
                    With ModPOS.Ingreso
                        .StartPosition = FormStartPosition.CenterScreen
                        .bNuevo = False
                        .TxtReferencia.Enabled = False
                        .INGClave = dt.Rows(0)("INGClave")
                        .SUCClave = dt.Rows(0)("SUCClave")
                        .ALMClave = dt.Rows(0)("ALMClave")
                        .Referencia = dt.Rows(0)("Referencia")
                        .Nota = dt.Rows(0)("Notas")
                        .Estado = dt.Rows(0)("Estado")
                        .PRVClave = IIf(dt.Rows(0)("PRVClave").GetType.Name = "DBNull", "", dt.Rows(0)("PRVClave"))
                        .TxtAlmacen.Text = dt.Rows(0)("NAlmacen")
                        .TxtEstado.Text = dt.Rows(0)("NEstado")
                        dt.Dispose()
                    End With
                End If
                ModPOS.Ingreso.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Ingreso.Show()
                ModPOS.Ingreso.BringToFront()
            Else
                MessageBox.Show("No es posible modificar un Ingreso que ya ha sido autorizado/cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("No se ha seleccionado algun Ingreso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FrmMtoIngreso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox4


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_alm_def"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If


        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month


      
        refrescaGrid()

        bLoad = True

    End Sub

    Public Sub refrescaGrid()
        Cursor.Current = Cursors.WaitCursor

        If CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = ""
        Else
            sALMClave = CmbAlmacen.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, Me.GridIngresos, "sp_muestra_ingreso", "@Almacen", sALMClave, "@Periodo", Periodo, "@Mes", Mes)
        Me.GridIngresos.RootTable.Columns("INGClave").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridIngresos.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelado")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridIngresos.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default

    End Sub


    Private Sub BtnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngreso.Click
        If validaForm() Then
            If ModPOS.Ingreso Is Nothing Then
                ModPOS.Ingreso = New FrmIngreso
                ModPOS.Ingreso.SUCClave = CmbSucursal.SelectedValue
                ModPOS.Ingreso.ALMClave = CmbAlmacen.SelectedValue
                ModPOS.Ingreso.TxtAlmacen.Text = CmbAlmacen.SelectedItem.row.itemarray(1)
                ModPOS.Ingreso.bNuevo = True
            End If
            ModPOS.Ingreso.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Ingreso.Show()
            ModPOS.Ingreso.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sIngresoSelected <> "" Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ingreso", "@INGClave", sIngresoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_detalle_ingreso", "@INGClave", sIngresoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_detalle_ubcing", "@INGClave", sIngresoSelected))
            OpenReport.PrintPreview("Ingreso de Almacén", "CRIngreso.rpt", pvtaDataSet, "")
        Else
            MessageBox.Show("¡No se ha seleccionado un Ingreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridIngresos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridIngresos.DoubleClick
        If Not GridIngresos.GetValue(0) Is Nothing Then
            modificarIngreso()
        End If
    End Sub

    Private Sub GridIngresos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridIngresos.SelectionChanged
        If Not GridIngresos.GetValue(0) Is Nothing Then
            sIngresoSelected = GridIngresos.GetValue("INGClave")
            sReferencia = GridIngresos.GetValue("Referencia")
        Else
            sIngresoSelected = ""
            sReferencia = ""
        End If
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarIngreso()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then
            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_filtra_alm_def"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub BtnEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEtiquetas.Click
        If sIngresoSelected <> "" Then
            Dim a As New FrmPrintLabelCode
            a.COMClave = sIngresoSelected
            a.iTipoDOc = 2
            a.ShowDialog()
            a.Dispose()
        Else
            MessageBox.Show("¡No se ha seleccionado una Ingreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sIngresoSelected <> "" Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar el ingreso: " & sReferencia & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_ingreso", "@INGClave", Me.sIngresoSelected)
                    If dt.Rows(0)("Estado") = 1 Then
                        ModPOS.Ejecuta("sp_cancela_ingreso", "@INGClave", sIngresoSelected, "@Usuario", ModPOS.UsuarioActual)
                        refrescaGrid()
                        dt.Dispose()
                    Else
                        MessageBox.Show("No es posible cancelar el Ingreso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

            End Select
        End If

    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub
End Class