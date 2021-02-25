Public Class FrmEntrada

    Public ALMClave As String
    Public INGClave As String
    Public EditaCosto As Integer

    Private dtPrecios, dtImpuesto, dtImpuestoProd As DataTable

    Private PROClave As String
    Private GTIN As String
    Private Clave As String
    Private Nombre As String
    Private Descripcion As String
    Private TOrigen As Integer
    Private Seguimiento As Integer
    Private DiasGarantia As Integer
    Private NumDecimales As Integer
    Private CMIClave As String
    Private Costo As Double
    Private Cantidad As Double
    Private Factor As Integer = 1
    Private TUnidad As String
    Private TProducto As String
    Private Linea, Sublinea As Integer
    Private UBCClave As String

    Private bNuevo As Boolean = False
    Private bLoad As Boolean = False
    Private bError As Boolean = True

    Private Enum Ejecutar
        Insert = 1
        Update = 0
    End Enum

    Private alerta(12) As PictureBox
    Private reloj As parpadea


    Public Sub ModCosto(ByVal Cost As Double)
        Me.TxtCost.Text = CStr(Cost)
        Dim dNeto As Double
        If Not Cost = ModPOS.Redondear(Costo, 2) Then
            If Cost > ModPOS.Redondear(Costo, 2) Then

                Select Case MessageBox.Show("Se ha modificado el costo. ¿Desea recalcular el precio de todas las listas?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case System.Windows.Forms.DialogResult.Yes
                        Dim i As Integer
                        For i = 0 To dtPrecios.Rows.Count - 1
                            dtPrecios.Rows(i)("CostoRef") = Math.Abs(Cost)
                            If dtPrecios.Rows(i)("Factor") = 0 Then
                                dtPrecios.Rows(i)("Precio") = dtPrecios.Rows(i)("CostoRef")
                            Else
                                dtPrecios.Rows(i)("Precio") = Redondear(Math.Abs(Cost) * (1 + IIf(dtPrecios.Rows(i)("Factor") < 0, 1, dtPrecios.Rows(i)("Factor")) / 100), 2)
                            End If
                            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)
                            dtPrecios.Rows(i)("Minimo") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)

                        Next
                    Case System.Windows.Forms.DialogResult.No
                        'Recalcula Utilidad
                        Dim i As Integer
                        For i = 0 To dtPrecios.Rows.Count - 1
                            If (Math.Abs(Cost) * RecuperaImpuesto(1)) > dtPrecios.Rows(i)("Neto") Then
                                dtPrecios.Rows(i)("CostoRef") = Math.Abs(Cost)
                                dtPrecios.Rows(i)("Factor") = 0
                                dtPrecios.Rows(i)("Precio") = Redondear(Math.Abs(Cost), 2)
                                dNeto = dtPrecios.Rows(i)("Neto")
                                dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)
                                dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)) - dNeto)

                            Else
                                dtPrecios.Rows(i)("CostoRef") = Math.Abs(Cost)
                                dtPrecios.Rows(i)("Factor") = Redondear((dtPrecios.Rows(i)("Precio") / Math.Abs(Cost)) - 1, 2) * 100
                            End If
                        Next
                End Select
            Else
                Select Case MessageBox.Show("Se ha modificado el costo. ¿Desea recalcular el precio de todas las listas?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case System.Windows.Forms.DialogResult.Yes
                        Dim i As Integer
                        For i = 0 To dtPrecios.Rows.Count - 1
                            dtPrecios.Rows(i)("CostoRef") = Math.Abs(Cost)
                            If dtPrecios.Rows(i)("Factor") = 0 Then
                                dtPrecios.Rows(i)("Precio") = dtPrecios.Rows(i)("CostoRef")
                            Else
                                dtPrecios.Rows(i)("Precio") = Redondear(Math.Abs(Cost) * (1 + IIf(dtPrecios.Rows(i)("Factor") < 0, 1, dtPrecios.Rows(i)("Factor")) / 100), 2)
                            End If
                            dNeto = dtPrecios.Rows(i)("Neto")
                            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)
                            dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)) - dNeto)


                        Next
                    Case System.Windows.Forms.DialogResult.No
                        'Recalcula Utilidad
                        Dim i As Integer
                        For i = 0 To dtPrecios.Rows.Count - 1
                            dtPrecios.Rows(i)("CostoRef") = Math.Abs(Cost)
                            dtPrecios.Rows(i)("Factor") = Redondear((dtPrecios.Rows(i)("Precio") / Math.Abs(Cost)) - 1, 2) * 100
                        Next
                End Select
            End If
            Costo = Cost
        End If
    End Sub

 
    Public Function RecuperaImpuesto(ByVal iTipo As Integer) As Double
        Dim FactorImpuesto As Double = 1

        If Not dtImpuesto Is Nothing AndAlso dtImpuesto.Rows.Count > 0 Then
            Dim foundRows() As DataRow
            foundRows = dtImpuesto.Select("Marca=True and TImpuesto=" & CStr(iTipo))

            If foundRows.GetLength(0) > 0 Then

                Dim i As Integer
                Dim PrecioImp As Double = 100
                Dim ImpImporte As Double = 0
                For i = 0 To foundRows.GetUpperBound(0)

                    If foundRows(i)("SobreImp") = 1 Then
                        If foundRows(i)("TAplicacion") = 1 Then
                            ImpImporte = PrecioImp * (foundRows(i)("Valor") / 100)
                        Else
                            ImpImporte = foundRows(i)("Valor")
                        End If
                    Else
                        If foundRows(i)("TAplicacion") = 1 Then
                            ImpImporte = foundRows(i)("Valor")
                        Else
                            ImpImporte = foundRows(i)("Valor")
                        End If
                    End If
                    PrecioImp = PrecioImp + ImpImporte
                Next

                FactorImpuesto = (1 + ((PrecioImp - 100) / 100))
            End If
        End If

        Return FactorImpuesto

    End Function

    Private Sub FrmEntrada_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Total As Double = ModPOS.Ingreso.GridDetalle.GetTotal(ModPOS.Ingreso.GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        ModPOS.Ingreso.TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
        bError = False
        ModPOS.Entrada.Dispose()
        ModPOS.Entrada = Nothing
    End Sub


    Private Sub FrmEntrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9
        alerta(9) = Me.PictureBox10
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13

        With Me.CmbOrigen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Origen"
            .llenar()
        End With

      

        With Me.CmbSeguimiento
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Seguimiento"
            .llenar()
        End With

        With Me.CmbTipoComision
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_comision_producto"
            .llenar()
        End With

        With Me.CmbUnidadVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_unidad"
            .llenar()
        End With


        dtImpuesto = ModPOS.Recupera_Tabla("sp_filtra_impuestos")
        If Not dtImpuesto Is Nothing Then
            GridImpuestos.DataSource = dtImpuesto
            GridImpuestos.RetrieveStructure(True)
            GridImpuestos.GroupByBoxVisible = False
            GridImpuestos.RootTable.Columns("IMPClave").Visible = False
            GridImpuestos.RootTable.Columns("TAplicacion").Visible = False
            GridImpuestos.RootTable.Columns("SobreImp").Visible = False
            GridImpuestos.RootTable.Columns("Valor").Visible = False
            GridImpuestos.RootTable.Columns("TImpuesto").Visible = False
            GridImpuestos.CurrentTable.Columns("Nombre").Selectable = False
            GridImpuestos.CurrentTable.Columns("Tipo").Selectable = False
            ChkMarcaTodos.Enabled = True
        End If

        With Me.CmbLinea
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_linea"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With
        bLoad = True

        If Not CmbLinea.SelectedValue Is Nothing AndAlso bLoad Then
            With Me.CmbSubLinea
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_sublinea"
                .NombreParametro1 = "CLAClavePadre"
                .Parametro1 = CmbLinea.SelectedValue
                .llenar()
            End With
        End If


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim Total As Double = ModPOS.Ingreso.GridDetalle.GetTotal(ModPOS.Ingreso.GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        ModPOS.Ingreso.TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
        bError = False
        Me.Close()
    End Sub


    Private Sub BtnKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@Nombre", "Digitos Clave Cliente")
        Dim len As Integer = CInt(dt.Rows(0)("Valor"))
        dt.Dispose()
        Dim CLAClave As Integer

        If Not CmbSubLinea.SelectedValue Is Nothing Then
            CLAClave = CmbSubLinea.SelectedValue
        ElseIf Not CmbLinea.SelectedValue Is Nothing Then
            CLAClave = CmbLinea.SelectedValue
        Else
            CLAClave = 0
        End If

        dt = ModPOS.Recupera_Tabla("sp_calcula_proclave", "@CLAClave", CLAClave, "@len", len, "@COMClave", ModPOS.CompanyActual)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                TxtClave.Text = dt.Rows(0)("Clave")
            Else
                MessageBox.Show("No fue posible sugerir Clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dt.Dispose()
        Else
            MessageBox.Show("No fue posible sugerir Clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        SendKeys.Send("{TAB}")

    End Sub

    Private Sub CmbSeguimiento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSeguimiento.SelectedIndexChanged
        If bLoad = True AndAlso Not CmbSeguimiento.SelectedValue Is Nothing Then
            If CmbSeguimiento.SelectedValue = 2 Then
                TxtDiasGarantia.Enabled = True
                TxtDiasGarantia.Text = "0"
            Else
                TxtDiasGarantia.Enabled = False
                TxtDiasGarantia.Text = "0"
            End If
        End If
    End Sub

    Public Sub leeCodigoBarras(ByVal Codigo As String)
        If Not Codigo = vbNullString Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", Codigo)

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    bNuevo = False

                    PROClave = dt.Rows(0)("PROClave")
                    GTIN = dt.Rows(0)("GTIN")
                    Clave = dt.Rows(0)("Clave")
                    Nombre = dt.Rows(0)("Nombre")
                    Descripcion = dt.Rows(0)("Descripcion")
                    TOrigen = dt.Rows(0)("TOrigen")
                    Seguimiento = dt.Rows(0)("Seguimiento")
                    DiasGarantia = dt.Rows(0)("DiasGarantia")
                    NumDecimales = dt.Rows(0)("Num_Decimales")
                    CMIClave = dt.Rows(0)("CMIClave")

                    Factor = dt.Rows(0)("Factor")
                    TUnidad = dt.Rows(0)("UNDClave")
                    TProducto = dt.Rows(0)("TProducto")

                    CmbLinea.SelectedValue = Linea
                    CmbSubLinea.SelectedValue = Sublinea

                    TxtClave.Text = Clave
                    TxtNombre.Text = Nombre
                    TxtDescripcion.Text = Descripcion
                    TxtCodigoBarras.Text = GTIN
                    CmbOrigen.SelectedValue = TOrigen
                    CmbSeguimiento.SelectedValue = Seguimiento
                    TxtDiasGarantia.Text = DiasGarantia
                    NumDec.Value = NumDecimales
                    CmbTipoComision.SelectedValue = CMIClave
                    TxtCost.Text = Costo
                    CmbUnidadVenta.SelectedValue = TUnidad
                    
                    TxtClave.Enabled = False
                    BtnKey.Enabled = False
                    TxtNombre.Enabled = False
                    GrpConfiguración.Enabled = False
                    BtnEditar.Enabled = True
                    TxtDescripcion.Enabled = False
                    TxtCodigoBarras.Enabled = False

                    Dim dtubc As DataTable
                    dtubc = ModPOS.Recupera_Tabla("sp_ubc_sugerida", "@ALMClave", ALMClave, "@PROClave", PROClave)
                    If Not dtubc Is Nothing AndAlso dtubc.Rows.Count > 0 Then
                        UBCClave = dtubc.Rows(0)("UBCClave")
                        TxtUbicacion.Text = dtubc.Rows(0)("Ubicacion")
                    End If
                    dtubc.Dispose()


                    dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@PROClave", PROClave, "@COMClave", ModPOS.CompanyActual)
                    GridPrecios.DataSource = dtPrecios
                    GridPrecios.RetrieveStructure(True)

                    GridPrecios.GroupByBoxVisible = False
                    GridPrecios.CurrentTable.Columns(1).Selectable = False
                    GridPrecios.CurrentTable.Columns(2).Selectable = False
                    GridPrecios.CurrentTable.Columns("Precio").Selectable = False
                    GridPrecios.RootTable.Columns("Costo").Visible = False
                    GridPrecios.RootTable.Columns("SUCClave").Visible = False
                    GridPrecios.RootTable.Columns("CostoRef").Visible = False
                    GridPrecios.RootTable.Columns("Fbase").Visible = False
                    GridPrecios.RootTable.Columns("PREClave").Visible = False



                    If Not dtImpuesto Is Nothing AndAlso dtImpuesto.Rows.Count > 0 Then

                        dtImpuestoProd = ModPOS.Recupera_Tabla("sp_filtra_impuestos_prod", "@Producto", PROClave)

                        If Not dtImpuestoProd Is Nothing Then
                            Dim y, x As Integer
                            For y = 0 To dtImpuesto.Rows.Count - 1
                                For x = 0 To dtImpuestoProd.Rows.Count - 1
                                    If dtImpuesto.Rows(y)("IMPClave") = dtImpuestoProd.Rows(x)("IMPClave") Then
                                        dtImpuesto.Rows(y)("Marca") = True
                                        Exit For
                                    End If
                                Next
                            Next
                        End If

                    End If

                    If EditaCosto = 0 Then
                        TxtCost.Enabled = False
                        GridPrecios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    Else
                        TxtCost.Enabled = True
                        GridPrecios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    End If


                Else

                    If MessageBox.Show("El producto con clave ó Código de Barras : " & TxtBusqueda.Text & " no existe, ¿Desea crear un nuevo producto con esta clave o código?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                        BtnEditar.Enabled = False
                        CmbLinea.SelectedValue = 0
                        CmbSubLinea.SelectedValue = 0

                        Dim sCodigoBarras As String = TxtBusqueda.Text

                        If Not dtPrecios Is Nothing Then
                            reinicializa()
                        End If

                        TxtCodigoBarras.Text = sCodigoBarras
                        bNuevo = True
                        Costo = 0
                        PROClave = ""
                        TProducto = 1
                        TxtClave.Text = sCodigoBarras
                        TxtClave.Enabled = True
                        BtnKey.Enabled = True
                        TxtNombre.Enabled = True
                        TxtDescripcion.Enabled = True
                        TxtCodigoBarras.Enabled = True
                        GrpConfiguración.Enabled = True

                        dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_precios", "@Costo", Costo, "@COMClave", ModPOS.CompanyActual)
                        GridPrecios.DataSource = dtPrecios
                        GridPrecios.RetrieveStructure(True)

                        GridPrecios.GroupByBoxVisible = False
                        GridPrecios.CurrentTable.Columns(1).Selectable = False
                        GridPrecios.CurrentTable.Columns(2).Selectable = False
                        GridPrecios.CurrentTable.Columns("Precio").Selectable = False
                        GridPrecios.RootTable.Columns("Costo").Visible = False
                        GridPrecios.RootTable.Columns("CostoRef").Visible = False
                        GridPrecios.RootTable.Columns("Fbase").Visible = False
                        GridPrecios.RootTable.Columns("PREClave").Visible = False


                        If Not dtImpuesto Is Nothing AndAlso dtImpuesto.Rows.Count > 0 Then

                            dtImpuestoProd = ModPOS.Recupera_Tabla("sp_filtra_impuestos_def", "@COMClave", ModPOS.CompanyActual)

                            If Not dtImpuestoProd Is Nothing Then
                                Dim y, x As Integer
                                For y = 0 To dtImpuesto.Rows.Count - 1
                                    For x = 0 To dtImpuestoProd.Rows.Count - 1
                                        If dtImpuesto.Rows(y)("IMPClave") = dtImpuestoProd.Rows(x)("IMPClave") Then
                                            dtImpuesto.Rows(y)("Marca") = True
                                            Exit For
                                        End If
                                    Next
                                Next
                            End If
                        End If
                    End If
                End If
                dt.Dispose()
            End If
        End If
        TxtBusqueda.Text = ""
    End Sub

    Private Sub addIngresoDetalle()
        Dim foundRows() As System.Data.DataRow
        foundRows = ModPOS.Ingreso.dtIngresoDetalle.Select("PROClave Like '" & PROClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = ModPOS.Ingreso.dtIngresoDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("PROClave") = PROClave
            row1.Item("TProducto") = TProducto
            row1.Item("CostoVigente") = Costo
            row1.Item("Clave") = Clave
            row1.Item("Nombre") = Nombre
            row1.Item("Cantidad") = Cantidad
            row1.Item("Costo") = Math.Abs(CDbl(TxtCost.Text))
            row1.Item("Subtotal") = Cantidad * Math.Abs(CDbl(TxtCost.Text))
            row1.Item("Ubicación") = TxtUbicacion.Text.ToUpper.Trim
            row1.Item("UBCClave") = UBCClave
            ModPOS.Ingreso.dtIngresoDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla
        ElseIf Cantidad <> foundRows(0)("Cantidad") Then
            'actualiza
            foundRows(0)("Cantidad") = Cantidad
            foundRows(0)("Subtotal") = foundRows(0)("Costo") * Cantidad
        End If

    End Sub

    Private Sub reinicializa()
        CmbUnidadVenta.SelectedValue = CmbUnidadVenta.Items.Item(0)(0)
        CmbSeguimiento.SelectedValue = 1
        NumDec.Value = 0

        TxtCodigoBarras.Text = ""
        TxtClave.Text = ""
        TxtNombre.Text = ""
        TxtUbicacion.Text = ""
        TxtDescripcion.Text = ""
        TxtCost.Text = "0.0"
        TxtCantidad.Text = "0"
        TxtClave.Enabled = False
        TxtDescripcion.Enabled = False
        TxtCodigoBarras.Enabled = False
        BtnKey.Enabled = False
        TxtNombre.Enabled = False
        GrpConfiguración.Enabled = False
        TxtCodigoBarras.Focus()

        Dim i As Integer

        If Not dtImpuesto Is Nothing Then
            For i = 0 To dtImpuesto.Rows.Count - 1
                dtImpuesto.Rows(i)("Marca") = False
            Next
        End If

        For i = 0 To dtPrecios.Rows.Count - 1
            dtPrecios.Rows(i)("CostoRef") = Math.Abs(CDbl(TxtCost.Text))
            dtPrecios.Rows(i)("Precio") = Redondear(Math.Abs(CDbl(TxtCost.Text)) * (1 + IIf(dtPrecios.Rows(i)("Factor") < 0, 1, dtPrecios.Rows(i)("Factor")) / 100), 2)
            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)
            dtPrecios.Rows(i)("Minimo") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)

        Next

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion", "@ALMClave", ALMClave, "@Ubicacion", TxtUbicacion.Text.ToUpper.Trim)
            If dt.Rows.Count = 1 Then
                UBCClave = dt.Rows(0)("UBCClave")
            Else
                MessageBox.Show("La ubicación que intenta agregar no existe para el almacén seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            dt.Dispose()

           
            Cantidad = CDbl(TxtCantidad.Text)

            If bNuevo Then
                dt = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", TxtCodigoBarras.Text.Trim.ToUpper.Replace("'", "''"))
                If Not dt Is Nothing Then
                    If dt.Rows.Count = 0 Then
                        addProducto()
                    Else
                        MessageBox.Show("¡El código de barras que intenta agregar ya existe en el sistema!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
            Else
                updProducto()
            End If

            addIngresoDetalle()

            reinicializa()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridPrecios_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridPrecios.CellEdited
        Dim dNeto As Double
        If GridPrecios.CurrentColumn.Caption = "Neto" Then
            If IsNumeric(GridPrecios.GetValue("Neto")) AndAlso GridPrecios.GetValue("Neto") >= (GridPrecios.GetValue("CostoRef") * RecuperaImpuesto(1)) Then

                If GridPrecios.GetValue("CostoRef") = 0 Then
                    GridPrecios.SetValue("Neto", Redondear(GridPrecios.GetValue("Precio") * RecuperaImpuesto(1), 2))

                    GridPrecios.SetValue("Minimo", Redondear(GridPrecios.GetValue("Precio") * RecuperaImpuesto(1), 2))
                    Beep()
                    MessageBox.Show("¡El Costo debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Dim dPrecio As Double
                dPrecio = GridPrecios.GetValue("Neto") / RecuperaImpuesto(1)
                GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))
                GridPrecios.SetValue("Factor", Redondear((dPrecio / GridPrecios.GetValue("CostoRef") - 1) * 100, 2))

                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Neto"))

            Else
                GridPrecios.SetValue("Neto", Redondear(GridPrecios.GetValue("Precio") * RecuperaImpuesto(1), 2))
                GridPrecios.SetValue("Minimo", Redondear(GridPrecios.GetValue("Precio") * RecuperaImpuesto(1), 2))

                Beep()
                MessageBox.Show("¡El Precio Neto debe ser mayor o igual al Costo más Impuestos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If


        If GridPrecios.CurrentColumn.Caption = "Minimo" Then
            If Not IsNumeric(GridPrecios.GetValue("Minimo")) OrElse GridPrecios.GetValue("Neto") < GridPrecios.GetValue("Minimo") OrElse GridPrecios.GetValue("Minimo") < (GridPrecios.GetValue("CostoRef") * RecuperaImpuesto(1)) Then

                GridPrecios.SetValue("Minimo", Redondear(GridPrecios.GetValue("CostoRef") * RecuperaImpuesto(1), 2))

                Beep()
                MessageBox.Show("¡El Precio Minimo debe ser mayor o igual al Costo más Impuestos y menor o igual al Precio Neto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If


        If GridPrecios.CurrentColumn.Caption = "Factor" Then
            Dim dPrecio As Double
            If IsNumeric(GridPrecios.GetValue("Factor")) AndAlso GridPrecios.GetValue("Factor") >= 0 Then

                If GridPrecios.GetValue("CostoRef") = 0 Then
                    GridPrecios.SetValue("Factor", GridPrecios.GetValue("Fbase"))
                    dPrecio = GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100))
                    GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))
                    dNeto = GridPrecios.GetValue("Neto")
                    GridPrecios.SetValue("Neto", Redondear(dPrecio * RecuperaImpuesto(1), 2))
                    GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(dPrecio * RecuperaImpuesto(1), 2)) - dNeto))

                    Beep()
                    MessageBox.Show("¡El Costo debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If GridPrecios.GetValue("Factor") = 0 Then
                    dPrecio = GridPrecios.GetValue("CostoRef")
                Else
                    dPrecio = GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100))
                End If
                GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))
                dNeto = GridPrecios.GetValue("Neto")
                GridPrecios.SetValue("Neto", Redondear(dPrecio * RecuperaImpuesto(1), 2))

                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(dPrecio * RecuperaImpuesto(1), 2)) - dNeto))

            Else
                GridPrecios.SetValue("Factor", GridPrecios.GetValue("Fbase"))
                dPrecio = GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100))
                GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))

                dNeto = GridPrecios.GetValue("Neto")

                GridPrecios.SetValue("Neto", Redondear(dPrecio * RecuperaImpuesto(1), 2))
                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(dPrecio * RecuperaImpuesto(1), 2)) - dNeto))

                Beep()
                MessageBox.Show("¡El factor de utilidad no puede ser menor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

        If GridPrecios.CurrentColumn.Caption = "Precio" Then
            If IsNumeric(GridPrecios.GetValue("Precio")) AndAlso GridPrecios.GetValue("Precio") >= GridPrecios.GetValue("CostoRef") Then

                If GridPrecios.GetValue("CostoRef") = 0 Then
                    GridPrecios.SetValue("Precio", Redondear(GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100)), 2))
                    Beep()
                    MessageBox.Show("¡El Costo debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If GridPrecios.GetValue("Precio") = GridPrecios.GetValue("CostoRef") Then
                    GridPrecios.SetValue("Factor", 0)
                Else
                    GridPrecios.SetValue("Factor", Redondear((GridPrecios.GetValue("Precio") / GridPrecios.GetValue("CostoRef") - 1) * 100, 2))
                End If

                dNeto = GridPrecios.GetValue("Neto")
                GridPrecios.SetValue("Neto", Redondear(GridPrecios.GetValue("Precio") * RecuperaImpuesto(1), 2))
                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(GridPrecios.GetValue("Precio") * RecuperaImpuesto(1), 2)) - dNeto))

            Else
                GridPrecios.SetValue("Precio", Redondear(GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100)), 2))
                Beep()
                MessageBox.Show("¡El Precio debe ser mayor o igual al Costo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub TxtCost_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCost.Leave
        If Not (TxtCost.Text = ModPOS.Redondear(Costo, 2)) Then
            Beep()
            If CDbl(TxtCost.Text) < 0 Then
                MessageBox.Show("El costo debe ser mayor o igual a cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            ModCosto(CDbl(TxtCost.Text))
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtImpuesto.Rows.Count > 0 Then
            Dim i As Integer
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtImpuesto.Rows.Count - 1
                    dtImpuesto.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtImpuesto.Rows.Count - 1
                    dtImpuesto.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub addProducto()
        PROClave = ModPOS.obtenerLlave
        GTIN = TxtCodigoBarras.Text.Trim.ToUpper.Replace("'", "''")
        Clave = TxtClave.Text.ToUpper.Trim
        Nombre = TxtNombre.Text.ToUpper.Trim
        Descripcion = TxtDescripcion.Text.ToUpper.Trim
        TOrigen = CmbOrigen.SelectedValue
        Seguimiento = CmbSeguimiento.SelectedValue
        TUnidad = CmbUnidadVenta.SelectedValue
        DiasGarantia = IIf(TxtDiasGarantia.Text = "", 0, Math.Abs(CInt(TxtDiasGarantia.Text)))
        NumDecimales = NumDec.Value
        CMIClave = CmbTipoComision.SelectedValue
        Linea = IIf(CmbLinea.SelectedValue Is Nothing, 0, CmbLinea.SelectedValue)
        Sublinea = IIf(CmbSubLinea.SelectedValue Is Nothing, 0, CmbSubLinea.SelectedValue)

        ModPOS.Ejecuta("sp_inserta_producto", _
        "@PROClave", PROClave, _
        "@Clave", Clave, _
        "@NumParte", "", _
        "@Nombre", Nombre, _
        "@Descripcion", Descripcion, _
        "@Tipo", 1, _
        "@TOrigen", TOrigen, _
        "@TRotacion", 0, _
        "@Seguimiento", Seguimiento, _
        "@DiasGarantia", DiasGarantia, _
        "@Minimo", 0, _
        "@Maximo", 0, _
        "@Reorden", 0, _
        "@NumDecimales", NumDecimales, _
        "@CMIClave", CMIClave, _
        "@Nota", "", _
        "@Usuario", ModPOS.UsuarioActual, _
        "@COMClave", ModPOS.CompanyActual)


        'Impuesto
        Dim foundRows() As DataRow
        Dim z As Integer
        foundRows = dtImpuesto.Select("Marca=True")

        If foundRows.GetLength(0) > 0 Then
            Dim sIMPClave As String
            For z = 0 To foundRows.GetUpperBound(0)
                sIMPClave = foundRows(z)("IMPClave")
                ModPOS.Ejecuta("sp_inserta_impprod", "@IMPClave", sIMPClave, "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
            Next
        End If


        'Costo

        Costo = Math.Abs(CDbl(TxtCost.Text))

        'Sucursal producto

        Dim dtSucursal As DataTable

        dtSucursal = SelectDistinc("Sucursal", dtPrecios, "SUCClave")
        For z = 0 To dtSucursal.Rows.Count - 1
            ModPOS.Ejecuta("sp_inserta_sucursalproducto", _
                                 "@SUCClave", dtSucursal.Rows(z)("SUCClave"), _
                                 "@PROClave", PROClave, _
                                 "@Costo", Costo, _
                                 "@Rotacion", 0, _
                                 "@Minimo", 0, _
                                 "@Maximo", 0, _
                                 "@Reorden", 0, _
                                 "@TipoImpuesto", 1, _
                                 "@Usuario", ModPOS.UsuarioActual)

        Next

      
        'Precio
        Me.actualizaPrecios(Ejecutar.Insert)

        'Unidades
        ModPOS.Ejecuta("sp_inserta_productounidad", _
                                      "@UNDClave", TUnidad, _
                                      "@PROClave", PROClave, _
                                      "@GTIN", GTIN, _
                                      "@Factor", Factor, _
                                      "@Usuario", ModPOS.UsuarioActual)


        ModPOS.Ejecuta("sp_inserta_existencia", _
       "@PROClave", Me.PROClave, _
       "@Usuario", ModPOS.UsuarioActual)

        If Linea > 0 Then
            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 4, "@Class", Linea, "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
        End If

        If Sublinea > 0 Then
            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 4, "@Class", Sublinea, "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
        End If

    End Sub

    Private Sub updProducto()

        ModPOS.Ejecuta("sp_update_existencia", _
      "@PROClave", Me.PROClave, _
      "@Usuario", ModPOS.UsuarioActual)

        Me.actualizaPrecios(Ejecutar.Update)
    End Sub

    Private Sub actualizaPrecios(ByVal Ejecutar As Ejecutar)
        Dim i As Integer

        For i = 0 To dtPrecios.Rows.Count - 1

            Select Case Ejecutar
                Case Ejecutar.Insert
                    If dtPrecios.Rows(i)("Factor") >= 0 Then
                        ModPOS.Ejecuta("sp_inserta_precio", _
                                        "@PREClave", dtPrecios.Rows(i)("PREClave"), _
                                        "@PROClave", PROClave, _
                                        "@Utilidad", Math.Abs(dtPrecios.Rows(i)("Factor") / 100), _
                                        "@Descuento", 0, _
                                        "@Puntos", 0, _
                                        "@General", dtPrecios.Rows(i)("Neto"), _
                                        "@Minimo", dtPrecios.Rows(i)("Minimo"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                    Else
                        ModPOS.Ejecuta("sp_inserta_precio", _
                                        "@PREClave", dtPrecios.Rows(i)("PREClave"), _
                                        "@PROClave", PROClave, _
                                        "@Utilidad", Math.Abs(dtPrecios.Rows(i)("Fbase") / 100), _
                                        "@Descuento", 0, _
                                        "@Puntos", 0, _
                                        "@General", dtPrecios.Rows(i)("Neto"), _
                                        "@Minimo", dtPrecios.Rows(i)("Minimo"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                    End If
                Case Ejecutar.Update

                    If dtPrecios.Rows(i)("Fbase") <> dtPrecios.Rows(i)("Factor") OrElse _
                       dtPrecios.Rows(i)("Costo") <> dtPrecios.Rows(i)("CostoRef") Then

                        ModPOS.Ejecuta("sp_modifica_precio_lista", _
                                       "@PREClave", dtPrecios.Rows(i)("PREClave"), _
                                       "@PROClave", PROClave, _
                                       "@Costo", CDbl(dtPrecios.Rows(i)("CostoRef")), _
                                       "@Utilidad", Math.Abs(CDbl(dtPrecios.Rows(i)("Factor") / 100)), _
                                       "@Precio", CDbl(dtPrecios.Rows(i)("Precio")), _
                                       "@General", dtPrecios.Rows(i)("Neto"), _
                                       "@Minimo", dtPrecios.Rows(i)("Minimo"), _
                                       "@Usuario", ModPOS.UsuarioActual)
                    End If
            End Select
        Next
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)
        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 60 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 60)
        End If

        If Me.TxtCodigoBarras.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 50 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If TxtCost.Text = "" OrElse CDbl(TxtCost.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbUnidadVenta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If


        
        If Me.CmbTipoComision.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbSeguimiento.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridPrecios.RowCount = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtCantidad.Text = "" OrElse CDbl(TxtCantidad.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtUbicacion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf bNuevo Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Producto", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(1))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmEntrada_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub CmbLinea_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLinea.SelectedValueChanged
        If Not CmbLinea.SelectedValue Is Nothing AndAlso bLoad Then
            With Me.CmbSubLinea
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_sublinea"
                .NombreParametro1 = "CLAClavePadre"
                .Parametro1 = CmbLinea.SelectedValue
                .llenar()
            End With
        End If
    End Sub


    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_producto"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.BusquedaInicial = True
        a.Busqueda = TxtBusqueda.Text.Trim.ToUpper
        a.AlmRequerido = True
        a.ALMClave = ALMClave
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtBusqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            leeCodigoBarras(TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub


    Private Sub btnBusquedaUbc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusquedaUbc.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_ubicacion"
        a.TablaCmb = "Reubicacion"
        a.CampoCmb = "Filtro"
        a.AlmRequerido = True
        a.ALMClave = Me.ALMClave
        a.NumColDes = 1
        a.OcultaCol = True
        a.OcultaColNum = 0
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtUbicacion.Text = a.Descripcion
        End If
        a.Dispose()
    End Sub

    Private Sub TxtBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusqueda.KeyUp
        If e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_producto"
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = TxtBusqueda.Text.Trim.ToUpper
            a.AlmRequerido = True
            a.ALMClave = ALMClave
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                leeCodigoBarras(a.valor)
            End If
            a.Dispose()
        End If
    End Sub

    Private Sub TxtClave_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtClave.Leave
        If TxtCodigoBarras.Text = "" Then
            TxtCodigoBarras.Text = TxtClave.Text
        End If
    End Sub

    Private Sub TxtNombre_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNombre.Leave
        If TxtDescripcion.Text = "" Then
            TxtDescripcion.Text = TxtNombre.Text
        End If
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If PROClave <> "" Then
            If ModPOS.Producto Is Nothing Then

                ModPOS.Producto = New FrmProducto
                With ModPOS.Producto
                    .Text = "Modificar Producto"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    ' .CmbTipo.Enabled = False
                    .bIngreso = True
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_producto", "@PROClave", PROClave)

                    .Costo = dt.Rows(0)("CostoVigente")
                    .PROClave = dt.Rows(0)("PROClave")
                    .Clave = dt.Rows(0)("Clave")
                    .NumParte = IIf(dt.Rows(0)("NumParte").GetType.Name = "DBNull", "", dt.Rows(0)("NumParte"))
                    .Nombre = dt.Rows(0)("Nombre")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Tipo = dt.Rows(0)("TProducto")
                    .TOrigen = dt.Rows(0)("TOrigen")
                    .TRotacion = dt.Rows(0)("TRotacion")
                    .Estado = dt.Rows(0)("Estado")
                    .Seguimiento = dt.Rows(0)("Seguimiento")
                    .DiasGarantia = dt.Rows(0)("DiasGarantia")
                    .Minimo = dt.Rows(0)("Minimo")
                    .Maximo = dt.Rows(0)("Maximo")
                    .Reorden = dt.Rows(0)("Reorden")
                    .Marca = IIf(dt.Rows(0)("Marca").GetType.Name = "DBNull", 0, dt.Rows(0)("Marca"))
                    .Linea = IIf(dt.Rows(0)("Linea").GetType.Name = "DBNull", 0, dt.Rows(0)("Linea"))
                    .Sublinea = IIf(dt.Rows(0)("Sublinea").GetType.Name = "DBNull", 0, dt.Rows(0)("Sublinea"))
                    .NumDecimales = dt.Rows(0)("Num_Decimales")
                    .CMIClave = IIf(dt.Rows(0)("CMIClave").GetType.FullName = "System.DBNull", "", dt.Rows(0)("CMIClave"))
                    .Nota = IIf(dt.Rows(0)("Nota").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Nota"))

                    dt.Dispose()

                    .UiTab1.Enabled = True

                    .TxtNumParte.Focus()
                End With
            End If

            ModPOS.Producto.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Producto.Show()
            ModPOS.Producto.BringToFront()
        End If

    End Sub


    Private Sub GridImpuestos_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridImpuestos.CellEdited
        Dim i As Integer
        Dim dNeto As Double
        For i = 0 To dtPrecios.Rows.Count - 1
          
            dNeto = dtPrecios.Rows(i)("Neto")
            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)
            dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * RecuperaImpuesto(1), 2)) - dNeto)

        Next
    End Sub

    Private Sub GridImpuestos_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridImpuestos.CellValueChanged
        If GridImpuestos.Row = 0 Then
            GridImpuestos.MoveNext()
            GridImpuestos.MovePrevious()
        Else
            GridImpuestos.MovePrevious()
            GridImpuestos.MoveNext()
        End If
    End Sub
End Class