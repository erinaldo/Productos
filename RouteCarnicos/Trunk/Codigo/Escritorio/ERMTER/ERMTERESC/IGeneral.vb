Imports ERMTERLOG
Imports BASMENLOG

Public Class IGeneral
    Inherits System.Windows.Forms.Form

    Dim vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Dim vcDtTerminal As DataTable
    Dim vcMensaje As New CMensaje
    Dim vcFiltro As String
    Dim vcMultiseleccion As Boolean
    Dim vcSeleccion As ArrayList

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
        Me.btAceptar.Location = New System.Drawing.Point(520, 517)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 27
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(632, 517)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 28
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
        Me.grIndex.TabIndex = 26
        Me.grIndex.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
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
        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In grIndex.RootTable.Columns
            If vlColumna.Key = "Seleccionado" Then
                vlColumna.Caption = ""
            Else
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("TER" + vlColumna.Key)
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("TER" + vlColumna.Key + "T")
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
            End If
        Next

        With grIndex.RootTable
            .Columns("TipoFase").Visible = False
            .Columns("Comentario").Visible = False
            .Columns("MFechaHora").Visible = False
            .Columns("MUsuarioID").Visible = False

            If vcMultiseleccion Then
                .Columns("Seleccionado").Width = 30
                .Columns("Seleccionado").ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                .Columns("Seleccionado").EditType = Janus.Windows.GridEX.EditType.CheckBox
                .Columns("Seleccionado").FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit
                .Columns("Seleccionado").Position = 0
                .Columns("Seleccionado").ActAsSelector = True

            End If

            .Columns("TerminalClave").Width = 100
            .Columns("TerminalClave").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("Descripcion").Width = 420
            .Columns("Descripcion").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

            .Columns("NumeroSerie").Width = 140
            .Columns("NumeroSerie").FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
        End With

        grIndex.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = vcMensaje.RecuperarDescripcion("XAGRUPADOR")



    End Sub

    Private Sub SeleccionarRegs()
        Dim vlRegistros() As Janus.Windows.GridEX.GridEXRow
        Dim vlRegistro As Janus.Windows.GridEX.GridEXRow
        vcSeleccion = New ArrayList
        'vlRegistros = CType(Me.grIndex.DataSource, DataTable).Select("Seleccionado=true")
        vlRegistros = Me.grIndex.GetCheckedRows
        For Each vlRegistro In vlRegistros
            Dim vlTerminal As New cTerminal
            vlTerminal.Recuperar(vlRegistro.Cells("TerminalClave").Value)
            vcSeleccion.Add(vlTerminal)
        Next
    End Sub

    Private Sub SeleccionarReg()
        Dim vlTerminal As New cTerminal
        If Not IsNothing(grIndex.GetRow) Then
            vcSeleccion = New ArrayList
            vlTerminal.Recuperar(grIndex.GetRow.Cells("TerminalClave").Text)
            vcSeleccion.Add(vlTerminal)
        End If
    End Sub

    Public Function Seleccionar(Optional ByVal pvFiltro As String = "", Optional ByVal pvMultiseleccion As Boolean = True) As ArrayList
        vcFiltro = pvFiltro
        vcMultiseleccion = pvMultiseleccion
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return vcSeleccion
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region " Eventos "

    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vlTerminal As New ERMTERLOG.cTerminal

        Try

            Me.Text = vcMensaje.RecuperarDescripcion("ERMTERESC_IGeneral")

            vcDtTerminal = vlTerminal.Tabla.Recuperar(vcFiltro)

            If vcMultiseleccion Then
                Dim Cols As New DataColumn("Seleccionado", System.Type.GetType("System.Boolean"))
                Cols.DefaultValue = False
                Cols.AllowDBNull = False
                vcDtTerminal.Columns.Add(Cols)
            End If

            grIndex.ClearStructure()
            grIndex.DataSource = vcDtTerminal
            grIndex.DataMember = "Terminal"
            grIndex.RetrieveStructure()

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
