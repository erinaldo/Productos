Public Class FrmPisos
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
    Friend WithEvents BtnEliminaSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificaSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregarSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPiso As System.Windows.Forms.GroupBox
    Friend WithEvents GrpMesas As System.Windows.Forms.GroupBox
    Friend WithEvents GridMesas As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PnlColorPiso As System.Windows.Forms.Panel
    Friend WithEvents LblColorPiso As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents PnlDisponible As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpColores As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PnlSucia As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PnlOcupada As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpOcupada As System.Windows.Forms.GroupBox
    Friend WithEvents PictOcupada As System.Windows.Forms.PictureBox
    Friend WithEvents GrpDisponible As System.Windows.Forms.GroupBox
    Friend WithEvents PictDisponible As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPisos))
        Me.GrpPiso = New System.Windows.Forms.GroupBox
        Me.GrpOcupada = New System.Windows.Forms.GroupBox
        Me.PictOcupada = New System.Windows.Forms.PictureBox
        Me.GrpDisponible = New System.Windows.Forms.GroupBox
        Me.PictDisponible = New System.Windows.Forms.PictureBox
        Me.GrpColores = New System.Windows.Forms.GroupBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PnlSucia = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.PnlOcupada = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.PnlDisponible = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PnlColorPiso = New System.Windows.Forms.Panel
        Me.LblColorPiso = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpMesas = New System.Windows.Forms.GroupBox
        Me.BtnAgregarSub = New Janus.Windows.EditControls.UIButton
        Me.GridMesas = New Janus.Windows.GridEX.GridEX
        Me.BtnEliminaSub = New Janus.Windows.EditControls.UIButton
        Me.BtnModificaSub = New Janus.Windows.EditControls.UIButton
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.GrpPiso.SuspendLayout()
        Me.GrpOcupada.SuspendLayout()
        CType(Me.PictOcupada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDisponible.SuspendLayout()
        CType(Me.PictDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpColores.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMesas.SuspendLayout()
        CType(Me.GridMesas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPiso
        '
        Me.GrpPiso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPiso.Controls.Add(Me.GrpOcupada)
        Me.GrpPiso.Controls.Add(Me.GrpDisponible)
        Me.GrpPiso.Controls.Add(Me.GrpColores)
        Me.GrpPiso.Controls.Add(Me.PictureBox3)
        Me.GrpPiso.Controls.Add(Me.CmbSucursal)
        Me.GrpPiso.Controls.Add(Me.Label12)
        Me.GrpPiso.Controls.Add(Me.PictureBox4)
        Me.GrpPiso.Controls.Add(Me.PnlColorPiso)
        Me.GrpPiso.Controls.Add(Me.LblColorPiso)
        Me.GrpPiso.Controls.Add(Me.PictureBox1)
        Me.GrpPiso.Controls.Add(Me.ChkEstado)
        Me.GrpPiso.Controls.Add(Me.PictureBox2)
        Me.GrpPiso.Controls.Add(Me.TxtDescripcion)
        Me.GrpPiso.Controls.Add(Me.LblDescripcion)
        Me.GrpPiso.Controls.Add(Me.TxtClave)
        Me.GrpPiso.Controls.Add(Me.LblClave)
        Me.GrpPiso.Location = New System.Drawing.Point(10, 7)
        Me.GrpPiso.Name = "GrpPiso"
        Me.GrpPiso.Size = New System.Drawing.Size(775, 187)
        Me.GrpPiso.TabIndex = 1
        Me.GrpPiso.TabStop = False
        Me.GrpPiso.Text = "Piso"
        '
        'GrpOcupada
        '
        Me.GrpOcupada.Controls.Add(Me.PictOcupada)
        Me.GrpOcupada.Location = New System.Drawing.Point(492, 97)
        Me.GrpOcupada.Name = "GrpOcupada"
        Me.GrpOcupada.Size = New System.Drawing.Size(71, 73)
        Me.GrpOcupada.TabIndex = 119
        Me.GrpOcupada.TabStop = False
        Me.GrpOcupada.Text = "Icono Ocup."
        '
        'PictOcupada
        '
        Me.PictOcupada.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictOcupada.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictOcupada.Location = New System.Drawing.Point(8, 14)
        Me.PictOcupada.Name = "PictOcupada"
        Me.PictOcupada.Size = New System.Drawing.Size(54, 52)
        Me.PictOcupada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictOcupada.TabIndex = 0
        Me.PictOcupada.TabStop = False
        '
        'GrpDisponible
        '
        Me.GrpDisponible.Controls.Add(Me.PictDisponible)
        Me.GrpDisponible.Location = New System.Drawing.Point(410, 97)
        Me.GrpDisponible.Name = "GrpDisponible"
        Me.GrpDisponible.Size = New System.Drawing.Size(71, 73)
        Me.GrpDisponible.TabIndex = 118
        Me.GrpDisponible.TabStop = False
        Me.GrpDisponible.Text = "Icono Disp."
        '
        'PictDisponible
        '
        Me.PictDisponible.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictDisponible.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictDisponible.Location = New System.Drawing.Point(8, 14)
        Me.PictDisponible.Name = "PictDisponible"
        Me.PictDisponible.Size = New System.Drawing.Size(54, 52)
        Me.PictDisponible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictDisponible.TabIndex = 0
        Me.PictDisponible.TabStop = False
        '
        'GrpColores
        '
        Me.GrpColores.Controls.Add(Me.PictureBox7)
        Me.GrpColores.Controls.Add(Me.PictureBox6)
        Me.GrpColores.Controls.Add(Me.PictureBox5)
        Me.GrpColores.Controls.Add(Me.PnlSucia)
        Me.GrpColores.Controls.Add(Me.Label3)
        Me.GrpColores.Controls.Add(Me.PnlOcupada)
        Me.GrpColores.Controls.Add(Me.Label2)
        Me.GrpColores.Controls.Add(Me.PnlDisponible)
        Me.GrpColores.Controls.Add(Me.Label1)
        Me.GrpColores.Location = New System.Drawing.Point(205, 97)
        Me.GrpColores.Name = "GrpColores"
        Me.GrpColores.Size = New System.Drawing.Size(187, 73)
        Me.GrpColores.TabIndex = 64
        Me.GrpColores.TabStop = False
        Me.GrpColores.Text = "Color de Mesas"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(117, 16)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox7.TabIndex = 118
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(72, 18)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox6.TabIndex = 71
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(22, 18)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox5.TabIndex = 70
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PnlSucia
        '
        Me.PnlSucia.BackColor = System.Drawing.Color.White
        Me.PnlSucia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlSucia.Location = New System.Drawing.Point(125, 33)
        Me.PnlSucia.Name = "PnlSucia"
        Me.PnlSucia.Size = New System.Drawing.Size(34, 30)
        Me.PnlSucia.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(124, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Apartada"
        '
        'PnlOcupada
        '
        Me.PnlOcupada.BackColor = System.Drawing.Color.White
        Me.PnlOcupada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlOcupada.Location = New System.Drawing.Point(70, 33)
        Me.PnlOcupada.Name = "PnlOcupada"
        Me.PnlOcupada.Size = New System.Drawing.Size(34, 30)
        Me.PnlOcupada.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(63, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 14)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Ocupada"
        '
        'PnlDisponible
        '
        Me.PnlDisponible.BackColor = System.Drawing.Color.White
        Me.PnlDisponible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlDisponible.Location = New System.Drawing.Point(13, 33)
        Me.PnlDisponible.Name = "PnlDisponible"
        Me.PnlDisponible.Size = New System.Drawing.Size(34, 30)
        Me.PnlDisponible.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 14)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Disponible"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(488, 73)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 69
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(107, 18)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(227, 21)
        Me.CmbSucursal.TabIndex = 116
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(13, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 18)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "Sucursal"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(188, 106)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 60
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PnlColorPiso
        '
        Me.PnlColorPiso.BackColor = System.Drawing.Color.White
        Me.PnlColorPiso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlColorPiso.Location = New System.Drawing.Point(105, 106)
        Me.PnlColorPiso.Name = "PnlColorPiso"
        Me.PnlColorPiso.Size = New System.Drawing.Size(81, 64)
        Me.PnlColorPiso.TabIndex = 59
        '
        'LblColorPiso
        '
        Me.LblColorPiso.Location = New System.Drawing.Point(13, 106)
        Me.LblColorPiso.Name = "LblColorPiso"
        Me.LblColorPiso.Size = New System.Drawing.Size(80, 15)
        Me.LblColorPiso.TabIndex = 57
        Me.LblColorPiso.Text = "Color del Piso"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(471, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(712, 13)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(60, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(540, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Location = New System.Drawing.Point(107, 73)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(508, 20)
        Me.TxtDescripcion.TabIndex = 2
        '
        'LblDescripcion
        '
        Me.LblDescripcion.Location = New System.Drawing.Point(13, 76)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(80, 15)
        Me.LblDescripcion.TabIndex = 26
        Me.LblDescripcion.Text = "Descripcion"
        '
        'TxtClave
        '
        Me.TxtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClave.Location = New System.Drawing.Point(107, 45)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(428, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 49)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 431)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 431)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpMesas
        '
        Me.GrpMesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMesas.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMesas.Controls.Add(Me.BtnAgregarSub)
        Me.GrpMesas.Controls.Add(Me.GridMesas)
        Me.GrpMesas.Controls.Add(Me.BtnEliminaSub)
        Me.GrpMesas.Controls.Add(Me.BtnModificaSub)
        Me.GrpMesas.Location = New System.Drawing.Point(10, 200)
        Me.GrpMesas.Name = "GrpMesas"
        Me.GrpMesas.Size = New System.Drawing.Size(775, 222)
        Me.GrpMesas.TabIndex = 2
        Me.GrpMesas.TabStop = False
        Me.GrpMesas.Text = "Mesas"
        '
        'BtnAgregarSub
        '
        Me.BtnAgregarSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregarSub.Icon = CType(resources.GetObject("BtnAgregarSub.Icon"), System.Drawing.Icon)
        Me.BtnAgregarSub.Location = New System.Drawing.Point(679, 15)
        Me.BtnAgregarSub.Name = "BtnAgregarSub"
        Me.BtnAgregarSub.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregarSub.TabIndex = 2
        Me.BtnAgregarSub.Text = "&Agregar"
        Me.BtnAgregarSub.ToolTipText = "Agrega nueva mesa"
        Me.BtnAgregarSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridMesas
        '
        Me.GridMesas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMesas.ColumnAutoResize = True
        Me.GridMesas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMesas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMesas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMesas.Location = New System.Drawing.Point(7, 15)
        Me.GridMesas.Name = "GridMesas"
        Me.GridMesas.RecordNavigator = True
        Me.GridMesas.Size = New System.Drawing.Size(666, 200)
        Me.GridMesas.TabIndex = 1
        Me.GridMesas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminaSub
        '
        Me.BtnEliminaSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaSub.Icon = CType(resources.GetObject("BtnEliminaSub.Icon"), System.Drawing.Icon)
        Me.BtnEliminaSub.Location = New System.Drawing.Point(679, 97)
        Me.BtnEliminaSub.Name = "BtnEliminaSub"
        Me.BtnEliminaSub.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaSub.TabIndex = 4
        Me.BtnEliminaSub.Text = "&Eliminar "
        Me.BtnEliminaSub.ToolTipText = "Elimina la mesa seleccionada"
        Me.BtnEliminaSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificaSub
        '
        Me.BtnModificaSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificaSub.Image = CType(resources.GetObject("BtnModificaSub.Image"), System.Drawing.Image)
        Me.BtnModificaSub.Location = New System.Drawing.Point(679, 59)
        Me.BtnModificaSub.Name = "BtnModificaSub"
        Me.BtnModificaSub.Size = New System.Drawing.Size(90, 30)
        Me.BtnModificaSub.TabIndex = 3
        Me.BtnModificaSub.Text = "&Modificar "
        Me.BtnModificaSub.ToolTipText = "Modifica la mesa"
        Me.BtnModificaSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPisos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.GrpPiso)
        Me.Controls.Add(Me.GrpMesas)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmPisos"
        Me.Text = "FrmPisos"
        Me.GrpPiso.ResumeLayout(False)
        Me.GrpPiso.PerformLayout()
        Me.GrpOcupada.ResumeLayout(False)
        CType(Me.PictOcupada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDisponible.ResumeLayout(False)
        CType(Me.PictDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpColores.ResumeLayout(False)
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMesas.ResumeLayout(False)
        CType(Me.GridMesas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public PISClave As String
    Public SUCClave As String = ""
    Public Clave As String
    Public Descripcion As String
    Public ColorPiso As Integer
    Public cMesaOcupada As Integer
    Public cMesaDisponible As Integer
    Public cMesaSucia As Integer
    Public Estado As Integer = 1

    Public IconoDisp As Byte()
    Public IconoDispActual As Byte()
    Public NuevoIconoDisp As Boolean = False

    Public IconoOcup As Byte()
    Public IconoOcupActual As Byte()
    Public NuevoIconoOcup As Boolean = False

    Private sMesaSelected As String
    Private sMesaRef As String

    Private alerta(6) As PictureBox
    Private reloj As parpadea

    Private dtMesas As DataTable


    Public Sub AddMesa(ByVal sMESClave As String, ByVal sClave As String, ByVal iEstado As Integer, ByVal sEstado As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtMesas.Select("MESClave Like '" & sMESClave & "' and Baja = 0")

        If foundRows.Length = 0 Then

            foundRows = dtMesas.Select("Clave = '" & Trim(sClave) & "' and Baja = 0")
            If foundRows.Length = 0 Then

                Dim row1 As DataRow
                row1 = dtMesas.NewRow()
                'declara el nombre de la fila

                row1.Item("MESClave") = sMESClave
                row1.Item("Clave") = sClave
                row1.Item("Estado") = sEstado
                row1.Item("iEstado") = iEstado
                row1.Item("Update") = 1
                row1.Item("Baja") = 0

                dtMesas.Rows.Add(row1)
                'agrega la fila completo a la tabla

            Else
                Beep()
                MessageBox.Show("¡La clave de Mesa que intenta agregar ya existe para el Piso actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            Dim foundRows2() As Data.DataRow

            foundRows2 = dtMesas.Select("Clave = '" & Trim(sClave) & "' and Baja = 0")
            If foundRows2.Length = 0 Then

                foundRows(0)("Clave") = sClave
                foundRows(0)("Estado") = sEstado
                foundRows(0)("iEstado") = iEstado
                foundRows(0)("update") = 1
            Else
                Beep()
                MessageBox.Show("¡La clave de Mesa que intenta agregar ya existe para el Piso actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
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
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)

        End If

        If PnlColorPiso.BackColor.ToArgb = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If PnlDisponible.BackColor.ToArgb = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If PnlOcupada.BackColor.ToArgb = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If PnlSucia.BackColor.ToArgb = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Piso", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Clave que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub FrmPisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        
        TxtClave.Text = Clave
        TxtDescripcion.Text = Descripcion
        ChkEstado.Estado = Estado
        ChkEstado.Enabled = True


        If Padre = "Agregar" Then

            PISClave = ModPOS.obtenerLlave

            dtMesas = ModPOS.CrearTabla("Mesa", _
            "MESClave", "System.String", _
            "Clave", "System.String", _
            "Estado", "System.String", _
            "iEstado", "System.Int32", _
            "Update", "System.Int32", _
            "Baja", "System.Int32", _
            "Principal", "System.String", _
            "PrincipalName", "System.String")
        Else
            CmbSucursal.SelectedValue = SUCClave
            PnlColorPiso.BackColor = System.Drawing.Color.FromArgb(ColorPiso)
            PnlDisponible.BackColor = System.Drawing.Color.FromArgb(cMesaDisponible)
            PnlOcupada.BackColor = System.Drawing.Color.FromArgb(cMesaOcupada)
            PnlSucia.BackColor = System.Drawing.Color.FromArgb(cMesaSucia)

            dtMesas = ModPOS.Recupera_Tabla("sp_muestra_mesas", "@PISClave", PISClave)
        End If

        GridMesas.DataSource = dtMesas
        GridMesas.RetrieveStructure(True)
        GridMesas.GroupByBoxVisible = False
        GridMesas.RootTable.Columns("MESClave").Visible = False
        GridMesas.RootTable.Columns("iEstado").Visible = False
        GridMesas.RootTable.Columns("Update").Visible = False
        GridMesas.RootTable.Columns("Baja").Visible = False
        GridMesas.RootTable.Columns("Principal").Visible = False
        GridMesas.RootTable.Columns("PrincipalName").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridMesas.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridMesas.RootTable.FormatConditions.Add(fc)

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub Reinicializa()

        PISClave = ModPOS.obtenerLlave
        Clave = ""
        Descripcion = ""
        ColorPiso = -1
        cMesaDisponible = -1
        cMesaOcupada = -1
        cMesaSucia = -1
        Estado = 1

        TxtClave.Text = Clave
        TxtDescripcion.Text = Descripcion
        ChkEstado.Estado = Estado

        PnlColorPiso.BackColor = System.Drawing.Color.FromArgb(ColorPiso)
        PnlDisponible.BackColor = System.Drawing.Color.FromArgb(cMesaDisponible)
        PnlOcupada.BackColor = System.Drawing.Color.FromArgb(cMesaOcupada)
        PnlSucia.BackColor = System.Drawing.Color.FromArgb(cMesaSucia)

        dtMesas = ModPOS.CrearTabla("Mesa", _
             "MESClave", "System.String", _
             "Clave", "System.String", _
             "Estado", "System.String", _
             "iEstado", "System.Int32", _
             "Update", "System.Int32", _
             "Baja", "System.Int32")

        GridMesas.DataSource = dtMesas
        GridMesas.RetrieveStructure(True)
        GridMesas.GroupByBoxVisible = False
        GridMesas.RootTable.Columns("MESClave").Visible = False
        GridMesas.RootTable.Columns("iEstado").Visible = False
        GridMesas.RootTable.Columns("Update").Visible = False
        GridMesas.RootTable.Columns("Baja").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridMesas.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridMesas.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim foundRows() As System.Data.DataRow

            Select Case Me.Padre
                Case "Agregar"

                    SUCClave = CmbSucursal.SelectedValue
                    Clave = UCase(Trim(Me.TxtClave.Text))
                    Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                    Me.Estado = ChkEstado.GetEstado
                    ColorPiso = Me.PnlColorPiso.BackColor.ToArgb
                    cMesaDisponible = Me.PnlDisponible.BackColor.ToArgb
                    cMesaOcupada = Me.PnlOcupada.BackColor.ToArgb
                    cMesaSucia = Me.PnlSucia.BackColor.ToArgb
                    IconoDispActual = IconoDisp
                    IconoOcupActual = IconoOcup

                    ModPOS.Ejecuta("sp_inserta_piso", _
                    "@SUCClave", SUCClave, _
                    "@PISClave", PISClave, _
                    "@Clave", Clave, _
                    "@Descripcion", Descripcion, _
                    "@ColorPiso", ColorPiso, _
                    "@cMesaDisponible", cMesaDisponible, _
                    "@cMesaOcupada", cMesaOcupada, _
                    "@cMesaSucia", cMesaSucia, _
                    "@ImgDisponible", IconoDispActual, _
                    "@ImgOcupada", IconoOcupActual, _
                    "@Estado", Estado, _
                    "@Usuario", ModPOS.UsuarioActual)


                    foundRows = dtMesas.Select(" Update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_mesa", _
                            "@PISClave", PISClave, _
                            "@MESClave", foundRows(z)("MESClave"), _
                            "@Clave", foundRows(z)("Clave"), _
                            "@Estado", foundRows(z)("iEstado"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Reinicializa()

                Case "Modificar"
                    If Not (Descripcion = UCase(Trim(Me.TxtDescripcion.Text)) AndAlso _
                        SUCClave = CmbSucursal.SelectedValue AndAlso _
                        ColorPiso = Me.PnlColorPiso.BackColor.ToArgb AndAlso _
                        IconoDisp Is IconoDispActual AndAlso _
                        IconoOcup Is IconoOcupActual AndAlso _
                        cMesaDisponible = Me.PnlDisponible.BackColor.ToArgb AndAlso _
                        cMesaOcupada = Me.PnlOcupada.BackColor.ToArgb AndAlso _
                        cMesaSucia = Me.PnlSucia.BackColor.ToArgb AndAlso _
                        Estado = ChkEstado.GetEstado) Then

                        SUCClave = CmbSucursal.SelectedValue
                        Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                        Me.Estado = ChkEstado.GetEstado
                        ColorPiso = Me.PnlColorPiso.BackColor.ToArgb
                        cMesaDisponible = Me.PnlDisponible.BackColor.ToArgb
                        cMesaOcupada = Me.PnlOcupada.BackColor.ToArgb
                        cMesaSucia = Me.PnlSucia.BackColor.ToArgb
                        IconoDispActual = IconoDisp
                        IconoOcupActual = IconoOcup


                        ModPOS.Ejecuta("sp_actualiza_piso", _
                        "@SUCClave", SUCClave, _
                        "@PISClave", PISClave, _
                        "@Clave", Clave, _
                        "@Descripcion", Descripcion, _
                        "@ColorPiso", ColorPiso, _
                        "@cMesaDisponible", cMesaDisponible, _
                        "@cMesaOcupada", cMesaOcupada, _
                        "@cMesaSucia", cMesaSucia, _
                        "@ImgDisponible", IconoDispActual, _
                        "@ImgOcupada", IconoOcupActual, _
                        "@Estado", Estado, _
                        "@Usuario", ModPOS.UsuarioActual)

                    End If

                    foundRows = dtMesas.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_elimina_mesa", _
                            "@PISClave", PISClave, _
                            "@MESClave", foundRows(z)("MESClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtMesas.Select(" Update = 1 and Baja = 0")

                    If foundRows.Length <> 0 Then
                        'actualiza denominaciones
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_mesa", _
                            "@PISClave", PISClave, _
                            "@MESClave", foundRows(z)("MESClave"), _
                            "@Clave", foundRows(z)("Clave"), _
                            "@Estado", foundRows(z)("iEstado"), _
                            "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    Me.Close()

            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmPisos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not ModPOS.MtoPisos Is Nothing Then
            ModPOS.ActualizaGrid(True, ModPOS.MtoPisos.GridPisos, "sp_recupera_pisos", "@COMClave", ModPOS.CompanyActual)
            ModPOS.MtoPisos.GridPisos.RootTable.Columns("PISClave").Visible = False
        End If
        ModPOS.Pisos.Dispose()
        ModPOS.Pisos = Nothing
    End Sub

    Private Sub BtnAgregarSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarSub.Click
        Dim a As New FrmMesa
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

    Private Sub BtnModificaSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificaSub.Click
        modificarMesas()
    End Sub

    Public Sub modificarMesas()
        If sMesaSelected <> "" Then
            If GridMesas.GetValue("Baja") = 0 Then
                Dim a As New FrmMesa
                a.Padre = "Modificar"
                a.MESClave = sMesaSelected
                a.Clave = GridMesas.GetValue("Clave")
                a.Estado = GridMesas.GetValue("iEstado")
                a.ShowDialog()
            End If
        End If
    End Sub

    Private Sub GridCuentas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridMesas.DoubleClick
        modificarMesas()
    End Sub

    Private Sub BtnEliminaSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaSub.Click
        If Me.sMesaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la mesa: " & sMesaRef, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMesas.Select("MESClave Like '" & sMesaSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridMesas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificaSub.PerformClick()
        End If
    End Sub

    Private Sub GridCuentas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridMesas.SelectionChanged
        If Not Me.GridMesas.GetValue(0) Is Nothing Then
            Me.BtnModificaSub.Enabled = True
            Me.BtnEliminaSub.Enabled = True
            Me.sMesaSelected = GridMesas.GetValue(0)
            sMesaRef = GridMesas.GetValue("Clave")
        Else
            Me.sMesaSelected = ""
            sMesaRef = ""
            Me.BtnModificaSub.Enabled = False
            Me.BtnEliminaSub.Enabled = False
        End If
    End Sub

    Private Sub PnlColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlColorPiso.DoubleClick
        Me.ColorDialog1.Color = Me.PnlColorPiso.BackColor
        Me.ColorDialog1.ShowDialog()
        Me.PnlColorPiso.BackColor = Me.ColorDialog1.Color
    End Sub


    Private Sub PnlDisponible_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlDisponible.DoubleClick
        Me.ColorDialog1.Color = Me.PnlDisponible.BackColor
        Me.ColorDialog1.ShowDialog()
        Me.PnlDisponible.BackColor = Me.ColorDialog1.Color
    End Sub

    Private Sub PnlOcupada_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlOcupada.DoubleClick
        Me.ColorDialog1.Color = Me.PnlOcupada.BackColor
        Me.ColorDialog1.ShowDialog()
        Me.PnlOcupada.BackColor = Me.ColorDialog1.Color
    End Sub

    Private Sub PnlSucia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlSucia.DoubleClick
        Me.ColorDialog1.Color = Me.PnlSucia.BackColor
        Me.ColorDialog1.ShowDialog()
        Me.PnlSucia.BackColor = Me.ColorDialog1.Color
    End Sub

    Private Sub PictDisponible_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictDisponible.DoubleClick
        Dim curFileName As String = ""


        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de Icono|*.ICO"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de Icono"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName



                Dim fsIcono As System.IO.FileStream
                fsIcono = New System.IO.FileStream(curFileName, System.IO.FileMode.Open)
                Dim fiIcono As System.IO.FileInfo = New System.IO.FileInfo(curFileName)
                Dim Temp As Long = fiIcono.Length
                Dim lung As Long = Convert.ToInt32(Temp)
                ReDim IconoDisp(lung)
                fsIcono.Read(IconoDisp, 0, lung)
                fsIcono.Close()
                fsIcono.Dispose()

                Me.PictDisponible.Image = Image.FromFile(curFileName)
                NuevoIconoDisp = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PictOcupada_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictOcupada.DoubleClick
        Dim curFileName As String = ""


        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de Icono|*.ICO"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de Icono"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim fsIcono As System.IO.FileStream
                fsIcono = New System.IO.FileStream(curFileName, System.IO.FileMode.Open)
                Dim fiIcono As System.IO.FileInfo = New System.IO.FileInfo(curFileName)
                Dim Temp As Long = fiIcono.Length
                Dim lung As Long = Convert.ToInt32(Temp)
                ReDim IconoOcup(lung)
                fsIcono.Read(IconoOcup, 0, lung)
                fsIcono.Close()
                fsIcono.Dispose()

                Me.PictOcupada.Image = Image.FromFile(curFileName)
                NuevoIconoOcup = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
