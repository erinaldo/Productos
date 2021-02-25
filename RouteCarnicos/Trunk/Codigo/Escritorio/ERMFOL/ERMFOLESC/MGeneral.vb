Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports ERMFOLLOG
Imports BASMENLOG

Public Enum eModo
    Crear = 1
    Modificar
    Eliminar
    Leer
End Enum

Public Class MGeneral
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
    Friend WithEvents lbDescripcion As System.Windows.Forms.Label
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbValorInicial As System.Windows.Forms.Label
    Friend WithEvents cbTipoEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbTipoEstado As System.Windows.Forms.Label
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents btEliminarDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCrearDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebValorInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MGeneral))
        Dim GridDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.lbDescripcion = New System.Windows.Forms.Label
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbValorInicial = New System.Windows.Forms.Label
        Me.cbTipoEstado = New Janus.Windows.EditControls.UIComboBox
        Me.lbTipoEstado = New System.Windows.Forms.Label
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox
        Me.btEliminarDetalle = New Janus.Windows.EditControls.UIButton
        Me.btCrearDetalle = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ebValorInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(440, 268)
        Me.BtAceptar.TabIndex = 14
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(552, 268)
        Me.BtCancelar.TabIndex = 15
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(8, 248)
        Me.lbLinea.Size = New System.Drawing.Size(641, 2)
        Me.lbLinea.TabIndex = 27
        Me.lbLinea.Visible = False
        '
        'lbDescripcion
        '
        Me.lbDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lbDescripcion.Location = New System.Drawing.Point(9, 12)
        Me.lbDescripcion.Name = "lbDescripcion"
        Me.lbDescripcion.Size = New System.Drawing.Size(132, 20)
        Me.lbDescripcion.TabIndex = 1
        Me.lbDescripcion.Text = "Descripcion"
        Me.lbDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDescripcion
        '
        Me.ebDescripcion.Location = New System.Drawing.Point(148, 12)
        Me.ebDescripcion.MaxLength = 64
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.Size = New System.Drawing.Size(506, 20)
        Me.ebDescripcion.TabIndex = 2
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbValorInicial
        '
        Me.lbValorInicial.BackColor = System.Drawing.Color.Transparent
        Me.lbValorInicial.Location = New System.Drawing.Point(9, 40)
        Me.lbValorInicial.Name = "lbValorInicial"
        Me.lbValorInicial.Size = New System.Drawing.Size(132, 20)
        Me.lbValorInicial.TabIndex = 3
        Me.lbValorInicial.Text = "ValorInicial"
        Me.lbValorInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTipoEstado
        '
        Me.cbTipoEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoEstado.Location = New System.Drawing.Point(475, 40)
        Me.cbTipoEstado.Name = "cbTipoEstado"
        Me.cbTipoEstado.Size = New System.Drawing.Size(179, 20)
        Me.cbTipoEstado.TabIndex = 6
        Me.cbTipoEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbTipoEstado
        '
        Me.lbTipoEstado.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoEstado.Location = New System.Drawing.Point(360, 40)
        Me.lbTipoEstado.Name = "lbTipoEstado"
        Me.lbTipoEstado.Size = New System.Drawing.Size(112, 20)
        Me.lbTipoEstado.TabIndex = 5
        Me.lbTipoEstado.Text = "TipoEstado"
        Me.lbTipoEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbDetalle
        '
        Me.gbDetalle.BackColor = System.Drawing.Color.Transparent
        Me.gbDetalle.Controls.Add(Me.btEliminarDetalle)
        Me.gbDetalle.Controls.Add(Me.btCrearDetalle)
        Me.gbDetalle.Controls.Add(Me.GridDetalle)
        Me.gbDetalle.Location = New System.Drawing.Point(8, 72)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(648, 184)
        Me.gbDetalle.TabIndex = 13
        Me.gbDetalle.Text = "Detalle"
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btEliminarDetalle
        '
        Me.btEliminarDetalle.CausesValidation = False
        Me.btEliminarDetalle.Enabled = False
        Me.btEliminarDetalle.Icon = CType(resources.GetObject("btEliminarDetalle.Icon"), System.Drawing.Icon)
        Me.btEliminarDetalle.Location = New System.Drawing.Point(560, 48)
        Me.btEliminarDetalle.Name = "btEliminarDetalle"
        Me.btEliminarDetalle.Size = New System.Drawing.Size(80, 24)
        Me.btEliminarDetalle.TabIndex = 2
        Me.btEliminarDetalle.Text = "Eliminar"
        Me.btEliminarDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCrearDetalle
        '
        Me.btCrearDetalle.Icon = CType(resources.GetObject("btCrearDetalle.Icon"), System.Drawing.Icon)
        Me.btCrearDetalle.Location = New System.Drawing.Point(560, 16)
        Me.btCrearDetalle.Name = "btCrearDetalle"
        Me.btCrearDetalle.Size = New System.Drawing.Size(80, 24)
        Me.btCrearDetalle.TabIndex = 1
        Me.btCrearDetalle.Text = "Crear"
        Me.btCrearDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'GridDetalle
        '
        GridDetalle_DesignTimeLayout.LayoutString = resources.GetString("GridDetalle_DesignTimeLayout.LayoutString")
        Me.GridDetalle.DesignTimeLayout = GridDetalle_DesignTimeLayout
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(12, 16)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.GridDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.Size = New System.Drawing.Size(540, 156)
        Me.GridDetalle.TabIndex = 0
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'ebValorInicial
        '
        Me.ebValorInicial.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebValorInicial.Location = New System.Drawing.Point(148, 40)
        Me.ebValorInicial.MaxLength = 16
        Me.ebValorInicial.Name = "ebValorInicial"
        Me.ebValorInicial.Size = New System.Drawing.Size(120, 20)
        Me.ebValorInicial.TabIndex = 28
        Me.ebValorInicial.Text = "0"
        Me.ebValorInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebValorInicial.Value = 0
        Me.ebValorInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebValorInicial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(669, 300)
        Me.Controls.Add(Me.ebValorInicial)
        Me.Controls.Add(Me.cbTipoEstado)
        Me.Controls.Add(Me.lbTipoEstado)
        Me.Controls.Add(Me.lbValorInicial)
        Me.Controls.Add(Me.lbDescripcion)
        Me.Controls.Add(Me.ebDescripcion)
        Me.Controls.Add(Me.gbDetalle)
        Me.Name = "MGeneral"
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.gbDetalle, 0)
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.ebDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lbDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lbValorInicial, 0)
        Me.Controls.SetChildIndex(Me.lbTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.cbTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.ebValorInicial, 0)
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public vgMODO As eModo
    Private vlHuboCambios As Boolean = False
    Public vcFolio As cFolio
    Public vcMensaje As CMensaje
    Public vcMUsuarioId As String
    Dim blnEditandoClave As Boolean = False
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vgCerrar As Boolean = False

    Public Function CREAR(ByRef prFolio As cFolio, ByVal pvMUsuarioId As String) As Boolean
        vgMODO = eModo.Crear
        vcFolio = prFolio
        vcMUsuarioId = pvMUsuarioId

        vcFolio.MUsuarioId = vcMUsuarioId

        ConfigurarTitulos()

        Me.Text = vcMensaje.RecuperarDescripcion("ERMFOLESC_MGeneralC")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MODIFICAR(ByRef prFolio As cFolio, ByVal pvMusuarioId As String) As Boolean
        vgMODO = eModo.Modificar
        vcFolio = prFolio
        vcMUsuarioId = pvMusuarioId
        ConfigurarTitulos()

        Me.ebValorInicial.Enabled = Not vcFolio.ExisteRelacion

        Me.Text = vcMensaje.RecuperarDescripcion("ERMFOLESC_MGeneralM")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function
    Public Function Consultar(ByRef prFolio As cFolio, ByVal pvMusuarioId As String) As Boolean
        vgMODO = eModo.Leer
        vcFolio = prFolio
        vcMUsuarioId = pvMusuarioId
        ConfigurarTitulos()

        Me.ebValorInicial.Enabled = Not vcFolio.ExisteRelacion

        For Each ctrls As Control In Me.Controls
            ctrls.Enabled = False
        Next
        gbDetalle.Enabled = True
        GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        btCrearDetalle.Enabled = False
        btEliminarDetalle.Enabled = False


        Me.Text = vcMensaje.RecuperarDescripcion("xconsultar") + " " + vcMensaje.RecuperarDescripcion("ERMFOLESC_NGeneral")
        BtAceptar.Visible = False
        BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        BtCancelar.Icon = BtAceptar.Icon
        BtCancelar.Enabled = True
        Me.ShowDialog()

    End Function

    Private Sub ConfigurarTitulos()
        vcMensaje = New CMensaje

        '<Folio>
        Me.lbDescripcion.Text = vcMensaje.RecuperarDescripcion("FOLDescripcion")
        Me.lbValorInicial.Text = vcMensaje.RecuperarDescripcion("FOLValorInicial")
        Me.lbTipoEstado.Text = vcMensaje.RecuperarDescripcion("FOLTipoEstado")


        'Poner en el Tag el Nombre del Campo en la BD
        ebDescripcion.Tag = "Descripcion"
        ebValorInicial.Tag = "ValorInicial"
        cbTipoEstado.Tag = "TipoEstado"

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True

            .SetToolTip(Me.ebDescripcion.TextBox, vcMensaje.RecuperarDescripcion("FOLDescripcionT"))
            .SetToolTip(Me.ebValorInicial.TextBox, vcMensaje.RecuperarDescripcion("FOLValorInicialT"))
            .SetToolTip(Me.cbTipoEstado, vcMensaje.RecuperarDescripcion("FOLTipoEstadoT"))

            .SetToolTip(Me.BtAceptar, vcMensaje.RecuperarDescripcion("BTAceptarT"))
            If vgMODO = eModo.Leer Then
                .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTRegresar"))
            Else
                .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTCancelarT"))
            End If

        End With

        LlenarCbTipoEstado()

        Me.BtAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelar")
        '<\Folio>

        '<Modulo>
        'Me.gbModulo.Text = vcMensaje.RecuperarDescripcion("XModulo")
        'Me.lbModuloClave.Text = vcMensaje.RecuperarDescripcion("FOLModuloMovDetalleClave")
        'vlToolTip.SetToolTip(Me.ebModuloClave, vcMensaje.RecuperarDescripcion("FOLModuloMovDetalleClaveT"))
        '<\Modulo>

        '<Detalle>
        Me.gbDetalle.Text = vcMensaje.RecuperarDescripcion("XDetalle")
        GridDetalle.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        With GridDetalle.RootTable
            For Each vlColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOD" & vlColumna.Key)
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOD" & vlColumna.Key & "T")
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            Next
            .Columns("TipoEstado").DefaultValue = 1
        End With

        Me.btCrearDetalle.Text = vcMensaje.RecuperarDescripcion("BTCrear")
        Me.btEliminarDetalle.Text = vcMensaje.RecuperarDescripcion("BTEliminar")

        With vlToolTip
            .SetToolTip(Me.btCrearDetalle, vcMensaje.RecuperarDescripcion("BTCrearT"))
            .SetToolTip(Me.btEliminarDetalle, vcMensaje.RecuperarDescripcion("BTEliminarT"))
        End With

        lbGeneral.LlenarColumna(GridDetalle.RootTable.Columns("TipoContenido"), "TFOLCONT")
        lbGeneral.LlenarColumna(GridDetalle.RootTable.Columns("TipoEstado"), "EDOREG")
        '<\Detalle>

        If vgMODO = eModo.Crear Then
            LimpiarCampos()
        ElseIf vgMODO = eModo.Modificar Or vgMODO = eModo.Leer Then
            LlenarCampos()
        End If

        vlHuboCambios = False
    End Sub

    Private Sub LimpiarCampos()
        ebDescripcion.Text = ""
        ebValorInicial.Text = ""
        cbTipoEstado.SelectedValue = 1
        'ebModuloClave.Text = ""
        GridDetalle.DataSource = vcFolio.FODArray

    End Sub

    Private Sub LlenarCampos()
        With vcFolio
            ebDescripcion.Text = .Descripcion
            ebValorInicial.Text = .ValorInicial
            cbTipoEstado.SelectedValue = .TipoEstado

            'Dim vcModulo As New ERMMOTLOG.cModuloMovDetalle
            'vcModulo.Recuperar(.ModuloMovDetalleClave)
            'ebModuloClave.Text = vcModulo.Nombre
            'ebModuloClave.Tag = vcModulo.ModuloMovDetalleClave

            GridDetalle.DataSource = vcFolio.FODArray

            LlenarDetalle()

        End With
    End Sub

    Private Sub LlenarCbTipoEstado()
        lbGeneral.LlenarComboBox(cbTipoEstado, "EDOREG")
    End Sub

    Private Sub LlenarDetalle()
        Try
            GridDetalle.Refresh()
            GridDetalle.Refetch()
            DeshabilitaCrear(GridDetalle)
            'GridUnidad.RootTable.ApplyFilter(GridUnidad.RootTable.StoredFilters(0).FilterCondition)
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click

        Me.DialogResult = Windows.Forms.DialogResult.None

        If vgMODO = eModo.Crear Or vgMODO = eModo.Modificar Then
            With vcFolio

                If vgMODO = eModo.Crear Then
                    Dim vlClave As String
                    vlClave = lbGeneral.cKeyGen.KEYGEN(1)
                    .FolioID = vlClave
                End If

                .Descripcion = ebDescripcion.Text
                .ValorInicial = ebValorInicial.Text
                .TipoEstado = cbTipoEstado.SelectedValue
                .MUsuarioId = vcMUsuarioId

                '.ModuloMovDetalleClave = ebModuloClave.Tag

            End With
            Try
                If vgMODO = eModo.Crear Then
                    vcFolio.Insertar()
                Else
                    vcFolio.ValidarCampos()
                    If vcFolio.TipoEstado = 1 Then
                        If Not vcFolio.ExistenDetallesRequeridos() Then
                            Throw New LbControlError.cError("E0067", , "EsquemaId")
                        End If
                    End If
                End If

            Catch ex As LbControlError.cError
                Me.DeshabilitaCrear(Me.GridDetalle)
                ex.Mostrar()
                PonerFoco(ex.Source)
                Exit Sub
            End Try
        ElseIf vgMODO = eModo.Eliminar Then
            vcFolio.Eliminar()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.DeshabilitaCrear(Me.GridDetalle)
        vgCerrar = True
        Me.Close()
    End Sub

    Private Sub PonerFoco(ByVal pvNombreCampo As String)
        Select Case pvNombreCampo
            Case "Descripcion"
                Me.ebDescripcion.Focus()
            Case "ValorInicial"
                Me.ebValorInicial.Focus()
            Case "TipoEstado"
                Me.cbTipoEstado.Focus()
            Case "TipoFormato"
                Me.GridDetalle.MoveLast()
                Me.GridDetalle.Focus()
                
        End Select
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not vgCerrar Then
            Me.DialogResult = Windows.Forms.DialogResult.None
            If vgMODO = eModo.Crear Or vgMODO = eModo.Modificar Then
                If Not vgCerrar And vlHuboCambios Then
                    If (MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No) Then
                        Exit Sub
                    End If
                End If
            End If
            vcFolio.Limpiar()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub ValidarRow(ByVal pvRow As Janus.Windows.GridEX.GridEXRow)
        If pvRow Is Nothing Then Exit Sub
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In pvRow.Cells
            Select Case vlCelda.Column.Key
                Case "TipoContenido"
                    If vlCelda.Value Is Nothing Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOD" & vlCelda.Column.Key, True)}, vlCelda.Column.Key)
                    End If

                    If vlCelda.Value < 1 Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOD" & vlCelda.Column.Key, True)}, vlCelda.Column.Key)
                    End If

                    If vlCelda.Value = 2 Then
                        validarFormato(pvRow.Cells.Item("Formato").Value)
                    End If
            End Select
        Next
    End Sub

    Private Sub validarFormato(ByVal valor As String)
        If valor Is Nothing Then Exit Sub

        For Each letra As Char In valor
            If letra <> "0" Then
                Throw New LbControlError.cError("E0669")
            End If
        Next

    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If Not peGridEx.GetRow Is Nothing And peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then 'Or peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or peGridEx.DataChanged = False) Then
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

