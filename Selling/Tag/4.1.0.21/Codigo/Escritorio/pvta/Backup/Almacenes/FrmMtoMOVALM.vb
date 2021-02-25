Public Class FrmMtoMOVALM
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
    Friend WithEvents GrpTransferencia As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnTransferencia As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridTransferencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbFormato As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoMOVALM))
        Me.GrpTransferencia = New System.Windows.Forms.GroupBox
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbFormato = New Selling.StoreCombo
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnTransferencia = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridTransferencia = New Janus.Windows.GridEX.GridEX
        Me.GrpTransferencia.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTransferencia
        '
        Me.GrpTransferencia.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTransferencia.Controls.Add(Me.BtnEliminar)
        Me.GrpTransferencia.Controls.Add(Me.BtnSalir)
        Me.GrpTransferencia.Controls.Add(Me.PictureBox2)
        Me.GrpTransferencia.Controls.Add(Me.cmbFormato)
        Me.GrpTransferencia.Controls.Add(Me.BtnModificar)
        Me.GrpTransferencia.Controls.Add(Me.BtnReimpresion)
        Me.GrpTransferencia.Controls.Add(Me.Label2)
        Me.GrpTransferencia.Controls.Add(Me.ChkTodos)
        Me.GrpTransferencia.Controls.Add(Me.Label3)
        Me.GrpTransferencia.Controls.Add(Me.dtPicker)
        Me.GrpTransferencia.Controls.Add(Me.BtnTransferencia)
        Me.GrpTransferencia.Controls.Add(Me.PictureBox1)
        Me.GrpTransferencia.Controls.Add(Me.CmbSucursal)
        Me.GrpTransferencia.Controls.Add(Me.Label1)
        Me.GrpTransferencia.Controls.Add(Me.GridTransferencia)
        Me.GrpTransferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTransferencia.ForeColor = System.Drawing.Color.Black
        Me.GrpTransferencia.Location = New System.Drawing.Point(0, 0)
        Me.GrpTransferencia.Name = "GrpTransferencia"
        Me.GrpTransferencia.Size = New System.Drawing.Size(789, 473)
        Me.GrpTransferencia.TabIndex = 1
        Me.GrpTransferencia.TabStop = False
        Me.GrpTransferencia.Text = "Traspasos"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(405, 430)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 10
        Me.BtnEliminar.Text = "&Salir"
        Me.BtnEliminar.ToolTipText = "Cancelar transpaso seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(309, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(581, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox2.TabIndex = 126
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbFormato
        '
        Me.cmbFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFormato.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormato.Location = New System.Drawing.Point(597, 41)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(184, 24)
        Me.cmbFormato.TabIndex = 125
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(597, 430)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 11
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar traspaso seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(501, 430)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.ToolTipText = "Reimpresión de traspaso seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(539, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Formato "
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(7, 46)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(69, 20)
        Me.ChkTodos.TabIndex = 123
        Me.ChkTodos.Text = "Todos"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(539, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CausesValidation = False
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(597, 16)
        Me.dtPicker.MaxDate = New Date(9998, 12, 28, 0, 0, 0, 0)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 54
        '
        'BtnTransferencia
        '
        Me.BtnTransferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTransferencia.Icon = CType(resources.GetObject("BtnTransferencia.Icon"), System.Drawing.Icon)
        Me.BtnTransferencia.Location = New System.Drawing.Point(693, 430)
        Me.BtnTransferencia.Name = "BtnTransferencia"
        Me.BtnTransferencia.Size = New System.Drawing.Size(90, 37)
        Me.BtnTransferencia.TabIndex = 6
        Me.BtnTransferencia.Text = "&Traspaso"
        Me.BtnTransferencia.ToolTipText = "Nuevo Traspaso"
        Me.BtnTransferencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(62, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(82, 18)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(362, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridTransferencia
        '
        Me.GridTransferencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridTransferencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTransferencia.ColumnAutoResize = True
        Me.GridTransferencia.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTransferencia.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTransferencia.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridTransferencia.GroupByBoxVisible = False
        Me.GridTransferencia.Location = New System.Drawing.Point(7, 70)
        Me.GridTransferencia.Name = "GridTransferencia"
        Me.GridTransferencia.RecordNavigator = True
        Me.GridTransferencia.Size = New System.Drawing.Size(776, 354)
        Me.GridTransferencia.TabIndex = 2
        Me.GridTransferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoMOVALM
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.GrpTransferencia)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoMOVALM"
        Me.Text = " Traspasos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTransferencia.ResumeLayout(False)
        Me.GrpTransferencia.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Mes As Integer
    Public Periodo As Integer

    Private sSUCClave As String

    Private sTransferenciaSelected As String
    Private sNombre As String

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private dtTraspaso As DataTable

    Private bLoad As Boolean = False

    Private Sub FrmMtoMOVALM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        With Me.cmbFormato
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "Tabla"
            .Parametro1 = "MOVALM"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Imprimir"
            .llenar()
        End With


        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year
        Mes = dtPicker.Value.Month




        refrescaGrid()


    End Sub

    Public Sub refrescaGrid()
        bLoad = False
        Cursor.Current = Cursors.WaitCursor

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtTraspaso Is Nothing Then
            dtTraspaso.Dispose()
        End If

        dtTraspaso = ModPOS.Recupera_Tabla("sp_muestra_transferencia", "@SUCClave", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridTransferencia.DataSource = dtTraspaso
        GridTransferencia.RetrieveStructure()

        Me.GridTransferencia.RootTable.Columns("MVAClave").Visible = False
        Me.GridTransferencia.RootTable.Columns("iEstado").Visible = False
        Me.GridTransferencia.RootTable.Columns("Total").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridTransferencia.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridTransferencia.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default
        bLoad = True
    End Sub

    Private Sub GridTransferencia_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTransferencia.CurrentCellChanged
        If Not GridTransferencia.CurrentColumn Is Nothing Then
            If GridTransferencia.CurrentColumn.Caption = "Marca" Then
                GridTransferencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridTransferencia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridTransferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridTransferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridTransferencia_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTransferencia.SelectionChanged
        If Not GridTransferencia.GetValue(0) Is Nothing Then
            sTransferenciaSelected = GridTransferencia.GetValue("MVAClave")
            sNombre = GridTransferencia.GetValue("Folio")
            BtnModificar.Enabled = True
            BtnEliminar.Enabled = True
            BtnReimpresion.Enabled = True

        Else
            sTransferenciaSelected = ""
            sNombre = ""
            BtnModificar.Enabled = False
            BtnEliminar.Enabled = False
            BtnReimpresion.Enabled = False
        End If
    End Sub

    Private Sub GridTransferencia_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTransferencia.DoubleClick
        If Not GridTransferencia.GetValue(0) Is Nothing Then
            modificarTransferencia()
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbFormato.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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

    Private Sub FrmMtoCompras_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoTransferencia.Dispose()
        ModPOS.MtoTransferencia = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransferencia.Click
        If validaForm() Then
            If ModPOS.Transferencia Is Nothing Then
                ModPOS.Transferencia = New FrmMOVALM
                ModPOS.Transferencia.Padre = "Nuevo"
                ModPOS.Transferencia.Formato = cmbFormato.SelectedValue

                ' ModPOS.Transferencia.TxtSucursal.Text = CmbAlmacen.SelectedItem.row.itemarray(1)
                ModPOS.Transferencia.ALMClave = Me.CmbSucursal.SelectedValue

            End If
            ModPOS.Transferencia.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Transferencia.Show()
            ModPOS.Transferencia.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click

        If cmbFormato.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un formato de impresión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim foundRows() As DataRow
        foundRows = dtTraspaso.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            If cmbFormato.SelectedValue = 1 Then

                Dim dtTicket As DataTable
                dtTicket = ModPOS.SiExisteRecupera("sp_recupera_tikclave", "@SUCClave", CmbSucursal.SelectedValue)

                Dim sTIKClave As String = ""
                If Not dtTicket Is Nothing Then
                    sTIKClave = dtTicket.Rows(0)("TIKClave")
                    dtTicket.Dispose()
                End If

                For i = 0 To foundRows.GetUpperBound(0)
                    imprimirTicketTransferencia(sTIKClave, True, foundRows(i)("MVAClave"))
                Next
            Else
                For i = 0 To foundRows.GetUpperBound(0)
                    imprimirReporteTransferencia(foundRows(i)("MVAClave"))
                Next
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado un Traspaso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarTransferencia()


        If sTransferenciaSelected <> "" Then
            If ModPOS.Transferencia Is Nothing Then
                ModPOS.Transferencia = New FrmMOVALM
                With ModPOS.Transferencia
                    .Text = "Modificar Traspaso"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .Formato = IIf(cmbFormato.SelectedValue Is Nothing, 2, cmbFormato.SelectedValue)

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", Me.sTransferenciaSelected)
                    .MVAClave = dt.Rows(0)("MVAClave")
                    .Tipo = dt.Rows(0)("Tipo")
                    .Motivo = IIf(dt.Rows(0)("Motivo").GetType.Name = "DBNull", "", dt.Rows(0)("Motivo"))
                    .Solicita = IIf(dt.Rows(0)("Solicita").GetType.Name = "DBNull", "", dt.Rows(0)("Solicita"))
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .ALMDestino = dt.Rows(0)("ALMDestino")
                    .Folio = dt.Rows(0)("Folio")
                    .FecRegistro = dt.Rows(0)("FechaRegistro")
                    .Notas = dt.Rows(0)("Notas")
                    .Estado = dt.Rows(0)("Estado")
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))

                    '.TxtSucursal.Text = dt.Rows(0)("NAlmacen")
                    .DescripcionEstado = dt.Rows(0)("NEstado")
                    dt.Dispose()

                End With
            End If

            ModPOS.Transferencia.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Transferencia.Show()
            ModPOS.Transferencia.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.modificarTransferencia()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click

        Dim foundRows() As DataRow
        foundRows = dtTraspaso.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar los traspasos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim dSaldo As Double = IIf(dtTraspaso.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtTraspaso.Compute("Sum(Total)", "Marca = True"))

                    Dim a As New MeAutorizacion
                    a.Sucursal = Me.CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim i As Integer
                            For i = 0 To foundRows.GetUpperBound(0)
                                Dim dt As DataTable
                                Dim iEstado As Integer
                                dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", foundRows(i)("MVAClave"))
                                iEstado = dt.Rows(0)("Estado")
                                dt.Dispose()
                                If iEstado = 1 Then
                                    ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("MVAClave"), "@Usuario", ModPOS.UsuarioActual)
                                    refrescaGrid()
                                Else
                                    MessageBox.Show("No es posible cancelar el Traspaso: " & CStr(foundRows(i)("Folio")), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Next
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡No se ha seleccionado un Traspaso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Combos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub





    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

  
    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtTraspaso.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To dtTraspaso.Rows.Count - 1
                    dtTraspaso.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtTraspaso.Rows.Count - 1
                    dtTraspaso.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub



  
End Class
