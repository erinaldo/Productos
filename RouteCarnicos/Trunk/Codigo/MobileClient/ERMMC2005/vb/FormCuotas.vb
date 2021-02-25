Public Class FormCuotas

#Region "Constructor"
    Sub New(ByVal pvVendedorId As String)
        MyBase.New()
        Me.InitializeComponent()
        sVendedorId = pvVendedorId
    End Sub
#End Region

#Region "Variables y Constantes"
    Private sVendedorId As String = String.Empty
    Private refaVista As Vista
    Private bCargando As Boolean

    Private Const ConstTabPageEsquemas = 0
    Private Const ConstTabPageProductos = 1
    Private Const ConstTabPageClientes = 2
    Private Const ConstTabPageVendedor = 3

#End Region

#Region "Eventos Generales de la Forma"
    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub FormCuotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormCuotas", refaVista) Then
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.LlenaFlexGridEsquemas()
        Me.LlenaFlexGridProductos()
        Me.LlenaFlexGridClientes()
        Me.LlenaFlexGridVendedor()
    End Sub

#End Region



#Region "Funciones Generales"

#End Region

#Region "Métodos Generales"
    Private Sub ColocarEtiquetas(ByRef pvFG As C1.Win.C1FlexGrid.C1FlexGrid)
        With pvFG
            Select Case .Name
                Case Me.FlexGridEsquemas.Name
                    .Cols("Cantidad").Caption = refaVista.BuscarMensaje("Titulos", "Cantidad")
                    .Cols("Tipo").Caption = refaVista.BuscarMensaje("Titulos", "Tipo")
                    .Cols("Minimo").Caption = refaVista.BuscarMensaje("Titulos", "Minimo")
                    .Cols("Nombre").Caption = refaVista.BuscarMensaje("Titulos", "Esquema")
                    .Cols("CuoClave").Caption = refaVista.BuscarMensaje("Titulos", "Clave")
                Case Me.FlexGridProductos.Name
                    .Cols("Cantidad").Caption = refaVista.BuscarMensaje("Titulos", "Cantidad")
                    .Cols("Tipo").Caption = refaVista.BuscarMensaje("Titulos", "Tipo")
                    .Cols("Minimo").Caption = refaVista.BuscarMensaje("Titulos", "Minimo")
                    .Cols("Nombre").Caption = refaVista.BuscarMensaje("Titulos", "Producto")
                    .Cols("CuoClave").Caption = refaVista.BuscarMensaje("Titulos", "Clave")
                Case Me.FlexGridClientes.Name
                    .Cols("Cantidad").Caption = refaVista.BuscarMensaje("Titulos", "Cantidad")
                    .Cols("Tipo").Caption = refaVista.BuscarMensaje("Titulos", "Tipo")
                    .Cols("Minimo").Caption = refaVista.BuscarMensaje("Titulos", "Minimo")
                    .Cols("Nombre").Caption = refaVista.BuscarMensaje("Titulos", "Cliente")
                    .Cols("CuoClave").Caption = refaVista.BuscarMensaje("Titulos", "Clave")
                Case Me.FlexGridVendedor.Name
                    .Cols("Cantidad").Caption = refaVista.BuscarMensaje("Titulos", "Cantidad")
                    .Cols("Tipo").Caption = refaVista.BuscarMensaje("Titulos", "Tipo")
                    .Cols("Minimo").Caption = refaVista.BuscarMensaje("Titulos", "Minimo")
                    .Cols("CuoClave").Caption = refaVista.BuscarMensaje("Titulos", "Clave")
            End Select
        End With
    End Sub
#End Region

