Public Class FrmProdDet
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
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpMultiproducto As System.Windows.Forms.GroupBox
    Friend WithEvents NumUnidades As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnBusqueda As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProdDet))
        Me.GrpMultiproducto = New System.Windows.Forms.GroupBox
        Me.TxtUnidad = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.NumUnidades = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnBusqueda = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpMultiproducto.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpMultiproducto
        '
        Me.GrpMultiproducto.Controls.Add(Me.TxtUnidad)
        Me.GrpMultiproducto.Controls.Add(Me.Label1)
        Me.GrpMultiproducto.Controls.Add(Me.ChkEstado)
        Me.GrpMultiproducto.Controls.Add(Me.NumUnidades)
        Me.GrpMultiproducto.Controls.Add(Me.Label2)
        Me.GrpMultiproducto.Controls.Add(Me.TxtNombre)
        Me.GrpMultiproducto.Controls.Add(Me.LblNombre)
        Me.GrpMultiproducto.Controls.Add(Me.TxtClave)
        Me.GrpMultiproducto.Controls.Add(Me.LblClave)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox1)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox2)
        Me.GrpMultiproducto.Controls.Add(Me.BtnBusqueda)
        Me.GrpMultiproducto.Location = New System.Drawing.Point(7, 4)
        Me.GrpMultiproducto.Name = "GrpMultiproducto"
        Me.GrpMultiproducto.Size = New System.Drawing.Size(340, 129)
        Me.GrpMultiproducto.TabIndex = 1
        Me.GrpMultiproducto.TabStop = False
        Me.GrpMultiproducto.Text = "Producto"
        '
        'TxtUnidad
        '
        Me.TxtUnidad.Location = New System.Drawing.Point(79, 74)
        Me.TxtUnidad.Name = "TxtUnidad"
        Me.TxtUnidad.ReadOnly = True
        Me.TxtUnidad.Size = New System.Drawing.Size(120, 20)
        Me.TxtUnidad.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Unidad"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(273, 15)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(60, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'NumUnidades
        '
        Me.NumUnidades.DecimalDigits = 6
        Me.NumUnidades.Location = New System.Drawing.Point(79, 101)
        Me.NumUnidades.Name = "NumUnidades"
        Me.NumUnidades.Size = New System.Drawing.Size(120, 20)
        Me.NumUnidades.TabIndex = 3
        Me.NumUnidades.Text = "0.000000"
        Me.NumUnidades.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumUnidades.Value = 0
        Me.NumUnidades.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 22)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Cantidad"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(79, 48)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(255, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 51)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(79, 19)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(120, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 21)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(233, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(204, 101)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnBusqueda
        '
        Me.BtnBusqueda.Image = CType(resources.GetObject("BtnBusqueda.Image"), System.Drawing.Image)
        Me.BtnBusqueda.Location = New System.Drawing.Point(202, 16)
        Me.BtnBusqueda.Name = "BtnBusqueda"
        Me.BtnBusqueda.Size = New System.Drawing.Size(26, 22)
        Me.BtnBusqueda.TabIndex = 37
        Me.BtnBusqueda.ToolTipText = "Busqueda"
        Me.BtnBusqueda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(161, 139)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(257, 138)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmProdDet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(350, 180)
        Me.Controls.Add(Me.GrpMultiproducto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(366, 208)
        Me.Name = "FrmProdDet"
        Me.Text = "Detalle de Mulitempaque"
        Me.GrpMultiproducto.ResumeLayout(False)
        Me.GrpMultiproducto.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public SubPadre As String
    Public PROClavePadre As String
    Public MLTClave As String
    Public PROClave As String
    Public Clave As String
    Public Nombre As String
    Public Unidad As String
    Public CantidadUnidades As Double = 0
    Public Estado As Integer
    Public TProducto As Integer

    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If CDbl(Me.NumUnidades.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TProducto = 3 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("¡No es posible agregar un producto de tipo Multiempaque o Kit como detalle de otro producto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

    Private Sub FrmProdDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        TxtUnidad.Text = Unidad
        NumUnidades.Text = CStr(CantidadUnidades)
        ChkEstado.Estado = Estado

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    If PROClave Is Nothing Then
                        Dim dt As DataTable
                        dt = ModPOS.SiExisteRecupera("sp_recupera_claveprod", "@Clave", UCase(Trim(Me.TxtClave.Text)))
                        If Not dt Is Nothing Then
                            Me.PROClave = dt.Rows(0)("PROClave")
                            Me.TxtNombre.Text = dt.Rows(0)("Nombre")
                            TProducto = dt.Rows(0)("TProducto")
                            dt.Dispose()
                        End If
                    End If


                    CantidadUnidades = Math.Abs(CDbl(NumUnidades.Text))
                    Me.Estado = ChkEstado.GetEstado

                    ModPOS.Producto.AddMultiproducto(PROClave, TxtClave.Text, TxtNombre.Text, TxtUnidad.Text, CantidadUnidades, Estado, IIf(Estado = 1, "Activo", "Inactivo"), TProducto)


                Case "Modificar"
                    If Not (Estado = ChkEstado.GetEstado AndAlso CantidadUnidades = Math.Abs(CDbl(NumUnidades.Text))) Then

                        Me.Estado = ChkEstado.GetEstado
                        CantidadUnidades = Math.Abs(CDbl(NumUnidades.Text))

                        ModPOS.Producto.AddMultiproducto(PROClave, TxtClave.Text, TxtNombre.Text, TxtUnidad.Text, CantidadUnidades, Estado, IIf(Estado = 1, "Activo", "Inactivo"), TProducto)

                    End If

            End Select
        Me.Close()
        Else
        Beep()
        MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmProdDet_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ProdDet.Dispose()
        ModPOS.ProdDet = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusqueda.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_recupera_claveprod", "@Clave", a.valor)

            If Not dt Is Nothing Then

                Me.PROClave = dt.Rows(0)("PROClave")
                TProducto = dt.Rows(0)("TProducto")
                Me.TxtClave.Text = dt.Rows(0)("Clave")
                Me.TxtNombre.Text = dt.Rows(0)("Nombre")
                Me.TxtUnidad.Text = IIf(dt.Rows(0)("Unidad").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Unidad"))

                dt.Dispose()
            End If


        End If
        a.Dispose()
    End Sub


    Private Sub TxtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then

            Clave = UCase(Trim(Me.TxtClave.Text))

            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_recupera_claveprod", "@Clave", Clave)

            If dt Is Nothing Then

                Beep()
                MessageBox.Show("La Referencia que intenta agregar no existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TxtClave.Text = ""
                Me.TxtNombre.Text = ""
                Me.TxtUnidad.Text = ""
            Else

                Me.PROClave = dt.Rows(0)("PROClave")
                Me.TxtNombre.Text = dt.Rows(0)("Nombre")
                Me.TxtUnidad.Text = dt.Rows(0)("Unidad")

                dt.Dispose()
            End If

        End If
    End Sub


    

End Class
