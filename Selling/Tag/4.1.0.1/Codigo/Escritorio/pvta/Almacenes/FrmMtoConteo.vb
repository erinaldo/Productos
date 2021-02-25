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
        ModPOS.ActualizaGrid(False, Me.GridConteos, "sp_muestra_conteos", "@SUCClave", IIf(cmbSucursal.SelectedValue Is Nothing, " ", cmbSucursal.SelectedValue), "@Periodo", Periodo, "@Mes", Mes)
        Me.GridConteos.RootTable.Columns("CONClave").Visible = False
      
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



        If Me.cmbSucursal.SelectedValue Is Nothing Then
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

          With cmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        If ModPOS.SucursalPredeterminada <> "" Then
            cmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
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

                        .Clave = IIf(dt.Rows(0)("Clave").GetType.Name = "DBNull", "", dt.Rows(0)("Clave"))
                        .Tipo = IIf(dt.Rows(0)("Tipo").GetType.Name = "DBNull", 1, dt.Rows(0)("Tipo"))
                        .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                        .ALMClave = IIf(dt.Rows(0)("ALMClave").GetType.Name = "DBNull", "", dt.Rows(0)("ALMClave"))
                        .CONClave = dt.Rows(0)("CONClave")
                    End With
                End If
                ModPOS.Conteo.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Conteo.Show()
                ModPOS.Conteo.BringToFront()
            Else
                MessageBox.Show("El conteo actual no puede ser modificado debido a que se encuentra en un estado diferente a Definición", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            BtnAjustar.Enabled = False
            BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAjustar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAjustar.Click
        If validaForm() Then
            If sConteoSelected <> "" Then
                

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                If dt.Rows(0)("Estado") = 3 Then
                    Select Case MessageBox.Show("¿Esta seguro que desea ajustar el Conteo: " & sClave & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            If ModPOS.Ajustar Is Nothing Then
                                ModPOS.Ajustar = New FrmAjustar
                                With ModPOS.Ajustar
                                    .Padre = "Ajustar"
                                    .CONClave = dt.Rows(0)("CONClave")
                                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                                End With
                            End If
                            ModPOS.Ajustar.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Ajustar.Show()
                            ModPOS.Ajustar.BringToFront()
                    End Select
                Else
                    MessageBox.Show("Solo es posible ajuster Conteos que se encuentran  en Estado igual a Finalizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                dt.Dispose()

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
        If Not cmbSucursal.SelectedValue Is Nothing Then
            If ModPOS.Conteo Is Nothing Then
                ModPOS.Conteo = New FrmConteos
                ModPOS.Conteo.Padre = "Nuevo"
                ModPOS.Conteo.SUCClave = cmbSucursal.SelectedValue
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
                            ModPOS.Ejecuta("st_elimina_conteo", "@CONClave", sConteoSelected)
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
                Dim sFrase As String
                Dim iEstado As Integer

                If bIniciar = True Then
                    sFrase = "Iniciar"
                Else
                    sFrase = "Finalizar"
                End If

               
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_conteo", "@CONClave", sConteoSelected)
                iEstado = dt.Rows(0)("Estado")
                dt.Dispose()

                If bIniciar = True Then
                    If iEstado = 1 Then
                        Select Case MessageBox.Show("¿Esta seguro que desea " & sFrase & " el Conteo: " & sClave & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.Yes
                                Dim bError As Boolean = False
                                dt = ModPOS.Recupera_Tabla("st_obtener_apartados", "@CONClave", sConteoSelected)
                                If dt.Rows.Count > 0 Then
                                    MessageBox.Show("El conteo seleccionado no puede ser iniciado debido a que existen ubicaciones con producto apartado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Dim b As New FrmConsultaGen
                                    b.Text = "Pedidos con Apartados"
                                    ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_obtener_doc_apartados", "@CONClave", sConteoSelected)
                                    b.ShowDialog()
                                    b.Dispose()

                                    bError = True
                                End If
                                dt.Dispose()

                                If bError = False Then
                                    'Valida si se encuentran todas las ubicacioens asignadas
                                    dt = ModPOS.Recupera_Tabla("st_conteo_asignacion", "@CONClave", sConteoSelected)
                                    Dim foundRows() As DataRow
                                    foundRows = dt.Select(" Asignado = ''")
                                    If foundRows.Length > 0 Then
                                        MessageBox.Show("El conteo seleccionado no puede ser iniciado debido a que tiene ubicaciones pendietnes de asignar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


                                        Dim b As New FrmConsultaGen
                                        b.Text = "Ubicación Pendiente"
                                        ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_obtener_sin_asg", "@CONClave", sConteoSelected)
                                        b.ShowDialog()
                                        b.Dispose()


                                    Else
                                        ModPOS.Ejecuta("sp_act_edo_conteo", "@CONClave", sConteoSelected)
                                        ActualizarGrid()
                                    End If
                                    dt.Dispose()
                                End If

                        End Select
                    End If

                Else

                    If iEstado = 2 OrElse iEstado = 3 Then
                        If iEstado = 2 Then
                            Select MessageBox.Show("¿Esta seguro que desea " & sFrase & " el Conteo: " & sClave & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.Yes
                                    ModPOS.Ejecuta("sp_end_conteo", "@CONClave", dt.Rows(0)("CONClave"), "@Usuario", ModPOS.UsuarioActual)

                                    ActualizarGrid()
                            End Select
                        End If

                        If ModPOS.Ajustar Is Nothing Then
                            ModPOS.Ajustar = New FrmAjustar
                            With ModPOS.Ajustar
                                .Padre = "Finalizar"
                                .CONClave = dt.Rows(0)("CONClave")
                            End With
                        End If
                        ModPOS.Ajustar.StartPosition = FormStartPosition.CenterScreen
                        ModPOS.Ajustar.Show()
                        ModPOS.Ajustar.BringToFront()

                    Else
                        MessageBox.Show("El conteo seleccionado no se encuentra en estado de Ejecución por lo que no es posible Finalizarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

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

   

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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