Imports ERMFOLLOG
Imports BASMENLOG
Imports ERMFOLLOG.Amesol

Public Class NFoliosFiscales
    Inherits FormasBase.Browse01

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
    Friend WithEvents BtCrear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NFoliosFiscales))
        Me.BtCrear = New DevComponents.DotNetBar.ButtonItem
        Me.BtModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtCrear, Me.BtModificar, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        Me.GridEx1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BtCrear
        '
        Me.BtCrear.DisabledImage = CType(resources.GetObject("BtCrear.DisabledImage"), System.Drawing.Image)
        Me.BtCrear.Icon = CType(resources.GetObject("BtCrear.Icon"), System.Drawing.Icon)
        Me.BtCrear.Name = "BtCrear"
        Me.BtCrear.SubItemsExpandWidth = 11
        '
        'BtModificar
        '
        Me.BtModificar.DisabledImage = CType(resources.GetObject("BtModificar.DisabledImage"), System.Drawing.Image)
        Me.BtModificar.Icon = CType(resources.GetObject("BtModificar.Icon"), System.Drawing.Icon)
        Me.BtModificar.Name = "BtModificar"
        Me.BtModificar.SubItemsExpandWidth = 11
        '
        'btActualizar
        '
        Me.btActualizar.DisabledImage = CType(resources.GetObject("btActualizar.DisabledImage"), System.Drawing.Image)
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Text = "btActualizar"
        '
        'NFoliosFiscales
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.DoubleBuffered = True
        Me.Name = "NFoliosFiscales"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared vgInstance As NFoliosFiscales = Nothing
    Public vcMensaje As CMensaje
    Public vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Public vcAcceso As New LbAcceso.cAcceso
    Public vcFolio As cFolio

#Region "FUNCIONES GENERALES"

    Public Shared Function Instance() As NFoliosFiscales
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New NFoliosFiscales
        End If
        Return vgInstance
    End Function

    Sub Inicio(ByRef peAcceso As LbAcceso.cAcceso)
        vcAcceso = peAcceso
        vcMensaje = New CMensaje
        vcFolio = New cFolio
        Me.Show()
    End Sub

    Private Sub Browse01_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
#If DEBUG Then
            'vcConexion.Conectar("Provider=SQLOLEDB.1;Data Source=localhost\sqlexpress;user id=sa;password='dbsa';initial catalog=lactigurt2.31.1.0")
            vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\Sql2005;user id=sa;password=Amesol11.;initial catalog=SKPruebas")
            'lbGeneral.cParametros.UsuarioID = "Admin"
            'vcAcceso.MUsuarioId = "Admin"
            lbGeneral.cParametros.UsuarioID = "Admin"
            vcAcceso.MUsuarioId = "Admin"
            vcMensaje = New BASMENLOG.CMensaje
            vcMensaje.LlenarDataSet()
            vcAcceso.Crear = True
            vcAcceso.Eliminar = True
            vcAcceso.Modificar = True
            vcAcceso.Leer = True
#End If

            vcFolio = New cFolio
            configurarTitulos()
            CONSULTA()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub configurarTitulos()
        Me.Text = vcMensaje.RecuperarDescripcion("ERMFOLESC_NFoliosFiscales")
        BtCrear.Tooltip = vcMensaje.RecuperarDescripcion("BTCrearT")
        BtModificar.Tooltip = vcMensaje.RecuperarDescripcion("BTModificarT")
        btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("BTActualizarT")

        With Me.GridEx1.RootTable
            .Columns("FolioID").Caption = vcMensaje.RecuperarDescripcion("XFolio")
            .Columns("Descripcion").Caption = vcMensaje.RecuperarDescripcion("FOLDescripcion")
            .Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("FOLTipoEstado")

            .Columns("FolioID").HeaderToolTip = vcMensaje.RecuperarDescripcion("XFolio")
            .Columns("Descripcion").HeaderToolTip = vcMensaje.RecuperarDescripcion("FOLDescripcionT")
            .Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("FOLTipoEstadoT")

        End With
        Me.GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")

        If Not vcAcceso.Crear Then
            BtCrear.Enabled = False
        End If

        If Not vcAcceso.Modificar And Not vcAcceso.Leer Then
            BtModificar.Enabled = False
        End If

        If vcAcceso.Leer And Not vcAcceso.Modificar Then
            BtModificar.Tooltip = vcMensaje.RecuperarDescripcion("xconsultar")
            BtModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")
        End If
    End Sub

    Private Sub CONSULTA()
        Dim vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
        Dim ldtFoliosFiscales As DataTable
        Dim lsConsulta As String = "SELECT FolioId, Descripcion, TipoEstado FROM folio WHERE Fiscal = 1"

        Try

            GridEx1.DataSource = Nothing
            GridEx1.DataMember = Nothing
            ldtFoliosFiscales = vcConexion.EjecutarConsulta(lsConsulta)

            GridEx1.DataSource = ldtFoliosFiscales
            GridEx1.DataMember = "FoliosFiscales"

            Me.GridEx1.RootTable.RemoveFilter()
            GridEx1.UpdateData()
            LlenarCombos()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub LlenarCombos()
        lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoEstado"), "EDOREG")
    End Sub

    Private Sub Modificar()
        If GridEx1.RowCount <= 0 Then Exit Sub

        Dim vlMante As New MFoliosFiscales

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcFolio.Recuperar(GridEx1.GetRow.Cells("FolioID").Value)

            Try
                vcFolio.Bloquear(vcAcceso.MUsuarioId)
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try
            vlMante.Mensajes = vcMensaje
            If vlMante.MODIFICAR(vcFolio, vcAcceso.MUsuarioId) = True Then 'Aceptar
                Try
                    vcFolio.Grabar()
                Catch ex As LbControlError.cError
                    vcConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try
                vcConexion.ConfirmarTran()

                vcFolio.ModificarEn(Me.GridEx1.DataSource)
            End If
        End If
    End Sub

    Private Sub Consultar()
        Dim vlMante As New MFoliosFiscales

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcFolio.Recuperar(GridEx1.GetRow.Cells("FolioID").Value)
            vlMante.Mensajes = vcMensaje
            vlMante.Consultar(vcFolio, vcAcceso.MUsuarioId)
        End If
    End Sub

#End Region

#Region "BOTONES"
    Private Sub BtCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCrear.Click
        Dim vlMante As New MFoliosFiscales

        vcFolio.Limpiar()
        vlMante.Mensajes = vcMensaje
        If vlMante.CREAR(vcFolio, vcAcceso.MUsuarioId) = True Then 'Aceptar
            Try
                vcFolio.Grabar()
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try
            vcConexion.ConfirmarTran()

            vcFolio.InsertarEn(Me.GridEx1.DataSource)

        End If
    End Sub

    Private Sub BtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtModificar.Click
        If vcAcceso.Modificar Then
            Call Modificar()
        Else
            If vcAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub GridEX1_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEx1.RowDoubleClick
        BtModificar_Click(Nothing, Nothing)

    End Sub

    Private Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btActualizar.Click

        CONSULTA()
    End Sub

#End Region

End Class
