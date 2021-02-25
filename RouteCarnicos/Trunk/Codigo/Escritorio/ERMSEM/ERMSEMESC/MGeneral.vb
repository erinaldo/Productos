Imports System.IO

Public Enum eModo
    Crear = 1
    Modificar
    Eliminar
    Leer
End Enum

Public Class MGeneral
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LbEstado As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabGenerales As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents PbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtTelefono As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNombreEmpresa As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents lblNombreEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblLogo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPais As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtRegion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents txtLocalidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLocalidad As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents txtInterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumeroInt As System.Windows.Forms.Label
    Friend WithEvents txtNumero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents txtColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents txtCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ebClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbConfirmacion As System.Windows.Forms.Label
    Friend WithEvents lbContrasenaClave As System.Windows.Forms.Label
    Friend WithEvents ebConfirmacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbDirArchivosFacElec As System.Windows.Forms.Label
    Friend WithEvents ebcontrasenaClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDirArchivosFacElec As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btDirArchivos As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebDirectorioXML As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btDirXML As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbDirectorioXML As System.Windows.Forms.Label
    Friend WithEvents btDirRepMensual As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebClienteClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDirRepMensual As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbDirRepMensual As System.Windows.Forms.Label
    Friend WithEvents lbClienteClave As System.Windows.Forms.Label
    Friend WithEvents ebClienteRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chbFoliosTerminal As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbComprobanteDig As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbFormatoFactura As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblFormatoFactura As System.Windows.Forms.Label
    'Friend WithEvents chbMultiplesPedidos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btHistorico As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblVersionCFD As System.Windows.Forms.Label
    Friend WithEvents cbVersionCFD As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblProveedorTimbre As System.Windows.Forms.Label
    Friend WithEvents cbProveedorTimbre As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents GroupBoxCFDi As System.Windows.Forms.GroupBox
    Friend WithEvents lbCustomerKey As System.Windows.Forms.Label
    Friend WithEvents ebCustomerKey As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbServidorTimbre As System.Windows.Forms.Label
    Friend WithEvents ebServidorTimbre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbServidorCancelacion As System.Windows.Forms.Label
    Friend WithEvents ebServidorCancelacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MGeneral))
        Me.LbEstado = New System.Windows.Forms.Label
        Me.cbEstado = New Janus.Windows.EditControls.UIComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabGenerales = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPais = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblPais = New System.Windows.Forms.Label
        Me.txtMunicipio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblMunicipio = New System.Windows.Forms.Label
        Me.txtRegion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblRegion = New System.Windows.Forms.Label
        Me.txtLocalidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblLocalidad = New System.Windows.Forms.Label
        Me.txtCodigoPostal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblCodigoPostal = New System.Windows.Forms.Label
        Me.txtInterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblNumeroInt = New System.Windows.Forms.Label
        Me.txtNumero = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblNumero = New System.Windows.Forms.Label
        Me.txtReferencia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblReferencia = New System.Windows.Forms.Label
        Me.txtColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblColonia = New System.Windows.Forms.Label
        Me.txtCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblCalle = New System.Windows.Forms.Label
        Me.txtTelefono = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtNombreEmpresa = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.lblRFC = New System.Windows.Forms.Label
        Me.lblNombreEmpresa = New System.Windows.Forms.Label
        Me.lblLogo = New System.Windows.Forms.Label
        Me.PbLogo = New System.Windows.Forms.PictureBox
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBoxCFDi = New System.Windows.Forms.GroupBox
        Me.lbServidorCancelacion = New System.Windows.Forms.Label
        Me.ebServidorCancelacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbServidorTimbre = New System.Windows.Forms.Label
        Me.ebServidorTimbre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCustomerKey = New System.Windows.Forms.Label
        Me.ebCustomerKey = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblProveedorTimbre = New System.Windows.Forms.Label
        Me.cbProveedorTimbre = New Janus.Windows.EditControls.UIComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbContrasenaClave = New System.Windows.Forms.Label
        Me.ebcontrasenaClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebConfirmacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbConfirmacion = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbDirArchivosFacElec = New System.Windows.Forms.Label
        Me.lbDirRepMensual = New System.Windows.Forms.Label
        Me.ebDirRepMensual = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btDirRepMensual = New Janus.Windows.EditControls.UIButton
        Me.lbDirectorioXML = New System.Windows.Forms.Label
        Me.btDirXML = New Janus.Windows.EditControls.UIButton
        Me.ebDirectorioXML = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDirArchivosFacElec = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btDirArchivos = New Janus.Windows.EditControls.UIButton
        Me.ebClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btCliente = New Janus.Windows.EditControls.UIButton
        Me.ebClienteClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbClienteClave = New System.Windows.Forms.Label
        Me.ebClienteRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.chbFoliosTerminal = New Janus.Windows.EditControls.UICheckBox
        Me.chbComprobanteDig = New Janus.Windows.EditControls.UICheckBox
        Me.lblVersionCFD = New System.Windows.Forms.Label
        Me.lblFormatoFactura = New System.Windows.Forms.Label
        Me.cbVersionCFD = New Janus.Windows.EditControls.UIComboBox
        Me.cbFormatoFactura = New Janus.Windows.EditControls.UIComboBox
        Me.btHistorico = New Janus.Windows.EditControls.UIButton
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabGenerales.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        Me.GroupBoxCFDi.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbEstado
        '
        Me.LbEstado.Location = New System.Drawing.Point(372, 11)
        Me.LbEstado.Name = "LbEstado"
        Me.LbEstado.Size = New System.Drawing.Size(132, 20)
        Me.LbEstado.TabIndex = 4
        Me.LbEstado.Text = "Estado"
        Me.LbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEstado
        '
        Me.cbEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbEstado.Enabled = False
        Me.cbEstado.Location = New System.Drawing.Point(508, 11)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(136, 20)
        Me.cbEstado.TabIndex = 0
        Me.cbEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(28, 547)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 3)
        Me.Label5.TabIndex = 4
        Me.Label5.Visible = False
        '
        'btCancelar
        '
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(540, 367)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 3
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(428, 367)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 2
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabGenerales)
        Me.TabControl1.Location = New System.Drawing.Point(12, 37)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(632, 318)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabGenerales
        '
        Me.TabGenerales.Controls.Add(Me.GroupBox1)
        Me.TabGenerales.Controls.Add(Me.txtTelefono)
        Me.TabGenerales.Controls.Add(Me.txtRFC)
        Me.TabGenerales.Controls.Add(Me.txtNombreEmpresa)
        Me.TabGenerales.Controls.Add(Me.lblTelefono)
        Me.TabGenerales.Controls.Add(Me.lblRFC)
        Me.TabGenerales.Controls.Add(Me.lblNombreEmpresa)
        Me.TabGenerales.Controls.Add(Me.lblLogo)
        Me.TabGenerales.Controls.Add(Me.PbLogo)
        Me.TabGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabGenerales.Location = New System.Drawing.Point(0, 26)
        Me.TabGenerales.Name = "TabGenerales"
        Me.TabGenerales.Padding = New System.Windows.Forms.Padding(1)
        Me.TabGenerales.Size = New System.Drawing.Size(632, 292)
        Me.TabGenerales.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabGenerales.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabGenerales.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabGenerales.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabGenerales.Style.GradientAngle = 90
        Me.TabGenerales.TabIndex = 0
        Me.TabGenerales.TabItem = Me.TabItem1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtPais)
        Me.GroupBox1.Controls.Add(Me.lblPais)
        Me.GroupBox1.Controls.Add(Me.txtMunicipio)
        Me.GroupBox1.Controls.Add(Me.lblMunicipio)
        Me.GroupBox1.Controls.Add(Me.txtRegion)
        Me.GroupBox1.Controls.Add(Me.lblRegion)
        Me.GroupBox1.Controls.Add(Me.txtLocalidad)
        Me.GroupBox1.Controls.Add(Me.lblLocalidad)
        Me.GroupBox1.Controls.Add(Me.txtCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.lblCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.txtInterior)
        Me.GroupBox1.Controls.Add(Me.lblNumeroInt)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.lblNumero)
        Me.GroupBox1.Controls.Add(Me.txtReferencia)
        Me.GroupBox1.Controls.Add(Me.lblReferencia)
        Me.GroupBox1.Controls.Add(Me.txtColonia)
        Me.GroupBox1.Controls.Add(Me.lblColonia)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Controls.Add(Me.lblCalle)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 162)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Domicilio"
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(381, 123)
        Me.txtPais.MaxLength = 40
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(237, 20)
        Me.txtPais.TabIndex = 9
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.BackColor = System.Drawing.Color.Transparent
        Me.lblPais.Location = New System.Drawing.Point(317, 126)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(27, 13)
        Me.lblPais.TabIndex = 19
        Me.lblPais.Text = "Pais"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Location = New System.Drawing.Point(381, 97)
        Me.txtMunicipio.MaxLength = 40
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Size = New System.Drawing.Size(237, 20)
        Me.txtMunicipio.TabIndex = 7
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.BackColor = System.Drawing.Color.Transparent
        Me.lblMunicipio.Location = New System.Drawing.Point(317, 100)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(52, 13)
        Me.lblMunicipio.TabIndex = 17
        Me.lblMunicipio.Text = "Municipio"
        '
        'txtRegion
        '
        Me.txtRegion.Location = New System.Drawing.Point(70, 123)
        Me.txtRegion.MaxLength = 40
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Size = New System.Drawing.Size(237, 20)
        Me.txtRegion.TabIndex = 8
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.BackColor = System.Drawing.Color.Transparent
        Me.lblRegion.Location = New System.Drawing.Point(6, 126)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblRegion.TabIndex = 15
        Me.lblRegion.Text = "Region"
        '
        'txtLocalidad
        '
        Me.txtLocalidad.Location = New System.Drawing.Point(70, 97)
        Me.txtLocalidad.MaxLength = 40
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Size = New System.Drawing.Size(237, 20)
        Me.txtLocalidad.TabIndex = 6
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.BackColor = System.Drawing.Color.Transparent
        Me.lblLocalidad.Location = New System.Drawing.Point(6, 100)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 13
        Me.lblLocalidad.Text = "Localidad"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Location = New System.Drawing.Point(524, 45)
        Me.txtCodigoPostal.MaxLength = 16
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigoPostal.TabIndex = 4
        '
        'lblCodigoPostal
        '
        Me.lblCodigoPostal.AutoSize = True
        Me.lblCodigoPostal.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigoPostal.Location = New System.Drawing.Point(460, 48)
        Me.lblCodigoPostal.Name = "lblCodigoPostal"
        Me.lblCodigoPostal.Size = New System.Drawing.Size(27, 13)
        Me.lblCodigoPostal.TabIndex = 11
        Me.lblCodigoPostal.Text = "C.P."
        '
        'txtInterior
        '
        Me.txtInterior.Location = New System.Drawing.Point(524, 19)
        Me.txtInterior.MaxLength = 16
        Me.txtInterior.Name = "txtInterior"
        Me.txtInterior.Size = New System.Drawing.Size(94, 20)
        Me.txtInterior.TabIndex = 2
        '
        'lblNumeroInt
        '
        Me.lblNumeroInt.AutoSize = True
        Me.lblNumeroInt.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeroInt.Location = New System.Drawing.Point(460, 22)
        Me.lblNumeroInt.Name = "lblNumeroInt"
        Me.lblNumeroInt.Size = New System.Drawing.Size(39, 13)
        Me.lblNumeroInt.TabIndex = 11
        Me.lblNumeroInt.Text = "Interior"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(354, 19)
        Me.txtNumero.MaxLength = 16
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 1
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.BackColor = System.Drawing.Color.Transparent
        Me.lblNumero.Location = New System.Drawing.Point(284, 22)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(42, 13)
        Me.lblNumero.TabIndex = 9
        Me.lblNumero.Text = "Exterior"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(70, 71)
        Me.txtReferencia.MaxLength = 100
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(548, 20)
        Me.txtReferencia.TabIndex = 5
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lblReferencia.Location = New System.Drawing.Point(6, 74)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(59, 13)
        Me.lblReferencia.TabIndex = 7
        Me.lblReferencia.Text = "Referencia"
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(70, 45)
        Me.txtColonia.MaxLength = 64
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(384, 20)
        Me.txtColonia.TabIndex = 3
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.BackColor = System.Drawing.Color.Transparent
        Me.lblColonia.Location = New System.Drawing.Point(6, 48)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(42, 13)
        Me.lblColonia.TabIndex = 7
        Me.lblColonia.Text = "Colonia"
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(70, 19)
        Me.txtCalle.MaxLength = 64
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(208, 20)
        Me.txtCalle.TabIndex = 0
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.BackColor = System.Drawing.Color.Transparent
        Me.lblCalle.Location = New System.Drawing.Point(6, 22)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(30, 13)
        Me.lblCalle.TabIndex = 7
        Me.lblCalle.Text = "Calle"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(528, 59)
        Me.txtTelefono.MaxLength = 32
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(93, 20)
        Me.txtTelefono.TabIndex = 2
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(205, 59)
        Me.txtRFC.MaxLength = 64
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(253, 20)
        Me.txtRFC.TabIndex = 1
        '
        'txtNombreEmpresa
        '
        Me.txtNombreEmpresa.Location = New System.Drawing.Point(205, 20)
        Me.txtNombreEmpresa.MaxLength = 60
        Me.txtNombreEmpresa.Name = "txtNombreEmpresa"
        Me.txtNombreEmpresa.Size = New System.Drawing.Size(416, 20)
        Me.txtNombreEmpresa.TabIndex = 0
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.BackColor = System.Drawing.Color.Transparent
        Me.lblTelefono.Location = New System.Drawing.Point(464, 62)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
        Me.lblTelefono.TabIndex = 3
        Me.lblTelefono.Text = "Telefono"
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.BackColor = System.Drawing.Color.Transparent
        Me.lblRFC.Location = New System.Drawing.Point(110, 62)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(28, 13)
        Me.lblRFC.TabIndex = 2
        Me.lblRFC.Text = "RFC"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(110, 23)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(88, 13)
        Me.lblNombreEmpresa.TabIndex = 2
        Me.lblNombreEmpresa.Text = "Nombre Empresa"
        '
        'lblLogo
        '
        Me.lblLogo.AutoSize = True
        Me.lblLogo.BackColor = System.Drawing.Color.Transparent
        Me.lblLogo.Location = New System.Drawing.Point(25, 97)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Size = New System.Drawing.Size(48, 13)
        Me.lblLogo.TabIndex = 1
        Me.lblLogo.Text = "Logotipo"
        '
        'PbLogo
        '
        Me.PbLogo.BackColor = System.Drawing.Color.Transparent
        Me.PbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbLogo.Location = New System.Drawing.Point(4, 4)
        Me.PbLogo.Name = "PbLogo"
        Me.PbLogo.Size = New System.Drawing.Size(90, 90)
        Me.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PbLogo.TabIndex = 0
        Me.PbLogo.TabStop = False
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabGenerales
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Datos Generales"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.GroupBoxCFDi)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox3)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox2)
        Me.TabControlPanel1.Controls.Add(Me.ebClave)
        Me.TabControlPanel1.Controls.Add(Me.btCliente)
        Me.TabControlPanel1.Controls.Add(Me.ebClienteClave)
        Me.TabControlPanel1.Controls.Add(Me.lbClienteClave)
        Me.TabControlPanel1.Controls.Add(Me.ebClienteRFC)
        Me.TabControlPanel1.Controls.Add(Me.chbFoliosTerminal)
        Me.TabControlPanel1.Controls.Add(Me.chbComprobanteDig)
        Me.TabControlPanel1.Controls.Add(Me.lblVersionCFD)
        Me.TabControlPanel1.Controls.Add(Me.lblFormatoFactura)
        Me.TabControlPanel1.Controls.Add(Me.cbVersionCFD)
        Me.TabControlPanel1.Controls.Add(Me.cbFormatoFactura)
        Me.TabControlPanel1.Controls.Add(Me.btHistorico)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(632, 292)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem2
        '
        'GroupBoxCFDi
        '
        Me.GroupBoxCFDi.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxCFDi.Controls.Add(Me.lbServidorCancelacion)
        Me.GroupBoxCFDi.Controls.Add(Me.ebServidorCancelacion)
        Me.GroupBoxCFDi.Controls.Add(Me.lbServidorTimbre)
        Me.GroupBoxCFDi.Controls.Add(Me.ebServidorTimbre)
        Me.GroupBoxCFDi.Controls.Add(Me.lbCustomerKey)
        Me.GroupBoxCFDi.Controls.Add(Me.ebCustomerKey)
        Me.GroupBoxCFDi.Controls.Add(Me.lblProveedorTimbre)
        Me.GroupBoxCFDi.Controls.Add(Me.cbProveedorTimbre)
        Me.GroupBoxCFDi.Location = New System.Drawing.Point(5, 291)
        Me.GroupBoxCFDi.Name = "GroupBoxCFDi"
        Me.GroupBoxCFDi.Size = New System.Drawing.Size(623, 125)
        Me.GroupBoxCFDi.TabIndex = 38
        Me.GroupBoxCFDi.TabStop = False
        Me.GroupBoxCFDi.Text = "CFD V3"
        Me.GroupBoxCFDi.Visible = False
        '
        'lbServidorCancelacion
        '
        Me.lbServidorCancelacion.BackColor = System.Drawing.Color.Transparent
        Me.lbServidorCancelacion.Location = New System.Drawing.Point(8, 90)
        Me.lbServidorCancelacion.Name = "lbServidorCancelacion"
        Me.lbServidorCancelacion.Size = New System.Drawing.Size(131, 20)
        Me.lbServidorCancelacion.TabIndex = 36
        Me.lbServidorCancelacion.Text = "Servidor Cancelacion"
        Me.lbServidorCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebServidorCancelacion
        '
        Me.ebServidorCancelacion.Location = New System.Drawing.Point(197, 90)
        Me.ebServidorCancelacion.MaxLength = 64
        Me.ebServidorCancelacion.Name = "ebServidorCancelacion"
        Me.ebServidorCancelacion.Size = New System.Drawing.Size(408, 20)
        Me.ebServidorCancelacion.TabIndex = 35
        Me.ebServidorCancelacion.Tag = "Calle"
        Me.ebServidorCancelacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorCancelacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbServidorTimbre
        '
        Me.lbServidorTimbre.BackColor = System.Drawing.Color.Transparent
        Me.lbServidorTimbre.Location = New System.Drawing.Point(8, 62)
        Me.lbServidorTimbre.Name = "lbServidorTimbre"
        Me.lbServidorTimbre.Size = New System.Drawing.Size(131, 20)
        Me.lbServidorTimbre.TabIndex = 36
        Me.lbServidorTimbre.Text = "Servidor Timbre"
        Me.lbServidorTimbre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebServidorTimbre
        '
        Me.ebServidorTimbre.Location = New System.Drawing.Point(197, 62)
        Me.ebServidorTimbre.MaxLength = 64
        Me.ebServidorTimbre.Name = "ebServidorTimbre"
        Me.ebServidorTimbre.Size = New System.Drawing.Size(408, 20)
        Me.ebServidorTimbre.TabIndex = 35
        Me.ebServidorTimbre.Tag = "Calle"
        Me.ebServidorTimbre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorTimbre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCustomerKey
        '
        Me.lbCustomerKey.BackColor = System.Drawing.Color.Transparent
        Me.lbCustomerKey.Location = New System.Drawing.Point(8, 36)
        Me.lbCustomerKey.Name = "lbCustomerKey"
        Me.lbCustomerKey.Size = New System.Drawing.Size(131, 20)
        Me.lbCustomerKey.TabIndex = 36
        Me.lbCustomerKey.Text = "Customer Key"
        Me.lbCustomerKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCustomerKey
        '
        Me.ebCustomerKey.Location = New System.Drawing.Point(197, 36)
        Me.ebCustomerKey.MaxLength = 64
        Me.ebCustomerKey.Name = "ebCustomerKey"
        Me.ebCustomerKey.Size = New System.Drawing.Size(408, 20)
        Me.ebCustomerKey.TabIndex = 35
        Me.ebCustomerKey.Tag = "Calle"
        Me.ebCustomerKey.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCustomerKey.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblProveedorTimbre
        '
        Me.lblProveedorTimbre.AutoSize = True
        Me.lblProveedorTimbre.BackColor = System.Drawing.Color.Transparent
        Me.lblProveedorTimbre.Location = New System.Drawing.Point(8, 16)
        Me.lblProveedorTimbre.Name = "lblProveedorTimbre"
        Me.lblProveedorTimbre.Size = New System.Drawing.Size(91, 13)
        Me.lblProveedorTimbre.TabIndex = 11
        Me.lblProveedorTimbre.Text = "Proveedor Timbre"
        '
        'cbProveedorTimbre
        '
        Me.cbProveedorTimbre.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbProveedorTimbre.Location = New System.Drawing.Point(196, 12)
        Me.cbProveedorTimbre.Name = "cbProveedorTimbre"
        Me.cbProveedorTimbre.Size = New System.Drawing.Size(156, 20)
        Me.cbProveedorTimbre.TabIndex = 0
        Me.cbProveedorTimbre.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ebConfirmacion)
        Me.GroupBox3.Controls.Add(Me.lbContrasenaClave)
        Me.GroupBox3.Controls.Add(Me.ebcontrasenaClave)
        Me.GroupBox3.Controls.Add(Me.lbConfirmacion)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 206)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(624, 79)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contraseña Clave Privada"
        '
        'lbContrasenaClave
        '
        Me.lbContrasenaClave.BackColor = System.Drawing.Color.Transparent
        Me.lbContrasenaClave.Location = New System.Drawing.Point(5, 16)
        Me.lbContrasenaClave.Name = "lbContrasenaClave"
        Me.lbContrasenaClave.Size = New System.Drawing.Size(190, 20)
        Me.lbContrasenaClave.TabIndex = 34
        Me.lbContrasenaClave.Text = "ContrasenaClave"
        Me.lbContrasenaClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebcontrasenaClave
        '
        Me.ebcontrasenaClave.Location = New System.Drawing.Point(203, 16)
        Me.ebcontrasenaClave.MaxLength = 64
        Me.ebcontrasenaClave.Name = "ebcontrasenaClave"
        Me.ebcontrasenaClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebcontrasenaClave.Size = New System.Drawing.Size(156, 20)
        Me.ebcontrasenaClave.TabIndex = 31
        Me.ebcontrasenaClave.Tag = "Calle"
        Me.ebcontrasenaClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebcontrasenaClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebConfirmacion
        '
        Me.ebConfirmacion.Location = New System.Drawing.Point(203, 42)
        Me.ebConfirmacion.MaxLength = 64
        Me.ebConfirmacion.Name = "ebConfirmacion"
        Me.ebConfirmacion.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebConfirmacion.Size = New System.Drawing.Size(156, 20)
        Me.ebConfirmacion.TabIndex = 32
        Me.ebConfirmacion.Tag = "Calle"
        Me.ebConfirmacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebConfirmacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbConfirmacion
        '
        Me.lbConfirmacion.BackColor = System.Drawing.Color.Transparent
        Me.lbConfirmacion.Location = New System.Drawing.Point(5, 42)
        Me.lbConfirmacion.Name = "lbConfirmacion"
        Me.lbConfirmacion.Size = New System.Drawing.Size(207, 26)
        Me.lbConfirmacion.TabIndex = 35
        Me.lbConfirmacion.Text = "Confirmar Contraseña de Clave Privada"
        Me.lbConfirmacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lbDirArchivosFacElec)
        Me.GroupBox2.Controls.Add(Me.lbDirRepMensual)
        Me.GroupBox2.Controls.Add(Me.ebDirRepMensual)
        Me.GroupBox2.Controls.Add(Me.btDirRepMensual)
        Me.GroupBox2.Controls.Add(Me.lbDirectorioXML)
        Me.GroupBox2.Controls.Add(Me.btDirXML)
        Me.GroupBox2.Controls.Add(Me.ebDirectorioXML)
        Me.GroupBox2.Controls.Add(Me.ebDirArchivosFacElec)
        Me.GroupBox2.Controls.Add(Me.btDirArchivos)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(624, 118)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Directorios"
        '
        'lbDirArchivosFacElec
        '
        Me.lbDirArchivosFacElec.BackColor = System.Drawing.Color.Transparent
        Me.lbDirArchivosFacElec.Location = New System.Drawing.Point(5, 78)
        Me.lbDirArchivosFacElec.Name = "lbDirArchivosFacElec"
        Me.lbDirArchivosFacElec.Size = New System.Drawing.Size(163, 20)
        Me.lbDirArchivosFacElec.TabIndex = 33
        Me.lbDirArchivosFacElec.Text = "DirArchivosFacElec"
        Me.lbDirArchivosFacElec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDirRepMensual
        '
        Me.lbDirRepMensual.BackColor = System.Drawing.Color.Transparent
        Me.lbDirRepMensual.Location = New System.Drawing.Point(5, 27)
        Me.lbDirRepMensual.Name = "lbDirRepMensual"
        Me.lbDirRepMensual.Size = New System.Drawing.Size(190, 20)
        Me.lbDirRepMensual.TabIndex = 21
        Me.lbDirRepMensual.Text = "Directorio Reportes Mensuales"
        Me.lbDirRepMensual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDirRepMensual
        '
        Me.ebDirRepMensual.Enabled = False
        Me.ebDirRepMensual.Location = New System.Drawing.Point(203, 27)
        Me.ebDirRepMensual.Name = "ebDirRepMensual"
        Me.ebDirRepMensual.Size = New System.Drawing.Size(383, 20)
        Me.ebDirRepMensual.TabIndex = 24
        Me.ebDirRepMensual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDirRepMensual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btDirRepMensual
        '
        Me.btDirRepMensual.Location = New System.Drawing.Point(587, 27)
        Me.btDirRepMensual.Name = "btDirRepMensual"
        Me.btDirRepMensual.Size = New System.Drawing.Size(24, 20)
        Me.btDirRepMensual.TabIndex = 25
        Me.btDirRepMensual.Text = "..."
        Me.btDirRepMensual.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbDirectorioXML
        '
        Me.lbDirectorioXML.BackColor = System.Drawing.Color.Transparent
        Me.lbDirectorioXML.Location = New System.Drawing.Point(5, 52)
        Me.lbDirectorioXML.Name = "lbDirectorioXML"
        Me.lbDirectorioXML.Size = New System.Drawing.Size(163, 20)
        Me.lbDirectorioXML.TabIndex = 29
        Me.lbDirectorioXML.Text = "lbDirectorioXML"
        Me.lbDirectorioXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btDirXML
        '
        Me.btDirXML.Location = New System.Drawing.Point(587, 52)
        Me.btDirXML.Name = "btDirXML"
        Me.btDirXML.Size = New System.Drawing.Size(24, 20)
        Me.btDirXML.TabIndex = 27
        Me.btDirXML.Text = "..."
        Me.btDirXML.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebDirectorioXML
        '
        Me.ebDirectorioXML.Enabled = False
        Me.ebDirectorioXML.Location = New System.Drawing.Point(203, 52)
        Me.ebDirectorioXML.MaxLength = 64
        Me.ebDirectorioXML.Name = "ebDirectorioXML"
        Me.ebDirectorioXML.Size = New System.Drawing.Size(383, 20)
        Me.ebDirectorioXML.TabIndex = 26
        Me.ebDirectorioXML.Tag = "Calle"
        Me.ebDirectorioXML.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDirectorioXML.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebDirArchivosFacElec
        '
        Me.ebDirArchivosFacElec.Enabled = False
        Me.ebDirArchivosFacElec.Location = New System.Drawing.Point(203, 78)
        Me.ebDirArchivosFacElec.MaxLength = 64
        Me.ebDirArchivosFacElec.Name = "ebDirArchivosFacElec"
        Me.ebDirArchivosFacElec.Size = New System.Drawing.Size(383, 20)
        Me.ebDirArchivosFacElec.TabIndex = 28
        Me.ebDirArchivosFacElec.Tag = "Calle"
        Me.ebDirArchivosFacElec.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDirArchivosFacElec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btDirArchivos
        '
        Me.btDirArchivos.Location = New System.Drawing.Point(587, 78)
        Me.btDirArchivos.Name = "btDirArchivos"
        Me.btDirArchivos.Size = New System.Drawing.Size(24, 20)
        Me.btDirArchivos.TabIndex = 30
        Me.btDirArchivos.Text = "..."
        Me.btDirArchivos.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebClave
        '
        Me.ebClave.Enabled = False
        Me.ebClave.Location = New System.Drawing.Point(209, 57)
        Me.ebClave.MaxLength = 20
        Me.ebClave.Name = "ebClave"
        Me.ebClave.Size = New System.Drawing.Size(84, 20)
        Me.ebClave.TabIndex = 18
        Me.ebClave.Tag = "Region"
        Me.ebClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btCliente
        '
        Me.btCliente.Location = New System.Drawing.Point(290, 57)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(24, 20)
        Me.btCliente.TabIndex = 20
        Me.btCliente.Text = "..."
        Me.btCliente.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebClienteClave
        '
        Me.ebClienteClave.Location = New System.Drawing.Point(209, 57)
        Me.ebClienteClave.MaxLength = 20
        Me.ebClienteClave.Name = "ebClienteClave"
        Me.ebClienteClave.Size = New System.Drawing.Size(84, 20)
        Me.ebClienteClave.TabIndex = 19
        Me.ebClienteClave.Tag = "Region"
        Me.ebClienteClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteClave.Visible = False
        Me.ebClienteClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbClienteClave
        '
        Me.lbClienteClave.BackColor = System.Drawing.Color.Transparent
        Me.lbClienteClave.Location = New System.Drawing.Point(13, 57)
        Me.lbClienteClave.Name = "lbClienteClave"
        Me.lbClienteClave.Size = New System.Drawing.Size(131, 20)
        Me.lbClienteClave.TabIndex = 23
        Me.lbClienteClave.Text = "Cliente Generico"
        Me.lbClienteClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebClienteRFC
        '
        Me.ebClienteRFC.Enabled = False
        Me.ebClienteRFC.Location = New System.Drawing.Point(314, 57)
        Me.ebClienteRFC.MaxLength = 20
        Me.ebClienteRFC.Name = "ebClienteRFC"
        Me.ebClienteRFC.Size = New System.Drawing.Size(303, 20)
        Me.ebClienteRFC.TabIndex = 22
        Me.ebClienteRFC.Tag = "Region"
        Me.ebClienteRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbFoliosTerminal
        '
        Me.chbFoliosTerminal.BackColor = System.Drawing.Color.Transparent
        Me.chbFoliosTerminal.Location = New System.Drawing.Point(13, 32)
        Me.chbFoliosTerminal.Name = "chbFoliosTerminal"
        Me.chbFoliosTerminal.Size = New System.Drawing.Size(152, 20)
        Me.chbFoliosTerminal.TabIndex = 17
        Me.chbFoliosTerminal.Text = "Folios Fiscales a Terminal"
        Me.chbFoliosTerminal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbComprobanteDig
        '
        Me.chbComprobanteDig.BackColor = System.Drawing.Color.Transparent
        Me.chbComprobanteDig.Location = New System.Drawing.Point(13, 5)
        Me.chbComprobanteDig.Name = "chbComprobanteDig"
        Me.chbComprobanteDig.Size = New System.Drawing.Size(183, 20)
        Me.chbComprobanteDig.TabIndex = 16
        Me.chbComprobanteDig.Text = "Comprobante Digital"
        Me.chbComprobanteDig.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblVersionCFD
        '
        Me.lblVersionCFD.AutoSize = True
        Me.lblVersionCFD.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionCFD.Location = New System.Drawing.Point(205, 8)
        Me.lblVersionCFD.Name = "lblVersionCFD"
        Me.lblVersionCFD.Size = New System.Drawing.Size(140, 13)
        Me.lblVersionCFD.TabIndex = 11
        Me.lblVersionCFD.Text = "Version Comprobante Digital"
        '
        'lblFormatoFactura
        '
        Me.lblFormatoFactura.AutoSize = True
        Me.lblFormatoFactura.BackColor = System.Drawing.Color.Transparent
        Me.lblFormatoFactura.Location = New System.Drawing.Point(205, 35)
        Me.lblFormatoFactura.Name = "lblFormatoFactura"
        Me.lblFormatoFactura.Size = New System.Drawing.Size(143, 13)
        Me.lblFormatoFactura.TabIndex = 11
        Me.lblFormatoFactura.Text = "Formato Comprobante Digital"
        '
        'cbVersionCFD
        '
        Me.cbVersionCFD.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbVersionCFD.Location = New System.Drawing.Point(362, 5)
        Me.cbVersionCFD.Name = "cbVersionCFD"
        Me.cbVersionCFD.Size = New System.Drawing.Size(136, 20)
        Me.cbVersionCFD.TabIndex = 0
        Me.cbVersionCFD.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbFormatoFactura
        '
        Me.cbFormatoFactura.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFormatoFactura.Location = New System.Drawing.Point(362, 31)
        Me.cbFormatoFactura.Name = "cbFormatoFactura"
        Me.cbFormatoFactura.Size = New System.Drawing.Size(136, 20)
        Me.cbFormatoFactura.TabIndex = 0
        Me.cbFormatoFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btHistorico
        '
        Me.btHistorico.Icon = CType(resources.GetObject("btHistorico.Icon"), System.Drawing.Icon)
        Me.btHistorico.Location = New System.Drawing.Point(528, 4)
        Me.btHistorico.Name = "btHistorico"
        Me.btHistorico.Size = New System.Drawing.Size(100, 24)
        Me.btHistorico.TabIndex = 3
        Me.btHistorico.Text = "Historial"
        Me.btHistorico.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel1
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Facturación Electrónica"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MGeneral
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(659, 401)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.LbEstado)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MGeneral"
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabGenerales.ResumeLayout(False)
        Me.TabGenerales.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.GroupBoxCFDi.ResumeLayout(False)
        Me.GroupBoxCFDi.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private vcModo As eModo
    Private vcUsuarioId As String
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcMensaje As New BASMENLOG.CMensaje
    Private vcSubEmpresa As ERMSEMLOG.cSubEmpresa
    Private vcCambioLogo As Boolean = False
    Private vcCerrar As Boolean = False
    Private vcHuboCambios As Boolean = False
    Private vcActualizarPEM As Boolean



