Imports System.Data.SqlServerCe

Public Class FormMenuMovProducto
    Inherits System.Windows.Forms.Form
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef refparoTransProd As TransProd, ByVal parsVisitaActual As String)
        MyBase.New()

        Me.TransProd = refparoTransProd
        sModuloMovDetalleClaveActual = Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        ListViewFolios.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewFolios.Activation = oApp.TipoSeleccion

        ListViewFolios.FullRowSelect = True
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        ListViewFolios.SmallImageList.ImageSize = New System.Drawing.Size(32, 32)
#End If
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        sVisitaActual = parsVisitaActual
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If oVendedor.motconfiguracion.Secuencia Then
            If ctrlSeguimiento.Incluido Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenuMovProducto)
                Me.Controls.Remove(ctrlSeguimiento)
            End If
        Else
            If Not Me.MenuItemRegresar Is Nothing Then
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

        If Not IsNothing(MenuItemCancelar) Then MenuItemCancelar.Dispose()
        If Not IsNothing(MenuItemDetalles) Then MenuItemDetalles.Dispose()
        If Not IsNothing(MenuItemGeneral) Then MenuItemGeneral.Dispose()
        If Not IsNothing(MenuItemModificar) Then MenuItemModificar.Dispose()
        If Not IsNothing(MenuItemNuevo) Then MenuItemNuevo.Dispose()
        If Not IsNothing(MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(MenuItemSurtir) Then MenuItemSurtir.Dispose()
        If Not IsNothing(MenuItemTabNuevo) Then MenuItemTabNuevo.Dispose()
        If Not IsNothing(MainMenuMovProducto) Then MainMenuMovProducto.Dispose()
        If Not IsNothing(ContextMenuFolios) Then ContextMenuFolios.Dispose()
        If Not IsNothing(ContextMenuNuevo) Then ContextMenuNuevo.Dispose()

        If Not IsNothing(ListViewFolios) Then
            If ListViewFolios.Columns.Count > 0 Then ListViewFolios.Columns.Clear()
            ListViewFolios.Dispose()
        End If

        If Not IsNothing(DetailViewDetalles) Then DetailViewDetalles.Dispose()
        bIniciando = True
        If Not IsNothing(TabPageDetalle) Then TabPageDetalle.Dispose()
        If Not IsNothing(TabPageGeneral) Then TabPageGeneral.Dispose()
        If Not IsNothing(TabControlMovProducto) Then TabControlMovProducto.Dispose()
        bIniciando = False
        If Not IsNothing(ImageListFolios) Then
            ImageListFolios.Images.Clear()
            ImageListFolios.Dispose()
            ImageListFolios = Nothing
        End If
        InputPanelMovProducto.Dispose()

        If Not IsNothing(Me.ButtonCancelar) Then ButtonCancelar.Dispose()
        If Not IsNothing(Me.ButtonDetalleContinuar) Then ButtonDetalleContinuar.Dispose()
        If Not IsNothing(Me.ButtonDetalleOtros) Then ButtonDetalleOtros.Dispose()
        If Not IsNothing(Me.ButtonDetalleRegresar) Then ButtonDetalleRegresar.Dispose()
        If Not IsNothing(Me.ButtonGeneralContinuar) Then ButtonGeneralContinuar.Dispose()
        If Not IsNothing(Me.ButtonGeneralRegresar) Then ButtonGeneralRegresar.Dispose()
        If Not IsNothing(Me.ButtonCancelarCont) Then ButtonCancelarCont.Dispose()
        If Not IsNothing(Me.ButtonCancelarSalir) Then ButtonCancelarSalir.Dispose()

        If Not IsNothing(Me.PanelMotivoCancelacion) Then PanelMotivoCancelacion.Dispose()
        'If Not IsNothing(Me.com) Then ButtonCancelarSalir.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuMovProducto As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelMovProducto As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents ImageListFolios As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemGeneral As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCancelar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemNuevo As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuFolios As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemSurtir As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDetalles As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuNuevo As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlMovProducto As System.Windows.Forms.TabControl
    Friend WithEvents TabPageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents ButtonGeneralRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonGeneralContinuar As System.Windows.Forms.Button
    Friend WithEvents LabelNombreMovimiento As System.Windows.Forms.Label
    Friend WithEvents ListViewFolios As System.Windows.Forms.ListView
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents ButtonDetalleOtros As System.Windows.Forms.Button
    Friend WithEvents ButtonDetalleContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonDetalleRegresar As System.Windows.Forms.Button
    Friend WithEvents LabelDetalle As System.Windows.Forms.Label
    Private WithEvents DetailViewDetalles As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents PanelMotivoCancelacion As System.Windows.Forms.Panel
    Friend WithEvents ButtonCancelarCont As System.Windows.Forms.Button
    Friend WithEvents ButtonCancelarSalir As System.Windows.Forms.Button
    Friend WithEvents ComboBoxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents LabelP0212 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LabelMotivo As System.Windows.Forms.Label
    Friend WithEvents MenuItemTabNuevo As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMenuMovProducto))
        Me.ButtonGeneralContinuar = New System.Windows.Forms.Button
        Me.ContextMenuFolios = New System.Windows.Forms.ContextMenu
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.MenuItemCancelar = New System.Windows.Forms.MenuItem
        Me.MenuItemNuevo = New System.Windows.Forms.MenuItem
        Me.MenuItemSurtir = New System.Windows.Forms.MenuItem
        Me.MenuItemDetalles = New System.Windows.Forms.MenuItem
        Me.ImageListFolios = New System.Windows.Forms.ImageList
        Me.MainMenuMovProducto = New System.Windows.Forms.MainMenu
        Me.MenuItemGeneral = New System.Windows.Forms.MenuItem
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.InputPanelMovProducto = New Microsoft.WindowsCE.Forms.InputPanel
        Me.ContextMenuNuevo = New System.Windows.Forms.ContextMenu
        Me.MenuItemTabNuevo = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlMovProducto = New System.Windows.Forms.TabControl
        Me.TabPageGeneral = New System.Windows.Forms.TabPage
        Me.ListViewFolios = New System.Windows.Forms.ListView
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.ButtonGeneralRegresar = New System.Windows.Forms.Button
        Me.LabelNombreMovimiento = New System.Windows.Forms.Label
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.LabelDetalle = New System.Windows.Forms.Label
        Me.ButtonDetalleOtros = New System.Windows.Forms.Button
        Me.ButtonDetalleContinuar = New System.Windows.Forms.Button
        Me.ButtonDetalleRegresar = New System.Windows.Forms.Button
        Me.DetailViewDetalles = New Resco.Controls.DetailView.DetailView
        Me.PanelMotivoCancelacion = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ComboBoxMotivo = New System.Windows.Forms.ComboBox
        Me.LabelMotivo = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LabelTitulo = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.LabelP0212 = New System.Windows.Forms.Label
        Me.ButtonCancelarCont = New System.Windows.Forms.Button
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.ButtonCancelarSalir = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControlMovProducto.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.PanelMotivoCancelacion.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonGeneralContinuar
        '
        Me.ButtonGeneralContinuar.Location = New System.Drawing.Point(3, 240)
        Me.ButtonGeneralContinuar.Name = "ButtonGeneralContinuar"
        Me.ButtonGeneralContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonGeneralContinuar.TabIndex = 0
        Me.ButtonGeneralContinuar.Text = "ButtonGeneralContinuar"
        '
        'ContextMenuFolios
        '
        Me.ContextMenuFolios.MenuItems.Add(Me.MenuItemModificar)
        Me.ContextMenuFolios.MenuItems.Add(Me.MenuItemCancelar)
        Me.ContextMenuFolios.MenuItems.Add(Me.MenuItemNuevo)
        Me.ContextMenuFolios.MenuItems.Add(Me.MenuItemSurtir)
        Me.ContextMenuFolios.MenuItems.Add(Me.MenuItemDetalles)
        '
        'MenuItemModificar
        '
        Me.MenuItemModificar.Text = "MenuItemModificar"
        '
        'MenuItemCancelar
        '
        Me.MenuItemCancelar.Text = "MenuItemCancelar"
        '
        'MenuItemNuevo
        '
        Me.MenuItemNuevo.Text = "MenuItemNuevo"
        '
        'MenuItemSurtir
        '
        Me.MenuItemSurtir.Text = "MenuItemSurtir"
        '
        'MenuItemDetalles
        '
        Me.MenuItemDetalles.Text = "MenuItemDetalles"
        Me.ImageListFolios.Images.Clear()
        Me.ImageListFolios.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.ImageListFolios.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        Me.ImageListFolios.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Image))
        Me.ImageListFolios.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Image))
        '
        'MainMenuMovProducto
        '
        Me.MainMenuMovProducto.MenuItems.Add(Me.MenuItemGeneral)
        '
        'MenuItemGeneral
        '
        Me.MenuItemGeneral.MenuItems.Add(Me.MenuItemRegresar)
        Me.MenuItemGeneral.Text = "MenuItemGeneral"
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'ContextMenuNuevo
        '
        Me.ContextMenuNuevo.MenuItems.Add(Me.MenuItemTabNuevo)
        '
        'MenuItemTabNuevo
        '
        Me.MenuItemTabNuevo.Text = "MenuItemTabNuevo"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlMovProducto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlMovProducto
        '
        Me.TabControlMovProducto.Controls.Add(Me.TabPageGeneral)
        Me.TabControlMovProducto.Controls.Add(Me.TabPageDetalle)
        Me.TabControlMovProducto.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMovProducto.Name = "TabControlMovProducto"
        Me.TabControlMovProducto.SelectedIndex = 0
        Me.TabControlMovProducto.Size = New System.Drawing.Size(242, 295)
        Me.TabControlMovProducto.TabIndex = 1
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.ContextMenu = Me.ContextMenuFolios
        Me.TabPageGeneral.Controls.Add(Me.ListViewFolios)
        Me.TabPageGeneral.Controls.Add(Me.ButtonCancelar)
        Me.TabPageGeneral.Controls.Add(Me.ButtonGeneralContinuar)
        Me.TabPageGeneral.Controls.Add(Me.ButtonGeneralRegresar)
        Me.TabPageGeneral.Controls.Add(Me.LabelNombreMovimiento)
        Me.TabPageGeneral.Location = New System.Drawing.Point(0, 0)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Size = New System.Drawing.Size(242, 272)
        Me.TabPageGeneral.Text = "TabPageGeneral"
        '
        'ListViewFolios
        '
        Me.ListViewFolios.ContextMenu = Me.ContextMenuFolios
        Me.ListViewFolios.FullRowSelect = True
        Me.ListViewFolios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFolios.Location = New System.Drawing.Point(3, 16)
        Me.ListViewFolios.Name = "ListViewFolios"
        Me.ListViewFolios.Size = New System.Drawing.Size(228, 220)
        Me.ListViewFolios.SmallImageList = Me.ImageListFolios
        Me.ListViewFolios.TabIndex = 3
        Me.ListViewFolios.View = System.Windows.Forms.View.Details
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(157, 240)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonCancelar.TabIndex = 4
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'ButtonGeneralRegresar
        '
        Me.ButtonGeneralRegresar.Location = New System.Drawing.Point(80, 240)
        Me.ButtonGeneralRegresar.Name = "ButtonGeneralRegresar"
        Me.ButtonGeneralRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonGeneralRegresar.TabIndex = 1
        Me.ButtonGeneralRegresar.Text = "ButtonGeneralRegresar"
        '
        'LabelNombreMovimiento
        '
        Me.LabelNombreMovimiento.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelNombreMovimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelNombreMovimiento.Location = New System.Drawing.Point(4, 2)
        Me.LabelNombreMovimiento.Name = "LabelNombreMovimiento"
        Me.LabelNombreMovimiento.Size = New System.Drawing.Size(228, 20)
        Me.LabelNombreMovimiento.Text = "LabelNombreMovimiento"
        Me.LabelNombreMovimiento.Visible = False
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.LabelDetalle)
        Me.TabPageDetalle.Controls.Add(Me.ButtonDetalleOtros)
        Me.TabPageDetalle.Controls.Add(Me.ButtonDetalleContinuar)
        Me.TabPageDetalle.Controls.Add(Me.ButtonDetalleRegresar)
        Me.TabPageDetalle.Controls.Add(Me.DetailViewDetalles)
        Me.TabPageDetalle.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 269)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'LabelDetalle
        '
        Me.LabelDetalle.Location = New System.Drawing.Point(4, 15)
        Me.LabelDetalle.Name = "LabelDetalle"
        Me.LabelDetalle.Size = New System.Drawing.Size(220, 14)
        Me.LabelDetalle.Text = "LabelDetalle"
        '
        'ButtonDetalleOtros
        '
        Me.ButtonDetalleOtros.Location = New System.Drawing.Point(162, 240)
        Me.ButtonDetalleOtros.Name = "ButtonDetalleOtros"
        Me.ButtonDetalleOtros.Size = New System.Drawing.Size(74, 24)
        Me.ButtonDetalleOtros.TabIndex = 0
        Me.ButtonDetalleOtros.Text = "ButtonDetalleOtros"
        '
        'ButtonDetalleContinuar
        '
        Me.ButtonDetalleContinuar.Location = New System.Drawing.Point(4, 240)
        Me.ButtonDetalleContinuar.Name = "ButtonDetalleContinuar"
        Me.ButtonDetalleContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonDetalleContinuar.TabIndex = 1
        Me.ButtonDetalleContinuar.Text = "ButtonDetalleContinuar"
        '
        'ButtonDetalleRegresar
        '
        Me.ButtonDetalleRegresar.Location = New System.Drawing.Point(83, 240)
        Me.ButtonDetalleRegresar.Name = "ButtonDetalleRegresar"
        Me.ButtonDetalleRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonDetalleRegresar.TabIndex = 2
        Me.ButtonDetalleRegresar.Text = "ButtonDetalleRegresar"
        '
        'DetailViewDetalles
        '
        Me.DetailViewDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewDetalles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewDetalles.LabelWidth = 110
        Me.DetailViewDetalles.Location = New System.Drawing.Point(4, 31)
        Me.DetailViewDetalles.Name = "DetailViewDetalles"
        Me.DetailViewDetalles.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewDetalles.SeparatorWidth = 4
        Me.DetailViewDetalles.Size = New System.Drawing.Size(228, 206)
        Me.DetailViewDetalles.TabIndex = 4
        '
        'PanelMotivoCancelacion
        '
        Me.PanelMotivoCancelacion.BackColor = System.Drawing.Color.White
        Me.PanelMotivoCancelacion.Controls.Add(Me.Panel3)
        Me.PanelMotivoCancelacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMotivoCancelacion.Location = New System.Drawing.Point(0, 0)
        Me.PanelMotivoCancelacion.Name = "PanelMotivoCancelacion"
        Me.PanelMotivoCancelacion.Size = New System.Drawing.Size(242, 295)
        Me.PanelMotivoCancelacion.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.ComboBoxMotivo)
        Me.Panel3.Controls.Add(Me.LabelMotivo)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.LabelP0212)
        Me.Panel3.Controls.Add(Me.ButtonCancelarCont)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.ButtonCancelarSalir)
        Me.Panel3.Location = New System.Drawing.Point(5, 71)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(232, 141)
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(59, 72)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(168, 22)
        Me.ComboBoxMotivo.TabIndex = 1
        '
        'LabelMotivo
        '
        Me.LabelMotivo.Location = New System.Drawing.Point(4, 72)
        Me.LabelMotivo.Name = "LabelMotivo"
        Me.LabelMotivo.Size = New System.Drawing.Size(49, 20)
        Me.LabelMotivo.Text = "LabelMotivo"
        Me.LabelMotivo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(2, 139)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(228, 2)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.LabelTitulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(228, 24)
        '
        'LabelTitulo
        '
        Me.LabelTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelTitulo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTitulo.ForeColor = System.Drawing.Color.White
        Me.LabelTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(228, 24)
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(2, 141)
        '
        'LabelP0212
        '
        Me.LabelP0212.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LabelP0212.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelP0212.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelP0212.Location = New System.Drawing.Point(8, 28)
        Me.LabelP0212.Name = "LabelP0212"
        Me.LabelP0212.Size = New System.Drawing.Size(216, 37)
        Me.LabelP0212.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonCancelarCont
        '
        Me.ButtonCancelarCont.Location = New System.Drawing.Point(75, 106)
        Me.ButtonCancelarCont.Name = "ButtonCancelarCont"
        Me.ButtonCancelarCont.Size = New System.Drawing.Size(74, 24)
        Me.ButtonCancelarCont.TabIndex = 2
        Me.ButtonCancelarCont.Text = "ButtonCancelarCont"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(230, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(2, 141)
        '
        'ButtonCancelarSalir
        '
        Me.ButtonCancelarSalir.Location = New System.Drawing.Point(152, 106)
        Me.ButtonCancelarSalir.Name = "ButtonCancelarSalir"
        Me.ButtonCancelarSalir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonCancelarSalir.TabIndex = 3
        Me.ButtonCancelarSalir.Text = "ButtonCancelarSalir"
        '
        'FormMenuMovProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelMotivoCancelacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuMovProducto
        Me.MinimizeBox = False
        Me.Name = "FormMenuMovProducto"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlMovProducto.ResumeLayout(False)
        Me.TabPageGeneral.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.PanelMotivoCancelacion.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const amp = "&amp;" '&
    Private Const quot = "&quot;" '"
    Private Const lt = "&lt;" '<
    Private Const gt = "&gt;" '>
    Private Const apos = "&#36;" ''

    Public Enum TiposAccionesDocumentos
        Terminar = 0
        Ninguna = 1
        Crear = 2
        Modificar = 3
        SurtirPedido = 4
        CancelarPedido = 5
    End Enum
    Public sModuloMovDetalleClaveActual As String
    Protected oTransProd As TransProd
    Protected tTipoAccionDocumento As TiposAccionesDocumentos
    Protected sVisitaActual As String
    Protected bHaCambiadoDetalle As Boolean
    Public OrigenAdelante As Boolean = True

    Public Property TransProd() As TransProd
        Get
            Return oTransProd
        End Get
        Set(ByVal Value As TransProd)
            oTransProd = Value
        End Set
    End Property
    Public Property TipoAccion() As TiposAccionesDocumentos
        Get
            Return tTipoAccionDocumento
        End Get
        Set(ByVal Value As TiposAccionesDocumentos)
            tTipoAccionDocumento = Value
        End Set
    End Property

    Private Const ConstPosTabPageGeneral = 0
    Private Const ConstPosTabPageDetalle = 1

    Private Const ConstPosId = 1

    Private refaVista As Vista

    Private bIniciando As Boolean = True

#Region " Funciones y eventos generales de la forma "
    Public Function ExistenMovimientos() As Boolean
        If Not Vista.Buscar("FormMenuMovProducto", refaVista) Then
            Return False
        End If
        Me.refaVista.CrearListView(Me.ListViewFolios, "ListViewDocumentos")
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            'ButtonDetalleContinuar.Enabled = False
            Dim sWhere As String = ""
            sWhere = " t inner join visita v on v.visitaclave=t.visitaclave and v.diaclave=t.diaclave "
            sWhere &= " left join TransProd f on f.TransProdId = t.FacturaId "
            sWhere &= " WHERE v.ClienteClave='" & Me.TransProd.ClienteActual.ClienteClave & "' and t.Tipo=" & Me.TransProd.Tipo
            sWhere &= " and (t.tipofase<>2 or ((t.VISITACLAVE1='" & Me.TransProd.VisitaActual & "' and t.DiaClave1='" & oDia.DiaActual & "')or  (t.VISITACLAVE='" & Me.TransProd.VisitaActual & "' and t.DiaClave='" & oDia.DiaActual & "') ))"

            Me.refaVista.PoblarListView(Me.ListViewFolios, oDBVen, "ListViewDocumentosReparto", sWhere)
        Else
            Me.refaVista.PoblarListView(Me.ListViewFolios, oDBVen, "ListViewDocumentos", "WHERE DiaClave='" & oDia.DiaActual & "' AND VisitaClave='" & Me.TransProd.VisitaActual & "' AND PCEModuloMovDetClave='" & Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' and Tipo=" & Me.TransProd.Tipo)

        End If

        If (ListViewFolios.Items.Count = 0) Then
            If OrigenAdelante = True Then
                If Not oTransProd.ClienteActual.ExisteFormaVenta Then
                    MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0358"))
                    Return False
                End If
                ' Nuevo movimiento
                Me.TransProd.Reiniciar(True)
                Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClaveActual
                Select Case Me.TransProd.Tipo
                    Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.MovSinInvEV
                        Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                        Me.TransProd.TipoPedido = ServicesCentral.TiposPedidos.Normal
                End Select
                FormProcesando.PubSubTitulo(oVendedor.NombreModulo)
                FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Creando"), Me.TransProd.ModuloMovDetalle.Nombre)
                Me.TipoAccion = TiposAccionesDocumentos.Crear
                Return False
            Else
                Me.TipoAccion = TiposAccionesDocumentos.Terminar
                Return False
            End If
        End If


        Return True
    End Function

    Private Sub FormMovProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        [Global].ObtenerFactores(Me)

        Me.PanelMotivoCancelacion.Visible = False
        Me.Panel1.Visible = True

        If oVendedor.motconfiguracion.Secuencia Then
            LabelNombreMovimiento.Visible = False
            LabelDetalle.Visible = False
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuMovProducto)
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

        'If Not Vista.Buscar("FormMenuMovProducto", refaVista) Then
        '    Exit Sub
        'End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        Me.ButtonCancelar.Text = Me.MenuItemCancelar.Text
        Me.LabelP0212.Text = Me.refaVista.BuscarMensaje("MsgBoxGeneral", "P0212")
        Me.ButtonCancelarCont.Text = Me.ButtonGeneralContinuar.Text
        Me.ButtonCancelarSalir.Text = Me.ButtonGeneralRegresar.Text
        'Me.refaVista.CrearListView(Me.ListViewFolios, "ListViewDocumentos")
        'If Me.TipoAccion = TiposAccionesDocumentos.SurtirPedido Then
        '    ButtonDetalleContinuar.Enabled = False
        'End If

        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            'ButtonDetalleContinuar.Enabled = False
            'Dim sWhere As String = ""
            'sWhere = " t inner join visita v on v.visitaclave=t.visitaclave and v.diaclave=t.diaclave "
            'sWhere &= " WHERE v.ClienteClave='" & Me.TransProd.ClienteActual.ClienteClave & "' and Tipo=" & Me.TransProd.Tipo
            'sWhere &= " and (tipofase<>2 or ((VISITACLAVE1='" & Me.TransProd.VisitaActual & "' and DiaClave1='" & oDia.DiaActual & "')or  (t.VISITACLAVE='" & Me.TransProd.VisitaActual & "' and t.DiaClave='" & oDia.DiaActual & "') ))"


            'Me.refaVista.PoblarListView(Me.ListViewFolios, oDBVen, "ListViewDocumentosReparto", sWhere)
            If Me.ContextMenuNuevo.MenuItems.Contains(Me.MenuItemTabNuevo) Then
                Me.ContextMenuNuevo.MenuItems.Remove(Me.MenuItemTabNuevo)
            End If
        Else
            'Me.refaVista.PoblarListView(Me.ListViewFolios, oDBVen, "ListViewDocumentos", "WHERE DiaClave='" & oDia.DiaActual & "' AND VisitaClave='" & Me.TransProd.VisitaActual & "' AND PCEModuloMovDetClave='" & Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' and Tipo=" & Me.TransProd.Tipo)
            If Not Me.ContextMenuNuevo.MenuItems.Contains(Me.MenuItemTabNuevo) Then
                Me.ContextMenuNuevo.MenuItems.Add(Me.MenuItemTabNuevo)
            End If
        End If

        Me.LabelNombreMovimiento.Text = Me.TransProd.ModuloMovDetalle.Nombre
        Me.TabControlMovProducto.TabPages.RemoveAt(1)
        bHaCambiadoDetalle = False
        bIniciando = False
        Me.ResumeLayout()

        With ListViewFolios
            If .Items.Count > 0 Then
                '.Items(0).Selected = True
                .Focus()
            Else
                Me.ButtonDetalleContinuar.Focus()
            End If
        End With

        'If (ListViewFolios.Items.Count = 0) Then
        '    If OrigenAdelante = True Then
        '        Me.CrearDocumento()
        '    Else
        '        Me.TipoAccion = TiposAccionesDocumentos.Terminar
        '        Me.Close()
        '    End If
        'End If
        Cursor.Current = Cursors.Default
        [Global].HabilitarMenuItem(Me.MainMenuMovProducto, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.TipoAccion = TiposAccionesDocumentos.Terminar
        Me.Close()
    End Sub

#End Region

#Region " TabPage General "

    Private Sub CrearDocumento()
        If Not oTransProd.ClienteActual.ExisteFormaVenta Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0358"))
            Exit Sub
        End If
        ' Nuevo movimiento
        Me.TransProd.Reiniciar(True)
        Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClaveActual
        Select Case Me.TransProd.Tipo
            Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.MovSinInvEV
                Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                Me.TransProd.TipoPedido = ServicesCentral.TiposPedidos.Normal
        End Select
        FormProcesando.PubSubTitulo(oVendedor.NombreModulo)
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Creando"), Me.TransProd.ModuloMovDetalle.Nombre)
        Me.TipoAccion = TiposAccionesDocumentos.Crear
        Me.Close()
    End Sub

    Private Sub VerPropiedadesDocumento(Optional ByVal pvCambiarDeIndex As Boolean = True)
        If Not oTransProd.ClienteActual.ExisteFormaVenta Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0358"))
            Exit Sub
        End If
        If oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion Then
            If (Me.TransProd.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV) AndAlso (Not oConHist.Campos("ModificarVenta")) Then
                MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "I0164"))
                If Me.TabControlMovProducto.SelectedIndex <> ConstPosTabPageGeneral Then
                    Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
                End If
                Exit Sub
            End If
        End If

        Dim refListViewItem As ListViewItem
        If ListViewFolios.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        refListViewItem = ListViewFolios.Items(ListViewFolios.SelectedIndices(0))
        Me.TransProd.FolioActual = refListViewItem.Text
        Me.TransProd.TransProdId = refListViewItem.SubItems(ConstPosId).Text
        LimpiarDetailView(Me.DetailViewDetalles)
        Me.TransProd.Recuperar()

        If oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion Then
            ButtonDetalleContinuar.Enabled = oConHist.Campos("ModificarVenta")
        Else

            If Me.TransProd.ModuloMovDetalle.TipoTransProd = ServicesCentral.TiposTransProd.Pedido Then
                If (Not Me.TransProd.VisitaClave1 = String.Empty) Then
                    ButtonDetalleContinuar.Enabled = False
                ElseIf (TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido AndAlso (IsDBNull(Me.TransProd.VisitaClave1) OrElse Me.TransProd.VisitaClave1 = "")) AndAlso (Not IsDBNull(TransProd.FacturaId) AndAlso Not IsNothing(TransProd.FacturaId)) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "I0250"))
                    Exit Sub
                Else
                    If (Me.TransProd.VisitaActual <> sVisitaActual) Then
                        ButtonDetalleContinuar.Enabled = False
                    Else
                        ButtonDetalleContinuar.Enabled = oConHist.Campos("ModificarVenta")
                    End If

                End If
            End If

        End If

            Select Case Me.TransProd.ModuloMovDetalle.TipoTransProd
                Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.MovSinInvEV
                    Dim sNombreListView As String = ""
                    Dim dTotalBonificaciones As Decimal = 0
                    Me.TransProd.Recuperar()
                    Select Case Me.TransProd.TipoFase
                        Case ServicesCentral.TiposFasesPedidos.Cancelado
                            sNombreListView = "DetailViewPedidoCancelado"
                            Me.ButtonDetalleOtros.Visible = False
                        Case ServicesCentral.TiposFasesPedidos.Captura
                            sNombreListView = "DetailViewPedidoActivo"
                            Select Case oVendedor.TipoModulo
                                Case ServicesCentral.TiposModulos.Preventa
                                    Me.ButtonDetalleContinuar.Visible = True
                                    Me.ButtonDetalleOtros.Visible = False

                                Case Else
                                    Me.ButtonDetalleContinuar.Visible = True
                                    If Me.TransProd.ModuloMovDetalle.TipoModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis Then
                                        Me.ButtonDetalleOtros.Visible = True
                                        Me.ButtonDetalleOtros.Text = Me.refaVista.BuscarMensaje("ButtonDetalleOtros", "Surtir")

                                    Else
                                        Me.ButtonDetalleOtros.Visible = False
                                    End If
                            End Select
                        Case ServicesCentral.TiposFasesPedidos.Facturado
                            sNombreListView = "DetailViewPedidoFacturado"
                            Me.ButtonDetalleOtros.Visible = False
                        Case ServicesCentral.TiposFasesPedidos.Surtido
                            sNombreListView = "DetailViewPedidoSurtido"
                            dTotalBonificaciones = oDBVen.EjecutarCmdScalardblSQL("Select Total from TransProd where FacturaID='" & Me.TransProd.TransProdId & "'")
                            If Me.TransProd.ModuloMovDetalle.TipoModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis Then
                                Me.ButtonDetalleOtros.Visible = True
                                Me.ButtonDetalleOtros.Text = Me.refaVista.BuscarMensaje("ButtonDetalleOtros", "Consultar")

                            Else
                                Me.ButtonDetalleOtros.Visible = False
                            End If
                    End Select
                    Me.DetailViewDetalles.Items.Clear()
                    Me.refaVista.CrearDetailView(Me.DetailViewDetalles, sNombreListView)
                    'If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso Me.TransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido AndAlso oConHist.Campos("PagoAutomatico") AndAlso oConHist.Campos("CobrarVentas") Then
                    '    LlenarComboMonedas()
                    'Else
                    '    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    '        For Each ViewItem As Resco.Controls.DetailView.Item In DetailViewDetalles.Items
                    '            ViewItem.Enabled = False
                    '        Next
                    '    End If

                    '    Dim oItem As Resco.Controls.DetailView.ItemComboBox
                    '    oItem = DetailViewDetalles.Items("MonedaId")
                    '    oItem.Visible = False
                    'End If
                    Me.bIniciando = True
                    refaVista.PoblarDetailView(Me.DetailViewDetalles, oDBVen, sNombreListView, "WHERE TRP.TransProdID='" & Me.TransProd.TransProdId & "'")
                    'SeleccionaMoneda()
                    SeleccionaFolioFactura()
                    Me.EliminaElementosCombos()
                    Me.SeleccionaElementosCombos()
                    Me.bIniciando = False
                    ' Verificar la fecha de entrega
                    Me.VerificarFechaEntrega(Me.TransProd.TipoPedido)
                    'Me.VerificarFechaFacturacion()
                    If Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Facturado Then
                        Me.DetailViewDetalles.Items("FechaFacturacion").Visible = True
                    Else
                        If Not Me.DetailViewDetalles.Items("FechaFacturacion") Is Nothing Then
                            Me.DetailViewDetalles.Items("FechaFacturacion").Visible = False
                        End If
                    End If

                    If Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido And Me.TransProd.VisitaClave1 = "" Then
                        Me.DetailViewDetalles.Items("Bonificaciones").Visible = False
                        Me.DetailViewDetalles.Items("MontoReal").Visible = False
                    End If
                    If dTotalBonificaciones > 0 Then
                        Me.DetailViewDetalles.Items("Bonificaciones").Value = Format(dTotalBonificaciones, "#,##0.00")
                        Me.DetailViewDetalles.Items("MontoReal").Value = Format(CDec(Me.DetailViewDetalles.Items("Total").Value) - dTotalBonificaciones, "#,##0.00")
                    End If

                Case ServicesCentral.TiposTransProd.DevolucionesCliente
            End Select
            bHaCambiadoDetalle = False
            If pvCambiarDeIndex Then
                bIniciando = True
                Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageDetalle
                Me.TabControlMovProducto.Refresh()
                bIniciando = False
            End If
            Me.ButtonDetalleContinuar.Focus()
    End Sub

    'Private Sub LlenarComboMonedas()
    '    Dim oItem As Resco.Controls.DetailView.ItemComboBox
    '    Dim dtMonedas As DataTable
    '    Dim sTipoCodigo As String
    '    Dim aMonedas As New ArrayList
    '    dtMonedas = oDBVen.RealizarConsultaSQL("select MonedaId, Nombre, TipoCodigo from Moneda", "Moneda")
    '    For Each drMoneda As DataRow In dtMonedas.Rows
    '        sTipoCodigo = ValorReferencia.BuscarEquivalente("CDGOMON", drMoneda("TipoCodigo").ToString)
    '        Dim oMoneda As New ValorReferencia.Valor(drMoneda("MonedaId"))
    '        oMoneda.Cadena = drMoneda("Nombre") & " " & sTipoCodigo
    '        aMonedas.Add(oMoneda)
    '    Next
    '    If aMonedas.Count > 0 Then
    '        oItem = DetailViewDetalles.Items("MonedaId")
    '        If Not oItem Is Nothing Then
    '            oItem.ValueMember = "Id"
    '            oItem.DisplayMember = "Cadena"
    '            oItem.DataSource = aMonedas
    '            oItem.Visible = True
    '        End If
    '    End If
    '    dtMonedas.Dispose()
    'End Sub

    'Private Sub SeleccionaMoneda()
    '    Dim sConsulta As String = "select ABD.MonedaId from ABNDetalle ABD inner join AbnTrp ABT on ABD.ABNId = ABT.ABNId and ABT.TransProdId = '" & Me.TransProd.TransProdId & "'"
    '    Dim oItem As Resco.Controls.DetailView.ItemComboBox
    '    Dim dtAbonos As DataTable
    '    dtAbonos = oDBVen.RealizarConsultaSQL(sConsulta, "Abono")
    '    oItem = DetailViewDetalles.Items("MonedaId")
    '    If Not oItem Is Nothing Then
    '        If dtAbonos.Rows.Count > 0 Then
    '            If IsDBNull(dtAbonos.Rows(0)("MonedaId")) Then
    '                oItem.Value = oConHist.Campos("MonedaID").ToString
    '            Else
    '                oItem.Value = dtAbonos.Rows(0)("MonedaId").ToString
    '            End If
    '        Else
    '            oItem.Value = oConHist.Campos("MonedaID").ToString
    '        End If
    '    End If
    '    dtAbonos.Dispose()
    'End Sub

    Private Sub SeleccionaFolioFactura()
        Dim sConsulta As New System.Text.StringBuilder
        sConsulta.Append("select Folio from transprod where transprodid = '" & TransProd.FacturaId & "'")

        Dim oItem As Resco.Controls.DetailView.ItemTextBox
        Dim dtFactura As DataTable
        dtFactura = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "Transprod")
        If dtFactura.Rows.Count > 0 Then
            oItem = DetailViewDetalles.Items("FacturaId")
            If Not oItem Is Nothing Then oItem.Value = dtFactura.Rows(0)("Folio").ToString
        End If
        dtFactura.Dispose()
        sConsulta = Nothing
    End Sub

    'Private Sub HabilitarMoneda()
    '    Dim refVenta As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("FormaVenta")
    '    Dim refPago As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("FormaPago")
    '    Dim refMoneda As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("MonedaId")
    '    refMoneda.Enabled = False
    '    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso Me.TransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido AndAlso oConHist.Campos("PagoAutomatico") Then
    '        If Not refVenta.SelectedItem Is Nothing AndAlso Not refPago.SelectedItem Is Nothing Then
    '            Dim oDRVenta As ValorReferencia.Descripcion = refVenta.SelectedItem
    '            Dim nVenta As Integer = CInt(oDRVenta.Id)
    '            Dim oDRPago As ValorReferencia.Descripcion = refPago.SelectedItem
    '            Dim nPago As Integer = CInt(oDRPago.Id)
    '            refMoneda.Enabled = (nVenta = 1 And nPago = 1)
    '        End If
    '    End If
    'End Sub

    'Private Function EliminarPagoAutomatico() As Boolean
    '    Try
    '        'TODO: Probar Cambio TipoPago
    '        If Me.TransProd.CFVTipo = 1 And ValorReferencia.RecuperaGrupo("PAGO", Me.TransProd.ClientePagoId) = "E" Then
    '            If oConHist.Campos("PagoAutomatico") And oConHist.Campos("CobrarVentas") Then
    '                Dim dtAbono As DataTable
    '                dtAbono = oDBVen.RealizarConsultaSQL("SELECT ABNId, FechaHora FROM AbnTrp WHERE TransProdId = '" & Me.TransProd.TransProdId & "'", "AbnTrp")
    '                If dtAbono.Rows.Count > 0 Then
    '                    Dim sABNId As String
    '                    Dim dFechaHora As DateTime
    '                    sABNId = dtAbono.Rows(0)("ABNId")
    '                    dFechaHora = DateTime.Parse(dtAbono.Rows(0)("FechaHora"))
    '                    FormasPago.EliminarABNTrp(sABNId, Me.TransProd.TransProdId, dFechaHora)
    '                    Dim sABDId As String
    '                    sABDId = oDBVen.RealizarScalarSQL("SELECT ABDId FROM ABNDetalle WHERE ABNId = '" & sABNId & "'")
    '                    FormasPago.EliminarABNDetalle(sABNId, sABDId, False)
    '                    FormasPago.EliminarAbono(sABNId)
    '                    Me.TransProd.ClienteActual.ActualizarSaldo(Me.TransProd.Total)
    '                    Me.TransProd.ActualizarSaldo(Me.TransProd.Total)
    '                End If
    '            End If
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function

    'Private Sub ActualizarPreliquidacion()
    '    Try
    '        'TODO: Probar Cambio TipoPago
    '        If Me.TransProd.CFVTipo = 1 And ValorReferencia.RecuperaGrupo("PAGO", TransProd.ClientePagoId).ToUpper = "E" Then
    '            If oConHist.Campos("PagoAutomatico") And oConHist.Campos("CobrarVentas") And oConHist.Campos("Preliquidacion") Then
    '                Dim bExistePreliquidacion As Boolean
    '                Dim sPLIId As String = ""
    '                Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0", "Preliq")
    '                Dim nMontoTotal As Double = 0
    '                bExistePreliquidacion = oDT.Rows.Count > 0
    '                If bExistePreliquidacion Then
    '                    sPLIId = oDT.Rows(0)("PLIId")
    '                    nMontoTotal = oDT.Rows(0)("MontoTotal")
    '                End If
    '                'If oConHist.Campos("PagoAutomatico") Then
    '                'Else
    '                nMontoTotal -= oTransProd.Total
    '                'End If
    '                Dim sComando As String
    '                If bExistePreliquidacion Then
    '                    If nMontoTotal <> 0 Then
    '                        sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
    '                    Else
    '                        Dim bBorrar As Boolean
    '                        bBorrar = (oDBVen.RealizarScalarSQL("select count(*) from PLBPLE where PLIId = '" & sPLIId & "'") = 0)
    '                        bBorrar = bBorrar And (oDBVen.RealizarScalarSQL("select count(*) from TransProd where PLIId = '" & sPLIId & "' and TransProdId <> '" & oTransProd.TransProdId & "'") = 0)
    '                        If bBorrar Then
    '                            sComando = "delete Preliquidacion where PLIId = '" & sPLIId & "'"
    '                        Else
    '                            sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
    '                        End If
    '                    End If
    '                    oDBVen.EjecutarComandoSQL(sComando)

    '                    'Eliminar la relacion de TransProd con Preliquidacion
    '                    oTransProd.PLIId = ""
    '                    oTransProd.ActualizarPLIId()
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Function ValidarTotalPreliquidacion() As Boolean
    '    'TODO: Probar Cambio TipoPago
    '    If Me.TransProd.CFVTipo = 1 And ValorReferencia.RecuperaGrupo("PAGO", Me.TransProd.ClientePagoId).ToUpper = "E" Then
    '        If oConHist.Campos("PagoAutomatico") And oConHist.Campos("CobrarVentas") And oConHist.Campos("Preliquidacion") Then
    '            Dim nMontoTotal As Double = oDBVen.RealizarScalarSQL("SELECT MontoTotal FROM PreLiquidacion where Enviado = 0")
    '            If oTransProd.Total > nMontoTotal Then
    '                Return False
    '            End If
    '        End If
    '    End If
    '    Return True
    'End Function

    Private Sub EliminarProductoNegado()
        Dim sComando As String
        sComando = "delete ProductoNegado where not PromocionClave is null and TransProdId = '" & Me.TransProd.TransProdId & "' "
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub

