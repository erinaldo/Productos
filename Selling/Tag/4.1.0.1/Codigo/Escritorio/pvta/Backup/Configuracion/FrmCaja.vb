Public Class FrmCaja
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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpPDV As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtNombre As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbFase As Selling.StoreCombo
    Friend WithEvents CmbTicket As Selling.StoreCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Almacen As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbImpRec As Selling.StoreCombo
    Friend WithEvents CmbImpFac As Selling.StoreCombo
    Friend WithEvents TxtEfectivo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtVales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtCheque As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmbDevolucion As Selling.StoreCombo
    Friend WithEvents BtnAsociar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtProcesador As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents ChkManual As Selling.ChkStatus
    Friend WithEvents ChkCajon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BtnExplorador As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtAplicacion As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnBorrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbPicking As Selling.StoreCombo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents NumCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkDetallado As Selling.ChkStatus
    Friend WithEvents Label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCaja))
        Me.GrpPDV = New System.Windows.Forms.GroupBox
        Me.ChkDetallado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.NumCopias = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbDevolucion = New Selling.StoreCombo
        Me.cmbPicking = New Selling.StoreCombo
        Me.Label19 = New System.Windows.Forms.Label
        Me.ChkCajon = New System.Windows.Forms.CheckBox
        Me.ChkManual = New Selling.ChkStatus(Me.components)
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.BtnAsociar = New Janus.Windows.EditControls.UIButton
        Me.TxtProcesador = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbImpRec = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Almacen = New System.Windows.Forms.Label
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbTicket = New Selling.StoreCombo
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbFase = New Selling.StoreCombo
        Me.TxtNombre = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.CmbImpFac = New Selling.StoreCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtEfectivo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtVales = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtCheque = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtAplicacion = New System.Windows.Forms.TextBox
        Me.BtnBorrar = New Janus.Windows.EditControls.UIButton
        Me.Label22 = New System.Windows.Forms.Label
        Me.BtnExplorador = New Janus.Windows.EditControls.UIButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GrpPDV.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPDV
        '
        Me.GrpPDV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPDV.Controls.Add(Me.ChkDetallado)
        Me.GrpPDV.Controls.Add(Me.PictureBox2)
        Me.GrpPDV.Controls.Add(Me.NumCopias)
        Me.GrpPDV.Controls.Add(Me.Label4)
        Me.GrpPDV.Controls.Add(Me.CmbDevolucion)
        Me.GrpPDV.Controls.Add(Me.cmbPicking)
        Me.GrpPDV.Controls.Add(Me.Label19)
        Me.GrpPDV.Controls.Add(Me.ChkCajon)
        Me.GrpPDV.Controls.Add(Me.ChkManual)
        Me.GrpPDV.Controls.Add(Me.PictureBox7)
        Me.GrpPDV.Controls.Add(Me.Label3)
        Me.GrpPDV.Controls.Add(Me.CmbAlmacen)
        Me.GrpPDV.Controls.Add(Me.BtnAsociar)
        Me.GrpPDV.Controls.Add(Me.TxtProcesador)
        Me.GrpPDV.Controls.Add(Me.Label15)
        Me.GrpPDV.Controls.Add(Me.PictureBox12)
        Me.GrpPDV.Controls.Add(Me.Label14)
        Me.GrpPDV.Controls.Add(Me.PictureBox9)
        Me.GrpPDV.Controls.Add(Me.PictureBox6)
        Me.GrpPDV.Controls.Add(Me.PictureBox5)
        Me.GrpPDV.Controls.Add(Me.PictureBox4)
        Me.GrpPDV.Controls.Add(Me.PictureBox3)
        Me.GrpPDV.Controls.Add(Me.CmbImpRec)
        Me.GrpPDV.Controls.Add(Me.Label1)
        Me.GrpPDV.Controls.Add(Me.Almacen)
        Me.GrpPDV.Controls.Add(Me.CmbSucursal)
        Me.GrpPDV.Controls.Add(Me.Label10)
        Me.GrpPDV.Controls.Add(Me.CmbTicket)
        Me.GrpPDV.Controls.Add(Me.PictureBox1)
        Me.GrpPDV.Controls.Add(Me.Label5)
        Me.GrpPDV.Controls.Add(Me.cmbFase)
        Me.GrpPDV.Controls.Add(Me.TxtNombre)
        Me.GrpPDV.Controls.Add(Me.ChkEstado)
        Me.GrpPDV.Controls.Add(Me.CmbImpFac)
        Me.GrpPDV.Controls.Add(Me.Label2)
        Me.GrpPDV.Controls.Add(Me.TxtDescripcion)
        Me.GrpPDV.Controls.Add(Me.LblNombre)
        Me.GrpPDV.Controls.Add(Me.LblClave)
        Me.GrpPDV.Location = New System.Drawing.Point(7, -1)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(689, 284)
        Me.GrpPDV.TabIndex = 1
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Datos Generales"
        '
        'ChkDetallado
        '
        Me.ChkDetallado.Location = New System.Drawing.Point(402, 178)
        Me.ChkDetallado.Name = "ChkDetallado"
        Me.ChkDetallado.Size = New System.Drawing.Size(153, 22)
        Me.ChkDetallado.TabIndex = 130
        Me.ChkDetallado.Text = "Corte Detallado"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(67, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'NumCopias
        '
        Me.NumCopias.Location = New System.Drawing.Point(543, 92)
        Me.NumCopias.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumCopias.Name = "NumCopias"
        Me.NumCopias.Size = New System.Drawing.Size(57, 20)
        Me.NumCopias.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(396, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Copias fac. de Crédito"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbDevolucion
        '
        Me.CmbDevolucion.Location = New System.Drawing.Point(402, 229)
        Me.CmbDevolucion.Name = "CmbDevolucion"
        Me.CmbDevolucion.Size = New System.Drawing.Size(202, 21)
        Me.CmbDevolucion.TabIndex = 8
        '
        'cmbPicking
        '
        Me.cmbPicking.Location = New System.Drawing.Point(113, 202)
        Me.cmbPicking.Name = "cmbPicking"
        Me.cmbPicking.Size = New System.Drawing.Size(212, 21)
        Me.cmbPicking.TabIndex = 128
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(4, 205)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 18)
        Me.Label19.TabIndex = 129
        Me.Label19.Text = "Impresora Picking"
        '
        'ChkCajon
        '
        Me.ChkCajon.AutoSize = True
        Me.ChkCajon.Location = New System.Drawing.Point(402, 124)
        Me.ChkCajon.Name = "ChkCajon"
        Me.ChkCajon.Size = New System.Drawing.Size(165, 17)
        Me.ChkCajon.TabIndex = 120
        Me.ChkCajon.Text = "Apertura de cajón automática"
        Me.ChkCajon.UseVisualStyleBackColor = True
        '
        'ChkManual
        '
        Me.ChkManual.Location = New System.Drawing.Point(402, 149)
        Me.ChkManual.Name = "ChkManual"
        Me.ChkManual.Size = New System.Drawing.Size(153, 22)
        Me.ChkManual.TabIndex = 119
        Me.ChkManual.Text = "Apertura y Cierre Manual"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(68, 121)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox7.TabIndex = 118
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(113, 118)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(212, 21)
        Me.CmbAlmacen.TabIndex = 5
        '
        'BtnAsociar
        '
        Me.BtnAsociar.Icon = CType(resources.GetObject("BtnAsociar.Icon"), System.Drawing.Icon)
        Me.BtnAsociar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnAsociar.Location = New System.Drawing.Point(504, 251)
        Me.BtnAsociar.Name = "BtnAsociar"
        Me.BtnAsociar.Size = New System.Drawing.Size(34, 30)
        Me.BtnAsociar.TabIndex = 11
        Me.BtnAsociar.ToolTipText = "Asociar caja a una PC"
        '
        'TxtProcesador
        '
        Me.TxtProcesador.Enabled = False
        Me.TxtProcesador.Location = New System.Drawing.Point(113, 257)
        Me.TxtProcesador.Name = "TxtProcesador"
        Me.TxtProcesador.Size = New System.Drawing.Size(387, 20)
        Me.TxtProcesador.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(4, 259)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 22)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Asociar a una PC"
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(374, 233)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox12.TabIndex = 111
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(331, 232)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 15)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "Devolución"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(346, 33)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox9.TabIndex = 108
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(72, 231)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox6.TabIndex = 107
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(68, 175)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox5.TabIndex = 106
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(68, 149)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.TabIndex = 105
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(67, 89)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox3.TabIndex = 104
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbImpRec
        '
        Me.CmbImpRec.Location = New System.Drawing.Point(113, 175)
        Me.CmbImpRec.Name = "CmbImpRec"
        Me.CmbImpRec.Size = New System.Drawing.Size(212, 21)
        Me.CmbImpRec.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Impresora Recibo"
        '
        'Almacen
        '
        Me.Almacen.Location = New System.Drawing.Point(4, 92)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(57, 15)
        Me.Almacen.TabIndex = 89
        Me.Almacen.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(113, 89)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(212, 21)
        Me.CmbSucursal.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 232)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 16)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Recibo"
        '
        'CmbTicket
        '
        Me.CmbTicket.Location = New System.Drawing.Point(113, 229)
        Me.CmbTicket.Name = "CmbTicket"
        Me.CmbTicket.Size = New System.Drawing.Size(212, 21)
        Me.CmbTicket.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(68, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(317, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Fase"
        '
        'cmbFase
        '
        Me.cmbFase.Location = New System.Drawing.Point(364, 30)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(133, 21)
        Me.cmbFase.TabIndex = 2
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(113, 30)
        Me.TxtNombre.Mask = "0#########"
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(120, 20)
        Me.TxtNombre.TabIndex = 1
        Me.TxtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(543, 30)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(73, 22)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'CmbImpFac
        '
        Me.CmbImpFac.Location = New System.Drawing.Point(113, 146)
        Me.CmbImpFac.Name = "CmbImpFac"
        Me.CmbImpFac.Size = New System.Drawing.Size(212, 21)
        Me.CmbImpFac.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 14)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Impresora Factura"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(113, 59)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(387, 20)
        Me.TxtDescripcion.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(4, 62)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(72, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(4, 32)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(510, 402)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(606, 402)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.TxtEfectivo)
        Me.GroupBox1.Controls.Add(Me.TxtVales)
        Me.GroupBox1.Controls.Add(Me.TxtCheque)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 51)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Programación de Corte de Caja"
        '
        'TxtEfectivo
        '
        Me.TxtEfectivo.Location = New System.Drawing.Point(102, 19)
        Me.TxtEfectivo.Name = "TxtEfectivo"
        Me.TxtEfectivo.Size = New System.Drawing.Size(94, 20)
        Me.TxtEfectivo.TabIndex = 11
        Me.TxtEfectivo.Text = "0.00"
        Me.TxtEfectivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtEfectivo.Value = 0
        Me.TxtEfectivo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtVales
        '
        Me.TxtVales.Location = New System.Drawing.Point(457, 19)
        Me.TxtVales.Name = "TxtVales"
        Me.TxtVales.Size = New System.Drawing.Size(94, 20)
        Me.TxtVales.TabIndex = 13
        Me.TxtVales.Text = "0.00"
        Me.TxtVales.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtVales.Value = 0
        Me.TxtVales.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtCheque
        '
        Me.TxtCheque.Location = New System.Drawing.Point(283, 19)
        Me.TxtCheque.Name = "TxtCheque"
        Me.TxtCheque.Size = New System.Drawing.Size(93, 20)
        Me.TxtCheque.TabIndex = 12
        Me.TxtCheque.Text = "0.00"
        Me.TxtCheque.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtCheque.Value = 0
        Me.TxtCheque.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 15)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Limite Efectivo"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(202, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Limite Cheque"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(382, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 15)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Limite Vales"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtAplicacion)
        Me.GroupBox3.Controls.Add(Me.BtnBorrar)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.BtnExplorador)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 344)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(689, 50)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Aplicación para Sistemas de Pagos Externa"
        '
        'TxtAplicacion
        '
        Me.TxtAplicacion.Location = New System.Drawing.Point(68, 20)
        Me.TxtAplicacion.Name = "TxtAplicacion"
        Me.TxtAplicacion.ReadOnly = True
        Me.TxtAplicacion.Size = New System.Drawing.Size(540, 20)
        Me.TxtAplicacion.TabIndex = 28
        Me.TxtAplicacion.TabStop = False
        '
        'BtnBorrar
        '
        Me.BtnBorrar.Icon = CType(resources.GetObject("BtnBorrar.Icon"), System.Drawing.Icon)
        Me.BtnBorrar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnBorrar.Location = New System.Drawing.Point(649, 14)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(34, 30)
        Me.BtnBorrar.TabIndex = 31
        Me.BtnBorrar.ToolTipText = "Borrar Aplicación"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(3, 23)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 20)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Aplicación"
        '
        'BtnExplorador
        '
        Me.BtnExplorador.Image = CType(resources.GetObject("BtnExplorador.Image"), System.Drawing.Image)
        Me.BtnExplorador.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnExplorador.Location = New System.Drawing.Point(614, 14)
        Me.BtnExplorador.Name = "BtnExplorador"
        Me.BtnExplorador.Size = New System.Drawing.Size(34, 30)
        Me.BtnExplorador.TabIndex = 30
        '
        'FrmCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(706, 446)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCaja"
        Me.Text = "Caja"
        Me.GrpPDV.ResumeLayout(False)
        Me.GrpPDV.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCopias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public CAJClave As String
    Public Clave As String
    Public Nombre As String
    Public Estado As Integer
    Public Manual As Integer
    Public Fase As Integer
    Public PRNClavePic As String = ""
    Public CorteDetallado As Integer

    Public LimiteEfectivo As Double
    Public LimiteCheque As Double
    Public LimiteVales As Double

    Public ImpFac As String = ""
    Public ImpRec As String = ""
    Public TIKClave As String = ""
    Public SUCClave As String = ""
    Public ALMClave As String = ""
    Public TICDevolucion As String = ""
    Public Procesador As String = ""
    Public Cajon As Boolean = False
    Public Aplicacion As String = ""
    Public copiaCredito As Integer = 0

    Private alerta(8) As PictureBox
    Private reloj As parpadea

    Private cpyLimiteEfectivo As Double
    Private cpyLimiteCheque As Double
    Private cpyLimiteVales As Double

    Private bLoad As Boolean = False


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 10 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 10)

        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)

        End If

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbImpFac.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbImpRec.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbFase.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTicket.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbDevolucion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Caja", "@clave", UCase(Trim(Me.TxtNombre.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
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

    Private Sub FrmCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox9
        alerta(7) = Me.PictureBox12
        alerta(8) = Me.PictureBox7

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        With Me.cmbFase
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Caja"
            .NombreParametro2 = "campo"
            .Parametro2 = "Fase"
            .llenar()
        End With

        bLoad = True

        With Me.CmbImpFac
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.CmbImpRec
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.CmbTicket
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_ticket"
            .NombreParametro1 = "Tipo"
            .Parametro1 = 2
            .NombreParametro2 = "SUCClave"
            .Parametro2 = SUCClave
            .llenar()
        End With

        With Me.CmbDevolucion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_ticket"
            .NombreParametro1 = "Tipo"
            .Parametro1 = 3
            .NombreParametro2 = "SUCClave"
            .Parametro2 = SUCClave
            .llenar()
        End With


        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        With Me.cmbPicking
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        TxtNombre.Text = Clave
        TxtDescripcion.Text = Nombre
        CmbImpFac.SelectedValue = ImpFac
        CmbImpRec.SelectedValue = ImpRec
        cmbPicking.SelectedValue = PRNClavePic
        cmbFase.SelectedValue = Fase
        ChkEstado.Estado = Estado
        ChkManual.Estado = Manual
        ChkCajon.Checked = Cajon
        CmbTicket.SelectedValue = TIKClave
        CmbDevolucion.SelectedValue = TICDevolucion
        CmbSucursal.SelectedValue = SUCClave
        CmbAlmacen.SelectedValue = ALMClave
        TxtEfectivo.Text = CStr(LimiteEfectivo)
        TxtCheque.Text = CStr(LimiteCheque)
        TxtVales.Text = CStr(LimiteVales)
        TxtProcesador.Text = Procesador
        TxtAplicacion.Text = Aplicacion
        NumCopias.Value = copiaCredito
        ChkDetallado.Estado = CorteDetallado

    End Sub

    Public Sub reinicializar()
        Clave = ""
        Nombre = ""
        ImpFac = ""
        ImpRec = ""
        Fase = 1
        Estado = 1
        TIKClave = ""
        TICDevolucion = ""
        SUCClave = ""
        PRNClavePic = ""

        LimiteEfectivo = 0
        LimiteCheque = 0
        LimiteVales = 0
        Procesador = ""
        ALMClave = ""
        Cajon = False
        Aplicacion = ""
        TxtAplicacion.Text = Aplicacion
        TxtNombre.Text = Clave
        TxtDescripcion.Text = Nombre
        CmbImpFac.SelectedValue = ImpFac
        CmbImpRec.SelectedValue = ImpRec
        cmbPicking.SelectedValue = PRNClavePic

        cmbFase.SelectedValue = Fase
        ChkEstado.Estado = Estado
        ChkCajon.Checked = Cajon
        CmbTicket.SelectedValue = TIKClave
        CmbDevolucion.SelectedValue = TICDevolucion
        CmbSucursal.SelectedValue = SUCClave
        CmbAlmacen.SelectedValue = ALMClave
        TxtEfectivo.Text = CStr(LimiteEfectivo)
        TxtCheque.Text = CStr(LimiteCheque)
        TxtVales.Text = CStr(LimiteVales)
        TxtProcesador.Text = Procesador
    End Sub

    Private Sub FrmCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Caja.Dispose()
        ModPOS.Caja = Nothing
    End Sub

    Private Sub BtnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If TxtEfectivo.Text = "" Then
                cpyLimiteEfectivo = 0.0
            Else
                cpyLimiteEfectivo = CDbl(TxtEfectivo.Text)
            End If

            If TxtCheque.Text = "" Then
                cpyLimiteCheque = 0.0
            Else
                cpyLimiteCheque = CDbl(TxtCheque.Text)
            End If

            If TxtVales.Text = "" Then
                cpyLimiteVales = 0.0
            Else
                cpyLimiteVales = CDbl(TxtVales.Text)
            End If

            Select Case Me.Padre
                Case "Agregar"
                    CAJClave = ModPOS.obtenerLlave
                    Clave = UCase(Trim(Me.TxtNombre.Text))
                    Nombre = UCase(Trim(Me.TxtDescripcion.Text))
                    ImpFac = CmbImpFac.SelectedValue
                    ImpRec = CmbImpRec.SelectedValue
                    TIKClave = CmbTicket.SelectedValue
                    SUCClave = CmbSucursal.SelectedValue
                    ALMClave = CmbAlmacen.SelectedValue
                    Fase = cmbFase.SelectedValue
                    LimiteEfectivo = cpyLimiteEfectivo
                    LimiteCheque = cpyLimiteCheque
                    LimiteVales = cpyLimiteVales
                    TICDevolucion = CmbDevolucion.SelectedValue
                    Procesador = TxtProcesador.Text
                    Manual = ChkManual.GetEstado
                    Cajon = ChkCajon.Checked
                    Aplicacion = TxtAplicacion.Text
                    PRNClavePic = cmbPicking.SelectedValue
                    NumCopias.Value = copiaCredito
                    CorteDetallado = ChkDetallado.GetEstado


                    ModPOS.Ejecuta("sp_inserta_caja", _
                    "@CAJClave", CAJClave, _
                    "@Clave", Clave, _
                    "@Nombre", Nombre, _
                    "@ImpFac", ImpFac, _
                    "@ImpRec", ImpRec, _
                    "@TIKClave", TIKClave, _
                    "@Devolucion", TICDevolucion, _
                    "@SUCClave", SUCClave, _
                    "@ALMClave", ALMClave, _
                    "@Fase", Fase, _
                    "@Efectivo", LimiteEfectivo, _
                    "@Cheque", LimiteCheque, _
                    "@Vales", LimiteVales, _
                    "@Procesador", Procesador, _
                    "@Manual", Manual, _
                    "@Cajon", Cajon, _
                    "@Aplicacion", Aplicacion, _
                    "@PRNClavePic", PRNClavePic, _
                    "@copiaCredito", copiaCredito, _
                    "@CorteDetallado", CorteDetallado, _
                    "@Usuario", ModPOS.UsuarioActual)

                    reinicializar()

                    If Not ModPOS.MtoCajas Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoCajas.GridCaja, "sp_muestra_caja", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoCajas.GridCaja.RootTable.Columns("ID").Visible = False

                    End If


                Case "Modificar"


                    If Not (Clave = UCase(Trim(Me.TxtNombre.Text)) AndAlso _
                        Nombre = UCase(Trim(Me.TxtDescripcion.Text)) AndAlso _
                        ImpFac = CmbImpFac.SelectedValue AndAlso _
                        ImpRec = CmbImpRec.SelectedValue AndAlso _
                        TIKClave = CmbTicket.SelectedValue AndAlso _
                        TICDevolucion = CmbDevolucion.SelectedValue AndAlso _
                        SUCClave = CmbSucursal.SelectedValue AndAlso _
                        Fase = cmbFase.SelectedValue AndAlso _
                        LimiteEfectivo = cpyLimiteEfectivo AndAlso _
                        LimiteCheque = cpyLimiteCheque AndAlso _
                        LimiteVales = cpyLimiteVales AndAlso _
                        Procesador = TxtProcesador.Text AndAlso _
                        ALMClave = CmbAlmacen.SelectedValue AndAlso _
                        Manual = ChkManual.GetEstado AndAlso _
                        Cajon = ChkCajon.Checked AndAlso _
                        Aplicacion = TxtAplicacion.Text AndAlso _
                        PRNClavePic = cmbPicking.SelectedValue AndAlso _
                        NumCopias.Value = copiaCredito AndAlso _
                        CorteDetallado = ChkDetallado.GetEstado AndAlso _
                        Estado = ChkEstado.GetEstado) Then


                        PRNClavePic = cmbPicking.SelectedValue
                        Clave = UCase(Trim(Me.TxtNombre.Text))
                        Nombre = UCase(Trim(Me.TxtDescripcion.Text))
                        ImpFac = CmbImpFac.SelectedValue
                        ImpRec = CmbImpRec.SelectedValue
                        TIKClave = CmbTicket.SelectedValue
                        TICDevolucion = CmbDevolucion.SelectedValue
                        SUCClave = CmbSucursal.SelectedValue
                        Fase = cmbFase.SelectedValue
                        LimiteEfectivo = cpyLimiteEfectivo
                        LimiteCheque = cpyLimiteCheque
                        LimiteVales = cpyLimiteVales
                        Estado = ChkEstado.GetEstado
                        Manual = ChkManual.GetEstado
                        Procesador = TxtProcesador.Text
                        Cajon = ChkCajon.Checked
                        ALMClave = CmbAlmacen.SelectedValue
                        Aplicacion = TxtAplicacion.Text
                        copiaCredito = NumCopias.Value
                        CorteDetallado = ChkDetallado.GetEstado

                        ModPOS.Ejecuta("sp_modificar_caja", _
                        "@CAJClave", CAJClave, _
                        "@Nombre", Nombre, _
                        "@ImpFac", ImpFac, _
                        "@ImpRec", ImpRec, _
                        "@TIKClave", TIKClave, _
                        "@Devolucion", TICDevolucion, _
                        "@SUCClave", SUCClave, _
                        "@ALMClave", ALMClave, _
                        "@Fase", Fase, _
                        "@Efectivo", LimiteEfectivo, _
                        "@Cheque", LimiteCheque, _
                        "@Vales", LimiteVales, _
                        "@Estado", Estado, _
                        "@Procesador", Procesador, _
                        "@Manual", Manual, _
                        "@Cajon", Cajon, _
                        "@Aplicacion", Aplicacion, _
                        "@PRNClavePic", PRNClavePic, _
                        "@copiaCredito", copiaCredito, _
                        "@CorteDetallado", CorteDetallado, _
                        "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoCajas Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoCajas.GridCaja, "sp_muestra_caja", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.MtoCajas.GridCaja.RootTable.Columns("ID").Visible = False
                        End If

                    End If
                    Me.Close()
            End Select



        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsociar.Click
        Me.TxtProcesador.Text = ModPOS.GetProcessorId
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then

            With Me.CmbTicket
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_ticket"
                .NombreParametro1 = "Tipo"
                .Parametro1 = 2
                .NombreParametro2 = "SUCClave"
                .Parametro2 = CmbSucursal.SelectedValue
                .llenar()
            End With

            With Me.CmbDevolucion
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_ticket"
                .NombreParametro1 = "Tipo"
                .Parametro1 = 3
                .NombreParametro2 = "SUCClave"
                .Parametro2 = CmbSucursal.SelectedValue
                .llenar()
            End With

            With Me.CmbImpFac
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_impresora"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With


            With Me.CmbImpRec
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_impresora"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With


            With Me.cmbPicking
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_impresora"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub BtnExplorador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExplorador.Click


        OpenFileDialog1.Filter = "Todos los archivos de Aplicación|*.EXE"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            TxtAplicacion.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
        TxtAplicacion.Text = ""
    End Sub

   
End Class
