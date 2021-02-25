Imports MobileClient.FormasPago

Public Class FormPagos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()
        blnSeleccionManual = True

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave

        With ListViewPagos
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            .CheckBoxes = True
        End With


        dtpFecha.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        blnSeleccionManual = False

        Dim cnhist As CONHist = New CONHist()
        _Moneda = cnhist.Campos("MonedaID").ToString()
        cnhist.Campos.Clear()
        cnhist.Dispose()
        'ConfigurarGrid()
    End Sub


    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.C1FlexGridPagosDet Is Nothing Then
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

        If Not Me.MenuItemBorrar Is Nothing Then Me.MenuItemBorrar.Dispose()
        If Not Me.MenuItemBorrarAbono Is Nothing Then Me.MenuItemBorrarAbono.Dispose()
        If Not Me.MenuItemCrear Is Nothing Then Me.MenuItemCrear.Dispose()
        If Not Me.MenuItemCrearAbono Is Nothing Then Me.MenuItemCrearAbono.Dispose()
        If Not Me.MenuItemModificarAbono Is Nothing Then Me.MenuItemModificarAbono.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuPagos Is Nothing Then Me.MainMenuPagos.Dispose()
        If Not Me.ContextMenuABNDetalle Is Nothing Then Me.ContextMenuABNDetalle.Dispose()
        If Not Me.ContextMenuAbono Is Nothing Then Me.ContextMenuAbono.Dispose()
        If Not Me.C1FlexGridPagosDet Is Nothing Then Me.C1FlexGridPagosDet.Dispose()
        Me.C1FlexGridPagosDet = Nothing
        If Me.ListViewPagos.Columns.Count > 0 Then
            Me.ListViewPagos.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuPagos As System.Windows.Forms.MainMenu
    Friend WithEvents ContextMenuABNDetalle As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemBorrar As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuAbono As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemBorrarAbono As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCrearAbono As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemModificarAbono As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlPagos As System.Windows.Forms.TabControl
    Friend WithEvents TabPagePagos As System.Windows.Forms.TabPage
    Friend WithEvents ButtonEliminarEnc As System.Windows.Forms.Button
    Friend WithEvents ListViewPagos As System.Windows.Forms.ListView
    Friend WithEvents LabelPrincipal As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuarEnc As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarEnc As System.Windows.Forms.Button
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents C1FlexGridPagosDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonContinuarDet As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarDet As System.Windows.Forms.Button
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents LabelFechaPago As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents MenuItemCrear As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPagos))
        Me.ContextMenuAbono = New System.Windows.Forms.ContextMenu
        Me.MenuItemBorrarAbono = New System.Windows.Forms.MenuItem
        Me.MenuItemCrearAbono = New System.Windows.Forms.MenuItem
        Me.MenuItemModificarAbono = New System.Windows.Forms.MenuItem
        Me.ContextMenuABNDetalle = New System.Windows.Forms.ContextMenu
        Me.MenuItemBorrar = New System.Windows.Forms.MenuItem
        Me.MenuItemCrear = New System.Windows.Forms.MenuItem
        Me.MainMenuPagos = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlPagos = New System.Windows.Forms.TabControl
        Me.TabPagePagos = New System.Windows.Forms.TabPage
        Me.ButtonEliminarEnc = New System.Windows.Forms.Button
        Me.ListViewPagos = New System.Windows.Forms.ListView
        Me.LabelPrincipal = New System.Windows.Forms.Label
        Me.ButtonContinuarEnc = New System.Windows.Forms.Button
        Me.ButtonRegresarEnc = New System.Windows.Forms.Button
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.C1FlexGridPagosDet = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonContinuarDet = New System.Windows.Forms.Button
        Me.ButtonRegresarDet = New System.Windows.Forms.Button
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.LabelFechaPago = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControlPagos.SuspendLayout()
        Me.TabPagePagos.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuAbono
        '
        Me.ContextMenuAbono.MenuItems.Add(Me.MenuItemBorrarAbono)
        Me.ContextMenuAbono.MenuItems.Add(Me.MenuItemCrearAbono)
        Me.ContextMenuAbono.MenuItems.Add(Me.MenuItemModificarAbono)
        '
        'MenuItemBorrarAbono
        '
        Me.MenuItemBorrarAbono.Text = "MenuItemBorrarAbono"
        '
        'MenuItemCrearAbono
        '
        Me.MenuItemCrearAbono.Text = "MenuItemCrearAbono"
        '
        'MenuItemModificarAbono
        '
        Me.MenuItemModificarAbono.Text = "MenuItemModificarAbono"
        '
        'ContextMenuABNDetalle
        '
        Me.ContextMenuABNDetalle.MenuItems.Add(Me.MenuItemBorrar)
        Me.ContextMenuABNDetalle.MenuItems.Add(Me.MenuItemCrear)
        '
        'MenuItemBorrar
        '
        Me.MenuItemBorrar.Text = "MenuItemBorrar"
        '
        'MenuItemCrear
        '
        Me.MenuItemCrear.Text = "MenuItemCrear"
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
        Me.Panel1.Controls.Add(Me.TabControlPagos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlPagos
        '
        Me.TabControlPagos.Controls.Add(Me.TabPagePagos)
        Me.TabControlPagos.Controls.Add(Me.TabPageDetalle)
        Me.TabControlPagos.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPagos.Name = "TabControlPagos"
        Me.TabControlPagos.SelectedIndex = 0
        Me.TabControlPagos.Size = New System.Drawing.Size(242, 295)
        Me.TabControlPagos.TabIndex = 1
        '
        'TabPagePagos
        '
        Me.TabPagePagos.Controls.Add(Me.ButtonEliminarEnc)
        Me.TabPagePagos.Controls.Add(Me.ListViewPagos)
        Me.TabPagePagos.Controls.Add(Me.LabelPrincipal)
        Me.TabPagePagos.Controls.Add(Me.ButtonContinuarEnc)
        Me.TabPagePagos.Controls.Add(Me.ButtonRegresarEnc)
        Me.TabPagePagos.Location = New System.Drawing.Point(4, 25)
        Me.TabPagePagos.Name = "TabPagePagos"
        Me.TabPagePagos.Size = New System.Drawing.Size(234, 266)
        Me.TabPagePagos.Text = "TabPagePagos"
        '
        'ButtonEliminarEnc
        '
        Me.ButtonEliminarEnc.Location = New System.Drawing.Point(157, 237)
        Me.ButtonEliminarEnc.Name = "ButtonEliminarEnc"
        Me.ButtonEliminarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonEliminarEnc.TabIndex = 0
        Me.ButtonEliminarEnc.Text = "ButtonEliminarEnc"
        '
        'ListViewPagos
        '
        Me.ListViewPagos.CheckBoxes = True
        Me.ListViewPagos.ContextMenu = Me.ContextMenuAbono
        Me.ListViewPagos.FullRowSelect = True
        Me.ListViewPagos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPagos.Location = New System.Drawing.Point(3, 16)
        Me.ListViewPagos.Name = "ListViewPagos"
        Me.ListViewPagos.Size = New System.Drawing.Size(228, 216)
        Me.ListViewPagos.TabIndex = 1
        Me.ListViewPagos.View = System.Windows.Forms.View.Details
        '
        'LabelPrincipal
        '
        Me.LabelPrincipal.Location = New System.Drawing.Point(4, 1)
        Me.LabelPrincipal.Name = "LabelPrincipal"
        Me.LabelPrincipal.Size = New System.Drawing.Size(230, 20)
        '
        'ButtonContinuarEnc
        '
        Me.ButtonContinuarEnc.Location = New System.Drawing.Point(3, 237)
        Me.ButtonContinuarEnc.Name = "ButtonContinuarEnc"
        Me.ButtonContinuarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarEnc.TabIndex = 3
        Me.ButtonContinuarEnc.Text = "ButtonContinuarEnc"
        '
        'ButtonRegresarEnc
        '
        Me.ButtonRegresarEnc.Location = New System.Drawing.Point(80, 237)
        Me.ButtonRegresarEnc.Name = "ButtonRegresarEnc"
        Me.ButtonRegresarEnc.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarEnc.TabIndex = 4
        Me.ButtonRegresarEnc.Text = "ButtonRegresarEnc"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.dtpFecha)
        Me.TabPageDetalle.Controls.Add(Me.C1FlexGridPagosDet)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuarDet)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresarDet)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxTotal)
        Me.TabPageDetalle.Controls.Add(Me.LabelTotal)
        Me.TabPageDetalle.Controls.Add(Me.LabelFechaPago)
        Me.TabPageDetalle.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 266)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(103, 16)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(126, 24)
        Me.dtpFecha.TabIndex = 12
        Me.dtpFecha.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'C1FlexGridPagosDet
        '
        Me.C1FlexGridPagosDet.AllowEditing = True
        Me.C1FlexGridPagosDet.AutoResize = True
        Me.C1FlexGridPagosDet.AutoSearchDelay = 1
        Me.C1FlexGridPagosDet.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridPagosDet.Clip = ""
        Me.C1FlexGridPagosDet.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.C1FlexGridPagosDet.Col = 0
        Me.C1FlexGridPagosDet.ColSel = 0
        Me.C1FlexGridPagosDet.ComboList = Nothing
        Me.C1FlexGridPagosDet.EditMask = Nothing
        Me.C1FlexGridPagosDet.ExtendLastCol = False
        Me.C1FlexGridPagosDet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.C1FlexGridPagosDet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridPagosDet.LeftCol = 1
        Me.C1FlexGridPagosDet.Location = New System.Drawing.Point(4, 41)
        Me.C1FlexGridPagosDet.Name = "C1FlexGridPagosDet"
        Me.C1FlexGridPagosDet.Redraw = True
        Me.C1FlexGridPagosDet.Row = 1
        Me.C1FlexGridPagosDet.RowSel = 1
        Me.C1FlexGridPagosDet.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.C1FlexGridPagosDet.ScrollTrack = True
        Me.C1FlexGridPagosDet.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridPagosDet.ShowCursor = False
        Me.C1FlexGridPagosDet.ShowSort = True
        Me.C1FlexGridPagosDet.Size = New System.Drawing.Size(228, 168)
        Me.C1FlexGridPagosDet.StyleInfo = resources.GetString("C1FlexGridPagosDet.StyleInfo")
        Me.C1FlexGridPagosDet.SupportInfo = "3QAoAR8BuQChAEMBkAA3ADEBZAGGADIBCAHiAK8A8gDtACkBkQD/AF4BKAFTAVwB2gBsAOQAogB1AFkAT" & _
            "QDWAIEAZADMANEAnQA="
        Me.C1FlexGridPagosDet.TabIndex = 0
        Me.C1FlexGridPagosDet.TopRow = 1
        '
        'ButtonContinuarDet
        '
        Me.ButtonContinuarDet.Location = New System.Drawing.Point(4, 237)
        Me.ButtonContinuarDet.Name = "ButtonContinuarDet"
        Me.ButtonContinuarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDet.TabIndex = 1
        Me.ButtonContinuarDet.Text = "ButtonContinuarDet"
        '
        'ButtonRegresarDet
        '
        Me.ButtonRegresarDet.Location = New System.Drawing.Point(88, 237)
        Me.ButtonRegresarDet.Name = "ButtonRegresarDet"
        Me.ButtonRegresarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarDet.TabIndex = 2
        Me.ButtonRegresarDet.Text = "ButtonRegresarDet"
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Enabled = False
        Me.TextBoxTotal.Location = New System.Drawing.Point(103, 213)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(129, 23)
        Me.TextBoxTotal.TabIndex = 3
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(4, 216)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(96, 20)
        Me.LabelTotal.Text = "LabelTotal"
        '
        'LabelFechaPago
        '
        Me.LabelFechaPago.Location = New System.Drawing.Point(4, 17)
        Me.LabelFechaPago.Name = "LabelFechaPago"
        Me.LabelFechaPago.Size = New System.Drawing.Size(96, 20)
        Me.LabelFechaPago.Text = "LabelFechaPago"
        '
        'FormPagos
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
        Me.Name = "FormPagos"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlPagos.ResumeLayout(False)
        Me.TabPagePagos.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private eEstado As Estado
    Private oCliente As Cliente
    Private sVisitaClave As String
    Private refaVista As Vista
    Private blnSeleccionManual As Boolean = False
    Private sABNIdActual As String = ""
    Private dSaldoClienteActual As Double = 0
    Private dPagosEfectivoOriginal As Double = 0
    Private Eliminados As New ArrayList
    Private blnClientePagos As Boolean
    Private dtClientePagos As DataTable
    Private bAceptarSugerencia As Boolean
    Private sFolio As String = String.Empty
    Private bHuboCambio As Boolean = False

    Private _Moneda As String
    'Private blnLimiteCreditoCheque As Boolean
