Public Class FrmAddProdConteo
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
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnImagen As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents btnClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents ChkLimitar As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddProdConteo))
        Me.GrpProductos = New System.Windows.Forms.GroupBox()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpClas = New System.Windows.Forms.GroupBox()
        Me.cmbGrupo = New Selling.StoreCombo()
        Me.TreeViewClass = New System.Windows.Forms.TreeView()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.BtnImagen = New Janus.Windows.EditControls.UIButton()
        Me.ChkLimitar = New System.Windows.Forms.CheckBox()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpProductos.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpClas.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpProductos.Controls.Add(Me.ChkTodos)
        Me.GrpProductos.Controls.Add(Me.Label5)
        Me.GrpProductos.Controls.Add(Me.btnClasificacion)
        Me.GrpProductos.Controls.Add(Me.picKeyboard)
        Me.GrpProductos.Controls.Add(Me.Label1)
        Me.GrpProductos.Controls.Add(Me.TxtMaxHits)
        Me.GrpProductos.Controls.Add(Me.GrpClas)
        Me.GrpProductos.Controls.Add(Me.BtnCancelar)
        Me.GrpProductos.Controls.Add(Me.BtnAgregar)
        Me.GrpProductos.Controls.Add(Me.BtnUbicacion)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Controls.Add(Me.BtnImagen)
        Me.GrpProductos.Controls.Add(Me.ChkLimitar)
        Me.GrpProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpProductos.ForeColor = System.Drawing.Color.Black
        Me.GrpProductos.Location = New System.Drawing.Point(7, 2)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(821, 554)
        Me.GrpProductos.TabIndex = 0
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(9, 50)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(142, 22)
        Me.ChkTodos.TabIndex = 129
        Me.ChkTodos.Text = "Seleccionar Todo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Busqueda"
        '
        'btnClasificacion
        '
        Me.btnClasificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClasificacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClasificacion.Icon = CType(resources.GetObject("btnClasificacion.Icon"), System.Drawing.Icon)
        Me.btnClasificacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnClasificacion.Location = New System.Drawing.Point(601, 44)
        Me.btnClasificacion.Name = "btnClasificacion"
        Me.btnClasificacion.Size = New System.Drawing.Size(65, 28)
        Me.btnClasificacion.TabIndex = 93
        Me.btnClasificacion.ToolTipText = "Mostrar Clasificaciones"
        Me.btnClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(577, 10)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 33)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 13
        Me.picKeyboard.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(627, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(759, 15)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 22)
        Me.TxtMaxHits.TabIndex = 84
        Me.TxtMaxHits.Text = "10,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 10000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(9, 78)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(220, 434)
        Me.GrpClas.TabIndex = 14
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        Me.GrpClas.Visible = False
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(7, 17)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(207, 24)
        Me.cmbGrupo.TabIndex = 8
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 44)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(207, 383)
        Me.TreeViewClass.TabIndex = 0
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(570, 520)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(119, 28)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(697, 520)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(119, 28)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega el producto al conteo actual"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnUbicacion
        '
        Me.BtnUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUbicacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUbicacion.Icon = CType(resources.GetObject("BtnUbicacion.Icon"), System.Drawing.Icon)
        Me.BtnUbicacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnUbicacion.Location = New System.Drawing.Point(750, 44)
        Me.BtnUbicacion.Name = "BtnUbicacion"
        Me.BtnUbicacion.Size = New System.Drawing.Size(65, 28)
        Me.BtnUbicacion.TabIndex = 7
        Me.BtnUbicacion.Text = "F3 "
        Me.BtnUbicacion.ToolTipText = "Muestra la localización del producto"
        Me.BtnUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(82, 15)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(366, 22)
        Me.TxtBuscar.TabIndex = 1
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.CardViewGridlines = Janus.Windows.GridEX.CardViewGridlines.Vertical
        Me.GridProductos.CardWidth = 726
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(9, 78)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(807, 436)
        Me.GridProductos.TabIndex = 3
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnImagen
        '
        Me.BtnImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImagen.Icon = CType(resources.GetObject("BtnImagen.Icon"), System.Drawing.Icon)
        Me.BtnImagen.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnImagen.Location = New System.Drawing.Point(676, 44)
        Me.BtnImagen.Name = "BtnImagen"
        Me.BtnImagen.Size = New System.Drawing.Size(65, 28)
        Me.BtnImagen.TabIndex = 3
        Me.BtnImagen.Text = "F2"
        Me.BtnImagen.ToolTipText = "Muestra la Imagen del Producto"
        Me.BtnImagen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkLimitar
        '
        Me.ChkLimitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkLimitar.Location = New System.Drawing.Point(454, 18)
        Me.ChkLimitar.Name = "ChkLimitar"
        Me.ChkLimitar.Size = New System.Drawing.Size(135, 19)
        Me.ChkLimitar.TabIndex = 96
        Me.ChkLimitar.Text = "Limitar a Clave"
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmAddProdConteo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(834, 561)
        Me.Controls.Add(Me.GrpProductos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmAddProdConteo"
        Me.Text = "Busqueda de Productos"
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpClas.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SUCClave As String
    Private ALMClave As String
    Private CONClave As String

    Private sProdSelected As String
    Private sClave As String
    Private sGTIN As String
    Private sImg As String
    Private Tipo As Integer = 1
    Private dataSetArbol As Data.DataSet
    Private bLoad As Boolean = False
    Private bClasLoad As Boolean = False
    Private bClasVisible As Boolean = False
    Private bError As Boolean = False

    Public TImpuesto As Integer = 1
    Public url_imagen As String
    Public Busqueda As String
    Public Padre As String = ""
    ' Private dt As DataTable
    Private dtProducto As DataTable


    Public bMessage As Boolean = True
    ' Private dataSetArbol As Data.DataSet


    Public Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 3, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACIÓN"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()
    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("Clasificacion"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("Clasificacion").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeViewClass.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent



    End Sub


    Private Sub actGrid(ByVal MaxHits As Integer, ByVal Tag As Integer, ByVal sBusqueda As String, ByVal sAlmacen As String)

        sBusqueda = sBusqueda.Replace("'", "")

        bLoad = False

        dtProducto = Recupera_Tabla("st_busca_ConteoProductos", "@Class", Tag, "@Max", MaxHits, "@Busqueda", sBusqueda, "@ALMClave", sAlmacen, "@COMClave", ModPOS.CompanyActual, "@Char", cReplace, "@Limitar", ChkLimitar.Checked, "@Servicio", 0)

        GridProductos.DataSource = dtProducto
        GridProductos.RetrieveStructure()
        Me.GridProductos.RootTable.Columns("Marca").Width = 20
        Me.GridProductos.RootTable.Columns("Clave").Width = 70
        Me.GridProductos.RootTable.Columns("Descripción").Width = 270
        Me.GridProductos.RootTable.Columns("Exist").Width = 20
        Me.GridProductos.RootTable.Columns("Apart").Width = 20
        Me.GridProductos.RootTable.Columns("Bloq").Width = 20

        Me.GridProductos.RootTable.Columns("Nombre").Width = 60
        Me.GridProductos.RootTable.Columns("ID").Visible = False

        Me.GridProductos.RootTable.Columns("Exist").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Apart").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Bloq").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


        bLoad = True



    End Sub


  
    Public WriteOnly Property Sucursal() As String
        Set(ByVal Value As String)
            SUCClave = Value
        End Set
    End Property
  

    Public WriteOnly Property Almacen() As String
        Set(ByVal Value As String)
            ALMClave = Value
        End Set
    End Property


    Public WriteOnly Property Conteo() As String
        Set(ByVal Value As String)
            CONClave = Value
        End Set
    End Property

    Private Sub GridProductos_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridProductos.CurrentCellChanged
        If Not GridProductos.CurrentColumn Is Nothing Then
            If GridProductos.CurrentColumn.Caption = "Marca" Then
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub FrmBusca_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bError Then
            e.Cancel = True
        End If




    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnAgregar.KeyUp, BtnCancelar.KeyUp, BtnImagen.KeyUp, BtnUbicacion.KeyUp, GridProductos.KeyUp, cmbGrupo.KeyUp, TreeViewClass.KeyUp, TxtMaxHits.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.BtnCancelar.PerformClick()
            Case Is = Keys.F2
                Me.BtnImagen.PerformClick()
            Case Is = Keys.F3
                Me.BtnUbicacion.PerformClick()
        End Select

    End Sub


    Private Sub FrmBuscaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim frmstatusmessage As frmStatus = Nothing

        If bMessage = True Then
            frmstatusmessage = New frmStatus
            frmstatusmessage.Show("Estamos haciendo magia...")
        End If

        Me.StartPosition = FormStartPosition.CenterScreen



        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "3"
            .llenar()
        End With

        If bMessage = True Then
            frmstatusmessage.Close()
        End If

        bLoad = True
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If GridProductos.RowCount > 0 AndAlso Not GridProductos.GetValue(0) Is Nothing Then
            BtnImagen.Enabled = True
            BtnAgregar.Enabled = True
            BtnUbicacion.Enabled = True

            sProdSelected = GridProductos.GetValue("ID")
            sClave = GridProductos.GetValue("Clave")


        Else
            Me.sProdSelected = ""
            sClave = ""
            Me.BtnImagen.Enabled = False
            Me.BtnAgregar.Enabled = False
            Me.BtnUbicacion.Enabled = False
        End If
    End Sub

    Private Sub BtnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagen.Click
        If sProdSelected <> "" Then
            Dim a As FrmPicture = New FrmPicture
            a.url_imagen = Me.url_imagen
            a.ClaveProducto = GridProductos.GetValue("Clave")
            a.NombreProducto = GridProductos.GetValue("Descripción")
            a.PROClave = sProdSelected
            a.btnRemover.Visible = False
            a.btnAgregar.Visible = False
            a.BtnGuardar.Visible = False
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub BtnUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbicacion.Click
        If sProdSelected <> "" Then
            Dim a As New FrmConsultaGen
            a.Text = "Localización dentro del Almacén"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_ubcproducto", "@PROClave", sProdSelected, "@ALMClave", ALMClave)

            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

  


 
    Private Sub picKeyboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        Process.Start("osk.exe")
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bLoad = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

    Private Sub TreeViewClass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeViewClass.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not TreeViewClass.SelectedNode.Tag Is Nothing Then
            actGrid(CInt(TxtMaxHits.Text), TreeViewClass.SelectedNode.Tag, TxtBuscar.Text, ALMClave)
        End If
    End Sub

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            actGrid(CInt(TxtMaxHits.Text), e.Node.Tag, TxtBuscar.Text, ALMClave)
        End If
    End Sub


    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Clock.Stop()

        If TxtBuscar.Text <> "" Then
            Me.actGrid(CInt(TxtMaxHits.Text), 0, TxtBuscar.Text, ALMClave)
        End If

    End Sub

    Private Sub btnClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClasificacion.Click
        If bClasVisible = True Then
            'Oculta GrpClass
            bClasVisible = False
            GrpClas.Visible = bClasVisible
            GridProductos.Location = New Point(9, 78)
            GridProductos.Width += 226

        Else
            'Muestra GrpClass
            bClasVisible = True
            GrpClas.Visible = bClasVisible
            GridProductos.Location = New Point(233, 78)
            GridProductos.Width -= 226
            If bClasLoad = False Then
                actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))
                Me.actGrid(CInt(TxtMaxHits.Text), TreeViewClass.TopNode.Tag, TxtBuscar.Text, ALMClave)
                bClasLoad = True
            End If
        End If
    End Sub

    Private Sub TxtMaxHits_Leave(sender As Object, e As EventArgs) Handles TxtMaxHits.Leave
        If TxtBuscar.Text <> "" Then
            Me.actGrid(CInt(TxtMaxHits.Text), 0, TxtBuscar.Text, ALMClave)
        End If
    End Sub



   
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If Not dtProducto Is Nothing Then
            Dim foundRows() As DataRow
            Dim z As Integer
            foundRows = dtProducto.Select("Marca=True")

            If foundRows.GetLength(0) > 0 Then
                Dim frmstatusmessage As frmStatus = Nothing
                frmstatusmessage = New frmStatus

                Dim fin As String = Str(foundRows.GetUpperBound(0) + 1)

                For z = 0 To foundRows.GetUpperBound(0)
                    frmstatusmessage.Show("Estamos haciendo magia..." & Str(z + 1) & "/" & fin)
                    ModPOS.Ejecuta("sp_actualiza_conteo_config", "@CONClave", CONClave, "@PROClave", foundRows(z)("ID"), "@Usuario", ModPOS.UsuarioActual)
                Next
                frmstatusmessage.Close()
            End If
        End If


    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtProducto.Rows.Count > 0 Then

            Dim frmstatusmessage As frmStatus = Nothing
            frmstatusmessage = New frmStatus

            Dim fin As String = Str(GridProductos.GetDataRows.Length)

            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    frmstatusmessage.Show("Estamos haciendo magia..." & Str(i + 1) & "/" & fin)

                    GridProductos.GetDataRows(i).DataRow("Marca") = 1
                Next
            Else
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    frmstatusmessage.Show("Estamos haciendo magia..." & Str(i + 1) & "/" & fin)

                    GridProductos.GetDataRows(i).DataRow("Marca") = 0
                Next
            End If
            frmstatusmessage.Close()

            dtProducto.AcceptChanges()

            GridProductos.Refresh()
        End If
    End Sub
End Class
