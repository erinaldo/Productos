Imports System.Data.SqlServerCe

Public Class FormComunicacion
    Inherits System.Windows.Forms.Form

    Private eTipoTablas As ServicesCentral.TiposBase

    Private refaVista As Vista
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlComunicacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPageComunicacion As System.Windows.Forms.TabPage
    Friend WithEvents TabControlTransferir As System.Windows.Forms.TabControl
    Friend WithEvents TabPageEnviar As System.Windows.Forms.TabPage
    Private WithEvents DetailViewEnviar As Resco.Controls.DetailView.DetailView
    Friend WithEvents LabelEnviar As System.Windows.Forms.Label
    Friend WithEvents TabPageRecibir As System.Windows.Forms.TabPage
    Private WithEvents DetailViewRecibir As Resco.Controls.DetailView.DetailView
    Friend WithEvents LabelRecibir As System.Windows.Forms.Label
    Friend WithEvents TabPageAgenda As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxCanjes As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimeFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelFechaInicio As System.Windows.Forms.Label
    Friend WithEvents LabelFechaFin As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents TabPageConfiguracion As System.Windows.Forms.TabPage
    Friend WithEvents ButtonAceptar As System.Windows.Forms.Button
    Private WithEvents DetailViewConfiguracion As Resco.Controls.DetailView.DetailView
    Friend WithEvents LabelConfiguracion As System.Windows.Forms.Label
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button

    Private bModoConectar As Boolean
    Dim WithEvents connMgr As OpenNETCF.Net.ConnectionManager
    Dim WithEvents connMgr1 As New WANSample.Conn
    Dim Conectado As Boolean = False
    Friend WithEvents PanelConexion As System.Windows.Forms.Panel
    Friend WithEvents pnlModem As System.Windows.Forms.Panel
    Friend WithEvents btnDesconectar As System.Windows.Forms.Button
    Friend WithEvents btnConexion As System.Windows.Forms.Button
    Friend WithEvents LabelConexion As System.Windows.Forms.Label
    Friend WithEvents cboConexion As System.Windows.Forms.ComboBox

    '#If MOD_TERM = "HHP" Then
    '    Dim WithEvents hhpConn As HHP.WinCE.Network.RAS
    '#End If
    Dim blnHuboConexion As Boolean = False
    Dim bEnProceso As Boolean = False
    Dim bDescompactando As Boolean
    Dim bFinalizoCorrecto As Boolean
    Dim bCanjes As Boolean = False
    Dim bReintentar As Boolean
    Friend WithEvents TabPagePuertos As System.Windows.Forms.TabPage
    Private WithEvents DetailViewPuertos As Resco.Controls.DetailView.DetailView
    Dim sMensajeEnd As String

    '--Bandera de compilación para la version que corre sobre Windows CE 5.0 
    '#Const SO_WCE = 1


    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        InicializarObjetos()
    End Sub

    Public Sub New(ByVal pareTipoArchivos As Integer)
        MyBase.New()
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        eTipoTablas = pareTipoArchivos
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        InicializarObjetos()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.MenuItemRegresar) Then Me.MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuComunicacion) Then Me.MainMenuComunicacion.Dispose()
        If Not IsNothing(Me.DetailViewConfiguracion) Then
            Me.DetailViewConfiguracion.Items.Clear()
            Me.DetailViewConfiguracion.Dispose()
            Me.DetailViewConfiguracion = Nothing
        End If
        If Not IsNothing(Me.DetailViewEnviar) Then
            Me.DetailViewEnviar.Items.Clear()
            Me.DetailViewEnviar.Dispose()
            Me.DetailViewEnviar = Nothing
        End If
        If Not IsNothing(Me.DetailViewRecibir) Then
            Me.DetailViewRecibir.Items.Clear()
            Me.DetailViewRecibir.Dispose()
            Me.DetailViewRecibir = Nothing
        End If
        If Not IsNothing(Me.DateTimeFechaInicio) Then Me.DateTimeFechaInicio.Dispose()
        If Not IsNothing(Me.DateTimeFechaFin) Then Me.DateTimeFechaFin.Dispose()

        If Not IsNothing(Me.connMgr) Then Me.connMgr = Nothing
        If Not IsNothing(Me.connMgr1) Then Me.connMgr1.Dispose()
        '#If MOD_TERM = "HHP" Then
        '        If Not IsNothing(Me.hhpConn) Then Me.hhpConn = Nothing
        '#End If

        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuComunicacion As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuComunicacion = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlComunicacion = New System.Windows.Forms.TabControl
        Me.TabPageComunicacion = New System.Windows.Forms.TabPage
        Me.TabControlTransferir = New System.Windows.Forms.TabControl
        Me.TabPageEnviar = New System.Windows.Forms.TabPage
        Me.DetailViewEnviar = New Resco.Controls.DetailView.DetailView
        Me.LabelEnviar = New System.Windows.Forms.Label
        Me.TabPageAgenda = New System.Windows.Forms.TabPage
        Me.CheckBoxCanjes = New System.Windows.Forms.CheckBox
        Me.DateTimeFechaFin = New System.Windows.Forms.DateTimePicker
        Me.DateTimeFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.LabelFechaInicio = New System.Windows.Forms.Label
        Me.LabelFechaFin = New System.Windows.Forms.Label
        Me.TabPageRecibir = New System.Windows.Forms.TabPage
        Me.DetailViewRecibir = New Resco.Controls.DetailView.DetailView
        Me.LabelRecibir = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.TabPageConfiguracion = New System.Windows.Forms.TabPage
        Me.ButtonAceptar = New System.Windows.Forms.Button
        Me.DetailViewConfiguracion = New Resco.Controls.DetailView.DetailView
        Me.LabelConfiguracion = New System.Windows.Forms.Label
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.TabPagePuertos = New System.Windows.Forms.TabPage
        Me.DetailViewPuertos = New Resco.Controls.DetailView.DetailView
        Me.PanelConexion = New System.Windows.Forms.Panel
        Me.pnlModem = New System.Windows.Forms.Panel
        Me.btnDesconectar = New System.Windows.Forms.Button
        Me.btnConexion = New System.Windows.Forms.Button
        Me.LabelConexion = New System.Windows.Forms.Label
        Me.cboConexion = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.TabControlComunicacion.SuspendLayout()
        Me.TabPageComunicacion.SuspendLayout()
        Me.TabControlTransferir.SuspendLayout()
        Me.TabPageEnviar.SuspendLayout()
        Me.TabPageAgenda.SuspendLayout()
        Me.TabPageRecibir.SuspendLayout()
        Me.TabPageConfiguracion.SuspendLayout()
        Me.TabPagePuertos.SuspendLayout()
        Me.PanelConexion.SuspendLayout()
        Me.pnlModem.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuComunicacion
        '
        Me.MainMenuComunicacion.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlComunicacion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlComunicacion
        '
        Me.TabControlComunicacion.Controls.Add(Me.TabPageComunicacion)
        Me.TabControlComunicacion.Controls.Add(Me.TabPageConfiguracion)
        Me.TabControlComunicacion.Controls.Add(Me.TabPagePuertos)
        Me.TabControlComunicacion.Location = New System.Drawing.Point(0, 0)
        Me.TabControlComunicacion.Name = "TabControlComunicacion"
        Me.TabControlComunicacion.SelectedIndex = 0
        Me.TabControlComunicacion.Size = New System.Drawing.Size(242, 295)
        Me.TabControlComunicacion.TabIndex = 1
        '
        'TabPageComunicacion
        '
        Me.TabPageComunicacion.Controls.Add(Me.TabControlTransferir)
        Me.TabPageComunicacion.Controls.Add(Me.ButtonContinuar)
        Me.TabPageComunicacion.Controls.Add(Me.ButtonRegresar)
        Me.TabPageComunicacion.Location = New System.Drawing.Point(4, 25)
        Me.TabPageComunicacion.Name = "TabPageComunicacion"
        Me.TabPageComunicacion.Size = New System.Drawing.Size(234, 266)
        Me.TabPageComunicacion.Text = "TabPageComunicacion"
        '
        'TabControlTransferir
        '
        Me.TabControlTransferir.Controls.Add(Me.TabPageEnviar)
        Me.TabControlTransferir.Controls.Add(Me.TabPageAgenda)
        Me.TabControlTransferir.Controls.Add(Me.TabPageRecibir)
        Me.TabControlTransferir.Location = New System.Drawing.Point(0, 0)
        Me.TabControlTransferir.Name = "TabControlTransferir"
        Me.TabControlTransferir.SelectedIndex = 0
        Me.TabControlTransferir.Size = New System.Drawing.Size(242, 240)
        Me.TabControlTransferir.TabIndex = 1
        '
        'TabPageEnviar
        '
        Me.TabPageEnviar.Controls.Add(Me.DetailViewEnviar)
        Me.TabPageEnviar.Controls.Add(Me.LabelEnviar)
        Me.TabPageEnviar.Location = New System.Drawing.Point(4, 25)
        Me.TabPageEnviar.Name = "TabPageEnviar"
        Me.TabPageEnviar.Size = New System.Drawing.Size(234, 211)
        Me.TabPageEnviar.Text = "TabPageEnviar"
        '
        'DetailViewEnviar
        '
        Me.DetailViewEnviar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewEnviar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewEnviar.LabelWidth = 0
        Me.DetailViewEnviar.Location = New System.Drawing.Point(4, 20)
        Me.DetailViewEnviar.Name = "DetailViewEnviar"
        Me.DetailViewEnviar.SeparatorWidth = 16
        Me.DetailViewEnviar.Size = New System.Drawing.Size(225, 168)
        Me.DetailViewEnviar.TabIndex = 0
        '
        'LabelEnviar
        '
        Me.LabelEnviar.Location = New System.Drawing.Point(4, 4)
        Me.LabelEnviar.Name = "LabelEnviar"
        Me.LabelEnviar.Size = New System.Drawing.Size(230, 20)
        Me.LabelEnviar.Text = "LabelEnviar"
        '
        'TabPageAgenda
        '
        Me.TabPageAgenda.Controls.Add(Me.CheckBoxCanjes)
        Me.TabPageAgenda.Controls.Add(Me.DateTimeFechaFin)
        Me.TabPageAgenda.Controls.Add(Me.DateTimeFechaInicio)
        Me.TabPageAgenda.Controls.Add(Me.LabelFechaInicio)
        Me.TabPageAgenda.Controls.Add(Me.LabelFechaFin)
        Me.TabPageAgenda.Location = New System.Drawing.Point(4, 25)
        Me.TabPageAgenda.Name = "TabPageAgenda"
        Me.TabPageAgenda.Size = New System.Drawing.Size(234, 211)
        Me.TabPageAgenda.Text = "TabPageAgenda"
        '
        'CheckBoxCanjes
        '
        Me.CheckBoxCanjes.Location = New System.Drawing.Point(7, 112)
        Me.CheckBoxCanjes.Name = "CheckBoxCanjes"
        Me.CheckBoxCanjes.Size = New System.Drawing.Size(200, 20)
        Me.CheckBoxCanjes.TabIndex = 16
        Me.CheckBoxCanjes.Text = "CheckBoxCanjes"
        '
        'DateTimeFechaFin
        '
        Me.DateTimeFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DateTimeFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeFechaFin.Location = New System.Drawing.Point(7, 71)
        Me.DateTimeFechaFin.Name = "DateTimeFechaFin"
        Me.DateTimeFechaFin.Size = New System.Drawing.Size(200, 24)
        Me.DateTimeFechaFin.TabIndex = 14
        Me.DateTimeFechaFin.Value = New Date(2006, 9, 7, 0, 0, 0, 0)
        '
        'DateTimeFechaInicio
        '
        Me.DateTimeFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.DateTimeFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeFechaInicio.Location = New System.Drawing.Point(7, 23)
        Me.DateTimeFechaInicio.Name = "DateTimeFechaInicio"
        Me.DateTimeFechaInicio.Size = New System.Drawing.Size(200, 24)
        Me.DateTimeFechaInicio.TabIndex = 13
        Me.DateTimeFechaInicio.Value = New Date(2006, 9, 7, 0, 0, 0, 0)
        '
        'LabelFechaInicio
        '
        Me.LabelFechaInicio.Location = New System.Drawing.Point(7, 4)
        Me.LabelFechaInicio.Name = "LabelFechaInicio"
        Me.LabelFechaInicio.Size = New System.Drawing.Size(100, 20)
        Me.LabelFechaInicio.Text = "LabelFechaInicio"
        '
        'LabelFechaFin
        '
        Me.LabelFechaFin.Location = New System.Drawing.Point(7, 54)
        Me.LabelFechaFin.Name = "LabelFechaFin"
        Me.LabelFechaFin.Size = New System.Drawing.Size(100, 20)
        Me.LabelFechaFin.Text = "LabelFechaFin"
        '
        'TabPageRecibir
        '
        Me.TabPageRecibir.Controls.Add(Me.DetailViewRecibir)
        Me.TabPageRecibir.Controls.Add(Me.LabelRecibir)
        Me.TabPageRecibir.Location = New System.Drawing.Point(4, 25)
        Me.TabPageRecibir.Name = "TabPageRecibir"
        Me.TabPageRecibir.Size = New System.Drawing.Size(234, 211)
        Me.TabPageRecibir.Text = "TabPageRecibir"
        '
        'DetailViewRecibir
        '
        Me.DetailViewRecibir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewRecibir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewRecibir.LabelWidth = 170
        Me.DetailViewRecibir.Location = New System.Drawing.Point(4, 20)
        Me.DetailViewRecibir.Name = "DetailViewRecibir"
        Me.DetailViewRecibir.SeparatorWidth = 6
        Me.DetailViewRecibir.Size = New System.Drawing.Size(225, 168)
        Me.DetailViewRecibir.TabIndex = 0
        '
        'LabelRecibir
        '
        Me.LabelRecibir.Location = New System.Drawing.Point(4, 4)
        Me.LabelRecibir.Name = "LabelRecibir"
        Me.LabelRecibir.Size = New System.Drawing.Size(230, 16)
        Me.LabelRecibir.Text = "LabelRecibir"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(2, 241)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 2
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(81, 241)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'TabPageConfiguracion
        '
        Me.TabPageConfiguracion.Controls.Add(Me.ButtonAceptar)
        Me.TabPageConfiguracion.Controls.Add(Me.DetailViewConfiguracion)
        Me.TabPageConfiguracion.Controls.Add(Me.LabelConfiguracion)
        Me.TabPageConfiguracion.Controls.Add(Me.ButtonCancelar)
        Me.TabPageConfiguracion.Location = New System.Drawing.Point(4, 25)
        Me.TabPageConfiguracion.Name = "TabPageConfiguracion"
        Me.TabPageConfiguracion.Size = New System.Drawing.Size(234, 266)
        Me.TabPageConfiguracion.Text = "TabPageConfiguracion"
        '
        'ButtonAceptar
        '
        Me.ButtonAceptar.Location = New System.Drawing.Point(4, 241)
        Me.ButtonAceptar.Name = "ButtonAceptar"
        Me.ButtonAceptar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonAceptar.TabIndex = 0
        Me.ButtonAceptar.Text = "ButtonAceptar"
        '
        'DetailViewConfiguracion
        '
        Me.DetailViewConfiguracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewConfiguracion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewConfiguracion.LabelWidth = 110
        Me.DetailViewConfiguracion.Location = New System.Drawing.Point(4, 24)
        Me.DetailViewConfiguracion.Name = "DetailViewConfiguracion"
        Me.DetailViewConfiguracion.SeparatorWidth = 6
        Me.DetailViewConfiguracion.Size = New System.Drawing.Size(222, 211)
        Me.DetailViewConfiguracion.TabIndex = 1
        '
        'LabelConfiguracion
        '
        Me.LabelConfiguracion.Location = New System.Drawing.Point(4, 8)
        Me.LabelConfiguracion.Name = "LabelConfiguracion"
        Me.LabelConfiguracion.Size = New System.Drawing.Size(230, 20)
        Me.LabelConfiguracion.Text = "LabelConfiguracion"
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(83, 241)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonCancelar.TabIndex = 3
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'TabPagePuertos
        '
        Me.TabPagePuertos.Controls.Add(Me.DetailViewPuertos)
        Me.TabPagePuertos.Location = New System.Drawing.Point(4, 25)
        Me.TabPagePuertos.Name = "TabPagePuertos"
        Me.TabPagePuertos.Size = New System.Drawing.Size(234, 266)
        Me.TabPagePuertos.Text = "TabPagePuertos"
        '
        'DetailViewPuertos
        '
        Me.DetailViewPuertos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewPuertos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewPuertos.LabelWidth = 110
        Me.DetailViewPuertos.Location = New System.Drawing.Point(6, 28)
        Me.DetailViewPuertos.Name = "DetailViewPuertos"
        Me.DetailViewPuertos.SeparatorWidth = 6
        Me.DetailViewPuertos.Size = New System.Drawing.Size(222, 211)
        Me.DetailViewPuertos.TabIndex = 2
        '
        'PanelConexion
        '
        Me.PanelConexion.Controls.Add(Me.pnlModem)
        Me.PanelConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelConexion.Location = New System.Drawing.Point(0, 0)
        Me.PanelConexion.Name = "PanelConexion"
        Me.PanelConexion.Size = New System.Drawing.Size(242, 295)
        '
        'pnlModem
        '
        Me.pnlModem.BackColor = System.Drawing.SystemColors.GrayText
        Me.pnlModem.Controls.Add(Me.btnDesconectar)
        Me.pnlModem.Controls.Add(Me.btnConexion)
        Me.pnlModem.Controls.Add(Me.LabelConexion)
        Me.pnlModem.Controls.Add(Me.cboConexion)
        Me.pnlModem.Location = New System.Drawing.Point(37, 82)
        Me.pnlModem.Name = "pnlModem"
        Me.pnlModem.Size = New System.Drawing.Size(166, 68)
        '
        'btnDesconectar
        '
        Me.btnDesconectar.Location = New System.Drawing.Point(81, 44)
        Me.btnDesconectar.Name = "btnDesconectar"
        Me.btnDesconectar.Size = New System.Drawing.Size(82, 20)
        Me.btnDesconectar.TabIndex = 3
        Me.btnDesconectar.Text = "Desconecta"
        '
        'btnConexion
        '
        Me.btnConexion.Location = New System.Drawing.Point(3, 44)
        Me.btnConexion.Name = "btnConexion"
        Me.btnConexion.Size = New System.Drawing.Size(72, 20)
        Me.btnConexion.TabIndex = 1
        Me.btnConexion.Text = "Conectar"
        '
        'LabelConexion
        '
        Me.LabelConexion.Location = New System.Drawing.Point(3, 0)
        Me.LabelConexion.Name = "LabelConexion"
        Me.LabelConexion.Size = New System.Drawing.Size(133, 17)
        Me.LabelConexion.Text = "LabelConexion"
        '
        'cboConexion
        '
        Me.cboConexion.Location = New System.Drawing.Point(2, 19)
        Me.cboConexion.Name = "cboConexion"
        Me.cboConexion.Size = New System.Drawing.Size(161, 23)
        Me.cboConexion.TabIndex = 0
        '
        'FormComunicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelConexion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuComunicacion
        Me.MinimizeBox = False
        Me.Name = "FormComunicacion"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlComunicacion.ResumeLayout(False)
        Me.TabPageComunicacion.ResumeLayout(False)
        Me.TabControlTransferir.ResumeLayout(False)
        Me.TabPageEnviar.ResumeLayout(False)
        Me.TabPageAgenda.ResumeLayout(False)
        Me.TabPageRecibir.ResumeLayout(False)
        Me.TabPageConfiguracion.ResumeLayout(False)
        Me.TabPagePuertos.ResumeLayout(False)
        Me.PanelConexion.ResumeLayout(False)
        Me.pnlModem.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InicializarObjetos()
        DetailViewRecibir.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        DetailViewEnviar.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        DetailViewConfiguracion.Text = "DetailViewConfiguracion"
        DetailViewConfiguracion.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

