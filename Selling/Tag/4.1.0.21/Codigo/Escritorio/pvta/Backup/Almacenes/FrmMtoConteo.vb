Public Class FrmMtoConteo

    Public Mes As Integer
    Public Periodo As Integer

    Private sALMClave As String
    Private sConteoSelected, sClave As String
    Private bIniciar As Boolean = False
    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String

    Private bLoad As Boolean = False

    Public Sub ActualizarGrid()
        ModPOS.ActualizaGrid(False, Me.GridConteos, "sp_muestra_conteos", "@Almacen", IIf(CmbAlmacen.SelectedValue Is Nothing, " ", CmbAlmacen.SelectedValue), "@Periodo", Periodo, "@Mes", Mes)
        Me.GridConteos.RootTable.Columns("CONClave").Visible = False
        Me.GridConteos.RootTable.Columns("TipoConteo").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridConteos.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Finalizado Con Diferencia")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridConteos.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub FrmMtoConteo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoConteo.Dispose()
        ModPOS.MtoConteo = Nothing
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0



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

  
    Private Sub FrmMtoIngreso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Cursor.Current = Cursors.WaitCursor

        '  Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

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

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month


        ActualizarGrid()

        Cursor.Current = Cursors.Default

        bLoad = True
    End Sub

    Private Sub GridConteos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridConteos.DoubleClick
        If sConteoSelected <> "" Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)

            If dt.Rows(0)("Estado") = 1 Then

                If ModPOS.Conteo Is Nothing Then

                    ModPOS.Conteo = New FrmConteos
                    With ModPOS.Conteo
                        .Padre = "Modificar"
                        .CmbTipo.Enabled = False
                        .CmbAlmacen.Enabled = False
                        .Clave = IIf(dt.Rows(0)("Clave").GetType.Name = "DBNull", "", dt.Rows(0)("Clave"))
                        .Tipo = dt.Rows(0)("Tipo")
                        .TipoConteo = dt.Rows(0)("Tipo")
                        .Almacen = dt.Rows(0)("ALMClave")
                        .CONClave = dt.Rows(0)("CONClave")
                    End With
                End If
                ModPOS.Conteo.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Conteo.Show()
                ModPOS.Conteo.BringToFront()
            Else
                MessageBox.Show("El conteo actual no puede ser modificado debido a que se encuentra en un estado diferente a En definición", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dt.Dispose()
        End If

    End Sub

    Private Sub GridConteos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridConteos.SelectionChanged
        If Not GridConteos.GetValue(0) Is Nothing Then
            sConteoSelected = GridConteos.GetValue("CONClave")
            sClave = IIf(GridConteos.GetValue("Clave").GetType.Name = "DBNull", "", GridConteos.GetValue("Clave"))
            BtnContar.Enabled = True
            BtnFinalizar.Enabled = True
            BtnImprimir.Enabled = True
            BtnAjustar.Enabled = True
            BtnEliminar.Enabled = True
            If GridConteos.GetValue("Estado") = "Definición" Then
                BtnFinalizar.Text = "Iniciar"
                BtnFinalizar.ToolTipText = "Iniciar el Conteo Seleccionado"
                bIniciar = True
            Else
                BtnFinalizar.Text = "Finalizar"
                BtnFinalizar.ToolTipText = "Finaliza el Conteo Seleccionado"
                bIniciar = False
            End If
        Else
            sConteoSelected = ""
            sClave = ""
            BtnContar.Enabled = False
            BtnFinalizar.Enabled = False
            BtnImprimir.Enabled = False
            BtnAjustar.Enabled = False
            BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAjustar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAjustar.Click
        If validaForm() Then
            If sConteoSelected <> "" Then
                Select Case MessageBox.Show("¿Esta seguro que desea ajustar el Conteo: " & sClave & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                        If dt.Rows(0)("Estado") = 3 Then
                            If ModPOS.Ajustar Is Nothing Then
                                ModPOS.Ajustar = New FrmAjustar
                                With ModPOS.Ajustar
                                    .CONClave = dt.Rows(0)("CONClave")
                                    .ALMClave = dt.Rows(0)("ALMClave")
                                    .TipoConteo = dt.Rows(0)("TipoConteo")
                                End With
                            End If
                            ModPOS.Ajustar.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Ajustar.Show()
                            ModPOS.Ajustar.BringToFront()
                        Else
                            MessageBox.Show("El conteo No se encuentra Finalizado o No tiene Diferencias", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        dt.Dispose()
                End Select
            Else
                MessageBox.Show("No a seleccionado algun registro de conteo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnContar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnContar.Click
        If validaForm() Then
            If sConteoSelected <> "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                Select Case CInt(dt.Rows(0)("Estado"))
                    Case Is = 2
                        Select Case CInt(dt.Rows(0)("TipoConteo"))
                            Case Is = 1
                                If ModPOS.Contar Is Nothing Then
                                    ModPOS.Contar = New FrmContar
                                    With ModPOS.Contar
                                        .Tipo = dt.Rows(0)("Tipo")
                                        .CONClave = dt.Rows(0)("CONClave")
                                        .ALMClave = dt.Rows(0)("ALMClave")
                                    End With
                                End If
                                ModPOS.Contar.Text = "Conteo: " & sClave
                                ModPOS.Contar.StartPosition = FormStartPosition.CenterScreen
                                ModPOS.Contar.Show()
                                ModPOS.Contar.BringToFront()
                            Case Is = 2
                                'Agregar nuevo conteo por linea
                                If ModPOS.ContarProducto Is Nothing Then
                                    ModPOS.ContarProducto = New FrmContarProducto
                                    With ModPOS.ContarProducto
                                        .Tipo = dt.Rows(0)("Tipo")
                                        .CONClave = dt.Rows(0)("CONClave")
                                        .ALMClave = dt.Rows(0)("ALMClave")
                                    End With
                                End If
                                ModPOS.ContarProducto.Text = "Conteo: " & sClave
                                ModPOS.ContarProducto.StartPosition = FormStartPosition.CenterScreen
                                ModPOS.ContarProducto.Show()
                                ModPOS.ContarProducto.BringToFront()
                        End Select
                    Case Is = 1
                        MessageBox.Show("El Conteo actual se encuentra en Definición, debera Iniciarlo antes de Comenzar a Contar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case Is > 2
                        MessageBox.Show("El Conteo se encuentra Finalizado, por lo que no es posible registrar más información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Select
                dt.Dispose()
            Else
                MessageBox.Show("No a seleccionado algun registro de conteo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnConteo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConteo.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            If ModPOS.Conteo Is Nothing Then
                ModPOS.Conteo = New FrmConteos
                ModPOS.Conteo.Padre = "Nuevo"
                ModPOS.Conteo.Almacen = CmbAlmacen.SelectedValue
            End If
            ModPOS.Conteo.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Conteo.Show()
            ModPOS.Conteo.BringToFront()
        Else
            MessageBox.Show("Debe seleccionar un almacén para configurar el conteo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnEliminar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If validaForm() Then
            If sConteoSelected <> "" Then
                Select Case MessageBox.Show("¿Esta seguro que desea cancelar el Conteo: " & sClave & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                        If dt.Rows(0)("Estado") = 1 Then
                            ModPOS.Ejecuta("sp_borra_conteo", "@CONClave", sConteoSelected)
                            ActualizarGrid()
                        Else
                            MessageBox.Show("El conteo se encuentra en estado de Ejecución o Finalizado por lo que no es posible eliminarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        dt.Dispose()
                End Select
            Else
                MessageBox.Show("No a seleccionado algun registro de conteo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFinalizar.Click
        If validaForm() Then
            If sConteoSelected <> "" Then
                Select Case MessageBox.Show("¿Esta seguro que desea Finalizar el Conteo: " & sClave & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        If bIniciar = True Then
                            ModPOS.Ejecuta("sp_act_edo_conteo", "@CONClave", sConteoSelected)
                            ActualizarGrid()
                        Else
                            Dim dt As DataTable
                            dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                            If dt.Rows(0)("Estado") = 2 Then
                                ModPOS.Ejecuta("sp_end_conteo", "@Forma", dt.Rows(0)("TipoConteo"), "@CONClave", dt.Rows(0)("CONClave"), "@Usuario", ModPOS.UsuarioActual)
                                ActualizarGrid()
                            Else
                                MessageBox.Show("El conteo seleccionado no se encuentra en estado de Ejecución por lo que no es posible Finalizarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            dt.Dispose()
                        End If
                End Select
            Else
                MessageBox.Show("No a seleccionado algun registro de conteo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If validaForm() Then
            If sConteoSelected <> "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "reportDataSet"
                Select Case CInt(dt.Rows(0)("TipoConteo"))
                    Case Is = 1

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_conteo_det", "@CONClave", sConteoSelected, "@ALMClave", dt.Rows(0)("ALMClave"), "@Tipo", dt.Rows(0)("Tipo")))
                        OpenReport.PrintPreview("Conteo", "CRMarbete.rpt", pvtaDataSet, "")
                    Case Is = 2
                        'agregar marbeteporlinea
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_marbete", "@CONClave", sConteoSelected))
                        OpenReport.PrintPreview("Conteo", "CRMarbeteProducto.rpt", pvtaDataSet, "")
                End Select
                dt.Dispose()
            Else
                MessageBox.Show("No a seleccionado algun registro de conteo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnSalir_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

   

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bLoad Then
            If validaForm() Then
                ActualizarGrid()
            End If
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            ActualizarGrid()
        End If
    End Sub
End Class