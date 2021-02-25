Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmDevolucion
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
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblAtiende As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents LblCaja As System.Windows.Forms.Label
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents LblDevolucion As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnBuscaDev As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDevolucion))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnBuscaDev = New Janus.Windows.EditControls.UIButton
        Me.TxtDevolucion = New System.Windows.Forms.TextBox
        Me.LblDevolucion = New System.Windows.Forms.Label
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.LblAtiende = New System.Windows.Forms.Label
        Me.LblUsuario = New System.Windows.Forms.Label
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.LblCaja = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.CmbMotivo = New Selling.StoreCombo
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.BtnBuscaDev)
        Me.GrpTickets.Controls.Add(Me.TxtDevolucion)
        Me.GrpTickets.Controls.Add(Me.LblDevolucion)
        Me.GrpTickets.Controls.Add(Me.BtnBuscaTicket)
        Me.GrpTickets.Controls.Add(Me.LblSaldo)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.TxtFolio)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.Label2)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridDetalle)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(7, 58)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(785, 366)
        Me.GrpTickets.TabIndex = 0
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Detalle Devolución"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(595, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 55
        '
        'BtnBuscaDev
        '
        Me.BtnBuscaDev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaDev.Image = CType(resources.GetObject("BtnBuscaDev.Image"), System.Drawing.Image)
        Me.BtnBuscaDev.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaDev.Location = New System.Drawing.Point(195, 332)
        Me.BtnBuscaDev.Name = "BtnBuscaDev"
        Me.BtnBuscaDev.Size = New System.Drawing.Size(48, 26)
        Me.BtnBuscaDev.TabIndex = 52
        Me.BtnBuscaDev.ToolTipText = "Busqueda de Ticket de Devolución"
        Me.BtnBuscaDev.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDevolucion
        '
        Me.TxtDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDevolucion.Location = New System.Drawing.Point(77, 337)
        Me.TxtDevolucion.Name = "TxtDevolucion"
        Me.TxtDevolucion.Size = New System.Drawing.Size(112, 21)
        Me.TxtDevolucion.TabIndex = 50
        '
        'LblDevolucion
        '
        Me.LblDevolucion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblDevolucion.Location = New System.Drawing.Point(7, 339)
        Me.LblDevolucion.Name = "LblDevolucion"
        Me.LblDevolucion.Size = New System.Drawing.Size(84, 15)
        Me.LblDevolucion.TabIndex = 51
        Me.LblDevolucion.Text = "Folio Dev."
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(249, 15)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(48, 26)
        Me.BtnBuscaTicket.TabIndex = 49
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Ticket"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(578, 322)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(201, 35)
        Me.LblSaldo.TabIndex = 48
        Me.LblSaldo.Text = "0.00"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTotal.Location = New System.Drawing.Point(449, 332)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(124, 19)
        Me.LblTotal.TabIndex = 47
        Me.LblTotal.Text = "Importe Devolución"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(121, 18)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(122, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(560, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 19)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(304, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 21)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(531, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Periodo"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio del Ticket"
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(7, 43)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(772, 269)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblAtiende
        '
        Me.LblAtiende.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAtiende.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblAtiende.Location = New System.Drawing.Point(316, 8)
        Me.LblAtiende.Name = "LblAtiende"
        Me.LblAtiende.Size = New System.Drawing.Size(72, 15)
        Me.LblAtiende.TabIndex = 6
        Me.LblAtiende.Text = "ATIENDE"
        '
        'LblUsuario
        '
        Me.LblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblUsuario.Location = New System.Drawing.Point(394, 6)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(279, 20)
        Me.LblUsuario.TabIndex = 8
        Me.LblUsuario.Text = "Folio"
        Me.LblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'LblDescripcion
        '
        Me.LblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblDescripcion.Location = New System.Drawing.Point(53, 7)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(257, 19)
        Me.LblDescripcion.TabIndex = 7
        Me.LblDescripcion.Text = "Folio"
        Me.LblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCaja
        '
        Me.LblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCaja.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCaja.Location = New System.Drawing.Point(6, 8)
        Me.LblCaja.Name = "LblCaja"
        Me.LblCaja.Size = New System.Drawing.Size(51, 15)
        Me.LblCaja.TabIndex = 5
        Me.LblCaja.Text = "CAJA"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(11, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Motivo de Devolución"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(525, 36)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox4.TabIndex = 44
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(702, 430)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 10
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(606, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbMotivo
        '
        Me.CmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbMotivo.Location = New System.Drawing.Point(153, 35)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(366, 21)
        Me.CmbMotivo.TabIndex = 42
        '
        'FrmDevolucion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(799, 473)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.CmbMotivo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.LblDescripcion)
        Me.Controls.Add(Me.LblAtiende)
        Me.Controls.Add(Me.LblCaja)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmDevolucion"
        Me.Text = "Devolución de Venta"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public bLiquidacion As Boolean = False
    Public Ventas() As DataRow
    Public Referencia As String
    Public DEVClave As String
    Public CAJClave As String
    Public ALMClave As String
    Public Impresora As String
    Public Caja As String
    Public Cajon As Boolean = False
    Public TicketDev As String
    Public ActivaCaja As Boolean = False
    Public ActivaDevolucion As Boolean = False
    Public SUCClave As String

    Private Folio As Integer
    Private FolioRef As String
    Private Autoriza As String

    Private Estado As Integer = 0

    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private dtDetalle As DataTable
    Private Total As Double

    Private bLoad As Boolean = False

    Public Mes As Integer
    Public Periodo As Integer

    Private Function imprimeDevolucion(ByVal Devolucion As String, ByVal Impresora As String, ByVal Ticket As String, ByVal Saldo As Double, ByVal Cte As String, ByVal FolioVta As String) As Boolean
        Dim dTotalAhorro, dTotalPuntos, dTotalVenta, dArticulos As Double

        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If


        Dim dtHeadTicket As DataTable
        dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

        If Not dtHeadTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()
        End If


        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddSubHeaderLine(Caja & " DEV. # " & Referencia & "-" & CStr(Folio), 1, 3)
        Tickets.AddSubHeaderLine("REFERENCIA: " & FolioVta, 1, 3)
        Tickets.AddSubHeaderLine("CTE: " & Cte, 0, 3)
        Tickets.AddSubHeaderLine("LE ATENDIO: " & LblUsuario.Text, 0, 3)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 3)

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtVentaDetalle As DataTable
        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_muestra_detalledev", "@DEVClave", Devolucion)

        If Not dtVentaDetalle Is Nothing Then
            Dim i As Integer = 0
            dArticulos = dtVentaDetalle.Rows.Count()
            For i = 0 To dArticulos - 1
                Dim sDVEClave As String = dtVentaDetalle.Rows(i)("DEVClave")
                Dim sGTIN As String = dtVentaDetalle.Rows(i)("Clave")
                Dim sNombre As String = dtVentaDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtVentaDetalle.Rows(i)("Cantidad")
                Dim dPrecioBruto As Double = dtVentaDetalle.Rows(i)("PrecioBruto")
                Dim dImpuestoImp As Double = dtVentaDetalle.Rows(i)("ImpuestoImp")
                Dim dDescuentoImp As Double = dtVentaDetalle.Rows(i)("DescuentoImp")
                Dim dPuntosImp As Double = dtVentaDetalle.Rows(i)("PuntosImp")
                Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")
                Dim dDescPorc As Double

                dDescPorc = dDescuentoImp / (dPrecioBruto + dImpuestoImp)

                ' AGREGAR PRODUCTO A LISTA
                Tickets.AddItem(sDVEClave, sGTIN, sNombre, dCantidad, dPrecioBruto + dImpuestoImp, dDescuentoImp)

                dTotalAhorro += (dDescuentoImp * dCantidad)
                dTotalPuntos += (dPuntosImp * dCantidad)
                dTotalVenta += (dTotal)

            Next
            dtVentaDetalle.Dispose()
        End If


        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
        Tickets.AddTotalDevolucion(dTotalVenta, Saldo, 1)

        'El metodo AddFooterLine funciona igual que la cabecera 

        Dim dtPieTicket As DataTable
        dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

        If Not dtPieTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtPieTicket.Rows.Count - 1
                Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
            Next
            dtPieTicket.Dispose()
        End If

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Sub FrmDevolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox4


        With Me.CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Devolucion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Motivo"
            .llenar()
        End With

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        If ActivaCaja Then
            TxtDevolucion.Visible = True
            BtnBuscaDev.Visible = True
            LblDevolucion.Visible = True
        Else
            TxtDevolucion.Visible = False
            BtnBuscaDev.Visible = False
            LblDevolucion.Visible = False
        End If

        If Not Ventas Is Nothing AndAlso Ventas.GetLength(0) = 1 Then
            TxtFolio.Text = Ventas(0)("Folio")
            Me.AgregarFolio(Ventas(0)("Folio"), CDate(Ventas(0)("Fecha")).Year, CDate(Ventas(0)("Fecha")).Month)

        End If

        bLoad = True
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtFolio.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbMotivo.SelectedValue Is Nothing Then
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

    Private Sub AgregarFolio(ByVal Folio As String, ByVal Periodo As Integer, ByVal Mes As Integer)
        If validaForm() Then

            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month

            If Not dtDetalle Is Nothing Then
                dtDetalle.Dispose()
            End If

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_dev", "@Folio", Folio, "@Periodo", Periodo, "@Mes", Mes)

            If dtDetalle.Rows.Count = 0 Then
                MessageBox.Show("No se encontro un Ticket del mes " & CStr(Mes) & " de " & CStr(Periodo) & " con Folio igual a " & TxtFolio.Text & " o se encuentra Apartado/Facturado/Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
            GridDetalle.RootTable.Columns("DVEClave").Visible = False
            GridDetalle.CurrentTable.Columns(1).Selectable = False
            GridDetalle.CurrentTable.Columns(2).Selectable = False
            GridDetalle.CurrentTable.Columns(4).Selectable = False
            GridDetalle.CurrentTable.Columns(5).Selectable = False
            GridDetalle.CurrentTable.Columns(6).Selectable = False
            GridDetalle.CurrentTable.Columns(7).Selectable = False
            GridDetalle.RootTable.Columns("VENClave").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("PrecioBruto").Visible = False
            GridDetalle.RootTable.Columns("ImpuestoImp").Visible = False
            GridDetalle.RootTable.Columns("DescuentoImp").Visible = False
            GridDetalle.RootTable.Columns("PuntosImp").Visible = False
            GridDetalle.RootTable.Columns("Cliente").Visible = False
            GridDetalle.RootTable.Columns("Seguimiento").Visible = False
            GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Function imprimeRecibo(ByVal Abono As String, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal Cte As String) As Boolean
        Dim dTotalPagos, dPagos As Double

        Dim Tickets As Imprimir = New Imprimir
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If


        Dim dtHeadTicket As DataTable
        dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

        If Not dtHeadTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()
        End If


        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddSubHeaderLine("RECIBO", 1, 3)
        Tickets.AddSubHeaderLine("CTE: " & Cte, 0, 3)
        Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

        Dim dtRef As DataTable = ModPOS.Recupera_Tabla("sp_recibo_enc", "@ABNClave", Abono)

        Tickets.AddSubHeaderBloqLine("REFERENCIA: " & dtRef.Rows(0)("Referencia"), 0, 1)
        Tickets.AddSubHeaderBloqLine("FORMA PAGO: " & dtRef.Rows(0)("Descripcion"), 0, 1)
        Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency"), 0, 1)

        dtRef.Dispose()

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtPagosDetalle As DataTable
        dtPagosDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle", "@ABNClave", Abono)

        If Not dtPagosDetalle Is Nothing Then
            Dim i As Integer = 0
            dPagos = dtPagosDetalle.Rows.Count()
            For i = 0 To dPagos - 1
                Dim sFolio As String = dtPagosDetalle.Rows(i)("Folio")
                Dim sTipo As String = dtPagosDetalle.Rows(i)("Tipo")
                Dim dImporte As Double = dtPagosDetalle.Rows(i)("Importe")


                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemRecibo(sFolio, sTipo, dImporte)

                dTotalPagos += (dImporte)
            Next
            dtPagosDetalle.Dispose()
        End If

        'El metodo AddTotalRecibo requiere 4 parametros 
        '  Tickets.AddTotalRecibo(dTotalPagos, 0, 0, 1)
        Tickets.AddFooterLine("TOTAL APLICADO: " & Format(CStr(ModPOS.Redondear(dTotalPagos, 2)), "Currency"), 1, 2)
        Tickets.AddFooterLine("CAMBIO: " & Format(CStr(ModPOS.Redondear(Cambio, 2)), "Currency"), 0, 2)

        'El metodo AddFooterLine funciona igual que la cabecera 

        Dim dtPieTicket As DataTable
        dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

        If Not dtPieTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtPieTicket.Rows.Count - 1
                Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
            Next
            dtPieTicket.Dispose()
        End If

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Sub TxtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress

        If Asc(e.KeyChar) = 13 Then
            AgregarFolio(TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), Periodo, Mes)
        End If
    End Sub

    Private Sub FrmDevolucion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bLiquidacion = True AndAlso Not ModPOS.Liquid Is Nothing Then
            ModPOS.Liquid.ActualizaGridTransac()
        End If

        If bLiquidacion = True AndAlso Not ModPOS.MtoVenta Is Nothing Then
            ModPOS.MtoVenta.ActualizaGridTransac()
        End If

        ModPOS.Devolucion.Dispose()
        ModPOS.Devolucion = Nothing
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not dtDetalle Is Nothing Then
            dtDetalle.Dispose()
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Devolución" Then
            If IsNumeric(GridDetalle.GetValue("Devolución")) Then
                If GridDetalle.GetValue("Disponible") >= GridDetalle.GetValue("Devolución") Then
                    Dim Actual As Double
                    Actual = Math.Abs(CDbl(GridDetalle.GetValue("Devolución"))) * GridDetalle.GetValue("Precio")
                    GridDetalle.SetValue(7, Actual)
                Else
                    Beep()
                    MessageBox.Show("¡La cantidad a devolver no puede ser mayor al disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Devolución", 0)
                End If
            Else
                GridDetalle.SetValue("Devolución", 0)
            End If
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        LblSaldo.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If Not dtDetalle Is Nothing Then
            Dim i As Integer
            Dim Efectivo As Double

            Dim foundRows() As DataRow
            foundRows = dtDetalle.Select("Devolución > 0 and Disponible >= Devolución")

            If foundRows.GetLength(0) > 0 Then


                If ActivaDevolucion Then
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = CDbl(LblSaldo.Text)
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If Not a.Autorizado Then
                            a.Dispose()
                            Exit Sub
                        End If
                        Autoriza = a.Autoriza
                    ElseIf a.DialogResult = DialogResult.Cancel Then
                        a.Dispose()
                        Exit Sub
                    End If
                    a.Dispose()
                End If

                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_saldo_doc", "@Tipo", 1, "@Documento", foundRows(0)(8))

                If dt.Rows(0)("Saldo") > 0 Then
                    If dt.Rows(0)("Saldo") >= Total Then
                        ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 1, "@Documento", foundRows(0)(8), "@Importe", Total)
                        Efectivo = 0
                    Else
                        ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 1, "@Documento", foundRows(0)(8), "@Importe", Total - dt.Rows(0)("Saldo"))
                        Efectivo = Total - dt.Rows(0)("Saldo")

                        If Cajon = True Then
                            AbrirCajon(Impresora)
                        End If

                    End If
                Else
                    Efectivo = Total

                    If Cajon = True AndAlso ActivaCaja = True Then
                        AbrirCajon(Impresora)
                    End If
                End If
                dt.Dispose()





                dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                If dt Is Nothing Then
                    ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                    Folio = 1
                    Periodo = Today.Year
                    Mes = Today.Month
                Else
                    Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                    Periodo = dt.Rows(0)("Periodo")
                    Mes = dt.Rows(0)("Mes")
                    ModPOS.Ejecuta("sp_act_folio", "@Tipo", 2, "@PDVClave", CAJClave, "@Incremento", 1)
                    dt.Dispose()
                End If

                DEVClave = ModPOS.obtenerLlave


                If ActivaCaja Then
                    Estado = 1
                Else
                    Estado = 0
                End If

                'Tipo 1 = Folio 2= VENClave

                Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_vta_gral", "@VENClave", foundRows(0)("VENClave"))
                FolioRef = dtVenta.Rows(0)("Folio")
                dtVenta.Dispose()

                ModPOS.Ejecuta("sp_crea_devolucion", _
                "@DEVClave", DEVClave, _
                "@VENClave", foundRows(0)("VENClave"), _
                "@CTEClave", foundRows(0)("Cliente"), _
                "@CAJClave", CAJClave, _
                "@Folio", Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes), _
                "@Motivo", CmbMotivo.SelectedValue, _
                "@Usuario", ModPOS.UsuarioActual, _
                "@Costo", 0, _
                "@Subtotal", 0, _
                "@ImpuestoTot", 0, _
                "@DescuentoTot", 0, _
                "@Total", 0, _
                "@Estado", Estado)


                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_actualiza_cantdev", "@Tipo", 1, "@Documento", foundRows(i)(8), "@Partida", foundRows(i)(0), "@Cantidad", foundRows(i)(3))

                    ModPOS.Ejecuta("sp_inserta_devdet", _
                                    "@DEVClave", DEVClave, _
                                    "@PROClave", foundRows(i)("PROClave"), _
                                    "@TProducto", foundRows(i)("TProducto"), _
                                    "@Costo", foundRows(i)("Costo"), _
                                    "@Precio", foundRows(i)("PrecioBruto"), _
                                    "@Descuento", foundRows(i)("DescuentoImp"), _
                                    "@Impuesto", foundRows(i)("ImpuestoImp"), _
                                    "@Puntos", foundRows(i)("PuntosImp"), _
                                    "@Cantidad", foundRows(i)("Devolución"), _
                                    "@Subtotal", (foundRows(i)("PrecioBruto") - foundRows(i)("DescuentoImp") + foundRows(i)("ImpuestoImp")), _
                                    "@Total", foundRows(i)("Devolución") * (foundRows(i)("PrecioBruto") - foundRows(i)("DescuentoImp") + foundRows(i)("ImpuestoImp")))


                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If foundRows(i)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = foundRows(i)("Devolución")
                        Do
                            Dim b As New FrmSerial
                            b.DOCClave = foundRows(i)("VENClave")
                            b.PROClave = foundRows(i)("PROClave")
                            b.Clave = foundRows(i)("Clave")
                            b.Nombre = foundRows(i)("Nombre")
                            b.Cantidad = PorRegistrar
                            b.Dias = foundRows(i)("DiasGarantia")
                            b.TipoDoc = 3
                            b.TipoMov = 1
                            b.ShowDialog()
                            SerialReg = SerialReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until SerialReg = foundRows(i)("Devolución") OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If foundRows(i)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = foundRows(i)("Devolución")
                        Do
                            Dim b As New FrmLote
                            b.DOCClave = foundRows(i)("VENClave")
                            b.PROClave = foundRows(i)("PROClave")
                            b.Clave = foundRows(i)("Clave")
                            b.Nombre = foundRows(i)("Nombre")
                            b.CantXRegistrar = PorRegistrar
                            b.TipoDoc = 3
                            b.TipoMov = 1
                            b.ShowDialog()
                            LoteReg = LoteReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until LoteReg = foundRows(i)("Devolución") OrElse PorRegistrar = 0
                    End If

                Next
                dtDetalle.Dispose()

                ModPOS.Ejecuta("sp_actualiza_devolucion", "@DEVClave", DEVClave)
                ModPOS.GeneraMovInv(1, 3, 3, DEVClave, ALMClave, Referencia & "-" & CStr(Folio), Autoriza)
                ModPOS.ActualizaExistAlm(1, 3, DEVClave, ALMClave)
                ModPOS.ActualizaExistUbc(1, 3, DEVClave, ALMClave)
                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("Cliente"), "@Importe", Total)

                Dim dtCliente As DataTable
                Dim RazonSocial As String

                dtCliente = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", foundRows(0)("Cliente"))
                RazonSocial = dtCliente.Rows(0)("RazonSocial")
                dtCliente.Dispose()


                imprimeDevolucion(DEVClave, Impresora, TicketDev, Efectivo, RazonSocial, FolioRef)


                Dim StopPrint As Boolean = False
                Do
                    Select Case MessageBox.Show("¿Desea Reimprimir el Ticket de Devolución", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            imprimeDevolucion(DEVClave, Impresora, TicketDev, Efectivo, RazonSocial, FolioRef)
                        Case Else
                            StopPrint = True
                    End Select
                Loop While Not StopPrint

                Me.Close()
            Else
                MessageBox.Show("Debe indicar una cantidad a devolver mayor o igual al disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Debe ingresar el folio completo del ticket y presionar Enter", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnBuscaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaTicket.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_ticket"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtFolio.Text = a.Descripcion
            Me.AgregarFolio(a.Descripcion, a.Periodo, a.Mes)
        End If
        a.Dispose()
    End Sub

    Private Sub pagaDevolucion(ByVal Folio As String, ByVal Periodo As Integer, ByVal Mes As Integer)

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_devolucion", "@Folio", Folio, "@Periodo", Periodo, "@Mes", Mes)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No se encontro un Ticket de Devolución del mes " & CStr(Mes) & " de " & CStr(Periodo) & " con Folio igual a " & TxtDevolucion.Text & " o ya fue pagado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            ModPOS.Ejecuta("sp_act_edo_devolucion", "@DEVClave", dt.Rows(0)("DEVClave"))

            LblSaldo.Text = CDbl(dt.Rows(0)("Total"))

            If Cajon = True AndAlso ActivaCaja = True Then
                AbrirCajon(Impresora)
            End If
        End If
    End Sub

    Private Sub TxtDevolucion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDevolucion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            pagaDevolucion(TxtDevolucion.Text, Periodo, Mes)
        End If
    End Sub

    Private Sub BtnBuscaDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaDev.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_ticket_devolucion"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtDevolucion.Text = a.Descripcion
            pagaDevolucion(a.Descripcion, a.Periodo, a.Mes)
        End If
        a.Dispose()
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
        End If
    End Sub
End Class