#Region "Variables"
    Dim indexTabEnviarDatos As Integer = 0
    Dim indexTabAgenda As Integer = 1
    Dim indexTabRecibirDatos As Integer = 2
#End Region

    Private Sub FormComunicacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '--Fix Nochistlan prender el bluetooth
        oApp.DesactivarWiFi()
        oApp.desconectarRAS()
        If oApp.ModeloTerminal = "SymbolMC50" Or oApp.ModeloTerminal = "SymbolC9090" Then
            'Apagar el bluetooth
            Symbol_Bluetooth.Bluetooth_Off()
        ElseIf oApp.ModeloTerminal = "SymbolMC35" Then
            Dim phone As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
            phone.BlueToothEstado(PhoneRadio.RadioMode.Off)
            phone.Dispose()
        End If
    End Sub

    Private Sub FormComunicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        '--Fix Nochistlan prender el bluetooth
        If oApp.ModeloTerminal = "SymbolMC50" Or oApp.ModeloTerminal = "SymbolC9090" Then
            'Apagar el bluetooth
            Symbol_Bluetooth.Bluetooth_On()
        ElseIf oApp.ModeloTerminal = "SymbolMC35" Then
            Dim phone As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
            phone.BlueToothEstado(PhoneRadio.RadioMode.On)
            phone.Dispose()
        End If

        If Not Vista.Buscar("FormComunicacion", refaVista) Then
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)

        Select Case eTipoTablas
            Case ServicesCentral.TiposBase.Aplicacion
                ' Quitar el TabPage de Enviar
                TabControlTransferir.TabPages.RemoveAt(indexTabAgenda)
                TabControlTransferir.TabPages.RemoveAt(indexTabEnviarDatos)
                indexTabRecibirDatos = 0
                DetailViewRecibir.Text = "DetailViewComAplicacion"
                refaVista.CrearDetailView(DetailViewRecibir, "DetailViewComAplicacion")
                'Me.ButtonLimpiarTodo.Visible = False
            Case ServicesCentral.TiposBase.Vendedor
                ' Quitar el TabPage de Enviar
                'TabControlTransferir.TabPages.RemoveAt(1)
                DateTimeFechaInicio.Value = PrimeraHora(Now)
                DateTimeFechaFin.Value = PrimeraHora(Now)
                DetailViewEnviar.Text = "DetailViewComDiaEnviar"
                LlenarDetailViewEnviar()
                'refaVista.CrearDetailView(DetailViewEnviar, "DetailViewComDiaEnviar")
                DetailViewRecibir.Text = "DetailViewComDiaRecibir"
                refaVista.CrearDetailView(DetailViewRecibir, "DetailViewComDiaRecibir")
                'Me.ButtonLimpiarTodo.Visible = False
        End Select

        llenarPuertos()

        refaVista.CrearDetailView(DetailViewConfiguracion, "DetailViewConfiguracion")
        EstablecerValoresPorDefectoCheckBox()
        LlenarComboTerminal()
        DetailViewConfiguracion.Items("TextBoxServidor").Text = oApp.Servidor.Trim
        DetailViewConfiguracion.Items("TextBoxUsuario").Text = oApp.Usuario.Clave.Trim
        Dim refTextBox As Resco.Controls.DetailView.ItemTextBox = DetailViewConfiguracion.Items("TextBoxContrasena")
        refTextBox.PasswordChar = "*"
        refTextBox.Text = oApp.Contrasena.Trim
        DetailViewConfiguracion.Items("TextBoxNombreServicio").Text = oApp.URL.Trim
        DetailViewConfiguracion.Items("ComboBoxTerminal").Value = oApp.ModeloTerminal.Trim
        CType(DetailViewConfiguracion.Items("CheckBoxWireless"), Resco.Controls.DetailView.ItemCheckBox).Checked = oApp.UsarWireless

        DetailViewConfiguracion.Items("CheckBoxAseguramientoVisita").Visible = False
        CType(DetailViewConfiguracion.Items("CheckBoxAseguramientoVisita"), Resco.Controls.DetailView.ItemCheckBox).Checked = oApp.AseguramientoVisita
        Dim refTextBox2 As Resco.Controls.DetailView.ItemTextBox = DetailViewConfiguracion.Items("TextBoxContraseniaAseguramiento")
        refTextBox2.PasswordChar = "*"
        Me.TabControlTransferir.SelectedIndex = 0

#If MOD_TERM <> "PALM" Then
        If oApp.ModeloTerminal = "HHP7900" Then
            Dim bScanner As New HANDHELD.CScanner
            bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
            Application.DoEvents()
            System.Threading.Thread.Sleep(100)
            bScanner.Terminate_Scanner()
        End If