#Region " ListView "

    Private Sub ListViewFolios_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewFolios.ItemActivate
        'Me.VerPropiedadesDocumento()
    End Sub

#End Region

#Region " Menus "

    Private Sub MenuItemNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNuevo.Click
        Me.CrearDocumento()
    End Sub

    Private Sub MenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        Me.VerPropiedadesDocumento()
    End Sub

    Private Sub MenuItemCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCancelar.Click
        Dim refListViewItem As ListViewItem
        If ListViewFolios.SelectedIndices.Count = 0 Then
            Exit Sub
        End If

        refListViewItem = ListViewFolios.Items(ListViewFolios.SelectedIndices(0))
        Me.TransProd.FolioActual = refListViewItem.Text
        Me.TransProd.TransProdId = refListViewItem.SubItems(ConstPosId).Text
        Me.TransProd.Recuperar()
        'If oDBVen.EjecutarCmdScalarIntSQL("select count(*) from productoprestamo where TransProdID ='" & refListViewItem.SubItems(ConstPosId).Text & "'") > 0 Then
        '    MsgBox(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "E0354"), MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        If Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Facturado Or Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Cancelado Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0030").Replace("$0$", ValorReferencia.BuscarEquivalente("TRPFASE", Me.TransProd.TipoFase)), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido AndAlso Me.TransProd.VisitaActual <> sVisitaActual Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0717").Replace("$0$", ValorReferencia.BuscarEquivalente("TRPFASE", Me.TransProd.TipoFase)), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And Me.TransProd.TipoFase <> ServicesCentral.TiposFasesPedidos.Captura And Me.TransProd.VisitaActual <> sVisitaActual Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0717").Replace("$0$", ValorReferencia.BuscarEquivalente("TRPFASE", Me.TransProd.TipoFase)), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Me.TransProd.VentaCobrada Then
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0496"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Then
            If Me.TransProd.PendientesSurtidos Then
                MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0598"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'If Not ValidarTotalPreliquidacion() Then
            '    MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0590"), MsgBoxStyle.Exclamation)
            '    Exit Sub
            'End If
        End If

        'If MsgBox(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "P0212"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question) <> MsgBoxResult.Yes Then
        '    Exit Sub
        'End If

        If Not ValidarFechaEntregar() Then
            Exit Sub
        End If

        If TransProd.TipoDoc = 3 Then
            ComboBoxMotivo.Enabled = False
        Else
            If Me.ComboBoxMotivo.Items.Count <= 0 Then
                With ComboBoxMotivo
                    Dim aGrupo As New ArrayList()
                    aGrupo.Add("Cancelacion")
                    .DataSource = ValorReferencia.RecuperaVARVGrupo("TRPMOT", aGrupo)

                    If .Items.Count > 0 Then
                        .DisplayMember = "Cadena"
                        .ValueMember = "Id"
                        .SelectedIndex = 0
                    Else
                        ComboBoxMotivo.Enabled = False
                    End If
                End With
            End If
        End If

        Me.Menu = Nothing
        If Not IsNothing(TransProd.FacturaId) AndAlso Not IsDBNull(TransProd.FacturaId) AndAlso TransProd.FacturaId <> "" Then
            Me.LabelP0212.Text = refaVista.BuscarMensaje("MsgBoxGeneral", "P0234")
        Else
            Me.LabelP0212.Text = refaVista.BuscarMensaje("MsgBoxGeneral", "P0212")
        End If
        Me.PanelMotivoCancelacion.Visible = True
        Me.PanelMotivoCancelacion.BringToFront()
        Me.Panel1.Visible = False

    End Sub

    Private Sub MenuItemSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSurtir.Click
        ' Cambios 2 Mayo 2006
        Dim refListViewItem As ListViewItem
        If ListViewFolios.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        refListViewItem = ListViewFolios.Items(ListViewFolios.SelectedIndices(0))
        Me.TransProd.FolioActual = refListViewItem.Text
        Me.TransProd.TransProdId = refListViewItem.SubItems(ConstPosId).Text
        Me.TransProd.Recuperar()
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            Me.TransProd.VisitaClave1 = sVisitaActual
            Me.TransProd.DiaClave1 = oDia.DiaActual
        End If
        Me.TransProd.Actualizar()
        Me.TipoAccion = TiposAccionesDocumentos.SurtirPedido
        Me.Close()
        ' /Cambios 2 Mayo 2006
        'Me.SurtirPedido()
    End Sub

    Private Sub ContextMenuFolios_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuFolios.Popup
        ContextMenuFolios.MenuItems.Clear()
        If ListViewFolios.SelectedIndices.Count = 0 Then
            ContextMenuFolios.MenuItems.Add(Me.MenuItemNuevo)
        Else
            Dim refListViewItem As ListViewItem = ListViewFolios.Items(ListViewFolios.SelectedIndices(0))
            Dim tTipoFasePedido As ServicesCentral.TiposFasesPedidos = MobileClient.TransProd.RecuperarTipoFasePedido(refListViewItem.SubItems(ConstPosId).Text)
            Select Case tTipoFasePedido
                Case ServicesCentral.TiposFasesPedidos.Captura
                    If oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion Then
                        ContextMenuFolios.MenuItems.Add(Me.MenuItemModificar)
                    End If
                    ContextMenuFolios.MenuItems.Add(Me.MenuItemCancelar)
                    If oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Preventa Then
                        ContextMenuFolios.MenuItems.Add(Me.MenuItemSurtir)
                    End If
                Case ServicesCentral.TiposFasesPedidos.Surtido
                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Then
                        ContextMenuFolios.MenuItems.Add(Me.MenuItemModificar)
                        ContextMenuFolios.MenuItems.Add(Me.MenuItemCancelar)
                    End If
                    ContextMenuFolios.MenuItems.Add(Me.MenuItemDetalles)
                Case ServicesCentral.TiposFasesPedidos.Cancelado
                    ContextMenuFolios.MenuItems.Add(Me.MenuItemDetalles)
            End Select
        End If
    End Sub

    Private Sub MenuItemDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDetalles.Click
        Me.VerPropiedadesDocumento()
    End Sub

    Private Sub MenuItemTabNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemTabNuevo.Click
        Me.CrearDocumento()
    End Sub

