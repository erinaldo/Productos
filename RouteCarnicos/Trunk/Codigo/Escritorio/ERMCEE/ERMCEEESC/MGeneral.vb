Imports BASMENLOG
Imports ERMCEELOG

Public Class MGeneral
    Inherits FormasBase.Mantenimiento01

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
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents lbOrden As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbEstado As System.Windows.Forms.Label
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbEsquemaPadre As System.Windows.Forms.Label
    Friend WithEvents ebOrden As System.Windows.Forms.NumericUpDown
    Friend WithEvents epErrores1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCalle As System.Windows.Forms.Label
    Friend WithEvents ebCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbExterior As System.Windows.Forms.Label
    Friend WithEvents lbInterior As System.Windows.Forms.Label
    Friend WithEvents ebExterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebInterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents ebCodigoPostal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbReferencia As System.Windows.Forms.Label
    Friend WithEvents lbLocalidad As System.Windows.Forms.Label
    Friend WithEvents ebLocalidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbMunicipio As System.Windows.Forms.Label
    Friend WithEvents ebMunicipio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebEntidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbEntidad As System.Windows.Forms.Label
    Friend WithEvents lbPais As System.Windows.Forms.Label
    Friend WithEvents ebPais As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbMatriz As System.Windows.Forms.Label
    Friend WithEvents cbTipo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebcolonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbColonia As System.Windows.Forms.Label
    Friend WithEvents cbSubEmpresa As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbSubEmpresa As System.Windows.Forms.Label
    Friend WithEvents gbRegimen As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grdRegimenFiscal As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbRFC As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim grdRegimenFiscal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MGeneral))
        Me.lbNombre = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cbEstado = New Janus.Windows.EditControls.UIComboBox
        Me.lbEstado = New System.Windows.Forms.Label
        Me.ebMatrizDesc = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebMatriz = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btMatriz = New Janus.Windows.EditControls.UIButton
        Me.cbTipo = New Janus.Windows.EditControls.UIComboBox
        Me.epErrores1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btNumCertificado = New Janus.Windows.EditControls.UIButton
        Me.ebNumCertificado = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNumCertificado = New System.Windows.Forms.Label
        Me.lbRFC = New System.Windows.Forms.Label
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCalle = New System.Windows.Forms.Label
        Me.ebCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbExterior = New System.Windows.Forms.Label
        Me.lbInterior = New System.Windows.Forms.Label
        Me.ebExterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebInterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbColonia = New System.Windows.Forms.Label
        Me.ebcolonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCodigoPostal = New System.Windows.Forms.Label
        Me.ebCodigoPostal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbReferencia = New System.Windows.Forms.Label
        Me.lbLocalidad = New System.Windows.Forms.Label
        Me.ebLocalidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbMunicipio = New System.Windows.Forms.Label
        Me.ebMunicipio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebEntidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbEntidad = New System.Windows.Forms.Label
        Me.lbPais = New System.Windows.Forms.Label
        Me.ebPais = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbMatriz = New System.Windows.Forms.Label
        Me.lbSubEmpresa = New System.Windows.Forms.Label
        Me.cbSubEmpresa = New Janus.Windows.EditControls.UIComboBox
        Me.gbRegimen = New Janus.Windows.EditControls.UIGroupBox
        Me.grdRegimenFiscal = New Janus.Windows.GridEX.GridEX
        CType(Me.epErrores1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRegimen.SuspendLayout()
        CType(Me.grdRegimenFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Location = New System.Drawing.Point(144, 12)
        Me.EbClave.MaxLength = 16
        Me.EbClave.TabIndex = 0
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(8, 12)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(480, 487)
        Me.BtAceptar.Size = New System.Drawing.Size(92, 24)
        Me.BtAceptar.TabIndex = 22
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(580, 487)
        Me.BtCancelar.Size = New System.Drawing.Size(92, 24)
        Me.BtCancelar.TabIndex = 23
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(11, 474)
        Me.lbLinea.Size = New System.Drawing.Size(661, 2)
        Me.lbLinea.Visible = False
        '
        'lbNombre
        '
        Me.lbNombre.Location = New System.Drawing.Point(8, 60)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(132, 20)
        Me.lbNombre.TabIndex = 19
        Me.lbNombre.Text = "Nombre"
        Me.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTipo
        '
        Me.lbTipo.Location = New System.Drawing.Point(8, 36)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(132, 20)
        Me.lbTipo.TabIndex = 23
        Me.lbTipo.Text = "Tipo"
        Me.lbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNombre
        '
        Me.ebNombre.Location = New System.Drawing.Point(144, 60)
        Me.ebNombre.MaxLength = 60
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(528, 20)
        Me.ebNombre.TabIndex = 4
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbEstado
        '
        Me.cbEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbEstado.Location = New System.Drawing.Point(492, 12)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(180, 20)
        Me.cbEstado.TabIndex = 1
        Me.cbEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbEstado
        '
        Me.lbEstado.Location = New System.Drawing.Point(352, 12)
        Me.lbEstado.Name = "lbEstado"
        Me.lbEstado.Size = New System.Drawing.Size(132, 20)
        Me.lbEstado.TabIndex = 31
        Me.lbEstado.Text = "Estado"
        Me.lbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebMatrizDesc
        '
        Me.ebMatrizDesc.Enabled = False
        Me.ebMatrizDesc.Location = New System.Drawing.Point(328, 84)
        Me.ebMatrizDesc.Name = "ebMatrizDesc"
        Me.ebMatrizDesc.Size = New System.Drawing.Size(344, 20)
        Me.ebMatrizDesc.TabIndex = 7
        Me.ebMatrizDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMatrizDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebMatriz
        '
        Me.ebMatriz.Location = New System.Drawing.Point(144, 84)
        Me.ebMatriz.Name = "ebMatriz"
        Me.ebMatriz.Size = New System.Drawing.Size(160, 20)
        Me.ebMatriz.TabIndex = 5
        Me.ebMatriz.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMatriz.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btMatriz
        '
        Me.btMatriz.Location = New System.Drawing.Point(304, 84)
        Me.btMatriz.Name = "btMatriz"
        Me.btMatriz.Size = New System.Drawing.Size(24, 19)
        Me.btMatriz.TabIndex = 6
        Me.btMatriz.Text = "..."
        Me.btMatriz.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cbTipo
        '
        Me.cbTipo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipo.Location = New System.Drawing.Point(144, 36)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(160, 20)
        Me.cbTipo.TabIndex = 2
        Me.cbTipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'epErrores1
        '
        Me.epErrores1.ContainerControl = Me
        '
        'btNumCertificado
        '
        Me.btNumCertificado.Location = New System.Drawing.Point(304, 108)
        Me.btNumCertificado.Name = "btNumCertificado"
        Me.btNumCertificado.Size = New System.Drawing.Size(24, 19)
        Me.btNumCertificado.TabIndex = 9
        Me.btNumCertificado.Text = "..."
        Me.btNumCertificado.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebNumCertificado
        '
        Me.ebNumCertificado.Location = New System.Drawing.Point(144, 108)
        Me.ebNumCertificado.MaxLength = 20
        Me.ebNumCertificado.Name = "ebNumCertificado"
        Me.ebNumCertificado.Size = New System.Drawing.Size(160, 20)
        Me.ebNumCertificado.TabIndex = 8
        Me.ebNumCertificado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumCertificado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNumCertificado
        '
        Me.lbNumCertificado.Location = New System.Drawing.Point(8, 108)
        Me.lbNumCertificado.Name = "lbNumCertificado"
        Me.lbNumCertificado.Size = New System.Drawing.Size(132, 20)
        Me.lbNumCertificado.TabIndex = 17
        Me.lbNumCertificado.Text = "NumCertificado"
        Me.lbNumCertificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRFC
        '
        Me.lbRFC.Location = New System.Drawing.Point(352, 108)
        Me.lbRFC.Name = "lbRFC"
        Me.lbRFC.Size = New System.Drawing.Size(132, 20)
        Me.lbRFC.TabIndex = 35
        Me.lbRFC.Text = "RFC"
        Me.lbRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebRFC
        '
        Me.ebRFC.Location = New System.Drawing.Point(492, 108)
        Me.ebRFC.MaxLength = 20
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.Size = New System.Drawing.Size(180, 20)
        Me.ebRFC.TabIndex = 10
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCalle
        '
        Me.lbCalle.Location = New System.Drawing.Point(8, 132)
        Me.lbCalle.Name = "lbCalle"
        Me.lbCalle.Size = New System.Drawing.Size(132, 20)
        Me.lbCalle.TabIndex = 37
        Me.lbCalle.Text = "Calle"
        Me.lbCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCalle
        '
        Me.ebCalle.Location = New System.Drawing.Point(144, 132)
        Me.ebCalle.MaxLength = 64
        Me.ebCalle.Name = "ebCalle"
        Me.ebCalle.Size = New System.Drawing.Size(160, 20)
        Me.ebCalle.TabIndex = 11
        Me.ebCalle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbExterior
        '
        Me.lbExterior.Location = New System.Drawing.Point(352, 132)
        Me.lbExterior.Name = "lbExterior"
        Me.lbExterior.Size = New System.Drawing.Size(60, 20)
        Me.lbExterior.TabIndex = 35
        Me.lbExterior.Text = "Exterior"
        Me.lbExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbInterior
        '
        Me.lbInterior.Location = New System.Drawing.Point(512, 132)
        Me.lbInterior.Name = "lbInterior"
        Me.lbInterior.Size = New System.Drawing.Size(76, 20)
        Me.lbInterior.TabIndex = 35
        Me.lbInterior.Text = "Interior"
        Me.lbInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebExterior
        '
        Me.ebExterior.Location = New System.Drawing.Point(416, 132)
        Me.ebExterior.MaxLength = 16
        Me.ebExterior.Name = "ebExterior"
        Me.ebExterior.Size = New System.Drawing.Size(76, 20)
        Me.ebExterior.TabIndex = 12
        Me.ebExterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebExterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebInterior
        '
        Me.ebInterior.Location = New System.Drawing.Point(596, 132)
        Me.ebInterior.MaxLength = 16
        Me.ebInterior.Name = "ebInterior"
        Me.ebInterior.Size = New System.Drawing.Size(76, 20)
        Me.ebInterior.TabIndex = 13
        Me.ebInterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebInterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbColonia
        '
        Me.lbColonia.Location = New System.Drawing.Point(8, 156)
        Me.lbColonia.Name = "lbColonia"
        Me.lbColonia.Size = New System.Drawing.Size(132, 20)
        Me.lbColonia.TabIndex = 37
        Me.lbColonia.Text = "Colonia"
        Me.lbColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebcolonia
        '
        Me.ebcolonia.Location = New System.Drawing.Point(144, 156)
        Me.ebcolonia.MaxLength = 64
        Me.ebcolonia.Name = "ebcolonia"
        Me.ebcolonia.Size = New System.Drawing.Size(348, 20)
        Me.ebcolonia.TabIndex = 14
        Me.ebcolonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebcolonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCodigoPostal
        '
        Me.lbCodigoPostal.Location = New System.Drawing.Point(512, 156)
        Me.lbCodigoPostal.Name = "lbCodigoPostal"
        Me.lbCodigoPostal.Size = New System.Drawing.Size(76, 20)
        Me.lbCodigoPostal.TabIndex = 35
        Me.lbCodigoPostal.Text = "CodigoPostal"
        Me.lbCodigoPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCodigoPostal
        '
        Me.ebCodigoPostal.Location = New System.Drawing.Point(596, 156)
        Me.ebCodigoPostal.MaxLength = 16
        Me.ebCodigoPostal.Name = "ebCodigoPostal"
        Me.ebCodigoPostal.Size = New System.Drawing.Size(76, 20)
        Me.ebCodigoPostal.TabIndex = 15
        Me.ebCodigoPostal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoPostal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebReferencia
        '
        Me.ebReferencia.Location = New System.Drawing.Point(144, 180)
        Me.ebReferencia.MaxLength = 100
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.Size = New System.Drawing.Size(528, 20)
        Me.ebReferencia.TabIndex = 16
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbReferencia
        '
        Me.lbReferencia.Location = New System.Drawing.Point(8, 180)
        Me.lbReferencia.Name = "lbReferencia"
        Me.lbReferencia.Size = New System.Drawing.Size(132, 20)
        Me.lbReferencia.TabIndex = 37
        Me.lbReferencia.Text = "Referencia"
        Me.lbReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLocalidad
        '
        Me.lbLocalidad.Location = New System.Drawing.Point(8, 204)
        Me.lbLocalidad.Name = "lbLocalidad"
        Me.lbLocalidad.Size = New System.Drawing.Size(132, 20)
        Me.lbLocalidad.TabIndex = 37
        Me.lbLocalidad.Text = "Localidad"
        Me.lbLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebLocalidad
        '
        Me.ebLocalidad.Location = New System.Drawing.Point(144, 204)
        Me.ebLocalidad.MaxLength = 40
        Me.ebLocalidad.Name = "ebLocalidad"
        Me.ebLocalidad.Size = New System.Drawing.Size(160, 20)
        Me.ebLocalidad.TabIndex = 17
        Me.ebLocalidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLocalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbMunicipio
        '
        Me.lbMunicipio.Location = New System.Drawing.Point(352, 204)
        Me.lbMunicipio.Name = "lbMunicipio"
        Me.lbMunicipio.Size = New System.Drawing.Size(132, 20)
        Me.lbMunicipio.TabIndex = 37
        Me.lbMunicipio.Text = "Municipio"
        Me.lbMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebMunicipio
        '
        Me.ebMunicipio.Location = New System.Drawing.Point(488, 204)
        Me.ebMunicipio.MaxLength = 40
        Me.ebMunicipio.Name = "ebMunicipio"
        Me.ebMunicipio.Size = New System.Drawing.Size(184, 20)
        Me.ebMunicipio.TabIndex = 18
        Me.ebMunicipio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMunicipio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebEntidad
        '
        Me.ebEntidad.Location = New System.Drawing.Point(144, 228)
        Me.ebEntidad.MaxLength = 40
        Me.ebEntidad.Name = "ebEntidad"
        Me.ebEntidad.Size = New System.Drawing.Size(160, 20)
        Me.ebEntidad.TabIndex = 19
        Me.ebEntidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEntidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbEntidad
        '
        Me.lbEntidad.Location = New System.Drawing.Point(8, 228)
        Me.lbEntidad.Name = "lbEntidad"
        Me.lbEntidad.Size = New System.Drawing.Size(132, 20)
        Me.lbEntidad.TabIndex = 37
        Me.lbEntidad.Text = "Entidad"
        Me.lbEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPais
        '
        Me.lbPais.Location = New System.Drawing.Point(352, 228)
        Me.lbPais.Name = "lbPais"
        Me.lbPais.Size = New System.Drawing.Size(132, 20)
        Me.lbPais.TabIndex = 37
        Me.lbPais.Text = "Pais"
        Me.lbPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPais
        '
        Me.ebPais.Location = New System.Drawing.Point(488, 228)
        Me.ebPais.MaxLength = 40
        Me.ebPais.Name = "ebPais"
        Me.ebPais.Size = New System.Drawing.Size(184, 20)
        Me.ebPais.TabIndex = 20
        Me.ebPais.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPais.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbMatriz
        '
        Me.lbMatriz.Location = New System.Drawing.Point(8, 84)
        Me.lbMatriz.Name = "lbMatriz"
        Me.lbMatriz.Size = New System.Drawing.Size(132, 20)
        Me.lbMatriz.TabIndex = 39
        Me.lbMatriz.Text = "Matriz"
        Me.lbMatriz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbSubEmpresa
        '
        Me.lbSubEmpresa.Location = New System.Drawing.Point(352, 36)
        Me.lbSubEmpresa.Name = "lbSubEmpresa"
        Me.lbSubEmpresa.Size = New System.Drawing.Size(132, 20)
        Me.lbSubEmpresa.TabIndex = 31
        Me.lbSubEmpresa.Text = "Sub Empresa"
        Me.lbSubEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbSubEmpresa
        '
        Me.cbSubEmpresa.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbSubEmpresa.Location = New System.Drawing.Point(492, 36)
        Me.cbSubEmpresa.Name = "cbSubEmpresa"
        Me.cbSubEmpresa.Size = New System.Drawing.Size(180, 20)
        Me.cbSubEmpresa.TabIndex = 3
        Me.cbSubEmpresa.Tag = "SubEmpresa"
        Me.cbSubEmpresa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbRegimen
        '
        Me.gbRegimen.Controls.Add(Me.grdRegimenFiscal)
        Me.gbRegimen.Location = New System.Drawing.Point(11, 254)
        Me.gbRegimen.Name = "gbRegimen"
        Me.gbRegimen.Size = New System.Drawing.Size(661, 222)
        Me.gbRegimen.TabIndex = 40
        Me.gbRegimen.Text = "Regimen Fiscal"
        Me.gbRegimen.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'grdRegimenFiscal
        '
        grdRegimenFiscal_DesignTimeLayout.LayoutString = resources.GetString("grdRegimenFiscal_DesignTimeLayout.LayoutString")
        Me.grdRegimenFiscal.DesignTimeLayout = grdRegimenFiscal_DesignTimeLayout
        Me.grdRegimenFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRegimenFiscal.GroupByBoxVisible = False
        Me.grdRegimenFiscal.Location = New System.Drawing.Point(6, 19)
        Me.grdRegimenFiscal.Name = "grdRegimenFiscal"
        Me.grdRegimenFiscal.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegimenFiscal.Size = New System.Drawing.Size(649, 197)
        Me.grdRegimenFiscal.TabIndex = 21
        Me.grdRegimenFiscal.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grdRegimenFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(694, 523)
        Me.Controls.Add(Me.gbRegimen)
        Me.Controls.Add(Me.lbMatriz)
        Me.Controls.Add(Me.ebCalle)
        Me.Controls.Add(Me.lbCalle)
        Me.Controls.Add(Me.ebRFC)
        Me.Controls.Add(Me.lbRFC)
        Me.Controls.Add(Me.cbTipo)
        Me.Controls.Add(Me.btMatriz)
        Me.Controls.Add(Me.ebMatriz)
        Me.Controls.Add(Me.ebMatrizDesc)
        Me.Controls.Add(Me.cbSubEmpresa)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.lbSubEmpresa)
        Me.Controls.Add(Me.lbEstado)
        Me.Controls.Add(Me.ebNombre)
        Me.Controls.Add(Me.lbTipo)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.btNumCertificado)
        Me.Controls.Add(Me.ebNumCertificado)
        Me.Controls.Add(Me.lbNumCertificado)
        Me.Controls.Add(Me.lbExterior)
        Me.Controls.Add(Me.lbInterior)
        Me.Controls.Add(Me.ebExterior)
        Me.Controls.Add(Me.ebInterior)
        Me.Controls.Add(Me.lbColonia)
        Me.Controls.Add(Me.ebcolonia)
        Me.Controls.Add(Me.lbCodigoPostal)
        Me.Controls.Add(Me.ebCodigoPostal)
        Me.Controls.Add(Me.ebReferencia)
        Me.Controls.Add(Me.lbReferencia)
        Me.Controls.Add(Me.lbLocalidad)
        Me.Controls.Add(Me.ebLocalidad)
        Me.Controls.Add(Me.lbMunicipio)
        Me.Controls.Add(Me.ebMunicipio)
        Me.Controls.Add(Me.ebEntidad)
        Me.Controls.Add(Me.lbEntidad)
        Me.Controls.Add(Me.lbPais)
        Me.Controls.Add(Me.ebPais)
        Me.Name = "MGeneral"
        Me.Text = "MGeneral"
        Me.Controls.SetChildIndex(Me.ebPais, 0)
        Me.Controls.SetChildIndex(Me.lbPais, 0)
        Me.Controls.SetChildIndex(Me.lbEntidad, 0)
        Me.Controls.SetChildIndex(Me.ebEntidad, 0)
        Me.Controls.SetChildIndex(Me.ebMunicipio, 0)
        Me.Controls.SetChildIndex(Me.lbMunicipio, 0)
        Me.Controls.SetChildIndex(Me.ebLocalidad, 0)
        Me.Controls.SetChildIndex(Me.lbLocalidad, 0)
        Me.Controls.SetChildIndex(Me.lbReferencia, 0)
        Me.Controls.SetChildIndex(Me.ebReferencia, 0)
        Me.Controls.SetChildIndex(Me.ebCodigoPostal, 0)
        Me.Controls.SetChildIndex(Me.lbCodigoPostal, 0)
        Me.Controls.SetChildIndex(Me.ebcolonia, 0)
        Me.Controls.SetChildIndex(Me.lbColonia, 0)
        Me.Controls.SetChildIndex(Me.ebInterior, 0)
        Me.Controls.SetChildIndex(Me.ebExterior, 0)
        Me.Controls.SetChildIndex(Me.lbInterior, 0)
        Me.Controls.SetChildIndex(Me.lbExterior, 0)
        Me.Controls.SetChildIndex(Me.lbNumCertificado, 0)
        Me.Controls.SetChildIndex(Me.ebNumCertificado, 0)
        Me.Controls.SetChildIndex(Me.btNumCertificado, 0)
        Me.Controls.SetChildIndex(Me.lbNombre, 0)
        Me.Controls.SetChildIndex(Me.lbTipo, 0)
        Me.Controls.SetChildIndex(Me.ebNombre, 0)
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbEstado, 0)
        Me.Controls.SetChildIndex(Me.lbSubEmpresa, 0)
        Me.Controls.SetChildIndex(Me.cbEstado, 0)
        Me.Controls.SetChildIndex(Me.cbSubEmpresa, 0)
        Me.Controls.SetChildIndex(Me.ebMatrizDesc, 0)
        Me.Controls.SetChildIndex(Me.ebMatriz, 0)
        Me.Controls.SetChildIndex(Me.btMatriz, 0)
        Me.Controls.SetChildIndex(Me.cbTipo, 0)
        Me.Controls.SetChildIndex(Me.lbRFC, 0)
        Me.Controls.SetChildIndex(Me.ebRFC, 0)
        Me.Controls.SetChildIndex(Me.lbCalle, 0)
        Me.Controls.SetChildIndex(Me.ebCalle, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.lbMatriz, 0)
        Me.Controls.SetChildIndex(Me.gbRegimen, 0)
        CType(Me.epErrores1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbRegimen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRegimen.ResumeLayout(False)
        CType(Me.grdRegimenFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public vlMatriz As NGENERAL.slMatriz

    Dim vgModo As eModo
    Dim bCambioManual As Boolean = False
    Dim vcCentroExp As CCentroExp
    Dim vlCentroExpID As String
    Public vgUsuarioID As String
    Dim vcMensaje As CMensaje
    Dim vlHuboCambios As Boolean
    Dim vgCerrar As Boolean = False
    Dim EsqTabla As New DataTable
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Dim vcnumcertificado As New ERMCEFLOG.cCertificadoFolio
    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Function CREAR(ByRef prCentroExp As CCentroExp, ByVal pvUsuarioID As String, ByVal pvMatriz As NGENERAL.slMatriz) As Boolean
        'Dim vlDateTime As String
        'Dim vlNumero As Integer

        vcCentroExp = prCentroExp
        vgModo = eModo.Crear


        vgUsuarioID = pvUsuarioID


        ConfigurarTitulos()

        ebMatriz.Text = pvMatriz.MatrizID
        ebMatrizDesc.Text = pvMatriz.MatrizNombre
        cbEstado.SelectedValue = 1

        bCambioManual = True
        If ebMatriz.Text <> "" Then
            cbTipo.SelectedValue = 1
            cbSubEmpresa.SelectedValue = pvMatriz.SubEmpresa
        Else
            cbTipo.SelectedValue = 0
        End If
        bCambioManual = False


        '        LimpiarCampos()

        '        If Not pvPadre.PadreID = Nothing Then
        '            ebTipo.SelectedValue = pvPadre.PadreTipo
        '            ebTipo.Enabled = False
        '        Else
        '            ebTipo.Enabled = True
        '        End If

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCEEESC_MGeneralC")

        '        vlHuboCambios = False


        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If

    End Function

    Function MODIFICAR(ByRef prCentroExp As CCentroExp, ByVal pvUsuarioID As String) As Boolean

        'Dim vlDateTime As String
        'Dim vlNumero As Integer
        Dim vlMGeneral As New MGeneral

        vcCentroExp = prCentroExp
        vgUsuarioID = pvUsuarioID
        vgModo = eModo.Modificar
        vgUsuarioID = pvUsuarioID
        vlCentroExpID = prCentroExp.CentroExpID

        If (vcCentroExp.NumCertificado <> "") Then


            vcnumcertificado.Recuperar(vcCentroExp.NumCertificado)
            If vcCentroExp.NumCertificadoEnFosHistVigente(vlCentroExpID) Xor Not (vcnumcertificado.FechaInicial <= Date.Today And vcnumcertificado.FechaFinal >= Date.Today) Then
                ebNumCertificado.Enabled = False
                btNumCertificado.Enabled = False
            End If


        End If
        'If vcCentroExp.NumCertificadoEnFosHistVigente(vlCentroExpID) And Not (vcnumcertificado.FechaInicial <= Date.Today And vcnumcertificado.FechaFinal >= Date.Today) Then
        '    ebNumCertificado.Enabled = True
        '    btNumCertificado.Enabled = True

        'End If

        ConfigurarTitulos()



        vlHuboCambios = False

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCEEESC_MGeneralM")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If

    End Function
    Function Consultar(ByRef prCentroExp As CCentroExp, ByVal pvUsuarioID As String) As Boolean

        'Dim vlDateTime As String
        'Dim vlNumero As Integer
        Dim vlMGeneral As New MGeneral

        vcCentroExp = prCentroExp
        vgUsuarioID = pvUsuarioID
        vgModo = eModo.Leer
        vgUsuarioID = pvUsuarioID
        vlCentroExpID = prCentroExp.CentroExpID

        ConfigurarTitulos()
        For Each ctrls As Control In Me.Controls
            ctrls.Enabled = False
        Next
        BtCancelar.Enabled = True
        BtAceptar.Visible = False
        BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        BtCancelar.Icon = BtAceptar.Icon



        vlHuboCambios = False

        Me.Text = vcMensaje.RecuperarDescripcion("xconsultar") + " " + vcMensaje.RecuperarDescripcion("ERMCEEESC_NGeneral")

        Me.ShowDialog()


    End Function

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        'Dim vlCampo As String
        'Dim vlStatus As Integer

        Try
            If EbClave.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbClave.Text, False)}, )
                EbClave.Focus()
            End If
            If ebNombre.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNombre.Text, False)}, )
                ebNombre.Focus()
            End If

            If cbSubEmpresa.SelectedItem Is Nothing Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbSubEmpresa.Text, False)}, )
                cbSubEmpresa.Focus()
            End If


            If ebMatriz.Text = "" Then
                If cbTipo.SelectedValue = 1 Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbMatriz.Text, False)}, )
                    ebMatriz.Focus()
                End If
            End If

            If ebNumCertificado.Text = "" Then
                If cbTipo.SelectedValue = 0 Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNumCertificado.Text, False)}, )
                    ebNumCertificado.Focus()
                End If
            End If
            If ebRFC.Text = "" Then
                If cbTipo.SelectedValue = 0 Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbRFC.Text, False)}, )
                    ebRFC.Focus()
                End If
            Else
                Dim rfcValidar As String = ebRFC.Text
                If rfcValidar.Replace("-", "").ToString.Length > 13 Then
                    Throw New LbControlError.cError("E0718", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("RFC", False), New LbControlError.cParametroMSG("14", False)})
                    ebRFC.Focus()
                End If
            End If
            If ebCalle.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbCalle.Text, False)}, )
                ebCalle.Focus()
            End If
            If ebCodigoPostal.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbCodigoPostal.Text, False)}, )
                ebCodigoPostal.Focus()
            End If
            If ebMunicipio.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbMunicipio.Text, False)}, )
                ebMunicipio.Focus()
            End If
            If ebEntidad.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbEntidad.Text, False)}, )
                ebEntidad.Focus()
            End If


            If ebPais.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbPais.Text, False)}, )
                ebPais.Focus()
            End If


            Dim vcnumcertificado As New ERMCEFLOG.cCertificadoFolio
            If ebNumCertificado.Text <> "" Then


                If vcnumcertificado.Existe(ebNumCertificado.Text) Then
                    vcnumcertificado.Recuperar(ebNumCertificado.Text)
                    If Not (vcnumcertificado.FechaInicial <= Date.Today And vcnumcertificado.FechaFinal >= Date.Today) And cbEstado.SelectedValue = 1 Then
                        Throw New LbControlError.cError("E0640", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNumCertificado.Text, False)}, )
                        ebNumCertificado.Focus()
                    End If
                Else
                    Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNumCertificado.Text, False)}, )
                    ebNumCertificado.Focus()
                End If
            End If

            If cbTipo.SelectedValue = 1 Then
                If Not vcCentroExp.Existe(ebMatriz.Text) Then
                    Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(cbTipo.Items(0).Text, False)}, )
                    ebMatriz.Focus()
                End If

                If Not vcCentroExp.ExisteMatriz(ebMatriz.Text) Then
                    Throw New LbControlError.cError("E0638", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(cbTipo.Items(1).Text, False)}, )
                    ebMatriz.Focus()
                End If
                If ebMatriz.Text = EbClave.Text Then
                    Throw New LbControlError.cError("E0656", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbMatriz.Text, False), New LbControlError.cParametroMSG(lbClave.Text, False)}, )
                    'epErrores1.SetError(sender, vcMensaje.RecuperarDescripcion("E0656", New String() {lbMatriz.Text, lbClave.Text}))
                    ebMatriz.Focus()
                    Exit Sub
                End If
            End If


            If cbEstado.SelectedValue = 1 And cbTipo.SelectedValue = 0 Then
                If vcCentroExp.ExisteMatrizEnSubEmpresa(vcCentroExp.CentroExpID, cbSubEmpresa.SelectedValue) Then
                    Throw New LbControlError.cError("E0774", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.cbSubEmpresa.Text, False)})
                    'epErrores1.SetError(sender, vcMensaje.RecuperarDescripcion("E0774", New String() {Me.cbSubEmpresa.Text, ""}))
                    cbSubEmpresa.Focus()
                End If
            End If


            If CType(grdRegimenFiscal.DataSource, DataTable).Select("Seleccionado = 1").Length = 0 Then
                Throw New LbControlError.cError("E0867", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.gbRegimen.Text, False)})
                'epErrores1.SetError(sender, vcMensaje.RecuperarDescripcion("E0774", New String() {Me.cbSubEmpresa.Text, ""}))
            End If
            'E0867


        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        Select Case vgModo
            Case eModo.Crear
                Try
                    If vcCentroExp.Existe(EbClave.Text) Then
                        Throw New LbControlError.cError("BE0002")
                    End If


                    'If Not vcCentroExp.Existe(ebEsquemaPadre.Text) And ebEsquemaPadre.Text <> "" Then
                    '    epErrores1.SetError(ebEsqPadre, vcMensaje.RecuperarDescripcion("E0094"))
                    '    Throw New LbControlError.cError("E0094", , "EsquemaIDPadre")
                    '    Exit Sub
                    'Else
                    '    epErrores1.SetError(ebEsqPadre, "")
                    'End If

                    If vcCentroExp.Insertar(EbClave.Text, ebMatriz.Text, ebNombre.Text, cbTipo.SelectedValue, cbSubEmpresa.SelectedValue, ebNumCertificado.Text, ebRFC.Text.Replace("-", "").ToString, ebCalle.Text, ebExterior.Text, ebInterior.Text, ebcolonia.Text, ebCodigoPostal.Text, ebReferencia.Text, ebLocalidad.Text, ebMunicipio.Text, ebEntidad.Text, ebPais.Text, cbEstado.SelectedValue, Now(), vgUsuarioID) Then

                        'Insertar Regimen fiscal
                        Dim drRegimenes As DataRow() = CType(grdRegimenFiscal.DataSource, DataTable).Select("Seleccionado = 1")
                        For Each drReg As DataRow In drRegimenes
                            Me.vcCentroExp.InsertarCRF(drReg("TipoRegimen"))
                        Next

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        Exit Sub
                    End If


                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try
            Case eModo.Modificar

                Try

                    With vcCentroExp

                        .CentroExpPadreID = ebMatriz.Text
                        .CentroExpID = EbClave.Text
                        .Nombre = ebNombre.Text
                        .MUsuarioID = vgUsuarioID

                        .Calle = ebCalle.Text
                        .Colonia = ebcolonia.Text
                        .CodigoPostal = ebCodigoPostal.Text
                        .Entidad = ebEntidad.Text
                        .NumExt = ebExterior.Text
                        .NumInt = ebInterior.Text
                        .Localidad = ebLocalidad.Text
                        .CentroExpPadreID = ebMatriz.Text
                        .Municipio = ebMunicipio.Text
                        .Nombre = ebNombre.Text
                        .TipoEstado = cbEstado.SelectedValue
                        .Tipo = cbTipo.SelectedValue
                        .NumCertificado = ebNumCertificado.Text
                        .Pais = ebPais.Text
                        .ReferenciaDom = ebReferencia.Text
                        .RFC = ebRFC.Text.Replace("-", "").ToString
                        .SubEmpresaId = cbSubEmpresa.SelectedValue
                    End With

                    If vcCentroExp.NumCertificadoEnFosHistVigente(vlCentroExpID) And Not (vcnumcertificado.FechaInicial <= Date.Today And vcnumcertificado.FechaFinal >= Date.Today) Then
                        If MsgBox(vcMensaje.RecuperarDescripcion("P0205"), MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then


                            Dim DTVigentes As DataTable = vcCentroExp.RecuperarTablaFosHistVigentePorNumeroCertificado(vcnumcertificado.NumCertificado, vlCentroExpID)
                            For Each fila As DataRow In DTVigentes.Rows
                                Dim vcFosHist As New ERMFOLLOG.Amesol.CFOSHist
                                vcFosHist.FolioID = fila("folioid")
                                vcFosHist.FOSId = fila("FOSId")
                                vcFosHist.FSHFechaInicio = Date.Now

                                If Not IsDBNull(fila("VendedorID")) Then
                                    vcFosHist.VendedorID = fila("VendedorID")
                                End If
                                If Not IsDBNull(fila("TerminalClave")) Then
                                    vcFosHist.TerminalClave = fila("TerminalClave")
                                End If
                                vcFosHist.NumCertificado = vcCentroExp.NumCertificado
                                vcFosHist.CentroExpID = vcCentroExp.CentroExpID
                                vcFosHist.Inicio = fila("Inicio")
                                vcFosHist.Fin = fila("Fin")
                                vcFosHist.Insertar()
                                vcFosHist.Grabar()

                            Next
                        End If
                    End If


                    'End If



                    If vcCentroExp.Grabar Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        Exit Sub
                    End If



                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

        End Select
        vgCerrar = True
        Me.Close()
    End Sub

    Private Sub LimpiarCampos()



    End Sub

    Private Sub LlenarCampos()

        With vcCentroExp

            EbClave.Text = .CentroExpID
            ebCalle.Text = .Calle
            ebcolonia.Text = .Colonia
            ebCodigoPostal.Text = .CodigoPostal
            ebEntidad.Text = .Entidad
            ebExterior.Text = .NumExt
            ebInterior.Text = .NumInt
            ebLocalidad.Text = .Localidad
            ebMatriz.Text = .CentroExpPadreID
            ebMunicipio.Text = .Municipio
            ebNombre.Text = .Nombre
            cbEstado.SelectedValue = .TipoEstado
            cbTipo.SelectedValue = .Tipo
            ebNumCertificado.Text = .NumCertificado
            ebPais.Text = .Pais
            ebReferencia.Text = .ReferenciaDom
            ebRFC.Text = .RFC
            cbSubEmpresa.SelectedValue = .SubEmpresaId
            If .CentroExpPadreID <> "" Then
                Dim tmpCentroExp As New CCentroExp
                tmpCentroExp.Recuperar(ebMatriz.Text)
                ebMatrizDesc.Text = tmpCentroExp.Nombre
            End If
            ebNombre.Focus()

        End With

    End Sub

    Private Sub ConfigurarTitulos()

        vcMensaje = New CMensaje
        vcMensaje.LlenarDataSet()

        lbClave.Text = vcMensaje.RecuperarDescripcion("CEECentroExpID")
        lbEstado.Text = vcMensaje.RecuperarDescripcion("CEETipoEstado")
        lbCalle.Text = vcMensaje.RecuperarDescripcion("CEECalle")
        lbCodigoPostal.Text = vcMensaje.RecuperarDescripcion("CEECodigoPostal")
        lbEntidad.Text = vcMensaje.RecuperarDescripcion("CEEEntidad")
        lbNumCertificado.Text = vcMensaje.RecuperarDescripcion("CEENumCertificado")
        lbNombre.Text = vcMensaje.RecuperarDescripcion("CEENombre")
        lbTipo.Text = vcMensaje.RecuperarDescripcion("ESQTipo")
        lbMatriz.Text = vcMensaje.RecuperarDescripcion("CeeCentroExpPadreID")
        lbRFC.Text = vcMensaje.RecuperarDescripcion("CeeRFC")
        lbColonia.Text = vcMensaje.RecuperarDescripcion("CeeColonia")
        lbExterior.Text = vcMensaje.RecuperarDescripcion("CeeNumExt")
        lbInterior.Text = vcMensaje.RecuperarDescripcion("CeeNumInt")
        lbLocalidad.Text = vcMensaje.RecuperarDescripcion("CeeLocalidad")
        lbMunicipio.Text = vcMensaje.RecuperarDescripcion("CeeMunicipio")
        lbPais.Text = vcMensaje.RecuperarDescripcion("CeePais")
        lbReferencia.Text = vcMensaje.RecuperarDescripcion("CeeReferenciaDom")
        lbSubEmpresa.Text = vcMensaje.RecuperarDescripcion("CEESubEmpresa")
        gbRegimen.Text = vcMensaje.RecuperarDescripcion("ERMCEEESC_MGeneral_gbRegimen")

        BtAceptar.Text = vcMensaje.RecuperarDescripcion("btAceptar")
        BtCancelar.Text = vcMensaje.RecuperarDescripcion("btCancelar")


        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True

            .SetToolTip(EbClave, vcMensaje.RecuperarDescripcion("CEECentroExpIDT"))
            .SetToolTip(cbEstado, vcMensaje.RecuperarDescripcion("CEETipoEstadoT"))
            .SetToolTip(ebEntidad, vcMensaje.RecuperarDescripcion("CEEEntidadT"))
            .SetToolTip(cbTipo, vcMensaje.RecuperarDescripcion("CEETipoT"))
            .SetToolTip(ebEntidad, vcMensaje.RecuperarDescripcion("CEEEntidadT"))
            .SetToolTip(ebCalle, vcMensaje.RecuperarDescripcion("CEECalleT"))
            .SetToolTip(ebCodigoPostal, vcMensaje.RecuperarDescripcion("CEECodigoPostalT"))
            .SetToolTip(ebcolonia, vcMensaje.RecuperarDescripcion("CEEColoniaT"))
            .SetToolTip(ebExterior, vcMensaje.RecuperarDescripcion("CEENUMEXTT"))
            .SetToolTip(ebInterior, vcMensaje.RecuperarDescripcion("CEENumIntT"))
            .SetToolTip(ebLocalidad, vcMensaje.RecuperarDescripcion("CEELocalidadT"))
            .SetToolTip(ebMatriz, vcMensaje.RecuperarDescripcion("CEECentroExpPadreIDT"))
            .SetToolTip(ebMunicipio, vcMensaje.RecuperarDescripcion("CEEMunicipioT"))
            .SetToolTip(ebNombre, vcMensaje.RecuperarDescripcion("CEEnOMBRET"))
            .SetToolTip(ebNumCertificado, vcMensaje.RecuperarDescripcion("CEENUMCERTIFICADOT"))
            .SetToolTip(ebPais, vcMensaje.RecuperarDescripcion("CEEPAIST"))
            .SetToolTip(ebReferencia, vcMensaje.RecuperarDescripcion("CEEReferenciaDomT"))
            .SetToolTip(ebRFC, vcMensaje.RecuperarDescripcion("CEERFCT"))

            .SetToolTip(cbSubEmpresa, vcMensaje.RecuperarDescripcion("CEESubEmpresaT"))


            .SetToolTip(BtAceptar, vcMensaje.RecuperarDescripcion("BtAceptarT"))
            If vgModo = eModo.Leer Then
                .SetToolTip(BtCancelar, vcMensaje.RecuperarDescripcion("BtRegresar"))
            Else
                .SetToolTip(BtCancelar, vcMensaje.RecuperarDescripcion("BtCancelarT"))
            End If

        End With

        'Poner en el Tag el Nombre del Campo en la BD
        EbClave.Tag = "CentroExpID"
        ebCalle.Tag = "Calle"
        cbEstado.Tag = "Estado"
        ebNombre.Tag = "Nombre"
        ebRFC.Tag = "RFC"
        ebCodigoPostal.Tag = "CodigoPostal"
        ebMunicipio.Tag = "Municipio"
        ebEntidad.Tag = "Entidad"
        ebPais.Tag = "Pais"
        ebMatriz.Tag = "CentroExpPadreID"
        ebNumCertificado.Tag = "NumCertificado"
        cbTipo.Tag = "Tipo"
        cbSubEmpresa.Tag = "SubEmpresa"

        LlenarCbTipoEstado()
        LlenarCbTipo()
        LlenarCbSubEmpresa()
        LlenarGridRegimen()

        If vgModo = eModo.Crear Then
            '            Me.EbClave.Enabled = True
            '            LimpiarCampos()
        ElseIf vgModo = eModo.Modificar Or vgModo = eModo.Leer Then
            Me.EbClave.Enabled = False
            LlenarCampos()
        End If

        '        vlHuboCambios = False

    End Sub

    Private Sub LlenarCbTipoEstado()
        lbGeneral.LlenarComboBox(cbEstado, "EDOREG")
    End Sub

    Private Sub LlenarCbTipo()
        lbGeneral.LlenarComboBox(cbTipo, "TIPOCEE")
    End Sub

    Private Sub LlenarCbSubEmpresa()
        Dim subempresa As New ERMSEMLOG.cSubEmpresa()

        For Each R As DataRow In subempresa.RecuperarTabla().Rows
            cbSubEmpresa.Items.Add(R!NombreEmpresa, R!SubEmpresaID)
        Next
    End Sub

    Private Sub LlenarGridRegimen()
        Try
            grdRegimenFiscal.RootTable.Columns("TipoRegimen").Caption = vcMensaje.RecuperarDescripcion("CRFTipoRegimen")
            grdRegimenFiscal.RootTable.Columns("TipoRegimen").HeaderToolTip = vcMensaje.RecuperarDescripcion("CRFTipoRegimenT")

            lbGeneral.LlenarColumna(grdRegimenFiscal.RootTable.Columns("TipoRegimen"), "TIPREG")

            grdRegimenFiscal.DataSource = vcCentroExp.CRFDataTable()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '#Region "Validaciones Campos"
    Private Sub EbRequeridos_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.Validated, EbClave.Validated, ebNombre.Validated, cbEstado.Validated, ebRFC.Validated, ebCalle.Validated, ebCodigoPostal.Validated, ebMunicipio.Validated, ebEntidad.Validated, ebPais.Validated, ebNumCertificado.Validated, ebMatriz.Validated, ebMatrizDesc.Validated, btNumCertificado.Validated, cbSubEmpresa.Validated
        Try
            If sender Is cbTipo Or sender Is cbSubEmpresa Or sender Is cbEstado Then


                If cbEstado.SelectedValue = 1 And cbTipo.SelectedValue = 0 Then
                    If vcCentroExp.ExisteMatrizEnSubEmpresa(vcCentroExp.CentroExpID, cbSubEmpresa.SelectedValue) Then
                        epErrores1.SetError(sender, vcMensaje.RecuperarDescripcion("E0774", New String() {Me.cbSubEmpresa.Text, ""}))
                        Exit Sub
                    Else
                        epErrores1.SetError(cbTipo, "")
                        epErrores1.SetError(cbSubEmpresa, "")
                        epErrores1.SetError(cbEstado, "")
                    End If

                Else
                    epErrores1.SetError(cbTipo, "")
                    epErrores1.SetError(cbSubEmpresa, "")
                    epErrores1.SetError(cbEstado, "")
                End If
            End If

            If sender.Text = "" Then
                If UCase(sender.name) = UCase("ebRFC") Then
                    If cbTipo.SelectedValue = 0 Then
                        epErrores1.SetError(ebRFC, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("CEERFC")}))
                        Exit Sub
                    End If
                ElseIf UCase(sender.name) = UCase("ebMatriz") Then
                    If cbTipo.SelectedValue = 1 Then
                        epErrores1.SetError(ebMatrizDesc, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("CEECentroExpPadreID")}))
                        Exit Sub
                    End If
                ElseIf UCase(sender.name) = UCase("ebNumCertificado") Then
                    If cbTipo.SelectedValue = 0 Then
                        epErrores1.SetError(btNumCertificado, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("CEENumCertificado")}))
                        Exit Sub
                    End If
                    EbRequeridos_Validated(btNumCertificado, Nothing)
                ElseIf UCase(sender.name) = UCase("ebMatrizDesc") Then
                Else
                    epErrores1.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("CEE" & sender.tag)}))
                    Exit Sub
                End If

            End If

            Select Case UCase(sender.name).ToString
                Case UCase("ebNumCertificado").ToString
                    Dim vcnumcertificado As New ERMCEFLOG.cCertificadoFolio
                    If vcnumcertificado.Existe(ebNumCertificado.Text) Then
                        vcnumcertificado.Recuperar(ebNumCertificado.Text)

                        If Not (vcnumcertificado.FechaInicial <= Date.Today And vcnumcertificado.FechaFinal >= Date.Today) Then
                            epErrores1.SetError(btNumCertificado, vcMensaje.RecuperarDescripcion("E0640", New String() {lbNumCertificado.Text}))
                            Exit Sub
                        End If
                    ElseIf ebNumCertificado.Text <> "" Then
                        epErrores1.SetError(btNumCertificado, vcMensaje.RecuperarDescripcion("BE0003", New String() {lbNumCertificado.Text}))
                        Exit Sub
                    End If
                    EbRequeridos_Validated(btNumCertificado, Nothing)

                Case UCase("ebClave").ToString
                    If vcCentroExp.Existe(EbClave.Text) Then
                        epErrores1.SetError(sender, vcMensaje.RecuperarDescripcion("BE0002"))
                        Exit Sub
                    End If

                Case UCase("ebMatriz").ToString()
                    If (cbTipo.SelectedValue = 1) Then
                        If Not vcCentroExp.Existe(ebMatriz.Text) Then
                            epErrores1.SetError(ebMatrizDesc, vcMensaje.RecuperarDescripcion("BE0003", New String() {cbTipo.Items(0).Text}))
                            Exit Sub
                        End If
                        If Not vcCentroExp.ExisteMatriz(ebMatriz.Text) Then
                            epErrores1.SetError(ebMatrizDesc, vcMensaje.RecuperarDescripcion("E0638", New String() {cbTipo.Items(1).Text}))
                            Exit Sub
                        End If
                        If ebMatriz.Text.ToUpper = EbClave.Text.ToUpper Then
                            epErrores1.SetError(ebMatrizDesc, vcMensaje.RecuperarDescripcion("E0656", New String() {lbMatriz.Text, lbClave.Text}))
                            Exit Sub
                        End If
                        vcCentroExp.Recuperar(ebMatriz.Text)
                        ebMatrizDesc.Text = vcCentroExp.Nombre
                    End If
                    EbRequeridos_Validated(ebMatrizDesc, Nothing)

                Case UCase("ebRFC").ToString
                    Dim rfcValidar As String = ebRFC.Text
                    If rfcValidar.Replace("-", "").ToString.Length > 13 Then
                        epErrores1.SetError(ebRFC, vcMensaje.RecuperarDescripcion("E0718", New String() {"RFC", "14"}))
                        Exit Sub
                    End If
                    'EbRequeridos_Validated(ebRFC, Nothing)

            End Select

            epErrores1.SetError(sender, "")
        Catch ex As Exception

        End Try
    End Sub
    '#End Region

    Private Sub Controles_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EbClave.Validated, ebNombre.Validated, cbEstado.Validated
        vlHuboCambios = True
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not vgCerrar And vlHuboCambios Then
            'Dim vlRespuesta As MsgBoxResult

            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub EditBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebRFC.Click

    End Sub

    Private Sub cbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged, cbSubEmpresa.SelectedIndexChanged
        vlHuboCambios = True
        If vgModo = eModo.Modificar Then
            If sender Is cbEstado And cbEstado.SelectedValue = 0 Then
                Dim subEm As String = vcCentroExp.NumCertificadoEnFosHistVigenteMatrizSucursales(vlCentroExpID)
                If subEm <> "" Then
                    epErrores1.SetError(cbEstado, vcMensaje.RecuperarDescripcion("E0704", New String() {Me.lbEstado.Text, subEm + " "}))
                    Return
                End If

            Else
                If sender Is cbSubEmpresa Then
                    Dim subEm As String = vcCentroExp.NumCertificadoEnFosHistVigenteMatrizSucursales(vlCentroExpID)

                    If subEm <> "" And vcCentroExp.SubEmpresaId <> cbSubEmpresa.SelectedValue Then
                        epErrores1.SetError(cbSubEmpresa, vcMensaje.RecuperarDescripcion("E0704", New String() {Me.lbSubEmpresa.Text, subEm + " "}))
                        Return
                    End If
                End If
            End If

        End If



        epErrores1.SetError(sender, "")


    End Sub

    Friend WithEvents lbNumCertificado As System.Windows.Forms.Label
    Friend WithEvents ebNumCertificado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btNumCertificado As Janus.Windows.EditControls.UIButton
    Friend WithEvents btMatriz As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebMatriz As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMatrizDesc As Janus.Windows.GridEX.EditControls.EditBox

    Private Sub btMatriz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMatriz.Click

        Dim frmBrowse As New IGeneral(False, , )

        frmBrowse.StartPosition = FormStartPosition.CenterParent
        frmBrowse.ShowDialog()

        If frmBrowse.Seleccion.Count = 0 Then
            Exit Sub
        End If

        With frmBrowse.Seleccion(0)
            vlMatriz.MatrizID = frmBrowse.Seleccion(0).Item("CentroExpID")
            vlMatriz.SubEmpresa = frmBrowse.Seleccion(0).Item("SubEmpresaID")
            vlMatriz.MatrizNombre = frmBrowse.Seleccion(0).Item("Nombre")

        End With

        ebMatriz.Text = vlMatriz.MatrizID
        ebMatrizDesc.Text = vlMatriz.MatrizNombre


        cbSubEmpresa.SelectedValue = vlMatriz.SubEmpresa
        'cbTipo.Enabled = False
        EbRequeridos_Validated(ebMatriz, Nothing)
    End Sub

    Dim bCambiar As Boolean = True

    Private Sub cbTipo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedValueChanged
        Try


            If vgModo = eModo.Modificar Then
                If cbTipo.SelectedValue = 1 And vcCentroExp.Tabla.RecuperarTabla("centroexppadreid='" + EbClave.Text.Replace("'", "''") + "'").Rows.Count > 0 Then
                    bCambiar = False
                    cbTipo.SelectedValue = 0
                    bCambiar = True
                    Throw New LbControlError.cError("E0639")
                End If
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
        If bCambiar Then
            If cbTipo.SelectedValue = 0 Then
                ebMatriz.Enabled = False
                ebMatriz.Text = ""
                ebMatrizDesc.Text = ""
                btMatriz.Enabled = False
                ebRFC.Enabled = True
                cbSubEmpresa.Enabled = True
                'cbSubEmpresa.SelectedItem = Nothing
                EbRequeridos_Validated(ebMatriz, Nothing)
            Else
                ebRFC.Text = ""
                cbSubEmpresa.SelectedItem = Nothing
                cbSubEmpresa.Enabled = False

                EbRequeridos_Validated(ebRFC, Nothing)
                If Not bCambioManual Then EbRequeridos_Validated(ebNumCertificado, Nothing)
                ebMatriz.Enabled = True
                btMatriz.Enabled = True

                ebRFC.Enabled = False

            End If
        End If

    End Sub

    Private Sub btNumCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNumCertificado.Click
        Dim frmBrowse As New ERMCEFESC.IGeneral

        frmBrowse.StartPosition = FormStartPosition.CenterParent
        Try
            Dim res As ArrayList = frmBrowse.Seleccionar("FechaInicial <=  cast(floor(cast(getdate() as float)) as datetime)  AND FechaFinal >=  cast(floor(cast(getdate() as float)) as datetime) ", False)
            If (Not IsDBNull(res) AndAlso res.Count > 0) Then
                Dim Certificadofolio As ERMCEFLOG.cCertificadoFolio = CType(res(0), ERMCEFLOG.cCertificadoFolio)
                ebNumCertificado.Text = Certificadofolio.NumCertificado
            End If
        Catch ex As Exception

        End Try
        EbRequeridos_Validated(ebNumCertificado, Nothing)
    End Sub

    Private Sub cbEstado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbEstado.Validating, cbSubEmpresa.Validating
        If vgModo = eModo.Modificar Then
            If vcCentroExp.NumCertificadoEnFosHistVigente(vlCentroExpID) And cbEstado.SelectedValue = 0 Then
                e.Cancel = True
            End If
            If sender Is cbSubEmpresa Then
                Dim subEm As String = vcCentroExp.NumCertificadoEnFosHistVigenteMatrizSucursales(vlCentroExpID)

                If subEm <> "" And vcCentroExp.SubEmpresaId <> cbSubEmpresa.SelectedValue Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub


    Private Sub grdRegimenFiscal_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdRegimenFiscal.CellValueChanged
        If vgModo <> eModo.Crear Then
            If e.Column.Key = "Seleccionado" Then
                If grdRegimenFiscal.GetValue("Seleccionado") = True Then
                    Me.vcCentroExp.InsertarCRF(grdRegimenFiscal.GetValue("TipoRegimen"))
                Else
                    Me.vcCentroExp.EliminarCRF(grdRegimenFiscal.GetValue("TipoRegimen"))
                End If
            End If
        End If
    End Sub
End Class

Public Enum eModo
    Crear = 1
    Modificar = 2
    Leer = 3
End Enum

