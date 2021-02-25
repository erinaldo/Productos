Public Class FrmProdCombo
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
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtOrden As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbColor As Selling.StoreCombo
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents ChkColor As Selling.ChkStatus
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProdCombo))
        Me.GrpMultiproducto = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtOrden = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.NumUnidades = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnBusqueda = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ChkColor = New Selling.ChkStatus(Me.components)
        Me.cmbColor = New Selling.StoreCombo()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.GrpMultiproducto.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpMultiproducto
        '
        Me.GrpMultiproducto.Controls.Add(Me.ChkColor)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox3)
        Me.GrpMultiproducto.Controls.Add(Me.txtOrden)
        Me.GrpMultiproducto.Controls.Add(Me.Label1)
        Me.GrpMultiproducto.Controls.Add(Me.cmbColor)
        Me.GrpMultiproducto.Controls.Add(Me.lblColor)
        Me.GrpMultiproducto.Controls.Add(Me.ChkEstado)
        Me.GrpMultiproducto.Controls.Add(Me.NumUnidades)
        Me.GrpMultiproducto.Controls.Add(Me.Label2)
        Me.GrpMultiproducto.Controls.Add(Me.TxtClave)
        Me.GrpMultiproducto.Controls.Add(Me.LblClave)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox1)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox2)
        Me.GrpMultiproducto.Controls.Add(Me.BtnBusqueda)
        Me.GrpMultiproducto.Location = New System.Drawing.Point(7, 4)
        Me.GrpMultiproducto.Name = "GrpMultiproducto"
        Me.GrpMultiproducto.Size = New System.Drawing.Size(460, 136)
        Me.GrpMultiproducto.TabIndex = 1
        Me.GrpMultiproducto.TabStop = False
        Me.GrpMultiproducto.Text = "Producto"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(205, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox3.TabIndex = 125
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'txtOrden
        '
        Me.txtOrden.DecimalDigits = 0
        Me.txtOrden.Location = New System.Drawing.Point(78, 100)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(120, 20)
        Me.txtOrden.TabIndex = 123
        Me.txtOrden.Text = "0"
        Me.txtOrden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtOrden.Value = 0
        Me.txtOrden.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 22)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Orden"
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(13, 48)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(78, 15)
        Me.lblColor.TabIndex = 122
        Me.lblColor.Text = "Color"
        Me.lblColor.Visible = False
        '
        'NumUnidades
        '
        Me.NumUnidades.DecimalDigits = 6
        Me.NumUnidades.Location = New System.Drawing.Point(79, 72)
        Me.NumUnidades.Name = "NumUnidades"
        Me.NumUnidades.Size = New System.Drawing.Size(120, 20)
        Me.NumUnidades.TabIndex = 3
        Me.NumUnidades.Text = "0.000000"
        Me.NumUnidades.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumUnidades.Value = 0.0R
        Me.NumUnidades.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 22)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Cantidad"
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
        Me.LblClave.Text = "Modelo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(234, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 20)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(204, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 20)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(281, 146)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(377, 146)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkColor
        '
        Me.ChkColor.Checked = True
        Me.ChkColor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkColor.Location = New System.Drawing.Point(273, 48)
        Me.ChkColor.Name = "ChkColor"
        Me.ChkColor.Size = New System.Drawing.Size(156, 22)
        Me.ChkColor.TabIndex = 126
        Me.ChkColor.Text = "Todos los colores"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.SystemColors.Window
        Me.cmbColor.Enabled = False
        Me.cmbColor.Location = New System.Drawing.Point(79, 45)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(119, 21)
        Me.cmbColor.TabIndex = 121
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
        'FrmProdCombo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(479, 190)
        Me.Controls.Add(Me.GrpMultiproducto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(366, 208)
        Me.Name = "FrmProdCombo"
        Me.Text = "Detalle de Mulitempaque"
        Me.GrpMultiproducto.ResumeLayout(False)
        Me.GrpMultiproducto.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public TallaColor As Integer = 0
    Public Padre As String
    Public SubPadre As String
    Public PROClavePadre As String
    Public MLTClave As String
    Public Modelo As String
    Public iColor As Integer = -1
    Public Color As String
    Public CantidadUnidades As Double = 0
    Public Estado As Integer
    Public TProducto As Integer


    Private alerta(2) As PictureBox
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


        If ChkColor.Checked = False AndAlso cmbColor.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDbl(Me.NumUnidades.Text) = 0 Then
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

    Private Sub FrmProdDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        TxtClave.Text = Modelo
        NumUnidades.Text = CStr(CantidadUnidades)
        ChkEstado.Estado = Estado

        If iColor = -1 Then
            ChkColor.Checked = True
        Else
            ChkColor.Checked = False

            With Me.cmbColor
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_obtener_colores"
                .NombreParametro1 = "COMClave"
                .Parametro1 = ModPOS.CompanyActual
                .NombreParametro2 = "Modelo"
                .Parametro2 = Modelo
                .llenar()
            End With

        End If


        cmbColor.SelectedValue = iColor


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"


                    If ChkColor.Checked = True Then
                        iColor = -1
                        Color = "TODOS"
                    Else
                        iColor = cmbColor.SelectedValue
                        Color = cmbColor.SelectedItem(1)
                    End If


                    CantidadUnidades = Math.Abs(CDbl(NumUnidades.Text))
                    Me.Estado = ChkEstado.GetEstado

                    ModPOS.Producto.AddMultiproducto("", "", "", Modelo, iColor, Color, "", CantidadUnidades, Estado, IIf(Estado = 1, "Activo", "Inactivo"), TProducto, txtOrden.Text)

                Case "Modificar"
                    If Not (Estado = ChkEstado.GetEstado AndAlso iColor = cmbColor.SelectedValue AndAlso CantidadUnidades = Math.Abs(CDbl(NumUnidades.Text))) Then


                        If ChkColor.Checked = True Then
                            iColor = -1
                            Color = "TODOS"
                        Else
                            iColor = cmbColor.SelectedValue
                            Color = cmbColor.SelectedItem(1)
                        End If

                        Me.Estado = ChkEstado.GetEstado
                        CantidadUnidades = Math.Abs(CDbl(NumUnidades.Text))


                        ModPOS.Producto.AddMultiproducto("", "", "", Modelo, iColor, Color, "", CantidadUnidades, Estado, IIf(Estado = 1, "Activo", "Inactivo"), TProducto, txtOrden.Text)

                    End If

            End Select
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusqueda.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
            a.NumColDes3 = 3
        Else
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Modelo = a.Descripcion3
            TxtClave.Text = Modelo
            With Me.cmbColor
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_obtener_colores"
                .NombreParametro1 = "COMClave"
                .Parametro1 = ModPOS.CompanyActual
                .NombreParametro2 = "Modelo"
                .Parametro2 = Modelo
                .llenar()
            End With
        End If
        a.Dispose()
    End Sub


    Private Sub TxtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            Modelo = UCase(Trim(Me.TxtClave.Text))
            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Modelo)
            If dt.Rows.Count = 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar no existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TxtClave.Text = ""
            Else
                Modelo = dt.Rows(0)("Modelo")
                dt.Dispose()

                'Carga Colores
                With Me.cmbColor
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "st_obtener_colores"
                    .NombreParametro1 = "COMClave"
                    .Parametro1 = ModPOS.CompanyActual
                    .NombreParametro2 = "Modelo"
                    .Parametro2 = Modelo
                    .llenar()
                End With



            End If

        End If
    End Sub




    Private Sub ChkColor_CheckedChanged(sender As Object, e As EventArgs) Handles ChkColor.CheckedChanged
        If ChkColor.Checked = True Then
            cmbColor.Enabled = False
        Else
            cmbColor.Enabled = True
        End If
    End Sub
End Class
