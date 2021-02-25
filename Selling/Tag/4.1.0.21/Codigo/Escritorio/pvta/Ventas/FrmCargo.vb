Public Class FrmCargo
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
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargo))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.TxtClaveProd = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(662, 305)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(566, 305)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.BtnDel)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.TxtClaveProd)
        Me.GrpDetalle.Controls.Add(Me.PictureBox2)
        Me.GrpDetalle.Controls.Add(Me.txtCantidad)
        Me.GrpDetalle.Controls.Add(Me.PictureBox1)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.Label4)
        Me.GrpDetalle.Controls.Add(Me.Label9)
        Me.GrpDetalle.Location = New System.Drawing.Point(4, 3)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(748, 296)
        Me.GrpDetalle.TabIndex = 121
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(686, 41)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(58, 24)
        Me.BtnDel.TabIndex = 3
        Me.BtnDel.ToolTipText = "Elimina la partida seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(686, 13)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(58, 24)
        Me.BtnBuscaProd.TabIndex = 2
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(218, 14)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(462, 21)
        Me.TxtDescripcion.TabIndex = 139
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(83, 14)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(126, 21)
        Me.TxtClaveProd.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(42, 41)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(17, 20)
        Me.PictureBox2.TabIndex = 135
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(83, 41)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(126, 20)
        Me.txtCantidad.TabIndex = 1
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCantidad.Value = 0.0R
        Me.txtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(42, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 19)
        Me.PictureBox1.TabIndex = 134
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
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
        Me.GridDetalle.Enabled = False
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(8, 68)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(736, 220)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Prod. Cve."
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 15)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Cantidad"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCargo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(757, 347)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmCargo"
        Me.Text = "Detalle de Cargo"
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public foundRows() As DataRow
    Public SUCClave As String
    Public CAJClave As String
    Public ClaveCaja As String
    Public CTEClave As String
    Public Total As Double = 0
    Public VALClave As String = ""

    Private TipoCambio As Decimal
    Private MonRefBase As String

    Private TImpuesto As Integer
    Private Moneda, PROClave, Clave, Nombre, ListaPrecio As String
    Private Tasa, Costo, PrecioBruto, Subtotal, ImpuestoTot As Double

    Private bError As Boolean = False
    Private dtDetalle As DataTable

    Private alerta(1) As PictureBox
    Private reloj As parpadea


    Private Sub FrmCargo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub



    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        bError = False

        If GridDetalle.RowCount <= 0 Then
            MessageBox.Show("No es posible generar el cargo debido a que no se encontraron conceptos en el detalle", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
            Exit Sub
        End If

        Dim Folio, Periodo, Mes As Integer

        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 12, "@PDVClave", CAJClave)
        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 12, "@PDVClave", CAJClave)
            Folio = 1
            Mes = Today.Month
            Periodo = Today.Year
        Else
            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 12, "@PDVClave", CAJClave, "@Incremento", 1)
            dt.Dispose()
        End If

        Dim sFolio As String = "CR" & ClaveCaja & CStr(Periodo) & CStr(Mes) & "-" & CStr(Folio)
        Dim CARClave As String = ModPOS.obtenerLlave


        ModPOS.Ejecuta("sp_crea_cargo", _
        "@CARClave", CARClave, _
        "@CTEClave", CTEClave, _
        "@Folio", sFolio, _
        "@CAJClave", CAJClave, _
        "@Usuario", ModPOS.UsuarioActual, _
        "@Motivo", 2, _
        "@Descripcion", "CARGO POR DEVOLUCIÓN", _
        "@Subtotal", Subtotal, _
        "@ImpuestoTot", ImpuestoTot, _
        "@Total", Total, _
        "@MONClave", Moneda, _
        "@TipoCambio", TipoCambio,
        "@VALClave", VALClave)


        Dim fila As Integer

        For fila = 0 To dtDetalle.Rows.Count - 1
            ModPOS.Ejecuta("st_inserta_cargodet", _
            "@DCRClave", dtDetalle.Rows(fila)("DCRClave"), _
            "@CARClave", CARClave, _
            "@Partida", (fila + 1) * 10, _
            "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
            "@Costo", dtDetalle.Rows(fila)("Costo"), _
            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
            "@PrecioBruto", dtDetalle.Rows(fila)("Precio"), _
            "@Subtotal", dtDetalle.Rows(fila)("Subtotal"), _
            "@PorcImp", dtDetalle.Rows(fila)("Tasa"), _
            "@ImpuestoImp", dtDetalle.Rows(fila)("Impuesto"), _
            "@TotalPartida", dtDetalle.Rows(fila)("Total"))
        Next

        dtDetalle.Dispose()


        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub recuperaProducto(ByVal sClave As String, ByVal iTipo As Integer)

        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("st_recupera_precio_servicio", "@Tipo", iTipo, "@Busca", sClave, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTEClave)
        If Not dtProducto Is Nothing Then


            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            Costo = dtProducto.Rows(0)("Costo")
            PrecioBruto = dtProducto.Rows(0)("PrecioBruto")
            Tasa = ModPOS.RecuperaImpuesto(SUCClave, PROClave, TImpuesto)
            dtProducto.Dispose()

            If PrecioBruto = 0 Then
                PROClave = ""
                Clave = ""
                Nombre = ""
                Tasa = 0
                Costo = 0
                TxtClaveProd.Text = Clave
                TxtDescripcion.Text = Nombre
                txtCantidad.Text = 0

                MessageBox.Show("¡El Producto seleccionado no cuenta con Precio Vigente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Else
                TxtClaveProd.Text = Clave
                TxtDescripcion.Text = Nombre
                txtCantidad.Text = 1
                txtCantidad.Focus()
            End If
           
        Else
            PROClave = ""
            Clave = ""
            Nombre = ""
            Tasa = 0
            Costo = 0
            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = Nombre
            txtCantidad.Text = 0

            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub


    Private Sub BtnBuscaProd_Click(sender As Object, e As EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "st_busca_servicios"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.BusquedaInicial = True
        a.CompaniaRequerido = True
        a.Busqueda = IIf(TxtClaveProd.Text = "", "%", TxtClaveProd.Text.Trim)
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                recuperaProducto(a.valor, 3)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClaveProd_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtClaveProd.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtClaveProd.Text <> "" Then
                    recuperaProducto(TxtClaveProd.Text.Trim, 2)
                End If
            Case Is = Keys.Right
                BtnBuscaProd.PerformClick()
        End Select

    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If PROClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(txtCantidad.Text) < 0 Then
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

    Private Sub txtCantidad_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyUp
        If e.KeyCode = Keys.Enter AndAlso CDbl(txtCantidad.Text) <> 0 Then
            If validaForm() Then

                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("PROClave = '" & PROClave & "'")
                If foundRows.Length = 0 Then


                    Dim dSubtotal As Decimal = Math.Round((PrecioBruto * Math.Abs(CDbl(txtCantidad.Text))), 2)
                    Dim dImpuesto As Decimal = Math.Round(dSubtotal * Tasa, 2)
                    Dim dTotal As Decimal = dSubtotal + dImpuesto

                    Dim row1 As DataRow
                    row1 = dtDetalle.NewRow()
                    'declara el nombre de la fila
                    row1.Item("DCRClave") = ModPOS.obtenerLlave
                    row1.Item("PROClave") = PROClave
                    row1.Item("Clave") = Clave
                    row1.Item("Nombre") = Nombre
                    row1.Item("Costo") = Costo
                    row1.Item("Cantidad") = Math.Abs(CDbl(txtCantidad.Text))
                    row1.Item("Precio") = PrecioBruto
                    row1.Item("Subtotal") = dSubtotal
                    row1.Item("Tasa") = Tasa
                    row1.Item("Impuesto") = dImpuesto
                    row1.Item("Total") = dTotal

                    dtDetalle.Rows.Add(row1)
                    'agrega la fila completo a la tabla

                    TxtDescripcion.Text = ""
                    txtCantidad.Text = ""
                    TxtClaveProd.Text = ""

                    Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    ImpuestoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)



                Else
                    PROClave = ""
                    Clave = ""
                    Nombre = ""
                    Tasa = 0
                    Costo = 0
                    TxtClaveProd.Text = Clave
                    TxtDescripcion.Text = Nombre
                    txtCantidad.Text = 0
                    MessageBox.Show("¡El concepto que intenta agregar ya existe ne la nota de cargo actual!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub


    Private Sub FrmCargo_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", CTEClave)
        ListaPrecio = dt.Rows(0)("PREClave")
        TImpuesto = dt.Rows(0)("TipoImpuesto")
        dt.Dispose()

      

      
        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With

        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        TipoCambio = dt.Rows(0)("TipoCambio")
        MonRefBase = dt.Rows(0)("Referencia")
        dt.Dispose()



        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2



        dtDetalle = ModPOS.CrearTabla("NotaCargoDet", _
                                               "DCRClave", "System.String", _
                                               "PROClave", "System.String", _
                                               "Clave", "System.String", _
                                               "Nombre", "System.String", _
                                               "Costo", "System.Double", _
                                               "Cantidad", "System.Double", _
                                               "Precio", "System.Decimal", _
                                               "Subtotal", "System.Decimal", _
                                               "Tasa", "System.Double", _
                                               "Impuesto", "System.Decimal", _
                                               "Total", "System.Decimal")

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DCRClave").Visible = False
        GridDetalle.RootTable.Columns("Tasa").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False


        GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum

        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"


    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GridDetalle.RowCount >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se removera el concepto: " & GridDetalle.GetValue("Clave"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("DCRClave = '" & GridDetalle.GetValue("DCRClave") & "'")
                    dtDetalle.Rows.Remove(foundRows(0))

                    Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    ImpuestoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)


                  
            End Select
        End If
    End Sub
End Class
