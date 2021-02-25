Imports ERMCLILOG
Imports BASMENLOG

Public Class IGeneral
    Inherits System.Windows.Forms.Form

    Dim vcConexion As LbConexion.cConexion
    Dim vcDtCliente As DataTable
    Dim vcMensaje As CMensaje
    Dim vcFiltro As String
    Dim vcMultiseleccion As Boolean
    Dim vcSeleccion As ArrayList
    Dim vlClienteLoad As New ERMCLILOG.cCliente
    Dim bMostrarRazonSocial As Boolean

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
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grIndex As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IGeneral))
        Dim grIndex_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.grIndex = New Janus.Windows.GridEX.GridEX
        CType(Me.grIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(520, 516)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 36
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(632, 516)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 37
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grIndex
        '
        grIndex_DesignTimeLayout.LayoutString = resources.GetString("grIndex_DesignTimeLayout.LayoutString")
        Me.grIndex.DesignTimeLayout = grIndex_DesignTimeLayout
        Me.grIndex.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grIndex.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grIndex.GroupByBoxVisible = False
        Me.grIndex.Location = New System.Drawing.Point(8, 8)
        Me.grIndex.Name = "grIndex"
        Me.grIndex.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grIndex.Size = New System.Drawing.Size(728, 496)
        Me.grIndex.TabIndex = 35
        Me.grIndex.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'IGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(744, 550)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.grIndex)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IGeneral"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IGeneral"
        CType(Me.grIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Funciones "

    Private Sub ConfigurarTitulos()
        Dim vlToolTip As New ToolTip
        Me.btAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptarI")
        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelarI")

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.btAceptar, vcMensaje.RecuperarDescripcion("BTAceptarIT"))
            .SetToolTip(Me.btCancelar, vcMensaje.RecuperarDescripcion("BTCancelarIT"))
        End With
    End Sub

    Private Sub ConfigurarGrid()
        With grIndex.RootTable
            '.Columns("MFechaHora").Visible = False
            '.Columns("MUsuarioID").Visible = False
            '.Columns("IdElectronico").Visible = False
            '.Columns("IdFiscal").Visible = True
            '.Columns("RazonSocial").Visible = True
            '.Columns("TipoFiscal").Visible = False
            '.Columns("FechaRegistroSistema").Visible = False
            '.Columns("FechaNacimiento").Visible = False
            '.Columns("TipoEstado").Visible = False
            '.Columns("CNPId").Visible = False
            '.Columns("Prestamo").Visible = False
            ''.Columns("SaldoPrestamo").Visible = False
            .Columns("ClienteClave").Visible = False

            If vcMultiseleccion Then
                .Columns("Seleccionado").Width = 30
                .Columns("Seleccionado").ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                .Columns("Seleccionado").EditType = Janus.Windows.GridEX.EditType.CheckBox
                .Columns("Seleccionado").FilterEditType = Janus.Windows.GridEX.FilterEditType.SameAsEditType
                .Columns("Seleccionado").Position = 0
                .Columns("Seleccionado").ActAsSelector = True
                .Columns("Seleccionado").AllowSort = False
            End If
            .Columns("TipoImpuesto").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("TipoImpuesto").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("TelefonoContacto").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("TelefonoContacto").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("Clave").Width = 100
            .Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("Clave").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("NombreContacto").Width = 350
            .Columns("NombreContacto").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("NombreContacto").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("RazonSocial").Width = 350
            .Columns("RazonSocial").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("RazonSocial").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
            .Columns("RazonSocial").Position = 7

            .Columns("NombreCorto").Width = 100
            .Columns("NombreCorto").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("NombreCorto").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("LimiteCreditoDinero").Width = 100
            .Columns("LimiteCreditoDinero").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("LimiteCreditoDinero").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
            .Columns("LimiteCreditoDinero").FormatString = "C"
            .Columns("LimiteCreditoDinero").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            .Columns("LimiteDescuento").Width = 100
            .Columns("LimiteDescuento").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("LimiteDescuento").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
            .Columns("LimiteDescuento").FormatString = "N"
            .Columns("LimiteDescuento").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            .Columns("SaldoEfectivo").Width = 100
            .Columns("SaldoEfectivo").EditType = Janus.Windows.GridEX.EditType.NoEdit
            .Columns("SaldoEfectivo").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
            .Columns("SaldoEfectivo").FormatString = "C"
            .Columns("SaldoEfectivo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        grIndex.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In grIndex.RootTable.Columns
            
            If vlColumna.Key = "DesgloseImpuesto" Then
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("CLIDesglose")
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center

            ElseIf vlColumna.Key <> "Seleccionado" Then
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("CLI" + vlColumna.Key)
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            Else
                vlColumna.Caption = ""
            End If
        Next

    End Sub

    Private Sub SeleccionarRegs()
        Dim vlRegistros() As Janus.Windows.GridEX.GridEXRow
        vcSeleccion = New ArrayList
        ' vlRegistros = CType(Me.grIndex.DataSource, DataTable).Select("Seleccionado=true")
        vlRegistros = Me.grIndex.GetCheckedRows

        Dim i As Integer = 0
        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim vlCliente As New ERMCLILOG.cCliente
        For i = 0 To vlRegistros.Length - 1
            Application.DoEvents()

            vlCliente = vlClienteLoad.Tabla.recuperarCliente(vlRegistros(i).Cells("ClienteClave").Value)
            'vlCliente.Recuperar(vlRegistros(i)("ClienteClave"))
            vcSeleccion.Add(vlCliente)
        Next i

    End Sub

    Private Sub SeleccionarReg()
        If grIndex.GetRow Is Nothing OrElse grIndex.GetRow.RowIndex < 0 Then Exit Sub
        Dim vlCliente As New cCliente
        vcSeleccion = New ArrayList
        vlCliente.Recuperar(grIndex.GetRow.Cells("ClienteClave").Text)
        vcSeleccion.Add(vlCliente)
    End Sub

    Public Function Seleccionar(Optional ByVal pvFiltro As String = "", Optional ByVal pvMultiseleccion As Boolean = True, Optional ByVal pvbRazonSocial As Boolean = False) As ArrayList
        vcConexion = LbConexion.cConexion.Instancia
        vcFiltro = pvFiltro
        vcMultiseleccion = pvMultiseleccion
        bMostrarRazonSocial = pvbRazonSocial
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return vcSeleccion
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region " Eventos "

    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            vcMensaje = New CMensaje

            Me.Text = vcMensaje.RecuperarDescripcion("ERMCLIESC_IGeneral")


            vcDtCliente = vlClienteLoad.Tabla.Recuperar(vcFiltro, "ClienteClave, Clave, IdFiscal, TipoImpuesto, RazonSocial, NombreContacto, TelefonoContacto, LimiteCreditoDinero, NombreCorto, LimiteDescuento, SaldoEfectivo, Exclusividad, VigExclusividad,ActualizaSaldoCheque, VencimientoVenta, DiasVencimiento, SaldoGarantia, Nuevo, FechaFactura,DesgloseImpuesto, CorreoElectronico ")

            If vcMultiseleccion Then
                Dim Cols As New DataColumn("Seleccionado", System.Type.GetType("System.Boolean"))
                Cols.DefaultValue = False
                Cols.AllowDBNull = False
                vcDtCliente.Columns.Add(Cols)
            End If

            grIndex.ClearStructure()
            grIndex.DataSource = vcDtCliente
            grIndex.DataMember = "Cliente"
            grIndex.RetrieveStructure()
            'grIndex.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False

            ConfigurarGrid()
            ConfigurarTitulos()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        If vcMultiseleccion Then
            SeleccionarRegs()
        Else
            SeleccionarReg()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

#End Region

End Class
