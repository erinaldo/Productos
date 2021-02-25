Imports System.Net
Imports System.Net.Mail

Public Class FrmCompania
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpIcono As System.Windows.Forms.GroupBox
    Friend WithEvents PictIcono As System.Windows.Forms.PictureBox
    Friend WithEvents GrpActividad As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabParam As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtFax As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NumLineNota As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumLineFactura As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumCliente As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumProveedor As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumCompra As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnExplorador As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmbImpuesto As Selling.StoreCombo
    Friend WithEvents NumPorcRiesgo As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumHistorico As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents TxtRFC As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents UiTabMail As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtHostSMTP As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtMailUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents TxtMailAdress As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ChkMailSSL As Selling.ChkStatus
    Friend WithEvents TxtMailPassword As System.Windows.Forms.TextBox
    Friend WithEvents BtnTest As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents CmbFormatOC As System.Windows.Forms.ComboBox
    Friend WithEvents NumTimeOut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents UiTabCFD As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BtnXML As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtXML As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCF As Selling.StoreCombo
    Friend WithEvents cmbVersionCF As Selling.StoreCombo
    Friend WithEvents cmbRegimenFiscal As Selling.StoreCombo
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbMetodoPago As Selling.StoreCombo
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmbMonedaCambio As Selling.StoreCombo
    Friend WithEvents cmbMoneda As Selling.StoreCombo
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents GrpPAC As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAddPAC As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnDelPAC As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridPAC As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbFactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtRegPatronal As System.Windows.Forms.TextBox
    Friend WithEvents cmbRiesgoPuesto As Selling.StoreCombo
    Friend WithEvents lblRiesgo As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicacion As Selling.ChkStatus
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbCosteo As Selling.StoreCombo
    Friend WithEvents TxtMailPort As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompania))
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox
        Me.cmbRiesgoPuesto = New Selling.StoreCombo
        Me.lblRiesgo = New System.Windows.Forms.Label
        Me.TxtRegPatronal = New System.Windows.Forms.TextBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtNoInterior = New System.Windows.Forms.TextBox
        Me.TxtNoExterior = New System.Windows.Forms.TextBox
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.CmbPaisFac = New Selling.StoreCombo
        Me.Label21 = New System.Windows.Forms.Label
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtFax = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.TxtTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GrpIcono = New System.Windows.Forms.GroupBox
        Me.PictIcono = New System.Windows.Forms.PictureBox
        Me.GrpActividad = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox13 = New System.Windows.Forms.PictureBox
        Me.lblRFC = New System.Windows.Forms.Label
        Me.TxtRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.UiTabParam = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ChkAplicacion = New Selling.ChkStatus(Me.components)
        Me.txtSucursal = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.PictureBox23 = New System.Windows.Forms.PictureBox
        Me.cmbFactura = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.PictureBox21 = New System.Windows.Forms.PictureBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.PictureBox20 = New System.Windows.Forms.PictureBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.NumTimeOut = New System.Windows.Forms.NumericUpDown
        Me.Label30 = New System.Windows.Forms.Label
        Me.PictureBox14 = New System.Windows.Forms.PictureBox
        Me.CmbFormatOC = New System.Windows.Forms.ComboBox
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.NumPorcRiesgo = New System.Windows.Forms.NumericUpDown
        Me.Label26 = New System.Windows.Forms.Label
        Me.NumHistorico = New System.Windows.Forms.NumericUpDown
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbMonedaCambio = New Selling.StoreCombo
        Me.cmbMoneda = New Selling.StoreCombo
        Me.CmbImpuesto = New Selling.StoreCombo
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.BtnExplorador = New Janus.Windows.EditControls.UIButton
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.NumLineNota = New System.Windows.Forms.NumericUpDown
        Me.NumLineFactura = New System.Windows.Forms.NumericUpDown
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.NumCliente = New System.Windows.Forms.NumericUpDown
        Me.NumProveedor = New System.Windows.Forms.NumericUpDown
        Me.NumCompra = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.UiTabMail = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TxtMailPort = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.BtnTest = New Janus.Windows.EditControls.UIButton
        Me.TxtMailPassword = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtHostSMTP = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtMailUser = New System.Windows.Forms.TextBox
        Me.TxtDisplayName = New System.Windows.Forms.TextBox
        Me.TxtMailAdress = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.ChkMailSSL = New Selling.ChkStatus(Me.components)
        Me.UiTabCFD = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GrpPAC = New System.Windows.Forms.GroupBox
        Me.BtnAddPAC = New Janus.Windows.EditControls.UIButton
        Me.PictureBox22 = New System.Windows.Forms.PictureBox
        Me.BtnDelPAC = New Janus.Windows.EditControls.UIButton
        Me.GridPAC = New Janus.Windows.GridEX.GridEX
        Me.PictureBox19 = New System.Windows.Forms.PictureBox
        Me.PictureBox18 = New System.Windows.Forms.PictureBox
        Me.PictureBox17 = New System.Windows.Forms.PictureBox
        Me.PictureBox16 = New System.Windows.Forms.PictureBox
        Me.PictureBox15 = New System.Windows.Forms.PictureBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.BtnXML = New Janus.Windows.EditControls.UIButton
        Me.TxtXML = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.cmbTipoCF = New Selling.StoreCombo
        Me.cmbVersionCF = New Selling.StoreCombo
        Me.cmbRegimenFiscal = New Selling.StoreCombo
        Me.cmbMetodoPago = New Selling.StoreCombo
        Me.PictureBox24 = New System.Windows.Forms.PictureBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbCosteo = New Selling.StoreCombo
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCompania.SuspendLayout()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpIcono.SuspendLayout()
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpActividad.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabParam.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumPorcRiesgo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumLineNota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumLineFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabMail.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.UiTabCFD.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GrpPAC.SuspendLayout()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPAC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(474, 451)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 10
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(378, 451)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 11
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.Location = New System.Drawing.Point(7, 7)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(557, 438)
        Me.UiTab1.TabIndex = 19
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabParam, Me.UiTabMail, Me.UiTabCFD})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Controls.Add(Me.GrpDomicilio)
        Me.UiTabCompania.Controls.Add(Me.GrpIcono)
        Me.UiTabCompania.Controls.Add(Me.GrpActividad)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(555, 416)
        Me.UiTabCompania.TabStop = True
        Me.UiTabCompania.Text = "General"
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilio.Controls.Add(Me.cmbRiesgoPuesto)
        Me.GrpDomicilio.Controls.Add(Me.lblRiesgo)
        Me.GrpDomicilio.Controls.Add(Me.TxtRegPatronal)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox5)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox6)
        Me.GrpDomicilio.Controls.Add(Me.TxtColoniaFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtMunicipioFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtEstadoFac)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox7)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox8)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox3)
        Me.GrpDomicilio.Controls.Add(Me.Label1)
        Me.GrpDomicilio.Controls.Add(Me.TxtReferencia)
        Me.GrpDomicilio.Controls.Add(Me.Label4)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.GrpDomicilio.Controls.Add(Me.TxtDomicilioFac)
        Me.GrpDomicilio.Controls.Add(Me.Label6)
        Me.GrpDomicilio.Controls.Add(Me.Label18)
        Me.GrpDomicilio.Controls.Add(Me.Label19)
        Me.GrpDomicilio.Controls.Add(Me.CmbPaisFac)
        Me.GrpDomicilio.Controls.Add(Me.Label21)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox9)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox4)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox2)
        Me.GrpDomicilio.Controls.Add(Me.TxtFax)
        Me.GrpDomicilio.Controls.Add(Me.TxtTelefono)
        Me.GrpDomicilio.Controls.Add(Me.Label7)
        Me.GrpDomicilio.Controls.Add(Me.Label8)
        Me.GrpDomicilio.Controls.Add(Me.Label2)
        Me.GrpDomicilio.Controls.Add(Me.Label3)
        Me.GrpDomicilio.Controls.Add(Me.Label33)
        Me.GrpDomicilio.Controls.Add(Me.Label20)
        Me.GrpDomicilio.Controls.Add(Me.Label5)
        Me.GrpDomicilio.Location = New System.Drawing.Point(7, 158)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(545, 252)
        Me.GrpDomicilio.TabIndex = 21
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio"
        '
        'cmbRiesgoPuesto
        '
        Me.cmbRiesgoPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRiesgoPuesto.Location = New System.Drawing.Point(397, 176)
        Me.cmbRiesgoPuesto.Name = "cmbRiesgoPuesto"
        Me.cmbRiesgoPuesto.Size = New System.Drawing.Size(140, 21)
        Me.cmbRiesgoPuesto.TabIndex = 103
        '
        'lblRiesgo
        '
        Me.lblRiesgo.Location = New System.Drawing.Point(293, 178)
        Me.lblRiesgo.Name = "lblRiesgo"
        Me.lblRiesgo.Size = New System.Drawing.Size(96, 17)
        Me.lblRiesgo.TabIndex = 102
        Me.lblRiesgo.Text = "Riesgo Puesto"
        '
        'TxtRegPatronal
        '
        Me.TxtRegPatronal.Location = New System.Drawing.Point(88, 175)
        Me.TxtRegPatronal.Name = "TxtRegPatronal"
        Me.TxtRegPatronal.Size = New System.Drawing.Size(199, 20)
        Me.TxtRegPatronal.TabIndex = 100
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(315, 50)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox5.TabIndex = 33
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(335, 71)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(19, 24)
        Me.PictureBox6.TabIndex = 34
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(75, 71)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(251, 20)
        Me.TxtColoniaFac.TabIndex = 5
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(75, 45)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(166, 20)
        Me.TxtMunicipioFac.TabIndex = 3
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(345, 19)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(192, 20)
        Me.TxtEstadoFac.TabIndex = 2
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(380, 71)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(27, 18)
        Me.PictureBox7.TabIndex = 35
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(327, 97)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(27, 20)
        Me.PictureBox8.TabIndex = 36
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(315, 23)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 16)
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(75, 122)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(464, 20)
        Me.TxtReferencia.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(329, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Código Postal"
        '
        'TxtNoInterior
        '
        Me.TxtNoInterior.Location = New System.Drawing.Point(482, 96)
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInterior.TabIndex = 9
        '
        'TxtNoExterior
        '
        Me.TxtNoExterior.Location = New System.Drawing.Point(380, 97)
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExterior.TabIndex = 8
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(415, 71)
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(122, 20)
        Me.TxtCodigoPostal.TabIndex = 6
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(345, 45)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(192, 20)
        Me.TxtLocalidad.TabIndex = 4
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(75, 96)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(251, 20)
        Me.TxtDomicilioFac.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Calle"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(5, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 18)
        Me.Label18.TabIndex = 88
        Me.Label18.Text = "Colonia"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(5, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 15)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "Municipio"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(75, 18)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(165, 21)
        Me.CmbPaisFac.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(5, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 15)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "País"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(353, 99)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox9.TabIndex = 37
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(240, 48)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox4.TabIndex = 32
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(240, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(404, 145)
        Me.TxtFax.Mask = "!(##) 000 00 0 00 00"
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(133, 20)
        Me.TxtFax.TabIndex = 12
        Me.TxtFax.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(75, 148)
        Me.TxtTelefono.Mask = "!(##) 000 00 0 00 00"
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(133, 20)
        Me.TxtTelefono.TabIndex = 11
        Me.TxtTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(312, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Fax"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(5, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Telefono"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(438, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "No. Int."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(334, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "No. Ext."
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(6, 176)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(76, 17)
        Me.Label33.TabIndex = 101
        Me.Label33.Text = "Reg. Patronal"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(247, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 16)
        Me.Label20.TabIndex = 86
        Me.Label20.Text = "Entidad/Estado"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(247, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 14)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Ciudad/Población"
        '
        'GrpIcono
        '
        Me.GrpIcono.BackColor = System.Drawing.Color.Transparent
        Me.GrpIcono.Controls.Add(Me.PictIcono)
        Me.GrpIcono.Location = New System.Drawing.Point(352, 16)
        Me.GrpIcono.Name = "GrpIcono"
        Me.GrpIcono.Size = New System.Drawing.Size(198, 131)
        Me.GrpIcono.TabIndex = 20
        Me.GrpIcono.TabStop = False
        Me.GrpIcono.Text = "Logo (518 x 262)"
        '
        'PictIcono
        '
        Me.PictIcono.BackColor = System.Drawing.Color.Transparent
        Me.PictIcono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono.Location = New System.Drawing.Point(8, 32)
        Me.PictIcono.Name = "PictIcono"
        Me.PictIcono.Size = New System.Drawing.Size(184, 77)
        Me.PictIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictIcono.TabIndex = 0
        Me.PictIcono.TabStop = False
        '
        'GrpActividad
        '
        Me.GrpActividad.BackColor = System.Drawing.Color.Transparent
        Me.GrpActividad.Controls.Add(Me.PictureBox1)
        Me.GrpActividad.Controls.Add(Me.PictureBox13)
        Me.GrpActividad.Controls.Add(Me.lblRFC)
        Me.GrpActividad.Controls.Add(Me.TxtRFC)
        Me.GrpActividad.Controls.Add(Me.TxtNombre)
        Me.GrpActividad.Controls.Add(Me.LblNombre)
        Me.GrpActividad.Controls.Add(Me.LblClave)
        Me.GrpActividad.Controls.Add(Me.TxtClave)
        Me.GrpActividad.Location = New System.Drawing.Point(7, 16)
        Me.GrpActividad.Name = "GrpActividad"
        Me.GrpActividad.Size = New System.Drawing.Size(340, 131)
        Me.GrpActividad.TabIndex = 19
        Me.GrpActividad.TabStop = False
        Me.GrpActividad.Text = "Compañia"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(45, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 16)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(45, 84)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox13.TabIndex = 58
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(5, 86)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 57
        Me.lblRFC.Text = "RFC"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(86, 83)
        Me.TxtRFC.Mask = "AAAA00000aaaa"
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(127, 20)
        Me.TxtRFC.TabIndex = 2
        Me.TxtRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(86, 50)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(248, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(5, 53)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(75, 14)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Razon Social"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 24)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(60, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(86, 21)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 0
        '
        'UiTabParam
        '
        Me.UiTabParam.Controls.Add(Me.GroupBox4)
        Me.UiTabParam.Controls.Add(Me.GroupBox3)
        Me.UiTabParam.Controls.Add(Me.GroupBox2)
        Me.UiTabParam.Controls.Add(Me.GroupBox1)
        Me.UiTabParam.Location = New System.Drawing.Point(1, 21)
        Me.UiTabParam.Name = "UiTabParam"
        Me.UiTabParam.Size = New System.Drawing.Size(555, 416)
        Me.UiTabParam.TabStop = True
        Me.UiTabParam.Text = "Parametros"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.PictureBox24)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.cmbCosteo)
        Me.GroupBox4.Controls.Add(Me.ChkAplicacion)
        Me.GroupBox4.Controls.Add(Me.txtSucursal)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.PictureBox23)
        Me.GroupBox4.Controls.Add(Me.cmbFactura)
        Me.GroupBox4.Controls.Add(Me.Label32)
        Me.GroupBox4.Controls.Add(Me.PictureBox21)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.PictureBox20)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.NumTimeOut)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.PictureBox14)
        Me.GroupBox4.Controls.Add(Me.CmbFormatOC)
        Me.GroupBox4.Controls.Add(Me.PictureBox12)
        Me.GroupBox4.Controls.Add(Me.NumPorcRiesgo)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.NumHistorico)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.PictureBox11)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cmbMonedaCambio)
        Me.GroupBox4.Controls.Add(Me.cmbMoneda)
        Me.GroupBox4.Controls.Add(Me.CmbImpuesto)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 170)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(551, 243)
        Me.GroupBox4.TabIndex = 114
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Varios"
        '
        'ChkAplicacion
        '
        Me.ChkAplicacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAplicacion.Location = New System.Drawing.Point(307, 187)
        Me.ChkAplicacion.Name = "ChkAplicacion"
        Me.ChkAplicacion.Size = New System.Drawing.Size(237, 15)
        Me.ChkAplicacion.TabIndex = 140
        Me.ChkAplicacion.Text = "Aplicación Automotriz"
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(383, 150)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(161, 20)
        Me.txtSucursal.TabIndex = 139
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(303, 153)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(66, 15)
        Me.Label37.TabIndex = 138
        Me.Label37.Text = "IP (VPN)"
        '
        'PictureBox23
        '
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(119, 95)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox23.TabIndex = 136
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'cmbFactura
        '
        Me.cmbFactura.FormattingEnabled = True
        Me.cmbFactura.Items.AddRange(New Object() {"Clasico", "Con Notas", "Con Pagare"})
        Me.cmbFactura.Location = New System.Drawing.Point(148, 96)
        Me.cmbFactura.Name = "cmbFactura"
        Me.cmbFactura.Size = New System.Drawing.Size(149, 21)
        Me.cmbFactura.TabIndex = 137
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(6, 99)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(129, 21)
        Me.Label32.TabIndex = 135
        Me.Label32.Text = "Formato Factura"
        '
        'PictureBox21
        '
        Me.PictureBox21.Image = CType(resources.GetObject("PictureBox21.Image"), System.Drawing.Image)
        Me.PictureBox21.Location = New System.Drawing.Point(117, 208)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox21.TabIndex = 132
        Me.PictureBox21.TabStop = False
        Me.PictureBox21.Visible = False
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(4, 206)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(123, 15)
        Me.Label40.TabIndex = 131
        Me.Label40.Text = "Moneda Cambiaria"
        '
        'PictureBox20
        '
        Me.PictureBox20.Image = CType(resources.GetObject("PictureBox20.Image"), System.Drawing.Image)
        Me.PictureBox20.Location = New System.Drawing.Point(117, 183)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox20.TabIndex = 129
        Me.PictureBox20.TabStop = False
        Me.PictureBox20.Visible = False
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(4, 181)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(123, 15)
        Me.Label39.TabIndex = 128
        Me.Label39.Text = "Moneda Predeterminada"
        '
        'NumTimeOut
        '
        Me.NumTimeOut.Location = New System.Drawing.Point(222, 151)
        Me.NumTimeOut.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumTimeOut.Name = "NumTimeOut"
        Me.NumTimeOut.Size = New System.Drawing.Size(75, 20)
        Me.NumTimeOut.TabIndex = 127
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(4, 153)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(280, 22)
        Me.Label30.TabIndex = 126
        Me.Label30.Text = "TimeOut para Consultas a la base de datos"
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(118, 127)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox14.TabIndex = 117
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'CmbFormatOC
        '
        Me.CmbFormatOC.FormattingEnabled = True
        Me.CmbFormatOC.Items.AddRange(New Object() {"Clasico", "Con Columnas"})
        Me.CmbFormatOC.Location = New System.Drawing.Point(148, 124)
        Me.CmbFormatOC.Name = "CmbFormatOC"
        Me.CmbFormatOC.Size = New System.Drawing.Size(149, 21)
        Me.CmbFormatOC.TabIndex = 118
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(117, 100)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox12.TabIndex = 125
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'NumPorcRiesgo
        '
        Me.NumPorcRiesgo.DecimalPlaces = 2
        Me.NumPorcRiesgo.Location = New System.Drawing.Point(383, 69)
        Me.NumPorcRiesgo.Name = "NumPorcRiesgo"
        Me.NumPorcRiesgo.Size = New System.Drawing.Size(100, 20)
        Me.NumPorcRiesgo.TabIndex = 122
        Me.NumPorcRiesgo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(4, 127)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(154, 15)
        Me.Label26.TabIndex = 59
        Me.Label26.Text = "Formato Orden de Compra"
        '
        'NumHistorico
        '
        Me.NumHistorico.Location = New System.Drawing.Point(383, 46)
        Me.NumHistorico.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumHistorico.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumHistorico.Name = "NumHistorico"
        Me.NumHistorico.Size = New System.Drawing.Size(100, 20)
        Me.NumHistorico.TabIndex = 121
        Me.NumHistorico.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(4, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(373, 16)
        Me.Label15.TabIndex = 120
        Me.Label15.Text = "Porcentaje de riesgo para ventas que exceden limite de crédito"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(4, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(366, 23)
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "Numero de Periodos a conservar al hacer corte de información"
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(118, 19)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox11.TabIndex = 116
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(4, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 20)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Impuesto predeterminado"
        '
        'cmbMonedaCambio
        '
        Me.cmbMonedaCambio.Location = New System.Drawing.Point(137, 206)
        Me.cmbMonedaCambio.Name = "cmbMonedaCambio"
        Me.cmbMonedaCambio.Size = New System.Drawing.Size(160, 21)
        Me.cmbMonedaCambio.TabIndex = 134
        '
        'cmbMoneda
        '
        Me.cmbMoneda.Location = New System.Drawing.Point(137, 181)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(160, 21)
        Me.cmbMoneda.TabIndex = 133
        '
        'CmbImpuesto
        '
        Me.CmbImpuesto.Location = New System.Drawing.Point(148, 18)
        Me.CmbImpuesto.Name = "CmbImpuesto"
        Me.CmbImpuesto.Size = New System.Drawing.Size(149, 21)
        Me.CmbImpuesto.TabIndex = 114
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.PictureBox10)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.BtnExplorador)
        Me.GroupBox3.Controls.Add(Me.TxtDireccion)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 102)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(551, 62)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Directorios"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(130, 24)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox10.TabIndex = 63
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(4, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 19)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "CFDI de Proveedores"
        '
        'BtnExplorador
        '
        Me.BtnExplorador.Image = CType(resources.GetObject("BtnExplorador.Image"), System.Drawing.Image)
        Me.BtnExplorador.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnExplorador.Location = New System.Drawing.Point(512, 17)
        Me.BtnExplorador.Name = "BtnExplorador"
        Me.BtnExplorador.Size = New System.Drawing.Size(33, 29)
        Me.BtnExplorador.TabIndex = 30
        Me.BtnExplorador.ToolTipText = "Ubicación en el servidor donde se guardaran los XML y PDF de proveedores"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(148, 24)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(359, 20)
        Me.TxtDireccion.TabIndex = 28
        Me.TxtDireccion.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.NumLineNota)
        Me.GroupBox2.Controls.Add(Me.NumLineFactura)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(259, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(294, 93)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Maximo de Lineas de Impresión"
        '
        'NumLineNota
        '
        Me.NumLineNota.Location = New System.Drawing.Point(111, 55)
        Me.NumLineNota.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumLineNota.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumLineNota.Name = "NumLineNota"
        Me.NumLineNota.Size = New System.Drawing.Size(100, 20)
        Me.NumLineNota.TabIndex = 7
        Me.NumLineNota.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumLineFactura
        '
        Me.NumLineFactura.Location = New System.Drawing.Point(111, 20)
        Me.NumLineFactura.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumLineFactura.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumLineFactura.Name = "NumLineFactura"
        Me.NumLineFactura.Size = New System.Drawing.Size(100, 20)
        Me.NumLineFactura.TabIndex = 6
        Me.NumLineFactura.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 27)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Nota de Crédito"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Factura"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.NumCliente)
        Me.GroupBox1.Controls.Add(Me.NumProveedor)
        Me.GroupBox1.Controls.Add(Me.NumCompra)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 93)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Numero de Digitos en Consecutivo"
        '
        'NumCliente
        '
        Me.NumCliente.Location = New System.Drawing.Point(136, 66)
        Me.NumCliente.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumCliente.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCliente.Name = "NumCliente"
        Me.NumCliente.Size = New System.Drawing.Size(100, 20)
        Me.NumCliente.TabIndex = 7
        Me.NumCliente.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumProveedor
        '
        Me.NumProveedor.Location = New System.Drawing.Point(136, 44)
        Me.NumProveedor.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumProveedor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumProveedor.Name = "NumProveedor"
        Me.NumProveedor.Size = New System.Drawing.Size(100, 20)
        Me.NumProveedor.TabIndex = 6
        Me.NumProveedor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumCompra
        '
        Me.NumCompra.Location = New System.Drawing.Point(136, 22)
        Me.NumCompra.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumCompra.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCompra.Name = "NumCompra"
        Me.NumCompra.Size = New System.Drawing.Size(100, 20)
        Me.NumCompra.TabIndex = 5
        Me.NumCompra.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Clave de Cliente"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 19)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Clave de Proveedor"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 19)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Orden de Compra"
        '
        'UiTabMail
        '
        Me.UiTabMail.Controls.Add(Me.GroupBox5)
        Me.UiTabMail.Location = New System.Drawing.Point(1, 21)
        Me.UiTabMail.Name = "UiTabMail"
        Me.UiTabMail.Size = New System.Drawing.Size(555, 416)
        Me.UiTabMail.TabStop = True
        Me.UiTabMail.Text = "Correo electrónico"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TxtMailPort)
        Me.GroupBox5.Controls.Add(Me.BtnTest)
        Me.GroupBox5.Controls.Add(Me.TxtMailPassword)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.TxtHostSMTP)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.TxtMailUser)
        Me.GroupBox5.Controls.Add(Me.TxtDisplayName)
        Me.GroupBox5.Controls.Add(Me.TxtMailAdress)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.ChkMailSSL)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(545, 202)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuración de Correo Electrónico"
        '
        'TxtMailPort
        '
        Me.TxtMailPort.Location = New System.Drawing.Point(113, 147)
        Me.TxtMailPort.Name = "TxtMailPort"
        Me.TxtMailPort.Size = New System.Drawing.Size(58, 20)
        Me.TxtMailPort.TabIndex = 100
        Me.TxtMailPort.Text = "1"
        Me.TxtMailPort.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtMailPort.Value = 1
        Me.TxtMailPort.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'BtnTest
        '
        Me.BtnTest.Icon = CType(resources.GetObject("BtnTest.Icon"), System.Drawing.Icon)
        Me.BtnTest.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnTest.Location = New System.Drawing.Point(401, 162)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(133, 29)
        Me.BtnTest.TabIndex = 8
        Me.BtnTest.Text = "Probar Configuración"
        Me.BtnTest.ToolTipText = "Prueba de envio de correo"
        '
        'TxtMailPassword
        '
        Me.TxtMailPassword.Location = New System.Drawing.Point(113, 96)
        Me.TxtMailPassword.Name = "TxtMailPassword"
        Me.TxtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtMailPassword.Size = New System.Drawing.Size(140, 20)
        Me.TxtMailPassword.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 124)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 15)
        Me.Label23.TabIndex = 99
        Me.Label23.Text = "Servidor SMTP"
        '
        'TxtHostSMTP
        '
        Me.TxtHostSMTP.Location = New System.Drawing.Point(113, 122)
        Me.TxtHostSMTP.Name = "TxtHostSMTP"
        Me.TxtHostSMTP.Size = New System.Drawing.Size(421, 20)
        Me.TxtHostSMTP.TabIndex = 5
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(7, 98)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 15)
        Me.Label25.TabIndex = 95
        Me.Label25.Text = "Contraseña"
        '
        'TxtMailUser
        '
        Me.TxtMailUser.Location = New System.Drawing.Point(113, 70)
        Me.TxtMailUser.Name = "TxtMailUser"
        Me.TxtMailUser.Size = New System.Drawing.Size(255, 20)
        Me.TxtMailUser.TabIndex = 3
        '
        'TxtDisplayName
        '
        Me.TxtDisplayName.Location = New System.Drawing.Point(113, 45)
        Me.TxtDisplayName.Name = "TxtDisplayName"
        Me.TxtDisplayName.Size = New System.Drawing.Size(255, 20)
        Me.TxtDisplayName.TabIndex = 2
        '
        'TxtMailAdress
        '
        Me.TxtMailAdress.Location = New System.Drawing.Point(113, 19)
        Me.TxtMailAdress.Name = "TxtMailAdress"
        Me.TxtMailAdress.Size = New System.Drawing.Size(255, 20)
        Me.TxtMailAdress.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(7, 23)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(111, 15)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Dirección de correo"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(7, 72)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 18)
        Me.Label28.TabIndex = 88
        Me.Label28.Text = "Usuario"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(6, 48)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 15)
        Me.Label29.TabIndex = 87
        Me.Label29.Text = "Nombre"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(8, 150)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 15)
        Me.Label31.TabIndex = 85
        Me.Label31.Text = "Puerto"
        '
        'ChkMailSSL
        '
        Me.ChkMailSSL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMailSSL.Checked = True
        Me.ChkMailSSL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMailSSL.Location = New System.Drawing.Point(9, 176)
        Me.ChkMailSSL.Name = "ChkMailSSL"
        Me.ChkMailSSL.Size = New System.Drawing.Size(119, 15)
        Me.ChkMailSSL.TabIndex = 7
        Me.ChkMailSSL.Text = "Habilitar SSL"
        '
        'UiTabCFD
        '
        Me.UiTabCFD.Controls.Add(Me.GroupBox6)
        Me.UiTabCFD.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCFD.Name = "UiTabCFD"
        Me.UiTabCFD.Size = New System.Drawing.Size(555, 416)
        Me.UiTabCFD.TabStop = True
        Me.UiTabCFD.Text = "Comprobante Fiscal"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.GrpPAC)
        Me.GroupBox6.Controls.Add(Me.PictureBox19)
        Me.GroupBox6.Controls.Add(Me.PictureBox18)
        Me.GroupBox6.Controls.Add(Me.PictureBox17)
        Me.GroupBox6.Controls.Add(Me.PictureBox16)
        Me.GroupBox6.Controls.Add(Me.PictureBox15)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.BtnXML)
        Me.GroupBox6.Controls.Add(Me.TxtXML)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.cmbTipoCF)
        Me.GroupBox6.Controls.Add(Me.cmbVersionCF)
        Me.GroupBox6.Controls.Add(Me.cmbRegimenFiscal)
        Me.GroupBox6.Controls.Add(Me.cmbMetodoPago)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(545, 411)
        Me.GroupBox6.TabIndex = 23
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Configuración de Comprobantes Fiscales"
        '
        'GrpPAC
        '
        Me.GrpPAC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPAC.BackColor = System.Drawing.Color.Transparent
        Me.GrpPAC.Controls.Add(Me.BtnAddPAC)
        Me.GrpPAC.Controls.Add(Me.PictureBox22)
        Me.GrpPAC.Controls.Add(Me.BtnDelPAC)
        Me.GrpPAC.Controls.Add(Me.GridPAC)
        Me.GrpPAC.Location = New System.Drawing.Point(11, 168)
        Me.GrpPAC.Name = "GrpPAC"
        Me.GrpPAC.Size = New System.Drawing.Size(528, 238)
        Me.GrpPAC.TabIndex = 125
        Me.GrpPAC.TabStop = False
        Me.GrpPAC.Text = "Proveedores Autorizados de Certificación"
        '
        'BtnAddPAC
        '
        Me.BtnAddPAC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddPAC.Icon = CType(resources.GetObject("BtnAddPAC.Icon"), System.Drawing.Icon)
        Me.BtnAddPAC.Location = New System.Drawing.Point(446, 11)
        Me.BtnAddPAC.Name = "BtnAddPAC"
        Me.BtnAddPAC.Size = New System.Drawing.Size(33, 22)
        Me.BtnAddPAC.TabIndex = 101
        Me.BtnAddPAC.ToolTipText = "Agregar unidad actual"
        Me.BtnAddPAC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox22
        '
        Me.PictureBox22.Image = CType(resources.GetObject("PictureBox22.Image"), System.Drawing.Image)
        Me.PictureBox22.Location = New System.Drawing.Point(217, 19)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox22.TabIndex = 74
        Me.PictureBox22.TabStop = False
        Me.PictureBox22.Visible = False
        '
        'BtnDelPAC
        '
        Me.BtnDelPAC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelPAC.Icon = CType(resources.GetObject("BtnDelPAC.Icon"), System.Drawing.Icon)
        Me.BtnDelPAC.Location = New System.Drawing.Point(483, 11)
        Me.BtnDelPAC.Name = "BtnDelPAC"
        Me.BtnDelPAC.Size = New System.Drawing.Size(34, 22)
        Me.BtnDelPAC.TabIndex = 5
        Me.BtnDelPAC.ToolTipText = "Eliminar unidad seleccionada"
        Me.BtnDelPAC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPAC
        '
        Me.GridPAC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPAC.ColumnAutoResize = True
        Me.GridPAC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPAC.Location = New System.Drawing.Point(10, 36)
        Me.GridPAC.Name = "GridPAC"
        Me.GridPAC.RecordNavigator = True
        Me.GridPAC.Size = New System.Drawing.Size(507, 196)
        Me.GridPAC.TabIndex = 4
        Me.GridPAC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox19
        '
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(98, 134)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox19.TabIndex = 64
        Me.PictureBox19.TabStop = False
        Me.PictureBox19.Visible = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(501, 105)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox18.TabIndex = 124
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(501, 82)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox17.TabIndex = 123
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(352, 58)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox16.TabIndex = 122
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(352, 33)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox15.TabIndex = 121
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(7, 108)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(172, 19)
        Me.Label38.TabIndex = 117
        Me.Label38.Text = "Metodo de Pago Predeterminado"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(7, 136)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 16)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "Repositorio XML"
        '
        'BtnXML
        '
        Me.BtnXML.Image = CType(resources.GetObject("BtnXML.Image"), System.Drawing.Image)
        Me.BtnXML.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnXML.Location = New System.Drawing.Point(506, 123)
        Me.BtnXML.Name = "BtnXML"
        Me.BtnXML.Size = New System.Drawing.Size(33, 30)
        Me.BtnXML.TabIndex = 71
        '
        'TxtXML
        '
        Me.TxtXML.Location = New System.Drawing.Point(118, 134)
        Me.TxtXML.Name = "TxtXML"
        Me.TxtXML.ReadOnly = True
        Me.TxtXML.Size = New System.Drawing.Size(378, 20)
        Me.TxtXML.TabIndex = 70
        Me.TxtXML.TabStop = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(7, 32)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(128, 14)
        Me.Label34.TabIndex = 89
        Me.Label34.Text = "Tipo Comprobante"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(7, 82)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(117, 17)
        Me.Label35.TabIndex = 88
        Me.Label35.Text = "Regimen Fiscal"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(6, 57)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(129, 14)
        Me.Label36.TabIndex = 87
        Me.Label36.Text = "Versión"
        '
        'cmbTipoCF
        '
        Me.cmbTipoCF.Location = New System.Drawing.Point(186, 29)
        Me.cmbTipoCF.Name = "cmbTipoCF"
        Me.cmbTipoCF.Size = New System.Drawing.Size(161, 21)
        Me.cmbTipoCF.TabIndex = 120
        '
        'cmbVersionCF
        '
        Me.cmbVersionCF.Location = New System.Drawing.Point(186, 54)
        Me.cmbVersionCF.Name = "cmbVersionCF"
        Me.cmbVersionCF.Size = New System.Drawing.Size(161, 21)
        Me.cmbVersionCF.TabIndex = 119
        '
        'cmbRegimenFiscal
        '
        Me.cmbRegimenFiscal.Location = New System.Drawing.Point(185, 79)
        Me.cmbRegimenFiscal.Name = "cmbRegimenFiscal"
        Me.cmbRegimenFiscal.Size = New System.Drawing.Size(311, 21)
        Me.cmbRegimenFiscal.TabIndex = 118
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.Location = New System.Drawing.Point(185, 105)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(311, 21)
        Me.cmbMetodoPago.TabIndex = 116
        '
        'PictureBox24
        '
        Me.PictureBox24.Image = CType(resources.GetObject("PictureBox24.Image"), System.Drawing.Image)
        Me.PictureBox24.Location = New System.Drawing.Point(350, 125)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox24.TabIndex = 143
        Me.PictureBox24.TabStop = False
        Me.PictureBox24.Visible = False
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(300, 127)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 20)
        Me.Label17.TabIndex = 142
        Me.Label17.Text = "Tipo Costeo"
        '
        'cmbCosteo
        '
        Me.cmbCosteo.Location = New System.Drawing.Point(383, 124)
        Me.cmbCosteo.Name = "cmbCosteo"
        Me.cmbCosteo.Size = New System.Drawing.Size(161, 21)
        Me.cmbCosteo.TabIndex = 141
        '
        'FrmCompania
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(568, 492)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompania"
        Me.Text = "Compañia"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCompania.ResumeLayout(False)
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpIcono.ResumeLayout(False)
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpActividad.ResumeLayout(False)
        Me.GrpActividad.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabParam.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumPorcRiesgo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NumLineNota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumLineFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.NumCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabMail.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.UiTabCFD.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GrpPAC.ResumeLayout(False)
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPAC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String = ""
    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Public COMClave As String
    Public Icono As Byte()
    Public NuevoIcono As Boolean = False

    Private alerta(23) As PictureBox
    Private reloj As parpadea
    Private cargado As Boolean = False

    Private correo As New MailMessage
    Private adjuntos As Attachment
    Private autenticar As New NetworkCredential
    Private envio As New SmtpClient

    Private EstadoFac, MunicipioFac, ColoniaFac As String


    Private dtPAC As DataTable
    Private ActualizaPAC As Boolean

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 60 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 60)
        End If

        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLocalidad.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoPostal.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNoExterior.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtDireccion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 60 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 60)
        End If

        If CmbImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbCosteo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(23))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbFactura.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(22))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtRFC.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbFormatOC.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbTipoCF.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbVersionCF.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(15))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbRegimenFiscal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbMetodoPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(17))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtXML.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(18))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbMoneda.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(19))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbMonedaCambio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(20))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbVersionCF.SelectedValue Is Nothing Then

            If Not (cmbVersionCF.SelectedValue = 1 Or cmbVersionCF.SelectedValue = 3 Or cmbVersionCF.SelectedValue = 5) AndAlso GridPAC.RowCount = 0 Then
                i += 1
                reloj = New parpadea(Me.alerta(21))
                reloj.Enabled = True
                reloj.Start()
            End If
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

    Private Sub FrmCompania_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        Dim dt As DataTable
        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9
        alerta(9) = Me.PictureBox10
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13
        alerta(13) = Me.PictureBox14

        alerta(14) = Me.PictureBox15
        alerta(15) = Me.PictureBox16
        alerta(16) = Me.PictureBox17
        alerta(17) = Me.PictureBox18
        alerta(18) = Me.PictureBox19
        alerta(19) = Me.PictureBox20
        alerta(20) = Me.PictureBox21

        alerta(21) = Me.PictureBox22
        alerta(22) = Me.PictureBox23
        alerta(23) = Me.PictureBox24

        With Me.CmbPaisFac
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        With Me.cmbCosteo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Costo"
            .llenar()
        End With

        With Me.CmbImpuesto
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impuesto"
            .llenar()
        End With


        With Me.cmbTipoCF
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.cmbVersionCF
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_versioncfd"
            .NombreParametro1 = "Grupo"
            .Parametro1 = IIf(cmbTipoCF.SelectedValue Is Nothing, 1, cmbTipoCF.SelectedValue)
            .llenar()
        End With

        With Me.cmbRegimenFiscal
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "RegimenFiscal"
            .llenar()
        End With


        With Me.cmbMetodoPago
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With

        With Me.cmbMoneda
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_monedas"
            .llenar()
        End With

        With Me.cmbMonedaCambio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_monedas"
            .llenar()
        End With


        With Me.cmbRiesgoPuesto
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "RiesgoPuesto"
            .llenar()
        End With

        If Padre = "Agregar" Then
            COMClave = ModPOS.obtenerLlave

            dtPAC = ModPOS.CrearTabla("CompanyPAC", _
            "TipoPAC", "System.Int32", _
            "PAC", "System.String", _
            "UserId", "System.String", _
            "CustomerKey", "System.String", _
            "Serv. Timbrado", "System.String", _
            "Serv. Cancelación", "System.Int32", _
            "Timbres", "System.Int32", _
            "Orden", "System.Int32")

        Else
            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", COMClave)

            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_companyPAC", "@COMClave", COMClave)

            With Me

                .TxtClave.Text = IIf(dt.Rows(0)("Clave").GetType.Name = "DBNull", "", dt.Rows(0)("Clave"))
                .TxtNombre.Text = dt.Rows(0)("Nombre")
                .TxtRFC.Text = dt.Rows(0)("id_Fiscal")
                .CmbPaisFac.Text = dt.Rows(0)("Pais")
                .EstadoFac = dt.Rows(0)("Estado")
                .MunicipioFac = dt.Rows(0)("Municipio")
                .ColoniaFac = dt.Rows(0)("Colonia")
                .TxtDomicilioFac.Text = dt.Rows(0)("Calle")
                .TxtCodigoPostal.Text = dt.Rows(0)("CodigoPostal")
                .TxtReferencia.Text = dt.Rows(0)("Referencia")
                .TxtLocalidad.Text = dt.Rows(0)("Localidad")
                .TxtNoExterior.Text = dt.Rows(0)("noExterior")
                .TxtNoInterior.Text = dt.Rows(0)("noInterior")
                .TxtTelefono.Text = dt.Rows(0)("Telefono")
                .TxtFax.Text = dt.Rows(0)("Fax")
                .TxtEstadoFac.Text = EstadoFac
                .TxtMunicipioFac.Text = MunicipioFac
                .TxtColoniaFac.Text = ColoniaFac
                .TxtRegPatronal.Text = IIf(dt.Rows(0)("registroPatronal").GetType.Name = "DBNull", "", dt.Rows(0)("registroPatronal"))
                .cmbRiesgoPuesto.SelectedValue = IIf(dt.Rows(0)("RiesgoPuesto").GetType.Name = "DBNull", 0, dt.Rows(0)("RiesgoPuesto"))

                If Not dt.Rows(0)("Logo") Is System.DBNull.Value Then
                    .PictIcono.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Logo"), Byte()))
                    .Icono = CType(dt.Rows(0)("Logo"), Byte())
                End If

            End With


            cargado = True

            Dim dtEstado As DataTable

            dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
            If dtEstado.Rows.Count > 0 Then
                ReDim aEstado(dtEstado.Rows.Count - 1)

                For i As Integer = 0 To dtEstado.Rows.Count - 1
                    aEstado(i) = dtEstado.Rows(i)("d_estado")
                Next

                Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)

                dtEstado.Dispose()
            End If


            dt.Dispose()


            dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", COMClave)
            With Me
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    Select Case CStr(dt.Rows(i)("PARClave"))
                        Case "DigitoOrd"
                            .NumCompra.Value = CInt(dt.Rows(i)("Valor"))
                        Case "DigitoProv"
                            .NumProveedor.Value = CInt(dt.Rows(i)("Valor"))
                        Case "Digitos"
                            .NumCliente.Value = CInt(dt.Rows(i)("Valor"))
                        Case "DirXML"
                            .TxtXML.Text = dt.Rows(i)("Valor")
                        Case "Imagenes"
                            .TxtDireccion.Text = dt.Rows(i)("Valor")
                        Case "Impuesto"
                            .CmbImpuesto.SelectedValue = dt.Rows(i)("Valor")
                        Case "LineasFac"
                            .NumLineFactura.Value = CInt(dt.Rows(i)("Valor"))
                        Case "LineasNC"
                            .NumLineNota.Value = CInt(dt.Rows(i)("Valor"))
                        Case "NumMesHist"
                            .NumHistorico.Value = dt.Rows(i)("Valor")
                        Case "PorcRiesgoCred"
                            .NumPorcRiesgo.Value = dt.Rows(i)("Valor")
                        Case "MailAdress"
                            .TxtMailAdress.Text = dt.Rows(i)("Valor")
                        Case "DisplayName"
                            .TxtDisplayName.Text = dt.Rows(i)("Valor")
                        Case "MailUser"
                            .TxtMailUser.Text = dt.Rows(i)("Valor")
                        Case "MailPassword"
                            .TxtMailPassword.Text = dt.Rows(i)("Valor")
                        Case "HostSMTP"
                            .TxtHostSMTP.Text = dt.Rows(i)("Valor")
                        Case "MailPort"
                            If dt.Rows(i)("Valor") <> "" Then
                                .TxtMailPort.Text = dt.Rows(i)("Valor")
                            Else
                                .TxtMailPort.Text = 1
                            End If
                        Case "MailSSL"
                            .ChkMailSSL.Estado = dt.Rows(i)("Valor")
                        Case "RepOrden"
                            .CmbFormatOC.SelectedItem = dt.Rows(i)("Valor")
                        Case "TimeOut"
                            .NumTimeOut.Value = IIf(IsNumeric(dt.Rows(i)("Valor")) = True, CInt(dt.Rows(i)("Valor")), 0)
                        Case "TipoCF"
                            .cmbTipoCF.SelectedValue = dt.Rows(i)("Valor")
                        Case "VersionCF"
                            .cmbVersionCF.SelectedValue = dt.Rows(i)("Valor")
                        Case "RegimenFiscal"
                            .cmbRegimenFiscal.SelectedValue = dt.Rows(i)("Valor")
                        Case "MetodoPago"
                            .cmbMetodoPago.SelectedValue = dt.Rows(i)("Valor")
                        Case "Moneda"
                            .cmbMoneda.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "MonedaCambio"
                            .cmbMonedaCambio.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "FormatFac"
                            .cmbFactura.SelectedItem = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "SUCURSAL"
                            .txtSucursal.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "Aplicacion"
                            .ChkAplicacion.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                        Case "Costeo"
                            .cmbCosteo.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))


                    End Select
                Next
            End With

            dt.Dispose()

        End If


        GridPAC.DataSource = dtPAC
        GridPAC.RetrieveStructure(True)
        GridPAC.GroupByBoxVisible = False
        GridPAC.RootTable.Columns("TipoPAC").Visible = False
        GridPAC.CurrentTable.Columns("PAC").Selectable = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub PictIcono_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictIcono.DoubleClick
        Dim curFileName As String = ""


        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de JPG|*.JPG"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo JPG"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName



                Dim fsIcono As System.IO.FileStream
                fsIcono = New System.IO.FileStream(curFileName, System.IO.FileMode.Open)
                Dim fiIcono As System.IO.FileInfo = New System.IO.FileInfo(curFileName)
                Dim Temp As Long = fiIcono.Length
                Dim lung As Long = Convert.ToInt32(Temp)
                ReDim Icono(lung)
                fsIcono.Read(Icono, 0, lung)
                fsIcono.Close()

                Me.PictIcono.Image = Image.FromFile(curFileName)

                NuevoIcono = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub testMail()
        Dim frmStatusMessage As New frmStatus
        Try
            correo.Body = "Prueba de Correo Electrónico Selling"
            correo.Subject = "eMail Test"
            correo.IsBodyHtml = True
            correo.To.Clear()
            correo.CC.Clear()
            correo.Bcc.Clear()

            correo.To.Add(Trim(TxtMailAdress.Text))

            correo.From = New MailAddress(TxtMailAdress.Text.Trim, TxtDisplayName.Text.Trim)
            envio.Credentials = New NetworkCredential(TxtMailUser.Text.Trim, TxtMailPassword.Text.Trim)
            envio.Host = TxtHostSMTP.Text.Trim  '"smtp.live.com"
            envio.Port = CInt(TxtMailPort.Text.Trim)  '587
            envio.EnableSsl = IIf(ChkMailSSL.GetEstado = 1, True, False) 'True
            frmStatusMessage.Show("Enviando correo electrónico...")
            envio.Send(correo)
            MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmStatusMessage.Dispose()
        Catch ex As Exception
            frmStatusMessage.Dispose()
            MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm() Then

            Try
                If Not System.IO.Directory.Exists(TxtDireccion.Text) Then
                    MessageBox.Show("No se tiene acceso al directorio de Comprobantes Fiscales Digitales (XML) de Proveedores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try


            Try
                If Not System.IO.Directory.Exists(TxtXML.Text) Then
                    MessageBox.Show("No se tiene acceso al directorio de Comprobantes Fiscales Digitales (XML)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            If Padre = "Agregar" Then
                ModPOS.Ejecuta("sp_insertar_Compania", _
                              "@COMClave", COMClave, _
                              "@Clave", UCase(Trim(TxtClave.Text)), _
                              "@Logo", Icono, _
                              "@Nombre", UCase(Trim(TxtNombre.Text)), _
                              "@RFC", TxtRFC.Text.ToUpper.Trim, _
                              "@Pais", CmbPaisFac.Text.ToUpper.Trim, _
                              "@Entidad", TxtEstadoFac.Text.ToUpper.Trim, _
                              "@Municipio", TxtMunicipioFac.Text.ToUpper.Trim, _
                              "@Colonia", TxtColoniaFac.Text.ToUpper.Trim, _
                              "@Calle", TxtDomicilioFac.Text.ToUpper.Trim, _
                              "@codigoPostal", TxtCodigoPostal.Text.ToUpper.Trim, _
                              "@Localidad", TxtLocalidad.Text.ToUpper.Trim, _
                              "@referencia", TxtReferencia.Text.ToUpper.Trim, _
                              "@noExterior", TxtNoExterior.Text.ToUpper.Trim, _
                              "@noInterior", TxtNoInterior.Text.ToUpper.Trim, _
                              "@Telefono", TxtTelefono.Text, _
                              "@Fax", TxtFax.Text, _
                              "@Ticket", 1, _
                              "@Factura", 1, _
                              "@Folio", 0, _
                              "@registroPatronal", TxtRegPatronal.Text, _
                              "@RiesgoPuesto", cmbRiesgoPuesto.SelectedValue, _
                              "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DigitoOrd", "@Orden", 1, "@Valor", CStr(Me.NumCompra.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DigitoProv", "@Orden", 2, "@Valor", CStr(Me.NumProveedor.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Digitos", "@Orden", 3, "@Valor", CStr(Me.NumCliente.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DirXML", "@Orden", 4, "@Valor", TxtXML.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Imagenes", "@Orden", 5, "@Valor", TxtDireccion.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Impuesto", "@Orden", 6, "@Valor", CmbImpuesto.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "LineasFac", "@Orden", 7, "@Valor", CStr(Me.NumLineFactura.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "LineasNC", "@Orden", 8, "@Valor", CStr(Me.NumLineNota.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "SUCURSAL", "@Orden", 9, "@Valor", txtSucursal.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "NumMesHist", "@Orden", 10, "@Valor", CStr(Me.NumHistorico.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "PorcRiesgoCred", "@Orden", 11, "@Valor", CStr(Me.NumPorcRiesgo.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailAdress", "@Orden", 12, "@Valor", TxtMailAdress.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DisplayName", "@Orden", 13, "@Valor", TxtDisplayName.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailUser", "@Orden", 14, "@Valor", TxtMailUser.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailPassword", "@Orden", 15, "@Valor", TxtMailPassword.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "HostSMTP", "@Orden", 16, "@Valor", TxtHostSMTP.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailPort", "@Orden", 17, "@Valor", TxtMailPort.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailSSL", "@Orden", 18, "@Valor", ChkMailSSL.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "RepOrden", "@Orden", 19, "@Valor", CmbFormatOC.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "TimeOut", "@Orden", 20, "@Valor", CStr(Me.NumTimeOut.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "TipoCF", "@Orden", 21, "@Valor", CStr(cmbTipoCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "VersionCF", "@Orden", 22, "@Valor", CStr(cmbVersionCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "RegimenFiscal", "@Orden", 23, "@Valor", CStr(cmbRegimenFiscal.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MetodoPago", "@Orden", 24, "@Valor", CStr(cmbMetodoPago.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Moneda", "@Orden", 25, "@Valor", cmbMoneda.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MonedaCambio", "@Orden", 26, "@Valor", cmbMonedaCambio.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "FormatFac", "@Orden", 27, "@Valor", cmbFactura.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Aplicacion", "@Orden", 28, "@Valor", ChkAplicacion.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Costeo", "@Orden", 29, "@Valor", cmbCosteo.SelectedValue, "@COMClave", COMClave)


                'PAC
                If dtPAC.Rows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To dtPAC.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_PAC", _
                      "@COMClave", COMClave, _
                      "@TipoPAC", dtPAC.Rows(i)("TipoPAC"), _
                      "@UserId", dtPAC.Rows(i)("UserId"), _
                      "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), _
                      "@ServerTimbre", dtPAC.Rows(i)("Serv. Timbrado"), _
                      "@ServerCancel", dtPAC.Rows(i)("Serv. Cancelación"), _
                      "@Timbres", dtPAC.Rows(i)("Timbres"), _
                      "@Orden", dtPAC.Rows(i)("Orden"), _
                      "@Usuario", ModPOS.UsuarioActual)
                    Next
                End If

                Me.Close()
            Else

                ModPOS.Ejecuta("sp_actualiza_Compania", _
                "@COMClave", COMClave, _
                "@Clave", UCase(Trim(TxtClave.Text)), _
                "@Logo", Icono, _
                "@Nombre", UCase(Trim(TxtNombre.Text)), _
                "@RFC", TxtRFC.Text.ToUpper.Trim, _
                "@Pais", CmbPaisFac.Text.ToUpper.Trim, _
                "@Entidad", TxtEstadoFac.Text.ToUpper.Trim, _
                "@Municipio", TxtMunicipioFac.Text.ToUpper.Trim, _
                "@Colonia", TxtColoniaFac.Text.ToUpper.Trim, _
                "@Calle", TxtDomicilioFac.Text.ToUpper.Trim, _
                "@codigoPostal", TxtCodigoPostal.Text.ToUpper.Trim, _
                "@Localidad", TxtLocalidad.Text.ToUpper.Trim, _
                "@referencia", TxtReferencia.Text.ToUpper.Trim, _
                "@noExterior", TxtNoExterior.Text.ToUpper.Trim, _
                "@noInterior", TxtNoInterior.Text.ToUpper.Trim, _
                "@Telefono", TxtTelefono.Text, _
                "@Fax", TxtFax.Text, _
                "@Ticket", 1, _
                "@Factura", 1, _
                "@Folio", 0, _
                "@registroPatronal", TxtRegPatronal.Text, _
                "@RiesgoPuesto", cmbRiesgoPuesto.SelectedValue, _
                "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DigitoOrd", "@Valor", CStr(Me.NumCompra.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DigitoProv", "@Valor", CStr(Me.NumProveedor.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Digitos", "@Valor", CStr(Me.NumCliente.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DirXML", "@Valor", TxtXML.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Imagenes", "@Valor", TxtDireccion.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Impuesto", "@Valor", CmbImpuesto.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "LineasFac", "@Valor", CStr(Me.NumLineFactura.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "LineasNC", "@Valor", CStr(Me.NumLineNota.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "SUCURSAL", "@Valor", txtSucursal.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "NumMesHist", "@Valor", CStr(Me.NumHistorico.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "PorcRiesgoCred", "@Valor", CStr(Me.NumPorcRiesgo.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailAdress", "@Valor", TxtMailAdress.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DisplayName", "@Valor", TxtDisplayName.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailUser", "@Valor", TxtMailUser.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailPassword", "@Valor", TxtMailPassword.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "HostSMTP", "@Valor", TxtHostSMTP.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailPort", "@Valor", TxtMailPort.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailSSL", "@Valor", ChkMailSSL.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "RepOrden", "@Valor", CmbFormatOC.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "TimeOut", "@Valor", CStr(Me.NumTimeOut.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "TipoCF", "@Valor", CStr(cmbTipoCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "VersionCF", "@Valor", CStr(cmbVersionCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "RegimenFiscal", "@Valor", CStr(cmbRegimenFiscal.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Moneda", "@Valor", cmbMoneda.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MonedaCambio", "@Valor", cmbMonedaCambio.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MetodoPago", "@Valor", CStr(cmbMetodoPago.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "FormatFac", "@Valor", cmbFactura.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Aplicacion", "@Valor", ChkAplicacion.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Costeo", "@Valor", cmbCosteo.SelectedValue, "@COMClave", COMClave)



                'PAC
                If ActualizaPAC AndAlso dtPAC.Rows.Count > 0 Then

                    ModPOS.Ejecuta("sp_elimina_PAC", "@COMClave", COMClave)


                    Dim i As Integer
                    For i = 0 To dtPAC.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_PAC", _
                      "@COMClave", COMClave, _
                      "@TipoPAC", dtPAC.Rows(i)("TipoPAC"), _
                      "@UserId", dtPAC.Rows(i)("UserId"), _
                      "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), _
                      "@ServerTimbre", dtPAC.Rows(i)("Serv. Timbrado"), _
                      "@ServerCancel", dtPAC.Rows(i)("Serv. Cancelación"), _
                      "@Timbres", dtPAC.Rows(i)("Timbres"), _
                      "@Orden", dtPAC.Rows(i)("Orden"), _
                      "@Usuario", ModPOS.UsuarioActual)
                    Next

                    ActualizaPAC = False
                End If

                Me.Close()

            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmCompania_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoCompania Is Nothing Then
            ModPOS.ActualizaGrid(False, ModPOS.MtoCompania.GridCompania, "sp_muestra_companias", Nothing)
            ModPOS.MtoCompania.GridCompania.RootTable.Columns("COMClave").Visible = False
        End If
        ModPOS.Compania.Dispose()
        ModPOS.Compania = Nothing
    End Sub

    Private Sub BtnExplorador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExplorador.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then

            If a.SelectedPath.Length <= 3 Then
                TxtDireccion.Text = a.SelectedPath
            Else
                TxtDireccion.Text = a.SelectedPath
            End If
        End If
    End Sub


    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        testMail()
    End Sub

    Private Sub BtnXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXML.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then

            If a.SelectedPath.Length <= 3 Then
                TxtXML.Text = a.SelectedPath
            Else
                TxtXML.Text = a.SelectedPath
            End If
        End If
    End Sub

    Private Sub cmbTipoCF_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoCF.SelectedValueChanged
        If cargado = True AndAlso Not cmbTipoCF.SelectedValue Is Nothing Then
            With Me.cmbVersionCF
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_versioncfd"
                .NombreParametro1 = "Grupo"
                .Parametro1 = cmbTipoCF.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub TxtEstadoFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstadoFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEstadoFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtEstadoFac.Text <> EstadoFac Then
            Dim dtMnpio As DataTable
            dtMnpio = ModPOS.Recupera_Tabla("sp_recupera_mnpio", "@Estado", TxtEstadoFac.Text.Trim.ToUpper)
            If dtMnpio.Rows.Count > 0 Then
                ReDim aMnpio(dtMnpio.Rows.Count - 1)
                For i As Integer = 0 To dtMnpio.Rows.Count - 1
                    aMnpio(i) = dtMnpio.Rows(i)("d_mnpio")
                Next
                Me.TxtMunicipioFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtMunicipioFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtMunicipioFac.AutoCompleteCustomSource.AddRange(aMnpio)
                dtMnpio.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtMunicipioFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMunicipioFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtMunicipioFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipioFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MunicipioFac Then
            Dim dtColonia As DataTable
            dtColonia = ModPOS.Recupera_Tabla("sp_recupera_colonia", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper)
            If dtColonia.Rows.Count > 0 Then
                ReDim aColonia(dtColonia.Rows.Count - 1)
                For i As Integer = 0 To dtColonia.Rows.Count - 1
                    aColonia(i) = dtColonia.Rows(i)("Nombre")
                Next
                Me.TxtColoniaFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtColoniaFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtColoniaFac.AutoCompleteCustomSource.AddRange(aColonia)
                dtColonia.Dispose()
            End If
            If TxtLocalidad.Text = "" Then
                Me.TxtLocalidad.Text = TxtMunicipioFac.Text
            End If
        End If

    End Sub

    Private Sub TxtColoniaFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtColoniaFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtColoniaFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColoniaFac.LostFocus
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> ColoniaFac AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MunicipioFac Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostal.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtLocalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLocalidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCodigoPostal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoPostal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDireccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNoExterior_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoExterior.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmbPaisFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPaisFac.SelectedIndexChanged
        If cargado = True AndAlso Not CmbPaisFac.SelectedValue Is Nothing Then
            Dim dtEstado As DataTable

            dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
            If dtEstado.Rows.Count > 0 Then
                ReDim aEstado(dtEstado.Rows.Count - 1)

                For i As Integer = 0 To dtEstado.Rows.Count - 1
                    aEstado(i) = dtEstado.Rows(i)("d_estado")
                Next

                Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)

                dtEstado.Dispose()
            End If

        End If

    End Sub

    Private Sub BtnAddPAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPAC.Click
        Dim a As New FrmPAC
        a.COMClave = COMClave
        a.ShowDialog()
    End Sub


    Public Sub AddPAC( _
    ByVal TipoPac As Integer, _
    ByVal PAC As String, _
    ByVal CustomerKey As String, _
    ByVal ServerTimbre As String, _
    ByVal ServerCancel As String, _
    ByVal UserId As String, _
    ByVal Timbres As Integer)


        Dim foundRows() As Data.DataRow
        foundRows = dtPAC.Select("TipoPAC = " & CStr(TipoPac))

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = dtPAC.NewRow()
            'declara el nombre de la fila

            row1.Item("TipoPAC") = TipoPac
            row1.Item("PAC") = PAC
            row1.Item("UserId") = UserId
            row1.Item("CustomerKey") = CustomerKey
            row1.Item("Serv. Timbrado") = ServerTimbre
            row1.Item("Serv. Cancelación") = ServerCancel
            row1.Item("Timbres") = Timbres
            row1.Item("Orden") = dtPAC.Rows.Count + 1
            dtPAC.Rows.Add(row1)
            'agrega la fila completo a la tabla

            If Padre = "Modificar" Then
                ActualizaPAC = True
            End If
        Else
            Beep()
            MessageBox.Show("¡El PAC que intenta agregar ya existe para la Compañia actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnDelPAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelPAC.Click
        If GridPAC.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el PAC: " & GridPAC.GetValue("PAC"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtPAC.Select("TipoPAC = " & CStr(GridPAC.GetValue("TipoPAC")))

                    dtPAC.Rows.Remove(foundRows(0))

                    If Padre = "Modificar" Then
                        ActualizaPAC = True
                    End If
            End Select
        End If
    End Sub

    Private Sub GridPAC_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridPAC.CellEdited
        Select Case GridPAC.CurrentColumn.Caption.Replace(" ", "")
            Case "CustomerKey"
                If (GridPAC.GetValue("CustomerKey").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("CustomerKey")).Length = 0) Then
                    GridPAC.SetValue("CustomerKey", "Error")
                End If


            Case "Serv.Timbrado"
                If (GridPAC.GetValue("Serv. Timbrado").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("Serv. Timbrado")).Length = 0) Then
                    GridPAC.SetValue("Serv. Timbrado", "Error")
                End If

            Case "Serv.Cancelación"
                If (GridPAC.GetValue("Serv. Cancelación").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("Serv. Cancelación")).Length = 0) Then
                    GridPAC.SetValue("Serv. Cancelación", "Error")
                End If

            Case "UserId"
                If (GridPAC.GetValue("TipoPAC") = 2 OrElse GridPAC.GetValue("TipoPAC") = 3) AndAlso (GridPAC.GetValue("UserId").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("UserId")).Length = 0) Then
                    GridPAC.SetValue("UserId", "Error")
                ElseIf GridPAC.GetValue("TipoPAC") = 1 Then
                    GridPAC.SetValue("UserId", "")
                End If


            Case "Orden"
                If Not (IsNumeric(GridPAC.GetValue("Orden")) AndAlso CDbl(GridPAC.GetValue("Orden")) > 0) Then
                    GridPAC.SetValue("Orden", 1)
                End If


            Case "Timbres"
                If Not (IsNumeric(GridPAC.GetValue("Timbres")) AndAlso CDbl(GridPAC.GetValue("Timbres")) > 0) Then
                    GridPAC.SetValue("Timbres", 1)
                End If

        End Select

        ActualizaPAC = True

    End Sub


End Class
