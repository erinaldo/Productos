Public Class FormImprod
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If


        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        oVisita = parsVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.GridDetalle Is Nothing Then
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

        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.GridDetalle Is Nothing Then Me.GridDetalle.Dispose()
        Me.GridDetalle = Nothing
        If Not Me.GridProducto Is Nothing Then Me.GridProducto.Dispose()
        Me.GridProducto = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageVenta As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxComentario As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents LabelComentario As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents LabelMotivo As System.Windows.Forms.Label
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents GridDetalle As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonRegresarD As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarD As System.Windows.Forms.Button
    Friend WithEvents TabPageProducto As System.Windows.Forms.TabPage
    Friend WithEvents GridProducto As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ComboBoxTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxNombre As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxIdentificador As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxClave As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarP As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarP As System.Windows.Forms.Button
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents LabelNombre As System.Windows.Forms.CheckBox
    Friend WithEvents LabelTipo As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxIdentificador As System.Windows.Forms.TextBox
    Friend WithEvents LabelIdentificador As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxClave As System.Windows.Forms.TextBox
    Friend WithEvents LabelClave As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImprod))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPageVenta = New System.Windows.Forms.TabPage
        Me.TextBoxComentario = New System.Windows.Forms.TextBox
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.LabelComentario = New System.Windows.Forms.Label
        Me.ComboBoxMotivo = New System.Windows.Forms.ComboBox
        Me.LabelMotivo = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.GridDetalle = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonRegresarD = New System.Windows.Forms.Button
        Me.ButtonContinuarD = New System.Windows.Forms.Button
        Me.TabPageProducto = New System.Windows.Forms.TabPage
        Me.GridProducto = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ComboBoxTipo2 = New System.Windows.Forms.ComboBox
        Me.ComboBoxNombre = New System.Windows.Forms.ComboBox
        Me.ComboBoxTipo = New System.Windows.Forms.ComboBox
        Me.ComboBoxIdentificador = New System.Windows.Forms.ComboBox
        Me.ComboBoxClave = New System.Windows.Forms.ComboBox
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.ButtonRegresarP = New System.Windows.Forms.Button
        Me.ButtonContinuarP = New System.Windows.Forms.Button
        Me.TextBoxNombre = New System.Windows.Forms.TextBox
        Me.LabelNombre = New System.Windows.Forms.CheckBox
        Me.LabelTipo = New System.Windows.Forms.CheckBox
        Me.TextBoxIdentificador = New System.Windows.Forms.TextBox
        Me.LabelIdentificador = New System.Windows.Forms.CheckBox
        Me.TextBoxClave = New System.Windows.Forms.TextBox
        Me.LabelClave = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageVenta.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.TabPageProducto.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
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
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageVenta)
        Me.TabControl1.Controls.Add(Me.TabPageDetalle)
        Me.TabControl1.Controls.Add(Me.TabPageProducto)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(242, 295)
        Me.TabControl1.TabIndex = 1
        '
        'TabPageVenta
        '
        Me.TabPageVenta.Controls.Add(Me.TextBoxComentario)
        Me.TabPageVenta.Controls.Add(Me.ButtonEliminar)
        Me.TabPageVenta.Controls.Add(Me.ButtonRegresar)
        Me.TabPageVenta.Controls.Add(Me.LabelComentario)
        Me.TabPageVenta.Controls.Add(Me.ComboBoxMotivo)
        Me.TabPageVenta.Controls.Add(Me.LabelMotivo)
        Me.TabPageVenta.Controls.Add(Me.ButtonContinuar)
        Me.TabPageVenta.Location = New System.Drawing.Point(4, 25)
        Me.TabPageVenta.Name = "TabPageVenta"
        Me.TabPageVenta.Size = New System.Drawing.Size(234, 266)
        Me.TabPageVenta.Text = "TabPageVenta"
        '
        'TextBoxComentario
        '
        Me.TextBoxComentario.Location = New System.Drawing.Point(95, 42)
        Me.TextBoxComentario.Multiline = True
        Me.TextBoxComentario.Name = "TextBoxComentario"
        Me.TextBoxComentario.Size = New System.Drawing.Size(136, 194)
        Me.TextBoxComentario.TabIndex = 3
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Enabled = False
        Me.ButtonEliminar.Location = New System.Drawing.Point(160, 239)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 0
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(80, 239)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 1
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'LabelComentario
        '
        Me.LabelComentario.Location = New System.Drawing.Point(8, 40)
        Me.LabelComentario.Name = "LabelComentario"
        Me.LabelComentario.Size = New System.Drawing.Size(88, 20)
        Me.LabelComentario.Text = "LabelComentario"
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(95, 16)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(136, 23)
        Me.ComboBoxMotivo.TabIndex = 5
        '
        'LabelMotivo
        '
        Me.LabelMotivo.Location = New System.Drawing.Point(8, 16)
        Me.LabelMotivo.Name = "LabelMotivo"
        Me.LabelMotivo.Size = New System.Drawing.Size(80, 20)
        Me.LabelMotivo.Text = "LabelMotivo"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(0, 239)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 2
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.GridDetalle)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresarD)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuarD)
        Me.TabPageDetalle.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 266)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.GridDetalle.AllowEditing = True
        Me.GridDetalle.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.GridDetalle.AutoResize = True
        Me.GridDetalle.AutoSearchDelay = 1
        Me.GridDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridDetalle.Clip = ""
        Me.GridDetalle.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.GridDetalle.Col = 0
        Me.GridDetalle.ColSel = 0
        Me.GridDetalle.ComboList = Nothing
        Me.GridDetalle.EditMask = Nothing
        Me.GridDetalle.ExtendLastCol = False
        Me.GridDetalle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.GridDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GridDetalle.LeftCol = 1
        Me.GridDetalle.Location = New System.Drawing.Point(3, 16)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.Redraw = True
        Me.GridDetalle.Row = 1
        Me.GridDetalle.RowSel = 1
        Me.GridDetalle.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.GridDetalle.ScrollTrack = True
        Me.GridDetalle.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.GridDetalle.ShowCursor = False
        Me.GridDetalle.ShowSort = True
        Me.GridDetalle.Size = New System.Drawing.Size(229, 216)
        Me.GridDetalle.StyleInfo = resources.GetString("GridDetalle.StyleInfo")
        Me.GridDetalle.SupportInfo = "dQBBAboAqwDHAGYBagDHAEgBwAAHAdgACwGTADsBJQG9AG4AOQB1APIAPQBdAOwAXACQAG4AMAFfACAB"
        Me.GridDetalle.TabIndex = 0
        Me.GridDetalle.TopRow = 1
        '
        'ButtonRegresarD
        '
        Me.ButtonRegresarD.Location = New System.Drawing.Point(83, 237)
        Me.ButtonRegresarD.Name = "ButtonRegresarD"
        Me.ButtonRegresarD.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarD.TabIndex = 1
        Me.ButtonRegresarD.Text = "ButtonRegresarD"
        '
        'ButtonContinuarD
        '
        Me.ButtonContinuarD.Location = New System.Drawing.Point(3, 237)
        Me.ButtonContinuarD.Name = "ButtonContinuarD"
        Me.ButtonContinuarD.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarD.TabIndex = 2
        Me.ButtonContinuarD.Text = "ButtonContinuarD"
        '
        'TabPageProducto
        '
        Me.TabPageProducto.Controls.Add(Me.GridProducto)
        Me.TabPageProducto.Controls.Add(Me.ComboBoxTipo2)
        Me.TabPageProducto.Controls.Add(Me.ComboBoxNombre)
        Me.TabPageProducto.Controls.Add(Me.ComboBoxTipo)
        Me.TabPageProducto.Controls.Add(Me.ComboBoxIdentificador)
        Me.TabPageProducto.Controls.Add(Me.ComboBoxClave)
        Me.TabPageProducto.Controls.Add(Me.ButtonBuscar)
        Me.TabPageProducto.Controls.Add(Me.ButtonRegresarP)
        Me.TabPageProducto.Controls.Add(Me.ButtonContinuarP)
        Me.TabPageProducto.Controls.Add(Me.TextBoxNombre)
        Me.TabPageProducto.Controls.Add(Me.LabelNombre)
        Me.TabPageProducto.Controls.Add(Me.LabelTipo)
        Me.TabPageProducto.Controls.Add(Me.TextBoxIdentificador)
        Me.TabPageProducto.Controls.Add(Me.LabelIdentificador)
        Me.TabPageProducto.Controls.Add(Me.TextBoxClave)
        Me.TabPageProducto.Controls.Add(Me.LabelClave)
        Me.TabPageProducto.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProducto.Name = "TabPageProducto"
        Me.TabPageProducto.Size = New System.Drawing.Size(234, 266)
        Me.TabPageProducto.Text = "TabPageProducto"
        '
        'GridProducto
        '
        Me.GridProducto.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.GridProducto.AllowEditing = True
        Me.GridProducto.AutoResize = True
        Me.GridProducto.AutoSearchDelay = 1
        Me.GridProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridProducto.Clip = ""
        Me.GridProducto.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.GridProducto.Col = 0
        Me.GridProducto.ColSel = 0
        Me.GridProducto.ComboList = Nothing
        Me.GridProducto.EditMask = Nothing
        Me.GridProducto.ExtendLastCol = False
        Me.GridProducto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.GridProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GridProducto.LeftCol = 1
        Me.GridProducto.Location = New System.Drawing.Point(3, 116)
        Me.GridProducto.Name = "GridProducto"
        Me.GridProducto.Redraw = True
        Me.GridProducto.Row = 0
        Me.GridProducto.RowSel = 0
        Me.GridProducto.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.GridProducto.ScrollTrack = True
        Me.GridProducto.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.GridProducto.ShowCursor = False
        Me.GridProducto.ShowSort = True
        Me.GridProducto.Size = New System.Drawing.Size(229, 119)
        Me.GridProducto.StyleInfo = resources.GetString("GridProducto.StyleInfo")
        Me.GridProducto.SupportInfo = "XQCvAPEADQENAUgBQAGOAAEB3QBaAGYBsgCJABcBDQHNAO8AVwBtAL0ARwBpAFEAwgA0AD4ARwAbAa8A1" & _
            "QC0AA=="
        Me.GridProducto.TabIndex = 0
        Me.GridProducto.TopRow = 1
        '
        'ComboBoxTipo2
        '
        Me.ComboBoxTipo2.Enabled = False
        Me.ComboBoxTipo2.Location = New System.Drawing.Point(167, 64)
        Me.ComboBoxTipo2.Name = "ComboBoxTipo2"
        Me.ComboBoxTipo2.Size = New System.Drawing.Size(65, 23)
        Me.ComboBoxTipo2.TabIndex = 1
        '
        'ComboBoxNombre
        '
        Me.ComboBoxNombre.Enabled = False
        Me.ComboBoxNombre.Location = New System.Drawing.Point(97, 88)
        Me.ComboBoxNombre.Name = "ComboBoxNombre"
        Me.ComboBoxNombre.Size = New System.Drawing.Size(70, 23)
        Me.ComboBoxNombre.TabIndex = 2
        '
        'ComboBoxTipo
        '
        Me.ComboBoxTipo.Enabled = False
        Me.ComboBoxTipo.Location = New System.Drawing.Point(97, 64)
        Me.ComboBoxTipo.Name = "ComboBoxTipo"
        Me.ComboBoxTipo.Size = New System.Drawing.Size(70, 23)
        Me.ComboBoxTipo.TabIndex = 3
        '
        'ComboBoxIdentificador
        '
        Me.ComboBoxIdentificador.Enabled = False
        Me.ComboBoxIdentificador.Location = New System.Drawing.Point(97, 40)
        Me.ComboBoxIdentificador.Name = "ComboBoxIdentificador"
        Me.ComboBoxIdentificador.Size = New System.Drawing.Size(70, 23)
        Me.ComboBoxIdentificador.TabIndex = 4
        '
        'ComboBoxClave
        '
        Me.ComboBoxClave.Enabled = False
        Me.ComboBoxClave.Location = New System.Drawing.Point(97, 16)
        Me.ComboBoxClave.Name = "ComboBoxClave"
        Me.ComboBoxClave.Size = New System.Drawing.Size(70, 23)
        Me.ComboBoxClave.TabIndex = 5
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(161, 237)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonBuscar.TabIndex = 6
        Me.ButtonBuscar.Text = "ButtonBuscar"
        '
        'ButtonRegresarP
        '
        Me.ButtonRegresarP.Location = New System.Drawing.Point(82, 237)
        Me.ButtonRegresarP.Name = "ButtonRegresarP"
        Me.ButtonRegresarP.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarP.TabIndex = 7
        Me.ButtonRegresarP.Text = "ButtonRegresarP"
        '
        'ButtonContinuarP
        '
        Me.ButtonContinuarP.Location = New System.Drawing.Point(3, 237)
        Me.ButtonContinuarP.Name = "ButtonContinuarP"
        Me.ButtonContinuarP.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarP.TabIndex = 8
        Me.ButtonContinuarP.Text = "ButtonContinuarP"
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Enabled = False
        Me.TextBoxNombre.Location = New System.Drawing.Point(167, 88)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(65, 23)
        Me.TextBoxNombre.TabIndex = 9
        '
        'LabelNombre
        '
        Me.LabelNombre.Location = New System.Drawing.Point(1, 88)
        Me.LabelNombre.Name = "LabelNombre"
        Me.LabelNombre.Size = New System.Drawing.Size(96, 20)
        Me.LabelNombre.TabIndex = 10
        Me.LabelNombre.Text = "LabelNombre"
        '
        'LabelTipo
        '
        Me.LabelTipo.Location = New System.Drawing.Point(1, 64)
        Me.LabelTipo.Name = "LabelTipo"
        Me.LabelTipo.Size = New System.Drawing.Size(96, 20)
        Me.LabelTipo.TabIndex = 11
        Me.LabelTipo.Text = "LabelTipo"
        '
        'TextBoxIdentificador
        '
        Me.TextBoxIdentificador.Enabled = False
        Me.TextBoxIdentificador.Location = New System.Drawing.Point(167, 40)
        Me.TextBoxIdentificador.Name = "TextBoxIdentificador"
        Me.TextBoxIdentificador.Size = New System.Drawing.Size(65, 23)
        Me.TextBoxIdentificador.TabIndex = 12
        '
        'LabelIdentificador
        '
        Me.LabelIdentificador.Location = New System.Drawing.Point(1, 40)
        Me.LabelIdentificador.Name = "LabelIdentificador"
        Me.LabelIdentificador.Size = New System.Drawing.Size(96, 20)
        Me.LabelIdentificador.TabIndex = 13
        Me.LabelIdentificador.Text = "LabelIdentificador"
        '
        'TextBoxClave
        '
        Me.TextBoxClave.Enabled = False
        Me.TextBoxClave.Location = New System.Drawing.Point(167, 16)
        Me.TextBoxClave.Name = "TextBoxClave"
        Me.TextBoxClave.Size = New System.Drawing.Size(65, 23)
        Me.TextBoxClave.TabIndex = 14
        '
        'LabelClave
        '
        Me.LabelClave.Location = New System.Drawing.Point(1, 16)
        Me.LabelClave.Name = "LabelClave"
        Me.LabelClave.Size = New System.Drawing.Size(96, 20)
        Me.LabelClave.TabIndex = 15
        Me.LabelClave.Text = "LabelClave"
        '
        'FormImprod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormImprod"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageVenta.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.TabPageProducto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "MIS VARIABLES"
    Private oVista As Vista
    Private fila As Integer = 0
    Private Query As String = String.Empty, Parametros As String = String.Empty, ValAnt As String
    Private VentaNueva As Boolean = True
    Private CambiosVentas As Boolean = False
    Private CambiosProductos As Boolean = False
    Private Hallado As Boolean = False
    Private oCliente As Cliente
    Private oVisita As String = String.Empty
