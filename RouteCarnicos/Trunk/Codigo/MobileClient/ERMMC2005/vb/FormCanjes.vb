Imports C1.Win.C1FlexGrid
Imports System.Data.SqlServerCe
Imports System.Drawing

Public Class FormCanjes
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuCargas As System.Windows.Forms.MainMenu
    Friend WithEvents lblTipoUnidad As System.Windows.Forms.Label
    Friend WithEvents LabelUnidad As System.Windows.Forms.Label
    Friend WithEvents LabelFechaCaducidad As System.Windows.Forms.Label
    Friend WithEvents LabelCaducidad As System.Windows.Forms.Label
    Friend WithEvents lblCaducidad As System.Windows.Forms.Label
    Friend WithEvents LabelCaducidad2 As System.Windows.Forms.Label
    Friend WithEvents LabelVer As System.Windows.Forms.Label
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not fgCanjes Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenuCargas)
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
        If Not Me.MainMenuCargas Is Nothing Then Me.MainMenuCargas.Dispose()
        If Not Me.fgCanjes Is Nothing Then Me.fgCanjes.Dispose()
        Me.fgCanjes = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents fgCanjes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelPuntos As System.Windows.Forms.Label
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents LabelSaldo As System.Windows.Forms.Label
    Friend WithEvents LabelCliente As System.Windows.Forms.Label
    Friend WithEvents PanelSeleccion As System.Windows.Forms.Panel
    Friend WithEvents PanelConfirma As System.Windows.Forms.Panel
    Friend WithEvents lblSaldoRestante As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarConf As System.Windows.Forms.Button
    Friend WithEvents LabelSaldoRestante As System.Windows.Forms.Label
    Friend WithEvents LabelCantidad As System.Windows.Forms.Label
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFiltro As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCanjes))
        Me.MainMenuCargas = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelSeleccion = New System.Windows.Forms.Panel
        Me.LabelVer = New System.Windows.Forms.Label
        Me.LabelFechaCaducidad = New System.Windows.Forms.Label
        Me.ComboBoxFiltro = New System.Windows.Forms.ComboBox
        Me.LabelCaducidad = New System.Windows.Forms.Label
        Me.fgCanjes = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.LabelPuntos = New System.Windows.Forms.Label
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.LabelSaldo = New System.Windows.Forms.Label
        Me.LabelCliente = New System.Windows.Forms.Label
        Me.PanelConfirma = New System.Windows.Forms.Panel
        Me.lblCaducidad = New System.Windows.Forms.Label
        Me.LabelCaducidad2 = New System.Windows.Forms.Label
        Me.lblTipoUnidad = New System.Windows.Forms.Label
        Me.LabelUnidad = New System.Windows.Forms.Label
        Me.lblSaldoRestante = New System.Windows.Forms.Label
        Me.lblCantidad = New System.Windows.Forms.Label
        Me.lblProducto = New System.Windows.Forms.Label
        Me.ButtonImprimir = New System.Windows.Forms.Button
        Me.ButtonContinuarConf = New System.Windows.Forms.Button
        Me.LabelSaldoRestante = New System.Windows.Forms.Label
        Me.LabelCantidad = New System.Windows.Forms.Label
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.PanelSeleccion.SuspendLayout()
        Me.PanelConfirma.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuCargas
        '
        Me.MainMenuCargas.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'PanelSeleccion
        '
        Me.PanelSeleccion.Controls.Add(Me.LabelVer)
        Me.PanelSeleccion.Controls.Add(Me.LabelFechaCaducidad)
        Me.PanelSeleccion.Controls.Add(Me.ComboBoxFiltro)
        Me.PanelSeleccion.Controls.Add(Me.LabelCaducidad)
        Me.PanelSeleccion.Controls.Add(Me.fgCanjes)
        Me.PanelSeleccion.Controls.Add(Me.LabelPuntos)
        Me.PanelSeleccion.Controls.Add(Me.ButtonRegresar)
        Me.PanelSeleccion.Controls.Add(Me.ButtonContinuar)
        Me.PanelSeleccion.Controls.Add(Me.LabelSaldo)
        Me.PanelSeleccion.Controls.Add(Me.LabelCliente)
        Me.PanelSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSeleccion.Location = New System.Drawing.Point(0, 0)
        Me.PanelSeleccion.Name = "PanelSeleccion"
        Me.PanelSeleccion.Size = New System.Drawing.Size(242, 295)
        '
        'LabelVer
        '
        Me.LabelVer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelVer.Location = New System.Drawing.Point(7, 58)
        Me.LabelVer.Name = "LabelVer"
        Me.LabelVer.Size = New System.Drawing.Size(81, 18)
        Me.LabelVer.Text = "LabelVer"
        '
        'LabelFechaCaducidad
        '
        Me.LabelFechaCaducidad.Location = New System.Drawing.Point(172, 36)
        Me.LabelFechaCaducidad.Name = "LabelFechaCaducidad"
        Me.LabelFechaCaducidad.Size = New System.Drawing.Size(68, 18)
        Me.LabelFechaCaducidad.Text = "Label1"
        '
        'ComboBoxFiltro
        '
        Me.ComboBoxFiltro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.ComboBoxFiltro.Location = New System.Drawing.Point(90, 56)
        Me.ComboBoxFiltro.Name = "ComboBoxFiltro"
        Me.ComboBoxFiltro.Size = New System.Drawing.Size(145, 20)
        Me.ComboBoxFiltro.TabIndex = 0
        '
        'LabelCaducidad
        '
        Me.LabelCaducidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelCaducidad.Location = New System.Drawing.Point(104, 36)
        Me.LabelCaducidad.Name = "LabelCaducidad"
        Me.LabelCaducidad.Size = New System.Drawing.Size(70, 18)
        Me.LabelCaducidad.Text = "LabelCaducidad"
        '
        'fgCanjes
        '
        Me.fgCanjes.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgCanjes.AllowEditing = False
        Me.fgCanjes.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgCanjes.AutoResize = True
        Me.fgCanjes.AutoSearchDelay = 1
        Me.fgCanjes.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fgCanjes.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgCanjes.Clip = ""
        Me.fgCanjes.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgCanjes.Col = 1
        Me.fgCanjes.ColSel = 1
        Me.fgCanjes.ComboList = Nothing
        Me.fgCanjes.EditMask = Nothing
        Me.fgCanjes.ExtendLastCol = False
        Me.fgCanjes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.fgCanjes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgCanjes.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.fgCanjes.LeftCol = 1
        Me.fgCanjes.Location = New System.Drawing.Point(4, 83)
        Me.fgCanjes.Name = "fgCanjes"
        Me.fgCanjes.Redraw = True
        Me.fgCanjes.Row = 1
        Me.fgCanjes.RowSel = 1
        Me.fgCanjes.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgCanjes.ScrollTrack = True
        Me.fgCanjes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgCanjes.ShowCursor = False
        Me.fgCanjes.ShowSort = True
        Me.fgCanjes.Size = New System.Drawing.Size(231, 176)
        Me.fgCanjes.StyleInfo = resources.GetString("fgCanjes.StyleInfo")
        Me.fgCanjes.SupportInfo = "ngDBAAYBRAEPAb8AkAC4ADwBDwHhAMMAaQCNAFoAEgGGAG8AVwDGAOEARwA1AD4A0QBoAE8A"
        Me.fgCanjes.TabIndex = 1
        Me.fgCanjes.TopRow = 1
        '
        'LabelPuntos
        '
        Me.LabelPuntos.Location = New System.Drawing.Point(44, 36)
        Me.LabelPuntos.Name = "LabelPuntos"
        Me.LabelPuntos.Size = New System.Drawing.Size(58, 19)
        Me.LabelPuntos.Text = "0"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 263)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 263)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 4
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'LabelSaldo
        '
        Me.LabelSaldo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelSaldo.Location = New System.Drawing.Point(6, 36)
        Me.LabelSaldo.Name = "LabelSaldo"
        Me.LabelSaldo.Size = New System.Drawing.Size(39, 19)
        Me.LabelSaldo.Text = "LabelSaldo"
        '
        'LabelCliente
        '
        Me.LabelCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelCliente.ForeColor = System.Drawing.Color.Navy
        Me.LabelCliente.Location = New System.Drawing.Point(6, 17)
        Me.LabelCliente.Name = "LabelCliente"
        Me.LabelCliente.Size = New System.Drawing.Size(232, 18)
        Me.LabelCliente.Text = "LabelCliente"
        '
        'PanelConfirma
        '
        Me.PanelConfirma.Controls.Add(Me.PanelSeleccion)
        Me.PanelConfirma.Controls.Add(Me.lblCaducidad)
        Me.PanelConfirma.Controls.Add(Me.LabelCaducidad2)
        Me.PanelConfirma.Controls.Add(Me.lblTipoUnidad)
        Me.PanelConfirma.Controls.Add(Me.LabelUnidad)
        Me.PanelConfirma.Controls.Add(Me.lblSaldoRestante)
        Me.PanelConfirma.Controls.Add(Me.lblCantidad)
        Me.PanelConfirma.Controls.Add(Me.lblProducto)
        Me.PanelConfirma.Controls.Add(Me.ButtonImprimir)
        Me.PanelConfirma.Controls.Add(Me.ButtonContinuarConf)
        Me.PanelConfirma.Controls.Add(Me.LabelSaldoRestante)
        Me.PanelConfirma.Controls.Add(Me.LabelCantidad)
        Me.PanelConfirma.Controls.Add(Me.LabelProducto)
        Me.PanelConfirma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelConfirma.Location = New System.Drawing.Point(0, 0)
        Me.PanelConfirma.Name = "PanelConfirma"
        Me.PanelConfirma.Size = New System.Drawing.Size(242, 295)
        '
        'lblCaducidad
        '
        Me.lblCaducidad.Location = New System.Drawing.Point(88, 147)
        Me.lblCaducidad.Name = "lblCaducidad"
        Me.lblCaducidad.Size = New System.Drawing.Size(146, 20)
        '
        'LabelCaducidad2
        '
        Me.LabelCaducidad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelCaducidad2.Location = New System.Drawing.Point(10, 146)
        Me.LabelCaducidad2.Name = "LabelCaducidad2"
        Me.LabelCaducidad2.Size = New System.Drawing.Size(78, 20)
        Me.LabelCaducidad2.Text = "LabelCaducidad2"
        '
        'lblTipoUnidad
        '
        Me.lblTipoUnidad.Location = New System.Drawing.Point(88, 72)
        Me.lblTipoUnidad.Name = "lblTipoUnidad"
        Me.lblTipoUnidad.Size = New System.Drawing.Size(146, 20)
        '
        'LabelUnidad
        '
        Me.LabelUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelUnidad.Location = New System.Drawing.Point(10, 72)
        Me.LabelUnidad.Name = "LabelUnidad"
        Me.LabelUnidad.Size = New System.Drawing.Size(78, 20)
        Me.LabelUnidad.Text = "LabelUnidad"
        '
        'lblSaldoRestante
        '
        Me.lblSaldoRestante.Location = New System.Drawing.Point(88, 122)
        Me.lblSaldoRestante.Name = "lblSaldoRestante"
        Me.lblSaldoRestante.Size = New System.Drawing.Size(146, 20)
        '
        'lblCantidad
        '
        Me.lblCantidad.Location = New System.Drawing.Point(88, 97)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(146, 20)
        '
        'lblProducto
        '
        Me.lblProducto.Location = New System.Drawing.Point(88, 36)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(146, 30)
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(88, 232)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonImprimir.TabIndex = 3
        Me.ButtonImprimir.Text = "ButtonImprimir"
        '
        'ButtonContinuarConf
        '
        Me.ButtonContinuarConf.Location = New System.Drawing.Point(8, 232)
        Me.ButtonContinuarConf.Name = "ButtonContinuarConf"
        Me.ButtonContinuarConf.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarConf.TabIndex = 4
        Me.ButtonContinuarConf.Text = "ButtonContinuarConf"
        '
        'LabelSaldoRestante
        '
        Me.LabelSaldoRestante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelSaldoRestante.Location = New System.Drawing.Point(10, 121)
        Me.LabelSaldoRestante.Name = "LabelSaldoRestante"
        Me.LabelSaldoRestante.Size = New System.Drawing.Size(78, 20)
        Me.LabelSaldoRestante.Text = "LabelSaldoRestante"
        '
        'LabelCantidad
        '
        Me.LabelCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelCantidad.Location = New System.Drawing.Point(10, 97)
        Me.LabelCantidad.Name = "LabelCantidad"
        Me.LabelCantidad.Size = New System.Drawing.Size(78, 20)
        Me.LabelCantidad.Text = "LabelCantidad"
        '
        'LabelProducto
        '
        Me.LabelProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelProducto.Location = New System.Drawing.Point(10, 37)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(78, 25)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'FormCanjes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelConfirma)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenuCargas
        Me.Name = "FormCanjes"
        Me.Text = "Amesol Route"
        Me.PanelSeleccion.ResumeLayout(False)
        Me.PanelConfirma.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private refaVista As Vista
    Private oCliente As Cliente
    Private blnCargando, bHuboCambios As Boolean
    Private tTipoCanje As BFCANJE
    Dim dCaducidad As Date
    Private LongitudTicket As Integer = 48
