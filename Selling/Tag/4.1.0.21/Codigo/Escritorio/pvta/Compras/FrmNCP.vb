Public Class FrmNCP
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbFechaCompra As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtFolioFactura As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProv As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProv As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNCP))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbFechaCompra = New System.Windows.Forms.DateTimePicker()
        Me.TxtFolioFactura = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.BtnBuscaProv = New Janus.Windows.EditControls.UIButton()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClaveProv = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(617, 131)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(521, 131)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Fecha "
        '
        'CmbFechaCompra
        '
        Me.CmbFechaCompra.CustomFormat = "yyyyMMdd"
        Me.CmbFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaCompra.Location = New System.Drawing.Point(102, 31)
        Me.CmbFechaCompra.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaCompra.Name = "CmbFechaCompra"
        Me.CmbFechaCompra.Size = New System.Drawing.Size(113, 20)
        Me.CmbFechaCompra.TabIndex = 2
        Me.CmbFechaCompra.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'TxtFolioFactura
        '
        Me.TxtFolioFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioFactura.Location = New System.Drawing.Point(102, 6)
        Me.TxtFolioFactura.Name = "TxtFolioFactura"
        Me.TxtFolioFactura.Size = New System.Drawing.Size(113, 21)
        Me.TxtFolioFactura.TabIndex = 1
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(5, 8)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(57, 15)
        Me.LblNombre.TabIndex = 127
        Me.LblNombre.Text = "Folio"
        '
        'BtnBuscaProv
        '
        Me.BtnBuscaProv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProv.Image = CType(resources.GetObject("BtnBuscaProv.Image"), System.Drawing.Image)
        Me.BtnBuscaProv.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProv.Location = New System.Drawing.Point(652, 53)
        Me.BtnBuscaProv.Name = "BtnBuscaProv"
        Me.BtnBuscaProv.Size = New System.Drawing.Size(40, 24)
        Me.BtnBuscaProv.TabIndex = 123
        Me.BtnBuscaProv.ToolTipText = "Busqueda de Proveedor"
        Me.BtnBuscaProv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(221, 56)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(422, 19)
        Me.TxtRazonSocial.TabIndex = 124
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Prov. Cve."
        '
        'TxtClaveProv
        '
        Me.TxtClaveProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProv.Location = New System.Drawing.Point(102, 55)
        Me.TxtClaveProv.Name = "TxtClaveProv"
        Me.TxtClaveProv.Size = New System.Drawing.Size(113, 21)
        Me.TxtClaveProv.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(5, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 15)
        Me.Label15.TabIndex = 130
        Me.Label15.Text = "Nota"
        '
        'TxtNota
        '
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(102, 82)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(542, 21)
        Me.TxtNota.TabIndex = 4
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(102, 109)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(114, 20)
        Me.TxtImporte.TabIndex = 5
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporte.Value = 0.0R
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Importe"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(67, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox1.TabIndex = 133
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(67, 56)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox2.TabIndex = 134
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(67, 109)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox3.TabIndex = 135
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'FrmNCP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(712, 173)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtImporte)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtNota)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbFechaCompra)
        Me.Controls.Add(Me.TxtFolioFactura)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.BtnBuscaProv)
        Me.Controls.Add(Me.TxtRazonSocial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtClaveProv)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(552, 182)
        Me.Name = "FrmNCP"
        Me.Text = "Nota de Crédito de Proveedor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String
    Private sPRVClave As String
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private Sub FrmNCP_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.NCP.Dispose()
        ModPOS.NCP = Nothing
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub CargaDatosProveedor(ByVal Clave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_busca_proveedor", "@Clave", Clave, "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            sPRVClave = dt.Rows(0)("PRVClave")
            TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
              CmbFechaCompra.Focus()
            TxtClaveProv.Text = Clave
        Else
            MsgBox("No se encontro un proveedor que coincida con la clave proporcionada")
            TxtRazonSocial.Text = ""
            sPRVClave = ""
        End If
        dt.Dispose()
    End Sub
    Private Sub BtnBuscaProv_Click(sender As Object, e As EventArgs) Handles BtnBuscaProv.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_proveedor"
        a.TablaCmb = "Proveedor"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.NumColDes2 = 4
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            CargaDatosProveedor(a.Descripcion)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClaveProv_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClaveProv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TxtClaveProv.Text = vbNullString Then
                CargaDatosProveedor(TxtClaveProv.Text.ToUpper.Trim.Replace("'", "''"))
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del proveedor
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_proveedor"
            a.TablaCmb = "Proveedor"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.NumColDes2 = 4
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProv.Text.Trim.ToUpper
            a.OcultaID = True
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                CargaDatosProveedor(a.Descripcion)
            End If
            a.Dispose()
        End If
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If TxtFolioFactura.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If sPRVClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtImporte.Text = "" OrElse CDbl(TxtImporte.Text) <= 0 Then
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


    Private Sub FrmNCP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        CmbFechaCompra.Value = Today.Date

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            ModPOS.Ejecuta("st_inserta_ncproveedor", _
                           "@NCPClave", ModPOS.obtenerLlave, _
                           "@Folio", TxtFolioFactura.Text.ToUpper.Trim, _
                           "@PRVClave", sPRVClave, _
                           "@Fecha", CmbFechaCompra.Value, _
                           "@Total", CDbl(TxtImporte.Text), _
                           "@Nota", TxtNota.Text, _
                           "@Usuario", ModPOS.UsuarioActual)

            If Not ModPOS.NCProveedor Is Nothing Then
                ModPOS.NCProveedor.refrescaGrid()
            End If

            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
