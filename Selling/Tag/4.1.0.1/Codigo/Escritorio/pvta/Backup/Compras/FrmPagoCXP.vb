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
    Friend WithEvents BtnPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Almacen As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoCXP))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.Almacen = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.BtnPago = New Janus.Windows.EditControls.UIButton
        Me.LblTotal = New System.Windows.Forms.Label
        Me.GridCxC = New Janus.Windows.GridEX.GridEX
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
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
        Me.GrpTickets.Controls.Add(Me.Almacen)
        Me.GrpTickets.Controls.Add(Me.CmbAlmacen)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.LblSaldo)
        Me.GrpTickets.Controls.Add(Me.BtnPago)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GrpTickets.Location = New System.Drawing.Point(7, 35)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(785, 433)
        Me.GrpTickets.TabIndex = 0
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cuentas por Pagar"
        '
        'Almacen
        '
        Me.Almacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Almacen.Location = New System.Drawing.Point(401, 17)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(78, 15)
        Me.Almacen.TabIndex = 107
        Me.Almacen.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(485, 14)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(292, 24)
        Me.CmbAlmacen.TabIndex = 106
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 18)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(123, 19)
        Me.ChkMarcaTodos.TabIndex = 102
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(594, 390)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(307, 392)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(184, 35)
        Me.LblSaldo.TabIndex = 48
        Me.LblSaldo.Text = "0.00"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnPago
        '
        Me.BtnPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPago.Image = CType(resources.GetObject("BtnPago.Image"), System.Drawing.Image)
        Me.BtnPago.Location = New System.Drawing.Point(690, 389)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(90, 37)
        Me.BtnPago.TabIndex = 1
        Me.BtnPago.Text = "F5- Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTotal.Location = New System.Drawing.Point(102, 395)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(200, 32)
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
        Me.GridCxC.Location = New System.Drawing.Point(7, 41)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(772, 343)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'LblClave
        '
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblClave.Location = New System.Drawing.Point(11, 13)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(81, 15)
        Me.LblClave.TabIndex = 100
        Me.LblClave.Text = "Proveedor"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(109, 11)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(423, 20)
        Me.TxtRazonSocial.TabIndex = 101
        '
        'FrmPagoCXP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(799, 473)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtRazonSocial)
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
        Me.PerformLayout()

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

        If Not CmbAlmacen.SelectedValue Is Nothing Then
            LlenaGridVencimiento = True
            If Not dtCxP Is Nothing Then
                dtCxP.Dispose()
            End If


            Cursor.Current = Cursors.WaitCursor

            dtCxP = ModPOS.Recupera_Tabla("sp_recupera_cxp", "@ALMClave", CmbAlmacen.SelectedValue, "@PRVClave", PRVClave)
            GridCxC.DataSource = dtCxP
            GridCxC.RetrieveStructure()
            GridCxC.AutoSizeColumns()

            GridCxC.RootTable.Columns("ID").Visible = False
            GridCxC.CurrentTable.Columns(2).Selectable = False
            GridCxC.CurrentTable.Columns(3).Selectable = False
            GridCxC.CurrentTable.Columns(4).Selectable = False
            GridCxC.CurrentTable.Columns(5).Selectable = False
            GridCxC.CurrentTable.Columns(6).Selectable = False
            GridCxC.CurrentTable.Columns(7).Selectable = False
            GridCxC.CurrentTable.Columns(8).Selectable = False
            GridCxC.CurrentTable.Columns("Vencido").Visible = False


            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCxC.RootTable.Columns("Vencido"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
            fc.FormatStyle.ForeColor = Color.Red
            GridCxC.RootTable.FormatConditions.Add(fc)


            DSaldo = 0
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(DSaldo, 2)), "Currency")
            Cursor.Current = Cursors.Default

            ChkMarcaTodos.Enabled = True
        Else
            Beep()
            MessageBox.Show("¡Verifique el almacén seleccionado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Private Function imprimeRecibo(ByVal Abono As String, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal cte As String) As Boolean
    '    Dim dTotalPagos, dPagos As Double

    '    Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
    '    Tickets.Generic = Generic
    '    Dim dtTicket As DataTable
    '    dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

    '    If Not dtTicket Is Nothing Then
    '        Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
    '        Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
    '        Tickets.LetraName = dtTicket.Rows(0)("FontName")
    '        If dtTicket.Rows(0)("url_imagen") <> "" Then
    '            Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
    '        End If
    '        dtTicket.Dispose()
    '    End If


    '    Dim dtHeadTicket As DataTable
    '    dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

    '    If Not dtHeadTicket Is Nothing Then
    '        Dim i As Integer
    '        For i = 0 To dtHeadTicket.Rows.Count - 1
    '            Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
    '        Next
    '        dtHeadTicket.Dispose()
    '    End If


    '    'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
    '    'de que al final de cada linea agrega una linea punteada "==========" 
    '    Tickets.AddSubHeaderLine("RECIBO", 1, 3)
    '    Tickets.AddSubHeaderLine("CTE: " & cte, 0, 3)
    '    Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
    '    Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

    '    Dim dtRef As DataTable = ModPOS.Recupera_Tabla("sp_recibo_enc", "@ABNClave", Abono)

    '    Tickets.AddSubHeaderBloqLine("REFERENCIA: " & dtRef.Rows(0)("Referencia"), 0, 1)
    '    Tickets.AddSubHeaderBloqLine("FORMA PAGO: " & dtRef.Rows(0)("Descripcion"), 0, 1)
    '    '        Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency"), 0, 1)

    '    dtRef.Dispose()

    '    'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
    '    'del producto y el tercero es el precio 
    '    Dim dtPagosDetalle As DataTable
    '    dtPagosDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle", "@ABNClave", Abono)

    '    If Not dtPagosDetalle Is Nothing Then
    '        Dim i As Integer = 0
    '        dPagos = dtPagosDetalle.Rows.Count()
    '        For i = 0 To dPagos - 1
    '            Dim sFolio As String = dtPagosDetalle.Rows(i)("Tipo")
    '            Dim sTipo As String = dtPagosDetalle.Rows(i)("Folio")
    '            Dim dImporte As Double = dtPagosDetalle.Rows(i)("Importe")


    '            ' AGREGAR PAGOS A LISTA
    '            Tickets.AddItemRecibo(sFolio, sTipo, dImporte)

    '            dTotalPagos += (dImporte)
    '        Next
    '        dtPagosDetalle.Dispose()
    '    End If

    '    'El metodo AddTotalRecibo requiere 4 parametros 
    '    Tickets.AddTotalRecibo(dTotalPagos, Importe, Cambio, Imprimir.FontEstilo.Negrita)

    '    'El metodo AddFooterLine funciona igual que la cabecera 

    '    Dim dtPieTicket As DataTable
    '    dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

    '    If Not dtPieTicket Is Nothing Then
    '        Dim i As Integer
    '        For i = 0 To dtPieTicket.Rows.Count - 1
    '            Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
    '        Next
    '        dtPieTicket.Dispose()
    '    End If

    '    'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
    '    'parametro de tipo string que debe de ser el nombre de la impresora. 
    '    Tickets.PrintTicket(Impresora, 70, 0)

    'End Function

    Private Sub FrmPagoCXP_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.CxP.RecuperaFolios()
    End Sub

    Private Sub FrmPagoCXP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Me.TxtRazonSocial.Text = sRazonSocial

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With

        BLoad = True

        Me.StartPosition = FormStartPosition.CenterScreen

        RecuperaFolios()

    End Sub

    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        If Not dtCxP Is Nothing AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            foundRows = dtCxP.Select("Marca ='True'")

            If foundRows.GetLength(0) > 0 Then

                Dim a As New FrmPago
                a.SaldoAcumulado = DSaldo
                a.Almacen = CmbAlmacen.SelectedValue
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

    Private Sub GridCxC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCxC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnPago.PerformClick()
        End If
    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnPago.KeyUp, BtnSalir.KeyUp, GridCxC.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F5
                Me.BtnPago.PerformClick()
        End Select
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If BLoad Then
            RecuperaFolios()
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxP.Rows.Count > 0 Then
            Dim i As Integer
            If ChkMarcaTodos.Checked Then
                DSaldo = 0
                For i = 0 To dtCxP.Rows.Count - 1
                    dtCxP.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtCxP.Rows.Count - 1
                    dtCxP.Rows(i)("Marca") = False
                Next
            End If
            DSaldo = IIf(dtCxP.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxP.Compute("Sum(Saldo)", "Marca = True"))
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(DSaldo, 2)), "Currency")
        End If

    End Sub
End Class
