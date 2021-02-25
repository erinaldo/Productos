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
    Friend WithEvents btModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGeneral))
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btModificar, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.BuiltInTextsData = ""
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        Me.GridEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'btModificar
        '
        Me.btModificar.DisabledImage = CType(resources.GetObject("btModificar.DisabledImage"), System.Drawing.Image)
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.SubItemsExpandWidth = 11
        Me.btModificar.Text = "Modificar"
        '
        'btActualizar
        '
        Me.btActualizar.DisabledImage = CType(resources.GetObject("btActualizar.DisabledImage"), System.Drawing.Image)
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.SubItemsExpandWidth = 11
        Me.btActualizar.Text = "Actualizar"
        '
        'NGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.Name = "NGeneral"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared vgInstance As NGeneral = Nothing

    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcDataTable As DataTable
    Private vcUsuarioID As String
    Private vcMensaje As New BASMENLOG.CMensaje
    Private vcSubEmpresa As New ERMSEMLOG.cSubEmpresa
    Private vcAcceso As LbAcceso.cAcceso

    Public Shared Function Instance() As NGeneral
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New NGeneral
        End If
        Return vgInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        vcConexion = LbConexion.cConexion.Instancia
        vcAcceso = pvAcceso
        vcUsuarioID = pvAcceso.MUsuarioId
        Me.Show()
    End Sub

    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        lbGeneral.cParametros.UsuarioID = "Admin"
        'lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\Sql2008R2;user id=sa;password='Amesol11.';initial catalog=RouteSK")
        vcMensaje = New BASMENLOG.CMensaje
        vcMensaje.LlenarDataSet()
        vcSubEmpresa = New ERMSEMLOG.cSubEmpresa
        vcAcceso = New LbAcceso.cAcceso
        vcUsuarioID = "Admin"

        vcAcceso = New LbAcceso.cAcceso
        vcAcceso.Crear = True
        vcAcceso.Eliminar = True
        vcAcceso.Modificar = True
        vcAcceso.Leer = True
#End If
        Try
            lbGeneral.LlenarConfiguracionGrid("ERMSEMESC", "NGeneral", GridEx1, "SubEmpresa")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarTodayButton) = vcMensaje.RecuperarDescripcion("XAhora")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarNoneButton) = vcMensaje.RecuperarDescripcion("XNinguna")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.RecordNavigator) = vcMensaje.RecuperarDescripcion("XRegistroDe")

        'btNuevo.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
        btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("btActualizar")


        GridEx1.RootTable.Columns("NombreEmpresa").Caption = vcMensaje.RecuperarDescripcion("SEMNombreEmpresa")

        GridEx1.RootTable.Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("SEMTipoEstado")

        GridEx1.RootTable.Columns("RFC").Caption = vcMensaje.RecuperarDescripcion("SEMRFC")



        GridEx1.RootTable.Columns("NombreEmpresa").HeaderToolTip = vcMensaje.RecuperarDescripcion("SEMNombreEmpresaT")

        GridEx1.RootTable.Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("SEMTipoEstadoT")

        GridEx1.RootTable.Columns("RFC").HeaderToolTip = vcMensaje.RecuperarDescripcion("SEMRFCT")


        Me.Text = vcMensaje.RecuperarDescripcion("ERMSEMESC_NGeneral")

        'If Not vcAcceso.Crear Then
        '    btNuevo.Enabled = False
        'End If
        If Not vcAcceso.Modificar And Not vcAcceso.Leer Then
            btModificar.Enabled = False
        End If
        If vcAcceso.Leer And Not vcAcceso.Modificar Then

            btModificar.Tooltip = vcMensaje.RecuperarDescripcion("xconsultar")
            btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")

        End If

        Call Actualizar()

    End Sub

    Private Sub Actualizar()

        lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoEstado"), "EDOREG")
        vcDataTable = vcSubEmpresa.Tabla.Recuperar("")
        GridEx1.DataSource = vcDataTable
        GridEx1.DataMember = "SubEmpresa"
    End Sub

    Private Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim vlMGeneral As New MGeneral
        Try
            vcSubEmpresa.Limpiar()
            If vlMGeneral.CREAR(vcSubEmpresa, vcUsuarioID) Then
                vcSubEmpresa.InsertarEn(GridEx1.DataSource)
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub Modificar()
        Dim vlMGeneral As New MGeneral
        If (Not GridEx1.GetRow Is Nothing) Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "SubEmpresa" Then
                Try
                    vcSubEmpresa.Recuperar(GridEx1.GetRow.Cells("SubEmpresaId").Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    vcSubEmpresa.Bloquear(vcUsuarioID)
                Catch ex As LbControlError.cError
                    vcConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try
                Dim bLogo As Boolean = False
                If vlMGeneral.MODIFICAR(vcSubEmpresa, vcUsuarioID) = True Then 'Aceptar
                    vcSubEmpresa.ModificarEn(GridEx1.DataSource)
                End If
            End If
        End If
    End Sub
    Private Sub Consultar()
        Dim vlMGeneral As New MGeneral

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "SubEmpresa" Then
            Try
                vcSubEmpresa.Recuperar(GridEx1.GetRow.Cells("SubEmpresaId").Value)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Sub
            End Try

            Try
                vcSubEmpresa.Bloquear(vcUsuarioID)
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try
            vlMGeneral.Consultar(vcSubEmpresa, vcUsuarioID)

        End If
    End Sub
    Private Sub btModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btModificar.Click
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

    Private Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid("ERMSEMESC", "NGeneral", GridEx1, "SubEmpresa")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub
End Class
