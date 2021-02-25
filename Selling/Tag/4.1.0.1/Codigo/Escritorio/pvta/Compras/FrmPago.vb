Public Class FrmPago
    Inherits System.Windows.Forms.Form

    Private PAGClave As String
    Private SaldoPendiente As Double
    Private ImportePago As Double


    Private bError As Boolean = False
    Private Pago, TipoCambio As Double
  
    Private alerta(4) As PictureBox
    Private reloj As parpadea
    Private FormaPagoLoad As Boolean = False
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Private Moneda As String

   

    Public WriteOnly Property SaldoAcumulado() As Double
        Set(ByVal Value As Double)
            SaldoPendiente = Value
        End Set
    End Property

    Public ReadOnly Property AbonoClave() As String
        Get
            AbonoClave = PAGClave
        End Get
    End Property


    Public ReadOnly Property TPago() As Integer
        Get
            TPago = cmbMetodoPago.SelectedValue()
        End Get
    End Property

    Public ReadOnly Property TotalPago() As Double
        Get
            TotalPago = ImportePago
        End Get
    End Property


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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpAbono As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMetodoPago As Selling.StoreCombo
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents CmbBanco As Selling.StoreCombo
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPago))
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.GrpAbono = New System.Windows.Forms.GroupBox()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.cmbMetodoPago = New Selling.StoreCombo()
        Me.CmbBanco = New Selling.StoreCombo()
        Me.GrpAbono.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblNombre.Location = New System.Drawing.Point(3, 16)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(401, 22)
        Me.LblNombre.TabIndex = 57
        Me.LblNombre.Text = "CANTIDAD A PAGAR"
        '
        'GrpAbono
        '
        Me.GrpAbono.Controls.Add(Me.LblTipoCambio)
        Me.GrpAbono.Controls.Add(Me.BtnTC)
        Me.GrpAbono.Controls.Add(Me.PictureBox5)
        Me.GrpAbono.Controls.Add(Me.cmbMetodoPago)
        Me.GrpAbono.Controls.Add(Me.TxtImporte)
        Me.GrpAbono.Controls.Add(Me.Label1)
        Me.GrpAbono.Controls.Add(Me.PictureBox1)
        Me.GrpAbono.Controls.Add(Me.PictureBox2)
        Me.GrpAbono.Controls.Add(Me.TxtReferencia)
        Me.GrpAbono.Controls.Add(Me.lblBanco)
        Me.GrpAbono.Controls.Add(Me.PictureBox3)
        Me.GrpAbono.Controls.Add(Me.CmbBanco)
        Me.GrpAbono.Controls.Add(Me.PictureBox4)
        Me.GrpAbono.Controls.Add(Me.lblReferencia)
        Me.GrpAbono.Controls.Add(Me.Label3)
        Me.GrpAbono.Controls.Add(Me.Label14)
        Me.GrpAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpAbono.Location = New System.Drawing.Point(7, 49)
        Me.GrpAbono.Name = "GrpAbono"
        Me.GrpAbono.Size = New System.Drawing.Size(734, 111)
        Me.GrpAbono.TabIndex = 0
        Me.GrpAbono.TabStop = False
        Me.GrpAbono.Text = "Registro de Abono"
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.Navy
        Me.LblTipoCambio.Location = New System.Drawing.Point(6, 83)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(126, 14)
        Me.LblTipoCambio.TabIndex = 78
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(5, 49)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(67, 28)
        Me.BtnTC.TabIndex = 64
        Me.BtnTC.Text = "MXN"
        Me.BtnTC.ToolTipText = "Elejir Moneda"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxDocumentos.Size = New System.Drawing.Size(61, 4)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(644, 25)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(28, 21)
        Me.PictureBox5.TabIndex = 76
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(75, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(187, 20)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Metodo de Pago"
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(588, 52)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(134, 23)
        Me.TxtImporte.TabIndex = 3
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporte.Value = 0.0R
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(585, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Monto"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(18, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 21)
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(211, 27)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 19)
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(446, 52)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(136, 23)
        Me.TxtReferencia.TabIndex = 5
        '
        'lblBanco
        '
        Me.lblBanco.BackColor = System.Drawing.Color.Transparent
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblBanco.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBanco.Location = New System.Drawing.Point(271, 25)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(73, 20)
        Me.lblBanco.TabIndex = 69
        Me.lblBanco.Text = "Banco"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(383, 28)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox3.TabIndex = 65
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(542, 25)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 23)
        Me.PictureBox4.TabIndex = 65
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(2, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 20)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Moneda"
        '
        'lblReferencia
        '
        Me.lblReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lblReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblReferencia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblReferencia.Location = New System.Drawing.Point(443, 25)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(189, 20)
        Me.lblReferencia.TabIndex = 71
        Me.lblReferencia.Text = "Referencia"
        '
        'LblSaldo
        '
        Me.LblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(181, 6)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(352, 38)
        Me.LblSaldo.TabIndex = 63
        Me.LblSaldo.Text = "$353.45 M.N"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(651, 166)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar Cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(555, 166)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMetodoPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMetodoPago.Location = New System.Drawing.Point(78, 51)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(184, 24)
        Me.cmbMetodoPago.TabIndex = 2
        '
        'CmbBanco
        '
        Me.CmbBanco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Location = New System.Drawing.Point(273, 51)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(167, 24)
        Me.CmbBanco.TabIndex = 4
        '
        'FrmPago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(748, 218)
        Me.Controls.Add(Me.LblSaldo)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.GrpAbono)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LblNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(764, 257)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(764, 257)
        Me.Name = "FrmPago"
        Me.Text = "Pagos"
        Me.GrpAbono.ResumeLayout(False)
        Me.GrpAbono.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmPago_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        'valida que se encuentre una forma de pago seleccionada
        If cmbMetodoPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtImporte.Text = "" Then
            Pago = 0
        Else
            Pago = Math.Abs(CDbl(TxtImporte.Text))
        End If

        'valida que el importe sea diferente de cero

        If Pago = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        'valida que si la forma de pago sea diferente de contado exista un banco
        If (cmbMetodoPago.SelectedValue > 1 AndAlso cmbMetodoPago.SelectedValue <= 6) AndAlso CmbBanco.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        'Valida que si la forma de pago sea diferente de contado exista una referencia
        If (cmbMetodoPago.SelectedValue > 1 AndAlso cmbMetodoPago.SelectedValue <= 6) AndAlso TxtReferencia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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

    Private Sub FrmAbono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim dt As DataTable
        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Exit For
                End Select
            Next
        End With
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        BtnTC.Text = dt.Rows(0)("Referencia")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)
        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        'If Multiple Then
        '    bEfectivo = True
        '    bCheque = True
        '    bTarjeta = True
        'Else
        '    'Dim dt As DataTable
        '    'dt = ModPOS.Recupera_Tabla("sp_recupera_saldo", "@Tipo", TipoDoc, "@Clave", DocumentoClave)
        '    'SaldoDocumento = dt.Rows(0)("Saldo")
        '    'bEfectivo = dt.Rows(0)("Efectivo")
        '    'bCheque = dt.Rows(0)("Cheque")
        '    'bTarjeta = dt.Rows(0)("Tarjeta")
        '    'dt.Dispose()
        'End If

        With cmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With

        FormaPagoLoad = True


        If cmbMetodoPago.SelectedValue > 1 AndAlso cmbMetodoPago.SelectedValue <= 6 Then
            CmbBanco.Visible = True
            TxtReferencia.Visible = True
            lblBanco.Visible = True
            lblReferencia.Visible = True
        Else
            CmbBanco.Visible = False
            TxtReferencia.Visible = False
            lblBanco.Visible = False
            lblReferencia.Visible = False
        End If


        LblSaldo.Text = Format(CStr(ModPOS.TruncateToDecimal(SaldoPendiente, 2)), "Currency")


        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With


        TxtImporte.Focus()

    End Sub


    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            PAGClave = ModPOS.obtenerLlave

            Pago *= TipoCambio
            ImportePago = Pago

            Select Case ImportePago
                Case Is > SaldoPendiente
                    Me.DialogResult = DialogResult.Cancel
                    Beep()
                    MessageBox.Show("¡El importe del pago no debe ser mayor al total a pagar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Case Is < SaldoPendiente
                    If MessageBox.Show("¡El importe del pago es menor al total a pagar,Desea continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Me.DialogResult = DialogResult.Cancel
                        Exit Sub
                    End If
            End Select

            If cmbMetodoPago.SelectedValue = 1 Then

                ModPOS.Ejecuta("sp_inserta_pago", _
                                  "@PAGClave", PAGClave, _
                                  "@TipoPago", cmbMetodoPago.SelectedValue, _
                                  "@Moneda", Moneda, _
                                  "@TipoCambio", TipoCambio, _
                                  "@Importe", ImportePago, _
                                  "@Saldo", ImportePago, _
                                  "@BNKClave", "", _
                                  "@Referencia", "", _
                                  "@COMClave", ModPOS.CompanyActual, _
                                  "@Usuario", ModPOS.UsuarioActual)


            Else
                ModPOS.Ejecuta("sp_inserta_pago", _
                                "@PAGClave", PAGClave, _
                                "@TipoPago", cmbMetodoPago.SelectedValue, _
                                "@Moneda", Moneda, _
                                "@TipoCambio", TipoCambio, _
                                "@Importe", ImportePago, _
                                "@Saldo", ImportePago, _
                                "@BNKClave", CmbBanco.SelectedValue, _
                                "@Referencia", TxtReferencia.Text.ToUpper.Trim, _
                                "@COMClave", ModPOS.CompanyActual, _
                                "@Usuario", ModPOS.UsuarioActual)
            End If
            bError = False
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            bError = True
            Me.DialogResult = DialogResult.Cancel
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMetodoPago.SelectedIndexChanged
        If FormaPagoLoad = True Then
            If cmbMetodoPago.SelectedValue = 1 OrElse cmbMetodoPago.SelectedValue >= 7 Then
                CmbBanco.Visible = False
                TxtReferencia.Visible = False
                lblBanco.Visible = False
                lblReferencia.Visible = False
            Else
                CmbBanco.Visible = True
                TxtReferencia.Visible = True
                lblBanco.Visible = True
                lblReferencia.Visible = True
            End If
        End If
    End Sub

    Private Sub TxtImporte_DoubleClick(sender As Object, e As EventArgs) Handles TxtImporte.DoubleClick
        TxtImporte.Text = ModPOS.TruncateToDecimal(SaldoPendiente / TipoCambio, 2)
    End Sub

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMetodoPago.KeyDown, TxtImporte.KeyDown, CmbBanco.KeyDown, TxtReferencia.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

            'If Not Me.GetNextControl(sender, True) Is Nothing Then Me.GetNextControl(sender, True).Focus()
        End If
    End Sub

    Private Sub BtnTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    Private Sub CtxDocumentos_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxDocumentos.ItemClicked
        BtnTC.Text = e.ClickedItem.Text

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        Moneda = dt.Rows(0)("MONClave")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        If CInt(TipoCambio) <> 1 Then
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.TruncateToDecimal(TipoCambio, 2)), "Currency")
        Else
            LblTipoCambio.Text = ""
        End If
        SendKeys.Send("{TAB}")

    End Sub
End Class