#Region "FOD"
   
    Private Sub GridDetalle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        Try
            Select Case (vgMODO)
                Case eModo.Crear
                    btEliminarDetalle.Enabled = True
                Case eModo.Modificar
                    If Not (GridDetalle.GetRow Is Nothing) Then
                        If (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                            btEliminarDetalle.Enabled = True
                        Else
                            If Not vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")) Is Nothing Then
                                If vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")).Estado = eEstado.Nuevo Then
                                    btEliminarDetalle.Enabled = True
                                Else
                                    btEliminarDetalle.Enabled = False
                                End If
                            Else
                                btEliminarDetalle.Enabled = True
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridDetalle_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridDetalle.FirstChange
        If (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            btEliminarDetalle.Enabled = True
        End If
        vlHuboCambios = True
    End Sub

    Private Sub GridDetalle_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridDetalle.AddingRecord
        Try
            ValidarRow(Me.GridDetalle.GetRow)
            vcFolio.InsertarFOD(vcFolio.FODArray.Count + 1, GridDetalle.GetValue("TipoContenido"), GridDetalle.GetValue("Formato"), GridDetalle.GetValue("TipoEstado"))
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
        End Try
        DeshabilitaCrear(GridDetalle)
    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        LlenarDetalle()
    End Sub

    Private Sub GridDetalle_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordAdded
        LlenarDetalle()
    End Sub

    Private Sub GridDetalle_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridDetalle.UpdatingRecord
        Try
            ValidarRow(Me.GridDetalle.GetRow)
            Dim vlDetalleClave As String = ""

            vlDetalleClave = GridDetalle.GetValue("FolioDetClave")

            Dim vcFOD As cFolioDetalle = vcFolio.FOD(vlDetalleClave)

            With vcFOD
                .TipoContenido = GridDetalle.GetValue("TipoContenido")
                .Formato = GridDetalle.GetValue("Formato")
                .TipoEstado = GridDetalle.GetValue("TipoEstado")
            End With
        Catch ex As LbControlError.cError
            'GridDetalle.Col = 2
            e.Cancel = True
            ex.Mostrar()

        End Try

        DeshabilitaCrear(GridDetalle)
    End Sub

    Private Sub GridDetalle_CellEditCanceled(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEditCanceled
        LlenarDetalle()
    End Sub

    Private Sub GridDetalle_RowEditCanceled(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridDetalle.RowEditCanceled
        LlenarDetalle()
    End Sub

    Private Sub BtCrearDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCrearDetalle.Click
        Try
            'If vgMODO = eModo.Crear Then
            '    vcFolio.ValidarCampos("FolioID")
            'End If
            With GridDetalle
                .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                .MoveToNewRecord()
                .Col = 2
                .Focus()
            End With
        Catch ex As LbControlError.cError
            ex.Mostrar()
            EbClave.Focus()
            Exit Sub
        End Try
    End Sub

    Private Sub BtEliminarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminarDetalle.Click
        If (GridDetalle.RowCount = 0) Then
            DeshabilitaCrear(GridDetalle)
            Exit Sub
        End If

        If (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            GridDetalle.CancelCurrentEdit()
            'Call DeshabilitaCrear(GridEsquemas)
        ElseIf (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            If Not vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")) Is Nothing Then
                If vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")).Estado = eEstado.Nuevo Then
                    GridDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    GridDetalle.Delete()
                    GridDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    GridDetalle.MovePrevious()
                    LlenarDetalle()
                End If
            End If

        End If
        DeshabilitaCrear(GridDetalle)
    End Sub

#End Region

#Region "Validaciones Campos"
    Private Sub EbRequeridos_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebDescripcion.Validated, cbTipoEstado.Validated, ebValorInicial.Validated
        Try
            If sender.Text = "" Then
                epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("FOL" & sender.tag)}))
                Exit Sub
            End If
            epErrores.SetError(sender, "")
        Catch ex As Exception

        End Try
    End Sub
#End Region

    'Private Sub btBuscarModulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarModulo.Click
    '    Try
    '        Dim frmBrowse As New ERMMOTESC.IGeneral(False, , " TipoEstado=1 and Baja=0 ")

    '        frmBrowse.StartPosition = FormStartPosition.CenterParent

    '        frmBrowse.ShowDialog()

    '        Dim vcModuloDetalle As ERMMOTLOG.cModuloMovDetalle
    '        vcModuloDetalle = frmBrowse.Seleccion(0)
    '        If Not vcModuloDetalle Is Nothing Then
    '            ebModuloClave.Text = vcModuloDetalle.Nombre
    '            ebModuloClave.Tag = vcModuloDetalle.ModuloMovDetalleClave
    '        End If

    '    Catch ex As LbControlError.cError
    '        ex.Mostrar()
    '        EbClave.Focus()
    '        Exit Sub
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub EbCambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EbClave.TextChanged, ebDescripcion.TextChanged, cbTipoEstado.SelectedValueChanged, ebValorInicial.TextChanged
        vlHuboCambios = True
    End Sub

    Private Sub MGeneral_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If vgMODO = eModo.Leer Then BtCancelar.Focus()
    End Sub

    Private Sub GridDetalle_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles GridDetalle.UpdatingCell
        Try
            Select Case e.Column.Key
                Case "Formato"
                    If e.Value Is Nothing Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(e.Column.Key, True)}, e.Column.Key)
                    End If
                    If e.Value = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOD" & e.Column.Key, True)}, e.Column.Key)
                    End If

            End Select
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Value = e.InitialValue
            e.Cancel = True
        End Try
    End Sub

    Private Sub ebValorInicial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebValorInicial.Validating
        If ebValorInicial.Value < 0 Then
            e.Cancel = True
            ebValorInicial.Value = 0
        End If
    End Sub
End Class