#Region "Funciones Generales"
    Private Sub LlenarValoresIniciales()
        'obtener mensajes
        lblProveedorTimbre.Text = vcMensaje.RecuperarDescripcion("SEMProveedorTimbre")
        ToolTip1.SetToolTip(cbProveedorTimbre, vcMensaje.RecuperarDescripcion("SEMProveedorTimbreT"))

        lblVersionCFD.Text = vcMensaje.RecuperarDescripcion("SEMVersionCFD")
        ToolTip1.SetToolTip(cbVersionCFD, vcMensaje.RecuperarDescripcion("SEMVersionCFDT"))

        lbServidorTimbre.Text = vcMensaje.RecuperarDescripcion("SEMServidorTimbre")
        ToolTip1.SetToolTip(ebServidorTimbre, vcMensaje.RecuperarDescripcion("SEMServidorTimbreT"))

        lbServidorCancelacion.Text = vcMensaje.RecuperarDescripcion("SEMServidorCancelacion")
        ToolTip1.SetToolTip(ebServidorCancelacion, vcMensaje.RecuperarDescripcion("SEMServidorCancelacionT"))

        lbCustomerKey.Text = vcMensaje.RecuperarDescripcion("SEMCustomerKey")
        ToolTip1.SetToolTip(ebCustomerKey, vcMensaje.RecuperarDescripcion("SEMCustomerKeyT"))


        lblFormatoFactura.Text = vcMensaje.RecuperarDescripcion("SEMFormatoFacturas")
        ToolTip1.SetToolTip(cbFormatoFactura, vcMensaje.RecuperarDescripcion("SEMFormatoFacturasT"))

        LbEstado.Text = vcMensaje.RecuperarDescripcion("SEMTipoEstado")
        ToolTip1.SetToolTip(cbEstado, vcMensaje.RecuperarDescripcion("SEMTipoEstadoT"))

        lblCalle.Text = vcMensaje.RecuperarDescripcion("SEMCalle")
        ToolTip1.SetToolTip(txtCalle, vcMensaje.RecuperarDescripcion("SEMCalleT"))

        lblNombreEmpresa.Text = vcMensaje.RecuperarDescripcion("SEMNombreEmpresa")
        ToolTip1.SetToolTip(txtNombreEmpresa, vcMensaje.RecuperarDescripcion("SEMNombreEmpresaT"))

        lblRFC.Text = vcMensaje.RecuperarDescripcion("SEMRFC")
        ToolTip1.SetToolTip(txtRFC, vcMensaje.RecuperarDescripcion("SEMRFCT"))

        lblPais.Text = vcMensaje.RecuperarDescripcion("SEMPais")
        ToolTip1.SetToolTip(txtPais, vcMensaje.RecuperarDescripcion("SEMPaisT"))

        lblRegion.Text = vcMensaje.RecuperarDescripcion("SEMRegion")
        ToolTip1.SetToolTip(txtRegion, vcMensaje.RecuperarDescripcion("SEMRegionT"))

        lblLocalidad.Text = vcMensaje.RecuperarDescripcion("SEMLocalidad")
        ToolTip1.SetToolTip(txtLocalidad, vcMensaje.RecuperarDescripcion("SEMLocalidadT"))

        lblReferencia.Text = vcMensaje.RecuperarDescripcion("SEMReferenciaDom")
        ToolTip1.SetToolTip(txtReferencia, vcMensaje.RecuperarDescripcion("SEMReferenciaDomT"))

        lblMunicipio.Text = vcMensaje.RecuperarDescripcion("SEMCiudad")
        ToolTip1.SetToolTip(txtMunicipio, vcMensaje.RecuperarDescripcion("SEMCiudadT"))

        lblColonia.Text = vcMensaje.RecuperarDescripcion("SEMColonia")
        ToolTip1.SetToolTip(txtColonia, vcMensaje.RecuperarDescripcion("SEMColoniaT"))

        lblNumero.Text = vcMensaje.RecuperarDescripcion("SEMNumero")
        ToolTip1.SetToolTip(txtNumero, vcMensaje.RecuperarDescripcion("SEMNumeroT"))

        lblNumeroInt.Text = vcMensaje.RecuperarDescripcion("SEMNumeroInterior")
        ToolTip1.SetToolTip(txtInterior, vcMensaje.RecuperarDescripcion("SEMNumeroInteriorT"))

        lblCodigoPostal.Text = vcMensaje.RecuperarDescripcion("SEMCodigoPostal")
        ToolTip1.SetToolTip(txtCodigoPostal, vcMensaje.RecuperarDescripcion("SEMCodigoPostalT"))

        lblLogo.Text = vcMensaje.RecuperarDescripcion("SEMLogotipo")
        ToolTip1.SetToolTip(PbLogo, vcMensaje.RecuperarDescripcion("SEMLogotipoT"))


        lblTelefono.Text = vcMensaje.RecuperarDescripcion("SEMTelefono")
        ToolTip1.SetToolTip(txtTelefono, vcMensaje.RecuperarDescripcion("SEMTelefonoT"))

        GroupBox1.Text = vcMensaje.RecuperarDescripcion("SEMDomicilio")

        TabItem1.Text = vcMensaje.RecuperarDescripcion("SEMDatosG")


        btAceptar.Text = vcMensaje.RecuperarDescripcion("BtAceptar")
        btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")


        chbComprobanteDig.Text = vcMensaje.RecuperarDescripcion("COHComprobanteDig")
        ToolTip1.SetToolTip(chbComprobanteDig, vcMensaje.RecuperarDescripcion("COHComprobanteDigT"))
        chbFoliosTerminal.Text = vcMensaje.RecuperarDescripcion("COHFoliosTerminal")
        ToolTip1.SetToolTip(chbFoliosTerminal, vcMensaje.RecuperarDescripcion("COHFoliosTerminalT"))
        'chbMultiplesPedidos.Text = vcMensaje.RecuperarDescripcion("COHMultiplesPedidos")
        'ToolTip1.SetToolTip(chbMultiplesPedidos, vcMensaje.RecuperarDescripcion("COHMultiplesPedidos"))
        lbClienteClave.Text = vcMensaje.RecuperarDescripcion("COHClienteGenerico")
        ToolTip1.SetToolTip(ebClienteClave, vcMensaje.RecuperarDescripcion("COHClienteGenericoT"))
        lbDirRepMensual.Text = vcMensaje.RecuperarDescripcion("COHDirRepMensual")
        ToolTip1.SetToolTip(ebDirRepMensual, vcMensaje.RecuperarDescripcion("COHDirRepMensualT"))
        lbDirectorioXML.Text = vcMensaje.RecuperarDescripcion("COHDirDocXML")
        ToolTip1.SetToolTip(ebDirectorioXML, vcMensaje.RecuperarDescripcion("COHDirDocXMLT"))
        lbDirArchivosFacElec.Text = vcMensaje.RecuperarDescripcion("COHDirArchivosFacElec")
        ToolTip1.SetToolTip(Me.ebDirArchivosFacElec.TextBox, vcMensaje.RecuperarDescripcion("COHDirArchivosFacElecT"))
        lbContrasenaClave.Text = vcMensaje.RecuperarDescripcion("COHContrasenaClave")
        ToolTip1.SetToolTip(Me.ebcontrasenaClave.TextBox, vcMensaje.RecuperarDescripcion("COHContrasenaClaveT"))
        lbConfirmacion.Text = vcMensaje.RecuperarDescripcion("XConfirmar") & " " & vcMensaje.RecuperarDescripcion("COHContrasenaClave")
        ToolTip1.SetToolTip(Me.ebConfirmacion.TextBox, vcMensaje.RecuperarDescripcion("XConfirmar") & " " & vcMensaje.RecuperarDescripcion("COHContrasenaClave"))




        ToolTip1.SetToolTip(btAceptar, vcMensaje.RecuperarDescripcion("BtAceptarT"))
        If vcModo = eModo.Leer Then
            ToolTip1.SetToolTip(btCancelar, vcMensaje.RecuperarDescripcion("btregresar"))
        Else
            ToolTip1.SetToolTip(btCancelar, vcMensaje.RecuperarDescripcion("BtCancelarT"))
        End If


        lbGeneral.LlenarComboBox(cbEstado, "EDOREG")

        lbGeneral.LlenarComboBox(cbVersionCFD, "VERFACTE")

        lbGeneral.LlenarComboBox(cbProveedorTimbre, "PROTIMB")


    End Sub

    Private Sub LlenarCampos()

        If vcModo = eModo.Crear Then
            Dim vlGeneral As New lbGeneral.cKeyGen


            vcSubEmpresa.SubEmpresaID = lbGeneral.cKeyGen.KEYGEN(1)
            cbEstado.SelectedValue = 1
            vcSubEmpresa.TipoEstado = cbEstado.SelectedValue
        Else

            vcSubEmpresa.SubEmpresaID = vcSubEmpresa.SubEmpresaID
            With vcSubEmpresa
                cbEstado.SelectedValue = .TipoEstado
                cbEstado.SelectedValue = .TipoEstado
                txtCalle.Text = .Calle
                txtMunicipio.Text = .Ciudad
                txtCodigoPostal.Text = .CodigoPostal
                txtColonia.Text = .Colonia
                txtLocalidad.Text = .Localidad
                txtNombreEmpresa.Text = .NombreEmpresa
                txtNumero.Text = .Numero
                txtInterior.Text = .NumeroInterior
                txtPais.Text = .Pais
                txtReferencia.Text = .ReferenciaDom
                txtRegion.Text = .Region
                txtRFC.Text = .RFC
                txtTelefono.Text = .Telefono
                Try
                    Dim ms As New MemoryStream(.Logotipo)
                    PbLogo.Image = System.Drawing.Image.FromStream(ms)
                    ms.Close()
                Catch ex As Exception
                End Try

                Dim vcClienteRFC As New ERMCLILOG.cCliente
                If .ClienteClave <> Nothing And Not IsDBNull(.ClienteClave) And .ClienteClave <> "" Then
                    vcClienteRFC.Recuperar(.ClienteClave)
                    Me.ebClave.Text = vcClienteRFC.Clave
                    Me.ebClienteRFC.Text = vcClienteRFC.IdFiscal
                    ebClienteClave.Text = .ClienteClave
                Else
                    Me.ebClienteRFC.Text = ""
                End If

                ebcontrasenaClave.Text = .ContrasenaClave
                ebConfirmacion.Text = .ContrasenaClave

                If (.VersionCFD > 0) Then
                    cbVersionCFD.SelectedValue = .VersionCFD
                End If


                If (.ProveedorTimbre > 0) Then
                    cbProveedorTimbre.SelectedValue = .ProveedorTimbre
                End If

                ebCustomerKey.Text = .CustomerKey
                ebServidorTimbre.Text = .ServidorTimbre
                ebServidorCancelacion.Text = .ServidorCancelacion
                If (.FormatoFactura > 0) Then
                    cbFormatoFactura.SelectedValue = .FormatoFactura
                End If

                ebDirArchivosFacElec.Text = .DirArchivosFacElec
                ebDirectorioXML.Text = .DirDocXML
                ebDirRepMensual.Text = .DirRepMensual
                chbComprobanteDig.Checked = .ComprobanteDig
                chbFoliosTerminal.Checked = .FoliosTerminal
                'Me.chbMultiplesPedidos.Checked = .VariosPedidos

            End With



            'ebCodigoBarras.Text = vcSubEmpresa.CodigoBarras
        End If

        chbComprobanteDig_CheckedChanged(Nothing, Nothing)
        vcHuboCambios = False
    End Sub


    Private Sub Grabar()


        Try
            vcSubEmpresa.Grabar(vcCambioLogo)






        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Function CREAR(ByRef prSubEmpresa As ERMSEMLOG.cSubEmpresa, ByVal pvUsuarioID As String) As Boolean
        vcModo = eModo.Crear
        vcSubEmpresa = prSubEmpresa
        vcUsuarioId = pvUsuarioID

        chbComprobanteDig.Checked = False
        chbComprobanteDig_CheckedChanged(Nothing, Nothing)

        Call LlenarValoresIniciales()
        Call LlenarCampos()

        Me.Text = vcMensaje.RecuperarDescripcion("ERMSEMESC_MGeneralC")
        vcSubEmpresa.vcGuardarHist = True
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Call Grabar()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                vcConexion.DeshacerTran()
                Exit Function
            End Try
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function

    Function MODIFICAR(ByRef prSubEmpresa As ERMSEMLOG.cSubEmpresa, ByVal pvUsuarioID As String) As Boolean
        vcModo = eModo.Modificar
        vcSubEmpresa = prSubEmpresa
        vcUsuarioId = pvUsuarioID

        Call LlenarValoresIniciales()
        Call LlenarCampos()


        Me.Text = vcMensaje.RecuperarDescripcion("ERMSEMESC_MGeneralM")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Call Grabar()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                vcConexion.DeshacerTran()
                Exit Function
            End Try
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function
    Function Consultar(ByRef prSubEmpresa As ERMSEMLOG.cSubEmpresa, ByVal pvUsuarioID As String) As Boolean
        vcModo = eModo.Leer
        vcSubEmpresa = prSubEmpresa
        vcUsuarioId = pvUsuarioID

        Call LlenarValoresIniciales()
        Call LlenarCampos()



        Me.Text = vcMensaje.RecuperarDescripcion("XConsultar") + " " + vcMensaje.RecuperarDescripcion("ERMSEMESC_NGeneral")

        btAceptar.Visible = False
        btCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        btCancelar.Icon = btAceptar.Icon

        For Each ctrls As Control In Me.Controls
            ctrls.Enabled = False
        Next


        btCancelar.Enabled = True

        Me.ShowDialog()


    End Function

    Private Sub ValidarCampos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.Validated
        Call ValidarCampos(sender)
    End Sub



    Private Sub ValidarCampos(ByVal pvSender As System.Object)
        Dim vlCampo As String = Nothing
        Try
            Select Case CType(pvSender.name, String)

                Case "cbEstado"
                    If vcModo = eModo.Modificar Then
                        'If vcSubEmpresa.TipoEstado = 1 And cbEstado.SelectedValue = 0 Then
                        '    'Validar que no existan Productos activos asignados a la SubEmpresa

                        '    If vcSubEmpresa.EstaAsignadaProducto(vcSubEmpresa.SubEmpresaID) Then
                        '        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("E0763"))
                        '        Exit Sub
                        '    End If
                        'End If
                    End If
                    vcSubEmpresa.TipoEstado = cbEstado.SelectedValue
                    vlCampo = "TipoEstado"


            End Select

            vcSubEmpresa.ValidarCampos(New String() {vlCampo})
        Catch ex As LbControlError.cError
            epErrores.SetError(pvSender, ex.Mensaje)
            Exit Sub
        End Try
        epErrores.SetError(pvSender, "")
    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                If (peGridEx.Row = 0) Then
                    peGridEx.MoveLast()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Eventos Varios"



    Private Sub Controles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedValueChanged, txtCalle.TextChanged, txtCodigoPostal.TextChanged, txtColonia.TextChanged, txtInterior.TextChanged, txtLocalidad.TextChanged, txtMunicipio.TextChanged, txtNombreEmpresa.TextChanged, txtNumero.TextChanged, txtPais.TextChanged, txtReferencia.TextChanged, txtRegion.TextChanged, txtRFC.TextChanged, txtTelefono.TextChanged
        vcHuboCambios = True
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbLogo.DoubleClick
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Filter = _
    "Images (*.BMP;*.JPG)|*.BMP;*.JPG"



        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PbLogo.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1.FileName)
            Dim ms As New MemoryStream

            If Path.GetExtension(Me.OpenFileDialog1.FileName) = "png" Then
                PbLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
            Else
                PbLogo.Image.Save(ms, PbLogo.Image.RawFormat)
            End If

            vcSubEmpresa.Logotipo = ms.GetBuffer
            ms.Close()
            vcCambioLogo = True
            vcHuboCambios = True
        End If
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not vcCerrar And vcHuboCambios And vcModo <> eModo.Leer Then
            'Dim vlRespuesta As MsgBoxResult

            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = False
            End If
        End If
    End Sub

