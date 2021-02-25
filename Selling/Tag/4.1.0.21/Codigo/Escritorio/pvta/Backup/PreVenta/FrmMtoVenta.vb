Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmMtoVenta
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
    Friend WithEvents cmbDiaTrabajo As System.Windows.Forms.DateTimePicker


    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtUsuarioNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label

    Friend WithEvents TxtClavePdV As System.Windows.Forms.TextBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label

    Friend WithEvents TxtNombrePdV As System.Windows.Forms.TextBox

    Friend WithEvents TabGeneral As Janus.Windows.UI.Tab.UITab
    Friend WithEvents GridMovAlm As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpMovAlm As System.Windows.Forms.GroupBox
    Friend WithEvents grpMovAlmDet As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents tabTransacciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tabCobranza As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbFormaVenta As Selling.StoreCombo
    Friend WithEvents GridCxC As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalirCxC As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblFormaVenta As System.Windows.Forms.Label
    Friend WithEvents LblVencimiento As System.Windows.Forms.Label
    Friend WithEvents cmbVencimiento As Selling.StoreCombo
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents lblFormVent As System.Windows.Forms.Label
    Friend WithEvents LblVenc As System.Windows.Forms.Label
    Friend WithEvents cmbVenc As Selling.StoreCombo
    Friend WithEvents BtnSalirTrans As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbFormVent As Selling.StoreCombo
    Friend WithEvents GridTransaccion As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridResumen As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GridAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GridLiquidacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblIngresos As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblLiquidado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTotalAbonos As System.Windows.Forms.Label
    Friend WithEvents LblTotalLiquidar As System.Windows.Forms.Label
    Friend WithEvents LblEgresos As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionProd As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionVta As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblTotalComision As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalirLiq As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMovAlmDet As Janus.Windows.GridEX.GridEX

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoVenta))
        Me.cmbDiaTrabajo = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.TxtUsuarioNombre = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClavePdV = New System.Windows.Forms.TextBox
        Me.LblTipo = New System.Windows.Forms.Label
        Me.TxtNombrePdV = New System.Windows.Forms.TextBox
        Me.TabGeneral = New Janus.Windows.UI.Tab.UITab
        Me.tabTransacciones = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton
        Me.BtnNuevo = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnSend = New Janus.Windows.EditControls.UIButton
        Me.BtnReimprimir = New Janus.Windows.EditControls.UIButton
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.lblFormVent = New System.Windows.Forms.Label
        Me.LblVenc = New System.Windows.Forms.Label
        Me.BtnSalirTrans = New Janus.Windows.EditControls.UIButton
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.GridTransaccion = New Janus.Windows.GridEX.GridEX
        Me.cmbTipo = New Selling.StoreCombo
        Me.cmbVenc = New Selling.StoreCombo
        Me.cmbFormVent = New Selling.StoreCombo
        Me.tabCobranza = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.LblFormaVenta = New System.Windows.Forms.Label
        Me.LblVencimiento = New System.Windows.Forms.Label
        Me.BtnSalirCxC = New Janus.Windows.EditControls.UIButton
        Me.BtnPago = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GridCxC = New Janus.Windows.GridEX.GridEX
        Me.cmbVencimiento = New Selling.StoreCombo
        Me.cmbFormaVenta = New Selling.StoreCombo
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.grpMovAlmDet = New System.Windows.Forms.GroupBox
        Me.GridMovAlmDet = New Janus.Windows.GridEX.GridEX
        Me.grpMovAlm = New System.Windows.Forms.GroupBox
        Me.GridMovAlm = New Janus.Windows.GridEX.GridEX
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GridResumen = New Janus.Windows.GridEX.GridEX
        Me.LblTotalComision = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GridComisionProd = New Janus.Windows.GridEX.GridEX
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GridComisionVta = New Janus.Windows.GridEX.GridEX
        Me.BtnSalirLiq = New Janus.Windows.EditControls.UIButton
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.LblLiquidado = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.LblTotalAbonos = New System.Windows.Forms.Label
        Me.LblTotalLiquidar = New System.Windows.Forms.Label
        Me.LblEgresos = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblIngresos = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GridLiquidacion = New Janus.Windows.GridEX.GridEX
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton
        CType(Me.TabGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGeneral.SuspendLayout()
        Me.tabTransacciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTransaccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCobranza.SuspendLayout()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovAlmDet.SuspendLayout()
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovAlm.SuspendLayout()
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbDiaTrabajo
        '
        Me.cmbDiaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbDiaTrabajo.Location = New System.Drawing.Point(85, 16)
        Me.cmbDiaTrabajo.Name = "cmbDiaTrabajo"
        Me.cmbDiaTrabajo.Size = New System.Drawing.Size(88, 20)
        Me.cmbDiaTrabajo.TabIndex = 42
        Me.cmbDiaTrabajo.Value = New Date(2012, 4, 13, 12, 36, 31, 0)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 328)
        Me.Panel1.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(178, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "Punto de Venta"
        '
        'TxtUsuarioNombre
        '
        Me.TxtUsuarioNombre.Location = New System.Drawing.Point(85, 45)
        Me.TxtUsuarioNombre.Name = "TxtUsuarioNombre"
        Me.TxtUsuarioNombre.ReadOnly = True
        Me.TxtUsuarioNombre.Size = New System.Drawing.Size(432, 20)
        Me.TxtUsuarioNombre.TabIndex = 5
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(8, 46)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(54, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Vendedor"
        '
        'TxtClavePdV
        '
        Me.TxtClavePdV.Location = New System.Drawing.Point(269, 16)
        Me.TxtClavePdV.Name = "TxtClavePdV"
        Me.TxtClavePdV.ReadOnly = True
        Me.TxtClavePdV.Size = New System.Drawing.Size(47, 20)
        Me.TxtClavePdV.TabIndex = 7
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(9, 19)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(83, 15)
        Me.LblTipo.TabIndex = 61
        Me.LblTipo.Text = "Día de Trabajo"
        '
        'TxtNombrePdV
        '
        Me.TxtNombrePdV.Location = New System.Drawing.Point(321, 16)
        Me.TxtNombrePdV.Name = "TxtNombrePdV"
        Me.TxtNombrePdV.ReadOnly = True
        Me.TxtNombrePdV.Size = New System.Drawing.Size(196, 20)
        Me.TxtNombrePdV.TabIndex = 81
        '
        'TabGeneral
        '
        Me.TabGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabGeneral.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.TabGeneral.Location = New System.Drawing.Point(6, 73)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Size = New System.Drawing.Size(773, 400)
        Me.TabGeneral.TabIndex = 44
        Me.TabGeneral.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tabTransacciones, Me.tabCobranza})
        Me.TabGeneral.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tabTransacciones
        '
        Me.tabTransacciones.Controls.Add(Me.GroupBox1)
        Me.tabTransacciones.Location = New System.Drawing.Point(1, 21)
        Me.tabTransacciones.Name = "tabTransacciones"
        Me.tabTransacciones.Size = New System.Drawing.Size(771, 378)
        Me.tabTransacciones.TabStop = True
        Me.tabTransacciones.Text = "Transacciones"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.BtnDevolucion)
        Me.GroupBox1.Controls.Add(Me.BtnFacturar)
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Controls.Add(Me.BtnCancelar)
        Me.GroupBox1.Controls.Add(Me.BtnSend)
        Me.GroupBox1.Controls.Add(Me.BtnReimprimir)
        Me.GroupBox1.Controls.Add(Me.BtnConsultar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.lblFormVent)
        Me.GroupBox1.Controls.Add(Me.BtnSalirTrans)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.ChkTodos)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.GridTransaccion)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.cmbVenc)
        Me.GroupBox1.Controls.Add(Me.cmbFormVent)
        Me.GroupBox1.Controls.Add(Me.LblVenc)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(1, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(770, 372)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transacciones"
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Image = CType(resources.GetObject("BtnDevolucion.Image"), System.Drawing.Image)
        Me.BtnDevolucion.Location = New System.Drawing.Point(481, 329)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(90, 37)
        Me.BtnDevolucion.TabIndex = 88
        Me.BtnDevolucion.Text = "Devolución"
        Me.BtnDevolucion.ToolTipText = "Crear Devolución"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFacturar.Image = CType(resources.GetObject("BtnFacturar.Image"), System.Drawing.Image)
        Me.BtnFacturar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnFacturar.Location = New System.Drawing.Point(577, 329)
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(90, 37)
        Me.BtnFacturar.TabIndex = 87
        Me.BtnFacturar.Text = "Facturar"
        Me.BtnFacturar.ToolTipText = "Crear nueva factura de registros seleccionados"
        Me.BtnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.Location = New System.Drawing.Point(673, 328)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 37)
        Me.BtnNuevo.TabIndex = 86
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.ToolTipText = "Crea una nuevo registro"
        Me.BtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(289, 329)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 85
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.Visible = False
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSend.Icon = CType(resources.GetObject("BtnSend.Icon"), System.Drawing.Icon)
        Me.BtnSend.Location = New System.Drawing.Point(577, 329)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 37)
        Me.BtnSend.TabIndex = 84
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.ToolTipText = "Envio por correo electrónico"
        Me.BtnSend.Visible = False
        Me.BtnSend.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimprimir
        '
        Me.BtnReimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimprimir.Icon = CType(resources.GetObject("BtnReimprimir.Icon"), System.Drawing.Icon)
        Me.BtnReimprimir.Location = New System.Drawing.Point(481, 328)
        Me.BtnReimprimir.Name = "BtnReimprimir"
        Me.BtnReimprimir.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimprimir.TabIndex = 83
        Me.BtnReimprimir.Text = "Reimprimir"
        Me.BtnReimprimir.ToolTipText = "Reimpresión de documentos"
        Me.BtnReimprimir.Visible = False
        Me.BtnReimprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnConsultar.Location = New System.Drawing.Point(385, 329)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 82
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.ToolTipText = "Muestra documento seleccionado"
        Me.BtnConsultar.Visible = False
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(181, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 14)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Tipo"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(224, 21)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 80
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'lblFormVent
        '
        Me.lblFormVent.Location = New System.Drawing.Point(364, 23)
        Me.lblFormVent.Name = "lblFormVent"
        Me.lblFormVent.Size = New System.Drawing.Size(87, 14)
        Me.lblFormVent.TabIndex = 78
        Me.lblFormVent.Text = "F. de Venta"
        '
        'LblVenc
        '
        Me.LblVenc.Location = New System.Drawing.Point(593, 23)
        Me.LblVenc.Name = "LblVenc"
        Me.LblVenc.Size = New System.Drawing.Size(58, 14)
        Me.LblVenc.TabIndex = 77
        Me.LblVenc.Text = "Venc."
        '
        'BtnSalirTrans
        '
        Me.BtnSalirTrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirTrans.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirTrans.Image = CType(resources.GetObject("BtnSalirTrans.Image"), System.Drawing.Image)
        Me.BtnSalirTrans.Location = New System.Drawing.Point(193, 329)
        Me.BtnSalirTrans.Name = "BtnSalirTrans"
        Me.BtnSalirTrans.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalirTrans.TabIndex = 52
        Me.BtnSalirTrans.Text = "&Salir"
        Me.BtnSalirTrans.ToolTipText = "Salir"
        Me.BtnSalirTrans.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(437, 24)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 39
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'ChkTodos
        '
        Me.ChkTodos.Enabled = False
        Me.ChkTodos.Location = New System.Drawing.Point(7, 22)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(68, 20)
        Me.ChkTodos.TabIndex = 49
        Me.ChkTodos.Text = "Todos"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(637, 23)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox4.TabIndex = 46
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'GridTransaccion
        '
        Me.GridTransaccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTransaccion.ColumnAutoResize = True
        Me.GridTransaccion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTransaccion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTransaccion.GroupByBoxVisible = False
        Me.GridTransaccion.Location = New System.Drawing.Point(7, 45)
        Me.GridTransaccion.Name = "GridTransaccion"
        Me.GridTransaccion.RecordNavigator = True
        Me.GridTransaccion.Size = New System.Drawing.Size(756, 277)
        Me.GridTransaccion.TabIndex = 4
        Me.GridTransaccion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipo.Location = New System.Drawing.Point(243, 17)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(115, 24)
        Me.cmbTipo.TabIndex = 79
        '
        'cmbVenc
        '
        Me.cmbVenc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbVenc.Location = New System.Drawing.Point(657, 20)
        Me.cmbVenc.Name = "cmbVenc"
        Me.cmbVenc.Size = New System.Drawing.Size(106, 24)
        Me.cmbVenc.TabIndex = 53
        '
        'cmbFormVent
        '
        Me.cmbFormVent.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormVent.Location = New System.Drawing.Point(457, 17)
        Me.cmbFormVent.Name = "cmbFormVent"
        Me.cmbFormVent.Size = New System.Drawing.Size(100, 24)
        Me.cmbFormVent.TabIndex = 1
        '
        'tabCobranza
        '
        Me.tabCobranza.Controls.Add(Me.GrpTickets)
        Me.tabCobranza.Location = New System.Drawing.Point(1, 21)
        Me.tabCobranza.Name = "tabCobranza"
        Me.tabCobranza.Size = New System.Drawing.Size(771, 378)
        Me.tabCobranza.TabStop = True
        Me.tabCobranza.Text = "Cobranza"
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.LblFormaVenta)
        Me.GrpTickets.Controls.Add(Me.LblVencimiento)
        Me.GrpTickets.Controls.Add(Me.BtnSalirCxC)
        Me.GrpTickets.Controls.Add(Me.BtnPago)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Controls.Add(Me.cmbVencimiento)
        Me.GrpTickets.Controls.Add(Me.cmbFormaVenta)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(2, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(769, 372)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cuentas por Cobrar"
        '
        'LblFormaVenta
        '
        Me.LblFormaVenta.Location = New System.Drawing.Point(152, 22)
        Me.LblFormaVenta.Name = "LblFormaVenta"
        Me.LblFormaVenta.Size = New System.Drawing.Size(104, 14)
        Me.LblFormaVenta.TabIndex = 78
        Me.LblFormaVenta.Text = "Forma de Venta"
        '
        'LblVencimiento
        '
        Me.LblVencimiento.Location = New System.Drawing.Point(382, 22)
        Me.LblVencimiento.Name = "LblVencimiento"
        Me.LblVencimiento.Size = New System.Drawing.Size(98, 14)
        Me.LblVencimiento.TabIndex = 77
        Me.LblVencimiento.Text = "Vencimiento"
        '
        'BtnSalirCxC
        '
        Me.BtnSalirCxC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirCxC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirCxC.Image = CType(resources.GetObject("BtnSalirCxC.Image"), System.Drawing.Image)
        Me.BtnSalirCxC.Location = New System.Drawing.Point(576, 332)
        Me.BtnSalirCxC.Name = "BtnSalirCxC"
        Me.BtnSalirCxC.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalirCxC.TabIndex = 52
        Me.BtnSalirCxC.Text = "&Salir"
        Me.BtnSalirCxC.ToolTipText = "Salir"
        Me.BtnSalirCxC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnPago
        '
        Me.BtnPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPago.Icon = CType(resources.GetObject("BtnPago.Icon"), System.Drawing.Icon)
        Me.BtnPago.Location = New System.Drawing.Point(672, 331)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(90, 37)
        Me.BtnPago.TabIndex = 51
        Me.BtnPago.Text = "Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago de registros seleccionados"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(365, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 22)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(123, 20)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(581, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 45)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(756, 281)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbVencimiento
        '
        Me.cmbVencimiento.BackColor = System.Drawing.SystemColors.Window
        Me.cmbVencimiento.Location = New System.Drawing.Point(485, 17)
        Me.cmbVencimiento.Name = "cmbVencimiento"
        Me.cmbVencimiento.Size = New System.Drawing.Size(91, 24)
        Me.cmbVencimiento.TabIndex = 53
        '
        'cmbFormaVenta
        '
        Me.cmbFormaVenta.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormaVenta.Location = New System.Drawing.Point(259, 17)
        Me.cmbFormaVenta.Name = "cmbFormaVenta"
        Me.cmbFormaVenta.Size = New System.Drawing.Size(100, 24)
        Me.cmbFormaVenta.TabIndex = 1
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(318, 335)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(108, 32)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nuevo transferencia"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(431, 335)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(108, 32)
        Me.BtnModificar.TabIndex = 16
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar transferencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(543, 335)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(108, 32)
        Me.BtnEliminar.TabIndex = 15
        Me.BtnEliminar.Text = "&Salir"
        Me.BtnEliminar.ToolTipText = "Cancelar transferencia seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(205, 335)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(108, 32)
        Me.BtnReimpresion.TabIndex = 14
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de transferencia seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(657, 335)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(108, 32)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grpMovAlmDet
        '
        Me.grpMovAlmDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMovAlmDet.Controls.Add(Me.GridMovAlmDet)
        Me.grpMovAlmDet.Location = New System.Drawing.Point(234, 1)
        Me.grpMovAlmDet.Name = "grpMovAlmDet"
        Me.grpMovAlmDet.Size = New System.Drawing.Size(534, 331)
        Me.grpMovAlmDet.TabIndex = 5
        Me.grpMovAlmDet.TabStop = False
        Me.grpMovAlmDet.Text = "Detalle"
        '
        'GridMovAlmDet
        '
        Me.GridMovAlmDet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMovAlmDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMovAlmDet.ColumnAutoResize = True
        Me.GridMovAlmDet.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMovAlmDet.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMovAlmDet.GroupByBoxVisible = False
        Me.GridMovAlmDet.Location = New System.Drawing.Point(6, 15)
        Me.GridMovAlmDet.Name = "GridMovAlmDet"
        Me.GridMovAlmDet.RecordNavigator = True
        Me.GridMovAlmDet.Size = New System.Drawing.Size(522, 309)
        Me.GridMovAlmDet.TabIndex = 3
        Me.GridMovAlmDet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpMovAlm
        '
        Me.grpMovAlm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpMovAlm.Controls.Add(Me.GridMovAlm)
        Me.grpMovAlm.Location = New System.Drawing.Point(0, 1)
        Me.grpMovAlm.Name = "grpMovAlm"
        Me.grpMovAlm.Size = New System.Drawing.Size(231, 330)
        Me.grpMovAlm.TabIndex = 4
        Me.grpMovAlm.TabStop = False
        Me.grpMovAlm.Text = "Documentos"
        '
        'GridMovAlm
        '
        Me.GridMovAlm.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMovAlm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMovAlm.ColumnAutoResize = True
        Me.GridMovAlm.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMovAlm.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMovAlm.GroupByBoxVisible = False
        Me.GridMovAlm.Location = New System.Drawing.Point(6, 15)
        Me.GridMovAlm.Name = "GridMovAlm"
        Me.GridMovAlm.RecordNavigator = True
        Me.GridMovAlm.Size = New System.Drawing.Size(219, 308)
        Me.GridMovAlm.TabIndex = 3
        Me.GridMovAlm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GridResumen)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(758, 366)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'GridResumen
        '
        Me.GridResumen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridResumen.ColumnAutoResize = True
        Me.GridResumen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridResumen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridResumen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridResumen.GroupByBoxVisible = False
        Me.GridResumen.Location = New System.Drawing.Point(6, 15)
        Me.GridResumen.Name = "GridResumen"
        Me.GridResumen.RecordNavigator = True
        Me.GridResumen.Size = New System.Drawing.Size(746, 344)
        Me.GridResumen.TabIndex = 3
        Me.GridResumen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblTotalComision
        '
        Me.LblTotalComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComision.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalComision.Location = New System.Drawing.Point(650, 339)
        Me.LblTotalComision.Name = "LblTotalComision"
        Me.LblTotalComision.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalComision.TabIndex = 87
        Me.LblTotalComision.Text = "0,0"
        Me.LblTotalComision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(531, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 15)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "T. a Comsión"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.GridComisionProd)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 128)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(758, 202)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Comisión por Producto"
        '
        'GridComisionProd
        '
        Me.GridComisionProd.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisionProd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisionProd.ColumnAutoResize = True
        Me.GridComisionProd.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisionProd.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisionProd.GroupByBoxVisible = False
        Me.GridComisionProd.Location = New System.Drawing.Point(6, 15)
        Me.GridComisionProd.Name = "GridComisionProd"
        Me.GridComisionProd.RecordNavigator = True
        Me.GridComisionProd.Size = New System.Drawing.Size(746, 180)
        Me.GridComisionProd.TabIndex = 3
        Me.GridComisionProd.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.GridComisionVta)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(758, 119)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Comisión por Venta"
        '
        'GridComisionVta
        '
        Me.GridComisionVta.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisionVta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisionVta.ColumnAutoResize = True
        Me.GridComisionVta.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisionVta.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisionVta.GroupByBoxVisible = False
        Me.GridComisionVta.Location = New System.Drawing.Point(6, 15)
        Me.GridComisionVta.Name = "GridComisionVta"
        Me.GridComisionVta.RecordNavigator = True
        Me.GridComisionVta.Size = New System.Drawing.Size(746, 97)
        Me.GridComisionVta.TabIndex = 3
        Me.GridComisionVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnSalirLiq
        '
        Me.BtnSalirLiq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirLiq.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirLiq.Image = CType(resources.GetObject("BtnSalirLiq.Image"), System.Drawing.Image)
        Me.BtnSalirLiq.Location = New System.Drawing.Point(655, 329)
        Me.BtnSalirLiq.Name = "BtnSalirLiq"
        Me.BtnSalirLiq.Size = New System.Drawing.Size(108, 32)
        Me.BtnSalirLiq.TabIndex = 92
        Me.BtnSalirLiq.Text = "&Salir"
        Me.BtnSalirLiq.ToolTipText = "Salir"
        Me.BtnSalirLiq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.Location = New System.Drawing.Point(539, 331)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(110, 30)
        Me.BtnCerrar.TabIndex = 91
        Me.BtnCerrar.Text = "F9- Cerrar"
        Me.BtnCerrar.ToolTipText = "Cierra el Documento Actual"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblSaldo.Location = New System.Drawing.Point(644, 254)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(113, 15)
        Me.LblSaldo.TabIndex = 90
        Me.LblSaldo.Text = "0.0"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(525, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 15)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "Saldo"
        '
        'LblLiquidado
        '
        Me.LblLiquidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLiquidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLiquidado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblLiquidado.Location = New System.Drawing.Point(644, 234)
        Me.LblLiquidado.Name = "LblLiquidado"
        Me.LblLiquidado.Size = New System.Drawing.Size(113, 15)
        Me.LblLiquidado.TabIndex = 88
        Me.LblLiquidado.Text = "0.0"
        Me.LblLiquidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(525, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 15)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Liquidado"
        '
        'LblTotalAbonos
        '
        Me.LblTotalAbonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalAbonos.Location = New System.Drawing.Point(87, 234)
        Me.LblTotalAbonos.Name = "LblTotalAbonos"
        Me.LblTotalAbonos.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalAbonos.TabIndex = 86
        Me.LblTotalAbonos.Text = "0,0"
        Me.LblTotalAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalLiquidar
        '
        Me.LblTotalLiquidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalLiquidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalLiquidar.Location = New System.Drawing.Point(328, 282)
        Me.LblTotalLiquidar.Name = "LblTotalLiquidar"
        Me.LblTotalLiquidar.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalLiquidar.TabIndex = 85
        Me.LblTotalLiquidar.Text = "0,0"
        Me.LblTotalLiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblEgresos
        '
        Me.LblEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEgresos.Location = New System.Drawing.Point(328, 254)
        Me.LblEgresos.Name = "LblEgresos"
        Me.LblEgresos.Size = New System.Drawing.Size(113, 15)
        Me.LblEgresos.TabIndex = 84
        Me.LblEgresos.Text = "0,0"
        Me.LblEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "T. Abonos"
        '
        'LblIngresos
        '
        Me.LblIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblIngresos.Location = New System.Drawing.Point(329, 234)
        Me.LblIngresos.Name = "LblIngresos"
        Me.LblIngresos.Size = New System.Drawing.Size(113, 15)
        Me.LblIngresos.TabIndex = 82
        Me.LblIngresos.Text = "0,0"
        Me.LblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(209, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "T. a Liquidar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(209, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "T. Egreso"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(210, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "T. Ingreso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.GridLiquidacion)
        Me.GroupBox4.Location = New System.Drawing.Point(206, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(557, 223)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resumen"
        '
        'GridLiquidacion
        '
        Me.GridLiquidacion.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLiquidacion.ColumnAutoResize = True
        Me.GridLiquidacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLiquidacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLiquidacion.GroupByBoxVisible = False
        Me.GridLiquidacion.Location = New System.Drawing.Point(6, 15)
        Me.GridLiquidacion.Name = "GridLiquidacion"
        Me.GridLiquidacion.RecordNavigator = True
        Me.GridLiquidacion.Size = New System.Drawing.Size(545, 201)
        Me.GridLiquidacion.TabIndex = 3
        Me.GridLiquidacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.GridAbonos)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(195, 223)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Abonos"
        '
        'GridAbonos
        '
        Me.GridAbonos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAbonos.ColumnAutoResize = True
        Me.GridAbonos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAbonos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAbonos.GroupByBoxVisible = False
        Me.GridAbonos.Location = New System.Drawing.Point(6, 15)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(183, 201)
        Me.GridAbonos.TabIndex = 3
        Me.GridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(650, 326)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(108, 32)
        Me.UiButton1.TabIndex = 52
        Me.UiButton1.Text = "&Salir"
        Me.UiButton1.ToolTipText = "Salir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.TabGeneral)
        Me.Controls.Add(Me.TxtNombrePdV)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmbDiaTrabajo)
        Me.Controls.Add(Me.TxtClavePdV)
        Me.Controls.Add(Me.LblTipo)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtUsuarioNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoVenta"
        Me.Text = "Vta. Convencional"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TabGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGeneral.ResumeLayout(False)
        Me.tabTransacciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTransaccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCobranza.ResumeLayout(False)
        Me.GrpTickets.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovAlmDet.ResumeLayout(False)
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovAlm.ResumeLayout(False)
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private bLoad As Boolean = False
    Private FormatoFactura As String

    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Private TabActual As String

    Private Impresora, ImpresoraLQ As String
    Private sMOVALMSelected As String
    Private sMOVALMFolio As String

    Private TotalAbonos, Ingresos, Egresos, ComisionVta, ComisionProd As Double
    'Transacciones
    Private sDocumentoSelected As String
    Private sEstado As String
    Private sFolio As String
    Private dTotalDoc As Double
    Private dSaldoDoc As Double
    Private iTipoCF As Integer
    Private sUUID As String
    Private sRFC As String
    Private Customerkey As String
    Private sCTEClave As String
    Private ServidorCancelacion As String
    Private ServidorTimbrado As String
    Private sDevTipo As String
    Private Autoriza As String

    Private sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean
    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream

    Private dtPAC As DataTable

    Private dtCxC As DataTable
    Private dtTran As DataTable

    Private dSaldo As Double

    Private TICDevolucion As String
    Private CajaClave As String
    Private CajaNombre As String

    Private Cajon As Boolean = False

    Public NombreVEN As String
    Public ClavePDV As String
    Public NombrePDV As String
    Public DiaTrabajo As Date
    Public CAJClave As String
    Public ALMClave As String
    Public SUCClave As String
    Public PDVClave As String
    Public VendedorClave As String


    Private Sub FrmMtoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Cursor.Current = Cursors.WaitCursor

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_obtener_usuario", "@USRClave", ModPOS.UsuarioActual)

        VendedorClave = dt.Rows(0)("USRClave")
        NombreVEN = dt.Rows(0)("Nombre")
      
        dt.Dispose()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        Me.StartPosition = FormStartPosition.CenterScreen
        cmbDiaTrabajo.Value = DiaTrabajo

        TxtClavePdV.Text = ClavePDV
        TxtNombrePdV.Text = NombrePDV
        TxtUsuarioNombre.Text = NombreVEN
        Cursor.Current = Cursors.Default

        With Me.cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Transaccion"
            .llenar()
        End With

        With Me.cmbFormaVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "FormaVenta"
            .llenar()
        End With

        With Me.cmbFormVent
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "FormaVenta"
            .llenar()
        End With


        With Me.cmbVencimiento
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Vencimiento"
            .llenar()
        End With

        With Me.cmbVenc
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Vencimiento"
            .llenar()
        End With

        Dim dtParam As DataTable

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "TipoCF"
                        iTipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()

        If iTipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
        End If



        
        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)

        'Recibo = dt.Rows(0)("TIKClave")
        TICDevolucion = dt.Rows(0)("TICDevolucion")
        Impresora = dt.Rows(0)("Referencia")
        '       PrintGeneric = dt.Rows(0)("Generic")
        ImpresoraLQ = dt.Rows(0)("ImpresoraFac")
        CajaClave = dt.Rows(0)("Clave")
        CajaNombre = dt.Rows(0)("Nombre")

        'Manual = IIf(dt.Rows(0)("Manual").GetType.Name = "DBNull", 0, dt.Rows(0)("Manual"))
        Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))

        dt.Dispose()
        bLoad = True

        Me.ActualizaGridTransac()

    End Sub

    Private Sub FrmMtoVenta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
        ModPOS.MtoVenta.Dispose()
        ModPOS.MtoVenta = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Aplica_Pagos(ByVal foundRows() As DataRow, ByVal CTEClave As String, ByVal AbonoClave As String, ByVal TPago As Integer, ByVal TotalAbono As Double, ByVal SaldoVenta As Double, ByVal TotalCambio As Double, ByVal ShowCambio As Boolean)
        Dim i As Integer
        Dim dts As DataTable
        Dim AcumulaPuntos As Integer

        dts = ModPOS.Recupera_Tabla("sp_recupera_cte_mostrador", "@Cliente", CTEClave)

        If dts.Rows(0)("POS") = 0 Then
            AcumulaPuntos = 1
        Else
            AcumulaPuntos = 0
        End If

        dts.Dispose()

        If foundRows.GetLength(0) = 1 Then

            Dim TotalPagoAplicar As Double

            Select Case Redondear(TotalAbono, 2)
                Case Is > Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = SaldoVenta

                    ModPOS.Ejecuta("sp_paga_documento", _
                                                  "@ABNClave", AbonoClave, _
                                                  "@TipoDoc", foundRows(0)("TipoDocumento"), _
                                                  "@Documento", foundRows(0)(0), _
                                                  "@Pago", TotalPagoAplicar, _
                                                  "@AcumulaPuntos", AcumulaPuntos, _
                                                  "Tipo", TPago, _
                                                  "@Usuario", ModPOS.UsuarioActual)
                Case Is < Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = TotalAbono

                    ModPOS.Ejecuta("sp_actualiza_saldo", _
                                   "@ABNClave", AbonoClave, _
                                   "@Pago", TotalPagoAplicar, _
                                   "@TipoDoc", foundRows(0)("TipoDocumento"), _
                                   "@Documento", foundRows(0)(0), _
                                   "Tipo", TPago, _
                                   "@Usuario", ModPOS.UsuarioActual)

                Case Is = Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = SaldoVenta

                    ModPOS.Ejecuta("sp_paga_documento", _
                                   "@ABNClave", AbonoClave, _
                                   "@TipoDoc", foundRows(0)("TipoDocumento"), _
                                   "@Documento", foundRows(0)(0), _
                                   "@Pago", TotalPagoAplicar, _
                                   "@AcumulaPuntos", AcumulaPuntos, _
                                   "Tipo", TPago, _
                                   "@Usuario", ModPOS.UsuarioActual)
            End Select

        Else
            Dim SaldoDisponible As Double
            SaldoDisponible = TotalAbono

            For i = 0 To foundRows.GetUpperBound(0)

                Select Case Redondear(SaldoDisponible, 2)
                    Case Is > Redondear(foundRows(i)(7), 2)
                        ModPOS.Ejecuta("sp_paga_documento", _
                                                      "@ABNClave", AbonoClave, _
                                                      "@TipoDoc", foundRows(i)("TipoDocumento"), _
                                                      "@Documento", foundRows(i)(0), _
                                                      "@Pago", foundRows(i)(7), _
                                                      "@AcumulaPuntos", AcumulaPuntos, _
                                                      "Tipo", TPago, _
                                                      "@Usuario", ModPOS.UsuarioActual)
                        SaldoDisponible -= foundRows(i)(7)
                    Case Is < Redondear(foundRows(i)(7), 2)
                        ModPOS.Ejecuta("sp_actualiza_saldo", _
                                       "@ABNClave", AbonoClave, _
                                       "@Pago", SaldoDisponible, _
                                       "@TipoDoc", foundRows(i)("TipoDocumento"), _
                                       "@Documento", foundRows(i)(0), _
                                       "Tipo", TPago, _
                                       "@Usuario", ModPOS.UsuarioActual)
                        SaldoDisponible -= SaldoDisponible

                    Case Is = Redondear(foundRows(i)(7), 2)
                        ModPOS.Ejecuta("sp_paga_documento", _
                                       "@ABNClave", AbonoClave, _
                                       "@TipoDoc", foundRows(i)("TipoDocumento"), _
                                       "@Documento", foundRows(i)(0), _
                                       "@Pago", foundRows(i)(7), _
                                       "@AcumulaPuntos", AcumulaPuntos, _
                                       "Tipo", TPago, _
                                       "@Usuario", ModPOS.UsuarioActual)
                        SaldoDisponible -= SaldoDisponible
                End Select

                If SaldoDisponible <= 0 Then
                    Exit For
                End If
            Next
        End If


        If TotalAbono > 0 Then
            If ShowCambio = True Then
                Dim msg As New FrmMeMsg
                If TPago = 1 Then
                    msg.TxtTiulo = "Su Cambio es:"
                Else
                    msg.TxtTiulo = "Su Saldo a favor es:"
                End If
                msg.TxtMsg = Format(CStr(ModPOS.Redondear(TotalCambio, 2)), "Currency")
                msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear(TotalCambio, 2))).ToUpper
                msg.ShowDialog()
                msg.Dispose()

            End If
            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClave, "@Importe", TotalAbono)
        End If
    End Sub

    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtCxC.Select("Marca ='True' and Saldo > 0")

            If foundRows.GetLength(0) > 0 Then

                If ModPOS.SiExite(ModPOS.BDConexion, "sp_aplicar_abn", "@CTEClave", foundRows(0)(8)) > 0 Then
                    Dim b As New FrmAbnPendiente
                    b.Cliente = foundRows(0)(8)
                    b.CAJClave = Me.CAJClave
                    b.SaldoDocumento = dSaldo
                    b.ShowDialog()

                    If b.DialogResult = DialogResult.OK Then
                        If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                            Dim i As Integer
                            For i = 0 To b.drAbonos.Length - 1
                                Aplica_Pagos(foundRows, foundRows(0)(8), b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("Saldo"), dSaldo, IIf(b.drAbonos(i)("Saldo") > dSaldo, b.drAbonos(i)("Saldo") - dSaldo, 0), False)
                            Next
                            dtCxC.Dispose()
                            ActualizaGridCxC()
                            Exit Sub
                        End If
                    End If
                End If

                Dim a As New FrmAbono
                a.VariosPagos = IIf(foundRows.GetLength(0) = 1, False, True)
                a.TipoDocumento = foundRows(0)("TipoDocumento")
                a.CAJA = CAJClave
                a.ClaveCte = foundRows(0)(8)
                a.ClaveDocumento = foundRows(0)(0)
                a.SaldoAcumulado = dSaldo
                a.AperturaCajon = Cajon
                a.ImpresoraCajon = Impresora
                a.ShowDialog()

                If a.DialogResult = DialogResult.OK Then
                    Aplica_Pagos(foundRows, foundRows(0)(8), a.AbonoClave, a.TPago, a.TotalAbono, a.SaldoVenta, a.TotalCambio, True)
                    dtCxC.Dispose()
                    ActualizaGridCxC()
                    'RetiroProgramado()
                End If

            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Function validaCobranza() As Boolean
        Dim i As Integer = 0

        If Me.cmbFormaVenta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbVencimiento.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Function validaTransaccion() As Boolean
        Dim i As Integer = 0

        If Me.cmbFormVent.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbVenc.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If
        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Public Sub ActualizaGridCxC()
        If validaCobranza() Then

            TabActual = "Cobranaza"
            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
            End If


            dtCxC = ModPOS.Recupera_Tabla("sp_recupera_vta_cxc", "@CAJClave", CAJClave, "@FormaVenta", cmbFormaVenta.SelectedValue, "@Vencimiento", cmbVencimiento.SelectedValue, "@FechaApertura", cmbDiaTrabajo.Value, "@FechaCierre", cmbDiaTrabajo.Value.AddHours(23.9999))
            GridCxC.DataSource = dtCxC
            GridCxC.RetrieveStructure()
            GridCxC.AutoSizeColumns()
            GridCxC.RootTable.Columns("ID").Visible = False
            GridCxC.CurrentTable.Columns(2).Selectable = False
            GridCxC.CurrentTable.Columns(3).Selectable = False
            GridCxC.CurrentTable.Columns(4).Selectable = False
            GridCxC.CurrentTable.Columns(5).Selectable = False
            GridCxC.CurrentTable.Columns(6).Selectable = False
            GridCxC.CurrentTable.Columns(7).Selectable = False
            GridCxC.CurrentTable.Columns("CTEClave").Visible = False
            GridCxC.CurrentTable.Columns("TipoDocumento").Visible = False


            If cmbFormaVenta.SelectedValue = 1 Then
                LblVencimiento.Visible = False
                cmbVencimiento.Visible = False
            Else
                LblVencimiento.Visible = True
                cmbVencimiento.Visible = True
            End If

            dSaldo = 0
            ChkMarcaTodos.Enabled = True
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TabGeneral_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles TabGeneral.SelectedTabChanged
        If bLoad = True Then
            Select Case e.Page.Name
                Case Is = "tabCobranza"
                    ActualizaGridCxC()
                Case Is = "tabTransacciones"
                    ActualizaGridTransac()
            End Select
        End If
    End Sub

    Private Sub cmbFormaVenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaVenta.SelectedIndexChanged
        If bLoad Then
            ActualizaGridCxC()
        End If
    End Sub

    Private Sub cmbVencimiento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVencimiento.SelectedIndexChanged
        If bLoad Then
            ActualizaGridCxC()
        End If
    End Sub

    Private Sub BtnSalirCxC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirCxC.Click
        Me.Close()
    End Sub

    Private Sub BtnSalirTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirTrans.Click
        Me.Close()
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxC.Rows.Count > 0 Then
            Dim i As Integer
            If ChkMarcaTodos.Checked Then
                dSaldo = 0
                For i = 0 To dtCxC.Rows.Count - 1
                    dtCxC.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtCxC.Rows.Count - 1
                    dtCxC.Rows(i)("Marca") = False
                Next
            End If
            dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
        End If

    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtTran.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                dSaldo = 0
                For i = 0 To dtTran.Rows.Count - 1
                    dtTran.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtTran.Rows.Count - 1
                    dtTran.Rows(i)("Marca") = False
                Next
            End If
            ' dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
        End If

    End Sub

    Public Sub ActualizaGridTransac()
        If validaTransaccion() Then
            TabActual = "Transac"
            If Not dtTran Is Nothing Then
                dtTran.Dispose()
            End If

            dtTran = ModPOS.Recupera_Tabla("sp_recupera_vta_tran", "@CAJClave", CAJClave, "@Tipo", cmbTipo.SelectedValue, "@FormaVenta", cmbFormVent.SelectedValue, "@Vencimiento", cmbVenc.SelectedValue, "@FechaApertura", cmbDiaTrabajo.Value, "@FechaCierre", cmbDiaTrabajo.Value.AddHours(23.9999))
            With GridTransaccion
                .DataSource = dtTran
                .RetrieveStructure()
                .AutoSizeColumns()
                .RootTable.Columns("ID").Visible = False
                .CurrentTable.Columns(2).Selectable = False
                .CurrentTable.Columns(3).Selectable = False
                .CurrentTable.Columns(4).Selectable = False
                .CurrentTable.Columns(5).Selectable = False
                .CurrentTable.Columns(6).Selectable = False
                .CurrentTable.Columns(7).Selectable = False
                .CurrentTable.Columns("TipoCF").Visible = False
                .CurrentTable.Columns("DevTipo").Visible = False
                .CurrentTable.Columns("CTEClave").Visible = False
                .CurrentTable.Columns("Saldo").Visible = False

                If iTipoCF = 3 Then
                    If cmbTipo.SelectedValue = 2 OrElse cmbTipo.SelectedValue = 3 Then
                        .CurrentTable.Columns("uuid").Visible = True
                    Else
                        .CurrentTable.Columns("uuid").Visible = False
                    End If
                Else
                    .CurrentTable.Columns("uuid").Visible = False
                End If

            End With


            If dtTran.Rows.Count = 0 Then
                sFolio = ""
                sDocumentoSelected = ""
                dTotalDoc = 0
                dSaldoDoc = 0
                iTipoCF = 0
                sRFC = ""
                sUUID = ""
                sCTEClave = ""
                sDevTipo = ""
                sEstado = ""
            End If

            If cmbTipo.SelectedValue = 1 OrElse cmbTipo.SelectedValue = 2 Then
                If cmbFormVent.SelectedValue = 1 Then
                    LblVenc.Visible = False
                    cmbVenc.Visible = False
                Else
                    LblVenc.Visible = True
                    cmbVenc.Visible = True
                End If
            End If

            If cmbTipo.SelectedValue = 1 Then
                BtnNuevo.Visible = True
                BtnNuevo.Text = "Venta"

                BtnFacturar.Visible = True
                BtnDevolucion.Visible = True
                BtnDevolucion.Text = "Devolución"
                BtnDevolucion.ToolTipText = "Crea devolución del registro seleccionado"

                BtnConsultar.Visible = True
                BtnReimprimir.Visible = False
                BtnSend.Visible = False
                BtnCancelar.Visible = True

            ElseIf cmbTipo.SelectedValue = 2 Then

                BtnNuevo.Visible = True
                BtnNuevo.Text = "NC"

                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = True
                BtnReimprimir.Visible = True
                BtnSend.Visible = True
                BtnCancelar.Visible = True

            ElseIf cmbTipo.SelectedValue = 3 Then
                BtnNuevo.Visible = False

                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = True
                BtnReimprimir.Visible = True
                BtnSend.Visible = True
                BtnCancelar.Visible = True

            ElseIf cmbTipo.SelectedValue = 4 Then

                BtnNuevo.Visible = False

                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = False
                BtnReimprimir.Visible = False
                BtnSend.Visible = False
                BtnCancelar.Visible = False

            ElseIf cmbTipo.SelectedValue = 5 Then

                BtnNuevo.Visible = True
                BtnNuevo.Text = "Nota Cargo"
                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = True
                BtnReimprimir.Visible = True
                BtnSend.Visible = True
                BtnCancelar.Visible = True

            End If
            ChkTodos.Enabled = True
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If bLoad AndAlso Not cmbTipo.SelectedValue Is Nothing Then
            If cmbTipo.SelectedValue = 1 OrElse cmbTipo.SelectedValue = 2 Then
                lblFormVent.Visible = True
                cmbFormVent.Visible = True
            Else
                lblFormVent.Visible = False
                cmbFormVent.Visible = False
                LblVenc.Visible = False
                cmbVenc.Visible = False
            End If

            ActualizaGridTransac()

        End If
    End Sub

    Private Sub cmbFormVent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormVent.SelectedIndexChanged
        If bLoad Then
            ActualizaGridTransac()
        End If
    End Sub

    Private Sub cmbVenc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVenc.SelectedIndexChanged
        If bLoad Then
            ActualizaGridTransac()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim foundRows() As DataRow

        foundRows = dtTran.Select("Marca ='True'")

        If foundRows.GetLength(0) = 1 Then


            If foundRows(0)("Estado") = "Cancelada" Then
                MessageBox.Show("El documento seleccionado ya se encuentra Cancelado")
                Exit Sub
            End If

            If cmbTipo.SelectedValue = 1 AndAlso foundRows(0)("Estado") <> "Cerrado" Then
                MessageBox.Show("No es posible cancelar el documento ya que no se encuentra Cerrado")
                Exit Sub
            End If

            Dim dt As DataTable

            '
            If cmbTipo.SelectedValue = 1 Then
                'Valida que no tenga abonos aplicados, que el total sea igual al saldo
                If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                    MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

         

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = foundRows(0)("Total")
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza

                            Select Case CInt(cmbTipo.SelectedValue)
                                Case Is = 1 'Venta

                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)("ID"), "@TipoDoc", 1)
                                    ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 1, foundRows(0)("ID"), ALMClave)
                                    ModPOS.ActualizaExistUbc(1, 1, foundRows(0)("ID"), ALMClave)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))
                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("ID"), "@Tipo", 1)


                                Case Is = 2 'Factura

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") = "Activa" Then


                                        If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                        Dim eRFC As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(0)(0))
                                        eRFC = dt.Rows(0)("cRFC")
                                        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", foundRows(0)("ID"))
                                    ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 2, foundRows(0)("ID"), ALMClave)
                                    ModPOS.ActualizaExistUbc(1, 2, foundRows(0)("ID"), ALMClave)

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("ID"), "@Tipo", 2)

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") <> "Activa" Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)("ID"))
                                    End If

                                Case Is = 3 ' NC

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") = "Activa" Then

                                        Dim eRFC As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(0)("ID"))
                                        eRFC = dt.Rows(0)("cRFC")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", foundRows(0)("ID"))

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    If sDevTipo = "Devolución" = 1 Then
                                        ModPOS.GeneraMovInv(2, 5, 4, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                        ModPOS.ActualizaExistAlm(2, 4, foundRows(0)("ID"), ALMClave)
                                        ModPOS.ActualizaExistUbc(2, 4, foundRows(0)("ID"), ALMClave)
                                    End If

                                  
                                Case Is = 4  ' Devolucion
                                    ModPOS.Ejecuta("sp_cancela_devolucion", "@DEVClave", foundRows(0)("ID"))

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_vta", "@DEVClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    ModPOS.GeneraMovInv(2, 5, 3, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                    ModPOS.ActualizaExistAlm(2, 3, foundRows(0)("ID"), ALMClave)
                                    ModPOS.ActualizaExistUbc(2, 3, foundRows(0)("ID"), ALMClave)

                                Case Is = 5 'Nota Cargo

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") = "Activa" Then

                                        If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                        Dim eRFC As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(0)(0))
                                        eRFC = dt.Rows(0)("cRFC")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", foundRows(0)("ID"))

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") <> "Activa" Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)(0))
                                    End If

                            End Select
                            ActualizaGridTransac()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe Marcar el documento que desea Cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If validaTransaccion() Then
            If sDocumentoSelected <> "" Then
                Dim FileXML As String = ""
                Dim dt As DataTable
                'Recupera correo electronico

                Dim Tipo As Integer
                Dim sTipo As String = ""

                If cmbTipo.SelectedValue = 2 Then
                    Tipo = 1
                    sTipo = "F"
                ElseIf cmbTipo.SelectedValue = 3 Then
                    Tipo = 7
                    sTipo = "N"
                ElseIf cmbTipo.SelectedValue = 5 Then
                    Tipo = 6
                    sTipo = "C"

                End If

                dt = ModPOS.Recupera_Tabla("sp_recupera_mail", "@Clave", sDocumentoSelected, "@Tipo", Tipo)
                sMailCliente = dt.Rows(0)("Email")
                dt.Dispose()

                If sMailCliente = "" Then
                    MessageBox.Show("El cliente no cuenta con una dirección de Correo Electrónica Configurada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Recupera CompanyParam

                If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                    MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                'Verifica que exista el path

                If iTipoCF <= 2 Then
                    Try
                        If Not System.IO.Directory.Exists(PathXML) Then
                            MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try

                    If PathXML.Length <= 3 Then
                        FileXML = PathXML & sFolio & ".xml"
                    Else
                        FileXML = PathXML & "\" & sFolio & ".xml"
                    End If

                    If Not System.IO.File.Exists(FileXML) Then
                        MessageBox.Show("No fue posible encontrar el archivo: " & FileXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If

                PathPDF = pathActual & "Temp\" & sFolio & ".PDF"

                'Genera PDF

                Dim MonRef, MonDesc As String
                Dim TipoCambio As Double

                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", sTipo, "@Documento", sDocumentoSelected)
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                dt.Dispose()

                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"

                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))

                If cmbTipo.SelectedValue = 2 Then

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", sDocumentoSelected))

                    If iTipoCF = 1 Then
                        If FormatoFactura = "Clasico" Then
                            OpenReport.PrintPDF("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                        Else
                            OpenReport.PrintPDF("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                        End If

                    ElseIf iTipoCF = 2 Then
                        If FormatoFactura = "Clasico" Then
                            OpenReport.PrintPDF("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                        Else
                            OpenReport.PrintPDF("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                        End If
                    ElseIf iTipoCF = 3 Then
                        OpenReport.PrintPDF("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    End If

                ElseIf cmbTipo.SelectedValue = 3 Then

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", sDocumentoSelected))

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", sDocumentoSelected))

                    If iTipoCF = 1 Then
                        OpenReport.PrintPDF("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    ElseIf iTipoCF = 2 Then
                        OpenReport.PrintPDF("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    ElseIf iTipoCF = 3 Then
                        OpenReport.PrintPDF("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    End If
                ElseIf cmbTipo.SelectedValue = 5 Then

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sDocumentoSelected))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", sDocumentoSelected))


                    OpenReport.PrintPDF("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)


                End If


                    If Not System.IO.File.Exists(PathPDF) Then
                        MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    'Envia Correo

                    Dim frmStatusMessage As New frmStatus
                    Try
                        correo = New MailMessage
                        autenticar = New NetworkCredential
                        envio = New SmtpClient

                        If cmbTipo.SelectedValue = 2 Then
                            If iTipoCF = 1 Then
                                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Factura (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                            ElseIf iTipoCF = 3 Then
                                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Factura (*.PDF), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                            End If

                            correo.Subject = "Factura " & sFolio

                        ElseIf cmbTipo.SelectedValue = 3 Then
                            If iTipoCF = 1 Then
                                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Crédito (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                            ElseIf iTipoCF = 3 Then
                                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Crédito (*.PDF), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                            End If

                            correo.Subject = "Nota de Crédito " & sFolio

                    ElseIf cmbTipo.SelectedValue = 5 Then
                        correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Cargo (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                        correo.Subject = "Nota de Cargo " & sFolio
                    End If

                        correo.IsBodyHtml = True
                        correo.To.Clear()
                        correo.CC.Clear()
                        correo.Bcc.Clear()


                    If sMailCliente.Split(",").Length >= 1 Then
                        Dim i As Integer
                        For i = 0 To sMailCliente.Split(",").Length - 1
                            correo.To.Add(sMailCliente.Split(",")(i))
                        Next
                    Else
                        correo.To.Add(sMailCliente)
                    End If

                        correo.From = New MailAddress(MailAdress, DisplayName)
                        envio.Credentials = New NetworkCredential(MailUser, MailPassword)
                        envio.Host = HostSMTP  '"smtp.live.com"
                        envio.Port = MailPort  '587
                        envio.EnableSsl = MailSSL 'True

                        frmStatusMessage.Show("Enviando correo electrónico...")

                        If iTipoCF <= 2 Then
                            dato = New FileStream(FileXML, FileMode.Open, FileAccess.Read)
                            adjuntos = New Attachment(dato, sFolio & ".XML")
                            correo.Attachments.Add(adjuntos)
                        End If


                        dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
                        adjuntos = New Attachment(dato, sFolio & ".PDF")
                        correo.Attachments.Add(adjuntos)


                        envio.Send(correo)
                        correo.Dispose()

                        MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        frmStatusMessage.Dispose()
                    Catch ex As Exception
                        frmStatusMessage.Dispose()
                        MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    dato.Close()

                    Try
                        My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try

                Else
                    MessageBox.Show("¡No se ha seleccionado un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnReimprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReimprimir.Click
        If validaTransaccion() Then
            Dim a As New FrmReimpresion
            If cmbTipo.SelectedValue = 2 Then
                a.TipoReimpresion = "Factura"
            ElseIf cmbTipo.SelectedValue = 3 Then
                a.TipoReimpresion = "NC"
            ElseIf cmbTipo.SelectedValue = 5 Then
                a.TipoReimpresion = "NotaCargo"
            End If
            a.Impresora = ""
            a.SUCClave = SUCClave
            a.ShowDialog()
            a.Dispose()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Imprimir()

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet

        If cmbTipo.SelectedValue = 1 Then
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_ped", "@VENClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
            pvtaDataSet.DataSetName = "pvtaDataSet"
            OpenReport.PrintPreview("Venta", "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(dTotalDoc, 2)).ToUpper)
            Exit Sub
        End If

        Dim MonRef, MonDesc As String
        Dim TipoCambio As Double
        Dim dt As DataTable

        Dim sTipo As String = ""

        If cmbTipo.SelectedValue = 2 Then
            sTipo = "F"
        ElseIf cmbTipo.SelectedValue = 3 Then
            sTipo = "N"
        ElseIf cmbTipo.SelectedValue = 5 Then
            sTipo = "C"
        End If

        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", sTipo, "@Documento", sDocumentoSelected)
        TipoCambio = dt.Rows(0)("TipoCambio")
        MonRef = dt.Rows(0)("Referencia")
        MonDesc = dt.Rows(0)("Descripcion")
        dt.Dispose()

        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))


        If cmbTipo.SelectedValue = 2 Then 'Factura

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", sDocumentoSelected))

            If iTipoCF = 1 Then
                If FormatoFactura = "Clasico" Then
                    OpenReport.PrintPreview("Factura", "CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                Else
                    OpenReport.PrintPreview("Factura", "CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                End If
            ElseIf iTipoCF = 2 Then
                If FormatoFactura = "Clasico" Then
                    OpenReport.PrintPreview("Factura", "CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                Else
                    OpenReport.PrintPreview("Factura", "CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                End If
            ElseIf iTipoCF = 3 Then
                OpenReport.PrintPreview("Factura", "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            End If

        ElseIf cmbTipo.SelectedValue = 3 Then ' Nota Crédito

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", sDocumentoSelected))

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", sDocumentoSelected))
            If iTipoCF = 1 Then
                OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            ElseIf iTipoCF = 2 Then
                OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)

            ElseIf iTipoCF = 3 Then
                OpenReport.PrintPreview("Nota de Crédito", "CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            End If

        ElseIf cmbTipo.SelectedValue = 5 Then ' Nota Cargo

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sDocumentoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", sDocumentoSelected))

            OpenReport.PrintPreview("Nota de Cargo", "CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotalDoc / TipoCambio, 2), MonDesc, MonRef).ToUpper)

        End If
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        If sDocumentoSelected <> "" Then
            Imprimir()
        Else
            MessageBox.Show("¡Debe seleccionar el documento que desea consultar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridTransaccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTransaccion.DoubleClick
        If Not GridTransaccion.GetValue(0) Is Nothing Then
            If cmbTipo.SelectedValue = 2 OrElse cmbTipo.SelectedValue = 3 OrElse cmbTipo.SelectedValue = 5 Then
                If sDocumentoSelected <> "" Then
                    If sEstado = "Pendiente" Then
                        If MessageBox.Show("El documento seleccionado se encuentra pendiente de Certificación, ¿deseas intentar nuevamente?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

                            Dim iTipoPAC, iTipoComprobante As Integer
                            Dim sTipoComprobante As String = ""

                            If cmbTipo.SelectedValue = 2 Then
                                sTipoComprobante = "ingreso"
                                iTipoComprobante = 1
                            ElseIf cmbTipo.SelectedValue = 3 Then
                                sTipoComprobante = "egreso"
                                iTipoComprobante = 7
                            ElseIf cmbTipo.SelectedValue = 5 Then
                                sTipoComprobante = "ingreso"
                                iTipoComprobante = 6
                            End If
                            iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, sFolio, sDocumentoSelected, sTipoComprobante, Nothing, Nothing, Nothing, iTipoComprobante)

                            If iTipoPAC <> 0 Then
                                ActualizaGridTransac()
                            End If

                        End If
                        Imprimir()
                    Else
                        Imprimir()
                    End If
                Else
                    MessageBox.Show("¡No se ha seleccionado un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If
    End Sub

    Private Sub GridTransaccion_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTransaccion.SelectionChanged
        If Not GridTransaccion.GetValue(0) Is Nothing Then

            sDocumentoSelected = GridTransaccion.GetValue("ID")
            sFolio = GridTransaccion.GetValue("Folio")
            sEstado = GridTransaccion.GetValue("Estado")
            dTotalDoc = GridTransaccion.GetValue("Total")
            dSaldoDoc = GridTransaccion.GetValue("Saldo")

            sCTEClave = GridTransaccion.GetValue("CTEClave")
            sRFC = GridTransaccion.GetValue("RFC")

            sUUID = IIf(GridTransaccion.GetValue("uuid").GetType.Name = "DBNull", "", GridTransaccion.GetValue("uuid"))
            iTipoCF = IIf(GridTransaccion.GetValue("TipoCF").GetType.Name = "DBNull", 1, GridTransaccion.GetValue("TipoCF"))

            sDevTipo = GridTransaccion.GetValue("DevTipo")

        Else
            sFolio = ""
            sDocumentoSelected = ""
            dTotalDoc = 0
            dSaldoDoc = 0
            iTipoCF = 0
            sRFC = ""
            sUUID = ""
            sCTEClave = ""
            sDevTipo = ""
            sEstado = ""
        End If
    End Sub

    Private Sub BtnFacturar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFacturar.Click
        If validaTransaccion() Then
            Dim foundRows() As DataRow

            foundRows = dtTran.Select("Marca ='True'")

            If foundRows.GetLength(0) > 0 Then

                If ModPOS.Factura Is Nothing Then
                    ModPOS.Factura = New FrmFactura
                    ModPOS.Factura.SUCClave = SUCClave
                    ModPOS.Factura.Ventas = foundRows
                    ModPOS.Factura.bLiquidacion = True
                End If

                ModPOS.Factura.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Factura.Show()

                If Not ModPOS.Factura Is Nothing Then
                    ModPOS.Factura.BringToFront()
                End If
            Else
                MessageBox.Show("¡Debe Marcar por lo menos un documento para Facturar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnDevolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click
        Dim foundRows() As DataRow

        foundRows = dtTran.Select("Marca ='True'")

        If foundRows.GetLength(0) = 1 Then

            'foundRows(0)("ID")

            If ModPOS.Devolucion Is Nothing Then
                ModPOS.Devolucion = New FrmDevolucion
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = CajaClave
                ModPOS.Devolucion.LblDescripcion.Text = CajaNombre
                ModPOS.Devolucion.LblUsuario.Text = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = CajaNombre
                ModPOS.Devolucion.Cajon = Cajon
                ModPOS.Devolucion.Ventas = foundRows
                ModPOS.Devolucion.bLiquidacion = True
            End If
            ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Devolucion.ShowDialog()
        Else
            MessageBox.Show("¡Debe Marcar la Venta sobre la que desea aplicar la Devolución!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Entrar()

        Dim dt As DataTable

        ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 1)

        dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", PDVClave)


        If ModPOS.PreVenta Is Nothing Then
            ModPOS.PreVenta = New FrmTPV
            ModPOS.PreVenta.bLiquidacion = True
            ModPOS.PreVenta.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
            ModPOS.PreVenta.StartPosition = FormStartPosition.CenterScreen

            With ModPOS.PreVenta
                Dim sFrase As String
                .ValidaInventario = dt.Rows(0)("ValidaInventario")
                .ALMClave = dt.Rows(0)("ALMClave")
                .PDVClave = dt.Rows(0)("PDVClave")
                .PuntodeVenta = dt.Rows(0)("Descripcion")
                .Referencia = dt.Rows(0)("Referencia")
                .Supervisor = dt.Rows(0)("Supervisor")
                .CTEClaveInicial = dt.Rows(0)("CTEClave")
                .CTENombreInicial = dt.Rows(0)("Cliente")
                .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                .Redondeo = dt.Rows(0)("Redondeo")
                .Agotamiento = dt.Rows(0)("Agotamiento")
                .LblFolio.Text = .Referencia & "- 0"
                .CAJClave = dt.Rows(0)("CAJClave")
                .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                sFrase = dt.Rows(0)("Frase")
                .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))
                dt.Dispose()
            End With
        End If

        ModPOS.PreVenta.ShowDialog()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If cmbTipo.SelectedValue = 1 Then
            'Venta
            Entrar()
        ElseIf cmbTipo.SelectedValue = 2 Then
            If validaTransaccion() Then
                Dim foundRows() As DataRow

                foundRows = dtTran.Select("Marca ='True'")

                If foundRows.GetLength(0) = 1 Then

                    If ModPOS.NC Is Nothing Then
                        ModPOS.NC = New FrmNC
                        ModPOS.NC.ALMClave = ALMClave
                        ModPOS.NC.SUCClave = SUCClave
                        ModPOS.NC.CAJClave = CAJClave
                        ModPOS.NC.Facturas = foundRows
                        ModPOS.NC.bLiquidacion = True
                    End If
                    ModPOS.NC.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.NC.Show()
                    If Not ModPOS.NC Is Nothing Then
                        ModPOS.NC.BringToFront()
                    End If
                Else
                    MessageBox.Show("¡Debe Marcar el documento sobre el que desea aplicar la NC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        ElseIf cmbTipo.SelectedValue = 5 Then

            If ModPOS.NotaCargo Is Nothing Then
                ModPOS.NotaCargo = New FrmNotaCargo
                ModPOS.NotaCargo.SUCClave = SUCClave
                ModPOS.NotaCargo.CAJClave = CAJClave
                ModPOS.NotaCargo.bLiquidacion = True
            End If

            ModPOS.NotaCargo.StartPosition = FormStartPosition.CenterScreen
            ModPOS.NotaCargo.Show()

            If Not ModPOS.NotaCargo Is Nothing Then
                ModPOS.NotaCargo.BringToFront()
            End If

        End If
    End Sub

    Private Sub BtnSalirLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirLiq.Click
        Me.Close()
    End Sub

    Private Sub GridCxC_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        If GridCxC.GetValue("Marca") = True Then
            dSaldo += CDbl(GridCxC.GetValue("Saldo"))
        Else
            dSaldo -= CDbl(GridCxC.GetValue("Saldo"))
        End If
    End Sub

    Private Sub cmbDiaTrabajo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDiaTrabajo.ValueChanged
        If bLoad Then
            If TabActual = "Cobranza" Then
                ActualizaGridCxC()
            Else
                ActualizaGridTransac()
            End If
        End If
    End Sub

    
End Class
