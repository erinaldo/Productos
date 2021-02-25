Imports System.Data.SqlServerCe

Public Class FormMercadeo
    Inherits System.Windows.Forms.Form
    Private Const ConstMenuRegresar = 0
    Private ValoresTipoPago As New Hashtable
    Private strEstatusModificado As String = "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "' "
    Private bHuboCambios As Boolean
    Private eModo As Modo
    Private blnSeleccionManual As Boolean = False
    Private iTabSeleccionado As Integer = 0
    Private bContinuar As Boolean = True
    Private strKeyActual As String
    Private strDetKeyActual As String
    Private Regresando As Boolean

    Public ImporteAnt As Decimal
    Public sVisitaClave As String
    Public bCargado As Boolean
    Public bEditando As Boolean
    Public sCte As String = ""

    Public Enum Modo
        Crear = 1
        Modificar = 2
        Cancelar = 3
        Vacio = 4
    End Enum

    Protected tTipoOpcion As ServicesCentral.TiposOpcionesMenuDia
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlAplicacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPageMercadeo As System.Windows.Forms.TabPage
    Friend WithEvents ListViewMenu As System.Windows.Forms.ListView
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxProducto As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxTipo As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxPresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxPresetacion As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPrecio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVentaAnterior As System.Windows.Forms.TextBox
    Friend WithEvents ButtonContinuar1 As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar1 As System.Windows.Forms.Button
    Friend WithEvents LabelVentaAnterior As System.Windows.Forms.Label
    Friend WithEvents LabelPrecio As System.Windows.Forms.Label
    Friend WithEvents LabelCantidad As System.Windows.Forms.Label
    Friend WithEvents LabelPresentacion As System.Windows.Forms.Label
    Friend WithEvents LabelTipo As System.Windows.Forms.Label
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents TabPageDetalle2 As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LabelProveedor As System.Windows.Forms.Label
    Friend WithEvents LabelUbicacion As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar2 As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar2 As System.Windows.Forms.Button

#Region "PROPIEDADES"
    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuDia
        Get
            Return tTipoOpcion
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuDia)
            tTipoOpcion = Value
        End Set
    End Property
    Public Property Transaccion() As SqlCeTransaction
        Get
            Return odbVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            odbVen.Transaccion = Value
        End Set
    End Property
