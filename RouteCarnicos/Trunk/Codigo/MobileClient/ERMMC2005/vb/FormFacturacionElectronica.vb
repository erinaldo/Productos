Public Class FormFacturacionElectronica
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ListViewFacturas.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewFacturas.Activation = oApp.TipoSeleccion

        Dim Valores As New Hashtable
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("FACTURA")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                Valores.Add(refDesc.Id, refDesc.Cadena)
            Next
        End If
        aValores = Nothing

    End Sub

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parGrupo As Modulos.GrupoModuloMovDetalle)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ListViewFacturas.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewFacturas.Activation = oApp.TipoSeleccion

        oCliente = paroCliente
        sVisitaClave = parsVisitaClave

        Grupo = parGrupo
        Condicion = " and Visita.DiaClave=TransProd.DiaClave AND Visita.ClienteClave='" & oCliente.ClienteClave & "' AND Visita.DiaClave='" & oDia.DiaActual & "'"
        'Dim oValorReferencia As New ValorReferencia
        'Dim Valores As New Hashtable


    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        QuitarCtrlSeguimiento()

        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MainMenuFacturas.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar = Nothing
        If Me.ListViewFacturas.Columns.Count > 0 Then
            Me.ListViewFacturas.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminarEnc As System.Windows.Forms.Button
    Friend WithEvents ListViewFacturas As System.Windows.Forms.ListView
    Friend WithEvents ButtonContinuarEnc As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarEnc As System.Windows.Forms.Button
    Friend WithEvents MainMenuFacturas As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuFacturas = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonEliminarEnc = New System.Windows.Forms.Button
        Me.ListViewFacturas = New System.Windows.Forms.ListView
        Me.ButtonContinuarEnc = New System.Windows.Forms.Button
        Me.ButtonRegresarEnc = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuFacturas
        '
        Me.MainMenuFacturas.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonEliminarEnc)
        Me.Panel1.Controls.Add(Me.ListViewFacturas)
        Me.Panel1.Controls.Add(Me.ButtonContinuarEnc)
        Me.Panel1.Controls.Add(Me.ButtonRegresarEnc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonEliminarEnc
        '
        Me.ButtonEliminarEnc.Location = New System.Drawing.Point(84, 264)
        Me.ButtonEliminarEnc.Name = "ButtonEliminarEnc"
        Me.ButtonEliminarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonEliminarEnc.TabIndex = 4
        Me.ButtonEliminarEnc.Text = "ButtonRegresar"
        '
        'ListViewFacturas
        '
        Me.ListViewFacturas.CheckBoxes = True
        Me.ListViewFacturas.FullRowSelect = True
        Me.ListViewFacturas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFacturas.Location = New System.Drawing.Point(4, 17)
        Me.ListViewFacturas.Name = "ListViewFacturas"
        Me.ListViewFacturas.Size = New System.Drawing.Size(232, 244)
        Me.ListViewFacturas.TabIndex = 5
        Me.ListViewFacturas.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuarEnc
        '
        Me.ButtonContinuarEnc.Location = New System.Drawing.Point(4, 264)
        Me.ButtonContinuarEnc.Name = "ButtonContinuarEnc"
        Me.ButtonContinuarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarEnc.TabIndex = 6
        Me.ButtonContinuarEnc.Text = "ButtonContinuar"
        '
        'ButtonRegresarEnc
        '
        Me.ButtonRegresarEnc.Location = New System.Drawing.Point(162, 264)
        Me.ButtonRegresarEnc.Name = "ButtonRegresarEnc"
        Me.ButtonRegresarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarEnc.TabIndex = 7
        Me.ButtonRegresarEnc.Text = "ButtonCancelar"
        '
        'FormFacturacionElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuFacturas
        Me.MinimizeBox = False
        Me.Name = "FormFacturacionElectronica"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private refaVista As Vista
    Private oCliente As Cliente
    Private sFecha As String
    Private sTotal As Double

    Private strEstatusModificado As String = ",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oApp.Usuario.UsuarioId & "' "
    Private sVisitaClave, Condicion As String
    Private blnSeleccionManual As Boolean = False
    Private Grupo As Modulos.GrupoModuloMovDetalle

    Private Sub FormFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuFacturas)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

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


        Cargar_ListView()

        With ListViewFacturas
            If .Items.Count > 0 Then
                '.Items(0).Selected = True
                .Focus()
            Else
                Continuar()
            End If
        End With
        [Global].HabilitarMenuItem(MainMenuFacturas, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub QuitarCtrlSeguimiento()
        If Not Me.MenuItemRegresar Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenuFacturas)
                    Me.Controls.Remove(ctrlSeguimiento)
                End If

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
    End Sub

    Public Sub Cargar_ListView()

        ListViewFacturas.Activation = oApp.TipoSeleccion
        ' Recuperar los demás componentes de la forma

        If Not Vista.Buscar("FormFacturacionElectronica", refaVista) Then
            Exit Sub
        End If

        refaVista.CrearListView(ListViewFacturas, "ListViewFacturacion")
        refaVista.PoblarListView(ListViewFacturas, odbVen, "ListViewFacturacion", Condicion)

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)

    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarEnc.Click
        'RevisarElementoMarcado
        If Not RevisarElementoMarcado(ListViewFacturas) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0046"), MsgBoxStyle.Exclamation)
        Else
            'Revisar la fase determinar si se puede cancelar
            Dim oFormasFactDetalle As New FormasFacturacionElectronica
            Dim sFolio As String = ListViewFacturas.Items(ListViewFacturas.SelectedIndices.Item(0)).Text
            Dim sTransProdID As String = ListViewFacturas.Items(ListViewFacturas.SelectedIndices.Item(0)).SubItems(3).Text
            Dim strSQL As String
            strSQL = "Select TipoFase from TransProd Where Folio='" & sFolio & "' and TransProdID = '" & sTransProdID & "' "
            If oDBVen.EjecutarCmdScalarIntSQL(strSQL) = 1 Then
                If oConHist.Campos("CobrarVentas") And Not oConHist.Campos("PagoAutomatico") Then
                    strSQL = "Select Total, Saldo From TransProd Where TransProdId='" & sTransProdID & "'"
                    Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(strSQL, "TransProd")
                    If oDt.Rows(0)("Total") <> oDt.Rows(0)("Saldo") Then
                        oDt.Dispose()
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0521"), MsgBoxStyle.Critical, "Amesol Route")
                        Exit Sub
                    End If
                    oDt.Dispose()
                End If
                If ValidarTotalPreliquidacion(sTransProdID) Then
                    QuitarCtrlSeguimiento()

                    Dim sFecha As String
                    sFecha = ListViewFacturas.Items(ListViewFacturas.SelectedIndices.Item(0)).SubItems(1).Text
                    oFormasFactDetalle.MostrarDetalle(oCliente, sVisitaClave, sFolio, FormFacturaDetalle.Modo.Cancelar, Grupo, sTransProdID, sFecha)
                    refaVista.PoblarListView(ListViewFacturas, oDBVen, "ListViewFacturacion", Condicion)

                    If oVendedor.motconfiguracion.Secuencia Then
                        Me.Controls.Add(ctrlSeguimiento)
                        Me.Panel1.SendToBack()
                        ctrlSeguimiento.CrearMenuItem(Me.MainMenuFacturas)
                        AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                        AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                        ctrlSeguimiento.Iniciar()
                        [Global].HabilitarMenuItem(Me.MainMenuFacturas, True)
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
                Else
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                MsgBox(Replace(refaVista.BuscarMensaje("MsgBox", "E0043"), "$0$", "Cancelado"))
            End If
        End If
    End Sub

    Private Sub ButtonContinuarEnc_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarEnc.Click
        If validarEnviado() = False Then Continuar()

    End Sub

    Private Sub Continuar()
        QuitarCtrlSeguimiento()

        Dim oFormasFactDetalle As New FormasFacturacionElectronica

        'LFGR
        If HaySeleccion(ListViewFacturas) Then
            'If ListViewFacturas.SelectedIndices.Count > 0 Then

            Dim sFolio As String = ""
            Dim sTransProdID As String = ""
            Dim sFecha As String = ""

            ObtieneDatosFactura(sFolio, sTransProdID, sFecha)
            oFormasFactDetalle.MostrarDetalle(oCliente, sVisitaClave, sFolio, FormFacturaDetalle.Modo.Consultar, Grupo, sTransProdID, sFecha, sTotal)
            'refaVista.PoblarListView(ListViewFacturas, oDBVen, "ListViewFacturacion", Condicion)
            Me.Close()
        Else
            Dim sFolio As String = String.Empty
            If oVendedor.CapturaFolioFac = False Then
                sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Facturacion)
                If sFolio = "" Then Exit Sub
            End If
            'If sFolio <> "" Then
            oFormasFactDetalle.MostrarDetalle(oCliente, sVisitaClave, sFolio, FormFacturaDetalle.Modo.Crear, Grupo, "")
            'refaVista.PoblarListView(ListViewFacturas, oDBVen, "ListViewFacturacion", Condicion)
            Me.Close()
            'End If
        End If
    End Sub

    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Private Sub ObtieneDatosFactura(ByRef sFol As String, ByRef sTransPrId As String, ByRef sFech As String)
        Dim i As Integer
        With ListViewFacturas
            For i = 0 To .Items.Count - 1
                If .Items(i).Checked Then
                    sFol = .Items(i).Text
                    sFech = .Items(i).SubItems(1).Text
                    'sTot = .Items(i).SubItems(2).Text
                    sTransPrId = .Items(i).SubItems(3).Text
                    Exit For
                End If
            Next
        End With
    End Sub

    Private Function ObtenerPedidosFactura(ByVal sTransProdId As String) As ArrayList
        Dim sConsulta As String
        Dim dtPedidos As DataTable
        Dim aPedidos As New ArrayList
        sConsulta = "select TransProdId from TransProd where FacturaID='" & sTransProdId & "'"
        dtPedidos = oDBVen.RealizarConsultaSQL(sConsulta, "TransProd")
        For Each drPedido As DataRow In dtPedidos.Rows
            aPedidos.Add(drPedido("TransProdId"))
        Next
        Return aPedidos
    End Function

    Private Function ValidarTipoPedidos(ByVal aPedidos As ArrayList) As Boolean
        Dim sPedidos As String = ""
        Dim sConsulta As String = ""
        Dim nCant As Integer
        For Each sPedido As String In aPedidos
            sPedidos &= "'" & sPedido & "',"
        Next
        sPedidos = sPedidos.Remove(sPedidos.Length - 1, 1)
        Dim aGrupo As New ArrayList()
        aGrupo.Add("E")
        Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
        If sVarCodigos.Length > 0 Then
            sConsulta = "select count(TransProdId) from TransProd where TransProdId in (" & sPedidos & ") and ClientePagoId in(" & sVarCodigos & ") and CFVTipo = 1"
            nCant = Integer.Parse(oDBVen.RealizarScalarSQL(sConsulta))
        End If
        Return (nCant = aPedidos.Count)
    End Function

    Private Function ValidarTotalPreliquidacion(ByVal sTransProdId As String) As Boolean
        If oConHist.Campos("PagoAutomatico") And Not oConHist.Campos("CobrarVentas") And oConHist.Campos("Preliquidacion") Then
            Dim aPedidos As ArrayList
            aPedidos = ObtenerPedidosFactura(sTransProdId)
            If ValidarTipoPedidos(aPedidos) Then
                Dim nMontoTotal As Double = oDBVen.RealizarScalarSQL("SELECT MontoTotal FROM PreLiquidacion where Enviado = 0")
                Dim nTRPTotal As Double = oDBVen.RealizarScalarSQL("SELECT Total FROM TransProd where TransProdId = '" & sTransProdId & "'")
                If nTRPTotal > nMontoTotal Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function validarEnviado() As Boolean
        Try
            Return ListViewFacturas.Items(ListViewFacturas.SelectedIndices.Item(0)).SubItems(4).Text
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ListViewFacturas_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewFacturas.ItemCheck
        Try
            If blnSeleccionManual Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(Me.ListViewFacturas, e.NewValue, e.Index)
            blnSeleccionManual = False
            If Me.ListViewFacturas.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnSeleccionManual = True
                Me.ListViewFacturas.Items(Me.ListViewFacturas.SelectedIndices(0)).Selected = False
                blnSeleccionManual = False
            End If
            ButtonRegresarEnc.Enabled = Not validarEnviado()
            Me.ButtonContinuarEnc.Enabled = Not validarEnviado()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonEliminarEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarEnc.Click

        Me.Close()

    End Sub

    Private Sub ListViewFacturas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewFacturas.SelectedIndexChanged
        Try
            If blnSeleccionManual Then Exit Sub
            If Me.ListViewFacturas.SelectedIndices.Count <= 0 Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(Me.ListViewFacturas, CheckState.Checked, Me.ListViewFacturas.SelectedIndices(0))
            blnSeleccionManual = False
            ButtonRegresarEnc.Enabled = Not validarEnviado()
            Me.ButtonContinuarEnc.Enabled = Not validarEnviado()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

End Class
