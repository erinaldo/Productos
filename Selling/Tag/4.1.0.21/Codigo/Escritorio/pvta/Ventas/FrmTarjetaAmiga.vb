Public Class FrmTarjetaAmiga
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTarjeta As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtTel2 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents btnSaldo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEstado As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnComprar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPagar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCorte As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnReporte As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarjetaAmiga))
        Me.GrpPasillo = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnCorte = New Janus.Windows.EditControls.UIButton()
        Me.btnReporte = New Janus.Windows.EditControls.UIButton()
        Me.btnPagar = New Janus.Windows.EditControls.UIButton()
        Me.btnComprar = New Janus.Windows.EditControls.UIButton()
        Me.btnEstado = New Janus.Windows.EditControls.UIButton()
        Me.btnSaldo = New Janus.Windows.EditControls.UIButton()
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton()
        Me.TxtTicket = New System.Windows.Forms.TextBox()
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblTarjeta = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPasillo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPasillo
        '
        Me.GrpPasillo.Controls.Add(Me.Label4)
        Me.GrpPasillo.Controls.Add(Me.Label3)
        Me.GrpPasillo.Controls.Add(Me.txtNombre)
        Me.GrpPasillo.Controls.Add(Me.txtCliente)
        Me.GrpPasillo.Controls.Add(Me.Label2)
        Me.GrpPasillo.Controls.Add(Me.txtSaldo)
        Me.GrpPasillo.Controls.Add(Me.Label1)
        Me.GrpPasillo.Controls.Add(Me.txtImporte)
        Me.GrpPasillo.Controls.Add(Me.btnCorte)
        Me.GrpPasillo.Controls.Add(Me.btnReporte)
        Me.GrpPasillo.Controls.Add(Me.btnPagar)
        Me.GrpPasillo.Controls.Add(Me.btnComprar)
        Me.GrpPasillo.Controls.Add(Me.btnEstado)
        Me.GrpPasillo.Controls.Add(Me.btnSaldo)
        Me.GrpPasillo.Controls.Add(Me.BtnBuscaTicket)
        Me.GrpPasillo.Controls.Add(Me.TxtTicket)
        Me.GrpPasillo.Controls.Add(Me.TxtTel2)
        Me.GrpPasillo.Controls.Add(Me.Label6)
        Me.GrpPasillo.Controls.Add(Me.PictureBox2)
        Me.GrpPasillo.Controls.Add(Me.PictureBox1)
        Me.GrpPasillo.Controls.Add(Me.LblTarjeta)
        Me.GrpPasillo.Location = New System.Drawing.Point(7, 7)
        Me.GrpPasillo.Name = "GrpPasillo"
        Me.GrpPasillo.Size = New System.Drawing.Size(590, 255)
        Me.GrpPasillo.TabIndex = 0
        Me.GrpPasillo.TabStop = False
        Me.GrpPasillo.Text = "Tarjeta Amiga"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 14)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 14)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Cliente"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(115, 123)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(467, 21)
        Me.txtNombre.TabIndex = 121
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(115, 96)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(143, 21)
        Me.txtCliente.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 14)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Saldo"
        '
        'txtSaldo
        '
        Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(115, 178)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(94, 20)
        Me.txtSaldo.TabIndex = 118
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSaldo.Value = 0.0R
        Me.txtSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Importe"
        '
        'txtImporte
        '
        Me.txtImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporte.Enabled = False
        Me.txtImporte.Location = New System.Drawing.Point(115, 152)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(94, 20)
        Me.txtImporte.TabIndex = 116
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtImporte.Value = 0.0R
        Me.txtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'btnCorte
        '
        Me.btnCorte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCorte.Icon = CType(resources.GetObject("btnCorte.Icon"), System.Drawing.Icon)
        Me.btnCorte.Location = New System.Drawing.Point(493, 219)
        Me.btnCorte.Name = "btnCorte"
        Me.btnCorte.Size = New System.Drawing.Size(91, 30)
        Me.btnCorte.TabIndex = 115
        Me.btnCorte.Text = "Corte"
        Me.btnCorte.ToolTipText = "Generar de corte"
        Me.btnCorte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnReporte
        '
        Me.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporte.Icon = CType(resources.GetObject("btnReporte.Icon"), System.Drawing.Icon)
        Me.btnReporte.Location = New System.Drawing.Point(394, 219)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(91, 30)
        Me.btnReporte.TabIndex = 113
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.ToolTipText = "impresión de reporte seleccionados"
        Me.btnReporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnPagar
        '
        Me.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagar.Icon = CType(resources.GetObject("btnPagar.Icon"), System.Drawing.Icon)
        Me.btnPagar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnPagar.Location = New System.Drawing.Point(103, 219)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(91, 30)
        Me.btnPagar.TabIndex = 112
        Me.btnPagar.Text = "Pagar"
        Me.btnPagar.ToolTipText = "Registrar Pago de la tarjeta seleccionada"
        Me.btnPagar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnComprar
        '
        Me.btnComprar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnComprar.Icon = CType(resources.GetObject("btnComprar.Icon"), System.Drawing.Icon)
        Me.btnComprar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnComprar.Location = New System.Drawing.Point(6, 219)
        Me.btnComprar.Name = "btnComprar"
        Me.btnComprar.Size = New System.Drawing.Size(91, 30)
        Me.btnComprar.TabIndex = 111
        Me.btnComprar.Text = "Comprar"
        Me.btnComprar.ToolTipText = "Realizar cobro o pago de un pedido seleccionado"
        Me.btnComprar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnEstado
        '
        Me.btnEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEstado.Icon = CType(resources.GetObject("btnEstado.Icon"), System.Drawing.Icon)
        Me.btnEstado.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnEstado.Location = New System.Drawing.Point(297, 219)
        Me.btnEstado.Name = "btnEstado"
        Me.btnEstado.Size = New System.Drawing.Size(91, 30)
        Me.btnEstado.TabIndex = 110
        Me.btnEstado.Text = "Edo. Cta."
        Me.btnEstado.ToolTipText = "impresión de estado de cuenta de la tarjeta seleccionada"
        Me.btnEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSaldo
        '
        Me.btnSaldo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaldo.Icon = CType(resources.GetObject("btnSaldo.Icon"), System.Drawing.Icon)
        Me.btnSaldo.Location = New System.Drawing.Point(200, 219)
        Me.btnSaldo.Name = "btnSaldo"
        Me.btnSaldo.Size = New System.Drawing.Size(91, 30)
        Me.btnSaldo.TabIndex = 109
        Me.btnSaldo.Text = "Saldo"
        Me.btnSaldo.ToolTipText = "Consultar saldo de la tarjeta seleccionada"
        Me.btnSaldo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Icon = CType(resources.GetObject("BtnBuscaTicket.Icon"), System.Drawing.Icon)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(264, 69)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(46, 23)
        Me.BtnBuscaTicket.TabIndex = 107
        Me.BtnBuscaTicket.Text = "F1"
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Pedido"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtTicket
        '
        Me.TxtTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(115, 69)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(143, 21)
        Me.TxtTicket.TabIndex = 106
        '
        'TxtTel2
        '
        Me.TxtTel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTel2.Location = New System.Drawing.Point(115, 19)
        Me.TxtTel2.Mask = "0000-0000-0000-0000"
        Me.TxtTel2.Name = "TxtTel2"
        Me.TxtTel2.Size = New System.Drawing.Size(195, 26)
        Me.TxtTel2.TabIndex = 105
        Me.TxtTel2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "No. Ticket"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(316, 69)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(316, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'LblTarjeta
        '
        Me.LblTarjeta.Location = New System.Drawing.Point(6, 29)
        Me.LblTarjeta.Name = "LblTarjeta"
        Me.LblTarjeta.Size = New System.Drawing.Size(80, 16)
        Me.LblTarjeta.TabIndex = 87
        Me.LblTarjeta.Text = "No. Tarjeta"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(507, 268)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTarjetaAmiga
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(601, 309)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpPasillo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 325)
        Me.Name = "FrmTarjetaAmiga"
        Me.Text = "Tarjeta Amiga"
        Me.GrpPasillo.ResumeLayout(False)
        Me.GrpPasillo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public CAJClave As String
    Public sPedido As String = ""
    Public iTipoDoc As Integer
    Public sCTEClave As String = ""
    Public sFolio As String = ""
    Public sClave As String = ""
    Public sCliente As String = ""
    Public dImporte As Double = 0
    Public dSaldo As Double = 0


    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Sub FrmTarjetaAmiga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        If sPedido <> "" Then
            TxtTicket.Text = sFolio
            txtCliente.Text = sClave
            txtNombre.Text = sCliente
            txtImporte.Text = dImporte
            txtSaldo.Text = dSaldo
        End If


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscaTicket_Click(sender As Object, e As EventArgs) Handles BtnBuscaTicket.Click
        Dim a As New MeSearchCte
        a.ProcedimientoAlmacenado = "sp_search_ticket_venta"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.RequiereCaja = True
        '  a.Caja = Caja
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            '  recuperaTicket(2, a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub btnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click

    End Sub
End Class
