Public Class FrmEstrategia
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
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoZona As Selling.StoreCombo
    Friend WithEvents lblZona As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbOrigen As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridEstructura As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAddEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtEstructura As System.Windows.Forms.TextBox
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstrategia))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.lblZona = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.BtnBuscaUbicacion = New Janus.Windows.EditControls.UIButton
        Me.TxtUbicacion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnDelEst = New Janus.Windows.EditControls.UIButton
        Me.GridEstructura = New Janus.Windows.GridEX.GridEX
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnBuscaEst = New Janus.Windows.EditControls.UIButton
        Me.txtEstructura = New System.Windows.Forms.TextBox
        Me.btnAddEst = New Janus.Windows.EditControls.UIButton
        Me.CmbOrigen = New Selling.StoreCombo
        Me.cmbTipoZona = New Selling.StoreCombo
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbArea = New Selling.StoreCombo
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbTipo = New Selling.StoreCombo
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(493, 480)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 9
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancela y cierra ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Icon = CType(resources.GetObject("BtnAceptar.Icon"), System.Drawing.Icon)
        Me.BtnAceptar.Location = New System.Drawing.Point(590, 480)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 8
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guarda cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblZona
        '
        Me.lblZona.Location = New System.Drawing.Point(6, 143)
        Me.lblZona.Name = "lblZona"
        Me.lblZona.Size = New System.Drawing.Size(51, 16)
        Me.lblZona.TabIndex = 54
        Me.lblZona.Text = "Zona"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(71, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(271, 9)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(381, 21)
        Me.TxtDescripcion.TabIndex = 101
        '
        'BtnBuscaUbicacion
        '
        Me.BtnBuscaUbicacion.Image = CType(resources.GetObject("BtnBuscaUbicacion.Image"), System.Drawing.Image)
        Me.BtnBuscaUbicacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaUbicacion.Location = New System.Drawing.Point(281, 167)
        Me.BtnBuscaUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaUbicacion.Name = "BtnBuscaUbicacion"
        Me.BtnBuscaUbicacion.Size = New System.Drawing.Size(31, 25)
        Me.BtnBuscaUbicacion.TabIndex = 104
        Me.BtnBuscaUbicacion.ToolTipText = "Busqueda de Ubicación"
        Me.BtnBuscaUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbicacion.Location = New System.Drawing.Point(94, 169)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(173, 21)
        Me.TxtUbicacion.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Ubicación"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Almacén"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnDelEst)
        Me.GroupBox2.Controls.Add(Me.GridEstructura)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 249)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(673, 225)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estrategias Recolección/Colocación"
        '
        'btnDelEst
        '
        Me.btnDelEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelEst.Icon = CType(resources.GetObject("btnDelEst.Icon"), System.Drawing.Icon)
        Me.btnDelEst.Location = New System.Drawing.Point(592, 14)
        Me.btnDelEst.Name = "btnDelEst"
        Me.btnDelEst.Size = New System.Drawing.Size(75, 32)
        Me.btnDelEst.TabIndex = 4
        Me.btnDelEst.ToolTipText = "Eliminar estructura seleccionada"
        Me.btnDelEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEstructura
        '
        Me.GridEstructura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEstructura.ColumnAutoResize = True
        Me.GridEstructura.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEstructura.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEstructura.GroupByBoxVisible = False
        Me.GridEstructura.Location = New System.Drawing.Point(8, 52)
        Me.GridEstructura.Name = "GridEstructura"
        Me.GridEstructura.RecordNavigator = True
        Me.GridEstructura.Size = New System.Drawing.Size(659, 165)
        Me.GridEstructura.TabIndex = 1
        Me.GridEstructura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Estructura "
        '
        'btnBuscaEst
        '
        Me.btnBuscaEst.Image = CType(resources.GetObject("btnBuscaEst.Image"), System.Drawing.Image)
        Me.btnBuscaEst.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBuscaEst.Location = New System.Drawing.Point(280, 109)
        Me.btnBuscaEst.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscaEst.Name = "btnBuscaEst"
        Me.btnBuscaEst.Size = New System.Drawing.Size(31, 25)
        Me.btnBuscaEst.TabIndex = 2
        Me.btnBuscaEst.ToolTipText = "Busqueda de Estructura"
        Me.btnBuscaEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtEstructura
        '
        Me.txtEstructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstructura.Location = New System.Drawing.Point(93, 111)
        Me.txtEstructura.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEstructura.Name = "txtEstructura"
        Me.txtEstructura.Size = New System.Drawing.Size(174, 21)
        Me.txtEstructura.TabIndex = 1
        '
        'btnAddEst
        '
        Me.btnAddEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddEst.Icon = CType(resources.GetObject("btnAddEst.Icon"), System.Drawing.Icon)
        Me.btnAddEst.Location = New System.Drawing.Point(592, 160)
        Me.btnAddEst.Name = "btnAddEst"
        Me.btnAddEst.Size = New System.Drawing.Size(75, 32)
        Me.btnAddEst.TabIndex = 3
        Me.btnAddEst.ToolTipText = "Agregar estructura"
        Me.btnAddEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbOrigen
        '
        Me.CmbOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbOrigen.Location = New System.Drawing.Point(94, 46)
        Me.CmbOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(173, 21)
        Me.CmbOrigen.TabIndex = 6
        '
        'cmbTipoZona
        '
        Me.cmbTipoZona.Location = New System.Drawing.Point(94, 140)
        Me.cmbTipoZona.Name = "cmbTipoZona"
        Me.cmbTipoZona.Size = New System.Drawing.Size(173, 21)
        Me.cmbTipoZona.TabIndex = 5
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClaveProd.Enabled = False
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(101, 9)
        Me.TxtClaveProd.Multiline = True
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.ReadOnly = True
        Me.TxtClaveProd.Size = New System.Drawing.Size(164, 21)
        Me.TxtClaveProd.TabIndex = 108
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Producto"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbArea)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.btnAddEst)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnBuscaEst)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.lblZona)
        Me.GroupBox1.Controls.Add(Me.cmbTipoZona)
        Me.GroupBox1.Controls.Add(Me.txtEstructura)
        Me.GroupBox1.Controls.Add(Me.TxtUbicacion)
        Me.GroupBox1.Controls.Add(Me.BtnBuscaUbicacion)
        Me.GroupBox1.Controls.Add(Me.CmbOrigen)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(673, 207)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estrategia"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 16)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Area"
        '
        'cmbArea
        '
        Me.cmbArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbArea.Location = New System.Drawing.Point(93, 79)
        Me.cmbArea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(173, 21)
        Me.cmbArea.TabIndex = 115
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(71, 82)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 114
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(71, 148)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 113
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(71, 114)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 112
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(71, 49)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 111
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.Location = New System.Drawing.Point(93, 17)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(174, 21)
        Me.cmbTipo.TabIndex = 109
        '
        'FrmEstrategia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(690, 524)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtClaveProd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstrategia"
        Me.Text = "Estrategia"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String
    Public SUCClave As String
    Public ALMClave As String
    Public PROClave As String = ""
    Public UBCClave As String = ""
    Public Clave As String
    Public Nombre As String
    Public Ubicacion As String
    Public Zona As Integer
    Public Minimo As Double
    Public Maximo As Double
    Public Rotacion As Double
    Public Reorden As Double

    Private dtZona, dtEstrategia As DataTable
    Private alerta(4) As PictureBox
    Private reloj As parpadea
    Private dv As DataView
    Private sESTClave, sId As String
    Private bLoad As Boolean = False

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If dtEstrategia.Rows.Count > 0 Then
            ModPOS.Sucursal.setEstrategia(dtEstrategia, PROClave)
        End If
        Me.Close()
    End Sub

    Private Sub FrmEstrategia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        With cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Estrategia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With CmbOrigen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        If Not CmbOrigen.SelectedValue Is Nothing Then
            With Me.cmbArea
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_areas"
                .NombreParametro1 = "ALMClave"
                .Parametro1 = CmbOrigen.SelectedValue
                .llenar()
            End With
        End If

        With Me.cmbTipoZona
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Hueco"
            .NombreParametro2 = "campo"
            .Parametro2 = "Zona"
            .llenar()
        End With


        bLoad = True

        TxtClaveProd.Text = Clave
        TxtDescripcion.Text = Nombre

        dtEstrategia = ModPOS.Recupera_Tabla("sp_muestra_estrategia", "@SUCClave", SUCClave, "@PROClave", PROClave)

        Me.GridEstructura.DataSource = dtEstrategia
        GridEstructura.RetrieveStructure()
        GridEstructura.GroupByBoxVisible = False
        GridEstructura.RootTable.Columns("id").Visible = False
        GridEstructura.RootTable.Columns("ALMClave").Visible = False
        GridEstructura.RootTable.Columns("AREClave").Visible = False
        GridEstructura.RootTable.Columns("ESTClave").Visible = False
        GridEstructura.RootTable.Columns("PROClave").Visible = False
        GridEstructura.RootTable.Columns("UBCClave").Visible = False
        GridEstructura.RootTable.Columns("Update").Visible = False
        GridEstructura.RootTable.Columns("Baja").Visible = False
        
        GridEstructura.CurrentTable.Columns("Tipo").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridEstructura.Tables(0).Columns("Tipo").ValueList
        With AircraftTypeValueListItemCollection

            dtZona = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Estrategia", "@Campo", "Tipo")

            Dim i As Integer

            For i = 0 To dtZona.Rows.Count - 1
                .Add(dtZona.Rows(i)("valor"), dtZona.Rows(i)("descripcion"))
            Next

        End With
        GridEstructura.CurrentTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.Combo


        GridEstructura.CurrentTable.Columns("Zona").HasValueList = True
        AircraftTypeValueListItemCollection = GridEstructura.Tables(0).Columns("Zona").ValueList
        With AircraftTypeValueListItemCollection

            dtZona = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Hueco", "@Campo", "Zona")

            Dim i As Integer

            For i = 0 To dtZona.Rows.Count - 1
                .Add(dtZona.Rows(i)("valor"), dtZona.Rows(i)("descripcion"))
            Next

        End With
        GridEstructura.CurrentTable.Columns("Zona").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridEstructura.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridEstructura.RootTable.FormatConditions.Add(fc)




    End Sub

    Private Sub FrmEstrategia_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.Estrategia.Dispose()
        ModPOS.Estrategia = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If sESTClave = "" OrElse txtEstructura.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipoZona.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbArea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            Me.alerta(0).Visible = False
            Return True
        End If
    End Function

    Private Sub BtnBuscaUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaUbicacion.Click
        Dim a As New MeSearch
        If sESTClave <> "" Then
            a.ProcedimientoAlmacenado = "sp_search_ubicacion_est"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = sESTClave
            a.OcultaCol = True
            a.OcultaColNum = 0
        Else
            MessageBox.Show("¡La Estructura es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        a.NumColDes = 1
        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then
            If Not CmbOrigen.SelectedValue Is Nothing Then

                leeUbicacion(a.Descripcion, a.valor)
            Else
                UBCClave = ""
                TxtUbicacion.Text = ""
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
        a.Dispose()

    End Sub

    Private Sub btnDelEst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelEst.Click
        If Me.sId <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Estrategia: " & CStr(cmbTipo.SelectedItem(1)) & ", Orden: " & CStr(GridEstructura.GetValue("Orden")), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtEstrategia.Select("Id = '" & sId & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                        foundRows(0)("Update") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub leeUbicacion(ByVal Codigo As String, ByVal UBC As String)

        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            If UBC = "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion_est", "@ESTClave", sESTClave, "@Ubicacion", Codigo)

                If dt.Rows.Count > 0 Then
                    UBCClave = dt.Rows(0)("UBCClave")
                Else
                    UBCClave = ""
                    TxtUbicacion.Text = ""
                    Beep()
                    MessageBox.Show("La ubicación no se encuentra en la estructura seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                UBCClave = UBC
                TxtUbicacion.Text = Codigo
            End If

        Else
            UBCClave = ""
            TxtUbicacion.Text = ""
            Beep()
            MessageBox.Show("La ubicación no se encuentra en la estructura seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub leeEstructura(ByVal Codigo As String, ByVal EST As String)

        If PROClave = "" Then
            Beep()
            MessageBox.Show("No ha especificado el producto al que desea agregar la estrategia de almacenaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If cmbArea.SelectedValue Is Nothing Then
            Beep()
            MessageBox.Show("No ha especificado el area del almacén", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            If EST = "" Then
                Dim dtEst As DataTable = ModPOS.SiExisteRecupera("sp_search_estructura", "@ALMClave", cmbArea.SelectedValue, "@Campo", "1", "@Busqueda", Codigo.Replace("'", "''"))
                If Not dtEst Is Nothing AndAlso dtEst.Rows.Count > 0 Then
                    sESTClave = dtEst.Rows(0)("ESTClave")
                    txtEstructura.Text = dtEst.Rows(0)("Clave")
                    dtEst.Dispose()
                End If
            Else
                sESTClave = EST
            End If

            txtEstructura.Text = Codigo
        Else
            sESTClave = ""
            txtEstructura.Text = ""
            Beep()
            MessageBox.Show("La estructura no se encuentra en el area seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub GridEstructura_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridEstructura.CellEdited
        Select Case GridEstructura.CurrentColumn.Caption
            Case "Orden"
                If IsNumeric(GridEstructura.GetValue("Orden")) Then
                    If CInt(GridEstructura.GetValue("Orden")) < 0 Then
                        GridEstructura.SetValue("Orden", 0)
                    Else
                        GridEstructura.SetValue("Update", 1)
                    End If
                End If
        End Select
    End Sub

    Private Sub GridEstructura_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstructura.CurrentCellChanged
        If Not GridEstructura.CurrentColumn Is Nothing Then
            If GridEstructura.CurrentColumn.Caption = "Orden" Then
                GridEstructura.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridEstructura.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridEstructura_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstructura.SelectionChanged
        If Not GridEstructura.GetValue(0) Is Nothing Then
            Me.btnDelEst.Enabled = True
            Me.sId = GridEstructura.GetValue("Id")
        Else
            Me.sId = ""
            Me.btnDelEst.Enabled = False
        End If
    End Sub

    Private Sub txtEstructura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEstructura.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeEstructura(txtEstructura.Text.Trim.ToUpper.Replace("'", "''"), "")
        End If
    End Sub

    Private Sub btnAddEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEst.Click
        If validaForm() Then
            'Actualiza Surtido
            Dim foundRows() As System.Data.DataRow

            foundRows = dtEstrategia.Select("ESTClave = '" & sESTClave & "' and Zona = " & CStr(cmbTipoZona.SelectedValue) & " and Tipo = " & CStr(cmbTipo.SelectedValue) & " and Baja=0")

            If foundRows.Length = 0 Then
                foundRows = dtEstrategia.Select("Tipo = " & CStr(cmbTipo.SelectedValue))

                Dim row1 As DataRow
                row1 = dtEstrategia.NewRow()
                'declara el nombre de la fila
                row1.Item("id") = ModPOS.obtenerLlave
                row1.Item("ALMClave") = CmbOrigen.SelectedValue
                row1.Item("AREClave") = cmbArea.SelectedValue
                row1.Item("ESTClave") = sESTClave
                row1.Item("PROClave") = PROClave
                row1.Item("UBCClave") = UBCClave
                row1.Item("Orden") = foundRows.Length + 1
                row1.Item("Tipo") = cmbTipo.SelectedValue
                row1.Item("Zona") = cmbTipoZona.SelectedValue
                row1.Item("Almacén") = CmbOrigen.SelectedItem(1)
                row1.Item("Area") = cmbArea.SelectedItem(1)
                row1.Item("Estructura") = txtEstructura.Text
                row1.Item("Ubicación") = TxtUbicacion.Text
                row1.Item("Update") = 1
                row1.Item("Baja") = 0
                'agrega la fila completo a la tabla
                dtEstrategia.Rows.Add(row1)


                txtEstructura.Text = ""
                txtEstructura.Focus()
            Else
                Beep()
                MessageBox.Show("La Estrategia que intenta agregar ya fue asignada previamente para el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnBuscaEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaEst.Click
        Dim a As New MeSearch
        If Not cmbArea.SelectedValue Is Nothing Then
            a.ProcedimientoAlmacenado = "sp_search_estructura"
            a.TablaCmb = ""
            a.AlmRequerido = True
            a.ALMClave = cmbArea.SelectedValue
        Else
            MessageBox.Show("¡No se ha especificado el area del almacén!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        a.NumColDes = 1
        a.OcultaCol = True
        a.OcultaColNum = 0
        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then
            If Not cmbArea.SelectedValue Is Nothing Then
                leeEstructura(a.Descripcion, a.valor)
            Else
                Beep()
                MessageBox.Show("¡El area de Almacén es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
        a.Dispose()

    End Sub

    Private Sub TxtUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUbicacion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If sESTClave <> "" Then
                leeUbicacion(TxtUbicacion.Text.Trim.ToUpper.Replace("'", "''"), "")
            Else
                MessageBox.Show("¡La Estructura es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub CmbOrigen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOrigen.SelectedValueChanged
        If bLoad AndAlso Not CmbOrigen.SelectedValue Is Nothing Then
            With Me.cmbArea
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_areas"
                .NombreParametro1 = "ALMClave"
                .Parametro1 = CmbOrigen.SelectedValue
                .llenar()
            End With
        End If
    End Sub
End Class