#End If
    End Sub

    Private Sub LLenarComboPuertos(ByRef Combo As Resco.Controls.DetailView.ItemComboBox)

        Dim Puertos As New DataTable
        Puertos.Columns.Add("Puerto", "".GetType)
        'Puertos.Columns.Add("Valor", 1.GetType)
        Puertos.Rows.Add(New Object() {""})
        For Each PUERTO As String In System.IO.Ports.SerialPort.GetPortNames()
            Puertos.Rows.Add(New Object() {PUERTO})
        Next
        Puertos.Rows.Add(New Object() {"INFRAROJO"})

        Combo.DataSource = Puertos
        Combo.DisplayMember = "Puerto"
        Combo.ValueMember = "Puerto"


    End Sub
    Private Sub llenarPuertos()
        Dim Papeles As New ArrayList()
        Papeles = ValorReferencia.RecuperarLista("TPAPEL")


        For i As Integer = 0 To Papeles.Count - 1
            Dim ComboNuevo As New Resco.Controls.DetailView.ItemComboBox
            ComboNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
            ComboNuevo.LabelAlignment = HorizontalAlignment.Left
            ComboNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            ComboNuevo.TextForeColor = System.Drawing.Color.Black
            ComboNuevo.Name = "CmbPuertos" + i.ToString()
            ComboNuevo.Label = CType(Papeles(i), MobileClient.ValorReferencia.Descripcion).Cadena
            ComboNuevo.Tag = CType(Papeles(i), MobileClient.ValorReferencia.Descripcion).Id
            ComboNuevo.DropDownStyle = Resco.Controls.DetailView.RescoComboBoxStyle.DropDown
            LLenarComboPuertos(ComboNuevo)
            DetailViewPuertos.Items.Add(ComboNuevo)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            ComboNuevo.Height = 32
