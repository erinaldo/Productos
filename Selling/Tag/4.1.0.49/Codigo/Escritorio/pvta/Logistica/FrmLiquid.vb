Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmLiquid
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
    Friend WithEvents dtpDiaTrabajo As System.Windows.Forms.DateTimePicker


    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtUsuarioNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label

    Friend WithEvents TxtClavePdV As System.Windows.Forms.TextBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label

    Friend WithEvents LblFase As System.Windows.Forms.Label
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents GrpFolio As System.Windows.Forms.GroupBox
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombrePdV As System.Windows.Forms.TextBox

    Friend WithEvents TabGeneral As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tabInventario As Janus.Windows.UI.Tab.UITabPage
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
    Friend WithEvents tabArqueo As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tabLiquidacion As Janus.Windows.UI.Tab.UITabPage
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
    Friend WithEvents tabComisiones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionProd As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionVta As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblTotalComision As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalirLiq As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GridMovAlmDet As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiquid))
        Me.dtpDiaTrabajo = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtUsuarioNombre = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClavePdV = New System.Windows.Forms.TextBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.LblFase = New System.Windows.Forms.Label()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.GrpFolio = New System.Windows.Forms.GroupBox()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.TxtNombrePdV = New System.Windows.Forms.TextBox()
        Me.TabGeneral = New Janus.Windows.UI.Tab.UITab()
        Me.tabInventario = New Janus.Windows.UI.Tab.UITabPage()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.grpMovAlmDet = New System.Windows.Forms.GroupBox()
        Me.GridMovAlmDet = New Janus.Windows.GridEX.GridEX()
        Me.grpMovAlm = New System.Windows.Forms.GroupBox()
        Me.GridMovAlm = New Janus.Windows.GridEX.GridEX()
        Me.tabTransacciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFormVent = New System.Windows.Forms.Label()
        Me.LblVenc = New System.Windows.Forms.Label()
        Me.BtnSalirTrans = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GridTransaccion = New Janus.Windows.GridEX.GridEX()
        Me.cmbTipo = New Selling.StoreCombo()
        Me.cmbVenc = New Selling.StoreCombo()
        Me.cmbFormVent = New Selling.StoreCombo()
        Me.tabCobranza = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.LblFormaVenta = New System.Windows.Forms.Label()
        Me.LblVencimiento = New System.Windows.Forms.Label()
        Me.BtnSalirCxC = New Janus.Windows.EditControls.UIButton()
        Me.BtnPago = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.cmbVencimiento = New Selling.StoreCombo()
        Me.cmbFormaVenta = New Selling.StoreCombo()
        Me.tabArqueo = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridResumen = New Janus.Windows.GridEX.GridEX()
        Me.tabComisiones = New Janus.Windows.UI.Tab.UITabPage()
        Me.LblTotalComision = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GridComisionProd = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GridComisionVta = New Janus.Windows.GridEX.GridEX()
        Me.tabLiquidacion = New Janus.Windows.UI.Tab.UITabPage()
        Me.BtnSalirLiq = New Janus.Windows.EditControls.UIButton()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblLiquidado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblTotalAbonos = New System.Windows.Forms.Label()
        Me.LblTotalLiquidar = New System.Windows.Forms.Label()
        Me.LblEgresos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblIngresos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GridLiquidacion = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSend = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.GrpFolio.SuspendLayout()
        CType(Me.TabGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGeneral.SuspendLayout()
        Me.tabInventario.SuspendLayout()
        Me.grpMovAlmDet.SuspendLayout()
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovAlm.SuspendLayout()
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransacciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTransaccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCobranza.SuspendLayout()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabArqueo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComisiones.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLiquidacion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpDiaTrabajo
        '
        Me.dtpDiaTrabajo.Enabled = False
        Me.dtpDiaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiaTrabajo.Location = New System.Drawing.Point(85, 16)
        Me.dtpDiaTrabajo.Name = "dtpDiaTrabajo"
        Me.dtpDiaTrabajo.Size = New System.Drawing.Size(88, 20)
        Me.dtpDiaTrabajo.TabIndex = 42
        Me.dtpDiaTrabajo.Value = New Date(2012, 4, 13, 12, 36, 31, 0)
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
        Me.Label22.Size = New System.Drawing.Size(89, 13)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "Punto de Venta"
        '
        'TxtUsuarioNombre
        '
        Me.TxtUsuarioNombre.Location = New System.Drawing.Point(129, 45)
        Me.TxtUsuarioNombre.Name = "TxtUsuarioNombre"
        Me.TxtUsuarioNombre.ReadOnly = True
        Me.TxtUsuarioNombre.Size = New System.Drawing.Size(378, 20)
        Me.TxtUsuarioNombre.TabIndex = 5
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 46)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(53, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Vendedor"
        '
        'TxtClavePdV
        '
        Me.TxtClavePdV.Location = New System.Drawing.Point(259, 16)
        Me.TxtClavePdV.Name = "TxtClavePdV"
        Me.TxtClavePdV.ReadOnly = True
        Me.TxtClavePdV.Size = New System.Drawing.Size(47, 20)
        Me.TxtClavePdV.TabIndex = 7
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(7, 19)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(83, 15)
        Me.LblTipo.TabIndex = 61
        Me.LblTipo.Text = "Día de Trabajo"
        '
        'LblFase
        '
        Me.LblFase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFase.BackColor = System.Drawing.Color.Transparent
        Me.LblFase.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFase.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblFase.Location = New System.Drawing.Point(44, 40)
        Me.LblFase.Name = "LblFase"
        Me.LblFase.Size = New System.Drawing.Size(192, 21)
        Me.LblFase.TabIndex = 77
        Me.LblFase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFolio
        '
        Me.LblFolio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblFolio.Location = New System.Drawing.Point(5, 11)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(257, 27)
        Me.LblFolio.TabIndex = 78
        Me.LblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrpFolio
        '
        Me.GrpFolio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFolio.Controls.Add(Me.LblFolio)
        Me.GrpFolio.Controls.Add(Me.LblFase)
        Me.GrpFolio.Location = New System.Drawing.Point(512, 4)
        Me.GrpFolio.Name = "GrpFolio"
        Me.GrpFolio.Size = New System.Drawing.Size(267, 64)
        Me.GrpFolio.TabIndex = 79
        Me.GrpFolio.TabStop = False
        Me.GrpFolio.Text = "Folio"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(60, 45)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.ReadOnly = True
        Me.TxtUsuario.Size = New System.Drawing.Size(64, 20)
        Me.TxtUsuario.TabIndex = 80
        '
        'TxtNombrePdV
        '
        Me.TxtNombrePdV.Location = New System.Drawing.Point(311, 16)
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
        Me.TabGeneral.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tabInventario, Me.tabTransacciones, Me.tabCobranza, Me.tabArqueo, Me.tabComisiones, Me.tabLiquidacion})
        Me.TabGeneral.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tabInventario
        '
        Me.tabInventario.Controls.Add(Me.BtnAgregar)
        Me.tabInventario.Controls.Add(Me.BtnModificar)
        Me.tabInventario.Controls.Add(Me.BtnEliminar)
        Me.tabInventario.Controls.Add(Me.BtnReimpresion)
        Me.tabInventario.Controls.Add(Me.BtnSalir)
        Me.tabInventario.Controls.Add(Me.grpMovAlmDet)
        Me.tabInventario.Controls.Add(Me.grpMovAlm)
        Me.tabInventario.Location = New System.Drawing.Point(1, 21)
        Me.tabInventario.Name = "tabInventario"
        Me.tabInventario.Size = New System.Drawing.Size(771, 378)
        Me.tabInventario.TabStop = True
        Me.tabInventario.Text = "Inventario"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(677, 335)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nuevo transferencia"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(581, 335)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 16
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar transferencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(389, 335)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
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
        Me.BtnReimpresion.Location = New System.Drawing.Point(485, 335)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
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
        Me.BtnSalir.Location = New System.Drawing.Point(294, 335)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
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
        Me.grpMovAlmDet.Location = New System.Drawing.Point(195, 1)
        Me.grpMovAlmDet.Name = "grpMovAlmDet"
        Me.grpMovAlmDet.Size = New System.Drawing.Size(576, 328)
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
        Me.GridMovAlmDet.Location = New System.Drawing.Point(5, 14)
        Me.GridMovAlmDet.Name = "GridMovAlmDet"
        Me.GridMovAlmDet.RecordNavigator = True
        Me.GridMovAlmDet.Size = New System.Drawing.Size(566, 308)
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
        Me.grpMovAlm.Size = New System.Drawing.Size(192, 328)
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
        Me.GridMovAlm.Location = New System.Drawing.Point(5, 14)
        Me.GridMovAlm.Name = "GridMovAlm"
        Me.GridMovAlm.RecordNavigator = True
        Me.GridMovAlm.Size = New System.Drawing.Size(182, 308)
        Me.GridMovAlm.TabIndex = 3
        Me.GridMovAlm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.GroupBox1.Controls.Add(Me.BtnConsultar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.lblFormVent)
        Me.GroupBox1.Controls.Add(Me.LblVenc)
        Me.GroupBox1.Controls.Add(Me.BtnSalirTrans)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.ChkTodos)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.GridTransaccion)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.cmbVenc)
        Me.GroupBox1.Controls.Add(Me.cmbFormVent)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(1, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(769, 372)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transacciones"
        '
        'lblFormVent
        '
        Me.lblFormVent.Location = New System.Drawing.Point(392, 22)
        Me.lblFormVent.Name = "lblFormVent"
        Me.lblFormVent.Size = New System.Drawing.Size(85, 14)
        Me.lblFormVent.TabIndex = 78
        Me.lblFormVent.Text = "F. de Venta"
        '
        'LblVenc
        '
        Me.LblVenc.Location = New System.Drawing.Point(602, 22)
        Me.LblVenc.Name = "LblVenc"
        Me.LblVenc.Size = New System.Drawing.Size(43, 14)
        Me.LblVenc.TabIndex = 77
        Me.LblVenc.Text = "Venc."
        '
        'BtnSalirTrans
        '
        Me.BtnSalirTrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirTrans.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirTrans.Image = CType(resources.GetObject("BtnSalirTrans.Image"), System.Drawing.Image)
        Me.BtnSalirTrans.Location = New System.Drawing.Point(673, 335)
        Me.BtnSalirTrans.Name = "BtnSalirTrans"
        Me.BtnSalirTrans.Size = New System.Drawing.Size(90, 30)
        Me.BtnSalirTrans.TabIndex = 52
        Me.BtnSalirTrans.Text = "&Salir"
        Me.BtnSalirTrans.ToolTipText = "Salir"
        Me.BtnSalirTrans.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(584, 20)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
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
        Me.PictureBox4.Location = New System.Drawing.Point(745, 19)
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
        Me.GridTransaccion.Size = New System.Drawing.Size(756, 286)
        Me.GridTransaccion.TabIndex = 4
        Me.GridTransaccion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipo.Location = New System.Drawing.Point(241, 17)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(131, 24)
        Me.cmbTipo.TabIndex = 79
        '
        'cmbVenc
        '
        Me.cmbVenc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbVenc.Location = New System.Drawing.Point(649, 17)
        Me.cmbVenc.Name = "cmbVenc"
        Me.cmbVenc.Size = New System.Drawing.Size(91, 24)
        Me.cmbVenc.TabIndex = 53
        '
        'cmbFormVent
        '
        Me.cmbFormVent.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormVent.Location = New System.Drawing.Point(479, 17)
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
        Me.LblFormaVenta.Location = New System.Drawing.Point(106, 22)
        Me.LblFormaVenta.Name = "LblFormaVenta"
        Me.LblFormaVenta.Size = New System.Drawing.Size(113, 14)
        Me.LblFormaVenta.TabIndex = 78
        Me.LblFormaVenta.Text = "Forma de Venta"
        '
        'LblVencimiento
        '
        Me.LblVencimiento.Location = New System.Drawing.Point(375, 22)
        Me.LblVencimiento.Name = "LblVencimiento"
        Me.LblVencimiento.Size = New System.Drawing.Size(87, 14)
        Me.LblVencimiento.TabIndex = 77
        Me.LblVencimiento.Text = "Vencimiento"
        '
        'BtnSalirCxC
        '
        Me.BtnSalirCxC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirCxC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirCxC.Image = CType(resources.GetObject("BtnSalirCxC.Image"), System.Drawing.Image)
        Me.BtnSalirCxC.Location = New System.Drawing.Point(673, 335)
        Me.BtnSalirCxC.Name = "BtnSalirCxC"
        Me.BtnSalirCxC.Size = New System.Drawing.Size(90, 30)
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
        Me.BtnPago.Location = New System.Drawing.Point(578, 335)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(90, 30)
        Me.BtnPago.TabIndex = 51
        Me.BtnPago.Text = "Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago de registros seleccionados"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(356, 20)
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
        Me.PictureBox2.Location = New System.Drawing.Point(563, 19)
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
        Me.GridCxC.Size = New System.Drawing.Size(756, 286)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbVencimiento
        '
        Me.cmbVencimiento.BackColor = System.Drawing.SystemColors.Window
        Me.cmbVencimiento.Location = New System.Drawing.Point(467, 17)
        Me.cmbVencimiento.Name = "cmbVencimiento"
        Me.cmbVencimiento.Size = New System.Drawing.Size(91, 24)
        Me.cmbVencimiento.TabIndex = 53
        '
        'cmbFormaVenta
        '
        Me.cmbFormaVenta.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormaVenta.Location = New System.Drawing.Point(224, 17)
        Me.cmbFormaVenta.Name = "cmbFormaVenta"
        Me.cmbFormaVenta.Size = New System.Drawing.Size(127, 24)
        Me.cmbFormaVenta.TabIndex = 1
        '
        'tabArqueo
        '
        Me.tabArqueo.Controls.Add(Me.GroupBox2)
        Me.tabArqueo.Location = New System.Drawing.Point(1, 21)
        Me.tabArqueo.Name = "tabArqueo"
        Me.tabArqueo.Size = New System.Drawing.Size(771, 378)
        Me.tabArqueo.TabStop = True
        Me.tabArqueo.Text = "Resumen de Movimientos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GridResumen)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(763, 372)
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
        Me.GridResumen.Location = New System.Drawing.Point(5, 14)
        Me.GridResumen.Name = "GridResumen"
        Me.GridResumen.RecordNavigator = True
        Me.GridResumen.Size = New System.Drawing.Size(753, 351)
        Me.GridResumen.TabIndex = 3
        Me.GridResumen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tabComisiones
        '
        Me.tabComisiones.Controls.Add(Me.LblTotalComision)
        Me.tabComisiones.Controls.Add(Me.Label7)
        Me.tabComisiones.Controls.Add(Me.GroupBox6)
        Me.tabComisiones.Controls.Add(Me.GroupBox5)
        Me.tabComisiones.Location = New System.Drawing.Point(1, 21)
        Me.tabComisiones.Name = "tabComisiones"
        Me.tabComisiones.Size = New System.Drawing.Size(771, 378)
        Me.tabComisiones.TabStop = True
        Me.tabComisiones.Text = "Comisiones"
        '
        'LblTotalComision
        '
        Me.LblTotalComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComision.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalComision.Location = New System.Drawing.Point(673, 347)
        Me.LblTotalComision.Name = "LblTotalComision"
        Me.LblTotalComision.Size = New System.Drawing.Size(94, 14)
        Me.LblTotalComision.TabIndex = 87
        Me.LblTotalComision.Text = "0,0"
        Me.LblTotalComision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(573, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 14)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "T. a Comsión"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.GridComisionProd)
        Me.GroupBox6.Location = New System.Drawing.Point(4, 139)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(763, 199)
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
        Me.GridComisionProd.Location = New System.Drawing.Point(5, 14)
        Me.GridComisionProd.Name = "GridComisionProd"
        Me.GridComisionProd.RecordNavigator = True
        Me.GridComisionProd.Size = New System.Drawing.Size(753, 179)
        Me.GridComisionProd.TabIndex = 3
        Me.GridComisionProd.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.GridComisionVta)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(763, 130)
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
        Me.GridComisionVta.Location = New System.Drawing.Point(5, 14)
        Me.GridComisionVta.Name = "GridComisionVta"
        Me.GridComisionVta.RecordNavigator = True
        Me.GridComisionVta.Size = New System.Drawing.Size(753, 110)
        Me.GridComisionVta.TabIndex = 3
        Me.GridComisionVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tabLiquidacion
        '
        Me.tabLiquidacion.Controls.Add(Me.BtnSalirLiq)
        Me.tabLiquidacion.Controls.Add(Me.BtnCerrar)
        Me.tabLiquidacion.Controls.Add(Me.LblSaldo)
        Me.tabLiquidacion.Controls.Add(Me.Label13)
        Me.tabLiquidacion.Controls.Add(Me.LblLiquidado)
        Me.tabLiquidacion.Controls.Add(Me.Label11)
        Me.tabLiquidacion.Controls.Add(Me.LblTotalAbonos)
        Me.tabLiquidacion.Controls.Add(Me.LblTotalLiquidar)
        Me.tabLiquidacion.Controls.Add(Me.LblEgresos)
        Me.tabLiquidacion.Controls.Add(Me.Label6)
        Me.tabLiquidacion.Controls.Add(Me.LblIngresos)
        Me.tabLiquidacion.Controls.Add(Me.Label4)
        Me.tabLiquidacion.Controls.Add(Me.Label2)
        Me.tabLiquidacion.Controls.Add(Me.Label1)
        Me.tabLiquidacion.Controls.Add(Me.GroupBox4)
        Me.tabLiquidacion.Controls.Add(Me.GroupBox3)
        Me.tabLiquidacion.Location = New System.Drawing.Point(1, 21)
        Me.tabLiquidacion.Name = "tabLiquidacion"
        Me.tabLiquidacion.Size = New System.Drawing.Size(771, 378)
        Me.tabLiquidacion.TabStop = True
        Me.tabLiquidacion.Text = "Liquidación"
        '
        'BtnSalirLiq
        '
        Me.BtnSalirLiq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalirLiq.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalirLiq.Image = CType(resources.GetObject("BtnSalirLiq.Image"), System.Drawing.Image)
        Me.BtnSalirLiq.Location = New System.Drawing.Point(581, 334)
        Me.BtnSalirLiq.Name = "BtnSalirLiq"
        Me.BtnSalirLiq.Size = New System.Drawing.Size(90, 37)
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
        Me.BtnCerrar.Location = New System.Drawing.Point(677, 334)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(90, 37)
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
        Me.LblSaldo.Location = New System.Drawing.Point(668, 268)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(94, 14)
        Me.LblSaldo.TabIndex = 90
        Me.LblSaldo.Text = "0.0"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(568, 268)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 14)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "Saldo"
        '
        'LblLiquidado
        '
        Me.LblLiquidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLiquidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLiquidado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblLiquidado.Location = New System.Drawing.Point(668, 249)
        Me.LblLiquidado.Name = "LblLiquidado"
        Me.LblLiquidado.Size = New System.Drawing.Size(94, 14)
        Me.LblLiquidado.TabIndex = 88
        Me.LblLiquidado.Text = "0.0"
        Me.LblLiquidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(568, 249)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 14)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Liquidado"
        '
        'LblTotalAbonos
        '
        Me.LblTotalAbonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalAbonos.Location = New System.Drawing.Point(72, 249)
        Me.LblTotalAbonos.Name = "LblTotalAbonos"
        Me.LblTotalAbonos.Size = New System.Drawing.Size(95, 14)
        Me.LblTotalAbonos.TabIndex = 86
        Me.LblTotalAbonos.Text = "0,0"
        Me.LblTotalAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalLiquidar
        '
        Me.LblTotalLiquidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalLiquidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalLiquidar.Location = New System.Drawing.Point(273, 294)
        Me.LblTotalLiquidar.Name = "LblTotalLiquidar"
        Me.LblTotalLiquidar.Size = New System.Drawing.Size(94, 14)
        Me.LblTotalLiquidar.TabIndex = 85
        Me.LblTotalLiquidar.Text = "0,0"
        Me.LblTotalLiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblEgresos
        '
        Me.LblEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEgresos.Location = New System.Drawing.Point(273, 268)
        Me.LblEgresos.Name = "LblEgresos"
        Me.LblEgresos.Size = New System.Drawing.Size(94, 14)
        Me.LblEgresos.TabIndex = 84
        Me.LblEgresos.Text = "0,0"
        Me.LblEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 14)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "T. Abonos"
        '
        'LblIngresos
        '
        Me.LblIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblIngresos.Location = New System.Drawing.Point(274, 249)
        Me.LblIngresos.Name = "LblIngresos"
        Me.LblIngresos.Size = New System.Drawing.Size(94, 14)
        Me.LblIngresos.TabIndex = 82
        Me.LblIngresos.Text = "0,0"
        Me.LblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(174, 294)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "T. a Liquidar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(174, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 14)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "T. Egreso"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(175, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "T. Ingreso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.GridLiquidacion)
        Me.GroupBox4.Location = New System.Drawing.Point(172, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(595, 239)
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
        Me.GridLiquidacion.Location = New System.Drawing.Point(5, 14)
        Me.GridLiquidacion.Name = "GridLiquidacion"
        Me.GridLiquidacion.RecordNavigator = True
        Me.GridLiquidacion.Size = New System.Drawing.Size(585, 219)
        Me.GridLiquidacion.TabIndex = 3
        Me.GridLiquidacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.GridAbonos)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(163, 239)
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
        Me.GridAbonos.Location = New System.Drawing.Point(5, 14)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(152, 219)
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
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(377, 20)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 80
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(200, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Tipo"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnConsultar.Location = New System.Drawing.Point(298, 335)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 30)
        Me.BtnConsultar.TabIndex = 82
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.ToolTipText = "Mostra documento seleccionado"
        Me.BtnConsultar.Visible = False
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSend.Icon = CType(resources.GetObject("BtnSend.Icon"), System.Drawing.Icon)
        Me.BtnSend.Location = New System.Drawing.Point(486, 335)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(92, 30)
        Me.BtnSend.TabIndex = 84
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.ToolTipText = "Envio por correo electrónico"
        Me.BtnSend.Visible = False
        Me.BtnSend.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(205, 335)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 85
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.Visible = False
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.Location = New System.Drawing.Point(580, 335)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 30)
        Me.BtnNuevo.TabIndex = 86
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.ToolTipText = "Crea una nueva registro"
        Me.BtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFacturar.Image = CType(resources.GetObject("BtnFacturar.Image"), System.Drawing.Image)
        Me.BtnFacturar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnFacturar.Location = New System.Drawing.Point(487, 335)
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(90, 30)
        Me.BtnFacturar.TabIndex = 87
        Me.BtnFacturar.Text = "Facturar"
        Me.BtnFacturar.ToolTipText = "Crear nueva factura de registros seleccionados"
        Me.BtnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Image = CType(resources.GetObject("BtnDevolucion.Image"), System.Drawing.Image)
        Me.BtnDevolucion.Location = New System.Drawing.Point(391, 335)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(90, 30)
        Me.BtnDevolucion.TabIndex = 88
        Me.BtnDevolucion.Text = "Devolución"
        Me.BtnDevolucion.ToolTipText = "Crear Devolución"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmLiquid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.TxtClavePdV)
        Me.Controls.Add(Me.TabGeneral)
        Me.Controls.Add(Me.TxtNombrePdV)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.GrpFolio)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dtpDiaTrabajo)
        Me.Controls.Add(Me.LblTipo)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtUsuarioNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmLiquid"
        Me.Text = "Liquidación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpFolio.ResumeLayout(False)
        CType(Me.TabGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGeneral.ResumeLayout(False)
        Me.tabInventario.ResumeLayout(False)
        Me.grpMovAlmDet.ResumeLayout(False)
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovAlm.ResumeLayout(False)
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransacciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTransaccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCobranza.ResumeLayout(False)
        Me.GrpTickets.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabArqueo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComisiones.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLiquidacion.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private alerta(4) As PictureBox
    Private reloj As parpadea
    Private FormatoFactura, FormatoNC, FormatCargo As String

    Private Impresora, ImpresoraLQ As String
    Private bLoad As Boolean = False
    Private sMOVALMSelected As String
    Private sMOVALMFolio As String
    Private ClaveCaja As String
    Private Moneda, RefMoneda As String

    Private TotalAbonos, Ingresos, Egresos, ComisionVta, ComisionProd As Double
    'Transacciones
    Private sDocumentoSelected As String
    Private sEstado As String
    Private sFolio As String
    Private dTotalDoc As Double
    Private dSaldoDoc As Double
    Private iTipoCF, iLogo As Integer
    Private sUUID As String
    Private sRFC As String
    Private sCTEClave As String
    Private sDevTipo As String
    Private Autoriza As String
    Private dFecha As Date

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

    Private SaldoBase As Decimal

    Private TICDevolucion As String
    Private CajaClave As String
    Private CajaNombre As String
    Private FormatoPedido As String
    Private Cajon As Boolean = False

    Public LIQClave As String
    Public ClaveVEN As String
    Public NombreVEN As String
    Public ClavePDV As String
    Public NombrePDV As String
    Public DiaTrabajo As Date
    Public Folio As String
    Public CAJClave As String
    Public ALMClave As String
    Public SUCClave As String
    Public PDVClave As String
    Public VendedorClave As String
    Public Fase As Integer


    Public Sub actualizaGridMovAlm()
        bLoad = False

        ModPOS.ActualizaGrid(False, Me.GridMovAlm, "sp_muestra_movalm", "@LIQClave", LIQClave)
        Me.GridMovAlm.RootTable.Columns("MVAClave").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridMovAlm.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridMovAlm.RootTable.FormatConditions.Add(fc)


        If Not Me.GridMovAlm.GetValue(0) Is Nothing Then
            Me.sMOVALMSelected = GridMovAlm.GetValue(0)
            sMOVALMFolio = GridMovAlm.GetValue(1)
            If Fase = 1 Then
                Me.BtnModificar.Enabled = True
                Me.BtnEliminar.Enabled = True
                Me.BtnReimpresion.Enabled = True
            Else
                Me.BtnModificar.Enabled = False
                Me.BtnEliminar.Enabled = False
            End If
        Else
            Me.sMOVALMSelected = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.BtnReimpresion.Enabled = False
            sMOVALMFolio = ""
        End If

        ModPOS.ActualizaGrid(False, Me.GridMovAlmDet, "sp_detalle_transferencia", "@MVAClave", sMOVALMSelected)
        GridMovAlmDet.RootTable.Columns("ID").Visible = False
        GridMovAlmDet.RootTable.Columns("PROClave").Visible = False
        GridMovAlmDet.RootTable.Columns("TProducto").Visible = False
        GridMovAlmDet.RootTable.Columns("Costo").Visible = False
        GridMovAlmDet.RootTable.Columns("Total").Visible = False


        bLoad = True


    End Sub

    Private Sub FrmMtoLiquid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)


        Cursor.Current = Cursors.WaitCursor


        Dim dt As DataTable



        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        Me.StartPosition = FormStartPosition.CenterScreen
        dtpDiaTrabajo.Value = DiaTrabajo

        TxtClavePdV.Text = ClavePDV
        TxtNombrePdV.Text = NombrePDV
        TxtUsuario.Text = ClaveVEN
        TxtUsuarioNombre.Text = NombreVEN
        LblFolio.Text = Folio
        Cursor.Current = Cursors.Default


        If Fase <> 1 Then
            LblFase.Text = "Cerrada"
            Me.BtnAgregar.Enabled = False
            Me.BtnCancelar.Enabled = False
            Me.BtnCerrar.Enabled = False

            Me.BtnDevolucion.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.BtnFacturar.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnPago.Enabled = False
        End If

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
                    Case "FormatNC"
                        FormatoNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatPedido"
                        FormatoPedido = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))

                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatCargo"
                        FormatCargo = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))

                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()

        If iTipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
        End If

        actualizaGridMovAlm()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        RefMoneda = dt.Rows(0)("Referencia")
        dt.Dispose()


        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)

        'Recibo = dt.Rows(0)("TIKClave")
        ClaveCaja = dt.Rows(0)("Clave")
        TICDevolucion = dt.Rows(0)("TICDevolucion")
        Impresora = dt.Rows(0)("Referencia")
        '       PrintGeneric = dt.Rows(0)("Generic")
        ImpresoraLQ = dt.Rows(0)("ImpresoraFac")
        CajaClave = dt.Rows(0)("Clave")
        CajaNombre = dt.Rows(0)("Nombre")

        'Manual = IIf(dt.Rows(0)("Manual").GetType.Name = "DBNull", 0, dt.Rows(0)("Manual"))
        Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))

        dt.Dispose()



    End Sub

    Private Sub FrmLiquid_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Liquid.Dispose()
        ModPOS.Liquid = Nothing
    End Sub

    Private Sub GridMovAlm_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMovAlm.SelectionChanged
        If bLoad = True Then
            If Not Me.GridMovAlm.GetValue(0) Is Nothing Then

                If Fase = 1 Then
                    Me.BtnModificar.Enabled = True
                    Me.BtnEliminar.Enabled = True
                    Me.BtnReimpresion.Enabled = True
                Else
                    Me.BtnModificar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                End If

                Me.sMOVALMSelected = GridMovAlm.GetValue(0)
                sMOVALMFolio = GridMovAlm.GetValue(1)
            Else
                Me.sMOVALMSelected = ""
                Me.BtnModificar.Enabled = False
                Me.BtnEliminar.Enabled = False
                Me.BtnReimpresion.Enabled = False

                sMOVALMFolio = ""
            End If
            ModPOS.ActualizaGrid(False, Me.GridMovAlmDet, "sp_detalle_transferencia", "@MVAClave", sMOVALMSelected)
            GridMovAlmDet.RootTable.Columns("ID").Visible = False
            GridMovAlmDet.RootTable.Columns("PROClave").Visible = False
            GridMovAlmDet.RootTable.Columns("TProducto").Visible = False
            GridMovAlmDet.RootTable.Columns("Costo").Visible = False
            GridMovAlmDet.RootTable.Columns("Total").Visible = False
        End If
    End Sub

    Public Sub modificarMOVALM()
        If sMOVALMSelected <> "" Then
            If ModPOS.Transferencia Is Nothing Then
                ModPOS.Transferencia = New FrmMOVALM
                With ModPOS.Transferencia
                    .Text = "Modificar Transferencia"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .FormPadre = LIQClave

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", Me.sMOVALMSelected)
                    .MVAClave = dt.Rows(0)("MVAClave")
                    .Motivo = dt.Rows(0)("Motivo")
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .ALMDestino = dt.Rows(0)("ALMDestino")
                    .Folio = dt.Rows(0)("Folio")
                    .FecRegistro = dt.Rows(0)("FechaRegistro")
                    .Notas = dt.Rows(0)("Notas")
                    .Estado = dt.Rows(0)("Estado")
                    '.TxtSucursal.Text = dt.Rows(0)("NAlmacen")
                    .DescripcionEstado = dt.Rows(0)("NEstado")
                    dt.Dispose()

                End With
            End If

            ModPOS.Transferencia.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Transferencia.Show()
            ModPOS.Transferencia.BringToFront()

        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Transferencia Is Nothing Then
            ModPOS.Transferencia = New FrmMOVALM
            ModPOS.Transferencia.Padre = "Nuevo"
            ' ModPOS.Transferencia.TxtSucursal.Text = CmbAlmacen.SelectedItem.row.itemarray(1)
            ModPOS.Transferencia.ALMDestino = ALMClave
            ModPOS.Transferencia.FormPadre = LIQClave
        End If
        ModPOS.Transferencia.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Transferencia.Show()
        ModPOS.Transferencia.BringToFront()

    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sMOVALMSelected <> "" Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", sMOVALMSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", sMOVALMSelected))
            OpenReport.PrintPreview("Transferencia", "CRTransferencia.rpt", pvtaDataSet, "")
        Else
            MessageBox.Show("¡No se ha seleccionado una Movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sMOVALMSelected <> "" Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar el Movimiento: " & sMOVALMFolio & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim dt As DataTable

                    Dim iEstado As Integer
                    dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", Me.sMOVALMSelected)
                    iEstado = dt.Rows(0)("Estado")
                    dt.Dispose()

                    If iEstado = 1 Then
                        ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", sMOVALMSelected, "@Usuario", ModPOS.UsuarioActual)
                        actualizaGridMovAlm()
                    Else
                        MessageBox.Show("No es posible cancelar ek movimiento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

            End Select
        End If


    End Sub

    Private Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarMOVALM()
    End Sub

    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtCxC.Select("Marca ='True' and SaldoBase > 0")

            If foundRows.GetLength(0) > 0 Then

                Dim fr() As DataRow
                fr = dtCxC.Select("Marca ='True' AND SaldoBase > 0 and CTEClave <> '" & foundRows(0)("CTEClave") & "'")

                If fr.GetLength(0) >= 1 Then
                    MessageBox.Show("No es posible realizar pagos de diferentes clientes a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim dtDoctos, dtAbnSaldo As DataTable
                dtDoctos = foundRows.CopyToDataTable()

                Dim idEvento As String = ""

                dtAbnSaldo = Recupera_Tabla("sp_aplicar_abn", "@CTEClave", dtDoctos.Rows(0)("CTEClave"))
                If dtAbnSaldo.Rows.Count > 0 Then

                    'Validar Promociones Pago

                    Dim i As Integer
                    Dim dtPromo As DataTable
                    Dim AplicaAnticipos As Boolean = True

                    If dtDoctos.Rows.Count > 1 Then
                        For i = 0 To dtDoctos.Rows.Count - 1
                            If CInt(dtDoctos.Rows(i)("TipoDocumento")) = 1 Then
                                dtPromo = ModPOS.Recupera_Tabla("st_valida_pago_promo", "@VENClave", CStr(dtDoctos.Rows(i)("ID")))
                                If dtPromo.Rows.Count > 0 Then
                                    MessageBox.Show("El documento: " & CStr(dtDoctos.Rows(i)("Folio")) & ", tiene promociones que limitan esta forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Next
                    Else
                        If CInt(dtDoctos.Rows(0)("TipoDocumento")) = 1 Then
                            dtPromo = ModPOS.Recupera_Tabla("st_valida_pago_promo", "@VENClave", CStr(dtDoctos.Rows(0)("ID")))
                            If dtPromo.Rows.Count > 0 Then
                                MessageBox.Show("El documento: " & CStr(dtDoctos.Rows(0)("Folio")) & ", tiene promociones que limitan esta forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                AplicaAnticipos = False
                            End If
                        End If
                    End If

                    If AplicaAnticipos = True Then
                        Dim b As New FrmAbnPendiente
                        b.BtnCancel.Text = "Ignorar"
                        b.Abonos = dtAbnSaldo
                        b.MonRef = RefMoneda
                        b.SaldoDocumento = SaldoBase
                        b.ShowDialog()

                        If b.DialogResult = DialogResult.OK Then
                            If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then

                                idEvento = obtenerLlave()

                                For i = 0 To b.drAbonos.Length - 1
                                    ModPOS.Aplica_Pagos(dtDoctos, dtDoctos.Rows(0)("CTEClave"), b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("SaldoBase"), CAJClave, b.drAbonos(i)("Tipo"), b.drAbonos(i)("Fecha"), idEvento)
                                Next
                            End If
                        End If
                    End If
                End If
                dtAbnSaldo.Dispose()

                Dim SaldoDoctos As Decimal = IIf(dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0") Is System.DBNull.Value, 0, dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0"))

                If SaldoDoctos > 0 Then
                    Dim a As New FrmAbono
                    a.SUCClave = SUCClave
                    a.VariosPagos = IIf(dtDoctos.Rows.Count = 1, False, True)
                    a.TipoDocumento = dtDoctos.Rows(0)("TipoDocumento")
                    a.CAJA = CAJClave
                    a.ClaveCaja = ClaveCaja
                    a.ClaveCte = dtDoctos.Rows(0)("CTEClave")
                    a.ClaveDocumento = dtDoctos.Rows(0)("ID")
                    a.SaldoAcumulado = SaldoDoctos
                    a.AperturaCajon = Cajon
                    a.ImpresoraCajon = Impresora
                    a.ShowDialog()

                    If a.DialogResult = DialogResult.OK Then
                        If a.detallePago.Rows.Count > 0 Then
                            Dim i As Integer
                            idEvento = IIf(idEvento = "", a.id_evento, idEvento)
                            For i = 0 To a.detallePago.Rows.Count - 1
                                ModPOS.Aplica_Pagos(dtDoctos, dtDoctos.Rows(0)("CTEClave"), a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("SaldoBase"), CAJClave, 1, a.detallePago.Rows(i)("FechaPago"), idEvento)
                            Next
                            dtCxC.Dispose()
                            ActualizaGridCxC()
                        End If

                    End If
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

            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
            End If

            dtCxC = ModPOS.Recupera_Tabla("sp_recupera_liq_cxc", "@LIQClave", LIQClave, "@FormaVenta", cmbFormaVenta.SelectedValue, "@Vencimiento", cmbVencimiento.SelectedValue)
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
            GridCxC.CurrentTable.Columns("SaldoBase").Visible = False
            GridCxC.CurrentTable.Columns("MONClave").Visible = False

            If cmbFormaVenta.SelectedValue = 1 Then
                LblVencimiento.Visible = False
                cmbVencimiento.Visible = False
            Else
                LblVencimiento.Visible = True
                cmbVencimiento.Visible = True
            End If

            SaldoBase = 0
            ChkMarcaTodos.Enabled = True
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TabGeneral_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles TabGeneral.SelectedTabChanged
        Select Case e.Page.Name
            Case Is = "tabCobranza"
                ActualizaGridCxC()
            Case Is = "tabTransacciones"
                ActualizaGridTransac()
            Case Is = "tabArqueo"
                ModPOS.ActualizaGrid(False, GridResumen, "sp_movimientos_liq", "@LIQClave", LIQClave)
            Case Is = "tabComisiones"
                ModPOS.ActualizaGrid(False, GridComisionVta, "sp_liq_comision_vta", "@LIQClave", LIQClave)
                ModPOS.ActualizaGrid(False, GridComisionProd, "sp_liq_comision_prod", "@LIQClave", LIQClave)

                ComisionVta = GridComisionProd.GetTotal(GridComisionProd.CurrentTable.Columns("Comision"), Janus.Windows.GridEX.AggregateFunction.Sum)
                ComisionProd = GridComisionVta.GetTotal(GridComisionVta.CurrentTable.Columns("Comision"), Janus.Windows.GridEX.AggregateFunction.Sum)

                LblTotalComision.Text = Format(CStr(ModPOS.Redondear(ComisionVta + ComisionProd, 2)), "Currency")

            Case Is = "tabLiquidacion"
                ModPOS.ActualizaGrid(False, GridAbonos, "sp_liq_pagos", "@LIQClave", LIQClave)

                TotalAbonos = GridAbonos.GetTotal(GridAbonos.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                LblTotalAbonos.Text = Format(CStr(ModPOS.Redondear(TotalAbonos, 2)), "Currency")

                ModPOS.ActualizaGrid(False, GridLiquidacion, "sp_liq_corte", "@LIQClave", LIQClave)

                Ingresos = GridLiquidacion.GetTotal(GridLiquidacion.CurrentTable.Columns("Ingreso"), Janus.Windows.GridEX.AggregateFunction.Sum)
                LblIngresos.Text = Format(CStr(ModPOS.Redondear(Ingresos, 2)), "Currency")

                Egresos = GridLiquidacion.GetTotal(GridLiquidacion.CurrentTable.Columns("Egreso"), Janus.Windows.GridEX.AggregateFunction.Sum)
                LblEgresos.Text = Format(CStr(ModPOS.Redondear(Egresos, 2)), "Currency")

                LblTotalLiquidar.Text = Format(CStr(ModPOS.Redondear(Ingresos - Egresos, 2)), "Currency")



        End Select

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
                SaldoBase = 0
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = False
                Next
            End If



            SaldoBase = IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True"))
        End If

    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtTran.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridTransaccion.GetDataRows.Length - 1
                    SaldoBase = 0
                    GridTransaccion.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridTransaccion.GetDataRows.Length - 1
                    GridTransaccion.GetDataRows(i).DataRow("Marca") = False
                Next
            End If


            ' dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
        End If

    End Sub

    Public Sub ActualizaGridTransac()
        If validaTransaccion() Then

            If Not dtTran Is Nothing Then
                dtTran.Dispose()
            End If

            dtTran = ModPOS.Recupera_Tabla("sp_recupera_liq_tran", "@LIQClave", LIQClave, "@Tipo", cmbTipo.SelectedValue, "@FormaVenta", cmbFormVent.SelectedValue, "@Vencimiento", cmbVenc.SelectedValue)
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

                .CurrentTable.Columns("Logo").Visible = False
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
                iLogo = 0
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
                ' BtnReimprimir.Visible = False
                BtnSend.Visible = False
                BtnCancelar.Visible = True

            ElseIf cmbTipo.SelectedValue = 2 Then

                BtnNuevo.Visible = True
                BtnNuevo.Text = "NC"

                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = True
                '  BtnReimprimir.Visible = True
                BtnSend.Visible = True
                BtnCancelar.Visible = True

            ElseIf cmbTipo.SelectedValue = 3 Then
                BtnNuevo.Visible = False

                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = True
                ' BtnReimprimir.Visible = True
                BtnSend.Visible = True
                BtnCancelar.Visible = True

            ElseIf cmbTipo.SelectedValue = 4 Then

                BtnNuevo.Visible = False

                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = False
                '  BtnReimprimir.Visible = False
                BtnSend.Visible = False
                BtnCancelar.Visible = False

            ElseIf cmbTipo.SelectedValue = 5 Then

                BtnNuevo.Visible = True
                BtnNuevo.Text = "Nota Cargo"
                BtnFacturar.Visible = False
                BtnDevolucion.Visible = False

                BtnConsultar.Visible = True
                ' BtnReimprimir.Visible = True
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
            ElseIf cmbTipo.SelectedValue = 1 AndAlso foundRows(0)("Estado") <> "Cerrado" Then
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

                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)("ID"), "@TipoDoc", 1, "@Autoriza", Autoriza)
                                    ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))
                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("ID"), "@Tipo", 1)


                                Case Is = 2 'Factura

                                    Dim bmotivo As Boolean = False
                                    Dim MotCancelacion As Integer
                                    Dim bCancela As Boolean = False
                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Factura"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            MotCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    Dim eRFC, rRFC, sVersionCF As String
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(0)("ID"))
                                    rRFC = dt.Rows(0)("id_Fiscal")
                                    eRFC = dt.Rows(0)("cRFC")
                                    sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") = "Activa" Then
                                        If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                        bCancela = ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC, sVersionCF, 2, foundRows(0)("ID"))
                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    ElseIf foundRows(0)("Estado") = "Espera" Then
                                        bCancela = ModPOS.ObtenerEspera(dtPAC, rRFC, 2, foundRows(0)("ID"), sUUID)

                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    End If

                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", foundRows(0)("ID"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)
                                    ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                  
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("ID"), "@Tipo", 2)

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") <> "Activa" Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)("ID"))
                                    End If

                                Case Is = 3 ' NC

                                    Dim bmotivo As Boolean = False
                                    Dim MotCancelacion As Integer
                                    Dim bCancela As Boolean = False

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "NC"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            MotCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    Dim eRFC, rRFC, sVersionCF As String
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(0)("ID"))
                                    rRFC = dt.Rows(0)("id_Fiscal")
                                    eRFC = dt.Rows(0)("cRFC")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()


                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") = "Activa" Then

                                       
                                        bCancela = ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC, sVersionCF, 4, foundRows(0)("ID"))

                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    ElseIf foundRows(0)("Estado") = "Espera" Then
                                        bCancela = ModPOS.ObtenerEspera(dtPAC, rRFC, 4, foundRows(0)("ID"), sUUID)

                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    End If

                                    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", foundRows(0)("ID"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    If sDevTipo = "Devolución" = 1 Then
                                        ModPOS.GeneraMovInv(2, 5, 4, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                    End If


                                Case Is = 4  ' Devolucion

                                    Dim bmotivo As Boolean = False
                                    Dim MotCancelacion As Integer
                                    Dim bCancela As Boolean = False

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "NC"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            MotCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    ModPOS.Ejecuta("sp_cancela_devolucion", "@DEVClave", foundRows(0)("ID"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_vta", "@DEVClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    ModPOS.GeneraMovInv(2, 5, 3, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                 
                                Case Is = 5 'Nota Cargo

                                    Dim bmotivo As Boolean = False
                                    Dim MotCancelacion As Integer
                                    Dim bCancela As Boolean = False
                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Factura"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            MotCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    Dim eRFC, rRFC, sVersionCF As String
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(0)("ID"))
                                    rRFC = dt.Rows(0)("id_Fiscal")
                                    eRFC = dt.Rows(0)("cRFC")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()

                                    If foundRows(0)("TipoCF") = 2 AndAlso foundRows(0)("Estado") = "Activa" Then

                                        If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                       

                                        bCancela = ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC, sVersionCF, 6, foundRows(0)("ID"))
                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    ElseIf foundRows(0)("Estado") = "Espera" Then
                                        bCancela = ModPOS.ObtenerEspera(dtPAC, rRFC, 6, foundRows(0)("ID"), sUUID)

                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    End If

                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", foundRows(0)("ID"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

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

                Dim MonRef, MonDesc, VersionCF As String
                Dim TipoCambio As Double

                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", sTipo, "@Documento", sDocumentoSelected)
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                VersionCF = dt.Rows(0)("VersionCF")
                dt.Dispose()

                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"

                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))

                If cmbTipo.SelectedValue = 2 Then


                    ModPOS.SendMail(VersionCF, sMailCliente, iTipoCF, FormatoFactura, dFecha, sFolio, sDocumentoSelected, dTotalDoc, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonRef, MonDesc, iLogo)

                   
                ElseIf cmbTipo.SelectedValue = 3 Then


                    ModPOS.SendMailNC(VersionCF, sMailCliente, iTipoCF, FormatoNC, dFecha, sFolio, sDocumentoSelected, dTotalDoc, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonDesc, MonRef, iLogo, True)


                  
                ElseIf cmbTipo.SelectedValue = 5 Then

                    ModPOS.SendMailCargo(VersionCF, sMailCliente, FormatCargo, dFecha, sFolio, sDocumentoSelected, dTotalDoc, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, TipoCambio, MonDesc, MonRef, iLogo, True)


                  

                End If

             
            Else
                MessageBox.Show("¡No se ha seleccionado un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub



    Private Sub Imprimir()

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet

        If cmbTipo.SelectedValue = 1 Then
            
            previewPedido(FormatoPedido, sDocumentoSelected, dTotalDoc, SUCClave)

            Exit Sub
        End If

        Dim MonRef, MonDesc, sFormato, sVersionCF As String
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
        sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
        sVersionCF = dt.Rows(0)("VersionCF")
        dt.Dispose()

        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))


        If cmbTipo.SelectedValue = 2 Then

            ModPOS.previewFactura(iTipoCF, sFormato, sDocumentoSelected, dTotalDoc, SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF, iLogo)


        ElseIf cmbTipo.SelectedValue = 3 Then

            ModPOS.previewNC(iTipoCF, sFormato, sDocumentoSelected, dTotalDoc, SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF, iLogo)

           

        ElseIf cmbTipo.SelectedValue = 5 Then ' Nota Cargo

            ModPOS.previewCargo(sFormato, sDocumentoSelected, dTotalDoc, TipoCambio, MonDesc, MonRef, sVersionCF, iLogo)

         
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
            If cmbTipo.SelectedValue = 2 OrElse cmbTipo.SelectedValue = 3 Then
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
                    MessageBox.Show("¡No se ha seleccionado una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            dFecha = GridTransaccion.GetValue("Fecha")
            sCTEClave = GridTransaccion.GetValue("CTEClave")
            sRFC = GridTransaccion.GetValue("RFC")
            iLogo = GridTransaccion.GetValue("Logo")
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
            iLogo = 0
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
                ModPOS.Devolucion.Padre = "Liquidacion"
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = CajaClave
                ModPOS.Devolucion.Atiende = MPrincipal.StUsuario.Text
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
            ModPOS.PreVenta.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
            ModPOS.PreVenta.StartPosition = FormStartPosition.CenterScreen

            With ModPOS.PreVenta
                '  .Padre = "Liquidacion"
                .ALMClave = dt.Rows(0)("ALMClave")
                .AlmacenClave = dt.Rows(0)("Clave")
                .AlmacenNombre = dt.Rows(0)("Nombre")
                .PDVClave = dt.Rows(0)("PDVClave")
                .PuntodeVenta = dt.Rows(0)("Descripcion")
                .Referencia = dt.Rows(0)("Referencia")
                .Impresora = dt.Rows(0)("Impresora")
                .Ticket = dt.Rows(0)("Ticket")
                .Supervisor = dt.Rows(0)("Supervisor")
                .Caja = False

                .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                .CAJClave = dt.Rows(0)("CAJClave")
                .CTEClaveInicial = dt.Rows(0)("CTEClave")
                .CTENombreInicial = dt.Rows(0)("Cliente")

                .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                .Redondeo = dt.Rows(0)("Redondeo")
                .Agotamiento = dt.Rows(0)("Agotamiento")
                .SolicitaVendedor = dt.Rows(0)("SolicitaVendedor")
                .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
                .LblFolio.Text = .Referencia & "- 0"
                .PrintGeneric = dt.Rows(0)("Generic")
                .sFrase = dt.Rows(0)("Frase")
                .ActivaDevolucion = dt.Rows(0)("Devolucion")
                .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

                .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))
                .Display = IIf(dt.Rows(0)("PoleDisplay").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("PoleDisplay"))))
                .Port = IIf(dt.Rows(0)("Puerto").GetType.Name = "DBNull", "COM5", dt.Rows(0)("Puerto"))
                .BaudRate = IIf(dt.Rows(0)("BaudRate").GetType.Name = "DBNull", 9600, dt.Rows(0)("BaudRate"))
                .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
                .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))
                .ActivarCotizacion = IIf(dt.Rows(0)("ActivarCotizacion").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ActivarCotizacion"))))
                .SucursalSurtido = dt.Rows(0)("SUCClave")
                .TipoVenta = IIf(dt.Rows(0)("TipoVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoVenta"))

                .txtLimite.Text = dt.Rows(0)("LimiteCredito")
                .txtDias.Text = dt.Rows(0)("DiasCredito")
                .txtSaldo.Text = dt.Rows(0)("SaldoCliente")

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


    Private Sub imprimirLiquidacion()
        Dim sImpresora As String
        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", ImpresoraLQ)
        sImpresora = dtPrinter.Rows(0)("Referencia")
        dtPrinter.Dispose()


        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_movimientos_liq", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_general", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_corte", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_pagos", "@LIQClave", LIQClave))

        ' OpenReport.PrintPreview("Liquidación", "CRLiquidacion.rpt", pvtaDataSet, "")

        OpenReport.Print(1, "CRLiquidacion.rpt", pvtaDataSet, "", sImpresora)

    End Sub



    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If Fase = 1 Then
            If TotalAbonos < Ingresos Then
                MessageBox.Show("No es posible cerrar la liquidación debido a que el importe total de los abonos debe ser igual al total de ingresos de las operaciones registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim a As New FrmArqueoLiq
            a.TotalLiquidar = Ingresos - Egresos
            a.LIQClave = Me.LIQClave
            a.Fase = 1
            a.ShowDialog()
            Fase = a.fase

        End If
        imprimirLiquidacion()
        imprimirComision()

    End Sub

    Private Sub BtnSalirLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirLiq.Click
        Me.Close()
    End Sub

    Private Sub GridCxC_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        If GridCxC.GetValue("Marca") = True Then
            SaldoBase += CDbl(GridCxC.GetValue("SaldoBase"))
        Else
            SaldoBase -= CDbl(GridCxC.GetValue("SaldoBase"))
        End If
    End Sub


    Private Sub imprimirComision()
        Dim sImpresora As String
        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", ImpresoraLQ)
        sImpresora = dtPrinter.Rows(0)("Referencia")
        dtPrinter.Dispose()


        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_general", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_comision_prod", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_comision_vta", "@LIQClave", LIQClave))
       
        ' OpenReport.PrintPreview("Comisiones", "CRComision.rpt", pvtaDataSet, "")

        OpenReport.Print(1, "CRComision.rpt", pvtaDataSet, "", sImpresora)

    End Sub


  
 
End Class
