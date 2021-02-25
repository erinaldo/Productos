Public Class FrmReimpresion
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents GridTickets As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReimpresion))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridTickets = New Janus.Windows.GridEX.GridEX
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox3)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.CmbCampo)
        Me.GrpTickets.Controls.Add(Me.TxtBuscar)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.TxtFolio)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridTickets)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(7, -1)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(778, 426)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(652, 19)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(120, 22)
        Me.dtPicker.TabIndex = 54
        Me.dtPicker.Value = New Date(2014, 7, 8, 23, 21, 0, 0)
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(634, 22)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 45
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(268, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 44
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(150, 19)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(138, 24)
        Me.CmbCampo.TabIndex = 43
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(293, 19)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(354, 22)
        Me.TxtBuscar.TabIndex = 42
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 47)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(158, 23)
        Me.ChkMarcaTodos.TabIndex = 3
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(53, 19)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(90, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(137, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio"
        '
        'GridTickets
        '
        Me.GridTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTickets.ColumnAutoResize = True
        Me.GridTickets.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTickets.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTickets.GroupByBoxVisible = False
        Me.GridTickets.Location = New System.Drawing.Point(7, 72)
        Me.GridTickets.Name = "GridTickets"
        Me.GridTickets.RecordNavigator = True
        Me.GridTickets.Size = New System.Drawing.Size(765, 347)
        Me.GridTickets.TabIndex = 4
        Me.GridTickets.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 431)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Agrega registro seleccionado"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmReimpresion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmReimpresion"
        Me.Text = "Impresión"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    'Private sSelected As String
    Public TipoReimpresion As String
    Public Impresora As String
    Public SUCClave As String
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private dt As DataTable
    Private bLoad As Boolean = False
    Private FormatoFactura As String

    Private Periodo, Mes As Integer

    Private Sub FrmReimpresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "FormatFac", "@COMClave", ModPOS.CompanyActual)
        FormatoFactura = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Valor"))
        dt.Dispose()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
     
        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        ChkMarcaTodos.Enabled = False
        bLoad = True

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtFolio.Text.Trim = "" AndAlso TxtBuscar.Text.Trim = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbCampo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dt.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dt Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            ' Usa el metodo select para filtrar los registros seleccionados.
            foundRows = dt.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then

                Dim sImpresora As String

                If Impresora <> "" Then
                    Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
                    sImpresora = dtPrinter.Rows(0)("Referencia")
                    dtPrinter.Dispose()
                Else
                    If PrintDialog1.ShowDialog() = DialogResult.OK Then
                        sImpresora = PrintDialog1.PrinterSettings.PrinterName
                    Else
                        Exit Sub
                    End If
                End If

                For i = 0 To foundRows.GetUpperBound(0)

                    Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                    Dim MonRef, MonDesc As String
                    Dim TipoCambio As Double
                    Dim dt As DataTable

                    Select Case TipoReimpresion
                        Case Is = "Factura"

                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            dt.Dispose()


                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"

                            'OpenReport.PrintPreview("Factura", "CRFactura.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(TotalFactura, 2)).ToUpper)
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", foundRows(i)("ID")))

                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", foundRows(i)("ID")))

                            If iTipoCF = 1 Then
                                If FormatoFactura = "Clasico" Then
                                    OpenReport.Print("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                                Else
                                    OpenReport.Print("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                                End If
                            ElseIf iTipoCF = 2 Then
                                If FormatoFactura = "Clasico" Then
                                    OpenReport.Print("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                                Else
                                    OpenReport.Print("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                                End If
                            ElseIf iTipoCF = 3 Then
                                OpenReport.Print("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            End If

                        Case Is = "NC"
                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            dt.Dispose()

                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"

                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", foundRows(i)("ID")))

                            If iTipoCF = 1 Then
                                OpenReport.Print("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            ElseIf iTipoCF = 2 Then
                                OpenReport.Print("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                            ElseIf iTipoCF = 3 Then
                                OpenReport.Print("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            End If


                        Case Is = "NotaCargo"
                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            dt.Dispose()

                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"

                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", foundRows(i)("ID")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", foundRows(i)("ID")))

                            OpenReport.Print("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                    End Select


                Next
                dt.Dispose()
                Me.Close()
            Else
                MessageBox.Show("Para agregar, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub


    Private Sub ActGrid()
        If validaForm() Then

            If Not dt Is Nothing Then
                dt.Dispose()
            End If

            Select Case TipoReimpresion
                Case Is = "Factura"
                    dt = ModPOS.Recupera_Tabla("sp_reimpresion_doc", "@Tipo", 1, "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), "@Periodo", Periodo, "@Mes", Mes, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"))
                Case Is = "NC"
                    dt = ModPOS.Recupera_Tabla("sp_reimpresion_doc", "@Tipo", 2, "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), "@Periodo", Periodo, "@Mes", Mes, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"))
                Case Is = "NotaCargo"
                    dt = ModPOS.Recupera_Tabla("sp_reimpresion_doc", "@Tipo", 3, "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), "@Periodo", Periodo, "@Mes", Mes, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"))
            End Select


            GridTickets.DataSource = dt
            GridTickets.RetrieveStructure()
            GridTickets.AutoSizeColumns()
            GridTickets.RootTable.Columns("ID").Visible = False
            GridTickets.CurrentTable.Columns(2).Selectable = False
            GridTickets.CurrentTable.Columns(3).Selectable = False
            GridTickets.CurrentTable.Columns(4).Selectable = False
            GridTickets.CurrentTable.Columns(5).Selectable = False
            GridTickets.CurrentTable.Columns(6).Selectable = False
            GridTickets.CurrentTable.Columns(7).Selectable = False
            GridTickets.RootTable.Columns("TipoCF").Visible = False

            GridTickets.RootTable.Columns("Marca").Width = 30
            GridTickets.RootTable.Columns("Folio").Width = 30
            GridTickets.RootTable.Columns("Total").Width = 40
            GridTickets.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridTickets.RootTable.Columns("Clave").Width = 30
            GridTickets.RootTable.Columns("Razón Social").Width = 200
            GridTickets.RootTable.Columns("RFC").Width = 70
            GridTickets.RootTable.Columns("Fecha").Width = 40

            If dt.Rows.Count > 0 Then
                ChkMarcaTodos.Enabled = True
            Else
                ChkMarcaTodos.Enabled = False
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtFolio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyUp
        If TxtFolio.Text.Trim <> "" Then
            ActGrid()
        End If
    End Sub


    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If TxtBuscar.Text.Trim <> "" Then
            ActGrid()
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            ActGrid()
        End If
    End Sub

    Private Sub CmbCampo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCampo.SelectedValueChanged
        If bLoad = True AndAlso Not CmbCampo.SelectedValue Is Nothing Then
            ActGrid()
        End If
    End Sub
End Class
