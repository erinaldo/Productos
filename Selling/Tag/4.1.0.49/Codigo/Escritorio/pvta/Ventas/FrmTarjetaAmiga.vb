Imports Newtonsoft.Json
Imports System.Net

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
    Friend WithEvents TxtTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents btnSaldo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEstado As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPagar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAcumulado As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbMonto As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents LbNip As System.Windows.Forms.Label
    Friend WithEvents TxtNip As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarjetaAmiga))
        Me.GrpPasillo = New System.Windows.Forms.GroupBox()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TxtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lbMonto = New System.Windows.Forms.Label()
        Me.btnAcumulado = New Janus.Windows.EditControls.UIButton()
        Me.btnPagar = New Janus.Windows.EditControls.UIButton()
        Me.btnEstado = New Janus.Windows.EditControls.UIButton()
        Me.btnSaldo = New Janus.Windows.EditControls.UIButton()
        Me.TxtTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblTarjeta = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.TxtNip = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.LbNip = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GrpPasillo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPasillo
        '
        Me.GrpPasillo.Controls.Add(Me.PictureBox3)
        Me.GrpPasillo.Controls.Add(Me.LbNip)
        Me.GrpPasillo.Controls.Add(Me.TxtNip)
        Me.GrpPasillo.Controls.Add(Me.BtnTC)
        Me.GrpPasillo.Controls.Add(Me.TxtMonto)
        Me.GrpPasillo.Controls.Add(Me.lbMonto)
        Me.GrpPasillo.Controls.Add(Me.btnAcumulado)
        Me.GrpPasillo.Controls.Add(Me.btnPagar)
        Me.GrpPasillo.Controls.Add(Me.btnEstado)
        Me.GrpPasillo.Controls.Add(Me.btnSaldo)
        Me.GrpPasillo.Controls.Add(Me.TxtTarj)
        Me.GrpPasillo.Controls.Add(Me.PictureBox2)
        Me.GrpPasillo.Controls.Add(Me.PictureBox1)
        Me.GrpPasillo.Controls.Add(Me.LblTarjeta)
        Me.GrpPasillo.Location = New System.Drawing.Point(7, 7)
        Me.GrpPasillo.Name = "GrpPasillo"
        Me.GrpPasillo.Size = New System.Drawing.Size(502, 146)
        Me.GrpPasillo.TabIndex = 0
        Me.GrpPasillo.TabStop = False
        Me.GrpPasillo.Text = "Tarjeta Amiga"
        '
        'BtnTC
        '
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(240, 63)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(71, 20)
        Me.BtnTC.TabIndex = 1
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
        'TxtMonto
        '
        Me.TxtMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMonto.Location = New System.Drawing.Point(113, 61)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(94, 20)
        Me.TxtMonto.TabIndex = 126
        Me.TxtMonto.Text = "0.00"
        Me.TxtMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtMonto.Value = 0.0R
        Me.TxtMonto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lbMonto
        '
        Me.lbMonto.Location = New System.Drawing.Point(6, 65)
        Me.lbMonto.Name = "lbMonto"
        Me.lbMonto.Size = New System.Drawing.Size(97, 14)
        Me.lbMonto.TabIndex = 124
        Me.lbMonto.Text = "Monto"
        '
        'btnAcumulado
        '
        Me.btnAcumulado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAcumulado.Icon = CType(resources.GetObject("btnAcumulado.Icon"), System.Drawing.Icon)
        Me.btnAcumulado.Location = New System.Drawing.Point(397, 102)
        Me.btnAcumulado.Name = "btnAcumulado"
        Me.btnAcumulado.Size = New System.Drawing.Size(91, 30)
        Me.btnAcumulado.TabIndex = 115
        Me.btnAcumulado.Text = "Acumulado"
        Me.btnAcumulado.ToolTipText = "Generar de Ingreso Acumulado del Apertura de Caja a la fecha"
        Me.btnAcumulado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnPagar
        '
        Me.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagar.Icon = CType(resources.GetObject("btnPagar.Icon"), System.Drawing.Icon)
        Me.btnPagar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnPagar.Location = New System.Drawing.Point(7, 102)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(91, 30)
        Me.btnPagar.TabIndex = 112
        Me.btnPagar.Text = "Pagar"
        Me.btnPagar.ToolTipText = "Registrar Pago de la tarjeta seleccionada"
        Me.btnPagar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnEstado
        '
        Me.btnEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEstado.Icon = CType(resources.GetObject("btnEstado.Icon"), System.Drawing.Icon)
        Me.btnEstado.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnEstado.Location = New System.Drawing.Point(201, 102)
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
        Me.btnSaldo.Location = New System.Drawing.Point(104, 102)
        Me.btnSaldo.Name = "btnSaldo"
        Me.btnSaldo.Size = New System.Drawing.Size(91, 30)
        Me.btnSaldo.TabIndex = 109
        Me.btnSaldo.Text = "Saldo"
        Me.btnSaldo.ToolTipText = "Consultar saldo de la tarjeta seleccionada"
        Me.btnSaldo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtTarj
        '
        Me.TxtTarj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTarj.Location = New System.Drawing.Point(113, 19)
        Me.TxtTarj.Name = "TxtTarj"
        Me.TxtTarj.Size = New System.Drawing.Size(195, 26)
        Me.TxtTarj.TabIndex = 105
        Me.TxtTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(213, 62)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(314, 19)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(419, 159)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNip
        '
        Me.TxtNip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNip.Location = New System.Drawing.Point(397, 19)
        Me.TxtNip.Mask = "0000"
        Me.TxtNip.Name = "TxtNip"
        Me.TxtNip.Size = New System.Drawing.Size(76, 26)
        Me.TxtNip.TabIndex = 127
        Me.TxtNip.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'LbNip
        '
        Me.LbNip.Location = New System.Drawing.Point(346, 29)
        Me.LbNip.Name = "LbNip"
        Me.LbNip.Size = New System.Drawing.Size(45, 14)
        Me.LbNip.TabIndex = 128
        Me.LbNip.Text = "NIP"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(479, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 129
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'FrmTarjetaAmiga
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(517, 204)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpPasillo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTarjetaAmiga"
        Me.Text = "Tarjeta Amiga"
        Me.GrpPasillo.ResumeLayout(False)
        Me.GrpPasillo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public IDCorte As String
    Public CAJClave As String
    Public impresora As String = ""

    Private dImporte As Double = 0
    Private dSaldo As Double = 0
    Private sFolio As String = ""
    Private sIdComercio As String = ""
    Public sIdTerminal As String = ""
    Private dTipoCambio As Double
    Private Moneda, MONClave As String
    Private datosTarjetaAmiga As New TarjetaAmiga

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private Sub FrmTarjetaAmiga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3


        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                     Case "IdComercioTA"
                        sIdComercio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        If Not dt Is Nothing Then
            MONClave = Moneda
            dTipoCambio = CDbl(dt.Rows(0)("TipoCambio"))
        End If
        dt.Dispose()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        If consultaTarjeta(TarjetaAmiga.Pago) Then

            ModPOS.Ejecuta("st_inserta_abonoTA", _
                           "@ABNClave", ModPOS.obtenerLlave, _
                           "@Clave", sFolio, _
                           "@CAJClave", CAJClave, _
                           "@fechaPago", DateTime.Now, _
                           "@Moneda", Moneda, _
                           "@TipoCambio", dTipoCambio, _
                           "@Importe", Math.Round(datosTarjetaAmiga.monto, 2), _
                           "@numTarjeta", datosTarjetaAmiga.tarjeta, _
                           "@idComercio", datosTarjetaAmiga.idComercio, _
                           "@idTerminal", datosTarjetaAmiga.idTerminal, _
                           "@numAutorizacion", datosTarjetaAmiga.clave, _
                           "@usuario", ModPOS.UsuarioActual)



            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 6, "@PDVClave", CAJClave, "@Incremento", 1)


            preguntaImpresion(TarjetaAmiga.Pago)

        End If
    End Sub

    Private Sub btnEstado_Click(sender As Object, e As EventArgs) Handles btnEstado.Click
        If consultaTarjeta(TarjetaAmiga.EstadoCuenta) Then
            preguntaImpresion(TarjetaAmiga.EstadoCuenta)
        End If
    End Sub

    Private Sub btnSaldo_Click(sender As Object, e As EventArgs) Handles btnSaldo.Click
        If consultaTarjeta(TarjetaAmiga.EstadoCuenta) Then
            Dim mensaje As String = "Disponible compra: " + datosTarjetaAmiga.disponibleCompra.ToString() & vbCrLf & "Disponible efectivo: " + datosTarjetaAmiga.disponibleDisposicion.ToString()
            MessageBox.Show(mensaje, "SALDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function consultaTarjeta(ByVal mov As String) As Boolean
        Dim valido As Boolean = True
        Dim frmStatusMessage As New frmStatus
        If validaForm(mov) Then

            frmStatusMessage.Show("Procesando...")
            frmStatusMessage.BringToFront()

            If mov = TarjetaAmiga.EstadoCuenta Then
                datosTarjetaAmiga.referencia = TxtNip.Text
            Else
                sFolio = datosTarjetaAmiga.ObtenerFolio(CAJClave)
                datosTarjetaAmiga.referencia = sFolio.Replace("-", "")
            End If


            Dim dMonto As Double = CDbl(TxtMonto.Text) * dTipoCambio


            datosTarjetaAmiga.nombre = ""
            datosTarjetaAmiga.tarjeta = TxtTarj.Text.Replace("-", "")
            datosTarjetaAmiga.monto = dMonto
            datosTarjetaAmiga.idComercio = sIdComercio
            datosTarjetaAmiga.idTerminal = sIdTerminal
            datosTarjetaAmiga.plazo = "0"
            datosTarjetaAmiga.idTransaccion = ""

            datosTarjetaAmiga = datosTarjetaAmiga.consulta(mov)
            If datosTarjetaAmiga.codigo <> 0 Then
                MessageBox.Show(datosTarjetaAmiga.mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                frmStatusMessage.Dispose()
                valido = False
            Else
                frmStatusMessage.Show(datosTarjetaAmiga.mensaje)
                TxtMonto.Text = 0.0
                TxtTarj.Text = ""
                TxtNip.Text = ""
            End If
        Else
            valido = False
        End If
        frmStatusMessage.Dispose()
        Return valido
    End Function

    Private Function validaForm(ByVal mov As String) As Boolean
        Dim i As Integer = 0

        If sIdTerminal = "" Then
            MessageBox.Show("El idTerminal es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If sIdComercio = "" Then
            MessageBox.Show("El idComercio es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If datosTarjetaAmiga.urlServicio = "" Then
            MessageBox.Show("La URL del servicio es requerido", "EEROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If TxtTarj.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("El  numero de tarjeta es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If TxtTarj.Text <> "" AndAlso TxtTarj.Text.Length <> 16 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("El numero de tarjeta debe contener 16 digitos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If mov = TarjetaAmiga.EstadoCuenta Then
            If TxtNip.Text = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
                MessageBox.Show("El NIP es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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

    Private Sub BtnTC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub
    Private Sub CtxDocumentos_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxDocumentos.ItemClicked
        BtnTC.Text = e.ClickedItem.Text

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        MONClave = dt.Rows(0)("MONClave")
        dTipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()
    End Sub

    Private Sub preguntaImpresion(ByVal mov As String)
        Select Case MessageBox.Show("¿Desea imprimir Recibo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes
                If mov = TarjetaAmiga.EstadoCuenta Then
                    datosTarjetaAmiga.imprimirTicketPago(impresora, True, mov)
                Else
                    For aux As Integer = 1 To 2
                        datosTarjetaAmiga.imprimirTicketPago(impresora, True, mov)
                    Next
                End If
                Dim reimprimir As Boolean = True

                Do
                    Select Case MessageBox.Show("¿Desea reimprimir Recibo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            datosTarjetaAmiga.imprimirTicketPago(impresora, True, mov)
                        Case System.Windows.Forms.DialogResult.No
                            reimprimir = False
                    End Select
                Loop While reimprimir = True
        End Select
    End Sub

 
    Private Sub btnAcumulado_Click(sender As Object, e As EventArgs) Handles btnAcumulado.Click
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_tarjetaAmiga_enc", "@IdCorte", IDCorte))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_tarjetaAmiga_det", "@IdCorte", IDCorte))
        OpenReport.PrintPreview("Acumulado de Pagos a Tarjeta Amiga ", "CRTarjetaAmiga.rpt", pvtaDataSet, "")

    End Sub
End Class
