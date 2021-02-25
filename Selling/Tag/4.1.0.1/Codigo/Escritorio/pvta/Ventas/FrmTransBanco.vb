
Public Class FrmTransBanco
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpExtra As System.Windows.Forms.GroupBox
    Friend WithEvents GrpRembolso As System.Windows.Forms.GroupBox
    Friend WithEvents GridRembolso As Janus.Windows.GridEX.GridEX
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransBanco))
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
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GrpExtra = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GrpRembolso = New System.Windows.Forms.GroupBox()
        Me.GridRembolso = New Janus.Windows.GridEX.GridEX()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpExtra.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpRembolso.SuspendLayout()
        CType(Me.GridRembolso, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(789, 517)
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
        Me.btnSalir.Location = New System.Drawing.Point(691, 517)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 118
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar complemento"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpExtra
        '
        Me.GrpExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpExtra.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpExtra.Controls.Add(Me.GridDetalle)
        Me.GrpExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpExtra.ForeColor = System.Drawing.Color.Black
        Me.GrpExtra.Location = New System.Drawing.Point(7, 138)
        Me.GrpExtra.Name = "GrpExtra"
        Me.GrpExtra.Size = New System.Drawing.Size(872, 373)
        Me.GrpExtra.TabIndex = 124
        Me.GrpExtra.TabStop = False
        Me.GrpExtra.Text = "Detalle:"
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(8, 18)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(858, 349)
        Me.GridDetalle.TabIndex = 2
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpRembolso
        '
        Me.GrpRembolso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRembolso.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpRembolso.Controls.Add(Me.GridRembolso)
        Me.GrpRembolso.Enabled = False
        Me.GrpRembolso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpRembolso.ForeColor = System.Drawing.Color.Black
        Me.GrpRembolso.Location = New System.Drawing.Point(7, 8)
        Me.GrpRembolso.Name = "GrpRembolso"
        Me.GrpRembolso.Size = New System.Drawing.Size(872, 124)
        Me.GrpRembolso.TabIndex = 135
        Me.GrpRembolso.TabStop = False
        Me.GrpRembolso.Text = "Anticipo / Reembolso / Devolución / Bonificación"
        '
        'GridRembolso
        '
        Me.GridRembolso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRembolso.ColumnAutoResize = True
        Me.GridRembolso.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridRembolso.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRembolso.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridRembolso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridRembolso.Location = New System.Drawing.Point(7, 21)
        Me.GridRembolso.Name = "GridRembolso"
        Me.GridRembolso.RecordNavigator = True
        Me.GridRembolso.Size = New System.Drawing.Size(858, 97)
        Me.GridRembolso.TabIndex = 7
        Me.GridRembolso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmTransBanco
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.GrpRembolso)
        Me.Controls.Add(Me.GrpExtra)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FrmTransBanco"
        Me.Text = "Transferencia a Bancos"
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpExtra.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpRembolso.ResumeLayout(False)
        CType(Me.GridRembolso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public IdCorte As String
    Public Consulta As Boolean = False
    Public CAJClave As String = ""
    Public InterfazSalida As String = ""
    Public iTransBanco As Integer = 0

    Private dtTransf, dtReembolso, dtMoneda, dtMoneda2, dtMetodo, dtTerminal, dtCuenta As DataTable
    Private bError As Boolean = False

    Private Sub FrmTransBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim i As Integer

        dtReembolso = ModPOS.Recupera_Tabla("st_recupera_reembolso", "@IdCorte", IdCorte)
        GridRembolso.DataSource = dtReembolso
        GridRembolso.RetrieveStructure(True)
        GridRembolso.GroupByBoxVisible = False


        GridRembolso.CurrentTable.Columns("Moneda").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridRembolso.Tables(0).Columns("Moneda").ValueList
        With AircraftTypeValueListItemCollection
            dtMoneda2 = ModPOS.Recupera_Tabla("st_filtra_moneda", Nothing)

            For i = 0 To dtMoneda2.Rows.Count - 1
                .Add(dtMoneda2.Rows(i)("MONClave"), dtMoneda2.Rows(i)("Referencia"))
            Next
        End With
        GridRembolso.CurrentTable.Columns("Moneda").EditType = Janus.Windows.GridEX.EditType.Combo



        dtTransf = ModPOS.Recupera_Tabla("st_recupera_transbanco", "@IdCorte", IdCorte)


        GridDetalle.DataSource = dtTransf
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("Moneda").Selectable = False
        GridDetalle.RootTable.Columns("Metodo").Selectable = False
        GridDetalle.RootTable.Columns("Cliente").Selectable = False
        GridDetalle.RootTable.Columns("Importe").Selectable = False
        GridDetalle.RootTable.Columns("Referencia").Selectable = False
        GridDetalle.RootTable.Columns("Terminal").Selectable = False
        GridDetalle.RootTable.Columns("Observación").Selectable = False

        GridDetalle.RootTable.Columns("Moneda").Width = 40
        GridDetalle.RootTable.Columns("Metodo").Width = 45
        GridDetalle.RootTable.Columns("Observación").Width = 45
        GridDetalle.RootTable.Columns("Importe").Width = 50
        GridDetalle.RootTable.Columns("Cliente").Width = 70
        GridDetalle.RootTable.Columns("Referencia").Width = 40
        GridDetalle.RootTable.Columns("Terminal").Width = 60
        GridDetalle.RootTable.Columns("Depositar").Width = 120
        GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far




        If Consulta = True Then
            GridDetalle.RootTable.Columns("Depositar").Visible = False
        End If

        GridDetalle.CurrentTable.Columns("Moneda").HasValueList = True
        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = GridDetalle.Tables(0).Columns("Moneda").ValueList
        With AircraftTypeValueListItemCollection2
            dtMoneda = ModPOS.Recupera_Tabla("st_filtra_moneda", Nothing)
            For i = 0 To dtMoneda.Rows.Count - 1
                .Add(dtMoneda.Rows(i)("MONClave"), dtMoneda.Rows(i)("Referencia"))
            Next
        End With
        GridDetalle.CurrentTable.Columns("Moneda").EditType = Janus.Windows.GridEX.EditType.Combo


        GridDetalle.CurrentTable.Columns("Metodo").HasValueList = True
        Dim AircraftTypeValueListItemCollection3 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection3 = GridDetalle.Tables(0).Columns("Metodo").ValueList
        With AircraftTypeValueListItemCollection3
            dtMetodo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "CFD", "@Campo", "MetodoPago")
            For i = 0 To dtMetodo.Rows.Count - 1
                .Add(dtMetodo.Rows(i)("Valor"), IIf(dtMetodo.Rows(i)("Valor") = 2, "Tarjeta", dtMetodo.Rows(i)("Descripcion")))
            Next
        End With
        GridDetalle.CurrentTable.Columns("Moneda").EditType = Janus.Windows.GridEX.EditType.Combo


        GridDetalle.CurrentTable.Columns("Terminal").HasValueList = True
        Dim AircraftTypeValueListItemCollection4 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection4 = GridDetalle.Tables(0).Columns("Terminal").ValueList
        With AircraftTypeValueListItemCollection4
            dtTerminal = ModPOS.Recupera_Tabla("st_filtra_terminal", "@CAJClave", CAJClave)
            For i = 0 To dtTerminal.Rows.Count - 1
                .Add(dtTerminal.Rows(i)("TERClave"), dtTerminal.Rows(i)("Terminal"))
            Next
        End With
        GridDetalle.CurrentTable.Columns("Terminal").EditType = Janus.Windows.GridEX.EditType.Combo


        GridDetalle.CurrentTable.Columns("Depositar").HasValueList = True
        Dim AircraftTypeValueListItemCollection5 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection5 = GridDetalle.Tables(0).Columns("Depositar").ValueList
        With AircraftTypeValueListItemCollection5
            dtCuenta = ModPOS.Recupera_Tabla("st_filtra_cuenta", Nothing)

            For i = 0 To dtCuenta.Rows.Count - 1
                .Add(dtCuenta.Rows(i)("Cuenta"), dtCuenta.Rows(i)("Referencia"))
            Next
        End With
        GridDetalle.CurrentTable.Columns("Depositar").EditType = Janus.Windows.GridEX.EditType.Combo

        iTransBanco = dtTransf.Rows.Count

    End Sub

    Private Sub FrmTransBanco_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Consulta = False Then

            Dim fila As Integer


            If dtTransf.Rows.Count > 0 Then


                Dim foundRows() As Data.DataRow

                foundRows = dtTransf.Select(" Depositar = '' or Depositar is Null")
                If foundRows.Length > 0 Then
                    Beep()
                    MessageBox.Show("Debe seleccionar el número de operación o cuenta al que realizara el Deposito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bError = True
                    Exit Sub
                Else
                    Select Case MessageBox.Show("¿Los numeros de operación o cuenta a depositar son correctos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.No
                            bError = True
                            Exit Sub
                    End Select
                End If


                Dim BNKClave, CNTAClave As String
                Dim Anticipo As Integer

                Cursor.Current = Cursors.WaitCursor
                For fila = 0 To dtTransf.Rows.Count - 1

                    If dtTransf.Rows(fila)("Observación").GetType.Name = "DBNull" Then
                        Anticipo = 0
                    ElseIf dtTransf.Rows(fila)("Observación") = "Anticipo" Then
                        Anticipo = 1
                    Else
                        Anticipo = 0
                    End If

                    BNKClave = CStr(dtTransf.Rows(fila)("Depositar")).Split("|")(0)
                    CNTAClave = CStr(dtTransf.Rows(fila)("Depositar")).Split("|")(1)

                    ModPOS.Ejecuta("st_transferencia_banco", _
                                 "@IdCorte", IdCorte, _
                                 "@TipoPago", dtTransf.Rows(fila)("Metodo"), _
                                 "@MONClave", dtTransf.Rows(fila)("Moneda"), _
                                 "@Importe", dtTransf.Rows(fila)("Importe"), _
                                 "@TERClave", dtTransf.Rows(fila)("Terminal"), _
                                 "@BNKClave", BNKClave, _
                                 "@CNTAClave", CNTAClave, _
                                 "@Anticipo", Anticipo, _
                                 "@Usuario", ModPOS.UsuarioActual)



                Next
                Dim Total As Double = dtTransf.Compute("SUM(Importe)", "")
                ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IdCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)

                Cursor.Current = Cursors.Default

                If InterfazSalida <> "" Then

                    Dim sFolio, sFecha As String
                    Dim dtInterfaz As DataTable
                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                    sFolio = IdCorte
                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Transferencia", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 Then
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                    End If
                End If

                Select Case MessageBox.Show("¿Desea imprimir el Corte de Caja?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim sImpresora As String
                        Dim iCopias As Integer
                        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                            iCopias = PrintDialog1.PrinterSettings.Copies

                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IdCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", IdCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_creditos", "@IdCorte", IdCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_otrospagos", "@IdCorte", IdCorte))
                            OpenReport.Print(iCopias, "CRCorte.rpt", pvtaDataSet, "", sImpresora)
                        End If
                End Select

            End If


         
        End If
        bError = False
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

   

    

End Class
