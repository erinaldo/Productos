Public Class FrmEditAbono
    Inherits System.Windows.Forms.Form

    Public ABNClave As String
    Private clave As String
    Private CAJClave As String
    Private Banco As String
    Private Terminal, Moneda, Referencia, Cuenta, METClave As String
    Private MetodoPago As Integer
    Private FechaPago As DateTime
    Private ValidaCtaPago As Integer = 1
    Private sClaveSAT As String

    Private alerta(4) As PictureBox
    Private reloj As parpadea


    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cmbFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBeneficiaria As System.Windows.Forms.Label
    Friend WithEvents cmbBeneficiaria As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblNumCta As System.Windows.Forms.Label
    Friend WithEvents TxtNumCta As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox

    Private bError As Boolean = False

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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents CmbBanco As Selling.StoreCombo
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents cmbTerminal As Selling.StoreCombo
    Friend WithEvents LblAbono As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditAbono))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblNumCta = New System.Windows.Forms.Label()
        Me.TxtNumCta = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.lblBeneficiaria = New System.Windows.Forms.Label()
        Me.cmbBeneficiaria = New Selling.StoreCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cmbFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblAbono = New System.Windows.Forms.Label()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.cmbTerminal = New Selling.StoreCombo()
        Me.LblBanco = New System.Windows.Forms.Label()
        Me.CmbBanco = New Selling.StoreCombo()
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
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
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.lblNumCta)
        Me.GrpGeneral.Controls.Add(Me.TxtNumCta)
        Me.GrpGeneral.Controls.Add(Me.LblReferencia)
        Me.GrpGeneral.Controls.Add(Me.TxtReferencia)
        Me.GrpGeneral.Controls.Add(Me.lblBeneficiaria)
        Me.GrpGeneral.Controls.Add(Me.cmbBeneficiaria)
        Me.GrpGeneral.Controls.Add(Me.lblFecha)
        Me.GrpGeneral.Controls.Add(Me.cmbFechaPago)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.LblAbono)
        Me.GrpGeneral.Controls.Add(Me.lblTerminal)
        Me.GrpGeneral.Controls.Add(Me.cmbTerminal)
        Me.GrpGeneral.Controls.Add(Me.LblBanco)
        Me.GrpGeneral.Controls.Add(Me.CmbBanco)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 13)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(468, 215)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(93, 183)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox5.TabIndex = 115
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(238, 118)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox4.TabIndex = 114
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(52, 121)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox3.TabIndex = 113
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'lblNumCta
        '
        Me.lblNumCta.AutoSize = True
        Me.lblNumCta.Location = New System.Drawing.Point(207, 121)
        Me.lblNumCta.Name = "lblNumCta"
        Me.lblNumCta.Size = New System.Drawing.Size(54, 13)
        Me.lblNumCta.TabIndex = 112
        Me.lblNumCta.Text = "Núm. Cta."
        '
        'TxtNumCta
        '
        Me.TxtNumCta.Location = New System.Drawing.Point(267, 118)
        Me.TxtNumCta.Name = "TxtNumCta"
        Me.TxtNumCta.Size = New System.Drawing.Size(181, 20)
        Me.TxtNumCta.TabIndex = 111
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(6, 121)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(59, 13)
        Me.LblReferencia.TabIndex = 110
        Me.LblReferencia.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(84, 118)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(117, 20)
        Me.TxtReferencia.TabIndex = 109
        '
        'lblBeneficiaria
        '
        Me.lblBeneficiaria.Location = New System.Drawing.Point(6, 186)
        Me.lblBeneficiaria.Name = "lblBeneficiaria"
        Me.lblBeneficiaria.Size = New System.Drawing.Size(110, 23)
        Me.lblBeneficiaria.TabIndex = 108
        Me.lblBeneficiaria.Text = "Cta. Beneficiaria"
        '
        'cmbBeneficiaria
        '
        Me.cmbBeneficiaria.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBeneficiaria.Location = New System.Drawing.Point(135, 183)
        Me.cmbBeneficiaria.Name = "cmbBeneficiaria"
        Me.cmbBeneficiaria.Size = New System.Drawing.Size(313, 21)
        Me.cmbBeneficiaria.TabIndex = 107
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(6, 156)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(69, 17)
        Me.lblFecha.TabIndex = 106
        Me.lblFecha.Text = "F. Pago"
        '
        'cmbFechaPago
        '
        Me.cmbFechaPago.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        Me.cmbFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmbFechaPago.Location = New System.Drawing.Point(135, 153)
        Me.cmbFechaPago.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaPago.Name = "cmbFechaPago"
        Me.cmbFechaPago.Size = New System.Drawing.Size(165, 20)
        Me.cmbFechaPago.TabIndex = 105
        Me.cmbFechaPago.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(349, 65)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox2.TabIndex = 89
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(61, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 88
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'LblAbono
        '
        Me.LblAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAbono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblAbono.Location = New System.Drawing.Point(19, 30)
        Me.LblAbono.Name = "LblAbono"
        Me.LblAbono.Size = New System.Drawing.Size(401, 15)
        Me.LblAbono.TabIndex = 87
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Location = New System.Drawing.Point(264, 65)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(50, 13)
        Me.lblTerminal.TabIndex = 86
        Me.lblTerminal.Text = "Terminal "
        '
        'cmbTerminal
        '
        Me.cmbTerminal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTerminal.Location = New System.Drawing.Point(267, 90)
        Me.cmbTerminal.Name = "cmbTerminal"
        Me.cmbTerminal.Size = New System.Drawing.Size(181, 21)
        Me.cmbTerminal.TabIndex = 85
        '
        'LblBanco
        '
        Me.LblBanco.AutoSize = True
        Me.LblBanco.Location = New System.Drawing.Point(6, 64)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(38, 13)
        Me.LblBanco.TabIndex = 82
        Me.LblBanco.Text = "Banco"
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Location = New System.Drawing.Point(9, 90)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(194, 21)
        Me.CmbBanco.TabIndex = 81
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(390, 234)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Ejecutar"
        Me.BtnActualizar.ToolTipText = "Ejecuta procedimiento seleccionado"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(294, 234)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmEditAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(487, 281)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditAbono"
        Me.Text = "Modifica Abono"
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

    Private Sub ActMetodoPago(ByVal metodo As Integer)

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "MetodoPago", "@Valor", metodo)
        sClaveSAT = IIf(dt.Rows(0)("ClaveSAT").GetType.Name = "DBNull", "", dt.Rows(0)("ClaveSAT"))
        dt.Dispose()

        Select Case sClaveSAT

            Case "04", "28"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "Referencia"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

                lblNumCta.Visible = True
                TxtNumCta.Visible = True

                lblTerminal.Visible = True
                cmbTerminal.Visible = True
                cmbTerminal.SelectedValue = 0


                lblFecha.Visible = False
                cmbFechaPago.Visible = False

                lblBeneficiaria.Visible = False
                cmbBeneficiaria.Visible = False

            Case "02"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "No. Cheque"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

                lblNumCta.Visible = True
                TxtNumCta.Visible = True

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0

                lblFecha.Visible = True
                cmbFechaPago.Visible = True
               
                lblBeneficiaria.Visible = True
                cmbBeneficiaria.Visible = True


            Case "29", "06", "05", "03"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "Referencia"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

                lblNumCta.Visible = True
                TxtNumCta.Visible = True

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0

                lblFecha.Visible = True
                cmbFechaPago.Visible = True
               
                lblBeneficiaria.Visible = True
                cmbBeneficiaria.Visible = True

            Case Else

                LblBanco.Visible = False
                CmbBanco.Visible = False

                LblReferencia.Visible = False
                TxtReferencia.Visible = False
                TxtReferencia.Text = ""

                lblNumCta.Visible = False
                TxtNumCta.Text = ""
                TxtNumCta.Visible = False

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0

                lblFecha.Visible = False
                cmbFechaPago.Visible = False

                lblBeneficiaria.Visible = False
                cmbBeneficiaria.Visible = False

        End Select






    End Sub


    Private Sub FrmEditAbono_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        Select Case sClaveSAT
            Case "04", "28"

                'Valida Terminal
                If ValidaCtaPago = 1 AndAlso cmbTerminal.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                'Valida Banco
                If ValidaCtaPago = 1 AndAlso CmbBanco.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(0))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                'Valida Referencia

                If ValidaCtaPago = 1 AndAlso TxtReferencia.Text = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La referencia requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 4 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La referencia debe contener al menos 4 carates o digitos. Por ejemplo los ultimos 4 digitos de la tarjea o de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                'Valida Num Cta
                If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength < 4 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(3))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("El número de cuenta debe contener minimo los ultimos 4 digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            Case "02"

                If ValidaCtaPago = 1 AndAlso CmbBanco.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(0))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                'Valida Referencia
                If ValidaCtaPago = 1 AndAlso TxtReferencia.Text = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("El número de cheque es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 4 Then
                    Dim s As String
                    s = "000" & TxtReferencia.Text

                    TxtReferencia.Text = s.Substring(s.Length - 4, 4)
                End If

                'Valida Num Cta
                If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength < 4 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(3))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("El número de cuenta debe contener minimo los 4 ultimos digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                'Valida Beneficiaria
                If cmbBeneficiaria.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(4))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La Cta Beneficiaria es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Case "29", "06", "05", "03"
                If ValidaCtaPago = 1 AndAlso CmbBanco.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(0))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                'Valida Referencia
                If ValidaCtaPago = 1 AndAlso TxtReferencia.Text = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La referencia es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 6 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La referencia debe contener  al menos 6 carates o digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength >= 6 AndAlso TxtReferencia.TextLength < 8 Then
                    Dim s As String
                    s = "000" & TxtReferencia.Text
                    TxtReferencia.Text = s.Substring(s.Length - 8, 8)
                End If

                'Valida Num Cta
                If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength < 4 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(3))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("El número de cuenta debe contener minimo los ultimos 4 digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


                'Valida Beneficiaria
                If cmbBeneficiaria.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(4))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La Cta Beneficiaria es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

           
        End Select

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


    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If validaForm() Then

            If Not cmbTerminal.SelectedValue Is Nothing Then
                Terminal = cmbTerminal.SelectedValue
            Else
                Terminal = ""
            End If


            Select Case sClaveSAT
                Case "04", "28", "02", "29", "06", "05", "03"
                    METClave = cmbBeneficiaria.SelectedValue
                    FechaPago = cmbFechaPago.Value
                Case Else
                    cmbFechaPago.Value = Today
                    METClave = ""
            End Select

           
            Banco = CmbBanco.SelectedValue
            Referencia = TxtReferencia.Text.ToUpper.Trim
            Cuenta = TxtNumCta.Text.ToUpper.Trim



            Dim dt As DataTable
            Dim estado As Integer = 2
            dt = Recupera_Tabla("st_sello_pago", "@ABNClave", ABNClave)

            If dt.Rows.Count > 0 Then
                estado = IIf(dt.Rows(0)("estado").GetType.Name <> "DBNull", dt.Rows(0)("estado"), 2)

            End If
            dt.Dispose()

            If estado = 2 Then
                ModPOS.Ejecuta("st_actualiza_abono", _
                               "@ABNClave", ABNClave, _
                               "@BNKClave", Banco, _
                               "@TERClave", Terminal, _
                               "@Referencia", Referencia, _
                               "@NumCta", Cuenta, _
                               "@fechaPago", FechaPago,
                               "@METClave", METClave)
            Else
                Beep()
                MessageBox.Show("¡El documento actual no puede ser modificado debido a que se encuentra asociado a un complemento de pago o se encuentra cancelado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            bError = False
            Me.Close()
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub FrmEditAbono_Load(sender As Object, e As EventArgs) Handles Me.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        Dim dt As DataTable
        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "ValidaCtaPago"
                        ValidaCtaPago = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()


        dt = Recupera_Tabla("st_recupera_abono", "@ABNClave", ABNClave)
        clave = IIf(dt.Rows(0)("Clave").GetType.Name <> "DBNull", dt.Rows(0)("Clave"), "")
        MetodoPago = dt.Rows(0)("TipoPago")
        CAJClave = dt.Rows(0)("CAJClave")
        Banco = IIf(dt.Rows(0)("BNKClave").GetType.Name <> "DBNull", dt.Rows(0)("BNKClave"), "")
        Terminal = IIf(dt.Rows(0)("TERClave").GetType.Name <> "DBNull", dt.Rows(0)("TERClave"), "")
        Moneda = IIf(dt.Rows(0)("Moneda").GetType.Name <> "DBNull", dt.Rows(0)("Moneda"), Moneda)
        Referencia = IIf(dt.Rows(0)("Referencia").GetType.Name <> "DBNull", dt.Rows(0)("Referencia"), "")
        Cuenta = IIf(dt.Rows(0)("numCta").GetType.Name <> "DBNull", dt.Rows(0)("numCta"), "")
        FechaPago = IIf(dt.Rows(0)("fechaPago").GetType.Name <> "DBNull", dt.Rows(0)("fechaPago"), dt.Rows(0)("MFechaHora"))
        METClave = IIf(dt.Rows(0)("METClave").GetType.Name <> "DBNull", dt.Rows(0)("METClave"), "")

        dt.Dispose()

        LblAbono.Text = "Folio: " & clave

        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With
        CmbBanco.SelectedValue = Banco

        With cmbTerminal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_terminal"
            .NombreParametro1 = "CAJClave"
            .Parametro1 = CAJClave
            .llenar()
        End With
        cmbTerminal.SelectedValue = Terminal
      
        TxtReferencia.Text = Referencia
        TxtNumCta.Text = Cuenta
        cmbFechaPago.Value = FechaPago


        With cmbBeneficiaria
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_beneficiario"
            .NombreParametro1 = "CAJClave"
            .Parametro1 = CAJClave
            .NombreParametro2 = "MONClave"
            .Parametro2 = Moneda
            .llenar()
        End With

        cmbBeneficiaria.SelectedValue = METClave


        ActMetodoPago(MetodoPago)


    End Sub

End Class