#End Region

#Region "FormImprod"
    Private Sub FormImprod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Recuperar los componentes de la forma
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
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

        If Not Vista.Buscar("FormImprod", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        oVista.ColocarEtiquetasForma(Me)
        Application.DoEvents()
        PreparaCampos()
        MuestraImprodVenta()
        MuestraImprodProducto()
        CambiosVentas = False
        CambiosProductos = False
        If Me.ExistePedidoOVenta Then
            Me.HabilitarTab(Me.TabPageVenta, False)
            Me.TabControl1.SelectedIndex = 1
        End If

        ComboBoxMotivo.Focus()
        [Global].HabilitarMenuItem(Me.MainMenu1, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresarD_Click(Nothing, Nothing)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedIndex
            Case 0
                ComboBoxMotivo.Focus()
            Case 1
                fila = GridDetalle.Row
            Case 2
                LabelClave.Focus()
        End Select

        If TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

#End Region

#Region "FUNCIONES"
    Private Function ValidaCampos(ByVal TipoImp As String) As Boolean
        If TipoImp = "Venta" Then
            If ComboBoxMotivo.Text = String.Empty Then
                Return False
            End If
            Return True
        ElseIf TipoImp = "Producto" Then
            If GridDetalle.Rows.Count = 2 AndAlso GridDetalle.Item(1, 0) = String.Empty Then
                Return True
            End If
            Dim i As Integer
            For i = 1 To GridDetalle.Rows.Count - 1
                If GridDetalle.Item(i, 0) <> String.Empty Then
                    If GridDetalle.Item(i, 2) = String.Empty Then
                        MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), GridDetalle.Cols(2).Caption))
                        GridDetalle.Select(i, 2)
                        Return False
                        'ElseIf GridDetalle.Item(i, 3) = "" OrElse Not IsNumeric(GridDetalle.Item(i, 3)) Then
                    ElseIf GridDetalle.Item(i, 3) = String.Empty OrElse Not IsNumeric(GridDetalle.Item(i, 3)) Then
                        MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), GridDetalle.Cols(3).Caption))
                        GridDetalle.Select(i, 3)
                        Return False
                    ElseIf GridDetalle.Item(i, 4) = String.Empty Then
                        MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), GridDetalle.Cols(4).Caption))
                        GridDetalle.Select(i, 4)
                        Return False
                    End If
                End If
            Next
            Return True
        End If
    End Function

    Private Function ValidaGridDet() As Boolean
        If GridDetalle.Rows.Count > 1 Then
            Dim i As Integer
            For i = 1 To GridDetalle.Rows.Count - 1
                If GridDetalle.Item(i, 0) <> String.Empty Then
                    Return True
                End If
            Next
        Else
            Return False
        End If
    End Function

    Private Function Operador(ByVal op As String, ByVal texto As String) As String
        Select Case op
            Case "Igual", "Igual a"
                Return "='" & texto & "'"
            Case "Diferente", "Diferente de"
                Return "<> '" & texto & "'"
            Case "Empiece con"
                Return "like '" & texto & "%'"
            Case "Termine con"
                Return "like '%" & texto & "'"
            Case "Contenga"
                Return "like '%" & texto & "%'"
            Case "No contenga"
                Return "not like '%" & texto & "%'"
        End Select
        Return String.Empty
    End Function

    Private Function EstaEnFGDetalle(ByVal clave As String, Optional ByVal Salto As Integer = 0) As Boolean
        If GridDetalle.Rows.Count > 1 Then
            Dim i As Integer, Tmp As String
            For i = 1 To GridDetalle.Rows.Count - 1
                If i <> Salto Then
                    Tmp = CStr(GridDetalle.Item(i, 0))
                    If Tmp <> Nothing AndAlso Tmp.ToUpper = clave.ToUpper Then
                        Return True
                    End If
                End If
            Next
            Return False
        Else
            Return False
        End If
    End Function

    Private Function GuardaVenta() As Boolean
        Try
            Dim s As String
            If VentaNueva Then
                s = "insert into improductividadventa values ('" & oVisita & "','" & oDia.DiaActual & "'," & ComboBoxMotivo.SelectedValue & ",'" & TextBoxComentario.Text & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
            Else
                s = "update improductividadventa set tipomotivo=" & ComboBoxMotivo.SelectedValue & ", comentario='" & TextBoxComentario.Text & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where visitaclave='" & oVisita & "' and diaclave='" & oDia.DiaActual & "'"
            End If
            If odbVen.EjecutarComandoSQL(s) > 0 Then
                Return True
            End If
            Return False
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function GuardaProductos() As Boolean
        Try
            If Not EliminarProductos() Then
                Return False
            End If
            Dim i As Integer, s As String, clave As String = String.Empty
            For i = 1 To GridDetalle.Rows.Count - 1
                clave = GridDetalle.Item(i, 0)
                If clave <> String.Empty Then
                    If ProductoNuevo(clave) Then
                        s = "insert into improductividadprod values ('" & oVisita & "','" & oDia.DiaActual & "','" & clave & "'," & GridDetalle.Item(i, 4) & "," & CDbl(GridDetalle.Item(i, 3)) & ",'" & GridDetalle.Item(i, 5) & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
                    Else
                        s = "update improductividadprod set tipomotivo=" & GridDetalle.Item(i, 4) & ", cantidad=" & CDbl(GridDetalle.Item(i, 3)) & ", comentario='" & GridDetalle.Item(i, 5) & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where visitaclave='" & oVisita & "' and diaclave='" & oDia.DiaActual & "' and productoclave='" & clave & "'"
                    End If
                    If oDBVen.EjecutarComandoSQL(s) = 0 Then
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As SqlServerCe.SqlCeException

        Catch ex As Exception

        End Try
    End Function

    Private Function ProductoNuevo(ByVal clave As String) As Boolean
        Try
            Dim Dt As DataTable = odbVen.RealizarConsultaSQL("select productoclave from improductividadprod where productoclave='" & clave & "' and visitaclave='" & oVisita & "' and diaclave='" & oDia.DiaActual & "'", "prod")
            If Dt.Rows.Count > 0 Then
                Dt.Dispose()
                Return False
            End If
            Dt.Dispose()
            Return True
        Catch ex As SqlServerCe.SqlCeException
        Catch ex As Exception
        End Try
    End Function

    Private Function EliminarProductos() As Boolean
        Try
            If GridDetalle.Rows.Count = 2 AndAlso GridDetalle.Item(1, 0) = String.Empty Then
                oDBVen.EjecutarComandoSQL("delete from improductividadprod where visitaclave='" & oVisita & "' and diaclave='" & oDia.DiaActual & "'")
                Return True
            Else
                Dim Claves As String = ClavesGrid(GridDetalle, 0)
                oDBVen.EjecutarComandoSQL("delete from improductividadprod where productoclave not in (" & Claves & ") and visitaclave='" & oVisita & "' and diaclave='" & oDia.DiaActual & "'")
                Return True
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function ClavesGrid(ByVal FG As C1.Win.C1FlexGrid.C1FlexGrid, ByVal col As Integer) As String
        Dim i As Integer
        Dim cadena As String = String.Empty
        For i = 1 To FG.Rows.Count - 1
            If FG.Item(i, col) <> String.Empty Then
                cadena &= "'" & FG.Item(i, col) & "',"
            End If
        Next
        Return Microsoft.VisualBasic.Left(cadena, cadena.Length - 1)
    End Function
    Private Function ExistePedidoOVenta() As Boolean
        Dim sConsulta As String = "SELECT * FROM TransProd INNER JOIN Visita ON TransProd.VisitaClave=Visita.VisitaClave "
        sConsulta &= "WHERE TransProd.DiaClave=Visita.DiaClave AND Visita.ClienteClave='" & oCliente.ClienteClave & "' "
        sConsulta &= "AND TransProd.Tipo IN (1,8) AND TransProd.TipoFase <> 0 AND Visita.VisitaClave='" & oVisita & "'"
        Return oDBVen.RealizarConsultaSQL(sConsulta, "ExistePedidoOVenta").Rows.Count > 0
    End Function
