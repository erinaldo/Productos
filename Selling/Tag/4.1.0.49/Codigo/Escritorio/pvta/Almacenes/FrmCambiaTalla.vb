Imports System.Data.SqlClient

Public Class FrmCambiaTalla
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaTalla As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents txtCambiar As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambiaTalla))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscaTalla = New Janus.Windows.EditControls.UIButton()
        Me.txtCambiar = New System.Windows.Forms.TextBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(587, 521)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(686, 521)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNota
        '
        Me.TxtNota.Location = New System.Drawing.Point(103, 62)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(403, 20)
        Me.TxtNota.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Motivo: "
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(10, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 18)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Reemplazar por"
        '
        'btnBuscaTalla
        '
        Me.btnBuscaTalla.Image = CType(resources.GetObject("btnBuscaTalla.Image"), System.Drawing.Image)
        Me.btnBuscaTalla.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBuscaTalla.Location = New System.Drawing.Point(321, 29)
        Me.btnBuscaTalla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscaTalla.Name = "btnBuscaTalla"
        Me.btnBuscaTalla.Size = New System.Drawing.Size(31, 30)
        Me.btnBuscaTalla.TabIndex = 106
        Me.btnBuscaTalla.ToolTipText = "Busqueda de producto "
        Me.btnBuscaTalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtCambiar
        '
        Me.txtCambiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambiar.Location = New System.Drawing.Point(103, 34)
        Me.txtCambiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCambiar.Name = "txtCambiar"
        Me.txtCambiar.ReadOnly = True
        Me.txtCambiar.Size = New System.Drawing.Size(212, 21)
        Me.txtCambiar.TabIndex = 105
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
        Me.GridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(12, 88)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(760, 427)
        Me.GridDetalle.TabIndex = 109
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Modelo Actual"
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(103, 6)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(212, 20)
        Me.txtProducto.TabIndex = 111
        '
        'lblProducto
        '
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProducto.Location = New System.Drawing.Point(321, 9)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(451, 18)
        Me.lblProducto.TabIndex = 112
        '
        'FrmCambiaTalla
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnBuscaTalla)
        Me.Controls.Add(Me.txtCambiar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNota)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambiaTalla"
        Me.Text = "Ajuste de Existencia"
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private ExistActual As Double
    Private ExistNueva As Double
    Public ALMClave As String
    Public PROClave, PROClaveCambio As String
    Public Nombre As String
    Public Clave As String
    Private SUCClave, InterfazSalida As String
    Private dtAjuste As DataTable


    Private Sub FrmCambiaTalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        txtProducto.Text = Clave
        lblProducto.Text = Nombre

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", ALMClave)
        SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
        dt.Dispose()

        recuperaExistencia(ALMClave, PROClave)

        Dim dtParam As DataTable
        Dim i As Integer

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                        Exit Select
                End Select
            Next
        End With
        dtParam.Dispose()

    End Sub



    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If txtCambiar.Text = "" Then
            MessageBox.Show("Debe seleccionar el reemplazo del producto seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf TxtNota.Text = "" Then
            MessageBox.Show("Es requerida la descripción del motivo del ajuste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf TxtNota.Text.Length > 50 Then
            MessageBox.Show("La descripción del motivo de ajuste sobrepasa el maximo de caracters permitidos (50)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If



        Dim foundRows() As Data.DataRow
        foundRows = dtAjuste.Select("Cambiar > 0")
        Dim i As Integer

        Dim dt As DataTable = ModPOS.CrearTabla("Ajustar", _
                                              "UBCClave", "System.String", _
                                              "PROClave", "System.String", _
                                              "Cantidad", "System.Double", _
                                              "Costo", "System.Decimal", _
                                              "Movimiento", "System.Int32")

        Dim row1, row2 As DataRow

        If foundRows.Length > 0 Then
            For i = 0 To foundRows.Length - 1
                Dim CantAjuste As Double = 0
                CantAjuste = foundRows(i)("Cambiar")

                If CantAjuste > 0 Then
                    If CantAjuste <= (foundRows(i)("Existencia") - (foundRows(i)("Apartado") + foundRows(i)("Bloqueado"))) Then

                        row1 = dt.NewRow()
                        row1.Item("UBCClave") = foundRows(i)("ID").ToString
                        row1.Item("PROClave") = PROClave
                        row1.Item("Cantidad") = CantAjuste * -1
                        row1.Item("Costo") = foundRows(i)("Costo") * CantAjuste
                        row1.Item("Movimiento") = 2
                        dt.Rows.Add(row1)


                        row2 = dt.NewRow()
                        row2.Item("UBCClave") = foundRows(i)("ID").ToString
                        row2.Item("PROClave") = PROClaveCambio
                        row2.Item("Cantidad") = CantAjuste
                        row2.Item("Costo") = foundRows(i)("Costo") * CantAjuste
                        row2.Item("Movimiento") = 1
                        dt.Rows.Add(row2)

                    Else
                        MessageBox.Show("El producto " & foundRows(i)("Clave") & ", No puede ser ajustado ya que sobrepasa la cantidad de Apartado y Bloqueado", "Información", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If
            Next

            If dt.Rows.Count > 0 Then
                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.MontodeAutorizacion = dt.Compute("SUM(Costo)", " Movimiento = 2")
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado Then
                        Dim Referencia As String = ModPOS.obtenerLlave

                        For i = 0 To dt.Rows.Count - 1
                            ModPOS.Ejecuta("sp_ajusta_exist_ubc", _
                                            "@ALMClave", ALMClave, _
                                            "@Diferencia", dt.Rows(i)("Cantidad"), _
                                           "@UBCClave", dt.Rows(i)("UBCClave"), _
                                            "@PROClave", dt.Rows(i)("PROClave"), _
                                            "@Nota", TxtNota.Text.ToUpper.Trim.Replace("'", ""), _
                                            "@Usuario", ModPOS.UsuarioActual)


                            ModPOS.Ejecuta("st_ajuste", _
                                                              "@SUCClave", SUCClave, _
                                                              "@ALMClave", ALMClave, _
                                                              "@UBCClave", dt.Rows(i)("UBCClave"), _
                                                              "@PROClave", dt.Rows(i)("PROClave"), _
                                                              "@Cantidad", dt.Rows(i)("Cantidad"), _
                                                              "@TipoMov", dt.Rows(i)("Movimiento"), _
                                                              "@Referencia", Referencia, _
                                                              "@Nota", TxtNota.Text.ToUpper.Trim.Replace("'", ""), _
                                                              "@Usuario", ModPOS.UsuarioActual)



                        Next

                        If InterfazSalida <> "" Then
                            Dim dtInterfaz As DataTable
                            Dim sFecha As String

                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "AjusteTC", "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                            End If
                        End If

                        MessageBox.Show("Productos Ajustados Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ModPOS.MtoExistencia.recuperaExistencia(2, "")
                        Me.Close()

                    End If
                End If
            Else
                MessageBox.Show("No se encontraron diferencias para realizar ajuste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Else
            MessageBox.Show("Debe introducir una cantidad mayor a cero en la columna de Cambiar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub recuperaExistencia(ByVal sALMClave As String, ByVal sPROClave As String)

        If Not dtAjuste Is Nothing Then
            dtAjuste.Dispose()
        End If

        dtAjuste = Recupera_Tabla("st_prd_exist_uba_tc", "@PROClave", sPROClave, "@ALMClave", sALMClave)

        GridDetalle.DataSource = dtAjuste
        GridDetalle.RetrieveStructure()
        ' GridDetalle.AutoSizeColumns()
        GridDetalle.RootTable.Columns("ID").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False

        GridDetalle.RootTable.Columns("Existencia").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Cambiar").FormatString = "0.00"

        GridDetalle.RootTable.Columns("Apartado").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Bloqueado").FormatString = "0.00"

    End Sub

    Private Sub BtnBuscaTalla_Click(sender As Object, e As EventArgs) Handles btnBuscaTalla.Click

        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_tallas", "@PROClave", PROClave)

        If dt.Rows.Count > 0 Then

            Dim a As New FrmConsulta
            a.Intro = False
            a.Campo = "PROClave"
            a.Campo2 = "Clave"
            a.AutoSizeForm = False

            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_tallas", "@PROClave", PROClave)


            a.GridConsultaGen.RootTable.Columns("PROClave").Visible = False
            a.GridConsultaGen.RootTable.Columns("Clave").Width = 95
            a.GridConsultaGen.RootTable.Columns("Nombre").Width = 250
            a.GridConsultaGen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    PROClaveCambio = a.ID
                    txtCambiar.Text = a.ID2
                End If
            End If
            a.Dispose()

        Else
            MessageBox.Show("El Producto no cuenta con tallas adicionales", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

      Private Sub actprd(ByVal sPROClave As String, ByVal sClave As String, ByVal sDesc As String, ByVal dCantidad As Double)
        Dim foundRows() As Data.DataRow
        foundRows = dtAjuste.Select("ID = '" & sPROClave & "'")

        If foundRows.Length = 0 Then

            Dim dMonto As Double

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_costo", "@SUCClave", SUCClave, "@PROClave", PROClave)
            dMonto = dt.Rows(0)("Costo")
            dt.Dispose()

            Dim row1 As DataRow
            row1 = dtAjuste.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = sPROClave
            row1.Item("Marca") = False
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sDesc
            row1.Item("Teorica") = 0
            row1.Item("Fisica") = dCantidad
            row1.Item("Apartado") = 0
            row1.Item("Bloqueado") = 0
            row1.Item("Costo") = dMonto
            row1.Item("Nuevo") = 1
            dtAjuste.Rows.Add(row1)
        Else
            foundRows(0)("Fisica") = dCantidad
        End If

    End Sub


    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Cambiar" Then
            If IsNumeric(GridDetalle.GetValue("Cambiar")) Then

                Select Case CDbl(GridDetalle.GetValue("Cambiar"))
                    Case Is < 0
                        GridDetalle.SetValue("Cambiar", 0)
                    Case Is > (CDbl(GridDetalle.GetValue("Existencia")) - CDbl(GridDetalle.GetValue("Apartado")))
                        GridDetalle.SetValue("Cambiar", (CDbl(GridDetalle.GetValue("Existencia")) - CDbl(GridDetalle.GetValue("Apartado"))))
                End Select

            Else
                GridDetalle.SetValue("Cambiar", 0)
            End If
        End If

    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Cambiar" Then
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Function recuperaProducto(ByVal Clave As String) As String
        If Not Clave = vbNullString Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", Clave)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then

                    Clave = dt.Rows(0)("PROClave")
                End If
                dt.Dispose()
            End If
        End If
        Return Clave
    End Function



  
End Class
