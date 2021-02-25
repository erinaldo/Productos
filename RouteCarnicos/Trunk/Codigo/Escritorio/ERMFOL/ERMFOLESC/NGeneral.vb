Imports ERMFOLLOG
Imports BASMENLOG
Public Class NGeneral
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
    Friend WithEvents BtActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGeneral))
        Me.BtCrear = New DevComponents.DotNetBar.ButtonItem
        Me.BtModificar = New DevComponents.DotNetBar.ButtonItem
        Me.BtActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtCrear, Me.BtModificar, Me.BtActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
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
        'BtActualizar
        '
        Me.BtActualizar.DisabledImage = CType(resources.GetObject("BtActualizar.DisabledImage"), System.Drawing.Image)
        Me.BtActualizar.Icon = CType(resources.GetObject("BtActualizar.Icon"), System.Drawing.Icon)
        Me.BtActualizar.Name = "BtActualizar"
        Me.BtActualizar.SubItemsExpandWidth = 11
        Me.BtActualizar.Text = "BtActualizar"
        '
        'NGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.DoubleBuffered = True
        Me.Name = "NGeneral"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared vgInstance As NGeneral = Nothing

    Public vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Public vcAcceso As New LbAcceso.cAcceso
    Public vcFolio As cFolio
    Public vcDtFOL As New DataTable
    Public vcMensaje As CMensaje

    Public Shared Function Instance() As NGeneral
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New NGeneral
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
            'vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\sql2008;user id=sa;password=dbsa;initial catalog=floriculturanew")
            vcConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.72\sql2008;user id=sa;password=dbsa;initial catalog=jolla2")
            lbGeneral.cParametros.UsuarioID = "Admin"
            vcAcceso.MUsuarioId = "Admin"
            'lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
            'vcAcceso.MUsuarioId = "26PKB2C2AHNRELF"
            vcMensaje = New BASMENLOG.CMensaje
            vcMensaje.LlenarDataSet()
            vcFolio = New cFolio
            vcAcceso.Crear = True
            vcAcceso.Eliminar = True
            vcAcceso.Modificar = True
            vcAcceso.Leer = True
#End If



            Me.Text = vcMensaje.RecuperarDescripcion("ERMFOLESC_NGeneral")

            vcFolio = New cFolio
            vcDtFOL = vcFolio.Tabla.Recuperar("Fiscal <> 1", " FolioID, Descripcion,TipoEstado ")

            GridEx1.ClearStructure()
            GridEx1.DataSource = vcDtFOL
            GridEx1.DataMember = "Folio"
            GridEx1.RetrieveStructure(True)

            ConfigurarGrid()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub ConfigurarGrid()

        Try
            lbGeneral.LlenarConfiguracionGrid("ERMFOLESC", "NGeneral", GridEx1, "Folio")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

        BtCrear.Tooltip = vcMensaje.RecuperarDescripcion("BTCrearT")
        BtModificar.Tooltip = vcMensaje.RecuperarDescripcion("BTModificarT")
        BtActualizar.Tooltip = vcMensaje.RecuperarDescripcion("BTActualizarT")

        With GridEx1.RootTable
            .Columns("FolioID").Visible = False
            .Columns("FolioID").ShowInFieldChooser = False

            .Columns("Descripcion").Width = 400

            .Columns("TipoEstado").Width = 100
            .Columns("TipoEstado").HasValueList = True
            .Columns("TipoEstado").EditType = Janus.Windows.GridEX.EditType.DropDownList
        End With

        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.RecordNavigator) = vcMensaje.RecuperarDescripcion("XREGISTRODE")

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In GridEx1.RootTable.Columns
            vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOL" & vlColumna.Key)
            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOL" & vlColumna.Key & "T")
            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Next

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

        LlenarCombos()
    End Sub

    Private Sub LlenarCombos()
        lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoEstado"), "EDOREG")
    End Sub

    Private Sub BtCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCrear.Click
        Dim vlMante As New MGeneral

        vcFolio.Limpiar()
        If vlMante.CREAR(vcFolio, vcAcceso.MUsuarioId) = True Then 'Aceptar
            Try
                vcFolio.Grabar()
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try
            vcConexion.ConfirmarTran()

            vcFolio.InsertarEn(vcDtFOL)

        End If
    End Sub

    Private Sub Modificar()
        Dim vlMante As New MGeneral

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcFolio.Recuperar(GridEx1.GetRow.Cells("FolioID").Value)

            Try
                vcFolio.Bloquear(vcAcceso.MUsuarioId)
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try

            If vlMante.MODIFICAR(vcFolio, vcAcceso.MUsuarioId) = True Then 'Aceptar
                Try
                    vcFolio.Grabar()
                Catch ex As LbControlError.cError
                    vcConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try
                vcConexion.ConfirmarTran()

                vcFolio.ModificarEn(vcDtFOL)
            End If
        End If
    End Sub
    Private Sub Consultar()
        Dim vlMante As New MGeneral

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcFolio.Recuperar(GridEx1.GetRow.Cells("FolioID").Value)
            vlMante.Consultar(vcFolio, vcAcceso.MUsuarioId)


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
        If vcAcceso.Modificar Then
            Call Modificar()
        Else
            If vcAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtActualizar.Click
        Try
            Dim vlFolio As New cFolio
            vcDtFOL = vlFolio.Tabla.Recuperar("", " FolioID, Descripcion,TipoEstado ")

            GridEx1.DataSource = vcDtFOL
            LlenarCombos()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid("ERMFOLESC", "NGeneral", GridEx1, "Folio")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub
End Class