#End Region

#Region "MIS METODOS"

    Private Sub PreparaCampos()
        Dim ValoresMotivo As New Hashtable
        Dim ValoresTipo As New Hashtable
        Dim Mot As New ArrayList
        Dim Motivos As String = String.Empty 'Motivos de la improductividad
        'El combobox de motivos
        Dim aGrupos As New ArrayList
        aGrupos.Add("Venta")
        aGrupos.Add("Terminar Visita")
        Mot = ValorReferencia.RecuperaVARVGrupo("MOTIMPRO", aGrupos)
        If Not IsNothing(Mot) AndAlso Mot.Count > 0 Then
            ComboBoxMotivo.DataSource = Mot
            ComboBoxMotivo.DisplayMember = "Cadena"
            ComboBoxMotivo.ValueMember = "Id"
        End If
        'Los combobox de búsquedas
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("BFSTRING")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                ComboBoxClave.Items.Add(refDesc.Cadena)
                ComboBoxIdentificador.Items.Add(refDesc.Cadena)
                ComboBoxNombre.Items.Add(refDesc.Cadena)
            Next
        End If
        'For Each dr As DataRow In ValorReferencia.RecuperarLista("BFSTRING").Rows
        '    ComboBoxClave.Items.Add(dr(1))
        '    ComboBoxIdentificador.Items.Add(dr(1))
        '    ComboBoxNombre.Items.Add(dr(1))
        'Next
        'El combobox de Tipo
        aValores = ValorReferencia.RecuperarLista("BFVARREF")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                ComboBoxTipo.Items.Add(refDesc.Cadena)
            Next
        End If
        'For Each dr As DataRow In ValorReferencia.RecuperarLista("BFVARREF").Rows
        '    ComboBoxTipo.Items.Add(dr(1))
        'Next
        'El comboboxtipo2
        Dim Tipos As New ArrayList
        aValores = ValorReferencia.RecuperarLista("PROTIPO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                Tipos.Add(New CTipos(refDesc.Id, refDesc.Cadena))
                ValoresTipo.Add(refDesc.Id, refDesc.Cadena)
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("PROTIPO").Rows
            '    Tipos.Add(New CTipos(dr(0), dr(1)))
            '    ValoresTipo.Add(dr(0), dr(1))
            'Next
            ComboBoxTipo2.DataSource = Tipos
            ComboBoxTipo2.DisplayMember = "Descripcion"
            ComboBoxTipo2.ValueMember = "Valor"
        End If
        aValores = Nothing
        'El FlexGrif de Detalle
        With GridDetalle
            .ClipSeparators = vbTab + vbLf
            .Cols.Count = 6
            .Rows.Count = 2
            .Cols.Fixed = 0
            .Cols(0).Name = "Clave"
            .Cols("Clave").Caption = oVista.BuscarMensaje("GridDetalle", "Clave")
            .Cols(0).Width = 60
            .Cols(1).Width = 15
            .Cols(1).ComboList = "..."
            .Cols(2).Name = "NomCorto"
            .Cols("NomCorto").Caption = oVista.BuscarMensaje("GridDetalle", "NomCorto")
            .Cols(2).Width = 100
            .Cols(2).AllowEditing = False
            .Cols(3).Name = "Cantidad"
            .Cols("Cantidad").Caption = oVista.BuscarMensaje("GridDetalle", "Cantidad")
            .Cols(3).Width = 55
            .Cols(3).EditMask = "9999"
            .Cols(3).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightBottom
            Dim aParGrupos As New ArrayList
            aParGrupos.Add("Producto")
            Dim aRes As ArrayList = ValorReferencia.RecuperaVARVGrupo("MOTIMPRO", aParGrupos)
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each Descripcion As ValorReferencia.Descripcion In aRes
                    ValoresMotivo.Add(Descripcion.Id, Descripcion.Cadena)
                Next
            End If
            .Cols(4).Name = "Motivo"
            .Cols("Motivo").Caption = oVista.BuscarMensaje("GridDetalle", "Motivo")
            .Cols("Motivo").DataMap = ValoresMotivo
            .Cols(4).Width = 100
            .Cols(5).Name = "Comentario"
            .Cols("Comentario").Caption = oVista.BuscarMensaje("GridDetalle", "Comentario")
            .Cols(5).Width = 90
        End With
        'El FlexGrid de Productos
        With GridProducto
            .Cols.Count = 5
            .Cols.Fixed = 0
            .Rows.Count = 1
            .Rows.Fixed = 1
            .ClipSeparators = vbTab + vbLf
            .Cols(0).Name = ""
            .Cols(0).DataType = GetType(Boolean)
            .Cols(0).Width = 18
            .Cols(1).Name = "Clave"
            .Cols(1).Caption = oVista.BuscarMensaje("GridProducto", "Clave")
            .Cols(1).Width = 50
            .Cols(1).AllowEditing = False
            .Cols(2).Name = "Identificador"
            .Cols(2).Caption = oVista.BuscarMensaje("GridProducto", "Identificador")
            .Cols(2).Width = 80
            .Cols(2).AllowEditing = False
            .Cols(3).Name = "Tipo"
            .Cols(3).Caption = oVista.BuscarMensaje("GridProducto", "Tipo")
            .Cols(3).Width = 60
            .Cols(3).AllowEditing = False
            .Cols(3).DataMap = ValoresTipo
            .Cols(4).Name = "Nombre"
            .Cols(4).Caption = oVista.BuscarMensaje("GridProducto", "Nombre")
            .Cols(4).Width = 100
            .Cols(4).AllowEditing = False
        End With
        LimpiaProductos()
    End Sub

    Private Sub MuestraImprodVenta()
        Try
            Dim Dt As DataTable = odbVen.RealizarConsultaSQL("select tipomotivo, comentario from improductividadventa where visitaclave='" & oVisita & "' and DiaClave='" & oDia.DiaActual & "'", "ImprodVenta")
            If Dt.Rows.Count > 0 Then
                For Each dr As DataRow In Dt.Rows
                    ComboBoxMotivo.SelectedValue = dr(0).ToString
                    TextBoxComentario.Text = dr(1)
                Next
                ButtonEliminar.Enabled = True
                VentaNueva = False
            End If
            Dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MuestraImprodProducto()
        Dim dt As DataTable = odbVen.RealizarConsultaSQL("select improductividadprod.productoclave, producto.nombre, improductividadprod.cantidad, improductividadprod.tipomotivo, improductividadprod.comentario from improductividadprod, producto where improductividadprod.visitaclave='" & oVisita & "' and improductividadprod.diaclave='" & oDia.DiaActual & "' and improductividadprod.productoclave=producto.productoclave", "ImprodProducto")
        If dt.Rows.Count > 0 Then
            GridDetalle.Rows.Count = 1
            'GridDetalle.Rows.Fixed = 1
            'GridDetalle.Cols.Count = 6
            'GridDetalle.Cols.Fixed = 0
            For Each dr As DataRow In dt.Rows
                GridDetalle.AddItem(dr(0).ToString + vbTab + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString)
            Next
        End If
        dt.Dispose()
    End Sub

    Private Sub LimpiaFila(ByVal Grid As C1.Win.C1FlexGrid.C1FlexGrid, ByVal Fila As Integer, Optional ByVal Salto As Integer = -1)
        Dim i As Integer
        With Grid
            For i = 0 To .Cols.Count - 1
                If i <> Salto Then
                    .Item(Fila, i) = String.Empty
                End If
            Next
        End With
    End Sub

    Private Sub BuscaProducto(ByVal TabIndex As Integer)
        Try
            Dim Dt As DataTable = odbVen.RealizarConsultaSQL(Query, "Producto")
            If Dt.Rows.Count = 0 Then
                Hallado = False
                If TabIndex = 1 Then
                    MsgBox(oVista.BuscarMensaje("Mensajes", "E0005"))
                ElseIf TabIndex = 2 Then
                    MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0034"), Parametros))
                End If
                Dt.Dispose()
                Exit Sub
            End If
            Hallado = True
            If TabIndex = 1 Then
                For Each dr As DataRow In Dt.Rows
                    GridDetalle.Item(GridDetalle.Row, 2) = dr(0)
                Next
            ElseIf TabIndex = 2 Then
                'Me.GridProducto.DataSource = Dt
                'Me.GridProducto.Cols.Insert(0)
                'Me.GridProducto.Cols(0).DataType = GetType(Boolean)
                For Each dr As DataRow In Dt.Rows
                    GridProducto.AddItem(vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString)
                    CambiosProductos = True
                Next
            End If
            Dt.Dispose()
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex1 As Exception
            MsgBox(ex1.Message)
        Finally
            'With Me.GridProducto
            '    .Cols(0).Name = ""
            '    .Cols(0).Width = 18
            '    .AllowEditing = True
            '    .Cols(1).Name = "Clave"
            '    .Cols(1).Caption = oVista.BuscarMensaje("GridProducto", "Clave")
            '    .Cols(1).Width = 50
            '    .Cols(1).AllowEditing = False
            '    .Cols(2).Name = "Identificador"
            '    .Cols(2).Caption = oVista.BuscarMensaje("GridProducto", "Identificador")
            '    .Cols(2).Width = 80
            '    .Cols(2).AllowEditing = False
            '    .Cols(3).Name = "Tipo"
            '    .Cols(3).Caption = oVista.BuscarMensaje("GridProducto", "Tipo")
            '    .Cols(3).Width = 60
            '    .Cols(3).AllowEditing = False
            '    .Cols(4).Name = "Nombre"
            '    .Cols(4).Caption = oVista.BuscarMensaje("GridProducto", "Nombre")
            '    .Cols(4).Width = 100
            '    .Cols(4).AllowEditing = False
            'End With
        End Try
    End Sub

    Private Sub LimpiaProductos()
        If ComboBoxClave.Items.Count > 0 Then ComboBoxClave.SelectedIndex = 0
        If ComboBoxTipo.Items.Count > 0 Then ComboBoxTipo.SelectedIndex = 0
        If ComboBoxNombre.Items.Count > 0 Then ComboBoxNombre.SelectedIndex = 0
        If ComboBoxIdentificador.Items.Count > 0 Then ComboBoxIdentificador.SelectedIndex = 0
        If ComboBoxTipo2.Items.Count > 0 Then ComboBoxTipo2.SelectedIndex = 0
        TextBoxClave.Text = String.Empty
        TextBoxIdentificador.Text = String.Empty
        TextBoxNombre.Text = String.Empty
        LabelClave.Checked = False
        LabelTipo.Checked = False
        LabelNombre.Checked = False
        LabelIdentificador.Checked = False
        GridProducto.Rows.Count = 1
    End Sub

    Private Sub CreaQuery()
        GridProducto.DataSource = Nothing
        GridProducto.Rows.Count = 1
        Parametros = String.Empty
        Query = "select producto.productoclave, producto.id, producto.tipo, producto.nombre from producto"
        'Query = "select producto.productoclave, producto.id, producto.tipo, producto.nombre, producto.tipofase from producto"
        'Query = "select producto.productoclave as '" & oVista.BuscarMensaje("GridProducto", "Clave") & "', producto.id as '" & oVista.BuscarMensaje("GridProducto", "Identificador") & "', producto.tipo as '" & oVista.BuscarMensaje("GridProducto", "Tipo") & "', producto.nombre as '" & oVista.BuscarMensaje("GridProducto", "Nombre") & "' from producto"
        Dim where As Boolean = False
        If LabelClave.Checked Then
            Parametros &= LabelClave.Text & " " & ComboBoxClave.Text & " " & TextBoxClave.Text & ", "
            Query &= " where productoclave " & Operador(ComboBoxClave.Text, TextBoxClave.Text)
            where = True
        End If
        If LabelIdentificador.Checked Then
            Parametros &= LabelIdentificador.Text & " " & ComboBoxIdentificador.Text & " " & TextBoxIdentificador.Text & ", "
            If where Then
                Query &= " and id " & Operador(ComboBoxIdentificador.Text, TextBoxIdentificador.Text)
            Else
                Query &= " where id " & Operador(ComboBoxIdentificador.Text, TextBoxIdentificador.Text)
                where = True
            End If
        End If
        If LabelTipo.Checked Then
            Parametros &= LabelTipo.Text & " " & ComboBoxTipo.Text & " " & ComboBoxTipo2.Text & ", "
            If where Then
                Query &= " and tipo " & Operador(ComboBoxTipo.Text, ComboBoxTipo2.SelectedValue)
            Else
                Query &= " where tipo " & Operador(ComboBoxTipo.Text, ComboBoxTipo2.SelectedValue)
                where = True
            End If
        End If
        If LabelNombre.Checked Then
            Parametros &= LabelNombre.Text & " " & ComboBoxNombre.Text & " " & TextBoxNombre.Text & ", "
            If where Then
                Query &= " and nombre " & Operador(ComboBoxNombre.Text, TextBoxNombre.Text)
            Else
                Query &= " where nombre " & Operador(ComboBoxNombre.Text, TextBoxNombre.Text)
            End If
        End If
        If Parametros.Length > 0 Then
            Parametros = Microsoft.VisualBasic.Left(Parametros, Parametros.Length - 2)
        End If
    End Sub

    Private Sub HabilitarTab(ByRef prTab As TabPage, ByVal pvHabilitado As Boolean)
        For Each oControl As Control In prTab.Controls
            oControl.Enabled = pvHabilitado
        Next
    End Sub
#End Region

#Region "TabPageVenta"

    Private Sub ImprimirTicket()
        Dim sGrupoActual As String = ValorReferencia.RecuperaGrupo("MOTIMPRO", ComboBoxMotivo.SelectedValue)
        If sGrupoActual.ToUpper = "TERMINAR VISITA" Then
            'Se modifica debido al folio 3532
            'If oVendedor.motconfiguracion.MensajeImpresion Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oVisita, 0, 29, oCliente, oVisita)
            End If
            'End If
        End If
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If ValidaCampos("Venta") Then
            If Not GuardaVenta() Then
                MsgBox("La Improductividad de Venta no se guardó")
            End If
            ImprimirTicket()
            If oVendedor.motconfiguracion.Secuencia Then
                If CType(ComboBoxMotivo.SelectedItem, ValorReferencia.Descripcion).Grupo = "Terminar Visita" Then
                    ctrlSeguimiento.TerminarVisita = True
                ElseIf CType(ComboBoxMotivo.SelectedItem, ValorReferencia.Descripcion).Grupo = "Venta" Then
                    ctrlSeguimiento.Improductividad = True
                End If
            End If
            Me.Close()
        Else
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelMotivo.Text))
            ComboBoxMotivo.Focus()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        Try
            Dim s As String
            s = "delete from improductividadventa where visitaclave='" & oVisita & "' and diaclave='" & oDia.DiaActual & "'"
            If oDBVen.EjecutarComandoSQL(s) > 0 Then
                Me.Close()
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxComentario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxComentario.KeyDown
        CambiosVentas = True
    End Sub

    Private Sub ComboBoxMotivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxMotivo.SelectedIndexChanged
        CambiosVentas = True
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        If CambiosVentas Then
            If cerrarForma() Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
