'Imports Serial
Imports FieldSoftware.PrinterCE_NetCF
Imports System.IO
Imports System.Drawing.Bitmap

Public Class FormImpresionTickets
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListViewMovtos As System.Windows.Forms.ListView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
#Region " Windows Form Designer generated code "

    Public Sub New(ByVal m As ModoImpresion, Optional ByVal paroCliente As Cliente = Nothing, Optional ByVal parsVisitaClave As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oModo = m
        If oModo = ModoImpresion.ConVisita Then
            oCliente = paroCliente
            sVisitaClave = parsVisitaClave
        End If
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.MenuItemRegresar) Then
            If oModo = ModoImpresion.ConVisita And oVendedor.motconfiguracion.Secuencia Then
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

        If Not IsNothing(Me.MenuItemRegresar) Then Me.MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenu1) Then Me.MainMenu1.Dispose()
        If Not IsNothing(Me.ListViewMovtos) Then
            If ListViewMovtos.Columns.Count > 0 Then ListViewMovtos.Columns.Clear()
            Me.ListViewMovtos.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListViewMovtos = New System.Windows.Forms.ListView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.ListViewMovtos)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ListViewMovtos
        '
        Me.ListViewMovtos.CheckBoxes = True
        Me.ListViewMovtos.FullRowSelect = True
        Me.ListViewMovtos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMovtos.Location = New System.Drawing.Point(8, 16)
        Me.ListViewMovtos.Name = "ListViewMovtos"
        Me.ListViewMovtos.Size = New System.Drawing.Size(224, 248)
        Me.ListViewMovtos.TabIndex = 3
        Me.ListViewMovtos.View = System.Windows.Forms.View.Details
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(88, 265)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 4
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(8, 265)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 5
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'FormImpresionTickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormImpresionTickets"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "ENUMs"
    Public Enum ModoImpresion
        ConVisita = 1
        SinVisita = 2
    End Enum
#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private arrModoVisitas As New ArrayList
    Private hHashTable As New Hashtable
    Private oModo As ModoImpresion
    Private sVisitaClave, sVRRecibo, sId, sArchivo As String
    Private blnInicio As Boolean = False
    'Tablas del recibo
    Private htTickets As Queue
#End Region

#Region "FUNCIONES"
    Private Function EstaEnModoVisita(ByVal Tipo As Integer) As Boolean
        Dim i As Integer
        For i = 0 To arrModoVisitas.Count - 1
            If arrModoVisitas(i) = Tipo Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HaySeleccion() As Boolean
        With ListViewMovtos
            If .Items.Count = 0 Then Return False
            Dim i As Integer
            Dim TipoMov As Integer
            Dim TipoRec As Integer
            htTickets = New Queue
            For i = 0 To .Items.Count - 1
                If .Items(i).Checked Then
                    If .Items(i).SubItems(1).Text <> "" Then
                        sId = .Items(i).SubItems(5).Text
                        TipoMov = .Items(i).SubItems(6).Text
                        TipoRec = .Items(i).SubItems(7).Text
                        htTickets.Enqueue(New String() {sId, TipoMov, TipoRec})
                    End If
                End If
            Next
            If htTickets.Count > 0 Then
                Return True
            End If
        End With
        Return False
    End Function

#End Region

