
Public Class FrmRegValores
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
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpRetiro As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCartePorte As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFechaEfectiva As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNomOperador As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lblEfectiva As System.Windows.Forms.Label
    Friend WithEvents BtnUsuario As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtRetiroCaja As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaRetiro As Janus.Windows.EditControls.UIButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegValores))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpRetiro = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.txtRetiroCaja = New System.Windows.Forms.TextBox()
        Me.BtnBuscaRetiro = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.grpGeneral = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCartePorte = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFechaEfectiva = New System.Windows.Forms.DateTimePicker()
        Me.lblNomOperador = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtEntrega = New System.Windows.Forms.TextBox()
        Me.lblEfectiva = New System.Windows.Forms.Label()
        Me.BtnUsuario = New Janus.Windows.EditControls.UIButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GrpRetiro.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGeneral.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Location = New System.Drawing.Point(0, 0)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(200, 100)
        Me.GrpSaldos.TabIndex = 0
        Me.GrpSaldos.TabStop = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(392, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 16)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Total Saldo"
        '
        'NumSaldo
        '
        Me.NumSaldo.Location = New System.Drawing.Point(496, 16)
        Me.NumSaldo.Name = "NumSaldo"
        Me.NumSaldo.ReadOnly = True
        Me.NumSaldo.Size = New System.Drawing.Size(160, 20)
        Me.NumSaldo.TabIndex = 60
        Me.NumSaldo.Text = "0.00"
        Me.NumSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumSaldo.Value = 0.0R
        Me.NumSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblCredito
        '
        Me.LblCredito.Location = New System.Drawing.Point(16, 16)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(104, 16)
        Me.LblCredito.TabIndex = 59
        Me.LblCredito.Text = "Crédito Disponible"
        '
        'NumDisponible
        '
        Me.NumDisponible.Location = New System.Drawing.Point(128, 16)
        Me.NumDisponible.Name = "NumDisponible"
        Me.NumDisponible.ReadOnly = True
        Me.NumDisponible.Size = New System.Drawing.Size(160, 20)
        Me.NumDisponible.TabIndex = 58
        Me.NumDisponible.Text = "0.00"
        Me.NumDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumDisponible.Value = 0.0R
        Me.NumDisponible.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Location = New System.Drawing.Point(0, 0)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(200, 100)
        Me.GrpMetodos.TabIndex = 0
        Me.GrpMetodos.TabStop = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(680, 16)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega nuevo Metodo de Pago"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(680, 104)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(80, 24)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.Text = "&Eliminar "
        Me.BtnElimina.ToolTipText = "Elimina el Metodo de Pago seleccionada"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModifica
        '
        Me.BtnModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.Location = New System.Drawing.Point(680, 64)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(80, 24)
        Me.BtnModifica.TabIndex = 3
        Me.BtnModifica.Text = "&Modificar "
        Me.BtnModifica.ToolTipText = "Modifica el Metodo de Pago seleccionada"
        Me.BtnModifica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GrpRetiro
        '
        Me.GrpRetiro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRetiro.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpRetiro.Controls.Add(Me.Label2)
        Me.GrpRetiro.Controls.Add(Me.BtnDel)
        Me.GrpRetiro.Controls.Add(Me.txtRetiroCaja)
        Me.GrpRetiro.Controls.Add(Me.BtnBuscaRetiro)
        Me.GrpRetiro.Controls.Add(Me.PictureBox3)
        Me.GrpRetiro.Controls.Add(Me.GridDetalle)
        Me.GrpRetiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpRetiro.ForeColor = System.Drawing.Color.Black
        Me.GrpRetiro.Location = New System.Drawing.Point(7, 198)
        Me.GrpRetiro.Name = "GrpRetiro"
        Me.GrpRetiro.Size = New System.Drawing.Size(683, 286)
        Me.GrpRetiro.TabIndex = 124
        Me.GrpRetiro.TabStop = False
        Me.GrpRetiro.Text = "Retiros de Caja"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(374, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Folio de Retiro"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(580, 14)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(41, 22)
        Me.BtnDel.TabIndex = 180
        Me.BtnDel.ToolTipText = "Remueve el  Retiro de Caja seleccionado del documento actual"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtRetiroCaja
        '
        Me.txtRetiroCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRetiroCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetiroCaja.Location = New System.Drawing.Point(458, 15)
        Me.txtRetiroCaja.Name = "txtRetiroCaja"
        Me.txtRetiroCaja.Size = New System.Drawing.Size(116, 21)
        Me.txtRetiroCaja.TabIndex = 178
        '
        'BtnBuscaRetiro
        '
        Me.BtnBuscaRetiro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaRetiro.Image = CType(resources.GetObject("BtnBuscaRetiro.Image"), System.Drawing.Image)
        Me.BtnBuscaRetiro.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaRetiro.Location = New System.Drawing.Point(627, 14)
        Me.BtnBuscaRetiro.Name = "BtnBuscaRetiro"
        Me.BtnBuscaRetiro.Size = New System.Drawing.Size(49, 22)
        Me.BtnBuscaRetiro.TabIndex = 179
        Me.BtnBuscaRetiro.ToolTipText = "Busqueda de Retiro de Caja"
        Me.BtnBuscaRetiro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(8, 18)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox3.TabIndex = 177
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 41)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(669, 425)
        Me.GridDetalle.TabIndex = 7
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(600, 490)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 117
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(502, 490)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 118
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar complemento"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grpGeneral
        '
        Me.grpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGeneral.Controls.Add(Me.PictureBox1)
        Me.grpGeneral.Controls.Add(Me.TxtNota)
        Me.grpGeneral.Controls.Add(Me.Label4)
        Me.grpGeneral.Controls.Add(Me.txtCartePorte)
        Me.grpGeneral.Controls.Add(Me.Label1)
        Me.grpGeneral.Controls.Add(Me.dtFechaEfectiva)
        Me.grpGeneral.Controls.Add(Me.lblNomOperador)
        Me.grpGeneral.Controls.Add(Me.PictureBox2)
        Me.grpGeneral.Controls.Add(Me.txtEntrega)
        Me.grpGeneral.Controls.Add(Me.lblEfectiva)
        Me.grpGeneral.Controls.Add(Me.BtnUsuario)
        Me.grpGeneral.Controls.Add(Me.Label9)
        Me.grpGeneral.Location = New System.Drawing.Point(7, 6)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Size = New System.Drawing.Size(683, 186)
        Me.grpGeneral.TabIndex = 135
        Me.grpGeneral.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(128, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox1.TabIndex = 176
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtNota
        '
        Me.TxtNota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNota.Location = New System.Drawing.Point(156, 125)
        Me.TxtNota.Multiline = True
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(520, 44)
        Me.TxtNota.TabIndex = 175
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Cod. Carta Porte:"
        '
        'txtCartePorte
        '
        Me.txtCartePorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCartePorte.Location = New System.Drawing.Point(156, 14)
        Me.txtCartePorte.Name = "txtCartePorte"
        Me.txtCartePorte.Size = New System.Drawing.Size(118, 21)
        Me.txtCartePorte.TabIndex = 135
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Observaciones:"
        '
        'dtFechaEfectiva
        '
        Me.dtFechaEfectiva.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaEfectiva.Location = New System.Drawing.Point(156, 95)
        Me.dtFechaEfectiva.Name = "dtFechaEfectiva"
        Me.dtFechaEfectiva.Size = New System.Drawing.Size(118, 20)
        Me.dtFechaEfectiva.TabIndex = 171
        '
        'lblNomOperador
        '
        Me.lblNomOperador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNomOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomOperador.Location = New System.Drawing.Point(156, 73)
        Me.lblNomOperador.Name = "lblNomOperador"
        Me.lblNomOperador.Size = New System.Drawing.Size(520, 15)
        Me.lblNomOperador.TabIndex = 169
        Me.lblNomOperador.Text = "Nombre:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(126, 46)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox2.TabIndex = 156
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'txtEntrega
        '
        Me.txtEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEntrega.Location = New System.Drawing.Point(156, 46)
        Me.txtEntrega.Name = "txtEntrega"
        Me.txtEntrega.Size = New System.Drawing.Size(115, 21)
        Me.txtEntrega.TabIndex = 166
        '
        'lblEfectiva
        '
        Me.lblEfectiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectiva.Location = New System.Drawing.Point(6, 100)
        Me.lblEfectiva.Name = "lblEfectiva"
        Me.lblEfectiva.Size = New System.Drawing.Size(76, 15)
        Me.lblEfectiva.TabIndex = 104
        Me.lblEfectiva.Text = "F. Entrega:"
        '
        'BtnUsuario
        '
        Me.BtnUsuario.Image = CType(resources.GetObject("BtnUsuario.Image"), System.Drawing.Image)
        Me.BtnUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnUsuario.Location = New System.Drawing.Point(277, 44)
        Me.BtnUsuario.Name = "BtnUsuario"
        Me.BtnUsuario.Size = New System.Drawing.Size(35, 22)
        Me.BtnUsuario.TabIndex = 161
        Me.BtnUsuario.ToolTipText = "Busqueda de Empleado"
        Me.BtnUsuario.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 15)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "Usuario que Entrega:"
        '
        'FrmRegValores
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(695, 534)
        Me.Controls.Add(Me.grpGeneral)
        Me.Controls.Add(Me.GrpRetiro)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimumSize = New System.Drawing.Size(667, 516)
        Me.Name = "FrmRegValores"
        Me.Text = "Registro de Valores"
        Me.GrpRetiro.ResumeLayout(False)
        Me.GrpRetiro.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    Public IdValores As String
    Public Padre As String
    Private USRClave As String = ""

    Private dtRetiros As DataTable
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private bNuevo As Boolean = False

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.txtCartePorte.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.txtCartePorte.Text.Length > 20 Then
            Me.txtCartePorte.Text = Me.txtCartePorte.Text.Substring(0, 20)
        End If

        If USRClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        ElseIf bNuevo Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "RegValores", "@clave", UCase(Trim(Me.txtCartePorte.Text)), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub FrmRegValores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        Me.StartPosition = FormStartPosition.CenterScreen


        If Padre = "Agregar" Then
            bNuevo = True
            IdValores = ModPOS.obtenerLlave
        Else
            grpGeneral.Enabled = False
            GrpRetiro.Enabled = False
            bNuevo = False

            Dim dt As DataTable = Recupera_Tabla("st_recupera_regvalores", "@IdValores", IdValores)
            USRClave = dt.Rows(0)("UsuarioEntrega")
            txtCartePorte.Text = dt.Rows(0)("codCartaPorte")
            TxtNota.Text = dt.Rows(0)("Notas")
            dtFechaEfectiva.Value = dt.Rows(0)("FechaEntrega")
            dt.Dispose()
        End If


        If USRClave = "" Then
            USRClave = ModPOS.UsuarioActual
        End If
        CargaDatosUsuario(USRClave, True)

      


        dtRetiros = ModPOS.Recupera_Tabla("st_recupera_retiroscaja", "@IdValores", IdValores)
        GridDetalle.DataSource = dtRetiros
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("ID").Visible = False
    
    End Sub


    Private Sub FrmRegValores_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Padre = "Agregar" AndAlso Not ModPOS.MtoRegValores Is Nothing Then
            If Not ModPOS.MtoRegValores.CmbSucursal.SelectedValue Is Nothing Then
                ModPOS.MtoRegValores.refrescaGrid()
            End If
        End If
        ModPOS.RegValores.Dispose()
        ModPOS.RegValores = Nothing
    End Sub

  

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim i As Integer
            Dim foundRows() As DataRow

            Select Case Me.Padre
                Case "Agregar"

                    foundRows = dtRetiros.Select("NumEnvase = ''")
                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("Existen Retiros de Caja seleccionados que no cuentan con el Num. Envase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim Importe As Decimal = dtRetiros.Compute("SUM(ImporteRetiro)", "")

                    ModPOS.Ejecuta("st_inserta_regvalores", _
                                    "@IdValores", IdValores, _
                                    "@UsuarioEntrega", USRClave, _
                                    "@codCartaPorte", txtCartePorte.Text.Trim.ToUpper, _
                                    "@fechaEntrega", dtFechaEfectiva.Value.Date, _
                                    "@Notas", TxtNota.Text, _
                                    "@ImporteEntregado", Importe, _
                                    "@SUCClave", SUCClave, _
                                    "@Usuario", ModPOS.UsuarioActual)

                    If dtRetiros.Rows.Count > 0 Then

                        Cursor.Current = Cursors.WaitCursor
                        For i = 0 To dtRetiros.Rows.Count - 1
                            ModPOS.Ejecuta("st_act_retirocaja", _
                                "@ID", dtRetiros.Rows(i)("ID"), _
                                "@IdValores", IdValores, _
                                "@numEnvase", dtRetiros.Rows(i)("NumEnvase"))
                        Next
                        Cursor.Current = Cursors.Default
                    End If


            End Select
            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaDatosUsuario(ByVal sUsuario As String, ByVal bUSRClave As Boolean)
        Dim dt As DataTable
        If bUSRClave = True Then
            dt = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", sUsuario)
        Else
            dt = ModPOS.SiExisteRecupera("sp_recupera_usuario", "@Usuario", sUsuario)
        End If

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            USRClave = dt.Rows(0)("USRClave")
            txtEntrega.Text = dt.Rows(0)("Referencia")
            lblNomOperador.Text = dt.Rows(0)("Nombre")
            dt.Dispose()
        Else
            USRClave = ""
            txtEntrega.Text = ""
            lblNomOperador.Text = ""
            MessageBox.Show("La información del Empleado no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnUsuario_Click(sender As Object, e As EventArgs) Handles BtnUsuario.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_usuario"
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.BusquedaInicial = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosUsuario(a.valor, True)

            End If
        End If
        a.Dispose()
    End Sub

    Private Sub txtEntrega_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEntrega.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtEntrega.Text <> "" Then
                    CargaDatosUsuario(txtEntrega.Text.Trim, False)
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_usuario"
                a.TablaCmb = "Usuario"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.CompaniaRequerido = False
                a.BusquedaInicial = False
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CargaDatosUsuario(a.valor, True)

                    End If
                End If
                a.Dispose()

        End Select

    End Sub

    Private Sub AddRetiroCaja(ByVal sRetiro As String, ByVal bID As Boolean)
        Dim dt As DataTable
        Dim sID As String
        Dim foundRows() As System.Data.DataRow
        If bID = True Then
            dt = ModPOS.Recupera_Tabla("st_obtener_retirocaja", "@ID", sRetiro)
        Else
            dt = ModPOS.Recupera_Tabla("st_obtener_retirocaja", "@Folio", sRetiro)
        End If

        If dt.Rows.Count > 0 Then
            sID = dt.Rows(0)("ID")
            foundRows = dtRetiros.Select("ID = '" & sID & "'")
            If foundRows.Length = 0 Then


                Dim row1 As DataRow
                row1 = dtRetiros.NewRow()
                'declara el nombre de la fila
                row1.Item("ID") = dt.Rows(0)("ID")
                row1.Item("NumEnvase") = dt.Rows(0)("NumEnvase")
                row1.Item("Folio") = dt.Rows(0)("Folio")
                row1.Item("FechaRetiro") = dt.Rows(0)("FechaRetiro")
                row1.Item("ImporteRetiro") = dt.Rows(0)("ImporteRetiro")
                row1.Item("Tipo") = dt.Rows(0)("Tipo")
                row1.Item("Motivo") = dt.Rows(0)("Motivo")
                row1.Item("Retira") = dt.Rows(0)("Retira")
                dtRetiros.Rows.Add(row1)

            End If
        Else
            MessageBox.Show("No se encontro un Folio de Retiro que coincida o ya se encuentra registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        dt.Dispose()

        txtRetiroCaja.Text = ""
    End Sub

    Private Sub BtnBuscaRetiro_Click(sender As Object, e As EventArgs) Handles BtnBuscaRetiro.Click
        Dim B As New FrmBuscaCorte
        B.bRetirosCaja = True
        B.Text = "Retiro de Caja"
        B.sp = "st_muestra_retiroscaja"
        B.SUCClave = SUCClave
        B.inicio = Today.Date
        B.fin = Today.Date.AddHours(23.9999)
        B.ShowDialog()
        If B.DialogResult = DialogResult.OK Then
            If B.IdCorte <> "" Then
                AddRetiroCaja(B.IdCorte, True)
            End If
        End If
    End Sub

    Private Sub txtRetiroCaja_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRetiroCaja.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtRetiroCaja.Text <> "" Then
                    AddRetiroCaja(txtRetiroCaja.Text.Trim, False)
                End If
            Case Is = Keys.Right

                Dim B As New FrmBuscaCorte
                B.bRetirosCaja = True
                B.Text = "Retiro de Caja"
                B.sp = "st_muestra_retiroscaja"
                B.SUCClave = SUCClave
                B.inicio = Today.Date
                B.fin = Today.Date.AddHours(23.9999)
                B.ShowDialog()
                If B.DialogResult = DialogResult.OK Then
                    If B.IdCorte <> "" Then
                        AddRetiroCaja(B.IdCorte, True)
                    End If
                End If
                B.Dispose()

        End Select

    End Sub

    Private Sub GridDetalle_CurrentCellChanging(sender As Object, e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles GridDetalle.CurrentCellChanging
        'If Not GridDetalle.CurrentColumn Is Nothing Then
        '    If GridDetalle.CurrentColumn.Caption = "NumEnvase" Then
        '        GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        '    Else
        '        GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        '    End If
        'End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If Not GridDetalle.GetValue(0) Is Nothing Then
            Select Case MessageBox.Show("Se quitara del docuemtno actual, el Retiro de Caja: " & GridDetalle.GetValue("Folio"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    'Elimina Detalle
                    foundRows = dtRetiros.Select("ID = '" & GridDetalle.GetValue("ID") & "'")
                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        For i = 0 To foundRows.GetUpperBound(0)
                            dtRetiros.Rows.Remove(foundRows(i))
                        Next
                    End If
            End Select
        End If

    End Sub

  
    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Num Envase" Then
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub
End Class