#End Region


#Region "Aceptar y Cancelar"

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None


        If vcModo = eModo.Crear AndAlso vcSubEmpresa.ExisteNombre(txtNombreEmpresa.Text) Then
            MsgBox(vcMensaje.RecuperarDescripcion("BE0002"))
            txtNombreEmpresa.Focus()
            Exit Sub
        End If

        If vcModo = eModo.Modificar AndAlso vcSubEmpresa.NombreEmpresa <> txtNombreEmpresa.Text AndAlso vcSubEmpresa.ExisteNombre(txtNombreEmpresa.Text) Then
            MsgBox(vcMensaje.RecuperarDescripcion("BE0002"))
            txtNombreEmpresa.Focus()
            Exit Sub
        End If


        If vcModo = eModo.Modificar AndAlso vcSubEmpresa.TipoEstado = 1 And cbEstado.SelectedValue = 0 Then
            'Validar que no existan Productos activos asignados a la SubEmpresa

            'If vcSubEmpresa.EstaAsignadaProducto(vcSubEmpresa.SubEmpresaID) Then
            '    MsgBox(vcMensaje.RecuperarDescripcion("E0763"))
            '    cbEstado.Focus()
            '    Exit Sub
            'End If

        End If

        If ebcontrasenaClave.Text <> ebConfirmacion.Text Then
            MsgBox(vcMensaje.RecuperarDescripcion("E0701").Replace("$0$", lbContrasenaClave.Text))
            ebcontrasenaClave.Focus()
            Exit Sub

        End If



        Try



            If vcModo = eModo.Modificar Then

            End If
            With vcSubEmpresa
                .TipoEstado = cbEstado.SelectedValue
                .Calle = txtCalle.Text
                .Ciudad = txtMunicipio.Text
                .CodigoPostal = txtCodigoPostal.Text
                .Colonia = txtColonia.Text
                .Localidad = txtLocalidad.Text
                .NombreEmpresa = txtNombreEmpresa.Text
                .Numero = txtNumero.Text
                .NumeroInterior = txtInterior.Text
                .Pais = txtPais.Text
                .ReferenciaDom = txtReferencia.Text
                .Region = txtRegion.Text
                .RFC = txtRFC.Text
                .Telefono = txtTelefono.Text

                .ComprobanteDig = chbComprobanteDig.Checked

                If chbComprobanteDig.Checked Then


                    If (cbVersionCFD.SelectedValue = 0) Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + "VersionCFD", True)}, "VersionCFD")
                    End If


                    If cbFormatoFactura.SelectedValue Is Nothing Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + "FormatoFacturas", True)}, "FormatoFactura")
                    End If

                    If (ebcontrasenaClave.Text.Length < 8 OrElse ebcontrasenaClave.Text.Length > 255) Then
                        Throw New LbControlError.cError("E0676", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("8"), New LbControlError.cParametroMSG("255")})
                    End If

                    .FormatoFactura = cbFormatoFactura.SelectedValue
                    .ClienteClave = ebClienteClave.Text

                    .ContrasenaClave = ebcontrasenaClave.Text
                    .DirArchivosFacElec = ebDirArchivosFacElec.Text
                    .DirDocXML = ebDirectorioXML.Text
                    .DirRepMensual = ebDirRepMensual.Text
                    .FoliosTerminal = chbFoliosTerminal.Checked
                    '.VariosPedidos = Me.chbMultiplesPedidos.Checked

                    .VersionCFD = cbVersionCFD.SelectedValue
                    If (cbVersionCFD.SelectedValue = 2 Or cbVersionCFD.SelectedValue = 4) Then


                        .CustomerKey = ebCustomerKey.Text

                        .ServidorTimbre = ebServidorTimbre.Text
                        .ServidorCancelacion = ebServidorCancelacion.Text
                        If cbProveedorTimbre.SelectedValue Is Nothing Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + "ProveedorTimbre", True)}, "ProveedorTimbre")
                        End If
                        .ProveedorTimbre = cbProveedorTimbre.SelectedValue

                    End If

                    If vcActualizarPEM Then
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()
                        .GenerarArchivoPEM()

                        .GenerarCERBase64()

                        If (cbVersionCFD.SelectedValue = 2 Or cbVersionCFD.SelectedValue = 4) Then
                            .GenerarPFXBase64()
                        End If
                        Me.Cursor = Cursors.Default
                        Application.DoEvents()

                    End If

                End If

                .MUsuarioId = vcUsuarioId
            End With

            If chbComprobanteDig.Checked Then
                If (cbVersionCFD.SelectedValue = 1 Or cbVersionCFD.SelectedValue = 3) Then
                    vcSubEmpresa.ValidarCampos(New String() {"ClienteClave", "ContrasenaClave", "DirArchivosFacElec", "DirDocXML", "DirRepMensual"})
                Else
                    vcSubEmpresa.ValidarCampos(New String() {"ClienteClave", "ContrasenaClave", "DirArchivosFacElec", "DirDocXML", "VersionCFD", "ProveedorTimbre", "ServidorTimbre", "CustomerKey", "FormatoFactura"})

                End If
                vcSubEmpresa.ValidarCampos(New String() {"VersionCFD"})

            End If
         
            If ebServidorTimbre.Text <> "" Then
                Dim U As Uri
                If Not Uri.TryCreate(ebServidorTimbre.Text, UriKind.Absolute, U) Or Not ebServidorTimbre.Text.ToUpper.StartsWith("HTTP") Then
                    Throw New LbControlError.cError("ME0819", , "ServidorTimbre")
                End If
            End If

            If ebServidorCancelacion.Text <> "" Then
                Dim U As Uri
                If Not Uri.TryCreate(ebServidorCancelacion.Text, UriKind.Absolute, U) Or Not ebServidorCancelacion.Text.ToUpper.StartsWith("HTTP") Then
                    Throw New LbControlError.cError("ME0819", , "ServidorCancelacion")
                End If
            End If



            If vcModo = eModo.Crear Then
                'vcSubEmpresa.Insertar(New String() {"SubEmpresaId", "Clave", "Tipo", "TipoEstado", "Nombre", "Domicilio", "Telefono", "CodigoBarras", "MUsuarioId"})
                vcSubEmpresa.Insertar(New String() {"NombreEmpresa"})
            Else
                vcSubEmpresa.ValidarCampos(New String() {"NombreEmpresa"})
            End If

        Catch ex As LbControlError.cError
            Me.Cursor = Cursors.Default
            ex.Mostrar()
            Select Case (ex.Source)

                Case "NombreEmpresa"
                    txtNombreEmpresa.Focus()
                Case "ClienteClave"
                    ebClave.Focus()
                Case "ContrasenaClave"
                    ebcontrasenaClave.Focus()
                Case "DirArchivosFacElec"
                    btDirArchivos.Focus()
                Case "DirDocXML"
                    btDirXML.Focus()
                Case "DirRepMensual"
                    btDirRepMensual.Focus()
                Case "ServidorTimbre"
                    ebServidorTimbre.Focus()
                Case "VersionCFD"
                    cbVersionCFD.Focus()
                Case "ProveedorTimbre"
                    cbProveedorTimbre.Focus()
                Case "CustomerKey"
                    ebCustomerKey.Focus()
                Case "FormatoFactura"
                    cbFormatoFactura.Focus()

            End Select
            Exit Sub
        End Try


        Me.DialogResult = Windows.Forms.DialogResult.OK
        vcCerrar = True
        Me.Close()
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub


