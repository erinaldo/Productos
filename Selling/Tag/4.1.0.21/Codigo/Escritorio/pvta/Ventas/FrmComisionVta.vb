Public Class FrmComisionVta
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents LstAsignados As System.Windows.Forms.ListBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents TxtPorc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComisionVta))
        Me.TxtTicket = New System.Windows.Forms.TextBox()
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSubtotal = New System.Windows.Forms.TextBox()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblIVA = New System.Windows.Forms.Label()
        Me.LblSubtotal = New System.Windows.Forms.Label()
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.LstAsignados = New System.Windows.Forms.ListBox()
        Me.TxtPorc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(7, 16)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(89, 21)
        Me.TxtTicket.TabIndex = 1
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(127, 15)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaTicket.TabIndex = 2
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Ticket"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 532)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 532)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(167, 80)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(618, 411)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Enabled = False
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 15)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(605, 388)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.TxtBusqueda)
        Me.GrpCliente.Controls.Add(Me.BtnAbrir)
        Me.GrpCliente.Controls.Add(Me.BtnAgregar)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaCte)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Location = New System.Drawing.Point(7, 1)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(778, 75)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(88, 17)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(113, 21)
        Me.TxtBusqueda.TabIndex = 96
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(585, 11)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(90, 30)
        Me.BtnAbrir.TabIndex = 95
        Me.BtnAbrir.Text = "&Abrir"
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(681, 11)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregar.TabIndex = 94
        Me.BtnAgregar.Text = "&Nuevo"
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 19)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(206, 15)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaCte.TabIndex = 1
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(88, 45)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(683, 21)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Buscar"
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubtotal.Enabled = False
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(279, 497)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(150, 26)
        Me.TxtSubtotal.TabIndex = 4
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(611, 498)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(174, 26)
        Me.TxtTotal.TabIndex = 17
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(556, 505)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(56, 14)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Comisión"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(434, 505)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(71, 14)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "% Comisión"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(239, 506)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(34, 15)
        Me.LblSubtotal.TabIndex = 92
        Me.LblSubtotal.Text = "Total"
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSinAsignar.Controls.Add(Me.BtnDevolucion)
        Me.GrpSinAsignar.Controls.Add(Me.LstAsignados)
        Me.GrpSinAsignar.Controls.Add(Me.TxtTicket)
        Me.GrpSinAsignar.Controls.Add(Me.BtnBuscaTicket)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(7, 80)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(160, 444)
        Me.GrpSinAsignar.TabIndex = 93
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Tickets"
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Image = CType(resources.GetObject("BtnDevolucion.Image"), System.Drawing.Image)
        Me.BtnDevolucion.Location = New System.Drawing.Point(101, 15)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(23, 22)
        Me.BtnDevolucion.TabIndex = 14
        Me.BtnDevolucion.ToolTipText = "Remueve el Ticket Seleccionado de la Factura Actual"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LstAsignados
        '
        Me.LstAsignados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LstAsignados.HorizontalScrollbar = True
        Me.LstAsignados.Location = New System.Drawing.Point(7, 42)
        Me.LstAsignados.Name = "LstAsignados"
        Me.LstAsignados.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstAsignados.ScrollAlwaysVisible = True
        Me.LstAsignados.Size = New System.Drawing.Size(146, 394)
        Me.LstAsignados.TabIndex = 10
        '
        'TxtPorc
        '
        Me.TxtPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPorc.Location = New System.Drawing.Point(510, 501)
        Me.TxtPorc.Name = "TxtPorc"
        Me.TxtPorc.Size = New System.Drawing.Size(40, 20)
        Me.TxtPorc.TabIndex = 15
        Me.TxtPorc.Text = "0.00"
        Me.TxtPorc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPorc.Value = 0.0R
        Me.TxtPorc.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'FrmComisionVta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.TxtPorc)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.LblTotal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmComisionVta"
        Me.Text = "Pago a Comisionistas"
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpSinAsignar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public MONRefBase As String
    Public CAJClave As String
    Public Cajon As Boolean = False
    Public Ticket As String
    Public PrintGeneric As Boolean
    Public SUCClave As String
    Public ALMClave As String
    Public Impresora As String
    Public Referencia As String

    Private COVClave As String
    Private VENClave As String
    Private Folio As Integer
    Private Periodo As Integer
    Private Mes As Integer

  
    Private dtAsignados As DataTable
    Private ComisionVtaCreada As Boolean = False
    Private Grabado As Boolean = False

    Private Subtotal As Decimal = 0
    Private Total As Decimal = 0


    'Receptor
    Private CTEClave As String = ""
    Private Clave As String
    Private RazonSocial As String





    Public Sub CargaDatosCliente(ByVal CTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
            Clave = dt.Rows(0)("Clave")
            RazonSocial = dt.Rows(0)("RazonSocial")
            dt.Dispose()
            TxtBusqueda.Text = Clave
            TxtRazonSocial.Text = RazonSocial
        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarCTE()
        If CTEClave <> "" Then
            If ModPOS.Cliente Is Nothing Then
                ModPOS.Cliente = New FrmCliente
                With ModPOS.Cliente
                    .Text = "Modificar Cliente"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    .fromForm = "ComisionVta"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClave)
                    .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                    .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
                    .CTEClave = dt.Rows(0)("CTEClave")
                    .TPersona = dt.Rows(0)("TPersona")
                    .Clave = dt.Rows(0)("Clave")
                    .NombreCorto = dt.Rows(0)("NombreCorto")
                    .RazonSocial = dt.Rows(0)("RazonSocial")
                    .RFC = dt.Rows(0)("id_Fiscal")
                    .CURP = dt.Rows(0)("CURP")
                    .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                    .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                    .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                    .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                    .FechaReg = dt.Rows(0)("FechaRegistro")
                    .Estado = dt.Rows(0)("Estado")
                    .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                    .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                    .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                    .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                    .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))
                    .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))
                 
                    .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                    .LCredito = dt.Rows(0)("LimiteCredito")
                    .DiasCredito = dt.Rows(0)("DiasCredito")

                    .PaisF = dt.Rows(0)("Pais")
                    .EntidadF = dt.Rows(0)("Entidad")
                    .MnpioF = dt.Rows(0)("Municipio")
                    .ColoniaF = dt.Rows(0)("Colonia")
                    .CalleF = dt.Rows(0)("Calle")
                    .LocalidadF = dt.Rows(0)("Localidad")
                    .referenciaF = dt.Rows(0)("referencia")
                    .noExteriorF = dt.Rows(0)("noExterior")
                    .noInteriorF = dt.Rows(0)("noInterior")
                    .codigoPostalF = dt.Rows(0)("codigoPostal")
                    .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                    .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                    .Contacto = dt.Rows(0)("Contacto")
                    .Tel1 = dt.Rows(0)("Tel1")
                    .Tel2 = dt.Rows(0)("Tel2")
                    .email = dt.Rows(0)("Email")

                    .Saldo = dt.Rows(0)("Saldo")
                    .CreditoDisponible = dt.Rows(0)("Disponible")

                    .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                    .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                    .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                    .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                    .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                    .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))
                    .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                    .Password = IIf(dt.Rows(0)("Password").GetType.Name = "DBNull", "", dt.Rows(0)("Password"))
                    .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()

        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Agregar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
    End Sub

    Private Sub BtnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CTEClave = a.valor
                CargaDatosCliente(CTEClave)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusqueda.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtBusqueda.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        CTEClave = dtCliente.Rows(0)("CTEClave")
                        dtCliente.Dispose()
                        CargaDatosCliente(CTEClave)
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_cliente"
                a.TablaCmb = "Cliente"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.CompaniaRequerido = True
                a.BusquedaInicial = True
                a.Busqueda = TxtBusqueda.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CTEClave = a.valor
                        CargaDatosCliente(CTEClave)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If Me.TxtRazonSocial.Text <> "" Then
            modificarCTE()
        End If
    End Sub

    Private Sub TxtTicket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTicket.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtTicket.Text = vbNullString Then
                CargaDatosTicket(DateTime.Today.Year(), DateTime.Today.Month(), TxtTicket.Text.ToUpper.Trim.Replace("'", "''"))
                TxtTicket.Text = ""
            End If
        End If
    End Sub

    Public Function CargaDatosTicket(ByVal Periodo As Integer, ByVal Mes As Integer, ByVal Folio As String) As Boolean
        'Valida que el campo Ticket no se encuentre vacio
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_busca_ticket_com", "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@SUCClave", SUCClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            VENClave = dt.Rows(0)("VENClave")
            dt.Dispose()

            If Not ComisionVtaCreada Then

                COVClave = ModPOS.obtenerLlave
                
                ModPOS.Ejecuta("sp_crea_comisionvta", _
                "@COVClave", COVClave, _
                "@Atendio", ModPOS.UsuarioActual)

                ComisionVtaCreada = True

            End If

            ModPOS.Ejecuta("sp_agrega_tic_com", "@COVClave", COVClave, "@VENClave", VENClave)


            CargaDetalle()

            Return True
        Else
            Return False
            MessageBox.Show("El folio introducido no se encuentra disponible o no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Private Sub CargaDetalle()

        dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_TicketsAsignados_com", "@COVClave", COVClave)
        Me.LstAsignados.DataSource = dtAsignados
        Me.LstAsignados.DisplayMember = dtAsignados.Columns(1).ColumnName
        Me.LstAsignados.ValueMember = dtAsignados.Columns(0).ColumnName
        Me.LstAsignados.ClearSelected()

        ModPOS.ActualizaGrid(False, Me.GridDetalle, "sp_muestra_detalle_com", "@COVClave", COVClave, "@COMClave", ModPOS.CompanyActual)
        GridDetalle.RootTable.Columns("Costo").Visible = False
        GridDetalle.RootTable.Columns("Impuesto").Visible = False
        GridDetalle.GroupByBoxVisible = False

        Dim dSubtotal As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        Dim dImpuesto As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)


        Subtotal = dSubtotal + dImpuesto
        TxtSubtotal.Text = Format(Redondear(Subtotal, 2).ToString, "Currency") & " " & MONRefBase

        Total = Redondear((CDbl(TxtPorc.Text) / 100) * Subtotal, 2)
        TxtTotal.Text = Format(Total.ToString, "Currency") & " " & MONRefBase

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaTicket.Click
        Dim a As New FrmBuscaTicket
        a.TipoBusqueda = "ComisionVta"
        a.ShowDialog()
        a.Dispose()
        TxtTicket.Focus()
    End Sub

    Private Sub BtnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click
        If Me.LstAsignados.SelectedIndex <> -1 Then

            If MessageBox.Show("¿Esta seguro de remover el ticket " & Me.LstAsignados.Items(Me.LstAsignados.SelectedIndex)(1) & " del documento actual?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                ModPOS.Ejecuta("sp_elimina_ticket_com", "@COVClave", COVClave, "@VENClave", Me.LstAsignados.Items(Me.LstAsignados.SelectedIndex)(0))

                CargaDetalle()
            End If
        Else
            MessageBox.Show("No se encuentra algun ticket seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If GridDetalle.RowCount <= 0 Then
            MessageBox.Show("No es posible generar el pago de comisión debido a que no se encontraron productos disponibles para los tickets seleccionados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CTEClave = "" Then
            MessageBox.Show("No es posible generar el pago de comisión debido a que no seleccionado un cliente comisionista", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CDbl(TxtPorc.Text) <= 0 OrElse CDbl(TxtPorc.Text) > 100 Then
            MessageBox.Show("No es posible generar el pago de comisión debido a que no el porcentaje de comision no se ha especificado o esta fuera de rango ( > 0 y < 100)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim a As New MeAutorizacion
        a.Sucursal = SUCClave
        a.MontodeAutorizacion = Total
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Autorizado Then
                a.Dispose()
                Exit Sub
            End If
        ElseIf a.DialogResult = DialogResult.Cancel Then
            a.Dispose()
            Exit Sub
        End If
        a.Dispose()

        Dim dt As DataTable
        dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 8, "@PDVClave", CAJClave)
        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 8, "@PDVClave", CAJClave)
            Folio = 1
            Periodo = Today.Year
            Mes = Today.Month
        Else
            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 8, "@PDVClave", CAJClave, "@Incremento", 1)
            dt.Dispose()
        End If

        'Actualiza ComisionVta
        ModPOS.Ejecuta("sp_actualiza_com", _
                      "@COVClave", COVClave, _
                      "@CTEClave", CTEClave, _
                      "@CAJClave", CAJClave, _
                      "@Folio", Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes), _
                      "@Atendio", ModPOS.UsuarioActual, _
                      "@porComision", CDbl(TxtPorc.Text), _
                      "@Total", Total)

        If Cajon = True Then
            AbrirCajon(Impresora)
        End If

        imprimeRecibo(Total, Referencia & "-" & CStr(Folio), Impresora, Me.PrintGeneric, Ticket, RazonSocial)


        Dim StopPrint As Boolean = False
        Do
            Select Case MessageBox.Show("¿Desea Reimprimir el Ticket de Pago de Comisión?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    imprimeRecibo(Total, Referencia & "-" & CStr(Folio), Impresora, Me.PrintGeneric, Ticket, RazonSocial)
                Case Else
                    StopPrint = True
            End Select
        Loop While Not StopPrint
        Me.Grabado = True
        Me.Close()
    End Sub

    Private Function imprimeRecibo(ByVal Comision As Double, ByVal sFolio As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Cte As String) As Boolean
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
        Tickets.AddSubHeaderLine("PAGO DE COMISION", 1, 3)
        Tickets.AddSubHeaderLine("A: " & Cte, 0, 3)

        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

        Tickets.AddSubHeaderBloqLine("FOLIO: " & sFolio, 0, 1)


        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtPagosDetalle As DataTable
        dtPagosDetalle = ModPOS.SiExisteRecupera("sp_detalle_com", "@COVClave", COVClave)

        If Not dtPagosDetalle Is Nothing Then
            Dim i As Integer = 0
            dPagos = dtPagosDetalle.Rows.Count()
            For i = 0 To dPagos - 1
                Dim sFolioS As String = dtPagosDetalle.Rows(i)("Folio")
                Dim sTipo As String = String.Format("{0:dd-MM-yyyy}", dtPagosDetalle.Rows(i)("Fecha"))
                Dim dImporte As Double = dtPagosDetalle.Rows(i)("Total")


                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemRecibo(sFolioS, sTipo, dImporte)

                dTotalPagos += (dImporte)
            Next
            dtPagosDetalle.Dispose()
        End If

        'El metodo AddTotalRecibo requiere 4 parametros 
        '  Tickets.AddTotalRecibo(dTotalPagos, 0, 0, 1)
        Tickets.AddFooterLine("PAGO : " & Format(CStr(ModPOS.Redondear(Comision, 2)), "Currency"), 1, 2)

        Tickets.AddFooterLine("GRACIAS POR SU PREFERENCIA", 0, 3)

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function


    Private Sub FrmComisionVta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ComisionVtaCreada AndAlso Not Grabado Then
            ModPOS.Ejecuta("sp_elimina_comisionvta", _
                    "@COVClave", COVClave)
        End If
        ModPOS.ComisionVta.Dispose()
        ModPOS.ComisionVta = Nothing
    End Sub

    Private Sub TxtPorc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPorc.Leave
        If Subtotal > 0 And CDbl(TxtPorc.Text) > 0 Then
            Total = Redondear((CDbl(TxtPorc.Text) / 100) * Subtotal, 2)
            TxtTotal.Text = Format(Total.ToString, "Currency") & " " & MONRefBase
        End If
    End Sub

   
  
End Class
