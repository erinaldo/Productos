<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormCuotas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        If Not Me.FlexGridClientes Is Nothing Then Me.FlexGridClientes.Dispose()
        Me.FlexGridClientes = Nothing
        If Not Me.FlexGridEsquemas Is Nothing Then Me.FlexGridEsquemas.Dispose()
        Me.FlexGridEsquemas = Nothing
        If Not Me.FlexGridProductos Is Nothing Then Me.FlexGridProductos.Dispose()
        Me.FlexGridProductos = Nothing
        If Not Me.FlexGridVendedor Is Nothing Then Me.FlexGridVendedor.Dispose()
        Me.FlexGridVendedor = Nothing
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.mainMenu1 Is Nothing Then Me.mainMenu1.Dispose()
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCuotas))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlCuotas = New System.Windows.Forms.TabControl
        Me.TabPageEsquemas = New System.Windows.Forms.TabPage
        Me.lbPorcentaje1 = New System.Windows.Forms.Label
        Me.btRegresarEsquemas = New System.Windows.Forms.Button
        Me.btContinuarEsquemas = New System.Windows.Forms.Button
        Me.pbEsquemas = New System.Windows.Forms.ProgressBar
        Me.FlexGridEsquemas = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.lbEsquemas = New System.Windows.Forms.Label
        Me.TabPageProducto = New System.Windows.Forms.TabPage
        Me.lbPorcentaje2 = New System.Windows.Forms.Label
        Me.pbProducto = New System.Windows.Forms.ProgressBar
        Me.btRegresarProductos = New System.Windows.Forms.Button
        Me.btContinuarProductos = New System.Windows.Forms.Button
        Me.FlexGridProductos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.lbProducto = New System.Windows.Forms.Label
        Me.TabPageClientes = New System.Windows.Forms.TabPage
        Me.lbPorcentaje3 = New System.Windows.Forms.Label
        Me.FlexGridClientes = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.pbClientes = New System.Windows.Forms.ProgressBar
        Me.btRegresarClientes = New System.Windows.Forms.Button
        Me.btContinuarClientes = New System.Windows.Forms.Button
        Me.lbClientes = New System.Windows.Forms.Label
        Me.TabPageVendedor = New System.Windows.Forms.TabPage
        Me.lbPorcentaje4 = New System.Windows.Forms.Label
        Me.FlexGridVendedor = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.pbVendedor = New System.Windows.Forms.ProgressBar
        Me.btRegresarVendedor = New System.Windows.Forms.Button
        Me.btContinuarVendedor = New System.Windows.Forms.Button
        Me.lbVendedor = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControlCuotas.SuspendLayout()
        Me.TabPageEsquemas.SuspendLayout()
        Me.TabPageProducto.SuspendLayout()
        Me.TabPageClientes.SuspendLayout()
        Me.TabPageVendedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlCuotas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlCuotas
        '
        Me.TabControlCuotas.Controls.Add(Me.TabPageEsquemas)
        Me.TabControlCuotas.Controls.Add(Me.TabPageProducto)
        Me.TabControlCuotas.Controls.Add(Me.TabPageClientes)
        Me.TabControlCuotas.Controls.Add(Me.TabPageVendedor)
        Me.TabControlCuotas.Location = New System.Drawing.Point(0, 2)
        Me.TabControlCuotas.Name = "TabControlCuotas"
        Me.TabControlCuotas.SelectedIndex = 0
        Me.TabControlCuotas.Size = New System.Drawing.Size(242, 295)
        Me.TabControlCuotas.TabIndex = 3
        '
        'TabPageEsquemas
        '
        Me.TabPageEsquemas.Controls.Add(Me.lbPorcentaje1)
        Me.TabPageEsquemas.Controls.Add(Me.btRegresarEsquemas)
        Me.TabPageEsquemas.Controls.Add(Me.btContinuarEsquemas)
        Me.TabPageEsquemas.Controls.Add(Me.pbEsquemas)
        Me.TabPageEsquemas.Controls.Add(Me.FlexGridEsquemas)
        Me.TabPageEsquemas.Controls.Add(Me.lbEsquemas)
        Me.TabPageEsquemas.Location = New System.Drawing.Point(4, 25)
        Me.TabPageEsquemas.Name = "TabPageEsquemas"
        Me.TabPageEsquemas.Size = New System.Drawing.Size(232, 265)
        Me.TabPageEsquemas.Text = "TabPageEsquemas"
        '
        'lbPorcentaje1
        '
        Me.lbPorcentaje1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbPorcentaje1.Location = New System.Drawing.Point(6, 203)
        Me.lbPorcentaje1.Name = "lbPorcentaje1"
        Me.lbPorcentaje1.Size = New System.Drawing.Size(226, 18)
        Me.lbPorcentaje1.Text = "lbPorcentaje1"
        '
        'btRegresarEsquemas
        '
        Me.btRegresarEsquemas.Location = New System.Drawing.Point(86, 238)
        Me.btRegresarEsquemas.Name = "btRegresarEsquemas"
        Me.btRegresarEsquemas.Size = New System.Drawing.Size(74, 24)
        Me.btRegresarEsquemas.TabIndex = 4
        Me.btRegresarEsquemas.Text = "btRegresarEsquemas"
        '
        'btContinuarEsquemas
        '
        Me.btContinuarEsquemas.Location = New System.Drawing.Point(6, 238)
        Me.btContinuarEsquemas.Name = "btContinuarEsquemas"
        Me.btContinuarEsquemas.Size = New System.Drawing.Size(74, 24)
        Me.btContinuarEsquemas.TabIndex = 3
        Me.btContinuarEsquemas.Text = "btContinuarEsquemas"
        '
        'pbEsquemas
        '
        Me.pbEsquemas.Location = New System.Drawing.Point(6, 221)
        Me.pbEsquemas.Name = "pbEsquemas"
        Me.pbEsquemas.Size = New System.Drawing.Size(222, 14)
        '
        'FlexGridEsquemas
        '
        Me.FlexGridEsquemas.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridEsquemas.AllowEditing = False
        Me.FlexGridEsquemas.AutoResize = True
        Me.FlexGridEsquemas.AutoSearchDelay = 1
        Me.FlexGridEsquemas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridEsquemas.Clip = ""
        Me.FlexGridEsquemas.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridEsquemas.Col = 1
        Me.FlexGridEsquemas.ColSel = 1
        Me.FlexGridEsquemas.ComboList = Nothing
        Me.FlexGridEsquemas.EditMask = Nothing
        Me.FlexGridEsquemas.ExtendLastCol = False
        Me.FlexGridEsquemas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGridEsquemas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridEsquemas.LeftCol = 1
        Me.FlexGridEsquemas.Location = New System.Drawing.Point(6, 23)
        Me.FlexGridEsquemas.Name = "FlexGridEsquemas"
        Me.FlexGridEsquemas.Redraw = True
        Me.FlexGridEsquemas.Row = 1
        Me.FlexGridEsquemas.RowSel = 1
        Me.FlexGridEsquemas.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridEsquemas.ScrollTrack = True
        Me.FlexGridEsquemas.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridEsquemas.ShowCursor = False
        Me.FlexGridEsquemas.ShowSort = True
        Me.FlexGridEsquemas.Size = New System.Drawing.Size(223, 176)
        Me.FlexGridEsquemas.StyleInfo = resources.GetString("FlexGridEsquemas.StyleInfo")
        Me.FlexGridEsquemas.SupportInfo = "5wDOADsBqAAIAZsBKAEEAa8AfQA2AY0AZAGbAMIAhAByAAsBHAHOADkBWgFiAJ4A8QDgAIgAmQAYAfQAb" & _
            "wC8AJUAtQDVAA=="
        Me.FlexGridEsquemas.TabIndex = 1
        Me.FlexGridEsquemas.Text = "C1FlexGrid1"
        Me.FlexGridEsquemas.TopRow = 1
        '
        'lbEsquemas
        '
        Me.lbEsquemas.Location = New System.Drawing.Point(7, 5)
        Me.lbEsquemas.Name = "lbEsquemas"
        Me.lbEsquemas.Size = New System.Drawing.Size(226, 18)
        Me.lbEsquemas.Text = "lbEsquemas"
        '
        'TabPageProducto
        '
        Me.TabPageProducto.Controls.Add(Me.lbPorcentaje2)
        Me.TabPageProducto.Controls.Add(Me.pbProducto)
        Me.TabPageProducto.Controls.Add(Me.btRegresarProductos)
        Me.TabPageProducto.Controls.Add(Me.btContinuarProductos)
        Me.TabPageProducto.Controls.Add(Me.FlexGridProductos)
        Me.TabPageProducto.Controls.Add(Me.lbProducto)
        Me.TabPageProducto.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProducto.Name = "TabPageProducto"
        Me.TabPageProducto.Size = New System.Drawing.Size(232, 263)
        Me.TabPageProducto.Text = "TabPageProducto"
        '
        'lbPorcentaje2
        '
        Me.lbPorcentaje2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbPorcentaje2.Location = New System.Drawing.Point(3, 201)
        Me.lbPorcentaje2.Name = "lbPorcentaje2"
        Me.lbPorcentaje2.Size = New System.Drawing.Size(226, 12)
        Me.lbPorcentaje2.Text = "lbPorcentaje2"
        '
        'pbProducto
        '
        Me.pbProducto.Location = New System.Drawing.Point(7, 219)
        Me.pbProducto.Name = "pbProducto"
        Me.pbProducto.Size = New System.Drawing.Size(226, 15)
        '
        'btRegresarProductos
        '
        Me.btRegresarProductos.Location = New System.Drawing.Point(87, 238)
        Me.btRegresarProductos.Name = "btRegresarProductos"
        Me.btRegresarProductos.Size = New System.Drawing.Size(74, 24)
        Me.btRegresarProductos.TabIndex = 4
        Me.btRegresarProductos.Text = "btRegresarProductos"
        '
        'btContinuarProductos
        '
        Me.btContinuarProductos.Location = New System.Drawing.Point(7, 238)
        Me.btContinuarProductos.Name = "btContinuarProductos"
        Me.btContinuarProductos.Size = New System.Drawing.Size(74, 24)
        Me.btContinuarProductos.TabIndex = 3
        Me.btContinuarProductos.Text = "btContinuarProductos"
        '
        'FlexGridProductos
        '
        Me.FlexGridProductos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridProductos.AllowEditing = False
        Me.FlexGridProductos.AutoResize = True
        Me.FlexGridProductos.AutoSearchDelay = 1
        Me.FlexGridProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridProductos.Clip = ""
        Me.FlexGridProductos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridProductos.Col = 1
        Me.FlexGridProductos.ColSel = 1
        Me.FlexGridProductos.ComboList = Nothing
        Me.FlexGridProductos.EditMask = Nothing
        Me.FlexGridProductos.ExtendLastCol = False
        Me.FlexGridProductos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGridProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridProductos.LeftCol = 1
        Me.FlexGridProductos.Location = New System.Drawing.Point(7, 23)
        Me.FlexGridProductos.Name = "FlexGridProductos"
        Me.FlexGridProductos.Redraw = True
        Me.FlexGridProductos.Row = 1
        Me.FlexGridProductos.RowSel = 1
        Me.FlexGridProductos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridProductos.ScrollTrack = True
        Me.FlexGridProductos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridProductos.ShowCursor = False
        Me.FlexGridProductos.ShowSort = True
        Me.FlexGridProductos.Size = New System.Drawing.Size(222, 173)
        Me.FlexGridProductos.StyleInfo = resources.GetString("FlexGridProductos.StyleInfo")
        Me.FlexGridProductos.SupportInfo = "HQHjAK0B/wC1ACcBNQH6AG8AQwEdAR8BLQHfANMAhQCjAEsB3gBVAXwA9wDIAIUAawDrAMYAlQDLAIUA9" & _
            "wAvAYIA3QCcAE0A"
        Me.FlexGridProductos.TabIndex = 2
        Me.FlexGridProductos.Text = "C1FlexGrid1"
        Me.FlexGridProductos.TopRow = 1
        '
        'lbProducto
        '
        Me.lbProducto.Location = New System.Drawing.Point(7, 5)
        Me.lbProducto.Name = "lbProducto"
        Me.lbProducto.Size = New System.Drawing.Size(226, 18)
        Me.lbProducto.Text = "lbProducto"
        '
        'TabPageClientes
        '
        Me.TabPageClientes.Controls.Add(Me.lbPorcentaje3)
        Me.TabPageClientes.Controls.Add(Me.FlexGridClientes)
        Me.TabPageClientes.Controls.Add(Me.pbClientes)
        Me.TabPageClientes.Controls.Add(Me.btRegresarClientes)
        Me.TabPageClientes.Controls.Add(Me.btContinuarClientes)
        Me.TabPageClientes.Controls.Add(Me.lbClientes)
        Me.TabPageClientes.Location = New System.Drawing.Point(4, 25)
        Me.TabPageClientes.Name = "TabPageClientes"
        Me.TabPageClientes.Size = New System.Drawing.Size(232, 263)
        Me.TabPageClientes.Text = "TabPageClientes"
        '
        'lbPorcentaje3
        '
        Me.lbPorcentaje3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbPorcentaje3.Location = New System.Drawing.Point(7, 200)
        Me.lbPorcentaje3.Name = "lbPorcentaje3"
        Me.lbPorcentaje3.Size = New System.Drawing.Size(226, 18)
        Me.lbPorcentaje3.Text = "lbPorcentaje3"
        '
        'FlexGridClientes
        '
        Me.FlexGridClientes.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridClientes.AllowEditing = False
        Me.FlexGridClientes.AutoResize = True
        Me.FlexGridClientes.AutoSearchDelay = 1
        Me.FlexGridClientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridClientes.Clip = ""
        Me.FlexGridClientes.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridClientes.Col = 1
        Me.FlexGridClientes.ColSel = 1
        Me.FlexGridClientes.ComboList = Nothing
        Me.FlexGridClientes.EditMask = Nothing
        Me.FlexGridClientes.ExtendLastCol = False
        Me.FlexGridClientes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGridClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridClientes.LeftCol = 1
        Me.FlexGridClientes.Location = New System.Drawing.Point(7, 23)
        Me.FlexGridClientes.Name = "FlexGridClientes"
        Me.FlexGridClientes.Redraw = True
        Me.FlexGridClientes.Row = 1
        Me.FlexGridClientes.RowSel = 1
        Me.FlexGridClientes.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridClientes.ScrollTrack = True
        Me.FlexGridClientes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridClientes.ShowCursor = False
        Me.FlexGridClientes.ShowSort = True
        Me.FlexGridClientes.Size = New System.Drawing.Size(226, 172)
        Me.FlexGridClientes.StyleInfo = resources.GetString("FlexGridClientes.StyleInfo")
        Me.FlexGridClientes.SupportInfo = "wQCbAR8BcAFTABMBcgDnAFIB6wA7AccAoADJAMsAsADmADIBaQG9AAIBQQFaAKkABAHmAFYAowChADEBo" & _
            "wAUAf4AewC6AA=="
        Me.FlexGridClientes.TabIndex = 6
        Me.FlexGridClientes.Text = "C1FlexGrid2"
        Me.FlexGridClientes.TopRow = 1
        '
        'pbClientes
        '
        Me.pbClientes.Location = New System.Drawing.Point(7, 219)
        Me.pbClientes.Name = "pbClientes"
        Me.pbClientes.Size = New System.Drawing.Size(226, 15)
        '
        'btRegresarClientes
        '
        Me.btRegresarClientes.Location = New System.Drawing.Point(87, 238)
        Me.btRegresarClientes.Name = "btRegresarClientes"
        Me.btRegresarClientes.Size = New System.Drawing.Size(74, 24)
        Me.btRegresarClientes.TabIndex = 3
        Me.btRegresarClientes.Text = "btRegresarClientes"
        '
        'btContinuarClientes
        '
        Me.btContinuarClientes.Location = New System.Drawing.Point(7, 238)
        Me.btContinuarClientes.Name = "btContinuarClientes"
        Me.btContinuarClientes.Size = New System.Drawing.Size(74, 24)
        Me.btContinuarClientes.TabIndex = 2
        Me.btContinuarClientes.Text = "btContinuarClientes"
        '
        'lbClientes
        '
        Me.lbClientes.Location = New System.Drawing.Point(7, 5)
        Me.lbClientes.Name = "lbClientes"
        Me.lbClientes.Size = New System.Drawing.Size(226, 18)
        Me.lbClientes.Text = "lbClientes"
        '
        'TabPageVendedor
        '
        Me.TabPageVendedor.Controls.Add(Me.lbPorcentaje4)
        Me.TabPageVendedor.Controls.Add(Me.FlexGridVendedor)
        Me.TabPageVendedor.Controls.Add(Me.pbVendedor)
        Me.TabPageVendedor.Controls.Add(Me.btRegresarVendedor)
        Me.TabPageVendedor.Controls.Add(Me.btContinuarVendedor)
        Me.TabPageVendedor.Controls.Add(Me.lbVendedor)
        Me.TabPageVendedor.Location = New System.Drawing.Point(4, 25)
        Me.TabPageVendedor.Name = "TabPageVendedor"
        Me.TabPageVendedor.Size = New System.Drawing.Size(232, 263)
        Me.TabPageVendedor.Text = "TabPageVendedor"
        '
        'lbPorcentaje4
        '
        Me.lbPorcentaje4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbPorcentaje4.Location = New System.Drawing.Point(5, 200)
        Me.lbPorcentaje4.Name = "lbPorcentaje4"
        Me.lbPorcentaje4.Size = New System.Drawing.Size(224, 18)
        Me.lbPorcentaje4.Text = "lbPorcentaje4"
        '
        'FlexGridVendedor
        '
        Me.FlexGridVendedor.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridVendedor.AllowEditing = False
        Me.FlexGridVendedor.AutoResize = True
        Me.FlexGridVendedor.AutoSearchDelay = 1
        Me.FlexGridVendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridVendedor.Clip = ""
        Me.FlexGridVendedor.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridVendedor.Col = 1
        Me.FlexGridVendedor.ColSel = 1
        Me.FlexGridVendedor.ComboList = Nothing
        Me.FlexGridVendedor.EditMask = Nothing
        Me.FlexGridVendedor.ExtendLastCol = False
        Me.FlexGridVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGridVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridVendedor.LeftCol = 1
        Me.FlexGridVendedor.Location = New System.Drawing.Point(7, 23)
        Me.FlexGridVendedor.Name = "FlexGridVendedor"
        Me.FlexGridVendedor.Redraw = True
        Me.FlexGridVendedor.Row = 1
        Me.FlexGridVendedor.RowSel = 1
        Me.FlexGridVendedor.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridVendedor.ScrollTrack = True
        Me.FlexGridVendedor.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridVendedor.ShowCursor = False
        Me.FlexGridVendedor.ShowSort = True
        Me.FlexGridVendedor.Size = New System.Drawing.Size(226, 169)
        Me.FlexGridVendedor.StyleInfo = resources.GetString("FlexGridVendedor.StyleInfo")
        Me.FlexGridVendedor.SupportInfo = "3gBWASUBNwHCAKsBewDFAA4B+wCbAG8BEwFjAXYAVgF4APUAQgFoAPEANAFCAD8AhACmAKoABgF5ADwAT" & _
            "QDxAMkAHgGfAA=="
        Me.FlexGridVendedor.TabIndex = 6
        Me.FlexGridVendedor.Text = "C1FlexGrid3"
        Me.FlexGridVendedor.TopRow = 1
        '
        'pbVendedor
        '
        Me.pbVendedor.Location = New System.Drawing.Point(7, 219)
        Me.pbVendedor.Name = "pbVendedor"
        Me.pbVendedor.Size = New System.Drawing.Size(226, 15)
        '
        'btRegresarVendedor
        '
        Me.btRegresarVendedor.Location = New System.Drawing.Point(87, 238)
        Me.btRegresarVendedor.Name = "btRegresarVendedor"
        Me.btRegresarVendedor.Size = New System.Drawing.Size(74, 24)
        Me.btRegresarVendedor.TabIndex = 3
        Me.btRegresarVendedor.Text = "btRegresarVendedor"
        '
        'btContinuarVendedor
        '
        Me.btContinuarVendedor.Location = New System.Drawing.Point(7, 238)
        Me.btContinuarVendedor.Name = "btContinuarVendedor"
        Me.btContinuarVendedor.Size = New System.Drawing.Size(74, 24)
        Me.btContinuarVendedor.TabIndex = 2
        Me.btContinuarVendedor.Text = "btContinuarVendedor"
        '
        'lbVendedor
        '
        Me.lbVendedor.Location = New System.Drawing.Point(7, 5)
        Me.lbVendedor.Name = "lbVendedor"
        Me.lbVendedor.Size = New System.Drawing.Size(226, 18)
        Me.lbVendedor.Text = "lbVendedor"
        '
        'FormCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenu1
        Me.Name = "FormCuotas"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlCuotas.ResumeLayout(False)
        Me.TabPageEsquemas.ResumeLayout(False)
        Me.TabPageProducto.ResumeLayout(False)
        Me.TabPageClientes.ResumeLayout(False)
        Me.TabPageVendedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlCuotas As System.Windows.Forms.TabControl
    Friend WithEvents TabPageEsquemas As System.Windows.Forms.TabPage
    Friend WithEvents lbPorcentaje1 As System.Windows.Forms.Label
    Friend WithEvents btRegresarEsquemas As System.Windows.Forms.Button
    Friend WithEvents btContinuarEsquemas As System.Windows.Forms.Button
    Friend WithEvents pbEsquemas As System.Windows.Forms.ProgressBar
    Friend WithEvents FlexGridEsquemas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbEsquemas As System.Windows.Forms.Label
    Friend WithEvents TabPageProducto As System.Windows.Forms.TabPage
    Friend WithEvents lbPorcentaje2 As System.Windows.Forms.Label
    Friend WithEvents pbProducto As System.Windows.Forms.ProgressBar
    Friend WithEvents btRegresarProductos As System.Windows.Forms.Button
    Friend WithEvents btContinuarProductos As System.Windows.Forms.Button
    Friend WithEvents FlexGridProductos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbProducto As System.Windows.Forms.Label
    Friend WithEvents TabPageClientes As System.Windows.Forms.TabPage
    Friend WithEvents lbPorcentaje3 As System.Windows.Forms.Label
    Friend WithEvents FlexGridClientes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pbClientes As System.Windows.Forms.ProgressBar
    Friend WithEvents btRegresarClientes As System.Windows.Forms.Button
    Friend WithEvents btContinuarClientes As System.Windows.Forms.Button
    Friend WithEvents lbClientes As System.Windows.Forms.Label
    Friend WithEvents TabPageVendedor As System.Windows.Forms.TabPage
    Friend WithEvents lbPorcentaje4 As System.Windows.Forms.Label
    Friend WithEvents FlexGridVendedor As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pbVendedor As System.Windows.Forms.ProgressBar
    Friend WithEvents btRegresarVendedor As System.Windows.Forms.Button
    Friend WithEvents btContinuarVendedor As System.Windows.Forms.Button
    Friend WithEvents lbVendedor As System.Windows.Forms.Label
End Class
