Public Class FrmCancelaProducto
    Inherits System.Windows.Forms.Form

    Public numMostrasdor As Integer
    Public bVentaConvencional As Boolean = False

    Public TipoDoc As Integer
    Public Picking As Boolean = False
    Public CTEClaveActual As String
    Public VENClave As String
    Public ALMClave As String

    Private dtDetalle As DataTable
    Private CantidadEliminar, CantidadOrigen As Decimal
    Public SeCancela As Boolean = False
    Friend WithEvents ChkEliminar As Selling.ChkStatus


    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCancelaProducto))
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.ChkEliminar = New Selling.ChkStatus(Me.components)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(524, 349)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar [F9]"
        Me.BtnOK.ToolTipText = "Cancela el producto y la cantidad actual"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(429, 349)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "&Salir [Esc]"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(4, 4)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(610, 340)
        Me.GridProductos.TabIndex = 46
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ChkEliminar
        '
        Me.ChkEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkEliminar.Location = New System.Drawing.Point(4, 357)
        Me.ChkEliminar.Name = "ChkEliminar"
        Me.ChkEliminar.Size = New System.Drawing.Size(158, 22)
        Me.ChkEliminar.TabIndex = 48
        Me.ChkEliminar.Text = "Eliminar Todos"
        '
        'FrmCancelaProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(619, 391)
        Me.Controls.Add(Me.ChkEliminar)
        Me.Controls.Add(Me.GridProductos)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(534, 430)
        Me.Name = "FrmCancelaProducto"
        Me.Text = "Cancelación de Producto"
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("Eliminar > 0 and Cantidad >= Eliminar")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            Dim SeBorra As Boolean

            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, UnidadesKilo, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer

            Dim iKgLt As Integer
            Dim sTipoDesc As String = ""
          


            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")

                CantidadEliminar = foundRows(i)("Eliminar")
                CantidadOrigen = foundRows(i)("Cantidad")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")


                dCantidad = CantidadOrigen - CantidadEliminar


                If foundRows(i)("UndKilo") > 0 Then
                    iKgLt = 1
                    UnidadesKilo = (foundRows(i)("UndKilo") / CantidadOrigen) * dCantidad
                    dBase = Math.Round(dPrecioUnitario * UnidadesKilo, 2)
                Else
                    iKgLt = 0
                    UnidadesKilo = 0
                    dBase = Math.Round(dPrecioUnitario * dCantidad, 2)
                End If


                Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", foundRows(i)("DVEClave"))
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

                   
                    StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, foundRows(i)("PROClave"), dBase - dDescGeneralImp)

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
                        dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "")
                        If dtVolumen.Rows.Count > 0 Then
                            Dim y As Integer
                            For y = 0 To dtVolumen.Rows.Count - 1
                                ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual)
                            Next

                            If bVentaConvencional = False Then
                                ModPOS.Mostradores(numMostrasdor).recalcularPartidas()
                            Else
                                ModPOS.PreVenta.recalcularPartidas()
                            End If
                        End If
                    End If
                End If

                dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


                 Select Case CantidadEliminar
                    Case Is = CantidadOrigen
                        SeCancela = True
                        SeBorra = True
                        'Elimina partida y libera apartado
                        ModPOS.Ejecuta("sp_elimina_partida", _
                        "@ALMClave", ALMClave, _
                        "@VENClave", VENClave, _
                        "@DVEClave", foundRows(i)("DVEClave"), _
                        "@Producto", foundRows(i)("PROClave"), _
                        "@Cantidad", foundRows(i)("Cantidad"), _
                        "@TipoDoc", TipoDoc, _
                        "@TProducto", foundRows(i)("TProducto"), _
                        "@Picking", Picking)

                        If bVentaConvencional = False Then
                            ModPOS.Mostradores(numMostrasdor).AgregaCancelado(foundRows(i)("DVEClave"), foundRows(i)("Clave") & " " & foundRows(i)("Nombre"), foundRows(i)("Total") / CantidadEliminar, CantidadEliminar, foundRows(i)("PuntosImp"))
                        Else
                            ModPOS.PreVenta.AgregaCancelado(foundRows(i)("DVEClave"), foundRows(i)("Clave") & " " & foundRows(i)("Nombre"), foundRows(i)("Total") / CantidadEliminar, CantidadEliminar, foundRows(i)("PuntosImp"))
                        End If


                    Case Is < CantidadOrigen
                        SeBorra = False
                        SeCancela = True
                        'Actualiza total de la partida y libera apartado

                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                          "@ALMClave", ALMClave, _
                                          "@VENTA", VENClave, _
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
                                          "@TipoDoc", TipoDoc, _
                                          "@Picking", Picking, _
                                          "@UndKilo", UnidadesKilo, _
                                          "@DVEClave", foundRows(i)("DVEClave"), _
                                          "@PorcImp", dPorcImp, _
                                          "@Usuario", ModPOS.UsuarioActual, _
                                          "@TipoDesc", sTipoDesc, _
                                          "@Autoriza", "", _
                                          "@Total", dImporteNeto)


                        ModPOS.Ejecuta("sp_actualiza_partida", _
                                                "@ALMClave", ALMClave, _
                                                "@VENClave", VENClave, _
                                                "@DVEClave", foundRows(i)("DVEClave"), _
                                                "@Producto", foundRows(i)("PROClave"), _
                                                "@Cantidad", CantidadEliminar, _
                                                "@TipoDoc", TipoDoc, _
                                                "@TProducto", foundRows(i)("TProducto"), _
                                                "@Picking", Picking)

                        If bVentaConvencional = False Then
                            ModPOS.Mostradores(numMostrasdor).AgregarProducto(foundRows(i)("DVEClave"), foundRows(i)("PROClave"), foundRows(i)("Clave"), foundRows(i)("Nombre"), dCantidad, dPrecioUnitario, dPorcImp, dDescGeneralImp + dVolumenImp + dDescuentoImp, iKgLt, UnidadesKilo, iGrupoMaterial, iSector, iPartida)
                        Else
                            ModPOS.PreVenta.AgregarProducto(foundRows(i)("DVEClave"), foundRows(i)("PROClave"), foundRows(i)("Clave"), foundRows(i)("Nombre"), dCantidad, dPrecioUnitario, dPorcImp, dDescGeneralImp + dVolumenImp + dDescuentoImp, iKgLt, UnidadesKilo, iGrupoMaterial, iSector, iPartida)
                        End If

                End Select




                If Picking = False Then
                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If foundRows(i)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = CantidadEliminar
                        Do
                            Dim b As New FrmSerial
                            b.DOCClave = VENClave
                            b.PROClave = foundRows(i)("PROClave")
                            b.Clave = foundRows(i)("Clave")
                            b.Nombre = foundRows(i)("Nombre")
                            b.Cantidad = PorRegistrar
                            b.Dias = foundRows(i)("DiasGarantia")
                            b.TipoDoc = 1
                            b.TipoMov = 1
                            b.ShowDialog()
                            SerialReg = SerialReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until SerialReg = CantidadEliminar OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If foundRows(i)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = CantidadEliminar
                        Do
                            Dim b As New FrmLote
                            b.DOCClave = VENClave
                            b.PROClave = foundRows(i)("PROClave")
                            b.Clave = foundRows(i)("Clave")
                            b.Nombre = foundRows(i)("Nombre")
                            b.CantXRegistrar = PorRegistrar
                            b.TipoDoc = 1
                            b.TipoMov = 1
                            b.ShowDialog()
                            LoteReg = LoteReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until LoteReg = CantidadEliminar OrElse PorRegistrar = 0
                    End If

                End If



            Next
            Me.Close()

        Else
            Beep()
            MessageBox.Show("No se ha especificado la cantidad de producto que desea eliminar de la venta actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub GridProductos_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridProductos.CellEdited
        If GridProductos.CurrentColumn.Caption = "Eliminar" Then
            If IsNumeric(GridProductos.GetValue("Eliminar")) Then
                If GridProductos.GetValue("Cantidad") < GridProductos.GetValue("Eliminar") Then
                    Beep()
                    MessageBox.Show("¡La cantidad a eliminar no puede ser mayor al disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridProductos.SetValue("Eliminar", 0)
                End If
            Else
                GridProductos.SetValue("Eliminar", 0)
            End If
            dtDetalle.AcceptChanges()
        End If
    End Sub

    Private Sub FrmCancelaProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnCancel.KeyUp, BtnOK.KeyUp, GridProductos.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.F9
                Me.BtnOK.PerformClick()
            Case Is = Keys.Escape
                Me.BtnCancel.PerformClick()
        End Select

    End Sub

    Private Sub FrmCancelaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        dtDetalle = ModPOS.Recupera_Tabla("sp_search_producto_detalle", "@Venta", VENClave)
        GridProductos.DataSource = dtDetalle
        GridProductos.RetrieveStructure()
        GridProductos.AutoSizeColumns()
        GridProductos.RootTable.Columns("PROClave").Visible = False
        GridProductos.RootTable.Columns("PuntosImp").Visible = False
        GridProductos.RootTable.Columns("DescuentoImp").Visible = False
        GridProductos.RootTable.Columns("PrecioBruto").Visible = False
        GridProductos.RootTable.Columns("Seguimiento").Visible = False
        GridProductos.RootTable.Columns("DiasGarantia").Visible = False
        GridProductos.RootTable.Columns("DVEClave").Visible = False
        GridProductos.RootTable.Columns("PorcImp").Visible = False
        GridProductos.RootTable.Columns("TProducto").Visible = False
        GridProductos.RootTable.Columns("UndKilo").Visible = False
        GridProductos.RootTable.Columns("GrupoMaterial").Visible = False
        GridProductos.RootTable.Columns("Sector").Visible = False
        GridProductos.RootTable.Columns("Partida").Visible = False

        GridProductos.RootTable.Columns("Clave").Selectable = False
        GridProductos.RootTable.Columns("Nombre").Selectable = False
        GridProductos.RootTable.Columns("Cantidad").Selectable = False
        GridProductos.RootTable.Columns("Total").Selectable = False

        Me.GridProductos.RootTable.Columns("Clave").Width = 70
        Me.GridProductos.RootTable.Columns("Nombre").Width = 270
        Me.GridProductos.RootTable.Columns("Cantidad").Width = 60
        Me.GridProductos.RootTable.Columns("Eliminar").Width = 60
        Me.GridProductos.RootTable.Columns("Total").Width = 60
        Me.GridProductos.RootTable.Columns("Cantidad").FormatString = "0.00"
    End Sub

  
    Private Sub ChkEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEliminar.CheckedChanged
        If GridProductos.RowCount > 0 Then
            Dim i As Integer
            
            If ChkEliminar.Checked Then
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Eliminar") = GridProductos.GetDataRows(i).DataRow("Cantidad")
                Next
            Else
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Eliminar") = 0
                Next
            End If


            dtDetalle.AcceptChanges()

            GridProductos.Refresh()
        End If
    End Sub
End Class
