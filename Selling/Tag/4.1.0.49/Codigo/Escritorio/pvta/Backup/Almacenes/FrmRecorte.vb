Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRecorte
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblSolicitado As System.Windows.Forms.Label
    Friend WithEvents LblDisponible As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecorte))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.lblRazonSocial = New System.Windows.Forms.Label
        Me.lblCiudad = New System.Windows.Forms.Label
        Me.lblColonia = New System.Windows.Forms.Label
        Me.lblCalle = New System.Windows.Forms.Label
        Me.lblCliente = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblFecha = New System.Windows.Forms.Label
        Me.lblFolio = New System.Windows.Forms.Label
        Me.LblCredito = New System.Windows.Forms.Label
        Me.LblDisponible = New System.Windows.Forms.Label
        Me.LblSolicitado = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpGeneral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 555)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 555)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 167)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 382)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 19)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(765, 358)
        Me.GridDetalle.TabIndex = 6
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.lblRazonSocial)
        Me.GrpGeneral.Controls.Add(Me.lblCiudad)
        Me.GrpGeneral.Controls.Add(Me.LblDisponible)
        Me.GrpGeneral.Controls.Add(Me.lblColonia)
        Me.GrpGeneral.Controls.Add(Me.LblCredito)
        Me.GrpGeneral.Controls.Add(Me.lblCalle)
        Me.GrpGeneral.Controls.Add(Me.lblCliente)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 6)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(559, 155)
        Me.GrpGeneral.TabIndex = 6
        Me.GrpGeneral.TabStop = False
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(11, 34)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(543, 17)
        Me.lblRazonSocial.TabIndex = 106
        Me.lblRazonSocial.Text = "Razón Social:"
        '
        'lblCiudad
        '
        Me.lblCiudad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiudad.Location = New System.Drawing.Point(11, 91)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(543, 17)
        Me.lblCiudad.TabIndex = 104
        Me.lblCiudad.Text = "Localidad:"
        '
        'lblColonia
        '
        Me.lblColonia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColonia.Location = New System.Drawing.Point(11, 72)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(543, 17)
        Me.lblColonia.TabIndex = 103
        Me.lblColonia.Text = "Colonia/CP:"
        '
        'lblCalle
        '
        Me.lblCalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCalle.Location = New System.Drawing.Point(11, 54)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(543, 16)
        Me.lblCalle.TabIndex = 102
        Me.lblCalle.Text = "Calle:"
        '
        'lblCliente
        '
        Me.lblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(11, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(543, 16)
        Me.lblCliente.TabIndex = 101
        Me.lblCliente.Text = "Cliente:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblTotal)
        Me.GroupBox1.Controls.Add(Me.LblSolicitado)
        Me.GroupBox1.Controls.Add(Me.LblFecha)
        Me.GroupBox1.Controls.Add(Me.lblFolio)
        Me.GroupBox1.Location = New System.Drawing.Point(571, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 155)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'LblFecha
        '
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.Location = New System.Drawing.Point(6, 36)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(202, 15)
        Me.LblFecha.TabIndex = 174
        Me.LblFecha.Text = "Fecha:"
        '
        'lblFolio
        '
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(6, 16)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(202, 15)
        Me.lblFolio.TabIndex = 104
        Me.lblFolio.Text = "Folio:"
        '
        'LblCredito
        '
        Me.LblCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCredito.Location = New System.Drawing.Point(11, 116)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(348, 15)
        Me.LblCredito.TabIndex = 175
        Me.LblCredito.Text = "Limite de Crédito:"
        '
        'LblDisponible
        '
        Me.LblDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisponible.Location = New System.Drawing.Point(11, 135)
        Me.LblDisponible.Name = "LblDisponible"
        Me.LblDisponible.Size = New System.Drawing.Size(324, 15)
        Me.LblDisponible.TabIndex = 176
        Me.LblDisponible.Text = "Disponible:"
        '
        'LblSolicitado
        '
        Me.LblSolicitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSolicitado.Location = New System.Drawing.Point(6, 116)
        Me.LblSolicitado.Name = "LblSolicitado"
        Me.LblSolicitado.Size = New System.Drawing.Size(202, 15)
        Me.LblSolicitado.TabIndex = 177
        Me.LblSolicitado.Text = "Total Solicitado:"
        '
        'LblTotal
        '
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(6, 137)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(202, 15)
        Me.LblTotal.TabIndex = 178
        Me.LblTotal.Text = "Total Actual:"
        '
        'FrmRecorte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmRecorte"
        Me.Text = "Recorte de Pedido"
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpGeneral.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public VENClave As String
    Public Total As Double
    Public ALMClave As String
    Public Fecha As DateTime

    Private dtDetalle As DataTable
    Private bLoad As Boolean


    Private Sub FrmRecorte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bLoad = False

        CargaDatosTicket(VENClave)

        dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_detalle_corte", "@VENClave", VENClave, "@ALMClave", ALMClave)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DVEClave").Visible = False
        GridDetalle.RootTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        GridDetalle.CurrentTable.Columns("Solicitado").Selectable = False
        GridDetalle.CurrentTable.Columns("Subtotal").Visible = False
        GridDetalle.CurrentTable.Columns("Total").Visible = False
        GridDetalle.CurrentTable.Columns("Disponible").Selectable = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Disponible"), Janus.Windows.GridEX.ConditionOperator.LessThan, GridDetalle.GetValue("Cantidad"))
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)

        bLoad = True


    End Sub

    Private Sub FrmRecorte_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.Pedidos Is Nothing Then
            ModPOS.Pedidos.AgregarFolio()
        End If
        ModPOS.Recorte.Dispose()
        ModPOS.Recorte = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Valida si existen productos pendientes de surtir

        Dim dSurtido As Double
        Dim bCerrar As Boolean = False

        dSurtido = dtDetalle.Compute("SUM(Cantidad)", "")

        If dSurtido <= 0 Then
            Select Case MessageBox.Show("El pedido será cancelado al no tener producto. ¿Desea continuar con la cancelación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    Exit Sub
                Case Else
                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", VENClave, "@TipoDoc", 1)
                    bCerrar = True
                    Me.Close()

                    ' Exit Sub
            End Select
        End If


        If bCerrar = False Then
            Dim foundRows() As DataRow

            foundRows = dtDetalle.Select("Solicitado <> Cantidad ")
            If foundRows.GetLength(0) > 0 Then

                Dim i As Integer

                For i = 0 To foundRows.GetUpperBound(0)

                    ModPOS.Ejecuta("sp_upd_ventadetalle", "@VENClave", VENClave, "@DVEClave", foundRows(i)("DVEClave"), "@Cantidad", foundRows(i)("Cantidad"))

                Next

                ModPOS.Ejecuta("sp_recalcula_documento", _
                                "@Tipo", 1, _
                                "@Documento", VENClave)

                Select Case MessageBox.Show("¿Desea imprimir el pedido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        ImprimirPedido()
                End Select
            End If
        End If

        Me.Close()

    End Sub

    Private Sub ImprimirPedido()

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
        Dim TotalVenta As Double = dt.Rows(0)("Total")
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_ped", "@VENClave", VENClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.DataSetName = "pvtaDataSet"
        OpenReport.PrintPreview("Pedido", "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(Total, 2)).ToUpper)


    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridDetalle.GetValue("Cantidad")) Then
                Select Case CDbl(GridDetalle.GetValue("Cantidad"))
                    Case Is > CDbl(GridDetalle.GetValue("Solicitado"))
                            Beep()
                        MessageBox.Show("¡La cantidad a surtir no de ser mayor a la solicitada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridDetalle.SetValue("Cantidad", CDbl(GridDetalle.GetValue("Solicitado")))
                    Case Is < 0
                        GridDetalle.SetValue("Cantidad", 0)
                    Case Else
                        If CDbl(GridDetalle.GetValue("Cantidad")) > CDbl(GridDetalle.GetValue("Disponible")) Then
                            If CDbl(GridDetalle.GetValue("Disponible")) >= 0 Then

                                MessageBox.Show("¡La cantidad a surtir es mayor a la disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                GridDetalle.SetValue("Cantidad", CDbl(GridDetalle.GetValue("Disponible")))
                            End If
                        End If
                End Select

                GridDetalle.SetValue("Total", CDbl(GridDetalle.GetValue("Cantidad")) * CDbl(GridDetalle.GetValue("Subtotal")))

                If GridDetalle.RootTable.FormatConditions.Count = 1 Then
                    Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
                    fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Disponible"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, GridDetalle.GetValue("Cantidad"))
                    fc1.FormatStyle.ForeColor = System.Drawing.Color.Black
                    GridDetalle.RootTable.FormatConditions.Add(fc1)
                End If

            Else
                GridDetalle.SetValue("Cantidad", 0)
            End If

        End If

    End Sub

    Private Sub CargaDatosTicket(ByVal sVENClave As String)
        'Valida que el campo Ticket no se encuentre vacio
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", sVENClave)

        If dt.Rows.Count > 0 Then
            lblFolio.Text = "Folio: " & dt.Rows(0)("Folio")
            LblFecha.Text = "Fecha: " & String.Format("{0:dd/MM/yyyy}", dt.Rows(0)("Fecha"))
            LblSolicitado.Text = "Total Solicitado: $" & String.Format(CStr(ModPOS.Redondear(dt.Rows(0)("Total"), 2)), "Currency")
            LblTotal.Text = "Total Actual: $" & String.Format(CStr(ModPOS.Redondear(dt.Rows(0)("Total"), 2)), "Currency")

            lblCliente.Text = "Cliente: " & dt.Rows(0)("Clave") & "   RFC: " & dt.Rows(0)("id_Fiscal")
            lblRazonSocial.Text = dt.Rows(0)("RazonSocial")
            lblCalle.Text = dt.Rows(0)("Calle")
            lblColonia.Text = dt.Rows(0)("Domicilio1")
            lblCiudad.Text = dt.Rows(0)("Domicilio2")

            LblCredito.Text = "Limite Crédito: $" & String.Format(CStr(ModPOS.Redondear(dt.Rows(0)("LimiteCredito"), 2)), "Currency")

            If dt.Rows(0)("LimiteCredito") = 0 Then
                LblDisponible.Text = "Disponible: $ 0.00"
            Else
                LblDisponible.Text = "Disponible: $" & String.Format(CStr(ModPOS.Redondear(dt.Rows(0)("LimiteCredito") - dt.Rows(0)("SaldoCte"), 2)), "Currency")
            End If
            
            
        End If

        dt.Dispose()
    End Sub

   

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        Dim Total As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)

        LblTotal.Text = "Total Actual: $" & String.Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

    End Sub
End Class