#Region "Propiedades"
    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region
    Private Sub FormCanjes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuCargas)
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

        Me.Visible = False
        blnCargando = False
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormCanjes", refaVista) Then
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        If Not oCliente.ConfiguracionPuntos Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "E0449"))
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Me.Visible = True
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)

        Me.LabelCaducidad2.Text = Me.LabelCaducidad.Text
        Me.LabelCliente.Text = oCliente.RazonSocial

        Me.LabelPuntos.Text = FormasCanjes.PuntosCliente(oCliente.ClienteClave, dCaducidad)
        Me.LabelFechaCaducidad.Text = Format(dCaducidad, oApp.FormatoFecha)

        ConfiguraGrid()
        Application.DoEvents()
        LlenarCombo()
        [Global].HabilitarMenuItem(MainMenuCargas, True)
        ComboBoxFiltro.Focus()
        bHuboCambios = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub LlenarCombo()
        Dim aValor As ArrayList
        With ComboBoxFiltro
            blnCargando = True
            aValor = ValorReferencia.RecuperarLista("BFCANJE")
            If Not IsNothing(aValor) AndAlso aValor.Count > 0 Then
                .DataSource = aValor
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                blnCargando = False
                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    .SelectedIndex = 0
                    ComboBoxFiltro_SelectedIndexChanged(Nothing, Nothing)
                Else
                    .SelectedIndex = 1
                End If
            End If
        End With
    End Sub
    Private Sub ConfiguraGrid()
        With fgCanjes
            .Redraw = False
            Dim f As Font = .Font
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 8
            .Cols(0).AllowMerging = True
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBoxGral", "CAPProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBoxGral", "PRONombre")
            .Cols(1).AllowMerging = True
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBoxGral", "XUnidad")
            .Cols(2).AllowMerging = True
            .Cols(3).Caption = refaVista.BuscarMensaje("MsgBoxGral", "CAPCantidad")
            .Cols(3).AllowMerging = True
            .Cols(4).Visible = False
            .Cols(5).Visible = False
            .Cols(6).Visible = False
            .Cols(7).Visible = False
            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.Simple
            .AutoResize = True
            .Redraw = True
        End With
    End Sub
    Private Sub CargarInfoGrid()
        fgCanjes.Redraw = False

        Dim dt As New DataTable
        Dim sConsultaSQL As New System.Text.StringBuilder

        fgCanjes.Rows.Count = 1
        If ComboBoxFiltro.SelectedValue = BFCANJE.canjes Then
            tTipoCanje = BFCANJE.canjes
            fgCanjes.Cols.Count = 8
            sConsultaSQL.Append("Select Canje.CANClave,CadPro.FechaInicial,CadPro.Rango1,Canje.Nombre,Producto.ProductoClave,CadPro.PRUTipoUnidad,Producto.Nombre as ProductoNombre,CadPro.Cantidad,CadRango.Cantidad as CantRango from Canje ")
            sConsultaSQL.Append("inner join CANDetalleVig on Canje.CANClave = CANDetalleVig.CANClave ")
            sConsultaSQL.Append("inner join CADRango on CANDetalleVig.CANClave = CADRango.CANClave and CANDetalleVig.FechaInicial = CADRango.FechaInicial ")
            sConsultaSQL.Append("inner join CADPro on CADRango.CANClave = CadPro.CANClave and CADRango.FechaInicial = CadPro.FechaInicial and CADRango.Rango1 = CadPro.Rango1 ")
            sConsultaSQL.Append("inner join Producto on Producto.ProductoClave = CadPro.ProductoClave ")
            sConsultaSQL.Append("where((CANDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CANDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") ")
            sConsultaSQL.Append("and (CADRango.Rango1<=" & Me.LabelPuntos.Text & ") AND canje.baja = 0 ) order by Canje.CANClave")
        Else
            fgCanjes.Cols.Count = 9
            fgCanjes.Cols(6).Visible = False
            fgCanjes.Cols(8).Visible = False
            tTipoCanje = BFCANJE.CanjesPendientes
            sConsultaSQL.Append("Select Canje.CANClave,CadPro.FechaInicial,CadPro.Rango1,")
            sConsultaSQL.Append("Canje.Nombre,Producto.ProductoClave,CadPro.PRUTipoUnidad,Producto.Nombre as ProductoNombre,CadPro.Cantidad,CadRango.Cantidad as CantRango,Clicap.ClAId ")
            sConsultaSQL.Append("from Canje inner join CANDetalleVig on Canje.CANClave = CANDetalleVig.CANClave ")
            sConsultaSQL.Append("inner join CADRango on CANDetalleVig.CANClave = CADRango.CANClave and CANDetalleVig.FechaInicial = CADRango.FechaInicial ")
            sConsultaSQL.Append("inner join CADPro on CADRango.CANClave = CadPro.CANClave and CADRango.FechaInicial = CadPro.FechaInicial and CADRango.Rango1 = CadPro.Rango1 ")
            sConsultaSQL.Append("inner join Producto on Producto.ProductoClave = CadPro.ProductoClave ")
            sConsultaSQL.Append("inner join clicap on clicap.CANClave = CadPro.CANClave and clicap.FechaInicial = CadPro.FechaInicial and clicap.Rango1 = CadPro.Rango1 and ")
            sConsultaSQL.Append("clicap.ProductoClave = CadPro.ProductoClave and clicap.PRUTipoUnidad = CadPro.PRUTipoUnidad Where clicap.FechaCanje is null and clicap.ClienteClave='" & oCliente.ClienteClave & "' AND canje.baja = 0 order by Canje.CANClave")

        End If

        dt = odbVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Canjes")

        Dim sCANClave As String = ""
        For Each dr As DataRow In dt.Rows
            If sCANClave <> dr("CANClave") Then
                sCANClave = dr("CANClave")
                Dim r As C1.Win.C1FlexGrid.Row = fgCanjes.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgCanjes
                    .Item(r.Index, 0) = dr("CANClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 2) = dr("CantRango")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgCanjes.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgCanjes
                .Item(r2.Index, 0) = dr("ProductoClave")
                .Item(r2.Index, 1) = dr("ProductoNombre")
                .Item(r2.Index, 2) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("PRUTipoUnidad"))
                .Item(r2.Index, 3) = dr("Cantidad")
                .Item(r2.Index, 4) = dr("CANClave")
                .Item(r2.Index, 5) = dr("FechaInicial")
                .Item(r2.Index, 6) = dr("Rango1")
                .Item(r2.Index, 7) = dr("PRUTipoUnidad")
                If tTipoCanje = BFCANJE.CanjesPendientes Then
                    .Item(r2.Index, 8) = dr("CLAId")
                End If
            End With
        Next
        fgCanjes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        fgCanjes.Redraw = True
    End Sub
    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        If bHuboCambios Then
            If MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If fgCanjes.Row > 0 Then
            Cursor.Current = Cursors.WaitCursor
            Dim r As C1.Win.C1FlexGrid.Row
            r = fgCanjes.Rows(fgCanjes.Row)
            If r.Node.Level = 1 Then
                If tTipoCanje = BFCANJE.canjes Then
                    GuardarCanje(fgCanjes.Item(r.Index, 4), fgCanjes.Item(r.Index, 5), fgCanjes.Item(r.Index, 6), fgCanjes.Item(r.Index, 0), fgCanjes.Item(r.Index, 7), fgCanjes.Item(r.Index, 3))
                Else
                    GuardarCanje(fgCanjes.Item(r.Index, 4), fgCanjes.Item(r.Index, 5), fgCanjes.Item(r.Index, 6), fgCanjes.Item(r.Index, 0), fgCanjes.Item(r.Index, 7), fgCanjes.Item(r.Index, 3), fgCanjes.Item(r.Index, 8))
                End If
            Else
                Cursor.Current = Cursors.Default
                MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "E0042"))
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Function GuardarCanje(ByVal parsCANClave As String, ByVal pardFechaInicial As Date, ByVal pariRango1 As Integer, ByVal parsProductoClave As String, ByVal pariPRUTipoUnidad As Integer, ByVal pardCantidad As Decimal, Optional ByVal parsCLAId As String = "") As Boolean
        Try
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Transaccion = oDBVen.oConexion.BeginTransaction()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Try
            Dim dCantidadDisponible As Decimal = 0
            Dim sMsgError As String = ""
            If tTipoCanje = BFCANJE.canjes Then
                If Inventario.ValidarExistenciaDisponibleDec(parsProductoClave, pariPRUTipoUnidad, pardCantidad, dCantidadDisponible, sMsgError) Then
                    If FormasCanjes.InsertarCliCap(parsCANClave, pardFechaInicial, pariRango1, parsProductoClave, pariPRUTipoUnidad, oCliente.ClienteClave, True) Then
                        If Inventario.ActualizarInventarioDec(parsProductoClave, pariPRUTipoUnidad, pardCantidad, ServicesCentral.TiposTransProd.CargaPorCanje, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , ) Then
                            FormasCanjes.RestarSaldo(parsCANClave, pardFechaInicial, pariRango1, oCliente.ClienteClave)
                        End If
                    End If
                Else
                    If FormasCanjes.InsertarCliCap(parsCANClave, pardFechaInicial, pariRango1, parsProductoClave, pariPRUTipoUnidad, oCliente.ClienteClave, False) Then
                        If FormasCanjes.RestarSaldo(parsCANClave, pardFechaInicial, pariRango1, oCliente.ClienteClave) Then
                            MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "E0029"))
                        Else
                            Transaccion.Rollback()
                            Transaccion.Dispose()
                            Transaccion = Nothing
                            Return False
                        End If
                    Else
                        Transaccion.Rollback()
                        Transaccion.Dispose()
                        Transaccion = Nothing
                        Return False
                    End If
                End If
            Else
                Dim blnExistencia As Boolean = False
                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    blnExistencia = Inventario.ValidarExistencia(parsProductoClave, pariPRUTipoUnidad, pardCantidad, dCantidadDisponible, sMsgError)
                Else
                    blnExistencia = Inventario.ValidarExistenciaDisponibleDec(parsProductoClave, pariPRUTipoUnidad, pardCantidad, dCantidadDisponible, sMsgError)
                End If
                If blnExistencia Then
                    If FormasCanjes.ActualizaFechaCanje(parsCANClave, pardFechaInicial, pariRango1, parsProductoClave, pariPRUTipoUnidad, oCliente.ClienteClave, parsCLAId) Then
                        Inventario.ActualizarInventarioDec(parsProductoClave, pariPRUTipoUnidad, pardCantidad, ServicesCentral.TiposTransProd.CargaPorCanje, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , )
                    End If
                Else
                    MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "E0029"))
                    Transaccion.Rollback()
                    Transaccion.Dispose()
                    Transaccion = Nothing
                    Return False
                End If
            End If
            Transaccion.Commit()
            Transaccion.Dispose()
            Transaccion = Nothing
            Try
                Me.lblProducto.Text = oDBVen.EjecutarCmdScalarStrSQL("Select Nombre from Producto Where ProductoClave = '" & parsProductoClave & "'")
                Me.lblTipoUnidad.Text = ValorReferencia.BuscarEquivalente("UNIDADV", pariPRUTipoUnidad)
                Me.lblCantidad.Text = pardCantidad
                Me.lblSaldoRestante.Text = FormasCanjes.PuntosCliente(oCliente.ClienteClave, dCaducidad)
                Me.lblCaducidad.Text = Format(dCaducidad, oApp.FormatoFecha)
                Me.PanelSeleccion.Visible = False
                Me.PanelConfirma.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return True
        Catch ex As Exception
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub ButtonContinuarConf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarConf.Click
        Me.Close()
    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        Dim Sw As System.IO.StreamWriter
        CreaArchivo(Sw, "\Impresion.txt")
        CreaEncabezado(Sw, LongitudTicket)
        CreaTitulos(Sw)
        CreaDetalle(Sw)
        Sw.Flush()
        Sw.Close()
        ImprimirArchivo(7, True, "\Impresion.txt", oConHist.Campos("MostrarLogo"), oVendedor.TipoModImp, False)
    End Sub

    Private Sub CreaTitulos(ByRef sw As System.IO.StreamWriter)
        Dim cad As String
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBoxGral", "XSALDOCLIENTE"), LongitudTicket))
        ImprimeLineaPunteada(sw, LongitudTicket)
        sw.WriteLine(refaVista.BuscarMensaje("MsgBoxGral", "XSECANJEO"))
        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBoxGral", "XCantidad"), 10, Alineacion.Izquierda, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBoxGral", "XProducto"), 18, Alineacion.Izquierda, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBoxGral", "XUnidad"), 10, Alineacion.Izquierda, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBoxGral", "XPuntos"), 10, Alineacion.Derecha, False)
        sw.WriteLine(cad)

        ImprimeLineaPunteada(sw, LongitudTicket)
    End Sub
    Private Sub CreaDetalle(ByRef sw As System.IO.StreamWriter)
        Try
            Dim Cad As String
            Dim sConsultaSQL As New System.Text.StringBuilder

            sConsultaSQL.Append("select CadPro.Cantidad,Producto.Nombre,CadPro.PRUTipoUnidad, CADRango.Cantidad as Puntos from clicap inner join CadPro on clicap.CANClave = CadPro.CANClave and clicap.FechaInicial = CadPro.FechaInicial And clicap.Rango1 = CadPro.Rango1 and CliCap.ProductoClave = Cadpro.ProductoClave and CliCap.PRUTipoUnidad = Cadpro.PRUTipoUnidad inner join Producto on Producto.ProductoCLave = Clicap.ProductoCLave inner join CADRango on CadPro.CANClave = CADRango.CANClave and CadPro.FechaInicial = CADRango.FechaInicial and CadPro.Rango1 = CADRAngo.Rango1 ")
            sConsultaSQL.Append(" WHERE CliCap.ClienteClave='" & oCliente.ClienteClave & "'")

            Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Canjes")
            For Each Dr As DataRow In dt.Rows
                Cad = CompletaHasta(Dr("Cantidad"), 10, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("Nombre"), 18, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("PRUTipoUnidad")), 10, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("Puntos"), 10, Alineacion.Derecha, False)
                sw.WriteLine(Cad)
            Next
            dt.Dispose()

            ImprimeLineaPunteada(sw, LongitudTicket)
            Cad = CompletaHasta(refaVista.BuscarMensaje("MsgBoxGral", "SALDORESTANTE") & ":", 35, Alineacion.Derecha, False)
            Cad &= CompletaHasta(FormasCanjes.PuntosCliente(oCliente.ClienteClave, dCaducidad), 13, Alineacion.Derecha, True)
            Cad &= CompletaHasta(Me.LabelCaducidad.Text & ":", 35, Alineacion.Derecha, False)
            Cad &= CompletaHasta(Format(dCaducidad, oApp.FormatoFecha), 13, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteCobranza")
        End Try
    End Sub

    Private Enum BFCANJE
        CanjesPendientes = 1
        canjes = 2
    End Enum

    Private Sub ComboBoxFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxFiltro.SelectedIndexChanged
        If blnCargando Then Exit Sub
        bHuboCambios = True
        CargarInfoGrid()
    End Sub

    Private Sub fgCanjes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgCanjes.KeyUp
        Select Case e.KeyCode
            Case Keys.Space
                If fgCanjes.Rows(fgCanjes.Row).Node.Collapsed Then
                    fgCanjes.Rows(fgCanjes.Row).Node.Collapsed = False
                Else
                    fgCanjes.Rows(fgCanjes.Row).Node.Collapsed = True
                End If
        End Select
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
End Class
