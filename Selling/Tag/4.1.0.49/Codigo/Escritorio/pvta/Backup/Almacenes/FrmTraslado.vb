Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmTraslado
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblOrigen As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNotas As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As Selling.StoreCombo
    Friend WithEvents cmbUnidad As Selling.StoreCombo
    Friend WithEvents cmbOrigen As Selling.StoreCombo
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecRegistro As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursalO As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursalD As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbTipoEntrega As Selling.StoreCombo
    Friend WithEvents CmbFormaEnvio As Selling.StoreCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtSolicita As System.Windows.Forms.TextBox
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblExistencia As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTraslado))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtSolicita = New System.Windows.Forms.TextBox
        Me.TxtMotivo = New System.Windows.Forms.TextBox
        Me.CmbFormaEnvio = New Selling.StoreCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbTipoEntrega = New Selling.StoreCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TxtNotas = New System.Windows.Forms.TextBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmbSucursalD = New Selling.StoreCombo
        Me.cmbSucursalO = New Selling.StoreCombo
        Me.cmbOrigen = New Selling.StoreCombo
        Me.cmbDestino = New Selling.StoreCombo
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblOrigen = New System.Windows.Forms.Label
        Me.LblDestino = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtFechaPrevista = New System.Windows.Forms.DateTimePicker
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.LblExistencia = New System.Windows.Forms.Label
        Me.cmbUnidad = New Selling.StoreCombo
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtEstado = New System.Windows.Forms.TextBox
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.TxtFecRegistro = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.Label10)
        Me.GrpGeneral.Controls.Add(Me.TxtSolicita)
        Me.GrpGeneral.Controls.Add(Me.TxtMotivo)
        Me.GrpGeneral.Controls.Add(Me.CmbFormaEnvio)
        Me.GrpGeneral.Controls.Add(Me.Label9)
        Me.GrpGeneral.Controls.Add(Me.cmbTipoEntrega)
        Me.GrpGeneral.Controls.Add(Me.Label8)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.TxtNotas)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.PictureBox5)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.cmbSucursalD)
        Me.GrpGeneral.Controls.Add(Me.cmbSucursalO)
        Me.GrpGeneral.Controls.Add(Me.cmbOrigen)
        Me.GrpGeneral.Controls.Add(Me.cmbDestino)
        Me.GrpGeneral.Controls.Add(Me.Label6)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.LblOrigen)
        Me.GrpGeneral.Controls.Add(Me.LblDestino)
        Me.GrpGeneral.Location = New System.Drawing.Point(8, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(545, 198)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 16)
        Me.Label10.TabIndex = 148
        Me.Label10.Text = "Solicita"
        '
        'TxtSolicita
        '
        Me.TxtSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSolicita.Location = New System.Drawing.Point(71, 107)
        Me.TxtSolicita.Name = "TxtSolicita"
        Me.TxtSolicita.Size = New System.Drawing.Size(464, 21)
        Me.TxtSolicita.TabIndex = 147
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivo.Location = New System.Drawing.Point(71, 80)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.Size = New System.Drawing.Size(464, 21)
        Me.TxtMotivo.TabIndex = 146
        '
        'CmbFormaEnvio
        '
        Me.CmbFormaEnvio.Location = New System.Drawing.Point(349, 167)
        Me.CmbFormaEnvio.Name = "CmbFormaEnvio"
        Me.CmbFormaEnvio.Size = New System.Drawing.Size(187, 21)
        Me.CmbFormaEnvio.TabIndex = 141
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(288, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 16)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "F. Envío"
        '
        'cmbTipoEntrega
        '
        Me.cmbTipoEntrega.Location = New System.Drawing.Point(71, 167)
        Me.cmbTipoEntrega.Name = "cmbTipoEntrega"
        Me.cmbTipoEntrega.Size = New System.Drawing.Size(211, 21)
        Me.cmbTipoEntrega.TabIndex = 143
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 16)
        Me.Label8.TabIndex = 144
        Me.Label8.Text = "T. Entrega"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(15, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 124
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(304, 24)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 125
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtNotas
        '
        Me.TxtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotas.Location = New System.Drawing.Point(71, 140)
        Me.TxtNotas.Name = "TxtNotas"
        Me.TxtNotas.Size = New System.Drawing.Size(465, 21)
        Me.TxtNotas.TabIndex = 3
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(304, 53)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 126
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(288, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Almacén"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(15, 84)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 129
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cmbSucursalD
        '
        Me.cmbSucursalD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalD.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalD.Location = New System.Drawing.Point(48, 48)
        Me.cmbSucursalD.Name = "cmbSucursalD"
        Me.cmbSucursalD.Size = New System.Drawing.Size(234, 21)
        Me.cmbSucursalD.TabIndex = 132
        '
        'cmbSucursalO
        '
        Me.cmbSucursalO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalO.Location = New System.Drawing.Point(48, 22)
        Me.cmbSucursalO.Name = "cmbSucursalO"
        Me.cmbSucursalO.Size = New System.Drawing.Size(234, 21)
        Me.cmbSucursalO.TabIndex = 131
        '
        'cmbOrigen
        '
        Me.cmbOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOrigen.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOrigen.Location = New System.Drawing.Point(349, 22)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(187, 21)
        Me.cmbOrigen.TabIndex = 128
        '
        'cmbDestino
        '
        Me.cmbDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDestino.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDestino.Location = New System.Drawing.Point(349, 51)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(187, 21)
        Me.cmbDestino.TabIndex = 126
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Nota"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Motivo"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Origen"
        '
        'LblOrigen
        '
        Me.LblOrigen.Location = New System.Drawing.Point(288, 25)
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Size = New System.Drawing.Size(56, 16)
        Me.LblOrigen.TabIndex = 95
        Me.LblOrigen.Text = "Almacén"
        '
        'LblDestino
        '
        Me.LblDestino.Location = New System.Drawing.Point(4, 51)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(56, 16)
        Me.LblDestino.TabIndex = 127
        Me.LblDestino.Text = "Destino"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(10, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 135
        Me.Label7.Text = "F. Prevista"
        '
        'dtFechaPrevista
        '
        Me.dtFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaPrevista.Location = New System.Drawing.Point(97, 137)
        Me.dtFechaPrevista.Name = "dtFechaPrevista"
        Me.dtFechaPrevista.Size = New System.Drawing.Size(118, 20)
        Me.dtFechaPrevista.TabIndex = 134
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(364, 40)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox6.TabIndex = 130
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(597, 551)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(694, 551)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.BtnDel)
        Me.GrpDetalle.Controls.Add(Me.LblExistencia)
        Me.GrpDetalle.Controls.Add(Me.cmbUnidad)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtClaveProd)
        Me.GrpDetalle.Controls.Add(Me.PictureBox6)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(8, 208)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(776, 337)
        Me.GrpDetalle.TabIndex = 2
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'LblExistencia
        '
        Me.LblExistencia.Location = New System.Drawing.Point(388, 42)
        Me.LblExistencia.Name = "LblExistencia"
        Me.LblExistencia.Size = New System.Drawing.Size(195, 16)
        Me.LblExistencia.TabIndex = 131
        Me.LblExistencia.Text = "Existencia: "
        '
        'cmbUnidad
        '
        Me.cmbUnidad.Location = New System.Drawing.Point(71, 39)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(149, 21)
        Me.cmbUnidad.TabIndex = 127
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(221, 40)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(137, 20)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 18)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(718, 14)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(48, 24)
        Me.BtnBuscaProd.TabIndex = 1
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(221, 15)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(491, 21)
        Me.TxtDescripcion.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Prod. Cve."
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(71, 15)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(149, 21)
        Me.TxtClaveProd.TabIndex = 0
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(8, 66)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(760, 265)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtFechaPrevista)
        Me.GroupBox1.Controls.Add(Me.TxtEstado)
        Me.GroupBox1.Controls.Add(Me.TxtFolio)
        Me.GroupBox1.Controls.Add(Me.TxtFecRegistro)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(559, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 198)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'TxtEstado
        '
        Me.TxtEstado.Enabled = False
        Me.TxtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstado.Location = New System.Drawing.Point(13, 74)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.ReadOnly = True
        Me.TxtEstado.Size = New System.Drawing.Size(202, 26)
        Me.TxtEstado.TabIndex = 93
        Me.TxtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(13, 46)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(202, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'TxtFecRegistro
        '
        Me.TxtFecRegistro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFecRegistro.Enabled = False
        Me.TxtFecRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecRegistro.Location = New System.Drawing.Point(13, 107)
        Me.TxtFecRegistro.Multiline = True
        Me.TxtFecRegistro.Name = "TxtFecRegistro"
        Me.TxtFecRegistro.ReadOnly = True
        Me.TxtFecRegistro.Size = New System.Drawing.Size(202, 21)
        Me.TxtFecRegistro.TabIndex = 108
        Me.TxtFecRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 18)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "FOLIO"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(718, 40)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(48, 24)
        Me.BtnDel.TabIndex = 134
        Me.BtnDel.ToolTipText = "Elimina la partida seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTraslado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FrmTraslado"
        Me.Text = "Traslado"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public Referencia As String = ""

    Public FormPadre As String = ""
    Public Formato As Integer = 2
    Public TRSClave As String
    Public Folio As String
    Public SUCClave As String
    Public ALMClave As String
    Public SUCDestino As String = ""
    Public ALMDestino As String = ""
    Public Motivo As String
    Public Solicita As String
    Public FecRegistro As DateTime
    Public DescripcionEstado As String
    Public Autorizo As String = ""
    Public Nombre As String
    Public Notas As String = ""
    Public fechaPrevista As Date = Today.Date
    Public tipoEntrega As Integer
    Public formaEnvio As Integer

    Public Estado As Integer = 1
    Public EstadoActual As Integer

    Private Transito, Picking As Boolean
    Private TCosto As Integer
    Private dtDetalle As DataTable
    Private bLoad As Boolean = False
    Private PROClave As String
    Private TProducto As Integer
    Private Cantidad As Double
    Private Clave As String
    Private Costo As Double
    Private NumDecimales As Integer
    Private Disponible As Double
    Private Autoriza As String

    Private alerta(5) As PictureBox
    Private reloj As parpadea

    Private Sub recuperaAlmacenOrigen()
        If Not cmbSucursalO.SelectedValue Is Nothing Then
            SUCClave = cmbSucursalO.SelectedValue
            With cmbOrigen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        Else
            SUCClave = ""
        End If
    End Sub

    Private Sub recuperaAlmacenDestino()
        If Not cmbSucursalD.SelectedValue Is Nothing Then
            SUCDestino = cmbSucursalD.SelectedValue
            With cmbDestino
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCDestino
                .llenar()
            End With
        Else
            SUCDestino = ""
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbSucursalO.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbSucursalD.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbDestino.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtMotivo.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
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

    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"))
        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

            PROClave = dtProducto.Rows(0)("PROClave")
            TProducto = dtProducto.Rows(0)("TProducto")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")


            NumDecimales = dtProducto.Rows(0)("Num_Decimales")

            dtProducto.Dispose()

            dtProducto = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", PROClave, "@ALMClave", ALMClave)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
                Disponible = dtProducto.Rows(0)("Disponible")
                dtProducto.Dispose()
            Else
                Disponible = 0
            End If


            LblExistencia.Text = "Existencia: " & CStr(Disponible)

            Me.TxtDescripcion.Text = Nombre

            TxtCantidad.DecimalDigits = NumDecimales

            TxtClaveProd.Text = Clave

            TxtCantidad.Focus()

            With Me.cmbUnidad
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_unidad_vta"
                .NombreParametro1 = "PROClave"
                .Parametro1 = PROClave
                .llenar()
            End With

        Else
            PROClave = ""
            TProducto = 0
            Cantidad = 0
            Clave = ""
            Costo = 0
            Disponible = 0
            LblExistencia.Text = "Existencia: " & CStr(Disponible)
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Function validaExistencia() As Boolean
        Dim dtDisponible As DataTable
        Dim Disponible As Double
        Dim result As Boolean = True
        Dim i As Integer

        For i = 0 To dtDetalle.Rows.Count - 1

            dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", dtDetalle.Rows(i)("PROClave"), "@ALMClave", ALMClave)

            If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                Disponible = dtDisponible.Rows(0)("Disponible")
                dtDisponible.Dispose()
            Else
                Disponible = 0
            End If

            If dtDetalle.Rows(i)("Cantidad") > Disponible Then
                result = False
                MessageBox.Show("La cantidad registrada del producto " & CStr(dtDetalle.Rows(i)("Clave")) & " excede la cantidad disponible (" & CStr(Disponible) & "), por lo que no es posible cerrar el documento actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit For
            Else
                result = True
            End If
        Next


        Return result

    End Function

    Private Sub actualizaExistencia(ByVal Tipo As Integer)
        Dim i As Integer = 0
        For i = 0 To dtDetalle.Rows.Count - 1
            ModPOS.Ejecuta("sp_actualiza_exist_producto", "@ALMClave", ALMClave, "@PROClave", dtDetalle.Rows(i)("PROClave"), "@TProducto", dtDetalle.Rows(i)("TProducto"), "@Cantidad", dtDetalle.Rows(i)("Cantidad"), "@Mov", Tipo)
        Next

    End Sub

    Private Sub FrmTraslado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Costeo"
                        TCosto = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Exit For
                End Select
            Next
        End With

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        With cmbSucursalO
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        With cmbSucursalD
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_all_sucursal"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With


        With Me.cmbTipoEntrega
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "tipoEntrega"
            .llenar()
        End With

        With Me.CmbFormaEnvio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "formaEnvio"
            .llenar()
        End With

        If Padre = "Nuevo" Then

            If ModPOS.SucursalPredeterminada <> "" Then
                cmbSucursalO.SelectedValue = ModPOS.SucursalPredeterminada
            End If

            recuperaAlmacenOrigen()

            If cmbOrigen.SelectedValue Is Nothing Then
                ALMClave = ""
            Else
                ALMClave = cmbOrigen.SelectedValue
            End If

            recuperaAlmacenDestino()

            If cmbDestino.SelectedValue Is Nothing Then
                ALMDestino = ""
            Else
                ALMDestino = cmbDestino.SelectedValue
            End If

        End If





        If Padre = "Nuevo" Then

            dtFechaPrevista.Value = fechaPrevista

            Me.TxtFecRegistro.Text = DateTime.Now.ToShortDateString 'ToString("MMMM dd, yyyy")
            dtDetalle = ModPOS.CrearTabla("TrasladoDetalle", _
                                          "ID", "System.String", _
                                          "PROClave", "System.String", _
                                          "TProducto", "System.Int32", _
                                          "Costo", "System.Double", _
                                          "Total", "System.Double", _
                                          "Cantidad", "System.Double", _
                                          "Clave", "System.String", _
                                          "Nombre", "System.String")

            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("ID").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("Total").Visible = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
            cmbDestino.SelectedValue = ALMDestino

        Else

            Me.TxtFolio.Text = Folio
            TxtFolio.Enabled = False
            TxtMotivo.Text = Motivo
            TxtSolicita.Text = Solicita
            dtFechaPrevista.Value = fechaPrevista

            Me.TxtFecRegistro.Text = FecRegistro.ToShortDateString
            TxtNotas.Text = Notas
            cmbSucursalD.SelectedValue = SUCDestino
            cmbSucursalO.SelectedValue = SUCClave
            Me.recuperaAlmacenOrigen()
            cmbOrigen.SelectedValue = ALMClave
            Me.recuperaAlmacenDestino()
            cmbDestino.SelectedValue = ALMDestino
            CmbFormaEnvio.SelectedValue = formaEnvio
            cmbTipoEntrega.SelectedValue = tipoEntrega

            cmbSucursalO.Enabled = False
            cmbOrigen.Enabled = False

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", TRSClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("ID").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("Total").Visible = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        End If

        bLoad = True

        EstadoActual = Estado

        TxtEstado.Text = recuperaValorRef("MOVALM", "Estado", EstadoActual)

        If EstadoActual > 1 Then
            cmbSucursalO.Enabled = False
            cmbSucursalD.Enabled = False
            Me.cmbDestino.Enabled = False
            Me.cmbOrigen.Enabled = False
            Me.TxtMotivo.Enabled = False
            TxtSolicita.Enabled = False
            Me.cmbUnidad.Enabled = False
            Me.dtFechaPrevista.Enabled = False
            Me.TxtNotas.Enabled = False
            Me.TxtCantidad.Enabled = False
            Me.TxtClaveProd.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnBuscaProd.Enabled = False
            BtnDel.Enabled = False

        End If



    End Sub

    Private Sub FrmTraslado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If FormPadre = "" AndAlso Not ModPOS.MtoTraslados Is Nothing Then

            If Not ModPOS.MtoTraslados.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoTraslados.Periodo > 0 AndAlso ModPOS.MtoTraslados.Mes > 0 Then
                ModPOS.MtoTraslados.refrescaGrid()
            End If

        End If
        ModPOS.Traslado.Dispose()
        ModPOS.Traslado = Nothing
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_producto"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.BusquedaInicial = True
        a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
        a.AlmRequerido = True
        a.ALMClave = ALMClave
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtClaveProd.Text = a.valor
            TxtDescripcion.Text = a.Descripcion
            recuperaProducto(a.valor)
            TxtCantidad.Focus()
        End If
        a.Dispose()


    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtClaveProd.Text) Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            Else
                MessageBox.Show("La clave de producto es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_producto"
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
            a.AlmRequerido = True
            a.ALMClave = ALMClave
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)

            End If
            a.Dispose()

        End If
    End Sub

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            If Not cmbUnidad.SelectedValue Is Nothing Then
                Cantidad = CDbl(cmbUnidad.SelectedValue) * Cantidad
            End If
            If System.String.IsNullOrEmpty(PROClave) Then
                Beep()
                MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else


                If Cantidad > Disponible Then
                    MessageBox.Show("La cantidad registrada excede la cantidad disponible en el almacén origen, el disponible actual es de: " & CStr(Disponible), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Exit Sub
                End If

                If cmbSucursalO.SelectedValue Is Nothing Then
                    MessageBox.Show("La Sucursal Origen seleccionada no es valida o es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("PROClave Like '" & PROClave & "'")

                If foundRows.Length = 0 Then
                    If Cantidad > 0 Then

                        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_obtener_costo", "@SUCClave", cmbSucursalO.SelectedValue, "@PROClave", PROClave)
                        Costo = dt.Rows(0)("CostoVigente")
                        dt.Dispose()

                        Dim row1 As DataRow
                        row1 = dtDetalle.NewRow()
                        'declara el nombre de la fila
                        row1.Item("ID") = ModPOS.obtenerLlave
                        row1.Item("PROClave") = PROClave
                        row1.Item("TProducto") = TProducto
                        row1.Item("Cantidad") = Cantidad
                        row1.Item("Costo") = Costo
                        row1.Item("Total") = Cantidad * Costo
                        row1.Item("Clave") = Clave
                        row1.Item("Nombre") = Nombre
                        dtDetalle.Rows.Add(row1)
                        'agrega la fila completo a la tabla


                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        TProducto = 0
                        Cantidad = 0
                        Costo = 0
                        Clave = ""
                        Nombre = ""
                        LblExistencia.Text = "Existencia:"
                        TxtClaveProd.Focus()
                    Else
                        MessageBox.Show("¡La Cantidad de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf Cantidad = 0 Then
                    'Elimina
                    dtDetalle.Rows.Remove(foundRows(0))

                    TxtClaveProd.Text = ""
                    TxtDescripcion.Text = ""
                    TxtCantidad.Text = 0
                    PROClave = ""
                    TProducto = 0
                    Cantidad = 0
                    Costo = 0
                    Clave = ""
                    Nombre = ""
                    LblExistencia.Text = "Existencia:"
                    TxtClaveProd.Focus()
                ElseIf Cantidad <> foundRows(0)("Cantidad") Then
                    'actualiza
                    foundRows(0)("Cantidad") = Cantidad
                    foundRows(0)("Total") = Costo * Cantidad
                    TxtClaveProd.Text = ""
                    TxtDescripcion.Text = ""
                    TxtCantidad.Text = 0
                    PROClave = ""
                    TProducto = 0
                    Cantidad = 0
                    Costo = 0
                    Clave = ""
                    Nombre = ""
                    LblExistencia.Text = "Existencia:"
                    TxtClaveProd.Focus()
                End If

                If dtDetalle.Rows.Count > 0 Then
                    cmbSucursalO.Enabled = False
                Else
                    cmbSucursalO.Enabled = True
                End If

            End If
        End If
    End Sub

    Private Sub BtnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EstadoActual = 1 AndAlso GridDetalle.RowCount > 0 Then
            Dim a As New MeAutorizacion
            a.Sucursal = cmbSucursalO.SelectedValue
            a.MontodeAutorizacion = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
            a.StartPosition = FormStartPosition.CenterScreen
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.Autorizado Then
                    Autorizo = a.cmbAutoriza.SelectedValue
                    EstadoActual = 2
                    Dim dtmsg As DataTable
                    dtmsg = Recupera_Tabla("sp_recupera_valorref", "@tabla", "MOVALM", "@campo", "Estado", "@estado", EstadoActual)
                    TxtEstado.Text = dtmsg.Rows(0)("Descripcion")
                    dtmsg.Dispose()
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("No es posible autorizar la transferencia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbSucursalO_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSucursalO.SelectedValueChanged
        If bLoad = True Then
            recuperaAlmacenOrigen()
        End If
    End Sub

    Private Sub cmbSucursalD_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSucursalD.SelectedValueChanged
        If bLoad = True Then
            recuperaAlmacenDestino()
        End If
    End Sub

    Private Sub cmbOrigen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrigen.SelectedValueChanged
        If bLoad = True Then
            If cmbOrigen.SelectedValue Is Nothing Then
                ALMClave = ""
            Else
                ALMClave = cmbOrigen.SelectedValue
            End If
        End If
    End Sub

    Private Sub cmbDestino_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDestino.SelectedValueChanged
        If bLoad = True Then
            If cmbDestino.SelectedValue Is Nothing Then
                ALMDestino = ""
            Else
                ALMDestino = cmbDestino.SelectedValue
            End If
        End If
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim dt As DataTable

            If EstadoActual = 1 Then

                If cmbSucursalO.SelectedValue = cmbSucursalD.SelectedValue Then
                    MessageBox.Show("La sucursal destino es requerida y debe ser diferente a la especificada como origen.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If dtFechaPrevista.Value < Today Then
                    MessageBox.Show("La fecha prevista de entrega no puede ser menor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
                Referencia = IIf(dt.Rows(0)("Clave").GetType.Name = "DBNull", False, dt.Rows(0)("Clave"))
                Transito = IIf(dt.Rows(0)("Transito").GetType.Name = "DBNull", False, dt.Rows(0)("Transito"))
                Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))

                dt.Dispose()

                If validaExistencia() = False Then
                    Exit Sub

                End If

            End If

            If GridDetalle.RowCount > 0 Then

                If EstadoActual = 1 Then

                    Dim a As New MeAutorizacion
                    a.Sucursal = cmbSucursalO.SelectedValue
                    a.MontodeAutorizacion = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autorizo = a.cmbAutoriza.SelectedValue
                            Autoriza = a.Autoriza

                            actualizaExistencia(1)

                            If Picking = False Then
                                If Transito = False Then
                                    EstadoActual = 2 'Cerrado
                                Else
                                    EstadoActual = 4 'Transito
                                End If
                            Else
                                EstadoActual = 5 'Picking
                            End If


                            TxtEstado.Text = recuperaValorRef("MOVALM", "Estado", EstadoActual)
                        End If
                    End If
                    a.Dispose()
                End If

                If Padre = "Nuevo" Then


                    Dim Periodo, Mes As Integer

                    dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 4, "@PDVClave", ALMClave)
                    If dt Is Nothing Then
                        ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 4, "@PDVClave", ALMClave)
                        Folio = 1
                        Periodo = Today.Year
                        Mes = Today.Month
                    Else
                        Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                        Periodo = dt.Rows(0)("Periodo")
                        Mes = dt.Rows(0)("Mes")
                        ModPOS.Ejecuta("sp_act_folio", "@Tipo", 4, "@PDVClave", ALMClave, "@Incremento", 1)
                        dt.Dispose()
                    End If


                    Folio = Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)
                    TxtFolio.Text = Folio
                    Notas = TxtNotas.Text.Trim.ToUpper
                    TRSClave = ModPOS.obtenerLlave
                    Motivo = TxtMotivo.Text
                    Solicita = TxtSolicita.Text
                    fechaPrevista = dtFechaPrevista.Value
                    tipoEntrega = cmbTipoEntrega.SelectedValue
                    formaEnvio = CmbFormaEnvio.SelectedValue


                    Dim dTotal As Double = dtDetalle.Compute("Sum(Total)", "Total > 0")

                    ModPOS.Ejecuta("sp_crea_traslado", _
                                "@TRSClave", TRSClave, _
                                "@SUCClave", SUCClave, _
                                "@ALMClave", ALMClave, _
                                "@SUCDestino", SUCDestino, _
                                "@ALMDestino", ALMDestino, _
                                "@Folio", Folio, _
                                "@FechaPrevista", fechaPrevista, _
                                "@Motivo", Motivo, _
                                "@Solicita", Solicita, _
                                "@Registro", ModPOS.UsuarioActual, _
                                "@Autorizo", Autorizo, _
                                "@Notas", Notas, _
                                "@Estado", EstadoActual, _
                                "@Total", dTotal, _
                                "@tipoEntrega", tipoEntrega, _
                                "@formaEnvio", formaEnvio, _
                                "@Usuario", ModPOS.UsuarioActual)

                    Estado = EstadoActual

                    Dim fila As Integer

                    For fila = 0 To dtDetalle.Rows.Count - 1

                        ModPOS.Ejecuta("sp_inserta_trasladodetalle", _
                        "@DTRSClave", dtDetalle.Rows(fila)("ID"), _
                        "@TRSClave", TRSClave, _
                        "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                        "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                        "@Costo", dtDetalle.Rows(fila)("Costo"), _
                        "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                        "@fila", fila + 1, _
                        "@Usuario", ModPOS.UsuarioActual)

                        If EstadoActual = 2 OrElse EstadoActual = 4 OrElse EstadoActual = 5 Then

                            ModPOS.Ejecuta("sp_actualiza_costo", _
                                                        "@SUCClave", SUCDestino, _
                                                        "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                                                        "@TCosto", TCosto, _
                                                        "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                                        "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                                        "@Usuario", ModPOS.UsuarioActual)

                        End If

                    Next



                    If EstadoActual = 2 Then 'Cerrado


                        ModPOS.GeneraMovInv(2, 8, 8, TRSClave, ALMClave, Folio, Autoriza)
                        ModPOS.ActualizaExistAlm(2, 8, TRSClave, ALMClave)
                        ModPOS.ActualizaExistUbc(2, 8, TRSClave, ALMClave)

                        ModPOS.GeneraMovInv(1, 8, 8, TRSClave, ALMDestino, Folio, Autoriza)
                        ModPOS.ActualizaExistAlm(1, 8, TRSClave, ALMDestino)
                        ModPOS.ActualizaExistUbc(1, 8, TRSClave, ALMDestino)



                    ElseIf EstadoActual = 4 Then 'Transito

                        ModPOS.GeneraMovInv(2, 8, 8, TRSClave, ALMClave, Folio, Autoriza)
                        ModPOS.ActualizaExistAlm(2, 8, TRSClave, ALMClave)
                        ModPOS.ActualizaExistUbc(2, 8, TRSClave, ALMClave)

                    ElseIf EstadoActual = 5 Then 'Picking
                        ModPOS.calculaRecoleccion(8, TRSClave, ALMClave)
                    End If

                    Padre = "Modificar"

                Else
                    If Estado = 1 Then
                        If Not (Motivo = TxtMotivo.Text AndAlso _
                                Solicita = TxtSolicita.Text AndAlso _
                                Notas = TxtNotas.Text.Trim.ToUpper AndAlso _
                                Estado = EstadoActual AndAlso _
                                tipoEntrega = cmbTipoEntrega.SelectedValue AndAlso _
                                formaEnvio = CmbFormaEnvio.SelectedValue AndAlso _
                                fechaPrevista = dtFechaPrevista.Value) Then

                            Motivo = TxtMotivo.Text
                            Solicita = TxtSolicita.Text
                            Notas = TxtNotas.Text.Trim.ToUpper
                            fechaPrevista = dtFechaPrevista.Value
                            tipoEntrega = cmbTipoEntrega.SelectedValue
                            formaEnvio = CmbFormaEnvio.SelectedValue

                            Dim dTotal As Double = dtDetalle.Compute("Sum(Total)", "Total > 0")

                            ModPOS.Ejecuta("sp_actualiza_traslado", _
                                                 "@TRSClave", TRSClave, _
                                                 "@SUCDestino", SUCDestino, _
                                                 "@ALMDestino", ALMDestino, _
                                                 "@fechaprevista", fechaPrevista, _
                                                 "@Motivo", Motivo, _
                                                 "@Solicita", Solicita, _
                                                 "@Autorizo", Autorizo, _
                                                 "@Notas", Notas, _
                                                 "@Estado", EstadoActual, _
                                                 "@Total", dTotal, _
                                                 "@tipoEntrega", tipoEntrega, _
                                                 "@formaEnvio", formaEnvio, _
                                                 "@Usuario", ModPOS.UsuarioActual)

                        End If

                        ModPOS.Ejecuta("sp_elimina_trasladodetalle", "@MVAClave", TRSClave)

                        Dim fila As Integer

                        For fila = 0 To dtDetalle.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_trasladodetalle", _
                           "@DTRSClave", dtDetalle.Rows(fila)("ID"), _
                           "@TRSClave", TRSClave, _
                           "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                           "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                           "@Costo", dtDetalle.Rows(fila)("Costo"), _
                           "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                           "@fila", fila + 1, _
                           "@Usuario", ModPOS.UsuarioActual)

                            If Estado = 1 Then
                                If EstadoActual = 2 OrElse EstadoActual = 4 OrElse EstadoActual = 5 Then

                                    ModPOS.Ejecuta("sp_actualiza_costo", _
                                                                "@SUCClave", SUCDestino, _
                                                                "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                                                                "@TCosto", TCosto, _
                                                                "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                                                "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                                                "@Usuario", ModPOS.UsuarioActual)

                                End If
                            End If

                        Next


                        If Estado = 1 Then
                            Estado = EstadoActual
                            If EstadoActual = 2 Then 'Cerrado

                                ModPOS.GeneraMovInv(2, 8, 8, TRSClave, ALMClave, Folio, Autoriza)
                                ModPOS.ActualizaExistAlm(2, 8, TRSClave, ALMClave)
                                ModPOS.ActualizaExistUbc(2, 8, TRSClave, ALMClave)

                                ModPOS.GeneraMovInv(1, 8, 8, TRSClave, ALMDestino, Folio, Autoriza)
                                ModPOS.ActualizaExistAlm(1, 8, TRSClave, ALMDestino)
                                ModPOS.ActualizaExistUbc(1, 8, TRSClave, ALMDestino)

                            ElseIf EstadoActual = 4 Then 'Transito

                                ModPOS.GeneraMovInv(2, 8, 8, TRSClave, ALMClave, Folio, Autoriza)
                                ModPOS.ActualizaExistAlm(2, 8, TRSClave, ALMClave)
                                ModPOS.ActualizaExistUbc(2, 8, TRSClave, ALMClave)
                            ElseIf EstadoActual = 5 Then 'Picking
                                ModPOS.calculaRecoleccion(8, TRSClave, ALMClave)
                            End If
                        End If
                    End If
                End If

                If MessageBox.Show("¿Desea Imprimir el Traslado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    If Formato = 1 Then
                        Dim dtTicket As DataTable
                        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_tikclave", "@SUCClave", SUCClave)

                        Dim sTIKClave As String = ""
                        If Not dtTicket Is Nothing Then
                            sTIKClave = dtTicket.Rows(0)("TIKClave")
                            dtTicket.Dispose()
                        End If

                        Do
                            ModPOS.imprimirTicketTraslado(sTIKClave, True, TRSClave)
                        Loop While MessageBox.Show("¿Desea reimprimir el ticket de traslado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes

                    Else
                        imprimirReporteTraslado(TRSClave)
                    End If
                End If

            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If GridDetalle.RowCount >= 0 AndAlso Not GridDetalle.GetValue("ID") Is Nothing Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el producto: " & GridDetalle.GetValue("Clave") & ", " & GridDetalle.GetValue("Nombre"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("ID = '" & GridDetalle.GetValue("ID") & "'")

                    If foundRows.Length = 1 Then
                        'Elimina
                        dtDetalle.Rows.Remove(foundRows(0))

                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        TProducto = 0
                        Cantidad = 0
                        Costo = 0
                        Clave = ""
                        Nombre = ""
                        LblExistencia.Text = "Existencia:"
                        TxtClaveProd.Focus()

                        If dtDetalle.Rows.Count = 0 Then

                            cmbSucursalO.Enabled = True
                        End If

                    End If
            End Select
        End If

    End Sub
End Class
