Public Class FrmEditPago
    Inherits System.Windows.Forms.Form

    Public PAGClave As String
    Public monto As Decimal = 0

    Public sMetodoPago, sBanco, Referencia As String
    Public FechaPago As DateTime


    Private clave As String
    Private Banco As String
    Private sClaveSAT, Moneda As String
    Private MetodoPago As Integer
   
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private formaLoad As Boolean = False

    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cmbFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMetodoPago As Selling.StoreCombo

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
    Friend WithEvents LblAbono As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditPago))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMetodoPago = New Selling.StoreCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cmbFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblAbono = New System.Windows.Forms.Label()
        Me.LblBanco = New System.Windows.Forms.Label()
        Me.CmbBanco = New Selling.StoreCombo()
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.cmbMetodoPago)
        Me.GrpGeneral.Controls.Add(Me.lblFecha)
        Me.GrpGeneral.Controls.Add(Me.cmbFechaPago)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.LblReferencia)
        Me.GrpGeneral.Controls.Add(Me.TxtReferencia)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.LblAbono)
        Me.GrpGeneral.Controls.Add(Me.LblBanco)
        Me.GrpGeneral.Controls.Add(Me.CmbBanco)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 13)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(468, 166)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(26, 64)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox2.TabIndex = 118
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Metodo P."
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMetodoPago.Location = New System.Drawing.Point(67, 64)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(206, 21)
        Me.cmbMetodoPago.TabIndex = 116
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(11, 132)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 17)
        Me.lblFecha.TabIndex = 115
        Me.lblFecha.Text = "F. Pago"
        '
        'cmbFechaPago
        '
        Me.cmbFechaPago.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        Me.cmbFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmbFechaPago.Location = New System.Drawing.Point(67, 131)
        Me.cmbFechaPago.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaPago.Name = "cmbFechaPago"
        Me.cmbFechaPago.Size = New System.Drawing.Size(182, 20)
        Me.cmbFechaPago.TabIndex = 114
        Me.cmbFechaPago.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(295, 100)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox3.TabIndex = 113
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(279, 105)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(59, 13)
        Me.LblReferencia.TabIndex = 110
        Me.LblReferencia.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(345, 102)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(117, 20)
        Me.TxtReferencia.TabIndex = 109
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(26, 102)
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
        'LblBanco
        '
        Me.LblBanco.AutoSize = True
        Me.LblBanco.Location = New System.Drawing.Point(11, 105)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(38, 13)
        Me.LblBanco.TabIndex = 82
        Me.LblBanco.Text = "Banco"
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Location = New System.Drawing.Point(67, 101)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(206, 21)
        Me.CmbBanco.TabIndex = 81
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(390, 185)
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
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(294, 185)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmEditPago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(487, 232)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditPago"
        Me.Text = "Modifica Pago"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ActMetodoPago(ByVal metodo As Integer)

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "MetodoPago", "@Valor", metodo)
        sClaveSAT = CStr(IIf(dt.Rows(0)("ClaveSAT").GetType.Name = "DBNull", "", dt.Rows(0)("ClaveSAT")))
        dt.Dispose()

        Select Case sClaveSAT

            Case "04", "28"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "Referencia"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

            Case "02"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "No. Cheque"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

            Case "29", "06", "05", "03"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "Referencia"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

            Case Else

                LblBanco.Visible = False
                CmbBanco.Visible = False

                LblReferencia.Visible = False
                TxtReferencia.Visible = False
                TxtReferencia.Text = ""

        End Select






    End Sub

    Private Sub FrmEditAbono_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If cmbMetodoPago.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
        End If

        Select Case sClaveSAT
            Case "04", "28"

                If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 4 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("La referencia debe contener al menos 4 carates o digitos. Por ejemplo los ultimos 4 digitos de la tarjea o de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Case "02"

                If CmbBanco.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                'Valida Referencia
                If TxtReferencia.Text = "" Then
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

          

            Case "29", "06", "05", "03"
                If CmbBanco.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                'Valida Referencia
                If TxtReferencia.Text = "" Then
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
            MetodoPago = CInt(cmbMetodoPago.SelectedValue)
            sMetodoPago = CStr(cmbMetodoPago.SelectedItem(1))
            FechaPago = cmbFechaPago.Value

            If CmbBanco.Visible = True Then
                sBanco = CStr(CmbBanco.SelectedItem(1))
                Banco = CStr(CmbBanco.SelectedValue)
                Referencia = TxtReferencia.Text.ToUpper.Trim
            Else
                sBanco = ""
                Banco = ""
                Referencia = ""
            End If
            ModPOS.Ejecuta("st_actualiza_pago", _
                               "@PAGClave", PAGClave, _
                               "@TipoPago", MetodoPago, _
                               "@fechaPago", FechaPago,
                               "@BNKClave", Banco, _
                               "@Referencia", Referencia, _
                               "@Usuario", ModPOS.UsuarioActual)

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

    Private Sub FrmEditPago_Load(sender As Object, e As EventArgs) Handles Me.Load

        alerta(0) = Me.PictureBox2
        alerta(1) = Me.PictureBox1
        alerta(2) = Me.PictureBox3

        Dim dt As DataTable
        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = CStr(IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor")))
                End Select
            Next
        End With
        dt.Dispose()

        dt = Recupera_Tabla("st_recupera_pago", "@PAGClave", PAGClave)
        clave = IIf(dt.Rows(0)("Clave").GetType.Name <> "DBNull", dt.Rows(0)("Clave"), "")
        MetodoPago = dt.Rows(0)("TipoPago")
        Banco = IIf(dt.Rows(0)("BNKClave").GetType.Name <> "DBNull", dt.Rows(0)("BNKClave"), "")
        Moneda = IIf(dt.Rows(0)("Moneda").GetType.Name <> "DBNull", dt.Rows(0)("Moneda"), Moneda)
        Referencia = IIf(dt.Rows(0)("Referencia").GetType.Name <> "DBNull", dt.Rows(0)("Referencia"), "")
        FechaPago = IIf(dt.Rows(0)("fechaPago").GetType.Name <> "DBNull", dt.Rows(0)("fechaPago"), dt.Rows(0)("MFechaHora"))
        dt.Dispose()

        LblAbono.Text = "Folio: " & clave


        With cmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With
        cmbMetodoPago.SelectedValue = MetodoPago

        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With
        CmbBanco.SelectedValue = Banco
        TxtReferencia.Text = Referencia
        cmbFechaPago.Value = FechaPago

        formaLoad = True

        ActMetodoPago(MetodoPago)

    End Sub

    Private Sub cmbMetodoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMetodoPago.SelectedIndexChanged
        If formaLoad = True Then
            If Not cmbMetodoPago.SelectedValue Is Nothing Then
                ActMetodoPago(CInt(cmbMetodoPago.SelectedValue))
            End If
        End If
    End Sub
End Class