#Region "MIS METODOS"
    Private Sub LlenaAbonos()
        Dim s As New System.Text.StringBuilder
        s.Append("select Abono.Folio, FechaAbono, Abono.Total, Abono.ABNId ")
        s.Append("from Abono inner join Visita on ")
        s.Append("Abono.visitaclave=Visita.visitaclave ")
        s.Append("where visita.clienteclave='" & oCliente.ClienteClave & "' ")
        s.Append("and visita.diaclave='" & oDia.DiaActual & "'")
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s.ToString, "Abono")
        s = Nothing
        For Each Dr As DataRow In Dt.Rows
            Dim LVI As New ListViewItem(sVRRecibo)
            LVI.Checked = False
            LVI.SubItems.Add(Dr("folio").ToString)
            LVI.SubItems.Add("")
            LVI.SubItems.Add(Format(Dr("fechaabono"), "dd/MM/yyyy"))
            LVI.SubItems.Add(FormatNumber(Dr("total"), 2))
            LVI.SubItems.Add(Dr("abnid").ToString)
            LVI.SubItems.Add("0") 'Tipo movimiento
            LVI.SubItems.Add("10") 'Tipo recibo
            ListViewMovtos.Items.Add(LVI)
        Next
        Dt.Dispose()
    End Sub

    Private Sub LlenaHashList()
        Dim aValores As ArrayList
        aValores = ValorReferencia.RecuperarLista("TRPTIPO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                hHashTable.Add(refDesc.Id, refDesc.Cadena)
            Next
        End If
        aValores = Nothing
    End Sub

    Private Sub LlenaLV()
        Try
            ListViewMovtos.Items.Clear()
            If oModo = ModoImpresion.ConVisita Then
                LlenaAbonos()
                LlenaTransProd()
                LlenaImproductividad()
            ElseIf oModo = ModoImpresion.SinVisita Then
                ListViewMovtos.Columns(2).Width = 0
                LlenaTransProd()
                LlenaPreliquidacion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LlenaModoVisitas()
        Dim aGrupos As New ArrayList
        If oModo = ModoImpresion.ConVisita Then
            aGrupos.Add("Visita")
            'Dim Dt2 As DataTable = ValorReferencia.RecuperarLista("TRECIBO", 10)
            'VRRecibo = Dt2.Rows(0).Item(1)
            sVRRecibo = ValorReferencia.BuscarEquivalente("TRECIBO", "10")
        Else

            aGrupos.Add("No Visita")
        End If
        arrModoVisitas = ValorReferencia.RecuperaVARVGrupo("TRPTIPO", aGrupos)
    End Sub

    Private Function ObtieneValoresModoVisitas() As String
        Dim s As String = ""
        For i As Integer = 0 To arrModoVisitas.Count - 1
            s &= "'" & CType(arrModoVisitas(i), ValorReferencia.Descripcion).Id & "',"
        Next
        If s.Length > 0 Then
            s = Microsoft.VisualBasic.Left(s, s.Length - 1)
        End If
        Return s
    End Function

    Private Sub LlenaTransProd()
        Dim s As New System.Text.StringBuilder
        s.Append("Select TransProd.TransProdId, TransProd.FacturaID, TransProd.Tipo, TransProd.Folio, f.Folio as Factura, f.FechaCaptura as FechaFacturacion, TransProd.FechaCaptura, TransProd.Total, TransProd.TipoFase, Visita.ClienteClave, Visita.DiaClave ")
        s.Append("From TransProd LEFT JOIN Visita ON ")
        s.Append("TransProd.VisitaClave = Visita.VisitaClave ")
        s.Append("left join TransProd f ON TransProd.FacturaID = f.TransProdID and f.Tipo = 8 ")
        s.Append("left join TRPDatoFiscal TDF on f.TransProdID = TDF.TransProdId ")
        s.Append("WHERE TransProd.Tipofase <> 0 and ((TransProd.Tipo = 1 and TransPRod.FacturaID = TDF.TransProdID) or TransProd.Tipo <>1) ")
        s.Append("AND TransProd.Tipo in (" & ObtieneValoresModoVisitas() & ") and TransProd.Tipo <> 8 ")
        If oModo = ModoImpresion.ConVisita Then
            s.Append("AND Visita.ClienteClave='" & oCliente.ClienteClave & "' ")
            s.Append("AND Visita.VisitaClave='" & sVisitaClave & "' ")
            s.Append("AND Visita.DiaClave='" & oDia.DiaActual & "'")
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                s.Append(" UNION ")
                s.Append("Select TransProd.TransProdId, TransProd.FacturaID, TransProd.Tipo, TransProd.Folio, f.Folio as Factura,  f.FechaCaptura as FechaFacturacion, TransProd.FechaCaptura, TransProd.Total, TransProd.TipoFase, Visita.ClienteClave, Visita.DiaClave ")
                s.Append("From TransProd INNER JOIN Visita ON ")
                s.Append("TransProd.VisitaClave1 = Visita.VisitaClave AND TransProd.DiaClave1 = Visita.DiaClave  ")
                s.Append("Left join TransProd f on TransProd.FacturaID = f.TransProdID and f.Tipo = 8 ")
                s.Append("left join TRPDatoFiscal TDF on f.TransProdID = TDF.TransProdId ")
                s.Append("WHERE Visita.ClienteClave='" & oCliente.ClienteClave & "' and ((TransProd.Tipo = 1 and TransPRod.FacturaID = TDF.TransProdID) or TransProd.Tipo <>1) and TransProd.Tipofase <> 0 and TransProd.Tipo <> 8  ")
            End If
        End If
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s.ToString, "TransProd")
        s = Nothing
        For Each Dr As DataRow In Dt.Rows
            'If EstaEnModoVisita(Dr("tipo")) Then
            If oModo = ModoImpresion.ConVisita Then
                If (Dr("Tipo") = 3 AndAlso Dr("TipoFase") <> 4) OrElse Dr("Tipo") <> 3 Then
                    'Dim LVI As New ListViewItem(Dr("Folio").ToString)
                    Dim LVI As New ListViewItem(hHashTable(Dr("tipo").ToString).ToString)
                    LVI.Checked = False
                    LVI.SubItems.Add(Dr("Folio").ToString)
                    LVI.SubItems.Add(Dr("Factura").ToString)
                    If Dr("tipo") = 1 And (Not IsDBNull(Dr("FacturaID")) AndAlso Dr("FacturaID").ToString() <> "") Then
                        LVI.SubItems.Add(Format(Dr("FechaFacturacion"), "dd/MM/yyyy"))
                    Else
                        LVI.SubItems.Add(Format(Dr("FechaCaptura"), "dd/MM/yyyy"))
                    End If
                    LVI.SubItems.Add(FormatNumber(Dr("Total"), 2))
                    If (Not IsDBNull(Dr("FacturaID")) AndAlso Dr("FacturaID").ToString() <> "" AndAlso Dr("Tipo") = 1) Then
                        LVI.SubItems.Add(Dr("FacturaID").ToString)
                        LVI.SubItems.Add("8") 'TipoMovimiento
                    Else
                        LVI.SubItems.Add(Dr("TransProdId").ToString)
                        LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoMovimiento
                    End If

                    LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoMovimiento
                    If Dr("Tipo") = 1 And (Not IsDBNull(Dr("FacturaID")) AndAlso Dr("FacturaID").ToString() <> "") Then
                        LVI.SubItems.Add("24") 'TipoRecibo
                    ElseIf Dr("Tipo") = 10 Then
                        LVI.SubItems.Add("30") 'TipoRecibo
                    ElseIf Dr("Tipo") = 24 Then
                        If Dr("TipoFase") = 6 Then
                            LVI.SubItems.Add("26") 'TipoRecibo Liquidacion
                        Else
                            LVI.SubItems.Add("25") 'TipoRecibo consignacion
                        End If
                    ElseIf Dr("Tipo") = 1 Then
                        Select Case oVendedor.TipoModulo
                            Case ServicesCentral.TiposModulos.Venta
                                LVI.SubItems.Add("1") 'TipoRecibo Pedido(Venta)
                            Case ServicesCentral.TiposModulos.Preventa
                                LVI.SubItems.Add("27") 'TipoRecibo Pedido(Preventa)
                            Case ServicesCentral.TiposModulos.Distribucion
                                LVI.SubItems.Add("28") 'TipoRecibo Pedido(Reparto)
                        End Select
                    Else
                        LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoRecibo
                    End If
                    ListViewMovtos.Items.Add(LVI)
                End If
            Else
                If (Dr("Tipo") = 3 AndAlso Dr("TipoFase") <> 4) OrElse Dr("Tipo") <> 3 Then
                    'Dim LVI As New ListViewItem(Dr("Folio").ToString)
                    Dim LVI As New ListViewItem(hHashTable(Dr("Tipo").ToString).ToString)
                    LVI.Checked = False
                    LVI.SubItems.Add(Dr("Folio").ToString)
                    LVI.SubItems.Add("")
                    If Dr("tipo") = 8 Then
                        LVI.SubItems.Add(Format(Dr("FechaFacturacion"), "dd/MM/yyyy"))
                    ElseIf Dr("Tipo") = 24 Then
                        If Dr("TipoFase") = 6 Then
                            LVI.SubItems.Add("26") 'TipoRecibo Liquidacion
                        Else
                            LVI.SubItems.Add("25") 'TipoRecibo consignacion
                        End If
                    Else
                        LVI.SubItems.Add(Format(Dr("FechaCaptura"), "dd/MM/yyyy"))
                    End If
                    LVI.SubItems.Add(FormatNumber(Dr("Total"), 2))
                    LVI.SubItems.Add(Dr("TransProdId").ToString)
                    LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoMovimiento
                    LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoRecibo
                    ListViewMovtos.Items.Add(LVI)
                End If
            End If
        Next
        Dt.Dispose()
    End Sub

    Private Sub LlenaImproductividad()
        Dim sConsulta As String 
        sConsulta = "select IMP.VisitaClave, IMP.DiaClave, IMP.TipoMotivo "
        sConsulta &= "from ImproductividadVenta IMP "
        sConsulta &= "inner join Visita VIS on VIS.VisitaClave = IMP.VisitaClave "
        sConsulta &= "AND VIS.ClienteClave= '" & oCliente.ClienteClave & "' "
        sConsulta &= "AND VIS.VisitaClave='" & sVisitaClave & "' "
        sConsulta &= "AND VIS.DiaClave='" & oDia.DiaActual & "' "
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "Improductividad")
        If Dt.Rows.Count > 0 Then
            Dim sGrupoActual As String
            Dim sTipo As String = ValorReferencia.BuscarEquivalente("TRECIBO", 29)
            For Each drImp As DataRow In Dt.Rows
                sGrupoActual = ValorReferencia.RecuperaGrupo("MOTIMPRO", drImp("TipoMotivo"))
                If sGrupoActual.ToUpper = "TERMINAR VISITA" Then
                    Dim lvItem As New ListViewItem(sTipo)
                    lvItem.Checked = False
                    lvItem.SubItems.Add("")
                    lvItem.SubItems.Add("")
                    lvItem.SubItems.Add(drImp("DiaClave").ToString)
                    lvItem.SubItems.Add("")
                    lvItem.SubItems.Add(drImp("VisitaClave").ToString)
                    lvItem.SubItems.Add("0") 'TipoMovimiento
                    lvItem.SubItems.Add("29") 'TipoRecibo
                    ListViewMovtos.Items.Add(lvItem)
                End If
            Next
        End If
        Dt.Dispose()
    End Sub

    Private Sub LlenaPreliquidacion()
        If oConHist.Campos("Preliquidacion") Then
            Dim sConsulta As String = "select PLIId, FechaPreliquidacion, MontoTotal from Preliquidacion where Enviado = 0"
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "TransProd")
            If Dt.Rows.Count > 0 Then
                Dim sTipo As String = ValorReferencia.BuscarEquivalente("TRECIBO", 13)
                Dim lvItem As New ListViewItem(sTipo)
                lvItem.Checked = False
                lvItem.SubItems.Add("")
                lvItem.SubItems.Add(Format(Dt.Rows(0)("FechaPreliquidacion"), "dd/MM/yyyy"))
                lvItem.SubItems.Add(FormatNumber(Dt.Rows(0)("MontoTotal"), 2))
                lvItem.SubItems.Add(Dt.Rows(0)("PLIId").ToString)
                lvItem.SubItems.Add("13") 'TipoMovimiento
                lvItem.SubItems.Add("13") 'TipoRecibo
                ListViewMovtos.Items.Add(lvItem)
            End If
            Dt.Dispose()
        End If
    End Sub

    Private Sub PreImpresion()
        If HaySeleccion() Then
            Me.ButtonContinuar.Enabled = False
            Me.ButtonRegresar.Enabled = False
            Dim sDatos() As String
            While htTickets.Count > 0
                sDatos = htTickets.Dequeue
                'Tipo = sDatos(1)
                ImprimirTicket(sDatos(0), sDatos(1), sDatos(2), sArchivo, oModo, oCliente, sVisitaClave, oVista, False)
                'ImprimirTicket("48598D1612834572", 8, 0, sArchivo, oModo, oCliente, sVisitaClave, oVista, False)
            End While
            LlenaLV()
            sId = Nothing
            'Tipo = Nothing
            htTickets = Nothing
            Me.ButtonContinuar.Enabled = True
            Me.ButtonRegresar.Enabled = True
        End If
    End Sub
