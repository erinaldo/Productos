Public Class FormHistoricoVtas
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        VisitaClave = parsVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemDetalle Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                Me.Controls.Remove(ctrlSeguimiento)
            Else
                For Each ctrl As Control In Me.Controls
                    If ctrl.Name = "lbNombreActividad" Then
                        Me.Controls.Remove(ctrl)
                        ctrl.Dispose()
                        ctrl = Nothing
                        Exit For
                    End If
                Next
            End If
        End If

        If Not Me.MenuItemDetalle Is Nothing Then Me.MenuItemDetalle.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.ListViewEstadisticas Is Nothing Then
            If Me.ListViewEstadisticas.Columns.Count > 0 Then
                Me.ListViewEstadisticas.Columns.Clear()
            End If
        End If
        If Not Me.ListViewVentas Is Nothing Then
            If Me.ListViewVentas.Columns.Count > 0 Then
                Me.ListViewVentas.Columns.Clear()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlHistorico As System.Windows.Forms.TabControl
    Friend WithEvents TabPageVentas As System.Windows.Forms.TabPage
    Friend WithEvents ButtonRegresarV As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarV As System.Windows.Forms.Button
    Friend WithEvents ListViewVentas As System.Windows.Forms.ListView
    Friend WithEvents ComboBoxFecha As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents TabPageEstadisticas As System.Windows.Forms.TabPage
    Friend WithEvents ListViewEstadisticas As System.Windows.Forms.ListView
    Friend WithEvents ButtonRegresarE As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarE As System.Windows.Forms.Button
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonDetalle As System.Windows.Forms.Button
    Friend WithEvents MenuItemDetalle As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemDetalle = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlHistorico = New System.Windows.Forms.TabControl
        Me.TabPageVentas = New System.Windows.Forms.TabPage
        Me.ButtonDetalle = New System.Windows.Forms.Button
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.ButtonRegresarV = New System.Windows.Forms.Button
        Me.ButtonContinuarV = New System.Windows.Forms.Button
        Me.ListViewVentas = New System.Windows.Forms.ListView
        Me.ComboBoxFecha = New System.Windows.Forms.ComboBox
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.TabPageEstadisticas = New System.Windows.Forms.TabPage
        Me.ListViewEstadisticas = New System.Windows.Forms.ListView
        Me.ButtonRegresarE = New System.Windows.Forms.Button
        Me.ButtonContinuarE = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControlHistorico.SuspendLayout()
        Me.TabPageVentas.SuspendLayout()
        Me.TabPageEstadisticas.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemDetalle)
        '
        'MenuItemDetalle
        '
        Me.MenuItemDetalle.Text = "MenuItemDetalle"
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
        Me.Panel1.Controls.Add(Me.TabControlHistorico)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlHistorico
        '
        Me.TabControlHistorico.Controls.Add(Me.TabPageVentas)
        Me.TabControlHistorico.Controls.Add(Me.TabPageEstadisticas)
        Me.TabControlHistorico.Location = New System.Drawing.Point(0, 0)
        Me.TabControlHistorico.Name = "TabControlHistorico"
        Me.TabControlHistorico.SelectedIndex = 0
        Me.TabControlHistorico.Size = New System.Drawing.Size(242, 295)
        Me.TabControlHistorico.TabIndex = 1
        '
        'TabPageVentas
        '
        Me.TabPageVentas.Controls.Add(Me.ButtonDetalle)
        Me.TabPageVentas.Controls.Add(Me.dtpFechaFin)
        Me.TabPageVentas.Controls.Add(Me.dtpFechaIni)
        Me.TabPageVentas.Controls.Add(Me.ButtonRegresarV)
        Me.TabPageVentas.Controls.Add(Me.ButtonContinuarV)
        Me.TabPageVentas.Controls.Add(Me.ListViewVentas)
        Me.TabPageVentas.Controls.Add(Me.ComboBoxFecha)
        Me.TabPageVentas.Controls.Add(Me.LabelFecha)
        Me.TabPageVentas.Location = New System.Drawing.Point(4, 25)
        Me.TabPageVentas.Name = "TabPageVentas"
        Me.TabPageVentas.Size = New System.Drawing.Size(234, 266)
        Me.TabPageVentas.Text = "TabPageVentas"
        '
        'ButtonDetalle
        '
        Me.ButtonDetalle.Location = New System.Drawing.Point(158, 237)
        Me.ButtonDetalle.Name = "ButtonDetalle"
        Me.ButtonDetalle.Size = New System.Drawing.Size(72, 24)
        Me.ButtonDetalle.TabIndex = 16
        Me.ButtonDetalle.Text = "ButtonDetalle"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(142, 43)
        Me.dtpFechaFin.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaFin.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 24)
        Me.dtpFechaFin.TabIndex = 14
        Me.dtpFechaFin.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(142, 17)
        Me.dtpFechaIni.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaIni.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(88, 24)
        Me.dtpFechaIni.TabIndex = 13
        Me.dtpFechaIni.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'ButtonRegresarV
        '
        Me.ButtonRegresarV.Location = New System.Drawing.Point(82, 237)
        Me.ButtonRegresarV.Name = "ButtonRegresarV"
        Me.ButtonRegresarV.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarV.TabIndex = 0
        Me.ButtonRegresarV.Text = "ButtonRegresarV"
        '
        'ButtonContinuarV
        '
        Me.ButtonContinuarV.Location = New System.Drawing.Point(5, 237)
        Me.ButtonContinuarV.Name = "ButtonContinuarV"
        Me.ButtonContinuarV.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarV.TabIndex = 1
        Me.ButtonContinuarV.Text = "ButtonContinuarV"
        '
        'ListViewVentas
        '
        Me.ListViewVentas.ContextMenu = Me.ContextMenu1
        Me.ListViewVentas.FullRowSelect = True
        Me.ListViewVentas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewVentas.Location = New System.Drawing.Point(5, 68)
        Me.ListViewVentas.Name = "ListViewVentas"
        Me.ListViewVentas.Size = New System.Drawing.Size(226, 168)
        Me.ListViewVentas.TabIndex = 2
        Me.ListViewVentas.View = System.Windows.Forms.View.Details
        '
        'ComboBoxFecha
        '
        Me.ComboBoxFecha.Location = New System.Drawing.Point(56, 17)
        Me.ComboBoxFecha.Name = "ComboBoxFecha"
        Me.ComboBoxFecha.Size = New System.Drawing.Size(86, 23)
        Me.ComboBoxFecha.TabIndex = 3
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(5, 17)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(48, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'TabPageEstadisticas
        '
        Me.TabPageEstadisticas.Controls.Add(Me.ListViewEstadisticas)
        Me.TabPageEstadisticas.Controls.Add(Me.ButtonRegresarE)
        Me.TabPageEstadisticas.Controls.Add(Me.ButtonContinuarE)
        Me.TabPageEstadisticas.Location = New System.Drawing.Point(4, 25)
        Me.TabPageEstadisticas.Name = "TabPageEstadisticas"
        Me.TabPageEstadisticas.Size = New System.Drawing.Size(234, 266)
        Me.TabPageEstadisticas.Text = "TabPageEstadisticas"
        '
        'ListViewEstadisticas
        '
        Me.ListViewEstadisticas.FullRowSelect = True
        Me.ListViewEstadisticas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEstadisticas.Location = New System.Drawing.Point(5, 16)
        Me.ListViewEstadisticas.Name = "ListViewEstadisticas"
        Me.ListViewEstadisticas.Size = New System.Drawing.Size(224, 220)
        Me.ListViewEstadisticas.TabIndex = 0
        Me.ListViewEstadisticas.View = System.Windows.Forms.View.Details
        '
        'ButtonRegresarE
        '
        Me.ButtonRegresarE.Location = New System.Drawing.Point(82, 237)
        Me.ButtonRegresarE.Name = "ButtonRegresarE"
        Me.ButtonRegresarE.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarE.TabIndex = 1
        Me.ButtonRegresarE.Text = "ButtonRegresarE"
        '
        'ButtonContinuarE
        '
        Me.ButtonContinuarE.Location = New System.Drawing.Point(5, 237)
        Me.ButtonContinuarE.Name = "ButtonContinuarE"
        Me.ButtonContinuarE.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarE.TabIndex = 2
        Me.ButtonContinuarE.Text = "ButtonContinuarE"
        '
        'FormHistoricoVtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormHistoricoVtas"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlHistorico.ResumeLayout(False)
        Me.TabPageVentas.ResumeLayout(False)
        Me.TabPageEstadisticas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private VisitaClave, TransProdId, Facturas As String
    Private NumDias, NumPedidos As Integer
    Private Fin As Boolean = False
#End Region

#Region "MIS METODOS"
    Private Sub LlenaCombo()
        With ComboBoxFecha
            .DataSource = ValorReferencia.RecuperarLista("BFNUMERI")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub AsignaFechas()
        dtpFechaIni.Value = Now
        dtpFechaFin.Value = Now
    End Sub

    Private Sub PoblaVentas()
        TransProdId = Nothing
        ListViewEstadisticas.Items.Clear()
        If dtpFechaFin.Enabled = True Then
            NumDias = ObtieneCantidadDias()
            If NumDias <= 0 Then
                Exit Sub
            End If
        Else
            NumDias = 1
        End If
        'Dim Condicion As String = " where tipo=8 and visita.clienteclave='" & oCliente.ClienteClave & "' and FechaFacturacion " & Operador(ComboBoxFecha.SelectedValue, DetailViewFechaIni.Items(0).Value, DetailViewFechaFin.Items(0).Value) & " and visita.vendedorid='" & oVendedor.VendedorId & "' order by FechaFacturacion"
        Dim Condicion As String = " where Tipo=" & IIf(Convert.ToInt32(oConHist.Campos("CobrarVentas")) = 1, "1", "8") & " and TipoFase <> 0 and visita.clienteclave='" & oCliente.ClienteClave & "' "
        If Not IsNothing(ComboBoxFecha.SelectedValue) Then
            Condicion &= "and FechaCaptura " & Operador(ComboBoxFecha.SelectedValue, dtpFechaIni.Value, dtpFechaFin.Value, TipoDato.Fecha) & " "
        End If
        Condicion &= "order by FechaCaptura"
        oVista.PoblarListView(ListViewVentas, oDBVen, "ListViewVentas", Condicion)
        ListViewVentas.Refresh()
    End Sub

    Private Function IDS() As String
        Dim i As Integer
        Dim s As String = ""
        With ListViewVentas
            For i = 0 To .Items.Count - 1
                s &= "'" & .Items(i).SubItems(4).Text & "',"
            Next
        End With
        s = Microsoft.VisualBasic.Left(s, s.Length - 1)
        Return s
    End Function

    Private Function ObtienePedidos(ByRef NumPedidos As Integer) As String
        Dim s As String = ""
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select transprodid from transprod where facturaid in(" & Facturas & ")", "Pedidos")
        NumPedidos = Dt.Rows.Count
        For Each Dr As DataRow In Dt.Rows
            s &= "'" & Dr(0) & "',"
        Next
        Dt.Dispose()
        If NumPedidos > 0 Then
            s = Microsoft.VisualBasic.Left(s, s.Length - 1)
        End If
        Return s
    End Function

    Private Sub PoblaEstadisticas()
        Facturas = IDS()
        If Facturas.Length = 0 Then Exit Sub
        'Dim Pedidos As String = ObtienePedidos(NumPedidos)
        'If NumPedidos <= 0 Then Exit Sub
        'NumPedidos = ObtieneCantidadPedidos(Pedidos)
        NumPedidos = Facturas.Split(",").Length
        'If NumPedidos <= 0 Then Exit Sub
        If (IIf(Convert.ToInt32(oConHist.Campos("CobrarVentas")) = 1, "1", "8") = "8") Then
            Dim aTbl As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE FacturaId in(" & Facturas & ")", "resul")
            If aTbl.Rows.Count > 0 Then
                Facturas = ""
                For Each r As DataRow In aTbl.Rows
                    Facturas &= "'" & r(0).ToString() & "',"
                Next
                Facturas = Facturas.Substring(0, Facturas.Length - 1)
            End If
        End If
        Dim Select1 As New System.Text.StringBuilder
        Select1.Append("select distinct(Producto.ProductoClave), Producto.Nombre, sum(TransProdDetalle.Cantidad), TransProdDetalle.TipoUnidad ")
        Select1.Append("from Producto, TransProdDetalle, TransProd ")
        Select1.Append("where Transproddetalle.Productoclave=Producto.Productoclave ")
        Select1.Append("and transprod.TransProdID in (" & Facturas & ") ")
        Select1.Append("and transproddetalle.transprodid=transprod.transprodid ")
        Select1.Append("group by producto.productoclave, TransProdDetalle.TipoUnidad, producto.nombre ")
        Select1.Append("order by producto.productoclave, tipounidad")
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Select1.ToString, "Select1")
        Select1 = Nothing
        Cursor.Current = Cursors.WaitCursor
        For Each Dr As DataRow In Dt.Rows
            With ListViewEstadisticas
                Dim LVI As New ListViewItem(Dr(0).ToString)
                LVI.SubItems.Add(Dr(1).ToString)
                LVI.SubItems.Add(FormatNumber(CInt(Dr(2).ToString) / NumPedidos, 2))
                LVI.SubItems.Add(ValorReferencia.BuscarEquivalente("UNIDADV", Dr(3)))
                'LVI.SubItems.Add(DescripcionVR(Dr(3)))
                LVI.SubItems.Add(ObtieneModa(Dr(0).ToString, Dr(3)))
                .Items.Add(LVI)
            End With
        Next
        Cursor.Current = Cursors.Default
        Dt.Dispose()
    End Sub

    Private Sub Ir_A(ByVal Indice As Integer)
        TabControlHistorico.SelectedIndex = Indice
    End Sub

