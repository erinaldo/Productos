Public Class FrmActCosto

    Private dtProductos, dtPrecios, dtImpuesto, dtImpuestoProd As DataTable

    Private PROClave As String = ""
    Private Clave As String
    Private Nombre As String
    Private Costo As Double
    Private TallaColor As Integer = 0

    Private PorcImpFrontera As Double
    Private bModCosto As Boolean = False
    Private SUCClave As String

    Private iContador As Integer = 0

    Private bCargado As Boolean = False

    Private Enum Ejecutar
        Insert = 1
        Update = 0
    End Enum

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private bLoad As Boolean = False

    Private dataSetArbol As Data.DataSet

    Public Sub ModCosto(ByVal Cost As Double)
        If PROClave <> "" Then
            Dim dNeto, dPrecio As Double
            Dim i As Integer

            Cost = Math.Abs(Redondear(Cost, 2))

            If Not Cost = ModPOS.Redondear(Costo, 2) Then
                bModCosto = True
                If Cost > ModPOS.Redondear(Costo, 2) Then
                    For i = 0 To dtPrecios.Rows.Count - 1
                        dPrecio = Math.Round(Cost * (1 + dtPrecios.Rows(i)("Factor")), 2)
                        dNeto = Math.Round(dPrecio * dtPrecios.Rows(i)("Impuesto"), 2)
                        dtPrecios.Rows(i)("Precio") = dPrecio
                        dtPrecios.Rows(i)("Neto") = dNeto
                        dtPrecios.Rows(i)("Min") = dPrecio - dtPrecios.Rows(i)("Diferencia")
                        dtPrecios.Rows(i)("Minimo") = Math.Round(dNeto - dtPrecios.Rows(i)("Diferencia"), 2)
                        dtPrecios.Rows(i)("Factor") = (dPrecio - Cost) / Cost
                        dtPrecios.Rows(i)("Utilidad") = ((dPrecio - Cost) * 100) / Cost
                        dtPrecios.Rows(i)("Modificado") = 1
                    Next
                Else
                    Select Case MessageBox.Show("Se ha modificado el costo. ¿Desea recalcular el precio de todas las listas?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case System.Windows.Forms.DialogResult.Yes
                            For i = 0 To dtPrecios.Rows.Count - 1
                                dPrecio = Math.Round(Cost * (1 + dtPrecios.Rows(i)("Factor")), 2)
                                dNeto = Math.Round(dPrecio * dtPrecios.Rows(i)("Impuesto"), 2)
                                dtPrecios.Rows(i)("Precio") = dPrecio
                                dtPrecios.Rows(i)("Neto") = dNeto
                                dtPrecios.Rows(i)("Min") = dPrecio - dtPrecios.Rows(i)("Diferencia")
                                dtPrecios.Rows(i)("Minimo") = Math.Round(dNeto - dtPrecios.Rows(i)("Diferencia"), 2)
                                dtPrecios.Rows(i)("Factor") = (dPrecio - Cost) / Cost
                                dtPrecios.Rows(i)("Utilidad") = ((dPrecio - Cost) * 100) / Cost
                                dtPrecios.Rows(i)("Modificado") = 1
                            Next
                    End Select
                End If
                Costo = Cost
            Else
                bModCosto = False
            End If
        End If
    End Sub

    Private Sub recuperaProducto(ByVal i As Integer)
        If Not CmbTipo.SelectedValue Is Nothing Then
            PROClave = dtProductos.Rows(i)("PROClave")
            Clave = dtProductos.Rows(i)("Clave")
            Nombre = dtProductos.Rows(i)("Nombre")
            Costo = dtProductos.Rows(i)("CostoVigente")
            TxtClaveProd.Text = ""
            TxtClave.Text = Clave
            TxtNombre.Text = Nombre
            TxtCost.Text = Costo

            bModCosto = False

            dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@Costo", Costo, "@TImpuesto", CmbTipo.SelectedValue, "@PROClave", PROClave, "@COMClave", ModPOS.CompanyActual)
            GridPrecios.DataSource = dtPrecios
            GridPrecios.RetrieveStructure(True)
            GridPrecios.GroupByBoxVisible = False
           GridPrecios.CurrentTable.Columns("Clave").Selectable = False
            GridPrecios.CurrentTable.Columns("Descripcion").Selectable = False
            GridPrecios.RootTable.Columns("Modificado").Visible = False
            GridPrecios.RootTable.Columns("Impuesto").Visible = False
            GridPrecios.RootTable.Columns("Factor").Visible = False
            GridPrecios.RootTable.Columns("PREClave").Visible = False
            GridPrecios.RootTable.Columns("Min").Visible = False
            GridPrecios.RootTable.Columns("Diferencia").Visible = False
            GridPrecios.RootTable.Columns("Inicio").Visible = False
            GridPrecios.RootTable.Columns("Utilidad").FormatString = "0.00"


        Else
            MessageBox.Show("¡El Tipo de Impuesto no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub loadProductos(ByVal CLAClave As Integer)
        If Not CmbTipo.SelectedValue Is Nothing Then
            dtProductos = ModPOS.Recupera_Tabla("sp_load_productos", "@Class", CLAClave)
            If dtProductos.Rows.Count > 0 Then
                iContador = 1
                recuperaProducto(iContador - 1)
                BtnSiguiente.Enabled = True
                TxtContador.Text = "1/" & CStr(dtProductos.Rows.Count)
            Else
                PROClave = ""
                TxtClave.Text = ""
                TxtNombre.Text = ""
                TxtCost.Text = "0"

                iContador = 0
                BtnSiguiente.Enabled = False
                TxtContador.Text = "0/0"

                dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@TImpuesto", CmbTipo.SelectedValue, "@PROClave", "", "@COMClave", ModPOS.CompanyActual, "@Costo", 0)
                GridPrecios.DataSource = dtPrecios
                GridPrecios.RetrieveStructure(True)
                GridPrecios.GroupByBoxVisible = False
             GridPrecios.CurrentTable.Columns("Clave").Selectable = False
                GridPrecios.CurrentTable.Columns("Descripcion").Selectable = False
                GridPrecios.RootTable.Columns("Modificado").Visible = False
                GridPrecios.RootTable.Columns("Impuesto").Visible = False
                GridPrecios.RootTable.Columns("Factor").Visible = False
                GridPrecios.RootTable.Columns("PREClave").Visible = False
                GridPrecios.RootTable.Columns("Min").Visible = False
                GridPrecios.RootTable.Columns("Diferencia").Visible = False
                GridPrecios.RootTable.Columns("Inicio").Visible = False
                GridPrecios.RootTable.Columns("Utilidad").FormatString = "0.00"

            End If
            BtnAnterior.Enabled = False
        Else
            MessageBox.Show("¡El Tipo de Impuesto No es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub actualizaTree(ByVal Tipo As Integer)

        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 3, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACIÓN"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()


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

    Private Sub FrmActCosto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.actCosto.Dispose()
        ModPOS.actCosto = Nothing
    End Sub

    Private Sub FrmActCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "3"
            .llenar()
        End With


        actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        bCargado = True
        
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            If bModCosto = True Then

                dtProductos.Rows(iContador - 1)("CostoVigente") = Math.Abs(CDbl(TxtCost.Text))

                Dim dtSucursal As DataTable

                dtSucursal = ModPOS.Recupera_Tabla("sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)

                dtSucursal = SelectDistinc("Sucursal", dtSucursal, "SUCClave")

                Dim z As Integer

                ModPOS.Ejecuta("st_act_costo_producto", _
                                "@PROClave", PROClave, _
                                "@Costo", Math.Abs(CDbl(TxtCost.Text)),
                                "@Usuario", ModPOS.UsuarioActual)

                For z = 0 To dtSucursal.Rows.Count - 1
                    ModPOS.Ejecuta("st_act_costo_sucursal", _
                                         "@SUCClave", dtSucursal.Rows(z)("SUCClave"), _
                                         "@PROClave", PROClave, _
                                         "@Costo", Math.Abs(CDbl(TxtCost.Text)), _
                                         "@Usuario", ModPOS.UsuarioActual)

                Next
            End If

            Dim foundRows() As System.Data.DataRow
            foundRows = dtPrecios.Select("Modificado = 1")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_modifica_precio", _
                                    "@PREClave", foundRows(i)("PREClave"), _
                                    "@PROClave", PROClave, _
                                    "@Inicio", foundRows(i)("Inicio"), _
                                    "@Precio", foundRows(i)("Precio"), _
                                    "@Minimo", foundRows(i)("Min"), _
                                    "@Usuario", ModPOS.UsuarioActual)
                Next
            End If
            Me.BtnSiguiente.PerformClick()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridPrecios_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridPrecios.CellEdited
        Dim dNeto, dPrecio As Decimal
        If GridPrecios.CurrentColumn.Caption = "Neto" Then
            If IsNumeric(GridPrecios.GetValue("Neto")) AndAlso GridPrecios.GetValue("Neto") >= (Costo * GridPrecios.GetValue("Impuesto")) Then
                dPrecio = Math.Round(Math.Round(GridPrecios.GetValue("Neto"), 2) / GridPrecios.GetValue("Impuesto"), 2)

                dNeto = Math.Round(dPrecio * GridPrecios.GetValue("Impuesto"), 2)

                GridPrecios.SetValue("Precio", dPrecio)
                GridPrecios.SetValue("Neto", dNeto)
                GridPrecios.SetValue("Minimo", Math.Round(dNeto - GridPrecios.GetValue("Diferencia"), 2))
                GridPrecios.SetValue("Min", dPrecio - GridPrecios.GetValue("Diferencia"))
                GridPrecios.SetValue("Modificado", 1)
                GridPrecios.SetValue("Factor", (dPrecio - CDbl(TxtCost.Text)) / CDbl(TxtCost.Text))
                GridPrecios.SetValue("Utilidad", ((dPrecio - CDbl(TxtCost.Text)) * 100) / CDbl(TxtCost.Text))
            Else
                GridPrecios.SetValue("Neto", Redondear(GridPrecios.GetValue("Precio") * GridPrecios.GetValue("Impuesto"), 2))
                Beep()
                MessageBox.Show("¡El Precio Neto debe ser mayor o igual al Costo más Impuestos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

        If GridPrecios.CurrentColumn.Caption = "Minimo" Then
            If Not IsNumeric(GridPrecios.GetValue("Minimo")) OrElse GridPrecios.GetValue("Neto") < GridPrecios.GetValue("Minimo") OrElse GridPrecios.GetValue("Minimo") < (Costo * GridPrecios.GetValue("Impuesto")) Then
                GridPrecios.SetValue("Minimo", Redondear(GridPrecios.GetValue("Neto") - GridPrecios.GetValue("Diferencia"), 2))
                Beep()
                MessageBox.Show("¡El Precio Minimo debe ser mayor o igual al Costo más Impuestos y menor o igual al Precio Neto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Dim Min As Double
                Min = Redondear(GridPrecios.GetValue("Minimo") / GridPrecios.GetValue("Impuesto"), 2)
                GridPrecios.SetValue("Min", Min)
                GridPrecios.SetValue("Diferencia", GridPrecios.GetValue("Precio") - Min)
                GridPrecios.SetValue("Modificado", 1)
            End If
        End If

        
        If GridPrecios.CurrentColumn.Caption = "Precio" Then
            If IsNumeric(GridPrecios.GetValue("Precio")) AndAlso GridPrecios.GetValue("Precio") >= Costo Then

                dPrecio = Math.Round(GridPrecios.GetValue("Precio"), 2)

               dNeto = Math.Round(dPrecio * GridPrecios.GetValue("Impuesto"), 2)
                GridPrecios.SetValue("Precio", dPrecio)
                GridPrecios.SetValue("Neto", dNeto)
                GridPrecios.SetValue("Minimo", Math.Round(dNeto - GridPrecios.GetValue("Diferencia"), 2))
                GridPrecios.SetValue("Min", dPrecio - GridPrecios.GetValue("Diferencia"))
                GridPrecios.SetValue("Modificado", 1)
                GridPrecios.SetValue("Factor", (dPrecio - CDbl(TxtCost.Text)) / CDbl(TxtCost.Text))
                GridPrecios.SetValue("Utilidad", ((dPrecio - CDbl(TxtCost.Text)) * 100) / CDbl(TxtCost.Text))


              
            Else
                GridPrecios.SetValue("Precio", Redondear(GridPrecios.GetValue("Neto") / GridPrecios.GetValue("Impuesto"), 2))
                Beep()
                MessageBox.Show("¡El Precio debe ser mayor o igual al Costo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

        If GridPrecios.CurrentColumn.Caption = "Utilidad" Then
            If IsNumeric(GridPrecios.GetValue("Utilidad")) AndAlso GridPrecios.GetValue("Utilidad") > 0 Then

                dPrecio = Math.Round(CDbl(TxtCost.Text) * (1 + (GridPrecios.GetValue("Utilidad") / 100)), 2)
                dNeto = Math.Round(dPrecio * GridPrecios.GetValue("Impuesto"), 2)

                GridPrecios.SetValue("Precio", dPrecio)
                GridPrecios.SetValue("Neto", dNeto)
                GridPrecios.SetValue("Minimo", Math.Round(dNeto - GridPrecios.GetValue("Diferencia"), 2))
                GridPrecios.SetValue("Min", dPrecio - GridPrecios.GetValue("Diferencia"))
                GridPrecios.SetValue("Modificado", 1)
                GridPrecios.SetValue("Factor", (dPrecio - CDbl(TxtCost.Text)) / CDbl(TxtCost.Text))
                GridPrecios.SetValue("Utilidad", ((dPrecio - CDbl(TxtCost.Text)) * 100) / CDbl(TxtCost.Text))

            Else
                GridPrecios.SetValue("Utilidad", GridPrecios.GetValue("Factor") * 100)
                Beep()
                MessageBox.Show("¡La Utilidad debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If



    End Sub

    Private Sub TxtCost_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCost.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not (TxtCost.Text = ModPOS.Redondear(Costo, 2)) Then
                If CDbl(TxtCost.Text) <= 0 Then
                    Beep()
                    MessageBox.Show("El costo debe ser mayor a cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Me.ModCosto(CDbl(TxtCost.Text))
                If Me.BtnGuardar.Focused Then
                    BtnGuardar.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub TxtCost_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCost.Leave
        If Not (TxtCost.Text = ModPOS.Redondear(Costo, 2)) Then
            If CDbl(TxtCost.Text) <= 0 Then
                Beep()
                MessageBox.Show("El costo debe ser mayor a cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Me.ModCosto(CDbl(TxtCost.Text))
            If Me.BtnGuardar.Focused Then
                BtnGuardar.PerformClick()
            End If
        End If
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

        If TxtCost.Text = "" OrElse CDbl(TxtCost.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If GridPrecios.RowCount = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
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

    Private Sub TreeViewClass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeViewClass.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not TreeViewClass.SelectedNode.Tag Is Nothing Then
            loadProductos(CInt(TreeViewClass.SelectedNode.Tag))
        End If
    End Sub

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            'Carga productos de la linea seleccionada y valida si no hay productos asociados a dicha nodo, enviando msg
            loadProductos(e.Node.Tag)
        End If
    End Sub

    Private Sub BtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnterior.Click
        If iContador >= 2 Then
            iContador -= 1
            TxtContador.Text = CStr(iContador) & "/" & CStr(dtProductos.Rows.Count)
            recuperaProducto(iContador - 1)
            If iContador = 1 Then
                BtnAnterior.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        If iContador < dtProductos.Rows.Count Then
            iContador += 1
            TxtContador.Text = CStr(iContador) & "/" & CStr(dtProductos.Rows.Count)
            recuperaProducto(iContador - 1)
            If iContador = 2 Then
                BtnAnterior.Enabled = True
            End If
        End If
    End Sub

    Private Sub loadProductosManual(ByVal sClave As String)
        If Not CmbTipo.SelectedValue Is Nothing Then
            dtProductos = ModPOS.Recupera_Tabla("sp_load_productos_manual", "@Clave", sClave)
            If dtProductos.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtProductos.Rows.Count - 1
                    If dtProductos.Rows(i)("Clave") = sClave Then
                        iContador = i + 1
                        TxtContador.Text = CStr(iContador) & "/" & CStr(dtProductos.Rows.Count)
                        recuperaProducto(i)
                        Exit For
                    End If
                Next
                If i = 0 Then
                    BtnAnterior.Enabled = False
                Else
                    BtnAnterior.Enabled = True
                End If
            Else
                MessageBox.Show("No existe la clave de producto proporcionada", "Información", MessageBoxButtons.OK)
                PROClave = ""
                TxtClave.Text = ""
                TxtNombre.Text = ""
                TxtCost.Text = "0"

                iContador = 0
                BtnSiguiente.Enabled = False
                TxtContador.Text = "0/0"

                dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@TImpuesto", CmbTipo.SelectedValue, "@PROClave", "", "@COMClave", ModPOS.CompanyActual)
                GridPrecios.DataSource = dtPrecios
                GridPrecios.RetrieveStructure(True)

                GridPrecios.GroupByBoxVisible = False
                GridPrecios.CurrentTable.Columns("Clave").Selectable = False
                GridPrecios.CurrentTable.Columns("Descripcion").Selectable = False
                GridPrecios.RootTable.Columns("Modificado").Visible = False
                GridPrecios.RootTable.Columns("Impuesto").Visible = False
                GridPrecios.RootTable.Columns("Factor").Visible = False
                GridPrecios.RootTable.Columns("PREClave").Visible = False
                GridPrecios.RootTable.Columns("Min").Visible = False
                GridPrecios.RootTable.Columns("Diferencia").Visible = False
                GridPrecios.RootTable.Columns("Inicio").Visible = False
                GridPrecios.RootTable.Columns("Utilidad").FormatString = "0.00"


            End If

        Else
            MessageBox.Show("¡El Tipo de Impuesto no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub


    Private Sub recuperaProductoClave(ByVal sClave As String)
        If Not CmbTipo.SelectedValue Is Nothing Then
            dtProductos = ModPOS.Recupera_Tabla("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
            If dtProductos.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtProductos.Rows.Count - 1
                    If dtProductos.Rows(i)("Clave") = sClave Then
                        iContador = i + 1
                        TxtContador.Text = CStr(iContador) & "/" & CStr(dtProductos.Rows.Count)
                        recuperaProducto(i)
                        Exit For
                    End If
                Next
                If i = 0 Then
                    BtnAnterior.Enabled = False
                Else
                    BtnAnterior.Enabled = True
                End If
            Else
                MessageBox.Show("No existe la clave de producto proporcionada", "Información", MessageBoxButtons.OK)
                PROClave = ""
                TxtClave.Text = ""
                TxtNombre.Text = ""
                TxtCost.Text = "0"

                iContador = 0
                BtnSiguiente.Enabled = False
                TxtContador.Text = "0/0"

                dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@TImpuesto", CmbTipo.SelectedValue, "@PROClave", "", "@COMClave", ModPOS.CompanyActual)
                GridPrecios.DataSource = dtPrecios
                GridPrecios.RetrieveStructure(True)

                GridPrecios.GroupByBoxVisible = False
                GridPrecios.CurrentTable.Columns("Clave").Selectable = False
                GridPrecios.CurrentTable.Columns("Descripcion").Selectable = False
                GridPrecios.RootTable.Columns("Modificado").Visible = False
                GridPrecios.RootTable.Columns("Impuesto").Visible = False
                GridPrecios.RootTable.Columns("Factor").Visible = False
                GridPrecios.RootTable.Columns("PREClave").Visible = False
                GridPrecios.RootTable.Columns("Min").Visible = False
                GridPrecios.RootTable.Columns("Diferencia").Visible = False
                GridPrecios.RootTable.Columns("Inicio").Visible = False
                GridPrecios.RootTable.Columns("Utilidad").FormatString = "0.00"


            End If

        Else
            MessageBox.Show("¡El Tipo de Impuesto no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub


    Public Sub recuperaProdManual(ByVal sClave As String)
        If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtProductos.Select("Clave Like '" & sClave & "'")
            If foundRows.Length = 0 Then
                'Busca y carga productos
                loadProductosManual(sClave)
            Else
                'busca dentro del arreglo acutal
                Dim i As Integer
                For i = 0 To dtProductos.Rows.Count - 1
                    If dtProductos.Rows(i)("Clave") = sClave Then
                        iContador = i + 1
                        TxtContador.Text = CStr(iContador) & "/" & CStr(dtProductos.Rows.Count)
                        recuperaProducto(i)
                        Exit For
                    End If
                Next
                If i = 0 Then
                    BtnAnterior.Enabled = False
                Else
                    BtnAnterior.Enabled = True
                End If
            End If
        Else
            loadProductosManual(sClave)
        End If
    End Sub

   

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bCargado = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

    Private Sub BtnBuscaProd_Click(sender As Object, e As EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod_costo"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            recuperaProductoClave(a.valor)
        End If
        a.Dispose()

    End Sub

    Private Sub TxtClaveProd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Enter AndAlso TxtClaveProd.Text <> "" Then
                recuperaProductoClave(TxtClaveProd.Text)
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto

            Dim a As New MeSearch
            If TallaColor = 1 Then
                a.ProcedimientoAlmacenado = "st_search_prod_tc"
                a.CampoCmb = "FiltroTC"
            Else
                a.ProcedimientoAlmacenado = "sp_search_prod"
                a.CampoCmb = "Filtro"
            End If
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProductoClave(a.valor)
            End If
            a.Dispose()

        End If
    End Sub

 
    Private Sub btnCostos_Click(sender As Object, e As EventArgs) Handles btnCostos.Click
        If ModPOS.ActualizaCosto Is Nothing Then
            ModPOS.ActualizaCosto = New FrmActualizaCosto
            With ModPOS.ActualizaCosto
                .Text = "Actualiza Costos"
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End If
        ModPOS.ActualizaCosto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ActualizaCosto.Show()
        ModPOS.ActualizaCosto.BringToFront()
    End Sub

 
End Class
