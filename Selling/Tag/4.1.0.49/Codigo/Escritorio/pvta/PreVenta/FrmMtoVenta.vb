Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmMtoVenta
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
    Friend WithEvents cmbInicio As System.Windows.Forms.DateTimePicker


    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtUsuarioNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label

    Friend WithEvents TxtClavePdV As System.Windows.Forms.TextBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label

    Friend WithEvents TxtNombrePdV As System.Windows.Forms.TextBox

    Friend WithEvents GridMovAlm As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpMovAlm As System.Windows.Forms.GroupBox
    Friend WithEvents grpMovAlmDet As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton

    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridResumen As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GridAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GridLiquidacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblIngresos As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblLiquidado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTotalAbonos As System.Windows.Forms.Label
    Friend WithEvents LblTotalLiquidar As System.Windows.Forms.Label
    Friend WithEvents LblEgresos As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionProd As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisionVta As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblTotalComision As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents GridPedidos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnFiltro As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMovAlmDet As Janus.Windows.GridEX.GridEX

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoVenta))
        Me.cmbInicio = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtUsuarioNombre = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClavePdV = New System.Windows.Forms.TextBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.TxtNombrePdV = New System.Windows.Forms.TextBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.grpMovAlmDet = New System.Windows.Forms.GroupBox()
        Me.GridMovAlmDet = New Janus.Windows.GridEX.GridEX()
        Me.grpMovAlm = New System.Windows.Forms.GroupBox()
        Me.GridMovAlm = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridResumen = New Janus.Windows.GridEX.GridEX()
        Me.LblTotalComision = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GridComisionProd = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GridComisionVta = New Janus.Windows.GridEX.GridEX()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblLiquidado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblTotalAbonos = New System.Windows.Forms.Label()
        Me.LblTotalLiquidar = New System.Windows.Forms.Label()
        Me.LblEgresos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblIngresos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GridLiquidacion = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.cmbFin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpPedidos = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.BtnFiltro = New Janus.Windows.EditControls.UIButton()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GridPedidos = New Janus.Windows.GridEX.GridEX()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.BtnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimprimir = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.grpMovAlmDet.SuspendLayout()
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovAlm.SuspendLayout()
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPedidos.SuspendLayout()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbInicio
        '
        Me.cmbInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbInicio.Location = New System.Drawing.Point(699, 17)
        Me.cmbInicio.Name = "cmbInicio"
        Me.cmbInicio.Size = New System.Drawing.Size(88, 22)
        Me.cmbInicio.TabIndex = 42
        Me.cmbInicio.Value = New Date(2012, 4, 13, 12, 36, 31, 0)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 328)
        Me.Panel1.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(6, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "Punto de Venta"
        '
        'TxtUsuarioNombre
        '
        Me.TxtUsuarioNombre.Location = New System.Drawing.Point(411, 12)
        Me.TxtUsuarioNombre.Name = "TxtUsuarioNombre"
        Me.TxtUsuarioNombre.ReadOnly = True
        Me.TxtUsuarioNombre.Size = New System.Drawing.Size(432, 20)
        Me.TxtUsuarioNombre.TabIndex = 5
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(351, 15)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(54, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Atiende"
        '
        'TxtClavePdV
        '
        Me.TxtClavePdV.Location = New System.Drawing.Point(97, 12)
        Me.TxtClavePdV.Name = "TxtClavePdV"
        Me.TxtClavePdV.ReadOnly = True
        Me.TxtClavePdV.Size = New System.Drawing.Size(47, 20)
        Me.TxtClavePdV.TabIndex = 7
        '
        'LblTipo
        '
        Me.LblTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipo.Location = New System.Drawing.Point(609, 22)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(83, 15)
        Me.LblTipo.TabIndex = 61
        Me.LblTipo.Text = "Periodo del "
        '
        'TxtNombrePdV
        '
        Me.TxtNombrePdV.Location = New System.Drawing.Point(149, 12)
        Me.TxtNombrePdV.Name = "TxtNombrePdV"
        Me.TxtNombrePdV.ReadOnly = True
        Me.TxtNombrePdV.Size = New System.Drawing.Size(196, 20)
        Me.TxtNombrePdV.TabIndex = 81
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(318, 335)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(108, 32)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nuevo transferencia"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(543, 335)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(108, 32)
        Me.BtnEliminar.TabIndex = 15
        Me.BtnEliminar.Text = "&Salir"
        Me.BtnEliminar.ToolTipText = "Cancelar transferencia seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(205, 335)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(108, 32)
        Me.BtnReimpresion.TabIndex = 14
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de transferencia seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grpMovAlmDet
        '
        Me.grpMovAlmDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMovAlmDet.Controls.Add(Me.GridMovAlmDet)
        Me.grpMovAlmDet.Location = New System.Drawing.Point(234, 1)
        Me.grpMovAlmDet.Name = "grpMovAlmDet"
        Me.grpMovAlmDet.Size = New System.Drawing.Size(534, 331)
        Me.grpMovAlmDet.TabIndex = 5
        Me.grpMovAlmDet.TabStop = False
        Me.grpMovAlmDet.Text = "Detalle"
        '
        'GridMovAlmDet
        '
        Me.GridMovAlmDet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMovAlmDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMovAlmDet.ColumnAutoResize = True
        Me.GridMovAlmDet.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMovAlmDet.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMovAlmDet.GroupByBoxVisible = False
        Me.GridMovAlmDet.Location = New System.Drawing.Point(6, 15)
        Me.GridMovAlmDet.Name = "GridMovAlmDet"
        Me.GridMovAlmDet.RecordNavigator = True
        Me.GridMovAlmDet.Size = New System.Drawing.Size(522, 309)
        Me.GridMovAlmDet.TabIndex = 3
        Me.GridMovAlmDet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpMovAlm
        '
        Me.grpMovAlm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpMovAlm.Controls.Add(Me.GridMovAlm)
        Me.grpMovAlm.Location = New System.Drawing.Point(0, 1)
        Me.grpMovAlm.Name = "grpMovAlm"
        Me.grpMovAlm.Size = New System.Drawing.Size(231, 330)
        Me.grpMovAlm.TabIndex = 4
        Me.grpMovAlm.TabStop = False
        Me.grpMovAlm.Text = "Documentos"
        '
        'GridMovAlm
        '
        Me.GridMovAlm.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMovAlm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMovAlm.ColumnAutoResize = True
        Me.GridMovAlm.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMovAlm.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMovAlm.GroupByBoxVisible = False
        Me.GridMovAlm.Location = New System.Drawing.Point(6, 15)
        Me.GridMovAlm.Name = "GridMovAlm"
        Me.GridMovAlm.RecordNavigator = True
        Me.GridMovAlm.Size = New System.Drawing.Size(219, 308)
        Me.GridMovAlm.TabIndex = 3
        Me.GridMovAlm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GridResumen)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(758, 366)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'GridResumen
        '
        Me.GridResumen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridResumen.ColumnAutoResize = True
        Me.GridResumen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridResumen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridResumen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridResumen.GroupByBoxVisible = False
        Me.GridResumen.Location = New System.Drawing.Point(6, 15)
        Me.GridResumen.Name = "GridResumen"
        Me.GridResumen.RecordNavigator = True
        Me.GridResumen.Size = New System.Drawing.Size(746, 344)
        Me.GridResumen.TabIndex = 3
        Me.GridResumen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblTotalComision
        '
        Me.LblTotalComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComision.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalComision.Location = New System.Drawing.Point(650, 339)
        Me.LblTotalComision.Name = "LblTotalComision"
        Me.LblTotalComision.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalComision.TabIndex = 87
        Me.LblTotalComision.Text = "0,0"
        Me.LblTotalComision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(531, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 15)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "T. a Comsión"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.GridComisionProd)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 128)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(758, 202)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Comisión por Producto"
        '
        'GridComisionProd
        '
        Me.GridComisionProd.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisionProd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisionProd.ColumnAutoResize = True
        Me.GridComisionProd.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisionProd.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisionProd.GroupByBoxVisible = False
        Me.GridComisionProd.Location = New System.Drawing.Point(6, 15)
        Me.GridComisionProd.Name = "GridComisionProd"
        Me.GridComisionProd.RecordNavigator = True
        Me.GridComisionProd.Size = New System.Drawing.Size(746, 180)
        Me.GridComisionProd.TabIndex = 3
        Me.GridComisionProd.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.GridComisionVta)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(758, 119)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Comisión por Venta"
        '
        'GridComisionVta
        '
        Me.GridComisionVta.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisionVta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisionVta.ColumnAutoResize = True
        Me.GridComisionVta.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisionVta.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisionVta.GroupByBoxVisible = False
        Me.GridComisionVta.Location = New System.Drawing.Point(6, 15)
        Me.GridComisionVta.Name = "GridComisionVta"
        Me.GridComisionVta.RecordNavigator = True
        Me.GridComisionVta.Size = New System.Drawing.Size(746, 97)
        Me.GridComisionVta.TabIndex = 3
        Me.GridComisionVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.Location = New System.Drawing.Point(539, 331)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(110, 30)
        Me.BtnCerrar.TabIndex = 91
        Me.BtnCerrar.Text = "F9- Cerrar"
        Me.BtnCerrar.ToolTipText = "Cierra el Documento Actual"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblSaldo.Location = New System.Drawing.Point(644, 254)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(113, 15)
        Me.LblSaldo.TabIndex = 90
        Me.LblSaldo.Text = "0.0"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(525, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 15)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "Saldo"
        '
        'LblLiquidado
        '
        Me.LblLiquidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLiquidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLiquidado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblLiquidado.Location = New System.Drawing.Point(644, 234)
        Me.LblLiquidado.Name = "LblLiquidado"
        Me.LblLiquidado.Size = New System.Drawing.Size(113, 15)
        Me.LblLiquidado.TabIndex = 88
        Me.LblLiquidado.Text = "0.0"
        Me.LblLiquidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(525, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 15)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Liquidado"
        '
        'LblTotalAbonos
        '
        Me.LblTotalAbonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalAbonos.Location = New System.Drawing.Point(87, 234)
        Me.LblTotalAbonos.Name = "LblTotalAbonos"
        Me.LblTotalAbonos.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalAbonos.TabIndex = 86
        Me.LblTotalAbonos.Text = "0,0"
        Me.LblTotalAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalLiquidar
        '
        Me.LblTotalLiquidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotalLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalLiquidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblTotalLiquidar.Location = New System.Drawing.Point(328, 282)
        Me.LblTotalLiquidar.Name = "LblTotalLiquidar"
        Me.LblTotalLiquidar.Size = New System.Drawing.Size(113, 15)
        Me.LblTotalLiquidar.TabIndex = 85
        Me.LblTotalLiquidar.Text = "0,0"
        Me.LblTotalLiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblEgresos
        '
        Me.LblEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEgresos.Location = New System.Drawing.Point(328, 254)
        Me.LblEgresos.Name = "LblEgresos"
        Me.LblEgresos.Size = New System.Drawing.Size(113, 15)
        Me.LblEgresos.TabIndex = 84
        Me.LblEgresos.Text = "0,0"
        Me.LblEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "T. Abonos"
        '
        'LblIngresos
        '
        Me.LblIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblIngresos.Location = New System.Drawing.Point(329, 234)
        Me.LblIngresos.Name = "LblIngresos"
        Me.LblIngresos.Size = New System.Drawing.Size(113, 15)
        Me.LblIngresos.TabIndex = 82
        Me.LblIngresos.Text = "0,0"
        Me.LblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(209, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "T. a Liquidar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(209, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "T. Egreso"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(210, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "T. Ingreso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.GridLiquidacion)
        Me.GroupBox4.Location = New System.Drawing.Point(206, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(557, 223)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resumen"
        '
        'GridLiquidacion
        '
        Me.GridLiquidacion.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLiquidacion.ColumnAutoResize = True
        Me.GridLiquidacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLiquidacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLiquidacion.GroupByBoxVisible = False
        Me.GridLiquidacion.Location = New System.Drawing.Point(6, 15)
        Me.GridLiquidacion.Name = "GridLiquidacion"
        Me.GridLiquidacion.RecordNavigator = True
        Me.GridLiquidacion.Size = New System.Drawing.Size(545, 201)
        Me.GridLiquidacion.TabIndex = 3
        Me.GridLiquidacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.GridAbonos)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(195, 223)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Abonos"
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
        Me.GridAbonos.Location = New System.Drawing.Point(6, 15)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(183, 201)
        Me.GridAbonos.TabIndex = 3
        Me.GridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(650, 326)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(108, 32)
        Me.UiButton1.TabIndex = 52
        Me.UiButton1.Text = "&Salir"
        Me.UiButton1.ToolTipText = "Salir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbFin
        '
        Me.cmbFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFin.Location = New System.Drawing.Point(817, 17)
        Me.cmbFin.Name = "cmbFin"
        Me.cmbFin.Size = New System.Drawing.Size(88, 22)
        Me.cmbFin.TabIndex = 82
        Me.cmbFin.Value = New Date(2012, 4, 13, 12, 36, 31, 0)
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(792, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 15)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "al"
        '
        'grpPedidos
        '
        Me.grpPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPedidos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpPedidos.Controls.Add(Me.btnConsultar)
        Me.grpPedidos.Controls.Add(Me.BtnFiltro)
        Me.grpPedidos.Controls.Add(Me.TxtFolio)
        Me.grpPedidos.Controls.Add(Me.Label3)
        Me.grpPedidos.Controls.Add(Me.GridPedidos)
        Me.grpPedidos.Controls.Add(Me.BtnSalir)
        Me.grpPedidos.Controls.Add(Me.BtnDevolucion)
        Me.grpPedidos.Controls.Add(Me.cmbFin)
        Me.grpPedidos.Controls.Add(Me.BtnFacturar)
        Me.grpPedidos.Controls.Add(Me.Label5)
        Me.grpPedidos.Controls.Add(Me.BtnNuevo)
        Me.grpPedidos.Controls.Add(Me.BtnCancelar)
        Me.grpPedidos.Controls.Add(Me.cmbInicio)
        Me.grpPedidos.Controls.Add(Me.BtnReimprimir)
        Me.grpPedidos.Controls.Add(Me.LblTipo)
        Me.grpPedidos.Controls.Add(Me.BtnModificar)
        Me.grpPedidos.Controls.Add(Me.ChkTodos)
        Me.grpPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPedidos.ForeColor = System.Drawing.Color.Black
        Me.grpPedidos.Location = New System.Drawing.Point(8, 38)
        Me.grpPedidos.Name = "grpPedidos"
        Me.grpPedidos.Size = New System.Drawing.Size(913, 432)
        Me.grpPedidos.TabIndex = 84
        Me.grpPedidos.TabStop = False
        Me.grpPedidos.Text = "Pedidos"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Icon = CType(resources.GetObject("btnConsultar.Icon"), System.Drawing.Icon)
        Me.btnConsultar.Location = New System.Drawing.Point(569, 396)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 94
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.ToolTipText = "Visualiza documento seleccionado"
        Me.btnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFiltro
        '
        Me.BtnFiltro.Icon = CType(resources.GetObject("BtnFiltro.Icon"), System.Drawing.Icon)
        Me.BtnFiltro.Location = New System.Drawing.Point(341, 13)
        Me.BtnFiltro.Name = "BtnFiltro"
        Me.BtnFiltro.Size = New System.Drawing.Size(39, 30)
        Me.BtnFiltro.TabIndex = 93
        Me.BtnFiltro.ToolTipText = "Quitar Filtro"
        Me.BtnFiltro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(141, 19)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(194, 21)
        Me.TxtFolio.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(86, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 18)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Folio"
        '
        'GridPedidos
        '
        Me.GridPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPedidos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridPedidos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPedidos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPedidos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPedidos.GroupByBoxVisible = False
        Me.GridPedidos.Location = New System.Drawing.Point(4, 45)
        Me.GridPedidos.Name = "GridPedidos"
        Me.GridPedidos.RecordNavigator = True
        Me.GridPedidos.Size = New System.Drawing.Size(901, 344)
        Me.GridPedidos.TabIndex = 90
        Me.GridPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(4, 396)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(110, 30)
        Me.BtnSalir.TabIndex = 89
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Icon = CType(resources.GetObject("BtnDevolucion.Icon"), System.Drawing.Icon)
        Me.BtnDevolucion.Location = New System.Drawing.Point(117, 396)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(110, 30)
        Me.BtnDevolucion.TabIndex = 88
        Me.BtnDevolucion.Text = "&Devolución"
        Me.BtnDevolucion.ToolTipText = "Crear Devolución"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFacturar.Icon = CType(resources.GetObject("BtnFacturar.Icon"), System.Drawing.Icon)
        Me.BtnFacturar.Location = New System.Drawing.Point(230, 396)
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(110, 30)
        Me.BtnFacturar.TabIndex = 87
        Me.BtnFacturar.Text = "&Facturar"
        Me.BtnFacturar.ToolTipText = "Crea una factura del registro seleccionado"
        Me.BtnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevo.Icon = CType(resources.GetObject("BtnNuevo.Icon"), System.Drawing.Icon)
        Me.BtnNuevo.Location = New System.Drawing.Point(795, 396)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(110, 30)
        Me.BtnNuevo.TabIndex = 86
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.ToolTipText = "Crea una nuevo registro"
        Me.BtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(343, 396)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(110, 30)
        Me.BtnCancelar.TabIndex = 85
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimprimir
        '
        Me.BtnReimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimprimir.Icon = CType(resources.GetObject("BtnReimprimir.Icon"), System.Drawing.Icon)
        Me.BtnReimprimir.Location = New System.Drawing.Point(682, 396)
        Me.BtnReimprimir.Name = "BtnReimprimir"
        Me.BtnReimprimir.Size = New System.Drawing.Size(110, 30)
        Me.BtnReimprimir.TabIndex = 83
        Me.BtnReimprimir.Text = "&Imprimir"
        Me.BtnReimprimir.ToolTipText = "Imprime los documentos selecionados"
        Me.BtnReimprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(456, 396)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(110, 30)
        Me.BtnModificar.TabIndex = 82
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica el documento seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Enabled = False
        Me.ChkTodos.Location = New System.Drawing.Point(7, 22)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(68, 20)
        Me.ChkTodos.TabIndex = 49
        Me.ChkTodos.Text = "Todos"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmMtoVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(932, 473)
        Me.Controls.Add(Me.grpPedidos)
        Me.Controls.Add(Me.TxtNombrePdV)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TxtClavePdV)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtUsuarioNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoVenta"
        Me.Text = "Vta. Convencional"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpMovAlmDet.ResumeLayout(False)
        CType(Me.GridMovAlmDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovAlm.ResumeLayout(False)
        CType(Me.GridMovAlm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.GridComisionProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GridComisionVta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GridLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPedidos.ResumeLayout(False)
        Me.grpPedidos.PerformLayout()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private bLoad As Boolean = False
    Private ClaveCaja As String
    Private Impresora, PrintGeneric, Recibo As String

    'Transacciones
    Private Autoriza As String


    Private dtTran As DataTable

    Private dSaldo As Double

    Private TICDevolucion As String
    Private CajaClave As String
    Private CajaNombre As String
    Private Moneda, Mostrador, Stage, StageCancelacion As String
    Private FormatoPedido As String
    Private Cajon As Boolean = False
    Public ActivarCaja As Boolean = False
    Public NombreVEN As String
    Public ClavePDV As String
    Public NombrePDV As String
    Public CAJClave As String
    Public ALMClave As String
    Public SUCClave As String
    Public PDVClave As String
    Public VendedorClave As String


    Private Sub FrmMtoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Cursor.Current = Cursors.WaitCursor

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_obtener_usuario", "@USRClave", ModPOS.UsuarioActual)

        VendedorClave = dt.Rows(0)("USRClave")
        NombreVEN = dt.Rows(0)("Nombre")

        dt.Dispose()


        Dim dtParam As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "FormatPedido"
                        FormatoPedido = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()



        Me.StartPosition = FormStartPosition.CenterScreen

        Dim fechainicio As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)


        cmbInicio.Value = fechainicio
        cmbFin.Value = Today.Date

        TxtClavePdV.Text = ClavePDV
        TxtNombrePdV.Text = NombrePDV
        TxtUsuarioNombre.Text = NombreVEN
        Cursor.Current = Cursors.Default

        If ActivarCaja = True Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)

            Recibo = dt.Rows(0)("TIKClave")
            ClaveCaja = dt.Rows(0)("Clave")
            TICDevolucion = dt.Rows(0)("TICDevolucion")
            Impresora = dt.Rows(0)("Referencia")
            PrintGeneric = dt.Rows(0)("Generic")
            CajaClave = dt.Rows(0)("Clave")
            CajaNombre = dt.Rows(0)("Nombre")

            Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))

            Stage = IIf(dt.Rows(0)("Stage").GetType.Name <> "DBNull", dt.Rows(0)("Stage"), "")
            StageCancelacion = IIf(dt.Rows(0)("StageCancelacion").GetType.Name <> "DBNull", dt.Rows(0)("StageCancelacion"), "")
            ' ConfirmarAbono = IIf(dt.Rows(0)("ConfirmaAbono").GetType.Name <> "DBNull", dt.Rows(0)("ConfirmaAbono"), 0)
            'muestraNotas = IIf(dt.Rows(0)("muestraNotas").GetType.Name <> "DBNull", dt.Rows(0)("muestraNotas"), 0)
            Mostrador = IIf(dt.Rows(0)("Mostrador").GetType.Name <> "DBNull", dt.Rows(0)("Mostrador"), "")

            dt.Dispose()
        Else
            BtnDevolucion.Visible = False
            BtnFacturar.Visible = False
        End If

        bLoad = True

        ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 1)

        Me.ActualizaGridTransac()

    End Sub

    Private Sub FrmMtoVenta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
        ModPOS.MtoVenta.Dispose()
        ModPOS.MtoVenta = Nothing
    End Sub



    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtTran.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                dSaldo = 0
                For i = 0 To GridPedidos.GetDataRows.Length - 1
                    GridPedidos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridPedidos.GetDataRows.Length - 1
                    GridPedidos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            dtTran.AcceptChanges()
            GridPedidos.Refresh()

            ' dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
        End If

    End Sub

    Public Sub ActualizaGridTransac()
        If Not dtTran Is Nothing Then
            dtTran.Dispose()
        End If

        dtTran = ModPOS.Recupera_Tabla("sp_recupera_vta_tran", "@PDVClave", PDVClave, "@Inicio", cmbInicio.Value, "@Fin", cmbFin.Value.AddHours(23.9999), "@COMClave", ModPOS.CompanyActual)
        With GridPedidos
            .DataSource = dtTran
            .RetrieveStructure()
            .AutoSizeColumns()
            .RootTable.Columns("VENClave").Visible = False
            .CurrentTable.Columns("iTipo").Visible = False
            .CurrentTable.Columns("iEstado").Visible = False
            .CurrentTable.Columns("CTEClave").Visible = False
            .CurrentTable.Columns("MONClave").Visible = False
            .CurrentTable.Columns("SaldoBase").Visible = False
            .RootTable.Columns("Marca").Width = 20
        End With




        ChkTodos.Enabled = True

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not dtTran Is Nothing Then

            Dim foundRows() As DataRow
            Dim bmotivo As Boolean = False
            Dim motCancelacion As Integer = -1

            foundRows = dtTran.Select("Marca ='True' and (iEstado = 2 or iEstado=3)  and (iTipo=1 or iTipo=3)")

            If foundRows.GetLength(0) = 1 Then


                Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = foundRows(0)("Total") * foundRows(0)("TipoCambio")
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.Autorizado Then
                                Autoriza = a.Autoriza

                                Dim dt As DataTable


                                dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(0)("VENClave"))
                                If dt.Rows.Count > 0 Then

                                    If dt.Rows(0)("Total") <> dt.Rows(0)("Saldo") Then
                                        MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        ActualizaGridTransac()
                                        Exit Sub
                                    End If


                                    If dt.Rows(0)("Estado") = 4 Then
                                        MessageBox.Show("El pedido seleccionado fue cancelado previamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        ActualizaGridTransac()
                                        Exit Sub
                                    End If


                                    If dt.Rows(0)("Estado") = 5 Then
                                        MessageBox.Show("El pedido seleccionado fue facturado previamente, por lo que no es posible cancelarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        ActualizaGridTransac()
                                        Exit Sub
                                    End If
                                End If

                                Do
                                    Dim m As New FrmMotivo
                                    m.Tabla = "Venta"
                                    m.Campo = "Cancelacion"
                                    m.ShowDialog()
                                    If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                        bmotivo = True
                                        motCancelacion = m.Motivo
                                    End If
                                    m.Dispose()
                                Loop While bmotivo = False

                                ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)("VENClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                             
                                If StageCancelacion <> "" Then
                                    ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("VENClave"), ALMClave, foundRows(0)("Folio"), Autoriza, False, 1, StageCancelacion)
                                Else
                                    ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("VENClave"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                End If

                                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                                ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("VENClave"), "@Tipo", 1)

                            End If
                        End If
                        a.Dispose()
                End Select
                Me.ActualizaGridTransac()
            Else
                MessageBox.Show("Debe marcar solo el documento que desea cancelar en Estado (Cerrado)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub Imprimir()
        previewPedido(FormatoPedido, GridPedidos.GetValue("VENClave"), GridPedidos.GetValue("Total"), SUCClave)
        Exit Sub
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Dim foundRows() As DataRow
        foundRows = dtTran.Select("Marca ='True' and iEstado = 6")

        If foundRows.GetLength(0) = 1 Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(0)("VENClave"))
            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("Estado") <> 6 Then
                    MessageBox.Show("No es posible modificar el documento seleccionado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActualizaGridTransac()
                    Exit Sub
                End If
            End If
            Entrar(foundRows(0)("VENClave"))
        Else
            MessageBox.Show("Debe seleccionar al menos un documento en Estado (Espera)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnFacturar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFacturar.Click
        Dim foundRows() As DataRow

        foundRows = dtTran.Select("Marca ='True' and (iEstado = 2 or iEstado=3)  and (iTipo=1 or iTipo=3)")

        If foundRows.GetLength(0) >= 1 Then

            Dim fr() As DataRow
            fr = dtTran.Select("Marca ='True'  and Clave <> '" & foundRows(0)("Clave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de diferentes clientes en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            fr = dtTran.Select("Marca ='True' and MONClave <> '" & foundRows(0)("MONClave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de diferentes Monedas en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtTran.Select("Marca ='True' and  MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de Tipo de Cambio Diferente en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            If ModPOS.Factura Is Nothing Then
                ModPOS.Factura = New FrmFactura
                ModPOS.Factura.SUCClave = SUCClave
                ModPOS.Factura.CAJClave = CAJClave
                ModPOS.Factura.CajaActiva = True
                ModPOS.Factura.Cajero = NombreVEN
                ModPOS.Factura.PrintGeneric = PrintGeneric
                ModPOS.Factura.Recibo = Recibo
                ModPOS.Factura.Cajon = Cajon
                ModPOS.Factura.ImpresoraCajon = Impresora
                ModPOS.Factura.Ventas = foundRows
                ModPOS.Factura.ClienteInicial = Mostrador
            End If
            ModPOS.Factura.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Factura.Show()
            If Not ModPOS.Factura Is Nothing Then
                ModPOS.Factura.BringToFront()
            End If

        Else
            MessageBox.Show("Para facturar, debe marcar por lo menos un registro en Estado (Cerrado o Pagado)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub BtnDevolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click
        Dim foundRows() As DataRow

        foundRows = dtTran.Select("Marca ='True' and iEstado = 2")

        If foundRows.GetLength(0) = 1 Then

            Dim dt As DataTable


            dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(0)("VENClave"))
            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("Estado") = 4 Then
                    MessageBox.Show("El pedido seleccionado fue cancelado previamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActualizaGridTransac()
                    Exit Sub
                End If


                If dt.Rows(0)("Estado") = 5 Then
                    MessageBox.Show("El pedido seleccionado fue facturado previamente, por lo que no es posible realizar una devolución", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActualizaGridTransac()
                    Exit Sub
                End If
            End If


            If ModPOS.Devolucion Is Nothing Then
                ModPOS.Devolucion = New FrmDevolucion
                ModPOS.Devolucion.Padre = "MtoVenta"
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = CajaClave
                ModPOS.Devolucion.Atiende = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = CajaNombre
                ModPOS.Devolucion.Cajon = Cajon
                ModPOS.Devolucion.Ventas = foundRows
                ModPOS.Devolucion.bLiquidacion = True
            End If
            ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Devolucion.ShowDialog()
        Else
            MessageBox.Show("Para Devolver, debe marcar solo un registro en Estado (Cerrado)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Entrar(ByVal VENClave As String)

        Dim dt As DataTable


        dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", PDVClave)


        If ModPOS.PreVenta Is Nothing Then
            ModPOS.PreVenta = New FrmTPV

            ModPOS.PreVenta.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
            ModPOS.PreVenta.StartPosition = FormStartPosition.CenterScreen

            With ModPOS.PreVenta
                '   .Padre = "MtoVta"
                If VENClave <> "" Then
                    .Padre = "Modificar"
                    .VentaAbierta = True
                    .VENClave = VENClave

                    .BtnCancelaProducto.Enabled = True
                    .BtnCancelaTicket.Enabled = True
                    .btnEnvio.Enabled = True
                    .BtnCerrar.Enabled = True
                    .BtnConvertir.Enabled = True
                    .BtnWait.Enabled = True
                Else
                    .Padre = "Nuevo"
                    .VentaAbierta = False
                    .btnBuscaCte.Enabled = False
                    .BtnCancelaProducto.Enabled = False
                    .BtnCancelaTicket.Enabled = False
                    .btnEnvio.Enabled = False
                    .BtnCerrar.Enabled = False
                    .TxtCantidad.Enabled = False
                    .TxtProducto.Enabled = False
                    .TxtCliente.Enabled = False
                    .BtnTC.Enabled = False
                    .BtnConvertir.Enabled = False
                    .BtnWait.Enabled = False
                End If
                .TipoCanal = dt.Rows(0)("TipoCanal")
                .ALMClave = dt.Rows(0)("ALMClave")
                .AlmacenClave = dt.Rows(0)("Clave")
                .AlmacenNombre = dt.Rows(0)("Nombre")
                .PDVClave = dt.Rows(0)("PDVClave")
                .PuntodeVenta = dt.Rows(0)("Descripcion")
                .Referencia = dt.Rows(0)("Referencia")
                .Impresora = dt.Rows(0)("Impresora")
                .Ticket = dt.Rows(0)("Ticket")
                .Supervisor = dt.Rows(0)("Supervisor")
                .Caja = ActivarCaja

                .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                .CAJClave = dt.Rows(0)("CAJClave")
                .CTEClaveInicial = dt.Rows(0)("CTEClave")
                .CTENombreInicial = dt.Rows(0)("Cliente")
                .lblCteClave.Text = dt.Rows(0)("ClaveCte")
                .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                .Redondeo = dt.Rows(0)("Redondeo")
                .Agotamiento = dt.Rows(0)("Agotamiento")
                .SolicitaVendedor = dt.Rows(0)("SolicitaVendedor")
                .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
                .LblFolio.Text = .Referencia & "- 0"
                .PrintGeneric = dt.Rows(0)("Generic")
                .sFrase = dt.Rows(0)("Frase")
                .ActivaDevolucion = dt.Rows(0)("Devolucion")
                .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

                .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))
                .Display = IIf(dt.Rows(0)("PoleDisplay").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("PoleDisplay"))))
                .Port = IIf(dt.Rows(0)("Puerto").GetType.Name = "DBNull", "COM5", dt.Rows(0)("Puerto"))
                .BaudRate = IIf(dt.Rows(0)("BaudRate").GetType.Name = "DBNull", 9600, dt.Rows(0)("BaudRate"))
                .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
                .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))
                .ActivarCotizacion = IIf(dt.Rows(0)("ActivarCotizacion").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ActivarCotizacion"))))
                .BloquearPrecio = IIf(dt.Rows(0)("BloquearPrecio").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("BloquearPrecio"))))
                .ImprimirRemoto = IIf(dt.Rows(0)("ImprimirRemoto").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ImprimirRemoto"))))


                .SucursalSurtido = dt.Rows(0)("SUCClave")
                .TipoVenta = IIf(dt.Rows(0)("TipoVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoVenta"))

                .txtLimite.Text = dt.Rows(0)("LimiteCredito")
                .txtDias.Text = dt.Rows(0)("DiasCredito")
                .txtSaldo.Text = dt.Rows(0)("SaldoCliente")

                dt.Dispose()
            End With
        End If

        ModPOS.PreVenta.ShowDialog()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Entrar("")
    End Sub

    Private Sub cmbDiaTrabajo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbInicio.ValueChanged
        If bLoad Then
            ActualizaGridTransac()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub GridPedidos_DoubleClick(sender As Object, e As EventArgs)
        BtnModificar.PerformClick()
    End Sub


    Private Sub BtnReimprimir_Click(sender As Object, e As EventArgs) Handles BtnReimprimir.Click
        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtTran.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            Dim sImpresora As String
            Dim iCopias As Integer = 0

            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                sImpresora = PrintDialog1.PrinterSettings.PrinterName
                iCopias = PrintDialog1.PrinterSettings.Copies
            Else
                Exit Sub
            End If

            For i = 0 To foundRows.GetUpperBound(0)

                previewPedido(FormatoPedido, foundRows(i)("VENCLave"), foundRows(i)("Total"), SUCClave, sImpresora, True, iCopias, True)

                foundRows(i)("Marca") = False
            Next
            ChkTodos.Checked = False

        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub GridPedidos_Click(sender As Object, e As EventArgs) Handles GridPedidos.Click
        If Not GridPedidos.CurrentColumn Is Nothing Then
            If GridPedidos.CurrentColumn.Caption <> "Marca" And Not GridPedidos.GetValue("Marca") Is Nothing Then
                If GridPedidos.GetValue("Marca") = False Then
                    GridPedidos.SetValue("Marca", True)
                Else
                    GridPedidos.SetValue("Marca", False)
                End If

                dtTran.AcceptChanges()

                GridPedidos.Refresh()
            End If
        End If
    End Sub

    Private Sub GridPedidos_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridPedidos.CurrentCellChanged
        If Not GridPedidos.CurrentColumn Is Nothing Then
            If GridPedidos.CurrentColumn.Caption = "Marca" Then
                GridPedidos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridPedidos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub cmbFin_ValueChanged(sender As Object, e As EventArgs) Handles cmbFin.ValueChanged
        If bLoad Then
            ActualizaGridTransac()
        End If
    End Sub

    Private Sub TxtFolio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtFolio.Text <> "" Then

                Dim condition As New Janus.Windows.GridEX.GridEXFilterCondition(GridPedidos.RootTable.Columns("Folio"), Janus.Windows.GridEX.ConditionOperator.EndsWith, TxtFolio.Text)

                GridPedidos.RootTable.FilterCondition = condition

            End If
        End If
    End Sub


    Private Sub BtnFiltro_Click(sender As Object, e As EventArgs) Handles BtnFiltro.Click
        TxtFolio.Text = ""
        Dim condition As New Janus.Windows.GridEX.GridEXFilterCondition(GridPedidos.RootTable.Columns("Folio"), Janus.Windows.GridEX.ConditionOperator.NotEqual, "")
        GridPedidos.RootTable.FilterCondition = condition
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim foundRows() As DataRow
        foundRows = dtTran.Select("Marca ='True'")

        If foundRows.GetLength(0) = 1 Then

            previewPedido(FormatoPedido, foundRows(0)("VENCLave"), foundRows(0)("Total"), SUCClave)

            foundRows(0)("Marca") = False


         
        Else
            MessageBox.Show("Debe seleccionar un solo documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
