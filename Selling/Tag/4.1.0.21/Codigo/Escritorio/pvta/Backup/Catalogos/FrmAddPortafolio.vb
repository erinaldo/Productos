Public Class FrmAddPortafolio
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
    Friend WithEvents GrpProducto As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddPortafolio))
        Me.GrpProducto = New System.Windows.Forms.GroupBox
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtProducto = New System.Windows.Forms.TextBox
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblCodigoBarras = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpProducto.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpProducto
        '
        Me.GrpProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProducto.Controls.Add(Me.TxtCantidad)
        Me.GrpProducto.Controls.Add(Me.Label5)
        Me.GrpProducto.Controls.Add(Me.BtnBuscaProd)
        Me.GrpProducto.Controls.Add(Me.Label3)
        Me.GrpProducto.Controls.Add(Me.TxtProducto)
        Me.GrpProducto.Controls.Add(Me.txtClave)
        Me.GrpProducto.Controls.Add(Me.Label1)
        Me.GrpProducto.Controls.Add(Me.TxtNombre)
        Me.GrpProducto.Controls.Add(Me.LblCodigoBarras)
        Me.GrpProducto.Location = New System.Drawing.Point(4, 3)
        Me.GrpProducto.Name = "GrpProducto"
        Me.GrpProducto.Size = New System.Drawing.Size(547, 137)
        Me.GrpProducto.TabIndex = 0
        Me.GrpProducto.TabStop = False
        Me.GrpProducto.Text = "Producto"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(69, 103)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(53, 20)
        Me.TxtCantidad.TabIndex = 102
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(198, 23)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(24, 22)
        Me.BtnBuscaProd.TabIndex = 103
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Producto"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(69, 24)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(124, 21)
        Me.TxtProducto.TabIndex = 101
        '
        'txtClave
        '
        Me.txtClave.Enabled = False
        Me.txtClave.Location = New System.Drawing.Point(69, 50)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(98, 20)
        Me.txtClave.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Clave"
        '
        'TxtNombre
        '
        Me.TxtNombre.Enabled = False
        Me.TxtNombre.Location = New System.Drawing.Point(69, 78)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(373, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblCodigoBarras
        '
        Me.LblCodigoBarras.Location = New System.Drawing.Point(5, 81)
        Me.LblCodigoBarras.Name = "LblCodigoBarras"
        Me.LblCodigoBarras.Size = New System.Drawing.Size(80, 16)
        Me.LblCodigoBarras.TabIndex = 87
        Me.LblCodigoBarras.Text = "Nombre"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(365, 146)
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
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(461, 146)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddPortafolio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(557, 191)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpProducto)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddPortafolio"
        Me.Text = "Agregar Producto"
        Me.GrpProducto.ResumeLayout(False)
        Me.GrpProducto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sClave As String
    Private sNombre As String
    Private sPROClave As String
    Private iTProducto As Integer
    Private dCantidad As Double
    Private iFactor As Integer
    Private iNumDecimales As Integer

    Private Sub leeCodigoBarras(ByVal Codigo As String)
        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_portafolio_producto", "@Busca", Codigo.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

                sPROClave = dtProducto.Rows(0)("PROClave")
                sClave = dtProducto.Rows(0)("Clave")
                sNombre = dtProducto.Rows(0)("Nombre")
                iTProducto = dtProducto.Rows(0)("TProducto")
                iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
                iFactor = dtProducto.Rows(0)("Factor")
                dtProducto.Dispose()

                TxtCantidad.DecimalDigits = iNumDecimales

                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                    dCantidad = 1 * iFactor
                    TxtCantidad.Text = "1"
                Else
                    dCantidad = CDbl(TxtCantidad.Text) * iFactor
                End If

                txtClave.Text = sClave
                TxtNombre.Text = sNombre

                Me.BtnAgregar.Focus()
            Else

                Beep()
                MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub FrmAddPortafolio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddPortafolio.Dispose()
        ModPOS.AddPortafolio = Nothing
    End Sub

    Private Sub Reinicializa()
        sPROClave = 0
        iTProducto = 0
        iNumDecimales = 0
        iFactor = 0
        dCantidad = 1
        TxtProducto.Text = ""
        sClave = ""
        sNombre = ""
        txtClave.Text = sClave
        TxtNombre.Text = sNombre
        TxtCantidad.Text = dCantidad
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

  
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If sClave <> "" Then
            If dCantidad <= 0 Then
                dCantidad = 1
            End If

            If Not ModPOS.Portafolio Is Nothing Then
                ModPOS.Portafolio.AddNuevoProducto(sPROClave, sClave, sNombre, dCantidad)
                Reinicializa()
                TxtProducto.Focus()
            Else
                Me.Close()
            End If

        Else
            MessageBox.Show("Debe especificar un producto, escribiendo la clave de producto, codigo de barras o mediante la opción de buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtProducto.Text = a.valor
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub
End Class
