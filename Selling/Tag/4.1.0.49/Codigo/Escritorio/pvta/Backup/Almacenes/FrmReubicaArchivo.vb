Public Class FrmReubicaArchivo
    Private dtTemporal, dtDestino As DataTable
    Private UBCOrigen As String
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    
    Private Sub FrmReubicaArchivo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ReubicaArchivo.Dispose()
        ModPOS.ReubicaArchivo = Nothing
    End Sub

    Private Sub FrmReubicaArchivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        With CmbOrigen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbOrigen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        creaTablaDestino()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub parpadea(ByVal i As Integer, ByVal OnOff As Boolean)
        If OnOff = True Then
            reloj = New parpadea(Me.alerta(i))
            reloj.Enabled = True
            reloj.Start()
        Else
            alerta(i).Visible = False
        End If
    End Sub

    Private Sub creaTablaDestino()
        dtDestino = ModPOS.CrearTabla("ReubicacionDetalle", _
                                                  "PROClave", "System.String", _
                                                  "Clave", "System.String", _
                                                  "C.Barras", "System.String", _
                                                  "Nombre", "System.String", _
                                                  "Origen", "System.Double", _
                                                  "Destino", "System.Double", _
                                                  "Ubicar en", "System.String", _
                                                  "flag", "System.Int32")

        GridDestino.DataSource = dtDestino
        GridDestino.RetrieveStructure()
        GridDestino.RootTable.Columns("PROClave").Visible = False
        GridDestino.RootTable.Columns("flag").Visible = False
        GridDestino.CurrentTable.Columns("Clave").Selectable = False
        GridDestino.CurrentTable.Columns("C.Barras").Selectable = False
        GridDestino.CurrentTable.Columns("Nombre").Selectable = False
        GridDestino.CurrentTable.Columns("Origen").Selectable = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDestino.RootTable.Columns("flag"), Janus.Windows.GridEX.ConditionOperator.Equal, 2)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDestino.RootTable.FormatConditions.Add(fc)

    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim a As New MeSearch
        If Not CmbOrigen.SelectedValue Is Nothing Then
            a.ProcedimientoAlmacenado = "sp_search_ubicacion"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = CmbOrigen.SelectedValue
            parpadea(0, False)
            a.OcultaCol = True
            a.OcultaColNum = 0
        Else
            parpadea(0, True)
            MessageBox.Show("¡El Almacén no es valido o es requerido!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        
        a.NumColDes = 0
        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then

            If dtDestino Is Nothing OrElse dtDestino.Rows.Count = 0 Then
                Me.TxtUbcOrigen.Text = a.Descripcion
                UBCOrigen = a.valor
                parpadea(1, False)
            Else
                MessageBox.Show("No es posible cambiar la ubicación cuando hay registros pendientes de procesar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            UBCOrigen = ""
            TxtUbcOrigen.Text = ""
            Beep()
            parpadea(1, True)
            MessageBox.Show("La ubicación origen es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
            a.Dispose()
    End Sub

 
    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        If CmbOrigen.SelectedValue Is Nothing Then
            parpadea(0, True)
            MessageBox.Show("El Almacén origen es requerido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            parpadea(0, False)

            If UBCOrigen = "" Then
                parpadea(1, True)
                MessageBox.Show("La ubicación origen es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                parpadea(1, False)
            End If
        End If

        Dim FileName, Path As String
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            TxtPath.Text = OpenFileDialog1.FileName
            FileName = OpenFileDialog1.SafeFileName
            Path = TxtPath.Text.Replace(FileName, "")

            

            If FileName.Contains(".CSV") OrElse FileName.Contains(".csv") Then

                dtTemporal = ReadCSV(TxtPath.Text, 3)
                'ModPOS.Recupera_Consulta("SELECT * FROM OPENROWSET ('MSDASQL', 'Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=" & Path & ";', 'SELECT * from " & FileName & "');")

                If Not dtTemporal Is Nothing AndAlso dtTemporal.Rows.Count > 0 Then
                    parpadea(2, False)

                    If Not dtDestino Is Nothing Then
                        dtDestino.Dispose()
                    End If

                    creaTablaDestino()

                    Dim i As Integer

                    Dim dtProducto As DataTable

                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.Show("Procesando Archivo...")

                    PBar.Maximum = dtTemporal.Rows.Count

                    For i = 0 To dtTemporal.Rows.Count - 1

                        PBar.Value = i + 1
                        lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                        lblPorc.Refresh()

                        If Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" Then

                            dtProducto = ModPOS.Recupera_Tabla("sp_recupera_prod_gtin", "@UBCClave", UBCOrigen, "@GTIN", dtTemporal.Rows(i)(1))
                            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count = 1 Then
                                If IsNumeric(dtTemporal.Rows(i)(2)) Then

                                    Dim foundRows() As System.Data.DataRow
                                    foundRows = dtDestino.Select("PROClave = '" & dtProducto.Rows(0)("PROClave") & "' and [Ubicar en]='" & dtTemporal.Rows(i)(0) & "'")

                                    If foundRows.Length = 0 Then

                                        Dim row1 As DataRow
                                        row1 = dtDestino.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("PROClave") = dtProducto.Rows(0)("PROClave")
                                        row1.Item("Clave") = dtProducto.Rows(0)("Clave")
                                        row1.Item("C.Barras") = dtProducto.Rows(0)("C.Barras")
                                        row1.Item("Nombre") = dtProducto.Rows(0)("Nombre")
                                        row1.Item("Origen") = dtProducto.Rows(0)("Origen")
                                        row1.Item("Destino") = dtTemporal.Rows(i)(2)
                                        row1.Item("Ubicar en") = dtTemporal.Rows(i)(0)
                                        row1.Item("flag") = 0
                                        dtDestino.Rows.Add(row1)
                                    End If
                                End If
                            End If
                        End If
                    Next

                    frmStatusMessage.Close()

                    Cursor.Current = Cursors.Default


                    If dtDestino.Rows.Count = 0 Then
                        parpadea(2, True)
                        MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Ubicación,Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        TxtPath.Text = ""
                        FileName = ""
                    End If

                Else
                    parpadea(2, True)
                    MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Ubicación,Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    TxtPath.Text = ""
                    FileName = ""
                End If
            End If
        Else
            parpadea(2, True)
            TxtPath.Text = ""
            FileName = ""
            If Not dtDestino Is Nothing Then
                dtDestino.Dispose()
            End If
        End If
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If Not dtDestino Is Nothing AndAlso dtDestino.Rows.Count > 0 Then

            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Procesando Movimientos de Reubicación...")

            PBar.Value = 0
            lblPorc.Text = "0%"

            PBar.Maximum = dtDestino.Rows.Count

            Dim i As Integer
            Dim dtUbicacion As DataTable

            dtUbicacion = ModPOS.Recupera_Tabla("sp_recupera_ubicaciones", "@ALMClave", CmbOrigen.SelectedValue)

            Dim foundRows() As System.Data.DataRow

            For i = 0 To dtDestino.Rows.Count - 1

                foundRows = dtUbicacion.Select("Ubicacion = '" & dtDestino.Rows(i)(6).ToString.Trim & "'")

                If foundRows.Length > 0 Then

                    If CDbl(dtDestino.Rows(i)("Destino")) <= CDbl(dtDestino.Rows(i)("Origen")) Then
                        If UBCOrigen <> foundRows(0)("UBCClave") Then
                            'Realiza Movimiento de Reubicación
                            ModPOS.Ejecuta("sp_reubicar", "@Primera", 0, "@PROClave", dtDestino.Rows(i)("PROClave").ToString.Trim, "@UBCOrigen", UBCOrigen, "@UBCDestino", foundRows(0)("UBCClave"), "@Cantidad", dtDestino.Rows(i)("Destino"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                        dtDestino.Rows(i)("flag") = 1
                    Else
                        dtDestino.Rows(i)("flag") = 2
                    End If
                Else
                    dtDestino.Rows(i)("flag") = 2
                End If

                PBar.Value = i + 1
                lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                lblPorc.Refresh()
            Next

            'Borra de dtDestino

            foundRows = dtDestino.Select("flag = 1")

            For i = 0 To foundRows.Length - 1
                dtDestino.Rows.Remove(foundRows(i))
            Next

            frmStatusMessage.Close()

            Cursor.Current = Cursors.Default

            If dtDestino.Rows.Count > 0 Then
                MessageBox.Show("Los registros en pantalla no fueron procesados ya que la cantidad a reubicar es mayor a la existente en la ubicación origen o la ubicación destino no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Else
                MessageBox.Show("Debe haber por lo menos un registro para ser procesado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
    End Sub
End Class