#End Region


    Private refaVista As Vista

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        ListViewMenu.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewMenu.Activation = oApp.TipoSeleccion
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuDia Is Nothing Then Me.MainMenuDia.Dispose()
        If Not Me.ListViewMenu Is Nothing Then
            If Me.ListViewMenu.Columns.Count > 0 Then
                Me.ListViewMenu.Columns.Clear()
            End If
        End If
        If Not Me.ComboBoxPresentacion Is Nothing Then
            Me.ComboBoxPresentacion.DataSource = Nothing
            Me.ComboBoxPresentacion.Dispose()
        End If
        If Not Me.ComboBoxProducto Is Nothing Then
            Me.ComboBoxProducto.DataSource = Nothing
            Me.ComboBoxProducto.Dispose()
        End If
        If Not Me.ComboBoxProveedor Is Nothing Then
            Me.ComboBoxProveedor.DataSource = Nothing
            Me.ComboBoxProveedor.Dispose()
        End If
        If Not Me.ComboBoxTipo Is Nothing Then
            Me.ComboBoxTipo.DataSource = Nothing
            Me.ComboBoxTipo.Dispose()
        End If
        If Not Me.ComboBoxUbicacion Is Nothing Then
            Me.ComboBoxUbicacion.DataSource = Nothing
            Me.ComboBoxUbicacion.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuDia As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuDia = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlAplicacion = New System.Windows.Forms.TabControl
        Me.TabPageMercadeo = New System.Windows.Forms.TabPage
        Me.ListViewMenu = New System.Windows.Forms.ListView
        Me.LabelMenu = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.ComboBoxProducto = New System.Windows.Forms.ComboBox
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.ComboBoxTipo = New System.Windows.Forms.ComboBox
        Me.TextBoxTipo = New System.Windows.Forms.TextBox
        Me.ComboBoxPresentacion = New System.Windows.Forms.ComboBox
        Me.TextBoxPresetacion = New System.Windows.Forms.TextBox
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox
        Me.TextBoxPrecio = New System.Windows.Forms.TextBox
        Me.TextBoxVentaAnterior = New System.Windows.Forms.TextBox
        Me.ButtonContinuar1 = New System.Windows.Forms.Button
        Me.ButtonRegresar1 = New System.Windows.Forms.Button
        Me.LabelVentaAnterior = New System.Windows.Forms.Label
        Me.LabelPrecio = New System.Windows.Forms.Label
        Me.LabelCantidad = New System.Windows.Forms.Label
        Me.LabelPresentacion = New System.Windows.Forms.Label
        Me.LabelTipo = New System.Windows.Forms.Label
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.TabPageDetalle2 = New System.Windows.Forms.TabPage
        Me.ComboBoxUbicacion = New System.Windows.Forms.ComboBox
        Me.TextBoxUbicacion = New System.Windows.Forms.TextBox
        Me.ComboBoxProveedor = New System.Windows.Forms.ComboBox
        Me.TextBoxProveedor = New System.Windows.Forms.TextBox
        Me.LabelProveedor = New System.Windows.Forms.Label
        Me.LabelUbicacion = New System.Windows.Forms.Label
        Me.ButtonContinuar2 = New System.Windows.Forms.Button
        Me.ButtonRegresar2 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControlAplicacion.SuspendLayout()
        Me.TabPageMercadeo.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.TabPageDetalle2.SuspendLayout()
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
        Me.TabControlAplicacion.Controls.Add(Me.TabPageMercadeo)
        Me.TabControlAplicacion.Controls.Add(Me.TabPageDetalle)
        Me.TabControlAplicacion.Controls.Add(Me.TabPageDetalle2)
        Me.TabControlAplicacion.Location = New System.Drawing.Point(0, 0)
        Me.TabControlAplicacion.Name = "TabControlAplicacion"
        Me.TabControlAplicacion.SelectedIndex = 0
        Me.TabControlAplicacion.Size = New System.Drawing.Size(242, 295)
        Me.TabControlAplicacion.TabIndex = 1
        '
        'TabPageMercadeo
        '
        Me.TabPageMercadeo.Controls.Add(Me.ListViewMenu)
        Me.TabPageMercadeo.Controls.Add(Me.LabelMenu)
        Me.TabPageMercadeo.Controls.Add(Me.ButtonContinuar)
        Me.TabPageMercadeo.Controls.Add(Me.ButtonRegresar)
        Me.TabPageMercadeo.Controls.Add(Me.ButtonEliminar)
        Me.TabPageMercadeo.Location = New System.Drawing.Point(0, 0)
        Me.TabPageMercadeo.Name = "TabPageMercadeo"
        Me.TabPageMercadeo.Size = New System.Drawing.Size(242, 272)
        Me.TabPageMercadeo.Text = "TabPageMercadeo"
        '
        'ListViewMenu
        '
        Me.ListViewMenu.CheckBoxes = True
        Me.ListViewMenu.FullRowSelect = True
        Me.ListViewMenu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMenu.Location = New System.Drawing.Point(4, 17)
        Me.ListViewMenu.Name = "ListViewMenu"
        Me.ListViewMenu.Size = New System.Drawing.Size(232, 216)
        Me.ListViewMenu.TabIndex = 0
        Me.ListViewMenu.View = System.Windows.Forms.View.Details
        '
        'LabelMenu
        '
        Me.LabelMenu.Location = New System.Drawing.Point(4, 16)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(230, 20)
        Me.LabelMenu.Text = "LabelMenu"
        Me.LabelMenu.Visible = False
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 236)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 2
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(81, 236)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(157, 236)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxProducto)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxProducto)
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxTipo)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxTipo)
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxPresentacion)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxPresetacion)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxCantidad)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxPrecio)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxVentaAnterior)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuar1)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresar1)
        Me.TabPageDetalle.Controls.Add(Me.LabelVentaAnterior)
        Me.TabPageDetalle.Controls.Add(Me.LabelPrecio)
        Me.TabPageDetalle.Controls.Add(Me.LabelCantidad)
        Me.TabPageDetalle.Controls.Add(Me.LabelPresentacion)
        Me.TabPageDetalle.Controls.Add(Me.LabelTipo)
        Me.TabPageDetalle.Controls.Add(Me.LabelProducto)
        Me.TabPageDetalle.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 269)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'ComboBoxProducto
        '
        Me.ComboBoxProducto.Location = New System.Drawing.Point(103, 18)
        Me.ComboBoxProducto.Name = "ComboBoxProducto"
        Me.ComboBoxProducto.Size = New System.Drawing.Size(124, 22)
        Me.ComboBoxProducto.TabIndex = 0
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(103, 41)
        Me.TextBoxProducto.MaxLength = 30
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(124, 21)
        Me.TextBoxProducto.TabIndex = 1
        '
        'ComboBoxTipo
        '
        Me.ComboBoxTipo.Location = New System.Drawing.Point(103, 65)
        Me.ComboBoxTipo.Name = "ComboBoxTipo"
        Me.ComboBoxTipo.Size = New System.Drawing.Size(124, 22)
        Me.ComboBoxTipo.TabIndex = 2
        '
        'TextBoxTipo
        '
        Me.TextBoxTipo.Location = New System.Drawing.Point(103, 88)
        Me.TextBoxTipo.MaxLength = 30
        Me.TextBoxTipo.Name = "TextBoxTipo"
        Me.TextBoxTipo.Size = New System.Drawing.Size(124, 21)
        Me.TextBoxTipo.TabIndex = 3
        '
        'ComboBoxPresentacion
        '
        Me.ComboBoxPresentacion.Location = New System.Drawing.Point(104, 113)
        Me.ComboBoxPresentacion.Name = "ComboBoxPresentacion"
        Me.ComboBoxPresentacion.Size = New System.Drawing.Size(124, 22)
        Me.ComboBoxPresentacion.TabIndex = 4
        '
        'TextBoxPresetacion
        '
        Me.TextBoxPresetacion.Location = New System.Drawing.Point(103, 137)
        Me.TextBoxPresetacion.MaxLength = 30
        Me.TextBoxPresetacion.Name = "TextBoxPresetacion"
        Me.TextBoxPresetacion.Size = New System.Drawing.Size(124, 21)
        Me.TextBoxPresetacion.TabIndex = 5
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(103, 162)
        Me.TextBoxCantidad.MaxLength = 10
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(124, 21)
        Me.TextBoxCantidad.TabIndex = 6
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(103, 184)
        Me.TextBoxPrecio.MaxLength = 10
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.Size = New System.Drawing.Size(124, 21)
        Me.TextBoxPrecio.TabIndex = 7
        '
        'TextBoxVentaAnterior
        '
        Me.TextBoxVentaAnterior.Location = New System.Drawing.Point(103, 206)
        Me.TextBoxVentaAnterior.MaxLength = 10
        Me.TextBoxVentaAnterior.Name = "TextBoxVentaAnterior"
        Me.TextBoxVentaAnterior.Size = New System.Drawing.Size(124, 21)
        Me.TextBoxVentaAnterior.TabIndex = 8
        '
        'ButtonContinuar1
        '
        Me.ButtonContinuar1.Location = New System.Drawing.Point(84, 232)
        Me.ButtonContinuar1.Name = "ButtonContinuar1"
        Me.ButtonContinuar1.Size = New System.Drawing.Size(69, 24)
        Me.ButtonContinuar1.TabIndex = 9
        Me.ButtonContinuar1.Text = "ButtonContinuar1"
        '
        'ButtonRegresar1
        '
        Me.ButtonRegresar1.Location = New System.Drawing.Point(158, 232)
        Me.ButtonRegresar1.Name = "ButtonRegresar1"
        Me.ButtonRegresar1.Size = New System.Drawing.Size(69, 24)
        Me.ButtonRegresar1.TabIndex = 10
        Me.ButtonRegresar1.Text = "ButtonRegresar1"
        '
        'LabelVentaAnterior
        '
        Me.LabelVentaAnterior.Location = New System.Drawing.Point(8, 209)
        Me.LabelVentaAnterior.Name = "LabelVentaAnterior"
        Me.LabelVentaAnterior.Size = New System.Drawing.Size(88, 16)
        Me.LabelVentaAnterior.Text = "LabelVentaAnterior"
        '
        'LabelPrecio
        '
        Me.LabelPrecio.Location = New System.Drawing.Point(8, 186)
        Me.LabelPrecio.Name = "LabelPrecio"
        Me.LabelPrecio.Size = New System.Drawing.Size(88, 16)
        Me.LabelPrecio.Text = "LabelPrecio"
        '
        'LabelCantidad
        '
        Me.LabelCantidad.Location = New System.Drawing.Point(8, 162)
        Me.LabelCantidad.Name = "LabelCantidad"
        Me.LabelCantidad.Size = New System.Drawing.Size(80, 16)
        Me.LabelCantidad.Text = "LabelCantidad"
        '
        'LabelPresentacion
        '
        Me.LabelPresentacion.Location = New System.Drawing.Point(2, 113)
        Me.LabelPresentacion.Name = "LabelPresentacion"
        Me.LabelPresentacion.Size = New System.Drawing.Size(98, 22)
        Me.LabelPresentacion.Text = "LabelPresentacion"
        '
        'LabelTipo
        '
        Me.LabelTipo.Location = New System.Drawing.Point(8, 66)
        Me.LabelTipo.Name = "LabelTipo"
        Me.LabelTipo.Size = New System.Drawing.Size(92, 24)
        Me.LabelTipo.Text = "LabelTipo"
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(8, 19)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(92, 22)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'TabPageDetalle2
        '
        Me.TabPageDetalle2.Controls.Add(Me.ComboBoxUbicacion)
        Me.TabPageDetalle2.Controls.Add(Me.TextBoxUbicacion)
        Me.TabPageDetalle2.Controls.Add(Me.ComboBoxProveedor)
        Me.TabPageDetalle2.Controls.Add(Me.TextBoxProveedor)
        Me.TabPageDetalle2.Controls.Add(Me.LabelProveedor)
        Me.TabPageDetalle2.Controls.Add(Me.LabelUbicacion)
        Me.TabPageDetalle2.Controls.Add(Me.ButtonContinuar2)
        Me.TabPageDetalle2.Controls.Add(Me.ButtonRegresar2)
        Me.TabPageDetalle2.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle2.Name = "TabPageDetalle2"
        Me.TabPageDetalle2.Size = New System.Drawing.Size(234, 269)
        Me.TabPageDetalle2.Text = "TabPageDetalle2"
        '
        'ComboBoxUbicacion
        '
        Me.ComboBoxUbicacion.Location = New System.Drawing.Point(104, 16)
        Me.ComboBoxUbicacion.Name = "ComboBoxUbicacion"
        Me.ComboBoxUbicacion.Size = New System.Drawing.Size(126, 22)
        Me.ComboBoxUbicacion.TabIndex = 0
        '
        'TextBoxUbicacion
        '
        Me.TextBoxUbicacion.Location = New System.Drawing.Point(104, 39)
        Me.TextBoxUbicacion.Name = "TextBoxUbicacion"
        Me.TextBoxUbicacion.Size = New System.Drawing.Size(126, 21)
        Me.TextBoxUbicacion.TabIndex = 1
        '
        'ComboBoxProveedor
        '
        Me.ComboBoxProveedor.Location = New System.Drawing.Point(104, 64)
        Me.ComboBoxProveedor.Name = "ComboBoxProveedor"
        Me.ComboBoxProveedor.Size = New System.Drawing.Size(126, 22)
        Me.ComboBoxProveedor.TabIndex = 2
        '
        'TextBoxProveedor
        '
        Me.TextBoxProveedor.Location = New System.Drawing.Point(104, 87)
        Me.TextBoxProveedor.MaxLength = 40
        Me.TextBoxProveedor.Name = "TextBoxProveedor"
        Me.TextBoxProveedor.Size = New System.Drawing.Size(126, 21)
        Me.TextBoxProveedor.TabIndex = 3
        '
        'LabelProveedor
        '
        Me.LabelProveedor.Location = New System.Drawing.Point(9, 64)
        Me.LabelProveedor.Name = "LabelProveedor"
        Me.LabelProveedor.Size = New System.Drawing.Size(88, 16)
        Me.LabelProveedor.Text = "LabelProveedor"
        '
        'LabelUbicacion
        '
        Me.LabelUbicacion.Location = New System.Drawing.Point(10, 16)
        Me.LabelUbicacion.Name = "LabelUbicacion"
        Me.LabelUbicacion.Size = New System.Drawing.Size(88, 16)
        Me.LabelUbicacion.Text = "LabelUbicacion"
        '
        'ButtonContinuar2
        '
        Me.ButtonContinuar2.Location = New System.Drawing.Point(83, 231)
        Me.ButtonContinuar2.Name = "ButtonContinuar2"
        Me.ButtonContinuar2.Size = New System.Drawing.Size(70, 24)
        Me.ButtonContinuar2.TabIndex = 6
        Me.ButtonContinuar2.Text = "ButtonContinuar2"
        '
        'ButtonRegresar2
        '
        Me.ButtonRegresar2.Location = New System.Drawing.Point(157, 231)
        Me.ButtonRegresar2.Name = "ButtonRegresar2"
        Me.ButtonRegresar2.Size = New System.Drawing.Size(70, 24)
        Me.ButtonRegresar2.TabIndex = 7
        Me.ButtonRegresar2.Text = "ButtonRegresar2"
        '
        'FormMercadeo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuDia
        Me.MinimizeBox = False
        Me.Name = "FormMercadeo"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlAplicacion.ResumeLayout(False)
        Me.TabPageMercadeo.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.TabPageDetalle2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormMercadeo_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.MenuItemRegresar Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenuDia)
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

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormMenuDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuDia)
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

        If Not Vista.Buscar("FormMercadeo", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        blnSeleccionManual = True

        refaVista.CrearListView(ListViewMenu, "ListViewMercadeo")
        refaVista.PoblarListView(ListViewMenu, oDBVen, "ListViewMercadeo", String.Format(" Where ClienteClave='{0}'", sCte))
        refaVista.ColocarEtiquetasForma(Me)

        eModo = Modo.Vacio
        blnSeleccionManual = False

        With ListViewMenu
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                'Me.ButtonContinuar.Focus()
                Revisar_Accion()
                Me.TabControlAplicacion.SelectedIndex = 1
            End If
        End With

        [Global].HabilitarMenuItem(Me.MainMenuDia, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub LlenaComboTipo()

        Dim arrCon As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("MRDTIPO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrCon.Add(New CConceptos(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("MRDTIPO").Rows
            '    arrCon.Add(New CConceptos(dr(0), dr(1)))
            'Next
            ComboBoxTipo.DataSource = arrCon
            ComboBoxTipo.DisplayMember = "Concepto"
            ComboBoxTipo.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub

    Private Sub LlenaComboPresentacion()

        Dim arrCon As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("MRDPRES")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrCon.Add(New CConceptos(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("MRDPRES").Rows
            '    arrCon.Add(New CConceptos(dr(0), dr(1)))
            'Next
            ComboBoxPresentacion.DataSource = arrCon
            ComboBoxPresentacion.DisplayMember = "Concepto"
            ComboBoxPresentacion.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub


    Private Sub LlenaComboProductos()
        Dim arrCon As New ArrayList
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("Select MPRId, PRoducto from MercadeoProducto", "MercadeoProducto")

        arrCon.Add(New CConceptos("", refaVista.BuscarMensaje("Mensajes", "XNoDefinido")))
        For Each dr As DataRow In Dt.Rows
            arrCon.Add(New CConceptos(dr(0), dr(1)))
        Next
        Dt.Dispose()

        ComboBoxProducto.DataSource = arrCon
        ComboBoxProducto.DisplayMember = "Concepto"
        ComboBoxProducto.ValueMember = "Valor"
    End Sub

    Private Sub LlenaComboProveedor()
        Dim arrCon As New ArrayList
        arrCon.Add(New CConceptos("", refaVista.BuscarMensaje("Mensajes", "XNoDefinido")))

        Dim Dt As DataTable = odbVen.RealizarConsultaSQL("Select MEPId, Proveedor from MercadeoProveedor", "MercadeoProducto")
        For Each dr As DataRow In Dt.Rows
            arrCon.Add(New CConceptos(dr(0), dr(1)))
        Next
        Dt.Dispose()

        ComboBoxProveedor.DataSource = arrCon
        ComboBoxProveedor.DisplayMember = "Concepto"
        ComboBoxProveedor.ValueMember = "Valor"
    End Sub

    Private Sub LlenaComboUbicacion()
        Dim arrCon As New ArrayList
        'arrCon.Add(New CConceptos("", refaVista.BuscarMensaje("Mensajes", "XNoDefinido")))
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("MRDUBICA")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrCon.Add(New CConceptos(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("MRDUBICA").Rows
            '    arrCon.Add(New CConceptos(dr(0), dr(1)))
            'Next
            ComboBoxUbicacion.DataSource = arrCon
            ComboBoxUbicacion.DisplayMember = "Concepto"
            ComboBoxUbicacion.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click

        OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        Close()

    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click

        Revisar_Accion()
        Me.TabControlAplicacion.SelectedIndex = 1

    End Sub

    Public Sub Revisar_Accion()



        If Not RevisarElementoMarcado(ListViewMenu) Then
            eModo = Modo.Crear
        Else
            eModo = Modo.Modificar
            strKeyActual = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(4).Text
            strDetKeyActual = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(5).Text
        End If

    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Not bHuboCambios Then
            Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
            Me.Close()
            Exit Sub
        End If

        If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
            Me.Close()
        End If
    End Sub


    Private Sub TabControlAplicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlAplicacion.SelectedIndexChanged


        If eModo <> Modo.Cancelar Then
            Revisar_Accion()
        End If

        If TabControlAplicacion.SelectedIndex = 0 Then

            If bHuboCambios Then
                If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                    bContinuar = False
                    Me.TabControlAplicacion.SelectedIndex = iTabSeleccionado
                    Exit Sub
                End If
            End If

            bEditando = False

            With ListViewMenu
                If .Items.Count > 0 Then
                    .Items(0).Selected = True
                    .Focus()
                Else
                    Me.ButtonContinuar.Focus()
                End If
            End With

        End If

        If bContinuar Then
            If TabControlAplicacion.SelectedIndex = 1 And Not Regresando And Not bEditando Then

                bCargado = True
                LlenaComboTipo()
                LlenaComboPresentacion()
                LlenaComboProductos()
                LlenaComboProveedor()
                LlenaComboUbicacion()
                bCargado = False

                If eModo = Modo.Crear Then

                    Limpiar_Campos()
                    Activar_Campos(True)

                ElseIf eModo = Modo.Modificar Then
                    Buscar_MercadeoProducto(strKeyActual)
                    Activar_Modificar()

                ElseIf eModo = Modo.Cancelar Then

                    Buscar_MercadeoProducto(strKeyActual)
                    Activar_Campos(False)
                    Me.TextBoxPresetacion.Enabled = False
                End If
                ComboBoxProducto.Focus()
                bHuboCambios = False
                bEditando = True

            End If
        End If

        Select Case Me.TabControlAplicacion.SelectedIndex
            'Case 0
            Case 1 : Me.ComboBoxProducto.Focus()
            Case 2 : ComboBoxUbicacion.Focus()
        End Select

        iTabSeleccionado = Me.TabControlAplicacion.SelectedIndex
        bContinuar = True
    End Sub


    Public Sub Activar_Campos(ByVal Activo As Boolean, Optional ByVal Desactivar_Botones As Boolean = True)

        ComboBoxProveedor.Enabled = Activo
        TextBoxProveedor.Enabled = Activo
        ComboBoxProducto.Enabled = Activo
        ComboBoxTipo.Enabled = Activo
        ComboBoxPresentacion.Enabled = Activo
        ComboBoxUbicacion.Enabled = Activo
        TextBoxCantidad.Enabled = Activo
        TextBoxPrecio.Enabled = Activo
        TextBoxCantidad.Enabled = Activo
        TextBoxVentaAnterior.Enabled = Activo
        TextBoxPresetacion.Enabled = Activo
        TextBoxTipo.Enabled = Activo

    End Sub

    Public Sub Activar_Modificar()

        ComboBoxProducto.Enabled = False
        ComboBoxTipo.Enabled = False
        ComboBoxPresentacion.Enabled = False
        TextBoxPresetacion.Enabled = False

        ComboBoxUbicacion.Enabled = True
        ComboBoxProveedor.Enabled = True

        TextBoxTipo.Enabled = False
        TextBoxProveedor.Enabled = True
        TextBoxUbicacion.Enabled = True
        ComboBoxUbicacion.Enabled = True

        TextBoxCantidad.Enabled = True
        TextBoxPrecio.Enabled = True
        TextBoxCantidad.Enabled = True
        TextBoxVentaAnterior.Enabled = True

    End Sub

    Public Sub Buscar_MercadeoProducto(ByVal strMPRID As String)

        Dim strQuery As String
        Dim dt As DataTable

        strQuery = "Select MercadeoProducto.MPRId,Mercadeo.MEPId,MercadeoProducto.Producto,MerDetalle.Cantidad, MerDetalle.Tipo, MerDetalle.Tipo2, MerDetalle.Tipo, MerDetalle.Presentacion, MerDetalle.Presentacion2,Precio, Cantidad,VentaAnterior,Ubicacion,Ubicacion2,MercadeoProveedor.Proveedor from Mercadeo inner join MerDetalle on Mercadeo.MerId=MerDetalle.MerId inner join MercadeoProducto on MercadeoProducto.MPRId=Mercadeo.MPRId inner join MercadeoProveedor on MercadeoProveedor.MEPId=Mercadeo.MEPId Where MerDetalle.MRDId='" & strDetKeyActual & "'"

        dt = odbVen.RealizarConsultaSQL(strQuery, "MercadeoProducto")

        If dt.Rows.Count > 0 Then

            Me.bCargado = True

            Me.TextBoxCantidad.Text = dt.Rows(0).Item("Cantidad")
            Me.TextBoxPrecio.Text = dt.Rows(0).Item("Precio")

            If dt.Rows(0).Item("Presentacion") = 0 Then

                SeleccionarValorCombo(ComboBoxPresentacion, dt.Rows(0).Item("Presentacion"))
                Me.TextBoxPresetacion.Text = dt.Rows(0).Item("Presentacion2")
                ComboBoxPresentacion.Enabled = False
                TextBoxProducto.Enabled = True
            Else
                SeleccionarValorCombo(ComboBoxPresentacion, dt.Rows(0).Item("Presentacion"))
                ComboBoxPresentacion.Enabled = True
                TextBoxProducto.Enabled = False
            End If

            If dt.Rows(0).Item("Tipo") = 0 Then
                SeleccionarValorCombo(ComboBoxTipo, dt.Rows(0).Item("Tipo"))
                Me.TextBoxTipo.Text = dt.Rows(0).Item("Tipo2")
                ComboBoxTipo.Enabled = False
                TextBoxPrecio.Enabled = True
            Else
                SeleccionarValorCombo(ComboBoxTipo, dt.Rows(0).Item("Tipo"))
                ComboBoxTipo.Enabled = True
                TextBoxPrecio.Enabled = False
            End If

            Me.TextBoxVentaAnterior.Text = dt.Rows(0).Item("VentaAnterior")
            Me.TextBoxPrecio.Text = dt.Rows(0).Item("Precio")



            SeleccionarValorCombo(ComboBoxProducto, dt.Rows(0).Item("MPRId"))

            If Me.ComboBoxProducto.SelectedIndex = -1 Then
                Me.TextBoxProducto.Enabled = True
                Me.TextBoxProveedor.Text = dt.Rows(0).Item("Proveedor")
            Else
                ComboBoxProducto.Enabled = True
                TextBoxProducto.Enabled = False
            End If

            SeleccionarValorCombo(ComboBoxProveedor, dt.Rows(0).Item("MEPId"))

            If Me.ComboBoxProveedor.SelectedIndex = -1 Then
                Me.TextBoxProveedor.Enabled = True
            Else
                ComboBoxProveedor.Enabled = False
                Me.TextBoxProveedor.Enabled = False
            End If

            If dt.Rows(0).Item("Ubicacion") = 0 Then

                SeleccionarValorCombo(ComboBoxUbicacion, dt.Rows(0).Item("Ubicacion"))
                Me.TextBoxUbicacion.Text = dt.Rows(0).Item("Ubicacion2")
                ComboBoxUbicacion.Enabled = False
                TextBoxUbicacion.Enabled = True
            Else
                SeleccionarValorCombo(ComboBoxUbicacion, dt.Rows(0).Item("Ubicacion"))
                ComboBoxUbicacion.Enabled = True
                TextBoxUbicacion.Enabled = False
            End If

            Me.bCargado = False
        End If

        dt.Dispose()
    End Sub


    Public Sub Limpiar_Campos()

        TextBoxCantidad.Text = 0
        TextBoxPrecio.Text = 0
        TextBoxPresetacion.Text = ""
        TextBoxVentaAnterior.Text = 0
        TextBoxProveedor.Text = ""
        TextBoxTipo.Text = ""
        TextBoxProducto.Text = ""
        TextBoxUbicacion.Text = ""

        If ComboBoxPresentacion.Items.Count > 0 Then Me.ComboBoxPresentacion.SelectedValue = "0"
        If ComboBoxProducto.Items.Count > 0 Then Me.ComboBoxProducto.SelectedValue = ""
        If ComboBoxTipo.Items.Count > 0 Then Me.ComboBoxTipo.SelectedValue = "0"
        If ComboBoxUbicacion.Items.Count > 0 Then Me.ComboBoxUbicacion.SelectedValue = "0"
    End Sub

    Private Sub ButtonContinuar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar1.Click

        Me.TabControlAplicacion.SelectedIndex = 2

    End Sub

    Public Function Actualiza_Mercadeo() As Boolean

        Try

            Dim strSQL1 As New System.Text.StringBuilder
            Dim strSQL2 As New System.Text.StringBuilder
            Dim iProvKey As String
            If odbVen.oConexion.State = ConnectionState.Closed Then
                odbVen.oConexion.Open()
            End If
            Transaccion = odbVen.oConexion.BeginTransaction()


            'Aqui debe de validar que no agrege mas bien el mismo

            If ComboBoxProveedor.SelectedIndex = -1 OrElse Me.ComboBoxProveedor.SelectedValue = String.Empty Then

                iProvKey = oApp.KEYGEN(100)

                Dim sInsertar As String = String.Format("Insert into MercadeoProveedor(MEPId, Proveedor,Estado, MFechaHora, MUsuarioID,Enviado)" & _
                               " values('{0}','{1}',1 {2},{3})", iProvKey, Me.TextBoxProveedor.Text, strEstatusModificado, 0)
                oDBVen.EjecutarComandoSQL(sInsertar)
            Else
                iProvKey = ComboBoxProveedor.SelectedValue()
            End If


            With strSQL1

                .Append("Update Mercadeo ")
                .Append("SET MEPId='" & iProvKey & "'")
                .Append(",MFechaHora=" & UniFechaSQL(Now))
                .Append(",MUsuarioID='" & oVendedor.UsuarioId & "'")
                .Append(",Enviado=0 ")
                .Append(" Where MerId='" & strKeyActual & "'")

            End With

            odbVen.EjecutarComandoSQL(strSQL1.ToString)
            '//Eliminar todos los abonos para volverlos a crear            

            With strSQL2

                .Append("Update MerDetalle ")
                .Append("SET Tipo=" & ComboBoxTipo.SelectedValue)
                .Append(",Tipo2='" & TextBoxTipo.Text & "'")
                .Append(",Presentacion=" & ComboBoxPresentacion.SelectedValue)
                .Append(",Presentacion2='" & TextBoxPresetacion.Text & "'")
                .Append(",Ubicacion=" & Me.ComboBoxUbicacion.SelectedValue)
                .Append(",Ubicacion2='" & Me.TextBoxUbicacion.Text & "'")
                .Append(",Cantidad=" & TextBoxCantidad.Text)
                .Append(",Precio=" & TextBoxPrecio.Text)
                .Append(",VentaAnterior=" & TextBoxVentaAnterior.Text)
                .Append(",MFechaHora=" & UniFechaSQL(Now))
                .Append(",MUsuarioID='" & oVendedor.UsuarioId & "'")
                .Append(",Enviado=0 ")
                .Append(" Where MRDId='" & strDetKeyActual & "'")

            End With



            odbVen.EjecutarComandoSQL(strSQL2.ToString)

            '//Guardar la información del detalle del importe AbonoDeposito


            '//Actualizar el Saldo del ABONO

            Transaccion.Commit()
            Transaccion.Dispose()
            Transaccion = Nothing
        Catch ex As SqlServerCe.SqlCeException
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing

            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function Elimina_Mercadeo() As Boolean

        Try
            If odbVen.oConexion.State = ConnectionState.Closed Then
                odbVen.oConexion.Open()
            End If
            Transaccion = odbVen.oConexion.BeginTransaction()
            '//Grabar la información del Deposito en Deposito
            Dim strSQL As New System.Text.StringBuilder
            Dim strSQL1 As New System.Text.StringBuilder
            Dim strSQL2 As New System.Text.StringBuilder

            Dim iAbnID As String = String.Empty
            Dim iAbnDetID As String = String.Empty
            Dim dblImporte As Decimal = 0

            '//Guardar la información del detalle del importe AbonoDeposito


            With strSQL2

                .Append("Delete from MerCli")
                .Append(" Where MerId='" & strKeyActual & "'")

            End With

            odbVen.EjecutarComandoSQL(strSQL2.ToString)


            With strSQL
                .Append("Delete from Mercadeo where MerId='")
                .Append(Me.strKeyActual & "'")
            End With

            odbVen.EjecutarComandoSQL(strSQL.ToString)



            With strSQL1
                .Append("Delete from MerDetalle where MRDId='")
                .Append(Me.strDetKeyActual & "'")
            End With

            odbVen.EjecutarComandoSQL(strSQL1.ToString)

            Transaccion.Commit()
            Transaccion.Dispose()
            Transaccion = Nothing

        Catch ex As SqlServerCe.SqlCeException
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing

            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing

            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function Agregar_Mercadeo() As Boolean

        Try
            '//Grabar la información del Deposito en Deposito
            If odbVen.oConexion.State = ConnectionState.Closed Then
                odbVen.oConexion.Open()
            End If
            Transaccion = odbVen.oConexion.BeginTransaction()

            Dim strSQL1 As New System.Text.StringBuilder
            Dim strSQL2 As New System.Text.StringBuilder
            Dim strSQL3 As New System.Text.StringBuilder
            Dim iDetKey As String
            Dim iMerKey As String
            Dim iProdKey As String
            Dim iProvKey As String
            Dim strSQL As String

            Dim dblImporte As Decimal = 0


            If ComboBoxProducto.SelectedIndex = -1 OrElse ComboBoxProducto.SelectedValue = String.Empty Then

                iProdKey = oApp.KEYGEN(200)

                strSQL = "Insert into MercadeoProducto (MPRId, PRoducto,Estado,MFechaHora, MUsuarioId,Enviado)" & _
                               " values('" & iProdKey & "','" & Me.TextBoxProducto.Text & "',1" & strEstatusModificado & ",0)"

                oDBVen.EjecutarComandoSQL(strSQL)

            Else

                iProdKey = ComboBoxProducto.SelectedValue

            End If


            If ComboBoxProveedor.SelectedIndex = -1 OrElse ComboBoxProveedor.SelectedValue = String.Empty Then

                iProvKey = oApp.KEYGEN(100)

                strSQL = "Insert into MercadeoProveedor(MEPId, Proveedor,Estado, MFechaHora,MUsuarioId,Enviado)" & _
                               " values('" & iProvKey & "','" & Me.TextBoxProveedor.Text & "',1" & strEstatusModificado & ",0)"
                odbVen.EjecutarComandoSQL(strSQL)
            Else
                iProvKey = ComboBoxProveedor.SelectedValue()
            End If

            iMerKey = oApp.KEYGEN(100)

            With strSQL1

                .Append("Insert into Mercadeo")
                .Append("(MERId,MPRId,MEPId, MFechaHora,MUsuarioID)")
                .Append(" Values('" & iMerKey & "',")
                .Append("'" & iProdKey & "'")
                .Append(",'" & iProvKey & "'")
                .Append(strEstatusModificado & ")")

            End With

            odbVen.EjecutarComandoSQL(strSQL1.ToString)

            iDetKey = oApp.KEYGEN(200)


            With strSQL3

                .Append("Insert into MerCli")
                .Append("(MERId, ClienteClave, MFechaHora,MUsuarioID)")
                .Append(" Values('" & iMerKey & "',")
                .Append("'" & sCte & "'")
                .Append(strEstatusModificado & ")")

            End With

            odbVen.EjecutarComandoSQL(strSQL3.ToString)


            With strSQL2

                .Append("Insert into MerDetalle ")
                .Append("(MERId,MRDId, DiaClave, VisitaClave, Tipo, Tipo2, Presentacion, Presentacion2, Ubicacion, Ubicacion2, VentaAnterior, Cantidad, Precio, MFechaHora, MUsuarioID)")
                .Append(" Values('" & iMerKey & "',")
                .Append("'" & iDetKey & "'")
                .Append(",'" & oDia.DiaActual & "'")
                .Append(",'" & sVisitaClave & "'")
                .Append("," & IIf(IsNothing(ComboBoxTipo.SelectedValue), 0, ComboBoxTipo.SelectedValue))
                .Append(",'" & TextBoxTipo.Text & "'")
                .Append("," & IIf(IsNothing(ComboBoxPresentacion.SelectedValue), 0, ComboBoxPresentacion.SelectedValue))
                .Append(",'" & TextBoxPresetacion.Text & "',")
                .Append(CInt(IIf(Trim(ComboBoxUbicacion.SelectedValue) = String.Empty, 0, ComboBoxUbicacion.SelectedValue)) & ",")
                .Append("'" & TextBoxUbicacion.Text & "',")
                .Append(TextBoxVentaAnterior.Text & ",")
                .Append(CInt(TextBoxCantidad.Text) & ",")
                .Append(CDbl(TextBoxPrecio.Text))
                .Append(strEstatusModificado & ")")

            End With

            odbVen.EjecutarComandoSQL(strSQL2.ToString)

            Transaccion.Commit()
            Transaccion.Dispose()
            Transaccion = Nothing


        Catch ex As SqlServerCe.SqlCeException
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing

            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing

            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Private Sub ButtonRegresar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar1.Click
        If Not bHuboCambios Then
            'Me.TabControlAplicacion.SelectedIndex = 0
            'eModo = Modo.Vacio
            Me.Close()
            Exit Sub
        End If

        If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            'Me.TabControlAplicacion.SelectedIndex = 0
            'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewMercadeo", String.Format(" Where ClienteClave='{0}'", sCte))
            'bHuboCambios = False
            'eModo = Modo.Vacio
            Me.Close()
        End If
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

        If Not ComboValido(ComboBoxProducto, TextBoxProducto) Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelProducto.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 1
            If ComboBoxProducto.SelectedValue Is Nothing Then
                ComboBoxProducto.Focus()
            Else
                TextBoxProducto.Focus()
            End If
            Return False

        ElseIf Not ComboValido(ComboBoxTipo, TextBoxTipo) Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelTipo.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 1
            If ComboBoxTipo.SelectedValue Is Nothing Then
                ComboBoxTipo.Focus()
            Else
                TextBoxTipo.Focus()
            End If
            Return False

        ElseIf Not ComboValido(ComboBoxPresentacion, TextBoxPresetacion) Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelPresentacion.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 1
            ComboBoxPresentacion.Focus()
            Return False


        ElseIf Not IsNumeric(TextBoxCantidad.Text) OrElse TextBoxCantidad.Text < 0 Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "E0336"), LabelCantidad.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 1
            TextBoxCantidad.Focus()
            Return False


        ElseIf Not IsNumeric(TextBoxPrecio.Text) OrElse CInt(TextBoxPrecio.Text) < 0 Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "E0336"), LabelPrecio.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 1
            TextBoxPrecio.Focus()
            Return False

        ElseIf Not IsNumeric(TextBoxVentaAnterior.Text) OrElse CInt(TextBoxVentaAnterior.Text) < 0 Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "E0336"), LabelVentaAnterior.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 1
            TextBoxVentaAnterior.Focus()
            Return False

        ElseIf Not ComboValido(ComboBoxUbicacion, TextBoxUbicacion) Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelUbicacion.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 2
            ComboBoxUbicacion.Focus()
            Return False

        ElseIf Not ComboValido(ComboBoxProveedor, TextBoxProveedor) Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelProveedor.Text), MsgBoxStyle.Information, "Amesol Route")
            TabControlAplicacion.SelectedIndex = 2
            ComboBoxProveedor.Focus()
            Return False

        End If



        Return True
    End Function
    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

        If RevisarElementoMarcado2(ListViewMenu) Then


            eModo = Modo.Cancelar
            strKeyActual = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(4).Text
            strDetKeyActual = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(5).Text

            Me.TabControlAplicacion.SelectedIndex = 1

        Else

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information, "Amesol Route")


        End If

    End Sub

    Private Sub TabPageDetalle_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageDetalle.EnabledChanged

    End Sub

    Friend Class CConceptos
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

    Private Sub ComboBoxProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProducto.SelectedIndexChanged

        HabilitarCombo(ComboBoxProducto, TextBoxProducto)

    End Sub

    Public Sub HabilitarCombo(ByRef ComboBox As ComboBox, ByRef TextBox As TextBox)

        If bCargado Then Exit Sub

        bHuboCambios = True

        If ComboBox.SelectedIndex = -1 Or ComboBox.SelectedValue = "0" Or ComboBox.Text.Trim = String.Empty Or ComboBox.SelectedValue = String.Empty Then
            TextBox.Text = ""
            TextBox.Enabled = True
        Else
            TextBox.Text = ""
            TextBox.Enabled = False
        End If


    End Sub

    Public Sub SeleccionarValorCombo(ByRef ComboBox As ComboBox, ByVal Valor As String)

        Dim item As CConceptos

        For cont As Integer = 0 To ComboBox.Items.Count - 1

            item = ComboBox.Items(cont)
            If item.Valor = Valor Then
                ComboBox.SelectedIndex = cont
            End If
        Next
    End Sub


    Public Function ComboValido(ByRef ComboBox As ComboBox, ByRef TextBox As TextBox) As Boolean
        If ComboBox.SelectedValue Is Nothing Then
            Return False
        End If

        If ComboBox.SelectedIndex = -1 And TextBox.Text = "" Then
            Return False
        ElseIf (ComboBox.SelectedValue = "0" Or ComboBox.SelectedValue = "") And TextBox.Text = "" Then
            Return False
        End If

        Return True
    End Function

    Private Sub ComboBoxTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTipo.SelectedIndexChanged
        HabilitarCombo(ComboBoxTipo, TextBoxTipo)
    End Sub

    Private Sub ComboBoxPresentacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPresentacion.SelectedIndexChanged
        HabilitarCombo(ComboBoxPresentacion, TextBoxPresetacion)
    End Sub

    Private Sub ComboBoxUbicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxUbicacion.SelectedIndexChanged
        HabilitarCombo(ComboBoxUbicacion, TextBoxUbicacion)
    End Sub

    Private Sub ComboBoxProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProveedor.SelectedIndexChanged
        HabilitarCombo(ComboBoxProveedor, TextBoxProveedor)
    End Sub

    Private Sub TextBoxProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ComboBoxProveedor.Enabled = False
        ComboBoxProveedor.SelectedValue = " "
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar2.Click

        If eModo = Modo.Cancelar OrElse ValidaCampos() Then

            Select Case eModo
                Case Modo.Crear

                    If Agregar_Mercadeo() Then
                        Me.Close()
                    End If
                    'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewMercadeo", String.Format(" Where ClienteClave='{0}'", sCte))
                    'TabControlAplicacion.SelectedIndex = 0
                    'eModo = Modo.Vacio

                Case Modo.Modificar

                    If Actualiza_Mercadeo() Then
                        Me.Close()
                    End If
                    'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewMercadeo", String.Format(" Where ClienteClave='{0}'", sCte))
                    'TabControlAplicacion.SelectedIndex = 0
                    'eModo = Modo.Vacio

                Case Modo.Cancelar

                    If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0001"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If Elimina_Mercadeo() Then
                            Me.Close()
                        End If
                    End If

                    'refaVista.PoblarListView(ListViewMenu, odbVen, "ListViewMercadeo", String.Format(" Where ClienteClave='{0}'", sCte))
                    'TabControlAplicacion.SelectedIndex = 0
                    'eModo = Modo.Vacio

            End Select

            'Me.Limpiar_Campos()

        End If

    End Sub

    Private Sub ButtonRegresar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar2.Click

        Regresando = True
        Me.TabControlAplicacion.SelectedIndex = 1
        Regresando = False

    End Sub

    Private Sub TextBoxTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    TextBoxTipo.TextChanged, TextBoxVentaAnterior.TextChanged, TextBoxUbicacion.TextChanged, _
    TextBoxCantidad.TextChanged, TextBoxPresetacion.TextChanged
        bHuboCambios = True
    End Sub

    Private Sub TextBoxProducto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxProducto.TextChanged
        bHuboCambios = True
        Me.ComboBoxProducto.Enabled = (TextBoxProducto.Text = "")
    End Sub

    Private Sub TextBoxProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxProveedor.TextChanged
        bHuboCambios = True
        Me.ComboBoxProveedor.Enabled = (TextBoxProveedor.Text = "")
    End Sub
End Class


