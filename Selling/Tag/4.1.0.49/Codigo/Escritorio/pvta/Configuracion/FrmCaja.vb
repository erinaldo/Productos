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
    Friend WithEvents BtnExplorador As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtAplicacion As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnBorrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbPicking As Selling.StoreCombo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents NumCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkDetallado As Selling.ChkStatus
    Friend WithEvents ChkTransferencia As Selling.ChkStatus
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbCorte As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnStage As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtStage As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GrpBloqueo As System.Windows.Forms.GroupBox
    Friend WithEvents ChkComision As Selling.ChkStatus
    Friend WithEvents ChkReembolso As Selling.ChkStatus
    Friend WithEvents ChkCambio As Selling.ChkStatus
    Friend WithEvents ChkRetiro As Selling.ChkStatus
    Friend WithEvents ChkDevolucion As Selling.ChkStatus
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnStageCancelacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtStageCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ChkAbono As Selling.ChkStatus
    Friend WithEvents ChkRecibo As Selling.ChkStatus
    Friend WithEvents ChkNotas As Selling.ChkStatus
    Friend WithEvents ChkFactura As Selling.ChkStatus
    Friend WithEvents ChkCargo As Selling.ChkStatus
    Friend WithEvents ChkMasiva As Selling.ChkStatus
    Friend WithEvents ChkGlobal As Selling.ChkStatus
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtMostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDocumento As Selling.StoreCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCancel As Selling.StoreCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents btnStageLU As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtStageLU As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ChkServicio As Selling.ChkStatus
    Friend WithEvents ChkPedido As Selling.ChkStatus
    Friend WithEvents ChkAnticipos As Selling.ChkStatus
    Friend WithEvents ChkPago As Selling.ChkStatus
    Friend WithEvents ChkNC As Selling.ChkStatus
    Friend WithEvents ChkApartados As Selling.ChkStatus
    Friend WithEvents PictureBox33 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbRecibo As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenDev As Selling.StoreCombo
    Friend WithEvents btnPOS As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtPOS As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkCierre As Selling.ChkStatus
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPassCajero As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdCajero As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtIdPos As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCaja))
        Me.GrpPDV = New System.Windows.Forms.GroupBox()
        Me.btnPOS = New Janus.Windows.EditControls.UIButton()
        Me.txtPOS = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox33 = New System.Windows.Forms.PictureBox()
        Me.cmbRecibo = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.btnStageLU = New Janus.Windows.EditControls.UIButton()
        Me.txtStageLU = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtMostrador = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.BtnStageCancelacion = New Janus.Windows.EditControls.UIButton()
        Me.txtStageCancelacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.BtnStage = New Janus.Windows.EditControls.UIButton()
        Me.TxtStage = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.cmbCorte = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.NumCopias = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ChkCajon = New System.Windows.Forms.CheckBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnAsociar = New Janus.Windows.EditControls.UIButton()
        Me.TxtProcesador = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Almacen = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNombre = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtEfectivo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtVales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtCheque = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtAplicacion = New System.Windows.Forms.TextBox()
        Me.BtnBorrar = New Janus.Windows.EditControls.UIButton()
        Me.BtnExplorador = New Janus.Windows.EditControls.UIButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GrpBloqueo = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtIdPos = New System.Windows.Forms.TextBox()
        Me.TxtIdCajero = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtPassCajero = New System.Windows.Forms.TextBox()
        Me.ChkApartados = New Selling.ChkStatus(Me.components)
        Me.ChkNC = New Selling.ChkStatus(Me.components)
        Me.ChkPago = New Selling.ChkStatus(Me.components)
        Me.ChkServicio = New Selling.ChkStatus(Me.components)
        Me.ChkPedido = New Selling.ChkStatus(Me.components)
        Me.ChkGlobal = New Selling.ChkStatus(Me.components)
        Me.ChkMasiva = New Selling.ChkStatus(Me.components)
        Me.ChkCargo = New Selling.ChkStatus(Me.components)
        Me.ChkFactura = New Selling.ChkStatus(Me.components)
        Me.ChkDevolucion = New Selling.ChkStatus(Me.components)
        Me.ChkComision = New Selling.ChkStatus(Me.components)
        Me.ChkReembolso = New Selling.ChkStatus(Me.components)
        Me.ChkCambio = New Selling.ChkStatus(Me.components)
        Me.ChkRetiro = New Selling.ChkStatus(Me.components)
        Me.chkCierre = New Selling.ChkStatus(Me.components)
        Me.cmbAlmacenDev = New Selling.StoreCombo()
        Me.ChkAnticipos = New Selling.ChkStatus(Me.components)
        Me.cmbTipoCancel = New Selling.StoreCombo()
        Me.cmbTipoDocumento = New Selling.StoreCombo()
        Me.ChkNotas = New Selling.ChkStatus(Me.components)
        Me.ChkRecibo = New Selling.ChkStatus(Me.components)
        Me.ChkAbono = New Selling.ChkStatus(Me.components)
        Me.ChkTransferencia = New Selling.ChkStatus(Me.components)
        Me.ChkDetallado = New Selling.ChkStatus(Me.components)
        Me.CmbDevolucion = New Selling.StoreCombo()
        Me.cmbPicking = New Selling.StoreCombo()
        Me.ChkManual = New Selling.ChkStatus(Me.components)
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.CmbImpRec = New Selling.StoreCombo()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.CmbTicket = New Selling.StoreCombo()
        Me.cmbFase = New Selling.StoreCombo()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.CmbImpFac = New Selling.StoreCombo()
        Me.GrpPDV.SuspendLayout()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpBloqueo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPDV
        '
        Me.GrpPDV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPDV.Controls.Add(Me.chkCierre)
        Me.GrpPDV.Controls.Add(Me.btnPOS)
        Me.GrpPDV.Controls.Add(Me.txtPOS)
        Me.GrpPDV.Controls.Add(Me.Label20)
        Me.GrpPDV.Controls.Add(Me.PictureBox13)
        Me.GrpPDV.Controls.Add(Me.Label18)
        Me.GrpPDV.Controls.Add(Me.cmbAlmacenDev)
        Me.GrpPDV.Controls.Add(Me.PictureBox33)
        Me.GrpPDV.Controls.Add(Me.cmbRecibo)
        Me.GrpPDV.Controls.Add(Me.Label50)
        Me.GrpPDV.Controls.Add(Me.ChkAnticipos)
        Me.GrpPDV.Controls.Add(Me.PictureBox11)
        Me.GrpPDV.Controls.Add(Me.btnStageLU)
        Me.GrpPDV.Controls.Add(Me.txtStageLU)
        Me.GrpPDV.Controls.Add(Me.Label17)
        Me.GrpPDV.Controls.Add(Me.cmbTipoCancel)
        Me.GrpPDV.Controls.Add(Me.Label16)
        Me.GrpPDV.Controls.Add(Me.cmbTipoDocumento)
        Me.GrpPDV.Controls.Add(Me.Label13)
        Me.GrpPDV.Controls.Add(Me.LblCliente)
        Me.GrpPDV.Controls.Add(Me.btnBuscaCte)
        Me.GrpPDV.Controls.Add(Me.TxtMostrador)
        Me.GrpPDV.Controls.Add(Me.Label12)
        Me.GrpPDV.Controls.Add(Me.ChkNotas)
        Me.GrpPDV.Controls.Add(Me.ChkRecibo)
        Me.GrpPDV.Controls.Add(Me.ChkAbono)
        Me.GrpPDV.Controls.Add(Me.PictureBox10)
        Me.GrpPDV.Controls.Add(Me.BtnStageCancelacion)
        Me.GrpPDV.Controls.Add(Me.txtStageCancelacion)
        Me.GrpPDV.Controls.Add(Me.Label11)
        Me.GrpPDV.Controls.Add(Me.PictureBox8)
        Me.GrpPDV.Controls.Add(Me.BtnStage)
        Me.GrpPDV.Controls.Add(Me.TxtStage)
        Me.GrpPDV.Controls.Add(Me.Label6)
        Me.GrpPDV.Controls.Add(Me.PictureBox23)
        Me.GrpPDV.Controls.Add(Me.cmbCorte)
        Me.GrpPDV.Controls.Add(Me.Label32)
        Me.GrpPDV.Controls.Add(Me.ChkTransferencia)
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
        Me.GrpPDV.Size = New System.Drawing.Size(818, 447)
        Me.GrpPDV.TabIndex = 1
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Datos Generales"
        '
        'btnPOS
        '
        Me.btnPOS.Image = CType(resources.GetObject("btnPOS.Image"), System.Drawing.Image)
        Me.btnPOS.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnPOS.Location = New System.Drawing.Point(391, 364)
        Me.btnPOS.Name = "btnPOS"
        Me.btnPOS.Size = New System.Drawing.Size(35, 22)
        Me.btnPOS.TabIndex = 195
        Me.btnPOS.ToolTipText = "Busqueda de Punto de Venta"
        Me.btnPOS.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtPOS
        '
        Me.txtPOS.Enabled = False
        Me.txtPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOS.Location = New System.Drawing.Point(113, 366)
        Me.txtPOS.Name = "txtPOS"
        Me.txtPOS.ReadOnly = True
        Me.txtPOS.Size = New System.Drawing.Size(273, 21)
        Me.txtPOS.TabIndex = 194
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(4, 368)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 15)
        Me.Label20.TabIndex = 193
        Me.Label20.Text = "Punto de Venta"
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(508, 225)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox13.TabIndex = 192
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(434, 227)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 15)
        Me.Label18.TabIndex = 191
        Me.Label18.Text = "Almacén Devolución"
        '
        'PictureBox33
        '
        Me.PictureBox33.Image = CType(resources.GetObject("PictureBox33.Image"), System.Drawing.Image)
        Me.PictureBox33.Location = New System.Drawing.Point(508, 338)
        Me.PictureBox33.Name = "PictureBox33"
        Me.PictureBox33.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox33.TabIndex = 189
        Me.PictureBox33.TabStop = False
        Me.PictureBox33.Visible = False
        '
        'cmbRecibo
        '
        Me.cmbRecibo.FormattingEnabled = True
        Me.cmbRecibo.Items.AddRange(New Object() {"Carta", "Ticket"})
        Me.cmbRecibo.Location = New System.Drawing.Point(542, 338)
        Me.cmbRecibo.Name = "cmbRecibo"
        Me.cmbRecibo.Size = New System.Drawing.Size(212, 21)
        Me.cmbRecibo.TabIndex = 188
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(434, 338)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(120, 15)
        Me.Label50.TabIndex = 187
        Me.Label50.Text = "Formato de Recibo"
        '
        'PictureBox11
        '
        Me.PictureBox11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(506, 309)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox11.TabIndex = 185
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'btnStageLU
        '
        Me.btnStageLU.Image = CType(resources.GetObject("btnStageLU.Image"), System.Drawing.Image)
        Me.btnStageLU.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnStageLU.Location = New System.Drawing.Point(681, 307)
        Me.btnStageLU.Name = "btnStageLU"
        Me.btnStageLU.Size = New System.Drawing.Size(35, 22)
        Me.btnStageLU.TabIndex = 184
        Me.btnStageLU.ToolTipText = "Busqueda de Stage"
        Me.btnStageLU.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtStageLU
        '
        Me.txtStageLU.Enabled = False
        Me.txtStageLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStageLU.Location = New System.Drawing.Point(543, 309)
        Me.txtStageLU.Name = "txtStageLU"
        Me.txtStageLU.ReadOnly = True
        Me.txtStageLU.Size = New System.Drawing.Size(132, 21)
        Me.txtStageLU.TabIndex = 183
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(434, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 15)
        Me.Label17.TabIndex = 182
        Me.Label17.Text = "Stage L.U."
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(434, 366)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 19)
        Me.Label16.TabIndex = 181
        Me.Label16.Text = "Tipo Doc. Cancel."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(4, 308)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 19)
        Me.Label13.TabIndex = 179
        Me.Label13.Text = "Tipo Doc."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCliente
        '
        Me.LblCliente.Location = New System.Drawing.Point(286, 415)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(469, 19)
        Me.LblCliente.TabIndex = 177
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(241, 407)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaCte.TabIndex = 174
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtMostrador
        '
        Me.TxtMostrador.Location = New System.Drawing.Point(113, 412)
        Me.TxtMostrador.Name = "TxtMostrador"
        Me.TxtMostrador.ReadOnly = True
        Me.TxtMostrador.Size = New System.Drawing.Size(120, 20)
        Me.TxtMostrador.TabIndex = 176
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 415)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 14)
        Me.Label12.TabIndex = 175
        Me.Label12.Text = "Cte. Mostrador"
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(508, 282)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox10.TabIndex = 170
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'BtnStageCancelacion
        '
        Me.BtnStageCancelacion.Image = CType(resources.GetObject("BtnStageCancelacion.Image"), System.Drawing.Image)
        Me.BtnStageCancelacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnStageCancelacion.Location = New System.Drawing.Point(681, 281)
        Me.BtnStageCancelacion.Name = "BtnStageCancelacion"
        Me.BtnStageCancelacion.Size = New System.Drawing.Size(35, 22)
        Me.BtnStageCancelacion.TabIndex = 169
        Me.BtnStageCancelacion.ToolTipText = "Busqueda de Stage"
        Me.BtnStageCancelacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtStageCancelacion
        '
        Me.txtStageCancelacion.Enabled = False
        Me.txtStageCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStageCancelacion.Location = New System.Drawing.Point(543, 281)
        Me.txtStageCancelacion.Name = "txtStageCancelacion"
        Me.txtStageCancelacion.ReadOnly = True
        Me.txtStageCancelacion.Size = New System.Drawing.Size(132, 21)
        Me.txtStageCancelacion.TabIndex = 168
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(434, 284)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 15)
        Me.Label11.TabIndex = 167
        Me.Label11.Text = "Stage Cancelación"
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(508, 251)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox8.TabIndex = 166
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'BtnStage
        '
        Me.BtnStage.Image = CType(resources.GetObject("BtnStage.Image"), System.Drawing.Image)
        Me.BtnStage.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnStage.Location = New System.Drawing.Point(681, 250)
        Me.BtnStage.Name = "BtnStage"
        Me.BtnStage.Size = New System.Drawing.Size(35, 22)
        Me.BtnStage.TabIndex = 165
        Me.BtnStage.ToolTipText = "Busqueda de Stage"
        Me.BtnStage.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtStage
        '
        Me.TxtStage.Enabled = False
        Me.TxtStage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStage.Location = New System.Drawing.Point(543, 251)
        Me.TxtStage.Name = "TxtStage"
        Me.TxtStage.ReadOnly = True
        Me.TxtStage.Size = New System.Drawing.Size(132, 21)
        Me.TxtStage.TabIndex = 164
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(434, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 15)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Stage Devolución"
        '
        'PictureBox23
        '
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(70, 282)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox23.TabIndex = 139
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'cmbCorte
        '
        Me.cmbCorte.FormattingEnabled = True
        Me.cmbCorte.Items.AddRange(New Object() {"Resumen", "Detallado"})
        Me.cmbCorte.Location = New System.Drawing.Point(113, 279)
        Me.cmbCorte.Name = "cmbCorte"
        Me.cmbCorte.Size = New System.Drawing.Size(212, 21)
        Me.cmbCorte.TabIndex = 140
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(4, 284)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 21)
        Me.Label32.TabIndex = 138
        Me.Label32.Text = "Formato de Corte"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(72, 54)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'NumCopias
        '
        Me.NumCopias.Location = New System.Drawing.Point(684, 60)
        Me.NumCopias.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumCopias.Name = "NumCopias"
        Me.NumCopias.Size = New System.Drawing.Size(57, 20)
        Me.NumCopias.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(537, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Copias fac. de Crédito"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(4, 200)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 18)
        Me.Label19.TabIndex = 129
        Me.Label19.Text = "Impresora Picking"
        '
        'ChkCajon
        '
        Me.ChkCajon.AutoSize = True
        Me.ChkCajon.Location = New System.Drawing.Point(347, 86)
        Me.ChkCajon.Name = "ChkCajon"
        Me.ChkCajon.Size = New System.Drawing.Size(165, 17)
        Me.ChkCajon.TabIndex = 120
        Me.ChkCajon.Text = "Apertura de cajón automática"
        Me.ChkCajon.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(72, 116)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox7.TabIndex = 118
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Almacén"
        '
        'BtnAsociar
        '
        Me.BtnAsociar.Icon = CType(resources.GetObject("BtnAsociar.Icon"), System.Drawing.Icon)
        Me.BtnAsociar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnAsociar.Location = New System.Drawing.Point(392, 330)
        Me.BtnAsociar.Name = "BtnAsociar"
        Me.BtnAsociar.Size = New System.Drawing.Size(34, 30)
        Me.BtnAsociar.TabIndex = 11
        Me.BtnAsociar.ToolTipText = "Asociar caja a una PC"
        '
        'TxtProcesador
        '
        Me.TxtProcesador.Enabled = False
        Me.TxtProcesador.Location = New System.Drawing.Point(113, 335)
        Me.TxtProcesador.Name = "TxtProcesador"
        Me.TxtProcesador.Size = New System.Drawing.Size(273, 20)
        Me.TxtProcesador.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(6, 338)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 22)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Asociar a una PC"
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(72, 254)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox12.TabIndex = 111
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(4, 257)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 15)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "Devolución"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(346, 28)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox9.TabIndex = 108
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(72, 226)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox6.TabIndex = 107
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(72, 170)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox5.TabIndex = 106
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(72, 144)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.TabIndex = 105
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(72, 84)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox3.TabIndex = 104
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Impresora Recibo"
        '
        'Almacen
        '
        Me.Almacen.Location = New System.Drawing.Point(4, 87)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(57, 15)
        Me.Almacen.TabIndex = 89
        Me.Almacen.Text = "Sucursal"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 16)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Recibo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(72, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(317, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Fase"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(113, 25)
        Me.TxtNombre.Mask = "0#########"
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(120, 20)
        Me.TxtNombre.TabIndex = 1
        Me.TxtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 14)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Impresora Factura"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(113, 54)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(387, 20)
        Me.TxtDescripcion.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(4, 57)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(72, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(4, 27)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(639, 627)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(735, 627)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtEfectivo)
        Me.GroupBox1.Controls.Add(Me.TxtVales)
        Me.GroupBox1.Controls.Add(Me.TxtCheque)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 504)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 51)
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
        Me.TxtEfectivo.Value = 0.0R
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
        Me.TxtVales.Value = 0.0R
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
        Me.TxtCheque.Value = 0.0R
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
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TxtAplicacion)
        Me.GroupBox3.Controls.Add(Me.BtnBorrar)
        Me.GroupBox3.Controls.Add(Me.BtnExplorador)
        Me.GroupBox3.Location = New System.Drawing.Point(567, 504)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 111)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Aplicación para Sistemas de Pagos Externa"
        '
        'TxtAplicacion
        '
        Me.TxtAplicacion.Location = New System.Drawing.Point(6, 19)
        Me.TxtAplicacion.Multiline = True
        Me.TxtAplicacion.Name = "TxtAplicacion"
        Me.TxtAplicacion.ReadOnly = True
        Me.TxtAplicacion.Size = New System.Drawing.Size(241, 51)
        Me.TxtAplicacion.TabIndex = 28
        Me.TxtAplicacion.TabStop = False
        '
        'BtnBorrar
        '
        Me.BtnBorrar.Icon = CType(resources.GetObject("BtnBorrar.Icon"), System.Drawing.Icon)
        Me.BtnBorrar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnBorrar.Location = New System.Drawing.Point(46, 76)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(34, 30)
        Me.BtnBorrar.TabIndex = 31
        Me.BtnBorrar.ToolTipText = "Borrar Aplicación"
        '
        'BtnExplorador
        '
        Me.BtnExplorador.Image = CType(resources.GetObject("BtnExplorador.Image"), System.Drawing.Image)
        Me.BtnExplorador.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnExplorador.Location = New System.Drawing.Point(6, 76)
        Me.BtnExplorador.Name = "BtnExplorador"
        Me.BtnExplorador.Size = New System.Drawing.Size(34, 30)
        Me.BtnExplorador.TabIndex = 30
        '
        'GrpBloqueo
        '
        Me.GrpBloqueo.Controls.Add(Me.ChkApartados)
        Me.GrpBloqueo.Controls.Add(Me.ChkNC)
        Me.GrpBloqueo.Controls.Add(Me.ChkPago)
        Me.GrpBloqueo.Controls.Add(Me.ChkServicio)
        Me.GrpBloqueo.Controls.Add(Me.ChkPedido)
        Me.GrpBloqueo.Controls.Add(Me.ChkGlobal)
        Me.GrpBloqueo.Controls.Add(Me.ChkMasiva)
        Me.GrpBloqueo.Controls.Add(Me.ChkCargo)
        Me.GrpBloqueo.Controls.Add(Me.ChkFactura)
        Me.GrpBloqueo.Controls.Add(Me.ChkDevolucion)
        Me.GrpBloqueo.Controls.Add(Me.ChkComision)
        Me.GrpBloqueo.Controls.Add(Me.ChkReembolso)
        Me.GrpBloqueo.Controls.Add(Me.ChkCambio)
        Me.GrpBloqueo.Controls.Add(Me.ChkRetiro)
        Me.GrpBloqueo.Location = New System.Drawing.Point(7, 561)
        Me.GrpBloqueo.Name = "GrpBloqueo"
        Me.GrpBloqueo.Size = New System.Drawing.Size(554, 103)
        Me.GrpBloqueo.TabIndex = 7
        Me.GrpBloqueo.TabStop = False
        Me.GrpBloqueo.Text = "Bloqueo de Aplicación"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtPassCajero)
        Me.GroupBox2.Controls.Add(Me.TxtIdCajero)
        Me.GroupBox2.Controls.Add(Me.TxtIdPos)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 452)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(818, 51)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos para Sistema de Recargas Telefónicas"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(13, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(95, 15)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "ID Pos"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(333, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 15)
        Me.Label22.TabIndex = 66
        Me.Label22.Text = "ID Cajero"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(505, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 15)
        Me.Label23.TabIndex = 68
        Me.Label23.Text = "Contraseña Cajero"
        '
        'TxtIdPos
        '
        Me.TxtIdPos.Location = New System.Drawing.Point(61, 21)
        Me.TxtIdPos.Name = "TxtIdPos"
        Me.TxtIdPos.Size = New System.Drawing.Size(264, 20)
        Me.TxtIdPos.TabIndex = 69
        '
        'TxtIdCajero
        '
        Me.TxtIdCajero.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.TxtIdCajero.Location = New System.Drawing.Point(391, 19)
        Me.TxtIdCajero.Name = "TxtIdCajero"
        Me.TxtIdCajero.Size = New System.Drawing.Size(106, 20)
        Me.TxtIdCajero.TabIndex = 70
        Me.TxtIdCajero.Text = "0"
        Me.TxtIdCajero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtIdCajero.Value = 0
        Me.TxtIdCajero.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'TxtPassCajero
        '
        Me.TxtPassCajero.Location = New System.Drawing.Point(610, 19)
        Me.TxtPassCajero.Name = "TxtPassCajero"
        Me.TxtPassCajero.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassCajero.Size = New System.Drawing.Size(197, 20)
        Me.TxtPassCajero.TabIndex = 71
        '
        'ChkApartados
        '
        Me.ChkApartados.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkApartados.Location = New System.Drawing.Point(402, 60)
        Me.ChkApartados.Name = "ChkApartados"
        Me.ChkApartados.Size = New System.Drawing.Size(61, 35)
        Me.ChkApartados.TabIndex = 145
        Me.ChkApartados.Text = "Apartados"
        Me.ChkApartados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkNC
        '
        Me.ChkNC.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkNC.Location = New System.Drawing.Point(254, 19)
        Me.ChkNC.Name = "ChkNC"
        Me.ChkNC.Size = New System.Drawing.Size(41, 35)
        Me.ChkNC.TabIndex = 144
        Me.ChkNC.Text = "NC"
        Me.ChkNC.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkPago
        '
        Me.ChkPago.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkPago.Location = New System.Drawing.Point(3, 60)
        Me.ChkPago.Name = "ChkPago"
        Me.ChkPago.Size = New System.Drawing.Size(58, 35)
        Me.ChkPago.TabIndex = 143
        Me.ChkPago.Text = "Pago"
        Me.ChkPago.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkServicio
        '
        Me.ChkServicio.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkServicio.Location = New System.Drawing.Point(125, 19)
        Me.ChkServicio.Name = "ChkServicio"
        Me.ChkServicio.Size = New System.Drawing.Size(58, 35)
        Me.ChkServicio.TabIndex = 142
        Me.ChkServicio.Text = "Servicios"
        Me.ChkServicio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkPedido
        '
        Me.ChkPedido.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkPedido.Location = New System.Drawing.Point(61, 60)
        Me.ChkPedido.Name = "ChkPedido"
        Me.ChkPedido.Size = New System.Drawing.Size(58, 35)
        Me.ChkPedido.TabIndex = 141
        Me.ChkPedido.Text = "E. Pedido"
        Me.ChkPedido.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkGlobal
        '
        Me.ChkGlobal.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkGlobal.Location = New System.Drawing.Point(183, 19)
        Me.ChkGlobal.Name = "ChkGlobal"
        Me.ChkGlobal.Size = New System.Drawing.Size(68, 35)
        Me.ChkGlobal.TabIndex = 140
        Me.ChkGlobal.Text = "F. Global"
        Me.ChkGlobal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkMasiva
        '
        Me.ChkMasiva.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkMasiva.Location = New System.Drawing.Point(119, 60)
        Me.ChkMasiva.Name = "ChkMasiva"
        Me.ChkMasiva.Size = New System.Drawing.Size(77, 35)
        Me.ChkMasiva.TabIndex = 139
        Me.ChkMasiva.Text = "F. Masiva"
        Me.ChkMasiva.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkCargo
        '
        Me.ChkCargo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkCargo.Location = New System.Drawing.Point(248, 60)
        Me.ChkCargo.Name = "ChkCargo"
        Me.ChkCargo.Size = New System.Drawing.Size(50, 35)
        Me.ChkCargo.TabIndex = 138
        Me.ChkCargo.Text = "Cargo"
        Me.ChkCargo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkFactura
        '
        Me.ChkFactura.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkFactura.Location = New System.Drawing.Point(304, 60)
        Me.ChkFactura.Name = "ChkFactura"
        Me.ChkFactura.Size = New System.Drawing.Size(77, 35)
        Me.ChkFactura.TabIndex = 137
        Me.ChkFactura.Text = "Facturación"
        Me.ChkFactura.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkDevolucion
        '
        Me.ChkDevolucion.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkDevolucion.Location = New System.Drawing.Point(304, 19)
        Me.ChkDevolucion.Name = "ChkDevolucion"
        Me.ChkDevolucion.Size = New System.Drawing.Size(77, 35)
        Me.ChkDevolucion.TabIndex = 136
        Me.ChkDevolucion.Text = "Devolución"
        Me.ChkDevolucion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkComision
        '
        Me.ChkComision.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkComision.Location = New System.Drawing.Point(61, 19)
        Me.ChkComision.Name = "ChkComision"
        Me.ChkComision.Size = New System.Drawing.Size(64, 35)
        Me.ChkComision.TabIndex = 135
        Me.ChkComision.Text = "Comisión"
        Me.ChkComision.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkReembolso
        '
        Me.ChkReembolso.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkReembolso.Location = New System.Drawing.Point(392, 19)
        Me.ChkReembolso.Name = "ChkReembolso"
        Me.ChkReembolso.Size = New System.Drawing.Size(77, 35)
        Me.ChkReembolso.TabIndex = 134
        Me.ChkReembolso.Text = "Reembolso"
        Me.ChkReembolso.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkCambio
        '
        Me.ChkCambio.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkCambio.Location = New System.Drawing.Point(5, 19)
        Me.ChkCambio.Name = "ChkCambio"
        Me.ChkCambio.Size = New System.Drawing.Size(56, 35)
        Me.ChkCambio.TabIndex = 133
        Me.ChkCambio.Text = "Cambios"
        Me.ChkCambio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ChkRetiro
        '
        Me.ChkRetiro.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkRetiro.Location = New System.Drawing.Point(189, 60)
        Me.ChkRetiro.Name = "ChkRetiro"
        Me.ChkRetiro.Size = New System.Drawing.Size(53, 35)
        Me.ChkRetiro.TabIndex = 132
        Me.ChkRetiro.Text = "Retiro"
        Me.ChkRetiro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkCierre
        '
        Me.chkCierre.Location = New System.Drawing.Point(540, 193)
        Me.chkCierre.Name = "chkCierre"
        Me.chkCierre.Size = New System.Drawing.Size(153, 22)
        Me.chkCierre.TabIndex = 196
        Me.chkCierre.Text = "Incluir en Cierre de Día"
        '
        'cmbAlmacenDev
        '
        Me.cmbAlmacenDev.Location = New System.Drawing.Point(543, 224)
        Me.cmbAlmacenDev.Name = "cmbAlmacenDev"
        Me.cmbAlmacenDev.Size = New System.Drawing.Size(212, 21)
        Me.cmbAlmacenDev.TabIndex = 190
        '
        'ChkAnticipos
        '
        Me.ChkAnticipos.Location = New System.Drawing.Point(540, 109)
        Me.ChkAnticipos.Name = "ChkAnticipos"
        Me.ChkAnticipos.Size = New System.Drawing.Size(214, 22)
        Me.ChkAnticipos.TabIndex = 186
        Me.ChkAnticipos.Text = "Anticipos en  Notas de Cargo"
        '
        'cmbTipoCancel
        '
        Me.cmbTipoCancel.Location = New System.Drawing.Point(543, 365)
        Me.cmbTipoCancel.Name = "cmbTipoCancel"
        Me.cmbTipoCancel.Size = New System.Drawing.Size(212, 21)
        Me.cmbTipoCancel.TabIndex = 180
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(113, 306)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(212, 21)
        Me.cmbTipoDocumento.TabIndex = 178
        '
        'ChkNotas
        '
        Me.ChkNotas.Location = New System.Drawing.Point(540, 83)
        Me.ChkNotas.Name = "ChkNotas"
        Me.ChkNotas.Size = New System.Drawing.Size(153, 22)
        Me.ChkNotas.TabIndex = 173
        Me.ChkNotas.Text = "Mostrar Notas"
        '
        'ChkRecibo
        '
        Me.ChkRecibo.Location = New System.Drawing.Point(540, 137)
        Me.ChkRecibo.Name = "ChkRecibo"
        Me.ChkRecibo.Size = New System.Drawing.Size(153, 22)
        Me.ChkRecibo.TabIndex = 172
        Me.ChkRecibo.Text = "Miniprinter"
        '
        'ChkAbono
        '
        Me.ChkAbono.Location = New System.Drawing.Point(540, 165)
        Me.ChkAbono.Name = "ChkAbono"
        Me.ChkAbono.Size = New System.Drawing.Size(153, 22)
        Me.ChkAbono.TabIndex = 171
        Me.ChkAbono.Text = "Confirmar Abono"
        '
        'ChkTransferencia
        '
        Me.ChkTransferencia.Location = New System.Drawing.Point(347, 165)
        Me.ChkTransferencia.Name = "ChkTransferencia"
        Me.ChkTransferencia.Size = New System.Drawing.Size(153, 22)
        Me.ChkTransferencia.TabIndex = 131
        Me.ChkTransferencia.Text = "Transferir al Cierre"
        '
        'ChkDetallado
        '
        Me.ChkDetallado.Location = New System.Drawing.Point(347, 137)
        Me.ChkDetallado.Name = "ChkDetallado"
        Me.ChkDetallado.Size = New System.Drawing.Size(153, 22)
        Me.ChkDetallado.TabIndex = 130
        Me.ChkDetallado.Text = "Corte Detallado"
        '
        'CmbDevolucion
        '
        Me.CmbDevolucion.Location = New System.Drawing.Point(113, 251)
        Me.CmbDevolucion.Name = "CmbDevolucion"
        Me.CmbDevolucion.Size = New System.Drawing.Size(212, 21)
        Me.CmbDevolucion.TabIndex = 8
        '
        'cmbPicking
        '
        Me.cmbPicking.Location = New System.Drawing.Point(113, 197)
        Me.cmbPicking.Name = "cmbPicking"
        Me.cmbPicking.Size = New System.Drawing.Size(212, 21)
        Me.cmbPicking.TabIndex = 128
        '
        'ChkManual
        '
        Me.ChkManual.Location = New System.Drawing.Point(347, 109)
        Me.ChkManual.Name = "ChkManual"
        Me.ChkManual.Size = New System.Drawing.Size(153, 22)
        Me.ChkManual.TabIndex = 119
        Me.ChkManual.Text = "Apertura y Cierre Manual"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(113, 113)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(212, 21)
        Me.CmbAlmacen.TabIndex = 5
        '
        'CmbImpRec
        '
        Me.CmbImpRec.Location = New System.Drawing.Point(113, 170)
        Me.CmbImpRec.Name = "CmbImpRec"
        Me.CmbImpRec.Size = New System.Drawing.Size(212, 21)
        Me.CmbImpRec.TabIndex = 7
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(113, 84)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(212, 21)
        Me.CmbSucursal.TabIndex = 4
        '
        'CmbTicket
        '
        Me.CmbTicket.Location = New System.Drawing.Point(113, 224)
        Me.CmbTicket.Name = "CmbTicket"
        Me.CmbTicket.Size = New System.Drawing.Size(212, 21)
        Me.CmbTicket.TabIndex = 9
        '
        'cmbFase
        '
        Me.cmbFase.Location = New System.Drawing.Point(364, 25)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(133, 21)
        Me.cmbFase.TabIndex = 2
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(543, 25)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(73, 22)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'CmbImpFac
        '
        Me.CmbImpFac.Location = New System.Drawing.Point(113, 141)
        Me.CmbImpFac.Name = "CmbImpFac"
        Me.CmbImpFac.Size = New System.Drawing.Size(212, 21)
        Me.CmbImpFac.TabIndex = 6
        '
        'FrmCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(835, 671)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpBloqueo)
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
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.GrpBloqueo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public idClaseCancel As String = ""
    Public IdClase As String = ""
    Public Padre As String
    Public Mostrador As String
    Public CAJClave As String
    Public PDVClave As String
    Public Clave As String
    Public Nombre As String
    Public Estado As Integer
    Public Manual As Integer
    Public Fase As Integer
    Public PRNClavePic As String = ""
    Public CorteDetallado As Integer
    Public Transferencia As Integer
    Public ConfirmarAbono As Integer = 0
    Public reciboTicket As Integer = 0
    Public mostrarNotas As Integer = 0
    Public incluirCierre As Boolean = False
    Public Anticipos As Integer = 0
    Public LimiteEfectivo As Double
    Public LimiteCheque As Double
    Public LimiteVales As Double
    Public Stage As String = ""
    Public StageCancelacion As String = ""
    Public StageLU As String = ""
    Public FormatoCorte As String = ""
    Public ImpFac As String = ""
    Public ImpRec As String = ""
    Public TIKClave As String = ""
    Public SUCClave As String = ""
    Public ALMClave As String = ""
    Public ALMClaveDev As String = ""
    Public TICDevolucion As String = ""
    Public Procesador As String = ""
    Public Cajon As Boolean = False
    Public Aplicacion As String = ""
    Public copiaCredito As Integer = 0
    Public Bloqueo As String = "0|0|0|0|0|0|0|0|0|0|0"
    Public FormatoRecibo As String = "Carta"
    Public idPOS As String
    Public idCajero As Integer
    Public passCajero As String

    Private sMostrador As String = ""
    Private alerta(14) As PictureBox
    Private reloj As parpadea
    Private cpyPDVClave As String = ""
    Private cpyStage As String = ""
    Private cpyStageCancelacion As String = ""
    Private cpyStageLU As String = ""
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

        If Me.cmbAlmacenDev.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
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

        If Me.cmbCorte.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cpyStage = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cpyStageCancelacion = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cpyStageLU = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbRecibo.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
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
        alerta(9) = Me.PictureBox23
        alerta(10) = Me.PictureBox8
        alerta(11) = Me.PictureBox10
        alerta(12) = Me.PictureBox11
        alerta(13) = Me.PictureBox33
        alerta(14) = Me.PictureBox13

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        bLoad = True

        With Me.cmbFase
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Caja"
            .NombreParametro2 = "campo"
            .Parametro2 = "Fase"
            .llenar()
        End With



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
            .Parametro1 = SUCClave
            .llenar()
        End With

        With cmbAlmacenDev
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.cmbPicking
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.cmbTipoDocumento
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_clasedocumento"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .NombreParametro2 = "Tipo"
            .Parametro2 = 2
            .llenar()
        End With


        With Me.cmbTipoCancel
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_clasedocumento"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .NombreParametro2 = "Tipo"
            .Parametro2 = 5
            .llenar()
        End With

        cmbRecibo.SelectedItem = FormatoRecibo

        TxtNombre.Text = Clave
        TxtDescripcion.Text = Nombre
        CmbSucursal.SelectedValue = SUCClave
        CmbAlmacen.SelectedValue = ALMClave
        cmbAlmacenDev.SelectedValue = ALMClaveDev
        CmbImpFac.SelectedValue = ImpFac
        CmbImpRec.SelectedValue = ImpRec
        cmbPicking.SelectedValue = PRNClavePic
        cmbFase.SelectedValue = Fase
        ChkEstado.Estado = Estado
        ChkManual.Estado = Manual
        ChkCajon.Checked = Cajon
        ChkAbono.Estado = ConfirmarAbono
        ChkRecibo.Estado = reciboTicket
        ChkNotas.Estado = mostrarNotas
        chkCierre.Checked = incluirCierre
        ChkAnticipos.Estado = Anticipos

        CmbTicket.SelectedValue = TIKClave
        CmbDevolucion.SelectedValue = TICDevolucion
        TxtEfectivo.Text = CStr(LimiteEfectivo)
        TxtCheque.Text = CStr(LimiteCheque)
        TxtVales.Text = CStr(LimiteVales)
        TxtProcesador.Text = Procesador
        TxtAplicacion.Text = Aplicacion
        NumCopias.Value = copiaCredito
        ChkDetallado.Estado = CorteDetallado
        ChkTransferencia.Estado = Transferencia
        cmbCorte.SelectedItem = FormatoCorte

        cmbTipoDocumento.SelectedValue = IdClase
        cmbTipoCancel.SelectedValue = idClaseCancel

        TxtIdCajero.Text = CStr(idCajero)
        TxtIdPos.Text = idPOS
        TxtPassCajero.Text = passCajero

        Dim dt As DataTable

        If Stage <> "" Then
            dt = ModPOS.SiExisteRecupera("sp_recupera_ubicacion", "@UBCClave", Stage)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                TxtStage.Text = dt.Rows(0)("Ubicacion")
                dt.Dispose()
            End If
        Else
            TxtStage.Text = ""
        End If

        If PDVClave <> "" Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", PDVClave)
            txtPOS.Text = dt.Rows(0)("Referencia")
            cpyPDVClave = PDVClave
            dt.Dispose()
        Else
            txtPOS.Text = ""
            cpyPDVClave = PDVClave
        End If

        If StageCancelacion <> "" Then
            dt = ModPOS.SiExisteRecupera("sp_recupera_ubicacion", "@UBCClave", StageCancelacion)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                txtStageCancelacion.Text = dt.Rows(0)("Ubicacion")
                dt.Dispose()
            End If
        Else
            txtStageCancelacion.Text = ""
        End If


        If StageLU <> "" Then
            dt = ModPOS.SiExisteRecupera("sp_recupera_ubicacion", "@UBCClave", StageLU)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                txtStageLU.Text = dt.Rows(0)("Ubicacion")
                dt.Dispose()
            End If
        Else
            txtStageLU.Text = ""
        End If

        cpyStage = Stage
        cpyStageCancelacion = StageCancelacion
        cpyStageLU = StageLU

        If Bloqueo.Split("|").Length >= 5 Then
            Dim i As Integer
            For i = 0 To Bloqueo.Split("|").Length - 1
                Select Case i
                    Case Is = 0
                        ChkRetiro.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 1
                        ChkCambio.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 2
                        ChkReembolso.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 3
                        ChkComision.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 4
                        ChkDevolucion.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 5
                        ChkFactura.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 6
                        ChkCargo.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 7
                        ChkMasiva.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 8
                        ChkGlobal.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 9
                        ChkPedido.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 10
                        ChkServicio.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 11
                        ChkNC.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 12
                        ChkPago.Estado = CInt(Bloqueo.Split("|")(i))
                    Case Is = 13
                        ChkApartados.Estado = CInt(Bloqueo.Split("|")(i))
                End Select
            Next
        End If

        If Mostrador <> "" Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", Mostrador)
            If dt.Rows.Count > 0 Then
                TxtMostrador.Text = dt.Rows(0)("Clave")
                LblCliente.Text = dt.Rows(0)("RazonSocial")
                sMostrador = Mostrador
            Else
                TxtMostrador.Text = ""
                LblCliente.Text = ""

            End If
            dt.Dispose()
        End If
    End Sub

    Public Sub reinicializar()
        idClaseCancel = ""
        IdClase = ""
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
        ConfirmarAbono = 0

        LimiteEfectivo = 0
        LimiteCheque = 0
        LimiteVales = 0
        Procesador = ""
        ALMClave = ""
        ALMClaveDev = ""
        Cajon = False
        incluirCierre = False
        Aplicacion = ""
        Transferencia = 0
        FormatoCorte = "Resumen"
        Mostrador = ""
        FormatoRecibo = "Carta"
        cpyPDVClave = ""

        PDVClave = cpyPDVClave
        txtPOS.Text = ""

        sMostrador = Mostrador
        TxtMostrador.Text = ""
        LblCliente.Text = ""

        TxtAplicacion.Text = Aplicacion
        TxtNombre.Text = Clave
        TxtDescripcion.Text = Nombre
        CmbImpFac.SelectedValue = ImpFac
        CmbImpRec.SelectedValue = ImpRec
        cmbPicking.SelectedValue = PRNClavePic

        cmbFase.SelectedValue = Fase
        ChkEstado.Estado = Estado
        ChkAbono.Estado = ConfirmarAbono

        ChkCajon.Checked = Cajon
        chkCierre.Checked = incluirCierre

        CmbTicket.SelectedValue = TIKClave
        CmbDevolucion.SelectedValue = TICDevolucion
        CmbSucursal.SelectedValue = SUCClave
        CmbAlmacen.SelectedValue = ALMClave
        cmbAlmacenDev.SelectedValue = ALMClaveDev
        cmbRecibo.SelectedItem = FormatoRecibo
        TxtEfectivo.Text = CStr(LimiteEfectivo)
        TxtCheque.Text = CStr(LimiteCheque)
        TxtVales.Text = CStr(LimiteVales)
        TxtProcesador.Text = Procesador
        ChkTransferencia.Estado = Transferencia
        cmbCorte.SelectedItem = FormatoCorte
        cmbTipoDocumento.SelectedValue = IdClase
        cmbTipoCancel.SelectedValue = idClaseCancel

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
            Dim cpyBloqueo As String

            cpyBloqueo = CStr(ChkRetiro.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkCambio.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkReembolso.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkComision.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkDevolucion.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkFactura.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkCargo.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkMasiva.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkGlobal.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkPedido.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkServicio.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkNC.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkPago.GetEstado) & "|"
            cpyBloqueo &= CStr(ChkApartados.GetEstado)

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
                    ALMClaveDev = cmbAlmacenDev.SelectedValue
                    Fase = cmbFase.SelectedValue
                    LimiteEfectivo = cpyLimiteEfectivo
                    LimiteCheque = cpyLimiteCheque
                    LimiteVales = cpyLimiteVales
                    TICDevolucion = CmbDevolucion.SelectedValue
                    Procesador = TxtProcesador.Text
                    Manual = ChkManual.GetEstado
                    Cajon = ChkCajon.Checked
                    incluirCierre = chkCierre.Checked
                    Aplicacion = TxtAplicacion.Text
                    PRNClavePic = cmbPicking.SelectedValue
                    NumCopias.Value = copiaCredito
                    CorteDetallado = ChkDetallado.GetEstado
                    Transferencia = ChkTransferencia.GetEstado
                    ConfirmarAbono = ChkAbono.GetEstado
                    reciboTicket = ChkRecibo.GetEstado
                    mostrarNotas = ChkNotas.GetEstado
                    Anticipos = ChkAnticipos.GetEstado
                    FormatoCorte = cmbCorte.SelectedItem
                    Bloqueo = cpyBloqueo
                    Stage = cpyStage
                    StageCancelacion = cpyStageCancelacion
                    StageLU = cpyStageLU
                    Mostrador = sMostrador
                    IdClase = cmbTipoDocumento.SelectedValue
                    idClaseCancel = cmbTipoCancel.SelectedValue
                    FormatoRecibo = cmbRecibo.SelectedItem
                    PDVClave = cpyPDVClave
                    idPOS = TxtIdPos.Text
                    idCajero = TxtIdCajero.Text
                    passCajero = TxtPassCajero.Text

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
                    "@ALMClaveDev", ALMClaveDev, _
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
                    "@Transferencia", Transferencia, _
                    "@FormatoCorte", FormatoCorte, _
                    "@Stage", Stage, _
                    "@StageCancelacion", StageCancelacion, _
                    "@StageLU", StageLU, _
                    "@Bloqueo", Bloqueo, _
                    "@confirmaAbono", ConfirmarAbono, _
                    "@reciboTicket", reciboTicket, _
                    "@mostrarNotas", mostrarNotas, _
                    "@incluirCierre", incluirCierre, _
                    "@Anticipos", Anticipos, _
                    "@Usuario", ModPOS.UsuarioActual, _
                    "@IdClase", IdClase, _
                    "@IdClaseCancel", idClaseCancel, _
                    "@Mostrador", Mostrador, _
                    "@PDVClave", PDVClave, _
                    "@FormatoRecibo", FormatoRecibo, _
                    "@idPos", idPOS, _
                    "@idCajero", idCajero, _
                    "@passCajero", passCajero)

                    reinicializar()

                    If Not ModPOS.MtoCajas Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoCajas.GridCaja, "sp_muestra_caja", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoCajas.GridCaja.RootTable.Columns("ID").Visible = False

                    End If


                Case "Modificar"


                    If Not (Clave = UCase(Trim(Me.TxtNombre.Text)) AndAlso _
                               Mostrador = sMostrador AndAlso _
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
                        ALMClaveDev = cmbAlmacenDev.SelectedValue AndAlso _
                        Manual = ChkManual.GetEstado AndAlso _
                        Cajon = ChkCajon.Checked AndAlso _
                        Aplicacion = TxtAplicacion.Text AndAlso _
                        PRNClavePic = cmbPicking.SelectedValue AndAlso _
                        NumCopias.Value = copiaCredito AndAlso _
                        CorteDetallado = ChkDetallado.GetEstado AndAlso _
                        Transferencia = ChkTransferencia.GetEstado AndAlso _
                        FormatoCorte = cmbCorte.SelectedItem AndAlso _
                        Bloqueo = cpyBloqueo AndAlso _
                        ConfirmarAbono = ChkAbono.GetEstado AndAlso _
                        cpyStage = Stage AndAlso _
                         reciboTicket = ChkRecibo.GetEstado AndAlso _
                        mostrarNotas = ChkNotas.GetEstado AndAlso _
                         incluirCierre = chkCierre.Checked AndAlso _
                        Anticipos = ChkAnticipos.GetEstado AndAlso _
                        cpyStageCancelacion = StageCancelacion AndAlso _
                        StageLU = cpyStageLU AndAlso _
                        IdClase = cmbTipoDocumento.SelectedValue AndAlso _
                        idClaseCancel = cmbTipoCancel.SelectedValue AndAlso _
                         FormatoRecibo = cmbRecibo.SelectedItem AndAlso _
                          PDVClave = cpyPDVClave AndAlso _
                        Estado = ChkEstado.GetEstado AndAlso _
                        idCajero = TxtIdCajero.Text AndAlso _
                        idPOS = TxtIdPos.Text AndAlso _
                        passCajero = TxtPassCajero.Text) Then


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
                        ConfirmarAbono = ChkAbono.GetEstado
                        reciboTicket = ChkRecibo.GetEstado
                        mostrarNotas = ChkNotas.GetEstado
                        incluirCierre = chkCierre.Checked
                        Anticipos = ChkAnticipos.GetEstado
                        Procesador = TxtProcesador.Text
                        Cajon = ChkCajon.Checked
                        ALMClave = CmbAlmacen.SelectedValue
                        ALMClaveDev = cmbAlmacenDev.SelectedValue
                        Aplicacion = TxtAplicacion.Text
                        copiaCredito = NumCopias.Value
                        CorteDetallado = ChkDetallado.GetEstado
                        Transferencia = ChkTransferencia.GetEstado
                        FormatoCorte = cmbCorte.SelectedItem
                        Bloqueo = cpyBloqueo
                        Stage = cpyStage
                        StageCancelacion = cpyStageCancelacion
                        StageLU = cpyStageLU
                        Mostrador = sMostrador
                        IdClase = cmbTipoDocumento.SelectedValue
                        idClaseCancel = cmbTipoCancel.SelectedValue
                        FormatoRecibo = cmbRecibo.SelectedItem
                        PDVClave = cpyPDVClave
                        idPOS = TxtIdPos.Text
                        idCajero = TxtIdCajero.Text
                        passCajero = TxtPassCajero.Text

                        ModPOS.Ejecuta("sp_modificar_caja", _
                        "@CAJClave", CAJClave, _
                        "@Nombre", Nombre, _
                        "@ImpFac", ImpFac, _
                        "@ImpRec", ImpRec, _
                        "@TIKClave", TIKClave, _
                        "@Devolucion", TICDevolucion, _
                        "@SUCClave", SUCClave, _
                        "@ALMClave", ALMClave, _
                        "@ALMClaveDev", ALMClaveDev, _
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
                        "@Transferencia", Transferencia, _
                        "@FormatoCorte", FormatoCorte, _
                        "@Stage", Stage, _
                        "@StageCancelacion", StageCancelacion, _
                          "@StageLU", StageLU, _
                        "@Bloqueo", Bloqueo, _
                        "@confirmaAbono", ConfirmarAbono, _
                        "@reciboTicket", reciboTicket, _
                        "@mostrarNotas", mostrarNotas, _
                        "@incluirCierre", incluirCierre, _
                        "@Anticipos", Anticipos, _
                        "@Mostrador", Mostrador, _
                         "@IdClase", IdClase, _
                          "@IdClaseCancel", idClaseCancel, _
                           "@FormatoRecibo", FormatoRecibo, _
                           "@PDVClave", PDVClave, _
                        "@Usuario", ModPOS.UsuarioActual, _
                        "@idPos", idPOS, _
                        "@idCajero", idCajero, _
                        "@passCajero", passCajero)

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

            With cmbAlmacenDev
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

            With Me.cmbTipoDocumento
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_filtra_clasedocumento"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .NombreParametro2 = "Tipo"
                .Parametro2 = 2
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


    Private Sub BtnStage_Click(sender As Object, e As EventArgs) Handles BtnStage.Click
        If Not cmbAlmacenDev.SelectedValue Is Nothing Then
            Dim a As New FrmConsulta
            a.Campo = "UBCClave"
            a.Campo2 = "Stage"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_aduana", "@ALMClave", cmbAlmacenDev.SelectedValue, "@Transito", 1)
            a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    cpyStage = a.ID
                    Me.TxtStage.Text = a.ID2
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("No se encuentra un Almacén de Devolución valido seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            If CmbAlmacen.SelectedValue.GetType.ToString <> "System.Data.DataRowView" AndAlso CmbAlmacen.SelectedValue <> ALMClave Then
                cpyStageLU = ""
                Me.txtStageLU.Text = ""
                cpyStageCancelacion = ""
                txtStageCancelacion.Text = ""



            End If
        End If
    End Sub

    Private Sub BtnStageCancelacion_Click(sender As Object, e As EventArgs) Handles BtnStageCancelacion.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New FrmConsulta
            a.Campo = "UBCClave"
            a.Campo2 = "Stage"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_aduana", "@ALMClave", CmbAlmacen.SelectedValue)
            a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    cpyStageCancelacion = a.ID
                    Me.txtStageCancelacion.Text = a.ID2
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("No se encuentra un Almacén valido seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnBuscaCte_Click(sender As Object, e As EventArgs) Handles btnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                sMostrador = a.valor
                TxtMostrador.Text = a.Descripcion
                LblCliente.Text = a.Descripcion2
            End If
        End If
        a.Dispose()
    End Sub



    Private Sub btnStageLU_Click(sender As Object, e As EventArgs) Handles btnStageLU.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New FrmConsulta
            a.Campo = "UBCClave"
            a.Campo2 = "Stage"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_aduana", "@ALMClave", CmbAlmacen.SelectedValue)
            a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    cpyStageLU = a.ID
                    Me.txtStageLU.Text = a.ID2
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("No se encuentra un Almacén valido seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


   
    Private Sub cmbAlmacenDev_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAlmacenDev.SelectedValueChanged
        If Not cmbAlmacenDev.SelectedValue Is Nothing Then
            If cmbAlmacenDev.SelectedValue.GetType.ToString <> "System.Data.DataRowView" AndAlso cmbAlmacenDev.SelectedValue <> ALMClaveDev Then
                cpyStage = ""
                Me.TxtStage.Text = ""
            End If
        End If
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        If Not CmbSucursal.SelectedValue Is Nothing Then
            Dim a As New FrmConsulta
            a.Campo = "PDVClave"
            a.Campo2 = "Referencia"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_filtra_puntodeventa", "@SUCClave", CmbSucursal.SelectedValue)
            a.GridConsultaGen.RootTable.Columns("PDVClave").Visible = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    cpyPDVClave = a.ID
                    Me.txtPOS.Text = a.ID2
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("No se encuentra una Sucursal valida seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
