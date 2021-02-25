Public Class FormCuentasxCobrar
    Inherits System.Windows.Forms.Form
    Private Const ConstMenuRegresar = 0
    Private ValoresConcepto As New Hashtable
    Private strEstatusModificado As String = "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "' "
    Private bHuboCambios As Boolean
    Private eModo As Modo
    Private bFin As Boolean = False
    Private blnSeleccionManual As Boolean = False
    Private strCCKeyActual As String
    Private strFechaHora As String
    Private Agrupacion As String
    Public ImporteAnt As Decimal
    Public ImporteAntAbono As Decimal
    Private oCliente As Cliente
    Dim blnCobrarVentas As Boolean = False
    Private sVisitaClave As String

    Public Enum Modo
        Crear = 1
        Modificar = 2
        Cancelar = 3
        Vacio = 4
    End Enum

    Protected tTipoOpcion As ServicesCentral.TiposOpcionesMenuDia
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlAplicacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPageCuentasxCobrar As System.Windows.Forms.TabPage
    Friend WithEvents ListViewMenu As System.Windows.Forms.ListView
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TabPageAbonos As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSaldoAplicar As System.Windows.Forms.TextBox
    Friend WithEvents LabelSaldoxAplicar As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LabelTotalxAplicar As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalAbono As System.Windows.Forms.TextBox
    Friend WithEvents C1FlexGridAbonos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TabPageCargos As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar1 As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar1 As System.Windows.Forms.Button
    Friend WithEvents C1FlexGridCargos As C1.Win.C1FlexGrid.C1FlexGrid

    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuDia
        Get
            Return tTipoOpcion
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuDia)
            tTipoOpcion = Value
        End Set
    End Property

    Private refaVista As Vista

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        ListViewMenu.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewMenu.Activation = oApp.TipoSeleccion
        TabControlAplicacion.TabPages(1).Enabled = False
        TabControlAplicacion.TabPages(2).Enabled = False
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuDia Is Nothing Then Me.MainMenuDia.Dispose()
        If Not Me.C1FlexGridAbonos Is Nothing Then Me.C1FlexGridAbonos.Dispose()
        Me.C1FlexGridAbonos = Nothing
        If Not Me.C1FlexGridCargos Is Nothing Then Me.C1FlexGridCargos.Dispose()
        Me.C1FlexGridCargos = Nothing
        If Me.ListViewMenu.Columns.Count > 0 Then
            Me.ListViewMenu.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuDia As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCuentasxCobrar))
        Me.MainMenuDia = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlAplicacion = New System.Windows.Forms.TabControl
        Me.TabPageCuentasxCobrar = New System.Windows.Forms.TabPage
        Me.ListViewMenu = New System.Windows.Forms.ListView
        Me.LabelMenu = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.TabPageAbonos = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxSaldoAplicar = New System.Windows.Forms.TextBox
        Me.LabelSaldoxAplicar = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.LabelTotalxAplicar = New System.Windows.Forms.Label
        Me.TextBoxTotalAbono = New System.Windows.Forms.TextBox
        Me.C1FlexGridAbonos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TabPageCargos = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.ButtonContinuar1 = New System.Windows.Forms.Button
        Me.ButtonRegresar1 = New System.Windows.Forms.Button
        Me.C1FlexGridCargos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Panel1.SuspendLayout()
        Me.TabControlAplicacion.SuspendLayout()
        Me.TabPageCuentasxCobrar.SuspendLayout()
        Me.TabPageAbonos.SuspendLayout()
        Me.TabPageCargos.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuDia
        '
        Me.MainMenuDia.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlAplicacion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlAplicacion
        '
        Me.TabControlAplicacion.Controls.Add(Me.TabPageCuentasxCobrar)
        Me.TabControlAplicacion.Controls.Add(Me.TabPageCargos)
        Me.TabControlAplicacion.Controls.Add(Me.TabPageAbonos)
        Me.TabControlAplicacion.Location = New System.Drawing.Point(0, 2)
        Me.TabControlAplicacion.Name = "TabControlAplicacion"
        Me.TabControlAplicacion.SelectedIndex = 0
        Me.TabControlAplicacion.Size = New System.Drawing.Size(242, 295)
        Me.TabControlAplicacion.TabIndex = 1
        '
        'TabPageCuentasxCobrar
        '
        Me.TabPageCuentasxCobrar.Controls.Add(Me.ListViewMenu)
        Me.TabPageCuentasxCobrar.Controls.Add(Me.LabelMenu)
        Me.TabPageCuentasxCobrar.Controls.Add(Me.ButtonContinuar)
        Me.TabPageCuentasxCobrar.Controls.Add(Me.ButtonRegresar)
        Me.TabPageCuentasxCobrar.Controls.Add(Me.ButtonEliminar)
        Me.TabPageCuentasxCobrar.Location = New System.Drawing.Point(4, 25)
        Me.TabPageCuentasxCobrar.Name = "TabPageCuentasxCobrar"
        Me.TabPageCuentasxCobrar.Size = New System.Drawing.Size(232, 265)
        Me.TabPageCuentasxCobrar.Text = "TabPageCuentasxCobrar"
        '
        'ListViewMenu
        '
        Me.ListViewMenu.CheckBoxes = True
        Me.ListViewMenu.FullRowSelect = True
        Me.ListViewMenu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMenu.Location = New System.Drawing.Point(4, 20)
        Me.ListViewMenu.Name = "ListViewMenu"
        Me.ListViewMenu.Size = New System.Drawing.Size(232, 209)
        Me.ListViewMenu.TabIndex = 0
        Me.ListViewMenu.View = System.Windows.Forms.View.Details
        '
        'LabelMenu
        '
        Me.LabelMenu.Location = New System.Drawing.Point(4, 4)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(230, 20)
        Me.LabelMenu.Text = "LabelMenu"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 233)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 2
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(81, 233)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(160, 233)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'TabPageAbonos
        '
        Me.TabPageAbonos.Controls.Add(Me.Label2)
        Me.TabPageAbonos.Controls.Add(Me.TextBoxSaldoAplicar)
        Me.TabPageAbonos.Controls.Add(Me.LabelSaldoxAplicar)
        Me.TabPageAbonos.Controls.Add(Me.Button1)
        Me.TabPageAbonos.Controls.Add(Me.Button2)
        Me.TabPageAbonos.Controls.Add(Me.LabelTotalxAplicar)
        Me.TabPageAbonos.Controls.Add(Me.TextBoxTotalAbono)
        Me.TabPageAbonos.Controls.Add(Me.C1FlexGridAbonos)
        Me.TabPageAbonos.Location = New System.Drawing.Point(4, 25)
        Me.TabPageAbonos.Name = "TabPageAbonos"
        Me.TabPageAbonos.Size = New System.Drawing.Size(232, 258)
        Me.TabPageAbonos.Text = "TabPageAbonos"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(2, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.Text = "LabelAbonos"
        '
        'TextBoxSaldoAplicar
        '
        Me.TextBoxSaldoAplicar.Enabled = False
        Me.TextBoxSaldoAplicar.Location = New System.Drawing.Point(149, 19)
        Me.TextBoxSaldoAplicar.Name = "TextBoxSaldoAplicar"
        Me.TextBoxSaldoAplicar.Size = New System.Drawing.Size(80, 23)
        Me.TextBoxSaldoAplicar.TabIndex = 1
        '
        'LabelSaldoxAplicar
        '
        Me.LabelSaldoxAplicar.Location = New System.Drawing.Point(63, 20)
        Me.LabelSaldoxAplicar.Name = "LabelSaldoxAplicar"
        Me.LabelSaldoxAplicar.Size = New System.Drawing.Size(80, 16)
        Me.LabelSaldoxAplicar.Text = "LabelSaldoxAplicar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(4, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "ButtonContinuar2"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(84, 233)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "ButtonRegresar2"
        '
        'LabelTotalxAplicar
        '
        Me.LabelTotalxAplicar.Location = New System.Drawing.Point(36, 208)
        Me.LabelTotalxAplicar.Name = "LabelTotalxAplicar"
        Me.LabelTotalxAplicar.Size = New System.Drawing.Size(104, 16)
        Me.LabelTotalxAplicar.Text = "LabelTotalxAplicar1"
        '
        'TextBoxTotalAbono
        '
        Me.TextBoxTotalAbono.Enabled = False
        Me.TextBoxTotalAbono.Location = New System.Drawing.Point(140, 208)
        Me.TextBoxTotalAbono.Name = "TextBoxTotalAbono"
        Me.TextBoxTotalAbono.Size = New System.Drawing.Size(92, 23)
        Me.TextBoxTotalAbono.TabIndex = 6
        '
        'C1FlexGridAbonos
        '
        Me.C1FlexGridAbonos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGridAbonos.AllowEditing = True
        Me.C1FlexGridAbonos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridAbonos.AutoResize = True
        Me.C1FlexGridAbonos.AutoSearchDelay = 1
        Me.C1FlexGridAbonos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridAbonos.Clip = ""
        Me.C1FlexGridAbonos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.C1FlexGridAbonos.Col = 0
        Me.C1FlexGridAbonos.ColSel = 0
        Me.C1FlexGridAbonos.ComboList = Nothing
        Me.C1FlexGridAbonos.EditMask = Nothing
        Me.C1FlexGridAbonos.ExtendLastCol = False
        Me.C1FlexGridAbonos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.C1FlexGridAbonos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridAbonos.LeftCol = 1
        Me.C1FlexGridAbonos.Location = New System.Drawing.Point(2, 46)
        Me.C1FlexGridAbonos.Name = "C1FlexGridAbonos"
        Me.C1FlexGridAbonos.Redraw = True
        Me.C1FlexGridAbonos.Row = 0
        Me.C1FlexGridAbonos.RowSel = 0
        Me.C1FlexGridAbonos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.C1FlexGridAbonos.ScrollTrack = True
        Me.C1FlexGridAbonos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridAbonos.ShowCursor = False
        Me.C1FlexGridAbonos.ShowSort = True
        Me.C1FlexGridAbonos.Size = New System.Drawing.Size(232, 158)
        Me.C1FlexGridAbonos.StyleInfo = resources.GetString("C1FlexGridAbonos.StyleInfo")
        Me.C1FlexGridAbonos.SupportInfo = "LAD9AHgB/wAqAIQB4QDIAIIAfgCiADEBkACsAIgAVQEgAQQBfwDhALYAMwFcAJYAbwDYAKMAWQDJAB8Br" & _
            "QC8AKIADgFcAA=="
        Me.C1FlexGridAbonos.TabIndex = 7
        Me.C1FlexGridAbonos.TopRow = 1
        '
        'TabPageCargos
        '
        Me.TabPageCargos.Controls.Add(Me.Label1)
        Me.TabPageCargos.Controls.Add(Me.TextBoxTotal)
        Me.TabPageCargos.Controls.Add(Me.LabelTotal)
        Me.TabPageCargos.Controls.Add(Me.ButtonContinuar1)
        Me.TabPageCargos.Controls.Add(Me.ButtonRegresar1)
        Me.TabPageCargos.Controls.Add(Me.C1FlexGridCargos)
        Me.TabPageCargos.Location = New System.Drawing.Point(4, 25)
        Me.TabPageCargos.Name = "TabPageCargos"
        Me.TabPageCargos.Size = New System.Drawing.Size(232, 258)
        Me.TabPageCargos.Text = "TabPageCargos"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 16)
        Me.Label1.Text = "LabelCargos"
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Enabled = False
        Me.TextBoxTotal.Location = New System.Drawing.Point(136, 208)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(95, 23)
        Me.TextBoxTotal.TabIndex = 1
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(32, 208)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(104, 16)
        Me.LabelTotal.Text = "LabelTotalxAplicar"
        '
        'ButtonContinuar1
        '
        Me.ButtonContinuar1.Location = New System.Drawing.Point(4, 233)
        Me.ButtonContinuar1.Name = "ButtonContinuar1"
        Me.ButtonContinuar1.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar1.TabIndex = 3
        Me.ButtonContinuar1.Text = "ButtonContinuar1"
        '
        'ButtonRegresar1
        '
        Me.ButtonRegresar1.Location = New System.Drawing.Point(84, 233)
        Me.ButtonRegresar1.Name = "ButtonRegresar1"
        Me.ButtonRegresar1.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar1.TabIndex = 4
        Me.ButtonRegresar1.Text = "ButtonRegresar1"
        '
        'C1FlexGridCargos
        '
        Me.C1FlexGridCargos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGridCargos.AllowEditing = True
        Me.C1FlexGridCargos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridCargos.AutoResize = True
        Me.C1FlexGridCargos.AutoSearchDelay = 1
        Me.C1FlexGridCargos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridCargos.Clip = ""
        Me.C1FlexGridCargos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.C1FlexGridCargos.Col = 0
        Me.C1FlexGridCargos.ColSel = 0
        Me.C1FlexGridCargos.ComboList = Nothing
        Me.C1FlexGridCargos.EditMask = Nothing
        Me.C1FlexGridCargos.ExtendLastCol = False
        Me.C1FlexGridCargos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.C1FlexGridCargos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridCargos.LeftCol = 1
        Me.C1FlexGridCargos.Location = New System.Drawing.Point(0, 20)
        Me.C1FlexGridCargos.Name = "C1FlexGridCargos"
        Me.C1FlexGridCargos.Redraw = True
        Me.C1FlexGridCargos.Row = 0
        Me.C1FlexGridCargos.RowSel = 0
        Me.C1FlexGridCargos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.C1FlexGridCargos.ScrollTrack = True
        Me.C1FlexGridCargos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridCargos.ShowCursor = False
        Me.C1FlexGridCargos.ShowSort = True
        Me.C1FlexGridCargos.Size = New System.Drawing.Size(237, 185)
        Me.C1FlexGridCargos.StyleInfo = resources.GetString("C1FlexGridCargos.StyleInfo")
        Me.C1FlexGridCargos.SupportInfo = "0gDOACYBawGxAKwBGQGxACgB2QA0AUcBTQAiAUYBBgGtAEEBawFRAeUA0gBRAOwAfAAQAScBFgFsAEoAv" & _
            "QCBAPMAnQA4AA=="
        Me.C1FlexGridCargos.TabIndex = 5
        Me.C1FlexGridCargos.TopRow = 1
        '
        'FormCuentasxCobrar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuDia
        Me.MinimizeBox = False
        Me.Name = "FormCuentasxCobrar"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlAplicacion.ResumeLayout(False)
        Me.TabPageCuentasxCobrar.ResumeLayout(False)
        Me.TabPageAbonos.ResumeLayout(False)
        Me.TabPageCargos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormMenuDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormCuentasxCobrar", refaVista) Then
            Exit Sub
        End If

        blnSeleccionManual = True

        blnCobrarVentas = oConHist.Campos("CobrarVentas") 'oDBVen.EjecutarCmdScalarObjSQL("Select CobrarVentas from Conhist ")

        Agrupacion = " WHERE Visita.clienteclave='" & oCliente.ClienteClave & "' group by fechahora, folio, tipo"
        refaVista.CrearListView(ListViewMenu, "ListViewCuentasxCobrar")
        refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewCuentasxCobrar", Agrupacion)
        refaVista.ColocarEtiquetasForma(Me)
        PreparaCampos()
        'LFGR
        eModo = Modo.Vacio
        Configurar_GridCargos()
        Configurar_GridAbonos()
        BuscaCargos()
        BuscaAbonos("")

        blnSeleccionManual = False
        bFin = True

        With ListViewMenu
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                Continuar()
            End If
        End With


    End Sub

    Public Sub Configurar_GridCargos()

        With C1FlexGridCargos
            .ClipSeparators = vbTab + vbLf
            .Rows.Count = 1
            .Cols.Count = 7
            .Cols.Fixed = 0
            .Cols(0).Name = ""
            .Cols(0).DataType = GetType(Boolean)
            .Cols(0).Width = 18


            .Cols(1).Name = "FechaHora"
            .Cols("FechaHora").Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Fecha")
            .Cols(1).AllowEditing = False
            .Cols(1).Width = 60

            .Cols(2).Width = 70
            .Cols(2).Name = "Folio"
            .Cols(2).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Folio")
            .Cols(2).DataMap = ValoresConcepto
            .Cols(2).AllowEditing = False

            .Cols(3).Width = 70
            .Cols(3).AllowEditing = True
            .Cols(3).DataType = GetType(Double)
            .Cols(3).Name = "Importe"
            .Cols(3).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(3).Format = oApp.FormatoDinero
            .Cols(3).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Importe")

            .Cols(4).Width = 70
            .Cols(4).AllowEditing = False
            .Cols(4).DataType = GetType(Double)
            .Cols(4).Name = "Total"
            .Cols(4).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(4).Format = oApp.FormatoDinero
            .Cols(4).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Total")

            .Cols(5).Width = 70
            .Cols(5).AllowEditing = False
            .Cols(5).DataType = GetType(Double)
            .Cols(5).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(5).Name = "Saldo"
            .Cols(5).Format = oApp.FormatoDinero
            .Cols(5).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Saldo")

            .Cols(6).Width = 10
            .Cols(6).Visible = False
            .Cols(6).AllowEditing = False
            .Cols(6).DataType = GetType(String)
            .Cols(6).Name = "TransProdID"
            .Cols(6).Caption = "TransProdID"

        End With
    End Sub

    Public Sub Configurar_GridAbonos()

        With C1FlexGridAbonos
            .ClipSeparators = vbTab + vbLf
            .Rows.Count = 1
            .Cols.Count = 8
            .Cols.Fixed = 0
            .Cols(0).Name = ""
            .Cols(0).DataType = GetType(Boolean)
            .Cols(0).Width = 18

            .Cols(1).Name = "FechaHora"
            .Cols(1).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Fecha")
            .Cols(1).AllowEditing = False
            .Cols(1).Width = 60

            .Cols(2).Width = 70
            .Cols(2).AllowEditing = True
            .Cols(2).DataType = GetType(Double)
            .Cols(2).Name = "Importe"
            .Cols(2).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Importe")
            .Cols(2).Format = oApp.FormatoDinero
            .Cols(2).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter

            .Cols(3).Width = 70
            .Cols(3).AllowEditing = False
            .Cols(3).DataType = GetType(Double)
            .Cols(3).Name = "Total"
            .Cols(3).Format = oApp.FormatoDinero
            .Cols(3).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(3).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Total")

            .Cols(4).Width = 70
            .Cols(4).AllowEditing = False
            .Cols(4).DataType = GetType(Double)
            .Cols(4).Name = "Saldo"
            .Cols(4).Format = oApp.FormatoDinero
            .Cols(4).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(4).Caption = refaVista.BuscarMensaje("GridsCargosAbonos", "Saldo")

            .Cols(5).Width = 10
            .Cols(5).Visible = False
            .Cols(5).AllowEditing = False
            .Cols(5).DataType = GetType(String)
            .Cols(5).Name = "AbonoID"
            .Cols(5).Caption = "AbonoID"

            .Cols(6).Visible = False

            .Cols(7).Visible = False
            .Cols(7).AllowEditing = False
            .Cols(7).DataType = GetType(Double)

        End With
    End Sub

    Private Sub BuscaCargos(Optional ByVal Filtro As String = "")
        Try
            Dim Query As String = ""

            Select Case eModo
                Case Modo.Crear, Modo.Vacio
                    If blnCobrarVentas Then
                        Query = "Select DISTINCT(FechaSurtido), Folio, Saldo as Importe, Total, Saldo, TransProdID from TransProd LEFT JOIN Visita on TransProd.VisitaClave= Visita.VisitaClave  Where(TransProd.Tipo = 1 And TransProd.Saldo > 0 and TransProd.TipoFase=2 and Visita.ClienteClave='" & oCliente.ClienteClave & "')"
                    Else
                        Query = "Select DISTINCT(FechaFacturacion), Folio, Saldo as Importe, Total, Saldo, TransProdID from TransProd LEFT JOIN Visita on TransProd.VisitaClave= Visita.VisitaClave  Where(TransProd.Tipo = 8 And TransProd.Saldo > 0 and TransProd.TipoFase=1 and Visita.ClienteClave='" & oCliente.ClienteClave & "')"
                    End If


                Case Modo.Cancelar
                    If blnCobrarVentas Then
                        Query = "Select FechaSurtido, Folio, SUM(abntrp.Importe) as Importe, Total, Saldo, abntrp.TransProdID from TransProd  inner join Visita on TransProd.VisitaClave=Visita.VisitaClave inner join abntrp on TransProd.TransProdID=abnTrp.TransProdID Where (TransProd.Tipo = 1)" & Filtro & _
                        " Group by FechaSurtido,Folio,Tipo,Total,Saldo,abntrp.TransProdID"
                    Else
                        Query = "Select FechaFacturacion, Folio, SUM(abntrp.Importe) as Importe, Total, Saldo, abntrp.TransProdID from TransProd  inner join Visita on TransProd.VisitaClave=Visita.VisitaClave inner join abntrp on TransProd.TransProdID=abnTrp.TransProdID Where (TransProd.Tipo = 8)" & Filtro & _
                        " Group by FechaFacturacion,Folio,Tipo,Total,Saldo,abntrp.TransProdID"
                    End If

                Case Modo.Modificar
                    If blnCobrarVentas Then
                        Query = "Select FechaSurtido, Folio, SUM(abntrp.Importe) as Importe, Total, (abntrp.importe + Saldo) as Saldo, abntrp.TransProdID from TransProd  inner join Visita on TransProd.VisitaClave=Visita.VisitaClave inner join abntrp on TransProd.TransProdID=abnTrp.TransProdID Where (TransProd.Tipo = 1)" & Filtro & _
                        " Group by FechaSurtido,Folio,Tipo,Total,Saldo,abntrp.importe,abntrp.TransProdID"
                    Else
                        Query = "Select FechaFacturacion, Folio, SUM(abntrp.Importe) as Importe, Total, (abntrp.importe + Saldo) as Saldo, abntrp.TransProdID from TransProd  inner join Visita on TransProd.VisitaClave=Visita.VisitaClave inner join abntrp on TransProd.TransProdID=abnTrp.TransProdID Where (TransProd.Tipo = 8)" & Filtro & _
                        " Group by FechaFacturacion,Folio,Tipo,Total,Saldo,abntrp.importe,abntrp.TransProdID"
                    End If

            End Select

            C1FlexGridCargos.Rows.Count = 1

            Dim Dt As DataTable = odbVen.RealizarConsultaSQL(Query, "AbnTrp")

            For Each dr As DataRow In Dt.Rows

                If eModo = Modo.Modificar Or eModo = Modo.Cancelar Then
                    Me.C1FlexGridCargos.AddItem("1" + vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString + vbTab + dr(5).ToString)
                Else
                    Me.C1FlexGridCargos.AddItem("0" + vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString + vbTab + dr(5).ToString)
                End If

            Next
            Me.Sumar_Total()
            Dt.Dispose()
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PreparaCampos()
        Dim Motivos As String = "" 'Motivos de la improductividad
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("TRPTIPO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                ValoresConcepto.Add(refDesc.Id, refDesc.Cadena)
            Next
        End If
        aValores = Nothing
        'For Each dr As DataRow In ValorReferencia.RecuperarLista("TRPTIPO").Rows
        '    ValoresConcepto.Add(dr(0), dr(1))
        'Next
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click

        OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        Close()

    End Sub

    Private Sub Continuar()
        Revisar_Accion()
        TabControlAplicacion.TabPages(1).Enabled = True
        Me.TabControlAplicacion.SelectedIndex = 1
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Public Sub Revisar_Accion()

        If Not RevisarElementoMarcado(ListViewMenu) Then
            eModo = Modo.Crear
        Else
            eModo = Modo.Modificar
            strFechaHora = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(0).Text
        End If

    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click

        Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        Me.Close()

    End Sub

    Private Sub TabControlAplicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlAplicacion.SelectedIndexChanged

        If eModo <> Modo.Cancelar Then
            Revisar_Accion()
        End If

        If RevisarGridCargos_Seleccion() Then

            'MsgBox(refaVista.BuscarMensaje("Mensajes", "E0062"), MsgBoxStyle.Information)
            'Exit Sub

        End If
        If TabControlAplicacion.SelectedIndex = 0 Then
            If Not bFin Then Exit Sub
            If eModo = Modo.Crear OrElse eModo = Modo.Vacio Then
                BuscaCargos()
                BuscaAbonos("")
            End If
            TabControlAplicacion.TabPages(1).Enabled = False
            TabControlAplicacion.TabPages(2).Enabled = False
        ElseIf TabControlAplicacion.SelectedIndex = 1 Then

            'Configurar_GridCargos()

            If eModo = Modo.Crear Then
                If Not HayCargosSeleccionados() Then
                    Limpiar_Campos()
                    BuscaCargos()
                End If
                Activar_Campos(True)

            ElseIf eModo = Modo.Modificar Then

                Activar_Campos(True)
                BuscaCargos(" And FechaHora=" & UniFechaSQL(strFechaHora))

            ElseIf eModo = Modo.Cancelar Then

                Activar_Campos(False)
                BuscaCargos(" And FechaHora=" & UniFechaSQL(strFechaHora))

            End If
            TabControlAplicacion.TabPages(2).Enabled = False
            bHuboCambios = False
        ElseIf TabControlAplicacion.SelectedIndex = 2 Then
            C1FlexGridAbonos.FinishEditing()

            'Configurar_GridAbonos()

            Me.TextBoxSaldoAplicar.Text = Me.TextBoxTotal.Text

            If eModo = Modo.Crear Then
                If Not HayCargosSeleccionados() Then
                    Limpiar_Campos()
                    BuscaAbonos("")
                End If
                Activar_Campos(True)

            ElseIf eModo = Modo.Modificar Then

                Activar_Campos(True)
                Sumar_TotalAbonos()
                BuscaAbonos("FechaHora=" & UniFechaSQL(strFechaHora))

            ElseIf eModo = Modo.Cancelar Then

                Activar_Campos(False)
                Sumar_TotalAbonos()
                BuscaAbonos(" FechaHora=" & UniFechaSQL(strFechaHora))

            End If

            bHuboCambios = False

        End If

    End Sub

    Public Sub BuscaAbonos(ByVal strFiltro As String)

        Try
            Dim Query As String = ""
            Select Case eModo
                Case Modo.Crear, Modo.Vacio
                    Query = " SELECT distinct FechaAbono AS Fecha, Saldo AS Importe, Total, Saldo, AbnID, 0 AS TransProdID, 0 AS Importebk FROM Abono LEFT JOIN Visita ON Abono.VisitaClave=Visita.VisitaClave WHERE Saldo > 0 AND Visita.ClienteClave='" & oCliente.ClienteClave & "'"
                Case Modo.Cancelar
                    Query = " Select distinct FechaAbono as Fecha, B.importe as Importe, Total, Saldo, A.AbnID, B.TransProdID, 0 as Importebk  from Abono A inner join abntrp B on A.AbnID=B.AbnID Where " & strFiltro
                Case Modo.Modificar
                    'Query = " Select FechaAbono as Fecha, Saldo+B.Importe as Importe, Total, Saldo, A.AbnID, B.TransProdID, B.Importe as ImporteBk   from Abono A inner join abntrp B on A.AbnID=B.AbnID Where " & strFiltro
                    'LFGR
                    Query = " Select distinct FechaAbono as Fecha, B.Importe as Importe, Total, Saldo, A.AbnID, B.TransProdID, B.Importe as ImporteBk   from Abono A inner join abntrp B on A.AbnID=B.AbnID Where " & strFiltro
            End Select

            C1FlexGridAbonos.Rows.Count = 1

            Dim Dt As DataTable = odbVen.RealizarConsultaSQL(Query, "Abonos")

            For Each dr As DataRow In Dt.Rows
                If eModo = Modo.Modificar Or eModo = Modo.Cancelar Then
                    C1FlexGridAbonos.AddItem("1" + vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString + vbTab + dr(5).ToString + vbTab + dr(6).ToString)
                Else
                    C1FlexGridAbonos.AddItem("0" + vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString + vbTab + dr(5).ToString + vbTab + dr(6).ToString)
                End If
            Next

            Me.Sumar_TotalAbonos()
            Dt.Dispose()

        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub Activar_Campos(ByVal Activo As Boolean, Optional ByVal Desactivar_Botones As Boolean = True)
        Me.C1FlexGridCargos.Enabled = Activo
        C1FlexGridAbonos.AllowEditing = Activo
    End Sub

    Public Sub Limpiar_Campos()
        Me.TextBoxTotal.Text = 0
    End Sub

    Public Sub Sumar_Total()

        Dim i As Integer
        Dim iTotal As Decimal = 0
        Dim iImp As Decimal = 0

        For i = 1 To C1FlexGridCargos.Rows.Count - 1

            If C1FlexGridCargos.Item(i, 0) Then
                If Not C1FlexGridCargos.Item(i, 3) Is Nothing Then
                    If IsNumeric(C1FlexGridCargos.Item(i, 3)) Then
                        iImp = C1FlexGridCargos.Item(i, 3)
                    End If
                End If

                iTotal = iTotal + iImp
            End If

        Next

        Me.TextBoxTotal.Text = Format(iTotal, "#,##0.00")

    End Sub

    Public Sub Sumar_TotalAbonos()

        Dim i As Integer
        Dim iTotal As Decimal = 0
        Dim iImp As Decimal = 0

        For i = 1 To C1FlexGridAbonos.Rows.Count - 1

            If C1FlexGridAbonos.Item(i, 0) Then

                If Not C1FlexGridAbonos.Item(i, 2) Is Nothing Then
                    If IsNumeric(C1FlexGridAbonos.Item(i, 2)) Then
                        iImp = C1FlexGridAbonos.Item(i, 2)
                    End If
                End If

                iTotal = iTotal + iImp
            End If

        Next

        TextBoxTotalAbono.Text = Format(iTotal, "#,##0.00")

    End Sub

    Private Sub ButtonContinuar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar1.Click

        If CType(TextBoxTotal.Text, Integer) = 0 Then

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0041"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridCargos.Focus()
            Exit Sub

        End If

        Sumar_Total()
        TabControlAplicacion.TabPages(2).Enabled = True
        TabControlAplicacion.SelectedIndex = 2

    End Sub

    Public Function Actualiza_CC() As Boolean

        Try
            '//Grabar la información del Deposito en Deposito

            Dim strSQL As New System.Text.StringBuilder
            Dim iAbnID As String = ""
            Dim iAbnDetID As String = ""
            Dim dblImporte As Decimal = 0
            Dim dblImporteAnt As Decimal = 0
            Dim dblSaldo As Decimal = 0
            Dim iFactID As String

            For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

                If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then

                    iAbnID = C1FlexGridAbonos.Item(cont, 5)
                    iFactID = C1FlexGridCargos.Item(C1FlexGridCargos.Row, 6)

                    dblImporte = CType(C1FlexGridAbonos.Item(C1FlexGridAbonos.Row, 2), Double)

                    dblImporteAnt = CType(C1FlexGridAbonos.Item(C1FlexGridAbonos.Row, 7), Double)

                    Dim strSQL1 As New System.Text.StringBuilder
                    Dim strSQLAbono As New System.Text.StringBuilder
                    Dim strSQLTransProd As New System.Text.StringBuilder

                    'Dim strFechaHora As String = UniFechaSQL(Now())

                    With strSQL1

                        .Append("Update abntrp set Importe=")
                        .Append(dblImporte)
                        .Append(",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where AbnID='")
                        .Append(iAbnID & "' and")
                        .Append(" FechaHora=")
                        .Append(UniFechaSQL(strFechaHora))

                        '.Append(strEstatusModificado & ")")
                        ',MFechaHora, MUsuarioID

                    End With

                    odbVen.EjecutarComandoSQL(strSQL1.ToString)

                    '//Guardar la información del detalle del importe AbonoDeposito 
                    With strSQLAbono
                        .Append("Update Abono set Saldo=Round(Saldo+")
                        .Append(dblImporteAnt - dblImporte)
                        .Append(",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "', Enviado = 0 Where AbnID='" & iAbnID & "'")
                    End With

                    With strSQLTransProd
                        .Append("Update TransProd set Saldo=Round(Saldo+")
                        .Append(dblImporteAnt - dblImporte)
                        .Append(",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "', Enviado = 0 Where TransProdID='" & iFactID & "'")
                    End With

                    odbVen.EjecutarComandoSQL(strSQLAbono.ToString)

                    odbVen.EjecutarComandoSQL(strSQLTransProd.ToString)

                End If
            Next

        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function Elimina_CC() As Boolean

        Try

            '//Grabar la información del Deposito en Deposito
            Dim strSQL As New System.Text.StringBuilder
            Dim iAbnID As String = ""
            Dim iAbnDetID As String = ""
            Dim dblImporte As Decimal = 0
            Dim TransProdID As String = ""
            Dim iTotal As Decimal
            Dim iImp As Decimal


            For i As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

                iImp = C1FlexGridAbonos.Item(i, 2)
                iAbnID = C1FlexGridAbonos.Item(i, 5)
                TransProdID = C1FlexGridAbonos.Item(i, 6)
                '//Guardar la información del detalle del importe AbonoDeposito 
                Dim strSQL3 As New System.Text.StringBuilder

                With strSQL3

                    .Append("Update Abono set Saldo=Round(Saldo+")
                    .Append(iImp)
                    .Append(",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado = 0 Where AbnID='" & iAbnID & "'")

                End With

                odbVen.EjecutarComandoSQL(strSQL3.ToString)

                iTotal = iTotal + iImp

            Next

            dblImporte = iTotal

            'Actualizar el cargo
            Dim strSQL4 As New System.Text.StringBuilder

            With strSQL4
                .Append("Update TransProd set Saldo=Round(Saldo+" & dblImporte & ",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 where TransProdID='")
                .Append(TransProdID & "'")
            End With

            odbVen.EjecutarComandoSQL(strSQL4.ToString)

            Dim strSQL1 As New System.Text.StringBuilder

            With strSQL1
                .Append("Delete from AbnTrp where FechaHora=")
                .Append(UniFechaSQL(Me.strFechaHora))
            End With

            odbVen.EjecutarComandoSQL(strSQL1.ToString)

        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function Agregar_CC() As Boolean

        Try

            '//Grabar la información del Cargos y Abonos

            Dim strSQL As New System.Text.StringBuilder

            Dim iAbnID As String = ""
            Dim iFactID As String = ""
            Dim dblImporte As Decimal = 0


            Dim strFechaHora As String = UniFechaSQL(Now())

            For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

                If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then

                    iAbnID = C1FlexGridAbonos.Item(cont, 5)
                    iFactID = C1FlexGridCargos.Item(C1FlexGridCargos.Row, 6)

                    dblImporte = CType(C1FlexGridAbonos.Item(cont, 2), Double)

                    Dim strSQL1 As New System.Text.StringBuilder
                    Dim strSQLAbono As New System.Text.StringBuilder
                    Dim strSQLTransProd As New System.Text.StringBuilder



                    With strSQL1
                        .Append("Insert into AbnTrp (ABNID,TransProdID, FechaHora,Importe,MFechaHora, MUsuarioID)")
                        .Append(" Values('")
                        .Append(iAbnID & "','")
                        .Append(iFactID & "',")
                        .Append(strFechaHora & ",")
                        .Append(dblImporte)
                        .Append(strEstatusModificado & ")")

                    End With

                    odbVen.EjecutarComandoSQL(strSQL1.ToString)

                    '//Guardar la información del detalle del importe AbonoDeposito 
                    With strSQLAbono
                        .Append("Update Abono set Saldo=Round(Saldo-")
                        .Append(dblImporte)
                        .Append(",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado = 0 Where AbnID='" & iAbnID & "'")
                    End With

                    With strSQLTransProd
                        .Append("Update TransProd set Saldo=Round(Saldo-")
                        .Append(dblImporte)
                        .Append(",2),MfechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where TransProdID='" & iFactID & "'")
                    End With

                    odbVen.EjecutarComandoSQL(strSQLAbono.ToString)

                    odbVen.EjecutarComandoSQL(strSQLTransProd.ToString)

                End If
            Next
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Private Sub ButtonRegresar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar1.Click

        If Not bHuboCambios Then
            'Me.TabControlAplicacion.SelectedIndex = 0
            'eModo = Modo.Vacio
            'TabControlAplicacion.TabPages(1).Enabled = False
            'Exit Sub
            Me.Close()
            Exit Sub
        End If


        If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then

            'Me.TabControlAplicacion.SelectedIndex = 0
            ''Refrescar el grid de los Depositos
            'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewCuentasxCobrar", Agrupacion)
            'bHuboCambios = False
            'eModo = Modo.Crear
            'BuscaCargos()
            'BuscaAbonos("")
            'TabControlAplicacion.TabPages(1).Enabled = False
            Me.Close()
            Exit Sub
        Else

        End If



    End Sub

    Private Sub HuboCambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTotal.TextChanged

        bHuboCambios = True

    End Sub

    Private Sub ListViewMenu_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewMenu.ItemCheck

        Try
            If blnSeleccionManual Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(Me.ListViewMenu, e.NewValue, e.Index)
            blnSeleccionManual = False
            If Me.ListViewMenu.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnSeleccionManual = True
                Me.ListViewMenu.Items(Me.ListViewMenu.SelectedIndices(0)).Selected = False
                eModo = Modo.Crear
                BuscaCargos()
                BuscaAbonos("")
                blnSeleccionManual = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListViewMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewMenu.SelectedIndexChanged

        Try
            If blnSeleccionManual Then Exit Sub
            If Me.ListViewMenu.SelectedIndices.Count <= 0 Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(Me.ListViewMenu, CheckState.Checked, Me.ListViewMenu.SelectedIndices(0))
            blnSeleccionManual = False
        Catch ex As Exception

        End Try

    End Sub

    Private Function ValidaCampos() As Boolean

        If RevisarGrid_Seleccion() Then

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridAbonos.Focus()
            Return False

        End If


        If CType(TextBoxTotalAbono.Text, Integer) = 0 Then

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0041"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridAbonos.Focus()
            Return False

        End If

        If TextBoxTotal.Text < TextBoxTotalAbono.Text Then

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0040"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridAbonos.Focus()
            Return False

        End If

        Return True
    End Function

    Public Function RevisarGrid_Seleccion() As Boolean

        Dim iCont As Integer = 0

        For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

            If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then

                iCont += 1

            End If

        Next

        Return iCont = 0

    End Function

    Public Function RevisarGridCargos_Seleccion() As Boolean

        Dim iCont As Integer = 0

        For cont As Integer = 1 To C1FlexGridCargos.Rows.Count - 1

            If CType(C1FlexGridCargos.Item(cont, 0), Boolean) Then
                iCont += 1
            End If

        Next

        Return iCont = 0

    End Function

    Public Function DesMarcaCargos_Seleccion(ByVal Row As Integer) As Boolean

        Dim iCont As Integer = 0

        For cont As Integer = 1 To C1FlexGridCargos.Rows.Count - 1

            If cont <> Row Then
                C1FlexGridCargos.Item(cont, 0) = False
            End If

        Next

        Return iCont = 0

    End Function
    Private Sub C1FlexGridCargos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGridCargos.Click
        Sumar_Total()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

        If RevisarElementoMarcado2(ListViewMenu) Then

            eModo = Modo.Cancelar
            strFechaHora = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(0).Text
            Me.TabControlAplicacion.SelectedIndex = 2
            TabControlAplicacion.TabPages(2).Enabled = True
            'C1FlexGridAbonos.Enabled = False
            'C1FlexGridAbonos.AllowEditing = False
        Else

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridAbonos.Focus()

        End If

    End Sub

    Private Sub C1FlexGridAbonos_AfterEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridCargos.AfterEdit
        Dim colActual As Byte
        Dim rowActual As Byte

        Dim Importe As Decimal
        Dim Saldo As Decimal

        colActual = e.Col
        rowActual = e.Row

        If e.Col = 0 Then
            Sumar_Total()
            Me.DesMarcaCargos_Seleccion(e.Row)
        End If

        C1FlexGridCargos.Refresh()

        If e.Col = 3 Then

            Importe = C1FlexGridCargos.Item(e.Row, 3)
            Saldo = C1FlexGridCargos.Item(e.Row, 5)

            If Importe > Saldo Then

                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0038"), MsgBoxStyle.Information)
                C1FlexGridCargos.Item(e.Row, 3) = ImporteAnt
                TabControlAplicacion.SelectedIndex = 1
                e.Cancel = True
                Exit Sub
            End If

            If Importe <= 0 Then

                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0041"), MsgBoxStyle.Information)
                C1FlexGridCargos.Item(e.Row, 3) = ImporteAnt
                TabControlAplicacion.SelectedIndex = 1
                e.Cancel = True
                Exit Sub
            End If

            bHuboCambios = True
            Sumar_Total()
            Me.TextBoxSaldoAplicar.Text = Me.TextBoxTotal.Text
            'TextBoxTotal.Text = Importe
        End If


    End Sub

    Private Sub C1FlexGridAbonos_BeforeEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridCargos.BeforeEdit

    End Sub

    Public Class CConceptos
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

    Private Sub C1FlexGridAbonos_StartEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridCargos.StartEdit

        If e.Col = 3 Then
            ImporteAnt = C1FlexGridCargos.Item(e.Row, 3)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Not eModo = Modo.Cancelar Then
            If Not ValidaCampos() Then
                Exit Sub
            End If
        End If

        Select Case eModo
            Case Modo.Crear

                If Agregar_CC() Then
                    Me.Close()
                End If
                'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewCuentasxCobrar", Agrupacion)

                'TabControlAplicacion.SelectedIndex = 0
                'eModo = Modo.Vacio

            Case Modo.Modificar

                If Actualiza_CC() Then
                    Me.Close()
                End If

                'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewCuentasxCobrar", Agrupacion)
                'TabControlAplicacion.SelectedIndex = 0
                'eModo = Modo.Vacio

            Case Modo.Cancelar

                If Elimina_CC() Then
                    Me.Close()
                End If
                'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewCuentasxCobrar", Agrupacion)
                'TabControlAplicacion.SelectedIndex = 0
                'eModo = Modo.Vacio

        End Select
        'BuscaCargos()
        'BuscaAbonos("")
        ''C1FlexGridAbonos.AllowEditing = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If eModo = Modo.Cancelar Then
            'TabControlAplicacion.SelectedIndex = 0
            'TabControlAplicacion.TabPages(1).Enabled = False
            'TabControlAplicacion.TabPages(2).Enabled = False
            ''C1FlexGridAbonos.AllowEditing = True
            Me.Close()
        Else
            TabControlAplicacion.SelectedIndex = 1
            TabControlAplicacion.TabPages(2).Enabled = False
            'C1FlexGridAbonos.AllowEditing = True
        End If

    End Sub

    Private Sub C1FlexGridAbonos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGridAbonos.Click
        Sumar_TotalAbonos()
    End Sub

    Private Sub C1FlexGridAbonos_AfterEdit1(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridAbonos.AfterEdit

        Dim colActual As Byte
        Dim rowActual As Byte
        Dim Importe As Decimal
        Dim Saldo As Decimal

        colActual = e.Col
        rowActual = e.Row

        If e.Col = 0 Then
            Sumar_Total()
        End If

        C1FlexGridAbonos.Refresh()

        If e.Col = 2 Then

            Importe = C1FlexGridAbonos.Item(e.Row, 2)
            Saldo = C1FlexGridAbonos.Item(e.Row, 4)

            If Importe > Saldo Then

                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0038"), MsgBoxStyle.Information)
                C1FlexGridAbonos.Item(e.Row, 2) = ImporteAntAbono
                e.Cancel = True

            End If

            If Importe <= 0 Then

                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0041"), MsgBoxStyle.Information)
                C1FlexGridAbonos.Item(e.Row, 2) = ImporteAntAbono
                e.Cancel = True

            End If

            bHuboCambios = True
            Sumar_TotalAbonos()
        End If

    End Sub

    Private Sub C1FlexGridAbonos_StartEdit1(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridAbonos.StartEdit

        If e.Col = 2 Then
            ImporteAntAbono = C1FlexGridAbonos.Item(e.Row, 2)
        End If

    End Sub

    Private Function HayCargosSeleccionados() As Boolean
        With C1FlexGridCargos
            If .Rows.Count <= 1 Then
                Return False
            Else
                Dim i As Integer
                For i = 1 To .Rows.Count - 1
                    If .Item(i, 0) Then
                        Return True
                    End If
                Next
                Return False
            End If
        End With
    End Function

    Private Function HayAbonosSeleccionados() As Boolean
        With C1FlexGridAbonos
            If .Rows.Count <= 1 Then
                Return False
            Else
                Dim i As Integer
                For i = 1 To .Rows.Count - 1
                    If .Item(i, 0) Then
                        Return True
                    End If
                Next
                Return False
            End If
        End With
    End Function

End Class
