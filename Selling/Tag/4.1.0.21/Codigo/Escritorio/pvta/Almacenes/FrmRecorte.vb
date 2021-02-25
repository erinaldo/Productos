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
    Public SUCClave As String
    Public FormatoPedido As String
    Private dtDetalle As DataTable
    Private bLoad As Boolean

    Private Sub recalculaPartidaPedido(ByVal dtDetalle As DataTable, ByVal DOCClave As String, ByVal DETClave As String, ByVal dCantidadOriginal As Decimal, ByVal dFaltante As Decimal)
        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("DVEClave = '" & DETClave & "'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer

            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer


            Dim sTipoDesc As String = ""



            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")


                dCantidad = dCantidadOriginal - dFaltante


             
                dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

                Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", foundRows(i)("DVEClave"))
                If Not dtDescuento Is Nothing Then
                    'Descuento General
                    Dim foundRows1() As DataRow = dtDescuento.Select(" Tipo = 1 ")
                    If foundRows1.Length = 1 Then
                        dDescGeneralPorc = foundRows1(0)("DescuentoPorc")
                    Else
                        dDescGeneralPorc = 0
                    End If

                    'Descuento Volumen
                    foundRows1 = dtDescuento.Select(" Tipo = 2")
                    If foundRows1.Length = 1 Then
                        oVolumen = foundRows1(0)("DescuentoPorc")
                    Else
                        oVolumen = 0
                    End If


                    'Descuento Gerencial
                    foundRows1 = dtDescuento.Select(" Tipo = 3 ")
                    If foundRows1.Length = 1 Then
                        dDescPorc = foundRows1(0)("DescuentoPorc")
                    Else
                        dDescPorc = 0
                    End If
                    dtDescuento.Dispose()
                Else
                    dDescPorc = 0
                    oVolumen = 0
                    dDescGeneralPorc = 0
                End If

                dDescGeneralImp = Math.Round(dBase * dDescGeneralPorc, 2)

                If oVolumen > 0 Then

                    Dim StrucVol As DescVol

                    StrucVol = obtenerDescuentoVolumen(foundRows(i)("Cliente"), iGrupoMaterial, iSector, DOCClave, foundRows(i)("PROClave"), dBase - dDescGeneralImp)

                    dVolumen = StrucVol.Descuento
                    sTipoDesc = StrucVol.Tipo

                    If dVolumen > 0 Then
                        dVolumenImp = Math.Round((dBase - dDescGeneralImp) * dVolumen, 2)
                    Else
                        dVolumenImp = 0
                    End If


                    'recalcula productos que tengan descuento de volumen
                    If oVolumen <> dVolumen Then
                        Dim dtVolumen As DataTable
                        dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", DOCClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "", "@Cerrado", 1)
                        If dtVolumen.Rows.Count > 0 Then
                            Dim y As Integer
                            For y = 0 To dtVolumen.Rows.Count - 1
                                ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)
                            Next


                        End If
                    End If
                End If

                dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


                Select Case dFaltante
                    Case Is = dCantidadOriginal
                        'Elimina partida y libera apartado
                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                        "@ALMClave", ALMClave, _
                                        "@VENTA", DOCClave, _
                                        "@PROClave", foundRows(i)("PROClave"), _
                                        "@PrecioBruto", dPrecioUnitario, _
                                        "@Cantidad", 0, _
                                        "@Importe", dBase, _
                                        "@DescGenPor", dDescGeneralPorc, _
                                        "@DescGenImp", dDescGeneralImp, _
                                        "@DescVolPor", dVolumen, _
                                        "@DescVolImp", dVolumenImp, _
                                        "@DescuentoPor", dDescPorc, _
                                        "@DescuentoImp", dDescuentoImp, _
                                        "@ImpuestoImp", dImpuestoImp, _
                                        "@TProducto", foundRows(i)("TProducto"), _
                                        "@TipoDoc", 1, _
                                        "@Picking", Picking, _
                                        "@UndKilo", foundRows(i)("UndKilo"), _
                                        "@DVEClave", foundRows(i)("DVEClave"), _
                                        "@PorcImp", dPorcImp, _
                                        "@Usuario", ModPOS.UsuarioActual, _
                                        "@TipoDesc", sTipoDesc, _
                                        "@Autoriza", "", _
                                        "@Total", dImporteNeto, _
                                        "@Cerrado", 1)

                    Case Is < dCantidadOriginal
                        'Actualiza total de la partida y libera apartado

                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                          "@ALMClave", ALMClave, _
                                          "@VENTA", DOCClave, _
                                          "@PROClave", foundRows(i)("PROClave"), _
                                          "@PrecioBruto", dPrecioUnitario, _
                                          "@Cantidad", dCantidad, _
                                          "@Importe", dBase, _
                                          "@DescGenPor", dDescGeneralPorc, _
                                          "@DescGenImp", dDescGeneralImp, _
                                          "@DescVolPor", dVolumen, _
                                          "@DescVolImp", dVolumenImp, _
                                          "@DescuentoPor", dDescPorc, _
                                          "@DescuentoImp", dDescuentoImp, _
                                          "@ImpuestoImp", dImpuestoImp, _
                                          "@TProducto", foundRows(i)("TProducto"), _
                                          "@TipoDoc", 1, _
                                          "@Picking", Picking, _
                                          "@UndKilo", foundRows(i)("UndKilo"), _
                                          "@DVEClave", foundRows(i)("DVEClave"), _
                                          "@PorcImp", dPorcImp, _
                                          "@Usuario", ModPOS.UsuarioActual, _
                                          "@TipoDesc", sTipoDesc, _
                                          "@Autoriza", "", _
                                          "@Total", dImporteNeto, _
                                          "@Cerrado", 1)




                End Select






            Next



        End If
    End Sub



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
        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Disponible").FormatString = "0.00"
        GridDetalle.CurrentTable.Columns("GrupoMaterial").Visible = False
        GridDetalle.CurrentTable.Columns("Sector").Visible = False
        GridDetalle.CurrentTable.Columns("Partida").Visible = False
        GridDetalle.CurrentTable.Columns("PrecioBruto").Visible = False
        GridDetalle.CurrentTable.Columns("PorcImp").Visible = False
        GridDetalle.CurrentTable.Columns("Cliente").Visible = False
        GridDetalle.CurrentTable.Columns("KgLt").Visible = False
        GridDetalle.CurrentTable.Columns("PROClave").Visible = False
        GridDetalle.CurrentTable.Columns("TProducto").Visible = False
        GridDetalle.CurrentTable.Columns("Peso").Visible = False
        GridDetalle.CurrentTable.Columns("UndKilo").Visible = False


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

                    Dim bmotivo As Boolean = False
                    Dim motCancelacion As Integer = -1

                    Do
                        Dim m As New FrmMotivo
                        m.Tabla = "Venta"
                        m.Campo = "Cancelacion"
                        m.ShowDialog()
                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            bmotivo = True
                            motCancelacion = m.Motivo
                        End If
                        m.Dispose()
                    Loop While bmotivo = False

                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", VENClave, "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", ModPOS.UsuarioActual)
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

                    recalculaPartidaPedido(dtDetalle, VENClave, foundRows(i)("DVEClave"), foundRows(i)("Solicitado"), foundRows(i)("Solicitado") - foundRows(i)("Cantidad"))
           
                Next

                Dim TImpuesto As Integer
                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", foundRows(0)("Cliente"))
                TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()


                Dim dtDet As DataTable
                dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_cerrada", "@VENClave", VENClave)
                If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                    ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 1)
                    dtDet.Dispose()
                End If

                ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", VENClave, "@Estado", 2, "@ActSaldo", 1)


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

        previewPedido(FormatoPedido, VENClave, TotalVenta, SUCClave)

    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridDetalle.GetValue("Cantidad")) Then

                If CDbl(GridDetalle.GetValue("Cantidad")) > CDbl(GridDetalle.GetValue("Solicitado")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad a surtir no de ser mayor a la solicitada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Cantidad", CDbl(GridDetalle.GetValue("Solicitado")))
                ElseIf CDbl(GridDetalle.GetValue("Cantidad")) < 0 Then
                    GridDetalle.SetValue("Cantidad", 0)
                    GridDetalle.SetValue("UndKilo", 0)
                Else
                    If CDbl(GridDetalle.GetValue("Cantidad")) > CDbl(GridDetalle.GetValue("Disponible")) Then
                        If CDbl(GridDetalle.GetValue("Disponible")) >= 0 Then

                            MessageBox.Show("¡La cantidad a surtir es mayor a la disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            GridDetalle.SetValue("Cantidad", CDbl(GridDetalle.GetValue("Disponible")))
                        End If
                    End If
                End If



                If CInt(GridDetalle.GetValue("KgLt")) = 1 Then
                    If CInt(GridDetalle.GetValue("Peso")) > 0 Then
                        GridDetalle.SetValue("UndKilo", GridDetalle.GetValue("Cantidad") / GridDetalle.GetValue("Peso"))
                    Else
                        GridDetalle.SetValue("UndKilo", 1)
                    End If
                Else
                    GridDetalle.SetValue("UndKilo", 0)
                End If

                GridDetalle.SetValue("Total", CDbl(GridDetalle.GetValue("Cantidad")) * CDbl(GridDetalle.GetValue("Subtotal")))

                If GridDetalle.RootTable.FormatConditions.Count = 1 Then
                    Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
                    fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Disponible"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, GridDetalle.GetValue("Cantidad"))
                    fc1.FormatStyle.ForeColor = System.Drawing.Color.Black
                    GridDetalle.RootTable.FormatConditions.Add(fc1)
                End If

            Else
                GridDetalle.SetValue("Cantidad", 0)
                GridDetalle.SetValue("UndKilo", 0)

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
