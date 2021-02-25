Imports System.Data.SqlClient

Public Class FrmEstructura
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
    Friend WithEvents UiTabPageEst As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPageUbc As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpPosicion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPosY As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents LblPosY As System.Windows.Forms.Label
    Friend WithEvents LblPosX As System.Windows.Forms.Label
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtPosX As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GrpDimensiones As System.Windows.Forms.GroupBox
    Friend WithEvents TxtColumnas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtAncho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtLargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LblFilas As System.Windows.Forms.Label
    Friend WithEvents LblColumnas As System.Windows.Forms.Label
    Friend WithEvents LblAncho As System.Windows.Forms.Label
    Friend WithEvents LblLargo As System.Windows.Forms.Label
    Friend WithEvents LblAlto As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtAlto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GrpEstructura As System.Windows.Forms.GroupBox
    Friend WithEvents CmbRotacion As Selling.StoreCombo
    Friend WithEvents CmbRecolecta As Selling.StoreCombo
    Friend WithEvents CmbColoca As Selling.StoreCombo
    Friend WithEvents CmbEstructura As Selling.StoreCombo
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents LblRotacion As System.Windows.Forms.Label
    Friend WithEvents LblRecoleccion As System.Windows.Forms.Label
    Friend WithEvents LblColocacion As System.Windows.Forms.Label
    Friend WithEvents LblArea As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents LblTEstructura As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridUbicaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridPosiciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabEstructura As Janus.Windows.UI.Tab.UITab
    Friend WithEvents BtnModificaPos As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminaPos As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregaUB As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminaUB As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnZona As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnArea As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnPasillo As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpContenido As System.Windows.Forms.GroupBox
    Friend WithEvents GridExistencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEtiquetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents NumNiveles As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPosicion As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents btnAddCol As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddFila As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelFila As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelCol As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblRangofin As System.Windows.Forms.Label
    Friend WithEvents lblRangoIni As System.Windows.Forms.Label
    Friend WithEvents cmbRangoFin As Selling.StoreCombo
    Friend WithEvents cmbRangoIni As Selling.StoreCombo
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSecuencia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbAplicacion As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbArea As Selling.StoreCombo

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstructura))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabEstructura = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPageEst = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpPosicion = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSecuencia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtPosY = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.LblPosY = New System.Windows.Forms.Label()
        Me.LblPosX = New System.Windows.Forms.Label()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.TxtPosX = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpDimensiones = New System.Windows.Forms.GroupBox()
        Me.NumNiveles = New System.Windows.Forms.NumericUpDown()
        Me.TxtColumnas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtAncho = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtLargo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblFilas = New System.Windows.Forms.Label()
        Me.LblColumnas = New System.Windows.Forms.Label()
        Me.LblAncho = New System.Windows.Forms.Label()
        Me.LblLargo = New System.Windows.Forms.Label()
        Me.LblAlto = New System.Windows.Forms.Label()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.TxtAlto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpEstructura = New System.Windows.Forms.GroupBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.lblRangofin = New System.Windows.Forms.Label()
        Me.lblRangoIni = New System.Windows.Forms.Label()
        Me.cmbRangoFin = New Selling.StoreCombo()
        Me.cmbRangoIni = New Selling.StoreCombo()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.CmbEstructura = New Selling.StoreCombo()
        Me.CmbRotacion = New Selling.StoreCombo()
        Me.CmbRecolecta = New Selling.StoreCombo()
        Me.CmbColoca = New Selling.StoreCombo()
        Me.CmbArea = New Selling.StoreCombo()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.LblRotacion = New System.Windows.Forms.Label()
        Me.LblRecoleccion = New System.Windows.Forms.Label()
        Me.LblColocacion = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.LblTEstructura = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.BtnPasillo = New Janus.Windows.EditControls.UIButton()
        Me.BtnArea = New Janus.Windows.EditControls.UIButton()
        Me.UiTabPageUbc = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpContenido = New System.Windows.Forms.GroupBox()
        Me.GridExistencia = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbTipoEstado = New Selling.StoreCombo()
        Me.txtPosicion = New System.Windows.Forms.Label()
        Me.GridUbicaciones = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregaUB = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminaUB = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridPosiciones = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminaPos = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificaPos = New Janus.Windows.EditControls.UIButton()
        Me.BtnZona = New Janus.Windows.EditControls.UIButton()
        Me.btnDelFila = New Janus.Windows.EditControls.UIButton()
        Me.btnDelCol = New Janus.Windows.EditControls.UIButton()
        Me.btnImportar = New Janus.Windows.EditControls.UIButton()
        Me.btnAddFila = New Janus.Windows.EditControls.UIButton()
        Me.btnAddCol = New Janus.Windows.EditControls.UIButton()
        Me.BtnEtiquetas = New Janus.Windows.EditControls.UIButton()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.cmbAplicacion = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        CType(Me.UiTabEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabEstructura.SuspendLayout()
        Me.UiTabPageEst.SuspendLayout()
        Me.GrpPosicion.SuspendLayout()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDimensiones.SuspendLayout()
        CType(Me.NumNiveles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpEstructura.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPageUbc.SuspendLayout()
        Me.GrpContenido.SuspendLayout()
        CType(Me.GridExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridUbicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridPosiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Icon = CType(resources.GetObject("BtnGuardar.Icon"), System.Drawing.Icon)
        Me.BtnGuardar.Location = New System.Drawing.Point(755, 6)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 15
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.Location = New System.Drawing.Point(755, 464)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCerrar.TabIndex = 22
        Me.BtnCerrar.Text = "&Salir"
        Me.BtnCerrar.ToolTipText = "Cerrar ventana"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabEstructura
        '
        Me.UiTabEstructura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabEstructura.Location = New System.Drawing.Point(8, 8)
        Me.UiTabEstructura.Name = "UiTabEstructura"
        Me.UiTabEstructura.Size = New System.Drawing.Size(734, 493)
        Me.UiTabEstructura.TabIndex = 9
        Me.UiTabEstructura.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPageEst, Me.UiTabPageUbc})
        '
        'UiTabPageEst
        '
        Me.UiTabPageEst.Controls.Add(Me.GrpPosicion)
        Me.UiTabPageEst.Controls.Add(Me.GrpDimensiones)
        Me.UiTabPageEst.Controls.Add(Me.GrpEstructura)
        Me.UiTabPageEst.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPageEst.Name = "UiTabPageEst"
        Me.UiTabPageEst.Size = New System.Drawing.Size(730, 469)
        Me.UiTabPageEst.TabStop = True
        Me.UiTabPageEst.Text = "Estructura"
        '
        'GrpPosicion
        '
        Me.GrpPosicion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPosicion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GrpPosicion.Controls.Add(Me.Label1)
        Me.GrpPosicion.Controls.Add(Me.TxtSecuencia)
        Me.GrpPosicion.Controls.Add(Me.TxtPosY)
        Me.GrpPosicion.Controls.Add(Me.PictureBox13)
        Me.GrpPosicion.Controls.Add(Me.LblPosY)
        Me.GrpPosicion.Controls.Add(Me.LblPosX)
        Me.GrpPosicion.Controls.Add(Me.PictureBox12)
        Me.GrpPosicion.Controls.Add(Me.TxtPosX)
        Me.GrpPosicion.Location = New System.Drawing.Point(358, 302)
        Me.GrpPosicion.Name = "GrpPosicion"
        Me.GrpPosicion.Size = New System.Drawing.Size(344, 159)
        Me.GrpPosicion.TabIndex = 8
        Me.GrpPosicion.TabStop = False
        Me.GrpPosicion.Text = "Posición"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 24)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Secuencia de Recolección"
        '
        'TxtSecuencia
        '
        Me.TxtSecuencia.DecimalDigits = 0
        Me.TxtSecuencia.Location = New System.Drawing.Point(162, 114)
        Me.TxtSecuencia.Name = "TxtSecuencia"
        Me.TxtSecuencia.Size = New System.Drawing.Size(72, 20)
        Me.TxtSecuencia.TabIndex = 37
        Me.TxtSecuencia.Text = "0"
        Me.TxtSecuencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtSecuencia.Value = 0
        Me.TxtSecuencia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'TxtPosY
        '
        Me.TxtPosY.DecimalDigits = 2
        Me.TxtPosY.Location = New System.Drawing.Point(48, 64)
        Me.TxtPosY.Name = "TxtPosY"
        Me.TxtPosY.Size = New System.Drawing.Size(72, 20)
        Me.TxtPosY.TabIndex = 14
        Me.TxtPosY.Text = "0.00"
        Me.TxtPosY.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtPosY.Value = 0.0R
        Me.TxtPosY.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(128, 68)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox13.TabIndex = 36
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'LblPosY
        '
        Me.LblPosY.Location = New System.Drawing.Point(8, 64)
        Me.LblPosY.Name = "LblPosY"
        Me.LblPosY.Size = New System.Drawing.Size(40, 24)
        Me.LblPosY.TabIndex = 28
        Me.LblPosY.Text = "Pos Y"
        '
        'LblPosX
        '
        Me.LblPosX.Location = New System.Drawing.Point(8, 24)
        Me.LblPosX.Name = "LblPosX"
        Me.LblPosX.Size = New System.Drawing.Size(40, 23)
        Me.LblPosX.TabIndex = 27
        Me.LblPosX.Text = "Pos X"
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(128, 24)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox12.TabIndex = 35
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'TxtPosX
        '
        Me.TxtPosX.DecimalDigits = 2
        Me.TxtPosX.Location = New System.Drawing.Point(48, 24)
        Me.TxtPosX.Name = "TxtPosX"
        Me.TxtPosX.Size = New System.Drawing.Size(72, 20)
        Me.TxtPosX.TabIndex = 13
        Me.TxtPosX.Text = "0.00"
        Me.TxtPosX.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtPosX.Value = 0.0R
        Me.TxtPosX.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GrpDimensiones
        '
        Me.GrpDimensiones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpDimensiones.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GrpDimensiones.Controls.Add(Me.NumNiveles)
        Me.GrpDimensiones.Controls.Add(Me.TxtColumnas)
        Me.GrpDimensiones.Controls.Add(Me.TxtAncho)
        Me.GrpDimensiones.Controls.Add(Me.TxtLargo)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox9)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox8)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox7)
        Me.GrpDimensiones.Controls.Add(Me.Label16)
        Me.GrpDimensiones.Controls.Add(Me.Label15)
        Me.GrpDimensiones.Controls.Add(Me.Label14)
        Me.GrpDimensiones.Controls.Add(Me.LblFilas)
        Me.GrpDimensiones.Controls.Add(Me.LblColumnas)
        Me.GrpDimensiones.Controls.Add(Me.LblAncho)
        Me.GrpDimensiones.Controls.Add(Me.LblLargo)
        Me.GrpDimensiones.Controls.Add(Me.LblAlto)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox10)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox11)
        Me.GrpDimensiones.Controls.Add(Me.TxtAlto)
        Me.GrpDimensiones.Location = New System.Drawing.Point(8, 302)
        Me.GrpDimensiones.Name = "GrpDimensiones"
        Me.GrpDimensiones.Size = New System.Drawing.Size(344, 159)
        Me.GrpDimensiones.TabIndex = 7
        Me.GrpDimensiones.TabStop = False
        Me.GrpDimensiones.Text = "Dimensiones"
        '
        'NumNiveles
        '
        Me.NumNiveles.Location = New System.Drawing.Point(128, 122)
        Me.NumNiveles.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NumNiveles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumNiveles.Name = "NumNiveles"
        Me.NumNiveles.Size = New System.Drawing.Size(98, 20)
        Me.NumNiveles.TabIndex = 12
        Me.NumNiveles.ThousandsSeparator = True
        Me.NumNiveles.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtColumnas
        '
        Me.TxtColumnas.DecimalDigits = 0
        Me.TxtColumnas.Location = New System.Drawing.Point(128, 96)
        Me.TxtColumnas.Name = "TxtColumnas"
        Me.TxtColumnas.Size = New System.Drawing.Size(96, 20)
        Me.TxtColumnas.TabIndex = 11
        Me.TxtColumnas.Text = "0"
        Me.TxtColumnas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtColumnas.Value = 0
        Me.TxtColumnas.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'TxtAncho
        '
        Me.TxtAncho.DecimalDigits = 2
        Me.TxtAncho.Location = New System.Drawing.Point(128, 72)
        Me.TxtAncho.Name = "TxtAncho"
        Me.TxtAncho.Size = New System.Drawing.Size(96, 20)
        Me.TxtAncho.TabIndex = 10
        Me.TxtAncho.Text = "0.00"
        Me.TxtAncho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAncho.Value = 0.0R
        Me.TxtAncho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtLargo
        '
        Me.TxtLargo.DecimalDigits = 2
        Me.TxtLargo.Location = New System.Drawing.Point(128, 48)
        Me.TxtLargo.Name = "TxtLargo"
        Me.TxtLargo.Size = New System.Drawing.Size(96, 20)
        Me.TxtLargo.TabIndex = 9
        Me.TxtLargo.Text = "0.00"
        Me.TxtLargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtLargo.Value = 0.0R
        Me.TxtLargo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(256, 72)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox9.TabIndex = 34
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(256, 50)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox8.TabIndex = 33
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(256, 24)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox7.TabIndex = 32
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(232, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 23)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "mts"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(232, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 23)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "mts"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(232, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 23)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "mts"
        '
        'LblFilas
        '
        Me.LblFilas.Location = New System.Drawing.Point(8, 124)
        Me.LblFilas.Name = "LblFilas"
        Me.LblFilas.Size = New System.Drawing.Size(120, 23)
        Me.LblFilas.TabIndex = 10
        Me.LblFilas.Text = "Numero de Niveles"
        '
        'LblColumnas
        '
        Me.LblColumnas.Location = New System.Drawing.Point(8, 96)
        Me.LblColumnas.Name = "LblColumnas"
        Me.LblColumnas.Size = New System.Drawing.Size(120, 23)
        Me.LblColumnas.TabIndex = 9
        Me.LblColumnas.Text = "Numero de Columnas"
        '
        'LblAncho
        '
        Me.LblAncho.Location = New System.Drawing.Point(8, 72)
        Me.LblAncho.Name = "LblAncho"
        Me.LblAncho.Size = New System.Drawing.Size(120, 23)
        Me.LblAncho.TabIndex = 8
        Me.LblAncho.Text = "Ancho"
        '
        'LblLargo
        '
        Me.LblLargo.Location = New System.Drawing.Point(8, 48)
        Me.LblLargo.Name = "LblLargo"
        Me.LblLargo.Size = New System.Drawing.Size(120, 23)
        Me.LblLargo.TabIndex = 7
        Me.LblLargo.Text = "Largo"
        '
        'LblAlto
        '
        Me.LblAlto.Location = New System.Drawing.Point(8, 24)
        Me.LblAlto.Name = "LblAlto"
        Me.LblAlto.Size = New System.Drawing.Size(120, 23)
        Me.LblAlto.TabIndex = 6
        Me.LblAlto.Text = "Alto"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(256, 96)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox10.TabIndex = 33
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(256, 122)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox11.TabIndex = 34
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'TxtAlto
        '
        Me.TxtAlto.DecimalDigits = 2
        Me.TxtAlto.Location = New System.Drawing.Point(128, 24)
        Me.TxtAlto.Name = "TxtAlto"
        Me.TxtAlto.Size = New System.Drawing.Size(96, 20)
        Me.TxtAlto.TabIndex = 8
        Me.TxtAlto.Text = "0.00"
        Me.TxtAlto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAlto.Value = 0.0R
        Me.TxtAlto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GrpEstructura
        '
        Me.GrpEstructura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEstructura.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GrpEstructura.Controls.Add(Me.cmbAplicacion)
        Me.GrpEstructura.Controls.Add(Me.Label2)
        Me.GrpEstructura.Controls.Add(Me.PictureBox17)
        Me.GrpEstructura.Controls.Add(Me.PictureBox16)
        Me.GrpEstructura.Controls.Add(Me.PictureBox15)
        Me.GrpEstructura.Controls.Add(Me.lblRangofin)
        Me.GrpEstructura.Controls.Add(Me.lblRangoIni)
        Me.GrpEstructura.Controls.Add(Me.cmbRangoFin)
        Me.GrpEstructura.Controls.Add(Me.cmbRangoIni)
        Me.GrpEstructura.Controls.Add(Me.PictureBox14)
        Me.GrpEstructura.Controls.Add(Me.CmbEstructura)
        Me.GrpEstructura.Controls.Add(Me.CmbRotacion)
        Me.GrpEstructura.Controls.Add(Me.CmbRecolecta)
        Me.GrpEstructura.Controls.Add(Me.CmbColoca)
        Me.GrpEstructura.Controls.Add(Me.CmbArea)
        Me.GrpEstructura.Controls.Add(Me.PictureBox6)
        Me.GrpEstructura.Controls.Add(Me.TxtID)
        Me.GrpEstructura.Controls.Add(Me.LblRotacion)
        Me.GrpEstructura.Controls.Add(Me.LblRecoleccion)
        Me.GrpEstructura.Controls.Add(Me.LblColocacion)
        Me.GrpEstructura.Controls.Add(Me.LblArea)
        Me.GrpEstructura.Controls.Add(Me.LblClave)
        Me.GrpEstructura.Controls.Add(Me.LblTEstructura)
        Me.GrpEstructura.Controls.Add(Me.PictureBox1)
        Me.GrpEstructura.Controls.Add(Me.PictureBox4)
        Me.GrpEstructura.Controls.Add(Me.PictureBox2)
        Me.GrpEstructura.Controls.Add(Me.PictureBox3)
        Me.GrpEstructura.Controls.Add(Me.PictureBox5)
        Me.GrpEstructura.Controls.Add(Me.BtnPasillo)
        Me.GrpEstructura.Controls.Add(Me.BtnArea)
        Me.GrpEstructura.Location = New System.Drawing.Point(8, 8)
        Me.GrpEstructura.Name = "GrpEstructura"
        Me.GrpEstructura.Size = New System.Drawing.Size(718, 288)
        Me.GrpEstructura.TabIndex = 6
        Me.GrpEstructura.TabStop = False
        Me.GrpEstructura.Text = "General"
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(408, 258)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox16.TabIndex = 131
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(408, 224)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox15.TabIndex = 130
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'lblRangofin
        '
        Me.lblRangofin.Location = New System.Drawing.Point(16, 261)
        Me.lblRangofin.Name = "lblRangofin"
        Me.lblRangofin.Size = New System.Drawing.Size(100, 23)
        Me.lblRangofin.TabIndex = 129
        Me.lblRangofin.Text = "Rango Envio Final"
        Me.lblRangofin.Visible = False
        '
        'lblRangoIni
        '
        Me.lblRangoIni.Location = New System.Drawing.Point(16, 224)
        Me.lblRangoIni.Name = "lblRangoIni"
        Me.lblRangoIni.Size = New System.Drawing.Size(100, 23)
        Me.lblRangoIni.TabIndex = 128
        Me.lblRangoIni.Text = "Rango Envio Inicial"
        Me.lblRangoIni.Visible = False
        '
        'cmbRangoFin
        '
        Me.cmbRangoFin.Location = New System.Drawing.Point(153, 258)
        Me.cmbRangoFin.Name = "cmbRangoFin"
        Me.cmbRangoFin.Size = New System.Drawing.Size(249, 21)
        Me.cmbRangoFin.TabIndex = 127
        Me.cmbRangoFin.Visible = False
        '
        'cmbRangoIni
        '
        Me.cmbRangoIni.Location = New System.Drawing.Point(153, 224)
        Me.cmbRangoIni.Name = "cmbRangoIni"
        Me.cmbRangoIni.Size = New System.Drawing.Size(249, 21)
        Me.cmbRangoIni.TabIndex = 126
        Me.cmbRangoIni.Visible = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(335, 87)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox14.TabIndex = 34
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'CmbEstructura
        '
        Me.CmbEstructura.Location = New System.Drawing.Point(152, 21)
        Me.CmbEstructura.Name = "CmbEstructura"
        Me.CmbEstructura.Size = New System.Drawing.Size(176, 21)
        Me.CmbEstructura.TabIndex = 7
        '
        'CmbRotacion
        '
        Me.CmbRotacion.Location = New System.Drawing.Point(153, 190)
        Me.CmbRotacion.Name = "CmbRotacion"
        Me.CmbRotacion.Size = New System.Drawing.Size(176, 21)
        Me.CmbRotacion.TabIndex = 7
        '
        'CmbRecolecta
        '
        Me.CmbRecolecta.Location = New System.Drawing.Point(152, 156)
        Me.CmbRecolecta.Name = "CmbRecolecta"
        Me.CmbRecolecta.Size = New System.Drawing.Size(176, 21)
        Me.CmbRecolecta.TabIndex = 7
        '
        'CmbColoca
        '
        Me.CmbColoca.Location = New System.Drawing.Point(152, 122)
        Me.CmbColoca.Name = "CmbColoca"
        Me.CmbColoca.Size = New System.Drawing.Size(176, 21)
        Me.CmbColoca.TabIndex = 7
        '
        'CmbArea
        '
        Me.CmbArea.Location = New System.Drawing.Point(152, 88)
        Me.CmbArea.Name = "CmbArea"
        Me.CmbArea.Size = New System.Drawing.Size(176, 21)
        Me.CmbArea.TabIndex = 7
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(335, 195)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox6.TabIndex = 31
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(152, 55)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(176, 20)
        Me.TxtID.TabIndex = 2
        '
        'LblRotacion
        '
        Me.LblRotacion.Location = New System.Drawing.Point(16, 193)
        Me.LblRotacion.Name = "LblRotacion"
        Me.LblRotacion.Size = New System.Drawing.Size(136, 23)
        Me.LblRotacion.TabIndex = 7
        Me.LblRotacion.Text = "Tipo de Nivel de Rotación"
        '
        'LblRecoleccion
        '
        Me.LblRecoleccion.Location = New System.Drawing.Point(16, 156)
        Me.LblRecoleccion.Name = "LblRecoleccion"
        Me.LblRecoleccion.Size = New System.Drawing.Size(120, 23)
        Me.LblRecoleccion.TabIndex = 6
        Me.LblRecoleccion.Text = "Pasillo de Recolección"
        '
        'LblColocacion
        '
        Me.LblColocacion.Location = New System.Drawing.Point(16, 126)
        Me.LblColocacion.Name = "LblColocacion"
        Me.LblColocacion.Size = New System.Drawing.Size(120, 16)
        Me.LblColocacion.TabIndex = 5
        Me.LblColocacion.Text = "Pasillo de Colocación"
        '
        'LblArea
        '
        Me.LblArea.Location = New System.Drawing.Point(16, 91)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(100, 23)
        Me.LblArea.TabIndex = 4
        Me.LblArea.Text = "Area"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(16, 58)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(100, 23)
        Me.LblClave.TabIndex = 2
        Me.LblClave.Text = "Clave"
        '
        'LblTEstructura
        '
        Me.LblTEstructura.Location = New System.Drawing.Point(16, 24)
        Me.LblTEstructura.Name = "LblTEstructura"
        Me.LblTEstructura.Size = New System.Drawing.Size(100, 23)
        Me.LblTEstructura.TabIndex = 0
        Me.LblTEstructura.Text = "Tipo de Estructura"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(336, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(336, 144)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 29
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(336, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 27
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(336, 120)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 28
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(336, 168)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 30
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'BtnPasillo
        '
        Me.BtnPasillo.Icon = CType(resources.GetObject("BtnPasillo.Icon"), System.Drawing.Icon)
        Me.BtnPasillo.Location = New System.Drawing.Point(356, 114)
        Me.BtnPasillo.Name = "BtnPasillo"
        Me.BtnPasillo.Size = New System.Drawing.Size(90, 30)
        Me.BtnPasillo.TabIndex = 33
        Me.BtnPasillo.Text = "Pasillo"
        Me.BtnPasillo.ToolTipText = "Crear nuevo pasillo"
        Me.BtnPasillo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnArea
        '
        Me.BtnArea.Icon = CType(resources.GetObject("BtnArea.Icon"), System.Drawing.Icon)
        Me.BtnArea.Location = New System.Drawing.Point(356, 79)
        Me.BtnArea.Name = "BtnArea"
        Me.BtnArea.Size = New System.Drawing.Size(90, 30)
        Me.BtnArea.TabIndex = 32
        Me.BtnArea.Text = "Area"
        Me.BtnArea.ToolTipText = "Crear nueva area"
        Me.BtnArea.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabPageUbc
        '
        Me.UiTabPageUbc.Controls.Add(Me.GrpContenido)
        Me.UiTabPageUbc.Controls.Add(Me.GroupBox2)
        Me.UiTabPageUbc.Controls.Add(Me.GroupBox1)
        Me.UiTabPageUbc.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPageUbc.Name = "UiTabPageUbc"
        Me.UiTabPageUbc.Size = New System.Drawing.Size(730, 469)
        Me.UiTabPageUbc.TabStop = True
        Me.UiTabPageUbc.Text = "Ubicaciones"
        '
        'GrpContenido
        '
        Me.GrpContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpContenido.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GrpContenido.Controls.Add(Me.GridExistencia)
        Me.GrpContenido.Location = New System.Drawing.Point(219, 200)
        Me.GrpContenido.Name = "GrpContenido"
        Me.GrpContenido.Size = New System.Drawing.Size(499, 269)
        Me.GrpContenido.TabIndex = 6
        Me.GrpContenido.TabStop = False
        Me.GrpContenido.Text = "Existencia"
        '
        'GridExistencia
        '
        Me.GridExistencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridExistencia.ColumnAutoResize = True
        Me.GridExistencia.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridExistencia.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridExistencia.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridExistencia.GroupByBoxVisible = False
        Me.GridExistencia.Location = New System.Drawing.Point(8, 19)
        Me.GridExistencia.Name = "GridExistencia"
        Me.GridExistencia.RecordNavigator = True
        Me.GridExistencia.Size = New System.Drawing.Size(483, 242)
        Me.GridExistencia.TabIndex = 2
        Me.GridExistencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Controls.Add(Me.cmbTipoEstado)
        Me.GroupBox2.Controls.Add(Me.txtPosicion)
        Me.GroupBox2.Controls.Add(Me.GridUbicaciones)
        Me.GroupBox2.Controls.Add(Me.BtnAgregaUB)
        Me.GroupBox2.Controls.Add(Me.BtnEliminaUB)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(205, 269)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ubicación"
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Enabled = False
        Me.cmbTipoEstado.Location = New System.Drawing.Point(8, 66)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(189, 21)
        Me.cmbTipoEstado.TabIndex = 7
        '
        'txtPosicion
        '
        Me.txtPosicion.Location = New System.Drawing.Point(6, 40)
        Me.txtPosicion.Name = "txtPosicion"
        Me.txtPosicion.Size = New System.Drawing.Size(151, 23)
        Me.txtPosicion.TabIndex = 22
        Me.txtPosicion.Text = "Tipo de Estructura"
        '
        'GridUbicaciones
        '
        Me.GridUbicaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUbicaciones.ColumnAutoResize = True
        Me.GridUbicaciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridUbicaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridUbicaciones.GroupByBoxVisible = False
        Me.GridUbicaciones.Location = New System.Drawing.Point(8, 93)
        Me.GridUbicaciones.Name = "GridUbicaciones"
        Me.GridUbicaciones.RecordNavigator = True
        Me.GridUbicaciones.Size = New System.Drawing.Size(189, 168)
        Me.GridUbicaciones.TabIndex = 2
        Me.GridUbicaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregaUB
        '
        Me.BtnAgregaUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregaUB.Icon = CType(resources.GetObject("BtnAgregaUB.Icon"), System.Drawing.Icon)
        Me.BtnAgregaUB.Location = New System.Drawing.Point(162, 12)
        Me.BtnAgregaUB.Name = "BtnAgregaUB"
        Me.BtnAgregaUB.Size = New System.Drawing.Size(35, 22)
        Me.BtnAgregaUB.TabIndex = 18
        Me.BtnAgregaUB.ToolTipText = "Agregar nueva ubicación"
        Me.BtnAgregaUB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminaUB
        '
        Me.BtnEliminaUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaUB.Icon = CType(resources.GetObject("BtnEliminaUB.Icon"), System.Drawing.Icon)
        Me.BtnEliminaUB.Location = New System.Drawing.Point(125, 12)
        Me.BtnEliminaUB.Name = "BtnEliminaUB"
        Me.BtnEliminaUB.Size = New System.Drawing.Size(32, 22)
        Me.BtnEliminaUB.TabIndex = 20
        Me.BtnEliminaUB.ToolTipText = "Elimina ubicación seleccionada"
        Me.BtnEliminaUB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Controls.Add(Me.GridPosiciones)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(710, 192)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Posición Dentro de la Estructura"
        '
        'GridPosiciones
        '
        Me.GridPosiciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPosiciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPosiciones.ColumnAutoResize = True
        Me.GridPosiciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPosiciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPosiciones.Location = New System.Drawing.Point(8, 16)
        Me.GridPosiciones.Name = "GridPosiciones"
        Me.GridPosiciones.RecordNavigator = True
        Me.GridPosiciones.Size = New System.Drawing.Size(694, 168)
        Me.GridPosiciones.TabIndex = 1
        Me.GridPosiciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminaPos
        '
        Me.BtnEliminaPos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaPos.Icon = CType(resources.GetObject("BtnEliminaPos.Icon"), System.Drawing.Icon)
        Me.BtnEliminaPos.Location = New System.Drawing.Point(755, 90)
        Me.BtnEliminaPos.Name = "BtnEliminaPos"
        Me.BtnEliminaPos.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminaPos.TabIndex = 17
        Me.BtnEliminaPos.Text = "&Eliminar Hueco"
        Me.BtnEliminaPos.ToolTipText = "Elimina hueco seleccionado"
        Me.BtnEliminaPos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificaPos
        '
        Me.BtnModificaPos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificaPos.Icon = CType(resources.GetObject("BtnModificaPos.Icon"), System.Drawing.Icon)
        Me.BtnModificaPos.Location = New System.Drawing.Point(755, 48)
        Me.BtnModificaPos.Name = "BtnModificaPos"
        Me.BtnModificaPos.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificaPos.TabIndex = 16
        Me.BtnModificaPos.Text = "&Modificar Hueco"
        Me.BtnModificaPos.ToolTipText = "Modificar hueco seleccionado"
        Me.BtnModificaPos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnZona
        '
        Me.BtnZona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnZona.Icon = CType(resources.GetObject("BtnZona.Icon"), System.Drawing.Icon)
        Me.BtnZona.Location = New System.Drawing.Point(755, 132)
        Me.BtnZona.Name = "BtnZona"
        Me.BtnZona.Size = New System.Drawing.Size(90, 37)
        Me.BtnZona.TabIndex = 23
        Me.BtnZona.Text = "Asignar &Zona"
        Me.BtnZona.ToolTipText = "Asignar Zona"
        Me.BtnZona.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelFila
        '
        Me.btnDelFila.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelFila.Image = Global.Selling.My.Resources.Resources._1452742829_Delete_Row
        Me.btnDelFila.Location = New System.Drawing.Point(755, 300)
        Me.btnDelFila.Name = "btnDelFila"
        Me.btnDelFila.Size = New System.Drawing.Size(90, 37)
        Me.btnDelFila.TabIndex = 160
        Me.btnDelFila.Text = "Elimina Fila"
        Me.btnDelFila.ToolTipText = "Elimina la ultima Fila"
        Me.btnDelFila.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelCol
        '
        Me.btnDelCol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCol.Image = Global.Selling.My.Resources.Resources._1452742935_Delete_Column
        Me.btnDelCol.Location = New System.Drawing.Point(755, 216)
        Me.btnDelCol.Name = "btnDelCol"
        Me.btnDelCol.Size = New System.Drawing.Size(90, 37)
        Me.btnDelCol.TabIndex = 159
        Me.btnDelCol.Text = "Elimina Columna"
        Me.btnDelCol.ToolTipText = "Elimina la ultima Columna"
        Me.btnDelCol.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImportar.Location = New System.Drawing.Point(755, 384)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(90, 37)
        Me.btnImportar.TabIndex = 158
        Me.btnImportar.Text = "Existencia"
        Me.btnImportar.ToolTipText = "Importar existencia"
        Me.btnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddFila
        '
        Me.btnAddFila.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddFila.Image = Global.Selling.My.Resources.Resources._1450431918_Add_Row
        Me.btnAddFila.Location = New System.Drawing.Point(755, 258)
        Me.btnAddFila.Name = "btnAddFila"
        Me.btnAddFila.Size = New System.Drawing.Size(90, 37)
        Me.btnAddFila.TabIndex = 26
        Me.btnAddFila.Text = "Agregar &Fila"
        Me.btnAddFila.ToolTipText = "Agregar Fila"
        Me.btnAddFila.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddCol
        '
        Me.btnAddCol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCol.Image = Global.Selling.My.Resources.Resources._1450431865_Add_Column
        Me.btnAddCol.Location = New System.Drawing.Point(755, 174)
        Me.btnAddCol.Name = "btnAddCol"
        Me.btnAddCol.Size = New System.Drawing.Size(90, 37)
        Me.btnAddCol.TabIndex = 25
        Me.btnAddCol.Text = "Agregar &Columna"
        Me.btnAddCol.ToolTipText = "Agregar Columna"
        Me.btnAddCol.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEtiquetas
        '
        Me.BtnEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEtiquetas.Image = Global.Selling.My.Resources.Resources._1450431970_barcode
        Me.BtnEtiquetas.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnEtiquetas.Location = New System.Drawing.Point(755, 342)
        Me.BtnEtiquetas.Name = "BtnEtiquetas"
        Me.BtnEtiquetas.Size = New System.Drawing.Size(90, 37)
        Me.BtnEtiquetas.TabIndex = 24
        Me.BtnEtiquetas.Text = "&Etiqueta"
        Me.BtnEtiquetas.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnEtiquetas.ToolTipText = "Imprime etiquetas de código de barras de las ubicaciones"
        Me.BtnEtiquetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Icon = CType(resources.GetObject("btnImprimir.Icon"), System.Drawing.Icon)
        Me.btnImprimir.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImprimir.Location = New System.Drawing.Point(754, 424)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.btnImprimir.TabIndex = 161
        Me.btnImprimir.Text = "Existencia"
        Me.btnImprimir.ToolTipText = "Imprimir existencia"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.Location = New System.Drawing.Point(512, 21)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(176, 21)
        Me.cmbAplicacion.TabIndex = 133
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(376, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Tipo de Aplicación"
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(696, 16)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox17.TabIndex = 134
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'FrmEstructura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(854, 513)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnDelFila)
        Me.Controls.Add(Me.btnDelCol)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnAddFila)
        Me.Controls.Add(Me.btnAddCol)
        Me.Controls.Add(Me.UiTabEstructura)
        Me.Controls.Add(Me.BtnEtiquetas)
        Me.Controls.Add(Me.BtnZona)
        Me.Controls.Add(Me.BtnModificaPos)
        Me.Controls.Add(Me.BtnEliminaPos)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 479)
        Me.Name = "FrmEstructura"
        Me.Text = "Estructura"
        CType(Me.UiTabEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabEstructura.ResumeLayout(False)
        Me.UiTabPageEst.ResumeLayout(False)
        Me.GrpPosicion.ResumeLayout(False)
        Me.GrpPosicion.PerformLayout()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDimensiones.ResumeLayout(False)
        Me.GrpDimensiones.PerformLayout()
        CType(Me.NumNiveles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpEstructura.ResumeLayout(False)
        Me.GrpEstructura.PerformLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPageUbc.ResumeLayout(False)
        Me.GrpContenido.ResumeLayout(False)
        CType(Me.GridExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridUbicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridPosiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public iTESTClave As Integer = 0
    Public iTipoAplicacion As Integer = 1
    Public sAlmacen As String = ""
    Public sArea As String = ""
    'Public sCpyNombre As String
    Public sColoca As String = ""
    Public sRecoge As String = ""
    Public iRotacion As Integer
    Public dAncho As Double
    Public dX As Double
    Public dY As Double
    Public Rotada As Boolean
    Public Clave As String
    Public ID As String
    Public dAlto As Double
    Public dLargo As Double
    Public iColumna As Integer = 1
    Public iNiveles As Integer = 1
    Public iEstado As Integer
    Public iformaEnvioInicial As Integer = 0
    Public iformaEnviofinal As Integer = 99
    Public iSecuenciaRecoleccion As Integer = 0
    Public Padre As String
    Public Grabado As Boolean = False

    Public iColor As Integer

    Private sHuecoSelected As String
    Private sUbicacionSelected, sUbicacion, InterfazSalida As String
    Private bUbicacionLoad As Boolean = False
    Public sSUCClave As String

    Private alerta(16) As PictureBox
    Private reloj As parpadea
    Private bLoad As Boolean = False
    Private Cargado As Boolean = False
    Private dtHuecos, dtExistencia, dtUbicacion, dtTipoEstado As DataTable


    Private Sub FrmEstructura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.Grabado Then
            ModPOS.Estructuras.Dispose()
            ModPOS.Estructuras = Nothing
        Else
            If Me.Padre = "Agregar" Then
                Beep()
                Select Case MessageBox.Show("Se cerrara la ventana actual sin guardar los cambios", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes

                        If ModPOS.Est_Selected <> -1 Then
                            ModPOS.vector(ModPOS.Est_Selected).Dispose()

                            'Se actualiza el indice que indica la estructura seleccionada.

                            ModPOS.numEst_Vector -= 1
                            ModPOS.Est_Selected = -1
                            'ModPOS.Ult_Cve_Est -= 1

                            If ModPOS.numEst_Vector >= 2 Then
                                ReDim Preserve vector(vector.Length - 1)
                            End If

                        End If

                        ModPOS.Estructuras.Dispose()
                        ModPOS.Estructuras = Nothing


                    Case DialogResult.No
                        e.Cancel = True
                End Select
            Else
                ModPOS.Estructuras.Dispose()
                ModPOS.Estructuras = Nothing
            End If
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim p1, p2 As Point
        Dim i As Integer

        If validaForm() Then
            Select Case Me.Padre
                Case "Nuevo"

                    p1.X = CInt(Me.TxtPosX.Text) * ModPOS.EscalaActual
                    p1.Y = CInt(Me.TxtPosY.Text) * ModPOS.EscalaActual
                    p2.X = p1.X + (CInt(Me.TxtLargo.Text) * ModPOS.EscalaActual)
                    p2.Y = p1.Y + (CInt(Me.TxtAncho.Text) * ModPOS.EscalaActual)

                    ModPOS.Superficie.NuevaEstructura(p1, p2)

                    ModPOS.Est_Selected = ModPOS.numEst_Vector - 1

                    ID = UCase(Trim(Me.TxtID.Text))

                    With ModPOS.vector(ModPOS.Est_Selected)

                        If Me.CmbArea.SelectedValue Is Nothing Then
                            .AREClave = ""
                            iColor = .BackColor.ToArgb()
                        Else
                            .AREClave = Me.CmbArea.SelectedValue
                            iColor = recuperaColor(CmbArea.SelectedValue)
                            .BackColor = System.Drawing.Color.FromArgb(Me.iColor)
                        End If

                        Me.Clave = ModPOS.vector(ModPOS.Est_Selected).Name

                        .TSTClave = CStr(Me.CmbEstructura.SelectedValue)
                        .TipoAplicacion = CInt(cmbAplicacion.SelectedValue)
                        .Clave = ID
                        .PasilloColoca = CStr(Me.CmbColoca.SelectedValue)

                        .PasilloRecoge = CStr(Me.CmbRecolecta.SelectedValue)

                        .TipoRotacion = CInt(Me.CmbRotacion.SelectedValue)

                        .Alto = CDbl(Me.TxtAlto.Text)
                        .Ancho = CDbl(Me.TxtAncho.Text)
                        .Largo = CDbl(Me.TxtLargo.Text)
                        .Columnas = CInt(Me.TxtColumnas.Text)
                        .Niveles = CInt(NumNiveles.Value)
                        .OrigenX = CDbl(Me.TxtPosX.Text)
                        .OrigenY = CDbl(Me.TxtPosY.Text)
                        .Color = Me.iColor
                        .SecuenciaRecoleccion = CInt(TxtSecuencia.Text)

                        If CmbEstructura.SelectedValue = 2 Then
                            .formaEnviofinal = cmbRangoIni.SelectedValue
                            .formaEnviofinal = cmbRangoFin.SelectedValue
                        End If


                        ModPOS.Graba_Estructura(ModPOS.vector(ModPOS.Est_Selected))

                        ModPOS.vector(ModPOS.numEst_Vector - 1).Image = ModPOS.ImageAddText(ModPOS.vector(ModPOS.numEst_Vector - 1), ModPOS.vector(ModPOS.numEst_Vector - 1).Clave)


                        Me.UiTabPageUbc.Enabled = True
                        Me.UiTabPageUbc.Show()

                        Padre = "Modificar"

                    End With


                    Me.Grabado = True
                Case "Agregar"
                    ID = UCase(Trim(Me.TxtID.Text))

                    With ModPOS.vector(ModPOS.Est_Selected)


                        If Me.CmbArea.SelectedValue Is Nothing Then
                            .AREClave = ""
                            iColor = -1
                            .BackColor = System.Drawing.Color.White
                        Else
                            .AREClave = Me.CmbArea.SelectedValue
                            iColor = recuperaColor(CmbArea.SelectedValue)
                            .BackColor = System.Drawing.Color.FromArgb(Me.iColor)
                        End If

                        .TSTClave = CStr(Me.CmbEstructura.SelectedValue)
                        .TipoAplicacion = CInt(cmbAplicacion.SelectedValue)
                        .Clave = ID
                        .PasilloColoca = CStr(Me.CmbColoca.SelectedValue)
                        .PasilloRecoge = CStr(Me.CmbRecolecta.SelectedValue)
                        .TipoRotacion = CInt(Me.CmbRotacion.SelectedValue)

                        If ModPOS.vector(ModPOS.Est_Selected).Rotada Then
                            .Height = CInt(CDbl(Me.TxtLargo.Text) * ModPOS.EscalaActual)
                            .Width = CInt(CDbl(Me.TxtAncho.Text) * ModPOS.EscalaActual)
                        Else
                            .Width = CInt(CDbl(Me.TxtLargo.Text) * ModPOS.EscalaActual)
                            .Height = CInt(CDbl(Me.TxtAncho.Text) * ModPOS.EscalaActual)
                        End If

                        .Alto = CDbl(Me.TxtAlto.Text)
                        .Largo = CDbl(Me.TxtLargo.Text)
                        .Ancho = CDbl(Me.TxtAncho.Text)
                        .Columnas = CInt(Me.TxtColumnas.Text)
                        .Niveles = CInt(NumNiveles.Value)
                        .OrigenX = CDbl(Me.TxtPosX.Text)
                        .OrigenY = CDbl(Me.TxtPosY.Text)
                        p1.X = CInt(.OrigenX) * ModPOS.EscalaActual
                        p1.Y = CInt(.OrigenY) * ModPOS.EscalaActual
                        .Location = p1
                        .Color = Me.iColor
                        .SecuenciaRecoleccion = CInt(TxtSecuencia.Text)

                        If CmbEstructura.SelectedValue = 2 Then
                            .formaEnviofinal = cmbRangoIni.SelectedValue
                            .formaEnviofinal = cmbRangoFin.SelectedValue
                        End If

                        ModPOS.Graba_Estructura(ModPOS.vector(ModPOS.Est_Selected))

                        ModPOS.vector(ModPOS.numEst_Vector - 1).Image = ModPOS.ImageAddText(ModPOS.vector(ModPOS.numEst_Vector - 1), ModPOS.vector(ModPOS.numEst_Vector - 1).Clave)

                        Me.UiTabPageUbc.Enabled = True
                        Me.UiTabPageUbc.Show()

                        CmbEstructura.Enabled = False
                        TxtID.ReadOnly = True
                        TxtAlto.ReadOnly = True
                        TxtAlto.BackColor = System.Drawing.SystemColors.InactiveCaption
                        TxtLargo.ReadOnly = True
                        TxtLargo.BackColor = System.Drawing.SystemColors.InactiveCaption
                        TxtColumnas.ReadOnly = True
                        TxtColumnas.BackColor = System.Drawing.SystemColors.InactiveCaption
                        NumNiveles.ReadOnly = True
                        NumNiveles.BackColor = System.Drawing.SystemColors.InactiveCaption


                        Padre = "Modificar"

                    End With


                    Me.Grabado = True
                Case "Modificar"

                    If Not dtUbicacion Is Nothing AndAlso dtUbicacion.Rows.Count >= 1 Then
                        Dim foundRows() As DataRow
                        foundRows = dtUbicacion.Select("Actualizado = 1")
                        If foundRows.GetLength(0) > 0 Then
                            For i = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_act_ubicacion", "@UBCClave", foundRows(i)("UBCClave"), "@Ubicacion", foundRows(i)("Ubicación"), "@Volumen", foundRows(i)("Volumen(cm3)"), "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If
                    End If


                    If Not dtExistencia Is Nothing AndAlso dtExistencia.Rows.Count >= 1 Then
                        Dim foundRows() As DataRow
                        foundRows = dtExistencia.Select("Actualizado = 1")
                        If foundRows.GetLength(0) > 0 Then

                            Dim sFecha As String

                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            Dim Referencia As String = ModPOS.obtenerLlave
                            Dim cantCambioEdo As Double = 0

                            For i = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_bloqueo_ubc", "@ALMClave", sAlmacen, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Estado", foundRows(i)("Estado"), "@Usuario", ModPOS.UsuarioActual)



                                If foundRows(i)("Estado") = 0 Then
                                    cantCambioEdo = foundRows(i)("Existencia") - foundRows(i)("Apartado") - foundRows(i)("Bloqueado")
                                Else
                                    cantCambioEdo = foundRows(i)("Bloqueado")
                                End If


                                ModPOS.Ejecuta("st_cambio_estado", _
                                               "@SUCClave", sSUCClave, _
                                               "@ALMClave", sAlmacen, _
                                               "@UBCClave", foundRows(i)("UBCClave"), _
                                               "@PROClave", foundRows(i)("PROClave"), _
                                               "@Cantidad", cantCambioEdo, _
                                               "@Estado", foundRows(i)("Estado"), _
                                               "@Referencia", Referencia, _
                                               "@Usuario", ModPOS.UsuarioActual)



                            Next


                            'Interfaz Cambio Estado
                            If InterfazSalida <> "" Then
                                Dim dtInterfaz As DataTable

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CambioEstado", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                End If
                            End If

                            cargaContenido()

                        End If
                    End If

                    If SiModifica() Then

                        Dim ModificarAncho As Boolean
                        If Math.Round(CDbl(TxtAncho.Text), 2) = Math.Round(dAncho, 2) Then
                            ModificarAncho = False
                        Else
                            ModificarAncho = True
                        End If

                        Dim Con As String = ModPOS.BDConexion
                        If Math.Round(CDbl(TxtAncho.Text), 2) >= Math.Round(dAncho, 2) Then
                            'AndAlso ModPOS.SiExite(Con, "sp_estructura_vacia", "@Estructura", Clave) = 0 Then
                            If Me.CmbArea.SelectedValue Is Nothing Then
                                sArea = ""
                                iColor = -1
                            Else
                                sArea = Me.CmbArea.SelectedValue
                                iColor = recuperaColor(CmbArea.SelectedValue)
                            End If

                            ID = UCase(Trim(TxtID.Text))
                            sColoca = CmbColoca.SelectedValue
                            sRecoge = CmbRecolecta.SelectedValue
                            iRotacion = CmbRotacion.SelectedValue
                            dAncho = CDbl(TxtAncho.Text)
                            dX = CDbl(TxtPosX.Text)
                            dY = CDbl(TxtPosY.Text)
                            iSecuenciaRecoleccion = CInt(TxtSecuencia.Text)
                            iTipoAplicacion = cmbAplicacion.SelectedValue
                            If CmbEstructura.SelectedValue = 2 Then
                                iformaEnvioInicial = cmbRangoIni.SelectedValue
                                iformaEnviofinal = cmbRangoFin.SelectedValue
                            End If

                            ModPOS.Update_Estructura(Me, Clave, ModificarAncho)

                            If Not ModPOS.MtoEstructura Is Nothing Then
                                ModPOS.ActualizaGrid(True, ModPOS.MtoEstructura.GridEstructuras, "sp_muestra_estructuras", "@almacen", ModPOS.MtoEstructura.CmbAlmacen.SelectedValue, "@area", "Todos")
                                ModPOS.MtoEstructura.GridEstructuras.RootTable.Columns("ESTClave").Visible = False
                            End If

                            If Not ModPOS.Superficie Is Nothing Then
                                If Superficie.ALMClave = Me.sAlmacen Then
                                    i = 0
                                    While i <= ModPOS.numEst_Vector
                                        If ModPOS.vector(i).Name = Clave Then
                                            With ModPOS.vector(ModPOS.Est_Selected)

                                                If Me.CmbArea.SelectedValue Is Nothing Then
                                                    .AREClave = ""
                                                    iColor = -1
                                                    .BackColor = System.Drawing.Color.White
                                                Else
                                                    .AREClave = Me.CmbArea.SelectedValue
                                                    iColor = recuperaColor(CmbArea.SelectedValue)
                                                    .BackColor = System.Drawing.Color.FromArgb(Me.iColor)
                                                End If

                                                .Clave = UCase(Trim(Me.TxtID.Text))
                                                .PasilloColoca = CStr(Me.CmbColoca.SelectedValue)
                                                .PasilloRecoge = CStr(Me.CmbRecolecta.SelectedValue)
                                                .TipoRotacion = CInt(Me.CmbRotacion.SelectedValue)

                                                If ModPOS.vector(ModPOS.Est_Selected).Rotada Then
                                                    .Width = CInt(CDbl(Me.TxtAncho.Text) * ModPOS.EscalaActual)
                                                Else
                                                    .Height = CInt(CDbl(Me.TxtAncho.Text) * ModPOS.EscalaActual)
                                                End If

                                                .Ancho = CDbl(Me.TxtAncho.Text)
                                                .OrigenX = CDbl(Me.TxtPosX.Text)
                                                .OrigenY = CDbl(Me.TxtPosY.Text)
                                                p1.X = CInt(.OrigenX) * ModPOS.EscalaActual
                                                p1.Y = CInt(.OrigenY) * ModPOS.EscalaActual
                                                .Location = p1
                                                .Color = Me.iColor
                                                .SecuenciaRecoleccion = CInt(Me.TxtSecuencia.Text)
                                                .TipoAplicacion = Me.iTipoAplicacion
                                                If CmbEstructura.SelectedValue = 2 Then
                                                    .formaEnvioInicial = cmbRangoIni.SelectedValue
                                                    .formaEnvioFinal = cmbRangoFin.SelectedValue
                                                End If

                                            End With
                                            Exit While
                                        End If
                                        i += 1
                                    End While
                                End If
                            End If

                        Else
                            MsgBox("No se puede Modificar el Ancho porque existen Ubicaciones Ocupadas o Apartadas")
                        End If

                    End If
            End Select

            Me.Grabado = True
        Else

            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmEstructura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtParam As DataTable
        Dim i As Integer



        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                        Exit Select
                End Select
            Next
        End With
        dtParam.Dispose()




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

        Me.Grabado = False



        With Me.CmbEstructura
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Estructura"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With



        With Me.cmbAplicacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Estructura"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoAplicacion"
            .llenar()
        End With

        With cmbTipoEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Hueco"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With

        With Me.CmbRotacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Estructura"
            .NombreParametro2 = "campo"
            .Parametro2 = "Rotacion"
            .llenar()
        End With


        With Me.CmbArea
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_areas"
            .NombreParametro1 = "ALMClave"
            .Parametro1 = sAlmacen
            .llenar()
        End With

        With Me.CmbColoca
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_pasillo"
            .NombreParametro1 = "ALMClave"
            .Parametro1 = sAlmacen
            .llenar()
        End With

        With Me.CmbRecolecta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_pasillo"
            .NombreParametro1 = "ALMClave"
            .Parametro1 = sAlmacen
            .llenar()
        End With

        With Me.cmbRangoIni
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "formaEnvio"
            .llenar()
        End With


        With Me.cmbRangoFin
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "formaEnvio"
            .llenar()
        End With


        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", sAlmacen)

        Me.sSUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))

        dt.Dispose()

        If Padre = "Modificar" Then
            CmbEstructura.Enabled = False
            TxtID.ReadOnly = True
            TxtAlto.ReadOnly = True
            TxtAlto.BackColor = System.Drawing.SystemColors.InactiveCaption
            TxtLargo.ReadOnly = True
            TxtLargo.BackColor = System.Drawing.SystemColors.InactiveCaption
            TxtColumnas.ReadOnly = True
            TxtColumnas.BackColor = System.Drawing.SystemColors.InactiveCaption
            NumNiveles.ReadOnly = True
            NumNiveles.BackColor = System.Drawing.SystemColors.InactiveCaption
        Else

            dt = ModPOS.Recupera_Tabla("sp_calcula_estclave", "@ALMClave", sAlmacen)
            ID = dt.Rows(0)("Clave")
            dt.Dispose()
        End If

        TxtID.Text = ID
        'sCpyNombre = ID
        CmbArea.SelectedValue = sArea

        CmbEstructura.SelectedValue = iTESTClave
        cmbAplicacion.SelectedValue = iTipoAPlicacion
        CmbColoca.SelectedValue = sColoca
        CmbRecolecta.SelectedValue = sRecoge
        CmbRotacion.SelectedValue = iRotacion

        TxtAncho.Text = dAncho
        TxtPosX.Text = dX
        TxtPosY.Text = dY

        TxtAlto.Text = dAlto
        TxtLargo.Text = dLargo

        TxtColumnas.Text = iColumna
        NumNiveles.Value = iNiveles

        cmbRangoIni.SelectedValue = iformaEnvioInicial
        cmbRangoFin.SelectedValue = iformaEnviofinal

        TxtSecuencia.Text = iSecuenciaRecoleccion

        If MyProfile <> "SUPER" Then
            BtnZona.Enabled = False
            btnImportar.Enabled = False
            BtnEliminaPos.Enabled = False
            btnAddCol.Enabled = False
            btnAddFila.Enabled = False
            btnDelCol.Enabled = False
            btnDelFila.Enabled = False
        End If

        If CmbEstructura.SelectedValue = 1 Then
            TxtColumnas.Enabled = True
            NumNiveles.Enabled = True

            BtnEliminaPos.Enabled = True
            GridExistencia.Enabled = True
            BtnAgregaUB.Enabled = True
            BtnEliminaUB.Enabled = True

            If MyProfile = "SUPER" Then
                BtnZona.Enabled = True
                btnImportar.Enabled = True
                BtnEliminaPos.Enabled = True
                btnAddCol.Enabled = True
                btnAddFila.Enabled = True
                btnDelCol.Enabled = True
                btnDelFila.Enabled = True
            End If
        Else

            If CmbEstructura.SelectedValue = 2 Then
                lblRangofin.Visible = True
                cmbRangoFin.Visible = True
                lblRangoIni.Visible = True
                cmbRangoIni.Visible = True
            Else
                lblRangofin.Visible = False
                cmbRangoFin.Visible = False
                lblRangoIni.Visible = False
                cmbRangoIni.Visible = False
            End If

            btnDelCol.Enabled = False
            btnDelFila.Enabled = False
            btnAddCol.Enabled = False
            btnAddFila.Enabled = False
            BtnEliminaPos.Enabled = False

            If CmbEstructura.SelectedValue <> 2 Then
                GridExistencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
            
            If CmbEstructura.SelectedValue = 0 OrElse CmbEstructura.SelectedValue = 2 Then
                BtnAgregaUB.Enabled = False
                BtnEliminaUB.Enabled = False

            End If

            TxtColumnas.Text = 1
            NumNiveles.Value = 1
            TxtColumnas.Enabled = False
            NumNiveles.Enabled = False
        End If

       

        Cargado = True
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbEstructura.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        Else
            If CmbEstructura.SelectedValue = 2 Then
                If Me.cmbRangoIni.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(14))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                If Me.cmbRangoFin.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(15))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            End If
        End If

        If cmbAplicacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtID.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtID.Text.Length > 40 Then
            Me.TxtID.Text = Me.TxtID.Text.Substring(0, 40)

        End If

        If Me.CmbColoca.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbRecolecta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbRotacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbArea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtAlto.Text = "" OrElse CDbl(Me.TxtAlto.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLargo.Text = "" OrElse CDbl(Me.TxtLargo.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtAncho.Text = "" OrElse CDbl(Me.TxtAncho.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColumnas.Text = "" OrElse CInt(Me.TxtColumnas.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtPosX.Text = "" OrElse CDbl(Me.TxtPosX.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtPosY.Text = "" OrElse CDbl(Me.TxtPosY.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

       

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" OrElse Padre = "Nuevo" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_estructura", "@ALMClave", sAlmacen, "@Clave", Me.TxtID.Text.ToUpper.Trim) > 0 Then
                Beep()
                MessageBox.Show("La Clave que intenta agregar ya existe en el sistema para el Almacén actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(1))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If


    End Function

    Private Function SiModifica() As Boolean

        Dim Area As String

        If Me.CmbArea.SelectedValue Is Nothing Then
            Area = ""
        Else
            Area = Me.CmbArea.SelectedValue
        End If

        If Area = sArea AndAlso _
            cmbAplicacion.SelectedValue = iTipoAplicacion AndAlso _
        UCase(Trim(TxtID.Text)) = ID AndAlso _
        CmbColoca.SelectedValue = sColoca AndAlso _
        CmbRecolecta.SelectedValue = sRecoge AndAlso _
        CmbRotacion.SelectedValue = iRotacion AndAlso _
        Math.Round(CDbl(TxtAncho.Text), 2) = Math.Round(dAncho, 2) AndAlso _
        CDbl(TxtPosX.Text) = dX AndAlso _
        CDbl(TxtPosY.Text) = dY AndAlso _
        cmbRangoFin.SelectedValue = iformaEnviofinal AndAlso _
        cmbRangoIni.SelectedValue = iformaEnvioInicial AndAlso _
        TxtSecuencia.Text = iSecuenciaRecoleccion Then
            Return False

        Else
            Return True

        End If
    End Function

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Select Case Me.Padre
            Case "Nuevo"
                If Me.Grabado Then
                    Me.Close()
                Else
                    Beep()
                    Select Case MessageBox.Show("Se cerrara la ventana actual sin guardar los cambios", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Case DialogResult.Yes
                            Me.Close()
                        Case DialogResult.No
                    End Select
                End If

            Case "Agregar"

                Me.Close()

            Case "Modificar"
                If Me.Grabado Then
                    Me.Close()
                Else
                    If SiModifica() Then
                        Beep()
                        Select Case MessageBox.Show("Se cerrara la ventana actual sin guardar los cambios", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            Case DialogResult.Yes
                                Me.Close()
                            Case DialogResult.No
                        End Select
                    Else
                        Me.Close()
                    End If
                End If
        End Select
    End Sub

    Private Sub cargaPosiciones()
        dtHuecos = New DataTable("Huecos")
        Dim i As Integer
        For i = 1 To CInt(Me.TxtColumnas.Text)
            dtHuecos.Columns.Add(CStr(i), Type.GetType("System.String"))
        Next

        Dim dtObjetos As DataTable

        dtObjetos = ModPOS.Recupera_Tabla("sp_muestra_huecos", "@Estructura", Clave)

        Dim foundRows() As DataRow


        Dim y As Integer

        If dtObjetos.Rows.Count > 0 Then
            For i = CInt(NumNiveles.Value) To 1 Step -1
                foundRows = dtObjetos.Select("Nivel = " & CStr(i))
                If foundRows.GetLength(0) > 0 Then
                    Dim row1 As DataRow
                    row1 = dtHuecos.NewRow()
                    For y = 0 To foundRows.GetUpperBound(0)
                        row1.Item(y) = IIf(foundRows(y)("Posición") = "", "", IIf(CStr(foundRows(y)("Columna")).Length = 1, "0", "") + CStr(foundRows(y)("Columna")) & "-" & CStr(foundRows(y)("cNivel")))
                    Next
                    dtHuecos.Rows.Add(row1)
                End If
            Next
        End If


        GridPosiciones.DataSource = dtHuecos
        GridPosiciones.RetrieveStructure(True)
        GridPosiciones.GroupByBoxVisible = False

        bUbicacionLoad = True

        If CmbEstructura.SelectedValue = 1 Then
            Me.BtnAgregaUB.Enabled = True
            Me.BtnEliminaUB.Enabled = True
            Me.BtnEliminaPos.Enabled = True
        End If

        Me.BtnModificaPos.Enabled = True
        Me.BtnZona.Enabled = True

        If Not Me.GridPosiciones.GetValue(0) Is Nothing Then
            sHuecoSelected = IIf(Me.GridPosiciones.GetValue(0).GetType.Name = "DBNull", "", Me.GridPosiciones.GetValue(0))
        Else
            sHuecoSelected = ""
        End If

        cargaUbicaciones(sHuecoSelected, Clave)

        If Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            sUbicacionSelected = Me.GridUbicaciones.GetValue(0)
        Else
            sUbicacionSelected = ""
        End If

    End Sub

    Private Sub UiTabEstructura_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTabEstructura.SelectedTabChanged
        If e.Page.Name = "UiTabPageUbc" Then
            If bUbicacionLoad = False Then
                cargaPosiciones()
            End If
            Me.BtnAgregaUB.Visible = True
            Me.BtnEliminaUB.Visible = True
            Me.BtnModificaPos.Visible = True
            Me.BtnEliminaPos.Visible = True
            Me.BtnZona.Visible = True
            Me.BtnEtiquetas.Visible = True
            btnAddCol.Visible = True
            btnAddFila.Visible = True
            btnImportar.Visible = True
            btnDelCol.Visible = True
            btnDelFila.Visible = True
        Else
            BtnEtiquetas.Visible = False
            Me.BtnAgregaUB.Visible = False
            Me.BtnEliminaUB.Visible = False
            Me.BtnModificaPos.Visible = False
            Me.BtnEliminaPos.Visible = False
            Me.BtnZona.Visible = False
            btnAddCol.Visible = False
            btnAddFila.Visible = False
            btnImportar.Visible = False
            btnDelCol.Visible = False
            btnDelFila.Visible = False
        End If
    End Sub

    Public Sub cargaUbicaciones(ByVal sPosicion As String, ByVal sESTClave As String)

        If Not dtUbicacion Is Nothing AndAlso dtUbicacion.Rows.Count >= 1 Then
            Dim foundRows() As DataRow
            foundRows = dtUbicacion.Select("Actualizado = 1  ")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_act_ubicacion", "@UBCClave", foundRows(i)("UBCClave"), "@Ubicacion", foundRows(i)("Ubicación"), "@Volumen", foundRows(i)("Volumen(cm3)"), "@Usuario", ModPOS.UsuarioActual)
                Next
            End If
        End If

        Dim iColumna As Integer
        Dim sNivel As String
        If sPosicion = "" Then
            iColumna = 0
            sNivel = ""
        Else
            iColumna = CInt(Split(sPosicion, "-")(0))
            sNivel = Split(sPosicion, "-")(1)
        End If

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_hueco", "@ESTClave", Clave, "@Columna", iColumna, "@cNivel", sNivel)
        txtPosicion.Text = "Posición: " & Me.sHuecoSelected

        If sPosicion = "" Then
            Me.BtnAgregaUB.Enabled = False
            Me.BtnEliminaUB.Enabled = False
        Else
            If CmbEstructura.SelectedValue = 1 Then
                Me.BtnEliminaUB.Enabled = True
                Me.BtnAgregaUB.Enabled = True
            End If
        End If

        If dt.Rows.Count = 1 Then
            bLoad = False
            cmbTipoEstado.SelectedValue = dt.Rows(0)("Estado")
            bLoad = True
        End If
        dt.Dispose()


        dtUbicacion = ModPOS.Recupera_Tabla("sp_muestra_ubicaciones", "@Columna", iColumna, "@cNivel", sNivel, "@Estructura", sESTClave)
        GridUbicaciones.DataSource = dtUbicacion
        GridUbicaciones.RetrieveStructure(True)
        GridUbicaciones.GroupByBoxVisible = False
        GridUbicaciones.RootTable.Columns("UBCClave").Visible = False
        GridUbicaciones.RootTable.Columns("Actualizado").Visible = False

        GridUbicaciones.RootTable.Columns("Volumen(cm3)").FormatString = "0.00"
    End Sub

    Private Sub GridPosiciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPosiciones.Click
        If Not GridPosiciones.CurrentColumn Is Nothing Then
            sHuecoSelected = IIf(Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption).GetType.Name = "DBNull", "", Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption))
            cargaUbicaciones(sHuecoSelected, Clave)
        End If
    End Sub

    Private Sub GridPosiciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPosiciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificaPos.PerformClick()
        End If
    End Sub

    Private Sub GridPosiciones_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPosiciones.SelectionChanged
        If bUbicacionLoad = True AndAlso Not Me.GridPosiciones.CurrentColumn Is Nothing Then
            sHuecoSelected = IIf(Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption).GetType.Name = "DBNull", "", Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption))
        Else
            sHuecoSelected = ""
        End If
    End Sub

    Private Sub BtnModificaPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificaPos.Click

        If Not GridPosiciones.CurrentColumn Is Nothing Then
            sHuecoSelected = IIf(Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption).GetType.Name = "DBNull", "", Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption))
        End If

        If sHuecoSelected <> "" Then
            Dim iColumna As Integer
            Dim sNivel As String
            iColumna = CInt(Split(sHuecoSelected, "-")(0))
            sNivel = Split(sHuecoSelected, "-")(1)
            ModificarHueco()

        Else
            MessageBox.Show("Debe seleccionar el hueco que desea modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnAgregaUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregaUB.Click
        If sHuecoSelected <> "" Then
            ModPOS.InsertaUbicacion(Clave, ID, Me.sHuecoSelected, Me.CmbEstructura.SelectedValue)
            cargaUbicaciones(Me.sHuecoSelected, Clave)
        Else
            MessageBox.Show("Debe seleccionar el hueco donde desea insertar la ubicación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnZona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZona.Click
        If ModPOS.AsignarZona Is Nothing Then
            ModPOS.AsignarZona = New FrmAsginarZona
            ModPOS.AsignarZona.Estructura = Clave
        End If
        ModPOS.AsignarZona.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AsignarZona.Show()
        ModPOS.AsignarZona.BringToFront()

    End Sub

    Private Sub ModificarHueco()
        If sHuecoSelected <> "" Then
            If ModPOS.Hueco Is Nothing Then
                ModPOS.Hueco = New FrmHueco
                With ModPOS.Hueco

                    Dim iColumna As Integer
                    Dim sNivel As String
                    If sHuecoSelected = "" Then
                        iColumna = 0
                        sNivel = ""
                    Else
                        iColumna = CInt(Split(sHuecoSelected, "-")(0))
                        sNivel = Split(sHuecoSelected, "-")(1)
                    End If


                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_hueco", "@ESTClave", Clave, "@Columna", iColumna, "@cNivel", sNivel)
                    .InterfazSalida = InterfazSalida
                    .sEstructura = Clave
                    .sHueco = dt.Rows(0)("Posicion")
                    .iColumna = dt.Rows(0)("Columna")
                    .sNivel = dt.Rows(0)("cNivel")
                    .Text = "Posición: " & Me.sHuecoSelected
                    .NumericUpDown1.Value = dt.Rows(0)("Porcentaje")
                    .TxtAlto.Text = CStr(dt.Rows(0)("Alto"))
                    ' .TxtCarga.Text = CStr(Me.GridPosiciones.GetValue("Capacidad(kg)"))
                    .sAlmacen = sAlmacen
                    .sSucursal = sSUCClave
                    Dim sConexion As String

                    sConexion = ModPOS.BDConexion

                    With .cmbTipoEstado
                        .Conexion = sConexion
                        .ProcedimientoAlmacenado = "sp_filtra_valorref"
                        .NombreParametro1 = "tabla"
                        .Parametro1 = "Hueco"
                        .NombreParametro2 = "campo"
                        .Parametro2 = "Estado"
                        .llenar()
                    End With

                    .cmbTipoEstado.SelectedValue = dt.Rows(0)("Estado")
                    .iEstado = dt.Rows(0)("Estado")
                    dt.Dispose()


                End With

            End If
            ModPOS.Hueco.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Hueco.Show()
            ModPOS.Hueco.BringToFront()
        End If
    End Sub

    Private Function recuperaColor(ByVal Area As String) As Integer
        Dim dt As DataTable
        Dim color As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_color", "@area", Area)

        color = dt.Rows(0)("Color")

        dt.Dispose()

        Return (color)

    End Function

    Private Sub BtnEliminaPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaPos.Click
        If Not GridPosiciones.CurrentColumn Is Nothing Then
            sHuecoSelected = IIf(Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption).GetType.Name = "DBNull", "", Me.GridPosiciones.GetValue(GridPosiciones.CurrentColumn.Caption))
        End If
        If sHuecoSelected <> "" Then

            Dim iColumna As Integer
            Dim sNivel As String
            iColumna = CInt(Split(sHuecoSelected, "-")(0))
            sNivel = Split(sHuecoSelected, "-")(1)



            If ModPOS.SiExite(ModPOS.BDConexion, "sp_hueco_vacio", "@Estructura", Clave, "@Columna", iColumna, "@cNivel", sNivel) = 0 Then

                Select Case MessageBox.Show("Se eliminara el hueco :" & sHuecoSelected, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes
                        ModPOS.Ejecuta("sp_elimina_hueco", "@ESTClave", Clave, "@Columna", iColumna, "@cNivel", sNivel)
                        cargaPosiciones()
                End Select

            Else
                MessageBox.Show("No es posible eliminar el hueco debido a que existen ubicaciones ocupadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub BtnEliminaUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaUB.Click
        If sUbicacionSelected <> "" Then
            Dim dt As DataTable
            Dim bVacia As Boolean

            dt = ModPOS.Recupera_Tabla("sp_ubicacion_vacia", "@Ubicacion", sUbicacionSelected)

            If Not dt.Rows(0)("Existencia").GetType.Name = "DBNull" Then
                If dt.Rows(0)("Existencia") > 0 Then
                    bVacia = False
                Else
                    bVacia = True
                End If
            Else
                bVacia = True
            End If
            dt.Dispose()

            If bVacia = True Then
                Select Case MessageBox.Show("Se eliminara la Ubicación :" & sUbicacion, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes
                        ModPOS.Ejecuta("sp_elimina_ubicacion", "@Ubicacion", sUbicacionSelected)

                        cargaUbicaciones(sHuecoSelected, Clave)

                End Select
            Else
                MessageBox.Show("No es posible eliminar la ubicación debido a que tiene existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub cargaContenido()
        GrpContenido.Text = "Existencia en: " & sUbicacion

        If Not dtExistencia Is Nothing AndAlso dtExistencia.Rows.Count >= 1 Then
            Dim foundRows() As DataRow
            foundRows = dtExistencia.Select("Actualizado = 1")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_bloqueo_ubc", "@ALMClave", sAlmacen, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Estado", foundRows(i)("Estado"), "@Usuario", ModPOS.UsuarioActual)
                Next
            End If
        End If

        dtExistencia = ModPOS.Recupera_Tabla("sp_muestra_ubccontenido", "@UBCClave", sUbicacionSelected)
        GridExistencia.DataSource = dtExistencia
        GridExistencia.RetrieveStructure(True)
        GridExistencia.GroupByBoxVisible = False
        GridExistencia.RootTable.Columns("PROClave").Visible = False
        GridExistencia.RootTable.Columns("UBCClave").Visible = False
        GridExistencia.RootTable.Columns("Actualizado").Visible = False
        GridExistencia.CurrentTable.Columns("Estado").HasValueList = True
        GridExistencia.RootTable.Columns("Existencia").FormatString = "0.00"
        GridExistencia.RootTable.Columns("Apartado").FormatString = "0.00"
        GridExistencia.RootTable.Columns("Bloqueado").FormatString = "0.00"


        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridExistencia.Tables(0).Columns("Estado").ValueList
        With AircraftTypeValueListItemCollection

            dtTipoEstado = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "PrdExistUba", "@Campo", "Estado")

            Dim i As Integer

            For i = 0 To dtTipoEstado.Rows.Count - 1
                .Add(dtTipoEstado.Rows(i)("valor"), dtTipoEstado.Rows(i)("descripcion"))
            Next

        End With
        GridExistencia.CurrentTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.Combo

    End Sub

    Private Sub GridUbicaciones_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridUbicaciones.CellEdited
        If GridUbicaciones.CurrentColumn.Caption = "Volumen(cm3)" Then
            If IsNumeric(GridUbicaciones.GetValue("Volumen(cm3)")) AndAlso GridUbicaciones.GetValue("Volumen(cm3)") >= 0 Then
                If GridUbicaciones.GetValue("Ubicación").GetType.Name = "DBNull" OrElse GridUbicaciones.GetValue("Ubicación") = "" Then
                    GridUbicaciones.SetValue("Actualizado", 0)
                Else
                    GridUbicaciones.SetValue("Actualizado", 1)
                End If
            Else
                GridUbicaciones.SetValue("Volumen(cm3)", 0)
                GridUbicaciones.SetValue("Actualizado", 0)
            End If
        ElseIf GridUbicaciones.CurrentColumn.Caption = "Ubicación" Then
            If Not (GridUbicaciones.GetValue("Ubicación").GetType.Name = "DBNull" OrElse GridUbicaciones.GetValue("Ubicación") = "") Then
                If ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_ubc", "@ALMClave", sAlmacen, "@Ubicacion", GridUbicaciones.GetValue("Ubicación"), "@UBCClave", GridUbicaciones.GetValue("UBCClave")) > 0 Then
                    Beep()
                    MessageBox.Show("La Ubicación que intenta agregar ya existe en el sistema para el Almacén actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GridUbicaciones.SetValue("Actualizado", 0)
                    GridUbicaciones.SetValue("Ubicación", "")
                Else
                    GridUbicaciones.SetValue("Actualizado", 1)
                End If
            Else
                GridUbicaciones.SetValue("Actualizado", 0)
            End If
        End If
    End Sub



    Private Sub BtnArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnArea.Click
        If ModPOS.Areas Is Nothing Then
            ModPOS.Areas = New FrmArea
            ModPOS.Areas.Forma = "Estructura"
            ModPOS.Areas.Text = "Agregar Area"
            ModPOS.Areas.MdiParent = ModPOS.Principal
            ModPOS.Areas.Padre = "Agregar"
            ModPOS.Areas.SUCClave = sSUCClave
            ModPOS.Areas.ALMClave = sAlmacen

            ModPOS.Areas.cmbTipoEstado.Enabled = False
            ModPOS.Areas.cmbTipoEstado.Visible = False
            ModPOS.Areas.LblEstado.Visible = False
        End If
        ModPOS.Areas.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Areas.Show()
        ModPOS.Areas.BringToFront()
    End Sub

    Private Sub BtnPasillo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPasillo.Click
        If ModPOS.Pasillo Is Nothing Then
            ModPOS.Pasillo = New FrmPasillo
            ModPOS.Pasillo.Forma = "Estructura"
            With ModPOS.Pasillo
                .Text = "Agregar Pasillo"
                .cmbTipoEstado.Enabled = False
                .cmbAlmacen.Enabled = False
                .Padre = "Agregar"
                .ALMClave = sAlmacen
                .SUCClave = sSUCClave
            End With
        End If
        With ModPOS.Pasillo
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub BtnEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEtiquetas.Click
        Dim a As New FrmPrintLabelCode
        a.COMClave = Clave
        a.iTipoDOc = 3
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub GridExistencia_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridExistencia.CellEdited
        If GridExistencia.CurrentColumn.Caption = "Estado" Then
            GridExistencia.SetValue("Actualizado", 1)
        End If
    End Sub

    Private Sub GridExistencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridExistencia.Click
        If Not GridExistencia.CurrentColumn Is Nothing Then
            If GridExistencia.CurrentColumn.Caption = "Estado" Then
                If CmbEstructura.SelectedValue = 1 OrElse CmbEstructura.SelectedValue = 2 Then
                    GridExistencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                End If
            Else
                GridExistencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub



    Private Sub CmbEstructura_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbEstructura.SelectedValueChanged
        If Cargado AndAlso Not CmbEstructura.SelectedValue Is Nothing Then
            If CmbEstructura.SelectedValue = 1 Then
                TxtColumnas.Enabled = True
                NumNiveles.Enabled = True

                BtnEliminaPos.Enabled = True
                GridExistencia.Enabled = True
                BtnAgregaUB.Enabled = True
                BtnEliminaUB.Enabled = True

                If MyProfile = "SUPER" Then
                    BtnZona.Enabled = True
                    btnImportar.Enabled = True
                    BtnEliminaPos.Enabled = True
                    btnAddCol.Enabled = True
                    btnAddFila.Enabled = True
                    btnDelCol.Enabled = True
                    btnDelFila.Enabled = True
                End If
            Else

                If CmbEstructura.SelectedValue = 2 Then
                    lblRangofin.Visible = True
                    cmbRangoFin.Visible = True
                    lblRangoIni.Visible = True
                    cmbRangoIni.Visible = True
                Else
                    lblRangofin.Visible = False
                    cmbRangoFin.Visible = False
                    lblRangoIni.Visible = False
                    cmbRangoIni.Visible = False
                End If
                btnDelCol.Enabled = False
                btnDelFila.Enabled = False
                btnAddCol.Enabled = False
                btnAddFila.Enabled = False
                BtnEliminaPos.Enabled = False
                If CmbEstructura.SelectedValue <> 2 Then
                    GridExistencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                End If

                If CmbEstructura.SelectedValue = 0 OrElse CmbEstructura.SelectedValue = 2 Then
                    BtnAgregaUB.Enabled = False
                    BtnEliminaUB.Enabled = False
                End If

                TxtColumnas.Text = 1
                NumNiveles.Value = 1
                TxtColumnas.Enabled = False
                NumNiveles.Enabled = False
            End If
        End If
    End Sub


    Private Sub btnAddFila_Click(sender As Object, e As EventArgs) Handles btnAddFila.Click
        Dim iColumna, iNiveles As Integer
        Dim Level As String

        Dim i, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3 As Integer
        Dim Porc As Double


        iColumna = CInt(TxtColumnas.Text)
        iNiveles = CInt(NumNiveles.Value)
        Posicion = iColumna * iNiveles


        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", ModPOS.vector(ModPOS.Est_Selected).TSTClave)

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")
        dt.Dispose()

        With ModPOS.vector(ModPOS.Est_Selected)
            Level = Chr(iNiveles + 65)
            For i = 1 To iColumna

                Posicion += 1
                'inserta posiciones

                ModPOS.Ejecuta("sp_inserta_hueco", "@HUEClave", CStr(Posicion), _
                                                  "@ESTClave", .Name, _
                                                  "@Columna", i, _
                                                  "@Nivel", iNiveles + 1, _
                                                  "@Largo", .Largo / iColumna, _
                                                  "@Ancho", .Ancho, _
                                                  "@Alto", .Alto / iNiveles, _
                                                  "@Porcentaje", Porc, _
                                                  "@cNivel", Level, _
                                                  "@Usuario", ModPOS.UsuarioActual)

                For k = 1 To ubicaciones

                    'inserta ubicaciones 
                    ModPOS.Ejecuta("sp_inserta_ubicacion", _
                                        "@ESTClave", .Name, _
                                        "@Clave", .Clave, _
                                        "@HUEClave", CStr(Posicion), _
                                        "@Ubicacion", CStr(k), _
                                        "@len1", len1, _
                                        "@len2", len2, _
                                        "@len3", len3, _
                                        "@cNivel", Level, _
                                        "@Columna", i, _
                                        "@Usuario", ModPOS.UsuarioActual)



                Next
            Next


            Me.NumNiveles.Value = iNiveles + 1

            .Niveles = iNiveles + 1


            ModPOS.Ejecuta("sp_modifica_estructura", _
                      "@ESTClave", .Name, _
                      "@Columna", .Columnas, _
                      "@Nivel", .Niveles, _
                      "@Usuario", ModPOS.UsuarioActual)
        End With

        cargaPosiciones()

    End Sub

    Private Sub btnAddCol_Click(sender As Object, e As EventArgs) Handles btnAddCol.Click
        Dim iColumna, iNiveles As Integer
        Dim Level As String

        Dim i, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3 As Integer
        Dim Porc As Double


        iColumna = CInt(TxtColumnas.Text)
        iNiveles = CInt(NumNiveles.Value)
        Posicion = iColumna * iNiveles


        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", ModPOS.vector(ModPOS.Est_Selected).TSTClave)

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")
        dt.Dispose()

        With ModPOS.vector(ModPOS.Est_Selected)
            For i = 1 To iNiveles
                Level = Chr(i + 64)

                Posicion += 1
                'inserta posiciones

                ModPOS.Ejecuta("sp_inserta_hueco", "@HUEClave", CStr(Posicion), _
                                                  "@ESTClave", .Name, _
                                                  "@Columna", iColumna + 1, _
                                                  "@Nivel", i, _
                                                  "@Largo", .Largo / iColumna, _
                                                  "@Ancho", .Ancho, _
                                                  "@Alto", .Alto / iNiveles, _
                                                  "@Porcentaje", Porc, _
                                                  "@cNivel", Level, _
                                                  "@Usuario", ModPOS.UsuarioActual)

                For k = 1 To ubicaciones

                    'inserta ubicaciones 
                    ModPOS.Ejecuta("sp_inserta_ubicacion", _
                                        "@ESTClave", .Name, _
                                        "@Clave", .Clave, _
                                        "@HUEClave", CStr(Posicion), _
                                        "@Ubicacion", CStr(k), _
                                        "@len1", len1, _
                                        "@len2", len2, _
                                        "@len3", len3, _
                                        "@cNivel", Level, _
                                        "@Columna", iColumna + 1, _
                                        "@Usuario", ModPOS.UsuarioActual)



                Next
            Next


            TxtColumnas.Text = iColumna + 1

            .Columnas = iColumna + 1


            ModPOS.Ejecuta("sp_modifica_estructura", _
                      "@ESTClave", .Name, _
                      "@Columna", .Columnas, _
                      "@Nivel", .Niveles, _
                      "@Usuario", ModPOS.UsuarioActual)
        End With

        cargaPosiciones()

    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        If sUbicacionSelected <> "" Then
            Dim curFileName As String = ""
            'buscamos la imagen a grabar
            Try
                Dim openDlg As OpenFileDialog = New OpenFileDialog
                openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
                ' Dim filter As String = openDlg.Filter
                openDlg.Title = "Abrir un Archivo de CSV o TXT"
                If (openDlg.ShowDialog() = DialogResult.OK) Then
                    curFileName = openDlg.FileName

                    Dim dtTemporal As DataTable = ReadCSV(curFileName, 2)

                    If dtTemporal.Rows.Count > 0 Then


                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.BringToFront()

                        Dim i As Integer
                        Dim PROClave As String
                        Dim Cantidad As Double

                        Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                                  "Fila", "System.String", _
                                                  "Producto", "System.String", _
                                                  "Cantidad", "System.String", _
                                                  "Error", "System.String")

                        Dim dt As DataTable


                        For i = 0 To dtTemporal.Rows.Count - 1
                            frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                            ' valida el producto
                            If dtTemporal.Rows(i)("GTIN").GetType.FullName <> "System.DBNull" Then
                                dt = Recupera_Tabla("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", dtTemporal.Rows(i)("GTIN").ToString.Replace("'", "''").Trim, "@Char", cReplace)
                                If dt.Rows.Count > 0 Then
                                    PROClave = dt.Rows(0)("PROClave")
                                    dt.Dispose()
                                    ' valida la capacidad gra
                                    If dtTemporal.Rows(i)("Cantidad").GetType.FullName <> "System.DBNull" Then
                                        If IsNumeric(dtTemporal.Rows(i)("Cantidad")) AndAlso CDbl(dtTemporal.Rows(i)("Cantidad")) >= 0 Then
                                            Cantidad = CDbl(dtTemporal.Rows(i)("Cantidad"))
                                            ModPOS.Ejecuta("st_agrega_exist_uba", "@UBCClave", sUbicacionSelected, "@PROClave", PROClave, "@Cantidad", Cantidad, "@ALMClave", Me.sAlmacen, "@Usuario", ModPOS.UsuarioActual)
                                        Else
                                            Dim row1 As DataRow
                                            row1 = dtError.NewRow()
                                            'declara el nombre de la fila
                                            row1.Item("Fila") = i + 1
                                            row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                            row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                            row1.Item("Error") = "El registro actual no cuenta con una existencia valida"
                                            dtError.Rows.Add(row1)
                                        End If
                                    Else
                                        Dim row1 As DataRow
                                        row1 = dtError.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("Fila") = i + 1
                                        row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                        row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                        row1.Item("Error") = "La capacidad de almacenaje se encuentra vacia"
                                        dtError.Rows.Add(row1)
                                    End If
                                Else
                                    dt.Dispose()
                                    Dim row1 As DataRow
                                    row1 = dtError.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("Fila") = i + 1
                                    row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                    row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                    row1.Item("Error") = "La clave de producto no existe"
                                    dtError.Rows.Add(row1)
                                End If
                            Else
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                row1.Item("Error") = "La clave de producto se encuentra vacia"
                                dtError.Rows.Add(row1)
                            End If
                        Next

                        If dtError.Rows.Count > 0 Then
                            MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Dim b As New FrmConsultaGen
                            b.Text = "Errores"
                            b.GridConsultaGen.DataSource = dtError
                            b.GridConsultaGen.RetrieveStructure(True)
                            b.GridConsultaGen.GroupByBoxVisible = False
                            b.ShowDialog()
                            b.Dispose()
                            dtError.Dispose()
                        Else
                            MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                        cargaContenido()
                        frmStatusMessage.Close()
                        Cursor.Current = Cursors.Default
                    Else
                        MessageBox.Show("El archivo no cuenta con el formato: Producto,Existencia o se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Debe seleccionar la ubicación a la cual desea importar la existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub btnDelCol_Click(sender As Object, e As EventArgs) Handles btnDelCol.Click
        Dim iColumna, iNiveles As Integer

        iColumna = CInt(TxtColumnas.Text)
        iNiveles = CInt(NumNiveles.Value)

        If iColumna > 1 Then

            With ModPOS.vector(ModPOS.Est_Selected)
                Dim dt As DataTable

                dt = ModPOS.Recupera_Tabla("st_valida_hueco", _
                                     "@ESTClave", .Name, _
                                     "@Columna", iColumna, _
                                     "@Nivel", iNiveles,
                                     "@Tipo", "C")

                If dt.Rows.Count > 0 Then

                    MessageBox.Show("No es posible elminiar la Columna debido a que no se encuentra vacia o tiene movimientos asociados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If
                dt.Dispose()

                Dim msg As String

                msg = ModPOS.Ejecuta("st_elimina_hueco", _
                                     "@ESTClave", .Name, _
                                     "@Columna", iColumna, _
                                     "@Nivel", iNiveles, _
                                     "@Tipo", "C")

                TxtColumnas.Text = iColumna - 1

                .Columnas = iColumna - 1


                msg = ModPOS.Ejecuta("sp_modifica_estructura", _
                          "@ESTClave", .Name, _
                          "@Columna", .Columnas, _
                          "@Nivel", .Niveles, _
                          "@Usuario", ModPOS.UsuarioActual)


            End With

            cargaPosiciones()


        Else
            MessageBox.Show("No es posible elminiar la unica columna existente en la estructura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelFila_Click(sender As Object, e As EventArgs) Handles btnDelFila.Click
        Dim iColumna, iNiveles As Integer

        iColumna = CInt(TxtColumnas.Text)
        iNiveles = CInt(NumNiveles.Value)

        If iNiveles > 1 Then

            With ModPOS.vector(ModPOS.Est_Selected)
                Dim dt As DataTable

                dt = ModPOS.Recupera_Tabla("st_valida_hueco", _
                                     "@ESTClave", .Name, _
                                     "@Columna", iColumna, _
                                     "@Nivel", iNiveles, _
                                     "@Tipo", "F")

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("No es posible elminiar la fila debido a que no se encuentra vacia o tiene movimientos asociados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                dt.Dispose()

                ModPOS.Ejecuta("st_elimina_hueco", _
                                   "@ESTClave", .Name, _
                                   "@Columna", iColumna, _
                                   "@Nivel", iNiveles, _
                                   "@Tipo", "F")


                Me.NumNiveles.Value = iNiveles - 1

                .Niveles = iNiveles - 1


                ModPOS.Ejecuta("sp_modifica_estructura", _
                          "@ESTClave", .Name, _
                          "@Columna", .Columnas, _
                          "@Nivel", .Niveles, _
                          "@Usuario", ModPOS.UsuarioActual)
            End With

            cargaPosiciones()

        Else
            MessageBox.Show("No es posible elminiar la unica fila existente en la estructura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub GridUbicaciones_Click(sender As Object, e As EventArgs) Handles GridUbicaciones.Click
        If Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            sUbicacionSelected = Me.GridUbicaciones.GetValue(0)
            sUbicacion = Me.GridUbicaciones.GetValue(1)
            cargaContenido()
        Else
            sUbicacion = ""
            sUbicacionSelected = ""
        End If
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_uba", "@ESTClave", ModPOS.vector(ModPOS.Est_Selected).Name))
        OpenReport.PrintPreview("Existencia por Estructura", "CREstructura.rpt", pvtaDataSet, "")
    End Sub

End Class