#End Region

#Region "FormImpresionTickets"

    Private Sub FormImpresionTickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oModo = ModoImpresion.ConVisita And oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oModo = ModoImpresion.ConVisita And oVendedor.motconfiguracion.Secuencia Then
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

        Me.ButtonContinuar.Enabled = False
        '--Fix para apagar el bluetooth
        If oApp.ModeloTerminal = "SymbolMC50" Or oApp.ModeloTerminal = "SymbolC9090" Then
            'Apagar/Encender el bluetooth
            Symbol_Bluetooth.Bluetooth_Off()
        ElseIf oApp.ModeloTerminal = "SymbolMC35" Then
            Dim phone As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
            phone.BlueToothEstado(PhoneRadio.RadioMode.Off)
            phone.Dispose()
        End If

        If Not Vista.Buscar("FormImpresionTickets", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        sArchivo = "\Impresion.txt"
        oVista.ColocarEtiquetasForma(Me)
        oVista.CrearListView(ListViewMovtos, "ListViewMovtos")
        Application.DoEvents()
        LlenaModoVisitas()
        LlenaHashList()
        LlenaLV()
        LlenaTamanios()
        'With ListViewMovtos
        '    If .Items.Count > 0 Then
        '        .Items(0).Selected = True
        '        .Focus()
        '    End If
        'End With
        Me.ListViewMovtos.Focus()
        Me.ButtonContinuar.Enabled = True
        [Global].HabilitarMenuItem(Me.MainMenu1, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        PreImpresion()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    'Private Sub ListViewMovtos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewMovtos.ItemCheck
    '    If blnInicio Then Exit Sub
    '    blnInicio = True
    '    MarcarElemento(ListViewMovtos, e.NewValue, e.Index)
    '    blnInicio = False
    'End Sub

    Private Sub Elegir()
        If Not RevisarElementoMarcado(ListViewMovtos) Then
            'MsgBox(refaVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information)
            Exit Sub
        End If
        blnInicio = True
        Dim refListViewItemSel As ListViewItem = ListViewMovtos.Items(ListViewMovtos.SelectedIndices(0))
        refListViewItemSel.Checked = True
        blnInicio = False
    End Sub

    'Private Sub ListViewMovtos_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewMovtos.ItemActivate
    '    If blnInicio Then Exit Sub
    '    Elegir()
    'End Sub
#End Region

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
End Class