#Region "TabPageEsquemas"
    Private Sub LlenaFlexGridEsquemas()
        Try
            bCargando = True
            With Me.FlexGridEsquemas
                .DataSource = Nothing
                Dim sQuery As String = "SELECT CUU.Cantidad, Convert(nvarchar,CE.Tipo) as Tipo, CE.Minimo, E.Nombre, CE.CUOClave From CuoVen CV INNER JOIN CuoEsquema CE ON CV.CUOClave=CE.CUOClave INNER JOIN Esquema E ON CE.EsquemaId=E.EsquemaId  "
                sQuery &= "INNER JOIN CuotaCumplida CC ON CV.CUOClave=CC.CUOClave and CV.VendedorID=CC.VendedorID "
                sQuery &= "INNER JOIN CueCcu CUU ON CC.CUOClave=CUU.CuoClave and CUU.VendedorID=CC.VendedorID AND CUU.EsquemaId=CE.EsquemaId AND CV.VendedorId='" & sVendedorId & "' "
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Esquemas")
                For Each oDr As DataRow In oDt.Rows
                    oDr("Tipo") = ValorReferencia.BuscarEquivalente("TUNIDAD", oDr("Tipo"))
                Next
                oDt.AcceptChanges()
                .DataSource = oDt
            End With
            Me.ColocarEtiquetas(Me.FlexGridEsquemas)
            Me.FlexGridEsquemas.Cols(0).Width = 10
            Me.FlexGridEsquemas.Row = -1
            Me.pbEsquemas.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LlenaFlexGridEsquemas")
        Finally
            bCargando = False
        End Try
    End Sub

    Private Sub FlexGridEsquemas_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGridEsquemas.SelChange
        If Not bCargando Then
            With Me.FlexGridEsquemas
                If .Row > 0 Then
                    Dim dPorcentaje As Double = .Item(.Row, "Cantidad") * 100 / .Item(.Row, "Minimo")
                    If dPorcentaje > 100 Then
                        dPorcentaje = 100
                    End If
                    Me.pbEsquemas.Value = CInt(dPorcentaje)
                    Me.lbPorcentaje1.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje") & ": " & FormatNumber(dPorcentaje, 2) & " %"
                Else
                    Me.pbEsquemas.Value = 0
                    Me.lbPorcentaje1.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje")
                End If
            End With
        End If
    End Sub

    Private Sub btContinuarEsquemas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContinuarEsquemas.Click
        Me.TabControlCuotas.SelectedIndex = ConstTabPageProductos
    End Sub

    Private Sub btRegresarEsquemas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRegresarEsquemas.Click
        Me.Close()
    End Sub
#End Region

#Region "TabPageProducto"
    Private Sub LlenaFlexGridProductos()
        Try
            bCargando = True
            With Me.FlexGridProductos
                .DataSource = Nothing
                Dim sQuery As String = "SELECT CUP.Cantidad, Convert(nvarchar,CP.Tipo) as Tipo, CP.Minimo, P.Nombre, CP.CUOClave From CuoVen CV  "
                sQuery &= "INNER JOIN CuoProducto CP ON CV.CUOClave=CP.CUOClave AND CV.VendedorId='" & sVendedorId & "' INNER JOIN Producto P ON CP.ProductoClave=P.ProductoClave "
                sQuery &= "INNER JOIN CuotaCumplida CC ON CV.CUOClave=CC.CUOClave and CV.VendedorID=CC.VendedorID INNER JOIN CupCcu CUP ON CC.CUOClave=CUP.CuoClave  AND CC.VendedorID=CUP.VendedorID AND CP.ProductoClave=CUP.ProductoClave "
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Productos")
                For Each oDr As DataRow In oDt.Rows
                    oDr("Tipo") = ValorReferencia.BuscarEquivalente("TUNIDAD", oDr("Tipo"))
                Next
                oDt.AcceptChanges()
                .DataSource = oDt
            End With
            Me.ColocarEtiquetas(Me.FlexGridProductos)
            Me.FlexGridProductos.Row = -1
            Me.FlexGridProductos.Cols(0).Width = 10
            Me.pbProducto.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LlenaFlexGridProductos")
        Finally
            bCargando = False
        End Try
    End Sub

    Private Sub FlexGridProductos_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGridProductos.SelChange
        If Not bCargando Then
            With Me.FlexGridProductos
                If .Row > 0 Then
                    Dim dPorcentaje As Double = .Item(.Row, "Cantidad") * 100 / .Item(.Row, "Minimo")
                    If dPorcentaje > 100 Then
                        dPorcentaje = 100
                    End If
                    Me.pbProducto.Value = CInt(dPorcentaje)
                    Me.lbPorcentaje2.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje") & ": " & FormatNumber(dPorcentaje, 2) & " %"
                Else
                    Me.pbProducto.Value = 0
                    Me.lbPorcentaje2.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje")
                End If
            End With
        End If
    End Sub

    Private Sub btContinuarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContinuarProductos.Click
        Me.TabControlCuotas.SelectedIndex = ConstTabPageClientes
    End Sub

    Private Sub btRegresarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRegresarProductos.Click
        Me.TabControlCuotas.SelectedIndex = ConstTabPageEsquemas
    End Sub

#End Region