#End Region


    
    Private Sub chbComprobanteDig_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbComprobanteDig.CheckedChanged
        If chbComprobanteDig.Checked Then
            chbFoliosTerminal.Enabled = True
            ebClienteClave.Enabled = True
            ebClave.Enabled = True
            btCliente.Enabled = True

            btDirXML.Enabled = True
            btDirArchivos.Enabled = True
            ebcontrasenaClave.Enabled = True
            If ebcontrasenaClave.Text <> "" Then
                ebConfirmacion.Enabled = True
            End If


            cbFormatoFactura.Enabled = True
            cbVersionCFD.Enabled = True

            If (cbVersionCFD.SelectedValue = 1 Or cbVersionCFD.SelectedValue = 3) Then
                btDirRepMensual.Enabled = True
            ElseIf cbVersionCFD.SelectedValue = 2 Or cbVersionCFD.SelectedValue = 4 Then
                GroupBoxCFDi.Enabled = True
            End If

        Else
            chbFoliosTerminal.Enabled = False
            ebClienteClave.Enabled = False
            btCliente.Enabled = False
            btDirRepMensual.Enabled = False
            btDirXML.Enabled = False
            ebClave.Enabled = False
            'ebClienteClave.Text = ""
            'Me.ebClave.Text = ""
            'ebClienteRFC.Text = ""
            btDirArchivos.Enabled = False
            ebcontrasenaClave.Enabled = False
            ebConfirmacion.Enabled = False

            cbFormatoFactura.Enabled = False
            cbVersionCFD.Enabled = False
            btDirRepMensual.Enabled = False
            GroupBoxCFDi.Enabled = False


            epErrores.SetError(ebClienteRFC, "")
            epErrores.SetError(ebcontrasenaClave, "")
        End If
        vcHuboCambios = True
    End Sub

    Private Sub btCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliente.Click
        Dim vcFrmBrowseCliente As New ERMCLIESC.IGeneral
        vcFrmBrowseCliente.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        Try
            Dim vcCliente As ERMCLILOG.cCliente = CType(vcFrmBrowseCliente.Seleccionar("", False)(0), ERMCLILOG.cCliente)
            ebClienteClave.Text = vcCliente.ClienteClave
            ebClave.Text = vcCliente.Clave
            ebClienteRFC.Text = vcCliente.IdFiscal
            ValidarCampos(ebClienteClave, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHistorico.Click
        Dim vlHistorico As New HSubEmpresa(vcSubEmpresa, vcConexion)
        vlHistorico.ShowDialog()
    End Sub

    Private Sub btDirRepMensual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDirRepMensual.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If (FolderBrowserDialog1.SelectedPath.Length > 199) Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0632"), MsgBoxStyle.Critical)
                Exit Sub
            End If
            Me.ebDirRepMensual.Text = FolderBrowserDialog1.SelectedPath
        End If
        vcHuboCambios = True
    End Sub

    Private Sub btDirXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDirXML.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If (FolderBrowserDialog1.SelectedPath.Length > 199) Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0632"), MsgBoxStyle.Critical)
                Exit Sub
            End If
            Me.ebDirectorioXML.Text = FolderBrowserDialog1.SelectedPath
        End If
        vcHuboCambios = True
    End Sub

    Private Sub btDirArchivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDirArchivos.Click
        Me.FolderBrowserDialog1.SelectedPath = Me.ebDirArchivosFacElec.Text
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If (FolderBrowserDialog1.SelectedPath.Length > 199) Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0632"), MsgBoxStyle.Critical)
                Exit Sub
            End If
            Me.ebDirArchivosFacElec.Text = FolderBrowserDialog1.SelectedPath
        End If
        vcHuboCambios = True
        vcActualizarPEM = True
    End Sub

    Private Sub ebClave_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClave.Validated

        If chbComprobanteDig.Checked Then
            If ebClave.Text = "" Then
                epErrores.SetError(ebClienteRFC, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("COHClienteGenerico")}))
                Exit Sub
            End If

            Dim vcCliente As New ERMCLILOG.cCliente
            If Not vcCliente.ExisteClave(ebClave.Text) Then
                ebClienteRFC.Text = ""
                epErrores.SetError(ebClienteRFC, vcMensaje.RecuperarDescripcion("E0027"))
                Exit Sub
            Else
                epErrores.SetError(ebClienteRFC, "")
                vcCliente.Recuperar(vcCliente.ObtenerClienteClave(ebClave.Text))
                ebClienteClave.Text = vcCliente.ClienteClave
                ebClienteRFC.Text = vcCliente.IdFiscal
            End If
        Else
            epErrores.SetError(ebClienteRFC, "")
        End If
    End Sub

    Private Sub ebcontrasenaClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebcontrasenaClave.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack AndAlso e.KeyChar <> vbCrLf AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MsgBox(vcMensaje.RecuperarDescripcion("E0677").Replace("$0$", lbContrasenaClave.Text), MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ebcontrasenaClave_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebcontrasenaClave.TextChanged
        If chbComprobanteDig.Checked Then
            If ebcontrasenaClave.Text = "" Then
                ebConfirmacion.Enabled = False
            Else
                ebConfirmacion.Enabled = True
            End If
        End If
    End Sub

    Private Sub ebcontrasenaClave_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebcontrasenaClave.Validated
        If chbComprobanteDig.Checked Then
            If ebcontrasenaClave.Text = "" Then
                epErrores.SetError(ebcontrasenaClave, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("COHcontrasenaClave")}))
                Exit Sub
            End If
        End If
        epErrores.SetError(ebcontrasenaClave, "")
    End Sub




    Private Sub cbVersionCFD_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVersionCFD.SelectedValueChanged
        If (cbVersionCFD.SelectedValue = 1 Or cbVersionCFD.SelectedValue = 3) Then
            btDirRepMensual.Enabled = True
            GroupBoxCFDi.Enabled = False
        ElseIf cbVersionCFD.SelectedValue = 2 Or cbVersionCFD.SelectedValue = 4 Then
            GroupBoxCFDi.Enabled = True
            btDirRepMensual.Enabled = False
        End If
        cbFormatoFactura.SelectedValue = Nothing
        Dim oVAR As New BASVARLOG.cValorReferencia
        oVAR.Recuperar("VERFACTE")
        Dim oVAV As BASVARLOG.cVARValor = oVAR.VARValor(cbVersionCFD.SelectedValue.ToString)
        lbGeneral.LlenarComboBoxConGrupo(cbFormatoFactura, "FRMFAC", oVAV.Grupo)

    End Sub

End Class
