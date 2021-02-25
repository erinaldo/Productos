Imports System.Data.SqlClient

Public Class FrmPasillo
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
    Friend WithEvents GrpPasillo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblLargo As System.Windows.Forms.Label
    Friend WithEvents LblAncho As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtAncho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtLargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPasillo))
        Me.GrpPasillo = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbAlmacen = New Selling.StoreCombo
        Me.cmbTipoEstado = New Selling.StoreCombo
        Me.LblEstado = New System.Windows.Forms.Label
        Me.TxtLargo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtAncho = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblAncho = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblLargo = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpPasillo.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPasillo
        '
        Me.GrpPasillo.Controls.Add(Me.PictureBox5)
        Me.GrpPasillo.Controls.Add(Me.Label4)
        Me.GrpPasillo.Controls.Add(Me.cmbAlmacen)
        Me.GrpPasillo.Controls.Add(Me.cmbTipoEstado)
        Me.GrpPasillo.Controls.Add(Me.LblEstado)
        Me.GrpPasillo.Controls.Add(Me.TxtLargo)
        Me.GrpPasillo.Controls.Add(Me.TxtAncho)
        Me.GrpPasillo.Controls.Add(Me.PictureBox4)
        Me.GrpPasillo.Controls.Add(Me.PictureBox3)
        Me.GrpPasillo.Controls.Add(Me.PictureBox2)
        Me.GrpPasillo.Controls.Add(Me.Label3)
        Me.GrpPasillo.Controls.Add(Me.Label2)
        Me.GrpPasillo.Controls.Add(Me.LblAncho)
        Me.GrpPasillo.Controls.Add(Me.TxtNombre)
        Me.GrpPasillo.Controls.Add(Me.LblLargo)
        Me.GrpPasillo.Controls.Add(Me.LblNombre)
        Me.GrpPasillo.Controls.Add(Me.LblClave)
        Me.GrpPasillo.Controls.Add(Me.TxtClave)
        Me.GrpPasillo.Controls.Add(Me.PictureBox1)
        Me.GrpPasillo.Controls.Add(Me.Label1)
        Me.GrpPasillo.Location = New System.Drawing.Point(7, 7)
        Me.GrpPasillo.Name = "GrpPasillo"
        Me.GrpPasillo.Size = New System.Drawing.Size(293, 164)
        Me.GrpPasillo.TabIndex = 0
        Me.GrpPasillo.TabStop = False
        Me.GrpPasillo.Text = "Pasillo"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(273, 104)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 24
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Almacén"
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Location = New System.Drawing.Point(73, 104)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(194, 21)
        Me.cmbAlmacen.TabIndex = 5
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Location = New System.Drawing.Point(73, 134)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoEstado.TabIndex = 6
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(7, 141)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(80, 15)
        Me.LblEstado.TabIndex = 19
        Me.LblEstado.Text = "Estado"
        '
        'TxtLargo
        '
        Me.TxtLargo.DecimalDigits = 2
        Me.TxtLargo.Location = New System.Drawing.Point(73, 59)
        Me.TxtLargo.Name = "TxtLargo"
        Me.TxtLargo.Size = New System.Drawing.Size(127, 20)
        Me.TxtLargo.TabIndex = 3
        Me.TxtLargo.Text = "0.00"
        Me.TxtLargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtLargo.Value = 0
        Me.TxtLargo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtAncho
        '
        Me.TxtAncho.DecimalDigits = 2
        Me.TxtAncho.Location = New System.Drawing.Point(73, 82)
        Me.TxtAncho.Name = "TxtAncho"
        Me.TxtAncho.Size = New System.Drawing.Size(127, 20)
        Me.TxtAncho.TabIndex = 4
        Me.TxtAncho.Text = "0.00"
        Me.TxtAncho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAncho.Value = 0
        Me.TxtAncho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(207, 82)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(207, 59)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(273, 37)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(207, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Metros"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(207, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Metros"
        '
        'LblAncho
        '
        Me.LblAncho.Location = New System.Drawing.Point(7, 82)
        Me.LblAncho.Name = "LblAncho"
        Me.LblAncho.Size = New System.Drawing.Size(60, 21)
        Me.LblAncho.TabIndex = 6
        Me.LblAncho.Text = "Ancho"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(73, 37)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(194, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblLargo
        '
        Me.LblLargo.Location = New System.Drawing.Point(7, 59)
        Me.LblLargo.Name = "LblLargo"
        Me.LblLargo.Size = New System.Drawing.Size(60, 22)
        Me.LblLargo.TabIndex = 4
        Me.LblLargo.Text = "Largo"
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 37)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(60, 22)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 15)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(60, 21)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Referencia"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(73, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(220, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(220, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Max. 10 Caracteres"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(113, 179)
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
        Me.BtnAgregar.Location = New System.Drawing.Point(210, 179)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPasillo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(309, 220)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpPasillo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPasillo"
        Me.Text = "Mantenimiento de Pasillos"
        Me.GrpPasillo.ResumeLayout(False)
        Me.GrpPasillo.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Forma As String = ""
    Public PASClave As String
    Public Referencia As String
    Public Nombre As String
    Public Largo As Double
    Public Ancho As Double
    Public Estado As Integer
    Public ALMClave As String

    Public sCpyALMClave As String
    Public sCpyNombre As String
    Public dCpyLargo As Double
    Public dCpyAncho As Double
    Public iCpyEstado As Integer



    Public Padre As String

    Private alerta(4) As PictureBox
    Private reloj As parpadea
    Private Cnx As SqlConnection
    Private da As SqlDataAdapter
    Private ds As DataTable

    Private Sub FrmPasillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5


    End Sub

    Private Sub FrmPasillo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPos.Pasillo.Dispose()
        ModPos.Pasillo = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)

        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)

        End If

        If Me.TxtLargo.Text = "" OrElse CDbl(Me.TxtLargo.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtAncho.Text = "" OrElse CDbl(Me.TxtAncho.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False

        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPos.BDConexion
            If (ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Pasillo", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual)) > 0 Then
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then
            Select Case ModPos.Pasillo.Padre
                Case "Agregar"
                    PASClave = ModPOS.obtenerLlave
                    Me.Referencia = UCase(Trim(Me.TxtClave.Text))
                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Largo = CDbl(Me.TxtLargo.Text)
                    Me.Ancho = CDbl(Me.TxtAncho.Text)
                    Me.ALMClave = cmbAlmacen.SelectedValue
                    Me.Estado = 1
                    ModPOS.Graba_Pasillo(Me)
                    Me.TxtClave.Text = ""
                    Me.TxtNombre.Text = ""
                    Me.TxtLargo.Text = ""
                    Me.TxtAncho.Text = ""
                    If Not (ModPOS.MtoPasillo Is Nothing) Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoPasillo.GridPasillos, "sp_muestra_pasillos", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoPasillo.GridPasillos.RootTable.Columns("ID").Visible = False
                    Else
                        If Forma = "Estructura" Then
                            With ModPOS.Estructuras
                                With .CmbColoca
                                    .Conexion = ModPOS.BDConexion
                                    .ProcedimientoAlmacenado = "sp_filtra_pasillo"
                                    .NombreParametro1 = "ALMClave"
                                    .Parametro1 = ModPOS.Almacen_Activo
                                    .llenar()
                                End With

                                With .CmbRecolecta
                                    .Conexion = ModPOS.BDConexion
                                    .ProcedimientoAlmacenado = "sp_filtra_pasillo"
                                    .NombreParametro1 = "ALMClave"
                                    .Parametro1 = ModPOS.Almacen_Activo
                                    .llenar()
                                End With
                            End With
                        End If
                    End If

                Case "Modificar"
                    Me.Referencia = UCase(Trim(Me.TxtClave.Text))
                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Largo = CDbl(Me.TxtLargo.Text)
                    Me.Ancho = CDbl(Me.TxtAncho.Text)
                    Me.Estado = Me.cmbTipoEstado.SelectedValue
                    Me.ALMClave = cmbAlmacen.SelectedValue

                    If Not (Me.Nombre = Me.sCpyNombre AndAlso _
                    Me.Largo = Me.dCpyLargo AndAlso _
                    Me.Estado = Me.iCpyEstado AndAlso _
                    Me.ALMClave = Me.sCpyALMClave AndAlso _
                    Me.Ancho = Me.dCpyAncho) Then

                        ModPOS.Update_Pasillo(ModPOS.Pasillo)

                        ModPOS.ActualizaGrid(True, ModPOS.MtoPasillo.GridPasillos, "sp_muestra_pasillos", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoPasillo.GridPasillos.RootTable.Columns("ID").Visible = False

                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

End Class
