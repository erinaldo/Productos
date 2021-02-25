Public Class FrmActCosto

    Private dtProductos, dtPrecios, dtImpuesto, dtImpuestoProd As DataTable

    Private PROClave As String
    Private Clave As String
    Private Nombre As String
    Private Costo As Double
    Private PorcImp As Double
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

    Public Function RecuperaImpuesto(ByVal sPROClave As String, ByVal iTImpuesto As Integer, ByVal sSUCClave As String) As Double

        Dim PrecioImp As Double = 100
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer

        Dim PorcImp As Double = 0

        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                End If
                PrecioImp += ImpImporte
            Next
            dtImpuesto.Dispose()
            PorcImp = (PrecioImp - 100) / 100
        End If

        Return Redondear(PorcImp, 2)

    End Function

    Public Sub ModCosto(ByVal Cost As Double)
        Dim dNeto As Double

        If Not Cost = ModPOS.Redondear(Costo, 2) Then
            bModCosto = True
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

                            dNeto = dtPrecios.Rows(i)("Neto")

                            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)
                            dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)) - dNeto)

                        Next
                    Case System.Windows.Forms.DialogResult.No
                        'Recalcula Utilidad
                        Dim i As Integer
                        For i = 0 To dtPrecios.Rows.Count - 1
                            If (Math.Abs(Cost) * (1 + PorcImp)) > dtPrecios.Rows(i)("Neto") Then
                                dtPrecios.Rows(i)("CostoRef") = Math.Abs(Cost)
                                dtPrecios.Rows(i)("Factor") = 0
                                dtPrecios.Rows(i)("Precio") = Redondear(Math.Abs(Cost), 2)

                                dNeto = dtPrecios.Rows(i)("Neto")
                                dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)

                                dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)) - dNeto)
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

                            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)
                            dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)) - dNeto)

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
        Else
            bModCosto = False
        End If
    End Sub

    Private Sub recuperaProducto(ByVal i As Integer)
        PROClave = dtProductos.Rows(i)("PROClave")
        Clave = dtProductos.Rows(i)("Clave")
        Nombre = dtProductos.Rows(i)("Nombre")
        Costo = dtProductos.Rows(i)("CostoVigente")

        PorcImp = RecuperaImpuesto(PROClave, 1, SUCClave)

        PorcImpFrontera = RecuperaImpuesto(PROClave, 2, SUCClave)

        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        TxtCost.Text = Costo

        bModCosto = False

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

    End Sub

    Private Sub loadProductos(ByVal CLAClave As Integer)
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

            dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@PROClave", "", "@COMClave", ModPOS.CompanyActual)
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

        End If
        BtnAnterior.Enabled = False

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
                Dim i As Integer
                Dim dtSucursal As DataTable

                dtSucursal = SelectDistinc("Sucursal", dtPrecios, "SUCClave")
               

                dtProductos.Rows(iContador - 1)("CostoVigente") = Costo

            End If



            

            actualizaPrecios(Ejecutar.Update)
            '            dtPrecios.AcceptChanges()
            Me.BtnSiguiente.PerformClick()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridPrecios_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridPrecios.CellEdited
        Dim dNeto As Double
        If GridPrecios.CurrentColumn.Caption = "Neto" Then
            If IsNumeric(GridPrecios.GetValue("Neto")) AndAlso GridPrecios.GetValue("Neto") >= (GridPrecios.GetValue("CostoRef") * (1 + PorcImp)) Then
                Dim dPrecio As Double
                dPrecio = GridPrecios.GetValue("Neto") / (1 + PorcImp)
                GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))
                GridPrecios.SetValue("Factor", Redondear((dPrecio / GridPrecios.GetValue("CostoRef") - 1) * 100, 2))
                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Neto"))

            Else
                GridPrecios.SetValue("Neto", Redondear(GridPrecios.GetValue("Precio") * (1 + PorcImp), 2))
                GridPrecios.SetValue("Minimo", Redondear(GridPrecios.GetValue("Precio") * (1 + PorcImp), 2))

                Beep()
                MessageBox.Show("¡El Precio Neto debe ser mayor o igual al Costo más Impuestos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If


        If GridPrecios.CurrentColumn.Caption = "Minimo" Then
            If Not IsNumeric(GridPrecios.GetValue("Minimo")) OrElse GridPrecios.GetValue("Neto") < GridPrecios.GetValue("Minimo") OrElse GridPrecios.GetValue("Minimo") < (GridPrecios.GetValue("CostoRef") * (1 + PorcImp)) Then
                GridPrecios.SetValue("Minimo", Redondear(GridPrecios.GetValue("CostoRef") * (1 + PorcImp), 2))
                Beep()
                MessageBox.Show("¡El Precio Minimo debe ser mayor o igual al Costo más Impuestos y menor o igual al Precio Neto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

        If GridPrecios.CurrentColumn.Caption = "Factor" Then
            Dim dPrecio As Double
            If IsNumeric(GridPrecios.GetValue("Factor")) AndAlso GridPrecios.GetValue("Factor") >= 0 Then
                If GridPrecios.GetValue("Factor") = 0 Then
                    dPrecio = GridPrecios.GetValue("CostoRef")
                Else
                    dPrecio = GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100))
                End If

                dNeto = GridPrecios.GetValue("Neto")

                GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))
                GridPrecios.SetValue("Neto", Redondear(dPrecio * (1 + PorcImp), 2))
                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(dPrecio * (1 + PorcImp), 2)) - dNeto))

            Else
                GridPrecios.SetValue("Factor", GridPrecios.GetValue("Fbase"))
                dPrecio = GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100))
                GridPrecios.SetValue("Precio", Redondear(dPrecio, 2))

                dNeto = GridPrecios.GetValue("Neto")

                GridPrecios.SetValue("Neto", Redondear(dPrecio * (1 + PorcImp), 2))

                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(dPrecio * (1 + PorcImp), 2)) - dNeto))

                Beep()
                MessageBox.Show("¡El factor de utilidad no puede ser menor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

        If GridPrecios.CurrentColumn.Caption = "Precio" Then
            If IsNumeric(GridPrecios.GetValue("Precio")) AndAlso GridPrecios.GetValue("Precio") >= GridPrecios.GetValue("CostoRef") Then
                If GridPrecios.GetValue("Precio") = GridPrecios.GetValue("CostoRef") Then
                    GridPrecios.SetValue("Factor", 0)
                Else
                    GridPrecios.SetValue("Factor", Redondear((GridPrecios.GetValue("Precio") / GridPrecios.GetValue("CostoRef") - 1) * 100, 2))
                End If
                dNeto = GridPrecios.GetValue("Neto")
                GridPrecios.SetValue("Neto", Redondear(GridPrecios.GetValue("Precio") * (1 + PorcImp), 2))
                GridPrecios.SetValue("Minimo", GridPrecios.GetValue("Minimo") + ((Redondear(GridPrecios.GetValue("Precio") * (1 + PorcImp), 2)) - dNeto))

            Else
                GridPrecios.SetValue("Precio", Redondear(GridPrecios.GetValue("CostoRef") * (1 + (GridPrecios.GetValue("Factor") / 100)), 2))
                Beep()
                MessageBox.Show("¡El Precio debe ser mayor o igual al Costo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

    Private Sub actualizaPrecios(ByVal Ejecutar As Ejecutar)
        Dim i As Integer

        For i = 0 To dtPrecios.Rows.Count - 1

            Select Case Ejecutar
                Case Ejecutar.Insert
                    If dtPrecios.Rows(i)("Factor") > =0 Then
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

            dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_preciosprod", "@PROClave", "", "@COMClave", ModPOS.CompanyActual)
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

    Private Sub TxtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                recuperaprodmanual(TxtClave.Text.ToUpper.Trim)
            Case Keys.Right
                'Busca y recupera los datos del producto
                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_prod"
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.CompaniaRequerido = True
                a.BusquedaInicial = True
                a.Busqueda = TxtClave.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    recuperaProdManual(a.valor)
                End If
                a.Dispose()
        End Select
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bCargado = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

End Class
