Public Class FormFacturaDetalle
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parFacturaID As String, ByVal parModo As Modo, ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal parTransProdID As String, Optional ByVal parFecha As String = "", Optional ByVal parTotal As Double = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        sFacturaID = parFacturaID

        sTransProdID = parTransProdID

        If parFecha <> "" Then
            dFecha = Date.ParseExact(parFecha, oApp.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
        End If

        sTotal = parTotal
        eModo = parModo
        Grupo = paroModuloMovDetActual

        If eModo = Modo.Crear Then
            ListViewFactura.CheckBoxes = True
        End If

        ListViewFactura.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewFactura.Activation = oApp.TipoSeleccion


        eModo = parModo

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenuPagos)
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

        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuPagos Is Nothing Then Me.MainMenuPagos.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar = Nothing
        ClienteDetalle.Dispose()
        If Me.ListViewFactura.Columns.Count > 0 Then
            Me.ListViewFactura.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabFacturaDetalle As System.Windows.Forms.TabControl
    Friend WithEvents TabFacturasPedido As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents labelFecha As System.Windows.Forms.Label
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents LabelPrincipal As System.Windows.Forms.Label
    Friend WithEvents ListViewFactura As System.Windows.Forms.ListView
    Friend WithEvents ButtonContinuarEnc As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarEnc As System.Windows.Forms.Button
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Private WithEvents DetailViewCliente As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonContinuarDet As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar1 As System.Windows.Forms.Button
    Friend WithEvents dtpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxOrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents LabelOrdenCompra As System.Windows.Forms.Label
    Friend WithEvents MainMenuPagos As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuPagos = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabFacturaDetalle = New System.Windows.Forms.TabControl
        Me.TabFacturasPedido = New System.Windows.Forms.TabPage
        Me.TextBoxOrdenCompra = New System.Windows.Forms.TextBox
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.ListViewFactura = New System.Windows.Forms.ListView
        Me.ButtonContinuarEnc = New System.Windows.Forms.Button
        Me.ButtonRegresarEnc = New System.Windows.Forms.Button
        Me.LabelOrdenCompra = New System.Windows.Forms.Label
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.DetailViewCliente = New Resco.Controls.DetailView.DetailView
        Me.ButtonContinuarDet = New System.Windows.Forms.Button
        Me.ButtonRegresar1 = New System.Windows.Forms.Button
        Me.dtpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.LabelPrincipal = New System.Windows.Forms.Label
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.labelFecha = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabFacturaDetalle.SuspendLayout()
        Me.TabFacturasPedido.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPagos
        '
        Me.MainMenuPagos.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabFacturaDetalle)
        Me.Panel1.Controls.Add(Me.dtpFechaPago)
        Me.Panel1.Controls.Add(Me.LabelPrincipal)
        Me.Panel1.Controls.Add(Me.TextBoxFolio)
        Me.Panel1.Controls.Add(Me.labelFecha)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabFacturaDetalle
        '
        Me.TabFacturaDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabFacturaDetalle.Controls.Add(Me.TabFacturasPedido)
        Me.TabFacturaDetalle.Controls.Add(Me.TabPageDetalle)
        Me.TabFacturaDetalle.Dock = System.Windows.Forms.DockStyle.None
        Me.TabFacturaDetalle.Location = New System.Drawing.Point(0, 67)
        Me.TabFacturaDetalle.Name = "TabFacturaDetalle"
        Me.TabFacturaDetalle.SelectedIndex = 0
        Me.TabFacturaDetalle.Size = New System.Drawing.Size(242, 228)
        Me.TabFacturaDetalle.TabIndex = 1
        '
        'TabFacturasPedido
        '
        Me.TabFacturasPedido.Controls.Add(Me.TextBoxOrdenCompra)
        Me.TabFacturasPedido.Controls.Add(Me.TextBoxTotal)
        Me.TabFacturasPedido.Controls.Add(Me.LabelTotal)
        Me.TabFacturasPedido.Controls.Add(Me.ListViewFactura)
        Me.TabFacturasPedido.Controls.Add(Me.ButtonContinuarEnc)
        Me.TabFacturasPedido.Controls.Add(Me.ButtonRegresarEnc)
        Me.TabFacturasPedido.Controls.Add(Me.LabelOrdenCompra)
        Me.TabFacturasPedido.Location = New System.Drawing.Point(0, 0)
        Me.TabFacturasPedido.Name = "TabFacturasPedido"
        Me.TabFacturasPedido.Size = New System.Drawing.Size(242, 205)
        Me.TabFacturasPedido.Text = "TabFacturasPedido"
        '
        'TextBoxOrdenCompra
        '
        Me.TextBoxOrdenCompra.Location = New System.Drawing.Point(101, 0)
        Me.TextBoxOrdenCompra.MaxLength = 24
        Me.TextBoxOrdenCompra.Name = "TextBoxOrdenCompra"
        Me.TextBoxOrdenCompra.Size = New System.Drawing.Size(132, 21)
        Me.TextBoxOrdenCompra.TabIndex = 10
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Enabled = False
        Me.TextBoxTotal.Location = New System.Drawing.Point(142, 149)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(91, 21)
        Me.TextBoxTotal.TabIndex = 1
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(55, 150)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(96, 20)
        Me.LabelTotal.Text = "LabelTotal"
        '
        'ListViewFactura
        '
        Me.ListViewFactura.FullRowSelect = True
        Me.ListViewFactura.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFactura.Location = New System.Drawing.Point(4, 25)
        Me.ListViewFactura.Name = "ListViewFactura"
        Me.ListViewFactura.Size = New System.Drawing.Size(229, 123)
        Me.ListViewFactura.TabIndex = 6
        Me.ListViewFactura.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuarEnc
        '
        Me.ButtonContinuarEnc.Location = New System.Drawing.Point(2, 172)
        Me.ButtonContinuarEnc.Name = "ButtonContinuarEnc"
        Me.ButtonContinuarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarEnc.TabIndex = 7
        Me.ButtonContinuarEnc.Text = "ButtonContinuar"
        '
        'ButtonRegresarEnc
        '
        Me.ButtonRegresarEnc.Location = New System.Drawing.Point(81, 172)
        Me.ButtonRegresarEnc.Name = "ButtonRegresarEnc"
        Me.ButtonRegresarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarEnc.TabIndex = 8
        Me.ButtonRegresarEnc.Text = "ButtonRegresar"
        '
        'LabelOrdenCompra
        '
        Me.LabelOrdenCompra.Location = New System.Drawing.Point(7, 0)
        Me.LabelOrdenCompra.Name = "LabelOrdenCompra"
        Me.LabelOrdenCompra.Size = New System.Drawing.Size(117, 20)
        Me.LabelOrdenCompra.Text = "LabelOrdenCompra"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.DetailViewCliente)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuarDet)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresar1)
        Me.TabPageDetalle.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(242, 205)
        Me.TabPageDetalle.Text = "TabFacturaDetalle"
        '
        'DetailViewCliente
        '
        Me.DetailViewCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewCliente.LabelWidth = 110
        Me.DetailViewCliente.Location = New System.Drawing.Point(4, 3)
        Me.DetailViewCliente.Name = "DetailViewCliente"
        Me.DetailViewCliente.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewCliente.SeparatorWidth = 4
        Me.DetailViewCliente.Size = New System.Drawing.Size(228, 168)
        Me.DetailViewCliente.TabIndex = 0
        '
        'ButtonContinuarDet
        '
        Me.ButtonContinuarDet.Location = New System.Drawing.Point(2, 172)
        Me.ButtonContinuarDet.Name = "ButtonContinuarDet"
        Me.ButtonContinuarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDet.TabIndex = 5
        Me.ButtonContinuarDet.Text = "ButtonContinuar1"
        '
        'ButtonRegresar1
        '
        Me.ButtonRegresar1.Location = New System.Drawing.Point(81, 172)
        Me.ButtonRegresar1.Name = "ButtonRegresar1"
        Me.ButtonRegresar1.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar1.TabIndex = 6
        Me.ButtonRegresar1.Text = "ButtonRegresar1"
        '
        'dtpFechaPago
        '
        Me.dtpFechaPago.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaPago.Location = New System.Drawing.Point(101, 41)
        Me.dtpFechaPago.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaPago.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaPago.Name = "dtpFechaPago"
        Me.dtpFechaPago.Size = New System.Drawing.Size(132, 22)
        Me.dtpFechaPago.TabIndex = 9
        Me.dtpFechaPago.Value = New Date(2007, 2, 1, 0, 0, 0, 0)
        '
        'LabelPrincipal
        '
        Me.LabelPrincipal.Location = New System.Drawing.Point(8, 17)
        Me.LabelPrincipal.Name = "LabelPrincipal"
        Me.LabelPrincipal.Size = New System.Drawing.Size(80, 20)
        Me.LabelPrincipal.Text = "LabelFolio"
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Location = New System.Drawing.Point(101, 17)
        Me.TextBoxFolio.MaxLength = 16
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(132, 21)
        Me.TextBoxFolio.TabIndex = 4
        '
        'labelFecha
        '
        Me.labelFecha.Location = New System.Drawing.Point(8, 42)
        Me.labelFecha.Name = "labelFecha"
        Me.labelFecha.Size = New System.Drawing.Size(72, 15)
        Me.labelFecha.Text = "LabelFecha"
        '
        'FormFacturaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuPagos
        Me.MinimizeBox = False
        Me.Name = "FormFacturaDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.TabFacturaDetalle.ResumeLayout(False)
        Me.TabFacturasPedido.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oCliente As Cliente
    Private sVisitaClave As String
    Private sFacturaID As String
    Private refaVista As Vista
    Private blnSeleccionManual As Boolean = False
    Private strEstatusModificado As String = ",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' "
    Private eModo As Modo
    Private dFecha As Date
    Private sTotal As Double
    Private Grupo As Modulos.GrupoModuloMovDetalle
    Private sTransProdID As String
    Private bHuboCambio As Boolean
    Private bIniciando As Boolean
    Private bHuboCambioCliente As Boolean = False
    Private bGuardarDetalle As Boolean = False
    Private TipoDom As Integer
    Private ClienteDetalle As New CliDom()

    Public Enum Modo
        Crear = 1
        Consultar = 2
        Cancelar = 3
    End Enum

    Private Sub FormFacturaDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.Dock = DockStyle.Top
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuPagos)
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
            'UbicarTitulo(lbNombreActividad, Me.Controls)
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

        bIniciando = True
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormFacturaDetalle", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        Dim strFiltro As String
        Application.DoEvents()
        Select Case eModo
            Case Modo.Crear
                strFiltro = " AND Visita.ClienteClave='" & oCliente.ClienteClave & "' AND Visita.DiaClave=TransProd.DiaClave"
                Me.TextBoxFolio.Text = sFacturaID
                refaVista.CrearListView(ListViewFactura, "ListViewFacturaPedido")
                refaVista.PoblarListView(ListViewFactura, oDBVen, "ListViewFacturaPedido", strFiltro)
                ListViewFactura.Activation = oApp.TipoSeleccion

                dtpFechaPago.CustomFormat = oApp.FormatoFecha()
                dtpFechaPago.Value = PrimeraHora(Now)
                dtpFechaPago.Enabled = False

                TextBoxFolio.Enabled = False

            Case Modo.Consultar, Modo.Cancelar

                strFiltro = " AND FacturaID='" & sTransProdID & "'"
                Me.TextBoxFolio.Text = sFacturaID
                refaVista.CrearListView(ListViewFactura, "ListViewFacturaDetalle")
                refaVista.PoblarListView(ListViewFactura, oDBVen, "ListViewFacturaDetalle", strFiltro)

                dtpFechaPago.CustomFormat = oApp.FormatoFecha()

                If IsDate(dFecha) Then
                    dtpFechaPago.Value = dFecha
                End If

                'LFGR
                Dim dt As DataTable = oDBVen.RealizarConsultaSQL("Select Total, Notas, Enviado from TransProd Where Folio='" & sFacturaID & "'", "Total") 'ENVIADO=0 AND 
                TextBoxTotal.Text = FormatNumber(dt.Rows(0).Item(0), 2)
                Me.TextBoxOrdenCompra.Text = dt.Rows(0).Item(1)
                Me.TextBoxOrdenCompra.Enabled = Not CType(dt.Rows(0).Item(2), Boolean)
                dt.Dispose()
                dt = Nothing
                'TextBoxTotal.Text = odbVen.EjecutarCmdScalarIntSQL("Select Total from TransProd Where Folio='" & sFacturaID & "'")

                DetailViewCliente.Enabled = False


        End Select
        ConfigurarPantalla()
        Cargar_Informacion()

        ClienteDetalle.IdFiscal = Me.DetailViewCliente.Items("IdFiscal").Value
        ClienteDetalle.RazonSocial = Me.DetailViewCliente.Items("RazonSocial").Value
        ClienteDetalle.Calle = Me.DetailViewCliente.Items("Calle").Value
        ClienteDetalle.Exterior = Me.DetailViewCliente.Items("Numero").Value
        ClienteDetalle.Interior = Me.DetailViewCliente.Items("NumInt").Value
        ClienteDetalle.Colonia = Me.DetailViewCliente.Items("Colonia").Value
        ClienteDetalle.Entidad = Me.DetailViewCliente.Items("Entidad").Value
        ClienteDetalle.Municipio = Me.DetailViewCliente.Items("Poblacion").Value
        ClienteDetalle.Pais = Me.DetailViewCliente.Items("Pais").Value
        ClienteDetalle.CodigPostal = Me.DetailViewCliente.Items("CodigoPostal").Value
        ClienteDetalle.Referencia = Me.DetailViewCliente.Items("ReferenciaDom").Value
        [Global].HabilitarMenuItem(Me.MainMenuPagos, True)
        Cursor.Current = Cursors.Default

        Me.dtpFechaPago.Focus()
        bHuboCambio = False
        bIniciando = False
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Public Sub Cargar_Informacion()

        If existe_ClienteDomicilio() Then
            'TODO: Cambio DomicilioCambios
            refaVista.CrearDetailView(DetailViewCliente, "DetailViewDomicilioCambios")
            refaVista.PoblarDetailView(DetailViewCliente, oDBVen, "DetailViewDomicilios", "WHERE ClienteDomicilio.tipo=1 and Cliente.ClienteClave='" & oCliente.ClienteClave & "'")
            If oVendedor.EditarDatosFiscal Then
                Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
                For Each refTextBox In Me.DetailViewCliente.Items
                    refTextBox.Enabled = True
                Next

            End If
        Else
            'TODO: Cambio DomicilioCambios
            refaVista.CrearDetailView(DetailViewCliente, "DetailViewDomicilios")
            refaVista.PoblarDetailView(DetailViewCliente, oDBVen, "DetailViewDomicilios", "WHERE Cliente.ClienteClave='" & oCliente.ClienteClave & "' AND ClienteDomicilio.Tipo=2")
            If oVendedor.EditarDatosFiscal Then
                Me.DetailViewCliente.Items("RazonSocial").Enabled = True
                Me.DetailViewCliente.Items("IdFiscal").Enabled = True
            End If
        End If
    End Sub

    Private Sub ConfigurarPantalla()
        If Me.eModo = Modo.Crear Then
            TextBoxFolio.Enabled = oVendedor.CapturaFolioFac
        Else
            TextBoxFolio.Enabled = False
        End If


        If eModo = Modo.Cancelar Then
            dtpFechaPago.Enabled = False
        ElseIf eModo = Modo.Crear Then
            dtpFechaPago.Enabled = True
        Else
            dtpFechaPago.Enabled = False
        End If

        'Deshabilitar los controles 

    End Sub
    Private Sub ActualizarOrdenCompra()
        Try
            If (oDBVen.oConexion.State = ConnectionState.Closed) Then
                oDBVen.oConexion.Open()
                oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()
            End If

            Dim strSQL1 As New System.Text.StringBuilder
            With strSQL1
                .Append("UPDATE Transprod SET Notas = '" & TextBoxOrdenCompra.Text & "' ")
                .Append("WHERE Transprodid = '" & sTransProdID & "' ")
            End With
            oDBVen.EjecutarComandoSQL(strSQL1.ToString)

            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Commit()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If

        Catch ex As Exception
            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Rollback()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If
        End Try
    End Sub
    Private Sub ButtonContinuarEnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarEnc.Click

        'RevisarElementoMarcado
        If Not RevisarElementoMarcado2(ListViewFactura) And eModo = Modo.Crear Then

            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0062"), MsgBoxStyle.Information)

        Else

            Select Case eModo
                Case Modo.Crear

                    TextBoxTotal.Text = Sumatoria()

                    TextBoxFolio.Focus()
                    If bGuardarDetalle Then GuardarDetalle()
                    If Crear_Factura() Then Me.Close()

                Case Modo.Cancelar

                    If Cancelar_Factura() Then Me.Close()

                Case Modo.Consultar
                    'Actualizacion de la orden de compra al entrar a modificar
                    ActualizarOrdenCompra()
                    HabilitarBotones(False)
                    If oVendedor.motconfiguracion.MensajeImpresion Then
                        If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, sTransProdID, ServicesCentral.TiposTransProd.Factura, ServicesCentral.TiposTransProd.Factura, oCliente, sVisitaClave)
                        End If
                    End If
                    HabilitarBotones(True)
                    Me.Close()

            End Select
        End If
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonContinuarEnc.Enabled = bHabilitar
        Me.ButtonRegresarEnc.Enabled = bHabilitar
    End Sub

    Private Function ValidarFolioUsado(ByVal sFolio As String) As Boolean
        Dim sConsulta As String
        sConsulta = "select count(*) from TransProd where Tipo = 8 and Folio = '" & sFolio & "'"
        Return oDBVen.RealizarScalarSQL(sConsulta) > 0
    End Function

    Public Function Crear_Factura() As Boolean

        Dim strSQL As String
        Dim strFacturaID As String
        Dim strTransProdID As String = String.Empty
        Dim strFechaFacturacion As String
        Dim aPedidos As New ArrayList
        Dim dFechaFactura As Date = dtpFechaPago.Value
        strFacturaID = Trim(TextBoxFolio.Text)
        Cursor.Current = Cursors.WaitCursor
        Try
            If strFacturaID = String.Empty Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.LabelPrincipal.Text))
                Cursor.Current = Cursors.Default
                Return False
            End If

            If oVendedor.CapturaFolioFac Then
                If Not EsNumerico(strFacturaID) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0613").Replace("$0$", Me.LabelPrincipal.Text))
                    Cursor.Current = Cursors.Default
                    Return False
                End If
                If ValidarFolioUsado(strFacturaID) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0657").Replace("$0$", Me.LabelPrincipal.Text))
                    Cursor.Current = Cursors.Default
                    Return False
                End If
            End If

            If (oDBVen.oConexion.State = ConnectionState.Closed) Then
                oDBVen.oConexion.Open()
                oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()
            End If
            '</Insertar la Factura....>
            'Campos Requeridos por la factura
            Dim dFechaCaptura As Date = PrimeraHora(Now)
            Dim strTipo As String = 8
            Dim strTipoFase As String = 1
            Dim TransProdID As String = ""

            Folio.ObtenerTransProdId(TransProdID)


            Dim refListViewItem As ListViewItem
            Dim FechaCobranza As Date
            Dim Fechatmp As Date
            Dim primero As Boolean = False
            Dim CFVtipo As String = 0
            For Each refListViewItem In Me.ListViewFactura.Items
                If refListViewItem.Checked Then

                    '//Poner para cambiar el estatus de la factura
                    strTransProdID = refListViewItem.SubItems(3).Text
                    aPedidos.Add(strTransProdID)
                    'strFechaFacturacion = refListViewItem.SubItems(1).Text
                    'Actulizar cada elemento de la Factura
                    'Dim dFechaFacturacion As Date = Date.ParseExact(strFechaFacturacion, oApp.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                    strSQL = "Update TransProd set TipoFase=3,FacturaID='" & TransProdID & "', FechaFacturacion=" & UniFechaSQL(dFechaFactura) & strEstatusModificado & ",enviado=0 where TransProdID='" & strTransProdID & "'"
                    oDBVen.EjecutarComandoSQL(strSQL)

                    Dim fila As System.Collections.Generic.List(Of Object) = oDBVen.RealizarReaderSQL("SELECT CFVtipo, FechaCobranza FROM TransProd where TransProdID='" & strTransProdID & "'")
                    Fechatmp = Convert.ToDateTime(fila(1))
                    If Not primero Then
                        FechaCobranza = Fechatmp
                        CFVtipo = fila(0).ToString()
                        primero = True
                    Else
                        If (FechaCobranza > Fechatmp) Then
                            FechaCobranza = Fechatmp
                            CFVtipo = fila(0).ToString()
                        End If
                    End If

                End If
            Next

            Dim strFolio As String = TextBoxFolio.Text
            Dim strDiaClave As String = oDia.DiaActual
            Dim strVisitaClave As String = sVisitaClave
            Dim dSubTotal As Double
            Dim dImpuesto As Double
            Dim strTotal As String = TextBoxTotal.Text
            Dim strSQL1 As New System.Text.StringBuilder

            ObtieneSubTotaleImpuesto(dSubTotal, dImpuesto)

            With strSQL1

                .Append("Insert Into TransProd(TransProdID,CFVtipo,Folio,VisitaClave,DiaClave,Tipo, TipoFase,FechaCaptura, FechaFacturacion, Subtotal, Impuesto, Total, Saldo, FechaCobranza , Notas, PCEModuloMovDetClave,FechaHoraAlta, Enviado, MFechaHora,MUsuarioID) ")
                .Append(" values ('" & TransProdID & "'")
                .Append("," & CFVtipo & "")
                .Append(",'" & strFolio & "'")
                .Append(",'" & sVisitaClave & "'")
                .Append(",'" & strDiaClave & "'")
                .Append("," & Grupo.TipoTransProd)
                .Append("," & strTipoFase)
                .Append("," & UniFechaSQL(dFechaCaptura) & "")
                .Append("," & UniFechaSQL(dFechaFactura) & "")
                .Append("," & dSubTotal & "")   'Subtotal
                .Append("," & dImpuesto & "")   'Impuesto
                .Append("," & strTotal & "")    'Total
                .Append(",Round(" & strTotal & ",2)")    'Saldo
                .Append("," + UniFechaSQL(FechaCobranza) & "")
                .Append(",'" & TextBoxOrdenCompra.Text & "'")
                .Append(",'" & Grupo.ModuloMovDetalleClave & "'")
                .Append("," & UniFechaSQL(Now))
                .Append(",0")
                .Append("," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")

            End With

            oDBVen.EjecutarComandoSQL(strSQL1.ToString)
            If oVendedor.CapturaFolioFac = False Then
                Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.Facturacion)
            End If

            'Se modifica el saldo del cliente
            'If oDBVen.RealizarConsultaSQL("Select * From ConHist Where CobrarVentas=0", "Temp").Rows.Count > 0 Then
            If Not oConHist.Campos("CobrarVentas") Then
                oCliente.ActualizarSaldo(strTotal)
                'oDBVen.EjecutarComandoSQL("Update Cliente Set SaldoEfectivo=(SaldoEfectivo + " & strTotal & ") Where ClienteClave='" & oCliente.ClienteClave & "'")
            End If

            'Sumar Puntos
            Dim oTransProd As New TransProd
            oTransProd.TransProdId = TransProdID
            oTransProd.ClienteActual = oCliente
            oTransProd.Recuperar()
            MovProducto.AcumularPuntos(oTransProd, 1)

            If Not oConHist.Campos("CobrarVentas") And oConHist.Campos("PagoAutomatico") Then
                If ValidarTipoPedidos(aPedidos) Then
                    AplicarPagoAutomatico(oTransProd)
                    ActualizarPreliquidacion(oTransProd)
                End If
            End If

            Crear_Factura = True
            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Commit()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If

            HabilitarBotones(False)
            If oVendedor.motconfiguracion.MensajeImpresion Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProd.TransProdId, ServicesCentral.TiposTransProd.Factura, ServicesCentral.TiposTransProd.Factura, oCliente, sVisitaClave)
                End If
            End If
            HabilitarBotones(True)

          
        Catch ex As Exception
            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Rollback()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If

            Crear_Factura = False

        End Try
        Cursor.Current = Cursors.Default
    End Function

    Private Function AplicarPagoAutomatico(ByVal oTransProd As TransProd) As Boolean
        Try
            Dim sABNId As String = ""
            Dim sFolio As String
            Dim dtAbono As DataTable
            dtAbono = oDBVen.RealizarConsultaSQL("SELECT ABNId, FechaHora FROM AbnTrp WHERE TransProdId = '" & oTransProd.TransProdId & "'", "AbnTrp")
            If dtAbono.Rows.Count > 0 Then
                Dim dFechaHora As DateTime
                Dim sABDId As String
                sABNId = dtAbono.Rows(0)("ABNId")
                dFechaHora = DateTime.Parse(dtAbono.Rows(0)("FechaHora"))
                sABDId = oDBVen.RealizarScalarSQL("SELECT ABDId FROM ABNDetalle WHERE ABNId = '" & sABNId & "'")
                sFolio = oDBVen.RealizarScalarSQL("SELECT Folio FROM Abono WHERE ABNId = '" & sABNId & "'")
                If FormasPago.ModificarAbono(sABNId, oTransProd.Total, 0) Then
                    If FormasPago.ModificarABNDetalle(sABNId, sABDId, 1, oTransProd.Total, 0, -1, "", False, oConHist.Campos("MonedaID").ToString) Then
                        FormasPago.ModificarABNTrp(sABNId, oTransProd.TransProdId, dFechaHora, oTransProd.Total, "", "")
                    End If
                End If
            Else
                sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Pagos)
                sABNId = FormasPago.GuardarAbono(0, sFolio, oTransProd.VisitaActual, oDia.DiaActual, Now.Date, oTransProd.Total, 0, ServicesCentral.TiposModulosMovDet.Pagos)
                If sABNId <> "" Then
                    'If FormasPago.GuardarABNDetalle(sABNId, oApp.KEYGEN(1), 1, oTransProd.Total, 0, -1, "", oConHist.Campos("MonedaID").ToString) Then
                    '    FormasPago.GuardarABNTrp(sABNId, oTransProd.TransProdId, oTransProd.Total, "", "")
                    'End If
                End If
            End If
            oTransProd.ClienteActual.ActualizarSaldo(Decimal.Negate(oTransProd.Total))
            oTransProd.ActualizarSaldo(Decimal.Negate(oTransProd.Total))

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function


    Private Sub ActualizarPreliquidacion(ByVal oTransProd As TransProd, Optional ByVal bEliminar As Boolean = False)
        Try
            If oConHist.Campos("PagoAutomatico") And Not oConHist.Campos("CobrarVentas") And oConHist.Campos("Preliquidacion") Then
                Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0", "Preliq")
                Dim bExistePreliquidacion As Boolean = oDT.Rows.Count > 0
                Dim sPLIId As String = ""
                Dim nMontoTotal As Double = 0
                Dim sComando As String
                If bExistePreliquidacion Then
                    sPLIId = oDT.Rows(0)("PLIId")
                    nMontoTotal = oDT.Rows(0)("MontoTotal")
                End If

                If Not bEliminar Then
                    nMontoTotal += oTransProd.Total
                    If bExistePreliquidacion Then
                        sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
                    Else
                        sPLIId = oApp.KEYGEN(1)
                        sComando = "insert into PreLiquidacion (PLIId, FechaPreLiquidacion, MontoTotal, Enviado) values ('" & sPLIId & "', " & UniFechaSQL(Now) & ", " & nMontoTotal & ", 0)"
                    End If
                Else
                    nMontoTotal -= oTransProd.Total
                    If nMontoTotal <> 0 Then
                        sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
                    Else
                        Dim bBorrar As Boolean
                        bBorrar = (oDBVen.RealizarScalarSQL("select count(*) from PLBPLE where PLIId = '" & sPLIId & "'") = 0)
                        bBorrar = bBorrar And (oDBVen.RealizarScalarSQL("select count(*) from TransProd where PLIId = '" & sPLIId & "' and TransProdId <> '" & oTransProd.TransProdId & "'") = 0)
                        If bBorrar Then
                            sComando = "delete Preliquidacion where PLIId = '" & sPLIId & "'"
                        Else
                            sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
                        End If
                    End If
                End If

                oDBVen.EjecutarComandoSQL(sComando)
                If Not bEliminar Then
                    'Relacionar TransProd con Preliquidación
                    oTransProd.PLIId = sPLIId
                Else
                    'Eliminar la relacion de TransProd con Preliquidacion
                    oTransProd.PLIId = ""
                End If
                oTransProd.ActualizarPLIId()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

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

    Public Sub ObtieneSubTotaleImpuesto(ByRef dSubTotal As Double, ByRef dImpuesto As Double)
        dSubTotal = 0
        dImpuesto = 0
        For i As Integer = 0 To ListViewFactura.Items.Count - 1
            If ListViewFactura.Items(i).Checked Then
                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select subtotal, impuesto from transprod where transprodid ='" & ListViewFactura.Items(i).SubItems(3).Text & "'", "Totales")
                dSubTotal += CDbl(Dt.Rows(0).Item(0))
                dImpuesto += CDbl(Dt.Rows(0).Item(1))
                Dt.Dispose()
            End If
        Next

    End Sub

    Public Function Cancelar_Factura() As Boolean

        Dim strSQL As String
        Dim strFacturaID As String

        strFacturaID = TextBoxFolio.Text

        Try
            If (oDBVen.oConexion.State = ConnectionState.Closed) Then
                oDBVen.oConexion.Open()
                oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()
            End If
            '//Actualizar cada elemento de la Factura
            strSQL = "Update TransProd set TipoFase=0, FechaCancelacion=" & UniFechaSQL(Now) & strEstatusModificado & ",Enviado=0 where TransProdID='" & sTransProdID & "'"
            oDBVen.EjecutarComandoSQL(strSQL)

            '//Cancelar los pedidos de esa factura 
            strSQL = "Update TransProd set FacturaId=NULL, TipoFase=2, FechaFacturacion=NULL" & strEstatusModificado & ",Enviado=0 where FacturaID='" & sTransProdID & "'"
            oDBVen.EjecutarComandoSQL(strSQL)

            'Restar Puntos
            Dim oTransProd As New TransProd
            oTransProd.TransProdId = sTransProdID
            oTransProd.ClienteActual = oCliente
            oTransProd.Recuperar()
            MovProducto.RestarPuntos(oTransProd, 1)

            'If oDBVen.RealizarConsultaSQL("Select * From ConHist Where CobrarVentas=0", "Temp").Rows.Count > 0 Then
            If Not oConHist.Campos("CobrarVentas") Then
                oTransProd.ClienteActual.ActualizarSaldo(-oTransProd.Total)
            End If

            If Not oConHist.Campos("CobrarVentas") And oConHist.Campos("PagoAutomatico") Then
                Dim aPedidos As ArrayList
                aPedidos = ObtenerPedidosFactura(oTransProd.TransProdId)
                If ValidarTipoPedidos(aPedidos) Then
                    EliminarPagoAutomatico(oTransProd)
                    ActualizarPreliquidacion(oTransProd, True)
                End If
            End If

            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Commit()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If
        Catch ex As Exception
            Cancelar_Factura = False
            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Rollback()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If
            Exit Function
        End Try


        Cancelar_Factura = True

    End Function

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

    Private Function EliminarPagoAutomatico(ByVal oTransProd As TransProd) As Boolean
        Try
            Dim dtAbono As DataTable
            dtAbono = oDBVen.RealizarConsultaSQL("SELECT ABNId, FechaHora FROM AbnTrp WHERE TransProdId = '" & oTransProd.TransProdId & "'", "AbnTrp")
            If dtAbono.Rows.Count > 0 Then
                Dim sABNId As String
                Dim dFechaHora As DateTime
                sABNId = dtAbono.Rows(0)("ABNId")
                dFechaHora = DateTime.Parse(dtAbono.Rows(0)("FechaHora"))
                FormasPago.EliminarABNTrp(sABNId, oTransProd.TransProdId, dFechaHora)
                Dim sABDId As String
                sABDId = oDBVen.RealizarScalarSQL("SELECT ABDId FROM ABNDetalle WHERE ABNId = '" & sABNId & "'")
                FormasPago.EliminarABNDetalle(sABNId, sABDId, False)
                FormasPago.EliminarAbono(sABNId)
                If oConHist.Campos("CobrarVentas") Then
                    oTransProd.ClienteActual.ActualizarSaldo(oTransProd.Total)
                    oTransProd.ActualizarSaldo(oTransProd.Total)
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function



    Private Sub ButtonRegresarEnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarEnc.Click

        If eModo = Modo.Cancelar Then
            Me.Close()
        End If

        If Me.bHuboCambio Or bGuardarDetalle Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub
    Private Sub GuardarDetalle()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
            Dim strSQLCli As New System.Text.StringBuilder
            Dim strSQLCliDom As New System.Text.StringBuilder
            Dim strSQL As String
            For Each refTextBox In Me.DetailViewCliente.Items
                Select Case refTextBox.Name
                    Case "RazonSocial", "IdFiscal"
                        strSQLCli.Append(IIf(strSQLCli.Length = 0, refTextBox.Name & "='" & refTextBox.Value & "'", ", " & refTextBox.Name & "='" & refTextBox.Value & "'"))
                    Case Else
                        strSQLCliDom.Append(IIf(strSQLCliDom.Length = 0, refTextBox.Name & "='" & refTextBox.Value & "'", ", " & refTextBox.Name & "='" & refTextBox.Value & "'"))
                End Select
            Next
            strSQL = "Update ClienteDomicilio Set " & strSQLCliDom.ToString & ",enviado=0 Where ClienteClave='" & oCliente.ClienteClave & "' AND Tipo=1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "Update Cliente Set " & strSQLCli.ToString & ",enviado=0 Where ClienteClave='" & oCliente.ClienteClave & "'"
            oDBVen.EjecutarComandoSQL(strSQL)
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ButtonContinuarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarDet.Click
        If Not eModo = Modo.Crear Then

            Me.TabFacturaDetalle.SelectedIndex = 0
            Exit Sub

        End If

        'Agregar los datos del cliente a la consulta
        'Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
        'Dim strSQLCli As New System.Text.StringBuilder
        'Dim strSQLCliDom As New System.Text.StringBuilder
        ''Dim sClienteClave As String = ""


        'Dim strSQL As String

        Cursor.Current = Cursors.WaitCursor
        Try
            'For Each refTextBox In Me.DetailViewCliente.Items
            '    Select Case refTextBox.Name
            '        Case "RazonSocial", "IdFiscal"
            '            strSQLCli.Append(IIf(strSQLCli.Length = 0, refTextBox.Name & "='" & refTextBox.Value & "'", ", " & refTextBox.Name & "='" & refTextBox.Value & "'"))
            '        Case Else
            '            strSQLCliDom.Append(IIf(strSQLCliDom.Length = 0, refTextBox.Name & "='" & refTextBox.Value & "'", ", " & refTextBox.Name & "='" & refTextBox.Value & "'"))
            '    End Select
            'Next
            If oVendedor.EditarDatosFiscal Then
                If (IsNothing(Me.DetailViewCliente.Items("RazonSocial").Value) OrElse Me.DetailViewCliente.Items("RazonSocial").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("RazonSocial").Label))
                    Cursor.Current = Cursors.Default

                    Exit Sub
                End If
                If (IsNothing(Me.DetailViewCliente.Items("IdFiscal").Value) OrElse Me.DetailViewCliente.Items("IdFiscal").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("IdFiscal").Label))
                    Cursor.Current = Cursors.Default

                    Exit Sub
                End If
                If (IsNothing(Me.DetailViewCliente.Items("Calle").Value) OrElse Me.DetailViewCliente.Items("Calle").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("Calle").Label))
                    Cursor.Current = Cursors.Default

                    Exit Sub
                End If
                If (IsNothing(Me.DetailViewCliente.Items("Entidad").Value) OrElse Me.DetailViewCliente.Items("Entidad").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("Entidad").Label))
                    Cursor.Current = Cursors.Default

                    Exit Sub
                End If
                If (IsNothing(Me.DetailViewCliente.Items("Poblacion").Value) OrElse Me.DetailViewCliente.Items("Poblacion").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("Poblacion").Label))
                    Cursor.Current = Cursors.Default

                    Exit Sub
                End If

                If (IsNothing(Me.DetailViewCliente.Items("Pais").Value) OrElse Me.DetailViewCliente.Items("Pais").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("Pais").Label))
                    Cursor.Current = Cursors.Default
                    ' bGuardarDetalle = False
                    Exit Sub
                End If
                If (IsNothing(Me.DetailViewCliente.Items("CodigoPostal").Value) OrElse Me.DetailViewCliente.Items("CodigoPostal").Value = "") Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewCliente.Items("CodigoPostal").Label))
                    Cursor.Current = Cursors.Default

                    Exit Sub
                End If
                bGuardarDetalle = True
                bHuboCambioCliente = False

                ClienteDetalle.IdFiscal = Me.DetailViewCliente.Items("IdFiscal").Value
                ClienteDetalle.RazonSocial = Me.DetailViewCliente.Items("RazonSocial").Value
                ClienteDetalle.Calle = Me.DetailViewCliente.Items("Calle").Value
                ClienteDetalle.Exterior = Me.DetailViewCliente.Items("Numero").Value
                ClienteDetalle.Interior = Me.DetailViewCliente.Items("NumInt").Value
                ClienteDetalle.Colonia = Me.DetailViewCliente.Items("Colonia").Value
                ClienteDetalle.Entidad = Me.DetailViewCliente.Items("Entidad").Value
                ClienteDetalle.Municipio = Me.DetailViewCliente.Items("Poblacion").Value
                ClienteDetalle.Pais = Me.DetailViewCliente.Items("Pais").Value
                ClienteDetalle.CodigPostal = Me.DetailViewCliente.Items("CodigoPostal").Value
                ClienteDetalle.Referencia = Me.DetailViewCliente.Items("ReferenciaDom").Value

            End If
            'strSQL = "Update ClienteDomicilio Set " & strSQLCliDom.ToString & ",enviado=0 Where ClienteClave='" & oCliente.ClienteClave & "' AND Tipo=1"
            'oDBVen.EjecutarComandoSQL(strSQL)

            'strSQL = "Update Cliente Set " & strSQLCli.ToString & ",enviado=0 Where ClienteClave='" & oCliente.ClienteClave & "'"
            'oDBVen.EjecutarComandoSQL(strSQL)
        Catch ex As Exception

        End Try
        Cursor.Current = Cursors.Default
        '***********************************

        Me.TabFacturaDetalle.SelectedIndex = 0


    End Sub

    Private Function existe_ClienteDomicilio() As Boolean
        'TODO: Cambio DomicilioCambios
        'Return oDBVen.EjecutarCmdScalarIntSQL("Select Count(*) from ClienteDomicilioCambios Where ClienteClave='" & oCliente.ClienteClave & "'") > 0
        Return oDBVen.EjecutarCmdScalarIntSQL("Select Count(*) from ClienteDomicilio Where tipo=1 and ClienteClave='" & oCliente.ClienteClave & "'") > 0

    End Function

    Private Sub ElegirOpcion()

        If Not RevisarElementoMarcado(ListViewFactura) Then
            Crear()
            Exit Sub
        Else
            Modificar()
        End If

    End Sub

    Private Sub Crear()
        blnSeleccionManual = True
        'Me.TabControlFacturacion.SelectedIndex = 1
        blnSeleccionManual = False
    End Sub

    Private Sub Modificar()
    End Sub

    Private Sub ListViewFactura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewFactura.LostFocus
        Try
            If eModo <> Modo.Crear Then Exit Sub
            TextBoxTotal.Text = Sumatoria()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListViewFactura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewFactura.SelectedIndexChanged
        Try
            If eModo <> Modo.Crear Then Exit Sub
            TextBoxTotal.Text = Sumatoria()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListViewFactura_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewFactura.ItemCheck

        Try
            If eModo <> Modo.Crear Then Exit Sub
            bHuboCambio = True
            TextBoxTotal.Text = Sumatoria(False, e.Index, e.NewValue)

        Catch ex As Exception

        End Try


    End Sub

    Public Function Sumatoria(Optional ByVal pvVerificarTodos As Boolean = True, Optional ByVal pvIndice As Integer = 0, Optional ByVal pvNuevoValor As System.Windows.Forms.CheckState = CheckState.Checked) As Double
        Dim Subtotal As Double

        If pvVerificarTodos Then
            For i As Integer = 0 To ListViewFactura.Items.Count - 1
                If ListViewFactura.Items(i).Checked Then
                    Subtotal += CType(ListViewFactura.Items(i).SubItems(2).Text, Double)
                End If
            Next
        Else
            For i As Integer = 0 To ListViewFactura.Items.Count - 1
                If i = pvIndice Then
                    If pvNuevoValor = CheckState.Checked Then
                        Subtotal += CType(ListViewFactura.Items(i).SubItems(2).Text, Double)
                    End If
                Else
                    If ListViewFactura.Items(i).Checked Then
                        Subtotal += CType(ListViewFactura.Items(i).SubItems(2).Text, Double)
                    End If
                End If
            Next
        End If


        Return Subtotal

    End Function

    Private Sub ButtonRegresar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar1.Click
        Me.TabFacturaDetalle.SelectedIndex = 0

    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.TabFacturaDetalle.SelectedIndex = 1 Then
            Me.ButtonRegresar1_Click(Nothing, Nothing)
        Else
            Me.ButtonRegresarEnc_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dtpFechaPago_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaPago.TextChanged
        bHuboCambio = True
    End Sub

    Private Sub TextBoxTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTotal.TextChanged
        bHuboCambio = True
    End Sub
    Private Sub llenarDetailVCliente()
        bIniciando = True
        Me.DetailViewCliente.Items("RazonSocial").Value = ClienteDetalle.RazonSocial
        Me.DetailViewCliente.Items("IdFiscal").Value = ClienteDetalle.IdFiscal
        Me.DetailViewCliente.Items("Calle").Value = ClienteDetalle.Calle
        Me.DetailViewCliente.Items("Numero").Value = ClienteDetalle.Exterior
        Me.DetailViewCliente.Items("NumInt").Value = ClienteDetalle.Interior
        Me.DetailViewCliente.Items("Colonia").Value = ClienteDetalle.Colonia
        Me.DetailViewCliente.Items("Entidad").Value = ClienteDetalle.Entidad
        Me.DetailViewCliente.Items("Poblacion").Value = ClienteDetalle.Municipio
        Me.DetailViewCliente.Items("Pais").Value = ClienteDetalle.Pais
        Me.DetailViewCliente.Items("CodigoPostal").Value = ClienteDetalle.CodigPostal
        Me.DetailViewCliente.Items("ReferenciaDom").Value = ClienteDetalle.Referencia
        bIniciando = False
    End Sub

    Private Sub TabFacturaDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabFacturaDetalle.SelectedIndexChanged
        Select Case Me.TabFacturaDetalle.SelectedIndex
            Case 0
                If Not eModo = Modo.Crear Then Exit Sub


                If bHuboCambioCliente Then
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                        Me.TabFacturaDetalle.SelectedIndex = 1
                        Exit Sub
                    Else
                        bHuboCambioCliente = False
                        llenarDetailVCliente()
                    End If
                End If


                Me.dtpFechaPago.Focus()
                dtpFechaPago.Enabled = True
            Case 1
                dtpFechaPago.Enabled = False
                For i As Integer = 0 To Me.DetailViewCliente.Items.Count
                    Dim refTextBox As Resco.Controls.DetailView.ItemTextBox = Me.DetailViewCliente.Items(i)
                    If refTextBox.Name = "RazonSocial" Then
                        refTextBox.SelectionStart = 0
                        refTextBox.SetFocus()
                        Exit For
                    End If
                Next
        End Select
    End Sub

    Private Sub TextBoxOrdenCompra_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxOrdenCompra.TextChanged
        bHuboCambio = True
    End Sub

    Private Sub DetailViewCliente_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewCliente.ItemChanged
        If bIniciando = False Then
            bHuboCambioCliente = True

        End If
    End Sub
End Class