#Region "TabPageClientes"
    Private Sub LlenaFlexGridClientes()
        Try
            bCargando = True
            With Me.FlexGridClientes
                .DataSource = Nothing
                Dim sQuery As String = "SELECT CCC.Cantidad, Convert(nvarchar,CUC.Tipo) as Tipo, CUC.Minimo, C.NombreCorto as Nombre, CUC.CUOClave From CuoVen CV  "
                sQuery &= "INNER JOIN CuoCliente CUC ON CV.CUOClave=CUC.CUOClave AND CV.VendedorId='" & sVendedorId & "' INNER JOIN Cliente C ON CUC.ClienteClave=C.ClienteClave "
                sQuery &= "INNER JOIN CuotaCumplida CC ON CV.CUOClave=CC.CUOClave and CV.VendedorID=CC.VendedorID INNER JOIN CucCcu CCC ON CC.CUOClave=CCC.CuoClave  and CCC.VendedorID=CC.VendedorID AND CCC.ClienteClave=CUC.ClienteClave "
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Clientes")
                For Each oDr As DataRow In oDt.Rows
                    oDr("Tipo") = ValorReferencia.BuscarEquivalente("TUNIDAD", oDr("Tipo"))
                Next
                oDt.AcceptChanges()
                .DataSource = oDt
            End With
            Me.ColocarEtiquetas(Me.FlexGridClientes)
            Me.FlexGridClientes.Row = -1
            Me.FlexGridClientes.Cols(0).Width = 10
            Me.pbClientes.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LlenaFlexGridClientes")
        Finally
            bCargando = False
        End Try
    End Sub

    Private Sub FlexGridClientes_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGridClientes.SelChange
        If Not bCargando Then
            With Me.FlexGridClientes
                If .Row > 0 Then
                    Dim dPorcentaje As Double = .Item(.Row, "Cantidad") * 100 / .Item(.Row, "Minimo")
                    If dPorcentaje > 100 Then
                        dPorcentaje = 100
                    End If
                    Me.pbClientes.Value = CInt(dPorcentaje)
                    Me.lbPorcentaje3.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje") & ": " & FormatNumber(dPorcentaje, 2) & " %"
                Else
                    Me.pbClientes.Value = 0
                    Me.lbPorcentaje3.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje")
                End If
            End With
        End If
    End Sub

    Private Sub btContinuarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContinuarClientes.Click
        Me.TabControlCuotas.SelectedIndex = ConstTabPageVendedor
    End Sub

    Private Sub btRegresarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRegresarClientes.Click
        Me.TabControlCuotas.SelectedIndex = ConstTabPageProductos
    End Sub

#End Region

#Region "TabPageVendedor"
    Private Sub LlenaFlexGridVendedor()
        Try
            bCargando = True
            With Me.FlexGridVendedor
                .DataSource = Nothing
                Dim sQuery As String = "SELECT CC.Cantidad, Convert(nvarchar,CV.Tipo) as Tipo, CV.Minimo, CV.CUOClave From CuoVen CV INNER JOIN CuotaCumplida CC ON CV.CUOClave=CC.CUOClave AND CV.VendedorID=CC.VendedorID "
                sQuery &= "WHERE CV.VendedorId='" & sVendedorId & "' "
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Vendedor")
                For Each oDr As DataRow In oDt.Rows
                    oDr("Tipo") = ValorReferencia.BuscarEquivalente("TUNIDAD", oDr("Tipo"))
                Next
                oDt.AcceptChanges()
                .DataSource = oDt
            End With
            Me.ColocarEtiquetas(Me.FlexGridVendedor)
            Me.FlexGridVendedor.Row = -1
            Me.FlexGridVendedor.Cols(0).Width = 10
            Me.pbVendedor.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LlenaFlexGridVendedor")
        Finally
            bCargando = False
        End Try
    End Sub

    Private Sub FlexGridVendedor_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGridVendedor.SelChange
        If Not bCargando Then
            With Me.FlexGridVendedor
                If .Row > 0 Then
                    Dim dPorcentaje As Double = .Item(.Row, "Cantidad") * 100 / .Item(.Row, "Minimo")
                    If dPorcentaje > 100 Then
                        dPorcentaje = 100
                    End If
                    Me.pbVendedor.Value = CInt(dPorcentaje)
                    Me.lbPorcentaje4.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje") & ": " & FormatNumber(dPorcentaje, 2) & " %"
                Else
                    Me.pbVendedor.Value = 0
                    Me.lbPorcentaje4.Text = refaVista.BuscarMensaje("MsgBox", "Porcentaje")
                End If
            End With
        End If
    End Sub

    Private Sub btContinuarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContinuarVendedor.Click
        Me.Close()
    End Sub

    Private Sub btRegresarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRegresarVendedor.Click
        Me.TabControlCuotas.SelectedIndex = ConstTabPageClientes
    End Sub
#End Region

End Class