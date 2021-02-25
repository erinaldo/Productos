Public Class FrmCancelaProducto
    Inherits System.Windows.Forms.Form

    Private Cantidad As Double
    Private PROClave As String
    Private VENClave As String
    Private DVEClave As String
    Private TProducto As Integer

    Private ALMClave As String

    Private CantidadDetalle As Double
    Private iSeguimiento As Integer
    Private iDias As Integer
    Private Clave As String
    Private Nombre As String

    Public PrecioNetoDetalle As Double
    Public Factor As Integer
    Public Descripcion As String
    Public PuntosDetalle As Double
    Public DescuentoDetalle As Double
    Public PorcImp As Double
    Public RestaArticulo As Boolean = False
    Public SeCancela As Boolean = False
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Public TipoDoc As Integer
    Public Picking As Boolean = False


    Public WriteOnly Property Almacen() As String
        Set(ByVal Value As String)
            ALMClave = Value
        End Set
    End Property

    Public WriteOnly Property VentaClave() As String
        Set(ByVal Value As String)
            VENClave = Value
        End Set
    End Property

    Public ReadOnly Property Producto() As String
        Get
            Producto = PROClave
        End Get
    End Property


    Public ReadOnly Property Partida() As String
        Get
            Partida = DVEClave
        End Get
    End Property

    Public ReadOnly Property CantidadCancelada() As Double
        Get
            CantidadCancelada = Cantidad
        End Get
    End Property

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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCancelaProducto))
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtProducto = New System.Windows.Forms.TextBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.LblNombre = New System.Windows.Forms.Label
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(432, 362)
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
        Me.BtnCancel.Location = New System.Drawing.Point(336, 362)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "&Salir [Esc]"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(4, 381)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(193, 15)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "Presione <TAB> para modificar cantidad."
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(4, 45)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(50, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(60, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 20)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "X"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(93, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 20)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "PRODUCTO:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(4, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 20)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "CANT."
        '
        'TxtProducto
        '
        Me.TxtProducto.Location = New System.Drawing.Point(93, 45)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(196, 20)
        Me.TxtProducto.TabIndex = 0
        '
        'GridProductos
        '
        Me.GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(4, 98)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(517, 262)
        Me.GridProductos.TabIndex = 46
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblNombre
        '
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.White
        Me.LblNombre.Location = New System.Drawing.Point(4, 74)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(518, 20)
        Me.LblNombre.TabIndex = 47
        '
        'FrmCancelaProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(528, 401)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.GridProductos)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtProducto)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(534, 430)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(534, 430)
        Me.Name = "FrmCancelaProducto"
        Me.Text = "Cancelación de Producto"
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        Me.Close()
    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Valida que el campo producto no se encuentre vacio
            If Not TxtProducto.Text = vbNullString Then
                'Si el campo cantidad esta vacio lo cambia a 1 por defecto
                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                End If
                'Recupera Articulo del detalle de venta
                Dim dtDetalleVenta As DataTable

                dtDetalleVenta = ModPOS.SiExisteRecupera("sp_recupera_VentaDetalle", _
                "@Venta", VENClave, _
                "@GTIN", TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), _
                "@Detalle", "")

                If dtDetalleVenta Is Nothing Then
                    dtDetalleVenta = ModPOS.SiExisteRecupera("sp_recupera_VentaDetalleClave", _
                    "@Venta", VENClave, _
                    "@GTIN", TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
                End If


                If Not dtDetalleVenta Is Nothing Then

                    PROClave = dtDetalleVenta.Rows(0)("PROClave")
                    CantidadDetalle = dtDetalleVenta.Rows(0)("Cantidad")
                    PrecioNetoDetalle = dtDetalleVenta.Rows(0)("SubTotalPartida")
                    PuntosDetalle = dtDetalleVenta.Rows(0)("PuntosImp")
                    DescuentoDetalle = dtDetalleVenta.Rows(0)("DescuentoImp")
                    PorcImp = dtDetalleVenta.Rows(0)("PorcImp")
                    Descripcion = dtDetalleVenta.Rows(0)("Descripcion")
                    Factor = dtDetalleVenta.Rows(0)("Factor")
                    iSeguimiento = dtDetalleVenta.Rows(0)("Seguimiento")
                    iDias = dtDetalleVenta.Rows(0)("DiasGarantia")
                    Clave = dtDetalleVenta.Rows(0)("Clave")
                    Nombre = dtDetalleVenta.Rows(0)("Nombre")
                    DVEClave = dtDetalleVenta.Rows(0)("DVEClave")
                    TProducto = dtDetalleVenta.Rows(0)("TProducto")
                    dtDetalleVenta.Dispose()
                    LblNombre.Text = Descripcion
                Else
                    CantidadDetalle = 0
                    PrecioNetoDetalle = 0
                    LblNombre.Text = ""
                    TxtProducto.Text = ""
                    Beep()
                    MessageBox.Show("El producto que intenta cancelar no corresponde a la venta actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                CantidadDetalle = 0
                PrecioNetoDetalle = 0
                LblNombre.Text = ""
                TxtProducto.Text = ""
                Beep()
                MessageBox.Show("El producto que intenta cancelar no corresponde a la venta actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) = 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                Else
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If
            TxtProducto.Focus()
        End If

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If CantidadDetalle > 0 Then
            Cantidad *= Factor
            If Cantidad > 0 Then

                'Dim a As New MeAutorizacion
                'a.Almacen = ALMClave
                'a.MontodeAutorizacion = PrecioNetoDetalle * Cantidad
                'a.ShowDialog()

                'If a.DialogResult = DialogResult.OK Then
                '    If a.Autorizado Then

                Select Case Cantidad
                    Case Is > CantidadDetalle
                        Beep()
                        MessageBox.Show("La Cantidad a cancelar no corresponde a la de la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        SeCancela = False
                    Case Is = CantidadDetalle
                        SeCancela = True
                        RestaArticulo = True
                        'Elimina partida y libera apartado
                        ModPOS.Ejecuta("sp_elimina_partida", _
                        "@ALMClave", ALMClave, _
                        "@VENClave", VENClave, _
                        "@DVEClave", DVEClave, _
                        "@Producto", PROClave, _
                        "@Cantidad", CantidadDetalle, _
                        "@TipoDoc", TipoDoc, _
                        "@TProducto", TProducto, _
                        "@Picking", Picking)


                    Case Is < CantidadDetalle
                        SeCancela = True
                        'Actualiza total de la partida y libera apartado

                        ModPOS.Ejecuta("sp_actualiza_partida", _
                                                "@ALMClave", ALMClave, _
                                                "@VENClave", VENClave, _
                                                "@DVEClave", DVEClave, _
                                                "@Producto", PROClave, _
                                                "@Cantidad", Cantidad, _
                                                "@TipoDoc", TipoDoc, _
                                                "@TProducto", TProducto, _
                                                "@Picking", Picking)

                End Select


                If Picking = False AndAlso SeCancela Then
                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If iSeguimiento = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = Cantidad
                        Do
                            Dim b As New FrmSerial
                            b.DOCClave = VENClave
                            b.PROClave = PROClave
                            b.Clave = Clave
                            b.Nombre = Nombre
                            b.Cantidad = PorRegistrar
                            b.Dias = iDias
                            b.TipoDoc = 1
                            b.TipoMov = 1
                            b.ShowDialog()
                            SerialReg = SerialReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until SerialReg = Cantidad OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If iSeguimiento = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = Cantidad
                        Do
                            Dim b As New FrmLote
                            b.DOCClave = VENClave
                            b.PROClave = PROClave
                            b.Clave = Clave
                            b.Nombre = Nombre
                            b.CantXRegistrar = PorRegistrar
                            b.TipoDoc = 1
                            b.TipoMov = 1
                            b.ShowDialog()
                            LoteReg = LoteReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until LoteReg = Cantidad OrElse PorRegistrar = 0
                    End If

                End If

                '    End If
                'End If
                'a.Dispose()

                If SeCancela Then
                    'Actualiza Total en bd
                    ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", 2, "@ALMClave", ALMClave)
                    Me.Close()
                End If
            Else
                Beep()
                MessageBox.Show("La cantidad a cancelar debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            Beep()
            MessageBox.Show("Doble Click sobre el producto a cancelar o lea su código de barras o escriba su clave y presione <Enter>", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) = 0 Then
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            Else
                Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            Cantidad = 1
            TxtCantidad.Text = CStr(Cantidad)
        End If

        TxtProducto.Focus()

    End Sub

    Private Sub FrmCancelaProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, TxtCantidad.KeyUp, BtnCancel.KeyUp, BtnOK.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.F9
                Me.BtnOK.PerformClick()
            Case Is = Keys.Escape
                Me.BtnCancel.PerformClick()
        End Select

    End Sub

    Private Sub FrmCancelaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ActualizaGrid(False, Me.GridProductos, "sp_search_producto_detalle", "@Venta", VENClave)
        GridProductos.RootTable.Columns("PROClave").Visible = False
        GridProductos.RootTable.Columns("PuntosImp").Visible = False
        GridProductos.RootTable.Columns("DescuentoImp").Visible = False
        GridProductos.RootTable.Columns("Factor").Visible = False
        GridProductos.RootTable.Columns("Seguimiento").Visible = False
        GridProductos.RootTable.Columns("DiasGarantia").Visible = False
        GridProductos.RootTable.Columns("DVEClave").Visible = False
        GridProductos.RootTable.Columns("PorcImp").Visible = False
        GridProductos.RootTable.Columns("TProducto").Visible = False
        'GridProductos.RootTable.Columns("SubTotalPartida").Visible = False
    End Sub

    Private Sub TxtProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProducto.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.F9
                Me.BtnOK.PerformClick()
            Case Is = Keys.Escape
                Me.BtnCancel.PerformClick()
        End Select
    End Sub

    Private Sub GridProductos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.DoubleClick
        If GridProductos.RowCount > 0 AndAlso Not GridProductos.GetValue(0) Is Nothing Then
            PROClave = GridProductos.GetValue("PROClave")
            CantidadDetalle = GridProductos.GetValue("Cantidad")
            PrecioNetoDetalle = GridProductos.GetValue("Precio")
            PuntosDetalle = GridProductos.GetValue("PuntosImp")
            DescuentoDetalle = GridProductos.GetValue("DescuentoImp")
            PorcImp = GridProductos.GetValue("PorcImp")
            Descripcion = GridProductos.GetValue("Descripcion")
            Factor = GridProductos.GetValue("Factor")
            iSeguimiento = GridProductos.GetValue("Seguimiento")
            iDias = GridProductos.GetValue("DiasGarantia")
            Clave = GridProductos.GetValue("Clave")
            Nombre = GridProductos.GetValue("Nombre")
            DVEClave = GridProductos.GetValue("DVEClave")
            TProducto = GridProductos.GetValue("TProducto")

            Cantidad = CantidadDetalle
            TxtProducto.Text = Clave
            TxtCantidad.Text = CantidadDetalle
            LblNombre.Text = Descripcion
        End If
    End Sub


End Class
