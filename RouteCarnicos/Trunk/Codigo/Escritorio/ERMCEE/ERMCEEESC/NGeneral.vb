Imports BASMENLOG
Imports ERMCEELOG

Public Class NGENERAL
    Inherits FormasBase.Browse01

    Public vcConexion As LbConexion.cConexion
    Public vgDataSet As New DataSet
    Public frmMGeneral As New MGeneral
    Public vcUsuarioID As String

    Public vcMensaje As CMensaje
    Dim vlCentroExp As New CCentroExp


    Public Shared vlMatriz As slMatriz
    Public oAcceso As LbAcceso.cAcceso


    Public Structure slMatriz

        Dim MatrizID As String

        Dim MatrizNombre As String

        Dim SubEmpresa As String

    End Structure

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
    Friend btEliminar As DevComponents.DotNetBar.ButtonItem
    Friend btnNuevo As DevComponents.DotNetBar.ButtonItem

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btNuevo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizr As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGENERAL))
        Me.btNuevo = New DevComponents.DotNetBar.ButtonItem
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizr = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btNuevo, Me.btModificar, Me.btnEliminar, Me.btActualizr})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        Me.GridEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEx1.GroupByBoxVisible = False
        Me.GridEx1.SettingsKey = "GridEx1"
        '
        'btNuevo
        '
        Me.btNuevo.DisabledImage = CType(resources.GetObject("btNuevo.DisabledImage"), System.Drawing.Image)
        Me.btNuevo.Icon = CType(resources.GetObject("btNuevo.Icon"), System.Drawing.Icon)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.SubItemsExpandWidth = 11
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.SubItemsExpandWidth = 11
        '
        'btModificar
        '
        Me.btModificar.DisabledImage = CType(resources.GetObject("btModificar.DisabledImage"), System.Drawing.Image)
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.SubItemsExpandWidth = 11
        '
        'btActualizr
        '
        Me.btActualizr.DisabledImage = CType(resources.GetObject("btActualizr.DisabledImage"), System.Drawing.Image)
        Me.btActualizr.Icon = CType(resources.GetObject("btActualizr.Icon"), System.Drawing.Icon)
        Me.btActualizr.Name = "btActualizr"
        Me.btActualizr.SubItemsExpandWidth = 11
        Me.btActualizr.Text = "btActualizar"
        '
        'NGENERAL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.Name = "NGENERAL"
        Me.Text = "Centros de Expedicion"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared oInstance As NGENERAL = Nothing

    '    Public Shared Sub Instance()
    '        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
    '            Dim MyThread As System.Threading.Thread
    '            MyThread = New System.Threading.Thread(AddressOf LaunchInstance)
    '            MyThread.SetApartmentState(Threading.ApartmentState.STA)
    '            MyThread.Start()
    '            MyThread.Join()
    '        Else
    '            Call LaunchInstance()
    '        End If
    '    End Sub

    '    Public Shared Sub LaunchInstance()
    '        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
    '            oInstance = New NGeneral
    '        End If
    '        oInstance.BringToFront()

    '#If DEBUG Then
    '        oInstance.ShowDialog()
    '#End If
    '    End Sub

    Public Shared Function Instance() As NGENERAL
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New NGENERAL
        End If
        Return oInstance
    End Function

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        oAcceso = pvAcceso
        oAcceso.MUsuarioId = "Admin"
        vcMensaje = New BASMENLOG.CMensaje
        Me.Show()
    End Sub

    Private Sub NGENERAL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If DEBUG Then
        If Not LbConexion.cConexion.Instancia.Estado = ConnectionState.Open Then
            LbConexion.cConexion.Instancia.Conectar("Provider=SQLOLEDB.1;Data Source=localhost\Sql2008R2;user id=sa;password=Amesol11.;initial catalog=RouteSK")
        End If
        oAcceso = New LbAcceso.cAcceso
        'oAcceso.MUsuarioId = "Admin"
        'lbGeneral.cParametros.UsuarioID = "Admin"
        lbGeneral.cParametros.UsuarioID = "Admin"
        oAcceso.MUsuarioId = "Admin"
        oAcceso.Crear = True
        oAcceso.Eliminar = False
        oAcceso.Modificar = True
        oAcceso.Leer = True
