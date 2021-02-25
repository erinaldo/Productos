Imports System.Data.SqlServerCe
Imports System.IO
'Imports Serial
Imports FieldSoftware.PrinterCE_NetCF

Public Class FormReportes
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal oDay As MobileClient.Dia, ByVal grupo As String, Optional ByVal sVisitaClave As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oGrupo = grupo
        oDia = oDay
        Me.TreeViewArbolClientes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        Me.ListViewClientes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ListViewClientes.Activation = [Global].oApp.TipoSeleccion
        Me.ListViewClientes.CheckBoxes = True
        VisitaClave = sVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuPagos Is Nothing Then Me.MainMenuPagos.Dispose()
        If Me.ListViewClientes.Columns.Count > 0 Then
            Me.ListViewClientes.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenuPagos As System.Windows.Forms.MainMenu
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControlReportes As System.Windows.Forms.TabControl
    Friend WithEvents TabPageFiltros As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxComparaFecha As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxFecha As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButtonGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBoxReporte As System.Windows.Forms.ComboBox
    Friend WithEvents LabelReporte As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuarFiltros As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarFiltros As System.Windows.Forms.Button
    Friend WithEvents TabPageClientes As System.Windows.Forms.TabPage
    Friend WithEvents ListViewClientes As System.Windows.Forms.ListView
    Friend WithEvents TreeViewArbolClientes As System.Windows.Forms.TreeView
    Friend WithEvents ButtonContinuarCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarCliente As System.Windows.Forms.Button
    Friend WithEvents LabelGruposCliente As System.Windows.Forms.Label
    Friend WithEvents TabPageReporte As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxReporte As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVerReporte As System.Windows.Forms.TextBox
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarReporte As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarReporte As System.Windows.Forms.Button
    Friend WithEvents LabelReporte2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxTodosLosClientes As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxTotalizar As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxTotalesPP As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuPagos = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TabControlReportes = New System.Windows.Forms.TabControl
        Me.TabPageFiltros = New System.Windows.Forms.TabPage
        Me.CheckBoxTotalesPP = New System.Windows.Forms.CheckBox
        Me.CheckBoxTotalizar = New System.Windows.Forms.CheckBox
        Me.CheckBoxTodosLosClientes = New System.Windows.Forms.CheckBox
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.ComboBoxComparaFecha = New System.Windows.Forms.ComboBox
        Me.CheckBoxFecha = New System.Windows.Forms.CheckBox
        Me.RadioButtonGeneral = New System.Windows.Forms.RadioButton
        Me.RadioButtonDetallado = New System.Windows.Forms.RadioButton
        Me.ComboBoxReporte = New System.Windows.Forms.ComboBox
        Me.LabelReporte = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonContinuarFiltros = New System.Windows.Forms.Button
        Me.ButtonRegresarFiltros = New System.Windows.Forms.Button
        Me.TabPageClientes = New System.Windows.Forms.TabPage
        Me.ListViewClientes = New System.Windows.Forms.ListView
        Me.TreeViewArbolClientes = New System.Windows.Forms.TreeView
        Me.ButtonContinuarCliente = New System.Windows.Forms.Button
        Me.ButtonRegresarCliente = New System.Windows.Forms.Button
        Me.LabelGruposCliente = New System.Windows.Forms.Label
        Me.TabPageReporte = New System.Windows.Forms.TabPage
        Me.TextBoxReporte = New System.Windows.Forms.TextBox
        Me.TextBoxVerReporte = New System.Windows.Forms.TextBox
        Me.ButtonImprimir = New System.Windows.Forms.Button
        Me.ButtonContinuarReporte = New System.Windows.Forms.Button
        Me.ButtonRegresarReporte = New System.Windows.Forms.Button
        Me.LabelReporte2 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.TabControlReportes.SuspendLayout()
        Me.TabPageFiltros.SuspendLayout()
        Me.TabPageClientes.SuspendLayout()
        Me.TabPageReporte.SuspendLayout()
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControlReportes)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlReportes
        '
        Me.TabControlReportes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlReportes.Controls.Add(Me.TabPageFiltros)
        Me.TabControlReportes.Controls.Add(Me.TabPageClientes)
        Me.TabControlReportes.Controls.Add(Me.TabPageReporte)
        Me.TabControlReportes.Dock = System.Windows.Forms.DockStyle.None
        Me.TabControlReportes.Location = New System.Drawing.Point(0, 0)
        Me.TabControlReportes.Name = "TabControlReportes"
        Me.TabControlReportes.SelectedIndex = 0
        Me.TabControlReportes.Size = New System.Drawing.Size(242, 295)
        Me.TabControlReportes.TabIndex = 1
        '
        'TabPageFiltros
        '
        Me.TabPageFiltros.Controls.Add(Me.CheckBoxTotalesPP)
        Me.TabPageFiltros.Controls.Add(Me.CheckBoxTotalizar)
        Me.TabPageFiltros.Controls.Add(Me.CheckBoxTodosLosClientes)
        Me.TabPageFiltros.Controls.Add(Me.dtpFechaFin)
        Me.TabPageFiltros.Controls.Add(Me.dtpFechaIni)
        Me.TabPageFiltros.Controls.Add(Me.ComboBoxComparaFecha)
        Me.TabPageFiltros.Controls.Add(Me.CheckBoxFecha)
        Me.TabPageFiltros.Controls.Add(Me.RadioButtonGeneral)
        Me.TabPageFiltros.Controls.Add(Me.RadioButtonDetallado)
        Me.TabPageFiltros.Controls.Add(Me.ComboBoxReporte)
        Me.TabPageFiltros.Controls.Add(Me.LabelReporte)
        Me.TabPageFiltros.Controls.Add(Me.Panel1)
        Me.TabPageFiltros.Controls.Add(Me.ButtonContinuarFiltros)
        Me.TabPageFiltros.Controls.Add(Me.ButtonRegresarFiltros)
        Me.TabPageFiltros.Location = New System.Drawing.Point(0, 0)
        Me.TabPageFiltros.Name = "TabPageFiltros"
        Me.TabPageFiltros.Size = New System.Drawing.Size(242, 272)
        Me.TabPageFiltros.Text = "TabPageFiltros"
        '
        'CheckBoxTotalesPP
        '
        Me.CheckBoxTotalesPP.Checked = True
        Me.CheckBoxTotalesPP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTotalesPP.Location = New System.Drawing.Point(4, 205)
        Me.CheckBoxTotalesPP.Name = "CheckBoxTotalesPP"
        Me.CheckBoxTotalesPP.Size = New System.Drawing.Size(224, 20)
        Me.CheckBoxTotalesPP.TabIndex = 17
        Me.CheckBoxTotalesPP.Text = "CheckBoxTotalesPP"
        '
        'CheckBoxTotalizar
        '
        Me.CheckBoxTotalizar.Location = New System.Drawing.Point(4, 179)
        Me.CheckBoxTotalizar.Name = "CheckBoxTotalizar"
        Me.CheckBoxTotalizar.Size = New System.Drawing.Size(153, 20)
        Me.CheckBoxTotalizar.TabIndex = 14
        Me.CheckBoxTotalizar.Text = "CheckBoxTotalizar"
        '
        'CheckBoxTodosLosClientes
        '
        Me.CheckBoxTodosLosClientes.Location = New System.Drawing.Point(3, 153)
        Me.CheckBoxTodosLosClientes.Name = "CheckBoxTodosLosClientes"
        Me.CheckBoxTodosLosClientes.Size = New System.Drawing.Size(199, 20)
        Me.CheckBoxTodosLosClientes.TabIndex = 11
        Me.CheckBoxTodosLosClientes.Text = "CheckBoxTodosLosClientes"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(144, 124)
        Me.dtpFechaFin.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaFin.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 22)
        Me.dtpFechaFin.TabIndex = 8
        Me.dtpFechaFin.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIni.Enabled = False
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(145, 95)
        Me.dtpFechaIni.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaIni.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(88, 22)
        Me.dtpFechaIni.TabIndex = 7
        Me.dtpFechaIni.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'ComboBoxComparaFecha
        '
        Me.ComboBoxComparaFecha.Enabled = False
        Me.ComboBoxComparaFecha.Location = New System.Drawing.Point(60, 96)
        Me.ComboBoxComparaFecha.Name = "ComboBoxComparaFecha"
        Me.ComboBoxComparaFecha.Size = New System.Drawing.Size(84, 22)
        Me.ComboBoxComparaFecha.TabIndex = 6
        '
        'CheckBoxFecha
        '
        Me.CheckBoxFecha.Enabled = False
        Me.CheckBoxFecha.Location = New System.Drawing.Point(3, 96)
        Me.CheckBoxFecha.Name = "CheckBoxFecha"
        Me.CheckBoxFecha.Size = New System.Drawing.Size(62, 20)
        Me.CheckBoxFecha.TabIndex = 5
        Me.CheckBoxFecha.Text = "CheckBoxFecha"
        '
        'RadioButtonGeneral
        '
        Me.RadioButtonGeneral.Enabled = False
        Me.RadioButtonGeneral.Location = New System.Drawing.Point(128, 48)
        Me.RadioButtonGeneral.Name = "RadioButtonGeneral"
        Me.RadioButtonGeneral.Size = New System.Drawing.Size(89, 20)
        Me.RadioButtonGeneral.TabIndex = 4
        Me.RadioButtonGeneral.TabStop = False
        Me.RadioButtonGeneral.Text = "RadioButtonGeneral"
        '
        'RadioButtonDetallado
        '
        Me.RadioButtonDetallado.Checked = True
        Me.RadioButtonDetallado.Enabled = False
        Me.RadioButtonDetallado.Location = New System.Drawing.Point(23, 48)
        Me.RadioButtonDetallado.Name = "RadioButtonDetallado"
        Me.RadioButtonDetallado.Size = New System.Drawing.Size(89, 20)
        Me.RadioButtonDetallado.TabIndex = 3
        Me.RadioButtonDetallado.Text = "RadioButtonDetallado"
        '
        'ComboBoxReporte
        '
        Me.ComboBoxReporte.Location = New System.Drawing.Point(78, 15)
        Me.ComboBoxReporte.Name = "ComboBoxReporte"
        Me.ComboBoxReporte.Size = New System.Drawing.Size(150, 22)
        Me.ComboBoxReporte.TabIndex = 2
        '
        'LabelReporte
        '
        Me.LabelReporte.Location = New System.Drawing.Point(3, 16)
        Me.LabelReporte.Name = "LabelReporte"
        Me.LabelReporte.Size = New System.Drawing.Size(100, 20)
        Me.LabelReporte.Text = "LabelReporte"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Location = New System.Drawing.Point(1, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 2)
        '
        'ButtonContinuarFiltros
        '
        Me.ButtonContinuarFiltros.Location = New System.Drawing.Point(4, 239)
        Me.ButtonContinuarFiltros.Name = "ButtonContinuarFiltros"
        Me.ButtonContinuarFiltros.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarFiltros.TabIndex = 9
        Me.ButtonContinuarFiltros.Text = "ButtonContinuarFiltros"
        '
        'ButtonRegresarFiltros
        '
        Me.ButtonRegresarFiltros.Location = New System.Drawing.Point(83, 239)
        Me.ButtonRegresarFiltros.Name = "ButtonRegresarFiltros"
        Me.ButtonRegresarFiltros.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarFiltros.TabIndex = 10
        Me.ButtonRegresarFiltros.Text = "ButtonRegresarFiltros"
        '
        'TabPageClientes
        '
        Me.TabPageClientes.Controls.Add(Me.ListViewClientes)
        Me.TabPageClientes.Controls.Add(Me.TreeViewArbolClientes)
        Me.TabPageClientes.Controls.Add(Me.ButtonContinuarCliente)
        Me.TabPageClientes.Controls.Add(Me.ButtonRegresarCliente)
        Me.TabPageClientes.Controls.Add(Me.LabelGruposCliente)
        Me.TabPageClientes.Location = New System.Drawing.Point(0, 0)
        Me.TabPageClientes.Name = "TabPageClientes"
        Me.TabPageClientes.Size = New System.Drawing.Size(234, 269)
        Me.TabPageClientes.Text = "TabPageClientes"
        '
        'ListViewClientes
        '
        Me.ListViewClientes.FullRowSelect = True
        Me.ListViewClientes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewClientes.Location = New System.Drawing.Point(3, 116)
        Me.ListViewClientes.Name = "ListViewClientes"
        Me.ListViewClientes.Size = New System.Drawing.Size(229, 124)
        Me.ListViewClientes.TabIndex = 0
        Me.ListViewClientes.View = System.Windows.Forms.View.Details
        '
        'TreeViewArbolClientes
        '
        Me.TreeViewArbolClientes.Location = New System.Drawing.Point(3, 19)
        Me.TreeViewArbolClientes.Name = "TreeViewArbolClientes"
        Me.TreeViewArbolClientes.Size = New System.Drawing.Size(229, 92)
        Me.TreeViewArbolClientes.TabIndex = 1
        '
        'ButtonContinuarCliente
        '
        Me.ButtonContinuarCliente.Location = New System.Drawing.Point(4, 241)
        Me.ButtonContinuarCliente.Name = "ButtonContinuarCliente"
        Me.ButtonContinuarCliente.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarCliente.TabIndex = 2
        Me.ButtonContinuarCliente.Text = "ButtonContinuarCliente"
        '
        'ButtonRegresarCliente
        '
        Me.ButtonRegresarCliente.Location = New System.Drawing.Point(83, 241)
        Me.ButtonRegresarCliente.Name = "ButtonRegresarCliente"
        Me.ButtonRegresarCliente.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarCliente.TabIndex = 3
        Me.ButtonRegresarCliente.Text = "ButtonRegresarCliente"
        '
        'LabelGruposCliente
        '
        Me.LabelGruposCliente.Location = New System.Drawing.Point(3, 2)
        Me.LabelGruposCliente.Name = "LabelGruposCliente"
        Me.LabelGruposCliente.Size = New System.Drawing.Size(226, 20)
        Me.LabelGruposCliente.Text = "LabelGruposCliente"
        '
        'TabPageReporte
        '
        Me.TabPageReporte.Controls.Add(Me.TextBoxReporte)
        Me.TabPageReporte.Controls.Add(Me.TextBoxVerReporte)
        Me.TabPageReporte.Controls.Add(Me.ButtonImprimir)
        Me.TabPageReporte.Controls.Add(Me.ButtonContinuarReporte)
        Me.TabPageReporte.Controls.Add(Me.ButtonRegresarReporte)
        Me.TabPageReporte.Controls.Add(Me.LabelReporte2)
        Me.TabPageReporte.Location = New System.Drawing.Point(0, 0)
        Me.TabPageReporte.Name = "TabPageReporte"
        Me.TabPageReporte.Size = New System.Drawing.Size(234, 269)
        Me.TabPageReporte.Text = "TabPageReporte"
        '
        'TextBoxReporte
        '
        Me.TextBoxReporte.Enabled = False
        Me.TextBoxReporte.Location = New System.Drawing.Point(84, 5)
        Me.TextBoxReporte.Name = "TextBoxReporte"
        Me.TextBoxReporte.Size = New System.Drawing.Size(145, 21)
        Me.TextBoxReporte.TabIndex = 0
        '
        'TextBoxVerReporte
        '
        Me.TextBoxVerReporte.Location = New System.Drawing.Point(3, 32)
        Me.TextBoxVerReporte.Multiline = True
        Me.TextBoxVerReporte.Name = "TextBoxVerReporte"
        Me.TextBoxVerReporte.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxVerReporte.Size = New System.Drawing.Size(228, 207)
        Me.TextBoxVerReporte.TabIndex = 1
        Me.TextBoxVerReporte.WordWrap = False
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(157, 241)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonImprimir.TabIndex = 2
        Me.ButtonImprimir.Text = "ButtonImprimir"
        '
        'ButtonContinuarReporte
        '
        Me.ButtonContinuarReporte.Location = New System.Drawing.Point(3, 241)
        Me.ButtonContinuarReporte.Name = "ButtonContinuarReporte"
        Me.ButtonContinuarReporte.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarReporte.TabIndex = 3
        Me.ButtonContinuarReporte.Text = "ButtonContinuarReporte"
        '
        'ButtonRegresarReporte
        '
        Me.ButtonRegresarReporte.Location = New System.Drawing.Point(80, 241)
        Me.ButtonRegresarReporte.Name = "ButtonRegresarReporte"
        Me.ButtonRegresarReporte.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarReporte.TabIndex = 4
        Me.ButtonRegresarReporte.Text = "ButtonRegresarReporte"
        '
        'LabelReporte2
        '
        Me.LabelReporte2.Location = New System.Drawing.Point(2, 7)
        Me.LabelReporte2.Name = "LabelReporte2"
        Me.LabelReporte2.Size = New System.Drawing.Size(72, 20)
        Me.LabelReporte2.Text = "LabelReporte2"
        '
        'FormReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuPagos
        Me.MinimizeBox = False
        Me.Name = "FormReportes"
        Me.Panel2.ResumeLayout(False)
        Me.TabControlReportes.ResumeLayout(False)
        Me.TabPageFiltros.ResumeLayout(False)
        Me.TabPageClientes.ResumeLayout(False)
        Me.TabPageReporte.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private refaVista As Vista
    Private blnSeleccionManual As Boolean = False
    Private blnDetGral As Boolean = False
    Private blnFechaFolio As Boolean = False
    Private tTipoReporte As TiposReportes = TiposReportes.NoDefinido
    'Private ArchivoCabecera As String = "\Cabecera.txt"
    Private sArchivoDetalle As String = "\Reporte.txt"
    Private Logo As String = "\Logo amesol chico.jpg"
    Private LongTot As Integer = 48
    Private oDia As MobileClient.Dia
    Private bFin As Boolean = False
    Dim blnCobrarVentas As Boolean = False
    Private bSeleccionando As Boolean = False
    Private oGrupo As String
    Private VisitaClave As String = ""
#End Region


#Region "Forma"
    Private Sub FormKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        'ListViewProductos.Activation = oApp.TipoSeleccion

        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormReportes", refaVista) Then
            Exit Sub
        End If

        dtpFechaIni.Value = Today
        dtpFechaFin.Value = Today

        blnCobrarVentas = oConHist.Campos("CobrarVentas") 'oDBVen.EjecutarCmdScalarObjSQL("Select CobrarVentas from Conhist ")

        refaVista.CrearListView(ListViewClientes, "ListViewClientes")
        Me.PoblarArbolClientes()

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        LlenaCombos()
        bFin = True

        Me.CheckBoxTodosLosClientes.Enabled = False
        Me.CheckBoxTotalizar.Enabled = False
        Me.CheckBoxTotalesPP.Enabled = False
        Me.ComboBoxReporte.Focus()

    End Sub
#End Region

#Region "Metodos"
    Public Sub ImprimirListaPrecios(ByVal parslistaPrecioClave As String, ByVal parslistaPrecioNombre As String)
        If Not Vista.Buscar("FormReportes", refaVista) Then
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        'While MsgBox(refaVista.BuscarMensaje("Mensajes2", "P0800"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes
        Dim Sw As StreamWriter
        tTipoReporte = TiposReportes.ListaPrecio

        CreaArchivo(Sw, sArchivoDetalle)

        CreaEncabezado(Sw, LongTot)
        ReporteListaPrecio(Sw, parslistaPrecioClave, parslistaPrecioNombre)



        Sw.Flush()
        Sw.Close()

        ImprimirArchivo(7, True, sArchivoDetalle, oConHist.Campos("MostrarLogo"), oVendedor.TipoModImp, False)

        'End While
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub
    Public Sub ImprimirTerminarVisita(ByVal parsVisitaClave As String, ByVal parsDiaClave As String, ByVal parsCliente As MobileClient.Cliente)
        If Not Vista.Buscar("FormReportes", refaVista) Then
            Exit Sub
        End If
        Dim grupos As New ArrayList
        grupos.Add("TerminarVisita")
        Dim aReportes As ArrayList = ValorReferencia.RecuperaVARVGrupoConSinGrupo("REPORTEM", grupos)

        If Not IsNothing(aReportes) Then
            For i As Integer = 1 To aReportes.Count - 1

                If CType(aReportes(i), ValorReferencia.Descripcion).Id = TiposReportes.MovimientosDureanteLaVisita Then
                    Do While MsgBox(refaVista.BuscarMensaje("Mensajes2", "P0800").Replace("$0$", " " + CType(aReportes(i), ValorReferencia.Descripcion).Cadena), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()
                        Dim Sw As StreamWriter
                        CreaArchivo(Sw, sArchivoDetalle)
                        ReporteResumenMovimientosDuranteLaVisita(Sw, parsVisitaClave, parsDiaClave, parsCliente)
                        Sw.Flush()
                        Sw.Close()
                        ImprimirArchivo(7, True, sArchivoDetalle, oConHist.Campos("MostrarLogo"), oVendedor.TipoModImp, False)
                        Cursor.Current = Cursors.Default
                        Application.DoEvents()
                    Loop
                ElseIf CType(aReportes(i), ValorReferencia.Descripcion).Id = TiposReportes.NotaVta Then
                    tTipoReporte = TiposReportes.NotaVta
                    If HayRegistrosGrupoTerminarVisita(parsVisitaClave, parsDiaClave, parsCliente.ClienteClave) = 1 Then

                        Do While MsgBox(refaVista.BuscarMensaje("Mensajes2", "P0800").Replace("$0$", " " + CType(aReportes(i), ValorReferencia.Descripcion).Cadena), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes
                            Cursor.Current = Cursors.WaitCursor
                            Application.DoEvents()
                            Dim Sw As StreamWriter
                            CreaArchivo(Sw, sArchivoDetalle)
                            CreaEncabezado(Sw, LongTot)
                            ReporteNotaDeVenta(Sw, parsVisitaClave, parsDiaClave, parsCliente)
                            Sw.Flush()
                            Sw.Close()
                            ImprimirArchivo(7, True, sArchivoDetalle, oConHist.Campos("MostrarLogo"), oVendedor.TipoModImp, False)

                            Cursor.Current = Cursors.Default
                            Application.DoEvents()
                        Loop
                    End If
                End If

            Next
        End If

    End Sub

    Private Sub LlenaCombos()
        blnSeleccionManual = True
        'ComboBoxComparaFecha
        With ComboBoxComparaFecha
            .DataSource = ValorReferencia.RecuperarLista("BFNUMERI")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With
        Dim grupos As New ArrayList
        grupos.Add(oGrupo)
        With ComboBoxReporte
            .DataSource = ValorReferencia.RecuperaVARVGrupoConSinGrupo("REPORTEM", grupos)
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With
        blnSeleccionManual = False
    End Sub
    Private Function PoblarArbolClientes() As Boolean
        Try
            Me.TreeViewArbolClientes.Nodes.Clear()
            ' Dataset con el esquema de productos
            Dim DataTableEsquema As DataTable
            Me.TreeViewArbolClientes.Nodes.Clear()
            'DataTableEsquema = oDBVen.RealizarConsultaSQL("SELECT EsquemaIDPadre, EsquemaID, Nombre FROM Esquema WHERE Tipo=" & ServicesCentral.TiposEsquemas.Clientes, "Esquema")
            Dim sConsulta As String
            sConsulta = "SELECT EsquemaIDPadre, EsquemaID, Nombre "
            sConsulta &= "FROM Esquema "
            sConsulta &= "WHERE Tipo = " & ServicesCentral.TiposEsquemas.Clientes & " and EsquemaId in (Select distinct EsquemaId from ClienteEsquema) "
            sConsulta &= "UNION "
            sConsulta &= "SELECT EsquemaIDPadre, EsquemaID, Nombre "
            sConsulta &= "FROM Esquema "
            sConsulta &= "WHERE Tipo = " & ServicesCentral.TiposEsquemas.Clientes & " and EsquemaIdPadre is null "
            sConsulta &= "order by EsquemaIdPadre, EsquemaId "
            DataTableEsquema = oDBVen.RealizarConsultaSQL(sConsulta, "Esquema")
            If DataTableEsquema.Rows.Count = 0 Then
                DataTableEsquema.Dispose()
                Exit Try
            End If
            ' DataViews para la búsqueda de los grupos
            Dim DataViewEsquema As New DataView(DataTableEsquema, "", "EsquemaIDPadre,EsquemaID", DataViewRowState.CurrentRows)
            Dim DataViewHijos As New DataView(DataTableEsquema, "", "EsquemaIDPadre", DataViewRowState.CurrentRows)
            ' Proceso de población de cada uno de los grupos válidos para este tipo de movimiento
            Dim refDataRow As DataRow
            Dim sNombreNodo As String
            Dim iRowIndex As Integer
            Dim oBusqueda(1) As Object
            Dim TreeNodeNuevo As TreeNode
            Dim oNodoRaiz As TreeNode = Nothing
            For Each refDataRow In DataTableEsquema.Rows
                oBusqueda(0) = refDataRow("EsquemaIDPadre")
                oBusqueda(1) = refDataRow("EsquemaID")
                If (IsDBNull(oBusqueda(0))) Then
                    iRowIndex = DataViewEsquema.Find(oBusqueda)
                    If iRowIndex <> -1 Then
                        sNombreNodo = DataViewEsquema(iRowIndex).Item("Nombre")
                        TreeNodeNuevo = Me.TreeViewArbolClientes.Nodes.Add(sNombreNodo)
                        TreeNodeNuevo.Tag = oBusqueda(1)
                        If oNodoRaiz Is Nothing Then
                            oNodoRaiz = TreeNodeNuevo
                        End If
                        PoblarNodoArbol(TreeNodeNuevo.Nodes, oBusqueda(1), DataViewHijos)
                    End If
                End If
            Next
            If Not oNodoRaiz Is Nothing Then
                oNodoRaiz.Expand()
                'Me.TreeViewArbolClientes.SelectedNode = oNodoRaiz
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarArbolProductos")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarArbolProductos")
        End Try
    End Function
    '<Hacer General la funcion>
    Private Function PoblarNodoArbol(ByRef refparTreeView As TreeNodeCollection, ByVal parsNodoPadre As String, ByRef refparDataViewEsquema As DataView) As Boolean
        Try
            Dim DataRowViewResultado() As DataRowView = refparDataViewEsquema.FindRows(parsNodoPadre)
            If DataRowViewResultado.Length <> 0 Then
                Dim refDataRowView As DataRowView
                Dim refTreeNode As TreeNode
                Dim sNombreNodo As String
                Dim sNodo As String
                For Each refDataRowView In DataRowViewResultado
                    sNodo = refDataRowView("EsquemaID")
                    If sNodo <> "*" Then
                        sNombreNodo = refDataRowView("Nombre")
                        refTreeNode = refparTreeView.Add(sNombreNodo)
                        refTreeNode.Tag = sNodo
                        PoblarNodoArbol(refTreeNode.Nodes, sNodo, refparDataViewEsquema)
                    End If
                Next
            End If
            Return True
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarNodoArbol")
        End Try
        Return False
    End Function
    'Private Sub PoblarListaClientesNodo()
    '    If Me.TreeViewArbolClientes.SelectedNode Is Nothing Then
    '        Exit Sub
    '    End If
    '    Dim refTreeNode As TreeNode = Me.TreeViewArbolClientes.SelectedNode
    '    'Me.LabelRuta.Text = refTreeNode.FullPath
    '    Dim aFiltro As New ArrayList
    '    ' Buscar los grupos que dependen del nodo seleccionado
    '    BuscarGruposClientes(refTreeNode.Tag, aFiltro)
    '    ' Poblar el listview con el filtro
    '    Dim sEsquemasFiltro As String = ""
    '    For Each sEsquemaID As String In aFiltro
    '        sEsquemasFiltro &= "'" & sEsquemaID & "',"
    '    Next
    '    sEsquemasFiltro = Mid(sEsquemasFiltro, 1, sEsquemasFiltro.Length - 1)
    '    refaVista.PoblarListView(ListViewClientes, oDBVen, "ListViewClientes", " WHERE EsquemaID in(" & sEsquemasFiltro & ")")
    'End Sub
    Private Sub PoblarListaClientesNodo()
        If Me.TreeViewArbolClientes.SelectedNode Is Nothing Then
            Exit Sub
        End If
        Dim refTreeNode As TreeNode = Me.TreeViewArbolClientes.SelectedNode
        Dim aFiltro As New ArrayList
        ' Buscar los esquemas que dependen del nodo seleccionado
        Dim sEsquemasFiltro As String = ""
        BuscarEsquemasClientes(refTreeNode.Tag, sEsquemasFiltro)
        Try
            ' Poblar el listview con el filtro
            refaVista.PoblarListView(ListViewClientes, oDBVen, "ListViewClientes", " WHERE EsquemaID in(" & sEsquemasFiltro & ")")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "PoblarListView")
        End Try
    End Sub
    Private Sub BuscarEsquemasClientes(ByVal parsEsquemaId As String, ByRef refparsEsquemas As String)
        refparsEsquemas &= "'" & parsEsquemaId & "',"
        BuscarEsquemasHijos(parsEsquemaId, refparsEsquemas)
        refparsEsquemas = Mid(refparsEsquemas, 1, refparsEsquemas.Length - 1)
    End Sub
    Private Sub BuscarEsquemasHijos(ByVal parsEsquemaPadreId As String, ByRef refparsEsquemas As String)
        Dim dtEsquemas As DataTable
        dtEsquemas = oDBVen.RealizarConsultaSQL("select EsquemaId from Esquema where EsquemaIdPadre = '" & parsEsquemaPadreId & "'", "Esquemas")
        For Each drEsquema As DataRow In dtEsquemas.Rows
            refparsEsquemas &= "'" & drEsquema("EsquemaId") & "',"
        Next
        dtEsquemas = oDBVen.RealizarConsultaSQL("select EsquemaID from Esquema where EsquemaIDPadre in (select EsquemaID from Esquema where EsquemaIDPadre= '" & parsEsquemaPadreId & "')", "EsquemasHijo")
        For Each drEsquemaHijo As DataRow In dtEsquemas.Rows
            refparsEsquemas &= "'" & drEsquemaHijo("EsquemaId") & "',"
            BuscarEsquemasHijos(drEsquemaHijo("EsquemaId"), refparsEsquemas)
        Next
        dtEsquemas.Dispose()
    End Sub
    Private Function BuscarGruposClientes(ByRef refparsNodo As String, ByRef refaArreglo As ArrayList) As Boolean
        Try
            ' Dataset con el esquema de productos
            Dim DataTableEsquema As DataTable
            DataTableEsquema = oDBVen.RealizarConsultaSQL("SELECT EsquemaIDPadre, EsquemaID FROM Esquema WHERE Tipo=" & ServicesCentral.TiposEsquemas.Clientes, "Esquema")
            If DataTableEsquema.Rows.Count = 0 Then
                DataTableEsquema.Dispose()
                Exit Try
            End If
            ' DataViews para la búsqueda de los grupos
            Dim DataViewEsquema As New DataView(DataTableEsquema, "", "EsquemaIDPadre", DataViewRowState.CurrentRows)
            ' Considerar el primer nodo tambien
            refaArreglo.Add(refparsNodo)
            ' Si se encuentra, agregarlo al arreglo del filtro
            Return BuscarNodosArbol(refaArreglo, refparsNodo, DataViewEsquema)
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarGruposProductos")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarGruposProductos")
        End Try
        Return False
    End Function
    Private Function BuscarNodosArbol(ByRef refaArreglo As ArrayList, ByVal parsNodo As String, ByRef refparDataViewEsquema As DataView) As Boolean
        Try
            Dim DataRowViewResultado() As DataRowView = refparDataViewEsquema.FindRows(parsNodo)
            If DataRowViewResultado.Length <> 0 Then
                Dim refDataRowView As DataRowView
                Dim sNodo As String
                For Each refDataRowView In DataRowViewResultado
                    sNodo = refDataRowView("EsquemaID")
                    If Not refaArreglo.Contains(sNodo) Then
                        refaArreglo.Add(sNodo)
                        If sNodo <> "*" Then
                            BuscarNodosArbol(refaArreglo, sNodo, refparDataViewEsquema)
                        End If
                    End If
                Next
            End If
            Return True
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarNodosArbol")
        End Try
        Return False
    End Function
    Private Function ValidaCampos() As Boolean
        If tTipoReporte = TiposReportes.NoDefinido Then
            'MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxFolio.Text))
            ComboBoxReporte.Focus()
            Return False
        End If
        Select Case tTipoReporte
            Case TiposReportes.Cargas, TiposReportes.Descargas, TiposReportes.EfectividadPorRuta, _
            TiposReportes.Ventas, TiposReportes.SaldosPorClienteEnEnvase, _
            TiposReportes.ResumenDeMovimientos
                If RadioButtonDetallado.Checked = False AndAlso RadioButtonGeneral.Checked = False Then
                    ComboBoxReporte.Focus()
                    Return False
                End If
        End Select
        Return True
    End Function

    Private Function TextoCentradoConSymbolo(ByVal cadena As String, ByVal Symbolo As Char) As String
        Dim Linea As String = ""

        For i As Integer = 1 To LongTot
            If i = Math.Round(LongTot / 2, 0) - Math.Round((cadena.Length + 2) / 2, 0) Then
                Linea &= " " & cadena & " "
                i = i + cadena.Length + 2
            Else
                Linea &= Symbolo
            End If
        Next

        Return Linea
    End Function
    Private Sub MuestraReporte()
        Dim line As String
        Try
            TextBoxReporte.Text = ComboBoxReporte.Text
            TextBoxVerReporte.Text = ""
            Dim SrAD As StreamReader = New StreamReader(sArchivoDetalle)
            Do
                line = SrAD.ReadLine()
                TextBoxVerReporte.Text &= line & vbCrLf
            Loop Until line Is Nothing
            SrAD.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "MuestraReporte")
        End Try
    End Sub

    Private Sub CreaReporte(Optional ByVal Clientes As String = "")
        Dim Sw As StreamWriter
  
        CreaArchivo(Sw, sArchivoDetalle)

        CreaEncabezado(Sw, LongTot)
        CreaTitulos(Sw)
        CreaDetalle(Sw, Clientes)
        Sw.Flush()
        Sw.Close()
    End Sub

    Private Sub CreaTitulos(ByRef sw As StreamWriter)
        Dim cad As String = ""

        Select Case tTipoReporte
            Case TiposReportes.Cobranza
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XCobranzaTitulo"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio"), 10, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFechaAlta"), 11, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte"), 13, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo"), 14, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.Cargas
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XCargasDetTit"), LongTot))
                Else
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XCargasGenTit"), LongTot))
                End If
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta("", 15, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 17, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 9, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XElemento"), 7, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.Descargas
                sw.WriteLine(TextoCentrado(Me.ComboBoxReporte.Text, LongTot))
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(RadioButtonDetallado.Text, LongTot))
                Else
                    sw.WriteLine(TextoCentrado(RadioButtonGeneral.Text, LongTot))
                End If
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)

                If RadioButtonDetallado.Checked Then
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 15, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 17, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 9, Alineacion.Derecha, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XElemento"), 7, Alineacion.Derecha, True)
                Else
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 32, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 9, Alineacion.Derecha, True)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XElemento"), 7, Alineacion.Derecha, True)
                End If


                sw.WriteLine(cad)
            Case TiposReportes.Inventario
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XInventarioTit"), LongTot))
                'If Me.RadioButtonGeneral.Checked Then
                '    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XGeneral"), LongTot))
                'Else
                '    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XDetallado"), LongTot))
                'End If
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                'Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select descripcion from VAVDescripcion where VARCodigo='UNIDADV'", "Inventario")
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 21, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XExis"), 9, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XApar"), 9, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XDisp"), 9, Alineacion.Derecha, False)

                sw.WriteLine(cad)
            Case TiposReportes.EfectividadPorRuta
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "Xefectividaddettit"), LongTot))
                Else
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XEfectividadGenTit"), LongTot))
                End If
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))
                sw.WriteLine()
                sw.WriteLine(TextoCentrado(oDia.DiaActual, LongTot))

            Case TiposReportes.Ventas
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XDetalladoVentasTit"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))
                ElseIf RadioButtonGeneral.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XGeneralVentas"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))
                End If
                'ImprimeLineaPunteada(sw, LongTot)
                sw.WriteLine(cad)
            Case TiposReportes.SaldosPorClienteEnEfectivo
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XSaldoEfectivo"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XClave"), 10, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "xnombre"), 25, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo"), 13, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.SaldosPorClienteEnEnvase
                sw.WriteLine(TextoCentrado(ValorReferencia.BuscarEquivalente("REPORTEM", tTipoReporte) + " " + IIf(RadioButtonDetallado.Checked, RadioButtonDetallado.Text, RadioButtonGeneral.Text), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)

                If RadioButtonDetallado.Checked Then
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCliente"), 20, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XEnvase"), 15, Alineacion.Izquierda, False)
                Else
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCliente"), 35, Alineacion.Izquierda, False)
                End If
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo"), 13, Alineacion.Derecha, True)


                sw.WriteLine(cad)
            Case TiposReportes.ResumenDeMovimientos
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XResumenDetalladoTit"), LongTot))
                Else
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XResumenGeneralTit"), LongTot))
                End If
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 28, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 10, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 10, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.HistoricoPromedio
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XHistoricoTit"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio"), 15, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFecha"), 15, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte"), 18, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.Depositos
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XDepositosTit"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XFicha"), 18, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XForma Pago"), 15, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte"), 15, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.Liquidacion
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XLiquidacionTit"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

            Case TiposReportes.GeneralDePromociones
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XPromocionesTit"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XClave"), 12, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPromocion"), 32, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTipo"), 4, Alineacion.Izquierda, True)
                sw.WriteLine(cad)
            Case TiposReportes.ResumenCobranza
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XResumenCobranza"), LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                ImprimeLineaPunteada(sw, LongTot)
                cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio"), 22, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte"), 13, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XAbono"), 13, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.SaldoProductoPrestado
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XSaldoProductoPrestadoDetTit"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                    ImprimeLineaPunteada(sw, LongTot)
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 30, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 18, Alineacion.Derecha, True)
                Else
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XSaldoProductoPrestadoGenTit"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                    ImprimeLineaPunteada(sw, LongTot)
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 30, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 18, Alineacion.Derecha, True)
                End If
                sw.WriteLine(cad)
            Case TiposReportes.MovSinInvSinVis
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XMovSinInvSinVisDet"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                    ImprimeLineaPunteada(sw, LongTot)
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 28, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 10, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 10, Alineacion.Derecha, True)
                Else
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XMovSinInvSinVisGral"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                    ImprimeLineaPunteada(sw, LongTot)
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 30, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 18, Alineacion.Derecha, True)
                End If
                sw.WriteLine(cad)
            Case TiposReportes.MovSinInvConVis
                If RadioButtonDetallado.Checked Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XMovSinInvConVisDet"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                    ImprimeLineaPunteada(sw, LongTot)
                    cad = CompletaHasta("", 5, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 10, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 10, Alineacion.Derecha, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XP.U"), 10, Alineacion.Derecha, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 13, Alineacion.Derecha, True)
                Else
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XMovSinInvConVisGral"), LongTot))
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                    ImprimeLineaPunteada(sw, LongTot)
                    cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio"), 10, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCliente"), 16, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XFechaMovimiento"), 11, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 11, Alineacion.Derecha, True)
                End If
                sw.WriteLine(cad)

            Case TiposReportes.ProductosPromocionNoEntregados
                sw.WriteLine(TextoCentrado(Me.ComboBoxReporte.Text, LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                sw.WriteLine(cad)
            Case TiposReportes.ExtensiónDeAlmacén
                Dim sRutClave As String = ""
                Dim tablaRutas As DataTable = oDBVen.RealizarConsultaSQL("SELECT RUTCLAVE FROM RUTA", "RUTAS")
                For Each FILA As DataRow In tablaRutas.Rows
                    sRutClave += FILA("RUTCLAVE") + ","
                Next
                sRutClave = sRutClave.Substring(0, sRutClave.Length - 1)
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XRuta") & ": " & sRutClave, LongTot))


                sw.WriteLine(TextoCentrado(Me.ComboBoxReporte.Text, LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))
                ImprimeLineaPunteada(sw, LongTot)

                cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProd"), 12, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XIni"), 5, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XRec"), 5, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 5, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProm"), 5, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCon"), 5, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "xDec"), 5, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XFin"), 6, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.VtaProductoyMovDeEnvase
                Dim sRutClave As String = ""
                Dim tablaRutas As DataTable = oDBVen.RealizarConsultaSQL("SELECT RUTCLAVE FROM RUTA", "RUTAS")
                For Each FILA As DataRow In tablaRutas.Rows
                    sRutClave += FILA("RUTCLAVE") + ","
                Next
                sRutClave = sRutClave.Substring(0, sRutClave.Length - 1)
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XRuta") & ": " & sRutClave, LongTot))

                sw.WriteLine(TextoCentrado(Me.ComboBoxReporte.Text, LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

                sw.WriteLine(TextoCentradoConSymbolo(refaVista.BuscarMensaje("MsgBox", "XResumenVta"), "-"))

                cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProd"), 10, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProm"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCon"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XLis"), 8, Alineacion.Derecha, True)

                sw.WriteLine(cad)

                cad = CompletaHasta("", 10, Alineacion.Izquierda, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XReg"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCan"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XNeta"), 6, Alineacion.Derecha, False)
                cad &= CompletaHasta("", 6, Alineacion.Derecha, False)
                cad &= CompletaHasta("", 6, Alineacion.Derecha, False)
                cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XPre"), 8, Alineacion.Derecha, True)
                sw.WriteLine(cad)
            Case TiposReportes.LiquidacionDisposur
                sw.WriteLine(TextoCentrado(Me.ComboBoxReporte.Text, LongTot))
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

        End Select
        If tTipoReporte <> TiposReportes.Ventas Then
            ImprimeLineaPunteada(sw, LongTot)
        End If
    End Sub

    Private Sub CreaDetalle(ByRef sw As StreamWriter, Optional ByVal Clientes As String = "")
        Select Case tTipoReporte
            Case TiposReportes.Cobranza
                ReporteCobranza(sw, Clientes)
            Case TiposReportes.Cargas
                ReporteCargas(sw)
            Case TiposReportes.Descargas
                ReporteDescargasyDevoluciones(sw)
            Case TiposReportes.Inventario
                ReporteInventario(sw)
            Case TiposReportes.EfectividadPorRuta
                ReporteEfectividadPorRuta(sw)
            Case TiposReportes.Ventas
                ReporteVentas(sw)
            Case TiposReportes.SaldosPorClienteEnEfectivo
                ReporteSaldoEfectivo(sw, Clientes)
            Case TiposReportes.SaldosPorClienteEnEnvase
                ReporteSaldoEnvase(sw, Clientes)
            Case TiposReportes.ResumenDeMovimientos
                ReporteResumenMovimientos(sw)
            Case TiposReportes.HistoricoPromedio
                ReporteHistoricoPromedio(sw, Clientes)
            Case TiposReportes.Depositos
                ReporteDepositos(sw)
            Case TiposReportes.Liquidacion
                ReporteLiquidacion(sw)
            Case TiposReportes.GeneralDePromociones
                ReportePromociones(sw)
            Case TiposReportes.ResumenCobranza
                ReporteResumenCobranza(sw, Clientes)
            Case TiposReportes.SaldoProductoPrestado
                ReporteSaldoProductoPrestado(sw, Clientes)
            Case TiposReportes.MovSinInvSinVis
                ReporteMovimientosSinInventario(sw, Clientes)
            Case TiposReportes.MovSinInvConVis
                ReporteMovimientosSinInventarioConV(sw, Clientes)
            Case TiposReportes.ProductosPromocionNoEntregados
                ReporteProductosPromocionNoEntregados(sw, Clientes)
            Case TiposReportes.ExtensiónDeAlmacén
                ReporteExtensionDeAlmacen(sw)
            Case TiposReportes.VtaProductoyMovDeEnvase
                ReporteVtaProductoyMovEnvase(sw)
            Case TiposReportes.LiquidacionDisposur
                ReporteLiquidacionPoblana(sw)
        End Select
    End Sub

    Private Sub ImprimeFirmaCentrada(ByRef Sw As IO.StreamWriter, ByVal etiqueta As String)


        Dim Linea As String = ""
        Dim Cadena As String = "____________________"

        For i As Integer = 1 To LongTot
            If i = Math.Round(LongTot / 2, 0) - Math.Round((cadena.Length + 2) / 2, 0) Then
                Linea &= " " & cadena & " "
                i = i + cadena.Length + 2
            Else
                Linea &= " "
            End If
        Next

        Sw.WriteLine(Linea)

        Linea = ""

        For i As Integer = 1 To LongTot
            If i = Math.Round(LongTot / 2, 0) - Math.Round((etiqueta.Length + 2) / 2, 0) Then
                Linea &= " " & etiqueta & " "
                i = i + etiqueta.Length + 2
            Else
                Linea &= " "
            End If
        Next

        Sw.WriteLine(Linea)



    End Sub
    Private Sub ImprimeFirmas(ByRef Sw As IO.StreamWriter, ByVal etiqueta1 As String, ByVal etiqueta2 As String)
        Dim Linea As String = ""

        Dim Cadena As String = "________________"

        If LongTot = 32 Then
            Cadena = "------------"
        End If

        For i As Integer = 0 To LongTot / 2
            If i = Math.Round(LongTot / 4, 0) - Math.Round((Cadena.Length + 2) / 2, 0) Then
                Linea &= " " & Cadena & " "
                i = i + Cadena.Length + 2
            Else
                Linea &= " "
            End If
        Next

        For i As Integer = 0 To LongTot / 2
            If i = Math.Round(LongTot / 4, 0) - Math.Round((Cadena.Length + 2) / 2, 0) Then
                Linea &= " " & Cadena & " "
                i = i + Cadena.Length + 2
            Else
                Linea &= " "
            End If
        Next

        Sw.WriteLine(Linea)

        Linea = ""

        For i As Integer = 0 To LongTot / 2
            If i = Math.Round(LongTot / 4, 0) - Math.Round((etiqueta1.Length + 2) / 2, 0) Then
                Linea &= " " & etiqueta1 & " "
                i = i + etiqueta1.Length + 2
            Else
                Linea &= " "
            End If
        Next

        For i As Integer = 0 To LongTot / 2
            If i = Math.Round(LongTot / 4, 0) - Math.Round((etiqueta2.Length + 2) / 2, 0) Then
                Linea &= " " & etiqueta2 & " "
                i = i + etiqueta2.Length + 2
            Else
                Linea &= " "
            End If
        Next

        Sw.WriteLine(Linea)
    End Sub

    Private Function HayRegistrosGrupoTerminarVisita(ByVal parsVisitaClave As String, ByVal parsDiaClave As String, ByVal parClienteClave As String) As Integer

        Select Case tTipoReporte
            Case TiposReportes.NotaVta
                Dim Q As New System.Text.StringBuilder
                Q.Append("select count(*) from transprod ")
                Q.Append("where ((tipo =1   ")
                Q.Append("and diaclave = '" & parsDiaClave & "' ")
                Q.Append("and visitaclave = '" & parsVisitaClave & "' and tipofase<>0 ) ")
                Q.Append("or (tipo=24 and  diaclave1  = '" & parsDiaClave & "' and visitaclave1 = '" & parsVisitaClave & "' and tipofase=6 ) )")

                If oDBVen.EjecutarCmdScalarIntSQL(Q.ToString) > 0 Then
                    Q = Nothing
                    Return 1
                End If

                'Validar abonos
                If oDBVen.EjecutarCmdScalarIntSQL("select count(*) from abono where visitaclave='" & parsVisitaClave & "' and diaclave='" & parsDiaClave & "' ") > 0 Then
                    Return 1
                End If

            Case Else
                Return 2

        End Select

        Return 0
    End Function

    Private Function HayRegistros(Optional ByVal clientes As String = "") As Integer
        Dim Q As New System.Text.StringBuilder
        Select Case tTipoReporte
            Case TiposReportes.Cobranza
                Q.Append("select distinct cliente.clienteclave, cliente.nombrecorto ")
                Q.Append("from transprod inner join Visita on Visita.VisitaClave = TransProd.VisitaClave ")
                Q.Append("inner join Cliente on Visita.Clienteclave=Cliente.ClienteClave ")
                Q.Append("where ")
                If blnCobrarVentas Then
                    Q.Append("transprod.tipo=1 and TransProd.TipoFase<>0 and TransProd.Saldo>0 ")
                Else
                    Q.Append("transprod.tipo=8 and TransProd.TipoFase<>0 and TransProd.Saldo>0 ")
                End If
                If clientes <> String.Empty Then
                    Q.Append("and visita.clienteclave in (" & clientes & ") ")
                End If
            Case TiposReportes.ResumenCobranza
                Q.Append("select distinct CLI.clienteclave ")
                Q.Append("from transprod TRP ")
                Q.Append("inner join ABNTRP ABT on ABT.TransProdID = TRP.TransProdID ")
                Q.Append("inner join Abono ABN on ABN.ABNID = ABT.ABNID ")
                Q.Append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave and VIS.DiaClave = ABN.DiaClave ")
                Q.Append("inner join Cliente CLI on VIS.Clienteclave=CLI.ClienteClave ")
                Q.Append("where VIS.DiaClave='" & oDia.DiaActual & "' ")
                If blnCobrarVentas Then
                    Q.Append(" and TRP.tipo=1 and TRP.tipofase <> 0 ")
                Else
                    Q.Append(" and TRP.tipo=8 and TRP.tipofase <> 0 ")
                End If

                If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                    Q.Append(" and VIS.clienteclave in(" & clientes & ") ")
                End If

            Case TiposReportes.Cargas
                Q.Append("select distinct transprodid from transprod where tipo=2 and " & FechaConvertida("fechaCaptura", tTipoReporte))
            Case TiposReportes.Descargas
                Q.Append("select distinct transprodid from transprod where tipo in (7,4) AND TipoFase <> 0  and " & IIf(CheckBoxFecha.Checked, FechaConvertida("fechaCaptura", tTipoReporte), " diaclave in(" & diaClavesEnFrecuencia() & ") "))

            Case TiposReportes.Inventario
                Q.Append("select productoclave from SKUInventario where Disponible>0 or Apartado>0")
            Case TiposReportes.EfectividadPorRuta
                Q.Append("select distinct cliente.clienteclave ")
                Q.Append("from agenda, cliente ")
                Q.Append("where agenda.clienteclave=cliente.clienteclave ")
                Q.Append("and agenda.vendedorid='" & oVendedor.VendedorId & "' ")
                Q.Append("and agenda.diaclave='" & oDia.DiaActual & "' ")
            Case TiposReportes.Ventas
                Q.Append("SELECT TRP.TransProdID FROM TransProd TRP INNER JOIN Visita VIS ON TRP.VisitaClave=VIS.VisitaClave and TRP.DiaClave=VIS.DiaClave ")
                Q.Append("INNER JOIN TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID ")
                Q.Append("WHERE TRP.Tipo=1 and TRP.TipoFase<>0  and VIS.VendedorId='" & oVendedor.VendedorId & "' ")
                Q.Append("and VIS.DiaClave='" & oDia.DiaActual & "' ")
                Q.Append("UNION ")
                Q.Append("SELECT TRP.TransProdId FROM TransProd TRP INNER JOIN Visita VIS ON TRP.VisitaClave1=VIS.VisitaClave and TRP.DiaClave1=VIS.DiaClave ")
                Q.Append("INNER JOIN TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID ")
                Q.Append("WHERE TRP.Tipo=1 and TRP.TipoFase<>0  and VIS.VendedorId='" & oVendedor.VendedorId & "' ")
                Q.Append("and VIS.DiaClave='" & oDia.DiaActual & "' ")
            Case TiposReportes.SaldosPorClienteEnEfectivo


                Q.Append("select cliente.clave, cliente.razonsocial,saldoefectivo as Saldo ")
                Q.Append("from cliente where saldoefectivo<>0 ")
                If clientes <> String.Empty Then
                    Q.Append("and clienteclave in (" & clientes & ") ")
                End If


            Case TiposReportes.SaldosPorClienteEnEnvase
                Q.Append("select * from ProductoPrestamoCli where saldo <>0 ")
                If clientes <> String.Empty Then
                    Q.Append("and clienteclave in (" & clientes & ")")
                End If

            Case TiposReportes.ResumenDeMovimientos
                Q.Append("select transprodid from transprod ")
                Q.Append("where transprod.diaclave='" & oDia.DiaActual & "' and tipofase<>0")
            Case TiposReportes.HistoricoPromedio
                Q.Append("select folio, visita.clienteclave, cliente.razonsocial from transprod, visita, cliente ")
                Q.Append("where transprod.tipo=1 ")
                Q.Append("and transprod.tipofase <> 0 ")
                Q.Append("and transprod.visitaclave=visita.visitaclave ")
                Q.Append("and transprod.diaclave=visita.diaclave ")
                Q.Append("and visita.clienteclave=cliente.clienteclave ")
                If clientes <> String.Empty Then
                    Q.Append("and visita.clienteclave in (" & clientes & ") ")
                End If
                Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' ")
                Q.Append("and " & FechaConvertida("TransProd.FechaCaptura"))

            Case TiposReportes.Depositos
                Q.Append("select ficha from deposito where " & FechaConvertida("fechadeposito"))
            Case TiposReportes.Liquidacion
                'Resumen de movtos
                Q.Append("select transprodid from transprod ")
                Q.Append("where tipofase<>0 and " & FechaConvertida("fechacaptura"))
                If oDBVen.RealizarConsultaSQL(Q.ToString, "ResumenMovtos").Rows.Count > 0 Then Return 1
                'Cobranza
                Q = New System.Text.StringBuilder
                Q.Append("select abndetalle.tipopago, abndetalle.tipobanco, abndetalle.importe ")
                Q.Append("from abono, abndetalle, visita ")
                Q.Append("where abono.abnid=abndetalle.abnid ")
                Q.Append("and abono.visitaclave=visita.visitaclave ")
                Q.Append("and abono.diaclave=visita.diaclave ")
                Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' ")
                Q.Append("and " & FechaConvertida("abono.fechaabono") & " ")
                If oDBVen.RealizarConsultaSQL(Q.ToString, "Cobranza").Rows.Count > 0 Then Return 1
                'Depósitos
                Q = New System.Text.StringBuilder
                Q.Append("select ficha from deposito where ")
                Q.Append(FechaConvertida("deposito.fechadeposito"))
                If oDBVen.RealizarConsultaSQL(Q.ToString, "Depósitos").Rows.Count > 0 Then
                    Return 1
                Else
                    Return 0
                End If
            Case TiposReportes.GeneralDePromociones
                Q.Append("Select promocionclave from promocion where tipo in (1,4) ")
                Q.Append("and " & UniFechaSQL(PrimeraHora(Now)))
                Q.Append(" between FechaInicial ")
                Q.Append("and FechaFinal ")

            Case TiposReportes.SaldoProductoPrestado
                Q.Append("Select Visita.ClienteClave from productoprestamo inner join TransProd on TransProd.TransProdId = ProductoPrestamo.TransProdId ")
                Q.Append("inner join Visita on TransProd.VisitaClave = Visita.VisitaClave and TransProd.DiaClave = Visita.DiaClave ")
                Q.Append("inner join Cliente on Visita.ClienteClave = Cliente.ClienteClave where (TransProd.Tipo = 1 and TransProd.TipoFase<>0) or (TransProd.Tipo = 15) ")
            Case TiposReportes.MovSinInvSinVis
                Q.Append("select transprod.transprodid from transprod ")
                Q.Append("inner join transproddetalle on transproddetalle.transprodid = transprod.transprodid ")
                Q.Append("where transprod.tipo = 19 and transprod.visitaClave is null " & IIf(CheckBoxFecha.Checked, " AND " & FechaConvertida("TransProd.FechaCaptura"), "") & " ")
            Case TiposReportes.MovSinInvConVis
                Q.Append("select TransProd.transprodid from transprod ")
                Q.Append("inner join transproddetalle on transproddetalle.transprodid = transprod.transprodid ")
                Q.Append("where TransProd.tipofase <>0 and TransProd.tipo = 21 and transprod.visitaClave is not null " & IIf(CheckBoxFecha.Checked, " AND " & FechaConvertida("TransProd.FechaCaptura"), "") & " ")
                If clientes <> String.Empty Then
                    Q.Append("and TransProd.ClienteClave in (" & clientes & ") ")
                End If
            Case TiposReportes.ProductosPromocionNoEntregados
                Q.Append("select * from ProductoNegado where not PromocionClave is null")
                If clientes <> String.Empty Then
                    Q.Append(" and cliente in(select clave from cliente where clienteclave in(" & clientes & ")) ")
                End If
            Case TiposReportes.MovimientosDureanteLaVisita

                Q.Append("select transprodid ")
                Q.Append("from TransProd inner join visita on transprod.visitaclave=visita.visitaclave ")
                Q.Append("where (tipo=9 or tipo=1)and transprod.diaclave=visita.diaclave ")
                Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "'  and Visita.DiaClave='" & oDia.DiaActual & "' ")
            Case TiposReportes.ExtensiónDeAlmacén
                Q.Append("select * from transprod T ")
                Q.Append("inner join transproddetalle TD on T.transprodid=TD.transprodid ")
                Q.Append("inner join producto P on TD.productoclave=P.productoclave ")
                Q.Append("where p.contenido<>1 and T.tipo in (23,2,1,19) and T.tipofase <>0 and T.diaclave in (" & diaClavesEnFrecuencia() & ")")

            Case TiposReportes.VtaProductoyMovDeEnvase
                Q.Append("select * from transprod ")
                Q.Append("where tipo=1 and tipofase <>0 and diaclave in (" & diaClavesEnFrecuencia() & ")")
                If oDBVen.RealizarConsultaSQL(Q.ToString, "Ventas").Rows.Count > 0 Then Return 1
                Q = New System.Text.StringBuilder
                Q.Append("select clienteclave from productoprestamocli where saldo <>0 or cargo<>0 or abono<>0 or venta<>0")
                If oDBVen.RealizarConsultaSQL(Q.ToString, "Prestamos").Rows.Count > 0 Then Return 1
                Q = New System.Text.StringBuilder
                Q.Append("select * from transprod ")
                Q.Append("where tipo=24 and tipofase=6  and diaclave1 in (" & diaClavesEnFrecuencia() & ")")
                If oDBVen.RealizarConsultaSQL(Q.ToString, "Consignacion").Rows.Count > 0 Then Return 1
                Q = New System.Text.StringBuilder
                Q.Append("select * from abono where diaclave in (" & diaClavesEnFrecuencia() & ")")
            Case TiposReportes.LiquidacionDisposur
                'Resumen de movtos
                If oDBVen.EjecutarCmdScalardblSQL("select sum(abndetalle.importe) as Importe from abono inner join abndetalle on abono.abnid=abndetalle.abnid inner join visita on  abono.visitaclave=visita.visitaclave and abono.diaclave=visita.diaclave inner join abntrp on abntrp.abnid=abono.abnid inner join transprod on abntrp.transprodid=transprod.transprodid where   visita.vendedorid='" & oVendedor.VendedorId & "' and " & FechaConvertida("abntrp.fechahora") & " and transprod.cfvtipo=1 and transprod.tipo=1 and transprod.tipofase<>0") + oDBVen.EjecutarCmdScalardblSQL("select sum(abndetalle.importe) as Importe from abono inner join abndetalle on abono.abnid=abndetalle.abnid inner join visita on  abono.visitaclave=visita.visitaclave and abono.diaclave=visita.diaclave inner join abntrp on abntrp.abnid=abono.abnid inner join transprod on abntrp.transprodid=transprod.transprodid where   visita.vendedorid='" & oVendedor.VendedorId & "' and " & FechaConvertida("abntrp.fechahora") & " and transprod.tipofase<>0 and ((transprod.tipo=1 and transprod.cfvtipo=2) or  transprod.tipo=24)  ") > 0 Then
                    Return 1
                End If

                Q.Append("select transprodid from transprod ")
                Q.Append("where tipofase<>0 and " & FechaConvertida("fechacaptura"))
                Q.Append(" and tipo in (1,24)")

            Case Else
                Return 2
        End Select
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Registros")
        Q = Nothing
        If Dt.Rows.Count > 0 Then
            Dt.Dispose()
            Return 1
        Else
            Dt.Dispose()
            Return 0
        End If
    End Function

    Public Function diaClavesEnFrecuencia() As String
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select  diaclave from dia where fuerafrecuencia=0", "DIAS")
        Dim dias As String = ""
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                dias &= "'" & row(0) & "',"
            Next
            dias = dias.Remove(dias.Length - 1, 1)
        End If
        dt.Dispose()
        Return dias
    End Function
    Public Function diaClavesFechaCapturaEnFrecuencia() As String
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select convert(nvarchar(200), fechacaptura,103) as fechacaptura from dia where fuerafrecuencia=0", "DIAS")
        Dim dias As String = ""
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                dias &= "'" & row(0) & "',"
            Next
            dias = dias.Remove(dias.Length - 1, 1)
        End If
        dt.Dispose()
        Return dias
    End Function

    Private Sub AgregaATotales(ByRef HT As Hashtable, ByVal Clave As String, ByVal pardCantidad As Decimal, ByVal TipoUnidad As String, ByVal pardCantidad1 As Decimal)
        Clave = Clave.ToUpper
        Dim lista As System.Collections.Generic.List(Of Decimal)
        If HT.ContainsKey(Clave) Then
            lista = HT.Item(Clave)
            lista.Item(0) += pardCantidad
            lista.Item(1) += pardCantidad1
            HT.Item(Clave) = lista
        Else
            lista = New System.Collections.Generic.List(Of Decimal)
            lista.Add(pardCantidad)
            lista.Add(pardCantidad1)
            HT.Add(Clave, lista)
        End If
    End Sub

    Private Sub AgregaANombres(ByRef HT As Hashtable, ByVal Clave As String, ByVal NombreProd As String)
        Clave = Clave.ToUpper
        If Not HT.ContainsKey(Clave) Then
            HT.Add(Clave, NombreProd)
        End If
    End Sub

    'Private Function RecuperaCantidadEnUnidades(ByVal clave As String, ByVal cantidad As Integer, ByVal tipounidad As Integer) As Integer
    '    Dim nFactor As Decimal = oDBVen.EjecutarCmdScalardblSQL("select factor from productodetalle where productoclave='" & clave & "' and productoclave=productodetclave and prutipounidad=" & tipounidad)
    '    Return cantidad * nFactor
    'End Function

    Private Sub ImprimeTotales(ByVal HT As Hashtable, ByVal HN As Hashtable, ByRef Sw As StreamWriter)
        Dim myEnum As IDictionaryEnumerator = HT.GetEnumerator
        While myEnum.MoveNext
            Dim Cad As String
            Dim lista As System.Collections.Generic.List(Of Decimal) = CType(myEnum.Value, System.Collections.Generic.List(Of Decimal))
            Cad = CompletaHasta(myEnum.Key & "-" & HN.Item(myEnum.Key).ToString, 32, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(lista.Item(0), 9, Alineacion.Derecha, False)
            Cad &= CompletaHasta(lista.Item(1), 7, Alineacion.Derecha, True)
            Sw.WriteLine(Cad)
        End While
    End Sub

    Private Sub ObtieneClientes(ByRef clientes As String)
        With ListViewClientes
            For i As Integer = 0 To .Items.Count - 1
                If .Items(i).Checked Then
                    clientes &= "'" & .Items(i).SubItems(2).Text & "',"
                End If
            Next
        End With
        If clientes.Length > 0 Then
            clientes = Microsoft.VisualBasic.Left(clientes, clientes.Length - 1)
        End If
    End Sub

    Private Function FechaConvertida(ByVal campo As String, Optional ByVal tTipoReporte As TiposReportes = TiposReportes.NoDefinido) As String
        Dim tmp As String = ""
        tmp = campo
        If CheckBoxFecha.Checked Then
            'tmp &= Operador(ComboBoxComparaFecha.SelectedValue, Format(dtpFechaIni.Value, oApp.FormatoFecha), Format(dtpFechaFin.Value, oApp.FormatoFecha), TipoDato.Fecha)
            tmp &= Operador(ComboBoxComparaFecha.SelectedValue, dtpFechaIni.Value, dtpFechaFin.Value, TipoDato.Fecha)
        Else
            If tTipoReporte = TiposReportes.Cargas Or tTipoReporte = TiposReportes.Descargas Then
                tmp &= " <> 0"
            Else
                tmp &= " between " & UniFechaSQL(PrimeraHora(Now)) & " AND " & UniFechaSQL(UltimaHora(Now))
                'tmp = String.Empty
            End If

        End If

        Return tmp
    End Function


    'Private Function ObtieneDescuentoPor(ByVal TPId As String) As Double
    '    Dim Descuento As Double = 1
    '    Dim HuboDescuento As Boolean = False
    '    For Each Dr As DataRow In oDBVen.RealizarConsultaSQL("select descuentopor from transproddescuento where transprodid='" & TPId & "' order by jerarquia", "desc").Rows
    '        HuboDescuento = True
    '        Descuento *= (1 - CDbl(Dr("descuentopor")) / 100)
    '    Next
    '    Descuento *= 100
    '    If Not HuboDescuento Then
    '        Descuento = 0
    '    End If
    '    Return Descuento
    'End Function

    'Private Function ObtieneIdPedidos(ByVal sQuery As String) As String
    '    'Dim IdPedidos As String = ""
    '    'If Not Query Then
    '    '    FolioId = "'" & FolioId & "'"
    '    'End If
    '    'Dim Q As String = "select transprodid from transprod where facturaid in (select transprodid from transprod where folio in (" & FolioId & "))"
    '    'For Each dr As DataRow In oDBVen.RealizarConsultaSQL(Q, "Pedidos").Rows
    '    '    IdPedidos &= "'" & dr("transprodid") & "',"
    '    'Next
    '    'If IdPedidos.Length > 0 Then
    '    '    IdPedidos = Microsoft.VisualBasic.Left(IdPedidos, IdPedidos.Length - 1)
    '    'Else
    '    '    IdPedidos = "''"
    '    'End If
    '    'Return IdPedidos

    '    Dim IdPedidos As String = ""
    '    'Dim Q As String = "select transprodid from transprod where facturaid in (select transprodid from transprod where folio in (" & FolioId & "))"
    '    For Each dr As DataRow In oDBVen.RealizarConsultaSQL(sQuery, "Pedidos").Rows
    '        IdPedidos &= "'" & dr("transprodid") & "',"
    '    Next
    '    If IdPedidos.Length > 0 Then
    '        IdPedidos = Microsoft.VisualBasic.Left(IdPedidos, IdPedidos.Length - 1)
    '    Else
    '        IdPedidos = "''"
    '    End If
    '    Return IdPedidos
    'End Function

#End Region

#Region "Eventos Controles"

    Private Sub ComboBoxComparaFecha_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxComparaFecha.SelectedIndexChanged
        If Not bFin Then Exit Sub
        If ComboBoxComparaFecha.SelectedValue = 7 Then
            dtpFechaFin.Enabled = True
        Else
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxFecha_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxFecha.CheckStateChanged
        ComboBoxComparaFecha.Enabled = CheckBoxFecha.Checked
        dtpFechaIni.Enabled = CheckBoxFecha.Checked
    End Sub

    Private Sub ComboBoxComparaFecha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxComparaFecha.Click
        If blnSeleccionManual Then Exit Sub
        If ComboBoxComparaFecha.SelectedValue = 7 Then
            dtpFechaFin.Enabled = True
        Else
            dtpFechaFin.Enabled = False
        End If
    End Sub
    Private Sub TreeViewArbolProd_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewArbolClientes.AfterSelect
        'If Not bSeleccionando Then
        'If (Me.TreeViewArbolClientes.SelectedNode.Tag <> Me.TreeViewArbolClientes.Nodes(0).Tag) Then
        PoblarListaClientesNodo()
        'Else
        'If (Me.TreeViewArbolClientes.SelectedNode.Nodes.Count > 0) Then
        '    Me.TreeViewArbolClientes.SelectedNode = Me.TreeViewArbolClientes.SelectedNode.Nodes(0)
        ' ElseIf Me.TreeViewArbolClientes.Nodes.Count > 1 Then
        '      Me.TreeViewArbolClientes.SelectedNode = Me.TreeViewArbolClientes.Nodes(1)
        '   End If
        'End If
        'End If
    End Sub

    Private Sub ButtonRegresarFiltros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarFiltros.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxReporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxReporte.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        tTipoReporte = ComboBoxReporte.SelectedValue
        'Me.CheckBoxTotalizar.Enabled = (tTipoReporte = TiposReportes.Inventario)
        'If Me.CheckBoxTotalizar.Enabled Then
        '    Me.CheckBoxTotalizar.Checked = True
        'Else
        '    Me.CheckBoxTotalizar.Checked = False
        'End If
        'If tTipoReporte = TiposReportes.Ventas Then
        '    CheckBoxTotalesPP.Enabled = True
        'Else
        '    CheckBoxTotalesPP.Enabled = False
        'End If
        Select Case tTipoReporte
            Case TiposReportes.EfectividadPorRuta, TiposReportes.Ventas, TiposReportes.SaldosPorClienteEnEnvase, TiposReportes.ResumenDeMovimientos, TiposReportes.SaldoProductoPrestado
                blnDetGral = True
                blnFechaFolio = False
                Me.RadioButtonDetallado.Enabled = True
                Me.RadioButtonGeneral.Enabled = True
                Me.CheckBoxFecha.Checked = False
                Me.CheckBoxFecha.Enabled = False
            Case TiposReportes.HistoricoPromedio, TiposReportes.Depositos
                blnDetGral = False
                blnFechaFolio = True
                Me.RadioButtonDetallado.Enabled = False
                Me.RadioButtonGeneral.Enabled = False
                Me.CheckBoxFecha.Enabled = True
            Case TiposReportes.Liquidacion, TiposReportes.LiquidacionDisposur
                blnDetGral = False
                blnFechaFolio = False
                Me.RadioButtonDetallado.Enabled = False
                Me.RadioButtonGeneral.Enabled = False
                Me.CheckBoxFecha.Checked = False
                Me.CheckBoxFecha.Enabled = True
            Case TiposReportes.Cargas, TiposReportes.Descargas
                blnDetGral = True
                blnFechaFolio = False
                Me.RadioButtonDetallado.Enabled = True
                Me.RadioButtonGeneral.Enabled = True
                Me.CheckBoxFecha.Checked = False
                Me.CheckBoxFecha.Enabled = True

            Case TiposReportes.MovSinInvSinVis, TiposReportes.MovSinInvConVis
                blnDetGral = True
                blnFechaFolio = True
                Me.RadioButtonDetallado.Enabled = True
                Me.RadioButtonGeneral.Enabled = True
                Me.CheckBoxFecha.Checked = True
                Me.CheckBoxFecha.Enabled = True
            Case Else
                blnDetGral = False
                blnFechaFolio = False
                Me.RadioButtonDetallado.Enabled = False
                Me.RadioButtonGeneral.Enabled = False
                Me.CheckBoxFecha.Checked = False
                Me.CheckBoxFecha.Enabled = False
        End Select
        'Activar o desactivar el combo box de filtro de clientes
        Me.CheckBoxTodosLosClientes.Enabled = False

        Select Case tTipoReporte
            Case TiposReportes.Cobranza, TiposReportes.SaldosPorClienteEnEfectivo, TiposReportes.SaldosPorClienteEnEnvase, TiposReportes.HistoricoPromedio, TiposReportes.ResumenCobranza, TiposReportes.SaldoProductoPrestado, TiposReportes.MovSinInvConVis, TiposReportes.ProductosPromocionNoEntregados, TiposReportes.ProductosPromocionNoEntregados
                Me.CheckBoxTodosLosClientes.Enabled = True
        End Select
    End Sub

    Private Sub ButtonContinuarFiltros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarFiltros.Click
        If Not ValidaCampos() Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        blnSeleccionManual = True
        If tTipoReporte = TiposReportes.Cobranza OrElse tTipoReporte = TiposReportes.SaldosPorClienteEnEnvase OrElse tTipoReporte = TiposReportes.HistoricoPromedio OrElse tTipoReporte = TiposReportes.ResumenCobranza OrElse tTipoReporte = TiposReportes.SaldosPorClienteEnEfectivo OrElse tTipoReporte = TiposReportes.SaldoProductoPrestado OrElse tTipoReporte = TiposReportes.MovSinInvConVis OrElse tTipoReporte = TiposReportes.ProductosPromocionNoEntregados Then
            If Me.CheckBoxTodosLosClientes.Enabled Then
                If Me.CheckBoxTodosLosClientes.Checked = False Then
                    Me.TabControlReportes.SelectedIndex = 1
                Else
                    Select Case HayRegistros()
                        Case 0
                            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0034"), MsgBoxStyle.Information)
                            blnSeleccionManual = False
                            Cursor.Current = Cursors.Default
                            Exit Sub
                        Case 2
                            MsgBox(refaVista.BuscarMensaje("Mensajes2", "I0166"), MsgBoxStyle.Information)
                            blnSeleccionManual = False
                            Cursor.Current = Cursors.Default
                            Exit Sub
                    End Select

                    CreaReporte()
                    MuestraReporte()
                    Me.TabControlReportes.SelectedIndex = 2
                End If
            End If
        Else
            Select Case HayRegistros()
                Case 0
                    MsgBox(refaVista.BuscarMensaje("Mensajes", "E0034"), MsgBoxStyle.Information)
                    blnSeleccionManual = False
                    Cursor.Current = Cursors.Default
                    Exit Sub
                Case 2
                    MsgBox(refaVista.BuscarMensaje("Mensajes2", "I0166"), MsgBoxStyle.Information)
                    blnSeleccionManual = False
                    Cursor.Current = Cursors.Default
                    Exit Sub
            End Select

            CreaReporte()
            MuestraReporte()
            Me.TabControlReportes.SelectedIndex = 2
        End If
        blnSeleccionManual = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ButtonRegresarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarCliente.Click
        blnSeleccionManual = True
        Me.TabControlReportes.SelectedIndex = 0
        blnSeleccionManual = False
    End Sub

    Private Sub ButtonContinuarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarCliente.Click
        Cursor.Current = Cursors.WaitCursor
        blnSeleccionManual = True
        Dim Clientes As String = ""
        ObtieneClientes(Clientes)
        'Checo que haya clientes seleccioandos
        If Clientes = "" Then
            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
            blnSeleccionManual = False
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        'Checo que haya registros para esos clientes
        If HayRegistros(Clientes) = 0 Then
            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0034"), MsgBoxStyle.Information)
            blnSeleccionManual = False
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        'Creo y muestro el reporte subsecuente
        CreaReporte(Clientes)
        MuestraReporte()
        Me.TabControlReportes.SelectedIndex = 2
        blnSeleccionManual = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ListViewClientes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewClientes.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        If tTipoReporte = TiposReportes.Cobranza OrElse tTipoReporte = TiposReportes.HistoricoPromedio OrElse tTipoReporte = TiposReportes.ResumenCobranza Then
            MarcarElementoIncluyente(ListViewClientes, e.NewValue, e.Index)
        Else
            MarcarElemento(ListViewClientes, e.NewValue, e.Index)
        End If
        blnSeleccionManual = False
        If ListViewClientes.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewClientes.Items(ListViewClientes.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub

    Private Sub ListViewProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewClientes.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewClientes.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        If tTipoReporte = TiposReportes.Cobranza OrElse tTipoReporte = TiposReportes.HistoricoPromedio Then
            MarcarElementoIncluyente(ListViewClientes, CheckState.Checked, ListViewClientes.SelectedIndices(0))
        Else
            MarcarElemento(ListViewClientes, CheckState.Checked, ListViewClientes.SelectedIndices(0))
        End If
        blnSeleccionManual = False
    End Sub

    Private Sub TabControlReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlReportes.SelectedIndexChanged
        If TabControlReportes.SelectedIndex = 1 Then
            If Me.TreeViewArbolClientes.Nodes.Count > 0 Then
                bSeleccionando = True
                Me.TreeViewArbolClientes.SelectedNode = Me.TreeViewArbolClientes.Nodes(0)
                bSeleccionando = False
                TreeViewArbolProd_AfterSelect(Nothing, Nothing)
            End If
            If tTipoReporte = TiposReportes.Cobranza Or tTipoReporte = TiposReportes.SaldosPorClienteEnEnvase Or tTipoReporte = TiposReportes.HistoricoPromedio Or tTipoReporte = TiposReportes.ResumenCobranza Or tTipoReporte = TiposReportes.SaldosPorClienteEnEfectivo Or tTipoReporte = TiposReportes.SaldoProductoPrestado Or tTipoReporte = TiposReportes.MovSinInvConVis Or tTipoReporte = TiposReportes.ProductosPromocionNoEntregados Then
                Me.TabPageClientes.Enabled = True
            Else
                Me.TabPageClientes.Enabled = False
            End If
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        ButtonContinuarReporte.Enabled = False
        ButtonRegresarReporte.Enabled = False
        ButtonImprimir.Enabled = False
        ImprimirArchivo(7, True, sArchivoDetalle, oConHist.Campos("MostrarLogo"), oVendedor.TipoModImp, False)
        ButtonContinuarReporte.Enabled = True
        ButtonRegresarReporte.Enabled = True
        ButtonImprimir.Enabled = True
    End Sub

    Private Sub ButtonRegresarReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarReporte.Click
        If Me.CheckBoxTodosLosClientes.Enabled AndAlso Me.CheckBoxTodosLosClientes.Checked Then
            TabControlReportes.SelectedIndex = 0
        Else
            Select Case tTipoReporte
                Case TiposReportes.Cobranza, TiposReportes.SaldosPorClienteEnEfectivo, TiposReportes.SaldosPorClienteEnEnvase, TiposReportes.HistoricoPromedio
                    TabControlReportes.SelectedIndex = 1
                Case Else
                    TabControlReportes.SelectedIndex = 0
            End Select
        End If
    End Sub

    Private Sub ButtonContinuarReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarReporte.Click
        Me.Close()
    End Sub
#End Region

#Region "REPORTES"
    Private Sub ReporteCobranza(ByRef Sw As StreamWriter, ByVal Clientes As String)
        Try
            Dim Q As New System.Text.StringBuilder
            Dim sFiltroFecha As String = FechaConvertida("Dia.FechaCaptura")
            Dim Tmp As String

            Q.Append("Select distinct TRP.TransProdID, CLI.clienteclave, CLI.clave, CLI.nombrecorto, TRP.Folio, TRP.FechaHoraAlta,TRP.Total,TRP.Saldo,TRP.MonedaID, MON.Nombre ")
            Q.Append("from transprod TRP inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            Q.Append("inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave ")
            Q.Append("inner join Moneda MON on TRP.MonedaID = MON.MonedaID ")
            Q.Append("where ")
            If blnCobrarVentas Then
                Q.Append(" TRP.tipo=1 and TRP.tipofase <> 0 and TRP.Saldo>0 ")
            Else
                Q.Append(" TRP.tipo=8 and TRP.tipofase <> 0 and TRP.Saldo>0 ")
            End If

            If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                Q.Append("and VIS.clienteclave in(" & Clientes & ") ")
            End If
            Q.Append("order by TRP.MonedaID, CLI.Clave ")
            'Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' "
            Dim TablaClientes As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Cobranza")
            Q = Nothing

            Dim DtMonedas As DataTable = oDBVen.RealizarConsultaSQL("Select Nombre from Moneda order by MonedaId", "Monedas")

            'Dim dGranTotal As Double = 0
            Dim sClave As String = String.Empty
            Dim dSaldoCliente As Double = 0

            Dim aGranTotal As New Generic.Dictionary(Of String, Decimal)

            Dim sMonedaID As String = String.Empty
            Dim sNombreMoneda As String = String.Empty
            Dim blnCambioMoneda As Boolean = False
            For Each Dr As DataRow In TablaClientes.Rows
                blnCambioMoneda = False
                If sClave <> String.Empty AndAlso sClave <> Dr("Clave") Then
                    Sw.WriteLine()
                End If
                If sClave <> Dr("Clave") OrElse sMonedaID <> Dr("MonedaID") Then
                    '// clave y nombre cliente
                    If sClave <> String.Empty Then
                        Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSaldoTotal") & " " & sNombreMoneda & ":", 32, Alineacion.Derecha, False)
                        Tmp &= CompletaHasta(Format(dSaldoCliente, oApp.FormatoDinero), 16, Alineacion.Derecha, True)
                        Sw.WriteLine(Tmp)
                        Sw.WriteLine()
                        dSaldoCliente = 0
                    End If
                End If

                If sMonedaID <> Dr("MonedaID") Then
                    Sw.WriteLine(ValorReferencia.BuscarEquivalente("CDGOMON", Dr("MonedaID")) & "-" & Dr("Nombre"))
                    sMonedaID = Dr("MonedaID")
                    sNombreMoneda = Dr("Nombre")
                    blnCambioMoneda = True
                End If

                If sClave <> Dr("Clave") OrElse blnCambioMoneda Then
                    sClave = Dr("clave")
                    Tmp = CompletaHasta(Dr("clave"), 17, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(Dr("nombrecorto"), 31, Alineacion.Izquierda, True)
                    Sw.WriteLine(Tmp)
                End If
                Dim dTotalDevolucion As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select Total from TransProd where FacturaID = '" & Dr("TransProdID") & "' and Tipo=12 ")

                Dim sDetalle As New System.Text.StringBuilder
                sDetalle.Append(CompletaHasta(Dr("Folio"), 10, Alineacion.Izquierda, False))
                sDetalle.Append(CompletaHasta(Format(Dr("FechaHoraAlta"), "dd/MM/yyyy"), 11, Alineacion.Izquierda, False))
                sDetalle.Append(CompletaHasta(Format(IIf(IsDBNull(Dr("Total")), 0, Dr("Total") - dTotalDevolucion), oApp.FormatoDinero), 13, Alineacion.Derecha, False))


                sDetalle.Append(CompletaHasta(Format(Dr("saldo"), oApp.FormatoDinero), 14, Alineacion.Derecha, True))
                dSaldoCliente += Dr("saldo")
                'dGranTotal += Dr("saldo")
                If aGranTotal.ContainsKey(Dr("Nombre")) Then
                    aGranTotal(Dr("Nombre")) += Dr("saldo")
                Else
                    aGranTotal.Add(Dr("Nombre"), Dr("saldo"))
                End If
                Sw.WriteLine(sDetalle.ToString)
                sDetalle = Nothing
            Next

            If dSaldoCliente > 0 Then
                Sw.WriteLine()
                Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSaldoTotal") & " " & sNombreMoneda & ":", 32, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(Format(dSaldoCliente, oApp.FormatoDinero), 16, Alineacion.Derecha, True)
                Sw.WriteLine(Tmp)
                Sw.WriteLine()
                dSaldoCliente = 0
            End If

            TablaClientes.Dispose()
            ImprimeLineaPunteada(Sw, LongTot)
            For Each sMONNombre As String In aGranTotal.Keys
                Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 32, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(Format(Math.Round(aGranTotal(sMONNombre), 2), oApp.FormatoDinero), 16, Alineacion.Derecha, True)
                Sw.WriteLine(Tmp)
            Next
            'Sw.WriteLine(Tmp)
            EspaciosAlFinal(Sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteCobranza")
        End Try
    End Sub

    Private Sub ReporteResumenCobranza(ByRef Sw As StreamWriter, ByVal Clientes As String)
        Try
            'IMPORTANTE: Al modificar este reporte se acordó que solo funcionaria para cobranza BACKUS 
            'porque considera solo un abono por jornada y que el total del abono se aplica a un documento

            Dim Q As New System.Text.StringBuilder
            Dim Tmp As String

            Q.Append("select distinct TRP.TransProdID, TRP.MonedaID, MON.Nombre, CLI.clienteclave, CLI.clave, CLI.nombrecorto,TRP.Folio,TRP.Total as TotalDocto,TRP.CFVTipo, ")
            Q.Append("ABN.Total as TotalAbono, ABT.Importe, TRP.Saldo ")
            Q.Append("from transprod TRP ")
            Q.Append("inner join ABNTRP ABT on ABT.TransProdID = TRP.TransProdID ")
            Q.Append("inner join Abono ABN on ABN.ABNID = ABT.ABNID ")
            Q.Append("inner join Moneda MON on TRP.MonedaID = MON.MonedaID ")
            Q.Append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave and VIS.DiaClave = ABN.DiaClave ")
            Q.Append("inner join Cliente CLI on VIS.Clienteclave=CLI.ClienteClave ")
            Q.Append("where VIS.DiaClave='" & oDia.DiaActual & "' ")
            If blnCobrarVentas Then
                Q.Append(" and TRP.tipo=1 and TRP.tipofase <> 0 ")
            Else
                Q.Append(" and TRP.tipo=8 and TRP.tipofase <> 0 ")
            End If

            If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                Q.Append(" and VIS.clienteclave in(" & Clientes & ") ")
            End If
            Q.Append("order by TRP.MonedaID, CLI.Clave,TRP.Folio ")

            Dim TablaClientes As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "ResumenCobranza")
            Q = Nothing

            Dim sClave As String = String.Empty

            Dim dTotalCliente As Double = 0
            Dim dTotalAbonos As Double = 0

            'Dim sFolio As String = String.Empty
            Dim sMonedaID As String = String.Empty
            Dim sNombreMoneda As String = String.Empty

            Dim aGranTotal As New Generic.Dictionary(Of String, Decimal)
            Dim blnCambioMoneda As Boolean = False
            For Each Dr As DataRow In TablaClientes.Rows
                blnCambioMoneda = False
                If sClave <> Dr("Clave") OrElse sMonedaID <> Dr("MonedaID") Then
                    '// clave y nombre cliente
                    If sClave <> String.Empty Then
                        Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalAbonos") & " " & sNombreMoneda & ":", 32, Alineacion.Derecha, False)
                        Tmp &= CompletaHasta(Format(dTotalCliente, oApp.FormatoDinero), 16, Alineacion.Derecha, True)
                        Sw.WriteLine(Tmp)
                        Sw.WriteLine()
                        dTotalCliente = 0
                    End If
                End If
                If sClave <> String.Empty AndAlso sClave <> Dr("Clave") Then
                    Sw.WriteLine()
                End If

                If sMonedaID <> Dr("MonedaID") Then
                    blnCambioMoneda = True
                    Sw.WriteLine(ValorReferencia.BuscarEquivalente("CDGOMON", Dr("MonedaID")) & "-" & Dr("Nombre"))
                    sMonedaID = Dr("MonedaID")
                    sNombreMoneda = Dr("Nombre")
                End If
                If sClave <> Dr("Clave") OrElse blnCambioMoneda Then
                    sClave = Dr("clave")
                    Tmp = CompletaHasta(Dr("clave"), 17, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(Dr("nombrecorto"), 31, Alineacion.Izquierda, True)
                    Sw.WriteLine(Tmp)
                    'EspaciosAlFinal(Sw, 1)
                End If
                'If sFolio <> Dr("Folio") Then
                'sFolio = Dr("Folio")
                Dim sDetalle As String = ""
                Dim iCFVTipo As Integer = 0

                dTotalCliente += Dr("TotalAbono")
                dTotalAbonos += Dr("TotalAbono")

                If aGranTotal.ContainsKey(Dr("Nombre")) Then
                    aGranTotal(Dr("Nombre")) += Dr("TotalAbono")
                Else
                    aGranTotal.Add(Dr("Nombre"), Dr("TotalAbono"))
                End If

                iCFVTipo = IIf(IsDBNull(Dr("CFVTipo")), 0, Dr("CFVTipo"))

                Dim dTotalDevolucion As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select Total from TransProd where FacturaID = '" & Dr("TransProdID") & "' and Tipo=12 ")
                '//Folio y forma de venta
                sDetalle = Space(2) & CompletaHasta(String.Format("{0} {1}", Dr("folio"), IIf(iCFVTipo = 0, "", ValorReferencia.BuscarEquivalente("FVENTA", iCFVTipo))), 20, Alineacion.Izquierda, False)
                sDetalle &= CompletaHasta(Format(Dr("TotalDocto") - dTotalDevolucion, oApp.FormatoDinero), 13, Alineacion.Derecha, False)
                sDetalle &= CompletaHasta(Format(Dr("TotalAbono"), oApp.FormatoDinero), 13, Alineacion.Derecha, True)
                Sw.WriteLine(sDetalle)

                Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo") & ":", 21, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(Format(Dr("Saldo"), oApp.FormatoDinero), 13, Alineacion.Derecha, True)
                Sw.WriteLine(Tmp)
            Next
            If dTotalCliente > 0 Then
                'Sw.WriteLine()
                Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalAbonos") & " " & sNombreMoneda & ":", 32, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(Format(dTotalCliente, oApp.FormatoDinero), 16, Alineacion.Derecha, True)
                Sw.WriteLine(Tmp)
                Sw.WriteLine()
            End If

            TablaClientes.Dispose()
            ImprimeLineaPunteada(Sw, LongTot)
            For Each sMONNombre As String In aGranTotal.Keys
                Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 35, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(Format(Math.Round(aGranTotal(sMONNombre), 2), oApp.FormatoDinero), 13, Alineacion.Derecha, True)
                Sw.WriteLine(Tmp)
            Next
            EspaciosAlFinal(Sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteCobranza")
        End Try
    End Sub

    Private Sub ReporteCargas(ByRef sw As StreamWriter)
        Try
            Dim sCargaDescarga As String = ""
            Dim tTipoReporte As TiposReportes

            sCargaDescarga = refaVista.BuscarMensaje("Mensajes", "XCarga").ToUpper & " "
            tTipoReporte = TiposReportes.Cargas

            Dim Tmp As String
            Dim Total As Double = 0
            Dim i As Integer = 0
            Dim oHashTotales As New Hashtable
            Dim oHashTotalesCantidad As New Hashtable
            Dim oHashNombres As New Hashtable
            If RadioButtonDetallado.Checked Then ' DETALLADO
                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select distinct transprodid from transprod where tipo=2 and " & FechaConvertida("fechaCaptura", tTipoReporte), "Cargas")

                For Each Dr As DataRow In Dt.Rows
                    i += 1
                    sw.WriteLine(sCargaDescarga & i)
                    Dim Q As New System.Text.StringBuilder
                    Q.Append("select transproddetalle.productoclave, producto.nombre, tipounidad, SUM(cantidad) as Cantidad, sum(Cantidad1) as cantidad1 ")
                    Q.Append("from TransProd, transproddetalle, Producto ")
                    Q.Append("where transproddetalle.productoclave = Producto.ProductoClave ")
                    Q.Append("and transprod.transprodid=transproddetalle.transprodid ")
                    Q.Append("and transprod.transprodid='" & Dr("transprodid") & "' ")
                    Q.Append("group by productoclave, nombre, tipounidad")
                    Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "CargasDetalle")
                    Q = Nothing
                    Dim ClaveTmp As String = ""
                    For Each Dr2 As DataRow In Dt2.Rows
                        If Dr2("productoclave") <> ClaveTmp Then
                            If ClaveTmp <> "" Then
                                sw.WriteLine()
                            End If
                            ClaveTmp = Dr2("productoclave")
                            Tmp = Microsoft.VisualBasic.Left(Dr2("productoclave") & "-" & Dr2("nombre"), 48)
                            sw.WriteLine(Tmp)
                        End If
                        Tmp = CompletaHasta("", 15, Alineacion.Izquierda, False)
                        Tmp &= CompletaHasta("- " & ValorReferencia.BuscarEquivalente("UNIDADV", Dr2("tipounidad")), 17, Alineacion.Izquierda, False)
                        Tmp &= CompletaHasta(Format(Dr2("cantidad"), "##0.00"), 9, Alineacion.Derecha, False)
                        Tmp &= CompletaHasta(Dr2("cantidad1"), 7, Alineacion.Derecha, True)
                        sw.WriteLine(Tmp)
                        AgregaATotales(oHashTotales, Dr2("productoclave"), Format(Dr2("cantidad"), "##0.00"), Dr2("tipounidad"), Dr2("cantidad1"))
                        AgregaANombres(oHashNombres, Dr2("productoclave"), Dr2("nombre"))
                    Next
                    Dt2.Dispose()
                    sw.WriteLine()
                Next
                Dt.Dispose()
            ElseIf RadioButtonGeneral.Checked Then ' GENERAL
                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select distinct transprodid from transprod where tipo=2 and " & FechaConvertida("fechaCaptura", tTipoReporte), "Cargas")

                Dim dTotCarga As Decimal
                Dim dTotCargaCantidad As Decimal
                For Each Dr As DataRow In Dt.Rows
                    dTotCarga = 0
                    dTotCargaCantidad = 0
                    i += 1
                    sw.WriteLine(sCargaDescarga & i)
                    Dim Q As New System.Text.StringBuilder
                    Q.Append("select transproddetalle.productoclave, producto.nombre, tipounidad, SUM(cantidad) as Cantidad, SUM(cantidad1) as Cantidad1 ")
                    Q.Append("from TransProd, transproddetalle, Producto ")
                    Q.Append("where transproddetalle.productoclave = Producto.ProductoClave ")
                    Q.Append("and transprod.transprodid=transproddetalle.transprodid ")
                    Q.Append("and transprod.transprodid='" & Dr("transprodid") & "' ")
                    Q.Append("group by productoclave, nombre, tipounidad")
                    Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "CargasDetalle")
                    Q = Nothing
                    Dim ClaveTmp = "", NomProd As String = ""
                    Dim dTotProd As Decimal
                    Dim dTotProdCantidad As Decimal
                    For Each Dr2 As DataRow In Dt2.Rows
                        If ClaveTmp <> Dr2("productoclave") Then
                            If ClaveTmp <> Nothing Then
                                'Imprimo la linea cuando hay cambio de producto
                                Tmp = CompletaHasta(ClaveTmp & "-" & NomProd, 32, Alineacion.Izquierda, False)
                                Tmp &= CompletaHasta(Format(dTotProd, "##0.00"), 9, Alineacion.Derecha, False)
                                Tmp &= CompletaHasta(dTotProdCantidad, 7, Alineacion.Derecha, True)
                                sw.WriteLine(Tmp)
                            End If
                            dTotProd = 0
                            dTotProdCantidad = 0
                            ClaveTmp = Dr2("productoclave")
                            NomProd = Dr2("nombre")
                            AgregaANombres(oHashNombres, ClaveTmp, NomProd)
                        End If
                        dTotProd += Dr2("cantidad")
                        dTotCarga += Dr2("cantidad")
                        dTotProdCantidad += Dr2("cantidad1")
                        dTotCargaCantidad += Dr2("cantidad1")
                        AgregaATotales(oHashTotales, ClaveTmp, Format(Dr2("cantidad"), "##0.00"), Dr2("tipounidad"), Dr2("cantidad1"))
                    Next
                    Dt2.Dispose()
                    'Se imprime la última línea de productos
                    Tmp = CompletaHasta(ClaveTmp & "-" & NomProd, 32, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(Format(dTotProd, "##0.00"), 9, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(dTotProdCantidad, 7, Alineacion.Derecha, True)
                    sw.WriteLine(Tmp)
                    'Se imprime el total de productos de la carga actual
                    Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 32, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(Format(dTotCarga, "##0.00"), 9, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(dTotCargaCantidad, 7, Alineacion.Derecha, True)
                    sw.WriteLine(Tmp)
                    sw.WriteLine()
                    ClaveTmp = Nothing
                Next
                Dt.Dispose()
            End If
            ImprimeLineaPunteada(sw, LongTot)
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XResumen"), LongTot))
            ImprimeTotales(oHashTotales, oHashNombres, sw)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteCargasDescargas")
        End Try
    End Sub
    Private Sub ReporteDescargasyDevoluciones(ByRef sw As StreamWriter)
        Try
            Dim sCargaDescarga As String = ""
            Dim tTipoReporte As TiposReportes

            'If TipoReporte = 2 Then
            '    sCargaDescarga = refaVista.BuscarMensaje("Mensajes", "XCarga").ToUpper & " "
            '    tTipoReporte = TiposReportes.Cargas
            'ElseIf TipoReporte = 7 Then
            '    sCargaDescarga = refaVista.BuscarMensaje("Mensajes", "XDescarga").ToUpper & " "
            '    tTipoReporte = TiposReportes.Descargas
            'End If

            Dim Tmp As String
            Dim TotalDescargaP As Double = 0
            Dim TotalDescargaE As Double = 0
            Dim TotalDescargaCantidad As Double = 0
            Dim TotalDevolucionP As Double = 0
            Dim TotalDevolucionE As Double = 0
            Dim TotalDevolucionCantidad As Double = 0

            Dim bprimerregistroi As Integer = 0
            Dim oHashTotales As New Hashtable
            Dim oHashNombres As New Hashtable
            Dim oHashTotalesDes As New Hashtable
            Dim oHashNombresDes As New Hashtable
            Dim oHashTotalesDev As New Hashtable
            Dim oHashNombresDev As New Hashtable
            Dim oHashTotalesDesEnvase As New Hashtable
            Dim oHashNombresDesEnvase As New Hashtable
            Dim oHashTotalesDevEnvase As New Hashtable
            Dim oHashNombresDevEnvase As New Hashtable


            If RadioButtonDetallado.Checked Then ' DETALLADO
                Dim Q As New System.Text.StringBuilder
                Q.Append("select  t.transprodid,t.tipo,t.folio,sum(TD.Cantidad) as cantidad,sum(TD.Cantidad1) as cantidad1 ")
                Q.Append("from transprod t ")
                Q.Append("inner join transproddetalle td on td.transprodid=t.transprodid ")
                Q.Append("inner join producto p on td.ProductoClave = P.ProductoClave ")
                Q.Append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and td.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
                Q.Append("where t.tipo in (7,4) AND T.TipoFase <> 0  and  " & IIf(CheckBoxFecha.Checked, FechaConvertida("fechaCaptura", tTipoReporte), " diaclave in(" & diaClavesEnFrecuencia() & ")") & "  ")
                Q.Append("group by  t.transprodid,t.tipo,t.folio ")
                Q.Append("order by t.tipo desc ")


                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString(), "Cargas")

                For Each Dr As DataRow In Dt.Rows

                    If Dr("tipo") = 7 Then
                        TotalDescargaP += Dr("cantidad")
                        TotalDescargaCantidad += Dr("cantidad1")
                        Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescarga"), 18, Alineacion.Izquierda, False)
                    Else
                        TotalDevolucionP += Dr("cantidad")
                        TotalDevolucionCantidad += Dr("cantidad1")
                        Tmp = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDevolucion"), 18, Alineacion.Izquierda, False)
                    End If

                    Tmp &= CompletaHasta(Dr("folio"), 14, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(Format(Dr("cantidad"), "##0.00"), 9, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(Dr("cantidad1"), 7, Alineacion.Derecha, True)

                    sw.WriteLine(Tmp)

                    Q = New System.Text.StringBuilder
                    Q.Append("select transproddetalle.productoclave, producto.nombre, tipounidad, SUM(cantidad) as Cantidad, SUM(cantidad1) as Cantidad1 ")
                    Q.Append("from TransProd, transproddetalle, Producto ")
                    Q.Append("where transproddetalle.productoclave = Producto.ProductoClave ")
                    Q.Append("and transprod.transprodid=transproddetalle.transprodid ")
                    Q.Append("and transprod.transprodid='" & Dr("transprodid") & "' ")
                    Q.Append("group by productoclave, nombre, tipounidad")
                    Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "CargasDetalle")
                    Q = Nothing
                    Dim ClaveTmp As String = ""
                    For Each Dr2 As DataRow In Dt2.Rows
                        If Dr2("productoclave") <> ClaveTmp Then
                            If ClaveTmp <> "" Then
                                sw.WriteLine()
                            End If
                            ClaveTmp = Dr2("productoclave")
                            Tmp = CompletaHasta(Dr2("productoclave"), 11, Alineacion.Izquierda, False)
                            Tmp &= CompletaHasta(Dr2("nombre"), 37, Alineacion.Izquierda, True)
                            sw.WriteLine(Tmp)
                        End If
                        Tmp = CompletaHasta("", 12, Alineacion.Izquierda, False)
                        Tmp &= CompletaHasta("- " & ValorReferencia.BuscarEquivalente("UNIDADV", Dr2("tipounidad")), 20, Alineacion.Izquierda, False)
                        Tmp &= CompletaHasta(Format(Dr2("cantidad"), "##0.00"), 9, Alineacion.Derecha, False)
                        Tmp &= CompletaHasta(Dr2("cantidad1"), 7, Alineacion.Derecha, True)
                        sw.WriteLine(Tmp)

                        If Dr("tipo") = 7 Then


                            AgregaATotales(oHashTotalesDes, Dr2("productoclave"), Format(Dr2("cantidad"), "##0.00"), Dr2("tipounidad"), Dr2("Cantidad1"))
                            AgregaANombres(oHashNombresDes, Dr2("productoclave"), Dr2("nombre"))
                        Else
                            AgregaATotales(oHashTotalesDev, Dr2("productoclave"), Format(Dr2("cantidad"), "##0.00"), Dr2("tipounidad"), Dr2("Cantidad1"))
                            AgregaANombres(oHashNombresDev, Dr2("productoclave"), Dr2("nombre"))
                        End If
                        
                    Next

                    Dt2.Dispose()
                    sw.WriteLine()
                Next

                ''-------------*************************EnvasesDetalle

                'Q = New System.Text.StringBuilder
                'Q.Append("select  t.transprodid,t.tipo,t.folio,sum(TD.Cantidad) as cantidad ")
                'Q.Append("from transprod t ")
                'Q.Append("inner join transproddetalle td on td.transprodid=t.transprodid ")
                'Q.Append("inner join producto p on td.ProductoClave = P.ProductoClave ")
                'Q.Append("inner join ProductoDetalle PRD on p.ProductoClave = PRD.ProductoClave and td.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
                'Q.Append("where p.contenido=1 and t.tipo in (7,4) and  " & IIf(CheckBoxFecha.Checked, FechaConvertida("fechaCaptura", tTipoReporte), " diaclave in(" & diaClavesEnFrecuencia() & ")") & "  ")
                'Q.Append("group by  t.transprodid,t.tipo,t.folio ")
                'Q.Append("order by t.tipo desc ")

                'Dt = oDBVen.RealizarConsultaSQL(Q.ToString(), "Cargas")

                'If Dt.Rows.Count > 0 Then
                '    Dim cad As String
                '    ImprimeLineaPunteada(sw, LongTot)
                '    cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XEnvase"), 20, Alineacion.Izquierda, False)
                '    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 20, Alineacion.Izquierda, False)
                '    cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 8, Alineacion.Derecha, True)
                '    sw.WriteLine(cad)
                '    ImprimeLineaPunteada(sw, LongTot)
                'End If

                'For Each Dr As DataRow In Dt.Rows

                '    If Dr("tipo") = 7 Then
                '        TotalDescargaE += Dr("cantidad")
                '        Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescarga"), 18, Alineacion.Izquierda, False)
                '    Else
                '        TotalDevolucionE += Dr("cantidad")
                '        'Tmp = CompletaHasta(ValorReferencia.BuscarEquivalente("TRPTIPO", Dr("tipo")), 18, Alineacion.Izquierda, False)
                '        Tmp = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDevolucion"), 18, Alineacion.Izquierda, False)
                '    End If

                '    Tmp &= CompletaHasta(Dr("folio"), 15, Alineacion.Izquierda, False)
                '    Tmp &= CompletaHasta(Dr("cantidad"), 15, Alineacion.Derecha, True)
                '    sw.WriteLine(Tmp)

                '    Q = New System.Text.StringBuilder
                '    Q.Append("select transproddetalle.productoclave, producto.nombre, tipounidad, SUM(cantidad) as Cantidad ")
                '    Q.Append("from TransProd, transproddetalle, Producto ")
                '    Q.Append("where producto.contenido=1 and transproddetalle.productoclave = Producto.ProductoClave ")
                '    Q.Append("and transprod.transprodid=transproddetalle.transprodid ")
                '    Q.Append("and transprod.transprodid='" & Dr("transprodid") & "' ")
                '    Q.Append("group by productoclave, nombre, tipounidad")
                '    Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "CargasDetalle")
                '    Q = Nothing
                '    Dim ClaveTmp As String = ""
                '    For Each Dr2 As DataRow In Dt2.Rows
                '        If Dr2("productoclave") <> ClaveTmp Then
                '            If ClaveTmp <> "" Then
                '                sw.WriteLine()
                '            End If
                '            ClaveTmp = Dr2("productoclave")
                '            Tmp = CompletaHasta(Dr2("productoclave"), 11, Alineacion.Izquierda, False)
                '            Tmp &= CompletaHasta(Dr2("nombre"), 37, Alineacion.Izquierda, True)
                '            sw.WriteLine(Tmp)
                '        End If
                '        Tmp = CompletaHasta("", 15, Alineacion.Izquierda, False)
                '        Tmp &= CompletaHasta("- " & ValorReferencia.BuscarEquivalente("UNIDADV", Dr2("tipounidad")), 20, Alineacion.Izquierda, False)
                '        Tmp &= CompletaHasta(Dr2("cantidad"), 13, Alineacion.Derecha, True)
                '        sw.WriteLine(Tmp)

                '        If Dr("tipo") = 7 Then
                '            AgregaATotales(oHashTotalesDesEnvase, Dr2("productoclave"), Dr2("cantidad"), Dr2("tipounidad"))
                '            AgregaANombres(oHashNombresDesEnvase, Dr2("productoclave"), Dr2("nombre"))
                '        Else
                '            AgregaATotales(oHashTotalesDevEnvase, Dr2("productoclave"), Dr2("cantidad"), Dr2("tipounidad"))
                '            AgregaANombres(oHashNombresDevEnvase, Dr2("productoclave"), Dr2("nombre"))
                '        End If
                '    Next
                '    Dt2.Dispose()
                '    sw.WriteLine()
                'Next
                'Dt.Dispose()
            ElseIf RadioButtonGeneral.Checked Then ' GENERAL
                Dim Q As New System.Text.StringBuilder
                Q.Append("select  t.transprodid,t.tipo,t.folio,sum(TD.Cantidad) as cantidad,sum(TD.Cantidad1) as cantidad1 ")
                Q.Append("from transprod t ")
                Q.Append("inner join transproddetalle td on td.transprodid=t.transprodid ")
                Q.Append("inner join producto p on td.ProductoClave = P.ProductoClave ")
                Q.Append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and td.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
                Q.Append("where t.tipo in (7,4) AND T.TipoFase <> 0  and  " & IIf(CheckBoxFecha.Checked, FechaConvertida("fechaCaptura", tTipoReporte), " diaclave in(" & diaClavesEnFrecuencia() & ")") & "  ")
                Q.Append("group by  t.transprodid,t.tipo,t.folio ")
                Q.Append("order by t.tipo desc ")


                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString(), "Cargas")

                For Each Dr As DataRow In Dt.Rows

                    If Dr("tipo") = 7 Then
                        TotalDescargaP += Dr("cantidad")
                        TotalDescargaCantidad += Dr("cantidad1")
                        Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescarga"), 18, Alineacion.Izquierda, False)
                    Else
                        TotalDevolucionP += Dr("cantidad")
                        TotalDevolucionCantidad += Dr("cantidad1")
                        Tmp = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDevolucion"), 18, Alineacion.Izquierda, False)
                    End If

                    Tmp &= CompletaHasta(Dr("folio"), 14, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(Format(Dr("cantidad"), "##0.00"), 9, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(Dr("cantidad1"), 7, Alineacion.Derecha, True)

                    sw.WriteLine(Tmp)

                    Q = New System.Text.StringBuilder
                    Q.Append("select transproddetalle.productoclave, producto.nombre, tipounidad, SUM(cantidad) as Cantidad, SUM(cantidad1) as Cantidad1 ")
                    Q.Append("from TransProd, transproddetalle, Producto,productodetalle ")
                    Q.Append("where transproddetalle.productoclave = Producto.ProductoClave ")
                    Q.Append("and  producto.ProductoClave = productodetalle.ProductoClave and transproddetalle.TipoUnidad = productodetalle.PRUTipoUnidad and productodetalle.ProductoClave = productodetalle.ProductoDetClave ")
                    Q.Append("and transprod.transprodid=transproddetalle.transprodid ")
                    Q.Append("and transprod.transprodid='" & Dr("transprodid") & "' ")
                    Q.Append("group by productoclave, nombre, tipounidad")
                    Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "CargasDetalle")
                    Q = Nothing
                    Dim ClaveTmp As String = ""
                    Dim productonombre As String = ""
                    Dim totalcant As Double = 0
                    Dim totalcant1 As Double = 0

                    For Each Dr2 As DataRow In Dt2.Rows
                        If Dr2("productoclave") <> ClaveTmp Then
                            If ClaveTmp <> "" Then

                                Tmp = CompletaHasta(ClaveTmp, 11, Alineacion.Izquierda, False)
                                Tmp &= CompletaHasta(productonombre, 21, Alineacion.Izquierda, False)
                                Tmp &= CompletaHasta(Format(totalcant, "##0.00"), 9, Alineacion.Derecha, False)
                                Tmp &= CompletaHasta(totalcant1, 7, Alineacion.Derecha, True)
                                sw.WriteLine(Tmp)
                            End If


                            totalcant = 0
                            totalcant1 = 0
                            ClaveTmp = Dr2("productoclave")
                            productonombre = Dr2("nombre")
                            AgregaANombres(oHashNombresDes, ClaveTmp, productonombre)

                        End If

                        totalcant += Dr2("Cantidad")
                        totalcant1 += Dr2("Cantidad1")
                        AgregaATotales(oHashTotalesDes, ClaveTmp, Format(Dr2("cantidad"), "##0.00"), Dr2("tipounidad"), Dr2("Cantidad1"))
                    Next
                    Tmp = CompletaHasta(ClaveTmp, 11, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(productonombre, 21, Alineacion.Izquierda, False)
                    Tmp &= CompletaHasta(Format(totalcant, "##0.00"), 9, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(totalcant1, 7, Alineacion.Derecha, True)
                    sw.WriteLine(Tmp)

                    Dt2.Dispose()
                    sw.WriteLine()
                    ClaveTmp = ""
                Next

                '    '-------------*************************EnvasesDetalle

                '    Q = New System.Text.StringBuilder
                '    Q.Append("select  t.transprodid,t.tipo,t.folio,sum(TD.Cantidad) as cantidad ")
                '    Q.Append("from transprod t ")
                '    Q.Append("inner join transproddetalle td on td.transprodid=t.transprodid ")
                '    Q.Append("inner join producto p on td.ProductoClave = P.ProductoClave ")
                '    Q.Append("inner join ProductoDetalle PRD on p.ProductoClave = PRD.ProductoClave and td.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
                '    Q.Append("where p.contenido=1 and t.tipo in (7,4) and  " & IIf(CheckBoxFecha.Checked, FechaConvertida("fechaCaptura", tTipoReporte), " diaclave in(" & diaClavesEnFrecuencia() & ")") & "  ")
                '    Q.Append("group by  t.transprodid,t.tipo,t.folio ")
                '    Q.Append("order by t.tipo desc ")


                '    Dt = oDBVen.RealizarConsultaSQL(Q.ToString(), "Cargas")

                '    If Dt.Rows.Count > 0 Then
                '        Dim cad As String
                '        ImprimeLineaPunteada(sw, LongTot)
                '        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XEnvase"), 40, Alineacion.Izquierda, False)
                '        cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 8, Alineacion.Derecha, True)
                '        sw.WriteLine(cad)
                '        ImprimeLineaPunteada(sw, LongTot)
                '    End If

                '    For Each Dr As DataRow In Dt.Rows

                '        If Dr("tipo") = 7 Then
                '            TotalDescargaE += Dr("cantidad")
                '            Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescarga"), 18, Alineacion.Izquierda, False)
                '        Else
                '            TotalDevolucionE += Dr("cantidad")

                '            Tmp = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDevolucion"), 18, Alineacion.Izquierda, False)
                '        End If

                '        Tmp &= CompletaHasta(Dr("folio"), 15, Alineacion.Izquierda, False)
                '        Tmp &= CompletaHasta(Dr("cantidad"), 15, Alineacion.Derecha, True)
                '        sw.WriteLine(Tmp)

                '        Q = New System.Text.StringBuilder
                '        Q.Append("select transproddetalle.productoclave, producto.nombre, tipounidad, SUM(cantidad) as Cantidad ")
                '        Q.Append("from TransProd, transproddetalle, Producto,productodetalle ")
                '        Q.Append("where producto.contenido=1 and transproddetalle.productoclave = Producto.ProductoClave ")
                '        Q.Append("and  producto.ProductoClave = productodetalle.ProductoClave and transproddetalle.TipoUnidad = productodetalle.PRUTipoUnidad and productodetalle.ProductoClave = productodetalle.ProductoDetClave ")
                '        Q.Append("and transprod.transprodid=transproddetalle.transprodid ")
                '        Q.Append("and transprod.transprodid='" & Dr("transprodid") & "' ")
                '        Q.Append("group by productoclave, nombre, tipounidad ")
                '        Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "CargasDetalle")
                '        Q = Nothing
                '        Dim ClaveTmp As String = ""
                '        Dim productonombre As String = ""
                '        Dim totalcant As Double = 0

                '        For Each Dr2 As DataRow In Dt2.Rows
                '            If Dr2("productoclave") <> ClaveTmp Then
                '                If ClaveTmp <> "" Then

                '                    Tmp = CompletaHasta(ClaveTmp, 11, Alineacion.Izquierda, False)
                '                    Tmp &= CompletaHasta(productonombre, 27, Alineacion.Izquierda, False)
                '                    Tmp &= CompletaHasta(totalcant, 10, Alineacion.Derecha, True)
                '                    sw.WriteLine(Tmp)
                '                End If


                '                totalcant = 0
                '                ClaveTmp = Dr2("productoclave")
                '                productonombre = Dr2("nombre")
                '                AgregaANombres(oHashNombresDes, ClaveTmp, productonombre)

                '            End If

                '            totalcant += Dr2("Cantidad")
                '            AgregaATotales(oHashTotalesDes, ClaveTmp, Dr2("cantidad"), Dr2("tipounidad"))
                '        Next
                '        Tmp = CompletaHasta(ClaveTmp, 11, Alineacion.Izquierda, False)
                '        Tmp &= CompletaHasta(productonombre, 27, Alineacion.Izquierda, False)
                '        Tmp &= CompletaHasta(totalcant, 10, Alineacion.Derecha, True)
                '        sw.WriteLine(Tmp)

                '        Dt2.Dispose()
                '        sw.WriteLine()
                '        ClaveTmp = ""
                '    Next

                '    Dt.Dispose()


            End If



            ImprimeLineaPunteada(sw, LongTot)
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XResumen"), LongTot))
            ImprimeLineaPunteada(sw, LongTot)
            If RadioButtonDetallado.Checked Then
                If TotalDevolucionP + TotalDescargaP > 0 Then
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XProducto").ToUpper, LongTot))
                    sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XDescarga"))
                    ImprimeTotales(oHashTotalesDes, oHashNombresDes, sw)
                    Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToLower & ": " & Format(TotalDescargaP, "##0.00"), 41, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(TotalDescargaCantidad, 7, Alineacion.Derecha, True)
                    sw.WriteLine(Tmp)
                    'sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToLower & ": " & TotalDescargaP & " " & TotalDescargaCantidad, 48, Alineacion.Derecha, True))


                    sw.WriteLine()
                    sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XDevolucion"))
                    ImprimeTotales(oHashTotalesDev, oHashNombresDev, sw)
                    Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToLower & ": " & Format(TotalDevolucionP, "##0.00"), 41, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(TotalDevolucionCantidad, 7, Alineacion.Derecha, True)
                    sw.WriteLine(Tmp)
                    'sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToLower & ": " & TotalDevolucionP & " " & TotalDevolucionCantidad, 48, Alineacion.Derecha, True))

                    Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToUpper & ": " & Format(TotalDevolucionP + TotalDescargaP, "##0.00"), 41, Alineacion.Derecha, False)
                    Tmp &= CompletaHasta(TotalDescargaCantidad + TotalDevolucionCantidad, 7, Alineacion.Derecha, True)
                    sw.WriteLine(Tmp)
                    'sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToUpper & ": " & TotalDevolucionP + TotalDescargaP & " " & TotalDescargaCantidad + TotalDevolucionCantidad, 48, Alineacion.Derecha, True))

                End If

                If TotalDevolucionE + TotalDescargaE > 0 Then
                    sw.WriteLine()
                    sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBox", "XEnvase").ToUpper(), LongTot))
                    sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XDescarga"))
                    ImprimeTotales(oHashTotalesDesEnvase, oHashNombresDesEnvase, sw)
                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToLower & ": " & TotalDescargaE, 48, Alineacion.Derecha, True))

                    sw.WriteLine()
                    sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XDevolucion"))
                    ImprimeTotales(oHashTotalesDevEnvase, oHashNombresDevEnvase, sw)
                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToLower & ": " & TotalDevolucionE, 48, Alineacion.Derecha, True))

                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToUpper & ": " & TotalDescargaE + TotalDevolucionE, 48, Alineacion.Derecha, True))


                End If

            Else
                ImprimeTotales(oHashTotalesDes, oHashNombresDes, sw)
                'Tmp = CompletaHasta(ClaveTmp, 11, Alineacion.Izquierda, False)
                'Tmp &= CompletaHasta(productonombre, 27, Alineacion.Izquierda, False)
                'Tmp &= CompletaHasta(totalcant, 10, Alineacion.Derecha, True)
                'sw.WriteLine(Tmp)
                Tmp = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ": " & Format(TotalDescargaP + TotalDescargaE + TotalDevolucionE + TotalDevolucionP, "##0.00"), 41, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(TotalDevolucionCantidad + TotalDescargaCantidad, 7, Alineacion.Derecha, True)
                sw.WriteLine(Tmp)
                'sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ": " & TotalDescargaP + TotalDescargaE + TotalDevolucionE + TotalDevolucionP & " " & TotalDevolucionCantidad + TotalDescargaCantidad, 48, Alineacion.Derecha, True))

                sw.WriteLine()
                sw.WriteLine()

                Tmp = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDescargas") & ": " & TotalDescargaP + TotalDescargaE, 41, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(TotalDescargaCantidad, 7, Alineacion.Derecha, True)
                sw.WriteLine(Tmp)

                Tmp = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDevoluciones") & ": " & TotalDevolucionE + TotalDevolucionP, 41, Alineacion.Derecha, False)
                Tmp &= CompletaHasta(TotalDevolucionCantidad, 7, Alineacion.Derecha, True)
                sw.WriteLine(Tmp)
                'sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDescargas") & ": " & TotalDescargaP + TotalDescargaE & " " & TotalDescargaCantidad, 48, Alineacion.Derecha, True))
                'sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDevoluciones") & ": " & TotalDevolucionE + TotalDevolucionP & " " & TotalDevolucionCantidad, 48, Alineacion.Derecha, True))
            End If


            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteCargasDescargas")
        End Try
    End Sub

    Private Sub ReporteInventario(ByRef sw As StreamWriter)
        Try
            Dim sConsulta As String = String.Empty
            Dim dtProductos As DataTable
            Dim dTotalExistencia As Decimal = 0
            Dim dTotalDisponible As Decimal = 0
            Dim dTotalApartado As Decimal = 0
            Dim dTotalExistenciaCantidad As Decimal = 0
            Dim dTotalDisponibleCantidad As Decimal = 0
            Dim dTotalApartadoCantidad As Decimal = 0
            'Dim dTotalUnidad As Decimal = 0
            Dim sCadena As String = String.Empty
            Dim sProducto As String = String.Empty
            Dim sProdAnt As String = String.Empty
            Dim dExistenciaAnt As Decimal = 0


            sConsulta = "select distinct PRO.productoclave, PRO.nombre, INV.TipoUnidad, sum(INV.disponible) as Disponible, sum(INV.Apartado) as Apartado, sum(INV.Cantidad) as Cantidad, sum(INV.Apartado1) as Apartado1 "
            sConsulta &= "from SKUInventario INV "
            sConsulta &= "inner join producto PRO on PRO.productoclave=INV.productoclave "
            sConsulta &= "where INV.disponible>0 or INV.apartado > 0 or INV.Cantidad > 0 or INV.Apartado1 > 0 "
            sConsulta &= "group by PRO.productoclave, PRO.nombre, INV.TipoUnidad "
            sConsulta &= "order by  PRO.ProductoClave,PRO.Nombre desc "

            dtProductos = oDBVen.RealizarConsultaSQL(sConsulta, "Inventario")
            For Each drProducto As DataRow In dtProductos.Rows
                If Me.CheckBoxTotalizar.Checked Then
                    dExistenciaAnt = drProducto("Disponible")
                End If
                If sProdAnt <> drProducto("ProductoClave") Then

                    sCadena = String.Empty
                    sProducto = Microsoft.VisualBasic.Left(CStr(drProducto("productoClave")) & "-" & CStr(drProducto("nombre")), 48)

                    sCadena = sCadena & CompletaHasta(sProducto, 48, Alineacion.Izquierda, False)

                    If Me.RadioButtonDetallado.Checked And sProdAnt <> String.Empty Then sw.WriteLine()
                    sw.WriteLine(sCadena)
                End If
                sProdAnt = drProducto("ProductoClave")

                dTotalExistencia += drProducto("Disponible")
                dTotalDisponible += IIf(drProducto("Disponible") - drProducto("Apartado") < 0, 0, drProducto("Disponible") - drProducto("Apartado"))
                dTotalApartado += drProducto("Apartado")
                dTotalExistenciaCantidad += drProducto("Cantidad")
                dTotalDisponibleCantidad += IIf(drProducto("Cantidad") - drProducto("Apartado1") < 0, 0, drProducto("Cantidad") - drProducto("Apartado1"))
                dTotalApartadoCantidad += drProducto("Apartado1")

                sCadena = "   " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", drProducto("TipoUnidad")), 18, Alineacion.Izquierda, False)

                sCadena = sCadena & CompletaHasta(Format(drProducto("Disponible"), "##0.00"), 9, Alineacion.Derecha, False)
                sCadena = sCadena & CompletaHasta(Format(drProducto("Apartado"), "##0.00"), 9, Alineacion.Derecha, False)
                sCadena = sCadena & CompletaHasta(Format(drProducto("Disponible") - drProducto("Apartado"), "##0.00"), 9, Alineacion.Derecha, True)

                sw.WriteLine(sCadena)

                sCadena = "   " & CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XElemento"), 18, Alineacion.Izquierda, False)
                sCadena = sCadena & CompletaHasta(drProducto("Cantidad"), 9, Alineacion.Derecha, False)
                sCadena = sCadena & CompletaHasta(drProducto("Apartado1"), 9, Alineacion.Derecha, False)
                sCadena = sCadena & CompletaHasta(drProducto("Cantidad") - drProducto("Apartado1"), 9, Alineacion.Derecha, True)
                sw.WriteLine(sCadena)
            Next

            ImprimeLineaPunteada(sw, LongTot)
            sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalProductos") & ":", 21, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(Format(dTotalExistencia, "##0.00"), 9, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(Format(dTotalApartado, "##0.00"), 9, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(Format(dTotalDisponible, "##0.00"), 9, Alineacion.Derecha, True)
            sw.WriteLine(sCadena)

            sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalElementos") & ":", 21, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(dTotalExistenciaCantidad, 9, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(dTotalApartadoCantidad, 9, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(dTotalDisponibleCantidad, 9, Alineacion.Derecha, True)
            sw.WriteLine(sCadena)

            sCadena = String.Empty
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteInventario")
        End Try
    End Sub

    Private Sub ReporteEfectividadPorRuta(ByRef sw As StreamWriter)
        Try
            Dim Cad As String = String.Empty
            'Delimitador(True, sw)
            Dim dtRutasClientes As DataTable

            Dim Q As New System.Text.StringBuilder
            Q.Append("select AGE.RUTClave as RUTClave, AGE.ClienteClave, CTE.RazonSocial, ")
            Q.Append("sum((case when VIS.VisitaClave is null then 0 else 1 end)) as Visitado, ")
            Q.Append("sum((case when TRP.TransProdId is null then 0 else 1 end)) as Compras, 1 as Agendado ")
            Q.Append("from Agenda AGE ")
            Q.Append("inner join Cliente CTE on AGE.ClienteClave = CTE.ClienteClave ")
            Q.Append("inner join Dia on AGE.DiaClave = Dia.DiaClave ")
            Q.Append("left join Visita VIS on CTE.ClienteClave = VIS.ClienteClave and AGE.VendedorId = VIS.VendedorId ")
            Q.Append("and VIS.DiaClave = Dia.DiaClave and convert(nvarchar(10), VIS.FechaHoraInicial, 112) = convert(nvarchar(10), Dia.FechaCaptura, 112) ")
            Q.Append("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            Q.Append("where AGE.VendedorId = '" & oVendedor.VendedorId & "' and AGE.DiaClave = '" & oDia.DiaActual & "' ")
            Q.Append("group by AGE.RUTClave, AGE.ClienteClave, CTE.RazonSocial ")
            Q.Append("union all ")
            Q.Append("select VIS.RUTClave as RUTClave, VIS.ClienteClave, CTE.RazonSocial, sum(1) as Visitado, ")
            Q.Append("sum((case when TRP.TransProdId is null then 0 else 1 end)) as Compras, 0 as Agendado ")
            Q.Append("from Visita VIS ")
            Q.Append("inner join Cliente CTE on VIS.ClienteClave = CTE.ClienteClave ")
            Q.Append("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            Q.Append("where VIS.VendedorId = '" & oVendedor.VendedorId & "' and VIS.DiaClave = '" & oDia.DiaActual & "' and vis.clienteclave not in(select clienteclave from agenda where diaclave ='" + oDia.DiaActual + "')")
            Q.Append("group by VIS.RUTClave, VIS.ClienteClave, CTE.RazonSocial ")
            Q.Append("order by RUTClave ")
            dtRutasClientes = oDBVen.RealizarConsultaSQL(Q.ToString, "Clientes")

            Dim drRuta As DataRow
            Dim sRUTClave As String = String.Empty
            For Each drRuta In dtRutasClientes.Rows
                If sRUTClave <> drRuta("RUTClave") Then
                    sRUTClave = drRuta("RUTClave")

                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XRuta") & ": " & sRUTClave, 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                    sw.WriteLine()

                    Dim aVisitadosRuta() As DataRow = dtRutasClientes.Select("RUTClave='" & sRUTClave & "' and Visitado > 0")

                    If RadioButtonDetallado.Checked Then
                        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCliente"), 38, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XEncuesta"), 10, Alineacion.Derecha, True)
                        sw.WriteLine(Cad)
                        ImprimeLineaPunteada(sw, LongTot)

                        Dim dtEncuestados As DataTable = oDBVen.RealizarConsultaSQL("SELECT distinct V.ClienteClave FROM Encuesta as E inner join Visita V ON E.VisitaClave = V.VisitaClave WHERE V.DiaClave='" & oDia.DiaActual & "' and  V.RUTClave='" & sRUTClave & "'", "Encuestados")

                        For Each Dr As DataRow In aVisitadosRuta
                            Cad = CompletaHasta(Dr("razonsocial"), 38, Alineacion.Izquierda, False)
                            If dtEncuestados.Select("ClienteClave='" & Dr("ClienteClave") & "'").Length > 0 Then
                                Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSi"), 10, Alineacion.Derecha, True)
                            Else
                                Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XNo"), 10, Alineacion.Derecha, True)
                            End If
                            sw.WriteLine(Cad)
                        Next
                        dtEncuestados.Dispose()
                        ImprimeLineaPunteada(sw, LongTot)

                    End If
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCant."), 38, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPorcent."), 10, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    ImprimeLineaPunteada(sw, LongTot)
                    DetalleEfectividadPorRuta(sw, dtRutasClientes, sRUTClave, True)
                    ImprimeLineaPunteada(sw, LongTot)
                    DetalleEfectividadPorRuta(sw, dtRutasClientes, sRUTClave, False)
                    ImprimeLineaPunteada(sw, LongTot)
                    drRuta = Nothing
                End If
            Next 'For por cada Ruta
            dtRutasClientes.Dispose()

            ''Descripcion de los motivos de improductividad (MOTIMPRO)
            'sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XMotivo") & ":")
            'Dim aValores As ArrayList = ValorReferencia.RecuperarLista("MOTIMPRO")
            'For Each refDesc As ValorReferencia.Descripcion In aValores
            '    sw.WriteLine(refDesc.Id & " = " & refDesc.Cadena)
            'Next
            'aValores = Nothing
            ''For Each dr3 As DataRow In ValorReferencia.RecuperarLista("MOTIMPRO").Rows
            ''    sw.WriteLine(dr3(0) & " = " & dr3(1))
            ''Next

            'Espacios en blanco
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "EfectividadPorRuta")
        End Try
    End Sub

    Private Sub DetalleEfectividadPorRuta(ByRef sw As StreamWriter, ByVal dtRutasClientes As DataTable, ByVal sRUTClave As String, ByVal bAgendado As Boolean)
        Dim Cad As String
        Dim sConsulta As String
        If bAgendado Then
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XClienteAgenda").ToUpper, LongTot))
        Else
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XClienteFueraAgenda").ToUpper, LongTot))
        End If
        'Visitados y No visitados
        sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XClientes").ToUpper)

        'SeleccionarClientesVisitados
        Dim TotalClientes, NoVisitados, Visitados As Integer
        Visitados = dtRutasClientes.Select("RUTClave='" & sRUTClave & "' and Visitado > 0 and Agendado = " & bAgendado).Length
        TotalClientes = dtRutasClientes.Select("RUTClave='" & sRUTClave & "' and Agendado = " & bAgendado).Length
        If bAgendado Then
            NoVisitados = TotalClientes - Visitados
        End If

        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XVisitados"), 28, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(Visitados, 10, Alineacion.Derecha, False)
        If bAgendado Then
            Cad &= CompletaHasta(Math.Round(Visitados * 100 / TotalClientes, 2) & "%", 10, Alineacion.Derecha, True)
        End If
        sw.WriteLine(Cad)

        If bAgendado Then
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XNoVisitados"), 28, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(NoVisitados, 10, Alineacion.Derecha, False)
            Cad &= CompletaHasta(Math.Round(NoVisitados * 100 / TotalClientes, 2) & "%", 10, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalClientes") & ":", 28, Alineacion.Derecha, False)
            Cad &= CompletaHasta(TotalClientes, 10, Alineacion.Derecha, False)
            sw.WriteLine(Cad)
            ImprimeLineaPunteada(sw, LongTot)
        End If

        'Detalle de Clientes Visitados
        Dim VisitadosConVenta As Integer = dtRutasClientes.Select("RUTClave = '" & sRUTClave & "' and Visitado > 0 and Compras > 0 and Agendado = " & bAgendado).Length
        If Visitados > 0 Then
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XVisitadosconVenta"), 28, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(VisitadosConVenta, 10, Alineacion.Derecha, False)
            Cad &= CompletaHasta(Math.Round(VisitadosConVenta * 100 / Visitados, 2) & "%", 10, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XVisitadosSinVenta"), 28, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(Visitados - VisitadosConVenta, 10, Alineacion.Derecha, False)
            Cad &= CompletaHasta(Math.Round((Visitados - VisitadosConVenta) * 100 / Visitados, 2) & "%", 10, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            ImprimeLineaPunteada(sw, LongTot)
        End If
        ''No Visitados por motivo X
        'Dim DtClNoVis As DataTable
        'DtClNoVis = oDBVen.RealizarConsultaSQL("select tipomotivo, clienteClave from improductividadventa inner join visita on Visita.VisitaClave = improductividadventa.VisitaClave and Visita.DiaClave = '" & oDia.DiaActual & "' and Visita.RutClave ='" & sRUTClave & "' and visita.VendedorID = '" & oVendedor.VendedorId & "' group by tipomotivo,clienteClave order by TipoMotivo", "Clientes")
        'Dim dr3 As DataRow
        'Dim iTipoMotivo As Integer
        'For Each dr3 In DtClNoVis.Rows
        '    If iTipoMotivo <> dr3("tipoMotivo") Then
        '        iTipoMotivo = dr3("tipoMotivo")
        '        Dim numclientes As Integer = DtClNoVis.Select("tipoMotivo = " & iTipoMotivo).Length
        '        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XNoVisitadosMotivo") & " " & iTipoMotivo, 28, Alineacion.Izquierda, False)
        '        Cad &= CompletaHasta(numclientes, 10, Alineacion.Derecha, False)
        '        Cad &= CompletaHasta(Math.Round(CInt(numclientes) * 100 / TotalClientes, 2) & "%", 10, Alineacion.Derecha, True)
        '        sw.WriteLine(Cad)
        '    End If
        'Next
        'If DtClNoVis.Rows.Count > 0 Then ImprimeLineaPunteada(sw)
        ''Producto negado
        'Dim TotProdNegados2 As Object = oDBVen.RealizarConsultaSQL("select count(improductividadprod.ProductoClave) as ProductoNegado from improductividadprod inner join visita on improductividadprod.visitaClave=visita.visitaClave and Visita.DiaClave = '" & oDia.DiaActual & "' and Visita.RutClave ='" & sRUTClave & "' and visita.VendedorID = '" & oVendedor.VendedorId & "' ", "TotProdNegados").Rows(0).Item(0)
        'Dim TotProdNegados As Integer = 0
        'If Not IsDBNull(TotProdNegados2) Then
        '    TotProdNegados = TotProdNegados2
        'End If
        'Usaré DtClNoVis aún para los visitados
        'DtClNoVis = oDBVen.RealizarConsultaSQL("select esquema.nombre as EsquemaNombre, producto.nombre as ProductoNombre, sum(cantidad) as Suma from improductividadprod inner join producto on Producto.ProductoClave = ImproductividadProd.ProductoClave inner join productoesquema on ProductoEsquema.ProductoClave = Producto.ProductoClave inner join esquema on ProductoEsquema.EsquemaID = Esquema.EsquemaID inner join visita on improductividadprod.visitaClave=visita.visitaClave and Visita.DiaClave = '" & oDia.DiaActual & "' and Visita.RutClave ='" & sRUTClave & "' and visita.VendedorID = '" & oVendedor.VendedorId & "' group by esquema.nombre, producto.nombre ", "ProdNegados")
        'Dim DistProdNegados As Integer = DtClNoVis.Rows.Count
        'If DistProdNegados > 0 Then sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XProductoNegado").ToUpper)
        'Dim sEsquema As String = String.Empty
        'For Each dr3 In DtClNoVis.Rows
        '    If sEsquema <> dr3("EsquemaNombre") Then
        '        sEsquema = dr3("EsquemaNombre")
        '        sw.WriteLine(sEsquema & ":")
        '    End If
        '    Cad = CompletaHasta(" - " & dr3("ProductoNombre"), 28, Alineacion.Izquierda, False)
        '    Cad &= CompletaHasta(dr3("suma"), 10, Alineacion.Derecha, True)
        '    'Cad &= CompletaHasta(Math.Round(CInt(dr3("suma")) * 100 / TotProdNegados, 2) & "%", 10, Alineacion.Derecha, True)
        '    sw.WriteLine(Cad)
        '    dr3 = Nothing
        'Next
        'If DtClNoVis.Rows.Count > 0 Then ImprimeLineaPunteada(sw)
        ''Producto Negado por Motivo X
        'iTipoMotivo = 0
        'DtClNoVis = oDBVen.RealizarConsultaSQL("select TipoMotivo, improductividadprod.ProductoClave from improductividadprod inner join producto on Producto.ProductoClave = ImproductividadProd.ProductoClave inner join visita on improductividadprod.visitaClave=visita.visitaClave and Visita.DiaClave = '" & oDia.DiaActual & "' and Visita.RutClave ='" & sRUTClave & "' and visita.VendedorID = '" & oVendedor.VendedorId & "' group by TipoMotivo,improductividadprod.ProductoClave ", "ProdNegadoMotivoX")
        'For Each dr3 In DtClNoVis.Rows
        '    If iTipoMotivo <> dr3("tipoMotivo") Then
        '        iTipoMotivo = dr3("tipoMotivo")
        '        Dim numProductos As Integer = DtClNoVis.Select("tipoMotivo = " & iTipoMotivo).Length
        '        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XP/NMotivo") & " " & dr3("tipomotivo"), 28, Alineacion.Izquierda, False)
        '        Cad &= CompletaHasta(numProductos, 10, Alineacion.Derecha, False)
        '        Cad &= CompletaHasta(Math.Round(CInt(numProductos) * 100 / TotProdNegados, 2) & "%", 10, Alineacion.Derecha, True)
        '        sw.WriteLine(Cad)
        '        dr3 = Nothing
        '    End If
        'Next
        'If DtClNoVis.Rows.Count > 0 Then ImprimeLineaPunteada(sw)
        'DtClNoVis.Dispose()
        'Sección de Encuestas
        'Total de encuestas que se deberían aplicar a los clientes del día
        Dim TotEncuestas As Integer
        If bAgendado Then
            TotEncuestas = oDBVen.RealizarConsultaSQL("Select distinct CENClave from CenCli where " & UniFechaSQL(PrimeraHora(oDia.FechaCaptura)) & " between IniAplicacion and FinAplicacion and ClienteClave in (select distinct ClienteClave from Agenda where VendedorId='" & oVendedor.VendedorId & "' and DiaClave='" & oDia.DiaActual & "' and RUTClave = '" & sRUTClave & "') ", "Encuestas").Rows.Count
        End If

        'Encuestas aplicadas 
        sConsulta = "select distinct ENC.CENClave "
        sConsulta &= "from Encuesta ENC "
        sConsulta &= "inner join Dia on ENC.DiaClave = Dia.DiaClave "
        sConsulta &= "inner join Visita VIS on VIS.DiaClave = '" & oDia.DiaActual & "' and VIS.VisitaClave = ENC.VisitaClave "
        If bAgendado Then
            sConsulta &= "and convert(nvarchar(10), VIS.FechaHoraInicial, 112) = convert(nvarchar(10), Dia.FechaCaptura, 112) "
        Else
            sConsulta &= "and convert(nvarchar(10), VIS.FechaHoraInicial, 112) <> convert(nvarchar(10), Dia.FechaCaptura, 112) "
        End If
        sConsulta &= "and Fase <> 0 and VIS.RUTClave='" & sRUTClave & "' "

        Dim EncAplicadas As Integer = oDBVen.RealizarConsultaSQL(sConsulta, "EncAplicadas").Rows.Count
        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XEncuestasAplicadas"), 28, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(EncAplicadas, 10, Alineacion.Derecha, False)
        If bAgendado Then
            If TotEncuestas > 0 Then
                Cad &= CompletaHasta(Math.Round(EncAplicadas * 100 / TotEncuestas, 2) & "%", 10, Alineacion.Derecha, True)
            Else
                Cad &= CompletaHasta("0%", 10, Alineacion.Derecha, True)
            End If
        End If
        sw.WriteLine(Cad)

        If bAgendado Then
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XEncuestasNoAplicadas"), 28, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(TotEncuestas - EncAplicadas, 10, Alineacion.Derecha, False)
            If TotEncuestas > 0 Then
                Cad &= CompletaHasta(Math.Round((TotEncuestas - EncAplicadas) * 100 / TotEncuestas, 2) & "%", 10, Alineacion.Derecha, True)
            Else
                Cad &= CompletaHasta("0%", 10, Alineacion.Derecha, True)
            End If
            sw.WriteLine(Cad)
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalEncuestas"), 28, Alineacion.Derecha, False)
            Cad &= CompletaHasta(TotEncuestas, 10, Alineacion.Derecha, False)
            Cad &= CompletaHasta("100%", 10, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            ImprimeLineaPunteada(sw, LongTot)
        End If

        'Sección de Clientes Encuestados
        'Total de Clientes que se deben encuestar en el dia

        Dim TotClientes As Integer
        If bAgendado Then
            TotClientes = oDBVen.RealizarConsultaSQL("select distinct clienteClave from CenCli where " & UniFechaSQL(PrimeraHora(oDia.FechaCaptura)) & " between IniAplicacion and FinAplicacion and ClienteClave in (select distinct ClienteClave from Agenda where VendedorId='" & oVendedor.VendedorId & "' and DiaClave='" & oDia.DiaActual & "' and RUTClave = '" & sRUTClave & "')", "TotClientes").Rows.Count
        End If
        'Total de Cliente encuestados
        'Q2 = "SELECT DISTINCT ClienteClave FROM CenCli WHERE CENClave in (SELECT Distinct CENClave FROM Encuesta INNER JOIN Visita ON Encuesta.VisitaClave=Visita.VisitaClave WHERE Visita.DiaClave='" & oDia.DiaActual & "' AND Encuesta.Fase=1)"                     

        sConsulta = "Select distinct CEC.ClienteClave "
        sConsulta &= "from CenCli CEC "
        sConsulta &= "inner join Encuesta ENC on CEC.CENClave = ENC.CENClave and ENC.Fase <> 0 "
        sConsulta &= "inner join Visita VIS on CEC.ClienteClave = VIS.ClienteClave and VIS.VisitaClave = ENC.VisitaClave "
        sConsulta &= "inner join Dia ON ENC.DiaClave = Dia.DiaClave and VIS.DiaClave = '" & oDia.DiaActual & "' and Vis.RUTClave = '" & sRUTClave & "' "
        If bAgendado Then
            sConsulta &= "and convert(nvarchar(10), VIS.FechaHoraInicial, 112) = convert(nvarchar(10), Dia.FechaCaptura, 112) "
        Else
            sConsulta &= "and convert(nvarchar(10), VIS.FechaHoraInicial, 112) <> convert(nvarchar(10), Dia.FechaCaptura, 112) "
        End If

        Dim CtesEncuestados As Integer = oDBVen.RealizarConsultaSQL(sConsulta, "CtesEncuestados").Rows.Count
        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XClientesEncuestados"), 28, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(CtesEncuestados, 10, Alineacion.Derecha, False)
        If bAgendado Then
            If TotClientes > 0 Then
                Cad &= CompletaHasta(Math.Round(CtesEncuestados * 100 / TotClientes, 2) & "%", 10, Alineacion.Derecha, True)
            Else
                Cad &= CompletaHasta("0%", 10, Alineacion.Derecha, True)
            End If
        End If
        sw.WriteLine(Cad)


        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XClientesNoEncuestados"), 28, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(TotClientes - CtesEncuestados, 10, Alineacion.Derecha, False)
        If TotClientes > 0 Then
            Cad &= CompletaHasta(Math.Round((TotClientes - CtesEncuestados) * 100 / TotClientes, 2) & "%", 10, Alineacion.Derecha, True)
        Else
            Cad &= CompletaHasta("0%", 10, Alineacion.Derecha, True)
        End If
        sw.WriteLine(Cad)
        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalClientes"), 28, Alineacion.Derecha, False)
        Cad &= CompletaHasta(TotClientes, 10, Alineacion.Derecha, False)
        Cad &= CompletaHasta("100%", 10, Alineacion.Derecha, True)
        sw.WriteLine(Cad)

        ImprimeLineaPunteada(sw, LongTot)

        'Estadística de los códigos de barra
        Dim iClientesConCodigo As Integer
        Dim iClientesSinCodigo As Integer
        If Visitados > 0 Then
            sConsulta = "select VIS.ClienteClave, sum(convert(Int, VIS.CodigoLeido)) as CodigoLeido "
            sConsulta &= "from Visita VIS "
            sConsulta &= "inner join Dia on VIS.DiaClave = Dia.DiaClave "
            sConsulta &= "where VIS.DiaClave='" & oDia.DiaActual & "' AND VIS.VendedorId='" & oVendedor.VendedorId & "' and VIS.RUTClave='" & sRUTClave & "' "
            If bAgendado Then
                sConsulta &= "and convert(nvarchar(10), VIS.FechaHoraInicial, 112) = convert(nvarchar(10), Dia.FechaCaptura, 112) "
            Else
                sConsulta &= "and convert(nvarchar(10), VIS.FechaHoraInicial, 112) <> convert(nvarchar(10), Dia.FechaCaptura, 112) "
            End If
            sConsulta &= "group by VIS.ClienteClave "

            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "CodigosBarras")
            iClientesConCodigo = oDt.Select("CodigoLeido>0").Length
            iClientesSinCodigo = Visitados - iClientesConCodigo
            oDt.Dispose()
        End If

        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCodigoBarras"), 28, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(iClientesConCodigo, 10, Alineacion.Derecha, False)
        If Visitados = 0 Then
            Cad &= CompletaHasta("0.00%", 10, Alineacion.Derecha, True)
        Else
            Cad &= CompletaHasta(Math.Round(iClientesConCodigo / Visitados * 100, 2) & "%", 10, Alineacion.Derecha, True)
        End If
        sw.WriteLine(Cad)
        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XClientesSeleccionados"), 28, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(iClientesSinCodigo, 10, Alineacion.Derecha, False)
        If Visitados = 0 Then
            Cad &= CompletaHasta("0.00%", 10, Alineacion.Derecha, True)
        Else
            Cad &= CompletaHasta(Math.Round(iClientesSinCodigo / Visitados * 100, 2) & "%", 10, Alineacion.Derecha, True)
        End If
        sw.WriteLine(Cad)
        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalClientes"), 28, Alineacion.Derecha, False)
        Cad &= CompletaHasta(Visitados, 10, Alineacion.Derecha, False)
        sw.WriteLine(Cad)
    End Sub

    Private Sub ReporteVentas(ByRef sw As StreamWriter)
        Try
            'delimitador(false,sw)
            Dim Cad = String.Empty, ProdNombre = String.Empty, ClienteNombre As String = String.Empty
            Dim Total As Double
            Dim aGranTotal As New Generic.Dictionary(Of String, Decimal)
            Dim Q As System.Text.StringBuilder
            Dim sTransProdIds As String = String.Empty
            If RadioButtonDetallado.Checked Then
                Dim DtTransProd As DataTable
                Q = New System.Text.StringBuilder
                Q.Append("SELECT Distinct TRP.TransProdID,TRP.TipoFase,TRP.folio, TRP.tipo, CLI.RazonSocial, TRP.DescVendPor, TRP.MonedaID, MON.Nombre,  TRP.TipoCambio ")
                Q.Append("FROM TransProd TRP INNER JOIN Visita VIS ON TRP.visitaclave=VIS.visitaclave and TRP.DiaClave=VIS.DiaClave inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave ")
                Q.Append("INNER JOIN TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID ")
                Q.Append("INNER JOIN Moneda MON ON MON.MonedaID= TRP.MonedaID ")
                Q.Append("where TRP.Tipo=1 and TRP.TipoFase<>0  ")
                Q.Append("and VIS.VendedorId='" & oVendedor.VendedorId & "' and VIS.DiaClave='" & oDia.DiaActual & "' ")
                Q.Append("UNION ")
                Q.Append("SELECT Distinct TRP.TransProdID,TRP.TipoFase,TRP.folio, TRP.tipo, CLI.RazonSocial, TRP.DescVendPor, TRP.MonedaID, MON.Nombre, TRP.TipoCambio ")
                Q.Append("FROM TransProd TRP INNER JOIN Visita VIS ON TRP.visitaclave1=VIS.visitaclave and TRP.DiaClave1=VIS.DiaClave inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave ")
                Q.Append("INNER JOIN TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID ")
                Q.Append("INNER JOIN Moneda MON ON MON.MonedaID= TRP.MonedaID ")
                Q.Append("where TRP.Tipo=1 and TRP.TipoFase<>0  ")
                Q.Append("and VIS.VendedorId='" & oVendedor.VendedorId & "' and VIS.DiaClave='" & oDia.DiaActual & "' ")
                Q.Append("order by TRP.TipoFase, CLI.Razonsocial, TRP.Folio ")
                DtTransProd = oDBVen.RealizarConsultaSQL(Q.ToString, "TransProd")
                Q = Nothing
                sTransProdIds = ObtieneTransProdIds(DtTransProd)

                'Si no existen registros de transprod
                If sTransProdIds.Length < 0 Then
                    DtTransProd.Dispose()
                    Exit Sub
                End If
                Q = New System.Text.StringBuilder
                Q.Append("select transproddetalle.TransProdID,transproddetalle.TransProdDetalleID, Producto.ProductoClave, producto.nombre, transproddetalle.UnidadCobranza, ")
                Q.Append("sum((transproddetalle.cantidad * transproddetalle.factor) +(transproddetalle.cantidad1 * transproddetalle.factor1)) as Cantidad, transproddetalle.precio, ")
                Q.Append("sum(transproddetalle.subtotal)as Subtotal, sum(Impuesto) as Impuesto, transproddetalle.Promocion ")
                Q.Append("from transproddetalle inner join Producto on producto.productoclave=transproddetalle.productoclave ")
                Q.Append("and transproddetalle.TransProdID in (" & sTransProdIds & ") ")
                Q.Append("group by transproddetalle.TransProdID,transproddetalle.TransProdDetalleID,Producto.ProductoClave, producto.nombre, transproddetalle.UnidadCobranza, precio, Promocion ")
                Q.Append("order by transproddetalle.TransProdID,Producto.ProductoClave, producto.nombre, UnidadCobranza, precio, Promocion ")
                Dim DtDetalles As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Detalle")
                Q = Nothing

                Q = New System.Text.StringBuilder
                Q.Append("select TRP.FacturaID,TPD.TransProdDetalleID, TPD.ProductoClave,TPD.Total ")
                Q.Append("from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdID = TRP.TransProdID where TRP.FacturaID in(" & sTransProdIds & ") ")
                Dim DtBonificaciones As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Bonificaciones")
                Q = Nothing

                'Dim DtMonedas As DataTable = oDBVen.RealizarConsultaSQL("Select Nombre from Moneda order by MonedaId", "Monedas")

                Dim DtTpdDes As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdID, TransProdDetalleID, sum(DesImporte) as DesImporte,sum(DesImpuesto) as DesImpuesto from TPDDes where TransProdID in(" & sTransProdIds & ") group by TransProdID, TransProdDetalleID ", "Descuentos")

                Dim oProductosDescuento As New Generic.SortedList(Of String, ProductoUnidadCobranza)

                Dim iTipoFase As Integer
                For Each Dr As DataRow In DtTransProd.Rows
                    If iTipoFase <> Dr("TipoFase") Then
                        If iTipoFase <> 0 Then
                            For Each sMONNombre As String In aGranTotal.Keys
                                Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 35, Alineacion.Derecha, False)
                                Cad &= CompletaHasta(FormatNumber(Math.Round(aGranTotal(sMONNombre), 2), 2), 13, Alineacion.Derecha, True)
                                sw.WriteLine(Cad)
                            Next
                            sw.WriteLine()
                            aGranTotal.Clear()
                        End If
                        iTipoFase = Dr("TipoFase")
                        If iTipoFase = 1 Then
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XVentasxSurtir").ToUpper, LongTot))
                        Else
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XVentasSurtidas").ToUpper, LongTot))
                        End If
                        ImprimeLineaPunteada(sw, LongTot)
                        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 11, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XUC"), 9, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCant."), 8, Alineacion.Derecha, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XP.U"), 8, Alineacion.Derecha, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 12, Alineacion.Derecha, True)
                        sw.WriteLine(Cad)
                        ImprimeLineaPunteada(sw, LongTot)
                    End If
                    If ClienteNombre <> Dr("razonsocial") Then
                        ClienteNombre = Dr("razonsocial")
                        sw.WriteLine(ClienteNombre)
                    End If
                    Total = 0
                    sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XFolio") & ":" & Dr("folio"))
                    sw.WriteLine(Dr("Nombre") & IIf(Dr("MonedaID") <> oConHist.Campos("MonedaID"), "(" & Dr("TipoCambio") & ")", ""))
                    'Nombre de producto, sus unidades, precio y demás
                    Dim PU As Double
                    ProdNombre = Nothing

                    For Each Dr2 As DataRow In DtDetalles.Select("TransProdID='" & Dr("TransProdID") & "'")
                        'Asigno el nombre del producto en cuestión
                        If ProdNombre <> Dr2("nombre") Then
                            ProdNombre = Dr2("nombre")
                            sw.WriteLine(Dr2("ProductoClave") & "-" & ProdNombre)
                        End If
                        'El detalle de unidades del producto
                        Cad = CompletaHasta("         - " & ValorReferencia.BuscarEquivalente("UCOBRA", Dr2("UnidadCobranza")), 20, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(Format(Dr2("cantidad"), "##0.00"), 8, Alineacion.Derecha, False)
                        'Cad &= CompletaHasta(Dr2("cantidad1"), 5, Alineacion.Derecha, False)
                        PU = CDbl(Dr2("precio"))
                        'If ((Dr2("Promocion")) And (CDbl(Dr2("precio")) = 0)) Then
                        If (Dr2("Promocion") = 2) Then
                            Cad &= CompletaHasta("*", 7, Alineacion.Derecha, False)
                        Else
                            Cad &= CompletaHasta(FormatNumber(PU, 2), 8, Alineacion.Derecha, False)
                        End If

                        Dim dSubtotal As Double = Dr2("Subtotal")
                        Dim dImpuesto As Double = Dr2("Impuesto")
                        'Quitar los descuentos del cliente
                        Dim drDescuentos() As DataRow
                        drDescuentos = DtTpdDes.Select("TransProdID='" & Dr("TransProdID") & "' and TransProdDetalleID='" & Dr2("TransProdDetalleID") & "'")
                        If drDescuentos.Length > 0 Then
                            dSubtotal -= drDescuentos(0)("DesImporte")
                            dImpuesto -= drDescuentos(0)("DesImpuesto")
                        End If
                        drDescuentos = Nothing

                        'Quitar el descuento del vendedor
                        dSubtotal -= (dSubtotal * (Dr("DescVendPor") / 100))
                        dImpuesto -= (dImpuesto * (Dr("DescVendPor") / 100))
                        'If ((Dr2("Promocion")) And (CDbl(Dr2("precio")) = 0)) Then
                        'Bonificaciones
                        Dim drBonificaciones() As DataRow = DtBonificaciones.Select("FacturaID = '" & Dr("TransProdID") & "' and TransProdDetalleID='" & Dr2("TransProdDetalleID") & "' ")
                        Dim dBonificacion As Decimal = 0
                        If drBonificaciones.Length > 0 Then
                            dBonificacion = drBonificaciones(0)("Total")
                        End If
                        Total += Decimal.Round((dSubtotal + dImpuesto) - dBonificacion, 2)

                        If (Dr2("Promocion") <> 2) Then
                            If oProductosDescuento.ContainsKey(Dr2("ProductoClave") & "-" & Dr2("Nombre") & Dr2("UnidadCobranza").ToString & Dr("Nombre")) Then
                                oProductosDescuento(Dr2("ProductoClave") & "-" & Dr2("Nombre") & Dr2("UnidadCobranza").ToString & Dr("Nombre")).Subtotal += Decimal.Round((dSubtotal + dImpuesto) - dBonificacion, 2)
                                oProductosDescuento(Dr2("ProductoClave") & "-" & Dr2("Nombre") & Dr2("UnidadCobranza").ToString & Dr("Nombre")).Cantidad += Dr2("Cantidad")
                            Else
                                oProductosDescuento.Add(Dr2("ProductoClave") & "-" & Dr2("Nombre") & Dr2("UnidadCobranza").ToString & Dr("Nombre"), New ProductoUnidadCobranza(Dr2("ProductoClave") & "-" & Dr2("Nombre"), Dr2("UnidadCobranza"), Dr2("Cantidad"), Decimal.Round((dSubtotal + dImpuesto) - dBonificacion, 2), Dr("Nombre")))
                            End If
                        End If

                        If Dr2("Promocion") = 2 Then
                            Cad &= CompletaHasta("", 13, Alineacion.Derecha, True)
                        Else
                            Cad &= CompletaHasta(FormatNumber(Decimal.Round((dSubtotal + dImpuesto) - dBonificacion, 2), 2), 12, Alineacion.Derecha, True)
                        End If

                        sw.WriteLine(Cad)
                    Next
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(FormatNumber(Math.Round(Total, 2), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    If aGranTotal.ContainsKey(Dr("Nombre")) Then
                        aGranTotal(Dr("Nombre")) += Total
                    Else
                        aGranTotal.Add(Dr("Nombre"), Total)
                    End If
                Next
                DtTransProd.Dispose()
                DtDetalles.Dispose()
                'DtDescuentos.Dispose()
                For Each sMONNombre As String In aGranTotal.Keys
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(FormatNumber(Math.Round(aGranTotal(sMONNombre), 2), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                Next
                ImprimeLineaPunteada(sw, LongTot)
                '-------------
                'Las Ventas x Producto
                ProdNombre = Nothing
                'Dt = oDBVen.RealizarConsultaSQL(Q.ToString, "Folios")
                Q = Nothing
                aGranTotal.Clear()
                sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XVentasProducto"))
                Dim sProductoKey As String
                For Each sProductoKey In oProductosDescuento.Keys
                    'Asigno el nombre del producto en cuestión
                    If ProdNombre <> oProductosDescuento(sProductoKey).ProductoClave Then
                        ProdNombre = oProductosDescuento(sProductoKey).ProductoClave
                        If ProdNombre <> Nothing Then
                            sw.WriteLine(ProdNombre)
                        End If
                    End If
                    'El detalle de unidades del producto
                    Cad = CompletaHasta(" - " & ValorReferencia.BuscarEquivalente("UCOBRA", oProductosDescuento(sProductoKey).UnidadCobranza), 14, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(Format(oProductosDescuento(sProductoKey).Cantidad, "##0.00"), 9, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(oProductosDescuento(sProductoKey).MonedaNombre, 12, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(FormatNumber(Math.Round(oProductosDescuento(sProductoKey).Subtotal, 2), 2), 13, Alineacion.Derecha, True)
                    If aGranTotal.ContainsKey(oProductosDescuento(sProductoKey).MonedaNombre) Then
                        aGranTotal(oProductosDescuento(sProductoKey).MonedaNombre) += Math.Round(oProductosDescuento(sProductoKey).Subtotal, 2)
                    Else
                        aGranTotal.Add(oProductosDescuento(sProductoKey).MonedaNombre, Math.Round(oProductosDescuento(sProductoKey).Subtotal, 2))
                    End If
                    sw.WriteLine(Cad)
                Next
                oProductosDescuento.Clear()
                oProductosDescuento = Nothing
                'Nuevamente el Gran Total
                ImprimeLineaPunteada(sw, LongTot)
                For Each sMONNombre As String In aGranTotal.Keys
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(FormatNumber(Math.Round(aGranTotal(sMONNombre), 2), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                Next
                ImprimeLineaPunteada(sw, LongTot)
                DtBonificaciones.Dispose()
                DtTpdDes.Dispose()
            ElseIf RadioButtonGeneral.Checked Then
                Q = New System.Text.StringBuilder
                Q.Append("SELECT Distinct TRP.TransProdID, TRP.Folio, TRP.TipoFase, CLI.RazonSocial, TRP.MonedaID, TRP.Total, MON.Nombre ")
                Q.Append("FROM TransProd TRP INNER JOIN Visita VIS ON TRP.visitaclave=VIS.visitaclave and TRP.DiaClave=VIS.DiaClave inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave ")
                Q.Append("INNER JOIN TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID ")
                Q.Append("INNER JOIN Moneda MON ON MON.MonedaID= TRP.MonedaID ")
                Q.Append("where TRP.Tipo=1 and TRP.TipoFase<>0  ")
                Q.Append("and VIS.VendedorId='" & oVendedor.VendedorId & "' and VIS.DiaClave='" & oDia.DiaActual & "' ")
                Q.Append("UNION ")
                Q.Append("SELECT Distinct TRP.TransProdID, TRP.Folio, TRP.TipoFase, CLI.RazonSocial, TRP.MonedaID, TRP.Total, MON.Nombre ")
                Q.Append("FROM TransProd TRP INNER JOIN Visita VIS ON TRP.visitaclave1=VIS.visitaclave and TRP.DiaClave1=VIS.DiaClave inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave ")
                Q.Append("INNER JOIN TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID ")
                Q.Append("INNER JOIN Moneda MON ON MON.MonedaID= TRP.MonedaID ")
                Q.Append("where TRP.Tipo=1 and TRP.TipoFase<>0  ")
                Q.Append("and VIS.VendedorId='" & oVendedor.VendedorId & "' and VIS.DiaClave='" & oDia.DiaActual & "' ")
                Q.Append("order by TRP.TipoFase, CLI.Razonsocial, TRP.Folio ")
                Dim dtTemp As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "General")
                Q = Nothing
                sTransProdIds = ObtieneTransProdIds(dtTemp)

                Q = New System.Text.StringBuilder
                Q.Append("select TRP.FacturaID, TRP.Total ")
                Q.Append("from TransProd TRP where TRP.FacturaID in(" & sTransProdIds & ") ")
                Dim DtBonificaciones As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Bonificaciones")
                Q = Nothing

                Dim iTipoFase As Integer = 0
                For Each Dr As DataRow In dtTemp.Rows
                    If iTipoFase <> Dr("TipoFase") Then
                        If iTipoFase <> 0 Then
                            For Each sMONNombre As String In aGranTotal.Keys
                                Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 35, Alineacion.Derecha, False)
                                Cad &= CompletaHasta(FormatNumber(Math.Round(aGranTotal(sMONNombre), 2), 2), 13, Alineacion.Derecha, True)
                                sw.WriteLine(Cad)
                            Next
                            ImprimeLineaPunteada(sw, LongTot)
                            aGranTotal.Clear()
                        End If
                        iTipoFase = Dr("TipoFase")
                        If iTipoFase = 1 Then
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XVentasxSurtir").ToUpper, LongTot))
                        Else
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XVentasSurtidas").ToUpper, LongTot))
                        End If
                        ImprimeLineaPunteada(sw, LongTot)
                        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio"), 19, Alineacion.Izquierda, False)
                        'Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XMoneda"), 6, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCliente"), 19, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 10, Alineacion.Derecha, True)
                        sw.WriteLine(Cad)
                        ImprimeLineaPunteada(sw, LongTot)
                    End If
                    Cad = CompletaHasta(Dr("folio") & "(" & Dr("Nombre") & ")", 19, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(Dr("razonsocial"), 19, Alineacion.Izquierda, False)

                    Dim drBonificaciones() As DataRow = DtBonificaciones.Select("FacturaID = '" & Dr("TransProdID") & "' ")
                    Dim dBonificacion As Decimal = 0
                    If drBonificaciones.Length > 0 Then
                        dBonificacion = drBonificaciones(0)("Total")
                    End If

                    Cad &= CompletaHasta(FormatNumber(Math.Round(CDbl(Dr("total") - dBonificacion), 2), 2), 10, Alineacion.Derecha, True)
                    Total = CDbl(Dr("total")) - dBonificacion
                    If aGranTotal.ContainsKey(Dr("Nombre")) Then
                        aGranTotal(Dr("Nombre")) += Total
                    Else
                        aGranTotal.Add(Dr("Nombre"), Total)
                    End If
                    sw.WriteLine(Cad)
                Next

                dtTemp.Dispose()
                DtBonificaciones.Dispose()

                For Each sMONNombre As String In aGranTotal.Keys
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & " " & sMONNombre & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta(FormatNumber(Math.Round(aGranTotal(sMONNombre), 2), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                Next
                ImprimeLineaPunteada(sw, LongTot)
            End If
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Ventas")
        End Try
    End Sub

    Private Sub ReporteSaldoEfectivo(ByRef sw As StreamWriter, ByVal Clientes As String)
        Try
            Dim Cad As String, GranTotal As Double
            Dim Q As New System.Text.StringBuilder
            Q.Append("select cliente.clave, cliente.razonsocial,saldoefectivo as Saldo ")
            Q.Append("from cliente where saldoefectivo<>0 ")
            If Clientes <> String.Empty Then
                Q.Append("and clienteclave in (" & Clientes & ") ")
            End If


            Dim dtTemp As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Saldos")
            Q = Nothing
            For Each Dr As DataRow In dtTemp.Rows
                Cad = CompletaHasta(Dr("clave"), 17, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("razonsocial"), 18, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("Saldo"), 2), 13, Alineacion.Derecha, True)
                GranTotal += CDbl(Dr("Saldo"))
                sw.WriteLine(Cad)
            Next
            dtTemp.Dispose()
            ImprimeLineaPunteada(sw, LongTot)
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & ":", 35, Alineacion.Derecha, False)
            Cad &= CompletaHasta(FormatNumber(GranTotal, 2), 13, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Reporte Saldo Efectivo")
        End Try
    End Sub

    Private Sub ReporteSaldoEnvase(ByRef sw As StreamWriter, ByVal Clientes As String)
        Try
            Dim GranTotal, Total As Double
            Dim Q As System.Text.StringBuilder
            Dim Agrupador = String.Empty, Cad As String
            If RadioButtonDetallado.Checked Then
                Q = New System.Text.StringBuilder
                Q.Append("select (cliente.clave + ' ' + cliente.razonsocial) as razonsocial, producto.nombre,sum(ProductoPrestamoCli.saldo) as Saldo ")
                Q.Append("from ProductoPrestamoCli ")
                Q.Append("inner join cliente on cliente.clienteclave=ProductoPrestamoCli.clienteclave    ")
                Q.Append("inner join producto on producto.productoclave = ProductoPrestamoCli.productoclave    ")
               
                If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                    Q.Append("where cliente.clienteclave in (" & Clientes & ") ")
                End If
                Q.Append("group by cliente.clave ,cliente.razonsocial, producto.nombre ")
                Q.Append("having sum(ProductoPrestamoCli.saldo) <> 0")
                Dim dtTemp As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "SaldoEnvase")
                Q = Nothing
                For Each Dr As DataRow In dtTemp.Rows
                    If Agrupador <> Dr("razonsocial") Then
                        
                        Agrupador = Dr("razonsocial")
                        sw.WriteLine(Agrupador)
                    End If
                    Cad = CompletaHasta("", 10, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(Dr("nombre"), 25, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(FormatNumber(Dr("saldo"), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    Total += CDbl(Dr("saldo"))
                Next

                Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 35, Alineacion.Derecha, False)
                Cad &= CompletaHasta(FormatNumber(Total, 2), 13, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                'GranTotal += Total
                ImprimeLineaPunteada(sw, LongTot)
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XResumen"), LongTot))
                '--------------------Resumen*********************************
                Total = 0
                Agrupador = String.Empty
                Q = New System.Text.StringBuilder
                Q.Append("select   producto.nombre,sum(ProductoPrestamoCli.saldo) as Saldo ")
                Q.Append("from ProductoPrestamoCli ")
                Q.Append("inner join cliente on cliente.clienteclave=ProductoPrestamoCli.clienteclave    ")
                Q.Append("inner join producto on producto.productoclave = ProductoPrestamoCli.productoclave    ")

                If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                    Q.Append("where cliente.clienteclave in (" & Clientes & ") ")
                End If
                Q.Append("group by  producto.nombre ")
                Q.Append("having sum(ProductoPrestamoCli.saldo) <> 0")
                dtTemp = oDBVen.RealizarConsultaSQL(Q.ToString, "Resumen")
                Q = Nothing
                For Each Dr As DataRow In dtTemp.Rows
                    
                    Cad = CompletaHasta(Dr("nombre"), 35, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(FormatNumber(Dr("saldo"), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    Total += CDbl(Dr("saldo"))
                Next
                dtTemp.Dispose()
                Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 35, Alineacion.Derecha, False)
                Cad &= CompletaHasta(FormatNumber(Total, 2), 13, Alineacion.Derecha, True)
                sw.WriteLine(Cad)

            Else
                Q = New System.Text.StringBuilder
                Q.Append("select (cliente.clave + ' ' + cliente.razonsocial) as razonsocial, sum(ProductoPrestamoCli.saldo) as Saldo ")
                Q.Append("from ProductoPrestamoCli ")
                Q.Append("inner join cliente on cliente.clienteclave=ProductoPrestamoCli.clienteclave    ")
                Q.Append("inner join producto on producto.productoclave = ProductoPrestamoCli.productoclave    ")

                If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                    Q.Append("where cliente.clienteclave in (" & Clientes & ") ")
                End If
                Q.Append("group by cliente.clave,cliente.razonsocial ")
                Q.Append("having sum(ProductoPrestamoCli.saldo) <> 0")
                'sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XSaldos por Envase"))
                Dim dtTemp As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "PorEnvase")
                Q = Nothing
                For Each dr As DataRow In dtTemp.Rows
                    Cad = CompletaHasta(dr("razonsocial"), 35, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(FormatNumber(dr("saldo"), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    GranTotal += CDbl(dr("saldo"))
                Next
                Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 35, Alineacion.Derecha, False)
                Cad &= CompletaHasta(FormatNumber(GranTotal, 2), 13, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                dtTemp.Dispose()
            End If
            
            ImprimeLineaPunteada(sw, LongTot)

            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteSaldoEnvase")
        End Try
    End Sub
    'TODO: Continuar con String Builder
    Private Sub ReporteResumenMovimientos(ByRef sw As StreamWriter)
        Dim Q2 As String = String.Empty, Cad As String = String.Empty
        Dim Tipo As Integer
        Dim Q As New System.Text.StringBuilder
        Dim dCantProdPiezas As Double
        If RadioButtonDetallado.Checked Then
            Dim CadTot As String = String.Empty, Total As Double ', Cantidad As Integer
            'Para Todos los movimientos menos Facturas (ese va a parte)
            Q = New System.Text.StringBuilder
            Q.Append("select transprod.tipo, transprod.Folio, producto.productoclave, producto.nombre, transproddetalle.tipounidad, ")
            Q.Append("sum(transproddetalle.cantidad) as Cantidad ")
            Q.Append("from TransProd inner join transproddetalle on TransProd.TransProdId = transproddetalle.transprodid ")
            Q.Append("inner join producto on transproddetalle.productoclave=producto.productoclave ")
            Q.Append("where transprod.diaclave='" & oDia.DiaActual & "' ")
            Q.Append("and  transprod.tipofase<>0 and not TransProd.tipo in(8,9) ")
            Q.Append("group by transprod.tipo, transprod.Folio, producto.productoclave, producto.nombre, transproddetalle.tipounidad ")
            Dim dtMovimientos As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")
            Q = Nothing
            Total = 0
            Dim sFolio As String = String.Empty
            Dim blnMovimientos As Boolean = False
            For Each Dr As DataRow In dtMovimientos.Rows
                If Tipo <> Dr("tipo") Then
                    If Tipo <> 0 Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                        sw.WriteLine(CadTot)
                        sw.WriteLine()
                    End If
                    Total = 0
                    Tipo = Dr("tipo")
                    sw.WriteLine()
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", Dr("tipo")).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", Dr("tipo"))).ToUpper)
                    sFolio = String.Empty
                End If
                If sFolio <> Dr("Folio") Then
                    blnMovimientos = True
                    If sFolio <> String.Empty Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                        sw.WriteLine(CadTot)
                        sw.WriteLine()
                    End If
                    Total = 0
                    sFolio = Dr("Folio")
                    sw.WriteLine(Dr("Folio"))
                End If
                dCantProdPiezas = Dr("cantidad")
                Cad = CompletaHasta(Dr("ProductoClave") & " " & Dr("nombre"), 48, Alineacion.Izquierda, True)
                sw.WriteLine(Cad)
                Cad = "                            " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")) & IIf(dCantProdPiezas = 0, "*", ""), 10, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                Total += dCantProdPiezas
            Next
            dtMovimientos.Dispose()
            If blnMovimientos Then
                'SoloFacturas = False
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If

            'Para las facturas (y sus respectivos pedidos)
            Tipo = Nothing
            Total = 0
            blnMovimientos = False
            sFolio = String.Empty
            Dim dtFacturas As DataTable = oDBVen.RealizarConsultaSQL("Select transprodid,Folio from transprod where Tipo=8 and diaclave='" & oDia.DiaActual & "' and tipofase<>0 ", "SubQuery")
            Q2 = ObtieneTransProdIds(dtFacturas)
            Q = New System.Text.StringBuilder
            Q.Append("Select transprod.tipo, TransProd.FacturaID, producto.productoclave, producto.nombre, transproddetalle.tipounidad, ")
            Q.Append("sum(transproddetalle.cantidad) as Cantidad ")
            Q.Append("from TransProd inner join transproddetalle on TransProd.TransProdId = transproddetalle.transprodid ")
            Q.Append("inner join producto on transproddetalle.productoclave=producto.productoclave ")
            Q.Append("where transprod.FacturaID in (" & Q2 & ") ")
            Q.Append("and transprod.tipofase<>0 ")
            Q.Append("group by transprod.tipo, TransProd.FacturaID, producto.productoclave, producto.nombre, transproddetalle.tipounidad")
            Dim dtMovimientos2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")
            Q = Nothing
            For Each Dr As DataRow In dtMovimientos2.Rows
                If Tipo <> Dr("tipo") Then
                    If Tipo <> Nothing Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                        sw.WriteLine(CadTot)
                        sw.WriteLine()
                    End If
                    blnMovimientos = True
                    Total = 0
                    Tipo = Dr("tipo")
                    sw.WriteLine()
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", 8).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", "8")).ToUpper)
                End If
                If sFolio <> Dr("FacturaID") Then
                    If sFolio <> String.Empty Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                        sw.WriteLine(CadTot)
                        sw.WriteLine()
                    End If
                    Total = 0
                    sFolio = Dr("FacturaID")
                    sw.WriteLine(dtFacturas.Select(" TransProdID='" & sFolio & "' ")(0)(1))
                End If
                dCantProdPiezas = Dr("cantidad")
                Cad = CompletaHasta(Dr("ProductoClave") & " " & Dr("nombre"), 48, Alineacion.Izquierda, True)
                sw.WriteLine(Cad)
                Cad = "                            " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")) & IIf(dCantProdPiezas = 0, "*", ""), 10, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                Total += dCantProdPiezas
            Next
            dtMovimientos2.Dispose()
            dtFacturas.Dispose()
            If blnMovimientos Then
                'SoloFacturas = False
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If

            'Cambios de Producto
            Tipo = Nothing

            Total = 0
            sFolio = Nothing
            blnMovimientos = False
            Q = New System.Text.StringBuilder
            Q.Append("Select transprod.tipo, case When TransProd.FacturaID is null Then TransProd.TransProdID Else TransProd.FacturaID End as TransProdID2, Folio, producto.productoclave, producto.nombre, transproddetalle.tipounidad, ")
            Q.Append("sum(transproddetalle.cantidad) as Cantidad, TipoMovimiento  ")
            Q.Append("from TransProd inner join transproddetalle on TransProd.TransProdId = transproddetalle.transprodid ")
            Q.Append("inner join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave ")
            Q.Append("where TransProd.Tipo=9 and transprod.diaclave='" & oDia.DiaActual & "' ")
            Q.Append("and transprod.tipofase<>0 ")
            Q.Append("group by transprod.tipo, case When TransProd.FacturaID is null Then TransProd.TransProdID Else TransProd.FacturaID End, Folio, producto.productoclave, producto.nombre, transproddetalle.tipounidad,TipoMovimiento ")
            Q.Append("order by TransProdID2, TipoMovimiento, Producto.Productoclave, TipoUnidad ")
            dtMovimientos = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")
            Q = Nothing
            If dtMovimientos.Rows.Count > 0 Then
                Dim TipoMovimiento As Integer = 0
                Tipo = dtMovimientos.Rows(0)("tipo")
                sw.WriteLine()
                'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", Tipo).Rows(0).Item(1)).ToUpper)
                sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", Tipo)).ToUpper)
                For Each Dr As DataRow In dtMovimientos.Rows
                    If sFolio <> Dr("TransProdID2") Then
                        If sFolio <> String.Empty Then
                            CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                            CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                            sw.WriteLine(CadTot)
                            sw.WriteLine()
                        End If
                        Total = 0
                        TipoMovimiento = 0
                        blnMovimientos = True
                        sw.WriteLine(Dr("Folio"))
                        sFolio = Dr("TransProdID2")
                    End If
                    If TipoMovimiento <> Dr("tipoMovimiento") Then
                        If TipoMovimiento <> 0 Then
                            CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                            CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                            sw.WriteLine(CadTot)
                            sw.WriteLine()
                        End If
                        Total = 0
                        blnMovimientos = True
                        TipoMovimiento = Dr("TipoMovimiento")
                        If TipoMovimiento = 1 Then
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XCambio").ToUpper, LongTot))
                        Else
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XPor").ToUpper, LongTot))
                        End If
                    End If
                    dCantProdPiezas = Dr("cantidad")
                    Cad = CompletaHasta(Dr("ProductoClave") & " " & Dr("nombre"), 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                    Cad = "                            " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")) & IIf(dCantProdPiezas = 0, "*", ""), 10, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    Total += dCantProdPiezas
                Next
            End If
            dtMovimientos.Dispose()
            If blnMovimientos Then
                'SoloFacturas = False
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If
        Else 'General
            Dim CadTot As String, Total As Double ', Cantidad As Integer
            'Para Todos los movimientos menos Facturas (ese va a parte)
            Q = New System.Text.StringBuilder
            Q.Append("select transprod.tipo, producto.productoclave, producto.nombre, transproddetalle.tipounidad, ")
            Q.Append("sum(transproddetalle.cantidad) as Cantidad ")
            Q.Append("from TransProd inner join transproddetalle on TransProd.TransProdId = transproddetalle.transprodid ")
            Q.Append("inner join producto on transproddetalle.productoclave=producto.productoclave ")
            Q.Append("where transprod.diaclave='" & oDia.DiaActual & "' ")
            Q.Append("and  transprod.tipofase<>0 and not TransProd.tipo in(8,9) ")
            Q.Append("group by transprod.tipo, producto.productoclave, producto.nombre, transproddetalle.tipounidad ")
            Dim dtMovimientos As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")
            Q = Nothing
            Dim blnMovimientos As Boolean = False

            For Each Dr As DataRow In dtMovimientos.Rows
                If Tipo <> Dr("tipo") Then
                    If Tipo <> Nothing Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                        sw.WriteLine(CadTot)
                        sw.WriteLine()
                    End If
                    Tipo = Dr("tipo")
                    blnMovimientos = True
                    Total = 0
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", Dr("tipo")).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", Dr("tipo"))).ToUpper)
                End If
                dCantProdPiezas = Dr("cantidad")
                Cad = CompletaHasta(Dr("ProductoClave") & " " & Dr("nombre"), 48, Alineacion.Izquierda, True)
                sw.WriteLine(Cad)
                Cad = "                            " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")) & IIf(dCantProdPiezas = 0, "*", ""), 10, Alineacion.Izquierda, False)

                Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                Total += dCantProdPiezas
            Next
            dtMovimientos.Dispose()
            Dim SoloFacturas As Boolean = True
            If blnMovimientos Then
                SoloFacturas = False
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If
            'Para las facturas (y sus respectivos pedidos)
            Tipo = Nothing
            blnMovimientos = False
            Total = 0
            Dim dtFacturas As DataTable = oDBVen.RealizarConsultaSQL("Select transprodid from TransProd where facturaid in(Select transprodid from transprod where Tipo=8 and diaclave='" & oDia.DiaActual & "' and tipofase<>0)", "Facturas")
            Q2 = ObtieneTransProdIds(dtFacturas)
            Q = New System.Text.StringBuilder
            Q.Append("Select transprod.tipo, producto.productoclave, producto.nombre, transproddetalle.tipounidad, ")
            Q.Append("sum(transproddetalle.cantidad) as Cantidad ")
            Q.Append("from TransProd inner join transproddetalle on TransProd.TransProdId = transproddetalle.transprodid ")
            Q.Append("inner join producto on transproddetalle.productoclave=producto.productoclave ")
            Q.Append("where transprod.transprodid in (" & Q2 & ") ")
            Q.Append("and transprod.tipofase<>0 ")
            Q.Append("group by transprod.tipo, producto.productoclave, producto.nombre, transproddetalle.tipounidad")
            Dim dtMovimientos2 As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")
            Q = Nothing
            For Each Dr As DataRow In dtMovimientos2.Rows
                If Tipo <> Dr("tipo") Then
                    Tipo = Dr("tipo")
                    blnMovimientos = True
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", 8).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", 8)).ToUpper)
                End If
                dCantProdPiezas = Dr("cantidad")
                Cad = CompletaHasta(Dr("ProductoClave") & " " & Dr("nombre"), 48, Alineacion.Izquierda, True)
                sw.WriteLine(Cad)
                Cad = "                            " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")) & IIf(dCantProdPiezas = 0, "*", ""), 10, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                Total += dCantProdPiezas
            Next
            dtMovimientos2.Dispose()
            If blnMovimientos Then
                SoloFacturas = False
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If

            'Cambios de Producto
            Tipo = Nothing
            blnMovimientos = False
            Total = 0
            Q = New System.Text.StringBuilder
            Q.Append("Select transprod.tipo, producto.productoclave, producto.nombre, transproddetalle.tipounidad, ")
            Q.Append("sum(transproddetalle.cantidad) as Cantidad, TipoMovimiento  ")
            Q.Append("from TransProd inner join transproddetalle on TransProd.TransProdId = transproddetalle.transprodid ")
            Q.Append("inner join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave ")
            Q.Append("where TransProd.Tipo=9 and transprod.diaclave='" & oDia.DiaActual & "' ")
            Q.Append("and transprod.tipofase<>0 ")
            Q.Append("group by transprod.tipo, producto.productoclave, producto.nombre, transproddetalle.tipounidad,TipoMovimiento ")
            Q.Append("order by TipoMovimiento,producto.productoclave, TipoUnidad ")
            dtMovimientos = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")
            Q = Nothing
            If dtMovimientos.Rows.Count > 0 Then
                blnMovimientos = True
                Dim TipoMovimiento As Integer = 0
                Tipo = dtMovimientos.Rows(0)("tipo")
                'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", Tipo).Rows(0).Item(1)).ToUpper)
                sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", Tipo)).ToUpper)
                For Each Dr As DataRow In dtMovimientos.Rows
                    If TipoMovimiento <> Dr("tipoMovimiento") Then
                        If TipoMovimiento <> 0 Then
                            CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                            CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                            sw.WriteLine(CadTot)
                            sw.WriteLine()
                        End If
                        Total = 0
                        TipoMovimiento = Dr("TipoMovimiento")
                        If TipoMovimiento = 1 Then
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XCambio").ToUpper, LongTot))
                        Else
                            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XPor").ToUpper, LongTot))
                        End If
                    End If
                    dCantProdPiezas = Dr("cantidad")
                    Cad = CompletaHasta(Dr("ProductoClave") & " " & Dr("nombre"), 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                    Cad = "                            " & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")) & IIf(dCantProdPiezas = 0, "*", ""), 10, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    Total += dCantProdPiezas
                Next
            End If
            dtMovimientos.Dispose()
            dtFacturas.Dispose()
            If blnMovimientos Then
                SoloFacturas = False
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalPiezas") & ":", 35, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 0), 13, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If

        End If
        ImprimeLineaPunteada(sw, LongTot)
        EspaciosAlFinal(sw)
    End Sub

    Private Sub ReporteHistoricoPromedio(ByRef sw As StreamWriter, ByVal Clientes As String)
        Try
            Dim n As Integer
            Dim Total As Double
            Dim Q = "", ClienteClave = "", Cad As String = ""
            Q = "select transprod.folio, transprod.total, transprod.fechacaptura, cliente.clave, cliente.razonsocial "
            Q &= "from transprod, visita, cliente "
            Q &= "where transprod.tipo=1 "
            Q &= "and transprod.tipofase<>0 "
            Q &= "and transprod.visitaclave=visita.visitaclave "
            Q &= "and transprod.diaclave=visita.diaclave "
            Q &= "and visita.clienteclave=cliente.clienteclave "
            'Q &= "and visita.clienteclave in (" & Clientes & ") "
            If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                Q &= "and visita.clienteclave in (" & Clientes & ") "
            End If
            Q &= "and visita.vendedorid='" & oVendedor.VendedorId & "' "
            Q &= "and " & FechaConvertida("TransProd.FechaCaptura")

            Q &= " order by cliente.clave, transprod.fechacaptura, transprod.folio"
            For Each Dr As DataRow In oDBVen.RealizarConsultaSQL(Q, "HistProm").Rows
                If ClienteClave <> Dr("clave") Then
                    If ClienteClave <> Nothing Then
                        sw.WriteLine()
                        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImportePromedio") & ":", 30, Alineacion.Derecha, False)
                        Cad &= CompletaHasta(FormatNumber(Math.Round(Total / n, 2), 2), 18, Alineacion.Derecha, True)
                        sw.WriteLine(Cad)
                        ImprimeLineaPunteada(sw, LongTot)
                    End If
                    ClienteClave = Dr("clave")
                    Cad = CompletaHasta(ClienteClave, 15, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(Dr("razonsocial"), 33, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                    n = 0
                    Total = 0
                End If
                Cad = CompletaHasta(Dr("folio"), 15, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Format(Dr("fechacaptura"), "dd/MM/yyyy"), 15, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("total"), 2), 18, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                Total += CDbl(Dr("total"))
                n += 1
            Next
            sw.WriteLine()
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImportePromedio") & ":", 30, Alineacion.Derecha, False)
            Cad &= CompletaHasta(FormatNumber(Math.Round(Total / n, 2), 2), 18, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            ImprimeLineaPunteada(sw, LongTot)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteHistoricoPromedio")
        End Try
    End Sub

    Private Sub ReporteDepositos(ByRef Sw As StreamWriter)
        Try
            Dim Q = "", Cad = "", CadTot = "", Ficha = "", Fecha As String = ""
            Dim Banco As Integer
            Dim Total, GranTotal As Double
            Q = "select deposito.fechadeposito, Deposito.ficha, deposito.tipobanco, "
            Q &= "abndetalle.tipopago, abddep.importe "
            Q &= "from deposito, abddep, abndetalle "
            Q &= "where deposito.depid=abddep.depid "
            Q &= "and abddep.abnid=abndetalle.abnid "
            Q &= "and abddep.abdid=abndetalle.abdid "
            Q &= "and " & FechaConvertida("deposito.fechadeposito") & " "

            Q &= " order by tipobanco, fechadeposito, ficha"
            For Each Dr As DataRow In oDBVen.RealizarConsultaSQL(Q, "Depositos").Rows
                'Para ver si imprimo la ficha
                If Ficha <> Dr("ficha") Then
                    If Ficha <> Nothing Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 33, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 2), 15, Alineacion.Derecha, True)
                        Sw.WriteLine(CadTot)
                        Sw.WriteLine()
                    End If
                    Total = 0
                    Ficha = Dr("ficha")
                    Cad = CompletaHasta("  " & Ficha, 18, Alineacion.Izquierda, False)
                Else
                    Cad = CompletaHasta(" ", 18, Alineacion.Izquierda, False)
                End If
                'Para ver si imprimo lo del banco
                If Banco <> Dr("tipobanco") Then
                    Banco = Dr("tipobanco")
                    Fecha = Nothing
                    'Sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TBANCO", Banco).Rows(0).Item(1)).ToUpper)
                    Sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TBANCO", Banco)).ToUpper)
                End If
                'Para ver si imprimo la fecha
                If Fecha <> Format(Dr("fechadeposito"), "dd/MM/yyyy") Then
                    Fecha = Format(Dr("fechadeposito"), "dd/MM/yyyy")
                    Sw.WriteLine("  " & Fecha)
                End If
                'Cad &= CompletaHasta(ValorReferencia.RecuperarLista("PAGO", Dr("tipopago")).Rows(0).Item(1), 15, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("PAGO", Dr("tipopago")), 15, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("importe"), 2), 15, Alineacion.Derecha, True)
                Sw.WriteLine(Cad)
                Total += CDbl(Dr("importe"))
                GranTotal += CDbl(Dr("importe"))
            Next
            CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 33, Alineacion.Derecha, False)
            CadTot &= CompletaHasta(FormatNumber(Total, 2), 15, Alineacion.Derecha, True)
            Sw.WriteLine(CadTot)
            Sw.WriteLine()
            CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & ":", 33, Alineacion.Derecha, False)
            CadTot &= CompletaHasta(FormatNumber(GranTotal, 2), 15, Alineacion.Derecha, True)
            Sw.WriteLine(CadTot)
            ImprimeLineaPunteada(Sw, LongTot)
            EspaciosAlFinal(Sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteDepositos")
        End Try
    End Sub
    Private Sub ReporteExtensionDeAlmacen(ByVal sw As StreamWriter)
        Dim initemp, inifin, rectemp, recfin, vtatemp, vtafin, promtemp, promfin, dectemp, decfin, finfin, contemp, confin As Integer
        Dim sProducto As String
        Dim Q As New Text.StringBuilder


        Dim tipomotivo As Integer = oDBApp.EjecutarCmdScalarIntSQL("select vavclave from VarValor where grupo='Venta' and varcodigo='TRPMOT'")

        Q.Append("select p.productoclave ")
        Q.Append(",case when t.tipo=23 then sum(PRD.Factor * TD.Cantidad) else 0 end as Ini ")
        Q.Append(",case when t.tipo=2 or t.tipo=3 then sum(PRD.Factor * TD.Cantidad) else 0 end as Rec ")
        Q.Append(",case when t.tipo=1 then case when td.promocion <> 2  then sum(PRD.Factor * TD.Cantidad) else 0 end else 0 end as Vta ")
        Q.Append(",case when t.tipo=1 then case when td.promocion = 2  then sum(PRD.Factor * TD.Cantidad) else 0 end else 0 end as Prom ")
        Q.Append(",case when t.tipo=24 then sum(PRD.Factor * TD.Cantidad) else 0 end as Con ")
        Q.Append(",case when t.tipo=7 then sum(PRD.Factor * TD.Cantidad) else 0 end as xDec ")
        Q.Append("from transprod T ")
        Q.Append("inner join transproddetalle TD on T.transprodid=TD.transprodid ")
        Q.Append("inner join producto P on TD.productoclave=P.productoclave ")
        Q.Append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
        Q.Append("left join dia d on t.diaclave=d.diaclave ")
        Q.Append("where P.Contenido <> 1 and t.tipofase <>0 and ")
        Q.Append("((((t.tipo in (24,2,1,7)) or (t.tipo =3 and (t.tipomotivo=12 or t.tipomotivo=1)) ) and t.diaclave in (" & diaClavesEnFrecuencia() & ")  and d.fuerafrecuencia=0 ) ")
        Q.Append("or t.tipo in (23)) ")
        Q.Append("group by p.productoclave,t.tipo, td.promocion ")
        Q.Append("order by p.productoclave")
        Dim tabla As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString(), "Reporte")
        Dim cad As String = ""

        For Each row As DataRow In tabla.Rows
            If row("productoclave") <> sProducto Then
                If sProducto <> "" Then
                    finfin += (initemp + rectemp - vtatemp - promtemp - contemp - dectemp)
                    cad = CompletaHasta(sProducto, 12, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(initemp, 5, Alineacion.Derecha, False)
                    cad &= CompletaHasta(rectemp, 5, Alineacion.Derecha, False)
                    cad &= CompletaHasta(vtatemp, 5, Alineacion.Derecha, False)
                    cad &= CompletaHasta(promtemp, 5, Alineacion.Derecha, False)
                    cad &= CompletaHasta(contemp, 5, Alineacion.Derecha, False)
                    cad &= CompletaHasta(dectemp, 5, Alineacion.Derecha, False)
                    cad &= CompletaHasta(initemp + rectemp - vtatemp - promtemp - contemp - dectemp, 6, Alineacion.Derecha, True)
                    sw.WriteLine(cad)
                End If

                initemp = 0
                rectemp = 0
                vtatemp = 0
                promtemp = 0
                dectemp = 0
                contemp = 0

                sProducto = row("productoclave")
            End If
            initemp += row("Ini")
            rectemp += row("Rec")
            vtatemp += row("Vta")
            promtemp += row("Prom")
            dectemp += row("xDec")
            contemp += row("Con")

            inifin += row("Ini")
            recfin += row("Rec")
            vtafin += row("Vta")
            promfin += row("Prom")
            decfin += row("xDec")
            confin += row("Con")
        Next
        finfin += (initemp + rectemp - vtatemp - promtemp - contemp - dectemp)
        cad = CompletaHasta(sProducto, 12, Alineacion.Izquierda, False)
        cad &= CompletaHasta(initemp, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(rectemp, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(vtatemp, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(promtemp, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(contemp, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(dectemp, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(initemp + rectemp - vtatemp - promtemp - contemp - dectemp, 6, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta("", 12, Alineacion.Izquierda, False)
        cad &= CompletaHasta(inifin, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(recfin, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(vtafin, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(promfin, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(confin, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(decfin, 5, Alineacion.Derecha, False)
        cad &= CompletaHasta(finfin, 6, Alineacion.Derecha, True)
        ImprimeLineaPunteada(sw, LongTot)
        sw.WriteLine(cad)
        sw.WriteLine()
        sw.WriteLine()
        sw.WriteLine()
        sw.WriteLine()
        sw.WriteLine()
        sw.WriteLine()


        ImprimeFirmas(sw, refaVista.BuscarMensaje("MsgBox", "XAlmDeLleno"), refaVista.BuscarMensaje("Mensajes2", "XVendedor"))
        EspaciosAlFinal(sw)

    End Sub

    Private Sub ReporteVtaProductoyMovEnvase(ByVal sw As StreamWriter)
        Dim vtareg, vtacan, vtaneta, prom, con As Integer
        Dim sProducto As String
        Dim sPrecioClave As String
        Dim Q As New Text.StringBuilder
        Q.Append("select p.productoclave, ")
        Q.Append("case when d.fuerafrecuencia =0 and td.promocion<>2 then sum(PRD.Factor *  TD.Cantidad) else 0 end as  VtaReg ,")
        Q.Append("case when t.tipofase=0 and td.promocion<>2 then sum(PRD.Factor *  TD.Cantidad) else 0 end as VtaCan, ")
        Q.Append("case when t.tipofase<>0 and td.promocion<>2 then sum(PRD.Factor *  TD.Cantidad) else 0 end as VtaNeta, ")
        Q.Append("case when  t.tipofase<>0 and td.promocion=2 then sum(PRD.Factor *  TD.Cantidad) else 0 end as Prom ,")
        Q.Append("0 as Con, ")
        Q.Append("pceprecioclave ")
        Q.Append("from transprod T ")
        Q.Append("inner join dia d on t.diaclave=d.diaclave ")
        Q.Append("inner join transproddetalle TD on T.transprodid=TD.transprodid ")
        Q.Append("inner join producto P on TD.productoclave=P.productoclave ")
        Q.Append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
        Q.Append("where t.tipo =1  and t.diaclave in (" & diaClavesEnFrecuencia() & ") ")
        Q.Append("group by p.productoclave, td.promocion ,t.tipofase,t.pceprecioclave,d.fuerafrecuencia ")
        Q.Append(vbCrLf + " union " + vbCrLf)
        Q.Append("select p.productoclave, ")
        Q.Append("0 as VtaReg ,0 as VtaCan,0 as VtaNeta,0 as Prom , ")
        Q.Append("(sum(PRD.Factor) * sum(TDCon.Cantidad)-sum(case isnull(PRDDev.Factor) when 1 then 0 else PRDDev.Factor end) * sum(case isnull(TDDev.Cantidad) when 1 then 0 else TDDev.Cantidad end)) as Con, ")
        Q.Append("pceprecioclave from transprod TCon  ")
        Q.Append("inner join transproddetalle TDCon on TCon.transprodid=TDCon.transprodid  ")
        Q.Append("inner join producto P on TDCon.productoclave=P.productoclave  ")
        Q.Append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and TDCon.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave  ")
        Q.Append("Left join TrpTpd on TrpTpd.Transprodid1=TCon.transprodid ")
        Q.Append("Left join transproddetalle TDDev on TrpTpd.Transprodid=TDDev.transprodid and TrpTpd.Transproddetalleid=TDDev.transproddetalleid and TDDev.productoclave = TDCon.productoclave and TDDev.tipounidad = TDCon.tipounidad ")
        Q.Append("Left join ProductoDetalle PRDDev on TDDev.ProductoClave = PRDDev.ProductoClave and TDDev.TipoUnidad = PRDDev.PRUTipoUnidad and PRDDev.ProductoClave = PRDDev.ProductoDetClave  ")
        Q.Append("where TCon.tipo =24  and TCon.tipofase =6 and diaclave1 in (" & diaClavesEnFrecuencia() & ")  ")
        Q.Append("group by p.productoclave, tdCon.promocion ,TCon.tipofase,TCon.pceprecioclave  ")
        Q.Append("order by p.productoclave ")



        Dim tabla As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString(), "Reporte")
        Dim cad As String = ""

        For Each row As DataRow In tabla.Rows
            If row("productoclave") <> sProducto Then
                If sProducto <> "" Then

                    cad = CompletaHasta(sProducto, 10, Alineacion.Izquierda, False)
                    cad &= CompletaHasta(vtareg, 6, Alineacion.Derecha, False)
                    cad &= CompletaHasta(vtacan, 6, Alineacion.Derecha, False)
                    cad &= CompletaHasta(vtaneta, 6, Alineacion.Derecha, False)
                    cad &= CompletaHasta(prom, 6, Alineacion.Derecha, False)
                    cad &= CompletaHasta(con, 6, Alineacion.Derecha, False)
                    cad &= CompletaHasta(row("pceprecioclave"), 8, Alineacion.Derecha, True)

                    sw.WriteLine(cad)
                End If

                vtareg = 0
                vtacan = 0
                vtaneta = 0
                prom = 0
                con = 0
                sProducto = row("productoclave")
            End If
            vtareg += row("VtaReg")
            vtacan += row("VtaCan")
            vtaneta += row("VtaNeta")
            prom += row("Prom")
            sPrecioClave = row("pceprecioclave")
            con += row("Con")

        Next
        If tabla.Rows.Count > 0 Then
            cad = CompletaHasta(sProducto, 10, Alineacion.Izquierda, False)
            cad &= CompletaHasta(vtareg, 6, Alineacion.Derecha, False)
            cad &= CompletaHasta(vtacan, 6, Alineacion.Derecha, False)
            cad &= CompletaHasta(vtaneta, 6, Alineacion.Derecha, False)
            cad &= CompletaHasta(prom, 6, Alineacion.Derecha, False)
            cad &= CompletaHasta(con, 6, Alineacion.Derecha, False)
            cad &= CompletaHasta(sPrecioClave, 8, Alineacion.Derecha, True)

            sw.WriteLine(cad)
        End If
        ImprimeLineaPunteada(sw, LongTot)

        '**********************
        Q = New Text.StringBuilder
        Q.Append("select ")
        Q.Append("case when p.contenido=0 and td.promocion<>2 then  sum(td.precio * TD.Cantidad)  else 0 end as vtaliquido,")
        Q.Append("case when p.contenido=1 and td.promocion<>2 then  sum(td.precio * TD.Cantidad)  else 0 end as vtaenvase,")
        Q.Append("case when p.contenido=0 and td.promocion<>2 then  sum(td.Impuesto)  else 0 end as impuestoliquido,")
        Q.Append("case when p.contenido=1 and td.promocion<>2 then  sum(td.Impuesto)  else 0 end as impuestoenvase,")
        Q.Append("case when p.contenido=0 and td.promocion<>2 then  sum(case isnull(TpdDes.DesImpuesto) when 1 then 0 else TpdDes.DesImpuesto end)  else 0 end as DesImpuestoliquido,")
        Q.Append("case when p.contenido=1 and td.promocion<>2 then  sum(case isnull(TpdDes.DesImpuesto) when 1 then 0 else TpdDes.DesImpuesto end)  else 0 end as DesImpuestoenvase,")
        Q.Append("case when p.contenido=0 and td.promocion<>2 then  sum(case isnull(TpdDesVendedor.DesImpuesto) when 1 then 0 else TpdDesVendedor.DesImpuesto end)  else 0 end as VenDesImpuestoliquido,")
        Q.Append("case when p.contenido=1 and td.promocion<>2 then  sum(case isnull(TpdDesVendedor.DesImpuesto) when 1 then 0 else TpdDesVendedor.DesImpuesto end)  else 0 end as VenDesImpuestoenvase,")
        'case isnull(PRDDev.Factor) when 1 then 0 else PRDDev.Factor end
        Q.Append("case when td.promocion<>2 then  sum(td.precio * TD.Cantidad)  else 0 end as vtatotal,")
        Q.Append("case when t.tipofase=0 then  sum(td.precio*TD.Cantidad)  else 0 end as vtacanceladas,")
        Q.Append("case when t.tipofase=0 then  sum(td.impuesto)  else 0 end as impcanceladas,")
        Q.Append("case when t.tipofase<>0 then  sum(td.descuentoimp) else 0 end as tddescuento ")
        Q.Append("from transprod T ")
        Q.Append("inner join transproddetalle TD on T.transprodid=TD.transprodid ")
        Q.Append("inner join producto P on TD.productoclave=P.productoclave ")
        Q.Append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
        Q.Append("left join TpdDes on TpdDes.transprodid=TD.transprodid and TpdDes.transproddetalleid=TD.transproddetalleid ")
        Q.Append("left join TpdDesVendedor on TpdDesVendedor.transprodid=TD.transprodid and TpdDesVendedor.transproddetalleid=TD.transproddetalleid ")
        Q.Append("where t.tipo =1  and diaclave in (" & diaClavesEnFrecuencia() & ") group by t.tipofase,p.contenido,td.promocion")

        Dim tablaDetalle As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString(), "Detalle")

        Q = New Text.StringBuilder
        Q.Append("select ")
        Q.Append("sum(t.descuentoimp) as descuentoimp,")
        Q.Append("sum(t.descuentovendedor)  as descuentovendedor,")
        Q.Append("sum(t.impuesto) as impuesto,")
        Q.Append("sum(t.total) as total ")
        Q.Append("from transprod T ")
        Q.Append("where t.tipo =1  and tipofase<>0 and diaclave in (" & diaClavesEnFrecuencia() & ") ")
        Dim tablaTransprod As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString(), "Transprod")

        Dim dConsignacion As Decimal = oDBVen.EjecutarCmdScalardblSQL("select  sum( tcon.total) from transprod TCon  where TCon.tipo =24  and TCon.tipofase =6 and convert(nvarchar(200), TCon.fechafacturacion ,103) in (" & diaClavesFechaCapturaEnFrecuencia() & ")")
        Dim dDevolucionConsignacion As Decimal = oDBVen.EjecutarCmdScalardblSQL("select  sum (case isnull(TrpTpd.total) when 1 then 0 else TrpTpd.total end) from transprod TCon  Left join TrpTpd on TrpTpd.Transprodid1=TCon.transprodid  where TCon.tipo =24  and TCon.tipofase =6 and convert(nvarchar(200), TCon.fechafacturacion ,103) in (" & diaClavesFechaCapturaEnFrecuencia() & ")")

        Q = New Text.StringBuilder
        Q.Append("select ")
        Q.Append("sum(total)as total from abono where  diaclave in (" & diaClavesEnFrecuencia() & ") ")
        Dim totalabono As Decimal = 0
        totalabono = oDBVen.EjecutarCmdScalardblSQL(Q.ToString)




        Q = New Text.StringBuilder
        Q.Append("select sum(saldoefectivo) as saldoefectivo from cliente")
        Dim totalSaldosEfe As Decimal = 0
        totalSaldosEfe = oDBVen.EjecutarCmdScalardblSQL(Q.ToString)

        Q = New Text.StringBuilder
        Q.Append("select sum(saldoefectivocarga)as saldoefectivocarga from cliente")
        Dim totalSaldosCar As Decimal = 0
        totalSaldosCar = oDBVen.EjecutarCmdScalardblSQL(Q.ToString)

        Dim vtaliquido As Decimal = 0, vtaenvase As Decimal = 0, vtatotal As Decimal = 0, vtacanceladas As Decimal = 0, tddescuento As Decimal = 0, descuentoimp As Decimal = 0, descuentovendedor As Decimal = 0, impuesto As Decimal = 0, total As Decimal = 0


        If Not IsDBNull(tablaDetalle.Compute("sum(vtaliquido)", "")) Then
            vtaliquido = tablaDetalle.Compute("sum(vtaliquido)", "") + tablaDetalle.Compute("sum(impuestoliquido)", "") - tablaDetalle.Compute("sum(DesImpuestoliquido)", "") - tablaDetalle.Compute("sum(VenDesImpuestoliquido)", "")
        End If
        If Not IsDBNull(tablaDetalle.Compute("sum(vtaenvase)", "")) Then
            vtaenvase = tablaDetalle.Compute("sum(vtaenvase)", "") + tablaDetalle.Compute("sum(impuestoenvase)", "") - tablaDetalle.Compute("sum(DesImpuestoenvase)", "") - tablaDetalle.Compute("sum(VenDesImpuestoenvase)", "")
        End If
        If Not IsDBNull(tablaDetalle.Compute("sum(vtatotal)", "")) Then
            vtatotal = vtaliquido + vtaenvase
        End If
        If Not IsDBNull(tablaDetalle.Compute("sum(vtacanceladas)", "")) Then
            vtacanceladas = tablaDetalle.Compute("sum(vtacanceladas)", "") + tablaDetalle.Compute("sum(impcanceladas)", "")
        End If

        If Not IsDBNull(tablaDetalle.Compute("sum(tddescuento)", "")) Then
            tddescuento = tablaDetalle.Compute("sum(tddescuento)", "")
        End If

        If Not IsDBNull(tablaTransprod.Compute("sum(descuentovendedor)", "")) Then
            descuentovendedor = tablaTransprod.Compute("sum(descuentovendedor)", "")
        End If
        If Not IsDBNull(tablaTransprod.Compute("sum(impuesto)", "")) Then
            impuesto = tablaTransprod.Compute("sum(impuesto)", "")
        End If
        If Not IsDBNull(tablaTransprod.Compute("sum(descuentoimp)", "")) Then
            descuentoimp = tablaTransprod.Compute("sum(descuentoimp)", "")
        End If
        If Not IsDBNull(tablaTransprod.Compute("sum(total)", "")) Then
            total = tablaTransprod.Compute("sum(total)", "")
        End If

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVenta") & " " & refaVista.BuscarMensaje("MsgBox", "XLiquido"), 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(vtaliquido, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVenta") & " " & refaVista.BuscarMensaje("MsgBox", "XEnvase"), 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(vtaenvase, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & " " & refaVista.BuscarMensaje("MsgBox", "XVendido"), 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(vtatotal, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVenta") & " " & refaVista.BuscarMensaje("MsgBox", "XCancelada"), 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(vtacanceladas, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        If tddescuento + descuentoimp + descuentovendedor <> 0 Then
            cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDescuentos"), 24, Alineacion.Izquierda, False)
            cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            cad &= CompletaHasta(Format(tddescuento + descuentoimp + descuentovendedor, "0.00"), 14, Alineacion.Derecha, True)
            sw.WriteLine(cad)
        End If

        'If impuesto <> 0 Then
        '    cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XImpuestos"), 24, Alineacion.Izquierda, False)
        '    cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        '    cad &= CompletaHasta(impuesto, 14, Alineacion.Derecha, True)
        '    sw.WriteLine(cad)
        'End If

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVenta").ToUpper & " " & refaVista.BuscarMensaje("MsgBox", "XNeta").ToUpper, 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(total, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XConsignacion").ToUpper, 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(dConsignacion - dDevolucionConsignacion, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)


        sw.WriteLine()

        cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToUpper & " " & refaVista.BuscarMensaje("MsgBox", "XCobranza").ToUpper, 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(totalabono, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        'cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCargo"), 24, Alineacion.Izquierda, False)
        'cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        'cad &= CompletaHasta(total + dConsignacion - dDevolucionConsignacion - totalabono, 14, Alineacion.Derecha, True)
        sw.WriteLine()

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XSaldoIniCte"), 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(totalSaldosCar, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XSaldoFinCte"), 24, Alineacion.Izquierda, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(Format(totalSaldosEfe, "0.00"), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)


        Dim tablaproductoprestamocli As DataTable = oDBVen.RealizarConsultaSQL("select p.nombre,saldocarga,cargo,abono,ppc.venta from productoprestamocli ppc inner join producto  p on ppc.productoclave = p.productoclave", "ProductoPrestamoCli")
        sw.WriteLine()

        If tablaproductoprestamocli.Rows.Count > 0 Then
            sw.WriteLine(TextoCentradoConSymbolo(refaVista.BuscarMensaje("MsgBox", "XMovimientoEnv"), "-"))
            cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XEnv"), 12, Alineacion.Izquierda, False)
            cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XIni"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCar"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XAbo"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XFin"), 8, Alineacion.Derecha, True)

            sw.WriteLine(cad)
            ImprimeLineaPunteada(sw, LongTot)

            For Each row As DataRow In tablaproductoprestamocli.Rows
                cad = CompletaHasta(row("nombre"), 12, Alineacion.Izquierda, False)
                cad &= CompletaHasta(row("saldocarga"), 7, Alineacion.Derecha, False)
                cad &= CompletaHasta(row("cargo"), 7, Alineacion.Derecha, False)
                cad &= CompletaHasta(row("abono"), 7, Alineacion.Derecha, False)
                cad &= CompletaHasta(row("venta"), 7, Alineacion.Derecha, False)
                cad &= CompletaHasta(row("saldocarga") + row("cargo") - row("abono") - row("venta"), 8, Alineacion.Derecha, True)

                sw.WriteLine(cad)

            Next
            ImprimeLineaPunteada(sw, LongTot)
            cad = CompletaHasta("", 12, Alineacion.Izquierda, False)
            cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(saldocarga)", ""), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(cargo)", ""), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(abono)", ""), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(venta)", ""), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(saldocarga)", "") + tablaproductoprestamocli.Compute("SUM(cargo)", "") - tablaproductoprestamocli.Compute("SUM(abono)", "") - tablaproductoprestamocli.Compute("SUM(venta)", ""), 8, Alineacion.Derecha, True)

            sw.WriteLine(cad)
        End If


        tablaproductoprestamocli.Dispose()
        tablaDetalle.Dispose()
        tablaTransprod.Dispose()
        tabla.Dispose()



        EspaciosAlFinal(sw)

    End Sub
    Private Sub ReporteListaPrecio(ByVal sw As StreamWriter, ByVal parsListaPrecioClave As String, ByVal parsListaPrecioNombre As String)
        Dim sQuery, Cad As String
        sQuery = "SELECT Producto.ProductoClave, Producto.Nombre,"
        sQuery &= "UnidadCobranza,MonedaId,Precio, minimo, maximo "
        sQuery &= "FROM PrecioProductoVig "
        sQuery &= "INNER JOIN  Producto  ON Producto.ProductoClave = PrecioProductoVig.ProductoClave "
        sQuery &= "WHERE PrecioClave ='" & parsListaPrecioClave & "' AND (convert(nvarchar(10), getdate(), 112) between convert(nvarchar(10),PrecioProductoVig.PPVFechaInicio,112) and convert(nvarchar(10),PrecioProductoVig.Fechafin,112)) "
        sQuery &= "order by Producto.ProductoClave, minimo "

        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XRuta") & ": " & oAgenda.RutaActual.RUTClave, LongTot))
        sw.WriteLine(TextoCentrado(ValorReferencia.BuscarEquivalente("REPORTEM", 25), LongTot))
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

        sw.WriteLine(TextoCentrado(parsListaPrecioClave & "-" & parsListaPrecioNombre, LongTot))
        ImprimeLineaPunteada(sw, LongTot)

        Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 12, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 10, Alineacion.Izquierda, False)
        Cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XPU"), 26, Alineacion.Derecha, True)
        sw.WriteLine(Cad)

        ImprimeLineaPunteada(sw, LongTot)

        Dim dtPrecios As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "ListaPrecio")

        For Each fila As DataRow In dtPrecios.Rows
            Cad = CompletaHasta(fila("ProductoClave"), 20, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(fila("Nombre"), 28, Alineacion.Izquierda, True)
            sw.WriteLine(Cad)
            Cad = "          " & CompletaHasta(ValorReferencia.BuscarEquivalente("UCOBRA", fila("UnidadCobranza")), 12, Alineacion.Izquierda, False)
            Cad &= CompletaHasta("$", 2, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(FormatNumber(fila("Precio"), 2), 11, Alineacion.Derecha, False)
            Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("CDGOMON", fila("MonedaId")), 4, Alineacion.Izquierda, False)
            Cad &= CompletaHasta("(" & fila("Minimo") & "-" & fila("Maximo") & ")", 9, Alineacion.Derecha, True)
            
            sw.WriteLine(Cad)
        Next
        ImprimeLineaPunteada(sw, LongTot)
        EspaciosAlFinal(sw)
    End Sub
    Private Sub ReporteLiquidacion(ByVal sw As StreamWriter)
        Try
            Dim bHuboRegistros As Boolean = False
            Dim QFecha = String.Empty, Cad As String = String.Empty
            Dim Q As New Text.StringBuilder
            Dim GranTotal, DescuentoDet As Double
            Dim blnTotales As Boolean = False
            QFecha = FechaConvertida("fechacaptura")
            '************************
            'RESUMEN DE MOVIMIENTOS
            '************************
            Dim Tipo As Integer
            Dim sProducto As String = ""
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 28, Alineacion.Izquierda, False)
            'Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 10, Alineacion.Izquierda, False)
            Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 10, Alineacion.Derecha, False)
            Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPromocion"), 10, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            ImprimeLineaPunteada(sw, LongTot)

            'Para Todos los movimientos menos Facturas (ese va a parte)
            Q.Append("select TransProd.Tipo, Producto.Nombre, TransProdDetalle.TipoUnidad, ")
            Q.Append("sum(TransProdDetalle.Cantidad) as Cantidad, ")
            Q.Append("sum(TransProdDetalle.DescuentoImp) as DescuentoDet, TransProdDetalle.Promocion ")
            Q.Append("from TransProd ")
            Q.Append("inner join TransProdDetalle on TransProd.TransProdID = TransProdDetalle.TransProdID ")
            Q.Append("inner join Producto on TransProdDetalle.ProductoClave = Producto.ProductoClave ")
            Q.Append("where TransProd.TipoFase <> 0 ")
            Q.Append("and " & QFecha & " ")
            Q.Append("group by TransProd.Tipo, Producto.Nombre, TransProdDetalle.TipoUnidad, TransProdDetalle.Promocion ")
            Q.Append("order by TransProd.Tipo, Producto.Nombre, TransProdDetalle.TipoUnidad ")
            Dim dtMovimientos As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")

            Q.Remove(0, Q.Length)

            'Descuentos
            Q.Append("Select TransProd.Tipo,sum(transprod.total) as Total,sum(transprod.descuentovendedor) as DescuentoVendedor, sum(transprod.descuentoimp) as DescuentoImp ")
            Q.Append("from TransProd ")
            Q.Append("where TransProd.TipoFase <>0 ")
            Q.Append("and " & QFecha & " group by transprod.tipo ")

            Dim dtTotales As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Totales")

            For Each Dr As DataRow In dtMovimientos.Rows
                bHuboRegistros = True
                If Tipo <> Dr("tipo") Then
                    blnTotales = False
                    sProducto = ""
                    If Tipo <> Nothing AndAlso Tipo = 1 Then
                        blnTotales = True
                        Dim aDr() As DataRow = dtTotales.Select("Tipo=" & Tipo)
                        If aDr.Length > 0 Then
                            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 35, Alineacion.Derecha, False)
                            Cad &= CompletaHasta("$ " & FormatNumber(IIf(IsDBNull(aDr(0)("total")), 0, aDr(0)("total")), 2), 13, Alineacion.Derecha, True)
                            sw.WriteLine(Cad)

                            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescuento") & ":", 35, Alineacion.Derecha, False)
                            Cad &= CompletaHasta("$ " & FormatNumber(IIf(IsDBNull(aDr(0)("descuentovendedor")), 0, aDr(0)("descuentovendedor")) + IIf(IsDBNull(aDr(0)("descuentoimp")), 0, aDr(0)("descuentoimp")) + DescuentoDet, 2), 13, Alineacion.Derecha, True)
                            sw.WriteLine(Cad)
                            sw.WriteLine()
                        End If
                    End If
                    DescuentoDet = 0
                    Tipo = Dr("tipo")
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", Dr("tipo")).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", Dr("tipo"))).ToUpper)
                End If

                If Not IsDBNull(Dr("descuentodet")) Then
                    DescuentoDet += CDbl(Dr("descuentodet"))
                End If
                If sProducto <> Dr("Nombre") Then
                    Cad = CompletaHasta(Dr("Nombre"), 28, Alineacion.Izquierda, False)
                    sw.WriteLine(Cad)
                    sProducto = Dr("Nombre")
                End If

                Cad = CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")), 28, Alineacion.Izquierda, False)
                If Not IsDBNull(Dr("Promocion")) AndAlso Dr("Promocion") = 2 Then
                    Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 20, Alineacion.Derecha, True)
                Else
                    Cad &= CompletaHasta(FormatNumber(Dr("cantidad"), 0), 10, Alineacion.Derecha, True)
                End If
                sw.WriteLine(Cad)
            Next
            dtMovimientos.Dispose()

            If bHuboRegistros And Not blnTotales AndAlso Tipo = 1 Then
                Dim aDr() As DataRow = dtTotales.Select("Tipo=" & Tipo)
                If aDr.Length > 0 Then
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta("$ " & FormatNumber(IIf(IsDBNull(aDr(0)("total")), 0, aDr(0)("total")), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)

                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescuento") & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta("$ " & FormatNumber(IIf(IsDBNull(aDr(0)("descuentovendedor")), 0, aDr(0)("descuentovendedor")) + IIf(IsDBNull(aDr(0)("descuentoimp")), 0, aDr(0)("descuentoimp")) + DescuentoDet, 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    sw.WriteLine()
                End If
                DescuentoDet = 0
            End If
            dtTotales.Dispose()
            bHuboRegistros = False
            ImprimeLineaPunteada(sw, LongTot)
            '************************
            'COBRANZA
            '************************

            '*************************
            ' para el tipo de Abonos Programados
            '************************
            'Dim dblTotalAbonoProgramado As Double
            Dim dtTotalAbonoProgramado As DataTable
            Dim strSQLAbonoProgramado As String
            Dim dtTotalAbonos As DataTable
            Dim strSQLTotalAbonos As String
            'Dim dblTotalAbonos As Double
            Dim strSQLAbonoDetalle As String
            Dim dblTotalAbonoDetalle As Double

            Dim dblTotalProgramado As Double

            Dim strFechaProgramada As String
            strFechaProgramada = FechaConvertida("fechapromesa")

            strSQLAbonoProgramado = String.Format("select case isnull(Sum(Importe)) when 0 then Sum(Importe) else 0 end as TotalAbonosProg,Visita.CLienteCLave from visita inner join AbonoProgramado on Visita.VisitaClave=AbonoProgramado.VisitaClave  where {0} group by Visita.ClienteClave", strFechaProgramada)
            'dblTotalAbonoProgramado = odbVen.EjecutarCmdScalardblSQL(strSQLAbonoProgramado)
            dtTotalAbonoProgramado = oDBVen.RealizarConsultaSQL(strSQLAbonoProgramado, "AbonoProgramado")

            Dim strFechaAbono As String
            strFechaAbono = FechaConvertida("Abono.FechaAbono")

            strSQLTotalAbonos = String.Format("select case isnull(Sum(Total)) when 0 then Sum(Total) else 0 end as TotalAbonos,Visita.CLienteCLave from visita inner join Abono " & _
                                            "on Visita.VisitaClave=Abono.VisitaClave Where {0} group by Visita.ClienteClave", strFechaAbono)

            dtTotalAbonos = oDBVen.RealizarConsultaSQL(strSQLTotalAbonos, "TotalAbonos")
            For Each dr As DataRow In dtTotalAbonoProgramado.Rows
                Dim dr2() As DataRow = dtTotalAbonos.Select("ClienteClave='" & dr("ClienteClave") & "'")
                If dr2.Length > 0 Then
                    dblTotalProgramado = CType(dr2(0)("TotalAbonos"), Double) - CType(dr("TotalAbonosProg"), Double)
                    If dblTotalProgramado <= 0 Then

                        strSQLAbonoDetalle = String.Format("select case isnull(Sum(ABNDetalle.Importe)) when 0 then Sum(ABNDetalle.Importe) else 0 end as TotalAbonos from visita inner join Abono " & _
                              "on Visita.VisitaClave=Abono.VisitaClave inner join ABNDetalle on Abono.ABNId=ABNDetalle.ABNId Where {0} ", strFechaAbono)
                        strSQLAbonoDetalle &= " and ClienteClave ='" & dr("ClienteClave") & "'"

                        dblTotalAbonoDetalle += oDBVen.EjecutarCmdScalardblSQL(strSQLAbonoDetalle)
                    Else
                        dblTotalAbonoDetalle += CType(dr("TotalAbonosProg"), Double)
                    End If
                End If
            Next
            dtTotalAbonos.Dispose()
            dtTotalAbonoProgramado.Dispose()

            'Hacer los calculos
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XCobranza1"), LongTot))
            sw.WriteLine()

            sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XAbonoProgramado"), 30, Alineacion.Izquierda, False) & CompletaHasta("$ " & FormatNumber(dblTotalAbonoDetalle, 2), 18, Alineacion.Derecha, False))
            sw.WriteLine()

            'Para todos los tipos de pagos menos efectivo
            Q.Remove(0, Q.Length)

            Dim aGrupo As New ArrayList()
            aGrupo.Add("E")
            Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
            Q.Append("select abndetalle.tipopago, abndetalle.tipobanco, sum(abndetalle.importe) as Importe ")
            Q.Append("from abono, abndetalle, visita ")
            Q.Append("where abono.abnid=abndetalle.abnid ")
            Q.Append("and abono.visitaclave=visita.visitaclave ")
            Q.Append("and abono.diaclave=visita.diaclave ")
            Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' ")
            Q.Append("and " & FechaConvertida("abono.fechaabono") & " ")
            If sVarCodigos.Length > 0 Then
                Q.Append("and not abndetalle.tipopago in(" & sVarCodigos & ") ")
            End If
            Q.Append("group by tipopago, tipobanco ")
            'TODO: Probar Cambio TipoPago
            For Each Dr As DataRow In oDBVen.RealizarConsultaSQL(Q.ToString, "CheqyDep").Rows
                'Cad = CompletaHasta(ValorReferencia.RecuperarLista("PAGO", Dr("tipopago")).Rows(0).Item(1), 15, Alineacion.Izquierda, False)
                Cad = CompletaHasta(ValorReferencia.BuscarEquivalente("PAGO", Dr("tipopago")), 15, Alineacion.Izquierda, False)
                If Not IsDBNull(Dr("TipoBanco")) Then
                    'Cad &= CompletaHasta(ValorReferencia.RecuperarLista("TBANCO", Dr("tipobanco")).Rows(0).Item(1), 15, Alineacion.Izquierda, False)
                    Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("TBANCO", Dr("tipobanco")), 15, Alineacion.Izquierda, False)
                Else
                    Cad &= CompletaHasta("", 15, Alineacion.Izquierda, False)
                End If
                Cad &= CompletaHasta("$ " & FormatNumber(Dr("importe"), 2), 18, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                GranTotal += CDbl(Dr("importe"))
            Next
            'If GranTotal > 0 Then
            sw.WriteLine()
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalDocumentos") & ":", 30, Alineacion.Derecha, False)
            Cad &= CompletaHasta("$ " & FormatNumber(GranTotal, 2), 18, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            'End If

            'Para el tipo de pago Efectivo
            Q.Remove(0, Q.Length)
            'TODO: Probar Cambio TipoPago
            If sVarCodigos.Length > 0 Then
                Q.Append("select abndetalle.tipopago, sum(abndetalle.importe) as Importe ")
                Q.Append("from abono, abndetalle, visita ")
                Q.Append("where abono.abnid=abndetalle.abnid ")
                Q.Append("and abono.visitaclave=visita.visitaclave ")
                Q.Append("and abono.diaclave=visita.diaclave ")
                Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' ")
                Q.Append("and " & FechaConvertida("abono.fechaabono") & " ")
                Q.Append("and abndetalle.tipopago in(" & sVarCodigos & ") group by tipopago ")
                For Each Dr As DataRow In oDBVen.RealizarConsultaSQL(Q.ToString, "Efevo").Rows
                    'Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & " " & ValorReferencia.RecuperarLista("PAGO", Dr("tipopago")).Rows(0).Item(1) & ":", 30, Alineacion.Derecha, False)
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & " " & ValorReferencia.BuscarEquivalente("PAGO", Dr("tipopago")) & ":", 30, Alineacion.Derecha, False)
                    Cad &= CompletaHasta("$ " & FormatNumber(Dr("importe"), 2), 18, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)
                    GranTotal += CDbl(Dr("importe"))
                Next
            End If
            'El total
            sw.WriteLine()
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & ":", 30, Alineacion.Derecha, False)
            Cad &= CompletaHasta("$ " & FormatNumber(GranTotal, 2), 18, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            GranTotal = 0
            ImprimeLineaPunteada(sw, LongTot)
            bHuboRegistros = False
            '************************
            'DEPOSITOS
            '************************
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XDepositosVendedor"), LongTot))
            sw.WriteLine()
            Dim Total As Double
            Dim CadTot = "", Fecha = "", Ficha As String = ""
            Dim Banco As Integer
            Q.Remove(0, Q.Length)

            Q.Append("select deposito.fechadeposito, Deposito.ficha, deposito.tipobanco, ")
            Q.Append("abndetalle.tipopago, abddep.importe ")
            Q.Append("from deposito, abddep, abndetalle ")
            Q.Append("where deposito.depid=abddep.depid ")
            Q.Append("and abddep.abnid=abndetalle.abnid ")
            Q.Append("and abddep.abdid=abndetalle.abdid ")
            Q.Append("and " & FechaConvertida("deposito.fechadeposito") & " ")
            Q.Append(" order by tipobanco, fechadeposito, ficha ")
            For Each Dr As DataRow In oDBVen.RealizarConsultaSQL(Q.ToString, "Depositos").Rows
                bHuboRegistros = True
                'Para ver si imprimo la ficha
                If Ficha <> Dr("ficha") Then
                    If Ficha <> Nothing Then
                        CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 33, Alineacion.Derecha, False)
                        CadTot &= CompletaHasta(FormatNumber(Total, 2), 15, Alineacion.Derecha, True)
                        sw.WriteLine(CadTot)
                        sw.WriteLine()
                    End If
                    Total = 0
                    Ficha = Dr("ficha")
                    Cad = CompletaHasta("  " & Ficha, 18, Alineacion.Izquierda, False)
                Else
                    Cad = CompletaHasta(" ", 18, Alineacion.Izquierda, False)
                End If
                'Para ver si imprimo lo del banco
                If Banco <> Dr("tipobanco") Then
                    Banco = Dr("tipobanco")
                    Fecha = Nothing
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TBANCO", Banco).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TBANCO", Banco)).ToUpper)
                End If
                'Para ver si imprimo la fecha
                If Fecha <> Format(Dr("fechadeposito"), "dd/MM/yyyy") Then
                    Fecha = Format(Dr("fechadeposito"), "dd/MM/yyyy")
                    sw.WriteLine("  " & Fecha)
                End If
                'Cad &= CompletaHasta(ValorReferencia.RecuperarLista("PAGO", Dr("tipopago")).Rows(0).Item(1), 15, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("PAGO", Dr("tipopago")), 15, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Dr("importe"), 2), 15, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                Total += CDbl(Dr("importe"))
                GranTotal += CDbl(Dr("importe"))
            Next
            If bHuboRegistros Then
                CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 33, Alineacion.Derecha, False)
                CadTot &= CompletaHasta(FormatNumber(Total, 2), 15, Alineacion.Derecha, True)
                sw.WriteLine(CadTot)
                sw.WriteLine()
            End If
            CadTot = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalDepositos") & ":", 33, Alineacion.Derecha, False)
            CadTot &= CompletaHasta("$ " & FormatNumber(GranTotal, 2), 15, Alineacion.Derecha, True)
            sw.WriteLine(CadTot)
            ImprimeLineaPunteada(sw, LongTot)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteLiquidacion")
        End Try
    End Sub
    Private Sub ReporteLiquidacionPoblana(ByVal sw As StreamWriter)
        Try
            Dim bHuboRegistros As Boolean = False
            Dim QFecha = String.Empty, Cad As String = String.Empty
            Dim Q As New Text.StringBuilder
            Dim GranTotal, DescuentoDet As Double

            QFecha = FechaConvertida("fechacaptura")
            '************************
            'RESUMEN DE MOVIMIENTOS
            '************************
            Dim Tipo As Integer
            Dim sProducto As String = ""
            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto"), 28, Alineacion.Izquierda, False)

            Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 10, Alineacion.Derecha, False)
            Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPromocion"), 10, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            ImprimeLineaPunteada(sw, LongTot)

            'Para Todos los movimientos menos Facturas (ese va a parte)
            Q.Append("select TransProd.transprodid,TransProd.Tipo,TransProd.cfvtipo,TransProdDetalle.ProductoClave , Producto.Nombre, TransProdDetalle.TipoUnidad, sum(TransProdDetalle.DescuentoImp) as DescuentoDet ")
            Q.Append("from TransProd ")
            Q.Append("inner join TransProdDetalle on TransProd.TransProdID = TransProdDetalle.TransProdID ")
            Q.Append("inner join Producto on TransProdDetalle.ProductoClave = Producto.ProductoClave ")
            Q.Append("where TransProd.Tipo in (1,24)  and TransProd.TipoFase<>0 ")
            Q.Append("and " & QFecha & " ")
            Q.Append("group by TransProd.transprodid,TransProd.Tipo, TransProdDetalle.ProductoClave,Producto.Nombre, TransProdDetalle.TipoUnidad, TransProd.cfvtipo ")
            Q.Append("order by TransProd.Tipo, Producto.Nombre, TransProdDetalle.TipoUnidad ")
            Dim dtMovimientos As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Movimientos")

            Q.Remove(0, Q.Length)
            Q.Append("Select sum(transprod.total) as Total,sum(transprod.descuentovendedor) as DescuentoVendedor, sum(transprod.descuentoimp) as DescuentoImp ")


            Q.Append("from TransProd ")
            Q.Append("where TransProd.Tipo in (1,24) and TransProd.TipoFase <>0 ")
            Q.Append("and " & QFecha)
            Dim dtTotales As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Totales")

            For Each Dr As DataRow In dtMovimientos.Rows
                bHuboRegistros = True
                If Tipo <> Dr("tipo") Then

                    sProducto = ""


                    DescuentoDet = 0
                    Tipo = Dr("tipo")
                    'sw.WriteLine(CStr(ValorReferencia.RecuperarLista("TRPTIPO", Dr("tipo")).Rows(0).Item(1)).ToUpper)
                    sw.WriteLine(CStr(ValorReferencia.BuscarEquivalente("TRPTIPO", Dr("tipo"))).ToUpper)
                End If

                If Not IsDBNull(Dr("descuentodet")) Then
                    DescuentoDet += CDbl(Dr("descuentodet"))
                End If
                If sProducto <> Dr("Nombre") Then
                    Cad = CompletaHasta(Dr("Nombre"), 28, Alineacion.Izquierda, False)
                    sw.WriteLine(Cad)
                    sProducto = Dr("Nombre")
                End If

                Cad = CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("tipounidad")), 28, Alineacion.Izquierda, False)

                Dim tCant As DataTable = oDBVen.RealizarConsultaSQL("select sum(case when promocion=2 then cantidad else 0 end)as promo, sum(case when promocion<>2 then cantidad else 0 end)as venta from transproddetalle where transprodid='" & Dr("transprodid") & "' and productoclave='" & Dr("ProductoClave") & "' and TipoUnidad='" & Dr("TipoUnidad") & "'", "cantidades")

                Cad &= CompletaHasta(FormatNumber(tCant.Rows(0)("venta"), 0), 10, Alineacion.Derecha, True)
                Cad &= CompletaHasta(FormatNumber(tCant.Rows(0)("promo"), 0), 10, Alineacion.Derecha, True)

                sw.WriteLine(Cad)
            Next
            dtMovimientos.Dispose()

            If bHuboRegistros Then

                Dim aDr() As DataRow = dtTotales.Select()
                If aDr.Length > 0 Then
                    sw.WriteLine()
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta("$ " & FormatNumber(IIf(IsDBNull(aDr(0)("total")), 0, aDr(0)("total")), 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)

                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescuento") & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta("$ " & FormatNumber(IIf(IsDBNull(aDr(0)("descuentovendedor")), 0, aDr(0)("descuentovendedor")) + IIf(IsDBNull(aDr(0)("descuentoimp")), 0, aDr(0)("descuentoimp")) + DescuentoDet, 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)


                    Q.Remove(0, Q.Length)
                    Q.Append("Select case when isnull(sum(transprod.total))=1 then 0 else sum(transprod.total) end as Total  ")
                    Q.Append("from TransProd ")
                    Q.Append("where TransProd.TipoFase<>0 ")
                    Q.Append("and ((transprod.tipo=1 and cfvtipo=2)or transprod.tipo=24) and " & QFecha)
                    Dim Credito As Decimal = oDBVen.EjecutarCmdScalardblSQL(Q.ToString)
                    Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalCredito") & ":", 35, Alineacion.Derecha, False)
                    Cad &= CompletaHasta("$ " & FormatNumber(Credito, 2), 13, Alineacion.Derecha, True)
                    sw.WriteLine(Cad)


                    sw.WriteLine()

                End If


                DescuentoDet = 0
            End If
            dtTotales.Dispose()
            bHuboRegistros = False
            ImprimeLineaPunteada(sw, LongTot)
            '************************
            'COBRANZA
            'Para el tipo de pago Efectivo


            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XCobranza1"), LongTot))
            sw.WriteLine()

            Dim dEfectivo As Decimal = oDBVen.EjecutarCmdScalardblSQL("select sum(abndetalle.importe) as Importe from abono inner join abndetalle on abono.abnid=abndetalle.abnid inner join visita on  abono.visitaclave=visita.visitaclave and abono.diaclave=visita.diaclave inner join abntrp on abntrp.abnid=abono.abnid inner join transprod on abntrp.transprodid=transprod.transprodid where   visita.vendedorid='" & oVendedor.VendedorId & "' and " & FechaConvertida("abntrp.fechahora") & " and transprod.cfvtipo=1 and transprod.tipo=1 and transprod.tipofase<>0")
            Dim dCobranza As Decimal = oDBVen.EjecutarCmdScalardblSQL("select sum(abndetalle.importe) as Importe from abono inner join abndetalle on abono.abnid=abndetalle.abnid inner join visita on  abono.visitaclave=visita.visitaclave and abono.diaclave=visita.diaclave inner join abntrp on abntrp.abnid=abono.abnid inner join transprod on abntrp.transprodid=transprod.transprodid where   visita.vendedorid='" & oVendedor.VendedorId & "' and " & FechaConvertida("abntrp.fechahora") & " and transprod.tipofase<>0 and ((transprod.tipo=1 and transprod.cfvtipo=2) or  transprod.tipo=24)  ")

            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalDepositos") & ":", 33, Alineacion.Derecha, False)
            Cad = CompletaHasta("Total Contado" & ":", 33, Alineacion.Derecha, False)
            Cad &= CompletaHasta("$ " & FormatNumber(dEfectivo, 2), 15, Alineacion.Derecha, True)
            sw.WriteLine(Cad)

            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalCobranza") & ":", 33, Alineacion.Derecha, False)
            Cad &= CompletaHasta("$ " & FormatNumber(dCobranza, 2), 15, Alineacion.Derecha, True)
            sw.WriteLine(Cad)


            Cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotalDepositos") & ":", 33, Alineacion.Derecha, False)
            Cad &= CompletaHasta("$ " & FormatNumber(dEfectivo + dCobranza, 2), 15, Alineacion.Derecha, True)
            sw.WriteLine(Cad)
            sw.WriteLine()
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteLiquidacion")
        End Try
    End Sub
    Private Sub ReportePromociones(ByRef sw As StreamWriter)
        Try
            Dim Q, Cad As String

            Q = "Select promocionclave, promocion.nombre, promocion.tipoaplicacion, promocion.fechafinal, promocion.tiporegla, promocion.seleccionproducto, promocion.capturacantidad, promocion.Tipo from promocion where promocion.TipoEstado=1 and getdate() between promocion.FechaInicial and promocion.FechaFinal  "

            Dim dtPromociones As DataTable = oDBVen.RealizarConsultaSQL(Q, "Promociones")
            For Each Dr As DataRow In dtPromociones.Rows
                Cad = CompletaHasta(Dr("promocionclave"), 12, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("nombre"), 32, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("tipoaplicacion"), 4, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                If Dr("Tipo") = 4 Then
                    Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes2", "XSeleccionarProducto") & ": " & IIf(Dr("SeleccionProducto"), refaVista.BuscarMensaje("Mensajes", "XSi"), refaVista.BuscarMensaje("Mensajes", "XNo")), 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                    Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes2", "XCapturarCantidad") & ": " & IIf(Dr("CapturaCantidad"), refaVista.BuscarMensaje("Mensajes", "XSi"), refaVista.BuscarMensaje("Mensajes", "XNo")), 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                End If
                Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XFinaliza") & ":", 14, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Format(Dr("fechafinal"), "dd/MM/yyyy"), 34, Alineacion.Izquierda, True)
                sw.WriteLine(Cad)
                '*******************************
                'Si la promoción es de productos, se muestran los productos
                If Dr("Tipo") = 1 Then
                    sw.WriteLine("  " & refaVista.BuscarMensaje("Mensajes", "XPromocionAplicadaA"))
                    Dim oDT2 As DataTable = oDBVen.RealizarConsultaSQL("select distinct Producto.ProductoClave,producto.nombre from producto inner join promocionproducto on promocionproducto.productoclave=producto.productoclave where promocionproducto.promocionclave='" & Dr("promocionclave") & "'", "PromProd")
                    For Each Dr2 As DataRow In oDT2.Rows
                        Cad = CompletaHasta("   - " & Dr2("nombre"), 32, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                    Next
                    If oDT2.Rows.Count > 0 Then sw.WriteLine()
                    oDT2.Dispose()
                Else
                    sw.WriteLine("  " & refaVista.BuscarMensaje("Mensajes", "XPromocionAplicadaA"))
                    Dim oDT2 As DataTable = oDBVen.RealizarConsultaSQL("Select Esquema.Nombre from promociondetalle inner join Esquema on Esquema.EsquemaID = promociondetalle.EsquemaID where promociondetalle.promocionclave='" & Dr("promocionclave") & "'", "PromProd")
                    For Each Dr2 As DataRow In oDT2.Rows
                        Cad = CompletaHasta("   - " & Dr2("nombre"), 32, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                    Next
                    If oDT2.Rows.Count > 0 Then sw.WriteLine()
                    oDT2.Dispose()


                    sw.WriteLine("  " & refaVista.BuscarMensaje("Mensajes2", "XEnProductos"))
                    Dim oDT3 As DataTable = oDBVen.RealizarConsultaSQL("select distinct producto.nombre from producto inner join promocionproducto on promocionproducto.productoclave=producto.productoclave where promocionproducto.promocionclave='" & Dr("promocionclave") & "'", "PromProd")
                    For Each Dr3 As DataRow In oDT3.Rows
                        Cad = CompletaHasta("   - " & Dr3("nombre"), 32, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                    Next
                    If oDT3.Rows.Count > 0 Then sw.WriteLine()
                    oDT3.Dispose()
                End If
                '*****************************
                Dim dtPromocionRegla As DataTable = oDBVen.RealizarConsultaSQL("select minimo, maximo, porcentaje, importe, precioclave, promocionreglaid from promocionregla where promocionclave='" & Dr("promocionclave") & "'", "PromocionRegla")
                For Each Dr2 As DataRow In dtPromocionRegla.Rows
                    Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XRangoVentas"), 18, Alineacion.Izquierda, False)
                    If Dr("TipoRegla") = 2 Then
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XPorCada") & ": " & FormatNumber(Dr2("minimo"), 2), 30, Alineacion.Izquierda, True)
                    Else
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDe") & ": " & FormatNumber(Dr2("minimo"), 2), 15, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XA") & ": " & FormatNumber(Dr2("maximo"), 2), 15, Alineacion.Izquierda, True)
                    End If
                    sw.WriteLine(Cad)
                    If Dr("tipoaplicacion") = 1 Then
                        Cad = CompletaHasta("    " & refaVista.BuscarMensaje("Mensajes", "XPorcentaje") & ":", 25, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(FormatNumber(Dr2("porcentaje"), 2) & "%", 23, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                        sw.WriteLine()
                    ElseIf Dr("tipoaplicacion") = 2 Then
                        Cad = CompletaHasta("    " & refaVista.BuscarMensaje("Mensajes", "XImporte") & ":", 25, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta("$" & FormatNumber(Dr2("importe"), 2), 23, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                        sw.WriteLine()
                    ElseIf Dr("tipoaplicacion") = 3 Then
                        Cad = CompletaHasta("    " & refaVista.BuscarMensaje("Mensajes", "XListaPrecio") & ":", 25, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(oDBVen.RealizarConsultaSQL("select nombre from precio where precioclave='" & Dr2("precioclave") & "'", "ListaPrecios").Rows(0).Item(0), 23, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                        sw.WriteLine()
                    ElseIf Dr("tipoaplicacion") = 4 Then
                        Dim dtPromocionAplicacion As DataTable
                        dtPromocionAplicacion = oDBVen.RealizarConsultaSQL("select distinct Producto.nombre, PromocionAplicacion.PRUTipoUnidad,PromocionAplicacion.Cantidad  from PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoClave = Producto.ProductoClave where PromocionAplicacion.promocionclave='" & Dr("promocionclave") & "' and PromocionAplicacion.PromocionReglaId='" & Dr2("PromocionReglaId") & "'", "PromProd")
                        For Each Dr3 As DataRow In dtPromocionAplicacion.Rows
                            Cad = CompletaHasta("    " & Dr3("nombre"), 33, Alineacion.Izquierda, False)
                            Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr3("PRUTipoUnidad")), 10, Alineacion.Izquierda, False)
                            Cad &= CompletaHasta(Dr3("Cantidad"), 2, Alineacion.Derecha, True)
                            sw.WriteLine(Cad)
                        Next
                        dtPromocionAplicacion.Dispose()
                    End If
                Next
                dtPromocionRegla.Dispose()
                sw.WriteLine()
            Next
            dtPromociones.Dispose()
            ImprimeLineaPunteada(sw, LongTot)
            'Imprimo las descripciones de los Tipos
            sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XTipo").ToUpper & ":")
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("TAPPROM")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    sw.WriteLine(refDesc.Id & " = " & refDesc.Cadena)
                Next
            End If
            aValores = Nothing
            'Dim dtValores As DataTable = ValorReferencia.RecuperarLista("TAPPROM")
            'For Each Dr As DataRow In dtValores.Rows
            '    sw.WriteLine(Dr("VAVClave") & " = " & Dr("Descripcion"))
            'Next
            EspaciosAlFinal(sw, 5)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReportePromociones")
        End Try
    End Sub

    Private Sub ReporteSaldoProductoPrestado(ByRef sw As StreamWriter, ByVal Clientes As String)
        Try
            Dim sConsulta As New System.Text.StringBuilder
            Dim cad As New System.Text.StringBuilder
            If RadioButtonDetallado.Checked Then
                sConsulta.Append("Select Visita.ClienteClave,Producto.Nombre,ProductoPrestamo.CantidadPrestada as Cantidad,TransProd.Tipo from ProductoPrestamo ")
                sConsulta.Append("inner join TransProd on TransProd.TransProdId = ProductoPrestamo.TransProdId ")
                sConsulta.Append("inner join Visita on TransProd.VisitaClave = Visita.VisitaClave and TransProd.DiaClave = Visita.DiaClave ")
                sConsulta.Append("inner join Producto on Producto.ProductoClave = ProductoPrestamo.ProductoDetClave ")
                sConsulta.Append("where (TransProd.Tipo = 1 and TransProd.TipoFase<>0 ) ")
                If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                    sConsulta.Append("and Visita.ClienteClave in(" & Clientes & ") ")
                End If
                sConsulta.Append("UNION ALL ")
                sConsulta.Append("Select Visita.ClienteClave,Producto.Nombre,TransProdDetalle.Cantidad,TransProd.Tipo ")
                sConsulta.Append("from TransProdDetalle inner join TransProd on TransProd.TransProdId = TransProdDetalle.TransProdId ")
                sConsulta.Append("inner join Visita on TransProd.VisitaClave = Visita.VisitaClave and TransProd.DiaClave = Visita.DiaClave ")
                sConsulta.Append("inner join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave ")
                sConsulta.Append("where (TransProd.Tipo = 15) ")

                Dim dtDetalle As DataTable = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "Detalle")
                sConsulta = New System.Text.StringBuilder
                sConsulta.Append("Select ClienteClave,NombreCorto,SaldoPrestamo from Cliente where ClienteClave in( ")
                sConsulta.Append("Select distinct Visita.ClienteClave from productoprestamo ")
                sConsulta.Append("inner join TransProd on TransProd.TransProdId = ProductoPrestamo.TransProdId ")
                sConsulta.Append("inner join Visita on TransProd.VisitaClave = Visita.VisitaClave and TransProd.DiaClave = Visita.DiaClave ")
                sConsulta.Append("where (TransProd.Tipo = 1) ")
                If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
                    sConsulta.Append("and Visita.ClienteClave in(" & Clientes & ") ")
                End If
                sConsulta.Append("UNION ")
                sConsulta.Append("Select distinct Visita.ClienteClave from TransProdDetalle ")
                sConsulta.Append("inner join TransProd on TransProd.TransProdId = TransProdDetalle.TransProdId ")
                sConsulta.Append("inner join Visita on TransProd.VisitaClave = Visita.VisitaClave and TransProd.DiaClave = Visita.DiaClave  ")
                sConsulta.Append("where (TransProd.Tipo = 15)) ")

                For Each Dr As DataRow In oDBVen.RealizarConsultaSQL(sConsulta.ToString, "Promociones").Rows
                    cad = New System.Text.StringBuilder
                    cad.Append(CompletaHasta(CType(Dr("NombreCorto"), String).ToUpper, 48, Alineacion.Izquierda, True))
                    sw.WriteLine(cad)
                    sw.WriteLine()
                    'ProductoPrestado
                    Dim drProdPrestado() As DataRow = dtDetalle.Select(" ClienteClave ='" & Dr("ClienteClave") & "' AND Tipo=1")
                    cad = New System.Text.StringBuilder
                    cad.Append(CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XProductoPrestado"), 46, Alineacion.Izquierda, True))
                    sw.WriteLine(cad)
                    Dim iSumaPrestado As Integer = 0
                    For Each Dr2 As DataRow In drProdPrestado
                        cad = New System.Text.StringBuilder
                        cad.Append("    " & CompletaHasta(Dr2("Nombre"), 26, Alineacion.Izquierda, False))
                        cad.Append(CompletaHasta(Dr2("Cantidad"), 18, Alineacion.Derecha, True))
                        iSumaPrestado += Dr2("Cantidad")
                        sw.WriteLine(cad)
                    Next
                    cad = New System.Text.StringBuilder
                    cad.Append(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 40, Alineacion.Derecha, False))
                    cad.Append(CompletaHasta(iSumaPrestado, 8, Alineacion.Derecha, True))
                    sw.WriteLine(cad)
                    sw.WriteLine()
                    'Producto Devuelto
                    Dim drProdDevuelto() As DataRow = dtDetalle.Select(" ClienteClave ='" & Dr("ClienteClave") & "' AND Tipo=15")
                    cad = New System.Text.StringBuilder
                    cad.Append(CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XProductoDevuelto"), 46, Alineacion.Izquierda, True))
                    sw.WriteLine(cad)
                    Dim iSumaDevuelto As Integer = 0
                    For Each Dr2 As DataRow In drProdDevuelto
                        cad = New System.Text.StringBuilder
                        cad.Append("    " & CompletaHasta(Dr2("Nombre"), 26, Alineacion.Izquierda, False))
                        cad.Append(CompletaHasta(Dr2("Cantidad"), 18, Alineacion.Derecha, True))
                        iSumaDevuelto += Dr2("Cantidad")
                        sw.WriteLine(cad)
                    Next
                    cad = New System.Text.StringBuilder
                    cad.Append(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 40, Alineacion.Derecha, False))
                    cad.Append(CompletaHasta(iSumaDevuelto, 8, Alineacion.Derecha, True))
                    sw.WriteLine(cad)

                    cad = New System.Text.StringBuilder
                    cad.Append(CompletaHasta(CType(refaVista.BuscarMensaje("Mensajes", "XSaldo"), String).ToUpper, 40, Alineacion.Derecha, False))
                    cad.Append(CompletaHasta(Dr("SaldoPrestamo"), 8, Alineacion.Derecha, True))
                    sw.WriteLine(cad)
                    sw.WriteLine()
                Next
                dtDetalle.Dispose()
                ImprimeLineaPunteada(sw, LongTot)
            End If
            cad = New System.Text.StringBuilder
            cad.Append(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XSaldoProducto"), LongTot))
            sw.WriteLine(cad)
            sw.WriteLine()

            'SALDOS POR PRODUCTO
            sConsulta = New System.Text.StringBuilder
            sConsulta.Append("Select Producto.Nombre,sum(ProductoPrestamo.CantidadPrestada) as Cantidad,TransProd.Tipo from ProductoPrestamo ")
            sConsulta.Append("inner join TransProd on TransProd.TransProdId = ProductoPrestamo.TransProdId ")
            sConsulta.Append("inner join Producto on Producto.ProductoClave = ProductoPrestamo.ProductoDetClave ")
            sConsulta.Append("where (TransProd.Tipo = 1 and TransProd.TipoFase<>0) group by Producto.Nombre,TransProd.Tipo ")
            sConsulta.Append("UNION ")
            sConsulta.Append("Select Producto.Nombre,sum(TransProdDetalle.Cantidad) as cantidad,TransProd.Tipo ")
            sConsulta.Append("from TransProdDetalle inner join TransProd on TransProd.TransProdId = TransProdDetalle.TransProdId ")
            sConsulta.Append("inner join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave ")
            sConsulta.Append("where (TransProd.Tipo = 15) group by Producto.Nombre,TransProd.Tipo")

            Dim dtAgrupados As DataTable = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "Agrupados")
            'Producto Prestado
            Dim drProdPrestado2() As DataRow = dtAgrupados.Select("Tipo=1")
            cad = New System.Text.StringBuilder
            cad.Append("  " & CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProductoPrestado"), 46, Alineacion.Izquierda, True))
            sw.WriteLine(cad)
            Dim iSumaPrestado2 As Integer = 0
            For Each Dr2 As DataRow In drProdPrestado2
                cad = New System.Text.StringBuilder
                cad.Append("    " & CompletaHasta(Dr2("Nombre"), 26, Alineacion.Izquierda, False))
                cad.Append(CompletaHasta(Dr2("Cantidad"), 18, Alineacion.Derecha, True))
                iSumaPrestado2 += Dr2("Cantidad")
                sw.WriteLine(cad)
            Next
            cad = New System.Text.StringBuilder
            cad.Append(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 40, Alineacion.Derecha, False))
            cad.Append(CompletaHasta(iSumaPrestado2, 8, Alineacion.Derecha, True))
            sw.WriteLine(cad)
            sw.WriteLine()
            'Producto Devuelto
            Dim drProdDevuelto2() As DataRow = dtAgrupados.Select(" Tipo=15")
            cad = New System.Text.StringBuilder
            cad.Append(CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XProductoDevuelto"), 46, Alineacion.Izquierda, True))
            sw.WriteLine(cad)
            Dim iSumaDevuelto2 As Integer = 0
            For Each Dr2 As DataRow In drProdDevuelto2
                cad = New System.Text.StringBuilder
                cad.Append("    " & CompletaHasta(Dr2("Nombre"), 30, Alineacion.Izquierda, False))
                cad.Append(CompletaHasta(Dr2("Cantidad"), 18, Alineacion.Derecha, True))
                iSumaDevuelto2 += Dr2("Cantidad")
                sw.WriteLine(cad)
            Next
            dtAgrupados.Dispose()
            cad = New System.Text.StringBuilder
            cad.Append(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 40, Alineacion.Derecha, False))
            cad.Append(CompletaHasta(iSumaDevuelto2, 8, Alineacion.Derecha, True))
            sw.WriteLine(cad)

            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReportePromociones")
        End Try
    End Sub

    Private Function ObtieneTransProdIds(ByVal pardt As DataTable) As String
        Dim sTmp As String = ""
        For Each lDr As DataRow In pardt.Rows
            sTmp &= "'" & lDr("transprodid") & "',"
        Next
        If sTmp.Length > 0 Then
            sTmp = Microsoft.VisualBasic.Left(sTmp, sTmp.Length - 1)
        Else
            sTmp = "''"
        End If
        Return sTmp
    End Function

    Private Sub ReporteMovimientosSinInventarioConV(ByRef sw As StreamWriter, ByVal Clientes As String)
        Try
            If RadioButtonDetallado.Checked Then ' DETALLADO
                Dim strSQL As String
                Dim nTotal As Single
                strSQL = "select NombreCorto, CLI.ClienteClave, Folio, FechaCaptura, TPD.ProductoClave, Nombre, TipoUnidad, "
                strSQL &= "Cantidad, Precio, TPD.SubTotal, case isnull(TRP.DescVendPor) when 0 then TRP.DescVendPor else 0 end as DescVendPor,"
                strSQL &= "sum(case isnull(TDD.DesImporte) when 0 then TDD.DesImporte else 0 end) as DesImporte, TPD.Promocion,TPD.Impuesto,sum(case isnull(TDD.DesImpuesto) when 0 then TDD.DesImpuesto else 0 end) as DesImpuesto "
                strSQL &= "from TransProd TRP "
                strSQL &= "inner join TransProdDetalle TPD on TPD.TransProdId = TRP.TransProdId "
                strSQL &= "inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave "
                strSQL &= "inner Join Cliente CLI on TRP.ClienteClave = CLI.ClienteClave "
                strSQL &= "left join TpdDes TDD on TDD.TransProdId = TPD.TransProdId and TDD.TransProdDetalleId = TPD.TransProdDetalleId "
                strSQL &= "where TRP.Tipo = 21 and trp.tipofase<>0 " & IIf(CheckBoxFecha.Checked, " AND " & FechaConvertida("TRP.FechaCaptura"), "")

                If Clientes <> String.Empty Then
                    strSQL &= "and TRP.ClienteClave in (" & Clientes & ") "
                End If
                strSQL &= "group by  TRP.TransProdId, TPD.TransProdDetalleId, NombreCorto, CLI.ClienteClave, Folio, FechaCaptura, TPD.ProductoClave, Nombre, TipoUnidad, Cantidad, Precio, TPD.SubTotal, TRP.DescVendPor ,TPD.Promocion,TPD.Impuesto "
                strSQL &= "order by FechaCaptura, CLI.ClienteClave, Folio, TPD.ProductoClave"

                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(strSQL, "Resultado")
                Dim linea As String
                Dim aObj As Object = Nothing
                Dim aClien As Object = Nothing
                Dim dFecha As Object = Nothing
                Dim sFolio As String = ""
                Dim totalCte As Single = 0
                Dim totalFecha As Single = 0
                Dim totalFolio As Single
                Dim gtotal As Single = 0
                For Each Dr As DataRow In Dt.Rows
                    If dFecha <> Dr("FechaCaptura") Then
                        If sFolio <> "" Then
                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFolio") & ": " & FormatNumber(Math.Round(totalFolio, 2), 2), 48, Alineacion.Derecha, True)
                            totalFolio = 0
                            sw.WriteLine(linea)
                        End If
                        If (Not IsNothing(aClien)) Then
                            sw.WriteLine("")
                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalCte") & ": " & FormatNumber(Math.Round(totalCte, 2), 2), 48, Alineacion.Derecha, True)
                            totalCte = 0
                            sw.WriteLine(linea)
                        End If
                        If Not IsNothing(dFecha) Then

                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFecha") & ": " & FormatNumber(Math.Round(totalFecha, 2), 2), 48, Alineacion.Derecha, True)

                            'gtotal = 0
                            totalFecha = 0
                            sw.WriteLine(linea.ToUpper)
                        End If
                        linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XFechaMovimiento"), 10, Alineacion.Izquierda, False)
                        linea &= CompletaHasta(Dr("FechaCaptura"), 11, Alineacion.Izquierda, True)
                        sw.WriteLine(linea)
                        dFecha = Dr("FechaCaptura")
                        aClien = Nothing
                        sFolio = ""
                    End If
                    If aClien <> Dr("ClienteClave") Then
                        If sFolio <> "" Then
                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFolio") & ": " & FormatNumber(Math.Round(totalFolio, 2), 2), 48, Alineacion.Derecha, True)
                            totalFolio = 0
                            sw.WriteLine(linea)
                        End If
                        If (Not IsNothing(aClien)) Then
                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalCte") & ": " & FormatNumber(Math.Round(totalCte, 2), 2), 48, Alineacion.Derecha, True)
                            'gtotal += totalCte
                            totalCte = 0
                            sw.WriteLine("")
                            sw.WriteLine(linea)
                        End If
                        linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCliente"), 10, Alineacion.Izquierda, False)
                        linea &= CompletaHasta(Dr("NombreCorto"), 30, Alineacion.Izquierda, True)
                        sw.WriteLine(linea)
                        aClien = Dr("ClienteClave")
                        'dFecha = Nothing
                        sFolio = ""
                    End If

                    If sFolio <> Dr("Folio") Then
                        If sFolio <> "" Then
                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFolio") & ": " & FormatNumber(Math.Round(totalFolio, 2), 2), 48, Alineacion.Derecha, True)
                            totalFolio = 0
                            sw.WriteLine(linea)
                        End If
                        linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio"), 10, Alineacion.Izquierda, False)
                        linea &= CompletaHasta(Dr("Folio"), 11, Alineacion.Izquierda, True)
                        sw.WriteLine(linea)
                        sFolio = Dr("Folio")
                    End If
                    If aObj <> Dr("ProductoClave") Then
                        aObj = Dr("ProductoClave")
                        linea = CompletaHasta("", 4, Alineacion.Izquierda, False)
                        linea &= CompletaHasta(Dr("Nombre"), 40, Alineacion.Izquierda, True)
                        sw.WriteLine(linea)
                    End If
                    'nTotal = (Dr("SubTotal") - Dr("DesImporte") - (Dr("SubTotal") * (Dr("DescVendPor") / 100))) + (Dr("Impuesto") - ((Dr("Impuesto") - Dr("DesImpuesto")) * Dr("DescVendPor") / 100)) - Dr("DesImpuesto")
                    nTotal = (Dr("SubTotal") - Dr("DesImporte") - ((Dr("SubTotal") - Dr("DesImporte")) * (Dr("DescVendPor") / 100)))
                    nTotal = nTotal + (Dr("Impuesto") - ((Dr("Impuesto") - Dr("DesImpuesto")) * Dr("DescVendPor") / 100)) - Dr("DesImpuesto")

                    linea = CompletaHasta("", 5, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("TipoUnidad")), 10, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(Dr("Cantidad"), 10, Alineacion.Derecha, True)
                    linea &= CompletaHasta(IIf(Dr("Promocion") = 2, "*", FormatNumber(Math.Round(Convert.ToSingle(Dr("Precio")), 2), 2)), 10, Alineacion.Derecha, True)
                    linea &= CompletaHasta(IIf(Dr("Promocion") = 2, "", FormatNumber(Math.Round(nTotal, 2), 2)), 13, Alineacion.Derecha, True)
                    totalCte += nTotal
                    totalFecha += nTotal
                    totalFolio += nTotal
                    gtotal += nTotal
                    sw.WriteLine(linea)
                Next

                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFolio") & ": " & FormatNumber(Math.Round(totalFolio, 2), 2), 48, Alineacion.Derecha, True)
                sw.WriteLine(linea)
                sw.WriteLine("")
                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalCte") & ": " & FormatNumber(Math.Round(totalCte, 2), 2), 48, Alineacion.Derecha, True)
                sw.WriteLine(linea)
                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFecha") & ": " & FormatNumber(Math.Round(totalFecha, 2), 2), 48, Alineacion.Derecha, True)
                sw.WriteLine(linea.ToUpper)
                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & ": " & FormatNumber(Math.Round(gtotal, 2), 2), 48, Alineacion.Derecha, True)
                sw.WriteLine(linea)
                ImprimeLineaPunteada(sw, LongTot)
                'Sección de Productos Promocionales***************************************************

                strSQL = "select  TPD.ProductoClave, Nombre, TipoUnidad,sum(cantidad) as cantidad "
                strSQL &= "from TransProd TRP "
                strSQL &= "inner join TransProdDetalle TPD on TPD.TransProdId = TRP.TransProdId "
                strSQL &= "inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave "
                strSQL &= "inner Join Cliente CLI on TRP.ClienteClave = CLI.ClienteClave "
                strSQL &= "left join TpdDes TDD on TDD.TransProdId = TPD.TransProdId and TDD.TransProdDetalleId = TPD.TransProdDetalleId "
                strSQL &= "where tpd.promocion=2 and TRP.Tipo = 21 and trp.tipofase<>0   " & IIf(CheckBoxFecha.Checked, " AND " & FechaConvertida("TRP.FechaCaptura"), "")
                If Clientes <> String.Empty Then
                    strSQL &= "and TRP.ClienteClave in (" & Clientes & ") "
                End If
                strSQL &= "group by   TPD.ProductoClave, Nombre, TipoUnidad "


                Dt = oDBVen.RealizarConsultaSQL(strSQL, "Resultado")

                sw.WriteLine(refaVista.BuscarMensaje("Mensajes2", "XProductosPromocionales"))
                Dim sProductoNombre As String = String.Empty
                For Each dr As DataRow In Dt.Rows
                    'Asigno el nombre del producto en cuestión
                    If sProductoNombre <> dr("ProductoClave") Then
                        sProductoNombre = dr("ProductoClave")
                        If sProductoNombre <> Nothing Then
                            sw.WriteLine(sProductoNombre)
                        End If
                    End If
                    'El detalle de unidades del producto
                    linea = CompletaHasta(" - " & ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 22, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(dr("Cantidad"), 5, Alineacion.Derecha, False)
                    sw.WriteLine(linea)
                Next

                Dt.Clear()
                Dt.Dispose()
            ElseIf RadioButtonGeneral.Checked Then ' GENERAL
                Dim strSQL As String
                strSQL = "select TransProdID,NombreCorto, FechaCaptura, Folio, sum(total) as Total, sum(impuesto) as Impuesto "
                strSQL &= "from TransProd "
                strSQL &= "inner Join Cliente on TransProd.ClienteClave = Cliente.ClienteClave "
                strSQL &= "where TransProd.TipoFase <> 0 and TransProd.tipo = 21 " & IIf(CheckBoxFecha.Checked, " and " & FechaConvertida("TransProd.FechaCaptura"), "") & " "
                If Clientes <> String.Empty Then
                    strSQL &= "and TransProd.ClienteClave in (" & Clientes & ") "
                End If
                strSQL &= "group by TransProdID,NombreCorto, FechaCaptura, Folio "
                strSQL &= "order by FechaCaptura, Folio"

                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(strSQL, "Resultado")
                Dim sTransProdIDs = ObtieneTransProdIds(Dt)
                Dim linea As String
                For Each Dr As DataRow In Dt.Rows
                    linea = CompletaHasta(Dr("Folio"), 10, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(Dr("NombreCorto"), 16, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(Dr("FechaCaptura"), 11, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(FormatNumber(Math.Round(Convert.ToSingle(Dr("Total")) - Convert.ToSingle(Dr("Impuesto")), 2), 2), 11, Alineacion.Derecha, True)
                    sw.WriteLine(linea)
                Next
                sw.WriteLine("")
                strSQL = "SELECT tp.TransProdDetalleID, case when tp2.promocion=2 then sum(tp.Cantidad) else 0  end as cantpromo,tp.impuesto,Nombre, tp.TipoUnidad,case when tp2.promocion<>2  or tp2.promocion is null then sum(tp.Cantidad) else 0 end as Cantidad, sum(tp.Subtotal)as Total, TransProd.DescVendPor, Producto.ProductoClave "
                strSQL &= "FROM TransProd "
                strSQL &= "INNER JOIN TransProdDetalle tp on tp.TransProdId = TransProd.TransProdId  "
                strSQL &= "left JOIN TransProdDetalle tp2 on  tp2.TransProdId = TransProd.TransProdId and tp2.promocion=2 and tp.transproddetalleid = tp2.transproddetalleid   "
                strSQL &= "INNER JOIN Producto on Producto.ProductoClave = tp.ProductoClave  "
                strSQL &= "INNER JOIN Cliente on TransProd.ClienteClave = Cliente.ClienteClave "
                strSQL &= "WHERE TransProd.Tipo = 21 and TransProd.TipoFase <> 0 and TransProd.TransProdID in(" & sTransProdIDs & ")"
                strSQL &= "GROUP BY tp.TransProdDetalleID, ProductoClave,Nombre, tipounidad,DescVendPor,tp.impuesto,tp2.promocion "
                strSQL &= "ORDER BY ProductoClave,Nombre, tp.TipoUnidad "

                linea = CompletaHasta("", 10, Alineacion.Izquierda, False)
                ImprimeLineaPunteada(sw, LongTot)
                linea &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XUnidad"), 10, Alineacion.Izquierda, False)
                linea &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCantidad"), 10, Alineacion.Derecha, False)
                linea &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "Xcantprom"), 9, Alineacion.Derecha, False)
                linea &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 9, Alineacion.Derecha, True)

                sw.WriteLine(linea)
                ImprimeLineaPunteada(sw, LongTot)
                Dt.Clear()
                Dt = oDBVen.RealizarConsultaSQL(strSQL, "Resultado")

                Dim dtDescuentos As DataTable = oDBVen.RealizarConsultaSQL("Select TPD.TransProdDetalleID, TPD.ProductoClave, sum(DesImporte) as DesImporte, sum(DesImpuesto) as DesImpuesto from TPDDes TPE inner join TransProdDetalle TPD on TPE.TransProdID=TPD.TransProdID and TPE.TransProdDEtalleID= TPD.TransProdDEtalleID where TPD.TransProdID in(" & sTransProdIDs & ") group by TPD.TransProdDetalleID,TPD.ProductoClave ", "Descuentos")

                Dim sProd As String = String.Empty
                Dim iTipoUnidad As Integer = 0
                Dim dCantidad As Double = 0
                Dim dTotal As Single = 0
                Dim dGranTotal As Single = 0
                Dim dpromo As Double = 0

                For Each Dr As DataRow In Dt.Rows

                    If (sProd <> Dr("ProductoClave")) Then
                        If sProd <> String.Empty Then
                            linea = CompletaHasta("", 10, Alineacion.Izquierda, False)
                            linea &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", iTipoUnidad), 10, Alineacion.Izquierda, False)
                            linea &= CompletaHasta(dCantidad, 10, Alineacion.Derecha, False)
                            linea &= CompletaHasta(dpromo, 9, Alineacion.Derecha, False)
                            linea &= CompletaHasta(FormatNumber(Math.Round(Convert.ToSingle(dTotal), 2), 2), 9, Alineacion.Derecha, True)

                            sw.WriteLine(linea)
                        End If
                        sProd = Dr("ProductoClave")

                        linea = CompletaHasta(Dr("Nombre"), 48, Alineacion.Izquierda, True)
                        iTipoUnidad = Dr("TipoUnidad")
                        sw.WriteLine(linea)
                        dCantidad = 0
                        dpromo = 0
                        dTotal = 0
                    ElseIf iTipoUnidad <> Dr("TipoUnidad") Then
                        If iTipoUnidad <> 0 Then
                            linea = CompletaHasta("", 10, Alineacion.Izquierda, False)
                            linea &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", iTipoUnidad), 10, Alineacion.Izquierda, False)
                            linea &= CompletaHasta(dCantidad, 10, Alineacion.Derecha, False)
                            linea &= CompletaHasta(dpromo, 9, Alineacion.Derecha, False)
                            linea &= CompletaHasta(FormatNumber(Math.Round(Convert.ToSingle(dTotal), 2), 2), 9, Alineacion.Derecha, True)

                            sw.WriteLine(linea)
                        End If
                        iTipoUnidad = Dr("TipoUnidad")
                        dCantidad = 0
                        dTotal = 0
                        dpromo = 0
                    End If

                    Dim dTotalSinDesc As Double = Dr("Total")
                    'QuitarDescuentos del Cliente
                    Dim drDescuentosCliente() As DataRow = dtDescuentos.Select("ProductoClave='" & sProd & "' and TransProdDetalleID='" & Dr("TransProdDetalleID") & "'")
                    If drDescuentosCliente.Length > 0 Then
                        dTotalSinDesc -= drDescuentosCliente(0)("DesImporte")
                    End If
                    'Quitar Descuentos del Vendedor
                    If Not IsDBNull(Dr("DescVendPor")) Then
                        dTotalSinDesc -= dTotalSinDesc * (Dr("DescVendPor") / 100)
                    End If
                    'Sumar Impuesto
                    If Not IsDBNull(Dr("Impuesto")) Then
                        Dim DESIMPUESTO As Double = 0
                        If (drDescuentosCliente.Length > 0) Then
                            DESIMPUESTO = drDescuentosCliente(0)("DesImpuesto")
                        End If
                        dTotalSinDesc += (Dr("Impuesto") - ((Dr("Impuesto") - DESIMPUESTO) * Dr("DescVendPor") / 100)) - DESIMPUESTO

                    End If

                    dpromo += Dr("cantpromo")
                    dCantidad += Dr("Cantidad")
                    dTotal += dTotalSinDesc
                    dGranTotal += dTotalSinDesc
                Next
                If iTipoUnidad <> 0 Then
                    linea = CompletaHasta("", 10, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", iTipoUnidad), 10, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(dCantidad, 10, Alineacion.Derecha, False)
                    linea &= CompletaHasta(dpromo, 9, Alineacion.Derecha, False)
                    linea &= CompletaHasta(FormatNumber(Math.Round(Convert.ToSingle(dTotal), 2), 2), 9, Alineacion.Derecha, True)

                    sw.WriteLine(linea)
                End If
                sw.WriteLine("")
                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XGranTotal") & ":" & FormatNumber(Math.Round(dGranTotal, 2), 2), 48, Alineacion.Derecha, True)
                sw.WriteLine(linea)
                Dt.Clear()
                Dt.Dispose()
                dtDescuentos.Dispose()
            End If
            ImprimeLineaPunteada(sw, LongTot)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteMovimientosSinInventario")
        End Try
    End Sub

    'Private Sub LlenaTamanios()
    '    htTamanio = New Hashtable
    '    'Extech Termica 2"
    '    AgregarTamanio(1, 53, 48)
    '    AgregarTamanio(2, 52, 42)
    '    AgregarTamanio(3, 51, 38)
    '    AgregarTamanio(4, 50, 32)
    '    AgregarTamanio(5, 49, 24)
    '    'Extech Termica 3"
    '    AgregarTamanio(6, 53, 72)---
    '    AgregarTamanio(7, 52, 64)
    '    AgregarTamanio(8, 51, 57)
    '    AgregarTamanio(9, 50, 48)
    '    AgregarTamanio(10, 49, 36)---
    '    'Extech Impacto 2"
    '    AgregarTamanio(11, 14, 20)
    '    AgregarTamanio(12, 28, 40)
    '    AgregarTamanio(13, 0, 20) '14 + 28
    '    AgregarTamanio(14, 20, 40)
    '    'Zebra Termica 2"
    '    AgregarTamanio(15, 0, 48, 9)
    '    AgregarTamanio(16, 1, 24, 9)
    '    AgregarTamanio(17, 2, 48, 18)
    '    AgregarTamanio(18, 3, 24, 18)
    '    AgregarTamanio(19, 4, 12, 18)
    '    AgregarTamanio(20, 5, 24, 36)
    '    AgregarTamanio(21, 6, 12, 36)
    'End Sub

    Private Function ObtenerTamaños(ByVal pColumnas As String) As String
        If oVendedor.TipoModImp = 1 Then
            If pColumnas = 48 Then
                Return "{53}"
            ElseIf pColumnas = 42 Then
                Return "{52}"
            ElseIf pColumnas = 38 Then
                Return "{51}"
            ElseIf pColumnas = 32 Then
                Return "{50}"
            ElseIf pColumnas = 24 Then
                Return "{49}"
            Else
                Return ("")
            End If
        ElseIf oVendedor.TipoModImp = 2 Then
        ElseIf oVendedor.TipoModImp = 3 Then
        ElseIf oVendedor.TipoModImp = 4 Then
        End If

        Return ""
    End Function
    Private Sub ReporteNotaDeVenta(ByRef sw As StreamWriter, ByVal parsVisitaclave As String, ByVal parsdiaclave As String, ByVal parsCliente As Cliente)
        Dim visitaActual As New Visita()
        Dim cad As String = ""
        visitaActual.VisitaClave = parsVisitaclave
        visitaActual.DiaClave = parsdiaclave
        visitaActual.ClienteActual = parsCliente
        visitaActual.RutClave = oAgenda.RutaActual.RUTClave

        'sw.WriteLine(TextoCentrado(oVendedor.Nombre))
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XRuta") & ": " & visitaActual.RutClave, LongTot))
        sw.WriteLine(TextoCentrado(ValorReferencia.BuscarEquivalente("REPORTEM", 24), LongTot))
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XImpresion") & ": " & Now.ToString("dd/MM/yyyy HH:mm:ss"), LongTot))

        sw.WriteLine()
        sw.WriteLine(visitaActual.ClienteActual.Clave & " - " & visitaActual.ClienteActual.NombreContacto)
        sw.WriteLine(visitaActual.ClienteActual.RazonSocial)
        Dim dom As DataTable = oDBVen.RealizarConsultaSQL("select calle,numero,numint from clientedomicilio where tipo=2 and clienteclave ='" & visitaActual.ClienteActual.ClienteClave & "'", "Domicilio")
        sw.WriteLine(dom.Rows(0)("Calle") & " " & dom.Rows(0)("numero") & " " & dom.Rows(0)("numint"))





        '**********************************VENTAS*****************************************************************

        Dim sConsultaDetalle As String = "select distinct td.productoclave,p.nombre ,td.tipounidad ,max(td.precio) as precio "
        sConsultaDetalle &= "from transproddetalle td "
        sConsultaDetalle &= "inner join producto p on p.productoclave = td.productoclave  "
        sConsultaDetalle &= "where td.transprodid='$0$' group by  td.productoclave,p.nombre ,td.tipounidad "

        Dim sConsultaCantidad As String = "select sum($4$) as $4$  from transproddetalle td  "
        sConsultaCantidad &= "where promocion $3$ and td.transprodid='$0$' and productoclave='$1$' and tipounidad='$2$'"

        Dim titulos As String = ""
        titulos = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProd"), 16, Alineacion.Izquierda, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 8, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProm"), 8, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XPU"), 8, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSubtotal"), 8, Alineacion.Derecha, True)


        Dim tablaVentas As DataTable = oDBVen.RealizarConsultaSQL("Select transprodid,folio,DescuentoImp,DescuentoVendedor,Impuesto,TOTAL from transprod where visitaclave='" & visitaActual.VisitaClave & "' and diaclave='" & visitaActual.DiaClave & "' and tipo=1 and tipofase<>0 ", "Ventas")
        Dim dTotalVenta As Decimal = 0
        For Each row As DataRow In tablaVentas.Rows
            Dim dsubtotal As Double = 0
            Dim dDescuentoDetalle As Double = 0
            ImprimeLineaPunteada(sw, LongTot)
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBox", "XVenta") & ":" & row("folio"), LongTot))
            ImprimeLineaPunteada(sw, LongTot)
            Dim tablaDetalle As DataTable = oDBVen.RealizarConsultaSQL(sConsultaDetalle.Replace("$0$", row("transprodid")), "Detalle")
            sw.WriteLine(titulos)
            ImprimeLineaPunteada(sw, LongTot)
            For Each detalle As DataRow In tablaDetalle.Rows

                Dim dPrecio As Decimal = oDBVen.EjecutarCmdScalardblSQL("select sum(case isnull(impuesto) when 1 then 0 else impuesto end ) -  sum(case isnull(ts.desimpuesto) when 1 then 0 else ts.desimpuesto end ) - sum(case isnull(tv.desimpuesto) when 1 then 0 else tv.desimpuesto end ) from transproddetalle td left join tpddes ts on td.transproddetalleid=ts.transproddetalleid and td.transprodid=ts.transprodid left join tpddesvendedor tv on td.transproddetalleid=tv.transproddetalleid and td.transprodid=tv.transprodid where td.transprodid='" & row("transprodid") & " ' and td.productoclave='" & detalle("productoclave") & "' AND TD.TIPOUNIDAD='" & detalle("tipounidad") & "'")



                Dim iVentas As Double = oDBVen.RealizarScalarSQL(sConsultaCantidad.Replace("$4$", "cantidad").Replace("$0$", row("transprodid")).Replace("$1$", detalle("productoclave")).Replace("$2$", detalle("tipounidad")).Replace("$3$", " <> 2 "))
                If iVentas = 0 Then
                    dPrecio = 0
                Else
                    dPrecio = (dPrecio / iVentas) + detalle("precio")
                End If

                Dim iPromocion As Double = oDBVen.RealizarScalarSQL(sConsultaCantidad.Replace("$4$", "cantidad").Replace("$0$", row("transprodid")).Replace("$1$", detalle("productoclave")).Replace("$2$", detalle("tipounidad")).Replace("$3$", " = 2 "))
                dDescuentoDetalle += oDBVen.RealizarScalarSQL(sConsultaCantidad.Replace("$4$", "DescuentoImp").Replace("$0$", row("transprodid")).Replace("$1$", detalle("productoclave")).Replace("$2$", detalle("tipounidad")).Replace("$3$", " <> 2 "))
                Dim Cantidades As String = ""
                Cantidades = CompletaHasta(detalle("nombre"), 16, Alineacion.Izquierda, False)
                Cantidades &= CompletaHasta(iVentas, 8, Alineacion.Derecha, False)
                Cantidades &= CompletaHasta(iPromocion, 8, Alineacion.Derecha, False)
                Cantidades &= CompletaHasta(dPrecio, 8, Alineacion.Derecha, False)
                Cantidades &= CompletaHasta(iVentas * dPrecio, 8, Alineacion.Derecha, True)
                dsubtotal += iVentas * dPrecio

                sw.WriteLine(Cantidades)
            Next
            ImprimeLineaPunteada(sw, LongTot)
            cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSubtotal"), 24, Alineacion.Derecha, False)
            cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            cad &= CompletaHasta(dsubtotal, 14, Alineacion.Derecha, True)
            sw.WriteLine(cad)
            cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDescuentos"), 24, Alineacion.Derecha, False)
            cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            cad &= CompletaHasta(row("DescuentoImp") + row("DescuentoVendedor") + dDescuentoDetalle, 14, Alineacion.Derecha, True)
            sw.WriteLine(cad)
            'cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XImpuestos"), 24, Alineacion.Derecha, False)
            'cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            'cad &= CompletaHasta(row("Impuesto"), 14, Alineacion.Derecha, True)
            'sw.WriteLine(cad)
            cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal"), 24, Alineacion.Derecha, False)
            cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            cad &= CompletaHasta(row("TOTAL"), 14, Alineacion.Derecha, True)
            sw.WriteLine(cad)
            sw.WriteLine()

            dTotalVenta += row("TOTAL")
        Next




        '****************************************************************************************
        '***********************************Consignacion*************************************************************
        '****************************************************************************************

        Dim Q As New System.Text.StringBuilder
        Q.Append("select distinct TCon.folio,tcon.transprodid as IDconsignacion,TDev.transprodid as IDdevolucion,tcon.impuesto as impuestoCon ")
        Q.Append("from transprod TCon  ")
        Q.Append("left join TrpTpd on TrpTpd.Transprodid1=TCon.transprodid ")
        Q.Append("left  join transprod TDev on TrpTpd.transprodid=TDev.transprodid ")
        Q.Append("where TCon.tipo =24  and TCon.tipofase =6 ")
        Q.Append(" and TCon.diaclave1='" & parsdiaclave & "' and tcon.visitaclave1='" & parsVisitaclave & "' ")


        titulos = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XProd"), 12, Alineacion.Izquierda, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCon"), 7, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XDev"), 7, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 7, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XPU"), 7, Alineacion.Derecha, False)
        titulos &= CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSubtotal"), 8, Alineacion.Derecha, True)

        Dim sdetalle As String


        Dim tablaConsignacion As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "Consignacion")
        'Dim tablaConsignacion As DataTable = oDBVen.RealizarConsultaSQL("Select transprodid,folio,DescuentoImp,DescuentoVendedor,Impuesto,TOTAL from transprod where visitaclave='" & visitaActual.VisitaClave & "' and diaclave='" & visitaActual.DiaClave & "' and tipo=3 and tipomotivo = 12 and tipofase<>0 ", "Consignacion")
        Dim dTotalConsignacion As Decimal = 0
        For Each row As DataRow In tablaConsignacion.Rows
            Dim dsubtotal As Double = 0
            Dim dDescuentoDetalle As Double = 0
            ImprimeLineaPunteada(sw, LongTot)
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBox", "XConsignacion") & ":" & row("folio"), LongTot))
            ImprimeLineaPunteada(sw, LongTot)
            sw.WriteLine(titulos)
            ImprimeLineaPunteada(sw, LongTot)
            Dim tablaDetalle As DataTable = oDBVen.RealizarConsultaSQL("select td.productoclave,p.nombre,td.cantidad,td.precio,td.tipounidad  from transproddetalle td inner join producto p on td.productoclave =p.productoclave where transprodid='" & row("IDconsignacion") & "'", "ConsignacionDetalle")
            'Dim dImpuesto As Double = 0
            For Each detalle As DataRow In tablaDetalle.Rows
                Dim iDevolucion As Integer = 0
                If IsDBNull(row("IDdevolucion")) Then
                    iDevolucion = 0
                    'dImpuesto += 0
                Else
                    iDevolucion = oDBVen.EjecutarCmdScalarIntSQL("select cantidad from transproddetalle  where transprodid='" & row("IDdevolucion") & "' and productoclave='" & detalle("productoclave") & "'")
                    'dImpuesto += oDBVen.EjecutarCmdScalardblSQL("select impuesto from transproddetalle  where transprodid='" & row("IDdevolucion") & "' and productoclave='" & detalle("productoclave") & "'")
                End If

                Dim ImpuestoXDetalle As Decimal = oDBVen.EjecutarCmdScalardblSQL("select sum(case isnull(impuesto) when 1 then 0 else impuesto end ) -  sum(case isnull(ts.desimpuesto) when 1 then 0 else ts.desimpuesto end ) - sum(case isnull(tv.desimpuesto) when 1 then 0 else tv.desimpuesto end ) from transproddetalle td left join tpddes ts on td.transproddetalleid=ts.transproddetalleid and td.transprodid=ts.transprodid left join tpddesvendedor tv on td.transproddetalleid=tv.transproddetalleid and td.transprodid=tv.transprodid where td.transprodid='" & row("IDconsignacion") & " ' and td.productoclave='" & detalle("productoclave") & "' AND TD.TIPOUNIDAD='" & detalle("tipounidad") & "'")
                Dim dPrecio As Decimal = detalle("precio") + (ImpuestoXDetalle / detalle("cantidad"))
                Dim dSubtotal1 As Decimal = ((detalle("cantidad") - iDevolucion) * dPrecio)

                sdetalle = CompletaHasta(detalle("nombre"), 12, Alineacion.Izquierda, False)
                sdetalle &= CompletaHasta(detalle("cantidad"), 7, Alineacion.Derecha, False)
                sdetalle &= CompletaHasta(iDevolucion, 7, Alineacion.Derecha, False)
                sdetalle &= CompletaHasta(detalle("cantidad") - iDevolucion, 7, Alineacion.Derecha, False)
                sdetalle &= CompletaHasta(dPrecio, 7, Alineacion.Derecha, False)
                sdetalle &= CompletaHasta(Math.Round(dSubtotal1, 2), 8, Alineacion.Derecha, True)
                sw.WriteLine(sdetalle)
                dsubtotal += Math.Round(dSubtotal1, 2)
                ImpuestoXDetalle = Nothing
                dPrecio = Nothing
                dSubtotal1 = Nothing

            Next
            ImprimeLineaPunteada(sw, LongTot)
            'cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSubtotal"), 24, Alineacion.Derecha, False)
            'cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            'cad &= CompletaHasta(dsubtotal, 14, Alineacion.Derecha, True)
            'sw.WriteLine(cad)

            'dImpuesto = row("impuestoCon") - dImpuesto

            'cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XImpuestos"), 24, Alineacion.Derecha, False)
            'cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            'cad &= CompletaHasta(dImpuesto, 14, Alineacion.Derecha, True)
            'sw.WriteLine(cad)

            cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal").ToUpper, 24, Alineacion.Derecha, False)
            cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            cad &= CompletaHasta(dsubtotal, 14, Alineacion.Derecha, True)
            sw.WriteLine(cad)
            dTotalConsignacion += dsubtotal

        Next
        sw.WriteLine()

        '***********************************COBRANZA*************************************************************
        ImprimeLineaPunteada(sw, LongTot)
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBox", "XCobranza"), LongTot))
        ImprimeLineaPunteada(sw, LongTot)

        Dim sConsultaAbono As String = "select sum(a.total) as abono,t.cfvtipo,T.TIPO from abono a "
        sConsultaAbono &= "inner join abntrp at on a.abnid=at.abnid "
        sConsultaAbono &= "inner join transprod t on at.transprodid=t.transprodid "
        sConsultaAbono &= "where a.diaclave ='" & visitaActual.DiaClave & "' and a.visitaclave='" & visitaActual.VisitaClave & "' "
        sConsultaAbono &= "group by cfvtipo,T.TIPO order by t.tipo"

        Dim tablaAbono As DataTable = oDBVen.RealizarConsultaSQL(sConsultaAbono, "Abono")
        Dim dAbonoTotal As Decimal = 0
        For Each fila As DataRow In tablaAbono.Rows
            If fila("tipo") = 24 Then
                cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XConsignacion"), 24, Alineacion.Derecha, False)

            Else
                cad = CompletaHasta(fila("cfvtipo"), 10, Alineacion.Derecha, False)
                cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("FVENTA", fila("cfvtipo")), 14, Alineacion.Derecha, False)
            End If


            cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
            cad &= CompletaHasta(fila("abono"), 14, Alineacion.Derecha, True)
            sw.WriteLine(cad)
            dAbonoTotal += fila("abono")
        Next

        ImprimeLineaPunteada(sw, LongTot)


        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVenta") & " " & refaVista.BuscarMensaje("MsgBox", "XNeta"), 24, Alineacion.Derecha, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(dTotalVenta, 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XConsignacion").ToUpper, 24, Alineacion.Derecha, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(dTotalConsignacion, 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)

        cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & " " & refaVista.BuscarMensaje("MsgBox", "XCobranza"), 24, Alineacion.Derecha, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(dAbonoTotal, 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)


        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCargo"), 24, Alineacion.Derecha, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta((dTotalVenta + dTotalConsignacion) - dAbonoTotal, 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)


        Dim dCargos As Double = oDBVen.EjecutarCmdScalardblSQL("select sum(t.total) from transprod t inner join visita v on v.visitaclave =t.visitaclave and t.diaclave=v.diaclave where v.clienteclave = '" & visitaActual.ClienteActual.ClienteClave & "' and t.diaclave in (" & diaClavesEnFrecuencia() & ") and t.visitaclave<>'" & visitaActual.VisitaClave & "' and t.tipofase<>0 and tipo in(1,24)")
        Dim dAbonos As Double = oDBVen.EjecutarCmdScalardblSQL("select sum(t.total) from abono t inner join visita v on v.visitaclave =t.visitaclave and t.diaclave=v.diaclave where v.clienteclave = '" & visitaActual.ClienteActual.ClienteClave & "' and t.visitaclave<>'" & visitaActual.VisitaClave & "' and t.diaclave in (" & diaClavesEnFrecuencia() & ")")
        dAbonos += oDBVen.EjecutarCmdScalardblSQL("select sum(td.total) from transprod  t inner join transproddetalle td on td.transprodid=t.transprodid inner join visita v on v.visitaclave =t.visitaclave and t.diaclave=v.diaclave where tipo=3 and tipomotivo =12 and v.clienteclave = '" & visitaActual.ClienteActual.ClienteClave & "' and t.visitaclave<>'" & visitaActual.VisitaClave & "' and t.diaclave in (" & diaClavesEnFrecuencia() & ") ")


        cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo") & " " & refaVista.BuscarMensaje("MsgBox", "XInicial"), 24, Alineacion.Derecha, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(visitaActual.ClienteActual.SaldoEfectivoCarga + (dCargos - dAbonos), 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)


        cad = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo") & " " & refaVista.BuscarMensaje("MsgBox", "XFinal"), 24, Alineacion.Derecha, False)
        cad &= CompletaHasta("$", 10, Alineacion.Derecha, False)
        cad &= CompletaHasta(visitaActual.ClienteActual.SaldoEfectivo, 14, Alineacion.Derecha, True)
        sw.WriteLine(cad)
        sw.WriteLine()

        Dim tablaproductoprestamocli As DataTable = oDBVen.RealizarConsultaSQL("select p.nombre,saldocarga,cargo,abono,ppc.venta from productoprestamocli ppc inner join producto  p on ppc.productoclave = p.productoclave where ppc.clienteclave = '" & visitaActual.ClienteActual.ClienteClave & "'", "ProductoPrestamoCli")

        ImprimeLineaPunteada(sw, LongTot)
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBox", "XEnvase"), LongTot))
        ImprimeLineaPunteada(sw, LongTot)

        cad = CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XEnv"), 12, Alineacion.Izquierda, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XIni"), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XCar"), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XAbo"), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XVta"), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("MsgBox", "XFin"), 8, Alineacion.Derecha, True)

        sw.WriteLine(cad)
        ImprimeLineaPunteada(sw, LongTot)

        For Each row As DataRow In tablaproductoprestamocli.Rows
            cad = CompletaHasta(row("nombre"), 12, Alineacion.Izquierda, False)
            cad &= CompletaHasta(row("saldocarga"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(row("cargo"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(row("abono"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(row("venta"), 7, Alineacion.Derecha, False)
            cad &= CompletaHasta(row("saldocarga") + row("cargo") - row("abono") - row("venta"), 8, Alineacion.Derecha, True)

            sw.WriteLine(cad)

        Next
        ImprimeLineaPunteada(sw, LongTot)
        cad = CompletaHasta("", 12, Alineacion.Izquierda, False)
        cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(saldocarga)", ""), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(cargo)", ""), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(abono)", ""), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(venta)", ""), 7, Alineacion.Derecha, False)
        cad &= CompletaHasta(tablaproductoprestamocli.Compute("SUM(saldocarga)", "") + tablaproductoprestamocli.Compute("SUM(cargo)", "") - tablaproductoprestamocli.Compute("SUM(abono)", "") - tablaproductoprestamocli.Compute("SUM(venta)", ""), 8, Alineacion.Derecha, True)

        Dim Dr As DataRow = oDBApp.RealizarConsultaSQL("SELECT NombreEmpresa FROM Configuracion", "Encabezado").Rows(0)

        sw.WriteLine(cad)
        sw.WriteLine()
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta1"))
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta2").Substring(0, refaVista.BuscarMensaje("MsgBox", "XNotaVenta2").IndexOf("$0$")))
        sw.WriteLine(TextoCentrado(Dr("NombreEmpresa"), LongTot))
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta2").Substring(refaVista.BuscarMensaje("MsgBox", "XNotaVenta2").IndexOf("$0$") + 3) & " " & refaVista.BuscarMensaje("MsgBox", "XNotaVenta3"))
        sw.WriteLine(TextoCentrado("$ " & visitaActual.ClienteActual.SaldoEfectivo, LongTot))
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta4"))
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta5"))
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta6"))
        sw.WriteLine(refaVista.BuscarMensaje("MsgBox", "XNotaVenta7"))
        ImprimeLineaPunteada(sw, LongTot)
        sw.WriteLine()
        sw.WriteLine()
        sw.WriteLine()
        ImprimeFirmaCentrada(sw, refaVista.BuscarMensaje("MsgBox", "XFirmaCliente"))
        sw.WriteLine()
        sw.WriteLine()
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("MsgBox", "XNotaVenta8"), LongTot))
        tablaVentas.Dispose()
        tablaConsignacion.Dispose
        EspaciosAlFinal(sw)
    End Sub
    Private Sub ReporteResumenMovimientosDuranteLaVisita(ByRef sw As StreamWriter, ByVal parsVisitaclave As String, ByVal parsdiaclave As String, ByVal parsCliente As Cliente)
        Try
            Dim visitaActual As New Visita()
            visitaActual.VisitaClave = parsVisitaclave
            visitaActual.DiaClave = parsdiaclave

            visitaActual.ClienteActual = parscliente
            visitaActual.RutClave = oAgenda.RutaActual.RUTClave



            Dim Dr As DataRow = oDBApp.RealizarConsultaSQL("SELECT NombreEmpresa,Telefono, RFC, Numero, Colonia, Ciudad, Region FROM Configuracion", "Encabezado").Rows(0)

            sw.WriteLine()
            LongTot = 32
            sw.WriteLine(ObtenerTamaños(32) & TextoCentrado(Dr("NombreEmpresa"), LongTot))
            LongTot = 48
            sw.WriteLine()
            sw.WriteLine(ObtenerTamaños(48) & TextoCentrado(Date.Now.ToShortDateString & " " & Date.Now.ToLongTimeString, LongTot))
            sw.WriteLine()



            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XCEDI") & ": " + oVendedor.ClaveCEDI, LongTot))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XTelefono") & ": " + Dr("Telefono"), LongTot))
            'sw.WriteLine(TextoCentrado(oVendedor.NombreVendedor))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XVendedor") & ": " & oVendedor.Clave, LongTot))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XRuta") & ": " & visitaActual.RutClave, LongTot))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XFecha") & ": " & parsdiaclave, LongTot))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XCliente") & ": " & visitaActual.ClienteActual.Clave, LongTot))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XRazonSocial") & ": " & visitaActual.ClienteActual.RazonSocial, LongTot))
            ImprimeLineaPunteada(sw, LongTot)
            ImprimeLineaPunteada(sw, LongTot)
            'Cambios}
            LongTot = 32
            sw.WriteLine(ObtenerTamaños(32) & TextoCentrado("Cambios", LongTot))
            LongTot = 48
            Dim DtCambios As DataTable
            Dim Q As System.Text.StringBuilder
            'Dim sTransProdIds As String = String.Empty
            Q = New System.Text.StringBuilder
            Q.Append("select transprod.transprodid,transprod.facturaid, transprod.folio,transprod.tipomovimiento, transprod.tipofase, transprod.descvendpor, transprod.total ")
            Q.Append("from TransProd inner join visita on transprod.visitaclave=visita.visitaclave inner join Cliente on visita.ClienteClave=Cliente.ClienteClave ")
            Q.Append("where tipo=9  ")
            Q.Append("and visita.visitaclave='" & parsVisitaclave & "' ")
            Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' and TransProd.DiaClave='" & oDia.DiaActual & "' order by razonsocial, folio")
            DtCambios = oDBVen.RealizarConsultaSQL(Q.ToString, "TransProd")
            'sTransProdIds = ObtieneTransProdIds(DtCambios)
            Dim oProducto As New Producto()
            If DtCambios.Rows.Count > 0 Then
                For Each row As DataRow In DtCambios.Select("tipomovimiento=1")
                    Dim total As Double = 0
                    Dim drSalida As DataRow = DtCambios.Select("transprodid='" & row("facturaid") & "'")(0)
                    LongTot = 32
                    sw.WriteLine(ObtenerTamaños(32) & TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XFolio") & ":" & row("folio"), LongTot))
                    LongTot = 48
                    If row("tipofase") = 0 Then
                        sw.WriteLine(ObtenerTamaños(48) & TextoCentrado(ValorReferencia.BuscarEquivalente("TRPFASE", row("tipofase")), LongTot))
                        sw.WriteLine()
                        Continue For
                    End If

                    sw.WriteLine(ObtenerTamaños(48) & TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XPartidas") & ": " & oDBVen.EjecutarCmdScalarStrSQL("select count(*) from transproddetalle where transprodid='" & drSalida("transprodid") & "'"), LongTot))

                    'Entrada(Devolciones)
                    sw.WriteLine("Devoluciones")
                    sw.WriteLine()
                    For Each partida As DataRow In oDBVen.RealizarConsultaSQL("select * from transproddetalle where transprodid='" & row("transprodid") & "'", "Detalle").Rows
                        sw.WriteLine(partida("productoclave"))
                        sw.WriteLine()
                        Dim cad As String = ""
                        oProducto.ProductoClave = partida("productoclave")
                        oProducto.Recuperar()
                        cad = CompletaHasta(oProducto.Nombre, 20, Alineacion.Izquierda, False)
                        cad &= CompletaHasta(partida("Cantidad"), 17, Alineacion.Derecha, False)
                        cad &= CompletaHasta("X", 2, Alineacion.Izquierda, False)
                        cad &= CompletaHasta("$" & partida("precio"), 9, Alineacion.Izquierda, True)
                        sw.WriteLine(cad)
                        sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte") + " $", 38, Alineacion.Derecha, False) & CompletaHasta(partida("total"), 10, Alineacion.Derecha, True))
                        sw.WriteLine()
                        total += partida("total")
                    Next
                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") + " $", 38, Alineacion.Derecha, False) & CompletaHasta(total, 10, Alineacion.Derecha, True))
                    total = 0
                    sw.WriteLine()
                    'Salida(Entregados)
                    sw.WriteLine("Entregados")
                    sw.WriteLine()
                    For Each partida As DataRow In oDBVen.RealizarConsultaSQL("select * from transproddetalle where transprodid='" & drSalida("transprodid") & "'", "Detalle").Rows
                        sw.WriteLine(partida("productoclave"))
                        Dim cad As String = ""
                        oProducto.ProductoClave = partida("productoclave")
                        oProducto.Recuperar()
                        cad = CompletaHasta(oProducto.Nombre, 20, Alineacion.Izquierda, False)
                        cad &= CompletaHasta(partida("Cantidad"), 17, Alineacion.Derecha, False)
                        cad &= CompletaHasta("X", 2, Alineacion.Izquierda, False)
                        cad &= CompletaHasta("$" & partida("precio"), 9, Alineacion.Izquierda, True)
                        sw.WriteLine(cad)
                        sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte") + " $", 38, Alineacion.Derecha, False) & CompletaHasta(partida("total"), 10, Alineacion.Derecha, True))
                        sw.WriteLine()
                        total += partida("total")
                    Next
                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") + " $", 38, Alineacion.Derecha, False) & CompletaHasta(total, 10, Alineacion.Derecha, True))
                    sw.WriteLine()

                Next

            End If
            DtCambios.Dispose()

            sw.WriteLine(ObtenerTamaños(48))
            ImprimeLineaPunteada(sw, LongTot)
            'ventas 
            sw.WriteLine()
            Dim DtVentas As DataTable

            LongTot = 32
            sw.WriteLine(ObtenerTamaños(32) & TextoCentrado("Ventas", LongTot))
            LongTot = 48

            Q = New System.Text.StringBuilder
            Q.Append("select transprod.transprodid,transprod.facturaid, transprod.folio,transprod.tipomovimiento, transprod.tipofase, transprod.descvendpor, transprod.total,transprod.subtotal,transprod.descuentoimp ")
            Q.Append("from TransProd inner join visita on transprod.visitaclave=visita.visitaclave inner join Cliente on visita.ClienteClave=Cliente.ClienteClave ")
            Q.Append("where tipo=1  ")
            Q.Append("and visita.visitaclave='" & parsVisitaclave & "' ")
            Q.Append("and visita.vendedorid='" & oVendedor.VendedorId & "' and TransProd.DiaClave='" & oDia.DiaActual & "' order by razonsocial, folio")
            DtVentas = oDBVen.RealizarConsultaSQL(Q.ToString, "TransProd")



            If DtVentas.Rows.Count > 0 Then
                Dim iGranTotal As Double = 0

                For Each row As DataRow In DtVentas.Rows

                    LongTot = 32
                    sw.WriteLine(ObtenerTamaños(32) & TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XFolio") & ":" & row("folio"), LongTot))
                    LongTot = 48
                    If row("tipofase") = 0 Then
                        sw.WriteLine(ObtenerTamaños(48) & TextoCentrado(ValorReferencia.BuscarEquivalente("TRPFASE", row("tipofase")), LongTot))
                        sw.WriteLine()
                        Continue For
                    End If

                    sw.WriteLine(ObtenerTamaños(48) & TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XPartidas") & ": " & oDBVen.EjecutarCmdScalarStrSQL("select count(*) from transproddetalle where transprodid='" & row("transprodid") & "'"), LongTot))
                    For Each partida As DataRow In oDBVen.RealizarConsultaSQL("select * from transproddetalle where transprodid='" & row("transprodid") & "'", "Detalle").Rows
                        sw.WriteLine(partida("productoclave"))
                        Dim cad As String = ""
                        oProducto.ProductoClave = partida("productoclave")
                        oProducto.Recuperar()
                        cad = CompletaHasta(oProducto.Nombre, 20, Alineacion.Izquierda, False)
                        cad &= CompletaHasta(partida("Cantidad"), 16, Alineacion.Derecha, False)
                        cad &= CompletaHasta("X", 2, Alineacion.Izquierda, False)
                        cad &= CompletaHasta("$" & partida("precio"), 9, Alineacion.Izquierda, True)
                        sw.WriteLine(cad)
                        sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XImporte")+" $", 38, Alineacion.Derecha, False) & CompletaHasta(partida("total"), 10, Alineacion.Derecha, True))
                        sw.WriteLine()
                    Next

                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XSubtotal") & " $", 38, Alineacion.Derecha, False) & CompletaHasta(row("subtotal"), 10, Alineacion.Derecha, True))

                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDescuento") & " $", 38, Alineacion.Derecha, False) & CompletaHasta(row("descuentoimp"), 10, Alineacion.Derecha, True))

                    sw.WriteLine(CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") + " $", 38, Alineacion.Derecha, False) & CompletaHasta(row("total"), 10, Alineacion.Derecha, True))


                    iGranTotal += row("total")
                    sw.WriteLine()
                Next
                sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XPagoEfectivo") & " $" & iGranTotal, LongTot))
            End If
            sw.WriteLine(ObtenerTamaños(48))
            sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes2", "XGraciasCompra"), LongTot))
            DtVentas.Dispose()


            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Ventas")
        End Try
    End Sub
    Private Sub ReporteMovimientosSinInventario(ByRef sw As StreamWriter, ByVal Clientes As String)
        Try
            If RadioButtonDetallado.Checked Then ' DETALLADO
                Dim strSQL As String = "select FechaCaptura, Nombre, TipoUnidad, sum(Cantidad) as Cantidad "
                strSQL &= "from TransProd "
                strSQL &= "inner join TransProdDetalle on TransProdDetalle.TransProdId = TransProd.TransProdId "
                strSQL &= "inner join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave "
                strSQL &= "where TransProd.tipo = 19 " & IIf(CheckBoxFecha.Checked, " and " & FechaConvertida("TransProd.FechaCaptura"), "") & " "
                strSQL &= "group by FechaCaptura, Nombre, TipoUnidad order by FechaCaptura"
                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(strSQL, "Resultado")
                Dim linea As String
                Dim dFecha As Object = Nothing
                For Each Dr As DataRow In Dt.Rows
                    If dFecha <> Dr("FechaCaptura") Then
                        dFecha = Dr("FechaCaptura")
                        linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XFechaMovimiento"), 10, Alineacion.Izquierda, False)
                        linea &= CompletaHasta(Dr("FechaCaptura"), 11, Alineacion.Izquierda, True)
                        sw.WriteLine(linea)
                    End If
                    linea = CompletaHasta(Dr("Nombre"), 28, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr("TipoUnidad")), 10, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(Dr("Cantidad"), 10, Alineacion.Derecha, True)
                    sw.WriteLine(linea)
                Next
                Dt.Clear()
                Dt.Dispose()
            ElseIf RadioButtonGeneral.Checked Then ' GENERAL
                Dim strSQL As String = "select FechaCaptura, Nombre, sum(Factor * Cantidad) as Cantidad "
                strSQL &= "from TransProd "
                strSQL &= "inner join TransProdDetalle on TransProdDetalle.TransProdId = TransProd.TransProdId "
                strSQL &= "inner join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave "
                strSQL &= "inner join ProductoDetalle PRD on Producto.ProductoClave = PRD.ProductoClave and TransProdDetalle.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave "
                strSQL &= "where TransProd.tipo = 19 " & IIf(CheckBoxFecha.Checked, " AND " & FechaConvertida("TransProd.FechaCaptura"), "") & " "
                strSQL &= "group by FechaCaptura, Nombre order by FechaCaptura"
                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(strSQL, "Resultado")
                Dim linea As String
                Dim total As Single = 0
                Dim totalFecha As Single = 0
                Dim dFecha As Object = Nothing
                For Each Dr As DataRow In Dt.Rows
                    If dFecha <> Dr("FechaCaptura") Then
                        If Not IsNothing(dFecha) Then
                            linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFecha") & ": " & FormatNumber(Math.Round(totalFecha, 2), 2), 48, Alineacion.Derecha, True)
                            totalFecha = 0
                            sw.WriteLine(linea)
                        End If
                        dFecha = Dr("FechaCaptura")
                        linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XFechaMovimiento"), 10, Alineacion.Izquierda, False)
                        linea &= CompletaHasta(Dr("FechaCaptura"), 11, Alineacion.Izquierda, True)
                        sw.WriteLine(linea)
                    End If
                    linea = CompletaHasta(Dr("Nombre"), 30, Alineacion.Izquierda, False)
                    linea &= CompletaHasta(Dr("Cantidad"), 18, Alineacion.Derecha, True)
                    total += Convert.ToSingle(Dr("Cantidad"))
                    totalFecha += Convert.ToSingle(Dr("Cantidad"))
                    sw.WriteLine(linea)
                Next
                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalFecha") & ": " & FormatNumber(Math.Round(totalFecha, 2), 2), 48, Alineacion.Derecha, True)
                sw.WriteLine(linea)
                linea = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTotal") & ":", 34, Alineacion.Derecha, False)
                linea &= CompletaHasta(FormatNumber(total, 2), 14, Alineacion.Derecha, True)
                sw.WriteLine(linea)
                Dt.Clear()
                Dt.Dispose()
            End If
            ImprimeLineaPunteada(sw, LongTot)
            EspaciosAlFinal(sw)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReporteMovimientosSinInventario")
        End Try
    End Sub

    Private Sub ReporteProductosPromocionNoEntregados(ByRef sw As StreamWriter, ByVal Clientes As String)
        Dim sConsulta, sCadena As String
        Dim sFase As String = ""
        Dim sCliente As String = ""
        Dim sFolio As String = ""
        Dim sProducto As String = ""
        Dim bNuevaFase As Boolean = False
        EspaciosAlFinal(sw, 1)

        sConsulta = "select PRG.TipoFasePRP, CLI.Clave, CLI.NombreCorto, PRG.FolioPedido, PRO.Nombre, PRG.TipoUnidad, PRG.PromocionClave, PRG.Cantidad, PRG.Saldo "
        sConsulta &= "from ProductoNegado PRG "
        sConsulta &= "inner join Cliente CLI on PRG.Cliente = CLI.ClienteClave "
        sConsulta &= "inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave "
        sConsulta &= "where not PRG.PromocionClave is null "
        If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
            sConsulta &= "and CLI.ClienteClave in (" & Clientes & ")"
        End If
        sConsulta &= "order by PRG.TipoFasePRP, CLI.Clave, CLI.NombreCorto, PRG.FolioPedido, PRO.Nombre, PRG.TipoUnidad, PRG.PromocionClave"
        Dim dtProducto As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "ProductoNegado")

        sConsulta = "select PRG.TipoFasePRP, PRG.ProductoClave, PRO.Nombre, PRG.TipoUnidad, sum(PRG.Cantidad) as Cantidad, sum(PRG.Saldo) as Saldo "
        sConsulta &= "from ProductoNegado PRG "
        sConsulta &= "inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave "
        sConsulta &= "where not PRG.PromocionClave is null "
        If Me.CheckBoxTodosLosClientes.Enabled And Me.CheckBoxTodosLosClientes.Checked = False Then
            sConsulta &= "and PRG.Cliente in (" & Clientes & ")"
        End If
        sConsulta &= "group by PRG.TipoFasePRP, PRG.ProductoClave, PRO.Nombre, PRG.TipoUnidad "
        Dim dtTotales As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "ProductoNegado")

        For Each dr As DataRow In dtProducto.Rows
            If sFase <> dr("TipoFasePRP").ToString Then
                If sFase <> "" Then
                    ImprimirTotales(dtTotales, sFase, sw)
                End If
                sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XFase") & ": ", 10, Alineacion.Izquierda, False)
                sCadena &= CompletaHasta(ValorReferencia.BuscarEquivalente("PRGFASE", dr("TipoFasePRP")), 38, Alineacion.Izquierda, False)
                sw.WriteLine(sCadena)
                ImprimeLineaPunteada(sw, LongTot)
                sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto") & ": ", 20, Alineacion.Izquierda, False)
                sCadena &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPromocion") & ": ", 12, Alineacion.Izquierda, False)
                sCadena &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCant.") & ": ", 8, Alineacion.Derecha, False)
                sCadena &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo") & ": ", 8, Alineacion.Derecha, True)
                sw.WriteLine(sCadena)
                ImprimeLineaPunteada(sw, LongTot)
                sFase = dr("TipoFasePRP").ToString
                sCliente = ""
                sFolio = ""
                sProducto = ""
                bNuevaFase = True
            End If
            If sCliente <> dr("Clave").ToString Then
                sCadena = CompletaHasta(dr("Clave") & "-" & dr("NombreCorto"), 48, Alineacion.Izquierda, False)
                sw.WriteLine(sCadena)
                sCliente = dr("Clave").ToString
                sFolio = ""
                sProducto = ""
            End If
            If sFolio <> dr("FolioPedido").ToString Then
                sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XFolio") & ": ", 10, Alineacion.Izquierda, False)
                sCadena &= CompletaHasta(dr("FolioPedido"), 38, Alineacion.Izquierda, False)
                sw.WriteLine(sCadena)
                sFolio = dr("FolioPedido").ToString
                sProducto = ""
            End If
            If sProducto <> dr("Nombre").ToString Then
                sCadena = CompletaHasta(dr("Nombre"), 48, Alineacion.Izquierda, False)
                sw.WriteLine(sCadena)
                sProducto = dr("Nombre").ToString
            End If

            sCadena = CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 20, Alineacion.Izquierda, False)
            sCadena &= CompletaHasta(dr("PromocionClave"), 12, Alineacion.Izquierda, False)
            sCadena &= CompletaHasta(FormatNumber(dr("Cantidad"), 0), 8, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(FormatNumber(dr("Saldo"), 0), 8, Alineacion.Derecha, True)
            sw.WriteLine(sCadena)
        Next

        ImprimirTotales(dtTotales, sFase, sw)

        dtProducto.Dispose()
        EspaciosAlFinal(sw, 5)
    End Sub

    Private Sub ImprimirTotales(ByVal dtTotales As DataTable, ByVal sFase As String, ByRef sw As StreamWriter)
        Dim sCadena As String
        EspaciosAlFinal(sw, 2)
        sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes2", "XTotalesProducto"), 48, Alineacion.Izquierda, False)
        sw.WriteLine(sCadena)
        ImprimeLineaPunteada(sw, LongTot)
        sCadena = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XProducto") & ": ", 28, Alineacion.Izquierda, False)
        sCadena &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XCant.") & ": ", 10, Alineacion.Derecha, False)
        sCadena &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XSaldo") & ": ", 10, Alineacion.Derecha, True)
        sw.WriteLine(sCadena)
        ImprimeLineaPunteada(sw, LongTot)
        Dim drFase() As DataRow = dtTotales.Select("TipoFasePRP = " & sFase)
        Dim sProducto As String = ""
        For Each dr As DataRow In drFase
            If sProducto <> dr("Nombre").ToString Then
                sCadena = CompletaHasta(dr("Nombre"), 48, Alineacion.Izquierda, False)
                sw.WriteLine(sCadena)
                sProducto = dr("Nombre").ToString
            End If
            sCadena = CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 28, Alineacion.Izquierda, False)
            sCadena &= CompletaHasta(FormatNumber(dr("Cantidad"), 0), 10, Alineacion.Derecha, False)
            sCadena &= CompletaHasta(FormatNumber(dr("Saldo"), 0), 10, Alineacion.Derecha, True)
            sw.WriteLine(sCadena)
        Next
        EspaciosAlFinal(sw, 2)
    End Sub
#End Region

    'Private Function ClienteEncuestado(ByVal pvClienteClave As String) As Boolean
    '    Dim sQuery As String = "SELECT * FROM Encuesta as E, Visita as V WHERE E.VisitaClave=V.VisitaClave AND E.DiaClave=V.DiaClave AND E.DiaClave='" & oDia.DiaActual & "' AND V.ClienteClave='" & pvClienteClave & "'"
    '    Return oDBVen.RealizarConsultaSQL(sQuery, "ClienteEncuestado").Rows.Count > 0
    'End Function

    Private Function ObtenerUnidades(ByVal ProductoClave As String) As Hashtable
        Dim Unidades As String = String.Empty
        Dim htUnidades As Hashtable = New Hashtable
        Dim dtUnidades As DataTable = oDBVen.RealizarConsultaSQL("select PRUTipoUnidad from ProductoUnidad where ProductoClave='" & ProductoClave & "'", "ProductoUnidad")
        If dtUnidades.Rows.Count > 0 Then
            For i As Integer = 0 To dtUnidades.Rows.Count - 1
                Unidades = Unidades & dtUnidades.Rows(i)("PRUTipoUnidad")
                If i < dtUnidades.Rows.Count - 1 Then
                    Unidades = Unidades & ","
                End If
            Next
        Else
            Unidades = "0"
        End If
        dtUnidades = oDBApp.RealizarConsultaSQL("select descripcion, VAVClave from VAVDescripcion where VARCodigo='UNIDADV' and VAVClave in(" & Unidades & ") ", "Inventario")
        For i As Integer = 0 To dtUnidades.Rows.Count - 1
            htUnidades.Add(dtUnidades.Rows(i)("VAVClave"), dtUnidades.Rows(i)("Descripcion"))
        Next
        dtUnidades.Dispose()
        Return htUnidades
    End Function

    Private Function ObtenerFactores(ByVal ProductoClave As String) As Hashtable
        Dim htFactores As New Hashtable
        Dim dtFactores As DataTable = oDBVen.RealizarConsultaSQL("Select PRUTipoUnidad, Factor From ProductoDetalle Where ProductoClave='" & ProductoClave & "' and ProductoClave=ProductoDetClave ", "Division")

        For i As Integer = 0 To dtFactores.Rows.Count - 1
            htFactores.Add(CStr(dtFactores.Rows(i)("PRUTipoUnidad")), CStr(dtFactores.Rows(i)("Factor")))
        Next
        dtFactores.Dispose()
        Return htFactores
    End Function

    Private Function ObtenerKeyMayorFactor(ByRef htFactores As Hashtable) As String
        Dim mkey As Object
        Dim mvalor As Integer = 0
        For Each key As Object In htFactores.Keys
            If htFactores(key) > mvalor Then
                mkey = key
                mvalor = htFactores(key)
            End If
        Next


        Return mkey.ToString
    End Function

    Private Function ObtenerPrecioMenorFactor(ByVal ProductoClave As String) As Double
        Dim sConsulta As String
        Dim dtUnidad As DataTable
        Dim nPrecio As Double = 0
        sConsulta = "select ProductoClave, PRUTipoUnidad from ProductoDetalle where ProductoClave = '" & ProductoClave & "' and ProductoDetClave = '" & ProductoClave & "' order by Factor "
        dtUnidad = oDBVen.RealizarConsultaSQL(sConsulta, "Unidad")
        If dtUnidad.Rows.Count > 0 Then
            sConsulta = "select case isnull(max(Precio)) when 1 then 0 else max(Precio) end as Precio from PrecioProductoVig where ProductoClave = '" & dtUnidad.Rows(0)("ProductoClave") & "' and PRUTipoUnidad = " & dtUnidad.Rows(0)("PRUTipoUnidad") & " and (convert(nvarchar(10), getdate(), 112) between convert(nvarchar(10),PPVFechaInicio,112) and convert(nvarchar(10),Fechafin,112))"
            nPrecio = oDBVen.RealizarScalarSQL(sConsulta)
        End If
        Return nPrecio
    End Function

    Private Function ObtenerPrecioFactor(ByVal ProductoClave As String, ByVal PRUTipoUnidad As Integer) As Double
        Dim sConsulta As String
        Dim nPrecio As Double = 0
        sConsulta = "select case isnull(max(Precio)) when 1 then 0 else max(Precio) end as Precio from PrecioProductoVig where ProductoClave = '" & ProductoClave & "' and PRUTipoUnidad = " & PRUTipoUnidad & " and (convert(nvarchar(10), getdate(), 112) between convert(nvarchar(10),PPVFechaInicio,112) and convert(nvarchar(10),Fechafin,112))"
        nPrecio = oDBVen.RealizarScalarSQL(sConsulta)
        Return nPrecio
    End Function

    Private Sub CheckBoxTodosLosClientes_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxTodosLosClientes.CheckStateChanged
        If Me.CheckBoxTodosLosClientes.Checked Then
            'Me.TabControlReportes.TabPages.RemoveAt(1)
            For Each oControl As Control In Me.TabPageClientes.Controls
                Try
                    oControl.Enabled = False
                Catch ex As Exception

                End Try

            Next
        Else
            'Me.TabControlReportes.TabPages.Insert(1, Me.TabPageClientes)
            For Each oControl As Control In Me.TabPageClientes.Controls
                Try
                    oControl.Enabled = True
                Catch ex As Exception

                End Try

            Next
        End If
    End Sub

    Private Sub TextBoxVerReporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxVerReporte.KeyPress
        e.Handled = True
    End Sub



#Region "ENUMS"
    'Private Enum Alineacion
    '    Izquierda = 0
    '    Derecha = 1
    'End Enum

    'Private Enum ModoImpresion
    '    Online = 1
    '    Buffer = 2
    'End Enum

    Private Enum TiposReportes
        NoDefinido = 0
        Ventas = 1
        Depositos = 2
        HistoricoPromedio = 3
        Liquidacion = 4
        GeneralDePromociones = 5
        EfectividadPorRuta = 6
        Cobranza = 7
        SaldosPorClienteEnEfectivo = 8
        SaldosPorClienteEnEnvase = 9
        ResumenDeMovimientos = 10
        Inventario = 11
        Cargas = 12
        Descargas = 13
        Cuotas = 14
        Mercadeo = 15
        ResumenCobranza = 16
        SaldoProductoPrestado = 17
        MovSinInvSinVis = 18
        MovSinInvConVis = 19
        ProductosPromocionNoEntregados = 20
        MovimientosDureanteLaVisita = 21
        ExtensiónDeAlmacén = 22
        VtaProductoyMovDeEnvase = 23
        NotaVta = 24
        ListaPrecio = 25
        LiquidacionDisposur = 26

    End Enum
#End Region

End Class
