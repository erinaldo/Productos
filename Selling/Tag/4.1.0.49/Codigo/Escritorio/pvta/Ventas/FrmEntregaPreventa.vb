Public Class FrmEntregaPreventa
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntregaPreventa))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.GrpCliente.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(713, 305)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 1
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(617, 305)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar sin guardar cambios"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.TxtFolio)
        Me.GrpCliente.Controls.Add(Me.TxtVendedor)
        Me.GrpCliente.Controls.Add(Me.TxtFecha)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.Label12)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.TxtCliente)
        Me.GrpCliente.Location = New System.Drawing.Point(12, 4)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(791, 88)
        Me.GrpCliente.TabIndex = 121
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "General"
        '
        'TxtFolio
        '
        Me.TxtFolio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(81, 28)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(173, 21)
        Me.TxtFolio.TabIndex = 112
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtVendedor.Enabled = False
        Me.TxtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor.Location = New System.Drawing.Point(474, 28)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(308, 21)
        Me.TxtVendedor.TabIndex = 3
        '
        'TxtFecha
        '
        Me.TxtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtFecha.Enabled = False
        Me.TxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Location = New System.Drawing.Point(260, 29)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(134, 21)
        Me.TxtFecha.TabIndex = 94
        '
        'lblRFC
        '
        Me.lblRFC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRFC.Location = New System.Drawing.Point(7, 59)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "Cliente"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(400, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 17)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Atendio"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(7, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Folio/Fecha"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(260, 54)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(522, 21)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'TxtCliente
        '
        Me.TxtCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCliente.Location = New System.Drawing.Point(81, 54)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(173, 21)
        Me.TxtCliente.TabIndex = 3
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(12, 128)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(791, 171)
        Me.GrpDetalle.TabIndex = 0
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(10, 19)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(768, 138)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(12, 98)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(107, 22)
        Me.ChkTodos.TabIndex = 129
        Me.ChkTodos.Text = "Confirmar Todo"
        '
        'FrmEntregaPreventa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(808, 347)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmEntregaPreventa"
        Me.Text = "Entrega Preventa"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private MaskCte As Integer = 0
    Private TallaColor As Integer = 0

    Private dtDetalle As DataTable
    Private bError As Boolean

    Private StageLU, SUCClave, ALMClave, StageCancelacion, VENClave As String
    Public CAJClave, impresora As String

    Private Sub FrmPedido_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        StageLU = IIf(dt.Rows(0)("StageLU").GetType.Name = "DBNull", "", dt.Rows(0)("StageLU"))
        StageCancelacion = IIf(dt.Rows(0)("StageCancelacion").GetType.Name = "DBNull", "", dt.Rows(0)("StageCancelacion"))
        SUCClave = dt.Rows(0)("SUCClave")
        ALMClave = dt.Rows(0)("ALMClave")
        dt.Dispose()

        If TallaColor = 1 Then
            ChkTodos.Enabled = GrupoTipo
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        BtnGuardar.Enabled = False
        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("Entrega > Cantidad")
        If foundRows.Length > 0 Then
            MessageBox.Show("¡La cantidad a entregar no de ser mayor a la actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            BtnGuardar.Enabled = True
            Exit Sub
        End If
        Dim imprimirVale As Boolean = False
        foundRows = dtDetalle.Select("Entrega > 0")
        For i As Integer = 0 To foundRows.Length - 1
            If ValidaExistencia(foundRows(i)("PROClave"), foundRows(i)("Entrega"), foundRows(i)("Nombre")) Then
                ModPOS.Ejecuta("st_actualiza_BackOrder", "@DVEClave", foundRows(i)("DVEClave"), "@Cantidad", foundRows(i)("Entrega"))

                ModPOS.Ejecuta("st_act_existencia_pue", _
                          "@VENClave", VENClave,
                          "@ALMClave", ALMClave, _
                          "@UBCClave", StageLU, _
                          "@PROClave", foundRows(i)("PROClave"), _
                          "@TProducto", foundRows(i)("TProducto"), _
                          "@Cantidad", foundRows(i)("Entrega"), _
                          "@Usuario", ModPOS.UsuarioActual
                           )
                If foundRows(i)("Entrega") < foundRows(i)("Cantidad") Then
                    imprimirVale = True
                End If
            Else
                imprimirVale = True
            End If
        Next

        If imprimirVale Then
            ModPOS.imprimirPreventa(VENClave, impresora)
        End If

        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        'CancelaProducto()
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Entrega" Then
            If IsNumeric(GridDetalle.GetValue("Entrega")) Then
                If CDbl(GridDetalle.GetValue("Entrega")) > CDbl(GridDetalle.GetValue("Cantidad")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad a entregar no de ser mayor a la actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Entrega", GridDetalle.GetValue("Entrega"))
                ElseIf CDbl(GridDetalle.GetValue("Entrega")) < 0 Then
                    GridDetalle.SetValue("Entrega", 0)
                Else
                    If ValidaExistencia(GridDetalle.GetValue("PROClave"), GridDetalle.GetValue("Entrega"), GridDetalle.GetValue("Nombre")) = False Then
                        GridDetalle.SetValue("Entrega", 0)
                    End If
                End If
            Else
                GridDetalle.SetValue("Entrega", 0)
            End If

        End If
    End Sub

    Private Sub TxtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFolio.KeyPress
        If Asc(e.KeyChar) = 13 Then
            RecuperarVenta(TxtFolio.Text)
        End If
    End Sub

    Private Sub RecuperarVenta(ByVal Folio As String)
        dtDetalle = ModPOS.Recupera_Tabla("st_muestra_BackOrder", "@Folio", Folio)
        If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count = 0 Then
            MessageBox.Show("La venta " & Folio & "no cuenta con productos pendientes de entregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure()
        GridDetalle.RootTable.Columns("DVEClave").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("PorcDesc").Visible = False
        GridDetalle.RootTable.Columns("GrupoMaterial").Visible = False
        GridDetalle.RootTable.Columns("Sector").Visible = False
        GridDetalle.RootTable.Columns("IdKIT").Visible = False
        GridDetalle.RootTable.Columns("TipoRechazo").Visible = False
        GridDetalle.RootTable.Columns("Combo").Visible = False
        GridDetalle.RootTable.Columns("centroSuministro").Visible = False
        GridDetalle.RootTable.Columns("Fecha").Visible = False
        GridDetalle.RootTable.Columns("ClaveCliente").Visible = False
        GridDetalle.RootTable.Columns("Cliente").Visible = False
        GridDetalle.RootTable.Columns("Atendio").Visible = False
        GridDetalle.RootTable.Columns("Partida").Visible = False
        GridDetalle.RootTable.Columns("VENClave").Visible = False

        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("Precio Unitario").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Dscto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"

        GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Dscto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Cantidad").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Entrega").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum


        GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Dscto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"

        GridDetalle.CurrentTable.Columns("Subtotal").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Dscto").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Impuesto").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Total").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Cantidad").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Subtotal").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Precio Unitario").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
        GridDetalle.CurrentTable.Columns("Nombre").EditType = Janus.Windows.GridEX.EditType.NoEdit


        TxtFecha.Text = dtDetalle.Rows(0)("Fecha").ToString()
        TxtCliente.Text = dtDetalle.Rows(0)("ClaveCliente")
        TxtRazonSocial.Text = dtDetalle.Rows(0)("Cliente")
        TxtVendedor.Text = dtDetalle.Rows(0)("Atendio")
        VENClave = dtDetalle.Rows(0)("VENClave")

        GrpDetalle.Enabled = True
        GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
    End Sub

    Private Function ValidaExistencia(ByVal PROClave As String, ByVal Cantidad As Double, ByVal Producto As String) As Boolean
        Dim Disponible, Existencia, Apartado, Bloqueado As Double
        Dim dtDisponible As DataTable
        dtDisponible = ModPOS.SiExisteRecupera("st_recupera_peu", "@PROClave", PROClave, "@UBCClave", StageLU)
        If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
            Existencia = dtDisponible.Rows(0)("Existencia")
            Apartado = dtDisponible.Rows(0)("Apartado")
            Bloqueado = dtDisponible.Rows(0)("Bloqueado")
            dtDisponible.Dispose()

            Disponible = Existencia - Apartado - Bloqueado
        Else
            Disponible = 0
        End If

        If Cantidad > Disponible Then
            MessageBox.Show("El producto " & Producto & " no cuenta con existencia disponible en la ubicación de Caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Dim i As Integer

                If ChkTodos.Checked Then
                    For i = 0 To GridDetalle.GetDataRows.Length - 1
                        GridDetalle.GetDataRows(i).DataRow("Entrega") = GridDetalle.GetDataRows(i).DataRow("Cantidad")
                        If ValidaExistencia(GridDetalle.GetDataRows(i).DataRow("PROClave"), GridDetalle.GetDataRows(i).DataRow("Entrega"), GridDetalle.GetDataRows(i).DataRow("Nombre")) = False Then
                            GridDetalle.SetValue("Entrega", 0)
                        End If
                    Next
                Else
                    For i = 0 To GridDetalle.GetDataRows.Length - 1
                        GridDetalle.GetDataRows(i).DataRow("Entrega") = 0
                    Next
                End If

                dtDetalle.AcceptChanges()

                GridDetalle.Refresh()
            End If
        End If
    End Sub

End Class