#End Region

#Region " Botones "

    Private Sub ButtonGeneralContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGeneralContinuar.Click
        If Me.ListViewFolios.SelectedIndices.Count = 0 Then
            'If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            '    MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0046"), MsgBoxStyle.Information)
            '    Exit Sub
            'Else
            Me.CrearDocumento()
            'End If
        Else

            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                Me.TransProd.FolioActual = ListViewFolios.Items(ListViewFolios.SelectedIndices(0)).Text
                Me.TransProd.TransProdId = ListViewFolios.Items(ListViewFolios.SelectedIndices(0)).SubItems(ConstPosId).Text
                Me.TransProd.Recuperar()

                If TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura Then
                    ButtonDetalleOtros_Click(Me, New EventArgs)
                Else
                    Me.VerPropiedadesDocumento()
                End If

            Else
                Me.VerPropiedadesDocumento()
            End If



        End If
    End Sub

    Private Sub ButtonGeneralRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGeneralRegresar.Click
        Me.TipoAccion = TiposAccionesDocumentos.Terminar
        Me.Close()
    End Sub

#End Region

#End Region

    Private Sub SurtirPedido()
        ' Cambios 2 Mayo 2006
        'Dim refListViewItem As ListViewItem
        'If ListViewFolios.SelectedIndices.Count = 0 Then
        '    Exit Sub
        'End If
        'refListViewItem = ListViewFolios.Items(ListViewFolios.SelectedIndices(0))
        If Not ValidarFechaEntregar() Then
            Exit Sub
        End If
        ''Me.TransProd.FolioActual = refListViewItem.Text
        ''Me.TransProd.TransProdId = refListViewItem.SubItems(Me.ConstPosId).Text
        '' / Cambios 2 Mayo 2006
        'If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
        '    Me.TransProd.VisitaClave1 = sVisitaActual
        '    Me.TransProd.DiaClave1 = oDia.DiaActual
        'End If
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Me.AsignarValoresCapturados()
        Me.TransProd.Actualizar()
        Me.TipoAccion = TiposAccionesDocumentos.SurtirPedido
        Me.Close()
    End Sub
    Private Sub ConsultarSurtirPedido()
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Me.TipoAccion = TiposAccionesDocumentos.SurtirPedido
        Me.Close()
    End Sub

