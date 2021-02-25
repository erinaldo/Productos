

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
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnReFac As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnMasiva As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnFacGlobal As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoFacturas))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.btnFacGlobal = New Janus.Windows.EditControls.UIButton()
        Me.btnMasiva = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnSend = New Janus.Windows.EditControls.UIButton()
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReFac = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridFacturas = New Janus.Windows.GridEX.GridEX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.btnFacGlobal)
        Me.GrpTickets.Controls.Add(Me.btnMasiva)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.BtnSend)
        Me.GrpTickets.Controls.Add(Me.BtnFacturar)
        Me.GrpTickets.Controls.Add(Me.BtnReFac)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.BtnConsultar)
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
        Me.GrpTickets.Size = New System.Drawing.Size(784, 561)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Facturas"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 19)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 56
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'btnFacGlobal
        '
        Me.btnFacGlobal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFacGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacGlobal.Image = CType(resources.GetObject("btnFacGlobal.Image"), System.Drawing.Image)
        Me.btnFacGlobal.Location = New System.Drawing.Point(110, 518)
        Me.btnFacGlobal.Name = "btnFacGlobal"
        Me.btnFacGlobal.Size = New System.Drawing.Size(90, 37)
        Me.btnFacGlobal.TabIndex = 55
        Me.btnFacGlobal.Text = "Fac. Global"
        Me.btnFacGlobal.ToolTipText = "Realiza la facturacion global de varios documentos  seleccionados."
        Me.btnFacGlobal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnMasiva
        '
        Me.btnMasiva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMasiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasiva.Image = CType(resources.GetObject("btnMasiva.Image"), System.Drawing.Image)
        Me.btnMasiva.Location = New System.Drawing.Point(206, 518)
        Me.btnMasiva.Name = "btnMasiva"
        Me.btnMasiva.Size = New System.Drawing.Size(90, 37)
        Me.btnMasiva.TabIndex = 54
        Me.btnMasiva.Text = "Fac.Masiva"
        Me.btnMasiva.ToolTipText = "Realiza la facturacion individual de varios documentos  seleccionados."
        Me.btnMasiva.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(6, 518)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(302, 518)
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
        Me.PictureBox2.Location = New System.Drawing.Point(569, 19)
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
        Me.BtnSend.Location = New System.Drawing.Point(398, 518)
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
        Me.BtnFacturar.Location = New System.Drawing.Point(688, 518)
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
        Me.BtnReFac.Location = New System.Drawing.Point(496, 518)
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
        Me.Label3.Location = New System.Drawing.Point(532, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Periodo"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnConsultar.Location = New System.Drawing.Point(592, 518)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 9
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.ToolTipText = "Mostrar factura seleccionada"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(592, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(185, 22)
        Me.dtPicker.TabIndex = 52
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(144, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(169, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(357, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(101, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridFacturas
        '
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
        Me.GridFacturas.Size = New System.Drawing.Size(770, 467)
        Me.GridFacturas.TabIndex = 2
        Me.GridFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmMtoFacturas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
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
    Private VersionCF As String

    Private ALMClave As String = ""
    Private InterfazSalida, sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private FormatoFactura As String

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False
  
    Private TipoCF As Integer
  
    Private dtPAC As DataTable

    Private Autoriza As String
    Private sSUCClave As String
    Private dtFacturas As DataTable

    Public Sub refrescaGrid()



        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If


        If Not dtFacturas Is Nothing Then
            dtFacturas.Dispose()
        End If

        dtFacturas = ModPOS.Recupera_Tabla("sp_muestra_facturas", "@Sucursal", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridFacturas.DataSource = dtFacturas
        GridFacturas.RetrieveStructure()
        GridFacturas.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."


        Me.GridFacturas.RootTable.Columns("FACClave").Visible = False
        Me.GridFacturas.RootTable.Columns("TipoCF").Visible = False
        Me.GridFacturas.RootTable.Columns("RFC").Visible = False
        Me.GridFacturas.RootTable.Columns("CTEClave").Visible = False

        If TipoCF = 2 Then
            Me.GridFacturas.RootTable.Columns("uuid").Visible = True
        Else
            Me.GridFacturas.RootTable.Columns("uuid").Visible = False
        End If


        Me.GridFacturas.RootTable.Columns("Logo").Visible = False

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
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
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

    Private Sub GridFacturas_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridFacturas.CellValueChanged
        dtFacturas.AcceptChanges()

        GridFacturas.Refresh()
    End Sub

    Private Sub GridFacturas_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridFacturas.CurrentCellChanged
        If Not GridFacturas.CurrentColumn Is Nothing Then
            If GridFacturas.CurrentColumn.Caption = "Marca" Then
                GridFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridFacturas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridFacturas.DoubleClick
        If Not GridFacturas.GetValue(0) Is Nothing Then
            Dim sFACClave As String = GridFacturas.GetValue("FACClave")
            If GridFacturas.GetValue("Estado") = "Pendiente" Then
                Dim iTipoPAC As Integer
                If MessageBox.Show("El documento seleccionado se encuentra pendiente de Certificación, ¿deseas intentar nuevamente?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

                    iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, GridFacturas.GetValue("Folio"), sFACClave, "ingreso", Nothing, Nothing, Nothing, 1, InterfazSalida)

                    If iTipoPAC <> 0 Then
                        Me.refrescaGrid()
                    End If
                Else
                    muestraPedidos(sFACClave)
                End If 'Desea Certificacion
            Else
                muestraPedidos(sFACClave)
            End If 'Estado Pendiente

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


    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtFacturas.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then



            Dim MonRef, MonDesc, sVersionCF As String
            Dim TipoCambio As Double
            Dim dt As DataTable
            Dim sFormato As String

            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(0)("FACClave"))
            TipoCambio = dt.Rows(0)("TipoCambio")
            MonRef = dt.Rows(0)("Referencia")
            MonDesc = dt.Rows(0)("Descripcion")
            sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
            sVersionCF = dt.Rows(0)("VersionCF")

            dt.Dispose()

            Dim iTipoCF As Integer = IIf(foundRows(0)("TipoCF").GetType.Name = "DBNull", 1, foundRows(0)("TipoCF"))

            ModPOS.previewFactura(iTipoCF, sFormato, foundRows(0)("FACClave"), foundRows(0)("Total"), sSUCClave, TipoCambio, MonDesc, MonRef, sVersionCF, foundRows(0)("Logo"))

        Else
            MessageBox.Show("Debe marcar solo 1 registro para poder visualizar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


 

    Private Sub BtnReFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReFac.Click
        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtFacturas.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            Dim sImpresora As String
            Dim iCopias As Integer
           
                If PrintDialog1.ShowDialog() = DialogResult.OK Then
                sImpresora = PrintDialog1.PrinterSettings.PrinterName
                iCopias = PrintDialog1.PrinterSettings.Copies
                Else
                    Exit Sub
                End If


            For i = 0 To foundRows.GetUpperBound(0)

                Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                Dim MonRef, MonDesc, sFormato, sVersionCF As String
                Dim TipoCambio As Double
                Dim dt As DataTable


                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("FACClave"))
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
                sVersionCF = dt.Rows(0)("VersionCF")
                dt.Dispose()

                ModPOS.imprimirFactura(iTipoCF, sFormato, foundRows(i)("FACClave"), foundRows(i)("Total"), sSUCClave, TipoCambio, MonDesc, MonRef, sImpresora, iCopias, sVersionCF, foundRows(i)("Logo"))

                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False


        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If validaForm() Then

            Dim foundRows() As DataRow

            ' Usa el metodo select para filtrar los registros seleccionados.
            foundRows = dtFacturas.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then

             
                Dim PathPDF As String
                Dim i As Integer
                Dim frmStatusMessage As New frmStatus

                Dim MonRef, MonDesc, sVersionCF As String
                Dim TipoCambio As Double
                Dim dt As DataTable
                Dim eMailCte As String = ""
                Dim sMailCliente As String = ""

                Dim sClienteActual As String = ""

                Dim sError As String = ""

                For i = 0 To foundRows.GetUpperBound(0)


                    If sClienteActual <> foundRows(i)("Clave") Then
                        Dim dtmail As DataTable
                        'Recupera correo electronico

                        dtmail = ModPOS.Recupera_Tabla("sp_recupera_mail", "@Clave", foundRows(i)("FACClave"), "@Tipo", 1)
                        eMailCte = dtmail.Rows(0)("Email")
                        dtmail.Dispose()

                        sClienteActual = foundRows(i)("Clave")

                        If eMailCte = "" OrElse eMailCte <> sMailCliente Then
                            Dim m As New FrmCorreo
                            m.eMail = eMailCte
                            m.Folio = " Folio: " & foundRows(i)("Folio") & " Cliente: " & foundRows(i)("Clave")
                            m.ShowDialog()
                            If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                eMailCte = m.Correo
                            Else
                                eMailCte = "Salir"
                            End If
                            m.Dispose()
                        End If


                    End If

                 

                    If eMailCte <> "" Then
                        If eMailCte <> "Salir" Then

                            PathPDF = pathActual & "Temp\" & foundRows(i)("Folio") & ".PDF"

                            Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                            'Genera PDF

                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("FACClave"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            sVersionCF = dt.Rows(0)("VersionCF")
                            Dim sFormato As String
                            sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))

                            dt.Dispose()

                            sError = ModPOS.SendMail(sVersionCF, eMailCte, iTipoCF, sFormato, foundRows(i)("Fecha"), foundRows(i)("Folio"), foundRows(i)("FACClave"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, sSUCClave, TipoCambio, MonRef, MonDesc, foundRows(i)("Logo"), IIf(foundRows.Length = 1, True, False))

                            If sError <> "" AndAlso foundRows.Length > 1 Then
                                MessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If


                        End If
                        foundRows(i)("Marca") = False
                    Else
                        MessageBox.Show("El cliente " & foundRows(i)("Clave").ToString & ", no cuenta con dirección de correo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
                frmStatusMessage.Dispose()
                ChkMarcaTodos.Checked = False
              
            Else
                MessageBox.Show("Para reenviar, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtFacturas.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then


            If foundRows(0)("Estado") = "Cancelada" Then
                MessageBox.Show("El documento seleccionado ya se encuentra Cancelado")
                Exit Sub
            End If



            Dim dt As DataTable

            'Valida que no tenga abonos aplicados, que el total sea igual al saldo

            If TipoCF = 1 OrElse TipoCF = 3 Then
                If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                    MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If CmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("La Sucursal no es valida o es requerida")
                Exit Sub
            End If
            'Recupera Almacen

            dt = Recupera_Tabla("sp_recupera_almfac", "@FACClave", foundRows(0)("FACClave"))
            ALMClave = dt.Rows(0)("ALMClave")
            dt.Dispose()

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion

                    a.Sucursal = CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = foundRows(0)("Total") * foundRows(0)("TipoCambio")
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza

                            Dim bmotivo As Boolean = False
                            Dim MotCancelacion As Integer
                            Dim bCancela As Boolean

                            Do
                                Dim m As New FrmMotivo
                                m.Tabla = "Factura"
                                m.Campo = "Cancelacion"
                                m.ShowDialog()
                                If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                    bmotivo = True
                                    MotCancelacion = m.Motivo
                                End If
                                m.Dispose()
                            Loop While bmotivo = False

                            Dim eRFC, rRFC, sCTEClave, CAJClave, Stage As String
                            Dim dTotal, dSaldo As Decimal

                            dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(0)("FACClave"))
                            eRFC = dt.Rows(0)("cRFC")
                            rRFC = dt.Rows(0)("id_Fiscal")
                            sCTEClave = dt.Rows(0)("CTEClave")
                            dTotal = dt.Rows(0)("total")
                            dSaldo = dt.Rows(0)("saldo")
                            CAJClave = dt.Rows(0)("CAJClave")
                            VersionCF = dt.Rows(0)("VersionCF")

                            dt.Dispose()


                            Dim sUUID As String = IIf(foundRows(0)("uuid").GetType.Name = "DBNull", "", foundRows(0)("uuid"))

                            If TipoCF = 2 AndAlso foundRows(0)("Estado") = "Activa" Then

                                If Math.Round(dTotal, 2) <> Math.Round(dSaldo, 2) Then
                                    MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If


                                bCancela = ModPOS.cancelarXML(dtPAC, foundRows(0)("Folio"), sUUID, eRFC, VersionCF, 2, foundRows(0)("FACClave"))
                                If bCancela = False Then
                                    Exit Sub
                                End If

                            ElseIf foundRows(0)("Estado") = "Espera" Then
                                bCancela = ModPOS.ObtenerEspera(dtPAC, rRFC, 2, foundRows(0)("FACClave"), sUUID)

                                If bCancela = False Then
                                    Exit Sub
                                End If
                            End If

                            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
                            Stage = IIf(dt.Rows(0)("StageCancelacion").GetType.Name <> "DBNull", dt.Rows(0)("StageCancelacion"), "")
                            dt.Dispose()

                            ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", foundRows(0)("FACClave"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                            If Stage <> "" Then
                                ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)("FACClave"), ALMClave, foundRows(0)("Folio"), Autoriza, 1, Stage)
                            Else
                                ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)("FACClave"), ALMClave, foundRows(0)("Folio"), Autoriza)
                            End If

                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal * foundRows(0)("TipoCambio"))
                            ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("FACClave"), "@Tipo", 2)


                            If TipoCF = 2 AndAlso foundRows(0)("Estado") <> "Activa" Then
                                ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)("FACClave"))
                            End If

                            If InterfazSalida <> "" AndAlso bCancela = True Then
                                Dim sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionFactura", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(0)("FACClave"), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                End If

                            End If

                            refrescaGrid()

                        End If
                    End If
            End Select
        Else
            MessageBox.Show("Debe marcar solo 1 registro para poder Cancelar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub btnMasiva_Click(sender As Object, e As EventArgs) Handles btnMasiva.Click
        If validaForm() Then
            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_filtra_caja", "@Sucursal", CmbSucursal.SelectedValue)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Dispose()

                Dim a As New FrmMasiva

                a.SUCClave = CmbSucursal.SelectedValue
                a.ShowDialog()
                a.Dispose()
                If validaForm() Then
                    refrescaGrid()
                End If
            Else
                MessageBox.Show("El Almacén o Sucursal seleccionada no tiene una Caja disponible para Facturar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles btnFacGlobal.Click
        If validaForm() Then
            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_filtra_caja", "@Sucursal", CmbSucursal.SelectedValue)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Dispose()

                Dim a As New FrmFacGlobal

                a.SUCClave = CmbSucursal.SelectedValue
                a.ShowDialog()
                a.Dispose()
                If validaForm() Then
                    refrescaGrid()
                End If
            Else
                MessageBox.Show("El Almacén o Sucursal seleccionada no tiene una Caja disponible para Facturar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub



    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtFacturas.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then

                For i = 0 To GridFacturas.GetDataRows.Length - 1
                    GridFacturas.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridFacturas.GetDataRows.Length - 1
                    GridFacturas.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtFacturas.AcceptChanges()

            GridFacturas.Refresh()
        End If
    End Sub

    Private Sub GridFacturas_Click(sender As Object, e As EventArgs) Handles GridFacturas.Click
        If Not GridFacturas.CurrentColumn Is Nothing Then
            If GridFacturas.CurrentColumn.Caption <> "Marca" And Not GridFacturas.GetValue("Marca") Is Nothing Then
                If GridFacturas.GetValue("Marca") = False Then
                    GridFacturas.SetValue("Marca", True)
                Else
                    GridFacturas.SetValue("Marca", False)
                End If
                dtFacturas.AcceptChanges()
                GridFacturas.Refresh()

            End If
        End If
    End Sub

  
End Class
