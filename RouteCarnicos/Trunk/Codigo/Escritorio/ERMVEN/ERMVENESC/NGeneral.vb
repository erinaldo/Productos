Imports BASMENLOG
Imports ERMVENLOG

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
    Friend WithEvents btEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGeneral))
        Me.btNuevo = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btEliminar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btNuevo, Me.btModificar, Me.btEliminar, Me.btActualizar})
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
        'btEliminar
        '
        Me.btEliminar.DisabledImage = CType(resources.GetObject("btEliminar.DisabledImage"), System.Drawing.Image)
        Me.btEliminar.Icon = CType(resources.GetObject("btEliminar.Icon"), System.Drawing.Icon)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.SubItemsExpandWidth = 11
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
        Me.Name = "NGeneral"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared vgInstance As NGeneral = Nothing

    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcDtVendedor As DataTable
    Private vcUsuarioID As String
    Private vcMensaje As CMensaje
    Private vcVendedor As cVendedor
    Private vcAcceso As LbAcceso.cAcceso

    Public Shared Function Instance() As NGeneral
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New NGeneral
        End If

        vgInstance.BringToFront()
        Return vgInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        vcUsuarioID = pvAcceso.MUsuarioId
        vcAcceso = pvAcceso
        vcMensaje = New CMensaje
        vcVendedor = New cVendedor
        Me.Show()
    End Sub

    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
#If DEBUG Then
            'lbGeneral.cParametros.UsuarioID = "Admin"
            vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\sqlExpress2005;user id=sa;password=Amesol11.;initial catalog=RouteSK")

            vcMensaje = New BASMENLOG.CMensaje
            vcMensaje.LlenarDataSet()
            vcVendedor = New cVendedor
            vcAcceso = New LbAcceso.cAcceso
            'vcUsuarioID = "Admin"
            lbGeneral.cParametros.UsuarioID = "Admin"
            'lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
            vcUsuarioID = "Admin"
            vcAcceso = New LbAcceso.cAcceso
            vcAcceso.Crear = True
            vcAcceso.Eliminar = True
            vcAcceso.Modificar = True
            vcAcceso.Leer = True
#End If
            Me.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_NGeneral")

            btNuevo.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
            btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
            btEliminar.Tooltip = vcMensaje.RecuperarDescripcion("btEliminar")
            btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("btActualizar")

            vcDtVendedor = vcVendedor.RecuperarGrid()
            GridEx1.DataSource = vcDtVendedor
            GridEx1.DataMember = "Vendedor"
            ConfigurarGrid()
            checarHabilitados()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try
        Bar1.Refresh()
    End Sub

    Private Sub checarHabilitados()
        If GridEx1.RowCount = 0 Then
            btModificar.Enabled = False
            btEliminar.Enabled = False
        Else
            btModificar.Enabled = True
            btEliminar.Enabled = True
        End If
        If Not vcAcceso.Crear Then
            btNuevo.Enabled = False
        End If
        If Not vcAcceso.Modificar And Not vcAcceso.Leer Then
            btModificar.Enabled = False
        End If
        If vcAcceso.Leer And Not vcAcceso.Modificar Then

            btModificar.Tooltip = vcMensaje.RecuperarDescripcion("xconsultar")
            btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")

        End If
        If Not vcAcceso.Eliminar Then
            btEliminar.Enabled = False
        End If
    End Sub


    Private Sub ConfigurarGrid()
        Try
            lbGeneral.LlenarConfiguracionGrid("ERMVENESC", "NGeneral", GridEx1, "Vendedor")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In GridEx1.RootTable.Columns
            If vlColumna.Key = "CEDI" Then
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("XCEDI")
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("Xcentrodistribucion")

            ElseIf vlColumna.Key = "Usuario" Then
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("XUsuario")
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("XUsuarios")

            Else
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("VEN" + vlColumna.Key)
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("VEN" + vlColumna.Key + "T")

            End If
            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Next
        Try
            lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoEstado"), "EDOREG")
            lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("Tipo"), "TVEND")
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try

        btNuevo.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
        btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("btActualizar")
        btEliminar.Tooltip = vcMensaje.RecuperarDescripcion("btEliminar")
    End Sub

    Private Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Dim vlMGeneral As New MGeneral
        Try
            Dim vlVendedor As New cVendedor

            'vcConexion.IniciarTran()
            If vlMGeneral.CREAR(vlVendedor, vcUsuarioID) Then
                vlVendedor.InsertarEn(GridEx1.DataSource)
                checarHabilitados()
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
        Dim vlVendedor As New cVendedor

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "Vendedor" Then
            Try
                vlVendedor.Recuperar(GridEx1.GetRow.Cells("VendedorId").Value)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Sub
            End Try

            If vlVendedor.Baja = False Then
                'vcConexion.IniciarTran()
                Try
                    vlVendedor.Bloquear(vcUsuarioID)
                Catch ex As LbControlError.cError
                    vcConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try
                If vlMGeneral.MODIFICAR(vlVendedor, vcUsuarioID) = True Then 'Aceptar
                    vlVendedor.ModificarEn(GridEx1.DataSource)
                    checarHabilitados()
                End If
            Else
                vlMGeneral.LEER(vlVendedor, vcUsuarioID)
            End If
        End If
    End Sub

    Private Sub Consultar()
        Dim vlMGeneral As New MGeneral
        Dim vlVendedor As New cVendedor

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "Vendedor" Then
            Try
                vlVendedor.Recuperar(GridEx1.GetRow.Cells("VendedorId").Value)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Sub
            End Try

            
                vlMGeneral.LEER(vlVendedor, vcUsuarioID)

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
        lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoEstado"), "EDOREG")
        lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("Tipo"), "TVEND")
        vcDtVendedor = vcVendedor.RecuperarGrid()
        GridEx1.DataSource = vcDtVendedor
        GridEx1.DataMember = "Vendedor"
        'checarHabilitados()
    End Sub

    Private Sub btEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        Dim vlMGeneral As New MGeneral
        Dim vlVendedor As New cVendedor

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "Vendedor" Then
            vlVendedor.Recuperar(GridEx1.GetRow.Cells("VendedorId").Value)
            If vlVendedor.Baja = True Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0048"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Sub
            End If

            If vlMGeneral.CargasPorTransferir(vlVendedor) Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0529"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Sub
            End If

            If vlVendedor.TieneFoliosAsignados Then
                If Not MsgBox(vcMensaje.RecuperarDescripcion("P0114"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If
            'vcConexion.IniciarTran()
            Try
                vlVendedor.Bloquear(vcUsuarioID)
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try
            If vlMGeneral.ELIMINAR(vlVendedor, vcUsuarioID) = True Then 'Aceptar
                vlVendedor.ModificarEn(GridEx1.DataSource)
                checarHabilitados()
            End If
        End If
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid("ERMVENESC", "NGeneral", GridEx1, "Vendedor")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub

End Class