#Region " TabPage Detalles "

    Private Sub ButtonDetalleRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetalleRegresar.Click
        Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
        Me.TabControlMovProducto.Refresh()
    End Sub

    Private Sub ButtonDetalleOtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetalleOtros.Click
        If Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido Then
            Select Case Me.TransProd.TipoFase
                Case ServicesCentral.TiposFasesPedidos.Cancelado

                Case ServicesCentral.TiposFasesPedidos.Captura
                    If oDBVen.EjecutarCmdScalarIntSQL("select count(*) from TransProdDetalle where TransProdID = '" & Me.TransProd.TransProdId & "'") <= 0 Then
                        MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0745"), MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    Me.SurtirPedido()
                Case ServicesCentral.TiposFasesPedidos.Facturado

                Case ServicesCentral.TiposFasesPedidos.Surtido
                    Me.ConsultarSurtirPedido()
            End Select
        End If
    End Sub

    Private Sub ButtonDetalleContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetalleContinuar.Click
        'If Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura Then
        If (Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) Then
            If Me.TransProd.PendientesSurtidos Then
                MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0598"), MsgBoxStyle.Exclamation)
                Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
                Me.TabControlMovProducto.Refresh()
                Exit Sub
            End If
        End If

        If (Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido Or Me.TransProd.Tipo = ServicesCentral.TiposTransProd.MovSinInvEV) _
        AndAlso (Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura _
        OrElse (Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido AndAlso (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion))) Then
            If Me.TransProd.VentaCobrada Then
                MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0496"), MsgBoxStyle.Exclamation)
                Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
                Me.TabControlMovProducto.Refresh()
                Exit Sub
            End If
            If Not ValidarFechaEntregar() Then
                Exit Sub
            End If
            If Not Me.ValidarCamposRequeridos() Then
                Exit Sub
            End If
            ' Actualizar los datos editables
            FormProcesando.PubSubTitulo(oVendedor.NombreModulo)
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Recuperando"), Me.TransProd.FolioActual)
            Me.AsignarValoresCapturados()
            Me.TransProd.Actualizar()
            Me.TipoAccion = TiposAccionesDocumentos.Modificar
            Me.Close()
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0030").Replace("$0$", ValorReferencia.BuscarEquivalente("TRPFASE", Me.TransProd.TipoFase)), MsgBoxStyle.Exclamation)
            Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
            Me.TabControlMovProducto.Refresh()
        End If
    End Sub

    Private Sub AsignarValoresCapturados()
        Try
            Dim refItem As Resco.Controls.DetailView.Item
            For Each refItem In Me.DetailViewDetalles.Items
                Select Case refItem.Name
                    Case "Notas"
                        Me.TransProd.Notas = refItem.Text
                    Case "FechaEntrega"
                        Dim refCombo As Resco.Controls.DetailView.ItemDateTime = refItem
                        If Not refCombo Is Nothing Then
                            Me.TransProd.FechaEntrega = refCombo.DateTime
                        End If
                    Case "FormaVenta"
                        Dim refCombo As Resco.Controls.DetailView.ItemComboBox = refItem
                        If Not refCombo.SelectedItem Is Nothing Then
                            Dim oDRV As ValorReferencia.Descripcion = refCombo.SelectedItem
                            Me.TransProd.CFVTipo = CInt(oDRV.Id)
                        End If
                End Select
            Next
            Me.TransProd.ClienteClave = oTransProd.ClienteActual.ClienteClave
            If Me.TransProd.TipoPedido <> ServicesCentral.TiposPedidos.Consignacion AndAlso Me.TransProd.TipoPedido <> ServicesCentral.TiposPedidos.Posfechado Then
                Me.TransProd.FechaEntrega = PrimeraHora(Now).AddDays(ObtenerDiasSurtido)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region


    Private Sub ListViewFolios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewFolios.SelectedIndexChanged
        If Not bIniciando Then
            If Me.ListViewFolios.SelectedIndices.Count = 0 Then
                If Me.TabControlMovProducto.TabPages.Count = 2 Then
                    Me.TabControlMovProducto.TabPages.RemoveAt(1)
                End If
                ButtonGeneralContinuar.Enabled = True
            Else
                If Me.TabControlMovProducto.TabPages.Count = 1 Then
                    Try
                        Me.TabPageDetalle.Text = ListViewFolios.Items(ListViewFolios.SelectedIndices(0)).Text
                        Me.TabControlMovProducto.TabPages.Add(Me.TabPageDetalle)
                        If (Me.TransProd.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV) And oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion Then
                            ButtonGeneralContinuar.Enabled = oConHist.Campos("ModificarVenta")
                        Else

                            ButtonGeneralContinuar.Enabled = True
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub VerificarFechaEntrega(ByVal partTipoPedido As ServicesCentral.TiposPedidos)
        Try
            Dim refDateTime As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewDetalles.Items("FechaEntrega")
            If Not refDateTime Is Nothing Then
                refDateTime.Visible = Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura AndAlso (partTipoPedido = ServicesCentral.TiposPedidos.Posfechado OrElse partTipoPedido = ServicesCentral.TiposPedidos.Consignacion)
                If refDateTime.Visible Then
                    Me.DetailViewDetalles.Refresh()
                    refDateTime.SetFocus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VerificarFechaFacturacion()
        Try
            Dim refDateTime As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewDetalles.Items("FechaFacturacion")
            If Not refDateTime Is Nothing Then
                refDateTime.Visible = IIf(Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Facturado, True, False)
                Me.DetailViewDetalles.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidarFechaEntregar() As Boolean
        If Me.TransProd.TipoPedido = ServicesCentral.TiposPedidos.Posfechado OrElse Me.TransProd.TipoPedido = ServicesCentral.TiposPedidos.Consignacion Then
            Dim refDateTime As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewDetalles.Items("FechaEntrega")
            If Not refDateTime Is Nothing Then
                Dim dFecha As Date = refDateTime.DateTime
                If refDateTime.DateTime < PrimeraHora(Now) Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "MsgBoxFechaInvalida"), MsgBoxStyle.Exclamation)
                    refDateTime.DateTime = PrimeraHora(Now)
                    Return False
                End If
            End If
        End If
        Return True
    End Function


    Private Sub TabControlMovProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlMovProducto.SelectedIndexChanged
        If Not Me.bIniciando Then
            If Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral Then

                With ListViewFolios
                    If .Items.Count > 0 Then
                        '.Items(0).Selected = True
                        .Focus()
                    Else
                        Me.ButtonDetalleContinuar.Focus()
                    End If
                End With

                If Me.bHaCambiadoDetalle Then
                    If MsgBox(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "MsgBoxGuardarCambios"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        If ValidarFechaEntregar() Then
                            Me.AsignarValoresCapturados()
                            Me.TransProd.Actualizar()
                        Else
                            Me.TabControlMovProducto.SelectedIndex = 1
                            Me.TabControlMovProducto.Refresh()
                        End If
                    End If
                    Me.bHaCambiadoDetalle = False
                End If


            Else
                If Me.ListViewFolios.SelectedIndices.Count = 0 Then
                    Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
                Else
                    VerPropiedadesDocumento(False)
                    'With DetailViewDetalles
                    '    If .Items.Count > 0 Then
                    '        .Items(0).SetFocus()
                    '    End If
                    'End With
                End If
            End If
        End If
    End Sub

#Region "HUICHO"

    Private Function ValidarCamposRequeridos() As Boolean
        'CFVTipo - FormaVenta
        Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewDetalles.Items("FormaVenta")
        If refComboBox.SelectedItem Is Nothing OrElse Not refComboBox.SelectedIndex >= 0 Then
            MsgBox(SustituyeCampo(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "BE0001"), refComboBox.Label), MsgBoxStyle.Exclamation)
            refComboBox.SetFocus()
            Return False
        End If
        ''ClientePagoId - FormaPago
        'refComboBox = Me.DetailViewDetalles.Items("FormaPago")
        'If refComboBox.SelectedItem Is Nothing OrElse Not refComboBox.SelectedIndex >= 0 Then
        '    MsgBox(SustituyeCampo(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "BE0001"), refComboBox.Label), MsgBoxStyle.Exclamation)
        '    refComboBox.SetFocus()
        '    Return False
        'End If
        ''Fecha de Cobranza
        'If Me.TransProd.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV And Me.TransProd.Tipo <> ServicesCentral.TiposTransProd.MovSinInvSV Then
        '    Dim refDateTime As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewDetalles.Items("FechaCobranza")
        '    If Not refDateTime Is Nothing Then
        '        Dim dFecha As Date = refDateTime.DateTime
        '        If refDateTime.DateTime < PrimeraHora(Now) Then
        '            MsgBox(Me.refaVista.BuscarMensaje("MsgBoxGeneral", "MsgBoxFechaInvalida"), MsgBoxStyle.Exclamation)
        '            refDateTime.DateTime = PrimeraHora(Now)
        '            Return False
        '        End If
        '    End If
        'End If
        Return True
    End Function

    Private Sub EliminaElementosCombos()
        Try
            'TODO: Cambio Valores Ref
            'Formas de pago del cliente
            Dim oArrFormasVentaCliente As New ArrayList
            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("SELECT DISTINCT CFVTipo FROM CLIFormaVenta WHERE ClienteClave='" & Me.TransProd.ClienteActual.ClienteClave & "' AND Estado=1", "EliminaElementosCombos")

            For Each oDr As DataRow In oDt.Rows
                oArrFormasVentaCliente.Add(oDr("CFVTipo").ToString)
            Next
            oDt.Dispose()
            Dim oDescripcion As ValorReferencia.Descripcion
            Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewDetalles.Items("FormaVenta")
            'FormaVenta
            Dim loArrFormasVenta As ArrayList = refComboBox.DataSource

            If oArrFormasVentaCliente.Count > 0 Then
                For i As Integer = 0 To loArrFormasVenta.Count - 1
                    If i >= loArrFormasVenta.Count Then
                        Exit For
                    End If
                    oDescripcion = loArrFormasVenta(i)
                    If Not oArrFormasVentaCliente.Contains(oDescripcion.Id) Then
                        loArrFormasVenta.RemoveAt(i)
                        If i >= loArrFormasVenta.Count Then
                            Exit For
                        End If
                        i = i - 1
                    End If

                Next
            Else
                loArrFormasVenta.Clear()
            End If
            refComboBox.DataSource = loArrFormasVenta

            ''FormaPago
            ''oArr = New ArrayList
            'refComboBox = Me.DetailViewDetalles.Items("FormaPago")

            'oArrFormasVentaCliente.Clear()
            'oArrFormasVentaCliente = Nothing


            ''TODO: Cambio FormaPago
            'Dim oArrFormasPagoCliente As New ArrayList
            'oDt = oDBVen.RealizarConsultaSQL("SELECT DISTINCT Tipo FROM ClientePago WHERE ClienteClave='" & Me.TransProd.ClienteActual.ClienteClave & "'", "EliminaElementosCombos")
            'If oDt.Rows.Count > 0 Then
            '    For Each oDr As DataRow In oDt.Rows
            '        oArrFormasPagoCliente.Add(oDr("Tipo").ToString)
            '    Next

            '    Dim loArrFormasPago As ArrayList = refComboBox.DataSource
            '    If oArrFormasPagoCliente.Count > 0 Then
            '        For i As Integer = 0 To loArrFormasPago.Count - 1
            '            If i >= loArrFormasPago.Count Then
            '                Exit For
            '            End If
            '            oDescripcion = loArrFormasPago(i)
            '            If Not oArrFormasPagoCliente.Contains(oDescripcion.Id) Then
            '                loArrFormasPago.RemoveAt(i)
            '                If i >= loArrFormasPago.Count Then
            '                    Exit For
            '                End If
            '                i = i - 1
            '            End If
            '        Next
            '    Else
            '        loArrFormasPago.Clear()
            '    End If
            '    refComboBox.DataSource = loArrFormasPago
            '    oArrFormasPagoCliente.Clear()
            '    oArrFormasPagoCliente = Nothing
            'End If
            'oDt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "EliminaElementosCombos")
        End Try

    End Sub

    Private Sub SeleccionaElementosCombos()
        Dim sQuery As String = "SELECT CFVTipo, ClientePagoId FROM TransProd WHERE TransProdId='" & Me.TransProd.TransProdId & "'"
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "SEC")
        Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewDetalles.Items("FormaVenta")
        Dim loArrFormaVenta As ArrayList = refComboBox.DataSource
        Dim n As Integer = -1
        refComboBox.SelectedIndex = n
        For Each oDescripcion As ValorReferencia.Descripcion In loArrFormaVenta
            n += 1
            If oDescripcion.Id = oDt.Rows(0)("CFVTipo") Then
                refComboBox.SelectedIndex = n
                Exit For
            End If
        Next
        'refComboBox = Me.DetailViewDetalles.Items("FormaPago")
        ''n = -1
        'refComboBox.SelectedIndex = 0
        'If (Not IsDBNull(oDt.Rows(0)("ClientePagoId"))) AndAlso oDt.Rows(0)("ClientePagoId") <> String.Empty Then
        '    Dim loArrFormaPago As ArrayList = refComboBox.DataSource
        '    'TODO: Cambio FormaPago
        '    Dim iTipoPago As Integer
        '    iTipoPago = oDt.Rows(0)("ClientePagoId")

        '    For Each oDescripcion As ValorReferencia.Descripcion In loArrFormaPago
        '        n += 1
        '        If oDescripcion.Id = iTipoPago Then
        '            refComboBox.Value = oDescripcion.Id
        '            Exit For
        '        End If
        '    Next
        'End If
        oDt.Dispose()
    End Sub
#End Region


    Private Sub ButtonCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        MenuItemCancelar_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonCancelarSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelarSalir.Click
        Me.Menu = Me.MainMenuMovProducto
        Me.PanelMotivoCancelacion.Visible = False
        Me.Panel1.Visible = True
    End Sub

    Private Sub ButtonCancelarCont_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelarCont.Click

        Cursor.Current = Cursors.WaitCursor
        Me.AsignarValoresCapturados()
        If Me.TransProd.TipoDoc <> 3 Then
            If (ComboBoxMotivo.Items.Count > 0) Then
                Me.TransProd.TipoMotivo = ComboBoxMotivo.SelectedValue
            End If
        End If

        Me.TipoAccion = TiposAccionesDocumentos.CancelarPedido
        Cursor.Current = Cursors.Default
        Me.Close()

    End Sub

End Class