#End Region

#Region "FUNCIONES"
    'Private Function DescripcionVR(ByVal Clave As Integer) As String
    '    Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select descripcion from VAVDescripcion where VARCodigo='UNIDADV' and VAVClave=" & Clave, "vv")
    '    Return Dt.Rows(0).Item(0)
    'End Function

    'Private Function Operador(ByVal Indice As Integer, ByVal ValorIni As Date, ByVal ValorFin As Date) As String
    '    Select Case Indice
    '        Case 1 'Igual
    '            Return " = " & UniFechaSQL(PrimeraHora(ValorIni))
    '        Case 2 'Diferente
    '            Return " <> " & UniFechaSQL(PrimeraHora(ValorIni))
    '        Case 3 'Mayor que
    '            Return " > " & UniFechaSQL(PrimeraHora(ValorIni))
    '        Case 4 'Menor que
    '            Return " < " & UniFechaSQL(PrimeraHora(ValorIni))
    '        Case 5 'Mayor igual que
    '            Return " >= " & UniFechaSQL(PrimeraHora(ValorIni))
    '        Case 6 'Menor igual que
    '            Return " <= " & UniFechaSQL(PrimeraHora(ValorIni))
    '        Case 7 'Entre
    '            Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " and " & UniFechaSQL(PrimeraHora(ValorFin))
    '    End Select
    '    Return ""
    'End Function

    Private Function ObtieneCantidadDias() As Integer
        Return DateDiff(DateInterval.Day, dtpFechaIni.Value, dtpFechaFin.Value) + 1
    End Function

    Private Function ObtieneModa(ByVal ClaveProducto As String, ByVal TipoUnidad As Integer) As Double
        Try
            Dim moda As New System.Text.StringBuilder
            moda.Append("select sum(TransProdDetalle.Cantidad) as Numero, transproddetalle.transprodid ")
            moda.Append("from Producto, TransProdDetalle, TransProd ")
            moda.Append("where TransProd.TransProdId = TransProdDetalle.TransProdId ")
            moda.Append("and TransProdDetalle.ProductoClave=Producto.ProductoClave ")
            moda.Append("and transprod.TransProdID in (" & Facturas & ") ")
            moda.Append("and producto.productoclave='" & ClaveProducto & "' ")
            moda.Append("and transproddetalle.tipounidad=" & TipoUnidad & " ")
            moda.Append("group by transproddetalle.transprodid ")
            'moda &= "order by Numero desc"
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(moda.ToString, "Moda")
            moda = Nothing
            Dim Cantidades As New ArrayList
            For Each Dr As DataRow In Dt.Rows
                Cantidades.Add(Dr(0))
            Next
            Dt.Dispose()
            Return ObtieneMaxRepeticion(Cantidades)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ObtieneModa")
        End Try
    End Function

    Private Function ObtieneMaxRepeticion(ByRef A As ArrayList) As Double
        A.Sort()
        A.Reverse()
        Dim clave, tmp As Integer
        Dim Maximo As Double = 0
        Dim ClaveMax As Double
        Dim i As Integer
        clave = -1
        For i = 0 To A.Count - 1
            'Si el Numero es nuevo lo asigno a Clave
            If A(i) <> clave Then
                clave = A(i)
                tmp = 0
            End If
            'Incremento la Cantidad de esa clave
            tmp += 1
            'Checo si la cantidad actual es la máxima
            If tmp > Maximo Then
                ClaveMax = clave
                Maximo = tmp
            End If
        Next
        Return ClaveMax
    End Function
