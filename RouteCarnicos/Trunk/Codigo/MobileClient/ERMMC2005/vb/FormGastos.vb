Public Class FormGastos
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ListViewGastos.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.MenuContextual Is Nothing Then Me.MenuContextual.Dispose()
        If Me.ListViewGastos.Columns.Count > 0 Then
            Me.ListViewGastos.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuContextual As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlGastos As System.Windows.Forms.TabControl
    Friend WithEvents TabPageGastos As System.Windows.Forms.TabPage
    Friend WithEvents ListViewGastos As System.Windows.Forms.ListView
    Friend WithEvents ButtonContinuarG As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarG As System.Windows.Forms.Button
    Friend WithEvents Buttoneliminar As System.Windows.Forms.Button
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents ButtonRegresarD As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarD As System.Windows.Forms.Button
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxImporte As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxComentario As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents LabelImpuesto As System.Windows.Forms.Label
    Friend WithEvents LabelImporte As System.Windows.Forms.Label
    Friend WithEvents LabelComentario As System.Windows.Forms.Label
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
    Friend WithEvents LabelConcepto As System.Windows.Forms.Label
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MenuContextual = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlGastos = New System.Windows.Forms.TabControl
        Me.TabPageGastos = New System.Windows.Forms.TabPage
        Me.ListViewGastos = New System.Windows.Forms.ListView
        Me.ButtonContinuarG = New System.Windows.Forms.Button
        Me.ButtonRegresarG = New System.Windows.Forms.Button
        Me.Buttoneliminar = New System.Windows.Forms.Button
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.ButtonRegresarD = New System.Windows.Forms.Button
        Me.ButtonContinuarD = New System.Windows.Forms.Button
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.TextBoxImpuesto = New System.Windows.Forms.TextBox
        Me.TextBoxPorcentaje = New System.Windows.Forms.TextBox
        Me.TextBoxImporte = New System.Windows.Forms.TextBox
        Me.TextBoxComentario = New System.Windows.Forms.TextBox
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.ComboBoxConcepto = New System.Windows.Forms.ComboBox
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.LabelImpuesto = New System.Windows.Forms.Label
        Me.LabelImporte = New System.Windows.Forms.Label
        Me.LabelComentario = New System.Windows.Forms.Label
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.LabelConcepto = New System.Windows.Forms.Label
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControlGastos.SuspendLayout()
        Me.TabPageGastos.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuContextual
        '
        Me.MenuContextual.MenuItems.Add(Me.MenuItemEliminar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "Eliminar"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlGastos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlGastos
        '
        Me.TabControlGastos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlGastos.Controls.Add(Me.TabPageGastos)
        Me.TabControlGastos.Controls.Add(Me.TabPageDetalle)
        Me.TabControlGastos.Dock = System.Windows.Forms.DockStyle.None
        Me.TabControlGastos.Location = New System.Drawing.Point(0, 2)
        Me.TabControlGastos.Name = "TabControlGastos"
        Me.TabControlGastos.SelectedIndex = 0
        Me.TabControlGastos.Size = New System.Drawing.Size(242, 292)
        Me.TabControlGastos.TabIndex = 18
        '
        'TabPageGastos
        '
        Me.TabPageGastos.Controls.Add(Me.ListViewGastos)
        Me.TabPageGastos.Controls.Add(Me.ButtonContinuarG)
        Me.TabPageGastos.Controls.Add(Me.ButtonRegresarG)
        Me.TabPageGastos.Controls.Add(Me.Buttoneliminar)
        Me.TabPageGastos.Location = New System.Drawing.Point(0, 0)
        Me.TabPageGastos.Name = "TabPageGastos"
        Me.TabPageGastos.Size = New System.Drawing.Size(242, 269)
        Me.TabPageGastos.Text = "TabPageGastos"
        '
        'ListViewGastos
        '
        Me.ListViewGastos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewGastos.CheckBoxes = True
        Me.ListViewGastos.ContextMenu = Me.MenuContextual
        Me.ListViewGastos.FullRowSelect = True
        Me.ListViewGastos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewGastos.Location = New System.Drawing.Point(9, 4)
        Me.ListViewGastos.Name = "ListViewGastos"
        Me.ListViewGastos.Size = New System.Drawing.Size(230, 228)
        Me.ListViewGastos.TabIndex = 3
        Me.ListViewGastos.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuarG
        '
        Me.ButtonContinuarG.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonContinuarG.Location = New System.Drawing.Point(9, 234)
        Me.ButtonContinuarG.Name = "ButtonContinuarG"
        Me.ButtonContinuarG.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarG.TabIndex = 2
        Me.ButtonContinuarG.Text = "ButtonContinuarG"
        '
        'ButtonRegresarG
        '
        Me.ButtonRegresarG.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonRegresarG.Location = New System.Drawing.Point(86, 234)
        Me.ButtonRegresarG.Name = "ButtonRegresarG"
        Me.ButtonRegresarG.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarG.TabIndex = 1
        Me.ButtonRegresarG.Text = "ButtonRegresarG"
        '
        'Buttoneliminar
        '
        Me.Buttoneliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Buttoneliminar.Location = New System.Drawing.Point(162, 234)
        Me.Buttoneliminar.Name = "Buttoneliminar"
        Me.Buttoneliminar.Size = New System.Drawing.Size(72, 24)
        Me.Buttoneliminar.TabIndex = 0
        Me.Buttoneliminar.Text = "ButtonEliminar"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.dtpFecha)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresarD)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuarD)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxTotal)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxImpuesto)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxPorcentaje)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxImporte)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxComentario)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxFolio)
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxConcepto)
        Me.TabPageDetalle.Controls.Add(Me.LabelTotal)
        Me.TabPageDetalle.Controls.Add(Me.LabelImpuesto)
        Me.TabPageDetalle.Controls.Add(Me.LabelImporte)
        Me.TabPageDetalle.Controls.Add(Me.LabelComentario)
        Me.TabPageDetalle.Controls.Add(Me.LabelFolio)
        Me.TabPageDetalle.Controls.Add(Me.LabelConcepto)
        Me.TabPageDetalle.Controls.Add(Me.LabelFecha)
        Me.TabPageDetalle.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(242, 269)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(101, 8)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(128, 22)
        Me.dtpFecha.TabIndex = 8
        Me.dtpFecha.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'ButtonRegresarD
        '
        Me.ButtonRegresarD.Location = New System.Drawing.Point(86, 235)
        Me.ButtonRegresarD.Name = "ButtonRegresarD"
        Me.ButtonRegresarD.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarD.TabIndex = 17
        Me.ButtonRegresarD.Text = "ButtonRegresarD"
        '
        'ButtonContinuarD
        '
        Me.ButtonContinuarD.Location = New System.Drawing.Point(9, 235)
        Me.ButtonContinuarD.Name = "ButtonContinuarD"
        Me.ButtonContinuarD.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarD.TabIndex = 16
        Me.ButtonContinuarD.Text = "ButtonContinuarD"
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Location = New System.Drawing.Point(101, 209)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(128, 21)
        Me.TextBoxTotal.TabIndex = 15
        Me.TextBoxTotal.Text = "0.00"
        '
        'TextBoxImpuesto
        '
        Me.TextBoxImpuesto.Enabled = False
        Me.TextBoxImpuesto.Location = New System.Drawing.Point(149, 185)
        Me.TextBoxImpuesto.Name = "TextBoxImpuesto"
        Me.TextBoxImpuesto.Size = New System.Drawing.Size(80, 21)
        Me.TextBoxImpuesto.TabIndex = 14
        '
        'TextBoxPorcentaje
        '
        Me.TextBoxPorcentaje.Location = New System.Drawing.Point(101, 185)
        Me.TextBoxPorcentaje.Name = "TextBoxPorcentaje"
        Me.TextBoxPorcentaje.Size = New System.Drawing.Size(40, 21)
        Me.TextBoxPorcentaje.TabIndex = 13
        '
        'TextBoxImporte
        '
        Me.TextBoxImporte.Location = New System.Drawing.Point(101, 161)
        Me.TextBoxImporte.Name = "TextBoxImporte"
        Me.TextBoxImporte.Size = New System.Drawing.Size(128, 21)
        Me.TextBoxImporte.TabIndex = 12
        Me.TextBoxImporte.Text = "0.00"
        '
        'TextBoxComentario
        '
        Me.TextBoxComentario.Location = New System.Drawing.Point(101, 85)
        Me.TextBoxComentario.Multiline = True
        Me.TextBoxComentario.Name = "TextBoxComentario"
        Me.TextBoxComentario.Size = New System.Drawing.Size(128, 73)
        Me.TextBoxComentario.TabIndex = 11
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Location = New System.Drawing.Point(101, 61)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(128, 21)
        Me.TextBoxFolio.TabIndex = 10
        '
        'ComboBoxConcepto
        '
        Me.ComboBoxConcepto.Location = New System.Drawing.Point(101, 32)
        Me.ComboBoxConcepto.Name = "ComboBoxConcepto"
        Me.ComboBoxConcepto.Size = New System.Drawing.Size(128, 22)
        Me.ComboBoxConcepto.TabIndex = 9
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(5, 209)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(100, 20)
        Me.LabelTotal.Text = "LabelTotal"
        '
        'LabelImpuesto
        '
        Me.LabelImpuesto.Location = New System.Drawing.Point(5, 185)
        Me.LabelImpuesto.Name = "LabelImpuesto"
        Me.LabelImpuesto.Size = New System.Drawing.Size(100, 20)
        Me.LabelImpuesto.Text = "LabelImpuesto"
        '
        'LabelImporte
        '
        Me.LabelImporte.Location = New System.Drawing.Point(5, 161)
        Me.LabelImporte.Name = "LabelImporte"
        Me.LabelImporte.Size = New System.Drawing.Size(100, 20)
        Me.LabelImporte.Text = "LabelImporte"
        '
        'LabelComentario
        '
        Me.LabelComentario.Location = New System.Drawing.Point(5, 85)
        Me.LabelComentario.Name = "LabelComentario"
        Me.LabelComentario.Size = New System.Drawing.Size(100, 20)
        Me.LabelComentario.Text = "LabelComentario"
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(5, 61)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(100, 20)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'LabelConcepto
        '
        Me.LabelConcepto.Location = New System.Drawing.Point(5, 32)
        Me.LabelConcepto.Name = "LabelConcepto"
        Me.LabelConcepto.Size = New System.Drawing.Size(100, 20)
        Me.LabelConcepto.Text = "LabelConcepto"
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(5, 8)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(100, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'FormGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormGastos"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlGastos.ResumeLayout(False)
        Me.TabPageGastos.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oVista As Vista
    '    Private Query As String = "where vendedorid='" & oVendedor.Clave & "' and diaclave='" & oDia.DiaActual & "' order by fecha"
    Private Query As String = "where vendedorid='" & oVendedor.VendedorId & "' and diaclave='" & oDia.DiaActual & "' order by fecha"
    Private Cambios, Nuevo As Boolean
    Private Fin As Boolean = False
    Private ClicBtn As Boolean = False
    Private Hora As Date
    Private nSeleccionado As Integer

    Private Sub FormGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormGastos", oVista) Then
            Exit Sub
        End If
        LlenaComboConcepto()
        oVista.CrearListView(ListViewGastos, "ListViewGastos")
        oVista.PoblarListView(ListViewGastos, oDBVen, "ListViewGastos", Query)
        oVista.ColocarEtiquetasForma(Me)
        Buttoneliminar.Text = Me.MenuItemEliminar.Text
        Cambios = False
        Nuevo = True
        ActualizaHora(Now)
        Fin = True
        If ListViewGastos.Items.Count = 0 Then
            CONTINUAR()
        End If
    End Sub

    Private Sub ActualizaHora(ByVal Valor As Object)
        Hora = Format(Valor, "HH:mm:ss")
    End Sub

    Private Sub LlenaComboConcepto()
        Dim arrCon As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("GASTIPO")
        If Not aValores Is Nothing AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrCon.Add(New CConceptos(refDesc.Id, refDesc.Cadena))
            Next
            ComboBoxConcepto.DataSource = arrCon
            ComboBoxConcepto.DisplayMember = "Concepto"
            ComboBoxConcepto.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub

    Private Sub ButtonRegresarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarG.Click
        Me.Close()
    End Sub


    Private Sub ButtonRegresarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarD.Click
        ClicBtn = True
        If TextBoxPorcentaje.Text = "" Then TextBoxPorcentaje.Text = 0
        REGRESAR()
        ClicBtn = False
    End Sub

    Private Sub REGRESAR()
        If Cambios Then
            Dim res As Object
            res = MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Amesol Route")
            If res = vbNo Then
                Exit Sub
            End If
            Nuevo = True
            Cambios = False
        End If
        With ListViewGastos
            If .Items.Count > 0 Then
                Me.TabControlGastos.SelectedIndex = 0
                .Focus()
            Else
                Me.Close()
            End If
        End With

    End Sub


    Private Sub ButtonContinuarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarD.Click
        If TextBoxPorcentaje.Text = "" Then TextBoxPorcentaje.Text = 0
        TextBoxImpuesto.Text = FormatNumber(RedondeoAritmetico(CDbl(TextBoxImporte.Text) * CDbl(TextBoxPorcentaje.Text) / 100, 2), 2)
        TextBoxTotal.Text = FormatNumber(CDbl(TextBoxImporte.Text) + CDbl(TextBoxImpuesto.Text), 2)
        'De aquí en adelante esta bien
        ClicBtn = True
        If Not GuardaGasto(dtpFecha.Value) Then
            Exit Sub
            ClicBtn = False
        End If
        ClicBtn = False
        Me.Close()
    End Sub

    Private Function GuardaGasto(ByVal Fecha As DateTime) As Boolean
        Dim bandera As Boolean = False
        Try
            If ValidaCampos() Then
                Dim s As String
                If Nuevo Then
                    ActualizaHora(Now)
                    s = "insert into gasto (Fecha, VendedorId, DiaClave, TipoConcepto, Folio, Total, Comentario, Porcentaje, Importe, Impuesto, MFechaHora, MUsuarioID) values(" & UniFechaSQL(Fecha & " " & Hora) & ",'" & oVendedor.VendedorId & "','" & oDia.DiaActual & "'," & ComboBoxConcepto.SelectedValue & ",'" & TextBoxFolio.Text & "'," & CDbl(TextBoxTotal.Text) & ",'" & TextBoxComentario.Text & "'," & CDbl(TextBoxPorcentaje.Text) & "," & CDbl(TextBoxImporte.Text) & "," & CDbl(TextBoxImpuesto.Text) & "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')"
                Else
                    s = "update gasto set tipoconcepto=" & ComboBoxConcepto.SelectedValue & ", folio='" & TextBoxFolio.Text & "', comentario='" & TextBoxComentario.Text & "', importe=" & CDbl(TextBoxImporte.Text) & ", porcentaje=" & CDbl(TextBoxPorcentaje.Text) & ", impuesto=" & CDbl(TextBoxImpuesto.Text) & ", total=" & CDbl(TextBoxTotal.Text) & ", mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where fecha=" & UniFechaSQL(dtpFecha.Value)
                End If
                If oDBVen.EjecutarComandoSQL(s) > 0 Then
                    bandera = True

                    Nuevo = True
                    Query = "where vendedorid='" & oVendedor.VendedorId & "' and diaclave='" & oDia.DiaActual & "' order by fecha"
                    oVista.PoblarListView(ListViewGastos, oDBVen, "ListViewGastos", Query)
                    LimpiaDetalles()
                    Cambios = False
                    TabControlGastos.SelectedIndex = 0
                End If
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL ERROR. El gasto no se guardó por: " & ex.Message)
            bandera = False
        Catch ex As Exception
            MsgBox("ERROR. El gasto no se guardó por: " & ex.Message)
            bandera = False
        End Try
        Return bandera
    End Function
    Private Sub ListViewGastos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewGastos.ItemCheck
        Try
            If ClicBtn Then Exit Sub
            ClicBtn = True
            MarcarElemento(ListViewGastos, e.NewValue, e.Index)
            ClicBtn = False
            If ListViewGastos.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                ClicBtn = True
                ListViewGastos.Items(ListViewGastos.SelectedIndices(0)).Selected = False
                ClicBtn = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxComentario.TextChanged, TextBoxImporte.TextChanged, TextBoxPorcentaje.TextChanged, TextBoxImpuesto.TextChanged, TextBoxTotal.TextChanged, TextBoxFolio.TextChanged
        If ClicBtn Then Exit Sub
        Cambios = True
    End Sub

    Private Sub ComboBoxConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxConcepto.SelectedIndexChanged
        Cambios = True
    End Sub

    Private Sub ButtonContinuarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarG.Click
        ClicBtn = True
        CONTINUAR()
        ClicBtn = False
    End Sub

    Private Sub CONTINUAR()
        LimpiaDetalles()
        Cambios = False
        Nuevo = True
        If HaySeleccion() Then
            CargaSeleccion()
            Cambios = False
            Nuevo = False
        End If
        ClicBtn = True
        TabControlGastos.SelectedIndex = 1
        ClicBtn = False
        ComboBoxConcepto.Focus()
    End Sub

    Private Function HaySeleccion() As Boolean
        Dim i As Integer
        For i = 0 To ListViewGastos.Items.Count - 1
            If ListViewGastos.Items(i).Checked Then
                nSeleccionado = i
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub CargaSeleccion()
        Dim i As Integer
        For i = 0 To ListViewGastos.Items.Count - 1
            If ListViewGastos.Items(i).Checked Then
                Dim dFecha As Date = Date.ParseExact(ListViewGastos.Items(i).Text.Trim, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                Dim IdFecha As String = UniFechaSQL(dFecha)
                Dim s As String = "select fecha, tipoconcepto, folio, comentario, importe, porcentaje, impuesto, total from gasto where fecha=" & IdFecha
                Dim DT As DataTable = oDBVen.RealizarConsultaSQL(s, "Gasto")
                For Each Dr As DataRow In DT.Rows
                    ActualizaHora(Dr(0))
                    dtpFecha.Value = Dr(0)
                    dtpFecha.Enabled = False
                    ComboBoxConcepto.SelectedValue = Dr(1).ToString
                    TextBoxFolio.Text = Dr(2)
                    TextBoxComentario.Text = Dr(3)
                    TextBoxImporte.Text = FormatNumber(Dr(4), 2)
                    TextBoxPorcentaje.Text = Dr(5)
                    TextBoxImpuesto.Text = FormatNumber(Dr(6), 2)
                    TextBoxTotal.Text = FormatNumber(Dr(7), 2)
                Next
                DT.Dispose()
                Exit For
            End If
        Next
    End Sub

    Private Sub LimpiaDetalles()
        If Not Fin Then Exit Sub
        dtpFecha.Value = Today
        dtpFecha.Enabled = True
        If ComboBoxConcepto.Items.Count > 0 Then
            ComboBoxConcepto.SelectedIndex = 0
        End If
        TextBoxFolio.Text = ""
        TextBoxComentario.Text = ""
        TextBoxImporte.Text = "0.00"
        TextBoxPorcentaje.Text = ""
        TextBoxImpuesto.Text = ""
        TextBoxTotal.Text = "0.00"
    End Sub

    Private Function ValidaCampos() As Boolean
        If IsNothing(ComboBoxConcepto.SelectedValue) Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "BE0001").Replace("$0$", LabelConcepto.Text), MsgBoxStyle.Information)
            ComboBoxConcepto.Focus()
            Return False
        ElseIf CDbl(TextBoxImporte.Text) = 0 Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0041"), MsgBoxStyle.Information)
            TextBoxImporte.Focus()
            Return False
        ElseIf TextBoxImporte.Text = "" Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelImporte.Text), MsgBoxStyle.Information)
            TextBoxImporte.Focus()
            Return False
        ElseIf TextBoxPorcentaje.Text = "" Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelImpuesto.Text), MsgBoxStyle.Information)
            TextBoxPorcentaje.Focus()
            Return False
        ElseIf CDbl(TextBoxTotal.Text) = 0 Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelTotal.Text), MsgBoxStyle.Information)
            TextBoxTotal.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ValidaNumeros(ByVal TB As TextBox)
        If TB.Text = "" Then
            TB.Text = "0"
        ElseIf Not IsNumeric(TB.Text) Then
            TB.Focus()
        End If
    End Sub

    Private Sub TextBoxImporte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxImporte.LostFocus
        If Not IsNumeric(TextBoxImporte.Text) OrElse CDbl(TextBoxImporte.Text) = 0 Then
            TextBoxImporte.Text = "0.00"
        Else
            TextBoxImporte.Text = FormatNumber((CDbl(TextBoxImporte.Text)), 2)
        End If
        
        If CDbl(TextBoxImporte.Text) <> 0 Then
            If TextBoxPorcentaje.Text = "" Then TextBoxPorcentaje.Text = 0
            TextBoxImpuesto.Text = FormatNumber(RedondeoAritmetico(CDbl(TextBoxImporte.Text) * CDbl(TextBoxPorcentaje.Text) / 100, 2), 2)
            TextBoxTotal.Text = FormatNumber(CDbl(TextBoxImporte.Text) + CDbl(TextBoxImpuesto.Text), 2)
        End If
    End Sub

    Private Sub TextBoxPorcentaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPorcentaje.LostFocus
        If Not IsNumeric(TextBoxPorcentaje.Text) Then
            TextBoxPorcentaje.Text = ""
            'TextBoxPorcentaje.Focus()
        ElseIf CDbl(TextBoxTotal.Text) <> 0 Then
            TextBoxImporte.Text = FormatNumber(Math.Round(CDbl(TextBoxTotal.Text) / (1 + CDbl(TextBoxPorcentaje.Text) / 100), 2), 2)
            TextBoxImpuesto.Text = FormatNumber(CDbl(TextBoxTotal.Text) - CDbl(TextBoxImporte.Text), 2)
        ElseIf CDbl(TextBoxImporte.Text) <> 0 Then
            TextBoxImpuesto.Text = FormatNumber(RedondeoAritmetico(CDbl(TextBoxImporte.Text) * CDbl(TextBoxPorcentaje.Text) / 100, 2), 2)
            TextBoxTotal.Text = FormatNumber(CDbl(TextBoxImporte.Text) + CDbl(TextBoxImpuesto.Text), 2)
        End If
    End Sub

    Private Sub TextBoxImpuesto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxImpuesto.LostFocus
        If Not IsNumeric(TextBoxImpuesto.Text) OrElse CDbl(TextBoxImpuesto.Text) = 0 Then
            TextBoxImpuesto.Text = "0.00"
        Else
            TextBoxImpuesto.Text = FormatNumber(RedondeoAritmetico(CDbl(TextBoxImpuesto.Text), 2), 2)
        End If
    End Sub

    Private Sub TextBoxTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTotal.LostFocus
        If Not IsNumeric(TextBoxTotal.Text) OrElse CDbl(TextBoxTotal.Text) = 0 Then
            TextBoxTotal.Text = "0.00"
        Else
            TextBoxTotal.Text = FormatNumber(Math.Round(CDbl(TextBoxTotal.Text), 2), 2)
            'A peticion de pamela..... las siguientes lineas (a ver si jala)
            TextBoxImporte.Text = FormatNumber(Math.Round(CDbl(TextBoxTotal.Text) / (1 + CDbl(IIf(Not IsNumeric(TextBoxPorcentaje.Text), 0, TextBoxPorcentaje.Text)) / 100), 2), 2)
            TextBoxImpuesto.Text = FormatNumber(CDbl(TextBoxTotal.Text) - CDbl(TextBoxImporte.Text), 2)
        End If
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        If Not Me.HaySeleccion() Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim dFecha As Date
            dFecha = Date.ParseExact(ListViewGastos.Items(nSeleccionado).Text.Trim, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select enviado from gasto where fecha=" & UniFechaSQL(dFecha), "Consulta")
            If Not IsDBNull(Dt.Rows(0)("enviado")) AndAlso Dt.Rows(0)("enviado") Then
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0596"), MsgBoxStyle.Information)
            Else
                Dt.Dispose()
                Dim res As Object
                res = MsgBox(oVista.BuscarMensaje("Mensajes", "P0001"), MsgBoxStyle.YesNo, "Amesol Route")
                If res = vbYes Then
                    EliminaGasto(ListViewGastos.Items(nSeleccionado).Text)
                    oVista.PoblarListView(ListViewGastos, oDBVen, "ListViewGastos", Query)
                End If

            End If
            Dt.Dispose()
        End If
    End Sub

    Private Sub EliminaGasto(ByVal clave As String)
        Try
            Dim dFecha As Date
            dFecha = Date.ParseExact(clave.Trim, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select enviado from gasto where fecha=" & UniFechaSQL(dFecha), "Consulta")




            Dim s As String = "delete from gasto where fecha=" & UniFechaSQL(dFecha)
            If oDBVen.EjecutarComandoSQL(s) = 0 Then
                MsgBox("El gasto no se pudo eliminar. Query: " & s)
            End If

        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL ERROR. El gasto no se eliminó por: " & ex.Message)
        Catch ex As Exception
            MsgBox("ERROR. El gasto no se eliminó por: " & ex.Message)
        End Try
    End Sub

    Private Sub TabControlGastos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlGastos.SelectedIndexChanged
        If ClicBtn OrElse Not Fin Then Exit Sub
        If TabControlGastos.SelectedIndex = 1 Then
            CONTINUAR()
            ComboBoxConcepto.Focus()
            Me.ComboBoxConcepto.Focus()
        Else
            If Cambios Then
                Dim res As Object
                res = MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Amesol Route")
                If res = vbNo Then
                    ClicBtn = True
                    TabControlGastos.SelectedIndex = 1
                    ClicBtn = False
                    Exit Sub
                End If
                Nuevo = True
                Cambios = False
            End If
            With ListViewGastos
                If .Items.Count > 0 Then
                    .Focus()
                    'Else
                    '    Me.Close()
                End If
            End With
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.TabControlGastos.SelectedIndex = 0 Then
            ButtonRegresarG_Click(Nothing, Nothing)
        Else
            ButtonRegresarD_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttoneliminar.Click
        MenuItemEliminar_Click(Nothing, Nothing)
    End Sub
End Class

Friend Class CConceptos
    Private Con As String
    Private Val As String

    Public Sub New(ByVal v As String, ByVal c As String)
        MyBase.New()
        Me.Val = v
        Me.Con = c
    End Sub

    Public ReadOnly Property Concepto() As String
        Get
            Return Con
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return Val
        End Get
    End Property
End Class