#End If



        Carga_Grid()


        GridEx1.FilterMode = Janus.Windows.GridEX.FilterMode.Manual





    End Sub

    Public Sub Carga_Grid()
        Try


            vcMensaje = New CMensaje
            vcMensaje.LlenarDataSet()
            '********************************************************************************************
            'AQUI AGREGA EL USUARIO DEBE USAR LA CLASE DE GETDATOS
            vcUsuarioID = oAcceso.MUsuarioId
            '**********************************************************************************
            Me.Text = vcMensaje.RecuperarDescripcion("ERMCEEESC_NGeneral")

            GridEx1.ClearStructure()

            GridEx1.SetDataBinding(vlCentroExp.DataSet.RecuperarTreeDataSet("").Tables(0), "esquemaRaiz")
            GridEx1.Hierarchical = True
            GridEx1.RetrieveStructure(True)

            Dim vlTbls As Janus.Windows.GridEX.GridEXTable
            vlTbls = GridEx1.RootTable

            For vlCont As Integer = 0 To 0

                vlTbls.ChildTables(0).DataMember = "SubCentroExp" & vlCont
                Ocultar_Columnas(vlTbls)
                vlTbls = vlTbls.ChildTables(0)

            Next

            Dim vlToolTip As New System.Windows.Forms.ToolTip

            btNuevo.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
            btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
            btnEliminar.Tooltip = vcMensaje.RecuperarDescripcion("btEliminarT")
            btActualizr.Tooltip = vcMensaje.RecuperarDescripcion("btActualizarT")

            If Not oAcceso.Crear Then
                btNuevo.Enabled = False
            End If
            If Not oAcceso.Eliminar Then
                btnEliminar.Enabled = False
            End If
            If Not oAcceso.Modificar And Not oAcceso.Leer Then
                btModificar.Enabled = False
            End If
            If oAcceso.Leer And Not oAcceso.Modificar Then

                btModificar.Tooltip = vcMensaje.RecuperarDescripcion("xconsultar")

                btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")
            End If
            Ocultar_Columnas(vlTbls)
            ConfigurarGrid()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception

            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
        If GridEx1.RootTable.ChildTables.Count > 0 Then GridEx1.RootTable.ChildTables(0).FilterParentRows = True

    End Sub

    Private Sub btActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActualizr.Click
        Call Carga_Grid()
    End Sub
    Private Sub Ocultar_Columnas(ByVal vlTblGrid As Janus.Windows.GridEX.GridEXTable)

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn

        With vlTblGrid

            .Columns("CentroExpPadreID").Visible = False
            .Columns("SubEmpresaId").Visible = False


            .Columns("CentroExpPadreID").ShowInFieldChooser = False
            .Columns("SubEmpresaId").ShowInFieldChooser = False

            For Each vlColumna In vlTblGrid.Columns

                vlColumna.Caption = vcMensaje.RecuperarDescripcion("CEE" + vlColumna.Key)
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("CEE" + vlColumna.Key + "T")
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center

                If vlColumna.Key = "NombreEmpresa" Then
                    vlColumna.Caption = vcMensaje.RecuperarDescripcion("CEESubEmpresa")
                    vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("CEESubEmpresaT")
                End If
            Next

            .Columns("Nombre").Width = 200

            .Columns("TipoEstado").HasValueList = True
            .Columns("TipoEstado").EditType = Janus.Windows.GridEX.EditType.DropDownList


            LlenarTipoEstado(vlTblGrid)


        End With

    End Sub

    Private Sub ConfigurarGrid()

        Try
            For Each vlTable As Janus.Windows.GridEX.GridEXTable In GridEx1.Tables
                lbGeneral.LlenarConfiguracionGrid("ERMCEEESC", "NGeneral", GridEx1, vlTable.Key)
            Next

            For Each vlTable As Janus.Windows.GridEX.GridEXTable In GridEx1.Tables
                vlTable.Caption = vlTable.Key
            Next
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

    End Sub

    Private Sub LlenarTipoEstado(ByVal vlTbl As Janus.Windows.GridEX.GridEXTable)
        Try
            lbGeneral.LlenarColumna(vlTbl.Columns("TipoEstado"), "EDOREG")
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    'Private Sub LlenarTipo(ByVal vlTbl As Janus.Windows.GridEX.GridEXTable)
    '    Try
    '        lbGeneral.LlenarColumna(vlTbl.Columns("Tipo"), "TESQUEMA")
    '    Catch ex As LbControlError.cError
    '        ex.Mostrar()
    '    End Try
    'End Sub

    Private Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Try
            Dim vlCentroExp As New CCentroExp
            frmMGeneral = Nothing
            frmMGeneral = New MGeneral

            If GridEx1.GetRow Is Nothing Then
                vlMatriz = New slMatriz
            Else
                If IsDBNull(GridEx1.GetRow.Cells("CentroExpPadreID").Value) OrElse GridEx1.GetRow.Cells("CentroExpPadreID").Value = "" Then

                    With vlMatriz
                        .MatrizID = GridEx1.GetRow.Cells("CentroExpID").Value

                        .MatrizNombre = GridEx1.GetRow.Cells("Nombre").Value

                        .SubEmpresa = GridEx1.GetRow.Cells("SubEmpresaId").Value
                    End With
                Else
                    vlMatriz = New slMatriz
                End If

            End If

            If frmMGeneral.CREAR(vlCentroExp, vcUsuarioID, vlMatriz) Then

                Carga_Grid()

            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
    End Sub

    Private Sub btModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btModificar.Click
        If GridEx1.RowCount = 0 Then Exit Sub
        If GridEx1.GetRow.Cells("CentroExpID").Value = "-1" Then Exit Sub
        If oAcceso.Modificar Then
            Call Modificar()
        Else
            If oAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub Consultar()
        Try
            Dim vlCentroExpID As String = ""
            Dim frmMGeneral As New MGeneral
            Dim vlCentroExp As New CCentroExp




            If GridEx1.RecordCount <= 0 Then
                Exit Sub
            End If

            If GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                vlCentroExpID = GridEx1.GetRow.Cells("CentroExpID").Value()
            Else
                Exit Sub
            End If

            If Not vlCentroExp.Recuperar(vlCentroExpID) Then
                Dim vlError As New LbControlError.cError("BF0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Esquema")})
                vlError.Mostrar()
                Exit Sub
            End If

            If frmMGeneral.Consultar(vlCentroExp, vcUsuarioID) Then
                Carga_Grid()
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

    End Sub
    Private Sub Modificar()
        Try
            Dim vlCentroExpID As String = ""
            Dim frmMGeneral As New MGeneral
            Dim vlCentroExp As New CCentroExp




            If GridEx1.RecordCount <= 0 Then
                Exit Sub
            End If

            If GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                vlCentroExpID = GridEx1.GetRow.Cells("CentroExpID").Value()
            Else
                Exit Sub
            End If

            If Not vlCentroExp.Recuperar(vlCentroExpID) Then
                Dim vlError As New LbControlError.cError("BF0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Esquema")})
                vlError.Mostrar()
                Exit Sub
            End If

            If frmMGeneral.MODIFICAR(vlCentroExp, vcUsuarioID) Then
                Carga_Grid()
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

    End Sub

    Private Sub GridEX1_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEx1.RowDoubleClick
        If GridEx1.RowCount = 0 Then Exit Sub

        If oAcceso.Modificar Then
            Call Modificar()
        Else
            If oAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim vlCentroExp As New CCentroExp

            If GridEx1.RowCount > 0 Then

                If GridEx1.GetRow.Cells("EsquemaID").Value = "-1" Then Exit Sub

                If vlCentroExp.DataSet.ExisteEsquemaProducto(GridEx1.GetRow.Cells("EsquemaID").Value) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0116"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    Exit Sub
                End If

                If MsgBox(vcMensaje.RecuperarDescripcion("P0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then

                    'Actualizar..el boton de Baja y Refrecar el Grid

                    Dim strEsquemaID As String
                    strEsquemaID = GridEx1.GetRow.Cells("EsquemaID").Value
                    vcConexion.Instancia.EjecutarComando("Update Esquema set Baja=1 where EsquemaID='" & strEsquemaID.Replace("'", "''") & "'")
                    vcConexion.Instancia.ConfirmarTran()
                    Carga_Grid()

                End If

            End If
        Catch exc As LbControlError.cError
            exc.Mostrar()
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            For Each vlTable As Janus.Windows.GridEX.GridEXTable In GridEx1.Tables
                lbGeneral.GrabarConfiguracionGrid("ERMCEEESC", "NGeneral", GridEx1, vlTable.Key)
            Next
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub
    Private filtroCentroExpID, filtronombre, filtroRFC, filtroMunicipio, filtroNumCertificado, filtroEntidad, filtroEstado, filtroSubEmpresa As String

    ''EVENTO DE FILTRO APLICADO AL GRID
    Private Sub Gridex1_ApplyingFilter(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridEx1.ApplyingFilter


        Try
            vlCentroExp = Nothing
            vlCentroExp = New CCentroExp

            filtroCentroExpID = GridEx1.FilterRow.Cells("CentroExpID").Text
            filtronombre = GridEx1.FilterRow.Cells("Nombre").Text
            filtroRFC = GridEx1.FilterRow.Cells("RFC").Text
            filtroMunicipio = GridEx1.FilterRow.Cells("Municipio").Text
            filtroEntidad = GridEx1.FilterRow.Cells("Entidad").Text
            filtroSubEmpresa = GridEx1.FilterRow.Cells("NombreEmpresa").Text

            If IsNothing(GridEx1.FilterRow.Cells("TipoEstado").Value()) Then
                If GridEx1.FilterRow.Cells("TipoEstado").Text = "" Then
                    filtroEstado = ""
                End If
            Else
                filtroEstado = GridEx1.FilterRow.Cells("TipoEstado").Value
            End If




            If (filtroCentroExpID = Nothing And filtronombre = Nothing And filtroEntidad = Nothing And filtroRFC = Nothing And filtroEntidad = Nothing And filtroEstado = Nothing And filtroMunicipio = Nothing And filtroSubEmpresa = Nothing) Then
                GridEx1.SetDataBinding(vlCentroExp.DataSet.RecuperarTreeDataSet("").Tables(0), "")
            Else
                GridEx1.SetDataBinding(vlCentroExp.DataSet.RecuperarTreeDataSetFiltroGridex("", filtroCentroExpID, filtronombre, filtroRFC, filtroNumCertificado, filtroSubEmpresa, filtroMunicipio, filtroEntidad, filtroEstado).Tables(0), "")
            End If



            Dim vlTbls As Janus.Windows.GridEX.GridEXTable
            vlTbls = GridEx1.RootTable

            For vlCont As Integer = 0 To vlCentroExp.DataSet.MaxEsquemas

                vlTbls.ChildTables(0).DataMember = "SubCentroExp" & vlCont
                Ocultar_Columnas(vlTbls)
                vlTbls = vlTbls.ChildTables(0)

            Next



            Ocultar_Columnas(vlTbls)
            ConfigurarGrid()




        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception

            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try



    End Sub
End Class
