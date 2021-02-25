Public Class NGENERAL
    Inherits FormasBase.Browse01

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents btCrear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGENERAL))
        Me.btCrear = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCrear, Me.btModificar, Me.btActualizar})
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
        'btCrear
        '
        Me.btCrear.DisabledImage = CType(resources.GetObject("btCrear.DisabledImage"), System.Drawing.Image)
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.SubItemsExpandWidth = 11
        '
        'btModificar
        '
        Me.btModificar.DisabledImage = CType(resources.GetObject("btModificar.DisabledImage"), System.Drawing.Image)
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.SubItemsExpandWidth = 11
        Me.btModificar.Text = "ButtonItem2"
        '
        'btActualizar
        '
        Me.btActualizar.DisabledImage = CType(resources.GetObject("btActualizar.DisabledImage"), System.Drawing.Image)
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.SubItemsExpandWidth = 11
        '
        'NGENERAL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.Name = "NGENERAL"
        Me.Text = "Mantener Clientes"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private Shared vgInstance As NGENERAL = Nothing

    Public vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Public vcAcceso As New LbAcceso.cAcceso
    Public vcMensaje As BASMENLOG.CMensaje
    Public vcCliente As ERMCLILOG.cCliente
    Public vcDataSet As New DataSet
#End Region

#Region "Métodos y Funciones"
    Public Shared Function Instance() As NGENERAL
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New NGENERAL
        End If
        Return vgInstance
    End Function

    Sub Inicio(ByRef peAcceso As LbAcceso.cAcceso)
        vcAcceso = peAcceso
        vcMensaje = New BASMENLOG.CMensaje
        vcCliente = New ERMCLILOG.cCliente

        Me.Show()
    End Sub

    Private Sub ConfigurarGrid()
        Try
            lbGeneral.LlenarConfiguracionGrid("ERMCLIESC", "NGeneral", GridEx1, "Cliente")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarTodayButton) = vcMensaje.RecuperarDescripcion("XAhora")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarNoneButton) = vcMensaje.RecuperarDescripcion("XNinguna")
        GridEx1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.RecordNavigator) = vcMensaje.RecuperarDescripcion("XRegistroDe")

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In GridEx1.RootTable.Columns
            vlColumna.Caption = vcMensaje.RecuperarDescripcion("CLI" + vlColumna.Key)
            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("CLI" + vlColumna.Key + "T")
            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Next

        btCrear.Tooltip = vcMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = vcMensaje.RecuperarDescripcion("btModificar")
        btActualizar.Tooltip = vcMensaje.RecuperarDescripcion("btActualizar")

        If Not vcAcceso.Crear Then
            btCrear.Enabled = False
        End If
        If Not vcAcceso.Modificar And Not vcAcceso.Leer Then
            btModificar.Enabled = False
        End If
        If vcAcceso.Leer And Not vcAcceso.Modificar Then

            btModificar.Tooltip = vcMensaje.RecuperarDescripcion("xconsultar")

            btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")

        End If

    End Sub

    Private Sub Modificar()
        Dim vlMante As New MGENERAL

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "Cliente" Then
            vcCliente = New ERMCLILOG.cCliente()
            vcCliente.Recuperar(GridEx1.GetRow.Cells("ClienteClave").Value)
            Try
                vcCliente.Bloquear(vcAcceso.MUsuarioId)
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try

            'blokear sus secuencias***********************************
            Dim loSecuencia As New ERMSECLOG.cSecuencia
            Dim ldt As New DataTable
            ldt = loSecuencia.Tabla.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(GridEx1.GetRow.Cells("ClienteClave").Value) & "'")

            For Each ldr As DataRow In ldt.Rows
                loSecuencia.Limpiar()

                Try
                    loSecuencia.Recuperar(ldr("SecId"))
                    loSecuencia.Bloquear(vcAcceso.MUsuarioId)
                Catch ex As LbControlError.cError
                    vcConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try


            Next
            '********************************************************

            If vlMante.MODIFICAR(vcCliente, vcAcceso.MUsuarioId) = True Then 'Aceptar
                vcCliente.ModificarEn(GridEx1.DataSource.Tables("Cliente"))
            Else
                vcConexion.DeshacerTran()
            End If
        End If
    End Sub
    Private Sub Consultar()
        Dim vlMante As New MGENERAL

        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) And GridEx1.GetRow.Table.Key = "Cliente" Then
            vcCliente = New ERMCLILOG.cCliente()
            vcCliente.Recuperar(GridEx1.GetRow.Cells("ClienteClave").Value)

            vlMante.Consultar(vcCliente, vcAcceso.MUsuarioId)

        End If
    End Sub

    Private Sub Actualizar()
        vcDataSet.Clear()
        vcDataSet = vcCliente.dsDatos.Recuperar("")
        GridEx1.DataSource = vcDataSet
        GridEx1.DataMember = "Cliente"
        lbGeneral.LlenarColumna(GridEx1.RootTable.Columns("TipoEstado"), "EDOREG")
    End Sub
#End Region


#Region "Eventos"
    Private Sub Browse01_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then

        If Not vcConexion.Estado = ConnectionState.Open Then

            vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\sql2005;user id=sa;password=Amesol11.;initial catalog=SKBase")
        End If

        vcMensaje = New BASMENLOG.CMensaje

        lbGeneral.cParametros.UsuarioID = "Admin"
        'lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        Dim oKeyGen As New lbGeneral.cKeyGen
        vcAcceso.MUsuarioId = "Admin"
        vcCliente = New ERMCLILOG.cCliente

        vcAcceso.Crear = True
        vcAcceso.Eliminar = True
        vcAcceso.Modificar = True
        vcAcceso.Leer = True

        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal

#End If


        vcMensaje.LlenarDataSet()
        Me.Text = vcMensaje.RecuperarDescripcion("ERMCLIESC_NGeneral")

        Call ConfigurarGrid()
        Call Actualizar()
    End Sub

    Private Sub BtCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCrear.Click
        Dim vlMante As New MGENERAL

        vcCliente = New ERMCLILOG.cCliente()
        'vcConexion.IniciarTran()
        If vlMante.CREAR(vcCliente, vcAcceso.MUsuarioId) = True Then 'Aceptar
            vcCliente.InsertarEn(GridEx1.DataSource.Tables("Cliente"))
        Else
            vcConexion.DeshacerTran()
        End If
    End Sub

    Private Sub BtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btModificar.Click
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

    Private Sub BtActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActualizar.Click
        Call Actualizar()
        'Dim frmBrowse As New ERMCLIESC.IPuntosEntrega(True, 2, "FREC-002", "Ruta A", True)
        'frmBrowse.StartPosition = FormStartPosition.CenterParent
        'frmBrowse.ShowDialog()
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid("ERMCLIESC", "NGeneral", GridEx1, "Cliente")
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub
#End Region

    'Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frmBrowse As New ERMCLIESC.IPuntosEntrega(True, 2, "mie", "101", False, "'000000000127','000000000125','000000000137','000000003304','000000001115','000000000975','000000003315'", "'000000000127','000000000125','000000000137','000000003304','000000001115','000000000975','000000003315'")
    '    frmBrowse.StartPosition = FormStartPosition.CenterParent
    '    frmBrowse.ShowDialog()

    'End Sub
End Class