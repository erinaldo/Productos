Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPagoCXP
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents GridCxC As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbPlazo As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkPagados As System.Windows.Forms.CheckBox
    Friend WithEvents Almacen As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoCXP))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.BtnNC = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.cmbPlazo = New System.Windows.Forms.ComboBox()
        Me.btnPago = New Janus.Windows.EditControls.UIButton()
        Me.Almacen = New System.Windows.Forms.Label()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.chkPagados = New System.Windows.Forms.CheckBox()
        Me.GrpTickets.SuspendLayout()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.chkPagados)
        Me.GrpTickets.Controls.Add(Me.BtnNC)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Controls.Add(Me.cmbPlazo)
        Me.GrpTickets.Controls.Add(Me.btnPago)
        Me.GrpTickets.Controls.Add(Me.Almacen)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.LblSaldo)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GrpTickets.Location = New System.Drawing.Point(7, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(917, 564)
        Me.GrpTickets.TabIndex = 0
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cuentas por Pagar"
        '
        'BtnNC
        '
        Me.BtnNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnNC.Icon = CType(resources.GetObject("BtnNC.Icon"), System.Drawing.Icon)
        Me.BtnNC.Location = New System.Drawing.Point(624, 13)
        Me.BtnNC.Name = "BtnNC"
        Me.BtnNC.Size = New System.Drawing.Size(91, 30)
        Me.BtnNC.TabIndex = 140
        Me.BtnNC.Text = "Aplica NC"
        Me.BtnNC.ToolTipText = "Aplicar Nota de Crédito"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(721, 13)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(91, 30)
        Me.BtnCancelar.TabIndex = 139
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el Ticket o Factura"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbPlazo
        '
        Me.cmbPlazo.FormattingEnabled = True
        Me.cmbPlazo.Items.AddRange(New Object() {"15 días", "30 días", "60 días", "90 días"})
        Me.cmbPlazo.Location = New System.Drawing.Point(149, 19)
        Me.cmbPlazo.Name = "cmbPlazo"
        Me.cmbPlazo.Size = New System.Drawing.Size(149, 24)
        Me.cmbPlazo.TabIndex = 138
        '
        'btnPago
        '
        Me.btnPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnPago.Icon = CType(resources.GetObject("btnPago.Icon"), System.Drawing.Icon)
        Me.btnPago.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnPago.Location = New System.Drawing.Point(818, 13)
        Me.btnPago.Name = "btnPago"
        Me.btnPago.Size = New System.Drawing.Size(91, 30)
        Me.btnPago.TabIndex = 108
        Me.btnPago.Text = "Pagar"
        Me.btnPago.ToolTipText = "Registrar Pago de registros seleccionados"
        Me.btnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Almacen
        '
        Me.Almacen.Location = New System.Drawing.Point(101, 24)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(78, 19)
        Me.Almacen.TabIndex = 107
        Me.Almacen.Text = "Plazo"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 24)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(88, 19)
        Me.ChkMarcaTodos.TabIndex = 102
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnSalir.Icon = CType(resources.GetObject("BtnSalir.Icon"), System.Drawing.Icon)
        Me.BtnSalir.Location = New System.Drawing.Point(527, 13)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(91, 30)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(671, 526)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(238, 35)
        Me.LblSaldo.TabIndex = 48
        Me.LblSaldo.Text = "0.00"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTotal.Location = New System.Drawing.Point(505, 533)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(160, 21)
        Me.LblTotal.TabIndex = 47
        Me.LblTotal.Text = "TOTAL A PAGAR"
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(6, 48)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(904, 475)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'chkPagados
        '
        Me.chkPagados.Location = New System.Drawing.Point(314, 24)
        Me.chkPagados.Name = "chkPagados"
        Me.chkPagados.Size = New System.Drawing.Size(155, 19)
        Me.chkPagados.TabIndex = 141
        Me.chkPagados.Text = "Incluir Pagados"
        '
        'FrmPagoCXP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(931, 572)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmPagoCXP"
        Me.Text = "Cuentas por Pagar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private reloj As parpadea
    Private dtCxP As DataTable
    Private BLoad As Boolean
    Private DSaldo As Double
    Private LlenaGridVencimiento As Boolean

    Public SUCClave As String = ""
    Public PRVClave As String = ""
    Public sRazonSocial As String = ""


    Private Sub RecuperaFolios()

        If Not cmbPlazo.SelectedItem Is Nothing Then
            LlenaGridVencimiento = True
            If Not dtCxP Is Nothing Then
                dtCxP.Dispose()
            End If


            Cursor.Current = Cursors.WaitCursor

            Dim iPagado As Integer
            If chkPagados.Checked Then
                iPagado = 1
            Else
                iPagado = 0
            End If

            dtCxP = ModPOS.Recupera_Tabla("sp_recupera_cxp", "@Plazo", cmbPlazo.SelectedItem, "@COMClave", ModPOS.CompanyActual, "@Pagado", iPagado)
            GridCxC.DataSource = dtCxP
            GridCxC.RetrieveStructure()
            GridCxC.AutoSizeColumns()

            GridCxC.RootTable.Columns("ID").Visible = False
            GridCxC.CurrentTable.Columns("Vencido").Visible = False
            GridCxC.RootTable.Columns("ALMClave").Visible = False
            GridCxC.RootTable.Columns("SUCClave").Visible = False
            GridCxC.RootTable.Columns("PRVClave").Visible = False

            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCxC.RootTable.Columns("Vencido"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
            fc.FormatStyle.ForeColor = Color.Red
            GridCxC.RootTable.FormatConditions.Add(fc)


            Dim fc2 As Janus.Windows.GridEX.GridEXFormatCondition
            fc2 = New Janus.Windows.GridEX.GridEXFormatCondition(GridCxC.RootTable.Columns("Saldo"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)
            fc2.FormatStyle.ForeColor = Color.Blue
            GridCxC.RootTable.FormatConditions.Add(fc2)



            DSaldo = 0
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(DSaldo, 2)), "Currency")
            Cursor.Current = Cursors.Default

            ChkMarcaTodos.Enabled = True
        Else
            Beep()
            MessageBox.Show("¡Verifique el almacén seleccionado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

   
    Private Sub FrmPagoCXP_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.CxP.RecuperaFolios()

        ModPOS.CxP.Dispose()
        ModPOS.CxP = Nothing
    End Sub

    Private Sub FrmPagoCXP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        cmbPlazo.SelectedItem = "15 días"

        BLoad = True

        Me.StartPosition = FormStartPosition.CenterScreen

        RecuperaFolios()

    End Sub


    Private Sub GridCxC_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        If GridCxC.GetValue("Marca") = True Then
            DSaldo += CDbl(GridCxC.GetValue("Saldo"))
        Else
            DSaldo -= CDbl(GridCxC.GetValue("Saldo"))
        End If
        Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(DSaldo, 2)), "Currency")

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub GridCxC_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridCxC.CurrentCellChanged
        If Not GridCxC.CurrentColumn Is Nothing Then
            If GridCxC.CurrentColumn.Caption = "Marca" Then
                GridCxC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridCxC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridCxC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCxC.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim foundRows() As DataRow

            foundRows = dtCxP.Select("Marca ='True' and Saldo > 0")

            If foundRows.GetLength(0) > 0 Then
                Me.btnPago.PerformClick()
            End If
        End If

    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnSalir.KeyUp, GridCxC.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F5
                Me.btnPago.PerformClick()
        End Select
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If BLoad Then
            RecuperaFolios()
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxP.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            dtCxP.AcceptChanges()
            GridCxC.Refresh()
            DSaldo = IIf(dtCxP.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxP.Compute("Sum(Saldo)", "Marca = True"))
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(DSaldo, 2)), "Currency")
        End If

    End Sub


    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPago.Click
        If Not dtCxP Is Nothing AndAlso Not cmbPlazo.SelectedItem Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            foundRows = dtCxP.Select("Marca ='True' and Saldo > 0")

            If foundRows.GetLength(0) > 0 Then

                Dim fr() As DataRow
                fr = dtCxP.Select("Marca ='True' and Proveedor <> '" & foundRows(0)("Proveedor") & "'")

                If fr.GetLength(0) >= 1 Then
                    MessageBox.Show("No es posible realizar pagos a compras de diferentes proveedores a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                Dim a As New FrmPago
                a.SaldoAcumulado = DSaldo

                a.ShowDialog()

                If a.DialogResult = DialogResult.OK Then

                    Dim SaldoDisponible As Double

                    SaldoDisponible = a.TotalPago

                    For i = 0 To foundRows.GetUpperBound(0)

                        Select Case Redondear(SaldoDisponible, 2)
                            Case Is > Redondear(foundRows(i)("Saldo"), 2)
                                ModPOS.Ejecuta("sp_paga_factura", _
                                                              "@PAGClave", a.AbonoClave, _
                                                              "@COMClave", foundRows(i)("ID"), _
                                                              "@Importe", foundRows(i)("Saldo"), _
                                                              "@Tipo", foundRows(i)("Tipo"), _
                                                              "@Usuario", ModPOS.UsuarioActual)
                                SaldoDisponible -= foundRows(i)("Saldo")
                            Case Is < Redondear(foundRows(i)("Saldo"), 2)
                                ModPOS.Ejecuta("sp_paga_factura", _
                                               "@PAGClave", a.AbonoClave, _
                                               "@Importe", SaldoDisponible, _
                                               "@COMClave", foundRows(i)("ID"), _
                                               "@Tipo", foundRows(i)("Tipo"), _
                                               "@Usuario", ModPOS.UsuarioActual)
                                SaldoDisponible -= SaldoDisponible

                            Case Is = Redondear(foundRows(i)("Saldo"), 2)
                                ModPOS.Ejecuta("sp_paga_factura", _
                                               "@PAGClave", a.AbonoClave, _
                                               "@COMClave", foundRows(i)("ID"), _
                                               "@Importe", SaldoDisponible, _
                                               "@Tipo", foundRows(i)("Tipo"), _
                                               "@Usuario", ModPOS.UsuarioActual)
                                SaldoDisponible -= SaldoDisponible
                        End Select

                        If SaldoDisponible <= 0 Then
                            Exit For
                        End If
                    Next

                End If

                dtCxP.Dispose()

                RecuperaFolios()

            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub cmbPlazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlazo.SelectedIndexChanged
        If BLoad = True Then
            RecuperaFolios()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Dim a As New FrmCancelacion
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub Aplica_NC(ByVal foundRows() As DataRow, ByVal PRVClave As String, ByVal NCPClave As String, ByVal TotalAbono As Double, ByVal SaldoVenta As Double, ByVal TotalCambio As Double, ByVal TipoDocumento As Integer)
        Dim i As Integer


        If foundRows.GetLength(0) = 1 Then

            Dim TotalPagoAplicar As Double

            Select Case Redondear(TotalAbono, 2)
                Case Is >= Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = SaldoVenta


                    ModPOS.Ejecuta("sp_paga_factura", _
                                                             "@PAGClave", NCPClave, _
                                                             "@COMClave", foundRows(i)("ID"), _
                                                             "@Importe", TotalPagoAplicar, _
                                                             "@Tipo", foundRows(i)("Tipo"), _
                                                             "@TipoDocumento", TipoDocumento, _
                                                             "@Usuario", ModPOS.UsuarioActual)

                Case Is < Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = TotalAbono

                    ModPOS.Ejecuta("sp_paga_factura", _
                                                       "@PAGClave", NCPClave, _
                                                       "@COMClave", foundRows(i)("ID"), _
                                                       "@Importe", TotalPagoAplicar, _
                                                       "@Tipo", foundRows(i)("Tipo"), _
                                                       "@TipoDocumento", TipoDocumento, _
                                                       "@Usuario", ModPOS.UsuarioActual)


            End Select

        Else
            Dim SaldoDisponible As Double
            SaldoDisponible = TotalAbono

            For i = 0 To foundRows.GetUpperBound(0)

                Select Case Redondear(SaldoDisponible, 2)
                    Case Is >= Redondear(foundRows(i)("Saldo"), 2)

                        ModPOS.Ejecuta("sp_paga_factura", _
                                                            "@PAGClave", NCPClave, _
                                                            "@COMClave", foundRows(i)("ID"), _
                                                            "@Importe", foundRows(i)("Saldo"), _
                                                            "@Tipo", foundRows(i)("Tipo"), _
                                                            "@TipoDocumento", TipoDocumento, _
                                                            "@Usuario", ModPOS.UsuarioActual)


                        SaldoDisponible -= foundRows(i)("Saldo")

                    Case Is < Redondear(foundRows(i)("Saldo"), 2)

                        ModPOS.Ejecuta("sp_paga_factura", _
                                                         "@PAGClave", NCPClave, _
                                                         "@COMClave", foundRows(i)("ID"), _
                                                         "@Importe", SaldoDisponible, _
                                                         "@Tipo", foundRows(i)("Tipo"), _
                                                         "@TipoDocumento", TipoDocumento, _
                                                         "@Usuario", ModPOS.UsuarioActual)

                        SaldoDisponible -= SaldoDisponible


                End Select

                If SaldoDisponible <= 0 Then
                    Exit For
                End If
            Next
        End If



    End Sub


    Private Sub BtnNC_Click(sender As Object, e As EventArgs) Handles BtnNC.Click

        If Not dtCxP Is Nothing AndAlso Not cmbPlazo.SelectedItem Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            foundRows = dtCxP.Select("Marca ='True'")

            If foundRows.GetLength(0) > 0 Then

                Dim fr() As DataRow
                fr = dtCxP.Select("Marca ='True' and Proveedor <> '" & foundRows(0)("Proveedor") & "'")

                If fr.GetLength(0) >= 1 Then
                    MessageBox.Show("No es posible aplicar Notas de Credito a diferentes proveedores a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                Dim b As New FrmAplicar
                b.PRVClave = foundRows(0)("PRVClave")

                b.SaldoDocumento = IIf(dtCxP.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxP.Compute("Sum(Saldo)", "Marca = True"))
                b.ShowDialog()

                If b.DialogResult = DialogResult.OK Then
                    If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then

                        For i = 0 To b.drAbonos.Length - 1
                            Aplica_NC(foundRows, foundRows(0)("PRVClave"), b.drAbonos(i)("ID"), b.drAbonos(i)("Saldo"), DSaldo, IIf(b.drAbonos(i)("Saldo") > DSaldo, b.drAbonos(i)("Saldo") - DSaldo, 0), b.drAbonos(i)("TipoDocumento"))
                        Next

                        RecuperaFolios()

                    End If
                End If


            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub chkPagados_CheckedChanged(sender As Object, e As EventArgs) Handles chkPagados.CheckedChanged
        If BLoad = True Then
            RecuperaFolios()
        End If
    End Sub
End Class
