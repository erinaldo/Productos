Public Class FrmLayout
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StPanel4 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StPanel5 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents jcbMenu As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Archivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Archivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Zoom As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Zoom2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Edicion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Estructura As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Edicion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Estructura1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Abrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Cerrar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Abrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Cerrar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Almacen As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Area As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EstructuraOpen As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Pasillo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Copiar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CopiarN As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Pegar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Rotar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Eliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Nuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Insertar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EliminarEst As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Fila As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Fila1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Columna As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Columna1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EliminarFila As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EliminarFila1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EliminarColumna As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EliminarColumna1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Largo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Nuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Insertar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EliminarEst1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Command1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Almacen1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Area1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EstructuraOpen1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Copiar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CopiarN1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Pegar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Rotar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Eliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Buscar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Buscar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Pasillo1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLayout))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.StPanel3 = New System.Windows.Forms.StatusBarPanel
        Me.StPanel4 = New System.Windows.Forms.StatusBarPanel
        Me.StPanel5 = New System.Windows.Forms.StatusBarPanel
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.jcbMenu = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.Archivo1 = New Janus.Windows.UI.CommandBars.UICommand("Archivo")
        Me.Edicion1 = New Janus.Windows.UI.CommandBars.UICommand("Edicion")
        Me.Estructura1 = New Janus.Windows.UI.CommandBars.UICommand("Estructura")
        Me.Zoom2 = New Janus.Windows.UI.CommandBars.UICommand("Zoom")
        Me.Archivo = New Janus.Windows.UI.CommandBars.UICommand("Archivo")
        Me.Abrir1 = New Janus.Windows.UI.CommandBars.UICommand("Abrir")
        Me.Cerrar1 = New Janus.Windows.UI.CommandBars.UICommand("Cerrar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Salir1 = New Janus.Windows.UI.CommandBars.UICommand("Salir")
        Me.Zoom = New Janus.Windows.UI.CommandBars.UICommand("Zoom")
        Me.Edicion = New Janus.Windows.UI.CommandBars.UICommand("Edicion")
        Me.Copiar1 = New Janus.Windows.UI.CommandBars.UICommand("Copiar")
        Me.CopiarN1 = New Janus.Windows.UI.CommandBars.UICommand("CopiarN")
        Me.Pegar1 = New Janus.Windows.UI.CommandBars.UICommand("Pegar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Rotar1 = New Janus.Windows.UI.CommandBars.UICommand("Rotar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Eliminar1 = New Janus.Windows.UI.CommandBars.UICommand("Eliminar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Buscar1 = New Janus.Windows.UI.CommandBars.UICommand("Buscar")
        Me.Estructura = New Janus.Windows.UI.CommandBars.UICommand("Estructura")
        Me.Nuevo1 = New Janus.Windows.UI.CommandBars.UICommand("Nuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Insertar1 = New Janus.Windows.UI.CommandBars.UICommand("Insertar")
        Me.EliminarEst1 = New Janus.Windows.UI.CommandBars.UICommand("EliminarEst")
        Me.Command1 = New Janus.Windows.UI.CommandBars.UICommand("Largo")
        Me.Abrir = New Janus.Windows.UI.CommandBars.UICommand("Abrir")
        Me.Almacen1 = New Janus.Windows.UI.CommandBars.UICommand("Almacen")
        Me.Area1 = New Janus.Windows.UI.CommandBars.UICommand("Area")
        Me.EstructuraOpen1 = New Janus.Windows.UI.CommandBars.UICommand("EstructuraOpen")
        Me.Pasillo1 = New Janus.Windows.UI.CommandBars.UICommand("Pasillo")
        Me.Cerrar = New Janus.Windows.UI.CommandBars.UICommand("Cerrar")
        Me.Salir = New Janus.Windows.UI.CommandBars.UICommand("Salir")
        Me.Almacen = New Janus.Windows.UI.CommandBars.UICommand("Almacen")
        Me.Area = New Janus.Windows.UI.CommandBars.UICommand("Area")
        Me.EstructuraOpen = New Janus.Windows.UI.CommandBars.UICommand("EstructuraOpen")
        Me.Pasillo = New Janus.Windows.UI.CommandBars.UICommand("Pasillo")
        Me.Copiar = New Janus.Windows.UI.CommandBars.UICommand("Copiar")
        Me.CopiarN = New Janus.Windows.UI.CommandBars.UICommand("CopiarN")
        Me.Pegar = New Janus.Windows.UI.CommandBars.UICommand("Pegar")
        Me.Rotar = New Janus.Windows.UI.CommandBars.UICommand("Rotar")
        Me.Eliminar = New Janus.Windows.UI.CommandBars.UICommand("Eliminar")
        Me.Nuevo = New Janus.Windows.UI.CommandBars.UICommand("Nuevo")
        Me.Insertar = New Janus.Windows.UI.CommandBars.UICommand("Insertar")
        Me.Fila1 = New Janus.Windows.UI.CommandBars.UICommand("Fila")
        Me.Columna1 = New Janus.Windows.UI.CommandBars.UICommand("Columna")
        Me.EliminarEst = New Janus.Windows.UI.CommandBars.UICommand("EliminarEst")
        Me.EliminarFila1 = New Janus.Windows.UI.CommandBars.UICommand("EliminarFila")
        Me.EliminarColumna1 = New Janus.Windows.UI.CommandBars.UICommand("EliminarColumna")
        Me.Fila = New Janus.Windows.UI.CommandBars.UICommand("Fila")
        Me.Columna = New Janus.Windows.UI.CommandBars.UICommand("Columna")
        Me.EliminarFila = New Janus.Windows.UI.CommandBars.UICommand("EliminarFila")
        Me.EliminarColumna = New Janus.Windows.UI.CommandBars.UICommand("EliminarColumna")
        Me.Largo = New Janus.Windows.UI.CommandBars.UICommand("Largo")
        Me.Buscar = New Janus.Windows.UI.CommandBars.UICommand("Buscar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        CType(Me.StPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.jcbMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 681)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StPanel1, Me.StPanel2, Me.StPanel3, Me.StPanel4, Me.StPanel5})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1018, 22)
        Me.StatusBar1.TabIndex = 0
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StPanel1
        '
        Me.StPanel1.Name = "StPanel1"
        Me.StPanel1.Text = "Nombre"
        Me.StPanel1.Width = 290
        '
        'StPanel2
        '
        Me.StPanel2.Name = "StPanel2"
        Me.StPanel2.Text = "Dimensiones"
        Me.StPanel2.Width = 225
        '
        'StPanel3
        '
        Me.StPanel3.Name = "StPanel3"
        Me.StPanel3.Text = "Posición"
        Me.StPanel3.Width = 225
        '
        'StPanel4
        '
        Me.StPanel4.Name = "StPanel4"
        Me.StPanel4.Text = "Total Ubicaciones"
        Me.StPanel4.Width = 125
        '
        'StPanel5
        '
        Me.StPanel5.Name = "StPanel5"
        Me.StPanel5.Text = "Ubicaciones Disponibles"
        Me.StPanel5.Width = 125
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.jcbMenu})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Archivo, Me.Zoom, Me.Edicion, Me.Estructura, Me.Abrir, Me.Cerrar, Me.Salir, Me.Almacen, Me.Area, Me.EstructuraOpen, Me.Pasillo, Me.Copiar, Me.CopiarN, Me.Pegar, Me.Rotar, Me.Eliminar, Me.Nuevo, Me.Insertar, Me.EliminarEst, Me.Fila, Me.Columna, Me.EliminarFila, Me.EliminarColumna, Me.Largo, Me.Buscar})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("52e9b3a0-0c36-4fa0-8edb-84a5849606d6")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.Tag = Nothing
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(100, 0)
        '
        'jcbMenu
        '
        Me.jcbMenu.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.jcbMenu.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.jcbMenu.CommandManager = Me.UiCommandManager1
        Me.jcbMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Archivo1, Me.Edicion1, Me.Estructura1, Me.Zoom2})
        Me.jcbMenu.Key = "Menu"
        Me.jcbMenu.Location = New System.Drawing.Point(0, 0)
        Me.jcbMenu.Name = "jcbMenu"
        Me.jcbMenu.RowIndex = 0
        Me.jcbMenu.Size = New System.Drawing.Size(1018, 26)
        Me.jcbMenu.Text = "Menu"
        '
        'Archivo1
        '
        Me.Archivo1.Key = "Archivo"
        Me.Archivo1.Name = "Archivo1"
        '
        'Edicion1
        '
        Me.Edicion1.Key = "Edicion"
        Me.Edicion1.Name = "Edicion1"
        '
        'Estructura1
        '
        Me.Estructura1.Key = "Estructura"
        Me.Estructura1.Name = "Estructura1"
        '
        'Zoom2
        '
        Me.Zoom2.Key = "Zoom"
        Me.Zoom2.Name = "Zoom2"
        '
        'Archivo
        '
        Me.Archivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Abrir1, Me.Cerrar1, Me.Separator2, Me.Salir1})
        Me.Archivo.Key = "Archivo"
        Me.Archivo.Name = "Archivo"
        Me.Archivo.Text = "A&rchivo"
        '
        'Abrir1
        '
        Me.Abrir1.Key = "Abrir"
        Me.Abrir1.Name = "Abrir1"
        '
        'Cerrar1
        '
        Me.Cerrar1.Key = "Cerrar"
        Me.Cerrar1.Name = "Cerrar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Salir1
        '
        Me.Salir1.Key = "Salir"
        Me.Salir1.Name = "Salir1"
        '
        'Zoom
        '
        Me.Zoom.Key = "Zoom"
        Me.Zoom.Name = "Zoom"
        Me.Zoom.Text = "&Zoom"
        '
        'Edicion
        '
        Me.Edicion.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Copiar1, Me.CopiarN1, Me.Pegar1, Me.Separator1, Me.Rotar1, Me.Separator3, Me.Eliminar1, Me.Separator5, Me.Buscar1})
        Me.Edicion.Key = "Edicion"
        Me.Edicion.Name = "Edicion"
        Me.Edicion.Text = "&Edición"
        '
        'Copiar1
        '
        Me.Copiar1.Key = "Copiar"
        Me.Copiar1.Name = "Copiar1"
        '
        'CopiarN1
        '
        Me.CopiarN1.Key = "CopiarN"
        Me.CopiarN1.Name = "CopiarN1"
        '
        'Pegar1
        '
        Me.Pegar1.Key = "Pegar"
        Me.Pegar1.Name = "Pegar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'Rotar1
        '
        Me.Rotar1.Key = "Rotar"
        Me.Rotar1.Name = "Rotar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'Eliminar1
        '
        Me.Eliminar1.Key = "Eliminar"
        Me.Eliminar1.Name = "Eliminar1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'Buscar1
        '
        Me.Buscar1.Key = "Buscar"
        Me.Buscar1.Name = "Buscar1"
        '
        'Estructura
        '
        Me.Estructura.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Nuevo1, Me.Separator4, Me.Insertar1, Me.EliminarEst1, Me.Command1})
        Me.Estructura.Key = "Estructura"
        Me.Estructura.Name = "Estructura"
        Me.Estructura.Text = "E&structura"
        '
        'Nuevo1
        '
        Me.Nuevo1.Key = "Nuevo"
        Me.Nuevo1.Name = "Nuevo1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'Insertar1
        '
        Me.Insertar1.Key = "Insertar"
        Me.Insertar1.Name = "Insertar1"
        '
        'EliminarEst1
        '
        Me.EliminarEst1.Key = "EliminarEst"
        Me.EliminarEst1.Name = "EliminarEst1"
        '
        'Command1
        '
        Me.Command1.Key = "Largo"
        Me.Command1.Name = "Command1"
        '
        'Abrir
        '
        Me.Abrir.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Almacen1, Me.Area1, Me.EstructuraOpen1, Me.Pasillo1})
        Me.Abrir.Key = "Abrir"
        Me.Abrir.Name = "Abrir"
        Me.Abrir.Text = "&Abrir"
        '
        'Almacen1
        '
        Me.Almacen1.Key = "Almacen"
        Me.Almacen1.Name = "Almacen1"
        '
        'Area1
        '
        Me.Area1.Key = "Area"
        Me.Area1.Name = "Area1"
        '
        'EstructuraOpen1
        '
        Me.EstructuraOpen1.Key = "EstructuraOpen"
        Me.EstructuraOpen1.Name = "EstructuraOpen1"
        '
        'Pasillo1
        '
        Me.Pasillo1.Key = "Pasillo"
        Me.Pasillo1.Name = "Pasillo1"
        '
        'Cerrar
        '
        Me.Cerrar.Key = "Cerrar"
        Me.Cerrar.Name = "Cerrar"
        Me.Cerrar.Text = "&Cerrar Almacén"
        '
        'Salir
        '
        Me.Salir.Key = "Salir"
        Me.Salir.Name = "Salir"
        Me.Salir.Text = "&Salir"
        '
        'Almacen
        '
        Me.Almacen.Key = "Almacen"
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Text = "&Almacén"
        '
        'Area
        '
        Me.Area.Key = "Area"
        Me.Area.Name = "Area"
        Me.Area.Text = "&Area"
        '
        'EstructuraOpen
        '
        Me.EstructuraOpen.Key = "EstructuraOpen"
        Me.EstructuraOpen.Name = "EstructuraOpen"
        Me.EstructuraOpen.Text = "&Estructura"
        '
        'Pasillo
        '
        Me.Pasillo.Key = "Pasillo"
        Me.Pasillo.Name = "Pasillo"
        Me.Pasillo.Text = "&Pasillo"
        '
        'Copiar
        '
        Me.Copiar.Key = "Copiar"
        Me.Copiar.Name = "Copiar"
        Me.Copiar.Text = "&Copiar"
        '
        'CopiarN
        '
        Me.CopiarN.Key = "CopiarN"
        Me.CopiarN.Name = "CopiarN"
        Me.CopiarN.Text = "&Copiado Especial"
        '
        'Pegar
        '
        Me.Pegar.Key = "Pegar"
        Me.Pegar.Name = "Pegar"
        Me.Pegar.Text = "&Pegar"
        '
        'Rotar
        '
        Me.Rotar.Key = "Rotar"
        Me.Rotar.Name = "Rotar"
        Me.Rotar.Text = "&Rotar"
        '
        'Eliminar
        '
        Me.Eliminar.Key = "Eliminar"
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "&Eliminar"
        '
        'Nuevo
        '
        Me.Nuevo.Key = "Nuevo"
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Text = "&Nuevo"
        '
        'Insertar
        '
        Me.Insertar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Fila1, Me.Columna1})
        Me.Insertar.Key = "Insertar"
        Me.Insertar.Name = "Insertar"
        Me.Insertar.Text = "&Insertar"
        '
        'Fila1
        '
        Me.Fila1.Key = "Fila"
        Me.Fila1.Name = "Fila1"
        Me.Fila1.Text = "&Filas en la parte &superior"
        '
        'Columna1
        '
        Me.Columna1.Key = "Columna"
        Me.Columna1.Name = "Columna1"
        Me.Columna1.Text = "&Columnas a la d&erecha"
        '
        'EliminarEst
        '
        Me.EliminarEst.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.EliminarFila1, Me.EliminarColumna1})
        Me.EliminarEst.Key = "EliminarEst"
        Me.EliminarEst.Name = "EliminarEst"
        Me.EliminarEst.Text = "&Eliminar"
        '
        'EliminarFila1
        '
        Me.EliminarFila1.Key = "EliminarFila"
        Me.EliminarFila1.Name = "EliminarFila1"
        Me.EliminarFila1.Text = "&Filas en la parte s&uperior"
        '
        'EliminarColumna1
        '
        Me.EliminarColumna1.Key = "EliminarColumna"
        Me.EliminarColumna1.Name = "EliminarColumna1"
        Me.EliminarColumna1.Text = "&Columnas a la d&erecha"
        '
        'Fila
        '
        Me.Fila.Key = "Fila"
        Me.Fila.Name = "Fila"
        Me.Fila.Text = "&Fila"
        '
        'Columna
        '
        Me.Columna.Key = "Columna"
        Me.Columna.Name = "Columna"
        Me.Columna.Text = "&Columna"
        '
        'EliminarFila
        '
        Me.EliminarFila.Key = "EliminarFila"
        Me.EliminarFila.Name = "EliminarFila"
        Me.EliminarFila.Text = "&Fila"
        '
        'EliminarColumna
        '
        Me.EliminarColumna.Key = "EliminarColumna"
        Me.EliminarColumna.Name = "EliminarColumna"
        Me.EliminarColumna.Text = "&Columna"
        '
        'Largo
        '
        Me.Largo.Key = "Largo"
        Me.Largo.Name = "Largo"
        Me.Largo.Text = "&Largo de Columna"
        '
        'Buscar
        '
        Me.Buscar.Key = "Buscar"
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Text = "Buscar"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.jcbMenu})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.jcbMenu)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(1018, 26)
        '
        'FrmLayout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1018, 703)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximumSize = New System.Drawing.Size(1034, 741)
        Me.Name = "FrmLayout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Almacenes"
        CType(Me.StPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.jcbMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key

            Case "Cerrar"

                ModPOS.Almacen_Activo = ""

                ModPOS.Graba_Layout_Activo()
                Me.Cerrar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                Me.Zoom.Enabled = Janus.Windows.UI.InheritableBoolean.False
                Me.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.False
                Me.Buscar.Enabled = Janus.Windows.UI.InheritableBoolean.False

                If ModPOS.Est_Selected = -1 Then
                    Me.Copiar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.CopiarN.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.Rotar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.Eliminar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.Fila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.Columna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.EliminarColumna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.EliminarFila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    Me.Largo.Enabled = Janus.Windows.UI.InheritableBoolean.False

                End If

                If ModPOS.numEst_CpyVector = -1 And ModPOS.Superficie Is Nothing Then
                    Me.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                End If

                ModPOS.Superficie.Close()
              
            Case "Salir"
                Me.Close()

            Case "Almacen"
                If ModPOS.Almacenes Is Nothing Then
                    ModPOS.Almacenes = New FrmAlmacenes
                    ModPOS.Almacenes.MdiParent = Me
                End If
                ModPOS.Almacenes.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Almacenes.Show()
                ModPOS.Almacenes.BringToFront()

            Case "Area"
                If ModPOS.MtoArea Is Nothing Then
                    ModPOS.MtoArea = New FrmMtoArea
                    ModPOS.MtoArea.MdiParent = Me
                End If
                ModPOS.MtoArea.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoArea.Show()
                ModPOS.MtoArea.BringToFront()

            Case "Pasillo"
                If ModPOS.MtoPasillo Is Nothing Then
                    ModPOS.MtoPasillo = New FrmMtoPasillo
                    ModPOS.MtoPasillo.MdiParent = Me
                End If
                ModPOS.MtoPasillo.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoPasillo.Show()
                ModPOS.MtoPasillo.BringToFront()

            Case "EstructuraOpen"
                If ModPOS.MtoEstructura Is Nothing Then
                    ModPOS.MtoEstructura = New FrmMtoEstructura
                    ModPOS.MtoEstructura.MdiParent = Me
                End If
                ModPOS.MtoEstructura.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoEstructura.Show()
                ModPOS.MtoEstructura.BringToFront()

            Case "Zoom"
                If Not ModPOS.Superficie Is Nothing Then

                    If ModPOS.Zoom Is Nothing Then
                        ModPOS.Zoom = New FrmZoom
                        ModPOS.Zoom.MdiParent = Me
                    End If
                    ModPOS.Zoom.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Zoom.Show()
                    ModPOS.Zoom.BringToFront()

                End If

            Case "Copiar"
                ModPOS.CopiaEstructura(ModPOS.vector(ModPOS.Est_Selected), 1)
                ModPOS.Principal.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.True

            Case "CopiarN"
                If ModPOS.Duplicar Is Nothing Then
                    ModPOS.Duplicar = New FrmDuplicarEst
                End If
                ModPOS.Duplicar.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Duplicar.Show()
                ModPOS.Duplicar.BringToFront()

            Case "Pegar"
                ModPOS.PegaEstructura(ModPOS.Superficie.Punto2)
                Me.Refresh()
                ModPOS.Principal.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.False

            Case "Rotar"
                ModPOS.RotarEstructura(ModPOS.vector(ModPOS.Est_Selected))

            Case "Nuevo"
                If ModPOS.Estructuras Is Nothing Then
                    ModPOS.Estructuras = New FrmEstructura
                    With ModPOS.Estructuras
                        .StartPosition = FormStartPosition.CenterScreen
                        .UiTabPageUbc.Enabled = False
                        .Text = "Nueva Estructura de Almacenaje"
                        .Padre = "Nuevo"
                        .MdiParent = ModPOS.Principal
                        .sAlmacen = ModPOS.Almacen_Activo
                       

                    End With
                End If
                With ModPOS.Estructuras
                    .StartPosition = FormStartPosition.CenterScreen
                    .Show()
                    .BringToFront()
                End With
            Case "Fila"
                ModPOS.InsertaFila(ModPOS.vector(ModPOS.Est_Selected))
                ModPOS.vector(ModPOS.Est_Selected).CambioTamaño = False
            Case "Columna"
                ModPOS.InsertaColumna(ModPOS.vector(ModPOS.Est_Selected))
                ModPOS.vector(ModPOS.Est_Selected).CambioTamaño = False
            Case "Largo"
                If ModPOS.LargoColumna Is Nothing Then
                    ModPOS.LargoColumna = New FrmLargo
                    ModPOS.LargoColumna.MdiParent = Me
                End If
                ModPOS.LargoColumna.StartPosition = FormStartPosition.CenterScreen
                ModPOS.LargoColumna.Show()
                ModPOS.LargoColumna.BringToFront()

            Case "EliminarFila"
                ModPOS.EliminaFila(ModPOS.vector(ModPOS.Est_Selected))
                ModPOS.vector(ModPOS.Est_Selected).CambioTamaño = False
            Case "EliminarColumna"
                ModPOS.EliminaColumna(ModPOS.vector(ModPOS.Est_Selected))
                ModPOS.vector(ModPOS.Est_Selected).CambioTamaño = False
            Case "Eliminar"
                Beep()
                Select Case MessageBox.Show("Se eliminara el :" & ModPOS.vector(ModPOS.Est_Selected).Clave, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes
                        Dim Con As String = ModPOS.BDConexion
                        If ModPOS.SiExite(Con, "sp_estructura_vacia", "@Estructura", ModPOS.vector(ModPOS.Est_Selected).Name) <> 0 Then
                            MessageBox.Show("La estructura seleccionada no puede ser eliminada ya que existen ubicaciones ocupadas o apartadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            ModPOS.Elimina_Estructura(ModPOS.vector(ModPOS.Est_Selected).Name)
                            If Not ModPOS.Superficie Is Nothing Then
                                If ModPOS.Superficie.ALMClave = ModPOS.Almacen_Activo Then
                                    ModPOS.vector(ModPOS.Est_Selected).Visible = False
                                    ModPOS.Superficie.Refresh()
                                End If
                            End If
                        End If
                    Case DialogResult.No
                End Select


            Case "Buscar"
                If ModPOS.Buscar Is Nothing Then
                    ModPOS.Buscar = New FrmBuscar
                    ModPOS.Buscar.MdiParent = Me
                End If
                ModPOS.Buscar.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Buscar.Show()
                ModPOS.Buscar.BringToFront()


        End Select


    End Sub

    Private Sub FrmLayout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       
        If ModPOS.Superficie Is Nothing Then
            Me.Cerrar.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Zoom.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Buscar.Enabled = Janus.Windows.UI.InheritableBoolean.False
        End If

        If ModPOS.Est_Selected = -1 Then
            Me.Copiar.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.CopiarN.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Rotar.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Eliminar.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Fila.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Columna.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.EliminarColumna.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.EliminarFila.Enabled = Janus.Windows.UI.InheritableBoolean.False
            Me.Largo.Enabled = Janus.Windows.UI.InheritableBoolean.False

        End If

        If ModPOS.numEst_CpyVector = -1 Then
            Me.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.False
        End If
    End Sub


    Private Sub FrmLayout_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ModPOS.Almacen_Activo <> "" Then
            e.Cancel = True
        Else
            ModPOS.Principal.Dispose()
            ModPOS.Principal = Nothing
        End If

    End Sub


End Class
