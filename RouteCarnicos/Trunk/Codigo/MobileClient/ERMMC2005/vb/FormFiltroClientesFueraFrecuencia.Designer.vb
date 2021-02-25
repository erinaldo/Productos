<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormFiltroClientesFueraFrecuencia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If

        If Not IsNothing(FlexGridClientes) Then
            FlexGridClientes.Dispose()
            FlexGridClientes = Nothing
        End If

        ClienteActual = Nothing

        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuAgenda) Then MainMenuAgenda.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MainMenuAgenda As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelAgenda As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelContrasena As System.Windows.Forms.Panel
    Friend WithEvents LabelContrasena As System.Windows.Forms.Label
    Friend WithEvents ButtonCancelarContrasena As System.Windows.Forms.Button
    Friend WithEvents ButtonAceptarContrasena As System.Windows.Forms.Button
    Friend WithEvents textContrasena As System.Windows.Forms.TextBox
    Friend WithEvents LabelTiempo As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFiltroClientesFueraFrecuencia))
        Me.MainMenuAgenda = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.InputPanelAgenda = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlClientesFueraFrecuencia = New System.Windows.Forms.TabControl
        Me.TabPageFiltro = New System.Windows.Forms.TabPage
        Me.ButtonFiltroContinuar = New System.Windows.Forms.Button
        Me.ButtonFiltroRegresar = New System.Windows.Forms.Button
        Me.TextBoxRazonSocial = New System.Windows.Forms.TextBox
        Me.ComboBoxComparaRazonSocial = New System.Windows.Forms.ComboBox
        Me.CheckBoxRazonSocial = New System.Windows.Forms.CheckBox
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox
        Me.ComboBoxComparaDom = New System.Windows.Forms.ComboBox
        Me.CheckBoxDomicilio = New System.Windows.Forms.CheckBox
        Me.TextBoxNombre = New System.Windows.Forms.TextBox
        Me.ComboBoxComparaNombre = New System.Windows.Forms.ComboBox
        Me.CheckBoxNombre = New System.Windows.Forms.CheckBox
        Me.TextBoxClave = New System.Windows.Forms.TextBox
        Me.ComboBoxComparaClave = New System.Windows.Forms.ComboBox
        Me.CheckBoxClave = New System.Windows.Forms.CheckBox
        Me.TabPageCliente = New System.Windows.Forms.TabPage
        Me.txtPatron = New System.Windows.Forms.TextBox
        Me.LabelAgenda = New System.Windows.Forms.Label
        Me.FlexGridClientes = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonAgendaContinuar = New System.Windows.Forms.Button
        Me.ButtonAgendaRegresar = New System.Windows.Forms.Button
        Me.LabelTiempo = New System.Windows.Forms.Label
        Me.PanelContrasena = New System.Windows.Forms.Panel
        Me.ButtonCancelarContrasena = New System.Windows.Forms.Button
        Me.ButtonAceptarContrasena = New System.Windows.Forms.Button
        Me.textContrasena = New System.Windows.Forms.TextBox
        Me.LabelContrasena = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControlClientesFueraFrecuencia.SuspendLayout()
        Me.TabPageFiltro.SuspendLayout()
        Me.TabPageCliente.SuspendLayout()
        Me.PanelContrasena.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuAgenda
        '
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlClientesFueraFrecuencia)
        Me.Panel1.Controls.Add(Me.LabelTiempo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlClientesFueraFrecuencia
        '
        Me.TabControlClientesFueraFrecuencia.Controls.Add(Me.TabPageFiltro)
        Me.TabControlClientesFueraFrecuencia.Controls.Add(Me.TabPageCliente)
        Me.TabControlClientesFueraFrecuencia.Location = New System.Drawing.Point(0, 0)
        Me.TabControlClientesFueraFrecuencia.Name = "TabControlClientesFueraFrecuencia"
        Me.TabControlClientesFueraFrecuencia.SelectedIndex = 0
        Me.TabControlClientesFueraFrecuencia.Size = New System.Drawing.Size(242, 295)
        Me.TabControlClientesFueraFrecuencia.TabIndex = 32
        '
        'TabPageFiltro
        '
        Me.TabPageFiltro.Controls.Add(Me.ButtonFiltroContinuar)
        Me.TabPageFiltro.Controls.Add(Me.ButtonFiltroRegresar)
        Me.TabPageFiltro.Controls.Add(Me.TextBoxRazonSocial)
        Me.TabPageFiltro.Controls.Add(Me.ComboBoxComparaRazonSocial)
        Me.TabPageFiltro.Controls.Add(Me.CheckBoxRazonSocial)
        Me.TabPageFiltro.Controls.Add(Me.TextBoxDomicilio)
        Me.TabPageFiltro.Controls.Add(Me.ComboBoxComparaDom)
        Me.TabPageFiltro.Controls.Add(Me.CheckBoxDomicilio)
        Me.TabPageFiltro.Controls.Add(Me.TextBoxNombre)
        Me.TabPageFiltro.Controls.Add(Me.ComboBoxComparaNombre)
        Me.TabPageFiltro.Controls.Add(Me.CheckBoxNombre)
        Me.TabPageFiltro.Controls.Add(Me.TextBoxClave)
        Me.TabPageFiltro.Controls.Add(Me.ComboBoxComparaClave)
        Me.TabPageFiltro.Controls.Add(Me.CheckBoxClave)
        Me.TabPageFiltro.Location = New System.Drawing.Point(0, 0)
        Me.TabPageFiltro.Name = "TabPageFiltro"
        Me.TabPageFiltro.Size = New System.Drawing.Size(242, 272)
        Me.TabPageFiltro.Text = "TabPageFiltro"
        '
        'ButtonFiltroContinuar
        '
        Me.ButtonFiltroContinuar.Location = New System.Drawing.Point(4, 227)
        Me.ButtonFiltroContinuar.Name = "ButtonFiltroContinuar"
        Me.ButtonFiltroContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonFiltroContinuar.TabIndex = 29
        Me.ButtonFiltroContinuar.Text = "ButtonFiltroContinuar"
        '
        'ButtonFiltroRegresar
        '
        Me.ButtonFiltroRegresar.Location = New System.Drawing.Point(82, 227)
        Me.ButtonFiltroRegresar.Name = "ButtonFiltroRegresar"
        Me.ButtonFiltroRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonFiltroRegresar.TabIndex = 30
        Me.ButtonFiltroRegresar.Text = "ButtonFiltroRegresar"
        '
        'TextBoxRazonSocial
        '
        Me.TextBoxRazonSocial.Enabled = False
        Me.TextBoxRazonSocial.Location = New System.Drawing.Point(100, 86)
        Me.TextBoxRazonSocial.Name = "TextBoxRazonSocial"
        Me.TextBoxRazonSocial.Size = New System.Drawing.Size(131, 21)
        Me.TextBoxRazonSocial.TabIndex = 18
        '
        'ComboBoxComparaRazonSocial
        '
        Me.ComboBoxComparaRazonSocial.Enabled = False
        Me.ComboBoxComparaRazonSocial.Location = New System.Drawing.Point(100, 61)
        Me.ComboBoxComparaRazonSocial.Name = "ComboBoxComparaRazonSocial"
        Me.ComboBoxComparaRazonSocial.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaRazonSocial.TabIndex = 19
        '
        'CheckBoxRazonSocial
        '
        Me.CheckBoxRazonSocial.Location = New System.Drawing.Point(1, 61)
        Me.CheckBoxRazonSocial.Name = "CheckBoxRazonSocial"
        Me.CheckBoxRazonSocial.Size = New System.Drawing.Size(101, 20)
        Me.CheckBoxRazonSocial.TabIndex = 20
        Me.CheckBoxRazonSocial.Text = "CheckBoxRazonSocial"
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(100, 189)
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(131, 21)
        Me.TextBoxDomicilio.TabIndex = 9
        '
        'ComboBoxComparaDom
        '
        Me.ComboBoxComparaDom.Enabled = False
        Me.ComboBoxComparaDom.Location = New System.Drawing.Point(100, 163)
        Me.ComboBoxComparaDom.Name = "ComboBoxComparaDom"
        Me.ComboBoxComparaDom.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaDom.TabIndex = 10
        '
        'CheckBoxDomicilio
        '
        Me.CheckBoxDomicilio.Location = New System.Drawing.Point(1, 163)
        Me.CheckBoxDomicilio.Name = "CheckBoxDomicilio"
        Me.CheckBoxDomicilio.Size = New System.Drawing.Size(101, 20)
        Me.CheckBoxDomicilio.TabIndex = 11
        Me.CheckBoxDomicilio.Text = "CheckBoxDomicilio"
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Enabled = False
        Me.TextBoxNombre.Location = New System.Drawing.Point(100, 137)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(131, 21)
        Me.TextBoxNombre.TabIndex = 12
        '
        'ComboBoxComparaNombre
        '
        Me.ComboBoxComparaNombre.Enabled = False
        Me.ComboBoxComparaNombre.Location = New System.Drawing.Point(100, 111)
        Me.ComboBoxComparaNombre.Name = "ComboBoxComparaNombre"
        Me.ComboBoxComparaNombre.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaNombre.TabIndex = 13
        '
        'CheckBoxNombre
        '
        Me.CheckBoxNombre.Location = New System.Drawing.Point(1, 111)
        Me.CheckBoxNombre.Name = "CheckBoxNombre"
        Me.CheckBoxNombre.Size = New System.Drawing.Size(101, 20)
        Me.CheckBoxNombre.TabIndex = 14
        Me.CheckBoxNombre.Text = "CheckBoxNombre"
        '
        'TextBoxClave
        '
        Me.TextBoxClave.Enabled = False
        Me.TextBoxClave.Location = New System.Drawing.Point(100, 37)
        Me.TextBoxClave.Name = "TextBoxClave"
        Me.TextBoxClave.Size = New System.Drawing.Size(131, 21)
        Me.TextBoxClave.TabIndex = 15
        '
        'ComboBoxComparaClave
        '
        Me.ComboBoxComparaClave.Enabled = False
        Me.ComboBoxComparaClave.Location = New System.Drawing.Point(100, 12)
        Me.ComboBoxComparaClave.Name = "ComboBoxComparaClave"
        Me.ComboBoxComparaClave.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaClave.TabIndex = 16
        '
        'CheckBoxClave
        '
        Me.CheckBoxClave.Location = New System.Drawing.Point(1, 12)
        Me.CheckBoxClave.Name = "CheckBoxClave"
        Me.CheckBoxClave.Size = New System.Drawing.Size(101, 20)
        Me.CheckBoxClave.TabIndex = 17
        Me.CheckBoxClave.Text = "CheckBoxClave"
        '
        'TabPageCliente
        '
        Me.TabPageCliente.Controls.Add(Me.txtPatron)
        Me.TabPageCliente.Controls.Add(Me.LabelAgenda)
        Me.TabPageCliente.Controls.Add(Me.FlexGridClientes)
        Me.TabPageCliente.Controls.Add(Me.ButtonAgendaContinuar)
        Me.TabPageCliente.Controls.Add(Me.ButtonAgendaRegresar)
        Me.TabPageCliente.Location = New System.Drawing.Point(0, 0)
        Me.TabPageCliente.Name = "TabPageCliente"
        Me.TabPageCliente.Size = New System.Drawing.Size(234, 269)
        Me.TabPageCliente.Text = "TabPageCliente"
        '
        'txtPatron
        '
        Me.txtPatron.Enabled = False
        Me.txtPatron.Location = New System.Drawing.Point(4, 22)
        Me.txtPatron.Name = "txtPatron"
        Me.txtPatron.Size = New System.Drawing.Size(228, 21)
        Me.txtPatron.TabIndex = 30
        '
        'LabelAgenda
        '
        Me.LabelAgenda.Location = New System.Drawing.Point(4, 4)
        Me.LabelAgenda.Name = "LabelAgenda"
        Me.LabelAgenda.Size = New System.Drawing.Size(177, 18)
        Me.LabelAgenda.Text = "LabelAgenda"
        '
        'FlexGridClientes
        '
        Me.FlexGridClientes.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridClientes.AllowEditing = True
        Me.FlexGridClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlexGridClientes.AutoResize = True
        Me.FlexGridClientes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.FlexGridClientes.AutoSearchDelay = 2
        Me.FlexGridClientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridClientes.Clip = ""
        Me.FlexGridClientes.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridClientes.Col = 1
        Me.FlexGridClientes.ColSel = 1
        Me.FlexGridClientes.ComboList = Nothing
        Me.FlexGridClientes.EditMask = Nothing
        Me.FlexGridClientes.ExtendLastCol = False
        Me.FlexGridClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridClientes.LeftCol = 1
        Me.FlexGridClientes.Location = New System.Drawing.Point(4, 44)
        Me.FlexGridClientes.Name = "FlexGridClientes"
        Me.FlexGridClientes.Redraw = True
        Me.FlexGridClientes.Row = 1
        Me.FlexGridClientes.RowSel = 1
        Me.FlexGridClientes.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridClientes.ScrollTrack = True
        Me.FlexGridClientes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridClientes.ShowCursor = False
        Me.FlexGridClientes.ShowSort = True
        Me.FlexGridClientes.Size = New System.Drawing.Size(229, 181)
        Me.FlexGridClientes.StyleInfo = resources.GetString("FlexGridClientes.StyleInfo")
        Me.FlexGridClientes.SupportInfo = "pwBzAaABlgF9AIgBCwHkAHsASQExAWABPQGuABABSQFJAYIAAgFRARIBeABTAKYA9wBtALwA9AA5AIcAP" & _
            "AD8AKQAXgByAA=="
        Me.FlexGridClientes.TabIndex = 29
        Me.FlexGridClientes.Text = "C1FlexGrid1"
        Me.FlexGridClientes.TopRow = 1
        '
        'ButtonAgendaContinuar
        '
        Me.ButtonAgendaContinuar.Location = New System.Drawing.Point(4, 228)
        Me.ButtonAgendaContinuar.Name = "ButtonAgendaContinuar"
        Me.ButtonAgendaContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAgendaContinuar.TabIndex = 27
        Me.ButtonAgendaContinuar.Text = "ButtonAgendaContinuar"
        '
        'ButtonAgendaRegresar
        '
        Me.ButtonAgendaRegresar.Location = New System.Drawing.Point(82, 228)
        Me.ButtonAgendaRegresar.Name = "ButtonAgendaRegresar"
        Me.ButtonAgendaRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAgendaRegresar.TabIndex = 28
        Me.ButtonAgendaRegresar.Text = "ButtonAgendaRegresar"
        '
        'LabelTiempo
        '
        Me.LabelTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.LabelTiempo.ForeColor = System.Drawing.Color.Blue
        Me.LabelTiempo.Location = New System.Drawing.Point(123, 24)
        Me.LabelTiempo.Name = "LabelTiempo"
        Me.LabelTiempo.Size = New System.Drawing.Size(112, 16)
        Me.LabelTiempo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelContrasena
        '
        Me.PanelContrasena.Controls.Add(Me.ButtonCancelarContrasena)
        Me.PanelContrasena.Controls.Add(Me.ButtonAceptarContrasena)
        Me.PanelContrasena.Controls.Add(Me.textContrasena)
        Me.PanelContrasena.Controls.Add(Me.LabelContrasena)
        Me.PanelContrasena.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContrasena.Location = New System.Drawing.Point(0, 0)
        Me.PanelContrasena.Name = "PanelContrasena"
        Me.PanelContrasena.Size = New System.Drawing.Size(242, 295)
        Me.PanelContrasena.Visible = False
        '
        'ButtonCancelarContrasena
        '
        Me.ButtonCancelarContrasena.Location = New System.Drawing.Point(86, 224)
        Me.ButtonCancelarContrasena.Name = "ButtonCancelarContrasena"
        Me.ButtonCancelarContrasena.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelarContrasena.TabIndex = 3
        Me.ButtonCancelarContrasena.Text = "ButtonCancelarContrasena"
        '
        'ButtonAceptarContrasena
        '
        Me.ButtonAceptarContrasena.Location = New System.Drawing.Point(8, 224)
        Me.ButtonAceptarContrasena.Name = "ButtonAceptarContrasena"
        Me.ButtonAceptarContrasena.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAceptarContrasena.TabIndex = 2
        Me.ButtonAceptarContrasena.Text = "ButtonAceptarContrasena"
        '
        'textContrasena
        '
        Me.textContrasena.Location = New System.Drawing.Point(8, 45)
        Me.textContrasena.MaxLength = 40
        Me.textContrasena.Name = "textContrasena"
        Me.textContrasena.Size = New System.Drawing.Size(223, 21)
        Me.textContrasena.TabIndex = 1
        '
        'LabelContrasena
        '
        Me.LabelContrasena.Location = New System.Drawing.Point(8, 12)
        Me.LabelContrasena.Name = "LabelContrasena"
        Me.LabelContrasena.Size = New System.Drawing.Size(223, 20)
        Me.LabelContrasena.Text = "LabelContrasena"
        Me.LabelContrasena.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormFiltroClientesFueraFrecuencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelContrasena)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuAgenda
        Me.MinimizeBox = False
        Me.Name = "FormFiltroClientesFueraFrecuencia"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlClientesFueraFrecuencia.ResumeLayout(False)
        Me.TabPageFiltro.ResumeLayout(False)
        Me.TabPageCliente.ResumeLayout(False)
        Me.PanelContrasena.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlClientesFueraFrecuencia As System.Windows.Forms.TabControl
    Friend WithEvents TabPageFiltro As System.Windows.Forms.TabPage
    Friend WithEvents TabPageCliente As System.Windows.Forms.TabPage
    Friend WithEvents txtPatron As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAgendaContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgendaRegresar As System.Windows.Forms.Button
    Friend WithEvents FlexGridClientes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelAgenda As System.Windows.Forms.Label
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxComparaDom As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxDomicilio As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxComparaNombre As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxNombre As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxClave As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxComparaClave As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxClave As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxComparaRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxRazonSocial As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonFiltroContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonFiltroRegresar As System.Windows.Forms.Button

    Public Sub New(ByVal paroRutaActual As Ruta)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FlexGridClientes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        RutaActual = paroRutaActual

        Me.ClienteActual = New Cliente

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