#End If

        Next

        For Each FILA As DataRow In oApp.Puertos.Rows
            For Each ITEM As Resco.Controls.DetailView.ItemComboBox In DetailViewPuertos.Items
                If ITEM.Tag = FILA("Impresora") Then
                    ITEM.SelectedItem = FILA("Puerto")
                End If
            Next
        Next





    End Sub

    Private Sub CrearItemEnviar(ByVal nTag As Integer, ByVal sNombre As String, ByVal sTexto As String, ByVal bHabilitado As Boolean, ByVal bSeleccionado As Boolean, ByVal oStyle As Resco.Controls.DetailView.RescoItemStyle, ByVal oItemBorder As Resco.Controls.DetailView.ItemBorder)
        Dim oItemChecBox As New Resco.Controls.DetailView.ItemCheckBox
        oItemChecBox.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        oItemChecBox.LabelForeColor = System.Drawing.Color.Navy
        oItemChecBox.LabelHeight = PubcAlturaItemsDetailView
        oItemChecBox.QuickChange = True
        oItemChecBox.TextBackColor = System.Drawing.Color.White
        oItemChecBox.TextForeColor = System.Drawing.Color.DarkBlue
        oItemChecBox.ThreeState = False
        oItemChecBox.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
        oItemChecBox.TextForeColor = System.Drawing.Color.Black
        oItemChecBox.Height = PubcAlturaItemsDetailView
        oItemChecBox.Tag = nTag
        oItemChecBox.Name = sNombre
        oItemChecBox.Text = sTexto
        oItemChecBox.Enabled = bHabilitado
        oItemChecBox.Checked = bSeleccionado
        oItemChecBox.Style = oStyle
        oItemChecBox.ItemBorder = oItemBorder
        DetailViewEnviar.Items.Add(oItemChecBox)
    End Sub

    Private Sub LlenarDetailViewEnviar()
        CrearItemEnviar(1, "CheckBoxJornada", refaVista.BuscarMensaje("MsgBox", "XInfoJornada"), True, True, Resco.Controls.DetailView.RescoItemStyle.LabelTop, Resco.Controls.DetailView.ItemBorder.Underline)
        CrearItemEnviar(2, "CheckBoxActividades", refaVista.BuscarMensaje("MsgBox", "XInfoActividades"), True, False, Resco.Controls.DetailView.RescoItemStyle.LabelTop, Resco.Controls.DetailView.ItemBorder.Underline)
        CrearItemEnviar(3, "CheckBoxMovSinInv", refaVista.BuscarMensaje("MsgBox", "XMovSinInvSinVisAbv"), False, False, Resco.Controls.DetailView.RescoItemStyle.LabelLeft, Resco.Controls.DetailView.ItemBorder.None)
    End Sub

    Private Sub LlenarComboTerminal()
        Dim oItem As Resco.Controls.DetailView.ItemComboBox
        oItem = DetailViewConfiguracion.Items("ComboBoxTerminal")
        oItem.Add("Generico")
        oItem.Add("HHP7600")
        oItem.Add("HHP7900")
        oItem.Add("HHPWM6")
        oItem.Add("IntermecCN3")
        oItem.Add("SymbolC9090")
        oItem.Add("SymbolMC35")
        oItem.Add("SymbolMC50")
        oItem.Add("SymbolMC70")
        oItem.Add("SymbolMC55")
    End Sub

    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click
        If oApp.Usuario.Clave <> DetailViewConfiguracion.Items("TextBoxUsuario").Text.Trim Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0108"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        oApp.Servidor = DetailViewConfiguracion.Items("TextBoxServidor").Text.Trim
        oApp.Usuario.Clave = DetailViewConfiguracion.Items("TextBoxUsuario").Text.Trim
        oApp.Contrasena = DetailViewConfiguracion.Items("TextBoxContrasena").Text.Trim
        oApp.URL = DetailViewConfiguracion.Items("TextBoxNombreServicio").Text.Trim
        oApp.ModeloTerminal = DetailViewConfiguracion.Items("ComboBoxTerminal").Value
        oApp.UsarWireless = CType(DetailViewConfiguracion.Items("CheckBoxWireless"), Resco.Controls.DetailView.ItemCheckBox).Checked
        oApp.AseguramientoVisita = CType(DetailViewConfiguracion.Items("CheckBoxAseguramientoVisita"), Resco.Controls.DetailView.ItemCheckBox).Checked

        If Not oApp.Puertos.Columns.Contains("Impresora") Then
            oApp.Puertos.Columns.Add("Impresora")
            oApp.Puertos.Columns.Add("Puerto")
        End If
        oApp.Puertos.Rows.Clear()
        Dim bPuerto = True
        For Each item As Resco.Controls.DetailView.ItemComboBox In DetailViewPuertos.Items
            If item.Text <> "" Then
                If Impresion.ObtenerPuerto(item.Text) = FieldSoftware.PrinterCE_NetCF.AsciiCE.ASCIIPORT.ANYCOM_BT Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0726").Replace("$0$", item.Text).Replace("$1$", ValorReferencia.BuscarEquivalente("TPAPEL", item.Tag)))
                    bPuerto = False
                Else
                    oApp.Puertos.Rows.Add(New Object() {item.Tag, item.Text})
                End If
            End If
        Next
        If Not bPuerto Then
            Exit Sub
        End If

        oApp.GuardarConfiguracion()

        [Global].ActualizarURLWebService()
        If TabControlComunicacion.SelectedIndex = 2 Then
            Me.Close()
        Else
            TabControlComunicacion.SelectedIndex = 0
        End If

    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        TabControlComunicacion.SelectedIndex = 0
    End Sub

    Private Function TodasJornadasTerminadas() As Boolean
        Dim sConsulta As String
        Dim dtDia As DataTable
        Dim nTotalDia As Integer = 0
        Dim nTotalVej As Integer = 0
        sConsulta = "select count(Dia.DiaClave) as TotalDIA, "
        sConsulta &= "sum(case when not VEJ.FechaFinal is null then 1 else 0 end) as TotalVEJ from Dia "
        sConsulta &= "left join VendedorJornada VEJ on Dia.DiaClave = VEJ.DiaClave "
        sConsulta &= "where Dia.FueraFrecuencia = 0 "
        dtDia = oDBVen.RealizarConsultaSQL(sConsulta, "Dia")
        If dtDia.Rows.Count > 0 Then
            nTotalDia = Convert.ToInt16(dtDia.Rows(0)("TotalDIA"))
            nTotalVej = Convert.ToInt16(dtDia.Rows(0)("TotalVEJ"))
        End If
        dtDia.Dispose()
        Return (nTotalVej = nTotalDia)
    End Function

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click

        'Si selecciono actualizar, verificar que se haya seleccionado alguna opcion
        If Me.TabControlTransferir.TabPages.Count = 1 Then
            If Not ValidarOpcionesSeleccionadas() Then
                'MDB0701
                MsgBox(refaVista.BuscarMensaje("MsgBox", "MDB0701"), MsgBoxStyle.Information)
                Exit Sub
            End If
        ElseIf Me.TabControlTransferir.SelectedIndex = indexTabEnviarDatos Then
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                If Not (oConHist.Campos("VentaSinSurtir")) Then
                    Dim dtVentasSinSurtir As DataTable = oDBVen.RealizarConsultaSQL("Select distinct CLI.Clave from TransProd TRP inner join Cliente CLI on TRP.ClienteClave = CLI.ClienteClave where TRP.Tipo = 1 and TRP.TipoFase = 1 ", "VentasSinSurtir")
                    If dtVentasSinSurtir.Rows.Count > 0 Then
                        Dim sCliente As String = String.Empty
                        For Each dr As DataRow In dtVentasSinSurtir.Rows
                            sCliente &= "'" & dr("Clave") & "',"
                        Next

                        If Len(sCliente) > 0 Then
                            sCliente = Microsoft.VisualBasic.Left(sCliente, sCliente.Length - 1)
                        End If
                        If MsgBox(refaVista.BuscarMensaje("MsgBox", "E0751").Replace("$0$", sCliente), MsgBoxStyle.Critical) Then
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Dim sMensaje As String = ""
            If oVendedor.JornadaTrabajo And Not oConHist.Campos("Inventario") And oConHist.Campos("ValidaInv") Then
                If Not TodasJornadasTerminadas() Then
                    sMensaje = refaVista.BuscarMensaje("MsgBox", "E0687")
                    'MsgBox(refaVista.BuscarMensaje("MsgBox", "E0687"), MsgBoxStyle.Information)
                    'Exit Sub
                End If
            End If

            If Not ValidarKilometraje() Then
                If sMensaje <> "" Then sMensaje &= vbCrLf
                sMensaje &= refaVista.BuscarMensaje("MsgBox", "E0720")
                'MsgBox(refaVista.BuscarMensaje("MsgBox", "E0720"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                'Exit Sub
            End If

            If sMensaje <> "" Then
                MsgBox(sMensaje, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        '--Verificar que tenga licencia valida en la terminal
        '--Usando el servicio WEB y mandandole el ID de la terminal
        'Revisar la licencia inicial
        FormProcesando.PubSubInformar("Conectando", "Checking Connection")
        If Not ProbarConexion() Then
            Exit Sub
        End If

        If ConexionEnBase.ChecarConexion Then
            Dim oLicencia As New VersionesLicencias
            If Not oLicencia.Revisar_Licencia() Then
                Exit Sub
            End If
            EnviarRecibirInformacion()
            'Else
            'blnHuboConexion = False
            '#If SO_WCE = 0 Then
            '                    Conectado = False
            '                    '--Mostra la lista de conexiones
            '                    connMgr = New OpenNETCF.Net.ConnectionManager
            '            Me.PanelConexion.Visible = True
            '            Me.Panel1.Visible = False

            '                    For Each Destino As OpenNETCF.Net.DestinationInfo In connMgr.EnumDestinations
            '                        Me.cboConexion.Items.Add(Destino.Description)
            '                    Next
            '                    Conectado = True
            '                    Me.cboConexion.Focus()
            '#Else
            '            '--Mandar llamar el XML con las conexiones

            '            ' Usar un DataSet para leer el contenido del archivo XML
            '            Dim DataSetConfig As New DataSet("Config")
            '            Dim refDataTableConfig As DataTable
            '            Dim refDataRowActual As DataRow

            '            DataSetConfig.ReadXml(PubcArchivoConfig)
            '            refDataTableConfig = DataSetConfig.Tables("Conexiones")
            '            If IsNothing(refDataTableConfig) Then
            '                Conectado = False
            '                MsgBox(refaVista.BuscarMensaje("MsgBox", "MDBConexion"), MsgBoxStyle.Critical)
            '            Else
            '                cboConexion.Items.Clear()
            '                If refDataTableConfig.Columns.Contains("Activo") Then
            '                    For Each refDataRowActual In refDataTableConfig.Rows
            '                        If refDataRowActual("Activo") = True Then
            '                            cboConexion.Items.Add(refDataRowActual.Item("Nombre"))
            '                        End If
            '                    Next
            '                End If

            '                If cboConexion.Items.Count > 0 Then
            '                    Me.PanelConexion.Visible = True
            '                    Me.Panel1.Visible = False
            '                    Conectado = True
            '                    Me.cboConexion.Focus()
            '                Else
            '                    Conectado = False
            '                    MsgBox(refaVista.BuscarMensaje("MsgBox", "MDBConexion"), MsgBoxStyle.Critical)
            '                End If
            '                refDataTableConfig.Dispose()
            '            End If
            '#End If
            'If Me.PanelConexion.Visible Then Me.PanelConexion.Visible = False
            'If Not Me.Panel1.Visible Then Me.PanelConexion.Visible = True
            'If Not TabControlComunicacion.Enabled Then TabControlComunicacion.Enabled = True
            'Exit Sub
        End If
    End Sub

    Private Sub EnviarRecibirInformacion()
        ' Verificar la base de datos de la aplicación   
        TabControlComunicacion.Enabled = False

        If Me.TabControlTransferir.TabPages.Count = 3 Then


            If Me.TabControlTransferir.SelectedIndex = indexTabEnviarDatos Then
                EnviarDatos()
            ElseIf Me.TabControlTransferir.SelectedIndex = indexTabAgenda Then
                FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0123"), "")
                Dim b As Boolean = False
                Try
                    [Global].IniciarWS()
                    b = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                If b Then
                    Try
                        If Not oServicioWeb.WSAuditoriaVerificar Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0562"), MsgBoxStyle.Information)
                        ElseIf Not HayDatoSinDescargar() Then
                            oDBVen.Grupo = 0
                            oDBVen.FechaIni = Me.DateTimeFechaInicio.Value
                            oDBVen.FechaFin = Me.DateTimeFechaFin.Value
                            If oDBVen.FechaIni > oDBVen.FechaFin Then
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0008"), MsgBoxStyle.Information)
                                TabControlComunicacion.Enabled = True
                                Me.Refresh()
                                Exit Sub
                            End If

                            ObtenerBD()
                            If bFinalizoCorrecto Then
                                'Reparto
                                'SKUInventario.CargarSKUInventarioReparto()
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "I0186"))
                                oApp.DesactivarWiFi()
                                oApp.desconectarRAS()
                                Me.Close()
                                oVendedor.RecuperarParametros(False)
                            End If
                        Else
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0550"), MsgBoxStyle.Information)
                        End If
                    Catch ex As System.Net.WebException
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "F0008"), MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EnviarRecibirInformacion")
                        FormProcesando.PubSubInformar()
                    Catch ex As System.Net.Sockets.SocketException
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "F0008"), MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EnviarRecibirInformacion")
                        FormProcesando.PubSubInformar()
                    Catch ex As System.Web.Services.Protocols.SoapException
                        If ex.Code.Name = "SINSDF" Or ex.Code.Name = "LLENARTABLA" OrElse ex.Code.Name = "SQLCON" Then
                            MsgBox(" '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical, "EnviarRecibirInformacion")
                        Else
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "I0167"), MsgBoxStyle.Critical, "EnviarRecibirInformacion")
                        End If
                        FormProcesando.PubSubInformar()
                    Catch ex As System.InvalidOperationException
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "I0167"), MsgBoxStyle.Critical, "EnviarRecibirInformacion")
                        FormProcesando.PubSubInformar()
                    Catch ex As Exception
                        MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical, "EnviarRecibirInformacion")
                        FormProcesando.PubSubInformar()
                    End Try
                End If
            ElseIf Me.TabControlTransferir.SelectedIndex = indexTabRecibirDatos Then
                RecibirDatos()
            End If
        Else
            RecibirDatos()
        End If
        oApp.DesactivarWiFi()
        oApp.desconectarRAS()
        TabControlComunicacion.Enabled = True
        Me.Refresh()
    End Sub

    Public Function ProbarConexion() As Boolean
        Dim bDisponible As Boolean = True
        If (Not oApp.ProbarServicioR(3)) Then
            bDisponible = False
            If oApp.UsarWireless Then
                bDisponible = oApp.RevisarServidor()
            End If
            If Not bDisponible Then
                If oApp.conectarRAS() Then
                    If oApp.ProbarServicioR(3) Then
                        bDisponible = True
                    End If
                End If
            End If
            If Not bDisponible Then
                MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click

        '--Fix Nochistlan apagar el bluetooth
        If oApp.ModeloTerminal = "SymbolMC50" Or oApp.ModeloTerminal = "SymbolC9090" Then
            'Apagar el bluetooth
            Symbol_Bluetooth.Bluetooth_Off()
        ElseIf oApp.ModeloTerminal = "SymbolMC35" Then
            Dim phone As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
            phone.BlueToothEstado(PhoneRadio.RadioMode.Off)
            phone.Dispose()
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EstablecerValoresPorDefectoCheckBox()
        Dim refCheckBox As Resco.Controls.DetailView.ItemCheckBox
        For Each refCheckBox In DetailViewRecibir.Items
            refCheckBox.Checked = False
        Next
    End Sub

    Private Sub RecibirDatos()
        Dim refCheckBox As Resco.Controls.DetailView.ItemCheckBox
        Dim sTablas As String = String.Empty
        Dim bTodos As Boolean = True
        ' Verificar qué tablas actualizar
        For Each refCheckBox In DetailViewRecibir.Items
            bTodos = bTodos And refCheckBox.Checked
            If refCheckBox.Checked Then
                Select Case refCheckBox.Name
                    '<Aplicacion>
                    Case "CheckBoxTipos"
                        sTablas &= "''ValorReferencia'',''VARValor'',''VAVDescripcion'',''ConfiguracionRecibo'',''Recibo'',''CORTabla'',''RECNota'',''RECEncabezadoPie'',''COTCampo'',''RECContenido'',''REODetalle'',"
                    Case "CheckBoxUsuarios"
                        sTablas &= "''Usuario'',"
                    Case "CheckBoxVistas"
                        sTablas &= "''Vista'',''VistaElemento'',''VistaElementoDet'',"

                        '<Vendedor>
                    Case "CheckBoxRecargas"
                        sTablas &= "''TransProd'',''TransProdDetalle'',"
                End Select
            End If
        Next
        If bTodos Then
            sTablas = "*"
        Else
            If sTablas <> "" Then
                sTablas = Mid(sTablas, 1, Len(sTablas) - 1)
            End If
        End If
        If sTablas <> "" Then
            Dim bResultado As Boolean
            Try
                Select Case eTipoTablas
                    Case ServicesCentral.TiposBase.Aplicacion
                        oDBApp.Cerrar()
                        FormProcesando.PubSubTitulo("Datos de la Aplicación")
                        If oDBApp.LlenarTablas(sTablas, False) Then
                            bResultado = oDBApp.Abrir(False)
                        End If
                    Case ServicesCentral.TiposBase.Vendedor
                        oDBVen.Cerrar()
                        FormProcesando.PubSubTitulo("Datos del Vendedor")
                        If oDBVen.LlenarTablas(sTablas, False) Then
                            bResultado = oDBVen.Abrir(False)
                        End If
                        If bResultado Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "I0189"), MsgBoxStyle.Information)
                        End If
                End Select
            Catch ex As Exception
                MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical, "RecibirDatos")
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End Try
            TabControlComunicacion.Enabled = True
            If bResultado Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            TabControlComunicacion.Enabled = True
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub EnviarDatos()
        FormProcesando.PubSubTitulo(Me.refaVista.BuscarMensaje("Procesando", "Titulo"))
        Dim sMensaje As String = ""
        Me.EnviarCaptura(sMensaje, False, refaVista)
        If sMensaje <> "" Then
            MsgBox(sMensaje, MsgBoxStyle.Exclamation)
        End If
        TabControlComunicacion.Enabled = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Class TablaAEnviar
        Public sNombreTabla As String
        Public sConsultaSQL As String
        Public bTieneCampoEnviado As Boolean
        Public bSaldos As Boolean = False

        Public Sub New(ByVal parsNombreTabla As String, ByVal parsConsultaSQL As String)
            Me.sNombreTabla = parsNombreTabla
            Me.sConsultaSQL = parsConsultaSQL
        End Sub
        Public Sub New(ByVal parsNombreTabla As String, ByVal parsConsultaSQL As String, ByVal parbSaldos As Boolean)
            Me.sNombreTabla = parsNombreTabla
            Me.sConsultaSQL = parsConsultaSQL
            Me.bSaldos = parbSaldos
        End Sub
        Public Function EjecutarConsulta(ByRef refparoDataSetEnvio As DataSet, ByRef refiTotalRegistros As Integer) As Boolean
            Try
                Dim iReg As Integer = oDBVen.RealizarConsultaSQLIncluyeLlaves(refparoDataSetEnvio, Me.sConsultaSQL, Me.sNombreTabla)
                refiTotalRegistros += iReg
                If iReg > 0 Then
                    Me.bTieneCampoEnviado = refparoDataSetEnvio.Tables(Me.sNombreTabla).Columns.Contains("Enviado")
                    If Me.bTieneCampoEnviado Then
                        refparoDataSetEnvio.Tables(Me.sNombreTabla).Columns.Remove("Enviado")
                    End If
                Else
                    refparoDataSetEnvio.Tables.Remove(Me.sNombreTabla)
                End If
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            Return False
        End Function
    End Class

    Private Function ValidarPreliquidacion() As Boolean
        If oConHist.Campos("Preliquidacion") Then
            Dim bExistePreliquidacion As Boolean
            Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT MontoTotal,PliMargen FROM PreLiquidacion  inner join Moneda on Moneda.MonedaID= PreLiquidacion.monedaID where Enviado = 0", "Preliq")
            Dim nMontoTotal As Decimal = 0
            Dim ndif As Decimal = 0
            bExistePreliquidacion = oDT.Rows.Count > 0
            If bExistePreliquidacion Then
                For Each fila As DataRow In oDT.Rows


                    nMontoTotal = fila("MontoTotal")
                    ndif = fila("PliMargen")
                    If nMontoTotal > ndif Then
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0586"), MsgBoxStyle.Information)
                        oDT.Dispose()
                        oDT = Nothing
                        Return False
                    End If
                Next
            End If
            oDT.Dispose()
            oDT = Nothing
        End If
        Return True
    End Function

    Private Function ValidarJornadas() As Boolean
        Dim res As Boolean = True
        If oVendedor.JornadaTrabajo Then
            If HayDatoSinDescargar() Then
                Dim valor As Integer = Convert.ToInt32(oDBVen.RealizarScalarSQL("select Count(*) from vendedorJornada WHERE FechaFinal is null"))
                If valor <> 0 Then
                    Dim fi As DateTime = Convert.ToDateTime(oDBVen.RealizarScalarSQL("select VEJFechaInicial from vendedorJornada WHERE FechaFinal is null"))

                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0594").Replace("$0$", fi.ToString(oApp.FormatoFecha)), MsgBoxStyle.Information)
                    Return False
                End If
            Else
                MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "I0162"), MsgBoxStyle.Information)
                Return False
            End If
        End If
        Return res
    End Function

    Private Function ValidarCargasEscritorio() As Boolean
        Try
            Return oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd where TransProd.Tipo = 2 and TipoFase = 5 and Escritorio = 1 ") <= 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Private Function ValidarKilometraje() As Boolean
    '    If oVendedor.Kilometraje Then
    '        Dim sConsulta As String
    '        Dim nCapturados As Integer
    '        Dim nTerminados As Integer
    '        sConsulta = "select count(CAMVENId) from CamionVendedor where Enviado = 0"
    '        nCapturados = oDBVen.EjecutarCmdScalarIntSQL(sConsulta)
    '        sConsulta = "select count(CAMVENId) from CamionVendedor where KmFinal is not null and Enviado = 0"
    '        nTerminados = oDBVen.EjecutarCmdScalarIntSQL(sConsulta)
    '        If (nCapturados > nTerminados) Then
    '            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0720"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
    '            Return False
    '        End If
    '    End If
    '    Return True
    'End Function

    'En este metodo no usar el refaVista en lugar de eso, usar el objeto que se envia como parametro refparoVista
    Public Function EnviarCaptura(ByRef refparsMensaje As String, ByVal blnLlamadaDesdeCliente As Boolean, ByRef refparoVista As Vista) As Boolean
        Dim sMensaje As String = ""
        Dim bFalloConexion As Boolean = False
        Dim bEnviarJornada As Boolean = True

        'NOTA IMPORTANTE: Si se agrega la funcionalidad de enviar algunas actividades de la visita, 
        'ningun movimiento que este dentro de esa visita se podrá modificar
        If Not blnLlamadaDesdeCliente Then bEnviarJornada = ValidarEnviarJornada()

        If Not blnLlamadaDesdeCliente And bEnviarJornada Then
            If Not ValidarPreliquidacion() Then Return False

            If Not ValidarJornadas() Then Return False

            oDBVen.EjecutarComandoSQL("Update TransProd Set TipoFase=1, Notas = null, Enviado=0, MFechaHora = " & UniFechaSQL(Now) & " where TransProd.Tipo = 2 and TipoFase = 5 and Escritorio = 1 ")

            If Not ValidarCargasEscritorio() Then
                oDBVen.EjecutarComandoSQL("Update TransProd Set TipoFase=1, Notas = null, Enviado=0, MFechaHora = " & UniFechaSQL(Now) & " where TransProd.Tipo = 2 and TipoFase = 5 and Escritorio = 1 ")
                MsgBox(refparoVista.BuscarMensaje("MsgBox", "F0011"))
                Return False
            End If

            'If oConHist.Campos("Inventario") Then
            '    Inventario.CrearMovimientoInventarioABordo()
            'End If
        End If


        Try
            [Global].IniciarWS()
            oServicioWeb.Timeout = (oApp.TimeOut * 60) * 1000
            ' Agregar al arreglo todas las tablas a enviar -> DEBEN TENER EL CAMPO "ENVIADO"
            Dim aTablas As New ArrayList
            Dim bFoliosDuplicados As Boolean = False
            If bEnviarJornada Then
                Dim blnFacturasElectronicas As Boolean
                'If oConHist.Campos("ComprobanteDig") Then
                Dim sFolios As String = ""
                Dim sTransProdID As String = ""
                Dim sFoliosDup As String = ""
                Dim dtFolios As DataTable
                dtFolios = oDBVen.RealizarConsultaSQL("select TRP.Folio,TRP.TransProdID,TRP.SubempresaID from TransProd TRP inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID where TRP.Tipo in( 8,10) and (TRP.Enviado = 0 or TRP.Enviado is null) ", "TransProd")
                If dtFolios.Rows.Count > 0 Then
                    blnFacturasElectronicas = True
                    For Each oSubEmpresa As SubEmpresa.DatosEmpresa In SubEmpresa.aSubEmpresa
                        sFolios = ""
                        sTransProdID = ""
                        For Each drFolio As DataRow In dtFolios.Select("SubEmpresaID ='" & oSubEmpresa.SubEmpresaId & "'")
                            sFolios &= "'" & drFolio("Folio") & "',"
                            sTransProdID &= "'" & drFolio("TransProdID") & "',"
                        Next
                        If sFolios.Length > 0 Then
                            sFolios = sFolios.Remove(sFolios.Length - 1, 1)
                            sTransProdID = sTransProdID.Remove(sTransProdID.Length - 1, 1)
                            sFoliosDup = oServicioWeb.WSObtenerFoliosDuplicados(sFolios, sTransProdID, oSubEmpresa.SubEmpresaId)
                            If sFoliosDup <> String.Empty Then
                                oDBVen.EjecutarComandoSQL("update TransProd set TipoMotivo = 10 where Folio in (" & sFoliosDup & ") and Tipo in (8,10) and (Enviado = 0 or Enviado is null) and SubEmpresaID='" & oSubEmpresa.SubEmpresaId & "' ")
                                bFoliosDuplicados = True
                            End If
                        End If
                    Next
                End If

                aTablas.Add(New TablaAEnviar("Gasto", "SELECT * FROM Gasto WHERE Enviado IS NULL or Enviado=0"))
                aTablas.Add(New TablaAEnviar("Deposito", "SELECT * FROM Deposito WHERE Enviado IS NULL or Enviado=0"))
                'Clientes
                aTablas.Add(New TablaAEnviar("Cliente", "SELECT ClienteClave,CNPId,Clave,IdElectronico,IdFiscal,RazonSocial,TipoFiscal,TipoImpuesto,NombreContacto,TelefonoContacto,FechaRegistroSistema,FechaNacimiento,LimiteCreditoDinero,NombreCorto,TipoEstado,LimiteDescuento,(Case When SaldoEfectivo is null Then 0 Else SaldoEfectivo End) - (Case When SaldoEfectivoCarga is null Then 0 Else SaldoEfectivoCarga End) as SaldoEfectivo,Prestamo, (Case When SaldoGarantia is null Then 0 Else SaldoGarantia End) - (Case When SaldoGarantiaCarga is null Then 0 Else SaldoGarantiaCarga End) as SaldoGarantia,Exclusividad,VigExclusividad, ActualizaSaldoCheque,CriterioCredito, VencimientoVenta, DiasVencimiento,DesgloseImpuesto, ExigirOrdenCompra, ImprimirPagare, CapturaDatosFacturacion, MFechaHora,MUsuarioID,Enviado FROM Cliente WHERE Enviado=0 or Enviado is null", True))
                aTablas.Add(New TablaAEnviar("ClienteDomicilio", "SELECT * FROM ClienteDomicilio WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("EliminarClienteEsquema", "SELECT ClienteClave,EsquemaID,MFechaHora,MUsuarioID FROM ClienteEsquema WHERE (Enviado=0 or Enviado is null) and Baja = 1"))
                aTablas.Add(New TablaAEnviar("ClienteEsquema", "SELECT ClienteClave,EsquemaID,MFechaHora,MUsuarioID,Enviado FROM ClienteEsquema WHERE (Enviado=0 or Enviado is null) and Baja = 0"))
                aTablas.Add(New TablaAEnviar("CLIFormaVenta", "SELECT * FROM CLIFormaVenta WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("CFVHist", "SELECT * FROM CFVHist WHERE Enviado=0 or Enviado is null"))
                'ClienteMensaje
                aTablas.Add(New TablaAEnviar("ClienteMensaje", "select * from ClienteMensaje WHERE Enviado=0 or Enviado is null"))
                'Activos
                aTablas.Add(New TablaAEnviar("Activo", "SELECT * FROM Activo WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ActivoServicio", "SELECT * FROM ActivoServicio WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ActivoClienteHist", "SELECT * FROM ActivoClienteHist WHERE Enviado=0 or Enviado is null"))
                'Mercadeo
                aTablas.Add(New TablaAEnviar("MercadeoProveedor", "SELECT * FROM MercadeoProveedor WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("MercadeoProducto", "SELECT * FROM MercadeoProducto WHERE Enviado=0 or Enviado is null"))
                'Visitas
                aTablas.Add(New TablaAEnviar("Visita", "SELECT VisitaCLave,DiaClave,ClienteClave,VendedorID,RUTClave,Numero,FechaHoraInicial,FechaHoraFinal,0 as TipoEstado, FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS,MFechaHora,MUsuarioID,Enviado FROM Visita WHERE (Enviado IS NULL or Enviado =0) AND TipoEstado<>0"))
                'Puntos
                aTablas.Add(New TablaAEnviar("CliCap", "SELECT * FROM CliCap WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("Punto", "select ClienteClave,Saldo-Case When SaldoCarga is null Then 0 else SaldoCarga End as Saldo,case When Saldo1 is null Then 0 Else Saldo1 End-Case When Saldo1Carga is null Then 0 ELse Saldo1Carga End as Saldo1,Venta-case When VentaCarga is null Then 0 Else VentaCarga End as Venta,MFechaHora,MUsuarioID,Enviado from punto WHERE Enviado=0 or Enviado is null", True))
                'VendedorJornada
                'Que este como enviado = false y que este finalizada es decir FechaFinal <> null
                aTablas.Add(New TablaAEnviar("VendedorJornada", "SELECT * FROM VendedorJornada WHERE (Enviado=0 or Enviado is null) and not FechaFinal is null "))
                'Encuestas
                aTablas.Add(New TablaAEnviar("Encuesta", "SELECT * FROM Encuesta WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENCPregunta", "SELECT * FROM ENCPregunta WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespNumero", "SELECT * FROM ENPRespNumero WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespOpcional", "SELECT * FROM ENPRespOpcional WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespTexto", "SELECT * FROM ENPRespTexto WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespCodigo", "SELECT * FROM ENPRespCodigo WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespImagen", "SELECT * FROM ENPRespImagen WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespMatricial", "SELECT * FROM ENPRespMatricial WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ENPRespGPS", "SELECT * FROM ENPRespGPS WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("CenCli", "SELECT *, 1 as Estado  FROM CenCli WHERE Enviado=0 or Enviado is null"))
                'Mercadeo
                aTablas.Add(New TablaAEnviar("Mercadeo", "SELECT * FROM Mercadeo WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("MerCli", "SELECT * FROM MerCli WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("MerDetalle", "SELECT * FROM MerDetalle WHERE Enviado=0 or Enviado is null"))
                'Preliquidacion
                aTablas.Add(New TablaAEnviar("PreLiquidacion", "SELECT PLIId, FechaPreliquidacion,MonedaID, '" & oVendedor.VendedorId & "' as VendedorId, FechaPreliquidacion as MFechaHora, '" & oVendedor.UsuarioId & "' as MUsuarioId, Enviado FROM Preliquidacion WHERE Enviado=0 or Enviado is null", False))
                If Not blnLlamadaDesdeCliente Then
                    aTablas.Add(New TablaAEnviar("PLIBancario", "SELECT PLIId, PBEId as PLBId, FechaDeposito, TipoBanco, Referencia, Total,TipoCambio, Ficha, MFechaHora, '" & oVendedor.UsuarioId & "' as MUsuarioId, Enviado FROM PLBPLE WHERE (Enviado=0 or Enviado is null) and not TipoBanco is null", False))
                    aTablas.Add(New TablaAEnviar("PLIEfectivo", "SELECT PLIId, PBEId as PLEId, DenominacionID, Total as Cantidad, MFechaHora, '" & oVendedor.UsuarioId & "' as MUsuarioId, Enviado FROM PLBPLE WHERE (Enviado=0 or Enviado is null) and not TipoEfectivo is null", False))
                End If
                'TransProd
                aTablas.Add(New TablaAEnviar("TransProd", "select TransProdID,VisitaClave,DiaClave,VisitaClave1,DiaClave1,PCEPrecioClave,PCEModuloMovDetClave,PCEEsquemaId,SubEmpresaID,FacturaID,ClienteClave,ClientePagoID,CFVTipo,PLIId,Folio,Tipo,TipoPedido,TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura,FechaEntrega,FechaFacturacion,FechaSurtido,FechaCancelacion,TipoMotivo,SubTDetalle,DescVendPor,DescuentoVendedor,DescuentoImp,Subtotal,Impuesto,Total,Case When Saldo is null Then 0 else Saldo End-case When SaldoCarga is null Then 0 Else SaldoCarga End as Saldo,Promocion,Descuento,MonedaID,TipoCambio,TipoTurno,FechaCobranza,DiasCredito,Notas,MFechaHora,MUsuarioID,Enviado from transprod WHERE Enviado=0 or Enviado is null", True))
                ' ProductoNegado
                aTablas.Add(New TablaAEnviar("ProductoNegado", "SELECT PRGId, TransProdId, ProductoClave, PromocionClave, ProductoClave1, TipoUnidad, Cantidad, Saldo, TipoFasePRP, FechaFase, MFechaHora, MUsuarioId, Enviado FROM ProductoNegado WHERE Enviado=0 or Enviado is null"))
                'TransProd
                aTablas.Add(New TablaAEnviar("TransProdDetalle", "SELECT TransProdID,TransProdDetalleID,ProductoClave,DescuentoClave,PrgId,TipoUnidad,Partida,UnidadCobranza,Cantidad,Cantidad1,Factor, Factor1, Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,Promocion,PromocionClave,CodigoSKU, TipoMotivo, MFechaHora,MUsuarioID,Enviado FROM TransProdDetalle WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("TPDImpuesto", "SELECT TPDImpuesto.* FROM TPDImpuesto WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("TRPPrp", "SELECT TRPPrp.* FROM TRPPrp WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("TpdDes", "SELECT TpdDes.* FROM TpdDes WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("TpdDesVendedor", "SELECT TpdDesVendedor.* FROM TpdDesVendedor WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("TrpTpd", "SELECT TrpTpd.* FROM TrpTpd WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("TRPPedimento", "SELECT TRPP.* FROM TRPPedimento TRPP WHERE Enviado=0 or Enviado is null"))

                'Prestamos
                aTablas.Add(New TablaAEnviar("ProductoPrestamoCli", "SELECT ClienteClave,ProductoClave,saldo,SaldoCarga,MFechaHora,MUsuarioID,Enviado FROM ProductoPrestamoCli WHERE Enviado=0 or Enviado is null", True))
                'Abonos
                aTablas.Add(New TablaAEnviar("Abono", "select ABNId,Folio,FechaCreacion,VisitaClave,DiaClave,FechaAbono,Total,Saldo-case When SaldoCarga is null then 0 else SaldoCarga End as Saldo,MFechaHora,MUsuarioID,Enviado from abono WHERE Enviado=0 or Enviado is null", True))
                aTablas.Add(New TablaAEnviar("ABNDetalle", "select ABNDetalle.ABNId,ABDId,TipoPago,Importe,SaldoDeposito-case When ABNDetalle.SaldoCarga is null then 0 else ABNDetalle.SaldoCarga End as SaldoDeposito,MonedaID,TipoCambio,TipoBanco,Referencia,ABNDetalle.MFechaHora,ABNDetalle.MUsuarioID,Enviado from ABNDetalle WHERE Enviado=0 or Enviado is null", True))
                aTablas.Add(New TablaAEnviar("ABNTrp", "Select * from ABNTrp WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("AbdDep", "Select * from AbdDep WHERE Enviado=0 or Enviado is null"))
                'Abonos Programados
                aTablas.Add(New TablaAEnviar("AbonoProgramado", "Select ABPId,VisitaClave,DiaClave,FechaPromesa,Importe - Case When ImporteCarga is null then 0 Else ImporteCarga End as Importe,MFechaHora,MUsuarioID from AbonoProgramado WHERE Enviado=0 or Enviado is null", True))
                ' 
                ' Improductividad
                aTablas.Add(New TablaAEnviar("ImproductividadVenta", "SELECT * FROM ImproductividadVenta WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("ImproductividadProd", "SELECT * FROM ImproductividadProd WHERE Enviado=0 or Enviado is null"))
                ' Solicitud
                aTablas.Add(New TablaAEnviar("Solicitud", "SELECT * FROM Solicitud WHERE Enviado=0 or Enviado is null"))

                'Cuotas
                aTablas.Add(New TablaAEnviar("CuotaCumplida", "SELECT * FROM CuotaCumplida WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("CucCcu", "SELECT * FROM CucCcu WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("CupCcu", "SELECT * FROM CupCcu WHERE Enviado=0 or Enviado is null"))
                aTablas.Add(New TablaAEnviar("CueCcu", "SELECT * FROM CueCcu WHERE Enviado=0 or Enviado is null"))
                'Folios Reservacion
                aTablas.Add(New TablaAEnviar("FolioReservacion", "SELECT * FROM FolioReservacion WHERE Enviado = 0 or Enviado is null"))

                'PuntoGPS
                aTablas.Add(New TablaAEnviar("PuntoGPS", "SELECT PuntoGPSId, CoordenadaX, CoordenadaY, '" & oVendedor.VendedorId & "' as VendedorId, RUTClave, DiaClave, MFechaHora, MUsuarioId, Enviado FROM PuntoGPS WHERE Enviado=0 or Enviado is null"))

                'CamionVendedor
                aTablas.Add(New TablaAEnviar("CamionVendedor", "SELECT CAMVENId, Placa, '" & oVendedor.VendedorId & "' as VendedorId, FechaHoraInicial, KmInicial, FechaHoraFinal, KmFinal, MFechaHora, '" & oVendedor.UsuarioId & "' as MUsuarioId, Enviado FROM CamionVendedor where Enviado = 0 or Enviado is null"))

                If blnFacturasElectronicas Then
                    'TPRDatoFiscal
                    Dim sConsulta As String
                    sConsulta = "select TDF.TransProdId, TDF.FolioId, TDF.FOSId, FOF.NumCertificado, FOF.Serie, FOF.Aprobacion, FOF.AnioAprobacion, TDF.RazonSocial, TDF.RFC, TDF.TelefonoContacto, "
                    sConsulta &= "TDF.Calle, TDF.NumExt, TDF.NumInt, TDF.Colonia, TDF.CodigoPostal, TDF.ReferenciaDom, TDF.Localidad, TDF.Municipio, TDF.Entidad, TDF.Pais, "
                    sConsulta &= "TDF.CadenaOriginal, TDF.SelloDigital, TDF.TelefonoEm, TDF.RFCEm, TDF.NombreEm, TDF.CalleEm, TDF.NumExtEm, TDF.NumIntEm, TDF.ColoniaEm, "
                    sConsulta &= "TDF.LocalidadEm, TDF.ReferenciaDomEm, TDF.MunicipioEm, TDF.RegionEm, TDF.PaisEm, TDF.CodigoPostalEm, TDF.CalleEx, TDF.NumExtEx, TDF.NumIntEx, "
                    sConsulta &= "TDF.ColoniaEx, TDF.CodigoPostalEx, TDF.ReferenciaDomEx, TDF.LocalidadEx, TDF.MunicipioEx, TDF.EntidadEx, TDF.PaisEx, TDF.TipoVersion, TDF.TipoNotaCredito,  "
                    sConsulta &= " TDF.MetodoPago, TDF.CerBase64, TDF.LugarExpedicion, TDF.FormaDePago, TDF.NumCtaPago, TDF.Banco, TDF.DatFacturaEditados, TDF.MFechaHora, TDF.MUsuarioId, TDF.Enviado "
                    sConsulta &= "from TRPDatoFiscal TDF "
                    sConsulta &= "inner join FolioFiscal FOF on TDF.FolioId = FOF.FolioID and TDF.FOSId = FOF.FOSId "
                    sConsulta &= "where TDF.Enviado is null or TDF.Enviado = 0 "
                    aTablas.Add(New TablaAEnviar("TRPDatoFiscal", sConsulta))
                    'FolioFiscal
                    aTablas.Add(New TablaAEnviar("FolioFiscal", "Select FolioId, FOSId, FSHFechaInicio, Usados, Enviado from FolioFiscal where Enviado = 0 or Enviado is null"))
                    'TRPRegimenFiscal
                    aTablas.Add(New TablaAEnviar("TRPRegimenFiscal", "Select * from TRPRegimenFiscal WHERE Enviado=0 or Enviado is null"))
                End If
            Else
                'Solo enviar los Movimientos sin Inventario sin Visita
                aTablas.Add(New TablaAEnviar("TransProd", "select TransProdID,VisitaClave,DiaClave,VisitaClave1,DiaClave1,PCEPrecioClave,PCEModuloMovDetClave,PCEEsquemaId,FacturaID,ClienteClave,ClientePagoID,CFVTipo,PLIId,Folio,Tipo,TipoPedido,TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura,FechaEntrega,FechaFacturacion,FechaSurtido,FechaCancelacion,TipoMotivo,SubTDetalle,DescVendPor,DescuentoVendedor,DescuentoImp, Subtotal,Impuesto,Total,Case When Saldo is null Then 0 else Saldo End-case When SaldoCarga is null Then 0 Else SaldoCarga End as Saldo,Promocion,Descuento,TipoTurno,FechaCobranza,DiasCredito,Notas,MFechaHora,MUsuarioID,Enviado from TransProd WHERE Tipo = 19 and (Enviado=0 or Enviado is null)"))
                aTablas.Add(New TablaAEnviar("TransProdDetalle", "SELECT TransProdID,TransProdDetalleID,ProductoClave,DescuentoClave,PrgId,TipoUnidad,Partida,Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,Promocion,PromocionClave, MFechaHora,MUsuarioID,Enviado FROM TransProdDetalle WHERE TransProdId in (select TransProdID from TransProd WHERE Tipo = 19 and (Enviado=0 or Enviado is null)) and (Enviado=0 or Enviado is null)"))
                aTablas.Add(New TablaAEnviar("FolioReservacion", "select * from FolioReservacion where FolioId in (select FolioId from Folio where ModuloMovDetalleClave in (select ModuloMovDetalleClave from ModuloMovDetalle where TipoTransProd = 19 and TipoEstado = 1 and Baja = 0)) and (Enviado = 0 or Enviado is null)"))
            End If
            'Depósitos Garantía
            'If oDBVen.RealizarConsultaSQL("Select DepGarantia From ConHist", "DepGarantia").Rows(0)(0) Then
            '    aTablas.Add(New TablaAEnviar("DepositoGarantia", "SELECT * FROM DepositoGarantia WHERE Enviado=0 or Enviado is null"))
            'End If
            FormProcesando.FormProceso.ProgressBarAvance.Maximum = aTablas.Count
            Dim dsEnvio As New DataSet
            Dim i As Integer = 0
            FormProcesando.PubSubInformar(refparoVista.BuscarMensaje("Procesando", "Preparando"))
            FormProcesando.PubSubInformar(0)
            Dim iTotalRegistros As Integer = 0
            For Each refTablaAEnviar As TablaAEnviar In aTablas
                refTablaAEnviar.EjecutarConsulta(dsEnvio, iTotalRegistros)
                If refTablaAEnviar.sNombreTabla = "TRPDatoFiscal" And Not dsEnvio.Tables("TRPDatoFiscal") Is Nothing Then
                    dsEnvio.Tables("TRPDatoFiscal").PrimaryKey = New DataColumn() {dsEnvio.Tables("TRPDatoFiscal").Columns("TransProdId")}
                End If
                FormProcesando.PubSubInformar(i)
                i += 1
            Next
            If iTotalRegistros = 0 Then
                MsgBox(refparoVista.BuscarMensaje("MsgBox", "I0162"), MsgBoxStyle.Information)
                aTablas.Clear()
                aTablas = Nothing
                dsEnvio.Dispose()
                dsEnvio = Nothing
                Exit Try
            End If

            If blnLlamadaDesdeCliente Then
                If dsEnvio.Tables.Count = 1 Then
                    If dsEnvio.Tables(0).TableName.ToUpper = "PRELIQUIDACION" Then
                        MsgBox(refparoVista.BuscarMensaje("MsgBox", "I0162"), MsgBoxStyle.Information)
                        aTablas.Clear()
                        aTablas = Nothing
                        dsEnvio.Dispose()
                        dsEnvio = Nothing
                        Exit Try
                    End If
                End If
            End If

            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Me.Transaccion = oDBVen.oConexion.BeginTransaction()

            Dim dFechaPrimerDia As DateTime = oDBVen.EjecutarCmdScalarObjSQL("select min(fechaCaptura) from dia where FueraFrecuencia =0")

            bReintentar = True
            Dim bPrimeraVez As Boolean = True

            While bReintentar
                If System.IO.Directory.Exists([Global].ImagenEncuesta) Then
                    If ComprimirArchivo([Global].ImagenEncuesta) Then
                        oServicioWeb.WSObtenerArchivoZip(Me.LoadBinaryData([Global].ImagenEncuesta & ".zip"))
                    End If
                End If

                If Not bPrimeraVez Then
                    If MsgBox(sMensaje, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Me.Transaccion.Rollback()
                        Exit While
                    End If
                    Application.DoEvents()
                End If
                FormProcesando.PubSubInformar(refparoVista.BuscarMensaje("Procesando", "EnviandoInfo"))
                bPrimeraVez = False

                bEnProceso = True
                bFinalizoCorrecto = False

                Try
                    '[Global].ActualizarURLWebService()
                    'oServicioWeb.Timeout = (oApp.TimeOut * 60) * 1000
                    bFinalizoCorrecto = oServicioWeb.WSActualizarCaptura(oVendedor.VendedorId, dsEnvio, oVendedor.Fecha, dFechaPrimerDia, sMensaje, bReintentar)
                    If (sMensaje <> "") Then MsgBox(sMensaje, MsgBoxStyle.Information Or MsgBoxStyle.SystemModal, "EnviarCaptura")
                Catch ex As System.Net.WebException
                    bFalloConexion = True
                    If MsgBox(refparoVista.BuscarMensaje("MsgBox", "P0102"), MsgBoxStyle.YesNo, "EnviarCaptura") = MsgBoxResult.No Then
                        'If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                        bReintentar = False
                        Me.Transaccion.Rollback()
                    Else
                        bReintentar = True
                        bPrimeraVez = True
                    End If
                Finally
                    Application.DoEvents()
                End Try
                sMensaje = sMensajeEnd

                If bFinalizoCorrecto Then
                    Application.DoEvents()

                    If bEnviarJornada Then
                        For Each refTablaAEnviar As TablaAEnviar In aTablas
                            If refTablaAEnviar.bSaldos Then
                                Select Case refTablaAEnviar.sNombreTabla.ToUpper
                                    Case "TRANSPROD", "ABONO"
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1,SaldoCarga=Saldo WHERE Enviado IS NULL or Enviado=0")
                                    Case "CLIENTE"
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1,SaldoEfectivoCarga=SaldoEfectivo WHERE Enviado IS NULL or Enviado=0")
                                    Case "ABNDETALLE"
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1,SaldoCarga=SaldoDeposito WHERE Enviado IS NULL or Enviado=0")
                                    Case "PRODUCTOPRESTAMOCLI"
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1 WHERE Enviado IS NULL or Enviado=0")
                                    Case "ABONOPROGRAMADO"
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1,ImporteCarga=Importe WHERE Enviado IS NULL or Enviado=0")
                                    Case "PUNTO"
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1,SaldoCarga=Saldo,Saldo1Carga=Saldo1,VentaCarga = Venta WHERE Enviado IS NULL or Enviado=0")
                                End Select
                            ElseIf refTablaAEnviar.bTieneCampoEnviado Then
                                Select Case refTablaAEnviar.sNombreTabla.ToUpper
                                    Case "VENDEDORJORNADA"
                                        oDBVen.EjecutarComandoSQL("UPDATE VendedorJornada SET Enviado=1 WHERE (Enviado IS NULL or Enviado=0) and not FechaFinal is null ")
                                    Case "PLIBANCARIO"
                                        If Not blnLlamadaDesdeCliente Then
                                            oDBVen.EjecutarComandoSQL("UPDATE PLBPLE SET Enviado = 1 WHERE (Enviado IS NULL OR Enviado = 0) AND NOT TipoBanco IS NULL ")
                                        End If
                                    Case "PLIEFECTIVO"
                                        If Not blnLlamadaDesdeCliente Then
                                            oDBVen.EjecutarComandoSQL("UPDATE PLBPLE SET Enviado = 1 WHERE (Enviado IS NULL OR Enviado = 0) AND NOT TipoEfectivo IS NULL ")
                                        End If
                                    Case "PRELIQUIDACION"
                                        If Not blnLlamadaDesdeCliente Then
                                            oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1 WHERE Enviado IS NULL or Enviado=0")
                                        End If
                                    Case Else
                                        oDBVen.EjecutarComandoSQL("UPDATE " & refTablaAEnviar.sNombreTabla & " SET Enviado=1 WHERE Enviado IS NULL or Enviado=0")
                                End Select
                            End If
                        Next
                    Else
                        'Actualizar los datos de Movimientos sin Inventario sin Visita
                        oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle SET Enviado = 1 WHERE TransProdId IN (SELECT TransProdId FROM TransProd WHERE Tipo = 19 AND (Enviado IS NULL OR Enviado = 0)) AND (Enviado IS NULL OR Enviado = 0)")
                        oDBVen.EjecutarComandoSQL("UPDATE TransProd SET Enviado = 1 WHERE Tipo = 19 AND (Enviado IS NULL OR Enviado = 0)")
                        oDBVen.EjecutarComandoSQL("UPDATE FolioReservacion SET Enviado = 1 WHERE FolioId IN (SELECT FolioId FROM Folio WHERE ModuloMovDetalleClave IN (SELECT ModuloMovDetalleClave FROM ModuloMovDetalle WHERE TipoTransProd = 19 AND TipoEstado = 1 AND Baja = 0)) AND (Enviado = 0 OR Enviado IS NULL)")
                    End If

                    If System.IO.Directory.Exists([Global].ImagenEncuesta) Then
                        System.IO.Directory.Delete([Global].ImagenEncuesta, True)
                    End If
                    If System.IO.File.Exists([Global].ImagenEncuesta & ".zip") Then
                        System.IO.File.Delete([Global].ImagenEncuesta & ".zip")
                    End If

                    refparsMensaje &= refparoVista.BuscarMensaje("MsgBox", "Todos") & vbLf & vbCr

                    If bFoliosDuplicados Then
                        refparsMensaje &= refparoVista.BuscarMensaje("MsgBox", "I0180") & vbLf & vbCr
                    End If

                    refparsMensaje &= sMensaje

                    Me.Transaccion.Commit()
                    Me.Transaccion.Dispose()
                    Me.Transaccion = Nothing
                   
                    sMensaje = ""
                    FormProcesando.PubSubInformar(refparoVista.BuscarMensaje("Procesando", "EnvInt"))

                    Dim bReintentoInterfaz As Boolean = False

                    Do
                        bReintentoInterfaz = False

                        Try
                            If Not oServicioWeb.WSEjecutarInterfaces(oVendedor.VendedorId, oVendedor.Fecha, dFechaPrimerDia, sMensaje, bReintentar) Then
                                MsgBox(sMensaje, MsgBoxStyle.Exclamation)
                            End If
                        Catch ex As System.Net.WebException
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            If MsgBox(refparoVista.BuscarMensaje("Procesando", "EnvIntR"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                bReintentoInterfaz = True
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            bReintentoInterfaz = False
                            'If MsgBox(refparoVista.BuscarMensaje("Procesando", "EnvInt"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            '    bReintentoInterfaz = True
                            'End If
                        End Try

                    Loop While bReintentoInterfaz

                    'oServicioWeb.TerminarSession()
                    aTablas.Clear()
                    aTablas = Nothing
                    dsEnvio.Dispose()
                    dsEnvio = Nothing

                    If bEnviarJornada Then
                        oVendedor.ActualizarFecha()
                    End If

                    If Not blnLlamadaDesdeCliente Then
                        If Convert.ToBoolean(oConHist.Campos("EliminaEnviado")) Then
                            EliminarDatosEnviados()
                        End If
                    End If

                    Return True
                Else
                    If Not bReintentar And Not bFalloConexion Then
                        refparsMensaje &= refparoVista.BuscarMensaje("MsgBox", "NoTodos") & vbLf & vbCr & vbLf & vbCr & sMensaje
                        refparsMensaje &= sMensaje
                        'MensajeAArchivo(sMensaje)
                        Me.Transaccion.Rollback()
                        'oServicioWeb.TerminarSession()
                    End If
                End If
            End While
            aTablas.Clear()
            aTablas = Nothing
            dsEnvio.Dispose()
            dsEnvio = Nothing

        Catch ex As System.Net.WebException
            If Not Me.Transaccion Is Nothing Then
                Me.Transaccion.Rollback()
            End If
            MsgBox(refparoVista.BuscarMensaje("MsgBox", "F0008"), MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EnviarCaptura")
        Catch ex As System.Net.Sockets.SocketException
            If Not Me.Transaccion Is Nothing Then
                Me.Transaccion.Rollback()
            End If
            MsgBox(refparoVista.BuscarMensaje("MsgBox", "F0008"), MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EnviarCaptura")
        Catch ex As System.Web.Services.Protocols.SoapException
            If Not Me.Transaccion Is Nothing Then
                Me.Transaccion.Rollback()
            End If
            If ex.Code.Name = "SQLCON" Then
                MsgBox(" '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical, "EnviarCaptura")
            Else
                MsgBox(refparoVista.BuscarMensaje("MsgBox", "F0008"), MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EnviarCaptura")
            End If

        Catch ex As Exception
            If Not Me.Transaccion Is Nothing Then
                Me.Transaccion.Rollback()
            End If
            If sMensaje = String.Empty Then
                MsgBox(refparoVista.BuscarMensaje("MsgBox", "MDBConexion"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal, "EnviarCaptura")
            Else
                MsgBox(sMensaje, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EnviarCaptura")
            End If
        End Try
        If Not IsNothing(Me.Transaccion) Then
            Me.Transaccion.Dispose()
            Me.Transaccion = Nothing
        End If

        Return False
    End Function

    Private Function ValidarEnviarJornada() As Boolean
        Dim refCheckBox As Resco.Controls.DetailView.ItemCheckBox
        For Each refCheckBox In DetailViewEnviar.Items
            If refCheckBox.Tag = 1 And refCheckBox.Checked Then
                Return True
            End If
        Next
        Return False
    End Function

    'Private Sub EndActualizarCaptura(ByVal AsyRes As IAsyncResult)
    '    Try
    '        sMensajeEnd = ""
    '        oServicioWeb = AsyRes.AsyncState
    '        bFinalizoCorrecto = oServicioWeb.EndWSActualizarCaptura(AsyRes, sMensajeEnd, bReintentar)
    '        bEnProceso = False
    '    Catch ex As Exception
    '        bFinalizoCorrecto = False
    '    End Try
    'End Sub

    'Private Sub MensajeAArchivo(ByVal sMensaje As String)
    '    Dim oFile As New IO.FileStream("IPSM/Route/log.txt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
    '    Dim w As IO.StreamWriter = New IO.StreamWriter(oFile)
    '    w.BaseStream.Seek(0, IO.SeekOrigin.End)
    '    w.Write("Log Entry : {0}", vbCrLf)
    '    w.WriteLine("{0} {1}{2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), vbCrLf)
    '    w.WriteLine("{0}{1}", sMensaje, vbCrLf)
    '    w.Flush()
    '    oFile.Close()
    'End Sub

    Private Sub ProgressDelegate(ByVal sender As Object, ByVal name As String, ByVal percent As Integer)
        Application.DoEvents()
    End Sub

    Private Function LoadBinaryData(ByVal parNombreArchivo As String) As Byte()
        Using fs As IO.FileStream = New IO.FileStream(parNombreArchivo, IO.FileMode.Open)
            Dim br As IO.BinaryReader
            br = New IO.BinaryReader(fs)
            Dim bytesRead As Byte() = br.ReadBytes(fs.Length)
            fs.Close()
            Return bytesRead
        End Using
    End Function

    Private Function ComprimirArchivo(ByVal sNombreDirectorio As String) As Boolean
        If System.IO.File.Exists(sNombreDirectorio & ".zip") Then
            System.IO.File.Delete(sNombreDirectorio & ".zip")
        End If

        If System.IO.Directory.GetFiles(sNombreDirectorio).Length <= 0 Then
            Return False
        End If

        Dim zipArchive As New Resco.IO.Zip.ZipArchive(sNombreDirectorio & ".zip", Resco.IO.Zip.ZipArchiveMode.Create, IO.FileShare.None)
        If zipArchive Is Nothing Then
            Return False
        End If

        zipArchive.AutoUpdate = True
        For Each archivo As String In System.IO.Directory.GetFiles(sNombreDirectorio)
            zipArchive.Add(archivo, "\", True, AddressOf ProgressDelegate)
        Next

        zipArchive.Close()
        Return True
    End Function

    Public Sub EndObtenerVendedorBD(ByVal byteArchivo As Byte(), ByVal sMensaje As String)

        Try
            Dim NombreArchivoSDF As String = oVendedor.UsuarioId & ".sdf"
            Dim sNombreArchivoZip As String = NombreArchivoSDF.Replace(".sdf", ".zip")

            bEnProceso = False
            bDescompactando = True
            If byteArchivo Is Nothing Or sMensaje <> "" Then
                MsgBox(sMensaje, MsgBoxStyle.Critical)
                Application.DoEvents()
                bDescompactando = False
                bFinalizoCorrecto = False
                Exit Sub
            End If
            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoZip) Then
                System.IO.File.Delete(oApp.RutaTrabajo & "\" & sNombreArchivoZip)
            End If

            Dim fsBD As IO.FileStream
            fsBD = New IO.FileStream(oApp.RutaTrabajo & "\" & sNombreArchivoZip, IO.FileMode.CreateNew, IO.FileAccess.Write)
            fsBD.Write(byteArchivo, 0, byteArchivo.Length)
            fsBD.Close()

            'Descompactar el archivo zip ups ver cuanto se tarda.
            Dim zipC1 As Resco.IO.Zip.ZipArchive

            zipC1 = New Resco.IO.Zip.ZipArchive(oApp.RutaTrabajo & "\" & sNombreArchivoZip, Resco.IO.Zip.ZipArchiveMode.Open, System.IO.FileShare.None)
            zipC1.Extract("\", oApp.RutaTrabajo, Nothing)
            zipC1.Close()

            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoZip) Then
                System.IO.File.Delete(oApp.RutaTrabajo & "\" & sNombreArchivoZip)
            End If

            'Reparto de mercancia
            SKUInventario.CargarSKUInventarioReparto()
            'Cargas
            Dim dInicio As Date
            dInicio = Now
            SKUInventario.CargarSKUInventarioCargas()
            
            oVendedor.ActualizarFecha()
            bDescompactando = False
            bFinalizoCorrecto = True
        Catch ex As System.Net.WebException
            bDescompactando = False
            bFinalizoCorrecto = False
        Catch ex1 As Exception
            MsgBox(ex1.GetBaseException.GetType.ToString() & " '" & ex1.GetBaseException.Message & "'", MsgBoxStyle.OkOnly And MsgBoxStyle.Critical, "EndObtenerVendedorBD")
            bDescompactando = False
            bFinalizoCorrecto = False
            'MsgBox("En ObtenerVendedorBD " & vbCrLf & ex.Message)
            'Throw ex
        End Try
    End Sub

    Private Sub ObtenerBD()
        'Dim NombreArchivoSDF As String = oVendedor.UsuarioId & ".sdf"
        'Dim sNombreArchivoZip As String = NombreArchivoSDF.Replace(".sdf", ".zip")

        'Dim blnCanjes As Boolean = False
        Dim blnReparto As Boolean = False
        'Dim byteArchivo As Byte()


        Dim sTipoConsultas As String = String.Empty
        bCanjes = False
        If CheckBoxCanjes.Checked = True Then
            bCanjes = True
            sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Canjes & ","
        End If
        sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Prestamos & ","
        sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Cargas & ","
        sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Consignacion

        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0031"), refaVista.BuscarMensaje("MsgBoxConexion", "CreandoTablas"))
        FormProcesando.PubSubEstado("")
        Dim sMensaje As String = String.Empty
        If oDBVen.oConexion.State = ConnectionState.Open Then
            oDBVen.oConexion.Close()
        End If
        Dim bObtenerBD As Boolean = True
        While bObtenerBD
            FormProcesando.PubSubEstado("")
            bEnProceso = True
            bFinalizoCorrecto = False
            Try
                [Global].IniciarWS()
                oServicioWeb.Timeout = (oApp.TimeOut * 60) * 1000
                Dim Mensaje As String = ""
                Dim Verificar As String = oServicioWeb.WSVerificarVendedorObtenerBD(Mensaje)
                If Verificar = "" Then
                    Dim res As Byte() = oServicioWeb.WSVendedorObtenerBD(oApp.ClaveTerminal, oApp.Usuario.Clave, oApp.Contrasena, PrimeraHora(oDBVen.FechaIni), UltimaHora(oDBVen.FechaFin), sTipoConsultas, sMensaje)
                    'oServicioWeb.TerminarSession()
                    EndObtenerVendedorBD(res, sMensaje)
                    bObtenerBD = False
                    FormProcesando.PubSubInformar()
                Else
                    If Verificar = "P0202" Then
                        If MsgBox(Mensaje, MsgBoxStyle.YesNo, Verificar) = MsgBoxResult.Yes Then
                            Dim res As Byte() = oServicioWeb.WSVendedorObtenerBD(oApp.ClaveTerminal, oApp.Usuario.Clave, oApp.Contrasena, PrimeraHora(oDBVen.FechaIni), UltimaHora(oDBVen.FechaFin), sTipoConsultas, sMensaje)
                            'oServicioWeb.TerminarSession()
                            EndObtenerVendedorBD(res, sMensaje)

                            FormProcesando.PubSubInformar()
                        Else
                            Application.DoEvents()
                            bDescompactando = False
                        End If
                        bObtenerBD = False
                    End If
                End If
            Catch ex As System.Net.WebException
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0102"), MsgBoxStyle.YesNo, "ObtenerBD") = MsgBoxResult.No Then
                    bObtenerBD = False
                End If
                Application.DoEvents()
                bDescompactando = False
            End Try
            While bDescompactando
            End While
        End While
    End Sub

    Private Function ValidarOpcionesSeleccionadas() As Boolean
        Dim refCheckBox As Resco.Controls.DetailView.ItemCheckBox
        For Each refCheckBox In DetailViewRecibir.Items
            If refCheckBox.Checked Then
                Return True
            End If
        Next
        Return False
    End Function

    '    Private Sub btnConexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConexion.Click
    '#If SO_WCE = 0 Then

    '        '--Desconectar si se conecto
    '        If Conectado Then

    '            For Each Destino As OpenNETCF.Net.DestinationInfo In connMgr.EnumDestinations
    '                Dim str As String = String.Empty
    '                str = Destino.Description.Trim

    '                If str.Trim.IndexOf(Me.cboConexion.Text.Trim) = 0 Then
    '                    Try

    '                        connMgr1.CONN_Connect(Destino.Guid)
    '                        Dim contIntentos As Integer = 0


    '                        While Not (connMgr1.CONN_IsConnected() = WANSample.Conn.CONNECTIONSTATUS.CONNMGR_STATUS_CONNECTED Or contIntentos < 5)

    '                            System.Threading.Thread.Sleep(1000)
    '                            contIntentos += 1

    '                        End While

    '                        '--Enviar los datos al server
    '                        EnviarRecibirInformacion()

    '                        '--Cuando termine de Enviar los datos cerrar la conexion
    '                        System.Threading.Thread.Sleep(500)

    '                        '--Desconectar
    '                        connMgr1.CONN_Disconnect()

    '                    Catch ex As Exception
    '                        MsgBox(ex.Message)
    '                        Conectado = False
    '                        Me.PanelConexion.Visible = False
    '                        Me.Panel1.Visible = True
    '                        oApp.DesactivarWiFi()
    '                        TabControlComunicacion.Enabled = True
    '                        Me.Refresh()
    '                    End Try

    '                    Exit For
    '                End If

    '            Next

    '        End If

    '#Else

    '        '--Conexión para la 7600
    '        Try
    '            Me.Enabled = False
    '            Cursor.Current = Cursors.WaitCursor

    '            hhpConn = New HHP.WinCE.Network.RAS

    '            ' Usar un DataSet para leer el contenido del archivo XML
    '            Dim DataSetConfig As New DataSet("Config")
    '            Dim refDataTableConfig As DataTable
    '            Dim refDataRowActual As DataRow

    '            DataSetConfig.ReadXml(PubcArchivoConfig)
    '            refDataTableConfig = DataSetConfig.Tables("Conexiones")

    '            If Not IsNothing(refDataTableConfig) Then
    '                For Each refDataRowActual In refDataTableConfig.Rows
    '                    If cboConexion.Text.Equals(refDataRowActual.Item("Nombre")) Then
    '                        If hhpConn.EntryExists(Me.cboConexion.Text) Then
    '                            hhpConn.Dial(Me.cboConexion.Text, refDataRowActual("User"), refDataRowActual("Password"))
    '                        Else
    '                            MsgBox("La conexion seleccionada no esta configurada", MsgBoxStyle.Critical)
    '                        End If
    '                    End If
    '                Next
    '            End If

    '            refDataTableConfig.Dispose()

    '        Catch ex As Exception
    '            MsgBox(refaVista.BuscarMensaje("MsgBox", "MDBConexion"), MsgBoxStyle.Critical)
    '            Me.Enabled = True
    '            Cursor.Current = Cursors.Default
    '            Conectado = False
    '            Me.PanelConexion.Visible = False
    '            Me.Panel1.Visible = True
    '            oApp.DesactivarWiFi()
    '            TabControlComunicacion.Enabled = True
    '            Me.Refresh()
    '        End Try
    '#End If
    '        Me.PanelConexion.Visible = False
    '        Me.Panel1.Visible = True
    '    End Sub

    Private Sub btnDesconectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesconectar.Click
        Try
            connMgr1.CONN_Disconnect()
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Conectado = False
        Me.PanelConexion.Visible = False
        Me.Panel1.Visible = True
    End Sub

    '#If MOD_TERM = "HHP" Then
    '    Private Sub hhpConn_StatusChanged(ByVal sender As Object, ByVal e As HHP.WinCE.Network.RAS.StatusChangedEventArgs) Handles hhpConn.StatusChanged
    '        If e.connstate = HHP.WinCE.Network.RAS.ConnState.RASCS_Connected Then
    '            Try
    '                blnHuboConexion = True
    '                If Me.TabControlTransferir.TabPages.Count = 3 Then
    '                    If Me.TabControlTransferir.SelectedIndex = indexTabEnviarDatos Then
    '                        Cursor.Current = Cursors.Default
    '                        EnviarDatos()
    '                    ElseIf Me.TabControlTransferir.SelectedIndex = indexTabAgenda Then
    '                        Cursor.Current = Cursors.Default
    '                        oDBVen.Grupo = 0
    '                        oDBVen.FechaIni = Me.DateTimeFechaInicio.Value
    '                        oDBVen.FechaFin = Me.DateTimeFechaFin.Value
    '                        If oDBVen.FechaIni > oDBVen.FechaFin Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0008"))
    '                            TabControlComunicacion.Enabled = True
    '                            Me.Refresh()
    '                            Exit Sub
    '                        End If

    '                        Try
    '                            ObtenerBD()
    '                            If bFinalizoCorrecto Then
    '                                oVendedor.RecuperarParametros(False)
    '                            End If
    '                        Catch ex As Exception
    '                            MsgBox(ex.Message)
    '                            FormProcesando.PubSubInformar()
    '                        End Try
    '                    ElseIf Me.TabControlTransferir.SelectedIndex = indexTabRecibirDatos Then
    '                        Cursor.Current = Cursors.Default
    '                        RecibirDatos()
    '                    End If
    '                Else
    '                    Cursor.Current = Cursors.Default
    '                    RecibirDatos()
    '                End If

    '                System.Threading.Thread.Sleep(100)
    '                '--Desconectar
    '                hhpConn.HangUp()

    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try

    '            Conectado = False

    '        ElseIf e.connstate = HHP.WinCE.Network.RAS.ConnState.RASCS_Disconnected Then
    '            Cursor.Current = Cursors.Default
    '            If Not blnHuboConexion Then
    '                MsgBox(refaVista.BuscarMensaje("MsgBox", "MDBConexion"), MsgBoxStyle.Exclamation)
    '            End If
    '            Me.Enabled = True

    '        End If
    '        Me.PanelConexion.Visible = False
    '        Me.Panel1.Visible = True
    '    End Sub
    '#End If

    Private Sub DetailViewEnviar_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewEnviar.ItemChanged
        If e.item.Tag <> 1 And e.item.Tag <> 2 Then Exit Sub
        Select Case e.item.Tag
            Case 1
                If CType(e.item, Resco.Controls.DetailView.ItemCheckBox).Checked Then
                    CType(DetailViewEnviar.Items("CheckBoxActividades"), Resco.Controls.DetailView.ItemCheckBox).Checked = False
                Else
                    CType(DetailViewEnviar.Items("CheckBoxActividades"), Resco.Controls.DetailView.ItemCheckBox).Checked = True
                End If
            Case 2
                If CType(DetailViewEnviar.Items("CheckBoxActividades"), Resco.Controls.DetailView.ItemCheckBox).Checked Then
                    CType(DetailViewEnviar.Items("CheckBoxMovSinInv"), Resco.Controls.DetailView.ItemCheckBox).Checked = True
                    CType(DetailViewEnviar.Items("CheckBoxJornada"), Resco.Controls.DetailView.ItemCheckBox).Checked = False
                Else
                    CType(DetailViewEnviar.Items("CheckBoxMovSinInv"), Resco.Controls.DetailView.ItemCheckBox).Checked = False
                    CType(DetailViewEnviar.Items("CheckBoxJornada"), Resco.Controls.DetailView.ItemCheckBox).Checked = True
                End If
        End Select
    End Sub


    Private Sub TabControlComunicacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlComunicacion.SelectedIndexChanged
        If TabControlComunicacion.SelectedIndex = 2 Or TabControlComunicacion.SelectedIndex = 1 Then
            ButtonAceptar.Parent = TabControlComunicacion.TabPages(TabControlComunicacion.SelectedIndex)
            ButtonCancelar.Parent = TabControlComunicacion.TabPages(TabControlComunicacion.SelectedIndex)
            ButtonAceptar.BringToFront()
            ButtonCancelar.BringToFront()
        End If
    End Sub

    Private Sub DetailViewConfiguracion_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewConfiguracion.ItemChanged
        If e.Name = "TextBoxContraseniaAseguramiento" Then
            If e.item.Text = oApp.ContraseniaAseguramiento Then
                DetailViewConfiguracion.Items("CheckBoxAseguramientoVisita").Visible = True
            Else
                DetailViewConfiguracion.Items("CheckBoxAseguramientoVisita").Visible = False
            End If
        End If

    End Sub
End Class
