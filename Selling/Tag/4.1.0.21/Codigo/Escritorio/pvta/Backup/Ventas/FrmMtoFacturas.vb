Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmMtoFacturas
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnReFac As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoFacturas))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnSend = New Janus.Windows.EditControls.UIButton
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton
        Me.BtnReFac = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridFacturas = New Janus.Windows.GridEX.GridEX
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.BtnSend)
        Me.GrpTickets.Controls.Add(Me.BtnFacturar)
        Me.GrpTickets.Controls.Add(Me.BtnReFac)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.BtnReimpresion)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.CmbSucursal)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridFacturas)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(742, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Facturas"
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(164, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(260, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 22
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(527, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 20)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.Icon = CType(resources.GetObject("BtnSend.Icon"), System.Drawing.Icon)
        Me.BtnSend.Location = New System.Drawing.Point(356, 430)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 37)
        Me.BtnSend.TabIndex = 20
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.ToolTipText = "Envio por correo electrónico"
        Me.BtnSend.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFacturar.Image = CType(resources.GetObject("BtnFacturar.Image"), System.Drawing.Image)
        Me.BtnFacturar.Location = New System.Drawing.Point(646, 430)
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(90, 37)
        Me.BtnFacturar.TabIndex = 21
        Me.BtnFacturar.Text = "&Facturar"
        Me.BtnFacturar.ToolTipText = "Crea una nueva Factura"
        Me.BtnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReFac
        '
        Me.BtnReFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReFac.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReFac.Icon = CType(resources.GetObject("BtnReFac.Icon"), System.Drawing.Icon)
        Me.BtnReFac.Location = New System.Drawing.Point(454, 430)
        Me.BtnReFac.Name = "BtnReFac"
        Me.BtnReFac.Size = New System.Drawing.Size(90, 37)
        Me.BtnReFac.TabIndex = 19
        Me.BtnReFac.Text = "Imprimir"
        Me.BtnReFac.ToolTipText = "Reimpresión de Facturas"
        Me.BtnReFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(490, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Periodo"
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(550, 430)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Consultar"
        Me.BtnReimpresion.ToolTipText = "Mostrar factura seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(550, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(185, 22)
        Me.dtPicker.TabIndex = 52
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(175, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(75, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(315, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridFacturas
        '
        Me.GridFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridFacturas.ColumnAutoResize = True
        Me.GridFacturas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridFacturas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridFacturas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridFacturas.Location = New System.Drawing.Point(7, 45)
        Me.GridFacturas.Name = "GridFacturas"
        Me.GridFacturas.RecordNavigator = True
        Me.GridFacturas.Size = New System.Drawing.Size(728, 379)
        Me.GridFacturas.TabIndex = 2
        Me.GridFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoFacturas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoFacturas"
        Me.Text = "Facturación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Mes As Integer
    Public Periodo As Integer
    
    Private sFacturaSelected As String
    Private sFolio As String
    Private ALMClave As String = ""
    Private sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private sCTEClave As String
    Private iTipoCF As Integer
    Private sUUID As String
    Private sRFC As String
    Private FormatoFactura As String

    Private dTotal, dSaldo As Double
    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False
    Private Estado As String

    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream


    Private TipoCF As Integer
    ' Private ServidorCancelacion, ServidorTimbrado, Customerkey As String

    Private dtPAC As DataTable

    Private Autoriza As String


    Public Sub refrescaGrid()

        Dim sSUCClave As String

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, Me.GridFacturas, "sp_muestra_facturas", "@Sucursal", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        Me.GridFacturas.RootTable.Columns("FACClave").Visible = False
        Me.GridFacturas.RootTable.Columns("TipoCF").Visible = False
        Me.GridFacturas.RootTable.Columns("RFC").Visible = False
        Me.GridFacturas.RootTable.Columns("CTEClave").Visible = False

        If TipoCF = 2 Then
            Me.GridFacturas.RootTable.Columns("uuid").Visible = True
        Else
            Me.GridFacturas.RootTable.Columns("uuid").Visible = False
        End If

        GridFacturas.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridFacturas.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridFacturas.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridFacturas.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub FrmMtoFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If


        Dim dtParam As DataTable

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "TipoCF"
                        TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()

        If TipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
        End If


        refrescaGrid()

        Cursor.Current = Cursors.Default
        bLoad = True


    End Sub

    Private Sub GridFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridFacturas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnReimpresion.PerformClick()
        End If
    End Sub

    Private Sub GridFacturas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridFacturas.SelectionChanged
        If Not GridFacturas.GetValue(0) Is Nothing Then
            sFacturaSelected = GridFacturas.GetValue("FACClave")
            dTotal = GridFacturas.GetValue("Total")
            dSaldo = GridFacturas.GetValue("Saldo")
            sFolio = GridFacturas.GetValue("Folio")
            sUUID = IIf(GridFacturas.GetValue("uuid").GetType.Name = "DBNull", "", GridFacturas.GetValue("uuid"))
            sRFC = GridFacturas.GetValue("RFC")
            iTipoCF = IIf(GridFacturas.GetValue("TipoCF").GetType.Name = "DBNull", 1, GridFacturas.GetValue("TipoCF"))
            sCTEClave = GridFacturas.GetValue("CTEClave")
            Estado = GridFacturas.GetValue("Estado")
        Else
            sFacturaSelected = ""
            sFolio = ""
            dTotal = 0
            dSaldo = 0
            iTipoCF = 0
            sRFC = ""
            sUUID = ""
            sCTEClave = ""
            Estado = ""
        End If
    End Sub

    Private Sub GridFacturas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridFacturas.DoubleClick
        If Not GridFacturas.GetValue(0) Is Nothing Then
            If sFacturaSelected <> "" Then
                Dim sFACClave As String = sFacturaSelected
                If Estado = "Pendiente" Then
                    Dim iTipoPAC As Integer
                    If MessageBox.Show("El documento seleccionado se encuentra pendiente de Certificación, ¿deseas intentar nuevamente?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then


                        iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, sFolio, sFACClave, "ingreso")

                        If iTipoPAC <> 0 Then
                            Me.refrescaGrid()
                            Imprimir(sFACClave)
                        End If
                    Else
                        muestraPedidos(sFACClave)
                    End If 'Desea Certificacion
                Else
                    muestraPedidos(sFACClave)
                End If 'Estado Pendiente
            End If 'Seleccion de factura
        End If 'Grid
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0



        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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

    Private Sub FrmMtoFacturas_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoFacturas.Dispose()
        ModPOS.MtoFacturas = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sFacturaSelected <> "" Then
            Imprimir(sFacturaSelected)
         End If
    End Sub

    Private Sub muestraPedidos(ByVal sFACClave As String)
        Dim a As New FrmConsultaGen
        a.Text = "Detalle de Ventas incluidas en la Factura"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_ventafac", "@FACClave", sFACClave)
        a.GridConsultaGen.GroupByBoxVisible = False
        a.ShowDialog()
        a.Dispose()
    End Sub


    Private Sub Imprimir(ByVal sFACClave As String)

        Dim MonRef, MonDesc As String
        Dim TipoCambio As Double
        Dim dt As DataTable

        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", sFACClave)
        TipoCambio = dt.Rows(0)("TipoCambio")
        MonRef = dt.Rows(0)("Referencia")
        MonDesc = dt.Rows(0)("Descripcion")
        dt.Dispose()

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", CmbSucursal.SelectedValue))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sFACClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", sFACClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", sFACClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sFACClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", sFACClave))

        If iTipoCF = 1 Then
            If FormatoFactura = "Clasico" Then
                OpenReport.PrintPreview("Factura", "CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            Else
                OpenReport.PrintPreview("Factura", "CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            End If
        ElseIf iTipoCF = 2 Then
            If FormatoFactura = "Clasico" Then
                OpenReport.PrintPreview("Factura", "CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            Else
                OpenReport.PrintPreview("Factura", "CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
            End If
        ElseIf iTipoCF = 3 Then
            OpenReport.PrintPreview("Factura", "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
        End If


    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub BtnReFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReFac.Click
        If validaForm() Then
            Dim a As New FrmReimpresion
            a.TipoReimpresion = "Factura"
            a.Impresora = ""
            a.SUCClave = CmbSucursal.SelectedValue
            a.ShowDialog()
            a.Dispose()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If validaForm() Then
            If sFacturaSelected <> "" Then
                Dim FileXML As String = ""
                Dim dt As DataTable
                'Recupera correo electronico

                dt = ModPOS.Recupera_Tabla("sp_recupera_mail", "@Clave", sFacturaSelected, "@Tipo", 1)
                sMailCliente = dt.Rows(0)("Email")
                dt.Dispose()

                If sMailCliente = "" Then
                    MessageBox.Show("El cliente no cuenta con una dirección de Correo Electrónica Configurada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Recupera CompanyParam

                If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                    MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                'Verifica que exista el path

                If iTipoCF <= 2 Then
                    Try
                        If Not System.IO.Directory.Exists(PathXML) Then
                            MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try

                    If PathXML.Length <= 3 Then
                        FileXML = PathXML & sFolio & ".xml"
                    Else
                        FileXML = PathXML & "\" & sFolio & ".xml"
                    End If

                    If Not System.IO.File.Exists(FileXML) Then
                        MessageBox.Show("No fue posible encontrar el archivo: " & FileXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If

                PathPDF = pathActual & "Temp\" & sFolio & ".PDF"

                'Genera PDF

                Dim MonRef, MonDesc As String
                Dim TipoCambio As Double

                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", sFacturaSelected)
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                dt.Dispose()

                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"

                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", CmbSucursal.SelectedValue))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sFacturaSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", sFacturaSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", sFacturaSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sFacturaSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", sFacturaSelected))

                If iTipoCF = 1 Then
                    If FormatoFactura = "Clasico" Then
                        OpenReport.PrintPDF("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    Else
                        OpenReport.PrintPDF("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    End If
                ElseIf iTipoCF = 2 Then
                    If FormatoFactura = "Clasico" Then
                        OpenReport.PrintPDF("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    Else
                        OpenReport.PrintPDF("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    End If
                ElseIf iTipoCF = 3 Then
                    OpenReport.PrintPDF("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                End If

                If Not System.IO.File.Exists(PathPDF) Then
                    MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Envia Correo

                Dim frmStatusMessage As New frmStatus
                Try
                    correo = New MailMessage
                    autenticar = New NetworkCredential
                    envio = New SmtpClient

                    If iTipoCF = 1 Then
                        correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Factura (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                    ElseIf iTipoCF = 3 Then
                        correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Factura (*.PDF), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                    End If

                    correo.Subject = "Factura " & sFolio
                    correo.IsBodyHtml = True
                    correo.To.Clear()
                    correo.CC.Clear()
                    correo.Bcc.Clear()

                    If sMailCliente.Split(",").Length >= 1 Then
                        Dim i As Integer
                        For i = 0 To sMailCliente.Split(",").Length - 1
                            correo.To.Add(sMailCliente.Split(",")(i))
                        Next
                    Else
                        correo.To.Add(sMailCliente)
                    End If


                    correo.From = New MailAddress(MailAdress, DisplayName)
                    envio.Credentials = New NetworkCredential(MailUser, MailPassword)
                    envio.Host = HostSMTP  '"smtp.live.com"
                    envio.Port = MailPort  '587
                    envio.EnableSsl = MailSSL 'True

                    frmStatusMessage.Show("Enviando correo electrónico...")

                    If iTipoCF <= 2 Then
                        dato = New FileStream(FileXML, FileMode.Open, FileAccess.Read)
                        adjuntos = New Attachment(dato, sFolio & ".XML")
                        correo.Attachments.Add(adjuntos)
                    End If


                    dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
                    adjuntos = New Attachment(dato, sFolio & ".PDF")
                    correo.Attachments.Add(adjuntos)


                    envio.Send(correo)
                    correo.Dispose()

                    MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmStatusMessage.Dispose()
                Catch ex As Exception
                    frmStatusMessage.Dispose()
                    MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dato.Close()

                Try
                    My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try

            Else
                MessageBox.Show("¡No se ha seleccionado una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFacturar.Click
        If validaForm() Then
            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_filtra_caja", "@Sucursal", CmbSucursal.SelectedValue)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Dispose()

                If ModPOS.Factura Is Nothing Then
                    ModPOS.Factura = New FrmFactura
                    ModPOS.Factura.SUCClave = CmbSucursal.SelectedValue
                End If

                ModPOS.Factura.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Factura.Show()

                If Not ModPOS.Factura Is Nothing Then
                    ModPOS.Factura.BringToFront()
                End If
            Else
                MessageBox.Show("El Almacén o Sucursal seleccionada no tiene una Caja disponible para Facturar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If sFacturaSelected <> "" Then

            If Estado = "Cancelada" Then
                MessageBox.Show("El documento seleccionado ya se encuentra Cancelado")
                Exit Sub
            End If

            Dim dt As DataTable

            'Valida que no tenga abonos aplicados, que el total sea igual al saldo

            If TipoCF = 1 OrElse TipoCF = 3 Then
                If dTotal <> dSaldo Then
                    MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If CmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("La Sucursal no es valida o es requerida")
                Exit Sub
            End If
            'Recupera Almacen

            dt = Recupera_Tabla("sp_recupera_almfac", "@FACClave", sFacturaSelected)
            ALMClave = dt.Rows(0)("ALMClave")
            dt.Dispose()

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & sFolio & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion

                    a.Sucursal = CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = dTotal
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza

                            Dim eRFC, sCTEClave As String
                            Dim dTotal As Double

                            dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sFacturaSelected)
                            eRFC = dt.Rows(0)("cRFC")
                            sCTEClave = dt.Rows(0)("CTEClave")
                            dTotal = dt.Rows(0)("total")
                            dSaldo = dt.Rows(0)("saldo")
                            dt.Dispose()

                            If TipoCF = 2 AndAlso Estado = "Activa" Then

                                If Math.Round(dTotal, 2) <> Math.Round(dSaldo, 2) Then
                                    MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If

                                If ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC) = False Then
                                    Exit Sub
                                End If

                            End If

                            ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", sFacturaSelected)
                            ModPOS.GeneraMovInv(1, 5, 2, sFacturaSelected, ALMClave, sFolio, Autoriza)
                            ModPOS.ActualizaExistAlm(1, 2, sFacturaSelected, ALMClave)
                            ModPOS.ActualizaExistUbc(1, 2, sFacturaSelected, ALMClave)
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal)
                            ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", sFacturaSelected, "@Tipo", 2)


                            If TipoCF = 2 AndAlso Estado <> "Activa" Then
                                ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", sFacturaSelected)
                            End If


                            refrescaGrid()

                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡No se ha seleccionado una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

 
    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub
End Class
