Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmOrden
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProv As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtClaveProv As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnAddProv As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtFecRegistro As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSugerido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents cmbAlmacen As Selling.StoreCombo
    Friend WithEvents cmbSucursal As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbUnidad As Selling.StoreCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrden))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtSolicita = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtMotivo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtClaveProv = New System.Windows.Forms.TextBox
        Me.TxtOrden = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnKey = New Janus.Windows.EditControls.UIButton
        Me.TxtEstado = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtFecRegistro = New System.Windows.Forms.TextBox
        Me.BtnAddProv = New Janus.Windows.EditControls.UIButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.BtnBuscaProv = New Janus.Windows.EditControls.UIButton
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnImportar = New Janus.Windows.EditControls.UIButton
        Me.TxtSugerido = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.BtnAddProd = New Janus.Windows.EditControls.UIButton
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.LblTotal = New System.Windows.Forms.Label
        Me.LblIVA = New System.Windows.Forms.Label
        Me.LblSubtotal = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.TxtIVA = New System.Windows.Forms.TextBox
        Me.TxtSubtotal = New System.Windows.Forms.TextBox
        Me.cmbUnidad = New Selling.StoreCombo
        Me.cmbAlmacen = New Selling.StoreCombo
        Me.cmbSucursal = New Selling.StoreCombo
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.PictureBox5)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.Label15)
        Me.GrpGeneral.Controls.Add(Me.TxtNota)
        Me.GrpGeneral.Controls.Add(Me.Label14)
        Me.GrpGeneral.Controls.Add(Me.TxtSolicita)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.TxtMotivo)
        Me.GrpGeneral.Controls.Add(Me.cmbAlmacen)
        Me.GrpGeneral.Controls.Add(Me.cmbSucursal)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.Label13)
        Me.GrpGeneral.Controls.Add(Me.TxtClaveProv)
        Me.GrpGeneral.Controls.Add(Me.TxtOrden)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.BtnKey)
        Me.GrpGeneral.Controls.Add(Me.TxtEstado)
        Me.GrpGeneral.Controls.Add(Me.Label9)
        Me.GrpGeneral.Controls.Add(Me.TxtFecRegistro)
        Me.GrpGeneral.Controls.Add(Me.BtnAddProv)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaProv)
        Me.GrpGeneral.Controls.Add(Me.TxtRazonSocial)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(778, 191)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(433, 78)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox5.TabIndex = 139
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(50, 107)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox4.TabIndex = 138
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(49, 75)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox3.TabIndex = 118
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(3, 161)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 15)
        Me.Label15.TabIndex = 137
        Me.Label15.Text = "Nota"
        '
        'TxtNota
        '
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(100, 157)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(542, 21)
        Me.TxtNota.TabIndex = 136
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(3, 134)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 135
        Me.Label14.Text = "Solicita"
        '
        'TxtSolicita
        '
        Me.TxtSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSolicita.Location = New System.Drawing.Point(100, 130)
        Me.TxtSolicita.Name = "TxtSolicita"
        Me.TxtSolicita.Size = New System.Drawing.Size(542, 21)
        Me.TxtSolicita.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Motivo"
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivo.Location = New System.Drawing.Point(100, 103)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.Size = New System.Drawing.Size(542, 21)
        Me.TxtMotivo.TabIndex = 132
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Sucursal Destino"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(395, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 15)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "Almacén"
        '
        'TxtClaveProv
        '
        Me.TxtClaveProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProv.Location = New System.Drawing.Point(100, 44)
        Me.TxtClaveProv.Name = "TxtClaveProv"
        Me.TxtClaveProv.Size = New System.Drawing.Size(114, 21)
        Me.TxtClaveProv.TabIndex = 2
        '
        'TxtOrden
        '
        Me.TxtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrden.Location = New System.Drawing.Point(100, 16)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(114, 21)
        Me.TxtOrden.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(50, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox2.TabIndex = 117
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(50, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(220, 16)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(27, 21)
        Me.BtnKey.TabIndex = 114
        Me.BtnKey.ToolTipText = "Genera clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtEstado
        '
        Me.TxtEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEstado.Enabled = False
        Me.TxtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstado.Location = New System.Drawing.Point(660, 12)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.ReadOnly = True
        Me.TxtEstado.Size = New System.Drawing.Size(113, 26)
        Me.TxtEstado.TabIndex = 93
        Me.TxtEstado.Text = "En Solicitud"
        Me.TxtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(363, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 15)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Fecha Registro"
        '
        'TxtFecRegistro
        '
        Me.TxtFecRegistro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFecRegistro.Enabled = False
        Me.TxtFecRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecRegistro.Location = New System.Drawing.Point(464, 17)
        Me.TxtFecRegistro.Multiline = True
        Me.TxtFecRegistro.Name = "TxtFecRegistro"
        Me.TxtFecRegistro.ReadOnly = True
        Me.TxtFecRegistro.Size = New System.Drawing.Size(178, 19)
        Me.TxtFecRegistro.TabIndex = 108
        '
        'BtnAddProv
        '
        Me.BtnAddProv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddProv.Image = CType(resources.GetObject("BtnAddProv.Image"), System.Drawing.Image)
        Me.BtnAddProv.Location = New System.Drawing.Point(726, 41)
        Me.BtnAddProv.Name = "BtnAddProv"
        Me.BtnAddProv.Size = New System.Drawing.Size(45, 24)
        Me.BtnAddProv.TabIndex = 4
        Me.BtnAddProv.ToolTipText = "Agregar Nuevo Proveedor"
        Me.BtnAddProv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(3, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Num. Orden"
        '
        'BtnBuscaProv
        '
        Me.BtnBuscaProv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProv.Image = CType(resources.GetObject("BtnBuscaProv.Image"), System.Drawing.Image)
        Me.BtnBuscaProv.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProv.Location = New System.Drawing.Point(660, 41)
        Me.BtnBuscaProv.Name = "BtnBuscaProv"
        Me.BtnBuscaProv.Size = New System.Drawing.Size(45, 24)
        Me.BtnBuscaProv.TabIndex = 3
        Me.BtnBuscaProv.ToolTipText = "Busqueda de Proveedor"
        Me.BtnBuscaProv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(220, 43)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(422, 19)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Prov. Cve."
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(596, 550)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 550)
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
        Me.GrpDetalle.Controls.Add(Me.PictureBox6)
        Me.GrpDetalle.Controls.Add(Me.cmbUnidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnImportar)
        Me.GrpDetalle.Controls.Add(Me.TxtSugerido)
        Me.GrpDetalle.Controls.Add(Me.Label6)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.BtnAddProd)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtClaveProd)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 201)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 308)
        Me.GrpDetalle.TabIndex = 2
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(726, 38)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(45, 24)
        Me.BtnDel.TabIndex = 141
        Me.BtnDel.ToolTipText = "Elimina la partida seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(11, 45)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox6.TabIndex = 140
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Cantidad"
        '
        'BtnImportar
        '
        Me.BtnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportar.Icon = CType(resources.GetObject("BtnImportar.Icon"), System.Drawing.Icon)
        Me.BtnImportar.Location = New System.Drawing.Point(671, 38)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Size = New System.Drawing.Size(45, 24)
        Me.BtnImportar.TabIndex = 129
        Me.BtnImportar.ToolTipText = "Importar el contenido de Orden de Compra desde un archico (*.csv)"
        Me.BtnImportar.Visible = False
        Me.BtnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtSugerido
        '
        Me.TxtSugerido.Enabled = False
        Me.TxtSugerido.Location = New System.Drawing.Point(550, 41)
        Me.TxtSugerido.Name = "TxtSugerido"
        Me.TxtSugerido.Size = New System.Drawing.Size(114, 20)
        Me.TxtSugerido.TabIndex = 102
        Me.TxtSugerido.Text = "0.00"
        Me.TxtSugerido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtSugerido.Value = 0
        Me.TxtSugerido.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(395, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 16)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Cantidad Maxima Sugerida"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(199, 41)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(121, 20)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'BtnAddProd
        '
        Me.BtnAddProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddProd.Image = CType(resources.GetObject("BtnAddProd.Image"), System.Drawing.Image)
        Me.BtnAddProd.Location = New System.Drawing.Point(726, 10)
        Me.BtnAddProd.Name = "BtnAddProd"
        Me.BtnAddProd.Size = New System.Drawing.Size(45, 24)
        Me.BtnAddProd.TabIndex = 2
        Me.BtnAddProd.ToolTipText = "Agregar Nuevo Producto"
        Me.BtnAddProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(671, 10)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(45, 24)
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
        Me.TxtDescripcion.Location = New System.Drawing.Point(199, 13)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(465, 19)
        Me.TxtDescripcion.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Prod. Cve."
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(72, 13)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(121, 21)
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
        Me.GridDetalle.Location = New System.Drawing.Point(7, 66)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(765, 236)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(604, 522)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(37, 15)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Total"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(429, 523)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(55, 15)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "Impuesto"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(259, 522)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(49, 15)
        Me.LblSubtotal.TabIndex = 92
        Me.LblSubtotal.Text = "Subtotal"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(639, 514)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(140, 26)
        Me.TxtTotal.TabIndex = 95
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA.Location = New System.Drawing.Point(485, 514)
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.ReadOnly = True
        Me.TxtIVA.Size = New System.Drawing.Size(113, 26)
        Me.TxtIVA.TabIndex = 94
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubtotal.Enabled = False
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(314, 515)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(110, 26)
        Me.TxtSubtotal.TabIndex = 93
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbUnidad
        '
        Me.cmbUnidad.Location = New System.Drawing.Point(72, 41)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(123, 21)
        Me.cmbUnidad.TabIndex = 130
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Location = New System.Drawing.Point(464, 75)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(290, 21)
        Me.cmbAlmacen.TabIndex = 131
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Location = New System.Drawing.Point(100, 75)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(290, 21)
        Me.cmbSucursal.TabIndex = 129
        '
        'FrmOrden
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtIVA)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.LblTotal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmOrden"
        Me.Text = "Orden de Compra"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String

    Public ORDClave As String
    Public Folio As String
    Public PRVClave As String
    Public ALMClave As String
    Public FecRegistro As DateTime
    Public UsrRegistro As String
    Public Autorizo As String = ""
    Public Nombre As String
    Public Estado As Integer = 1
    Public Subtotal As Double
    Public Impuesto As Double
    Public Total As Double
    Public Solicita As String
    Public Motivo As String
    Public Nota As String
    Public SUCClave As String
    Private dtDetalle As DataTable

    Private PROClave As String
    Private Cantidad As Double
    Private Clave As String
    Private Costo As Double
    Private IVA As Double
    Private NewEstado As Integer = 1
    Private NumDecimales As Integer
    Private TImpuesto As Integer
    Private TProducto As Integer
    Private bLoad As Boolean = False
    Private sPRVClave As String
    Private bUpdDetalle As Boolean = False

    Private alerta(5) As PictureBox
    Private reloj As parpadea

    Private Sub cmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedValueChanged
        If Not cmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then
            SUCClave = cmbSucursal.SelectedValue
            With cmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        End If
    End Sub

    Private Sub TxtClaveProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TxtClaveProv.Text = vbNullString Then
                CargaDatosProveedor(TxtClaveProv.Text.ToUpper.Trim.Replace("'", "''"))
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del proveedor
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_proveedor"
            a.TablaCmb = "Proveedor"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.NumColDes2 = 4
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProv.Text.Trim.ToUpper
            a.OcultaID = True
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                CargaDatosProveedor(a.Descripcion)
            End If
            a.Dispose()
        End If
    End Sub

    Private Sub BtnBuscaProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProv.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_proveedor"
        a.TablaCmb = "Proveedor"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.NumColDes2 = 4
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            CargaDatosProveedor(a.Descripcion)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not cmbSucursal.SelectedValue Is Nothing AndAlso sPRVClave <> "" AndAlso Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            Else
                MessageBox.Show("¡Clave de producto, la sucursal y el proveedor son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If Not cmbSucursal.SelectedValue Is Nothing AndAlso sPRVClave <> "" Then
                'Busca y recupera los datos del producto


                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_prod"
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.NumColDes = 2
                a.BusquedaInicial = True
                a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
                a.CompaniaRequerido = True
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    recuperaProducto(a.valor)
                End If
                a.Dispose()

            Else
                MessageBox.Show("¡la sucursal y el proveedor son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        If Not cmbSucursal.SelectedValue Is Nothing AndAlso sPRVClave <> "" Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()

        Else
            MessageBox.Show("¡la sucursal y el proveedor son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub BtnKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click

        If Not cmbSucursal.SelectedValue Is Nothing Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "DigitoOrd", "@COMClave", ModPOS.CompanyActual)
            Dim len As Integer = CInt(dt.Rows(0)("Valor"))
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_calcula_ordclave", "@SUCClave", SUCClave, "@len", len)

            TxtOrden.Text = dt.Rows(0)("Clave")
            dt.Dispose()

            TxtClaveProv.Focus()
        Else
            MessageBox.Show("¡la sucursal es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub

    Public Sub CargaDatosProveedor(ByVal Clave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_busca_proveedor", "@Clave", Clave, "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            sPRVClave = dt.Rows(0)("PRVClave")
            TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
            TxtClaveProv.Text = Clave
            TImpuesto = dt.Rows(0)("TImpuesto")
        Else
            MsgBox("No se encontro un proveedor que coincida con la clave proporcionada")
            TxtRazonSocial.Text = ""
            sPRVClave = ""
        End If
        dt.Dispose()
    End Sub

    Public Sub recuperaProducto(ByVal sClave As String)

        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"))
        If Not dtProducto Is Nothing Then

            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            IVA = ModPOS.RecuperaImpuesto(cmbSucursal.SelectedValue, PROClave, TImpuesto)
            NumDecimales = dtProducto.Rows(0)("Num_Decimales")
            TProducto = dtProducto.Rows(0)("TProducto")

            dtProducto.Dispose()

            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_obtener_costo", "@SUCClave", SUCClave, "@PROClave", PROClave)
            Costo = dt.Rows(0)("CostoVigente")
            dt.Dispose()


            Me.TxtDescripcion.Text = Nombre
            TxtCantidad.DecimalDigits = NumDecimales

            Dim dtRec As DataTable = ModPOS.SiExisteRecupera("sp_obtener_maximo_recomendado", "@SUCClave", cmbSucursal.SelectedValue, "@ALMClave", cmbAlmacen.SelectedValue, "@PROClave", PROClave)
            If Not dtRec Is Nothing Then
                TxtSugerido.Text = CStr(Redondear(dtRec.Rows(0)("Recomendado"), 2))
                dtRec.Dispose()
            Else
                TxtSugerido.Text = "0.00"
            End If

            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = Nombre

            With Me.cmbUnidad
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_unidad_vta"
                .NombreParametro1 = "PROClave"
                .Parametro1 = PROClave
                .llenar()
            End With

            TxtCantidad.Focus()
        Else
            PROClave = ""
            Cantidad = 0
            Clave = ""
            IVA = 0
            Costo = 0

            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAddProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddProv.Click
        If ModPOS.Proveedor Is Nothing Then
            ModPOS.Proveedor = New FrmProveedor
            With ModPOS.Proveedor
                .Text = "Agregar Proveedor"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .FromForm = "Orden"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Proveedor.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Proveedor.Show()
        ModPOS.Proveedor.BringToFront()
    End Sub

    Private Sub BtnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddProd.Click
        If ModPOS.Producto Is Nothing Then
            ModPOS.Producto = New FrmProducto
            With ModPOS.Producto
                .Text = "Agregar Producto"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabCosto.Enabled = False
                .UiTabKits.Enabled = True
                .UiTabEquivalentes.Enabled = True
                .ChkEstado.Enabled = False
                .TxtClave.Focus()
                .FromForm = "Orden"
            End With
        End If
        ModPOS.Producto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Producto.Show()
        ModPOS.Producto.BringToFront()
    End Sub

    Private Sub FrmOrden_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not ModPOS.MtoOrdenes Is Nothing Then

            If Not ModPOS.MtoOrdenes.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoOrdenes.Periodo > 0 AndAlso ModPOS.MtoOrdenes.Mes > 0 Then
                Cursor.Current = Cursors.WaitCursor
                ModPOS.MtoOrdenes.refreshGrid()
                Cursor.Current = Cursors.Default
            End If
        End If
        ModPOS.Orden.Dispose()
        ModPOS.Orden = Nothing
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtOrden.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClaveProv.Text = "" OrElse sPRVClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbAlmacen.SelectedValue Is Nothing Then
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

        If GridDetalle.RowCount <= 0 AndAlso Total <= 0 Then
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

    Private Sub FrmOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        With cmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        bLoad = True

        SUCClave = cmbSucursal.SelectedValue

        With cmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(cmbSucursal.SelectedValue Is Nothing, "", cmbSucursal.SelectedValue)
            .llenar()
        End With


        If Padre = "Nuevo" Then


            Me.TxtFecRegistro.Text = DateTime.Now.ToShortDateString 'ToString("MMMM dd, yyyy")
            Me.TxtSolicita.Text = MPrincipal.StUsuario.Text

            dtDetalle = ModPOS.CrearTabla("OrdenDetalle", _
            "ID", "System.String", _
            "Cantidad", "System.Double", _
            "Surtido", "System.Double", _
            "Clave", "System.String", _
            "Nombre", "System.String", _
            "Costo", "System.Double", _
            "PorcIVA", "System.Double", _
            "IVA", "System.Double", _
            "TProducto", "System.Int32", _
            "Subtotal", "System.Double", _
            "Impuesto", "System.Double", _
            "Importe", "System.Double")

            Solicita = ModPOS.UsuarioActual
        Else
            Me.TxtOrden.Text = Folio
            TxtOrden.Enabled = False
            Me.TxtFecRegistro.Text = DateTime.Now.ToShortDateString 'ToString("MMMM dd, yyyy")
            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_orden", "@ORDClave", ORDClave)
            GridDetalle.DataSource = dtDetalle

            TxtSolicita.Text = Solicita
            TxtMotivo.Text = Motivo
            TxtNota.Text = Nota
            Me.TxtSubtotal.Text = CStr(Redondear(Subtotal, 2))
            Me.TxtIVA.Text = CStr(Redondear(Impuesto, 2))
            Me.TxtTotal.Text = CStr(Redondear(Total, 2))

            NewEstado = Estado
            CargaDatosProveedor(TxtClaveProv.Text)
        End If

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("ID").Visible = False
        GridDetalle.RootTable.Columns("PorcIVA").Visible = False
        GridDetalle.RootTable.Columns("Subtotal").Visible = False
        GridDetalle.RootTable.Columns("Impuesto").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False

        GridDetalle.CurrentTable.Columns("Surtido").Selectable = False
        GridDetalle.CurrentTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        GridDetalle.CurrentTable.Columns("Costo").Selectable = False
        GridDetalle.CurrentTable.Columns("IVA").Selectable = False
        GridDetalle.CurrentTable.Columns("Importe").Selectable = False

    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If GridDetalle.RowCount >= 0 AndAlso Not GridDetalle.GetValue("ID") Is Nothing Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el producto: " & GridDetalle.GetValue("Clave") & ", " & GridDetalle.GetValue("Nombre"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes


                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("ID = '" & GridDetalle.GetValue("ID") & "'")

                    If foundRows.Length = 1 Then
                        bUpdDetalle = True
                        'Elimina
                        dtDetalle.Rows.Remove(foundRows(0))


                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        Cantidad = 0
                        Clave = ""
                        Nombre = ""
                        IVA = 0

                        If dtDetalle.Rows.Count = 0 Then
                            cmbSucursal.Enabled = True
                            TxtClaveProv.Enabled = True
                            BtnBuscaProv.Enabled = True
                            BtnAddProv.Enabled = True
                            TxtOrden.Enabled = True
                        End If

                        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        TxtSubtotal.Text = Format(CStr(ModPOS.Redondear(Subtotal, 2)), "Currency")
                        TxtIVA.Text = Format(CStr(ModPOS.Redondear(Impuesto, 2)), "Currency")
                        TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

                        TxtClaveProd.Focus()

                    End If
            End Select
        End If

    End Sub

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then

            If System.String.IsNullOrEmpty(PROClave) Then
                Beep()
                MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("ID = '" & PROClave & "'")

                If foundRows.Length = 0 Then

                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))

                    If Cantidad > 0 Then


                        If Not cmbUnidad.SelectedValue Is Nothing Then
                            Cantidad = CDbl(cmbUnidad.SelectedValue) * Cantidad
                        End If

                        bUpdDetalle = True
                        Dim row1 As DataRow
                        row1 = dtDetalle.NewRow()
                        'declara el nombre de la fila
                        row1.Item("ID") = PROClave
                        row1.Item("Cantidad") = Cantidad
                        row1.Item("Surtido") = 0
                        row1.Item("Clave") = Clave
                        row1.Item("Nombre") = Nombre
                        row1.Item("Costo") = Redondear(Costo, 2)
                        row1.Item("PorcIVA") = IVA
                        row1.Item("IVA") = Redondear(Costo * IVA, 2)
                        row1.Item("TProducto") = TProducto
                        'Totalizar 
                        row1.Item("Subtotal") = Redondear(Cantidad * Costo, 2)
                        row1.Item("Impuesto") = Redondear(Cantidad * (Costo * IVA), 2)
                        row1.Item("Importe") = Redondear(Cantidad * (Costo * (1 + IVA)), 2)

                        dtDetalle.Rows.Add(row1)
                        'agrega la fila completo a la tabla



                        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        TxtSubtotal.Text = Format(CStr(ModPOS.Redondear(Subtotal, 2)), "Currency")
                        TxtIVA.Text = Format(CStr(ModPOS.Redondear(Impuesto, 2)), "Currency")
                        TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        Cantidad = 0
                        Clave = ""
                        Nombre = ""
                        IVA = 0


                        If dtDetalle.Rows.Count = 1 Then
                            cmbSucursal.Enabled = False
                            TxtClaveProv.Enabled = False
                            BtnBuscaProv.Enabled = False
                            BtnAddProv.Enabled = False
                            TxtOrden.Enabled = False
                        End If

                        TxtClaveProd.Focus()

                    Else
                        MessageBox.Show("¡La Cantidad de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("¡El producto que intenta agregar ya existe en la compara actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            End If
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If Padre = "Nuevo" Then


                Folio = TxtOrden.Text.Trim.ToUpper
                SUCClave = cmbSucursal.SelectedValue
                ALMClave = cmbAlmacen.SelectedValue
                FecRegistro = Today
                PRVClave = sPRVClave
                Motivo = TxtMotivo.Text
                Solicita = TxtSolicita.Text
                Nota = TxtNota.Text

                If ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_ordfolio", "@Folio", Me.TxtOrden.Text.Trim.ToUpper, "@SUCClave", SUCClave) > 0 Then
                    MessageBox.Show("¡El Folio que intenta registrar ya existe en el sistema!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                ORDClave = ModPOS.obtenerLlave

                ModPOS.Ejecuta("sp_crea_orden", _
                            "@ORDClave", ORDClave, _
                            "@SUCClave", SUCClave, _
                            "@ALMClave", ALMClave, _
                            "@Folio", Folio, _
                            "@FechaRegistro", FecRegistro, _
                            "@PRVClave", PRVClave, _
                            "@Motivo", Motivo, _
                            "@Solicita", Solicita, _
                            "@Nota", Nota, _
                            "@Subtotal", Subtotal, _
                            "@ImpuestoTot", Impuesto, _
                            "@Total", Total, _
                            "@Estado", Estado, _
                            "@Usuario", ModPOS.UsuarioActual)

                Dim fila As Integer

                For fila = 0 To dtDetalle.Rows.Count - 1

                    ModPOS.Ejecuta("sp_inserta_detalleorden", _
                    "@ORDClave", ORDClave, _
                    "@fila", fila + 1, _
                    "@PROClave", dtDetalle.Rows(fila)("ID"), _
                    "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                    "@Costo", dtDetalle.Rows(fila)("Costo"), _
                    "@ImpuestoImp", dtDetalle.Rows(fila)("IVA"), _
                    "@ImpuestoPorc", dtDetalle.Rows(fila)("PorcIVA"), _
                    "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                    "@SubTotalPartida", dtDetalle.Rows(fila)("Costo") + dtDetalle.Rows(fila)("IVA"), _
                    "@TotalPartida", dtDetalle.Rows(fila)("Importe"))

                Next
                Padre = "Modificar"
            ElseIf Estado = 1 Then

                SUCClave = cmbSucursal.SelectedValue
                ALMClave = cmbAlmacen.SelectedValue
                PRVClave = sPRVClave
                Motivo = TxtMotivo.Text
                Solicita = TxtSolicita.Text
                Nota = TxtNota.Text

                ModPOS.Ejecuta("sp_actualiza_orden", _
                            "@ORDClave", ORDClave, _
                            "@SUCClave", SUCClave, _
                            "@ALMClave", ALMClave, _
                            "@PRVClave", PRVClave, _
                            "@Motivo", Motivo, _
                            "@Solicita", Solicita, _
                            "@Nota", Nota, _
                            "@Subtotal", Subtotal, _
                            "@ImpuestoTot", Impuesto, _
                            "@Total", Total, _
                            "@Estado", NewEstado, _
                            "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Ejecuta("sp_elimina_OrdenDet", "@ORDClave", ORDClave)

                Dim fila As Integer

                For fila = 0 To dtDetalle.Rows.Count - 1


                    ModPOS.Ejecuta("sp_inserta_detalleorden", _
                    "@ORDClave", ORDClave, _
                    "@fila", fila + 1, _
                    "@PROClave", dtDetalle.Rows(fila)("ID"), _
                    "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                    "@Costo", dtDetalle.Rows(fila)("Costo"), _
                    "@ImpuestoImp", dtDetalle.Rows(fila)("IVA"), _
                    "@ImpuestoPorc", dtDetalle.Rows(fila)("PorcIVA"), _
                    "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                    "@SubTotalPartida", dtDetalle.Rows(fila)("Costo") + dtDetalle.Rows(fila)("IVA"), _
                    "@TotalPartida", dtDetalle.Rows(fila)("Importe"))

                Next
            Else
                MessageBox.Show("No es posible modificar la Orden de Compra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("¿Desea imprimir la Orden de Compra?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                imprimirOrden()
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    'pendientes de revision


    Private Sub imprimirOrden()
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "RepOrden", "@COMClave", ModPOS.CompanyActual)
        Dim Reporte As String = CStr(dt.Rows(0)("Valor"))
        dt.Dispose()


        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        If Reporte = "Clasico" Then
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_orden", "@ORDClave", ORDClave))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_orden", "@ORDClave", ORDClave))
            OpenReport.PrintPreview("Orden de Compra", "CROrden.rpt", pvtaDataSet, "")
        Else
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_orden", "@ORDClave", ORDClave))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_orden", "@ORDClave", ORDClave))
            OpenReport.PrintPreview("Orden de Compra", "CROrdenC.rpt", pvtaDataSet, "")

        End If
    End Sub

    Private Sub BtnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportar.Click
        If PRVClave <> "" Then
            Dim FullPath As String
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If (result = DialogResult.OK) Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                FullPath = OpenFileDialog1.FileName

                If FullPath.Contains(".CSV") Then
                    Dim dtTemporal As DataTable = LeerCSV(FullPath)
                    If Not dtTemporal Is Nothing AndAlso dtTemporal.Rows.Count > 0 Then

                        Dim dtProducto As DataTable
                        Dim UBCClave As String = ""

                        Dim i As Integer
                        For i = 0 To dtTemporal.Rows.Count - 1
                            'Valida si existen datos para comparar
                            If Not dtTemporal.Rows(i)(0).GetType.FullName = "System.DBNull" AndAlso Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" Then
                                'Verifica que el producto exista
                                dtProducto = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", dtTemporal.Rows(i)(0).ToString.Trim)
                                If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count >= 1 Then
                                    'Verifica que la cantidad sea numerica
                                    If IsNumeric(dtTemporal.Rows(i)(1)) Then

                                        PROClave = dtProducto.Rows(0)("PROClave")
                                        Clave = dtProducto.Rows(0)("Clave")
                                        Nombre = dtProducto.Rows(0)("Nombre")

                                        NumDecimales = dtProducto.Rows(0)("Num_Decimales")

                                        IVA = ModPOS.RecuperaImpuesto(SUCClave, PROClave, TImpuesto)

                                        Cantidad = CDbl(dtTemporal.Rows(i)(1))

                                        Dim foundRows() As System.Data.DataRow
                                        foundRows = dtDetalle.Select("ID Like '" & PROClave & "'")

                                        If foundRows.Length = 0 Then
                                            If Cantidad > 0 Then
                                                Dim row1 As DataRow
                                                row1 = dtDetalle.NewRow()
                                                'declara el nombre de la fila
                                                row1.Item("ID") = PROClave
                                                row1.Item("Cantidad") = Cantidad
                                                row1.Item("Surtido") = 0.0
                                                row1.Item("Clave") = Clave
                                                row1.Item("Nombre") = Nombre
                                                row1.Item("Precio") = Redondear(Costo, 2)
                                                row1.Item("IVA") = Redondear(Costo * IVA, 2)
                                                row1.Item("PorcIVA") = IVA
                                                row1.Item("Subtotal") = Redondear(Cantidad * Costo, 2)
                                                row1.Item("Impuesto") = Redondear(Cantidad * (Costo * IVA), 2)
                                                row1.Item("Importe") = Redondear(Cantidad * (Costo * (1 + IVA)), 2)
                                                dtDetalle.Rows.Add(row1)
                                            End If
                                            'agrega la fila completo a la tabla
                                        ElseIf Cantidad = 0 AndAlso foundRows(0)("Surtido") = 0 Then
                                            'Elimina
                                            dtDetalle.Rows.Remove(foundRows(0))
                                        ElseIf Cantidad >= foundRows(0)("Surtido") Then
                                            'actualiza
                                            foundRows(0)("Cantidad") = Cantidad
                                            foundRows(0)("Subtotal") = Redondear(Cantidad * Costo, 2)
                                            foundRows(0)("Impuesto") = Redondear(Cantidad * (Costo * IVA), 2)
                                            foundRows(0)("Importe") = Redondear(Cantidad * (Costo * (1 + IVA)), 2)

                                        End If


                                    End If
                                    dtProducto.Dispose()
                                End If

                            End If
                        Next

                        Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        Me.TxtSubtotal.Text = CStr(Redondear(Subtotal, 2))
                        Me.TxtIVA.Text = CStr(Redondear(Impuesto, 2))
                        Me.TxtTotal.Text = CStr(Redondear(Total, 2))

                        dtTemporal.Dispose()

                        If dtDetalle.Rows.Count = 0 Then
                            MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    Else
                        MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

            End If
        Else
            MessageBox.Show("No se ha especificado el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class
