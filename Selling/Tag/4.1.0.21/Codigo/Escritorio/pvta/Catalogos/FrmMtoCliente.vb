Public Class FrmMtoCliente
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
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents GrpClientes As System.Windows.Forms.GroupBox
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cmbResponsable As Selling.StoreCombo
    Friend WithEvents BtnListado As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents GridClientes As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoCliente))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.cmbGrupo = New Selling.StoreCombo
        Me.cmbResponsable = New Selling.StoreCombo
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpClientes = New System.Windows.Forms.GroupBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridClientes = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.BtnListado = New Janus.Windows.EditControls.UIButton
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpClas.SuspendLayout()
        Me.GrpClientes.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.cmbResponsable)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 0)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(200, 422)
        Me.GrpClas.TabIndex = 0
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(8, 40)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(185, 21)
        Me.cmbGrupo.TabIndex = 38
        '
        'cmbResponsable
        '
        Me.cmbResponsable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbResponsable.BackColor = System.Drawing.SystemColors.Window
        Me.cmbResponsable.Location = New System.Drawing.Point(8, 15)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(185, 21)
        Me.cmbResponsable.TabIndex = 37
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 64)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(185, 351)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpClientes
        '
        Me.GrpClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClientes.Controls.Add(Me.CmbCampo)
        Me.GrpClientes.Controls.Add(Me.TxtBuscar)
        Me.GrpClientes.Controls.Add(Me.GridClientes)
        Me.GrpClientes.Location = New System.Drawing.Point(207, 0)
        Me.GrpClientes.Name = "GrpClientes"
        Me.GrpClientes.Size = New System.Drawing.Size(531, 422)
        Me.GrpClientes.TabIndex = 1
        Me.GrpClientes.TabStop = False
        Me.GrpClientes.Text = "Clientes"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 14)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 9
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(173, 14)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(352, 20)
        Me.TxtBuscar.TabIndex = 8
        '
        'GridClientes
        '
        Me.GridClientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClientes.ColumnAutoResize = True
        Me.GridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClientes.Location = New System.Drawing.Point(7, 37)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.RecordNavigator = True
        Me.GridClientes.Size = New System.Drawing.Size(518, 378)
        Me.GridClientes.TabIndex = 2
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(160, 428)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(544, 428)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar cliente seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(256, 428)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar cliente seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(640, 428)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nuevo cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(448, 428)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 10
        Me.BtnReimpresion.Text = "&Edo. Cuenta"
        Me.BtnReimpresion.ToolTipText = "Impresión de Edo. Cta del cliente seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnListado
        '
        Me.BtnListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnListado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnListado.Image = CType(resources.GetObject("BtnListado.Image"), System.Drawing.Image)
        Me.BtnListado.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnListado.Location = New System.Drawing.Point(352, 428)
        Me.BtnListado.Name = "BtnListado"
        Me.BtnListado.Size = New System.Drawing.Size(90, 37)
        Me.BtnListado.TabIndex = 11
        Me.BtnListado.Text = "&Listado"
        Me.BtnListado.ToolTipText = "Impresión de Listado de Clientes"
        Me.BtnListado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmMtoCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.BtnListado)
        Me.Controls.Add(Me.BtnReimpresion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpClientes)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoCliente"
        Me.Text = "Mantenimiento de Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpClas.ResumeLayout(False)
        Me.GrpClientes.ResumeLayout(False)
        Me.GrpClientes.PerformLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public iResponsable As Integer

    Private sCteSelected As String
    Private sNombre As String
    Private dSaldo As Double

    Private bload As Boolean = False
    Private dataSetArbol As Data.DataSet

    Public Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 1, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
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

    Private Sub FrmMtoCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        With cmbResponsable
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Responsable"
            .llenar()
        End With

        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "1"
            .llenar()
        End With

        actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))


        If cmbResponsable.SelectedValue Is Nothing Then
            MessageBox.Show("No se encontro alguna sucursal seleccionada o no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            iResponsable = ""
        Else
            iResponsable = cmbResponsable.SelectedValue
        End If

        ModPOS.ActualizaGrid(True, Me.GridClientes, "sp_muestra_clientes", "@Class", TreeViewClass.TopNode.Tag, "@Responsable", iResponsable, "@COMClave", ModPOS.CompanyActual)
        Me.GridClientes.RootTable.Columns("ID").Visible = False
        Cursor.Current = Cursors.Default

        bload = True

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoCliente.Dispose()
        ModPOS.MtoCliente = Nothing
    End Sub

    Private Sub GridClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridClientes_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClientes.SelectionChanged
        If Not GridClientes.GetValue(0) Is Nothing Then

            Me.BtnModificar.Enabled = True
            Me.sCteSelected = GridClientes.GetValue(0)
            Me.sNombre = GridClientes.GetValue(1)
            Me.dSaldo = GridClientes.GetValue("Saldo")

            If sCteSelected = GridClientes.GetValue("Clave") Then
                Me.BtnEliminar.Enabled = False
            Else
                Me.BtnEliminar.Enabled = True
            End If
        Else

            Me.sCteSelected = ""
            Me.dSaldo = 0
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Agregar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
    End Sub

    Public Sub modificarCte()
        If sCteSelected <> "" Then
            If ModPOS.Cliente Is Nothing Then
                ModPOS.Cliente = New FrmCliente
                With ModPOS.Cliente
                    .Text = "Modificar Cliente"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", Me.sCteSelected)
                    .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                    .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
                    .CTEClave = dt.Rows(0)("CTEClave")
                    .TPersona = dt.Rows(0)("TPersona")
                    .Clave = dt.Rows(0)("Clave")
                    .NombreCorto = dt.Rows(0)("NombreCorto")
                    .RazonSocial = dt.Rows(0)("RazonSocial")
                    .RFC = dt.Rows(0)("id_Fiscal")
                    .CURP = dt.Rows(0)("CURP")
                    .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                    .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                    .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                    .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                    .FechaReg = dt.Rows(0)("FechaRegistro")
                    .Estado = dt.Rows(0)("Estado")
                    .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                    .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                    .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                    .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                    .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))
                    .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))
                  
                    .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                    .LCredito = dt.Rows(0)("LimiteCredito")
                    .DiasCredito = dt.Rows(0)("DiasCredito")

                    .PaisF = dt.Rows(0)("Pais")
                    .EntidadF = dt.Rows(0)("Entidad")
                    .MnpioF = dt.Rows(0)("Municipio")
                    .ColoniaF = dt.Rows(0)("Colonia")
                    .CalleF = dt.Rows(0)("Calle")
                    .LocalidadF = dt.Rows(0)("Localidad")
                    .referenciaF = dt.Rows(0)("referencia")
                    .noExteriorF = dt.Rows(0)("noExterior")
                    .noInteriorF = dt.Rows(0)("noInterior")
                    .codigoPostalF = dt.Rows(0)("codigoPostal")
                    .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                    .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                    .Contacto = dt.Rows(0)("Contacto")
                    .Tel1 = dt.Rows(0)("Tel1")
                    .Tel2 = dt.Rows(0)("Tel2")
                    .email = dt.Rows(0)("Email")

                    .Saldo = dt.Rows(0)("Saldo")
                    .CreditoDisponible = dt.Rows(0)("Disponible")

                    .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                    .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                    .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                    .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                    .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                    .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))
                    .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                    .Password = IIf(dt.Rows(0)("Password").GetType.Name = "DBNull", "", dt.Rows(0)("Password"))
                    .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarCte()

    End Sub

    Private Sub GridProductos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClientes.DoubleClick
        modificarCte()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sCteSelected <> "" Then
            If dSaldo = 0 Then
                Beep()
                Select Case MessageBox.Show("Se eliminara el Cliente :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes

                        ModPOS.Ejecuta("sp_elimina_cte", "@CTEClave", sCteSelected, "@Usuario", ModPOS.UsuarioActual)

                        If Not TreeViewClass.SelectedNode.Tag Is Nothing Then

                            If cmbResponsable.SelectedValue Is Nothing Then
                                MessageBox.Show("No se encontro alguna sucursal seleccionada o no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                iResponsable = 0
                            Else
                                iResponsable = cmbResponsable.SelectedValue
                            End If

                            ModPOS.ActualizaGrid(True, Me.GridClientes, "sp_muestra_clientes", "@Class", TreeViewClass.SelectedNode.Tag, "@Responsable", iResponsable, "@COMClave", ModPOS.CompanyActual)
                            Me.GridClientes.RootTable.Columns("ID").Visible = False

                        End If
                    Case DialogResult.No

                End Select
            Else
                MessageBox.Show("No es posible eliminar el cliente selecionado ya que cuenta con saldo pendiente de cobro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sCteSelected <> "" Then

            Dim a As New MeFiltro
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edocta_enc", "@CTEClave", Me.sCteSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edocta_detalle", "@CTEClave", Me.sCteSelected, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                OpenReport.PrintPreview("Reporte de Estado de Cuenta del Cliente", "CREdoCte.rpt", pvtaDataSet, "")
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado un Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbResponsable.SelectedValueChanged
        If bload = True AndAlso Not cmbResponsable.SelectedValue Is Nothing Then
            ModPOS.ActualizaGrid(True, Me.GridClientes, "sp_muestra_clientes", "@Class", TreeViewClass.TopNode.Tag, "@Responsable", cmbResponsable.SelectedValue, "@COMClave", ModPOS.CompanyActual)
            Me.GridClientes.RootTable.Columns("ID").Visible = False
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Public Sub actGrid(ByVal tag As String)

        If cmbResponsable.SelectedValue Is Nothing Then
            MessageBox.Show("No se encontro alguna sucursal seleccionada o no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            iResponsable = ""
        Else
            iResponsable = cmbResponsable.SelectedValue
        End If

        ModPOS.ActualizaGrid(True, Me.GridClientes, "sp_muestra_clientes", "@Class", tag, "@Responsable", iResponsable, "@COMClave", ModPOS.CompanyActual)
        Me.GridClientes.RootTable.Columns("ID").Visible = False

    End Sub



    Private Sub TreeViewClass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeViewClass.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not TreeViewClass.SelectedNode.Tag Is Nothing Then
            actGrid(TreeViewClass.SelectedNode.Tag)
        End If
    End Sub



    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            actGrid(e.Node.Tag)
        End If
    End Sub

    Private Sub BtnListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListado.Click
        Dim a As New FiltroCliente
        a.Titulo = "Listado de Clientes"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "reportDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_listadocliente", "@Zona", a.Zona, "@Responsable", a.SucursalOrigen, "@Vendedor", a.Vendedor))
            OpenReport.PrintPreview("Reporte de Listado de Clientes", "CRListadoCte.rpt", pvtaDataSet, "")
        End If
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bload = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Clock.Stop()
        If Not CmbCampo.SelectedValue Is Nothing AndAlso Not cmbResponsable.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                ModPOS.ActualizaGrid(True, Me.GridClientes, "sp_busca_clientes", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                Me.GridClientes.RootTable.Columns("ID").Visible = False
            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
End Class