#End Region

#Region "TabPageDetalle"
    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            If GridDetalle.Rows.Count > 2 Then
                GridDetalle.RemoveItem(GridDetalle.RowSel)
                CambiosProductos = True
            Else
                If GridDetalle.Item(1, 0) = "" Then
                    MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), "Improductividad"))
                Else
                    LimpiaFila(GridDetalle, 1, 1)
                    CambiosProductos = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridDetalle_StartEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
        If e.Col = 0 Then
            fila = e.Row
            ValAnt = GridDetalle.Item(fila, e.Col)
        End If
    End Sub

    Private Sub ButtonRegresarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarD.Click
        If CambiosProductos Then
            If cerrarForma() Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        If GridDetalle.Rows.Count = 1 Then
            ContextMenu.MenuItems(0).Enabled = False
        End If
    End Sub

    Private Sub ButtonContinuarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarD.Click
        If Not CambiosProductos Then
            Me.Close()
        Else
            If ValidaCampos("Producto") Then
                If Not GuardaProductos() Then
                    MsgBox("Los productos no se guardaron correctamente")
                Else
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub GridDetalle_CellButtonClick(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles GridDetalle.CellButtonClick
        fila = GridDetalle.Row
        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub GridDetalle_AfterEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles GridDetalle.AfterEdit
        CambiosProductos = True
        If e.Col = 0 Then
            Dim clave As String = GridDetalle.Item(e.Row, 0)
            If clave <> String.Empty Then
                If EstaEnFGDetalle(clave, e.Row) Then
                    MsgBox(oVista.BuscarMensaje("Mensajes", "E0052"))
                    GridDetalle.Item(e.Row, 0) = ValAnt
                    'LimpiaFila(GridDetalle, e.Row, 1)
                Else
                    Query = "select nombre from producto where productoclave='" & clave & "'"
                    BuscaProducto(TabControl1.SelectedIndex)
                    If Not Hallado Then
                        GridDetalle.Item(e.Row, 0) = ValAnt
                    End If
                End If
            Else
                GridDetalle.Item(e.Row, 0) = ValAnt
                'LimpiaFila(GridDetalle, e.Row, 1)
            End If
        ElseIf e.Col = 5 Then
            If GridDetalle.Item(e.Row, 0) <> String.Empty AndAlso GridDetalle.Row = GridDetalle.Rows.Count - 1 Then
                GridDetalle.Rows.Count = GridDetalle.Rows.Count + 1
                GridDetalle.StartEditing(GridDetalle.Rows.Count - 1, 0)
            End If
        End If
    End Sub

#End Region

#Region "TabPageProducto"
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        CreaQuery()
        BuscaProducto(TabControl1.SelectedIndex)
    End Sub

    Private Sub ButtonRegresarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarP.Click
        LimpiaProductos()
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub ButtonContinuarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarP.Click
        If GridProducto.Rows.Count > 1 Then
            Dim i As Integer, primero As Boolean = True
            If fila = 0 Then
                fila = 1
            End If
            For i = 1 To GridProducto.Rows.Count - 1
                If GridProducto.Item(i, 0) Then
                    If Not EstaEnFGDetalle(GridProducto.Item(i, 1)) Then
                        If primero Then
                            GridDetalle.Item(fila, 0) = GridProducto.Item(i, 1)
                            GridDetalle.Item(fila, 2) = GridProducto.Item(i, 4)
                            GridDetalle.Item(fila, 3) = "1"
                            GridDetalle.Item(fila, 4) = String.Empty
                            GridDetalle.Item(fila, 5) = String.Empty
                            primero = False
                        Else
                            GridDetalle.AddItem(GridProducto.Item(i, 1).ToString + vbTab + vbTab + GridProducto.Item(i, 4).ToString + vbTab + "1" + vbTab + "" + vbTab + "")
                        End If
                    End If
                End If
            Next
            LimpiaProductos()
        End If
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub LabelClave_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelClave.CheckStateChanged
        If LabelClave.Checked Then
            ComboBoxClave.Enabled = True
            TextBoxClave.Enabled = True
        Else
            ComboBoxClave.Enabled = False
            TextBoxClave.Enabled = False
        End If
    End Sub

    Private Sub LabelIdentificador_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelIdentificador.CheckStateChanged
        If LabelIdentificador.Checked Then
            ComboBoxIdentificador.Enabled = True
            TextBoxIdentificador.Enabled = True
        Else
            ComboBoxIdentificador.Enabled = False
            TextBoxIdentificador.Enabled = False
        End If
    End Sub

    Private Sub LabelTipo_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelTipo.CheckStateChanged
        If LabelTipo.Checked Then
            ComboBoxTipo.Enabled = True
            ComboBoxTipo2.Enabled = True
        Else
            ComboBoxTipo.Enabled = False
            ComboBoxTipo2.Enabled = False
        End If
    End Sub

    Private Sub LabelNombre_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelNombre.CheckStateChanged
        If LabelNombre.Checked Then
            ComboBoxNombre.Enabled = True
            TextBoxNombre.Enabled = True
        Else
            ComboBoxNombre.Enabled = False
            TextBoxNombre.Enabled = False
        End If
    End Sub


#End Region
    
    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.TabControl1.SelectedIndex = 0 Then
            ButtonRegresar_Click(Nothing, Nothing)
        ElseIf Me.TabControl1.SelectedIndex = 1 Then
            ButtonRegresarD_Click(Nothing, Nothing)
        Else
            ButtonRegresarP_Click(Nothing, Nothing)
        End If
    End Sub

    Private Function cerrarForma() As Boolean
        If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            Return True
        End If

        Return False
    End Function
End Class

#Region "Otras Clases"
Public Class CMotivos
    Private Desc As String
    Private Val As String

    Public Sub New(ByVal v As String, ByVal d As String)
        MyBase.New()
        Me.Desc = d
        Me.Val = v
    End Sub

    Public ReadOnly Property Descripcion() As String
        Get
            Return Desc
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return Val
        End Get
    End Property

End Class

Public Class CTipos
    Private Desc As String
    Private Val As String

    Public Sub New(ByVal v As String, ByVal d As String)
        MyBase.New()
        Me.Desc = d
        Me.Val = v
    End Sub

    Public ReadOnly Property Descripcion() As String
        Get
            Return Desc
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return Val
        End Get
    End Property
End Class

#End Region
