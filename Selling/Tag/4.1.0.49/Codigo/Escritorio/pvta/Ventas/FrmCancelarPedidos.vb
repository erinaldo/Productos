
Public Class FrmCancelarPedidos
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpCortes As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridPedidos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCancelarPedidos))
        Me.GrpCortes = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbMotivo = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.cmbFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridPedidos = New Janus.Windows.GridEX.GridEX()
        Me.GrpCortes.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCortes
        '
        Me.GrpCortes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpCortes.Controls.Add(Me.Label5)
        Me.GrpCortes.Controls.Add(Me.CmbMotivo)
        Me.GrpCortes.Controls.Add(Me.Label4)
        Me.GrpCortes.Controls.Add(Me.ChkTodos)
        Me.GrpCortes.Controls.Add(Me.CmbCaja)
        Me.GrpCortes.Controls.Add(Me.BtnGuardar)
        Me.GrpCortes.Controls.Add(Me.cmbFechaFin)
        Me.GrpCortes.Controls.Add(Me.Label2)
        Me.GrpCortes.Controls.Add(Me.cmbFechaInicio)
        Me.GrpCortes.Controls.Add(Me.Label3)
        Me.GrpCortes.Controls.Add(Me.PictureBox1)
        Me.GrpCortes.Controls.Add(Me.CmbSucursal)
        Me.GrpCortes.Controls.Add(Me.BtnSalir)
        Me.GrpCortes.Controls.Add(Me.Label1)
        Me.GrpCortes.Controls.Add(Me.GridPedidos)
        Me.GrpCortes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpCortes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpCortes.ForeColor = System.Drawing.Color.Black
        Me.GrpCortes.Location = New System.Drawing.Point(0, 0)
        Me.GrpCortes.Name = "GrpCortes"
        Me.GrpCortes.Size = New System.Drawing.Size(797, 483)
        Me.GrpCortes.TabIndex = 1
        Me.GrpCortes.TabStop = False
        Me.GrpCortes.Text = "Cancelar pedidos"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(78, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 21)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Motivo"
        '
        'CmbMotivo
        '
        Me.CmbMotivo.Location = New System.Drawing.Point(133, 47)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(269, 24)
        Me.CmbMotivo.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(433, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 21)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Caja"
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(9, 48)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(103, 19)
        Me.ChkTodos.TabIndex = 123
        Me.ChkTodos.Text = "Todos"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(478, 47)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(301, 24)
        Me.CmbCaja.TabIndex = 73
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(701, 440)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 72
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbFechaFin
        '
        Me.cmbFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.cmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaFin.Location = New System.Drawing.Point(654, 17)
        Me.cmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaFin.Name = "cmbFechaFin"
        Me.cmbFechaFin.Size = New System.Drawing.Size(125, 22)
        Me.cmbFechaFin.TabIndex = 71
        Me.cmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(609, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Fin"
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(478, 17)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(125, 22)
        Me.cmbFechaInicio.TabIndex = 69
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(433, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Inicio"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(410, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 18)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(81, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(321, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(605, 440)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridPedidos
        '
        Me.GridPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPedidos.ColumnAutoResize = True
        Me.GridPedidos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPedidos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPedidos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPedidos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPedidos.GroupByBoxVisible = False
        Me.GridPedidos.Location = New System.Drawing.Point(7, 77)
        Me.GridPedidos.Name = "GridPedidos"
        Me.GridPedidos.RecordNavigator = True
        Me.GridPedidos.Size = New System.Drawing.Size(783, 357)
        Me.GridPedidos.TabIndex = 2
        Me.GridPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmCancelarPedidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(797, 483)
        Me.Controls.Add(Me.GrpCortes)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmCancelarPedidos"
        Me.Text = "Cancelación de pedidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpCortes.ResumeLayout(False)
        Me.GrpCortes.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private bLoad As Boolean = False
    Private sSUCClave As String

    Private TallaColor As Integer = 0
    Private CAJClave As String
    Private dtPedidos As DataTable
    Private ALMClave As String
    Private StageCancelacion As String
    
    Public Sub refrescaGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtPedidos Is Nothing Then
            dtPedidos.Dispose()
        End If

        Dim FechaIni As Date = cmbFechaInicio.Value
        Dim FechaFin As Date = cmbFechaFin.Value.AddHours(23.9999)

        dtPedidos = ModPOS.Recupera_Tabla("st_muestra_pedidosPendientes", "@FechaInicial", FechaIni, "@FechaFinal", FechaFin, "@SUCClave", sSUCClave)
        GridPedidos.DataSource = dtPedidos
        GridPedidos.RetrieveStructure()
        GridPedidos.RootTable.Columns("DOCClave").Visible = False
        GridPedidos.RootTable.Columns("iEstado").Visible = False
        GridPedidos.RootTable.Columns("TipoAplicacion").Visible = False
        GridPedidos.RootTable.Columns("CTEClave").Visible = False
        GridPedidos.RootTable.Columns("TipoCambio").Visible = False
        GridPedidos.RootTable.Columns("MONClave").Visible = False

        'GridPedidos.RootTable.Columns("Folio").EditType = Janus.Windows.GridEX.EditType.NoEdit
        'GridPedidos.RootTable.Columns("Fecha").EditType = Janus.Windows.GridEX.EditType.NoEdit
        'GridPedidos.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
        'GridPedidos.RootTable.Columns("RazonSocial").EditType = Janus.Windows.GridEX.EditType.NoEdit
        'GridPedidos.RootTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.NoEdit
        'GridPedidos.RootTable.Columns("Total").EditType = Janus.Windows.GridEX.EditType.NoEdit
    End Sub

    Private Sub FrmCancelarPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

        Dim dtParam As DataTable
        Dim i As Integer

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                        Exit For
                End Select
            Next
        End With
        dtParam.Dispose()

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        With CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Cancelacion"
            .llenar()
        End With


        Me.cmbFechaInicio.Value = Today
        Me.cmbFechaFin.Value = Today

        refrescaGrid()
        Cursor.Current = Cursors.Default
        bLoad = True
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0
        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmCancelarPedidos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.CancelarPedidos.Dispose()
        ModPOS.CancelarPedidos = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub cmbFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles cmbFechaInicio.ValueChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub cmbFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles cmbFechaFin.ValueChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim foundRows() As DataRow
        Dim i As Integer
        Dim dt As DataTable
        Dim msg As String = ""

        If ALMClave = "" Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CmbCaja.SelectedValue)
            ALMClave = dt.Rows(0)("ALMClave")
            StageCancelacion = dt.Rows(0)("StageCancelacion")
        End If
        If CmbMotivo Is Nothing Then
            MessageBox.Show("Se debe de seleccionar un motivo de cancelación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        foundRows = dtPedidos.Select("Marca = 'True' and iEstado = 2")
        If foundRows.Length > 0 AndAlso CmbSucursal Is Nothing Then
            MessageBox.Show("Debes de seleccionar una caja para los documentos ya cerrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Cancelar pedidos Abiertos o en Espera
        foundRows = dtPedidos.Select("Marca = 'True' and (iEstado = 1 or iEstado = 6)")
        For i = 0 To foundRows.GetUpperBound(0)
            msg = ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", foundRows(i)("DOCClave"), "@Estado", 4, "@ALMClave", ALMClave, "@Folio", foundRows(i)("Folio"), "@MONClave", foundRows(i)("MONClave"), "@TipoCambio", foundRows(i)("TipoCambio"))
            msg = ModPOS.Ejecuta("sp_cancela_ticket", "@ALMClave", ALMClave, "@VENClave", foundRows(i)("DOCClave"), "@TipoDOC", 1, "@Motivo", CmbMotivo.SelectedValue, "@Autoriza", ModPOS.UsuarioActual)
            msg = ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", foundRows(i)("DOCClave"))
        Next

        'Cancelar pedidos en Picking
        foundRows = dtPedidos.Select("Marca = 'True' and (iEstado = 7)")
        For i = 0 To foundRows.GetUpperBound(0)
            dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(i)("DOCClave"))
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Estado") = foundRows(i)("iEstado") Then
                    msg = ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1, "@Motivo", CmbMotivo.SelectedValue, "@Autoriza", ModPOS.UsuarioActual, "@TipoAplicacion", foundRows(i)("TipoAplicacion"))
                    msg = ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)
                    msg = ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", 1, "@DOCClave", foundRows(i)("DOCClave"), "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)
                End If
            End If
        Next

        'Cancelar pedidos Cerrados
        foundRows = dtPedidos.Select("Marca = 'True' and iEstado = 2")
        For i = 0 To foundRows.GetUpperBound(0)

            dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(i)("DOCClave"))
            If dt.Rows.Count > 0 Then
                'Valida si sigue estando en el mismo estado
                If dt.Rows(0)("Estado") = foundRows(i)("iEstado") Then
                    Dim dtDevo As DataTable = ModPOS.Recupera_Tabla("st_recupera_devoluciones_aplicadas", "@DOCClave", foundRows(i)("DOCClave"), "@TipoDoc", 1)
                    If dtDevo.Rows.Count > 0 Then
                        MessageBox.Show("El documento con Folio " & foundRows(i)("Folio") & " no es posible cancelarlo porque tiene Devoluciones asociadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        msg = ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1, "@Motivo", CmbMotivo.SelectedValue, "@Autoriza", ModPOS.UsuarioActual, "@TipoAplicacion", foundRows(i)("TipoAplicacion"))

                        If StageCancelacion <> "" Then
                            ModPOS.GeneraMovInv(1, 5, 1, foundRows(i)("DOCClave"), ALMClave, foundRows(i)("Folio"), ModPOS.UsuarioActual, False, 1, StageCancelacion)
                        Else
                            ModPOS.GeneraMovInv(1, 5, 1, foundRows(i)("DOCClave"), ALMClave, foundRows(i)("Folio"), ModPOS.UsuarioActual, False)
                        End If

                        msg = ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("Total") * foundRows(i)("TipoCambio"))
                        msg = ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)

                    End If
                    dtDevo.Dispose()
                End If
            End If
        Next
        refrescaGrid()
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtPedidos.Rows.Count > 0 Then
            Dim i As Integer

            If ChkTodos.Checked Then
                For i = 0 To GridPedidos.GetDataRows.Length - 1
                    GridPedidos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridPedidos.GetDataRows.Length - 1
                    GridPedidos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtPedidos.AcceptChanges()

            GridPedidos.Refresh()
        End If
    End Sub

    Private Sub GridPedidos_Click(sender As Object, e As EventArgs) Handles GridPedidos.Click
        If Not GridPedidos.CurrentColumn Is Nothing Then
            If GridPedidos.CurrentColumn.Caption <> "Marca" And Not GridPedidos.GetValue("Marca") Is Nothing Then
                If GridPedidos.GetValue("Marca") = False Then
                    GridPedidos.SetValue("Marca", True)
                Else
                    GridPedidos.SetValue("Marca", False)
                End If

                dtPedidos.AcceptChanges()

                GridPedidos.Refresh()
            End If
        End If
    End Sub

    Private Sub CmbCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCaja.SelectedValueChanged
        If bLoad Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CmbCaja.SelectedValue)
            ALMClave = dt.Rows(0)("ALMClave")
            StageCancelacion = dt.Rows(0)("StageCancelacion")
        End If

    End Sub
End Class
