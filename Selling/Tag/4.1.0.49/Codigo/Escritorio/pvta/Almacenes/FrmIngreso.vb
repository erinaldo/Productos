Public Class FrmIngreso

    Public SUCClave As String
    Public ALMClave As String
    Public INGClave As String
    Public dtIngresoDetalle As DataTable
    Public bNuevo As Boolean
    Public Estado As Integer = 1
    Public Referencia As String = ""
    Public Nota As String = ""
    Public PRVClave As String = ""
    Public contador As Integer

    Private IngresoSimple As Integer = 0

    Private EstadoActual As Integer = 1
    Private Autorizo As String = ""
    Private sPRVClave As String = ""
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private EditaCosto As Integer

    Private Autoriza As String
    Private Credito As Integer
    Private DiasCredito As Integer

    Private sPROClave, Clave, Nombre, UBCClave, Ubicacion As String
    Private Costo, Cantidad As Decimal
    Private TProducto As Integer

    Private Sub FrmIngreso_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not ModPOS.MtoIngresos Is Nothing Then
            ModPOS.MtoIngresos.refrescaGrid()
        End If
        ModPOS.Ingreso.Dispose()
        ModPOS.Ingreso = Nothing
    End Sub

    Private Sub FrmIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dtUsuario As DataTable
        dtUsuario = Recupera_Tabla("sp_recupera_usuarioActual", "@Usuario", ModPOS.UsuarioActual)
        EditaCosto = IIf(dtUsuario.Rows(0)("ModCosto").GetType.FullName = "System.DBNull", 0, dtUsuario.Rows(0)("ModCosto"))
        dtUsuario.Dispose()

        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "IngresoSimple"
                        IngresoSimple = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()


        If IngresoSimple = 1 Then
            BtnAddProd.Visible = False
            lblCantidad.Visible = True
            lblCodigo.Visible = True
            TxtProducto.Visible = True
            TxtCantidad.Visible = True
            lblDescripcion.Visible = True
        End If

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        TxtReferencia.Text = Referencia
        TxtNota.Text = Nota
        EstadoActual = Estado

        If bNuevo Then

            BtnImportar.Visible = True

            dtIngresoDetalle = ModPOS.CrearTabla("IngresoDetalle", _
                                  "ID", "System.String", _
                                  "PROClave", "System.String", _
                                  "TProducto", "System.Int32", _
                                  "Clave", "System.String", _
                                  "Nombre", "System.String", _
                                  "Cantidad", "System.Double", _
                                  "Costo", "System.Double", _
                                  "Subtotal", "System.Double", _
                                  "UBCClave", "System.String", _
                                  "Ubicación", "System.String")
        Else
            dtIngresoDetalle = ModPOS.Recupera_Tabla("sp_detalle_ingreso", "@INGClave", INGClave)
            sPRVClave = PRVClave
            If sPRVClave <> "" Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_proveedor", "@PRVClave", sPRVClave)
                If dt.Rows.Count > 0 Then
                    TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
                    TxtClaveProv.Text = dt.Rows(0)("Clave")
                    DiasCredito = dt.Rows(0)("DiasCredito")

                    If DiasCredito > 0 Then
                        Credito = 1
                    Else
                        Credito = 0
                    End If

                End If
                dt.Dispose()
            End If
        End If
        GridDetalle.DataSource = dtIngresoDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("ID").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("UBCClave").Visible = False
        GridDetalle.RootTable.Columns("Costo").Selectable = False
        GridDetalle.RootTable.Columns("Subtotal").Selectable = False
        GridDetalle.CurrentTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        GridDetalle.CurrentTable.Columns("Ubicación").Selectable = False

        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"


        If bNuevo = False Then
            Dim Total As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
            TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
        End If
    End Sub

    Private Sub imprimirIngreso()
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ingreso", "@INGClave", INGClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_detalle_ingreso", "@INGClave", INGClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_detalle_ubcing", "@INGClave", INGClave))
        OpenReport.PrintPreview("Ingreso de Almacén", "CRIngreso.rpt", pvtaDataSet, "")
    End Sub

    Private Sub BtnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddProd.Click
        If ModPOS.Entrada Is Nothing Then
            ModPOS.Entrada = New FrmEntrada
            With ModPOS.Entrada
                .ALMClave = ALMClave
                .INGClave = INGClave
                .EditaCosto = EditaCosto
            End With
        End If
        ModPOS.Entrada.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Entrada.Show()
        ModPOS.Entrada.BringToFront()
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridDetalle.GetValue("Cantidad")) Then
                If GridDetalle.GetValue("Cantidad") > 0 Then
                    Dim Actual As Double
                    Actual = Math.Abs(CDbl(GridDetalle.GetValue("Costo"))) * GridDetalle.GetValue("Cantidad")
                    GridDetalle.SetValue("Subtotal", Actual)
                Else
                    Beep()
                    MessageBox.Show("¡La cantidad a a ingresar debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Cantidad", 0)
                End If
            Else
                GridDetalle.SetValue("Cantidad", 0)
            End If
        End If
    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        Dim Total As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
    End Sub

    Private Sub BtnDelProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelProd.Click
        If GridDetalle.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del producto seleccionado del detalle de ingreso:" & GridDetalle.GetValue("Nombre"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtIngresoDetalle.Select("ID Like '" & GridDetalle.GetValue("ID") & "'")
                    dtIngresoDetalle.Rows.Remove(foundRows(0))
            End Select
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtReferencia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            
            If bNuevo AndAlso ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_ingreso", "@Referencia", Me.TxtReferencia.Text.Trim.ToUpper, "@Almacen", ALMClave) > 0 Then
                MessageBox.Show("¡La referencia que intenta registrar ya existe en el sistema!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If EstadoActual = 1 Then
                Dim a As New MeAutorizacion
                a.Sucursal = Me.SUCClave
                a.MontodeAutorizacion = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()

                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado Then

                        Autoriza = a.Autoriza
                        Autorizo = a.cmbAutoriza.SelectedValue
                        EstadoActual = 2
                        Dim dtmsg As DataTable
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "Ingreso", "@Campo", "Estado", "@estado", EstadoActual)
                        TxtEstado.Text = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    End If
                Else
                    Autorizo = ""
                    EstadoActual = 1
                End If
                a.Dispose()
            End If
            PRVClave = sPRVClave
            If bNuevo Then
                INGClave = ModPOS.obtenerLlave
                Referencia = TxtReferencia.Text.Trim.ToUpper
                Nota = TxtNota.Text.Trim.ToUpper

                ModPOS.Ejecuta("sp_crea_ingreso", _
                            "@INGClave", INGClave, _
                            "@ALMClave", ALMClave, _
                            "@Referencia", Referencia, _
                            "@Autorizo", Autorizo, _
                            "@Notas", Nota, _
                            "@Estado", EstadoActual, _
                            "@PRVClave", IIf(PRVClave <> "", PRVClave, Nothing), _
                            "@Usuario", ModPOS.UsuarioActual)

                Dim fila As Integer

                For fila = 0 To dtIngresoDetalle.Rows.Count - 1

                    ModPOS.Ejecuta("sp_inserta_detalleingreso", _
                    "@DINGClave", dtIngresoDetalle.Rows(fila)("ID"), _
                    "@INGClave", INGClave, _
                    "@PROClave", dtIngresoDetalle.Rows(fila)("PROClave"), _
                    "@TProducto", dtIngresoDetalle.Rows(fila)("TProducto"), _
                    "@Costo", dtIngresoDetalle.Rows(fila)("Costo"), _
                    "@Cantidad", dtIngresoDetalle.Rows(fila)("Cantidad"), _
                    "@UBCClave", dtIngresoDetalle.Rows(fila)("UBCClave"), _
                    "@fila", fila + 1)
                Next
            Else

                ModPOS.Ejecuta("sp_actualiza_ingreso", _
                            "@INGClave", INGClave, _
                            "@Autorizo", Autorizo, _
                            "@Notas", Nota, _
                            "@Estado", EstadoActual, _
                            "@PRVClave", IIf(PRVClave <> "", PRVClave, Nothing), _
                            "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Ejecuta("sp_elimina_ingresodetalle", "@INGClave", INGClave)

                Dim fila As Integer

                For fila = 0 To dtIngresoDetalle.Rows.Count - 1

                    ModPOS.Ejecuta("sp_inserta_detalleingreso", _
                    "@DINGClave", dtIngresoDetalle.Rows(fila)("ID"), _
                    "@INGClave", INGClave, _
                    "@PROClave", dtIngresoDetalle.Rows(fila)("PROClave"), _
                    "@TProducto", dtIngresoDetalle.Rows(fila)("TProducto"), _
                    "@Costo", dtIngresoDetalle.Rows(fila)("Costo"), _
                    "@Cantidad", dtIngresoDetalle.Rows(fila)("Cantidad"), _
                    "@UBCClave", dtIngresoDetalle.Rows(fila)("UBCClave"), _
                    "@fila", fila + 1)
                Next
            End If

            If EstadoActual = 2 AndAlso Estado = 1 Then
                'Dim fila As Integer

                'For fila = 0 To dtIngresoDetalle.Rows.Count - 1
                '    If dtIngresoDetalle.Rows(fila)("Costo") <> dtIngresoDetalle.Rows(fila)("CostoVigente") Then
                '        ModPOS.Ejecuta("sp_actualiza_costo", _
                '        "@SUCClave", Succlave, _
                '        "@PROClave", dtIngresoDetalle.Rows(fila)("PROClave"), _
                '        "@TCosto", dtIngresoDetalle.Rows(fila)("TCosto"), _
                '        "@CostoVigente", dtIngresoDetalle.Rows(fila)("CostoVigente"), _
                '        "@Costo", dtIngresoDetalle.Rows(fila)("Costo"), _
                '        "@Cantidad", dtIngresoDetalle.Rows(fila)("Cantidad"), _
                '        "@Documento", "", _
                '        "@Usuario", ModPOS.UsuarioActual)
                '    End If

                '    ModPOS.Ejecuta("sp_ingreso_ubc", "@PROClave", dtIngresoDetalle.Rows(fila)("PROClave"), "@UBCClave", dtIngresoDetalle.Rows(fila)("UBCClave"), "@Cantidad", dtIngresoDetalle.Rows(fila)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)

                'Next

                ModPOS.GeneraMovInv(1, 9, 7, INGClave, ALMClave, Referencia, Autoriza, False)
            
                If PRVClave <> "" Then
                    If MessageBox.Show("¿Desea crear automaticamente la compra a partir de este documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                        Dim fila As Integer
                        Dim IVA, Costo, Cantidad As Double
                        Dim impuestoTotal As Double = 0
                        For fila = 0 To dtIngresoDetalle.Rows.Count - 1

                            IVA = ModPOS.RecuperaImpuesto(SUCClave, dtIngresoDetalle.Rows(fila)("PROClave"), 1)
                            Costo = dtIngresoDetalle.Rows(fila)("Costo")
                            Cantidad = dtIngresoDetalle.Rows(fila)("Cantidad")
                            impuestoTotal += Redondear(Cantidad * (Costo * IVA), 6)
                        Next

                        ModPOS.Ejecuta("sp_inserta_compra", _
                             "@COMClave", INGClave, _
                             "@SUCClave", SUCClave, _
                             "@ALMClave", ALMClave, _
                             "@ORDClave", "", _
                             "@Factura", Referencia, _
                             "@PRVClave", PRVClave, _
                             "@Credito", Credito, _
                             "@DiasCredito", DiasCredito, _
                             "@FechaFactura", Today.Date, _
                             "@FechaVencimiento", Today.Date.AddDays(DiasCredito), _
                             "@CostoTot", GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum), _
                             "@DescuentoTot", 0, _
                             "@ImpuestoTot", impuestoTotal, _
                             "@SubTotal", GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum), _
                             "@Total", GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum) + impuestoTotal, _
                             "@Motivo", "Compra", _
                             "@Solicita", "", _
                             "@Nota", Nota, _
                             "@Fase", True, _
                             "@Usuario", ModPOS.UsuarioActual)


                        For fila = 0 To dtIngresoDetalle.Rows.Count - 1

                            IVA = ModPOS.RecuperaImpuesto(SUCClave, dtIngresoDetalle.Rows(fila)("PROClave"), 1)
                            Costo = dtIngresoDetalle.Rows(fila)("Costo")
                            Cantidad = dtIngresoDetalle.Rows(fila)("Cantidad")

                            ModPOS.Ejecuta("sp_inserta_detallecompra", _
                            "@COMClave", INGClave, _
                            "@PROClave", dtIngresoDetalle.Rows(fila)("PROClave"), _
                            "@TProducto", dtIngresoDetalle.Rows(fila)("TProducto"), _
                            "@Costo", Costo, _
                            "@Precio", Costo, _
                            "@DescPorc1", 0, _
                            "@DescPorc2", 0, _
                            "@DescPorc3", 0, _
                            "@DescPorc4", 0, _
                            "@Bonificacion", 0, _
                            "@DescuentoImp", 0, _
                            "@ImpuestoPorc", IVA, _
                            "@ImpuestoImp", Redondear(Costo * IVA, 6), _
                            "@SubTotalPartida", Redondear(Costo * (1 + IVA), 6), _
                            "@Cantidad", dtIngresoDetalle.Rows(fila)("Cantidad"), _
                            "@TotalPartida", Redondear(Cantidad * (Costo * (1 + IVA)), 6), _
                            "@fila", fila + 1, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next



                    End If
                End If

            End If
            Estado = EstadoActual

            If EstadoActual = 2 Then
                If MessageBox.Show("¿Desea imprimir el Ingreso?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    imprimirIngreso()
                End If
            End If

            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub addIngresoDetalle(ByVal PROClave As String, ByVal Clave As String, ByVal Nombre As String, ByVal TProducto As Integer, ByVal Costo As Double, ByVal Cantidad As Double, ByVal Ubicacion As String, ByVal UBCClave As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtIngresoDetalle.Select("PROClave Like '" & PROClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtIngresoDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("PROClave") = PROClave
            row1.Item("TProducto") = TProducto
            row1.Item("Clave") = Clave
            row1.Item("Nombre") = Nombre
            row1.Item("Cantidad") = Cantidad
            row1.Item("Costo") = Costo
            row1.Item("Subtotal") = Cantidad * Costo
            row1.Item("UBCClave") = UBCClave
            row1.Item("Ubicación") = Ubicacion

            dtIngresoDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla
        ElseIf Cantidad <> foundRows(0)("Cantidad") Then
            'actualiza
            foundRows(0)("Cantidad") = Cantidad
            foundRows(0)("Subtotal") = foundRows(0)("Costo") * Cantidad
        End If

    End Sub


    Private Sub BtnImpotar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportar.Click
        Dim FullPath As String


        Dim result As OpenFileDialog = New OpenFileDialog
        result.Filter = "Todos los archivos de CSV|*.CSV"
        result.Title = "Importar archivo CSV"

        If (result.ShowDialog() = DialogResult.OK) Then
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            FullPath = result.FileName

            If FullPath.Contains(".CSV") OrElse FullPath.Contains(".csv") Then
                Dim dtTemporal As DataTable = LeerCSV(FullPath)
                If Not dtTemporal Is Nothing AndAlso dtTemporal.Rows.Count > 0 Then

                    Dim dtProducto As DataTable
                    Dim UBCClave As String = ""
                    Dim Ubicacion As String = ""

                    Dim i As Integer
                    For i = 0 To dtTemporal.Rows.Count - 1
                        'Valida si existen datos para comparar
                        If Not dtTemporal.Rows(i)(0).GetType.FullName = "System.DBNull" AndAlso Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" Then
                            'Verifica que el producto exista}

                            dtProducto = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", dtTemporal.Rows(i)(0).ToString.Trim)
                            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count >= 1 Then
                                'Verifica que la cantidad sea numerica
                                If IsNumeric(dtTemporal.Rows(i)(1)) Then

                                    Dim dtubc As DataTable
                                    dtubc = ModPOS.Recupera_Tabla("sp_ubc_sugerida", "@ALMClave", ALMClave, "@PROClave", dtProducto.Rows(0)("PROClave"))
                                    If Not dtubc Is Nothing AndAlso dtubc.Rows.Count > 0 Then
                                        UBCClave = dtubc.Rows(0)("UBCClave")
                                        Ubicacion = dtubc.Rows(0)("Ubicacion")
                                    End If
                                    dtubc.Dispose()

                                    'Obtener costo
                                    Dim Costo As Double

                                    Dim dt As DataTable
                                    dt = ModPOS.Recupera_Tabla("sp_recupera_costo", "@SUCClave", SUCClave, "@PROClave", dtProducto.Rows(0)("PROClave"))
                                    Costo = dt.Rows(0)("Costo")
                                    dt.Dispose()

                                    addIngresoDetalle(dtProducto.Rows(0)("PROClave"), _
                                                      dtProducto.Rows(0)("Clave"), _
                                                      dtProducto.Rows(0)("Nombre"), _
                                                      dtProducto.Rows(0)("TProducto"), _
                                                       Costo, _
                                                        Math.Abs(CDbl(dtTemporal.Rows(i)(1))), _
                                                      Ubicacion, _
                                                      UBCClave)
                                End If
                                '   dtProducto.Dispose()
                            End If

                        End If
                    Next
                    dtTemporal.Dispose()

                    If dtIngresoDetalle.Rows.Count = 0 Then
                        MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Dim Total As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
                    End If
                Else
                    MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

        End If
    End Sub

    Public Sub CargaDatosProveedor(ByVal Clave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_busca_proveedor", "@Clave", Clave, "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            sPRVClave = dt.Rows(0)("PRVClave")
            TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
            TxtClaveProv.Text = Clave

            DiasCredito = dt.Rows(0)("DiasCredito")

            If DiasCredito > 0 Then
                Credito = 1
            Else
                Credito = 0
            End If
        Else
            MsgBox("No se encontro un proveedor que coincida con la clave proporcionada")
            TxtRazonSocial.Text = ""
            sPRVClave = ""
        End If
        dt.Dispose()
    End Sub


    Private Sub TxtClaveProv_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClaveProv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TxtClaveProv.Text = vbNullString Then
                CargaDatosProveedor(TxtClaveProv.Text.ToUpper.Trim.Replace("'", "''"))
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del proveedor
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_proveedor"
            a.TablaCmb = "Proveedor"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.NumColDes2 = 4
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProv.Text.Trim.ToUpper
            a.OcultaID = True
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                CargaDatosProveedor(a.Descripcion)
            End If
            a.Dispose()
        End If

    End Sub

    Private Sub BtnBuscaProv_Click(sender As Object, e As EventArgs) Handles BtnBuscaProv.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_proveedor"
        a.TablaCmb = "Proveedor"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.NumColDes2 = 4
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            CargaDatosProveedor(a.Descripcion)
        End If
        a.Dispose()
    End Sub

    Private Sub BtnAddProv_Click(sender As Object, e As EventArgs) Handles BtnAddProv.Click
        If ModPOS.Proveedor Is Nothing Then
            ModPOS.Proveedor = New FrmProveedor
            With ModPOS.Proveedor
                .Text = "Agregar Proveedor"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .FromForm = "Ingreso"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Proveedor.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Proveedor.Show()
        ModPOS.Proveedor.BringToFront()
    End Sub


    Private Sub recuperaProducto(ByVal sGTIN As String)
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", sGTIN)
        If Not dt Is Nothing AndAlso dt.Rows.Count >= 1 Then

            sPROClave = dt.Rows(0)("PROClave")
            Clave = dt.Rows(0)("Clave")
            Nombre = dt.Rows(0)("Nombre")
            TProducto = dt.Rows(0)("TProducto")
            TxtCantidad.DecimalDigits = dt.Rows(0)("Num_Decimales")
            dt.Dispose()



            dt = ModPOS.Recupera_Tabla("sp_ubc_sugerida", "@ALMClave", ALMClave, "@PROClave", sPROClave)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                UBCClave = dt.Rows(0)("UBCClave")
                Ubicacion = dt.Rows(0)("Ubicacion")
            End If
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_recupera_costo", "@SUCClave", SUCClave, "@PROClave", sPROClave)
            Costo = dt.Rows(0)("Costo")
            dt.Dispose()

            TxtCantidad.Focus()
            lblDescripcion.Text = Nombre
        Else
            TxtProducto.Text = ""
            sPROClave = ""

            MessageBox.Show("El código de producto no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub TxtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtProducto.Text) Then
                recuperaProducto(TxtProducto.Text.Trim.ToUpper)
            Else
                MessageBox.Show("El código de producto no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_producto"
                a.CampoCmb = "Filtro"
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = TxtProducto.Text.Trim.ToUpper
            a.AlmRequerido = True
            a.ALMClave = ALMClave
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                Else
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If


            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If

            If sPROClave <> "" Then
                addIngresoDetalle(sPROClave, _
                                  Clave, _
                                  Nombre, _
                                  TProducto, _
                                  Costo, _
                                  Cantidad, _
                                  Ubicacion, _
                                  UBCClave)

                lblDescripcion.Text = ""
                TxtCantidad.Text = "0"
                TxtProducto.Text = ""

            End If
            TxtProducto.Focus()

        End If
    End Sub
End Class