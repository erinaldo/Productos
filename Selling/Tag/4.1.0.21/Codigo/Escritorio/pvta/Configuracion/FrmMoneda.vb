Public Class FrmMoneda
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
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents NumTipoCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GrpDenominaciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDenominaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents NumTCVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMoneda))
        Me.GrpMoneda = New System.Windows.Forms.GroupBox()
        Me.NumTCVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.NumTipoCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDenominaciones = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridDenominaciones = New Janus.Windows.GridEX.GridEX()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.GrpMoneda.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDenominaciones.SuspendLayout()
        CType(Me.GridDenominaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpMoneda
        '
        Me.GrpMoneda.Controls.Add(Me.NumTCVenta)
        Me.GrpMoneda.Controls.Add(Me.Label1)
        Me.GrpMoneda.Controls.Add(Me.PictureBox4)
        Me.GrpMoneda.Controls.Add(Me.PictureBox2)
        Me.GrpMoneda.Controls.Add(Me.ChkEstado)
        Me.GrpMoneda.Controls.Add(Me.NumTipoCambio)
        Me.GrpMoneda.Controls.Add(Me.Label2)
        Me.GrpMoneda.Controls.Add(Me.PictureBox3)
        Me.GrpMoneda.Controls.Add(Me.TxtDescripcion)
        Me.GrpMoneda.Controls.Add(Me.LblNombre)
        Me.GrpMoneda.Controls.Add(Me.TxtNombre)
        Me.GrpMoneda.Controls.Add(Me.LblClave)
        Me.GrpMoneda.Controls.Add(Me.PictureBox1)
        Me.GrpMoneda.Controls.Add(Me.Label4)
        Me.GrpMoneda.Location = New System.Drawing.Point(7, 3)
        Me.GrpMoneda.Name = "GrpMoneda"
        Me.GrpMoneda.Size = New System.Drawing.Size(618, 125)
        Me.GrpMoneda.TabIndex = 1
        Me.GrpMoneda.TabStop = False
        Me.GrpMoneda.Text = "Moneda"
        '
        'NumTCVenta
        '
        Me.NumTCVenta.DecimalDigits = 4
        Me.NumTCVenta.Location = New System.Drawing.Point(170, 98)
        Me.NumTCVenta.Name = "NumTCVenta"
        Me.NumTCVenta.Size = New System.Drawing.Size(120, 20)
        Me.NumTCVenta.TabIndex = 57
        Me.NumTCVenta.Text = "0.0000"
        Me.NumTCVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumTCVenta.Value = 0.0R
        Me.NumTCVenta.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 19)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Tipo de Cambio (Venta)"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(296, 98)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox4.TabIndex = 58
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(399, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(425, 15)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(56, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'NumTipoCambio
        '
        Me.NumTipoCambio.DecimalDigits = 4
        Me.NumTipoCambio.Location = New System.Drawing.Point(170, 72)
        Me.NumTipoCambio.Name = "NumTipoCambio"
        Me.NumTipoCambio.Size = New System.Drawing.Size(120, 20)
        Me.NumTipoCambio.TabIndex = 3
        Me.NumTipoCambio.Text = "0.0000"
        Me.NumTipoCambio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumTipoCambio.Value = 0.0R
        Me.NumTipoCambio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 19)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Tipo de Cambio (Compra)"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(296, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 32
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(170, 45)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(226, 20)
        Me.TxtDescripcion.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 46)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Descripción"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(170, 17)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(120, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 18)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 14)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(296, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(296, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(439, 335)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(535, 335)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDenominaciones
        '
        Me.GrpDenominaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDenominaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDenominaciones.Controls.Add(Me.BtnAgregar)
        Me.GrpDenominaciones.Controls.Add(Me.GridDenominaciones)
        Me.GrpDenominaciones.Controls.Add(Me.BtnElimina)
        Me.GrpDenominaciones.Controls.Add(Me.BtnModifica)
        Me.GrpDenominaciones.Location = New System.Drawing.Point(7, 134)
        Me.GrpDenominaciones.Name = "GrpDenominaciones"
        Me.GrpDenominaciones.Size = New System.Drawing.Size(618, 195)
        Me.GrpDenominaciones.TabIndex = 4
        Me.GrpDenominaciones.TabStop = False
        Me.GrpDenominaciones.Text = "Denominaciones"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(522, 17)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega nueva denominación de moneda"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDenominaciones
        '
        Me.GridDenominaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDenominaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDenominaciones.ColumnAutoResize = True
        Me.GridDenominaciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDenominaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDenominaciones.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDenominaciones.Location = New System.Drawing.Point(7, 15)
        Me.GridDenominaciones.Name = "GridDenominaciones"
        Me.GridDenominaciones.RecordNavigator = True
        Me.GridDenominaciones.Size = New System.Drawing.Size(509, 172)
        Me.GridDenominaciones.TabIndex = 1
        Me.GridDenominaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(522, 95)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(90, 30)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.Text = "&Eliminar "
        Me.BtnElimina.ToolTipText = "Elimina la denominación seleccionada"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModifica
        '
        Me.BtnModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.Location = New System.Drawing.Point(522, 56)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(90, 30)
        Me.BtnModifica.TabIndex = 3
        Me.BtnModifica.Text = "&Modificar "
        Me.BtnModifica.ToolTipText = "Modifica la denominación seleccionada"
        Me.BtnModifica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMoneda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(632, 377)
        Me.Controls.Add(Me.GrpDenominaciones)
        Me.Controls.Add(Me.GrpMoneda)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMoneda"
        Me.Text = "Moneda"
        Me.GrpMoneda.ResumeLayout(False)
        Me.GrpMoneda.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDenominaciones.ResumeLayout(False)
        CType(Me.GridDenominaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public MONClave As String
    Public Referencia As String
    Public Descripcion As String
    Public Estado As Integer
    Public TipoCambio As Decimal
    Public TipoCambioVenta As Decimal

    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private dtMonedaDetalle As DataTable

    Private sMonDetalle As String
    Private sReferenciaDet As String


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 10 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 10)

        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)

        End If


        If CDec(Me.NumTipoCambio.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDec(Me.NumTCVenta.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Moneda", "@clave", UCase(Trim(Me.TxtNombre.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Public Sub AddDenominacion(ByVal sMNDClave As String, ByVal iTipoDenominacion As Integer, ByVal sTipo As String, ByVal sClave As String, ByVal dDenominacion As Double, ByVal iTipoEstado As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtMonedaDetalle.Select("MNDClave Like '" & sMNDClave & "' and Baja = 0")

        If foundRows.Length = 0 Then

            foundRows = dtMonedaDetalle.Select("Referencia = '" & sClave & "' and TipoDenominacion = '" & iTipoDenominacion.ToString & "' and Baja = 0")
            If foundRows.Length = 0 Then

                foundRows = dtMonedaDetalle.Select("TipoDenominacion = '" & iTipoDenominacion.ToString & "' and Importe = '" & dDenominacion.ToString & "' and Baja = 0")
                If foundRows.Length = 0 Then
                    Dim row1 As DataRow
                    row1 = dtMonedaDetalle.NewRow()
                    'declara el nombre de la fila

                    row1.Item("MNDClave") = sMNDClave
                    row1.Item("TipoDenominacion") = iTipoDenominacion
                    row1.Item("Referencia") = sClave
                    row1.Item("Tipo") = sTipo
                    row1.Item("Importe") = dDenominacion
                    row1.Item("TipoEstado") = iTipoEstado
                    row1.Item("Estado") = IIf(iTipoEstado = 1, "Activo", "Inactivo")
                    row1.Item("update") = 1
                    row1.Item("Baja") = 0

                    dtMonedaDetalle.Rows.Add(row1)
                    'agrega la fila completo a la tabla

                Else
                    Beep()
                    MessageBox.Show("¡El tipo e importe de denominación que intenta agregar ya existe para la moneda actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                Beep()
                MessageBox.Show("¡La referencia de la denominación que intenta agregar ya existe para la moneda actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            foundRows(0)("Referencia") = sClave
            foundRows(0)("Importe") = dDenominacion
            foundRows(0)("Estado") = IIf(iTipoEstado = 1, "Activo", "Inactivo")
            foundRows(0)("TipoEstado") = iTipoEstado
            foundRows(0)("update") = 1
        End If
    End Sub

    Private Sub FrmMoneda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        TxtNombre.Text = Referencia
        TxtDescripcion.Text = Descripcion
        NumTipoCambio.Text = CStr(TipoCambio)
        NumTCVenta.Text = CStr(TipoCambioVenta)
        ChkEstado.Estado = Estado

        If Padre = "Agregar" Then

            MONClave = ModPOS.obtenerLlave

            dtMonedaDetalle = ModPOS.CrearTabla("MonedaDetalle", _
            "MNDClave", "System.String", _
            "TipoDenominacion", "System.Int32", _
            "Tipo", "System.String", _
            "Referencia", "System.String", _
            "Importe", "System.Double", _
            "TipoEstado", "System.Int32", _
            "Estado", "System.String", _
            "update", "System.Int32", _
            "Baja", "System.Int32")
        Else
            dtMonedaDetalle = ModPOS.Recupera_Tabla("sp_recupera_mondetalle", "@MONClave", MONClave)
        End If


        GridDenominaciones.DataSource = dtMonedaDetalle
        GridDenominaciones.RetrieveStructure(True)
        GridDenominaciones.GroupByBoxVisible = False
        GridDenominaciones.RootTable.Columns("MNDClave").Visible = False
        GridDenominaciones.RootTable.Columns("TipoDenominacion").Visible = False
        GridDenominaciones.RootTable.Columns("Update").Visible = False
        GridDenominaciones.RootTable.Columns("TipoEstado").Visible = False
        GridDenominaciones.RootTable.Columns("Baja").Visible = False

        GridDenominaciones.CurrentTable.Columns("Referencia").Selectable = False
        GridDenominaciones.CurrentTable.Columns("Tipo").Selectable = False
        GridDenominaciones.CurrentTable.Columns("Importe").Selectable = False
        GridDenominaciones.CurrentTable.Columns("Estado").Selectable = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDenominaciones.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDenominaciones.RootTable.FormatConditions.Add(fc)


        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDenominaciones.RootTable.Columns("TipoEstado"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)

        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDenominaciones.RootTable.FormatConditions.Add(fc1)

    End Sub

    Private Sub reinicializaForm()

        dtMonedaDetalle.Dispose()

        TxtNombre.Text = ""
        TxtDescripcion.Text = ""
        NumTipoCambio.Text = ""
        NumTCVenta.Text = ""
        MONClave = ModPOS.obtenerLlave

        dtMonedaDetalle = ModPOS.CrearTabla("MonedaDetalle", _
        "MNDClave", "System.String", _
        "TipoDenominacion", "System.Int32", _
        "Tipo", "System.String", _
        "Referencia", "System.String", _
        "Importe", "System.Double", _
        "TipoEstado", "System.Int32", _
        "Estado", "System.String", _
        "update", "System.Int32", _
        "Baja", "System.Int32")


        GridDenominaciones.DataSource = dtMonedaDetalle
        GridDenominaciones.RetrieveStructure(True)
        GridDenominaciones.GroupByBoxVisible = False
        GridDenominaciones.RootTable.Columns("MNDClave").Visible = False
        GridDenominaciones.RootTable.Columns("TipoDenominacion").Visible = False
        GridDenominaciones.RootTable.Columns("Update").Visible = False
        GridDenominaciones.RootTable.Columns("TipoEstado").Visible = False
        GridDenominaciones.RootTable.Columns("Baja").Visible = False

        GridDenominaciones.CurrentTable.Columns("Referencia").Selectable = False
        GridDenominaciones.CurrentTable.Columns("Tipo").Selectable = False
        GridDenominaciones.CurrentTable.Columns("Importe").Selectable = False
        GridDenominaciones.CurrentTable.Columns("Estado").Selectable = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDenominaciones.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDenominaciones.RootTable.FormatConditions.Add(fc)


        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDenominaciones.RootTable.Columns("TipoEstado"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)

        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDenominaciones.RootTable.FormatConditions.Add(fc1)

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    Referencia = UCase(Trim(Me.TxtNombre.Text))
                    Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                    TipoCambio = Math.Abs(CDec(NumTipoCambio.Text))
                    TipoCambioVenta = Math.Abs(CDec(NumTCVenta.Text))
                    ModPOS.Ejecuta("sp_inserta_moneda", "@MONClave", MONClave, "@Referencia", Referencia, "@Descripcion", Descripcion, "@TipoCambio", TipoCambio, "@TipoCambioVenta", TipoCambioVenta, "@Usuario", ModPOS.UsuarioActual)

                   

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMonedaDetalle.Select(" update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta denominaciones

                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_monedadetalle", _
                            "@MONClave", MONClave, _
                            "@MNDClave", foundRows(z)("MNDClave"), _
                            "@TipoDenominacion", foundRows(z)("TipoDenominacion"), _
                            "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                            "@Importe", foundRows(z)("Importe"), _
                            "@Estado", foundRows(z)("TipoEstado"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next

                    End If

                    reinicializaForm()

                    If Not ModPOS.MtoMon Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoMon.GridMonedas, "sp_muestra_monedas", Nothing)
                        ModPOS.MtoMon.GridMonedas.RootTable.Columns("MONClave").Visible = False
                    End If

                Case "Modificar"
                    If Not (Estado = ChkEstado.GetEstado AndAlso Descripcion = TxtDescripcion.Text AndAlso
                             TipoCambio = Math.Abs(CDec(NumTipoCambio.Text)) AndAlso _
                             TipoCambioVenta = Math.Abs(CDec(NumTCVenta.Text))) Then

                        Me.Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                        Me.Estado = ChkEstado.GetEstado
                        TipoCambio = Math.Abs(CDec(NumTipoCambio.Text))
                        TipoCambioVenta = Math.Abs(CDec(NumTCVenta.Text))

                        ModPOS.Ejecuta("sp_actualiza_moneda", "@MONClave", MONClave, "@Descripcion", Descripcion, "@Estado", Estado, "@TipoCambio", TipoCambio, "@TipoCambioVenta", TipoCambioVenta, "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoMon Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoMon.GridMonedas, "sp_muestra_monedas", Nothing)
                            ModPOS.MtoMon.GridMonedas.RootTable.Columns("MONClave").Visible = False
                        End If
                    End If

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMonedaDetalle.Select(" update = 1 ")

                    If foundRows.Length <> 0 Then
                        'actualiza denominaciones
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_actualiza_monedadetalle", _
                            "@MONClave", MONClave, _
                            "@MNDClave", foundRows(z)("MNDClave"), _
                            "@TipoDenominacion", foundRows(z)("TipoDenominacion"), _
                            "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                            "@Importe", foundRows(z)("Importe"), _
                            "@Estado", foundRows(z)("TipoEstado"), _
                            "@Baja", foundRows(z)("Baja"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtMonedaDetalle.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then
                        'inserta denominaciones

                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_monedadetalle", _
                            "@MNDClave", foundRows(z)("MNDClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next

                    End If


                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmMoneda_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Moneda.Dispose()
        ModPOS.Moneda = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

 
    Private Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim a As New FrmAddDenominacion
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

    Private Sub BtnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModifica.Click
        If Me.sMonDetalle <> "" Then
            Dim a As New FrmAddDenominacion
            a.Padre = "Modificar"
            a.MNDClave = sMonDetalle
            a.Denominacion = GridDenominaciones.GetValue("TipoDenominacion")
            a.Referencia = sReferenciaDet
            a.Importe = GridDenominaciones.GetValue("Importe")
            a.Estado = GridDenominaciones.GetValue("TipoEstado")
            a.ShowDialog()
        End If
    End Sub

    Private Sub GridDenominaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDenominaciones.DoubleClick
        If Me.sMonDetalle <> "" Then
            Dim a As New FrmAddDenominacion
            a.Padre = "Modificar"
            a.MNDClave = sMonDetalle
            a.Denominacion = GridDenominaciones.GetValue("TipoDenominacion")
            a.Referencia = sReferenciaDet
            a.Importe = GridDenominaciones.GetValue("Importe")
            a.Estado = GridDenominaciones.GetValue("TipoEstado")
            a.ShowDialog()
        End If
    End Sub

    Private Sub GridDenominaciones_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDenominaciones.SelectionChanged
        If Not Me.GridDenominaciones.GetValue("MNDClave") Is Nothing Then
            Me.BtnElimina.Enabled = True
            Me.sMonDetalle = GridDenominaciones.GetValue("MNDClave")
            Me.sReferenciaDet = GridDenominaciones.GetValue("Referencia")
            Me.BtnModifica.Enabled = True
        Else
            Me.sMonDetalle = ""
            Me.sReferenciaDet = ""
            Me.BtnElimina.Enabled = False
            Me.BtnModifica.Enabled = False
        End If
    End Sub

    Private Sub BtnElimina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnElimina.Click
        If Me.sMonDetalle <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la referencia :" & sReferenciaDet, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMonedaDetalle.Select("MNDClave Like '" & sMonDetalle & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub
End Class