#End Region

#Region "FormHistoricoVtas"
    Private Sub FormHistoricoVtas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        If Not Vista.Buscar("FormHistoricoVtas", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        Me.ButtonDetalle.Text = MenuItemDetalle.Text
        oVista.CrearListView(ListViewVentas, "ListViewVentas")
        oVista.CrearListView(ListViewEstadisticas, "ListViewEstadisticas")
        LlenaCombo()
        AsignaFechas()
        PoblaVentas()
        Fin = True
        Me.ComboBoxFecha.Focus()
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
        Else
            Dim lbNombreActividad As New Label
            lbNombreActividad.BackColor = System.Drawing.SystemColors.Control
            lbNombreActividad.Dock = System.Windows.Forms.DockStyle.Top
            Dim tam As Single = 10 * nFactorH
            lbNombreActividad.Font = New System.Drawing.Font("Tahoma", tam!, System.Drawing.FontStyle.Bold)
            UbicarTitulo(lbNombreActividad, Me.Controls)
            lbNombreActividad.Name = "lbNombreActividad"
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 32 * nFactorH) 
#Else
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 16 * nFactorH)
#End If
            lbNombreActividad.Text = sNombreActividad
            lbNombreActividad.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.Controls.Add(lbNombreActividad)
            lbNombreActividad.BringToFront()
            tam = Nothing
        End If
        [Global].HabilitarMenuItem(Me.MainMenu1, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresarV_Click(Nothing, Nothing)
    End Sub

    Private Sub TabControlHistorico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlHistorico.SelectedIndexChanged
        If TabControlHistorico.SelectedIndex = 1 AndAlso ListViewEstadisticas.Items.Count = 0 Then
            If ListViewVentas.Items.Count > 0 Then
                PoblaEstadisticas()
            End If
        End If
    End Sub
#End Region

#Region "TabPageVentas"
    Private Sub ComboBoxFecha_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFecha.SelectedIndexChanged
        If Not Fin Then Exit Sub
        If CInt(ComboBoxFecha.SelectedValue) = 7 Then
            dtpFechaFin.Enabled = True
        Else
            dtpFechaFin.Enabled = False
        End If
        PoblaVentas()
    End Sub

    Private Sub ButtonRegresarV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarV.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuarV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarV.Click
        Ir_A(1)
    End Sub

    Private Sub DetailViewFechaIni_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs)
        If Not Fin Then Exit Sub
        PoblaVentas()
    End Sub

    Private Sub DetailViewFechaFin_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs)
        If Not Fin Then Exit Sub
        PoblaVentas()
    End Sub

    Private Sub ListViewVentas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewVentas.SelectedIndexChanged
        With ListViewVentas
            If .Items.Count = 0 OrElse .SelectedIndices.Count = 0 OrElse Not Fin Then Exit Sub
            TransProdId = .Items(.SelectedIndices(0)).SubItems(4).Text
        End With
    End Sub

    Private Sub MenuItemDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDetalle.Click
        If TransProdId = Nothing OrElse ListViewVentas.Items.Count = 0 Then Exit Sub
        Dim oFHVD As New FormHistoricoVtasDetalle(TransProdId)
        oFHVD.ShowDialog()
        oFHVD.Dispose()
        'listviewventas.SelectedIndices(0)
        Try
            ListViewVentas.Items(ListViewVentas.SelectedIndices(0)).Selected = False
        Catch ex As Exception
        Finally
            TransProdId = Nothing
        End Try
    End Sub
#End Region

#Region "TabPageEstadisticas"
    Private Sub ButtonRegresarE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarE.Click
        Ir_A(0)
    End Sub

    Private Sub ButtonContinuarE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarE.Click
        Me.Close()
    End Sub
#End Region



    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If TabControlHistorico.SelectedIndex = 0 Then
            ButtonRegresarV_Click(Nothing, Nothing)
        Else
            ButtonRegresarE_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ButtonDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDetalle.Click
        MenuItemDetalle_Click(Nothing, Nothing)
    End Sub

    Private Sub dtpFechaIni_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaIni.ValueChanged
        If Not Fin Then Exit Sub
        PoblaVentas()
    End Sub

    Private Sub dtpFechaFin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaFin.ValueChanged
        If Not Fin Then Exit Sub
        PoblaVentas()
    End Sub
End Class
