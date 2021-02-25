Imports BASMENLOG
Imports ERMTERLOG

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
    Friend WithEvents btNuevo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGeneral))
        Me.btNuevo = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btNuevo, Me.btModificar, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        '
        'btNuevo
        '
        Me.btNuevo.DisabledImage = CType(resources.GetObject("btNuevo.DisabledImage"), System.Drawing.Image)
        Me.btNuevo.Icon = CType(resources.GetObject("btNuevo.Icon"), System.Drawing.Icon)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.SubItemsExpandWidth = 11
        '
        'btModificar
        '
        Me.btModificar.DisabledImage = CType(resources.GetObject("btModificar.DisabledImage"), System.Drawing.Image)
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.SubItemsExpandWidth = 11
        '
        'btActualizar
        '
        Me.btActualizar.DisabledImage = CType(resources.GetObject("btActualizar.DisabledImage"), System.Drawing.Image)
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.SubItemsExpandWidth = 11
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
    Private vcAcceso As LbAcceso.cAcceso
    Public vcConexion As LbConexion.cConexion
    Public vcDtTerminal As DataTable
    Public vcUsuarioID As String
    Public vcMensaje As CMensaje

    Public Shared Function Instance() As NGeneral
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New NGeneral
        End If

        Return vgInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        vcConexion = LbConexion.cConexion.Instancia
        vcUsuarioID = pvAcceso.MUsuarioId
        vcAcceso = pvAcceso
        Me.Show()

    End Sub

    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
#If DEBUG Then
            vcConexion = LbConexion.cConexion.Instancia
            vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\SQL2005;user id=sa;password='Amesol11.';initial catalog=RouteSK")
            vcUsuarioID = "Admin"
            vcMensaje = New CMensaje
            vcMensaje.LlenarDataSet()
            vcAcceso = New LbAcceso.cAcceso
            vcAcceso.Crear = True
            vcAcceso.Eliminar = True
            vcAcceso.Modificar = True
            vcAcceso.Leer = True
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
#End If

            vcMensaje = New CMensaje

            Me.Text = vcMensaje.RecuperarDescripcion("ERMTERESC_NGeneral")

            btNuevo.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
            btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
            btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("btActualizar")
            Dim vlTerminal As New ERMTERLOG.cTerminal
            vcDtTerminal = vlTerminal.Tabla.Recuperar("")

            GridEx1.ClearStructure()
            GridEx1.DataSource = vcDtTerminal
            GridEx1.DataMember = "Terminal"
            GridEx1.RetrieveStructure()

            ConfigurarGrid()

            If Not vcAcceso.Crear Then
                btNuevo.Enabled = False
            End If
            If Not vcAcceso.Modificar And Not vcAcceso.Leer Then
                btModificar.Enabled = False
            End If
            If vcAcceso.Leer And Not vcAcceso.Modificar Then

                btModificar.Tooltip = vcMensaje.RecuperarDescripcion("xconsultar")

                Try
                    btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")
                Catch ex As Exception

                End Try

            End If

            

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

    End Sub

    Private Sub ConfigurarGrid()
        Try
            lbGeneral.LlenarConfiguracionGrid("ERMTERESC", "NGeneral", GridEx1, "Terminal")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

        With GridEx1.RootTable
            .Columns("MFechaHora").Visible = False
            .Columns("MUsuarioID").Visible = False
            .Columns("Comentario").Visible = False
            .Columns("MFechaHora").ShowInFieldChooser = False
            .Columns("MUsuarioID").ShowInFieldChooser = False
            .Columns("Comentario").ShowInFieldChooser = False
            .Columns("TerminalClave").Width = 100
            .Columns("TipoFase").HasValueList = True
            .Columns("TipoFase").EditType = Janus.Windows.GridEX.EditType.DropDownList
            .Columns("TipoFase").Width = 140
            .Columns("TipoFase").Position = 3
            .Columns("Descripcion").Width = 410
            .Columns("NumeroSerie").Width = 140
        End With

        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")

        btNuevo.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
        btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("btActualizar")

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In GridEx1.RootTable.Columns
            vlColumna.Caption = vcMensaje.RecuperarDescripcion("TER" + vlColumna.Key)
            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("TER" + vlColumna.Key + "T")
            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Next
        LlenarColTipoFase()
    End Sub

    Private Sub LlenarColTipoFase()
        Try
            lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoFase"), "TERFASE")
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Dim vlMGeneral As New MGeneral
        Try
            Dim vlTerminal As New cTerminal

            If vlMGeneral.CREAR(vlTerminal, vcUsuarioID) Then
                vlTerminal.Tabla.InsertarEn(vcDtTerminal)
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub
    Private Sub Consultar()
        Dim vlMGeneral As New MGeneral
        Dim vlTerminalClave As String = ""
        Try
            Dim vlTerminal As New cTerminal

            If GridEx1.RecordCount <= 0 Then
                Exit Sub
            End If

            If GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                vlTerminalClave = GridEx1.GetRow.Cells("TerminalClave").Value()
            Else
                Exit Sub
            End If

            If Not vlTerminal.Recuperar(vlTerminalClave) Then
                Dim vlError As New LbControlError.cError("BF0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Terminal")})
                vlError.Mostrar()
                Exit Sub
            End If

            vlMGeneral.Consultar(vlTerminal, vcUsuarioID)
            
        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub
    Private Sub Modificar()
        Dim vlMGeneral As New MGeneral
        Dim vlTerminalClave As String = ""
        Try
            Dim vlTerminal As New cTerminal

            If GridEx1.RecordCount <= 0 Then
                Exit Sub
            End If

            If GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                vlTerminalClave = GridEx1.GetRow.Cells("TerminalClave").Value()
            Else
                Exit Sub
            End If

            If Not vlTerminal.Recuperar(vlTerminalClave) Then
                Dim vlError As New LbControlError.cError("BF0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Terminal")})
                vlError.Mostrar()
                Exit Sub
            End If

            If vlMGeneral.MODIFICAR(vlTerminal, vcUsuarioID) Then
                vlTerminal.Tabla.ModificarEn(vcDtTerminal)
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
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
        Dim vlTerminal As New cTerminal
        Try
            vcDtTerminal = vlTerminal.Tabla.Recuperar("")
            GridEx1.DataSource = vcDtTerminal
            LlenarColTipoFase()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid("ERMTERESC", "NGeneral", GridEx1, "Terminal")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub
End Class
