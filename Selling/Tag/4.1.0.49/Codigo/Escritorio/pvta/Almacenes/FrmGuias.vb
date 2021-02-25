Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmGuias
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
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPorSurtir As System.Windows.Forms.GroupBox
    Friend WithEvents gridPaquetes As Janus.Windows.GridEX.GridEX
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnPrnLabel As Janus.Windows.EditControls.UIButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGuias))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.gridPaquetes = New Janus.Windows.GridEX.GridEX()
        Me.btnPrnLabel = New Janus.Windows.EditControls.UIButton()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpPorSurtir.SuspendLayout()
        CType(Me.gridPaquetes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSaldos.Controls.Add(Me.Label26)
        Me.GrpSaldos.Controls.Add(Me.NumSaldo)
        Me.GrpSaldos.Controls.Add(Me.LblCredito)
        Me.GrpSaldos.Controls.Add(Me.NumDisponible)
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(8, 8)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(757, 349)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
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
        'GridSaldos
        '
        Me.GridSaldos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSaldos.ColumnAutoResize = True
        Me.GridSaldos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSaldos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSaldos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSaldos.Location = New System.Drawing.Point(16, 40)
        Me.GridSaldos.Name = "GridSaldos"
        Me.GridSaldos.RecordNavigator = True
        Me.GridSaldos.Size = New System.Drawing.Size(725, 293)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMetodos.Controls.Add(Me.BtnAgregar)
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Controls.Add(Me.BtnElimina)
        Me.GrpMetodos.Controls.Add(Me.BtnModifica)
        Me.GrpMetodos.Location = New System.Drawing.Point(3, 3)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(768, 359)
        Me.GrpMetodos.TabIndex = 5
        Me.GrpMetodos.TabStop = False
        Me.GrpMetodos.Text = "Metodos Preferidos de Pago"
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
        'GridMetodos
        '
        Me.GridMetodos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMetodos.ColumnAutoResize = True
        Me.GridMetodos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMetodos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMetodos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMetodos.Location = New System.Drawing.Point(8, 16)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(664, 335)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(16, 16)
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
        'GrpPorSurtir
        '
        Me.GrpPorSurtir.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPorSurtir.Controls.Add(Me.btnPrnLabel)
        Me.GrpPorSurtir.Controls.Add(Me.Label2)
        Me.GrpPorSurtir.Controls.Add(Me.TxtSearch)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSalir)
        Me.GrpPorSurtir.Controls.Add(Me.BtnAceptar)
        Me.GrpPorSurtir.Controls.Add(Me.Label1)
        Me.GrpPorSurtir.Controls.Add(Me.dtPicker)
        Me.GrpPorSurtir.Controls.Add(Me.gridPaquetes)
        Me.GrpPorSurtir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPorSurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPorSurtir.ForeColor = System.Drawing.Color.Black
        Me.GrpPorSurtir.Location = New System.Drawing.Point(0, 0)
        Me.GrpPorSurtir.Name = "GrpPorSurtir"
        Me.GrpPorSurtir.Size = New System.Drawing.Size(910, 564)
        Me.GrpPorSurtir.TabIndex = 23
        Me.GrpPorSurtir.TabStop = False
        Me.GrpPorSurtir.Text = "Paquetes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 16)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Folio del Documento"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(142, 22)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(307, 22)
        Me.TxtSearch.TabIndex = 52
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(716, 521)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAceptar.Icon = CType(resources.GetObject("BtnAceptar.Icon"), System.Drawing.Icon)
        Me.BtnAceptar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnAceptar.Location = New System.Drawing.Point(812, 521)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 25
        Me.BtnAceptar.Text = "Guardar"
        Me.BtnAceptar.ToolTipText = "Actualiza la guia de los paquetes"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(656, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(718, 19)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 24
        '
        'gridPaquetes
        '
        Me.gridPaquetes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridPaquetes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.gridPaquetes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridPaquetes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridPaquetes.GroupByBoxVisible = False
        Me.gridPaquetes.Location = New System.Drawing.Point(7, 47)
        Me.gridPaquetes.Name = "gridPaquetes"
        Me.gridPaquetes.RecordNavigator = True
        Me.gridPaquetes.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal
        Me.gridPaquetes.Size = New System.Drawing.Size(896, 468)
        Me.gridPaquetes.TabIndex = 4
        Me.gridPaquetes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnPrnLabel
        '
        Me.btnPrnLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrnLabel.Icon = CType(resources.GetObject("btnPrnLabel.Icon"), System.Drawing.Icon)
        Me.btnPrnLabel.Location = New System.Drawing.Point(6, 521)
        Me.btnPrnLabel.Name = "btnPrnLabel"
        Me.btnPrnLabel.Size = New System.Drawing.Size(117, 37)
        Me.btnPrnLabel.TabIndex = 161
        Me.btnPrnLabel.Text = "Imprimir Etiqueta"
        Me.btnPrnLabel.ToolTipText = "Reimprimir Etiqueta"
        Me.btnPrnLabel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmGuias
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(910, 564)
        Me.Controls.Add(Me.GrpPorSurtir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmGuias"
        Me.Text = "Guias de Paqueteria"
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpPorSurtir.ResumeLayout(False)
        Me.GrpPorSurtir.PerformLayout()
        CType(Me.gridPaquetes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    ' Private VENClave As String
    Private dtPaquete As DataTable
    Private bload As Boolean = False
    Private Periodo, Mes As Integer

    Private idSheet As String = ""
    Private TipoPapel As String = ""
    Private AnchoPapel As Integer
    Private AltoPapel As Integer
    Private mpSuperior As Integer
    Private mpInferior As Integer
    Private mpIzquierdo As Integer
    Private mpDerecho As Integer
    Private Horizontal As Boolean = False
    Private Columnas As Integer
    Private Filas As Integer
    Private EspacioColumna As Integer
    Private EspacioFila As Integer
    Private AnchoEtiqueta As Integer
    Private AltoEtiqueta As Integer
    Private meSuperior As Integer
    Private meInferior As Integer
    Private meIzquierdo As Integer
    Private meDerecho As Integer
    Private TipoLetra As String = ""
    Private SizeLetra As Single
    Private SizeCodigo As Single

    Public Sub AgregarFolio()

        Clock.Stop()
        TxtSearch.Text = TxtSearch.Text.ToUpper.Replace("'", "-")
      
            If Split(TxtSearch.Text, "-").Length = 3 Then
                TxtSearch.Text = Split(TxtSearch.Text, "-")(1) & "-" & Split(TxtSearch.Text, "-")(2)
            End If

            If Not dtPaquete Is Nothing Then
                dtPaquete.Dispose()
            End If
            dtPaquete = ModPOS.Recupera_Tabla("st_recuperar_guias_faltantes", "@SUCClave", SUCClave, "@Periodo", Periodo, "@Mes", Mes, "@Folio", TxtSearch.Text.Trim.ToUpper)
            gridPaquetes.DataSource = dtPaquete
            gridPaquetes.RetrieveStructure()
            gridPaquetes.AutoSizeColumns()
            'gridPaquetes.RootTable.Columns("Usuario").Visible = False
            'gridPaquetes.RootTable.Columns("Sucursal").Visible = False
            'gridPaquetes.RootTable.Columns("Cliente").Visible = False
            gridPaquetes.RootTable.Columns("original").Visible = False
            gridPaquetes.RootTable.Columns("IdPaquete").Width = 140
            gridPaquetes.RootTable.Columns("Fecha").Width = 80
            gridPaquetes.RootTable.Columns("guia").Width = 90


    End Sub

    Private Sub FrmGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Me.StartPosition = FormStartPosition.CenterScreen

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If
        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month
        bload = True
        Me.AgregarFolio()

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_filtra_labelsheet", "@Tipo", 3)

        If dt.Rows.Count > 0 Then
            idSheet = dt.Rows(0)("IDSheet")

        End If

        If idSheet <> "" Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_labelsheet", "@IDSheet", idSheet)

            TipoPapel = dt.Rows(0)("Nombre")
            AnchoPapel = dt.Rows(0)("AnchoPapel")
            AltoPapel = dt.Rows(0)("AltoPapel")
            mpSuperior = dt.Rows(0)("mpSuperior")
            mpInferior = dt.Rows(0)("mpInferior")
            mpIzquierdo = dt.Rows(0)("mpIzquierdo")
            mpDerecho = dt.Rows(0)("mpDerecho")
            Horizontal = dt.Rows(0)("Horizontal")
            Columnas = dt.Rows(0)("Columnas")
            Filas = dt.Rows(0)("Filas")
            EspacioColumna = dt.Rows(0)("EspacioColumna")
            EspacioFila = dt.Rows(0)("EspacioFila")
            AnchoEtiqueta = dt.Rows(0)("AnchoEtiqueta")
            AltoEtiqueta = dt.Rows(0)("AltoEtiqueta")
            meSuperior = dt.Rows(0)("meSuperior")
            meInferior = dt.Rows(0)("meInferior")
            meIzquierdo = dt.Rows(0)("meIzquierdo")
            meDerecho = dt.Rows(0)("meDerecho")
            TipoLetra = dt.Rows(0)("TipoLetra")
            SizeLetra = dt.Rows(0)("SizeLetra")
            SizeCodigo = dt.Rows(0)("SizeCodigo")
            dt.Dispose()

        End If


    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            If Not dtPaquete Is Nothing Then
                dtPaquete.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub



    Private Sub GridPicking_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPaquetes.CurrentCellChanged
        If Not gridPaquetes.CurrentColumn Is Nothing Then
            If gridPaquetes.CurrentColumn.Caption = "Marca" OrElse gridPaquetes.CurrentColumn.Caption = "guia" Then
                gridPaquetes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                gridPaquetes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridPicking_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPaquetes.SelectionChanged
        If Not gridPaquetes.GetValue(0) Is Nothing Then
            Me.BtnAceptar.Enabled = True
        Else
            Me.BtnAceptar.Enabled = False
        End If
    End Sub


    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        AgregarFolio()
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyUp
        Clock.Start()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Dim foundRows() As DataRow
        foundRows = dtPaquete.Select("guia <> original")

        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                ModPOS.Ejecuta("st_act_guia", "@idPaquete", foundRows(i)("idPaquete"), "@Guia", foundRows(i)("guia"))
            Next
        End If

    End Sub

    Private Sub ImprimirEtiqueta(ByVal numCopias As Integer, ByVal idPaquete As String, ByVal TipoPaq As String, ByVal Fecha As Date, ByVal Usuario As String, ByVal Origen As String, ByVal Cliente As String, ByVal Domicilio As String, ByVal Domicilio1 As String, ByVal Domicilio2 As String, ByVal guia As String, ByVal nota As String)
        ' define el tamaño de la etiqueta
        Dim lsPackingLabels As New PickingPrinting.PackingSet(New System.Drawing.Printing.PaperSize(TipoPapel, ModPOS.Redondear(AnchoPapel * 100 * 0.3937, 0), ModPOS.Redondear(AltoPapel * 100 * 0.3937, 0)), _
                                                                       Horizontal, _
                                                                       ModPOS.Redondear(AnchoEtiqueta * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(AltoEtiqueta * 100 * 0.3937, 0), _
                                                                       Columnas, _
                                                                       ModPOS.Redondear(EspacioColumna * 100 * 0.3937, 0), _
                                                                       Filas, _
                                                                       ModPOS.Redondear(EspacioFila * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpIzquierdo * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpDerecho * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpSuperior * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpInferior * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(meIzquierdo * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(meDerecho * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(meSuperior * 100 * 0.3937, 0), _
                                                                      ModPOS.Redondear(meInferior * 100 * 0.3937, 0))
        'define el tamaño y tipo de letras
        lsPackingLabels.PackingFont = New Font(TipoLetra, SizeLetra, FontStyle.Regular)
        lsPackingLabels.PackingFontBold = New Font(TipoLetra, SizeLetra, FontStyle.Bold)
        lsPackingLabels.PackingCodeFont = New Font("Free 3 of 9 Extended", SizeCodigo)

        'Crea la etiqueta

        Dim lblPackingLabel As New PickingPrinting.PackingSheet()

        lblPackingLabel.AddPacking(idPaquete)
        lblPackingLabel.AddTipoPaquete(TipoPaq)
        lblPackingLabel.AddFecha(Fecha)
        lblPackingLabel.AddNombreUsuario(Usuario)
        lblPackingLabel.AddOrigen(Origen)
        lblPackingLabel.AddCliente(Cliente)
        lblPackingLabel.AddCalle(Domicilio)
        lblPackingLabel.AddDomicilio1(Domicilio1)
        lblPackingLabel.addDomicilio2(Domicilio2)
        lblPackingLabel.addGuia(guia)
        lblPackingLabel.addNota(nota)

        Dim i As Integer
        For i = 1 To numCopias
            lsPackingLabels.AddPackingSheet(lblPackingLabel)
        Next


        ' Permite al usuario elegir la impresora:

        PrintDialog1.Document = lsPackingLabels
        PrintDialog1.AllowSomePages = True

        '  If PrintDialog1.ShowDialog() = DialogResult.OK Then
        PrintDialog1.Document.Print()
        '  End If

    End Sub

    Private Sub btnPrnLabel_Click(sender As Object, e As EventArgs) Handles btnPrnLabel.Click

        Dim foundRows() As DataRow
        foundRows = dtPaquete.Select("Marca=True")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                ImprimirEtiqueta(1, foundRows(i)("idPaquete"), foundRows(i)("T"), foundRows(i)("fecha"), foundRows(i)("Usuario"), foundRows(i)("Sucursal"), foundRows(i)("Cliente"), foundRows(i)("Domicilio"), foundRows(i)("Domicilio2"), foundRows(i)("Domicilio3"), foundRows(i)("guia"), foundRows(i)("nota"))
            Next
        Else
            MessageBox.Show("Debe marcar los registros que desea Imprimir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
