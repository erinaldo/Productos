Imports System.Data.SqlClient

Public Class FrmCrearAlm
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
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblAlto As System.Windows.Forms.Label
    Friend WithEvents LblLargo As System.Windows.Forms.Label
    Friend WithEvents LblAncho As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GrpAlmacen As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDimensiones As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtAncho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtLargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtAlto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpAlmProducto As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkBloqueado As Selling.ChkStatus
    Friend WithEvents Label4 As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCrearAlm))
        Me.GrpAlmacen = New System.Windows.Forms.GroupBox
        Me.ChkBloqueado = New Selling.ChkStatus(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbTipoEstado = New Selling.StoreCombo
        Me.LblEstado = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpDimensiones = New System.Windows.Forms.GroupBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.TxtAlto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtLargo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtAncho = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblAncho = New System.Windows.Forms.Label
        Me.LblLargo = New System.Windows.Forms.Label
        Me.LblAlto = New System.Windows.Forms.Label
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpAlmProducto = New System.Windows.Forms.GroupBox
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.GrpAlmacen.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDimensiones.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpAlmProducto.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpAlmacen
        '
        Me.GrpAlmacen.Controls.Add(Me.ChkBloqueado)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox3)
        Me.GrpAlmacen.Controls.Add(Me.CmbSucursal)
        Me.GrpAlmacen.Controls.Add(Me.Label12)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox2)
        Me.GrpAlmacen.Controls.Add(Me.cmbTipoEstado)
        Me.GrpAlmacen.Controls.Add(Me.LblEstado)
        Me.GrpAlmacen.Controls.Add(Me.TxtNombre)
        Me.GrpAlmacen.Controls.Add(Me.LblNombre)
        Me.GrpAlmacen.Controls.Add(Me.TxtClave)
        Me.GrpAlmacen.Controls.Add(Me.LblClave)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox1)
        Me.GrpAlmacen.Controls.Add(Me.Label4)
        Me.GrpAlmacen.Location = New System.Drawing.Point(7, 2)
        Me.GrpAlmacen.Name = "GrpAlmacen"
        Me.GrpAlmacen.Size = New System.Drawing.Size(611, 106)
        Me.GrpAlmacen.TabIndex = 0
        Me.GrpAlmacen.TabStop = False
        Me.GrpAlmacen.Text = "General"
        '
        'ChkBloqueado
        '
        Me.ChkBloqueado.Checked = True
        Me.ChkBloqueado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBloqueado.Location = New System.Drawing.Point(470, 16)
        Me.ChkBloqueado.Name = "ChkBloqueado"
        Me.ChkBloqueado.Size = New System.Drawing.Size(138, 22)
        Me.ChkBloqueado.TabIndex = 110
        Me.ChkBloqueado.Text = "Bloqueado para Vta"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(390, 77)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox3.TabIndex = 108
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(70, 19)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(310, 21)
        Me.CmbSucursal.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 18)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "Sucursal"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(211, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox2.TabIndex = 82
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Location = New System.Drawing.Point(470, 45)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(125, 21)
        Me.cmbTipoEstado.TabIndex = 1
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(422, 48)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(49, 15)
        Me.LblEstado.TabIndex = 20
        Me.LblEstado.Text = "Estado"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(70, 76)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(314, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(8, 76)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 2
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(70, 48)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(135, 20)
        Me.TxtClave.TabIndex = 0
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(8, 50)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 0
        Me.LblClave.Text = "Referencia"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(390, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(203, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'GrpDimensiones
        '
        Me.GrpDimensiones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDimensiones.Controls.Add(Me.PictureBox6)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox5)
        Me.GrpDimensiones.Controls.Add(Me.PictureBox4)
        Me.GrpDimensiones.Controls.Add(Me.TxtAlto)
        Me.GrpDimensiones.Controls.Add(Me.TxtLargo)
        Me.GrpDimensiones.Controls.Add(Me.TxtAncho)
        Me.GrpDimensiones.Controls.Add(Me.Label3)
        Me.GrpDimensiones.Controls.Add(Me.Label2)
        Me.GrpDimensiones.Controls.Add(Me.Label1)
        Me.GrpDimensiones.Controls.Add(Me.LblAncho)
        Me.GrpDimensiones.Controls.Add(Me.LblLargo)
        Me.GrpDimensiones.Controls.Add(Me.LblAlto)
        Me.GrpDimensiones.Location = New System.Drawing.Point(7, 115)
        Me.GrpDimensiones.Name = "GrpDimensiones"
        Me.GrpDimensiones.Size = New System.Drawing.Size(611, 75)
        Me.GrpDimensiones.TabIndex = 1
        Me.GrpDimensiones.TabStop = False
        Me.GrpDimensiones.Text = "Dimensiones"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(558, 47)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(21, 18)
        Me.PictureBox6.TabIndex = 86
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(255, 45)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox5.TabIndex = 85
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(255, 17)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox4.TabIndex = 84
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'TxtAlto
        '
        Me.TxtAlto.DecimalDigits = 2
        Me.TxtAlto.Location = New System.Drawing.Point(107, 15)
        Me.TxtAlto.Name = "TxtAlto"
        Me.TxtAlto.Size = New System.Drawing.Size(140, 20)
        Me.TxtAlto.TabIndex = 9
        Me.TxtAlto.Text = "0.00"
        Me.TxtAlto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAlto.Value = 0
        Me.TxtAlto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtLargo
        '
        Me.TxtLargo.DecimalDigits = 2
        Me.TxtLargo.Location = New System.Drawing.Point(107, 45)
        Me.TxtLargo.Name = "TxtLargo"
        Me.TxtLargo.Size = New System.Drawing.Size(140, 20)
        Me.TxtLargo.TabIndex = 10
        Me.TxtLargo.Text = "0.00"
        Me.TxtLargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtLargo.Value = 0
        Me.TxtLargo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtAncho
        '
        Me.TxtAncho.DecimalDigits = 2
        Me.TxtAncho.Location = New System.Drawing.Point(409, 45)
        Me.TxtAncho.Name = "TxtAncho"
        Me.TxtAncho.Size = New System.Drawing.Size(140, 20)
        Me.TxtAncho.TabIndex = 11
        Me.TxtAncho.Text = "0.00"
        Me.TxtAncho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAncho.Value = 0
        Me.TxtAncho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(554, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Metros"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(250, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Metros"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(251, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Metros"
        '
        'LblAncho
        '
        Me.LblAncho.Location = New System.Drawing.Point(352, 46)
        Me.LblAncho.Name = "LblAncho"
        Me.LblAncho.Size = New System.Drawing.Size(55, 15)
        Me.LblAncho.TabIndex = 10
        Me.LblAncho.Text = "Ancho"
        '
        'LblLargo
        '
        Me.LblLargo.Location = New System.Drawing.Point(20, 52)
        Me.LblLargo.Name = "LblLargo"
        Me.LblLargo.Size = New System.Drawing.Size(56, 15)
        Me.LblLargo.TabIndex = 8
        Me.LblLargo.Text = "Largo"
        '
        'LblAlto
        '
        Me.LblAlto.Location = New System.Drawing.Point(20, 22)
        Me.LblAlto.Name = "LblAlto"
        Me.LblAlto.Size = New System.Drawing.Size(67, 15)
        Me.LblAlto.TabIndex = 6
        Me.LblAlto.Text = "Altura Maxima"
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Icon = CType(resources.GetObject("BtnOk.Icon"), System.Drawing.Icon)
        Me.BtnOk.Location = New System.Drawing.Point(528, 513)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 3
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar los cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(432, 513)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.GridDetalle.Location = New System.Drawing.Point(7, 45)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(598, 255)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpAlmProducto
        '
        Me.GrpAlmProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAlmProducto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpAlmProducto.Controls.Add(Me.BtnAdd)
        Me.GrpAlmProducto.Controls.Add(Me.BtnDel)
        Me.GrpAlmProducto.Controls.Add(Me.GridDetalle)
        Me.GrpAlmProducto.Location = New System.Drawing.Point(7, 200)
        Me.GrpAlmProducto.Name = "GrpAlmProducto"
        Me.GrpAlmProducto.Size = New System.Drawing.Size(611, 307)
        Me.GrpAlmProducto.TabIndex = 9
        Me.GrpAlmProducto.TabStop = False
        Me.GrpAlmProducto.Text = "Productos No Manejados en el Almacén"
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Icon = CType(resources.GetObject("BtnAdd.Icon"), System.Drawing.Icon)
        Me.BtnAdd.Location = New System.Drawing.Point(548, 17)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(26, 22)
        Me.BtnAdd.TabIndex = 130
        Me.BtnAdd.ToolTipText = "Busqueda de Producto"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Icon = CType(resources.GetObject("BtnDel.Icon"), System.Drawing.Icon)
        Me.BtnDel.Location = New System.Drawing.Point(579, 17)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(26, 22)
        Me.BtnDel.TabIndex = 129
        Me.BtnDel.ToolTipText = "Busqueda de Producto"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCrearAlm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(628, 557)
        Me.Controls.Add(Me.GrpAlmProducto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GrpDimensiones)
        Me.Controls.Add(Me.GrpAlmacen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(635, 422)
        Me.Name = "FrmCrearAlm"
        Me.Text = "Crear Almacen"
        Me.GrpAlmacen.ResumeLayout(False)
        Me.GrpAlmacen.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDimensiones.ResumeLayout(False)
        Me.GrpDimensiones.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpAlmProducto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String
    Public ALMClave As String
    Public Referencia As String
    Public sCpyNombre As String
    Public sCpySucursal As String
    Public bCpyBloqueoVta As Boolean = False
    Public dCpyLargo As Double = 0
    Public dCpyAncho As Double = 0
    Public dCpyAlto As Double = 0
    Public dCpyCapacidadCarga As Double = 0
    Public iCpyEstado As Integer
    Public iCpyEscala As Integer

    Public Padre As String

    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private cargado As Boolean = False

    Private dtDetalle, dtBorrados As DataTable
    Private DetalleEdited As Boolean = False
    Private sProductoSelected As String
    Private sClaveSelected As String

    Private Sub FrmCrearAlm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.CrearAlm.Dispose()
        ModPOS.CrearAlm = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        If validaForm() Then
            Select Case Me.Padre
                Case "Nuevo"

                    If Not ModPOS.Superficie Is Nothing Then
                        ModPOS.Graba_Layout_Activo()
                        ModPOS.Almacen_Activo = ""
                        ModPOS.Superficie.Close()
                    End If

                    ModPOS.Superficie = New FrmCanvas
                    With ModPOS.Superficie
                        .StartPosition = FormStartPosition.CenterScreen
                        .MdiParent = ModPOS.Principal
                        .Show()
                        .ALMClave = Me.ALMClave
                        ModPOS.Almacen_Activo = Me.ALMClave

                        'Modificar valores del almacen
                        .SUCClave = CmbSucursal.SelectedValue
                        .Referencia = UCase(Trim(Me.TxtClave.Text))
                        .Nombre = UCase(Trim(Me.TxtNombre.Text))
                        .Escala = ModPOS.EscalaActual
                        .Alto = CDbl(Me.TxtAlto.Text)
                        .Largo = CDbl(Me.TxtLargo.Text)
                        .Ancho = CDbl(Me.TxtAncho.Text)
                        .Width = CInt(ModPOS.Superficie.Largo) * ModPOS.EscalaActual
                        .Height = CInt(ModPOS.Superficie.Ancho) * ModPOS.EscalaActual
                        .Estado = 1
                        .BloqueoVta = ChkBloqueado.GetEstado
                        .Refresh()
                    End With

                    ModPOS.Graba_Superficie(ModPOS.Superficie)

                    Dim fila As Integer

                    For fila = 0 To dtDetalle.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_almacen_producto", _
                                    "@ALMClave", ALMClave, _
                                    "@PROClave", dtDetalle.Rows(fila)("PROClave"))
                    Next



                    ModPOS.Principal.Cerrar.Enabled = Janus.Windows.UI.InheritableBoolean.True
                    ModPOS.Principal.Zoom.Enabled = Janus.Windows.UI.InheritableBoolean.True
                    ModPOS.Principal.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.True
                    ModPOS.Principal.Buscar.Enabled = Janus.Windows.UI.InheritableBoolean.True


                Case "Modificar"
                    If Not (Me.sCpyNombre = UCase(Trim(Me.TxtNombre.Text)) AndAlso _
                    Me.iCpyEstado = CInt(Me.cmbTipoEstado.SelectedValue) AndAlso _
                    Me.dCpyLargo = CDbl(Me.TxtLargo.Text) AndAlso _
                    Me.dCpyAlto = CDbl(Me.TxtAlto.Text) AndAlso _
                    Me.dCpyAncho = CDbl(Me.TxtAncho.Text) AndAlso _
                    Me.bCpyBloqueoVta = CBool(ChkBloqueado.GetEstado) AndAlso _
                    Me.sCpySucursal = CmbSucursal.SelectedValue AndAlso DetalleEdited = False) Then

                        Me.sCpyNombre = UCase(Trim(Me.TxtNombre.Text))
                        Me.iCpyEstado = CInt(Me.cmbTipoEstado.SelectedValue)
                        Me.dCpyLargo = CDbl(Me.TxtLargo.Text)
                        Me.dCpyAlto = CDbl(Me.TxtAlto.Text)
                        Me.dCpyAncho = CDbl(Me.TxtAncho.Text)
                        Me.sCpySucursal = CmbSucursal.SelectedValue
                        bCpyBloqueoVta = CBool(ChkBloqueado.GetEstado)

                        ModPOS.Update_Almacen(Me)

                        If DetalleEdited Then

                            Dim fila As Integer

                            Cursor.Current = Cursors.WaitCursor

                            For fila = 0 To dtBorrados.Rows.Count - 1
                                ModPOS.Ejecuta("sp_elimina_almacen_producto", _
                                            "@ALMClave", ALMClave, _
                                            "@PROClave", dtBorrados.Rows(fila)("PROClave"))
                            Next

                            Dim foundRows() As DataRow
                            foundRows = dtDetalle.Select("Agregar = 1")

                            If foundRows.GetLength(0) > 0 Then
                                For fila = 0 To foundRows.GetUpperBound(0)
                                    ModPOS.Ejecuta("sp_inserta_almacen_producto", _
                                                "@ALMClave", ALMClave, _
                                                "@PROClave", foundRows(fila)("PROClave"))
                                Next
                            End If

                            Cursor.Current = Cursors.Default

                        End If

                        If Not ModPOS.Superficie Is Nothing Then
                            If ModPOS.Superficie.ALMClave = Me.ALMClave Then
                                With ModPOS.Superficie
                                    .Nombre = Me.sCpyNombre
                                    .SUCClave = Me.sCpySucursal
                                    .BloqueoVta = Me.bCpyBloqueoVta

                                    .Estado = Me.iCpyEstado
                                    .Largo = Me.dCpyLargo
                                    .Alto = Me.dCpyAlto
                                    .Ancho = Me.dCpyAncho
                                    .Width = CInt(Me.dCpyLargo * Me.iCpyEscala)
                                    .Height = CInt(Me.dCpyAncho * Me.iCpyEscala)
                                End With
                            End If
                        End If

                        If Not ModPOS.Almacenes Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.Almacenes.GridAlmacen, "sp_muestra_almacenes", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.Almacenes.GridAlmacen.RootTable.Columns("ALMClave").Visible = False
                        End If
                    End If
            End Select
            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)

        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)

        End If

        If Me.TxtAlto.Text = "" OrElse CDbl(Me.TxtAlto.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLargo.Text = "" OrElse CDbl(Me.TxtLargo.Text) = 0 OrElse CDbl(Me.TxtLargo.Text) < Me.dCpyLargo Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtAncho.Text = "" OrElse CDbl(Me.TxtAncho.Text) = 0 OrElse CDbl(Me.TxtAncho.Text) < Me.dCpyAncho Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

      

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Nuevo" Then
            Dim Con As String = ModPOS.BDConexion

            If Not Me.CmbSucursal.SelectedValue Is Nothing Then
                If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Almacen", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual, "@SUCClave", CmbSucursal.SelectedValue) > 0 Then
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
                i += 1
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function


    Private Sub FrmCrearAlm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6



        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        dtBorrados = ModPOS.CrearTabla("AlmacenDetalle", _
                            "PROClave", "System.String")

        If Padre <> "Nuevo" Then
            CmbSucursal.SelectedValue = sCpySucursal
            ChkBloqueado.Estado = Math.Abs(CInt(bCpyBloqueoVta))
            CmbSucursal.Enabled = False
            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_almacen_producto", "@ALMClave", ALMClave)
        Else
            ALMClave = ModPOS.obtenerLlave
            dtDetalle = ModPOS.CrearTabla("AlmacenDetalle", _
                                        "PROClave", "System.String", _
                                        "Clave", "System.String", _
                                        "Descripcion", "System.String", _
                                        "Agregar", "System.Int32")
        End If

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("Agregar").Visible = False
        GridDetalle.CurrentTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Descripcion").Selectable = False

        cargado = True

    End Sub


    Public Sub agregaProducto(ByVal PROClave As String, ByVal Clave As String, ByVal Nombre As String)

        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("PROClave Like '" & PROClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("PROClave") = PROClave
            row1.Item("Clave") = Clave
            row1.Item("Descripcion") = Nombre
            row1.Item("Agregar") = 1
            'agrega la fila completo a la tabla
            dtDetalle.Rows.Add(row1)
            DetalleEdited = True
        End If

    End Sub


    Private Sub BtnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se removera el producto " & sClaveSelected & " de la lista de no manejados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow

                    foundRows = dtBorrados.Select("PROClave Like '" & sProductoSelected & "'")

                    If foundRows.Length = 0 Then
                        Dim row1 As DataRow
                        row1 = dtBorrados.NewRow()
                        row1.Item("PROClave") = sProductoSelected
                        dtBorrados.Rows.Add(row1)
                    End If


                    foundRows = dtDetalle.Select(" PROClave Like '" & sProductoSelected & "'")
                    dtDetalle.Rows.Remove(foundRows(0))


                    DetalleEdited = True

            End Select
        End If
    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        If Not GridDetalle.GetValue(0) Is Nothing Then
            Me.BtnDel.Enabled = True
            Me.sProductoSelected = GridDetalle.GetValue("PROClave")
            Me.sClaveSelected = GridDetalle.GetValue("Clave")
        Else
            BtnDel.Enabled = False
            Me.sProductoSelected = ""
            Me.sClaveSelected = ""
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If ModPOS.AddProd Is Nothing Then
            ModPOS.AddProd = New FrmAddProd
            With ModPOS.AddProd
                .StartPosition = FormStartPosition.CenterScreen
                .ALMClave = ALMClave
            End With
        End If
        ModPOS.AddProd.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddProd.Show()
        ModPOS.AddProd.BringToFront()

    End Sub



End Class
