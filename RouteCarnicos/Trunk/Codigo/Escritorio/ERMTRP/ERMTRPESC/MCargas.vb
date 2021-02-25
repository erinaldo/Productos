Imports BASMENLOG
Imports ERMTRPLOG
Imports lbGeneral

Enum eModo
    Crear
    Modificar
    Leer
    Cancelar
End Enum

Public Enum TipoTRP
    Carga = 2
    Reclasificado = 22
    Sobrante = 25
End Enum

Public Class MCargas
    Inherits FormasBase.Mantenimiento01

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
    Friend WithEvents lbFolio As System.Windows.Forms.Label
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbTipoFase As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbTipoFase As System.Windows.Forms.Label
    Friend WithEvents gbTransProdDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grTransProdDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbDiaClave As System.Windows.Forms.Label
    Friend WithEvents cbAlmacen As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbAlmacen As System.Windows.Forms.Label
    Friend WithEvents lbVendedor As System.Windows.Forms.Label
    Friend WithEvents ebVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btBuscarVendedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbPCEModuloMovDetClave As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbPCEModuloMovDetClave As System.Windows.Forms.Label
    Friend WithEvents btTPDCrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btTPDEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btTPDBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents ebDiaClave As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebUSUId As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MCargas))
        Dim grTransProdDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.lbFolio = New System.Windows.Forms.Label
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cbTipoFase = New Janus.Windows.EditControls.UIComboBox
        Me.lbTipoFase = New System.Windows.Forms.Label
        Me.lbDiaClave = New System.Windows.Forms.Label
        Me.cbAlmacen = New Janus.Windows.EditControls.UIComboBox
        Me.lbAlmacen = New System.Windows.Forms.Label
        Me.lbVendedor = New System.Windows.Forms.Label
        Me.ebVendedor = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btBuscarVendedor = New Janus.Windows.EditControls.UIButton
        Me.cbPCEModuloMovDetClave = New Janus.Windows.EditControls.UIComboBox
        Me.lbPCEModuloMovDetClave = New System.Windows.Forms.Label
        Me.gbTransProdDetalle = New Janus.Windows.EditControls.UIGroupBox
        Me.btTPDCrear = New Janus.Windows.EditControls.UIButton
        Me.btTPDEliminar = New Janus.Windows.EditControls.UIButton
        Me.btTPDBuscar = New Janus.Windows.EditControls.UIButton
        Me.grTransProdDetalle = New Janus.Windows.GridEX.GridEX
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ebDiaClave = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.ebUSUId = New Janus.Windows.GridEX.EditControls.EditBox
        CType(Me.gbTransProdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTransProdDetalle.SuspendLayout()
        CType(Me.grTransProdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Location = New System.Drawing.Point(32, 392)
        Me.EbClave.Size = New System.Drawing.Size(4, 20)
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(20, 392)
        Me.lbClave.Size = New System.Drawing.Size(4, 20)
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(548, 392)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(660, 392)
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(52, 404)
        Me.lbLinea.Size = New System.Drawing.Size(16, 3)
        Me.lbLinea.Visible = False
        '
        'lbFolio
        '
        Me.lbFolio.BackColor = System.Drawing.Color.Transparent
        Me.lbFolio.Location = New System.Drawing.Point(8, 12)
        Me.lbFolio.Name = "lbFolio"
        Me.lbFolio.Size = New System.Drawing.Size(132, 20)
        Me.lbFolio.TabIndex = 0
        Me.lbFolio.Text = "Folio"
        Me.lbFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebFolio
        '
        Me.ebFolio.Location = New System.Drawing.Point(144, 12)
        Me.ebFolio.MaxLength = 16
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(180, 20)
        Me.ebFolio.TabIndex = 1
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbTipoFase
        '
        Me.cbTipoFase.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoFase.Location = New System.Drawing.Point(488, 12)
        Me.cbTipoFase.Name = "cbTipoFase"
        Me.cbTipoFase.Size = New System.Drawing.Size(180, 20)
        Me.cbTipoFase.TabIndex = 3
        Me.cbTipoFase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbTipoFase
        '
        Me.lbTipoFase.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoFase.Location = New System.Drawing.Point(352, 12)
        Me.lbTipoFase.Name = "lbTipoFase"
        Me.lbTipoFase.Size = New System.Drawing.Size(132, 20)
        Me.lbTipoFase.TabIndex = 2
        Me.lbTipoFase.Text = "Fase"
        Me.lbTipoFase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDiaClave
        '
        Me.lbDiaClave.BackColor = System.Drawing.Color.Transparent
        Me.lbDiaClave.Location = New System.Drawing.Point(8, 38)
        Me.lbDiaClave.Name = "lbDiaClave"
        Me.lbDiaClave.Size = New System.Drawing.Size(132, 20)
        Me.lbDiaClave.TabIndex = 4
        Me.lbDiaClave.Text = "DiaClave"
        Me.lbDiaClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbAlmacen.Location = New System.Drawing.Point(144, 64)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(524, 20)
        Me.cbAlmacen.TabIndex = 8
        Me.cbAlmacen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbAlmacen
        '
        Me.lbAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.lbAlmacen.Location = New System.Drawing.Point(8, 64)
        Me.lbAlmacen.Name = "lbAlmacen"
        Me.lbAlmacen.Size = New System.Drawing.Size(132, 20)
        Me.lbAlmacen.TabIndex = 7
        Me.lbAlmacen.Text = "Almacen"
        Me.lbAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbVendedor
        '
        Me.lbVendedor.BackColor = System.Drawing.Color.Transparent
        Me.lbVendedor.Location = New System.Drawing.Point(8, 90)
        Me.lbVendedor.Name = "lbVendedor"
        Me.lbVendedor.Size = New System.Drawing.Size(132, 20)
        Me.lbVendedor.TabIndex = 9
        Me.lbVendedor.Text = "Vendedor"
        Me.lbVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebVendedor
        '
        Me.ebVendedor.Enabled = False
        Me.ebVendedor.Location = New System.Drawing.Point(144, 90)
        Me.ebVendedor.MaxLength = 64
        Me.ebVendedor.Name = "ebVendedor"
        Me.ebVendedor.Size = New System.Drawing.Size(500, 20)
        Me.ebVendedor.TabIndex = 10
        Me.ebVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btBuscarVendedor
        '
        Me.btBuscarVendedor.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btBuscarVendedor.Location = New System.Drawing.Point(644, 90)
        Me.btBuscarVendedor.Name = "btBuscarVendedor"
        Me.btBuscarVendedor.Size = New System.Drawing.Size(24, 20)
        Me.btBuscarVendedor.TabIndex = 11
        Me.btBuscarVendedor.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cbPCEModuloMovDetClave
        '
        Me.cbPCEModuloMovDetClave.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbPCEModuloMovDetClave.Location = New System.Drawing.Point(144, 116)
        Me.cbPCEModuloMovDetClave.Name = "cbPCEModuloMovDetClave"
        Me.cbPCEModuloMovDetClave.Size = New System.Drawing.Size(524, 20)
        Me.cbPCEModuloMovDetClave.TabIndex = 13
        Me.cbPCEModuloMovDetClave.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbPCEModuloMovDetClave
        '
        Me.lbPCEModuloMovDetClave.BackColor = System.Drawing.Color.Transparent
        Me.lbPCEModuloMovDetClave.Location = New System.Drawing.Point(8, 116)
        Me.lbPCEModuloMovDetClave.Name = "lbPCEModuloMovDetClave"
        Me.lbPCEModuloMovDetClave.Size = New System.Drawing.Size(132, 20)
        Me.lbPCEModuloMovDetClave.TabIndex = 12
        Me.lbPCEModuloMovDetClave.Text = "Modulo"
        Me.lbPCEModuloMovDetClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbTransProdDetalle
        '
        Me.gbTransProdDetalle.BackColor = System.Drawing.Color.Transparent
        Me.gbTransProdDetalle.Controls.Add(Me.btTPDCrear)
        Me.gbTransProdDetalle.Controls.Add(Me.btTPDEliminar)
        Me.gbTransProdDetalle.Controls.Add(Me.btTPDBuscar)
        Me.gbTransProdDetalle.Controls.Add(Me.grTransProdDetalle)
        Me.gbTransProdDetalle.Location = New System.Drawing.Point(8, 152)
        Me.gbTransProdDetalle.Name = "gbTransProdDetalle"
        Me.gbTransProdDetalle.Size = New System.Drawing.Size(756, 228)
        Me.gbTransProdDetalle.TabIndex = 14
        Me.gbTransProdDetalle.Text = "Productos"
        Me.gbTransProdDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btTPDCrear
        '
        Me.btTPDCrear.BackColor = System.Drawing.Color.Transparent
        Me.btTPDCrear.Icon = CType(resources.GetObject("btTPDCrear.Icon"), System.Drawing.Icon)
        Me.btTPDCrear.Location = New System.Drawing.Point(664, 20)
        Me.btTPDCrear.Name = "btTPDCrear"
        Me.btTPDCrear.Size = New System.Drawing.Size(80, 24)
        Me.btTPDCrear.TabIndex = 1
        Me.btTPDCrear.Text = "Crear"
        Me.btTPDCrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btTPDEliminar
        '
        Me.btTPDEliminar.BackColor = System.Drawing.Color.Transparent
        Me.btTPDEliminar.CausesValidation = False
        Me.btTPDEliminar.Icon = CType(resources.GetObject("btTPDEliminar.Icon"), System.Drawing.Icon)
        Me.btTPDEliminar.Location = New System.Drawing.Point(664, 52)
        Me.btTPDEliminar.Name = "btTPDEliminar"
        Me.btTPDEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btTPDEliminar.TabIndex = 2
        Me.btTPDEliminar.Text = "Eliminar"
        Me.btTPDEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btTPDBuscar
        '
        Me.btTPDBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btTPDBuscar.Icon = CType(resources.GetObject("btTPDBuscar.Icon"), System.Drawing.Icon)
        Me.btTPDBuscar.Location = New System.Drawing.Point(664, 84)
        Me.btTPDBuscar.Name = "btTPDBuscar"
        Me.btTPDBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btTPDBuscar.TabIndex = 3
        Me.btTPDBuscar.Text = "Buscar"
        Me.btTPDBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grTransProdDetalle
        '
        Me.grTransProdDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        grTransProdDetalle_DesignTimeLayout.LayoutString = resources.GetString("grTransProdDetalle_DesignTimeLayout.LayoutString")
        Me.grTransProdDetalle.DesignTimeLayout = grTransProdDetalle_DesignTimeLayout
        Me.grTransProdDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grTransProdDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grTransProdDetalle.GroupByBoxVisible = False
        Me.grTransProdDetalle.Location = New System.Drawing.Point(12, 16)
        Me.grTransProdDetalle.Name = "grTransProdDetalle"
        Me.grTransProdDetalle.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grTransProdDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grTransProdDetalle.Size = New System.Drawing.Size(640, 200)
        Me.grTransProdDetalle.TabIndex = 0
        Me.grTransProdDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'ebDiaClave
        '
        Me.ebDiaClave.CustomFormat = "dd/mm/yyyy"
        '
        '
        '
        Me.ebDiaClave.DropDownCalendar.FirstMonth = New Date(2007, 8, 1, 0, 0, 0, 0)
        Me.ebDiaClave.DropDownCalendar.Name = ""
        Me.ebDiaClave.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ebDiaClave.Location = New System.Drawing.Point(144, 38)
        Me.ebDiaClave.Name = "ebDiaClave"
        Me.ebDiaClave.Size = New System.Drawing.Size(180, 20)
        Me.ebDiaClave.TabIndex = 6
        Me.ebDiaClave.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'ebUSUId
        '
        Me.ebUSUId.Enabled = False
        Me.ebUSUId.Location = New System.Drawing.Point(668, 90)
        Me.ebUSUId.MaxLength = 64
        Me.ebUSUId.Name = "ebUSUId"
        Me.ebUSUId.Size = New System.Drawing.Size(12, 20)
        Me.ebUSUId.TabIndex = 17
        Me.ebUSUId.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUSUId.Visible = False
        Me.ebUSUId.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MCargas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(774, 424)
        Me.Controls.Add(Me.ebUSUId)
        Me.Controls.Add(Me.ebDiaClave)
        Me.Controls.Add(Me.gbTransProdDetalle)
        Me.Controls.Add(Me.cbPCEModuloMovDetClave)
        Me.Controls.Add(Me.lbPCEModuloMovDetClave)
        Me.Controls.Add(Me.btBuscarVendedor)
        Me.Controls.Add(Me.lbVendedor)
        Me.Controls.Add(Me.ebVendedor)
        Me.Controls.Add(Me.cbAlmacen)
        Me.Controls.Add(Me.lbAlmacen)
        Me.Controls.Add(Me.lbDiaClave)
        Me.Controls.Add(Me.cbTipoFase)
        Me.Controls.Add(Me.lbTipoFase)
        Me.Controls.Add(Me.lbFolio)
        Me.Controls.Add(Me.ebFolio)
        Me.Name = "MCargas"
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.ebFolio, 0)
        Me.Controls.SetChildIndex(Me.lbFolio, 0)
        Me.Controls.SetChildIndex(Me.lbTipoFase, 0)
        Me.Controls.SetChildIndex(Me.cbTipoFase, 0)
        Me.Controls.SetChildIndex(Me.lbDiaClave, 0)
        Me.Controls.SetChildIndex(Me.lbAlmacen, 0)
        Me.Controls.SetChildIndex(Me.cbAlmacen, 0)
        Me.Controls.SetChildIndex(Me.ebVendedor, 0)
        Me.Controls.SetChildIndex(Me.lbVendedor, 0)
        Me.Controls.SetChildIndex(Me.btBuscarVendedor, 0)
        Me.Controls.SetChildIndex(Me.lbPCEModuloMovDetClave, 0)
        Me.Controls.SetChildIndex(Me.cbPCEModuloMovDetClave, 0)
        Me.Controls.SetChildIndex(Me.gbTransProdDetalle, 0)
        Me.Controls.SetChildIndex(Me.ebDiaClave, 0)
        Me.Controls.SetChildIndex(Me.ebUSUId, 0)
        CType(Me.gbTransProdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTransProdDetalle.ResumeLayout(False)
        CType(Me.grTransProdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Variables "
    Private tModo As eModo
    Private oTransProd As New cTransProd
    Private oAlmacen As New ERMALMLOG.cAlmacen
    Private oProducto As New ERMPROLOG.cProducto
    Private oMensaje As New CMensaje
    Private bHuboCambios As Boolean = False
    Private bCerrar As Boolean = False
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private sComponente As String = "ERMTRPESC"
    Private htCampos As Hashtable = New Hashtable(20)
    Private htElemInterfaz As Hashtable = New Hashtable(10)
    Private bModificarTransProd As Boolean = False
    Private bCargado As Boolean = False
    Private sNombre As String
    Private bModificandoDatos As Boolean = False
#End Region

#Region " Métodos y Funciones "
    Private Sub ActulizarSobrantes()
        'Me.cbAlmacen.Enabled = False
        Me.cbPCEModuloMovDetClave.Visible = False
        Me.ebVendedor.Visible = False
        'Me.lbAlmacen.Enabled = False
        Me.lbVendedor.Visible = False
        btBuscarVendedor.Visible = False
        Me.lbPCEModuloMovDetClave.Visible = False
        Me.gbTransProdDetalle.Location = New Point(8, 96)
        Me.gbTransProdDetalle.Size = New Size(756, 272)

    End Sub

    Public Function CREAR(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Crear
        oTransProd = prTransProd
        If oTransProd.Tipo = TipoTRP.Carga Then
            sNombre = Me.Name
        ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
            sNombre = "MSobrante"
            ActulizarSobrantes()
        Else
            sNombre = "MReclasificado"
        End If
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "C")


        Return IniciarPantalla()
    End Function

    Public Function MODIFICAR(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Modificar
        oTransProd = prTransProd
        If oTransProd.Tipo = TipoTRP.Carga Then
            sNombre = Me.Name
        ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
            sNombre = "MSobrante"
            ActulizarSobrantes()
        Else
            sNombre = "MReclasificado"
        End If
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "M")

        Return IniciarPantalla()
    End Function

    Public Function LEER(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Leer
        oTransProd = prTransProd
        If oTransProd.Tipo = TipoTRP.Carga Then
            sNombre = Me.Name
        ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
            sNombre = "MSobrante"
            ActulizarSobrantes()
        Else
            sNombre = "MReclasificado"
        End If
        Me.Text = oMensaje.RecuperarDescripcion("xconsultar") + " " + oMensaje.RecuperarDescripcion("ERMTRPESC_NCargas")
        BtCancelar.Icon = BtAceptar.Icon
        BtAceptar.Visible = False

        Return IniciarPantalla()
    End Function

    Private Function IniciarPantalla() As Boolean
        oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CrearObjetosCamposLogicos()
        CrearObjetosInterfaz()
        ConfigurarInterfaz()
        bCargado = True
        Me.Cursor = System.Windows.Forms.Cursors.Default

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            oConexion.ConfirmarTran()
            Return True
        Else
            oConexion.DeshacerTran()
            Return False
        End If
    End Function

    Private Sub CrearObjetosCamposLogicos()
        Dim oCL As ManejoCampoLogico

        CrearCampoLogico("Folio", CType(Me.lbFolio, Control), CType(Me.ebFolio, Control), True, "", True)
        oCL = CrearCampoLogico("TipoFase", CType(Me.lbTipoFase, Control), CType(Me.cbTipoFase, Control), True, "TRPFASE")
        oCL.VAVClaveDefault = 5
        CrearCampoLogico("DiaClave", CType(Me.lbDiaClave, Control), CType(Me.ebDiaClave, Control), True)
        CrearCampoLogico("Almacen", CType(Me.lbAlmacen, Control), CType(Me.cbAlmacen, Control), True)
        CrearCampoLogico("Vendedor", CType(Me.lbVendedor, Control), CType(Me.ebVendedor, Control), True)
        If oTransProd.Tipo = TipoTRP.Carga Then
            CrearCampoLogico("PCEModuloMovDetClave", CType(Me.lbPCEModuloMovDetClave, Control), CType(Me.cbPCEModuloMovDetClave, Control), True)
        End If

    End Sub

    Private Function CrearCampoLogico(ByVal pvCampo As String, ByRef prCtrlEtiqueta As System.Windows.Forms.Control, ByRef prCtrlCaptura As System.Windows.Forms.Control, Optional ByVal pvRequerido As Boolean = False, Optional ByVal pvValorReferencia As String = "", Optional ByVal pvLlave As Boolean = False) As ManejoCampoLogico
        Dim oCL As ManejoCampoLogico

        oCL = New ManejoCampoLogico(oTransProd.Mnemonico, pvCampo, prCtrlEtiqueta, prCtrlCaptura, pvRequerido, pvValorReferencia, pvLlave)
        htCampos.Add(oCL.Campo, oCL)
        oCL.CtrlCaptura.Tag = oCL
        Return oCL
    End Function

    Private Sub CrearObjetosInterfaz()
        'aqui se agregan los botones, etc
        Dim oEI As ManejoElementoInterfaz

        oEI = New ManejoElementoInterfaz(sComponente & "_" & Me.Name & "_gbTransProdDetall", CType(Me.gbTransProdDetalle, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)

        oEI = New ManejoElementoInterfaz("BTCrear", CType(Me.btTPDCrear, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTEliminar", CType(Me.btTPDEliminar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTBuscar", CType(Me.btTPDBuscar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTAceptar", CType(Me.BtAceptar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTCancelar", CType(Me.BtCancelar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
    End Sub

    Private Sub ConfigurarInterfaz()
        Dim oCL As ManejoCampoLogico
        Dim oEI As ManejoElementoInterfaz
        Dim lTootTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        For Each oCL In htCampos.Values
            oCL.FijarTexto(oMensaje)
            oCL.FijarTooltip(oMensaje, lTootTip)
            oCL.CargarValorReferencia()
        Next

        If tModo = eModo.Crear Or tModo = eModo.Modificar Then
            cbTipoFase.DataSource = Nothing
            If oTransProd.Tipo = TipoTRP.Sobrante Then
                lbGeneral.LlenarComboBox(cbTipoFase, "TRPFASE", 1, New String() {"2", "3", "4", "5", "6"})
            Else
                lbGeneral.LlenarComboBox(cbTipoFase, "TRPFASE", 5, New String() {"1", "2", "3", "4", "6"})
            End If

        End If

        'Titulos Botones
        For Each oEI In htElemInterfaz.Values
            oEI.FijarTexto(oMensaje)
            oEI.FijarTooltip(oMensaje, lTootTip)
        Next


        Me.ebDiaClave.TodayButtonText = oMensaje.RecuperarDescripcion("XAhora")
        Me.lbAlmacen.Text = oMensaje.RecuperarDescripcion("XCentroDistribucion")
        lTootTip.SetToolTip(Me.cbAlmacen, oMensaje.RecuperarDescripcion("XCentroDistribucion"))
        Me.lbVendedor.Text = oMensaje.RecuperarDescripcion("XVendedor")
        lTootTip.SetToolTip(Me.ebVendedor, oMensaje.RecuperarDescripcion("XVendedor"))
        If tModo = eModo.Leer Then
            lTootTip.SetToolTip(BtCancelar, oMensaje.RecuperarDescripcion("btregresar"))
            BtCancelar.Text = oMensaje.RecuperarDescripcion("btregresar")
        End If
        PonerTitulosGrid(grTransProdDetalle, "TPD")
        grTransProdDetalle.RootTable.Columns("Nombre").Caption = oMensaje.RecuperarDescripcion("PRONombre")
        grTransProdDetalle.RootTable.Columns("Nombre").HeaderToolTip = oMensaje.RecuperarDescripcion("PRONombreT")

        Dim oAlmacen As New ERMALMLOG.cAlmacen
        Dim ldt As DataTable = oAlmacen.Tabla.Recuperar("Tipo=1 AND TipoEstado=1")
        For Each ldr As DataRow In ldt.Rows
            cbAlmacen.Items.Add(ldr!Nombre, ldr!Clave)
        Next

        If oTransProd.Tipo = TipoTRP.Carga Then
            ldt = oConexion.EjecutarConsulta("select md.ModuloMovDetalleClave, md.Nombre from ModuloMovDetalle md inner join moduloterm mt on md.moduloclave=mt.moduloclave where md.tipoindice=10 and md.tipotransprod=2 and md.tipoestado=1 and mt.tipoestado=1")
            For Each ldr As DataRow In ldt.Rows
                cbPCEModuloMovDetClave.Items.Add(ldr!Nombre, ldr!ModuloMovDetalleClave)
            Next
        End If

        If tModo = eModo.Crear Then
            If cbAlmacen.Items.Count > 0 And oTransProd.Tipo = TipoTRP.Sobrante Then cbAlmacen.SelectedIndex = 0
            LimpiarControles()
            ebDiaClave.Value = oConexion.ObtenerFecha.Date
            If cbPCEModuloMovDetClave.Items.Count > 0 Then
                cbPCEModuloMovDetClave.SelectedValue = cbPCEModuloMovDetClave.Items(0).Value
            End If

            If oTransProd.Tipo = TipoTRP.Reclasificado Then
                btTPDCrear.Enabled = False
                btTPDBuscar.Enabled = False
            End If

            btBuscarVendedor.Enabled = False
            btTPDEliminar.Enabled = False
            If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then
                cbTipoFase.Enabled = False
                'grTransProdDetalle.AllowEdit = False
            End If

        ElseIf tModo = eModo.Modificar Then
            ebFolio.Enabled = False
            If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then
                ebDiaClave.Enabled = False
                cbAlmacen.Enabled = False
                btBuscarVendedor.Enabled = False
                cbPCEModuloMovDetClave.Enabled = False
                'grTransProdDetalle.AllowEdit = False
            End If

            If oTransProd.Tipo = TipoTRP.Reclasificado Then
                ebDiaClave.Enabled = False
                cbAlmacen.Enabled = False
                btBuscarVendedor.Enabled = False
            End If

            CargarDatos()

            If oTransProd.Notas = "" Then
                btBuscarVendedor.Enabled = False
            End If
        ElseIf (tModo = eModo.Leer) Then
            CargarDatos()
            ebFolio.Enabled = False
            cbTipoFase.Enabled = False
            ebDiaClave.Enabled = False
            cbAlmacen.Enabled = False
            btBuscarVendedor.Enabled = False
            cbPCEModuloMovDetClave.Enabled = False
            'grTransProdDetalle.Enabled = False
            grTransProdDetalle.AllowEdit = False
            btTPDCrear.Enabled = False
            btTPDEliminar.Enabled = False
            btTPDBuscar.Enabled = False
            BtAceptar.Enabled = False
        End If

        If oTransProd.Tipo = TipoTRP.Reclasificado Then
            lbPCEModuloMovDetClave.Visible = False
            cbPCEModuloMovDetClave.Visible = False
        End If

        If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then 'And tModo = eModo.Modificar Then
            Me.btTPDCrear.Enabled = (tModo = eModo.Modificar)
            Me.btTPDEliminar.Enabled = (tModo = eModo.Modificar)
            Me.btTPDBuscar.Enabled = (tModo = eModo.Modificar)
            'Me.btTPDCrear.Visible = False
            'Me.btTPDEliminar.Visible = False
            'Me.btTPDBuscar.Visible = False
            'Me.gbTransProdDetalle.Size = New System.Drawing.Size(664, Me.gbTransProdDetalle.Size.Height)
            'Me.BtAceptar.Location = New System.Drawing.Point(456, Me.BtAceptar.Location.Y)
            'Me.BtCancelar.Location = New System.Drawing.Point(568, Me.BtCancelar.Location.Y)
            'Me.Size = New System.Drawing.Size(692, Me.Size.Height)
        End If

        LlenarGridTransProdDetalle()

        If tModo = eModo.Crear Then
            Me.ebFolio.Focus()
        ElseIf tModo = eModo.Modificar Then
            Me.cbTipoFase.Focus()
        End If

        bHuboCambios = False
    End Sub

    Private Sub PonerTitulosGrid(ByVal prGrid As Janus.Windows.GridEX.GridEX, ByVal sNemonico As String)
        With prGrid.RootTable
            For Each lColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                lColumna.Caption = oMensaje.RecuperarDescripcion(sNemonico & lColumna.Key)
                lColumna.HeaderToolTip = oMensaje.RecuperarDescripcion(sNemonico & lColumna.Key & "T")
            Next
        End With
    End Sub

    Private Sub LimpiarControles()
        For Each oCL As ManejoCampoLogico In htCampos.Values
            Select Case oCL.CtrlCaptura.GetType.Name
                Case "EditBox"
                    oCL.CtrlCaptura.Text = ""
                Case "UICheckBox"
                    CType(oCL.CtrlCaptura, CheckBox).Checked = False
            End Select
        Next
    End Sub

    Private Sub CargarDatos()
        With oTransProd
            Me.ebFolio.Text = .Folio
            Me.cbTipoFase.SelectedValue = .TipoFase
            If .Tipo = TipoTRP.Sobrante Then
                Me.ebDiaClave.Text = Convert.ToDateTime(.FechaHoraAlta, Globalization.CultureInfo.CreateSpecificCulture("ES-MX"))
            Else
                Me.ebDiaClave.Text = Convert.ToDateTime(.DiaClave, Globalization.CultureInfo.CreateSpecificCulture("ES-MX"))
            End If

            If tModo = eModo.Crear Or tModo = eModo.Modificar Or oTransProd.Tipo = TipoTRP.Reclasificado Or oTransProd.Tipo = TipoTRP.Sobrante Then
                Me.cbAlmacen.SelectedValue = .Notas
            Else
                If cbTipoFase.SelectedValue <> 1 Then
                    Me.cbAlmacen.SelectedValue = .Notas
                Else
                    If oConexion.EjecutarConsulta("SELECT TOP 1 ClaveCEDI FROM AgendaVendedor WHERE DiaClave='" & lbGeneral.ValidaFormatoSQLString(.DiaClave) & "' AND VendedorId=(SELECT Top 1 VendedorId FROM Vendedor WHERE USUId='" & .MUsuarioID & "'  and TipoEstado = 1) ").Rows.Count > 0 Then
                        Me.cbAlmacen.SelectedValue = oConexion.EjecutarConsulta("SELECT TOP 1 ClaveCEDI FROM AgendaVendedor WHERE DiaClave='" & lbGeneral.ValidaFormatoSQLString(.DiaClave) & "' AND VendedorId=(SELECT Top 1 VendedorId FROM Vendedor WHERE USUId='" & .MUsuarioID & "' and TipoEstado = 1)").Rows(0)!ClaveCEDI
                    End If
                End If
            End If

            If .MUsuarioID <> "" And oTransProd.Tipo <> TipoTRP.Sobrante Then
                Dim oVendedor As New ERMVENLOG.cVendedor
                If tModo = eModo.Modificar Then
                    Me.ebVendedor.Text = oVendedor.Tabla.Recuperar("USUId='" & .MUsuarioID & "' AND TipoEstado=1 AND Baja=0").Rows(0)!Nombre
                ElseIf tModo = eModo.Leer Then
                    Me.ebVendedor.Text = oVendedor.Tabla.Recuperar("USUId='" & .MUsuarioID & "'").Rows(0)!Nombre
                End If
                ebUSUId.Text = .MUsuarioID
            End If
            If oTransProd.Tipo = TipoTRP.Carga Then
                Me.cbPCEModuloMovDetClave.SelectedValue = .PCEModuloMovDetClave
            End If
        End With
    End Sub

    Private Sub LlenarGridTransProdDetalle()
        LlenarDropDownColumna(grTransProdDetalle, "TipoUnidad", "UNIDADV")

        Dim ldtDataTable As DataTable
        Dim ldtProductos As DataTable

        ldtDataTable = oTransProd.TransProdDetalle.ToDataTable
        If Not ldtDataTable.Columns.Contains("Nombre") Then
            ldtDataTable.Columns.Add("Nombre", GetType(String))
        End If

        ldtProductos = oProducto.Tabla.Recuperar()
        For Each ldr As DataRow In ldtDataTable.Rows
            If ldtProductos.Select("ProductoClave='" & lbGeneral.ValidaFormatoSQLString(ldr!ProductoClave) & "'").Length > 0 Then
                ldr!Nombre = ldtProductos.Select("ProductoClave='" & lbGeneral.ValidaFormatoSQLString(ldr!ProductoClave) & "'")(0)!Nombre
            End If
            'ldr!Nombre = oProducto.Tabla.Recuperar("ProductoClave='" & ldr!ProductoClave & "'").Rows(0)!Nombre
        Next
        grTransProdDetalle.DataSource = ldtDataTable
        grTransProdDetalle.DataMember = "TransProdDetalle"

        ldtProductos = Nothing
        ldtDataTable = Nothing
    End Sub

    Private Sub LlenarDropDownColumna(ByRef pvGrid As Janus.Windows.GridEX.GridEX, ByVal pvColumna As String, ByVal pvValor As String)
        pvGrid.RootTable.Columns(pvColumna).HasValueList = True
        pvGrid.RootTable.Columns(pvColumna).EditType = Janus.Windows.GridEX.EditType.DropDownList
        lbGeneral.LlenarColumna(pvGrid.RootTable.Columns(pvColumna), pvValor)
    End Sub

    Private Sub PonerFoco(ByVal pvNombreCampo As String)
        Try
            Select Case pvNombreCampo
                Case "Folio"
                    ebFolio.Focus()
                Case "TipoFase"
                    cbTipoFase.Focus()
                Case "DiaClave"
                    ebDiaClave.Focus()
                Case "Notas"
                    cbAlmacen.Focus()
                Case "MUsuarioId"
                    ebVendedor.Focus()
                Case "PCEModuloMovDetClave"
                    cbPCEModuloMovDetClave.Focus()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                If (peGridEx.Row = 0) Then
                    Try
                        peGridEx.MoveLast()
                    Catch ex As Exception

                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub ObtenerProducto(ByRef pvClave As String, ByRef prGrid As Janus.Windows.GridEX.GridEX)
        Dim lDataTable As New DataTable

        If IsNothing(pvClave) = True Then
            Exit Sub
        End If

        lDataTable = oProducto.Tabla.Recuperar("ProductoClave='" + lbGeneral.ValidaFormatoSQLString(pvClave) + "'")

        If lDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("E0005")
        End If

        If lDataTable.Rows(0)!TipoFase <> 1 Then
            Throw New LbControlError.cError("E0408", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbGeneral.ClaveDescripcionVARValor("PROFASE", lDataTable.Rows(0)!TipoFase), False)})
        End If

        If oTransProd.Tipo = TipoTRP.Reclasificado Then
            If oConexion.EjecutarConsulta("SELECT TPD.ProductoClave FROM TransProd TRP INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId WHERE (TRP.Tipo=3 OR (TRP.Tipo=9 AND TRP.TipoMovimiento=1)) AND TRP.TipoFase=1 AND TRP.TipoMotivo IN (SELECT VAVClave FROM VarValor WHERE VARCodigo='TRPMOT' AND Grupo='No Venta') AND TRP.MUsuarioId='" & ebUSUId.Text & "' AND TRP.DiaClave='" & lbGeneral.ValidaFormatoSQLString(ebDiaClave.Value.ToString("dd/MM/yyyy")) & "' AND TPD.ProductoClave='" & lbGeneral.ValidaFormatoSQLString(pvClave) & "'").Rows.Count = 0 Then
                Throw New LbControlError.cError("E0630")
            End If
        End If

        'Dim lCol As New Janus.Windows.GridEX.GridEXColumn
        'lCol.HasValueList = True
        'Dim i As Integer
        'Select Case e.Column.Key
        '    Case "TipoUnidad"
        '        Dim oProducto As New ERMPROLOG.cProducto
        '        Dim aExcep() As String
        '        If Not grTransProdDetalle.GetValue("ProductoClave") Is Nothing And grTransProdDetalle.GetValue("ProductoClave") <> "" Then
        '            oProducto.Recuperar(grTransProdDetalle.GetValue("ProductoClave"))
        '            aExcep = oProducto.RegresaUnidades()
        '            lbGeneral.LlenarColumna(lCol, "UNIDADV", , aExcep)
        '            e.Column.EditValueList = lCol.ValueList
        Dim lCol As New Janus.Windows.GridEX.GridEXColumn
        Dim aExcep() As String
        lCol.HasValueList = True
        oProducto.Recuperar(pvClave)
        aExcep = oProducto.RegresaUnidades()
        lbGeneral.LlenarColumna(lCol, "UNIDADV", , aExcep)
        grTransProdDetalle.Tables(0).Columns("TipoUnidad").EditValueList = lCol.ValueList
        pvClave = lDataTable.Rows(0)!ProductoClave
        prGrid.GetRow.Cells("Nombre").Value = lDataTable.Rows(0)!Nombre

        If Array.IndexOf(aExcep, prGrid.GetRow.Cells("TipoUnidad").Value) = -1 Then
            If lCol.ValueList.Count > 0 Then
                prGrid.GetRow.Cells("TipoUnidad").Value = lCol.ValueList(0).Value
            Else
                prGrid.GetRow.Cells("TipoUnidad").Value = ""
            End If

        End If

    End Sub

    Private Sub LlenarNulos(ByRef prGrid As Janus.Windows.GridEX.GridEX)
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In prGrid.GetRow.Cells
            If IsDBNull(vlCelda.Value) Or IsNothing(vlCelda.Value) Then
                Select Case prGrid.Name
                    Case "grTransProdDetalle"
                        Select Case vlCelda.Column.Key
                            Case "ProductoClave"
                                vlCelda.Value = ""
                            Case "TipoUnidad"
                                Dim oProducto As New ERMPROLOG.cProducto
                                Dim aExcep() As String
                                Dim lCol As New Janus.Windows.GridEX.GridEXColumn
                                lCol.HasValueList = True

                                If Not prGrid.GetValue("ProductoClave") Is Nothing And prGrid.GetValue("ProductoClave") <> "" Then
                                    oProducto.Recuperar(prGrid.GetValue("ProductoClave"))
                                    aExcep = oProducto.RegresaUnidades()
                                    lbGeneral.LlenarColumna(lCol, "UNIDADV", , aExcep)
                                    prGrid.GetRow.Cells("TipoUnidad").Column.EditValueList = lCol.ValueList
                                    vlCelda.Value = CType(oProducto.PRUArray(0), ERMPROLOG.cProductoUnidad).PRUTipoUnidad
                                Else
                                    vlCelda.Value = 1
                                End If

                            Case "Cantidad"
                                vlCelda.Value = 1
                        End Select
                End Select
            End If
        Next
    End Sub

    Function BuscarTransProdDetalle(ByVal pvRenglon As Janus.Windows.GridEX.GridEXRow) As Boolean
        For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grTransProdDetalle.GetRows
            If LCase(vlDataRow.Cells("ProductoClave").Value) = LCase(pvRenglon.Cells("ProductoClave").Value) And vlDataRow.Cells("TipoUnidad").Value = pvRenglon.Cells("TipoUnidad").Value And Not vlDataRow Is pvRenglon Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub LlenarGridProdCargaAutomatica()
        Dim dtProd As DataTable
        dtProd = oTransProd.ObtenerProdCargaAutomatica(ebUSUId.Text, cbAlmacen.SelectedValue)
        If grTransProdDetalle.RowCount > 0 Then
            For Each oDataRow As Janus.Windows.GridEX.GridEXRow In grTransProdDetalle.GetRows
                oTransProd.TransProdDetalle(grTransProdDetalle.GetValue("TransProdDetalleId")).Eliminar()
                grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                grTransProdDetalle.Delete()
                grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
            Next
        End If
        For Each drProducto As DataRow In dtProd.Rows
            Dim lCol As New Janus.Windows.GridEX.GridEXColumn
            lCol.HasValueList = True
            lbGeneral.LlenarColumna(lCol, "UNIDADV")
            If lCol.ValueList.Count > 0 Then
                grTransProdDetalle.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                grTransProdDetalle.MoveToNewRecord()
                grTransProdDetalle.GetRow.Cells("ProductoClave").Value = drProducto("ProductoClave")
                grTransProdDetalle.GetRow.Cells("Nombre").Value = drProducto("Nombre")
                grTransProdDetalle.GetRow.Cells("TipoUnidad").Value = drProducto("TipoUnidad")
                grTransProdDetalle.GetRow.Cells("Cantidad").Value = drProducto("Cantidad")
                grTransProdDetalle.UpdateData()
            End If
            grTransProdDetalle.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
        Next
        'grTransProdDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub
#End Region

#Region " Eventos "
    Private Sub ControlesActivo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebFolio.Validated, cbTipoFase.Validated, ebDiaClave.Validated, cbAlmacen.Validated, btBuscarVendedor.Validated, cbPCEModuloMovDetClave.Validated
        Dim pvCampos() As String = Nothing
        Dim oCL As ManejoCampoLogico
        oCL = CType(sender.tag, ManejoCampoLogico)

        Select Case CType(sender.Name, String)
            Case "ebFolio"
                If ebFolio.Text <> "" Then
                    If oTransProd.ExisteFolio(ebFolio.Text) Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0002"))
                        Exit Sub
                    End If
                End If
                oTransProd.Folio = ebFolio.Text
                pvCampos = New String() {"Folio"}
            Case "cbTipoFase"
                oTransProd.TipoFase = cbTipoFase.SelectedValue
                pvCampos = New String() {"TipoFase"}
            Case "ebDiaClave"
                If oTransProd.Tipo = TipoTRP.Carga Then
                    If CDate(ebDiaClave.Text) < oConexion.ObtenerFecha.Date Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("E0066"))
                        Exit Sub
                    End If
                ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
                    If Not oTransProd.FechaSobrantesValida(CDate(Me.ebDiaClave.Text), cbAlmacen.SelectedValue) Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("E0724"))
                        Exit Sub
                    End If
                Else
                    If CDate(ebDiaClave.Text) > oConexion.ObtenerFecha.Date Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("E0087", New String() {oMensaje.RecuperarDescripcion("XFechaDiaTrabajo")}))
                        Exit Sub
                    End If
                End If
                If oTransProd.Tipo <> TipoTRP.Sobrante Then
                    oTransProd.DiaClave = ebDiaClave.Text
                End If
                pvCampos = New String() {"DiaClave"}
            Case "cbAlmacen"
                If IsNothing(cbAlmacen.SelectedValue) Then
                    epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {lbAlmacen.Text}))
                    Exit Sub
                End If
                oTransProd.Notas = cbAlmacen.SelectedValue
                pvCampos = New String() {"Notas"}
            Case "btBuscarVendedor"
                If ebUSUId.Text = "" Then
                    epErrores.SetError(btBuscarVendedor, oMensaje.RecuperarDescripcion("BE0001", New String() {lbVendedor.Text}))
                    Exit Sub
                End If
                oTransProd.Tabla.Campos("MUsuarioId").Valor = ebUSUId.Text
                pvCampos = New String() {"MUsuarioId"}
            Case "cbPCEModuloMovDetClave"
                If IsNothing(cbPCEModuloMovDetClave.SelectedValue) Then
                    epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {lbPCEModuloMovDetClave.Text}))
                    Exit Sub
                End If
                oTransProd.PCEModuloMovDetClave = cbPCEModuloMovDetClave.SelectedValue
                pvCampos = New String() {"PCEModuloMovDetClave"}
        End Select

        Try
            oTransProd.ValidarCampos(pvCampos)
        Catch ex As LbControlError.cError
            epErrores.SetError(sender, ex.Mensaje)
            Exit Sub
        End Try
        epErrores.SetError(sender, "")
    End Sub

    Private Sub EliminaProductosGrid()
        grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
        For Each lsItem As Janus.Windows.GridEX.GridEXRow In grTransProdDetalle.GetRows
            oTransProd.TransProdDetalle(lsItem.Cells("TransProdDetalleId").Value).Eliminar()
            CType(lsItem.DataRow, DataRowView).Delete()
        Next
        grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub ControlesActivo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebFolio.TextChanged, cbTipoFase.SelectedValueChanged, ebDiaClave.ValueChanged, cbAlmacen.SelectedValueChanged, ebVendedor.TextChanged, cbPCEModuloMovDetClave.TextChanged
        If sender.Name = "ebDiaClave" Or sender.Name = "cbAlmacen" Then
            If grTransProdDetalle.RowCount > 0 And bModificandoDatos = False And oTransProd.Tipo = TipoTRP.Reclasificado Then
                If MsgBox(oMensaje.RecuperarDescripcion("P0109"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                    Call EliminaProductosGrid()
                Else
                    bModificandoDatos = True
                    Select Case CType(sender.Name, String)
                        Case "ebDiaClave"
                            ebDiaClave.Value = oTransProd.DiaClave
                        Case "cbAlmacen"
                            cbAlmacen.SelectedValue = oTransProd.Notas
                    End Select
                    bModificandoDatos = False
                End If
            End If
        End If

        If sender.Name = "cbAlmacen" Then
            If btBuscarVendedor.Enabled = False Then
                If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then
                    btBuscarVendedor.Enabled = (tModo = eModo.Crear)
                ElseIf oTransProd.Tipo = TipoTRP.Reclasificado And tModo = eModo.Modificar Then
                    btBuscarVendedor.Enabled = False
                Else
                    btBuscarVendedor.Enabled = True
                End If
            End If

            ebVendedor.Text = ""
            ebUSUId.Text = ""

            If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then 'Carga automatica
                If grTransProdDetalle.RowCount > 0 Then
                    For Each oDataRow As Janus.Windows.GridEX.GridEXRow In grTransProdDetalle.GetRows
                        oTransProd.TransProdDetalle(grTransProdDetalle.GetValue("TransProdDetalleId")).Eliminar()
                        grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                        grTransProdDetalle.Delete()
                        grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    Next
                End If
            End If
        End If

        bHuboCambios = True
        If bCargado Then
            bModificarTransProd = True
        End If
    End Sub

    Private Sub btBuscarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarVendedor.Click
        Dim oSeleccionarVendedor As New ERMVENESC.IGeneral
        Dim lsAlmacenId As String = oAlmacen.Tabla.Recuperar("Clave='" & lbGeneral.ValidaFormatoSQLString(cbAlmacen.SelectedValue) & "'").Rows(0)!AlmacenId
        bHuboCambios = True
        Dim lItems As ArrayList = oSeleccionarVendedor.Seleccionar("TipoEstado=1 AND Baja=0 AND VendedorId IN (SELECT VendedorId FROM VENCentroDistHist AS VCD WHERE VCD.AlmacenId='" & lbGeneral.ValidaFormatoSQLString(lsAlmacenId) & "' AND VCD.VCHFechaInicial <=" & oConexion.UniFechaSQL(oConexion.ObtenerFecha.Date) & " AND VCD.FechaFinal >=" & oConexion.UniFechaSQL(oConexion.ObtenerFecha.Date) & ")", False)
        If Not lItems Is Nothing Then

            If grTransProdDetalle.RowCount > 0 And ebUSUId.Text <> lItems(0).USUId And oTransProd.Tipo = TipoTRP.Reclasificado Then
                If MsgBox(oMensaje.RecuperarDescripcion("P0109"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                    Call EliminaProductosGrid()
                Else
                    Exit Sub
                End If
            End If

            ebUSUId.Text = lItems(0).USUId
            ebVendedor.Text = lItems(0).Nombre
            epErrores.SetError(btBuscarVendedor, "")
            If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then 'Carga automatica
                LlenarGridProdCargaAutomatica()
                btTPDCrear.Enabled = True
                btTPDBuscar.Enabled = True
            End If
            If oTransProd.Tipo = TipoTRP.Reclasificado Then
                btTPDCrear.Enabled = True
                btTPDBuscar.Enabled = True
            End If
        End If
    End Sub

    Private Sub btTPDCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTPDCrear.Click
        grTransProdDetalle.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grTransProdDetalle.Col = 0
        grTransProdDetalle.MoveToNewRecord()
        grTransProdDetalle.RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.TextBox
        grTransProdDetalle.Focus()
    End Sub

    Private Sub btTPDEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTPDEliminar.Click
        If (grTransProdDetalle.RowCount = 0) Then
            Exit Sub
        End If

        If (grTransProdDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            grTransProdDetalle.CancelCurrentEdit()
            Call DeshabilitaCrear(grTransProdDetalle)
        ElseIf (grTransProdDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            oTransProd.TransProdDetalle(grTransProdDetalle.GetValue("TransProdDetalleId")).Eliminar()
            grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            grTransProdDetalle.Delete()
            grTransProdDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        End If

        'If oTransProd.Tipo = TipoTRP.Reclasificado Then
        '    If (grTransProdDetalle.RowCount = 0) Then
        '        ebDiaClave.Enabled = True
        '        cbAlmacen.Enabled = True
        '        btBuscarVendedor.Enabled = True
        '    End If
        'End If
    End Sub

    Private Sub btTPDBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTPDBuscar.Click
        'Dim vlSeleccionarProducto As New ERMPROESC.IGeneral(True, , "TipoFase=1")
        bHuboCambios = True
        Dim vlArrayList As ArrayList
        Dim vlDataTable As DataTable
        Dim ldtRegistros As DataTable
        Dim vlSeleccionarProducto As ERMPROESC.IProductoUnidad

        If oTransProd.Tipo = TipoTRP.Reclasificado Then
            vlSeleccionarProducto = New ERMPROESC.IProductoUnidad(True, "and PRO.TipoFase = 1 and PRU.ProductoClave in (SELECT TPD.ProductoClave FROM TransProd TRP INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId WHERE (TRP.Tipo=3 OR (TRP.Tipo=9 AND TRP.TipoMovimiento=1)) AND TRP.TipoFase=1 AND TRP.TipoMotivo IN (SELECT VAVClave FROM VarValor WHERE VARCodigo='TRPMOT' AND Grupo='No Venta') AND TRP.MUsuarioId='" & ebUSUId.Text & "' AND TRP.DiaClave='" & lbGeneral.ValidaFormatoSQLString(ebDiaClave.Value.ToString("dd/MM/yyyy")) & "')")
        Else
            vlSeleccionarProducto = New ERMPROESC.IProductoUnidad(True, "and PRO.TipoFase = 1")
        End If

        vlSeleccionarProducto.MultiSelectArr = True
        vlSeleccionarProducto.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.gbTransProdDetalle.Enabled = False
        vlArrayList = vlSeleccionarProducto.Seleccion

        If IsNothing(vlArrayList) = False Then
            Dim vlDataRow As DataRow
            Dim lsProductoClave, lsNombre, lsPRUTipoUnidad As String

            ldtRegistros = grTransProdDetalle.DataSource
            vlDataTable = ldtRegistros.Copy
            grTransProdDetalle.SuspendLayout()

            For Each aRegistro As ArrayList In vlArrayList
                lsProductoClave = aRegistro(0)
                lsNombre = aRegistro(1)
                lsPRUTipoUnidad = aRegistro(2)

                If ldtRegistros.Select("ProductoClave='" & lbGeneral.ValidaFormatoSQLString(lsProductoClave) & "' AND TipoUnidad=" & lsPRUTipoUnidad).Length = 0 Then
                    Dim oTransProdDetalle As New ERMTRPLOG.cTransProdDetalle(oTransProd)
                    vlDataRow = vlDataTable.NewRow()
                    vlDataRow("TransProdDetalleId") = lbGeneral.cKeyGen.KEYGEN(0)
                    vlDataRow("ProductoClave") = lsProductoClave
                    vlDataRow("Nombre") = lsNombre
                    vlDataRow("TipoUnidad") = lsPRUTipoUnidad
                    vlDataRow("Cantidad") = 1

                    With oTransProdDetalle
                        .TransProdDetalleID = lbGeneral.ChkDbNull(vlDataRow("TransProdDetalleId"))
                        .ProductoClave = lbGeneral.ChkDbNull(lsProductoClave)
                        .TipoUnidad = lbGeneral.ChkDbNull(lsPRUTipoUnidad)
                        .Cantidad = 1
                        .Partida = 0
                        .Precio = 0
                        .Subtotal = 0
                        .Total = 0
                        .Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    End With

                    If oTransProd.Tipo = TipoTRP.Reclasificado Then
                        Dim nCantidad As Integer
                        If oTransProdDetalle.ValidarCantidadMax(Me.ebUSUId.Text, Me.ebDiaClave.Text, Me.cbAlmacen.SelectedValue, nCantidad) Then
                            oTransProdDetalle.Insertar(New String() {"TransProdDetalleID", "ProductoClave", "TipoUnidad", "Cantidad", "Precio", "Subtotal", "Total"})
                            oTransProd.TransProdDetalle.Insertar(oTransProdDetalle)
                            vlDataTable.Rows.Add(vlDataRow)

                            'ebDiaClave.Enabled = False
                            'cbAlmacen.Enabled = False
                            'btBuscarVendedor.Enabled = False
                        End If
                    Else
                        oTransProdDetalle.Insertar(New String() {"TransProdDetalleID", "ProductoClave", "TipoUnidad", "Cantidad", "Precio", "Subtotal", "Total"})
                        oTransProd.TransProdDetalle.Insertar(oTransProdDetalle)
                        vlDataTable.Rows.Add(vlDataRow)
                    End If

                End If
                System.Windows.Forms.Application.DoEvents()
            Next

            Me.grTransProdDetalle.DataSource = vlDataTable
            grTransProdDetalle.ResumeLayout()
            grTransProdDetalle.UpdateData()
            grTransProdDetalle.Focus()

        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.gbTransProdDetalle.Enabled = True

        ''--------------------------------------------------------------------------------
        '
        'Dim vlSeleccionarProducto As New ERMPROESC.IProductoUnidad(True, "and TipoFase = 1")
        'vlSeleccionarProducto.ShowDialog()

        'bHuboCambios = True
        'Dim vlArrayList As ArrayList
        'Dim vlDataTable As DataTable
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'vlArrayList = vlSeleccionarProducto.Seleccion
        'If IsNothing(vlArrayList) = False Then
        '    vlDataTable = grTransProdDetalle.DataSource

        '    For Each vlProductoUnidad As ERMPROLOG.cProductoUnidad In vlArrayList
        '        Dim lCol As New Janus.Windows.GridEX.GridEXColumn
        '        Dim oProducto As New ERMPROLOG.cProducto
        '        Dim aExcep() As String

        '        lCol.HasValueList = True
        '        oProducto.Recuperar(vlProductoUnidad.ProductoClave)
        '        aExcep = oProducto.RegresaUnidades()
        '        lbGeneral.LlenarColumna(lCol, "UNIDADV", , aExcep)

        '        If lCol.ValueList.Count > 0 Then
        '            'If vlDataTable.Select("ProductoClave='" & vlProductoUnidad.ProductoClave & "' AND TipoUnidad=" & lCol.ValueList.Item(0).Value).Length = 0 Then

        '            If vlDataTable.Select("ProductoClave='" & vlProductoUnidad.ProductoClave & "' AND TipoUnidad=" & vlProductoUnidad.PRUTipoUnidad).Length = 0 Then
        '                With grTransProdDetalle

        '                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        '                    .MoveToNewRecord()
        '                    'ObtenerProducto(vlProductoUnidad.ProductoClave, grTransProdDetalle)
        '                    With .GetRow
        '                        .Cells("ProductoClave").Value = vlProductoUnidad.ProductoClave
        '                        .Cells("Nombre").Value = vlProductoUnidad.Nombre
        '                        .Cells("TipoUnidad").Value = vlProductoUnidad.PRUTipoUnidad 'lCol.ValueList.Item(0).Value
        '                        .Cells("Cantidad").Value = 1
        '                    End With
        '                    .UpdateData()

        '                End With
        '                System.Windows.Forms.Application.DoEvents()
        '            End If

        '        End If
        '    Next

        '    grTransProdDetalle.Focus()
        'End If

        'Me.Cursor = System.Windows.Forms.Cursors.Default

        '--------------------------------------------------------------------------------
        'For Each vlProducto As ERMPROLOG.cProducto In vlArrayList
        'Dim lCol As New Janus.Windows.GridEX.GridEXColumn
        'lCol.HasValueList = True
        'Dim oProducto As New ERMPROLOG.cProducto
        'Dim aExcep() As String
        'oProducto.Recuperar(vlProducto.ProductoClave)
        'aExcep = oProducto.RegresaUnidades()
        'lbGeneral.LlenarColumna(lCol, "UNIDADV", , aExcep)
        'If lCol.ValueList.Count > 0 Then
        '    If vlDataTable.Select("ProductoClave='" & vlProducto.ProductoClave & "' AND TipoUnidad=" & lCol.ValueList.Item(0).Value).Length = 0 Then
        '        grTransProdDetalle.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        '        grTransProdDetalle.MoveToNewRecord()
        '        grTransProdDetalle.GetRow.Cells("ProductoClave").Value = vlProducto.ProductoClave
        '        ObtenerProducto(vlProducto.ProductoClave, grTransProdDetalle)
        '        grTransProdDetalle.GetRow.Cells("TipoUnidad").Value = lCol.ValueList.Item(0).Value
        '        grTransProdDetalle.GetRow.Cells("Cantidad").Value = 1
        '        grTransProdDetalle.UpdateData()
        '    End If
        'End If
        'Next
        'grTransProdDetalle.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
        '    grTransProdDetalle.Focus()
        'End If
    End Sub

    Private Sub grTransProdDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grTransProdDetalle.CellEdited
        Try

            Select Case e.Column.Key
               
                Case "Cantidad", "ProductoClave"
                    Dim oProducto As New ERMPROLOG.cProducto

                    If Not grTransProdDetalle.GetValue("ProductoClave") Is Nothing And grTransProdDetalle.GetValue("ProductoClave") <> "" Then
                        oProducto.Recuperar(grTransProdDetalle.GetValue("ProductoClave"))
                        'e.Value = Math.Round(e.Value, oProducto.DecimalProducto, MidpointRounding.AwayFromZero)
                        grTransProdDetalle.SetValue("Cantidad", Math.Round(IIf(grTransProdDetalle.GetValue("Cantidad") Is DBNull.Value, 0, grTransProdDetalle.GetValue("Cantidad")), 0, MidpointRounding.AwayFromZero))
                    End If
            End Select
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub grTransProdDetalle_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grTransProdDetalle.FirstChange
        bHuboCambios = True
        If (grTransProdDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            'If (oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo <> 9) Or oTransProd.Tipo = TipoTRP.Reclasificado Then
            btTPDEliminar.Enabled = True
            btTPDCrear.Enabled = True
            'End If
            grTransProdDetalle.SetValue("TransProdDetalleId", lbGeneral.cKeyGen.KEYGEN(0))
            'If IsNothing(grTransProdDetalle.CurrentColumn) = False Then
            '    If grTransProdDetalle.CurrentColumn.Key <> "Cantidad" Then
            '        grTransProdDetalle.GetRow.Cells("Cantidad").Value = 1
            '    End If
            'End If
        End If
    End Sub

    Private Sub grTransProdDetalle_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grTransProdDetalle.UpdatingCell
        If e.Column.Key = "ProductoClave" Then
            If IsNothing(e.Value) Or IsDBNull(e.Value) Then
                If Not IsNothing(e.InitialValue) AndAlso Not IsDBNull(e.InitialValue) Then
                    e.Value = e.InitialValue
                Else
                    e.Value = ""
                End If
            End If
            If e.Value = "" Then
                grTransProdDetalle.GetRow.Cells("Nombre").Value = ""
                Exit Sub
            End If
            If IsNothing(e.InitialValue) = False Then
                If LCase(e.Value) = LCase(e.InitialValue) Then
                    e.Value = grTransProdDetalle.GetValue("ProductoClave")
                    Exit Sub
                End If
            End If

            Try
                ObtenerProducto(e.Value, grTransProdDetalle)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                e.Value = e.InitialValue
                e.Cancel = True
                Exit Sub
            End Try
        ElseIf e.Column.Key = "Cantidad" Then
            If Not IsNothing(e.Value) And Not IsDBNull(e.Value) Then
                If tModo = eModo.Crear Then
                    If e.Value <= 0 Then
                        MsgBox(oMensaje.RecuperarDescripcion("E0012"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        e.Value = e.InitialValue
                        e.Cancel = True
                        Exit Sub
                    End If
                ElseIf tModo = eModo.Modificar Then
                    If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Or oTransProd.Tipo = TipoTRP.Sobrante Then
                        If e.Value <= 0 Then
                            MsgBox(oMensaje.RecuperarDescripcion("E0012"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            e.Value = e.InitialValue
                            e.Cancel = True
                            Exit Sub
                        End If
                    Else
                        If CDate(oTransProd.DiaClave) > oConexion.ObtenerFecha.Date Then
                            If e.Value <= 0 Then
                                MsgBox(oMensaje.RecuperarDescripcion("E0012"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                                e.Value = e.InitialValue
                                e.Cancel = True
                                Exit Sub
                            End If
                        Else
                            If e.Value < 0 Then
                                MsgBox(oMensaje.RecuperarDescripcion("E0007"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                                e.Value = e.InitialValue
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ValidarRow(ByVal pvRow As Janus.Windows.GridEX.GridEXRow)

        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In pvRow.Cells
            Select Case vlCelda.Column.Key
                Case "ProductoClave"
                    If IsNothing(vlCelda.Value) Or IsDBNull(vlCelda.Value) Then
                        vlCelda.Value = ""
                    End If
                    If vlCelda.Value = "" Then
                        grTransProdDetalle.GetRow.Cells("Nombre").Value = ""
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oMensaje.RecuperarDescripcion("XProducto"), False)})
                    End If
            End Select
        Next

    End Sub

    Private Sub grTransProdDetalle_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grTransProdDetalle.AddingRecord

        Try
            ValidarRow(grTransProdDetalle.GetRow)
            Call LlenarNulos(grTransProdDetalle)

            If BuscarTransProdDetalle(grTransProdDetalle.GetRow) Then
                MsgBox(oMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                e.Cancel = True
                Exit Sub
            End If


            Dim oTransProdDetalle As New ERMTRPLOG.cTransProdDetalle(oTransProd)
            oTransProdDetalle.TransProdDetalleID = lbGeneral.ChkDbNull(grTransProdDetalle.GetValue("TransProdDetalleID"))
            oTransProdDetalle.ProductoClave = lbGeneral.ChkDbNull(grTransProdDetalle.GetValue("ProductoClave"))
            oProducto.Recuperar(grTransProdDetalle.GetValue("ProductoClave"))

            Dim lcol As New Janus.Windows.GridEX.GridEXColumn
            lcol.HasValueList = True
            LlenarColumna(lcol, "UNIDADV", , oProducto.RegresaUnidades())
            oTransProdDetalle.TipoUnidad = lcol.ValueList(0).Value
            If grTransProdDetalle.GetRow().Cells("TipoUnidad").Value Is Nothing Or grTransProdDetalle.GetRow().Cells("TipoUnidad").Value.GetType.ToString = "" Then
                grTransProdDetalle.GetRow().Cells("TipoUnidad").Value = lcol.ValueList(0).Value
            End If

            oTransProdDetalle.Cantidad = lbGeneral.ChkDbNull(grTransProdDetalle.GetValue("Cantidad"))
            oTransProdDetalle.Partida = 0
            oTransProdDetalle.Precio = 0
            oTransProdDetalle.Subtotal = 0
            oTransProdDetalle.Total = 0
            oTransProdDetalle.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
            If oTransProd.Tipo = TipoTRP.Reclasificado Then
                Dim nCantidad As Integer
                If Not oTransProdDetalle.ValidarCantidadMax(Me.ebUSUId.Text, Me.ebDiaClave.Text, Me.cbAlmacen.SelectedValue, nCantidad) Then
                    MsgBox(oMensaje.RecuperarDescripcion("E0571", New String() {grTransProdDetalle.GetValue("Nombre"), nCantidad}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            oTransProdDetalle.Insertar(New String() {"TransProdDetalleID", "ProductoClave", "TipoUnidad", "Cantidad", "Precio", "Subtotal", "Total"})
            oTransProd.TransProdDetalle.Insertar(oTransProdDetalle)

            'If oTransProd.Tipo = TipoTRP.Reclasificado Then
            '    ebDiaClave.Enabled = False
            '    cbAlmacen.Enabled = False
            '    btBuscarVendedor.Enabled = False
            'End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            Exit Sub
        End Try
    End Sub

    Private Sub grTransProdDetalle_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grTransProdDetalle.RecordAdded
        If (grTransProdDetalle.Focused = False) Then
            Call DeshabilitaCrear(grTransProdDetalle)
        End If
    End Sub

    Private Sub grTransProdDetalle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grTransProdDetalle.SelectionChanged
        With grTransProdDetalle
            Select Case (tModo)
                Case eModo.Crear
                    .RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .RootTable.Columns("TipoUnidad").EditType = Janus.Windows.GridEX.EditType.DropDownList
                Case eModo.Modificar
                    Dim lvFecha As Date
                    If oTransProd.Tipo = TipoTRP.Sobrante Then
                        lvFecha = oTransProd.FechaHoraAlta
                    Else
                        lvFecha = oTransProd.DiaClave
                    End If
                    If Convert.ToDateTime(lvFecha, Globalization.CultureInfo.CreateSpecificCulture("ES-MX")) > oConexion.ObtenerFecha.Date Then
                        .RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.TextBox
                        .RootTable.Columns("TipoUnidad").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    Else
                        If Not (.GetRow Is Nothing) Then
                            If (.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                                .RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.TextBox
                                .RootTable.Columns("TipoUnidad").EditType = Janus.Windows.GridEX.EditType.DropDownList
                            Else
                                If .GetRow.DataRow.Row.RowState = DataRowState.Added Then
                                    .RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.TextBox
                                    .RootTable.Columns("TipoUnidad").EditType = Janus.Windows.GridEX.EditType.DropDownList
                                Else
                                    .RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                                    .RootTable.Columns("TipoUnidad").EditType = Janus.Windows.GridEX.EditType.NoEdit
                                End If
                            End If
                        End If
                    End If

                Case eModo.Leer
                    .RootTable.Columns("ProductoClave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    .RootTable.Columns("TipoUnidad").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    .RootTable.Columns("Cantidad").EditType = Janus.Windows.GridEX.EditType.NoEdit
            End Select
        End With

        If grTransProdDetalle.RowCount > 0 And tModo = eModo.Crear Then
            btTPDEliminar.Enabled = True
        ElseIf grTransProdDetalle.RowCount > 0 And tModo = eModo.Modificar Then
            If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then
                btTPDEliminar.Enabled = True
            Else
                Dim vlFecha As Date
                If oTransProd.Tipo = TipoTRP.Sobrante Then
                    vlFecha = oTransProd.FechaHoraAlta
                Else
                    vlFecha = oTransProd.DiaClave
                End If
                If Convert.ToDateTime(vlFecha, Globalization.CultureInfo.CreateSpecificCulture("ES-MX")) > oConexion.ObtenerFecha.Date Then
                    btTPDEliminar.Enabled = True
                Else
                    If (grTransProdDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                        btTPDEliminar.Enabled = False
                    Else
                        If grTransProdDetalle.GetRow.DataRow.Row.RowState = DataRowState.Added Then 'And ((oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo <> 9) Or oTransProd.Tipo = TipoTRP.Reclasificado) Then
                            btTPDEliminar.Enabled = True
                        Else
                            btTPDEliminar.Enabled = False
                        End If
                    End If
                End If
                End If
        Else
                btTPDEliminar.Enabled = False
        End If
    End Sub

    Private Sub grTransProdDetalle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grTransProdDetalle.Leave
        Call DeshabilitaCrear(grTransProdDetalle)
    End Sub

    Private Sub grTransProdDetalle_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grTransProdDetalle.UpdatingRecord
        Call LlenarNulos(grTransProdDetalle)

        Try
            If grTransProdDetalle.GetValue("ProductoClave") = "" Then
                MsgBox(oMensaje.RecuperarDescripcion("BE0001", New String() {oMensaje.RecuperarDescripcion("TPDProductoClave")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                e.Cancel = True
                Exit Sub
            End If

            If BuscarTransProdDetalle(grTransProdDetalle.GetRow) Then
                Throw New LbControlError.cError("BE0002")
            End If

            oTransProd.TransProdDetalle(CType(grTransProdDetalle.GetValue("TransProdDetalleId"), String)).ProductoClave = grTransProdDetalle.GetValue("ProductoClave")
            oTransProd.TransProdDetalle(CType(grTransProdDetalle.GetValue("TransProdDetalleId"), String)).TipoUnidad = grTransProdDetalle.GetValue("TipoUnidad")
            oTransProd.TransProdDetalle(CType(grTransProdDetalle.GetValue("TransProdDetalleId"), String)).Cantidad = grTransProdDetalle.GetValue("Cantidad")

            oTransProd.TransProdDetalle(CType(grTransProdDetalle.GetValue("TransProdDetalleId"), String)).ValidarCampos(New String() {"ProductoClave", "TipoUnidad", "Cantidad"})
            If oTransProd.Tipo = TipoTRP.Reclasificado Then
                Dim nCantidad As Integer
                If Not oTransProd.TransProdDetalle(CType(grTransProdDetalle.GetValue("TransProdDetalleId"), String)).ValidarCantidadMax(Me.ebUSUId.Text, Me.ebDiaClave.Text, Me.cbAlmacen.SelectedValue, nCantidad) Then
                    MsgBox(oMensaje.RecuperarDescripcion("E0571", New String() {grTransProdDetalle.GetValue("Nombre"), nCantidad}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
        End Try
    End Sub

    Private Sub grTransProdDetalle_CancelingRowEdit(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grTransProdDetalle.CancelingRowEdit
        e.Cancel = True
    End Sub

    Private Sub grTransProdDetalle_EditingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EditingCellEventArgs) Handles grTransProdDetalle.EditingCell
        Dim lCol As New Janus.Windows.GridEX.GridEXColumn
        lCol.HasValueList = True
        Try

            Select Case e.Column.Key
                Case "TipoUnidad"
                    Dim oProducto As New ERMPROLOG.cProducto
                    Dim aExcep() As String
                    If Not grTransProdDetalle.GetValue("ProductoClave") Is Nothing And grTransProdDetalle.GetValue("ProductoClave") <> "" Then
                        oProducto.Recuperar(grTransProdDetalle.GetValue("ProductoClave"))
                        aExcep = oProducto.RegresaUnidades()
                        lbGeneral.LlenarColumna(lCol, "UNIDADV", , aExcep)
                        e.Column.EditValueList = lCol.ValueList
                    Else
                        e.Column.EditValueList = New Janus.Windows.GridEX.GridEXValueListItemCollection
                    End If
              
            End Select
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try

    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Dim bCambioTRP As Boolean = False

        Me.DialogResult = Windows.Forms.DialogResult.None
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If oTransProd.Tipo = TipoTRP.Sobrante Then
            Me.ebUSUId.Text = lbGeneral.cParametros.UsuarioID
        End If
        If tModo = eModo.Modificar Then
            Dim oTransProd2 As New ERMTRPLOG.cTransProd
            oTransProd2.Recuperar(oTransProd.TransProdID)
            With oTransProd2
                If .TipoFase <> Me.cbTipoFase.SelectedValue Then bCambioTRP = True
                If .Tipo = TipoTRP.Sobrante Then
                    If .FechaHoraAlta <> Me.ebDiaClave.Text Then bCambioTRP = True
                Else
                    If .DiaClave <> Me.ebDiaClave.Text Then bCambioTRP = True
                End If
                If .Notas <> Me.cbAlmacen.SelectedValue Then bCambioTRP = True
                If .Tabla.Campos("MUsuarioId").Valor <> Me.ebUSUId.Text Then bCambioTRP = True
                If .PCEModuloMovDetClave <> cbPCEModuloMovDetClave.SelectedValue Then bCambioTRP = True
            End With
        End If

        With oTransProd
            .Folio = Me.ebFolio.Text
            .TipoFase = Me.cbTipoFase.SelectedValue
            If oTransProd.Tipo = TipoTRP.Sobrante Then
                .FechaHoraAlta = Format(Me.ebDiaClave.Value.Date, "dd/MM/yyyy")
                .FechaCaptura = oConexion.ObtenerFecha
            Else
                .DiaClave = Format(Me.ebDiaClave.Value.Date, "dd/MM/yyyy")
                .FechaCaptura = Me.ebDiaClave.Value.Date
            End If

            .Notas = Me.cbAlmacen.SelectedValue
            .Tabla.Campos("MUsuarioId").Valor = Me.ebUSUId.Text

            If .Tipo = TipoTRP.Carga Then
                .PCEModuloMovDetClave = cbPCEModuloMovDetClave.SelectedValue
            End If
        End With

        Try
            Dim aCampos() As String = {"Folio", "TipoFase", "DiaClave", "Notas", "PCEModuloMovDetClave"}
            oTransProd.ValidarClase(aCampos)
        Catch ex As LbControlError.cError
            Me.Cursor = System.Windows.Forms.Cursors.Default
            ex.Mostrar()
            PonerFoco(ex.Source)
            oConexion.DeshacerTran()
            Exit Sub
        End Try

        If oTransProd.Tipo = TipoTRP.Carga Or oTransProd.Tipo = TipoTRP.Reclasificado Or oTransProd.Tipo = TipoTRP.Sobrante Then
            If IsNothing(cbAlmacen.SelectedValue) Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox(oMensaje.RecuperarDescripcion("BE0001", New String() {lbAlmacen.Text}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                cbAlmacen.Focus()
                Exit Sub
            End If

            If ebUSUId.Text = "" Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox(oMensaje.RecuperarDescripcion("BE0001", New String() {lbVendedor.Text}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                btBuscarVendedor.Focus()
                Exit Sub
            End If
        End If

        If oTransProd.Tipo = TipoTRP.Carga Then
            If IsNothing(cbPCEModuloMovDetClave.SelectedValue) Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox(oMensaje.RecuperarDescripcion("BE0001", New String() {lbPCEModuloMovDetClave.Text}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                cbAlmacen.Focus()
                Exit Sub
            End If
        End If


        Select Case tModo
            Case eModo.Crear
                'oTransProd.MUsuarioID = MUsuarioID
                If ebFolio.Text <> "" Then
                    If oTransProd.ExisteFolio(ebFolio.Text) Then
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                        MsgBox(oMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        ebFolio.Focus()
                        Exit Sub
                    End If
                End If

                If ebDiaClave.Text <> "" Then
                    If oTransProd.Tipo = TipoTRP.Carga Then
                        If CDate(ebDiaClave.Text) < oConexion.ObtenerFecha.Date Then
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            MsgBox(oMensaje.RecuperarDescripcion("E0066"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            ebDiaClave.Focus()
                            Exit Sub
                        End If
                    ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
                        If Not oTransProd.FechaSobrantesValida(CDate(Me.ebDiaClave.Text), cbAlmacen.SelectedValue) Then
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            MsgBox(oMensaje.RecuperarDescripcion("E0724"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            ebDiaClave.Focus()
                            Exit Sub
                        End If
                    Else
                        If CDate(ebDiaClave.Text) > oConexion.ObtenerFecha.Date Then
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            MsgBox(oMensaje.RecuperarDescripcion("E0087", New String() {oMensaje.RecuperarDescripcion("XFechaDiaTrabajo")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            ebDiaClave.Focus()
                            Exit Sub
                        End If
                    End If
                    Dim oDia As New ERMDIALOG.CDiaTrabajo
                    If oTransProd.Tipo <> TipoTRP.Sobrante Then
                        If Not oDia.Existe(ebDiaClave.Text) Then
                            oDia.DiaClave = ebDiaClave.Text
                            oDia.Referencia = " "
                            oDia.Estado = "1"
                            oDia.FechaCaptura = ebDiaClave.Text
                            oDia.MFechaHora = Date.Now.ToString("s")
                            oDia.MUsuarioID = oTransProd.MUsuarioID
                            oDia.Insertar()
                            oDia.Grabar()
                        End If
                    End If
                End If

                If grTransProdDetalle.RowCount = 0 Then
                    Dim sDescripcion As String
                    If oTransProd.Tipo = TipoTRP.Carga Then
                        sDescripcion = "XCarga"
                    ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
                        sDescripcion = "XRegistroSobrantes"
                    Else
                        sDescripcion = "XReclasificado"
                    End If

                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    MsgBox(oMensaje.RecuperarDescripcion("E0044", New String() {oMensaje.RecuperarDescripcion(sDescripcion)}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    btTPDCrear.Focus()
                    Exit Sub
                End If

                Try
                    With oTransProd
                        .TransProdID = lbGeneral.cKeyGen.KEYGEN(0)
                        '.Tipo = 2
                        .TipoMovimiento = 1
                        If oTransProd.Tipo <> TipoTRP.Sobrante Then
                            .FechaHoraAlta = oConexion.ObtenerFecha
                        End If

                        '.FechaCaptura = oConexion.ObtenerFecha
                        .Total = 0
                        .Saldo = 0
                    End With

                    oTransProd.Insertar()

                    Dim htTipoUnidad As New Hashtable
                    For Each lItem As cTransProdDetalle In oTransProd.TransProdDetalle.ToArrayList
                        If Not htTipoUnidad.ContainsKey(lItem.TipoUnidad) Then
                            htTipoUnidad.Add(lItem.TipoUnidad, 0)
                        End If
                        htTipoUnidad(lItem.TipoUnidad) += 1
                        lItem.Partida = htTipoUnidad(lItem.TipoUnidad)
                        lItem.Tabla.Campos("MUsuarioId").Valor = oTransProd.MUsuarioID
                    Next

                    oTransProd.Grabar()
                    If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then
                        oTransProd.GrabarCargaAutomatica()
                    End If
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    oConexion.DeshacerTran()
                    Exit Sub
                End Try
            Case eModo.Modificar
                Try
                    'If oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9 Then 'Carga automatica
                    '    If oTransProd.TipoFase = 0 Then
                    '        oTransProd.CancelarCargaAutomatica()
                    '    End If
                    'Else
                    If ebDiaClave.Text <> "" Then
                        If oTransProd.Tipo = TipoTRP.Carga Then
                            If oTransProd.TipoMotivo <> 9 And CDate(ebDiaClave.Text) < oConexion.ObtenerFecha.Date Then
                                Me.Cursor = System.Windows.Forms.Cursors.Default
                                MsgBox(oMensaje.RecuperarDescripcion("E0066"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                                ebDiaClave.Focus()
                                Exit Sub
                            End If
                        ElseIf oTransProd.Tipo = TipoTRP.Sobrante Then
                            If Not oTransProd.FechaSobrantesValida(CDate(Me.ebDiaClave.Text), cbAlmacen.SelectedValue) Then
                                Me.Cursor = System.Windows.Forms.Cursors.Default
                                MsgBox(oMensaje.RecuperarDescripcion("E0724"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                                ebDiaClave.Focus()
                                Exit Sub
                            End If
                        Else
                            If CDate(ebDiaClave.Text) > oConexion.ObtenerFecha.Date Then
                                Me.Cursor = System.Windows.Forms.Cursors.Default
                                MsgBox(oMensaje.RecuperarDescripcion("E0087", New String() {oMensaje.RecuperarDescripcion("XFechaDiaTrabajo")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                                ebDiaClave.Focus()
                                Exit Sub
                            End If
                        End If

                        If oTransProd.Tipo <> TipoTRP.Sobrante Then
                            Dim oDia As New ERMDIALOG.CDiaTrabajo
                            If Not oDia.Existe(ebDiaClave.Text) Then
                                oDia.DiaClave = ebDiaClave.Text
                                oDia.Referencia = " "
                                oDia.Estado = "1"
                                oDia.FechaCaptura = ebDiaClave.Text
                                oDia.MFechaHora = Date.Now.ToString("s")
                                oDia.MUsuarioID = oTransProd.MUsuarioID
                                oDia.Insertar()
                                oDia.Grabar()
                            End If
                        End If
                    End If

                    If grTransProdDetalle.RowCount = 0 Then
                        If oTransProd.Tipo = TipoTRP.Carga Then
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            MsgBox(oMensaje.RecuperarDescripcion("E0044", New String() {oMensaje.RecuperarDescripcion("XCarga")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Else
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            MsgBox(oMensaje.RecuperarDescripcion("E0044", New String() {oMensaje.RecuperarDescripcion("XReclasificado")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        End If
                        btTPDCrear.Focus()
                        Exit Sub
                    End If

                    If oTransProd.Tipo = TipoTRP.Carga Then
                        If (Convert.ToDateTime(oTransProd.DiaClave, Globalization.CultureInfo.CreateSpecificCulture("ES-MX")) > oConexion.ObtenerFecha.Date) Or (oTransProd.Tipo = TipoTRP.Carga And oTransProd.TipoMotivo = 9) Then
                            For Each lItem As cTransProdDetalle In oTransProd.TransProdDetalle.ToArrayList
                                If lItem.Cantidad <= 0 Then
                                    Me.Cursor = System.Windows.Forms.Cursors.Default
                                    MsgBox(oMensaje.RecuperarDescripcion("E0012"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                                    Exit Sub
                                End If
                            Next
                        End If
                    End If

                    If oTransProd.Tipo = TipoTRP.Reclasificado Then
                        Dim nCantidad As Integer
                        Dim sProducto As String = ""
                        If Not oTransProd.TransProdDetalle.ValidarCantidades(Me.ebUSUId.Text, Me.ebDiaClave.Text, Me.cbAlmacen.SelectedValue, sProducto, nCantidad) Then
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            Dim oProd As New ERMPROLOG.cProducto
                            oProd.Recuperar(sProducto)
                            MsgBox(oMensaje.RecuperarDescripcion("E0571", New String() {oProd.Nombre, nCantidad}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            grTransProdDetalle.Focus()
                            Exit Sub
                        End If
                    End If

                    Dim htTipoUnidad As New Hashtable
                    For Each lItem As cTransProdDetalle In oTransProd.TransProdDetalle.ToArrayList
                        If lItem.Status <> BASLOG.eEstado.Recuperado Then
                            If Not htTipoUnidad.ContainsKey(lItem.TipoUnidad) Then
                                htTipoUnidad.Add(lItem.TipoUnidad, 0)
                            End If
                            htTipoUnidad(lItem.TipoUnidad) += 1
                            lItem.Partida = htTipoUnidad(lItem.TipoUnidad)
                            lItem.Tabla.Campos("MUsuarioId").Valor = oTransProd.MUsuarioID
                        End If
                    Next

                    If bModificarTransProd Then
                        If bCambioTRP Then
                            For Each lItem As cTransProdDetalle In oTransProd.TransProdDetalle.ToArrayList
                                If lItem.Status <> BASLOG.eEstado.Eliminado Then
                                    lItem.Total = lItem.Total
                                End If
                            Next
                        End If
                        oTransProd.Grabar()
                    Else
                        Dim nCont As Integer = 0
                        Dim nTotal As Integer = oTransProd.TransProdDetalle.Count
                        While nCont < nTotal
                            Dim oItem As cTransProdDetalle
                            oItem = oTransProd.TransProdDetalle.ToArrayList(nCont)
                            If oItem.Status <> BASLOG.eEstado.Recuperado Then
                                If oItem.Status <> BASLOG.eEstado.Eliminado Then
                                    nCont += 1
                                Else
                                    nTotal -= 1
                                End If
                                oItem.Grabar()
                            Else
                                nCont += 1
                            End If
                        End While
                    End If
                    'End If

                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    oConexion.DeshacerTran()
                    Exit Sub
                End Try
        End Select
        Me.Cursor = System.Windows.Forms.Cursors.Default

        Me.DialogResult = Windows.Forms.DialogResult.OK
        bCerrar = True
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bCerrar And bHuboCambios Then
            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(oMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub
#End Region


    Private Sub MCargas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If tModo = eModo.Leer Then BtCancelar.Focus()
    End Sub

End Class
