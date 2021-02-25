Imports System.Data.SqlClient

Public Class FrmArea
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
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblTArea As System.Windows.Forms.Label
    Friend WithEvents LblColor As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents BtnColor As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PnlColor As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbTipoArea As Selling.StoreCombo
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArea))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbAlmacen = New Selling.StoreCombo
        Me.cmbTipoEstado = New Selling.StoreCombo
        Me.LblEstado = New System.Windows.Forms.Label
        Me.CmbTipoArea = New Selling.StoreCombo
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PnlColor = New System.Windows.Forms.Panel
        Me.BtnColor = New Janus.Windows.EditControls.UIButton
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblColor = New System.Windows.Forms.Label
        Me.LblTArea = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.PictureBox5)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.cmbAlmacen)
        Me.GrpGeneral.Controls.Add(Me.cmbTipoEstado)
        Me.GrpGeneral.Controls.Add(Me.LblEstado)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoArea)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.PnlColor)
        Me.GrpGeneral.Controls.Add(Me.BtnColor)
        Me.GrpGeneral.Controls.Add(Me.TxtNombre)
        Me.GrpGeneral.Controls.Add(Me.TxtClave)
        Me.GrpGeneral.Controls.Add(Me.LblColor)
        Me.GrpGeneral.Controls.Add(Me.LblTArea)
        Me.GrpGeneral.Controls.Add(Me.LblNombre)
        Me.GrpGeneral.Controls.Add(Me.LblClave)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Location = New System.Drawing.Point(6, 7)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(306, 211)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "General"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(285, 148)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox5.TabIndex = 27
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Almacén"
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Location = New System.Drawing.Point(87, 145)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(193, 21)
        Me.cmbAlmacen.TabIndex = 25
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Location = New System.Drawing.Point(87, 178)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoEstado.TabIndex = 5
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(7, 181)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(80, 15)
        Me.LblEstado.TabIndex = 17
        Me.LblEstado.Text = "Estado"
        '
        'CmbTipoArea
        '
        Me.CmbTipoArea.Location = New System.Drawing.Point(87, 74)
        Me.CmbTipoArea.Name = "CmbTipoArea"
        Me.CmbTipoArea.Size = New System.Drawing.Size(140, 21)
        Me.CmbTipoArea.TabIndex = 3
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(127, 111)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(233, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(287, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(233, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PnlColor
        '
        Me.PnlColor.BackColor = System.Drawing.Color.White
        Me.PnlColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlColor.Location = New System.Drawing.Point(87, 104)
        Me.PnlColor.Name = "PnlColor"
        Me.PnlColor.Size = New System.Drawing.Size(33, 30)
        Me.PnlColor.TabIndex = 9
        '
        'BtnColor
        '
        Me.BtnColor.Location = New System.Drawing.Point(147, 104)
        Me.BtnColor.Name = "BtnColor"
        Me.BtnColor.Size = New System.Drawing.Size(90, 30)
        Me.BtnColor.TabIndex = 4
        Me.BtnColor.Text = "Ca&mbiar Color"
        Me.BtnColor.ToolTipText = "Modificar el color del area"
        Me.BtnColor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(87, 45)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(200, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(87, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblColor
        '
        Me.LblColor.Location = New System.Drawing.Point(7, 111)
        Me.LblColor.Name = "LblColor"
        Me.LblColor.Size = New System.Drawing.Size(80, 15)
        Me.LblColor.TabIndex = 3
        Me.LblColor.Text = "Color"
        '
        'LblTArea
        '
        Me.LblTArea.Location = New System.Drawing.Point(7, 82)
        Me.LblTArea.Name = "LblTArea"
        Me.LblTArea.Size = New System.Drawing.Size(80, 15)
        Me.LblTArea.TabIndex = 2
        Me.LblTArea.Text = "Tipo de Area"
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 52)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 1
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 22)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 0
        Me.LblClave.Text = "Referencia"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(233, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Max. 10 Caracteres"
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Icon = CType(resources.GetObject("BtnOk.Icon"), System.Drawing.Icon)
        Me.BtnOk.Location = New System.Drawing.Point(226, 224)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 6
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar los cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(131, 224)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar la ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmArea
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(321, 266)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArea"
        Me.Text = "Area"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Forma As String = ""
    Public AREClave As String
    Public Referencia As String
    Public Nombre As String
    Public Tipo As Integer
    Public Color As Integer
    Public Estado As Integer
    Public ALMClave As String

    Public Padre As String

    Public sCpyNombre As String
    Public iCpyTipo As Integer
    Public iCpyColor As Integer
    Public iCpyEstado As Integer


    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Private Sub FrmArea_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPos.Areas.Dispose()
        ModPos.Areas = Nothing
    End Sub

    Private Sub BtnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnColor.Click
        Me.ColorDialog1.Color = Me.PnlColor.BackColor
        Me.ColorDialog1.ShowDialog()
        Me.PnlColor.BackColor = Me.ColorDialog1.Color
    End Sub

    Private Sub FrmArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        Dim Cnx As String

        Cnx = ModPos.BDConexion
        If Me.Padre = "Agregar" Then
            With CmbTipoArea
                .Conexion = Cnx
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = "Area"
                .NombreParametro2 = "campo"
                .Parametro2 = "Tipo"
                .llenar()
            End With


            With cmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almacen"
                .NombreParametro1 = "USRClave"
                .Parametro1 = ModPOS.UsuarioActual
                .NombreParametro2 = "COMClave"
                .Parametro2 = ModPOS.CompanyActual
                .llenar()
            End With


            With cmbTipoEstado
                .Conexion = Cnx
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = "Area"
                .NombreParametro2 = "campo"
                .Parametro2 = "Estado"
                .llenar()
            End With
        End If

        cmbAlmacen.SelectedValue = ALMClave
     
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

        If Me.CmbTipoArea.Text = "" OrElse CmbTipoArea.FindString(CmbTipoArea.Text) = -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        Dim iColor As Integer
        iColor = Me.PnlColor.BackColor.ToArgb
        If iColor = -1 Then
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

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Area", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If validaForm() Then
            Select Case ModPos.Areas.Padre
                Case "Agregar"
                    AREClave = ModPOS.obtenerLlave
                    Me.Referencia = UCase(Trim(Me.TxtClave.Text))
                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Tipo = Me.CmbTipoArea.SelectedValue
                    Me.Color = Me.PnlColor.BackColor.ToArgb
                    Me.Estado = 1
                    ALMClave = cmbAlmacen.SelectedValue

                    ModPOS.Graba_Area(ModPOS.Areas)
                    If Not ModPOS.MtoArea Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoArea.GridAreas, "sp_muestra_areas", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoArea.GridAreas.RootTable.Columns("Color").Visible = False
                        ModPOS.MtoArea.GridAreas.RootTable.Columns("ID").Visible = False
                    Else
                        If Forma = "Estructura" Then
                            With ModPOS.Estructuras
                                With .CmbArea
                                    .Conexion = ModPOS.BDConexion
                                    .ProcedimientoAlmacenado = "sp_filtra_areas"
                                    .NombreParametro1 = "ALMClave"
                                    .Parametro1 = ModPOS.Almacen_Activo
                                    .llenar()
                                End With
                            End With
                        End If
                    End If
                    Me.Close()

                Case "Modificar"
                    Me.Referencia = UCase(Trim(Me.TxtClave.Text))
                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Tipo = Me.CmbTipoArea.SelectedValue
                    Me.Color = Me.PnlColor.BackColor.ToArgb
                    Me.Estado = Me.cmbTipoEstado.SelectedValue

                    If Not (Me.Nombre = Me.sCpyNombre AndAlso _
                    Me.Tipo = Me.iCpyTipo AndAlso _
                    Me.Estado = Me.iCpyEstado AndAlso _
                    ALMClave = cmbAlmacen.SelectedValue AndAlso _
                    Me.Color = Me.iCpyColor) Then

                        If Me.Color <> Me.iCpyColor Then
                            ModPOS.Update_Area(ModPOS.Areas, True)

                            If ModPOS.numEst_Vector > 0 Then
                                Dim i As Integer = 0
                                While i < ModPOS.vector.Length
                                    If ModPOS.vector(i).AREClave = Me.AREClave Then
                                        ModPOS.vector(i).Color = Me.Color
                                        ModPOS.vector(i).BackColor = System.Drawing.Color.FromArgb(Me.Color)
                                    End If
                                    i += 1
                                End While
                                ModPOS.Superficie.Refresh()
                            End If

                        Else
                            ModPOS.Update_Area(ModPOS.Areas, False)
                        End If

                        ModPOS.ActualizaGrid(True, ModPOS.MtoArea.GridAreas, "sp_muestra_areas", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoArea.GridAreas.RootTable.Columns("Color").Visible = False
                        ModPOS.MtoArea.GridAreas.RootTable.Columns("ID").Visible = False

                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub



   
End Class