#Region "Forma"
    Private Sub FormPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuPagos)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        blnSeleccionManual = True

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

        ListViewPagos.Activation = oApp.TipoSeleccion
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPagos", refaVista) Then
            Exit Sub
        End If
        refaVista.CrearListView(ListViewPagos, "ListViewPagos")
        refaVista.PoblarListView(ListViewPagos, oDBVen, "ListViewPagos", " WHERE VisitaClave = '" & sVisitaClave & "' and DiaClave='" & oDia.DiaActual & "'")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)

        'Using oCONHist As New CONHist
        'blnLimiteCreditoCheque = oCONHist.Campos("LimiteCreditoCheque")
        'End Using

        ConfigurarGrid()
        blnSeleccionManual = False
        eEstado = Estado.Navegar

        With ListViewPagos
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                ElegirOpcion()
                'Me.Close()
            End If
        End With
        bHuboCambio = False
        [Global].HabilitarMenuItem(Me.MainMenuPagos, True)
    End Sub

    Private Sub TerminarVisita()
        If RegresarDetalle() Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Grid"

    Private Sub C1FlexGridPagosDet_ValidateEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles C1FlexGridPagosDet.ValidateEdit

        If e.Col = 2 Or e.Col = 4 Then Exit Sub
        'TODO: Probar Cambio TipoPago
        If IsNumeric(C1FlexGridPagosDet.Item(e.Row, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", C1FlexGridPagosDet.Item(e.Row, "TipoPago")).ToUpper = "E" Then
            If C1FlexGridPagosDet.Cols(e.Col).Name = "Importe" Then
                If e.Row = C1FlexGridPagosDet.Rows.Count - 1 Then
                    C1FlexGridPagosDet.Rows.Add()
                    C1FlexGridPagosDet.Item(C1FlexGridPagosDet.Rows.Count - 1, "Moneda") = _Moneda
                End If
            End If
        Else
            If C1FlexGridPagosDet.Cols(e.Col).Name = "Referencia" Then
                If e.Row = C1FlexGridPagosDet.Rows.Count - 1 Then
                    C1FlexGridPagosDet.Rows.Add()
                    C1FlexGridPagosDet.Item(C1FlexGridPagosDet.Rows.Count - 1, "Moneda") = _Moneda
                End If
            End If
        End If
    End Sub
    Private Sub C1FlexGridPagosDet_CellChanged(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridPagosDet.CellChanged
        If blnSeleccionManual Then Exit Sub
        If e.Row <= 0 Then Exit Sub
        Try
            Select Case C1FlexGridPagosDet.Cols(e.Col).Name
                Case "TipoPago"
                    If C1FlexGridPagosDet.Item(e.Row, "TipoPago") = "" Then Exit Sub
                    'TODO: Probar Cambio TipoPago
                    If ValorReferencia.RecuperaGrupo("PAGO", C1FlexGridPagosDet.Item(e.Row, "TipoPago")).ToUpper = "E" Then
                        blnSeleccionManual = True
                        C1FlexGridPagosDet.Item(e.Row, "TipoBanco") = Nothing
                        C1FlexGridPagosDet.Item(e.Row, "Referencia") = Nothing
                        C1FlexGridPagosDet.Item(e.Row, "Moneda") = _Moneda
                        blnSeleccionManual = False
                        C1FlexGridPagosDet.Cols("TipoBanco").AllowEditing = False
                        C1FlexGridPagosDet.Cols("Referencia").AllowEditing = False
                        C1FlexGridPagosDet.Cols("Moneda").AllowEditing = True
                    Else
                        C1FlexGridPagosDet.Cols("TipoBanco").AllowEditing = True
                        C1FlexGridPagosDet.Cols("Referencia").AllowEditing = True
                        C1FlexGridPagosDet.Item(e.Row, "Moneda") = ""
                        C1FlexGridPagosDet.Cols("Moneda").AllowEditing = False
                    End If

                Case "Importe"
                    'If Not IsNumeric(C1FlexGridPagosDet.Item(e.Row, e.Col)) Then
                    '    C1FlexGridPagosDet.Item(e.Row, e.Col) = 0
                    'End If
                    ActualizarTotal()
                    bHuboCambio = True
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub C1FlexGridPagosDet_EnterCell(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGridPagosDet.EnterCell
        If blnSeleccionManual Then Exit Sub
        Dim iCol As Integer = C1FlexGridPagosDet.Col
        Dim iRow As Integer = C1FlexGridPagosDet.Row

        If iRow <= 0 Or iCol <= 0 Then Exit Sub

        If C1FlexGridPagosDet.Cols(iCol).Name = "Importe" Then
            If Me.C1FlexGridPagosDet.Item(iRow, iCol) Is Nothing Then
                If Me.ExistePromesaPago Then
                    Me.bAceptarSugerencia = True
                    Me.C1FlexGridPagosDet.Item(iRow, iCol) = Me.ObtenerCantidadSugerida - Me.ObtenerAcumulado(iRow)
                End If
            Else
                Me.bAceptarSugerencia = False
            End If
        End If

        If IsDBNull(C1FlexGridPagosDet.Item(iRow, "TipoPago")) Then Exit Sub

        With C1FlexGridPagosDet
            If Not .Item(iRow, "ABNId") Is Nothing And Not .Item(iRow, "ABDId") Is Nothing Then
                If DiferenciasImporteSaldoABNDetalle(.Item(iRow, "ABNId"), .Item(iRow, "ABDId")) Then
                    .Rows(iRow).AllowEditing = False
                    Exit Sub
                End If
            End If

            .Rows(iRow).AllowEditing = True
            'TODO: Probar Cambio TipoPago
            If IsNumeric(.Item(iRow, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", .Item(iRow, "TipoPago")).ToUpper = "E" Then
                .Item(iRow, "TipoBanco") = Nothing
                .Item(iRow, "Referencia") = Nothing
                .Cols("TipoBanco").AllowEditing = False
                .Cols("Referencia").AllowEditing = False
            Else
                If .Rows(iRow).AllowEditing Then
                    .Cols("TipoBanco").AllowEditing = True
                    .Cols("Referencia").AllowEditing = True
                End If
            End If
        End With
    End Sub
#End Region

#Region "ListView"
    Private Sub ListViewPagos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewPagos.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewPagos, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewPagos.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewPagos.Items(ListViewPagos.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub

    Private Sub ListViewPagos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPagos.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewPagos.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewPagos, CheckState.Checked, ListViewPagos.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub

    'private sub 
#End Region

#Region "Menu Contextual"
    Private Sub MenuItemBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemBorrar.Click
        If C1FlexGridPagosDet.RowSel <= 0 Then Exit Sub

        Dim iRow As Integer

        With C1FlexGridPagosDet
            iRow = .RowSel

            If (Not .Item(iRow, "ABNId") Is Nothing) And (Not .Item(iRow, "ABDId") Is Nothing) Then
                If DiferenciasImporteSaldoABNDetalle(.Item(iRow, "ABNId"), .Item(iRow, "ABDId")) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0051"))
                    Exit Sub
                End If

                Eliminados.Add(.Item(iRow, "ABDId"))
            End If

            .RemoveItem(iRow)
            ActualizarTotal()
        End With
    End Sub
    Private Sub ContextMenuABNDetalle_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuABNDetalle.Popup
        If eEstado = Estado.Eliminar Then
            MenuItemBorrar.Enabled = False
            MenuItemCrear.Enabled = False
        Else
            MenuItemBorrar.Enabled = True
            MenuItemCrear.Enabled = True
        End If
    End Sub
#End Region

#Region "Eventos Controles"
    Private Sub ButtonContinuarEnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarEnc.Click
        ElegirOpcion()
        'Me.Close()
    End Sub

    Private Sub ButtonRegresarEnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarEnc.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarDet.Click
        Select Case eEstado
            Case Estado.Crear
                If Not Validar() Then Exit Sub
                Dim sABNId As String = ""
                sABNId = GuardarAbono(Me.ListViewPagos.Items.Count, sFolio, sVisitaClave, oDia.DiaActual, dtpFecha.Value, Me.TextBoxTotal.Text, Me.TextBoxTotal.Text, ServicesCentral.TiposModulosMovDet.Pagos)
                If sABNId <> "" Then
                    sABNIdActual = sABNId
                    Dim i As Integer
                    Dim dPagoCheque As Double = 0
                    Dim dPagoEfectivo As Double = 0

                    For i = 1 To C1FlexGridPagosDet.Rows.Count - 1
                        Dim iTipoBanco As Integer = -1
                        If Not IsDBNull(C1FlexGridPagosDet.Item(i, "TipoBanco")) Then
                            If IsNumeric(C1FlexGridPagosDet.Item(i, "TipoBanco")) Then
                                iTipoBanco = C1FlexGridPagosDet.Item(i, "TipoBanco")
                            End If
                        End If

                        If Not RenglonVacio(i) Then
                            'If CType(C1FlexGridPagosDet.Item(i, "TipoPago"), Integer) = 2 Then
                            'If Not blnLimiteCreditoCheque Then
                            'dPagoCheque += CType(C1FlexGridPagosDet.Item(i, "Importe"), Double)
                            'End If
                            'End If

                            'TODO: Probar Cambio TipoPago
                            Dim sGrupo As String = ValorReferencia.RecuperaGrupo("PAGO", CType(C1FlexGridPagosDet.Item(i, "TipoPago"), Integer)).ToUpper
                            If sGrupo = "EB" Then
                                If oCliente.ActualizaSaldoCheque Then
                                    dPagoCheque += CType(C1FlexGridPagosDet.Item(i, "Importe"), Double)
                                End If
                            End If
                            If sGrupo = "E" Then
                                dPagoEfectivo += CType(C1FlexGridPagosDet.Item(i, "Importe"), Double)
                            End If
                            'GuardarABNDetalle(sABNId, oApp.KEYGEN(i), C1FlexGridPagosDet.Item(i, "TipoPago"), C1FlexGridPagosDet.Item(i, "Importe"), C1FlexGridPagosDet.Item(i, "Importe"), iTipoBanco, C1FlexGridPagosDet.Item(i, "Referencia"), C1FlexGridPagosDet.Item(i, "Moneda"), 0)
                        End If
                    Next
                    oCliente.ActualizarSaldo(Decimal.Negate(CType(Me.TextBoxTotal.Text, Decimal) - Decimal.Round(dPagoCheque, 2)))
                    GuardaPreliquidacion(dPagoEfectivo, False)
                End If

            Case Estado.Modificar
                If Not Validar() Then Exit Sub
                If ModificarAbono(sABNIdActual, Me.TextBoxTotal.Text, Me.TextBoxTotal.Text) Then
                    Dim i As Integer
                    Dim dPagoCheque As Double = 0
                    Dim dPagoEfectivo As Double = 0

                    'Guardar Modificados y nuevos
                    For i = 1 To C1FlexGridPagosDet.Rows.Count - 1
                        If Not RenglonVacio(i) Then
                            Dim iTipoBanco As Integer = 0
                            If Not IsDBNull(C1FlexGridPagosDet.Item(i, "TipoBanco")) Then
                                If IsNumeric(C1FlexGridPagosDet.Item(i, "TipoBanco")) Then
                                    iTipoBanco = C1FlexGridPagosDet.Item(i, "TipoBanco")
                                End If
                            End If
                            'If CType(C1FlexGridPagosDet.Item(i, "TipoPago"), Integer) = 2 Then
                            'If Not blnLimiteCreditoCheque Then
                            'dPagoCheque += CType(C1FlexGridPagosDet.Item(i, "Importe"), Double)
                            ' End If
                            'End If
                            'TODO: Probar Cambio TipoPago
                            Dim sGrupo As String = ValorReferencia.RecuperaGrupo("PAGO", CType(C1FlexGridPagosDet.Item(i, "TipoPago"), Integer)).ToUpper
                            If sGrupo = "EB" Then
                                If oCliente.ActualizaSaldoCheque Then
                                    dPagoCheque += CType(C1FlexGridPagosDet.Item(i, "Importe"), Double)
                                End If
                            End If

                            If sGrupo = "E" Then
                                dPagoEfectivo += CType(C1FlexGridPagosDet.Item(i, "Importe"), Double)
                            End If

                            If (Not C1FlexGridPagosDet.Item(i, "ABNId") Is Nothing) And (Not C1FlexGridPagosDet.Item(i, "ABDId") Is Nothing) Then
                                ModificarABNDetalle(C1FlexGridPagosDet.Item(i, "ABNId"), C1FlexGridPagosDet.Item(i, "ABDId"), CInt(C1FlexGridPagosDet.Item(i, "TipoPago")), CDec(C1FlexGridPagosDet.Item(i, "Importe")), CDec(C1FlexGridPagosDet.Item(i, "Importe")), iTipoBanco, C1FlexGridPagosDet.Item(i, "Referencia"), C1FlexGridPagosDet.Item(i, "Moneda"), 0, )
                            Else
                                GuardarABNDetalle(sABNIdActual, oApp.KEYGEN(i), CInt(C1FlexGridPagosDet.Item(i, "TipoPago")), CDec(C1FlexGridPagosDet.Item(i, "Importe")), CDec(C1FlexGridPagosDet.Item(i, "Importe")), iTipoBanco, C1FlexGridPagosDet.Item(i, "Referencia"), C1FlexGridPagosDet.Item(i, "Moneda"), 0)
                            End If
                        End If
                    Next

                    'Guardar Eliminados
                    For Each sABDId As String In Eliminados
                        EliminarABNDetalle(sABNIdActual, sABDId)
                    Next
                    GuardaPreliquidacion(dPagoEfectivo - dPagosEfectivoOriginal, False)
                    oCliente.ActualizarSaldo(dSaldoClienteActual - (CType(Me.TextBoxTotal.Text, Double) - dPagoCheque))
                End If
            Case Estado.Eliminar

                Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0", "Preliq")
                If oDT.Rows.Count > 0 Then
                    If CType(oDT.Rows(0)("MontoTotal"), Double) < dPagosEfectivoOriginal Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                End If

                EliminarAbono(sABNIdActual)
                oCliente.ActualizarSaldo(dSaldoClienteActual)
                GuardaPreliquidacion(dPagosEfectivoOriginal, True)

        End Select

        If eEstado <> Estado.Eliminar Then
            HabilitarBotones(False)
            If oVendedor.motconfiguracion.MensajeImpresion Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, sABNIdActual, ServicesCentral.TiposTransProd.Pagos, ServicesCentral.TiposTransProd.Pagos, oCliente, sVisitaClave)
                End If
            End If
            HabilitarBotones(True)
        End If

        'blnSeleccionManual = True
        'refaVista.PoblarListView(ListViewPagos, oDBVen, "ListViewPagos", " WHERE VisitaClave = '" & sVisitaClave & "'")
        'eEstado = Estado.Navegar
        'Me.TabControlPagos.SelectedIndex = 0
        'blnSeleccionManual = False
        Me.Close()
    End Sub

    Private Sub GuardaPreliquidacion(ByVal parsImporte As Double, ByVal bEliminar As Boolean)
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
            nMontoTotal += parsImporte
            If bExistePreliquidacion Then
                sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
            Else
                sPLIId = oApp.KEYGEN(1)
                sComando = "insert into PreLiquidacion (PLIId, FechaPreLiquidacion, MontoTotal, Enviado) values ('" & sPLIId & "', " & UniFechaSQL(Now) & ", " & nMontoTotal & ", 0)"
            End If
        Else
            nMontoTotal -= parsImporte
            If nMontoTotal <> 0 Then
                sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
            Else
                Dim bBorrar As Boolean
                bBorrar = (oDBVen.RealizarScalarSQL("select count(*) from PLBPLE where PLIId = '" & sPLIId & "'") = 0)
                bBorrar = bBorrar And (oDBVen.RealizarScalarSQL("select count(*) from TransProd where PLIId = '" & sPLIId & "'") = 0)
                If bBorrar Then
                    sComando = "delete Preliquidacion where PLIId = '" & sPLIId & "'"
                Else
                    sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
                End If
            End If
        End If

        oDBVen.EjecutarComandoSQL(sComando)

    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonContinuarDet.Enabled = bHabilitar
        Me.ButtonRegresarDet.Enabled = bHabilitar
    End Sub

    Private Sub ButtonRegresarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarDet.Click
        If RegresarDetalle() Then
            Me.Close()
        End If
    End Sub

    Private Sub ButtonEliminarEnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEliminarEnc.Click
        If Not RevisarElementoMarcado(ListViewPagos) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0046"), MsgBoxStyle.Information)
        Else
            Eliminar()
        End If
    End Sub
    Private Function RegresarDetalle() As Boolean
        If eEstado = Estado.Crear Or eEstado = Estado.Modificar Then
            If bHuboCambio Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                    Return False
                End If
            End If
        End If
        'blnSeleccionManual = True
        'eEstado = Estado.Navegar
        'refaVista.PoblarListView(ListViewPagos, oDBVen, "ListViewPagos", " WHERE VisitaClave = '" & sVisitaClave & "'")
        'Me.TabControlPagos.SelectedIndex = 0
        'dtpFecha.Focus()
        'blnSeleccionManual = False
        Return True
    End Function

    Private Sub TabControlPagos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlPagos.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If TabControlPagos.SelectedIndex = 1 Then
            If Not ElegirOpcion() Then
                blnSeleccionManual = True
                TabControlPagos.SelectedIndex = 0

                With ListViewPagos
                    If .Items.Count > 0 Then
                        .Items(0).Selected = True
                        .Focus()
                    Else
                        Me.ButtonContinuarDet.Focus()
                    End If
                End With


                blnSeleccionManual = False
            End If
        Else
            If Not RegresarDetalle() Then
                blnSeleccionManual = True
                TabControlPagos.SelectedIndex = 1

                dtpFecha.Focus()
                blnSeleccionManual = False
            Else
                Me.Close()
            End If
        End If
    End Sub

#End Region

#Region "Metodos"
    Private Sub ConfigurarGrid()

        With C1FlexGridPagosDet
            .Cols.Count = 7
            .Cols.Fixed = 0
            .Cols(0).Width = 0
            .Cols(0).Name = "ABNId"

            .Cols(1).Width = 0
            .Cols(1).Name = "ABDId"

            .Cols(2).Name = "TipoPago"
            .Cols("TipoPago").Width = 90
            .Cols("TipoPago").Caption = refaVista.BuscarMensaje("GridPagos", "FormaPago")

            'Tipos de Pago
            Dim aTiposPago As ArrayList
            Dim aBancos As ArrayList

            dtClientePagos = oCliente.RecuperarTipoPago
            If dtClientePagos.Rows.Count > 0 Then
                For Each dr As DataRow In dtClientePagos.Rows
                    If aTiposPago Is Nothing Then
                        aTiposPago = New ArrayList
                    End If
                    aTiposPago.Add(dr("Tipo").ToString)
                Next

                For Each dr As DataRow In dtClientePagos.Rows
                    If Not IsDBNull(dr("TipoBanco")) Then
                        If aBancos Is Nothing Then
                            aBancos = New ArrayList
                        End If
                        aBancos.Add(dr("TipoBanco").ToString)
                    End If
                Next
                blnClientePagos = True
            Else
                blnClientePagos = False
            End If

            Dim ValoresTipoPago As New Hashtable
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("PAGO", aTiposPago)
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    'TODO: Probar Cambio TipoPago
                    If refDesc.Grupo <> "" Then
                        ValoresTipoPago.Add(refDesc.Id, refDesc.Cadena)
                    End If
                Next
                .Cols("TipoPago").DataMap = ValoresTipoPago
            End If

            .Cols(3).Name = "Moneda"
            .Cols("Moneda").Width = 50
            .Cols("Moneda").Caption = refaVista.BuscarMensaje("GridPagos", "Moneda")
            Dim ValoresMoneda As New Hashtable
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select MonedaId, substring(Nombre,1,8) as Nombre, TipoCodigo from Moneda", "Moneda")
            Dim sTipoCodigo As String = ""
            For Each fila As DataRow In dt.Rows
                sTipoCodigo = ValorReferencia.BuscarEquivalente("CDGOMON", fila("TipoCodigo").ToString)
                ValoresMoneda.Add(fila("MonedaId"), fila("Nombre").ToString() & " " & sTipoCodigo)
            Next
            .Cols("Moneda").DataMap = ValoresMoneda

            .Cols(4).Name = "Importe"
            .Cols("Importe").Width = 50
            .Cols("Importe").Caption = refaVista.BuscarMensaje("GridPagos", "Importe")

            .Cols(5).Name = "TipoBanco"
            .Cols("TipoBanco").Width = 60
            Dim ValoresTipoBanco As New Hashtable
            aValores = ValorReferencia.RecuperarLista("TBANCO", aBancos)
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresTipoBanco.Add(refDesc.Id, refDesc.Cadena)
                Next
                .Cols("TipoBanco").DataMap = ValoresTipoBanco
            End If
            aValores = Nothing
            .Cols("TipoBanco").Caption = refaVista.BuscarMensaje("GridPagos", "Banco")

            .Cols(6).Name = "Referencia"
            .Cols("Referencia").Width = 80
            .Cols("Referencia").Caption = refaVista.BuscarMensaje("GridPagos", "Referencia")

        End With
    End Sub
    Private Function ElegirOpcion() As Boolean
        If ListViewPagos.SelectedIndices.Count <= 0 Then
            Crear()
        Else
            If Not Modificar() Then
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub Crear()
        sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Pagos)
        If sFolio <> "" Then
            sABNIdActual = ""
            dSaldoClienteActual = 0
            blnSeleccionManual = True
            Me.TabControlPagos.SelectedIndex = 1
            blnSeleccionManual = False
            'Me.DetailViewFechaPago.Items(0).Enabled = True
            dtpFecha.Enabled = True
            Me.C1FlexGridPagosDet.AllowEditing = True
            dtpFecha.Value = Now
            Me.TextBoxTotal.Text = ""

            Me.C1FlexGridPagosDet.Rows.Count = 1
            Me.C1FlexGridPagosDet.Rows.Add()

            eEstado = Estado.Crear
        Else
            Me.TabControlPagos.SelectedIndex = 0
        End If
    End Sub
    Private Function Modificar() As Boolean
        If DiferenciasTotalSaldoABN(False) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0050"))
            Return False
        End If

        Me.C1FlexGridPagosDet.AllowEditing = True
        Eliminados.Clear()
        MostrarDetalle()
        Dim i As Integer = C1FlexGridPagosDet.Rows.Add().Index
        C1FlexGridPagosDet.Select(i, 0)
        Me.ButtonContinuarDet.Focus()
        eEstado = Estado.Modificar
        Return True
    End Function
    Private Function DiferenciasTotalSaldoABN(ByVal blnEliminacion As Boolean) As Boolean
        Try
            Dim refListViewItemSel As ListViewItem = ListViewPagos.Items(ListViewPagos.SelectedIndices(0))

            If refListViewItemSel.SubItems(1).Text <> refListViewItemSel.SubItems(2).Text Then
                Return True
            End If

            If blnEliminacion Then
                Dim dt As DataTable
                dt = oDBVen.RealizarConsultaSQL("Select Importe,SaldoDeposito from ABNDetalle where ABNId='" & refListViewItemSel.SubItems(3).Text & "' and Importe<>SaldoDeposito ", "ABNDetalle")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        dt.Dispose()
                        Return True
                    End If
                    dt.Dispose()
                End If
            End If
        Catch ex As Exception
            Return True
        End Try
        Return False
    End Function

    Private Sub Eliminar()
        If DiferenciasTotalSaldoABN(True) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0051"))
            Exit Sub
        End If

        Me.C1FlexGridPagosDet.AllowEditing = False
        MostrarDetalle()

        eEstado = Estado.Eliminar
    End Sub

    Private Sub MostrarDetalle()
        blnSeleccionManual = True
        Me.TabControlPagos.SelectedIndex = 1
        blnSeleccionManual = False

        Dim refListViewItemSel As ListViewItem = ListViewPagos.Items(ListViewPagos.SelectedIndices(0))
        refListViewItemSel.Checked = True

        Me.C1FlexGridPagosDet.Rows.Count = 1
        'Me.DetailViewFechaPago.Items(0).Enabled = False

        dtpFecha.Enabled = False

        Dim dsAbono As DataSet
        dsAbono = RecuperarAbono(refListViewItemSel.SubItems(3).Text)

        If Not dsAbono Is Nothing Then
            sABNIdActual = dsAbono.Tables("Abono").Rows(0)("ABNId")
            dSaldoClienteActual = dsAbono.Tables("Abono").Rows(0)("Saldo")

            dtpFecha.Value = dsAbono.Tables("Abono").Rows(0)("FechaAbono")
            Me.TextBoxTotal.Text = 0 'dsAbono.Tables("Abono").Rows(0)("Total")


            For Each dr As DataRow In dsAbono.Tables("ABNDetalle").Rows
                Dim r As C1.Win.C1FlexGrid.Row = C1FlexGridPagosDet.Rows.Add
                With C1FlexGridPagosDet
                    .Item(r.Index, "ABNId") = dr("ABNId")
                    .Item(r.Index, "ABDId") = dr("ABDId")
                    .Item(r.Index, "TipoPago") = dr("TipoPago").ToString
                    .Item(r.Index, "Moneda") = dr("MonedaId")
                    .Item(r.Index, "Importe") = dr("Importe")
                    .Item(r.Index, "TipoBanco") = IIf(IsDBNull(dr("TipoBanco")), dr("TipoBanco"), dr("TipoBanco").ToString)
                    .Item(r.Index, "Referencia") = dr("Referencia")
                    ' If CType(dr("TipoPago"), Integer) = 2 Then
                    'If Not blnLimiteCreditoCheque Then
                    'dSaldoClienteActual -= Math.Round(CType(dr("Importe"), Decimal), 2)
                    'End If
                    'End If
                    'TODO: Probar Cambio TipoPago
                    Dim sGrupo As String = ValorReferencia.RecuperaGrupo("PAGO", CType(dr("TipoPago"), Integer)).ToUpper
                    If sGrupo = "EB" Then
                        If oCliente.ActualizaSaldoCheque Then
                            dSaldoClienteActual -= Math.Round(CType(dr("Importe"), Decimal), 2)
                        End If
                    End If

                    If sGrupo = "E" Then
                        If oCliente.ActualizaSaldoCheque Then
                            dPagosEfectivoOriginal += Math.Round(CType(dr("Importe"), Decimal), 2)
                        End If
                    End If

                End With
            Next
        End If
    End Sub

    Private Sub ActualizarTotal()
        Dim i As Integer
        Dim iTotal As Decimal = 0

        For i = 1 To C1FlexGridPagosDet.Rows.Count - 1
            Dim iImp As Decimal = 0
            If Not C1FlexGridPagosDet.Item(i, "Importe") Is Nothing Then
                If IsNumeric(C1FlexGridPagosDet.Item(i, "Importe")) Then
                    iImp = C1FlexGridPagosDet.Item(i, "Importe")
                End If
            End If
            iTotal = iTotal + iImp

        Next

        Me.TextBoxTotal.Text = iTotal
    End Sub
    Private Function RenglonVacio(ByVal iRow As Integer) As Boolean
        Try
            With C1FlexGridPagosDet

                If .Item(iRow, "TipoPago") Is Nothing And .Item(iRow, "Importe") Is Nothing And .Item(iRow, "TipoBanco") Is Nothing And .Item(iRow, "Referencia") Is Nothing Then
                    Return True
                End If
            End With

        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Private Function Validar() As Boolean
        Try
            Dim i As Integer

            If eEstado = Estado.Crear Then
                If Year(dtpFecha.Value) > Year(Now) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0063"))
                    Return False
                End If

                If Year(dtpFecha.Value) < Year(Now) - 1 Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0064").Replace("$0$", Year(Now) - 1))
                    Return False
                End If
            End If


            With C1FlexGridPagosDet
                For i = 1 To .Rows.Count - 1
                    If Not RenglonVacio(i) Then
                        If .Item(i, "TipoPago") Is Nothing Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("TipoPago").Caption))
                            .Row = i
                            .Col = .Cols("TipoPago").Index
                            Return False
                        End If

                        If .Item(i, "TipoPago") = "" Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("TipoPago").Caption))
                            .Row = i
                            .Col = .Cols("TipoPago").Index
                            Return False
                        End If

                        If .Item(i, "Importe") Is Nothing Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("Importe").Caption))
                            Return False
                        End If

                        If Not IsNumeric(.Item(i, "Importe")) Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0041"))
                            Return False
                        End If

                        If .Item(i, "Importe") <= 0 Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0041"))
                            Return False
                        End If

                        'TODO: Probar Cambio TipoPago
                        If IsNumeric(.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", .Item(i, "TipoPago")).ToUpper <> "E" Then
                            If .Item(i, "TipoBanco") Is Nothing OrElse IsDBNull(.Item(i, "TipoBanco")) Then
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("TipoBanco").Caption))
                                Return False
                            End If
                            If .Item(i, "Referencia") = "" Then
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("Referencia").Caption))
                                Return False
                            End If
                        Else
                            .Item(i, "TipoBanco") = Nothing
                            .Item(i, "Referencia") = Nothing
                        End If

                        If blnClientePagos Then
                            If IsNumeric(.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", .Item(i, "TipoPago")).ToUpper <> "E" Then
                                If dtClientePagos.Select("Tipo=" & .Item(i, "TipoPago") & " AND TipoBanco=" & .Item(i, "TipoBanco")).Length <= 0 Then
                                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0060"))
                                    Return False
                                End If

                                'If dtClientePagos.Select("TipoBanco=" & .Item(i, "TipoBanco") & " AND Cuenta='" & .Item(i, "Referencia") & "'").Length <= 0 Then
                                '    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0061"))
                                '    Return False
                                'End If

                            End If
                        End If
                    End If
                Next
            End With

            'Validar que este dado de alta al menos 1 detalle

            Dim iCant As Integer = 0
            For i = 1 To C1FlexGridPagosDet.Rows.Count - 1
                If Not RenglonVacio(i) Then
                    iCant += 1
                End If
            Next

            If iCant <= 0 Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0053"))
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function ExistePromesaPago() As Boolean
        Dim sQuery As String = "SELECT AP.ABPId FROM AbonoProgramado AS AP, Visita AS V WHERE AP.FechaPromesa=" & UniFechaSQL(dtpFecha.Value, , "dd/MM/yyyy") & " AND AP.VisitaClave=V.VisitaClave AND AP.DiaClave=V.DiaClave AND V.ClienteClave='" & oCliente.ClienteClave & "'"
        Return oDBVen.RealizarConsultaSQL(sQuery, "ExistePromesaPago").Rows.Count > 0
    End Function
    Private Function ObtenerCantidadSugerida() As Double
        Dim sQuery As String = "SELECT SUM(AP.Importe) FROM AbonoProgramado as AP, Visita as V WHERE AP.FechaPromesa=" & UniFechaSQL(dtpFecha.Value, , "dd/MM/yyyy") & " AND AP.VisitaClave=V.VisitaClave AND AP.DiaClave=V.DiaClave AND V.ClienteClave='" & oCliente.ClienteClave & "'"
        Dim oDr As DataRow = oDBVen.RealizarConsultaSQL(sQuery, "ObtenerCantidadSugerida").Rows(0)
        If Not IsDBNull(oDr(0)) Then
            Return oDr(0)
        End If
        Return 0
    End Function
#End Region

#Region "FUNCIONES"
    Private Function ObtenerAcumulado(ByVal iIndice As Integer) As Double
        Dim dSuma As Double = 0
        Dim oHTImportes As New Hashtable
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("SELECT A2.ABNId, A2.ABDId, A2.Importe FROM ABNDetalle as A2, Abono as A1, Visita as V WHERE A1.ABNId=A2.ABNId AND A1.FechaAbono=" & UniFechaSQL(dtpFecha.Value, , "dd/MM/yyyy") & " AND A1.VisitaClave=V.VisitaClave AND A1.DiaClave=V.DiaClave AND V.ClienteClave='" & oCliente.ClienteClave & "'", "ObtenerAcumulado")
        For Each oDr As DataRow In oDt.Rows
            oHTImportes.Add(oDr("ABNId") & "_" & oDr("ABDId"), oDr("Importe"))
            dSuma += CDbl(oDr("Importe"))
        Next
        oDt.Dispose()
        For i As Integer = 1 To iIndice - 1
            If Not Me.C1FlexGridPagosDet.Item(i, "Importe") Is Nothing Then
                If oHTImportes.Contains(Me.C1FlexGridPagosDet.Item(i, "ABNId") & "_" & Me.C1FlexGridPagosDet.Item(i, "ABDId")) Then
                    'oHTImportes(Me.C1FlexGridPagosDet.Item(i, 0) & "_" & Me.C1FlexGridPagosDet.Item(i, 1)) = 2
                    dSuma += CDbl(Me.C1FlexGridPagosDet.Item(i, "Importe")) - CDbl(oHTImportes(Me.C1FlexGridPagosDet.Item(i, "ABNId") & "_" & Me.C1FlexGridPagosDet.Item(i, "ABDId")))
                Else
                    'oHTImportes.Add(Me.C1FlexGridPagosDet.Item(i, 0) & "_" & Me.C1FlexGridPagosDet.Item(i, 1), Me.C1FlexGridPagosDet.Item(i, 3))
                    dSuma += CDbl(Me.C1FlexGridPagosDet.Item(i, "Importe"))
                End If
            End If
        Next
        Return dSuma
    End Function
#End Region

    Private Sub MenuItemCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemCrear.Click

        If C1FlexGridPagosDet.Rows.Count < 1 Then
            C1FlexGridPagosDet.Rows.Add()
            Exit Sub
        End If

        If Not RenglonVacio(C1FlexGridPagosDet.Rows.Count - 1) Then
            C1FlexGridPagosDet.Rows.Add()
            Exit Sub
        End If
    End Sub

    Private Sub MenuItemCrearAbono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemCrearAbono.Click
        Crear()
    End Sub

    Private Sub MenuItemModificarAbono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemModificarAbono.Click

        If Not RevisarElementoMarcado(ListViewPagos) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0046"), MsgBoxStyle.Information)
        Else
            Modificar()
        End If

    End Sub

    Private Sub MenuItemBorrarAbono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemBorrarAbono.Click
        ButtonEliminarEnc_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If TabControlPagos.SelectedIndex = 0 Then
            ButtonRegresarEnc_Click(Nothing, Nothing)
        Else
            ButtonRegresarDet_Click(Nothing, Nothing)
        End If
    End Sub

#Region "Enum"
    Private Enum Estado
        Navegar
        Crear
        Modificar
        Eliminar
    End Enum
#End Region

    Private Sub C1FlexGridPagosDet_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridPagosDet.AfterEdit
        Select Case C1FlexGridPagosDet.Cols(e.Col).Name

            Case "Importe"
                If Me.bAceptarSugerencia Then

                    If Me.C1FlexGridPagosDet.Item(e.Row, e.Col) < Me.ObtenerCantidadSugerida - Me.ObtenerAcumulado(e.Row) Then
                        Dim oFAPD As New FormAbonoProgramadoDetalle(sVisitaClave, FormAbonoProgramadoDetalle.eModo.Nuevo)
                        oFAPD.ShowDialog()
                        oFAPD.Dispose()
                    End If
                End If
        End Select
    End Sub

    Private Sub dtpFecha_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.TextChanged
        bHuboCambio = True
    End Sub
End Class

