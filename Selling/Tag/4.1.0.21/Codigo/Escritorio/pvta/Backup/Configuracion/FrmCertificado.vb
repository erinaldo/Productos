Imports System.IO

Public Class FrmCertificado
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
    Friend WithEvents GrpFolio As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BtnLlave As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtLlave As System.Windows.Forms.TextBox
    Friend WithEvents BtnCertificado As Janus.Windows.EditControls.UIButton
    Friend WithEvents dFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtUrlCertificado As System.Windows.Forms.TextBox
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSerie As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCertificado))
        Me.GrpFolio = New System.Windows.Forms.GroupBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtUrlCertificado = New System.Windows.Forms.TextBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtContraseña = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dFin = New System.Windows.Forms.DateTimePicker
        Me.dInicio = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.BtnLlave = New Janus.Windows.EditControls.UIButton
        Me.TxtLlave = New System.Windows.Forms.TextBox
        Me.BtnCertificado = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSerie = New System.Windows.Forms.TextBox
        Me.LblSerie = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpFolio.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpFolio
        '
        Me.GrpFolio.Controls.Add(Me.TxtCompany)
        Me.GrpFolio.Controls.Add(Me.Label1)
        Me.GrpFolio.Controls.Add(Me.TxtUrlCertificado)
        Me.GrpFolio.Controls.Add(Me.PictureBox7)
        Me.GrpFolio.Controls.Add(Me.PictureBox6)
        Me.GrpFolio.Controls.Add(Me.PictureBox3)
        Me.GrpFolio.Controls.Add(Me.PictureBox2)
        Me.GrpFolio.Controls.Add(Me.PictureBox1)
        Me.GrpFolio.Controls.Add(Me.TxtContraseña)
        Me.GrpFolio.Controls.Add(Me.Label16)
        Me.GrpFolio.Controls.Add(Me.dFin)
        Me.GrpFolio.Controls.Add(Me.dInicio)
        Me.GrpFolio.Controls.Add(Me.Label13)
        Me.GrpFolio.Controls.Add(Me.BtnLlave)
        Me.GrpFolio.Controls.Add(Me.TxtLlave)
        Me.GrpFolio.Controls.Add(Me.BtnCertificado)
        Me.GrpFolio.Controls.Add(Me.Label3)
        Me.GrpFolio.Controls.Add(Me.Label2)
        Me.GrpFolio.Controls.Add(Me.TxtSerie)
        Me.GrpFolio.Controls.Add(Me.LblSerie)
        Me.GrpFolio.Location = New System.Drawing.Point(7, 7)
        Me.GrpFolio.Name = "GrpFolio"
        Me.GrpFolio.Size = New System.Drawing.Size(575, 216)
        Me.GrpFolio.TabIndex = 1
        Me.GrpFolio.TabStop = False
        Me.GrpFolio.Text = "Certificado"
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(123, 17)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(314, 20)
        Me.TxtCompany.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Compañia"
        '
        'TxtUrlCertificado
        '
        Me.TxtUrlCertificado.Location = New System.Drawing.Point(123, 73)
        Me.TxtUrlCertificado.Name = "TxtUrlCertificado"
        Me.TxtUrlCertificado.ReadOnly = True
        Me.TxtUrlCertificado.Size = New System.Drawing.Size(404, 20)
        Me.TxtUrlCertificado.TabIndex = 94
        Me.TxtUrlCertificado.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(105, 184)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox7.TabIndex = 93
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(105, 163)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 74
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(105, 135)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox3.TabIndex = 71
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(105, 105)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(105, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 92
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtContraseña
        '
        Me.TxtContraseña.Location = New System.Drawing.Point(123, 183)
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtContraseña.Size = New System.Drawing.Size(212, 20)
        Me.TxtContraseña.TabIndex = 90
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(5, 186)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 15)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Contraseña"
        '
        'dFin
        '
        Me.dFin.Enabled = False
        Me.dFin.Location = New System.Drawing.Point(123, 127)
        Me.dFin.Name = "dFin"
        Me.dFin.Size = New System.Drawing.Size(167, 20)
        Me.dFin.TabIndex = 89
        '
        'dInicio
        '
        Me.dInicio.Enabled = False
        Me.dInicio.Location = New System.Drawing.Point(123, 103)
        Me.dInicio.Name = "dInicio"
        Me.dInicio.Size = New System.Drawing.Size(167, 20)
        Me.dInicio.TabIndex = 88
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(4, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 15)
        Me.Label13.TabIndex = 86
        Me.Label13.Text = "Llave Privada (*.key)"
        '
        'BtnLlave
        '
        Me.BtnLlave.Image = CType(resources.GetObject("BtnLlave.Image"), System.Drawing.Image)
        Me.BtnLlave.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnLlave.Location = New System.Drawing.Point(535, 148)
        Me.BtnLlave.Name = "BtnLlave"
        Me.BtnLlave.Size = New System.Drawing.Size(33, 29)
        Me.BtnLlave.TabIndex = 85
        '
        'TxtLlave
        '
        Me.TxtLlave.Location = New System.Drawing.Point(123, 155)
        Me.TxtLlave.Name = "TxtLlave"
        Me.TxtLlave.ReadOnly = True
        Me.TxtLlave.Size = New System.Drawing.Size(404, 20)
        Me.TxtLlave.TabIndex = 84
        Me.TxtLlave.TabStop = False
        '
        'BtnCertificado
        '
        Me.BtnCertificado.Icon = CType(resources.GetObject("BtnCertificado.Icon"), System.Drawing.Icon)
        Me.BtnCertificado.ImageSize = New System.Drawing.Size(24, 24)
        Me.BtnCertificado.Location = New System.Drawing.Point(295, 40)
        Me.BtnCertificado.Name = "BtnCertificado"
        Me.BtnCertificado.Size = New System.Drawing.Size(33, 30)
        Me.BtnCertificado.TabIndex = 83
        Me.BtnCertificado.ToolTipText = "Buscar y recuperar información del certificado "
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 15)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Fin de Vigencia"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Inicio Vigencia"
        '
        'TxtSerie
        '
        Me.TxtSerie.Enabled = False
        Me.TxtSerie.Location = New System.Drawing.Point(123, 49)
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(167, 20)
        Me.TxtSerie.TabIndex = 1
        '
        'LblSerie
        '
        Me.LblSerie.Location = New System.Drawing.Point(5, 53)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(113, 15)
        Me.LblSerie.TabIndex = 24
        Me.LblSerie.Text = "Serie del Certificado"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(397, 230)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(493, 230)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCertificado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(589, 273)
        Me.Controls.Add(Me.GrpFolio)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(440, 268)
        Me.Name = "FrmCertificado"
        Me.Text = "Certificado"
        Me.GrpFolio.ResumeLayout(False)
        Me.GrpFolio.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public CERClave As String
    Public Certificado64 As String = ""
    Public Cer64 As String
    Public Serie As String
    Public Inicial As Date = Today.Date
    Public Final As Date = Today.Date
    Public LLave As String
    Public Password As String
    Public urlCertificado As String = ""

    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Private dInicioVigencia, dFinVigencia As Date

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtSerie.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Certificado", "@clave", Me.TxtSerie.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("El Certificado que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(1))
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

    Private Sub FrmFolio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TxtCompany.Text = ModPOS.CompanyName

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox6
        alerta(4) = Me.PictureBox7


        TxtSerie.Text = Serie
        dInicio.Value = Inicial
        dFin.Value = Final
        TxtLlave.Text = LLave
        TxtContraseña.Text = Password
        Cer64 = Certificado64
        TxtUrlCertificado.Text = urlCertificado



    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    CERClave = ModPOS.obtenerLlave
                    Serie = TxtSerie.Text
                    Inicial = dInicio.Value
                    Final = dFin.Value
                    LLave = TxtLlave.Text
                    Password = TxtContraseña.Text
                    Certificado64 = Cer64
                    urlCertificado = TxtUrlCertificado.Text


                    ModPOS.Ejecuta("sp_inserta_certificado", _
                                    "@CERClave", CERClave, _
                                    "@Serie", Serie, _
                                    "@Certificado", Certificado64, _
                                    "@Inicial", Inicial, _
                                    "@Final", Final, _
                                    "@Llave", LLave, _
                                    "@urlCertificado", urlCertificado, _
                                    "@Password", Password, _
                                    "@Usuario", ModPOS.UsuarioActual, _
                                    "@COMClave", ModPOS.CompanyActual)

                    If Not ModPOS.MtoCertificado Is Nothing Then
                        ModPOS.ActualizaGrid(False, ModPOS.MtoCertificado.GridCertificados, "sp_muestra_certificados", "@COMClave", ModPOS.CompanyActual)
                        MtoCertificado.GridCertificados.RootTable.Columns("CERClave").Visible = False
                    End If

                    TxtSerie.Text = ""
                    TxtLlave.Text = ""
                    TxtContraseña.Text = ""
                    Cer64 = ""
                    TxtUrlCertificado.Text = ""

                Case "Modificar"
                    If Not (Serie = TxtSerie.Text AndAlso _
                        Inicial = dInicio.Value AndAlso _
                        Final = dFin.Value AndAlso _
                        LLave = TxtLlave.Text AndAlso _
                        Certificado64 = Cer64 AndAlso _
                         urlCertificado = TxtUrlCertificado.Text AndAlso _
                        Password = TxtContraseña.Text) Then


                        Serie = TxtSerie.Text
                        Inicial = dInicio.Value
                        Final = dFin.Value
                        LLave = TxtLlave.Text
                        Password = TxtContraseña.Text
                        Certificado64 = Cer64
                        urlCertificado = TxtUrlCertificado.Text

                        ModPOS.Ejecuta("sp_actualiza_certificado", _
                                                "@CERClave", CERClave, _
                                                "@Serie", Serie, _
                                                "@Certificado", Certificado64, _
                                                "@Inicial", Inicial, _
                                                "@Final", Final, _
                                                "@Llave", LLave, _
                                                "@urlCertificado", urlCertificado, _
                                                "@Password", Password, _
                                                "@Usuario", ModPOS.UsuarioActual, _
                                                "@COMClave", ModPOS.CompanyActual)

                        If Not ModPOS.MtoCertificado Is Nothing Then
                            ModPOS.ActualizaGrid(False, ModPOS.MtoCertificado.GridCertificados, "sp_muestra_certificados", "@COMClave", ModPOS.CompanyActual)
                            MtoCertificado.GridCertificados.RootTable.Columns("CERClave").Visible = False
                        End If
                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmCertificado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Certificado.Dispose()
        ModPOS.Certificado = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnLlave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLlave.Click
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Llave (*.key)|*.key"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de Llave Privada"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                TxtLlave.Text = openDlg.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function GMTtoDate(ByVal s_GMT As String) As String
        Dim año, mes, dia, min As String
        min = Mid(s_GMT, 8, 8)
        año = Mid(s_GMT, 17, 4)
        dia = Mid(s_GMT, 5, 2)
        mes = Mid(s_GMT, 1, 3)
        Select Case mes
            Case "Jan"
                mes = "01"
            Case "Feb"
                mes = "02"
            Case "Mar"
                mes = "03"
            Case "Apr"
                mes = "04"
            Case "May"
                mes = "05"
            Case "Jun"
                mes = "06"
            Case "Jul"
                mes = "07"
            Case "Aug"
                mes = "08"
            Case "Sep"
                mes = "09"
            Case "Oct"
                mes = "10"
            Case "Nov"
                mes = "11"
            Case "Dec"
                mes = "12"
        End Select
        Return dia & "/" & mes & "/" & año
    End Function


    Private Function findSerie(ByVal filepath As String, ByVal busqueda As String) As String
        Dim fName As String = filepath
        Dim testTxt As New StreamReader(fName)
        Dim allRead As String = testTxt.ReadToEnd()
        testTxt.Close()
        Dim regMatch As String = busqueda

        Dim serie As String = ""
        Dim numSerie As String = ""

        serie = Mid(allRead, allRead.IndexOf(regMatch) + 28, 62)


        Dim i As Integer
        Dim flag As Boolean = True
        For i = 0 To serie.Length - 1
            Select Case serie(i)
                Case Is = "3"
                    If flag Then
                        numSerie = numSerie & serie(i + 1)
                        flag = False
                    End If
                Case Is = ":"
                    flag = True
            End Select
        Next

        Return numSerie

    End Function

    Public Sub findtext(ByVal filepath As String, ByVal busqueda As String, ByVal busqueda2 As String)
        Dim fName As String = filepath
        Dim testTxt As New StreamReader(fName)
        Dim allRead As String = testTxt.ReadToEnd()
        testTxt.Close()
        Dim regMatch As String = busqueda

        Dim fecha, fecha2 As String

        fecha = Mid(allRead, allRead.IndexOf(regMatch) + 13, 25)

        fecha2 = Mid(allRead, allRead.IndexOf(busqueda2) + 13, 25)



        dInicio.Value = CDate(GMTtoDate(fecha))
        dFin.Value = CDate(GMTtoDate(fecha2))

    End Sub

    Private Sub BtnCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCertificado.Click
        Try
            Dim frmStatusMessage As New frmStatus

            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Certificado (*.cer)|*.cer"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de Certificado"
            If (openDlg.ShowDialog() = DialogResult.OK) Then

                TxtUrlCertificado.Text = openDlg.FileName

                Try
                    If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                        System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
                    End If
                Catch ex As Exception
                End Try

                Dim DirCertificado As String = "C:\SelladoDigital\" & Path.GetFileName(openDlg.FileName)


                'Dim DirCertificado As String = openDlg.FileName

                Dim sPath As String = Path.GetDirectoryName(openDlg.FileName)

                If sPath <> "C:\SelladoDigital\" Then
                    If Not System.IO.File.Exists(DirCertificado) Then
                        System.IO.File.Copy(openDlg.FileName, DirCertificado)
                    End If
                End If


                Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
                Dim dir As String = DirActual.FullName()

                dir = dir & "\Openssl\openssl.exe"


                Dim DirArchivoPEM As String = DirCertificado & ".pem"

                frmStatusMessage.Show("Leyendo Certificado...")

                Shell(dir & " x509 -inform DER -outform PEM -in " & DirCertificado & " -pubkey -out " & DirArchivoPEM, AppWinStyle.Hide, True)

                Shell(dir & " x509 -in " & DirArchivoPEM & " -issuer -text -out C:\SelladoDigital\certificado.txt", AppWinStyle.Hide, True)

                Cer64 = ModPOS.GeneraCertificadoX64(DirCertificado)

                frmStatusMessage.Dispose()

                TxtSerie.Text = findSerie("C:\SelladoDigital\certificado.txt", "Serial Number:")
                findtext("C:\SelladoDigital\certificado.txt", "Not Before:", "Not After :")


                My.Computer.FileSystem.DeleteFile("C:\SelladoDigital\certificado.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                My.Computer.FileSystem.DeleteFile(DirArchivoPEM, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                My.Computer.FileSystem.DeleteFile(DirCertificado, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
