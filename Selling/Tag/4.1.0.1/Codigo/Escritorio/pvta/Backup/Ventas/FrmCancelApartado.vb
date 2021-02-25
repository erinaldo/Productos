Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCancelApartado
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
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiTab As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabApartados As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpApartados As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnBuscaApartados As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents Lbl As System.Windows.Forms.Label
    Friend WithEvents GridApartados As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabAbonos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents GridCancelados As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCancelApartado))
        Me.LblFechaHora = New System.Windows.Forms.Label
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.UiTab = New Janus.Windows.UI.Tab.UITab
        Me.UiTabApartados = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpApartados = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.BtnBuscaApartados = New Janus.Windows.EditControls.UIButton
        Me.TxtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.Lbl = New System.Windows.Forms.Label
        Me.GridApartados = New Janus.Windows.GridEX.GridEX
        Me.UiTabAbonos = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpSaldos = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridCancelados = New Janus.Windows.GridEX.GridEX
        Me.CmbAlmacen = New Selling.StoreCombo
        CType(Me.UiTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab.SuspendLayout()
        Me.UiTabApartados.SuspendLayout()
        Me.GrpApartados.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridApartados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabAbonos.SuspendLayout()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblFechaHora
        '
        Me.LblFechaHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaHora.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblFechaHora.Location = New System.Drawing.Point(525, 7)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(267, 21)
        Me.LblFechaHora.TabIndex = 9
        Me.LblFechaHora.Text = "FechaActual"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(608, 522)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 19)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Almacén"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(704, 522)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 99
        Me.BtnCancelar.Text = "F6- Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancelar Apartados"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab
        '
        Me.UiTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab.Location = New System.Drawing.Point(5, 35)
        Me.UiTab.Name = "UiTab"
        Me.UiTab.Size = New System.Drawing.Size(789, 481)
        Me.UiTab.TabIndex = 100
        Me.UiTab.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabApartados, Me.UiTabAbonos})
        Me.UiTab.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabApartados
        '
        Me.UiTabApartados.Controls.Add(Me.GrpApartados)
        Me.UiTabApartados.Icon = CType(resources.GetObject("UiTabApartados.Icon"), System.Drawing.Icon)
        Me.UiTabApartados.Location = New System.Drawing.Point(1, 23)
        Me.UiTabApartados.Name = "UiTabApartados"
        Me.UiTabApartados.Size = New System.Drawing.Size(787, 457)
        Me.UiTabApartados.TabStop = True
        Me.UiTabApartados.Text = "Cancelación de Apartados"
        '
        'GrpApartados
        '
        Me.GrpApartados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpApartados.BackColor = System.Drawing.Color.Transparent
        Me.GrpApartados.Controls.Add(Me.GroupBox1)
        Me.GrpApartados.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpApartados.Controls.Add(Me.BtnBuscaApartados)
        Me.GrpApartados.Controls.Add(Me.TxtDias)
        Me.GrpApartados.Controls.Add(Me.PictureBox1)
        Me.GrpApartados.Controls.Add(Me.Label4)
        Me.GrpApartados.Controls.Add(Me.LblTotal)
        Me.GrpApartados.Controls.Add(Me.Lbl)
        Me.GrpApartados.Controls.Add(Me.GridApartados)
        Me.GrpApartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpApartados.ForeColor = System.Drawing.Color.Black
        Me.GrpApartados.Location = New System.Drawing.Point(2, 4)
        Me.GrpApartados.Name = "GrpApartados"
        Me.GrpApartados.Size = New System.Drawing.Size(782, 450)
        Me.GrpApartados.TabIndex = 1
        Me.GrpApartados.TabStop = False
        Me.GrpApartados.Text = "Apartados"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GridAbonos)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 276)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(770, 131)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Abonos Realizados"
        '
        'GridAbonos
        '
        Me.GridAbonos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAbonos.ColumnAutoResize = True
        Me.GridAbonos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAbonos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAbonos.GroupByBoxVisible = False
        Me.GridAbonos.Location = New System.Drawing.Point(5, 18)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(760, 107)
        Me.GridAbonos.TabIndex = 2
        Me.GridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(10, 19)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(145, 19)
        Me.ChkMarcaTodos.TabIndex = 114
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'BtnBuscaApartados
        '
        Me.BtnBuscaApartados.Image = CType(resources.GetObject("BtnBuscaApartados.Image"), System.Drawing.Image)
        Me.BtnBuscaApartados.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaApartados.Location = New System.Drawing.Point(474, 15)
        Me.BtnBuscaApartados.Name = "BtnBuscaApartados"
        Me.BtnBuscaApartados.Size = New System.Drawing.Size(43, 22)
        Me.BtnBuscaApartados.TabIndex = 53
        Me.BtnBuscaApartados.ToolTipText = "Consultar apartados menor o igual numero de días de antiguedad indicada"
        Me.BtnBuscaApartados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDias
        '
        Me.TxtDias.DecimalDigits = 0
        Me.TxtDias.Location = New System.Drawing.Point(394, 15)
        Me.TxtDias.Name = "TxtDias"
        Me.TxtDias.Size = New System.Drawing.Size(55, 22)
        Me.TxtDias.TabIndex = 52
        Me.TxtDias.Text = "0"
        Me.TxtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDias.Value = 0
        Me.TxtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(455, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(219, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 14)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Num. Días de Antiguedad"
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTotal.Location = New System.Drawing.Point(495, 411)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(270, 35)
        Me.LblTotal.TabIndex = 48
        Me.LblTotal.Text = "0.00"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl
        '
        Me.Lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Lbl.Location = New System.Drawing.Point(201, 410)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(294, 36)
        Me.Lbl.TabIndex = 47
        Me.Lbl.Text = "TOTAL A CANCELAR"
        '
        'GridApartados
        '
        Me.GridApartados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridApartados.ColumnAutoResize = True
        Me.GridApartados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridApartados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridApartados.GroupByBoxVisible = False
        Me.GridApartados.Location = New System.Drawing.Point(7, 41)
        Me.GridApartados.Name = "GridApartados"
        Me.GridApartados.RecordNavigator = True
        Me.GridApartados.Size = New System.Drawing.Size(768, 231)
        Me.GridApartados.TabIndex = 4
        Me.GridApartados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabAbonos
        '
        Me.UiTabAbonos.Controls.Add(Me.GrpSaldos)
        Me.UiTabAbonos.Icon = CType(resources.GetObject("UiTabAbonos.Icon"), System.Drawing.Icon)
        Me.UiTabAbonos.Location = New System.Drawing.Point(1, 23)
        Me.UiTabAbonos.Name = "UiTabAbonos"
        Me.UiTabAbonos.Size = New System.Drawing.Size(787, 457)
        Me.UiTabAbonos.TabStop = True
        Me.UiTabAbonos.Text = "Abonos Cancelados"
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.Transparent
        Me.GrpSaldos.Controls.Add(Me.Label1)
        Me.GrpSaldos.Controls.Add(Me.CmbCampo)
        Me.GrpSaldos.Controls.Add(Me.TxtBuscar)
        Me.GrpSaldos.Controls.Add(Me.GridCancelados)
        Me.GrpSaldos.Location = New System.Drawing.Point(7, 7)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(770, 442)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Abonos Cancelados "
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Consulta por cliente"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(117, 18)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(167, 21)
        Me.CmbCampo.TabIndex = 11
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(286, 19)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(479, 20)
        Me.TxtBuscar.TabIndex = 10
        '
        'GridCancelados
        '
        Me.GridCancelados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCancelados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCancelados.ColumnAutoResize = True
        Me.GridCancelados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCancelados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCancelados.Location = New System.Drawing.Point(5, 41)
        Me.GridCancelados.Name = "GridCancelados"
        Me.GridCancelados.RecordNavigator = True
        Me.GridCancelados.Size = New System.Drawing.Size(760, 395)
        Me.GridCancelados.TabIndex = 2
        Me.GridCancelados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(79, 8)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(308, 21)
        Me.CmbAlmacen.TabIndex = 96
        '
        'FrmCancelApartado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(799, 562)
        Me.Controls.Add(Me.UiTab)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmbAlmacen)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmCancelApartado"
        Me.Text = "Administración de Apartados"
        CType(Me.UiTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab.ResumeLayout(False)
        Me.UiTabApartados.ResumeLayout(False)
        Me.GrpApartados.ResumeLayout(False)
        Me.GrpApartados.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridApartados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabAbonos.ResumeLayout(False)
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private reloj As parpadea
    Private dtApartados As DataTable

    Private bLoad As Boolean = False
    Private dTotal As Double
    Private Antiguedad As Integer = 0
    Private sApartadoSelected As String = ""

    Private Sub FrmCancelApartado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        Me.StartPosition = FormStartPosition.CenterScreen

        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
        Clock.Start()

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        RecuperaFolios(Antiguedad, False)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub RecuperaFolios(ByVal iDias As Integer, ByVal Msg As Boolean)
        If Not CmbAlmacen.SelectedValue Is Nothing Then

            If Not dtApartados Is Nothing Then
                bLoad = False
                dtApartados.Dispose()
            End If

            dtApartados = ModPOS.Recupera_Tabla("sp_recupera_apartados", "@Dias", iDias, "@ALMClave", CmbAlmacen.SelectedValue)
            GridApartados.DataSource = dtApartados
            GridApartados.RetrieveStructure()
            GridApartados.AutoSizeColumns()
            GridApartados.RootTable.Columns("ID").Visible = False
            GridApartados.CurrentTable.Columns(2).Selectable = False
            GridApartados.CurrentTable.Columns(3).Selectable = False
            GridApartados.CurrentTable.Columns(4).Selectable = False
            GridApartados.CurrentTable.Columns(5).Selectable = False
            GridApartados.CurrentTable.Columns(6).Selectable = False
            GridApartados.CurrentTable.Columns(7).Selectable = False
            GridApartados.CurrentTable.Columns("CTEClave").Visible = False

            If dtApartados.Rows.Count = 0 Then
                If Msg Then
                    Dim dtrow As DataRowView
                    dtrow = CmbAlmacen.SelectedItem
                    MessageBox.Show("No se encontraron apartados con antiguedad menor o igual a " & TxtDias.Text & " días de la sucursal " & dtrow.Row.ItemArray(1), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            dTotal = 0
            Me.LblTotal.Text = Format(CStr(ModPOS.Redondear(dTotal, 2)), "Currency")
            bLoad = True

            ModPOS.ActualizaGrid(False, Me.GridAbonos, "sp_abn_apartados", "@VENClave", sApartadoSelected)
            GridCancelados.GroupByBoxVisible = False

        Else
            Beep()
            MessageBox.Show("¡Verifique los días de antiguedad y la sucursal seleccionada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    Private Sub FrmCancelApartado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Apartados.Dispose()
        ModPOS.Apartados = Nothing
    End Sub



    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnSalir.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F6
                Me.BtnCancelar.PerformClick()
        End Select
    End Sub


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not dtApartados Is Nothing AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            foundRows = dtApartados.Select("Marca ='True'")

            If foundRows.GetLength(0) > 0 Then

                Select Case MessageBox.Show("Se cancelaran todos los apartados seleccionados ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes

                        Dim a As New MeAutorizacion
                        a.Sucursal = CmbAlmacen.SelectedValue
                        a.MontodeAutorizacion = dTotal
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.Autorizado Then

                                For i = 0 To foundRows.GetUpperBound(0)
                                    ModPOS.Ejecuta("sp_libera_pagos_apartados", "@VENClave", foundRows(i)("ID"))
                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("ID"), "@TipoDoc", 4)
                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("ID"), "@Tipo", 1)
                                   
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("Saldo"))

                                Next
                            End If
                            dtApartados.Dispose()
                            RecuperaFolios(Antiguedad, True)
                        End If
                        a.Dispose()
                End Select
            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    
    Private Sub BtnBuscaApartados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaApartados.Click
        If CInt(TxtDias.Text) >= 0 Then
            Antiguedad = CInt(TxtDias.Text)
            RecuperaFolios(Antiguedad, True)
        Else
            MessageBox.Show("La antiguedad debe ser mayor o igual a cero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub GridApartados_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridApartados.CellValueChanged
        If GridApartados.GetValue("Marca") = True Then
            dTotal += CDbl(GridApartados.GetValue("Total"))
        Else
            dTotal -= CDbl(GridApartados.GetValue("Total"))
        End If
        Me.LblTotal.Text = Format(CStr(ModPOS.Redondear(dTotal, 2)), "Currency")
    End Sub


    Private Sub GridApartados_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridApartados.SelectionChanged
        If Not GridApartados.GetValue(0) Is Nothing Then
            sApartadoSelected = GridApartados.GetValue("ID")
        Else
            sApartadoSelected = ""
        End If

        If bLoad Then
            ModPOS.ActualizaGrid(False, GridAbonos, "sp_abn_apartados", "@VENClave", sApartadoSelected)
            GridCancelados.GroupByBoxVisible = False
        End If
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                ModPOS.ActualizaGrid(False, Me.GridCancelados, "sp_busca_abn_cancelados", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtApartados.Rows.Count > 0 Then
            Dim i As Integer
            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtApartados.Rows.Count - 1
                    If dtApartados.Rows(i)("Marca") = False Then
                        dtApartados.Rows(i)("Marca") = True
                        dTotal += dtApartados.Rows(i)("Total")
                    End If
                Next
            Else
                For i = 0 To dtApartados.Rows.Count - 1
                    If dtApartados.Rows(i)("Marca") = True Then
                        dtApartados.Rows(i)("Marca") = False
                        dTotal -= dtApartados.Rows(i)("Total")
                    End If
                Next
            End If
            Me.LblTotal.Text = Format(CStr(ModPOS.Redondear(dTotal, 2)), "Currency")
        End If
    End Sub
End Class
