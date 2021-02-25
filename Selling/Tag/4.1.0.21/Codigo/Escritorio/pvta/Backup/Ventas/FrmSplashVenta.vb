Public Class FrmSplashVenta
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbPuntodeVenta As Selling.StoreCombo
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents BtnUsuario As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents GrpVenta As System.Windows.Forms.GroupBox
    Friend WithEvents GrpUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Lbluser As System.Windows.Forms.Label
    Friend WithEvents LblPwd As System.Windows.Forms.Label
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplashVenta))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnUsuario = New Janus.Windows.EditControls.UIButton
        Me.LblUsuario = New System.Windows.Forms.Label
        Me.GrpSucursal = New System.Windows.Forms.GroupBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.GrpVenta = New System.Windows.Forms.GroupBox
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton
        Me.cmbPuntodeVenta = New Selling.StoreCombo
        Me.GrpUsuario = New System.Windows.Forms.GroupBox
        Me.TxtLogin = New System.Windows.Forms.TextBox
        Me.TxtPassword = New System.Windows.Forms.TextBox
        Me.Lbluser = New System.Windows.Forms.Label
        Me.LblPwd = New System.Windows.Forms.Label
        Me.GrpSucursal.SuspendLayout()
        Me.GrpVenta.SuspendLayout()
        Me.GrpUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'BtnCancel
        '
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Name = "BtnCancel"
        '
        'BtnOk
        '
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Name = "BtnOk"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'BtnUsuario
        '
        resources.ApplyResources(Me.BtnUsuario, "BtnUsuario")
        Me.BtnUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUsuario.Image = Global.Selling.My.Resources.Resources.wi0102_48
        Me.BtnUsuario.Name = "BtnUsuario"
        '
        'LblUsuario
        '
        resources.ApplyResources(Me.LblUsuario, "LblUsuario")
        Me.LblUsuario.Name = "LblUsuario"
        '
        'GrpSucursal
        '
        Me.GrpSucursal.Controls.Add(Me.CmbSucursal)
        resources.ApplyResources(Me.GrpSucursal, "GrpSucursal")
        Me.GrpSucursal.Name = "GrpSucursal"
        Me.GrpSucursal.TabStop = False
        '
        'CmbSucursal
        '
        resources.ApplyResources(Me.CmbSucursal, "CmbSucursal")
        Me.CmbSucursal.Name = "CmbSucursal"
        '
        'GrpVenta
        '
        Me.GrpVenta.Controls.Add(Me.BtnAbrir)
        Me.GrpVenta.Controls.Add(Me.cmbPuntodeVenta)
        resources.ApplyResources(Me.GrpVenta, "GrpVenta")
        Me.GrpVenta.Name = "GrpVenta"
        Me.GrpVenta.TabStop = False
        '
        'BtnAbrir
        '
        resources.ApplyResources(Me.BtnAbrir, "BtnAbrir")
        Me.BtnAbrir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Name = "BtnAbrir"
        '
        'cmbPuntodeVenta
        '
        resources.ApplyResources(Me.cmbPuntodeVenta, "cmbPuntodeVenta")
        Me.cmbPuntodeVenta.Name = "cmbPuntodeVenta"
        '
        'GrpUsuario
        '
        Me.GrpUsuario.Controls.Add(Me.LblUsuario)
        Me.GrpUsuario.Controls.Add(Me.BtnUsuario)
        resources.ApplyResources(Me.GrpUsuario, "GrpUsuario")
        Me.GrpUsuario.Name = "GrpUsuario"
        Me.GrpUsuario.TabStop = False
        '
        'TxtLogin
        '
        resources.ApplyResources(Me.TxtLogin, "TxtLogin")
        Me.TxtLogin.Name = "TxtLogin"
        '
        'TxtPassword
        '
        resources.ApplyResources(Me.TxtPassword, "TxtPassword")
        Me.TxtPassword.Name = "TxtPassword"
        '
        'Lbluser
        '
        resources.ApplyResources(Me.Lbluser, "Lbluser")
        Me.Lbluser.Name = "Lbluser"
        '
        'LblPwd
        '
        resources.ApplyResources(Me.LblPwd, "LblPwd")
        Me.LblPwd.Name = "LblPwd"
        '
        'FrmSplashVenta
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LblPwd)
        Me.Controls.Add(Me.Lbluser)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.GrpUsuario)
        Me.Controls.Add(Me.GrpVenta)
        Me.Controls.Add(Me.GrpSucursal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSplashVenta"
        Me.ShowInTaskbar = False
        Me.GrpSucursal.ResumeLayout(False)
        Me.GrpVenta.ResumeLayout(False)
        Me.GrpUsuario.ResumeLayout(False)
        Me.GrpUsuario.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Public Caja As Boolean = False
    Public FrmPadre As String = ""
    Private bCambiaUsuario As Boolean = False
    Private sPDVClave As String = ""
    Private Tipo As Integer
    Private Cargado As Boolean = False
    Private fase As Integer
    Private SUCClave As String

    Private Sub FrmSplashVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        If FrmPadre = "Verificar" Then
            fase = 1
        Else
            fase = 0
        End If

        LblUsuario.Text = MPrincipal.StUsuario.Text

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

        SUCClave = CmbSucursal.SelectedValue

        Cargado = True



        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("No se encontro una sucursal disponible para el punto de venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If FrmPadre = "Caja" Then
            With cmbPuntodeVenta
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_caja"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
            Tipo = 2
        Else
            With cmbPuntodeVenta
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .NombreParametro2 = "Fase"
                .Parametro2 = fase
                .llenar()
            End With
            Tipo = 1
        End If

        Dim pdv As DataTable = ModPOS.Recupera_Tabla("sp_procesador_pdv", "@Procesador", ModPOS.GetProcessorId, "@Tipo", Tipo)

        If pdv.Rows.Count > 0 Then
            If Tipo = 1 Then
                cmbPuntodeVenta.SelectedValue = pdv.Rows(0)("PDVClave")
                sPDVClave = pdv.Rows(0)("PDVClave")
            Else
                cmbPuntodeVenta.SelectedValue = pdv.Rows(0)("CAJClave")
                sPDVClave = pdv.Rows(0)("CAJClave")
            End If
        Else
            sPDVClave = ""
        End If
        pdv.Dispose()

        Cursor.Current = Cursors.Default

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Entrar()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Entrar()

        Dim dt As DataTable

        If FrmPadre = "Verificar" Then


            dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", cmbPuntodeVenta.SelectedValue)

            If dt.Rows(0)("Tipo") = 1 Then 'Venta
                Dim a As New FrmConsultaPrecio
                a.ClienteActual = dt.Rows(0)("CTEClave")
                a.NombreClienteActual = dt.Rows(0)("Cliente")
                a.Almacen = dt.Rows(0)("ALMClave")
                a.Width = Screen.PrimaryScreen.Bounds.Width
                a.Height = Screen.PrimaryScreen.Bounds.Height
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()
                a.Dispose()
                Me.Close()
            End If

        Else

            Dim dtLicenciasUsadas As DataTable
            Dim LicenciasUsadas As Integer
            dtLicenciasUsadas = ModPOS.Recupera_Tabla("recupera", "@COMClave", ModPOS.CompanyActual)

            LicenciasUsadas = dtLicenciasUsadas.Rows(0)("Activas")
            If LicenciasUsadas >= ModPOS.Licencias Then
                Beep()
                MessageBox.Show("La caja/punto de venta que intenta abrir excede el maximo número de licencia para uso, solicite a su proveedor incrementar su número de licencias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not CmbSucursal.SelectedValue Is Nothing Then

                If Not cmbPuntodeVenta.SelectedValue Is Nothing Then


                    If bCambiaUsuario Then

                        Dim dtUsuario As DataTable

                        dtUsuario = ModPOS.SiExisteRecupera("sp_valida_Usr", "@Login", UCase(Trim(Me.TxtLogin.Text.Replace("'", "''"))))

                        If Not dtUsuario Is Nothing Then
                            If TxtPassword.Text.Trim = ModPOS.DecryptText(dtUsuario.Rows(0)("Password"), "AlpeGroup") Then
                                ModPOS.UsuarioLogin = UCase(Trim(Me.TxtLogin.Text))

                                dt = ModPOS.Recupera_Tabla("sp_load_usuario", "@Login", ModPOS.UsuarioLogin)
                                ModPOS.UsuarioActual = dt.Rows(0)("USRClave")
                                MPrincipal.StUsuario.Text = dt.Rows(0)("Nombre")
                                dt.Dispose()
                                dtUsuario.Dispose()
                            Else
                                Beep()
                                MessageBox.Show("El Usuario o la Contraseña no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                dtUsuario.Dispose()
                                Exit Sub
                            End If
                        Else
                            Beep()
                            MessageBox.Show("El Usuario o la Contraseña no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                    End If

                    If FrmPadre = "Caja" Then
                        Dim Fase As Integer
                        Dim Recibo As String
                        Dim TICDevolucion As String
                        Dim Impresora As String
                        Dim PrintGeneric As Boolean
                        Dim ImpresoraFac As String
                        Dim ALMClave As String
                        Dim SUCClave As String
                        Dim Referencia As String
                        Dim LEfectivo, LCheques, LVales As Double
                        Dim Manual As Integer
                        Dim Cajon As Boolean
                        Dim Aplicacion As String
                        Dim PRNClavePic As String
                        Dim CorteDetallado As Integer

                        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", cmbPuntodeVenta.SelectedValue)

                        Fase = dt.Rows(0)("Fase")
                        Recibo = dt.Rows(0)("TIKClave")
                        TICDevolucion = dt.Rows(0)("TICDevolucion")
                        LEfectivo = dt.Rows(0)("LimiteEfectivo")
                        LCheques = dt.Rows(0)("LimiteCheque")
                        LVales = dt.Rows(0)("LimiteVale")
                        Impresora = dt.Rows(0)("Referencia")
                        PrintGeneric = dt.Rows(0)("Generic")
                        ImpresoraFac = dt.Rows(0)("ImpresoraFac")
                        ALMClave = dt.Rows(0)("ALMClave")
                        Referencia = dt.Rows(0)("Clave")
                        SUCClave = dt.Rows(0)("SUCClave")

                        Manual = IIf(dt.Rows(0)("Manual").GetType.Name = "DBNull", 0, dt.Rows(0)("Manual"))
                        Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))
                        Aplicacion = IIf(dt.Rows(0)("url_aplicacion").GetType.Name = "DBNull", "", dt.Rows(0)("url_aplicacion"))
                        PRNClavePic = IIf(dt.Rows(0)("PRNClavePic").GetType.Name = "DBNull", "", dt.Rows(0)("PRNClavePic"))
                        CorteDetallado = (IIf(dt.Rows(0)("CorteDetallado").GetType.Name = "DBNull", 0, dt.Rows(0)("CorteDetallado")))

                        dt.Dispose()


                        If Fase = 0 Then
                            ModPOS.Ejecuta("sp_act_caja", "@CAJClave", cmbPuntodeVenta.SelectedValue, "@Fase", 1)

                            If ModPOS.MtoCXC Is Nothing Then
                                ModPOS.MtoCXC = New FrmTCaja
                                ModPOS.MtoCXC.CAJClave = cmbPuntodeVenta.SelectedValue
                                ModPOS.MtoCXC.Clave = Referencia
                                ModPOS.MtoCXC.LblDescripcion.Text = cmbPuntodeVenta.Text
                                ModPOS.MtoCXC.LblUsuario.Text = MPrincipal.StUsuario.Text
                                ModPOS.MtoCXC.ALMClave = ALMClave
                                ModPOS.MtoCXC.Recibo = Recibo
                                ModPOS.MtoCXC.TICDevolucion = TICDevolucion
                                ModPOS.MtoCXC.Impresora = Impresora
                                ModPOS.MtoCXC.PrintGeneric = PrintGeneric
                                ModPOS.MtoCXC.ImpresoraFac = ImpresoraFac
                                ModPOS.MtoCXC.LEfectivo = LEfectivo
                                ModPOS.MtoCXC.LCheques = LCheques
                                ModPOS.MtoCXC.LVales = LVales
                                ModPOS.MtoCXC.SUCClave = SUCClave
                                ModPOS.MtoCXC.Manual = Manual
                                ModPOS.MtoCXC.Cajon = Cajon
                                ModPOS.MtoCXC.Aplicacion = Aplicacion
                                ModPOS.MtoCXC.PRNClavePic = PRNClavePic
                                ModPOS.MtoCXC.CorteDetallado = CorteDetallado
                            End If
                            ModPOS.MtoCXC.Width = Screen.PrimaryScreen.Bounds.Width
                            ModPOS.MtoCXC.Height = Screen.PrimaryScreen.Bounds.Height
                            ModPOS.MtoCXC.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.MtoCXC.ShowDialog()
                        Else
                            MessageBox.Show("La Caja seleccionada ya se encuentra Abierta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                        Me.Close()

                    Else
                        ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", cmbPuntodeVenta.SelectedValue, "@Fase", 1)

                        dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", cmbPuntodeVenta.SelectedValue)

                        If dt.Rows(0)("Tipo") = 1 Then 'Venta

                            If ModPOS.Venta Is Nothing Then
                                ModPOS.Venta = New FrmTPDV

                                With ModPOS.Venta

                                    Dim dtVenta As DataTable
                                   
                                    .ALMClave = dt.Rows(0)("ALMClave")
                                    .AlmacenClave = dt.Rows(0)("Clave")
                                    .AlmacenNombre = dt.Rows(0)("Nombre")
                                    .PDVClave = dt.Rows(0)("PDVClave")
                                    .PuntodeVenta = dt.Rows(0)("Descripcion")
                                    .Referencia = dt.Rows(0)("Referencia")
                                    .Impresora = dt.Rows(0)("Impresora")
                                    .Ticket = dt.Rows(0)("Ticket")
                                    .Supervisor = dt.Rows(0)("Supervisor")
                                    .Caja = dt.Rows(0)("Caja")

                                    .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                                    .CAJClave = dt.Rows(0)("CAJClave")
                                    .CTEClaveInicial = dt.Rows(0)("CTEClave")
                                    .CTENombreInicial = dt.Rows(0)("Cliente")

                                    .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                                    .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                                    .Redondeo = dt.Rows(0)("Redondeo")
                                    .Agotamiento = dt.Rows(0)("Agotamiento")
                                    .SolicitaVendedor = dt.Rows(0)("SolicitaVendedor")
                                    .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
                                    .LblFolio.Text = .Referencia & "- 0"
                                    .PrintGeneric = dt.Rows(0)("Generic")
                                    .sFrase = dt.Rows(0)("Frase")
                                    .ActivaDevolucion = dt.Rows(0)("Devolucion")
                                    .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                                    .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

                                    .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))
                                    .PRNClavePic = IIf(dt.Rows(0)("PRNClavePic").GetType.Name = "DBNull", "", dt.Rows(0)("PRNClavePic"))
                                    .Display = IIf(dt.Rows(0)("PoleDisplay").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("PoleDisplay"))))
                                    .Port = IIf(dt.Rows(0)("Puerto").GetType.Name = "DBNull", "COM5", dt.Rows(0)("Puerto"))
                                    .BaudRate = IIf(dt.Rows(0)("BaudRate").GetType.Name = "DBNull", 9600, dt.Rows(0)("BaudRate"))
                                    .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
                                    .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))
                                    .ActivarCotizacion = IIf(dt.Rows(0)("ActivarCotizacion").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ActivarCotizacion"))))
                                    .GridView = IIf(dt.Rows(0)("GridView").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("GridView"))))
                                    .SucursalSurtido = dt.Rows(0)("SUCClave")
                                    .TipoVenta = IIf(dt.Rows(0)("TipoVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoVenta"))

                                    .txtLimite.Text = dt.Rows(0)("LimiteCredito")
                                    .txtDias.Text = dt.Rows(0)("DiasCredito")
                                    .txtSaldo.Text = dt.Rows(0)("SaldoCliente")

                                   
                                    dt.Dispose()


                                    ' ModPOS.Ejecuta("sp_actualiza_ventaopen", "@PDVClave", .PDVClave)

                                    dtVenta = ModPOS.SiExisteRecupera("sp_recupera_ventaopen", "@PDVClave", .PDVClave)

                                    If dtVenta Is Nothing Then
                                        .BtnCliente.Enabled = False
                                        .btnBuscaCte.Enabled = False
                                        .BtnCancelaProducto.Enabled = False
                                        .BtnCancelaTicket.Enabled = False
                                        .btnEnvio.Enabled = False
                                        .BtnCerrar.Enabled = False
                                        .TxtCantidad.Enabled = False
                                        .TxtProducto.Enabled = False
                                        .TxtCliente.Enabled = False
                                    Else
                                        'recupera ticket
                                        .VentaAbierta = True
                                        .VENClave = dtVenta.Rows(0)("VENClave")
                                        .sFolio = dtVenta.Rows(0)("Folio")
                                        .CTEClaveActual = dtVenta.Rows(0)("Cliente")
                                        .CTENombreActual = dtVenta.Rows(0)("RazonSocial")
                                        .AtiendeClave = dtVenta.Rows(0)("Cajero")
                                        .AtiendeNombre = dtVenta.Rows(0)("NombreUsuario")
                                        .SaldoVenta = dtVenta.Rows(0)("Saldo")
                                        .TotalVenta = dtVenta.Rows(0)("Total")
                                        .TipoDocumento = dtVenta.Rows(0)("Tipo")
                                        .EstadoDocumento = dtVenta.Rows(0)("Estado")
                                        .NoVtaOpen = dtVenta.Rows.Count
                                        .txtLimite.Text = dtVenta.Rows(0)("LimiteCredito")
                                        .txtDias.Text = dtVenta.Rows(0)("DiasCredito")
                                        .txtSaldo.Text = dtVenta.Rows(0)("SaldoCliente")
                                        .AlmacenOpen = IIf(dt.Rows(0)("ALMClave").GetType.Name = "DBNull", .ALMClave, dt.Rows(0)("ALMClave"))
                                       
                                        ' .recuperaVentaOpen(VENClave,sFolio,CTEClaveActual,CTENombreActual, AtiendeClave,AtiendeNombre,SaldoVenta, TotalVenta, TipoDocumento, EstadoDocumento, txtLimite.Text, txtDias.Text, txtSaldo.Text,NoVtaOpen)

                                    End If

                                End With
                            End If

                            ModPOS.Venta.Width = Screen.PrimaryScreen.Bounds.Width
                            ModPOS.Venta.Height = Screen.PrimaryScreen.Bounds.Height
                            ModPOS.Venta.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Venta.ShowDialog()
                            Me.Close()
                        ElseIf dt.Rows(0)("Tipo") = 2 Then 'Preventa
                            If dt.Rows(0)("Caja") = True Then
                                If ModPOS.MtoVenta Is Nothing Then
                                    ModPOS.MtoVenta = New FrmMtoVenta
                                    With ModPOS.MtoVenta
                                        .StartPosition = FormStartPosition.CenterScreen

                                        .DiaTrabajo = Today
                                        .PDVClave = dt.Rows(0)("PDVClave")
                                        .CAJClave = dt.Rows(0)("CAJClave")
                                        .ALMClave = dt.Rows(0)("ALMClave")
                                        .SUCClave = CmbSucursal.SelectedValue
                                        .ClavePDV = dt.Rows(0)("Referencia")
                                        .NombrePDV = dt.Rows(0)("Descripcion")
                                        dt.Dispose()
                                    End With
                                End If

                                ModPOS.MtoVenta.Width = Screen.PrimaryScreen.Bounds.Width
                                ModPOS.MtoVenta.Height = Screen.PrimaryScreen.Bounds.Height
                                ModPOS.MtoVenta.StartPosition = FormStartPosition.CenterScreen
                                ModPOS.MtoVenta.ShowDialog()
                                Me.Close()
                            Else
                                If ModPOS.PreVenta Is Nothing Then
                                    ModPOS.PreVenta = New FrmTPV
                                    With ModPOS.PreVenta
                                        Dim sFrase As String
                                        .ALMClave = dt.Rows(0)("ALMClave")
                                        .PDVClave = dt.Rows(0)("PDVClave")
                                        .PuntodeVenta = dt.Rows(0)("Descripcion")
                                        .Referencia = dt.Rows(0)("Referencia")
                                        .Supervisor = dt.Rows(0)("Supervisor")
                                        .CTEClaveInicial = dt.Rows(0)("CTEClave")
                                        .CTENombreInicial = dt.Rows(0)("Cliente")
                                        .AtiendeClave = dt.Rows(0)("USRClave")
                                        .AtiendeNombre = dt.Rows(0)("Usuario")
                                        .USRCambiaPrecio = dt.Rows(0)("USRCambiaPrecio")
                                        .PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")
                                        .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                                        .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                                        .Redondeo = dt.Rows(0)("Redondeo")
                                        .Agotamiento = dt.Rows(0)("Agotamiento")
                                        .LblFolio.Text = .Referencia & "- 0"
                                        .CAJClave = dt.Rows(0)("CAJClave")
                                        sFrase = dt.Rows(0)("Frase")
                                        .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))
                                        .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))

                                        dt.Dispose()
                                    End With
                                End If
                                ModPOS.PreVenta.Width = Screen.PrimaryScreen.Bounds.Width
                                ModPOS.PreVenta.Height = Screen.PrimaryScreen.Bounds.Height
                                ModPOS.PreVenta.StartPosition = FormStartPosition.CenterScreen
                                ModPOS.PreVenta.ShowDialog()
                                Me.Close()
                            End If
                        ElseIf dt.Rows(0)("Tipo") = 5 Then ' Restaurant
                            If ModPOS.Plano Is Nothing Then
                                ModPOS.Plano = New FrmPlano

                                With ModPOS.Plano


                                    .SUCClave = Me.SUCClave
                                    .ALMClave = dt.Rows(0)("ALMClave")
                                    .PDVClave = dt.Rows(0)("PDVClave")
                                    .PuntodeVenta = dt.Rows(0)("Descripcion")
                                    .Referencia = dt.Rows(0)("Referencia")
                                    .Impresora = dt.Rows(0)("Impresora")
                                    .Ticket = dt.Rows(0)("Ticket")
                                    .Supervisor = dt.Rows(0)("Supervisor")
                                    .Caja = dt.Rows(0)("Caja")
                                    .CAJClave = dt.Rows(0)("CAJClave")
                                    .CTEClaveInicial = dt.Rows(0)("CTEClave")
                                    .CTENombreInicial = dt.Rows(0)("Cliente")
                                    .ActivaDevolucion = dt.Rows(0)("Devolucion")
                                    .CajeroClave = dt.Rows(0)("USRClave")
                                    .CajeroNombre = dt.Rows(0)("Usuario")

                                    .MeseroClave = dt.Rows(0)("USRClave")
                                    .MeseroNombre = dt.Rows(0)("Usuario")

                                    .USRCambiaPrecio = dt.Rows(0)("USRCambiaPrecio")
                                    .PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")
                                    .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                                    ' .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                                    .Redondeo = dt.Rows(0)("Redondeo")
                                    .Agotamiento = dt.Rows(0)("Agotamiento")
                                    .SolicitaVendedor = dt.Rows(0)("SolicitaVendedor")
                                    .Url_Redondeo = dt.Rows(0)("ImgRedondeo")

                                    .LblTitulo.Text = .PuntodeVenta
                                    .PrintGeneric = dt.Rows(0)("Generic")
                                    .Frase = dt.Rows(0)("Frase")
                                    .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

                                    .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))

                                    dt.Dispose()

                                End With
                            End If
                            ModPOS.Plano.Width = Screen.PrimaryScreen.Bounds.Width
                            ModPOS.Plano.Height = Screen.PrimaryScreen.Bounds.Height
                            ModPOS.Plano.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Plano.ShowDialog()
                            Me.Close()
                        ElseIf dt.Rows(0)("Tipo") = 4 Then ' Barra
                            If ModPOS.Touch Is Nothing Then
                                ModPOS.Touch = New FrmTouch

                                With ModPOS.Touch

                                    Dim dtComanda, dtComandaDetalle As DataTable
                                    .Tipo = 4
                                    .SUCClave = Me.SUCClave
                                    .ALMClave = dt.Rows(0)("ALMClave")
                                    .PDVClave = dt.Rows(0)("PDVClave")
                                    .PuntodeVenta = dt.Rows(0)("Descripcion")
                                    .Referencia = dt.Rows(0)("Referencia")
                                    .Impresora = dt.Rows(0)("Impresora")
                                    .Ticket = dt.Rows(0)("Ticket")
                                    .Supervisor = dt.Rows(0)("Supervisor")
                                    .Caja = dt.Rows(0)("Caja")
                                    .CAJClave = dt.Rows(0)("CAJClave")
                                    .CTEClaveInicial = dt.Rows(0)("CTEClave")
                                    .CTENombreInicial = dt.Rows(0)("Cliente")
                                    .ActivaDevolucion = dt.Rows(0)("Devolucion")
                                    .CajeroClave = dt.Rows(0)("USRClave")
                                    .CajeroNombre = dt.Rows(0)("Usuario")

                                    .MeseroClave = dt.Rows(0)("USRClave")
                                    .MeseroNombre = dt.Rows(0)("Usuario")

                                    .USRCambiaPrecio = dt.Rows(0)("USRCambiaPrecio")
                                    .PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")
                                    .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                                    ' .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
                                    .Redondeo = dt.Rows(0)("Redondeo")
                                    .Agotamiento = dt.Rows(0)("Agotamiento")
                                    .SolicitaVendedor = dt.Rows(0)("SolicitaVendedor")
                                    .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
                                    .LblFolio.Text = .Referencia & "- "
                                    .PrintGeneric = dt.Rows(0)("Generic")
                                    .sFrase = dt.Rows(0)("Frase")
                                    .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

                                    .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))

                                    .Display = IIf(dt.Rows(0)("PoleDisplay").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("PoleDisplay"))))
                                    .Port = IIf(dt.Rows(0)("Puerto").GetType.Name = "DBNull", "COM5", dt.Rows(0)("Puerto"))
                                    .BaudRate = IIf(dt.Rows(0)("BaudRate").GetType.Name = "DBNull", 9600, dt.Rows(0)("BaudRate"))
                                    .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
                                    .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))


                                    dt.Dispose()

                                    dtComanda = ModPOS.SiExisteRecupera("sp_recupera_comandawait", "@PDVClave", .PDVClave)

                                    If Not dtComanda Is Nothing Then
                                        .BtnEspera.Text = "Espera(1)"
                                    End If

                                    dtComanda = ModPOS.SiExisteRecupera("sp_recupera_comandaopen", "@PDVClave", .PDVClave, "@Tipo", 4)

                                    If dtComanda Is Nothing Then
                                        .activaBotones(4, False)
                                        .cambiaStatus("BIENVENIDO", FrmTouch.Status.Original)
                                    Else
                                        'recupera comanda
                                        .activaBotones(4, True)

                                        .TotalArticulos = 0
                                        .TotalPuntos = 0
                                        .TotalVenta = 0
                                        .TotalAhorro = 0


                                        'recupera ticket

                                        .CMDClave = dtComanda.Rows(0)("CMDClave")
                                        .LblFolio.Text = dtComanda.Rows(0)("Folio")
                                        .CTEClaveActual = dtComanda.Rows(0)("CTEClave")
                                        .CTENombreActual = dtComanda.Rows(0)("RazonSocial")
                                        .LblCliente.Text = .CTENombreActual

                                        .MeseroClave = dtComanda.Rows(0)("Mesero")
                                        .MeseroNombre = dtComanda.Rows(0)("NombreMesero")

                                        .CajeroClave = dtComanda.Rows(0)("Cajero")
                                        .CajeroNombre = dtComanda.Rows(0)("NombreCajero")

                                        .LblCajero.Text = .CajeroNombre
                                        .LblMesero.Text = .MeseroNombre

                                        Dim dtCliente As DataTable
                                        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", .CTEClaveActual)
                                        .ListaPrecio = dtCliente.Rows(0)("PREClave")
                                        .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                                        dtCliente.Dispose()


                                        'Recupera los descuentos de cliente
                                        Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", .CTEClaveActual)
                                        If Not dtDescCte Is Nothing Then
                                            .DescuentoCliente = dtDescCte.Rows(0)("Cascada")
                                            .PorcDescCliente = dtDescCte.Rows(0)("DescuentoPorc")
                                            dtDescCte.Dispose()
                                        Else
                                            .DescuentoCliente = -1
                                            .PorcDescCliente = 0
                                        End If

                                        If .CambiarCliente = False Then
                                            .BtnCliente.Enabled = False

                                            .TxtCliente.Enabled = False
                                        End If

                                        .cambiaStatus("COMANDA (ABIERTA)", -1)




                                        .ComandaCerrada = False
                                        .ComandaNueva = True
                                        .GeneraMovSalida = True

                                        dtComanda.Dispose()

                                        dtComandaDetalle = ModPOS.Recupera_Tabla("sp_comandadetalle_open", "@CMDClave", .CMDClave)

                                        .TotalArticulos = dtComandaDetalle.Rows.Count

                                        Dim i As Integer

                                        For i = 0 To dtComandaDetalle.Rows.Count - 1
                                            .TotalAhorro += ((dtComandaDetalle.Rows(i)("Descuento") * (1 + dtComandaDetalle.Rows(i)("PorcImpuesto"))) * dtComandaDetalle.Rows(i)("Cant."))
                                            .TotalPuntos += (dtComandaDetalle.Rows(i)("Puntos") * dtComandaDetalle.Rows(i)("Cant."))
                                            .TotalVenta += (dtComandaDetalle.Rows(i)("Subtotal"))
                                        Next
                                        dtComandaDetalle.Dispose()

                                        .LblTotal.Text = Format(CStr(ModPOS.Redondear(.TotalVenta, 2)), "Currency")

                                    End If

                                End With
                            End If

                            ModPOS.Touch.Width = Screen.PrimaryScreen.Bounds.Width
                            ModPOS.Touch.Height = Screen.PrimaryScreen.Bounds.Height
                            ModPOS.Touch.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Touch.ShowDialog()
                            Me.Close()
                        End If
                    End If
                Else
                    Beep()
                    If FrmPadre = "Caja" Then
                        MessageBox.Show("La Caja seleccionada no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("El punto de venta seleccionado no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                Beep()
                MessageBox.Show("La Sucursal seleccionada no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub


    Private Sub FrmLogin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.SplashVenta.Dispose()
        ModPOS.SplashVenta = Nothing
    End Sub


    Private Sub CmbAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If Cargado = True AndAlso Not CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = CmbSucursal.SelectedValue
            If FrmPadre = "Caja" Then
                With cmbPuntodeVenta
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_caja"
                    .NombreParametro1 = "Sucursal"
                    .Parametro1 = SUCClave
                    .llenar()
                End With
            Else
                With cmbPuntodeVenta
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                    .NombreParametro1 = "Sucursal"
                    .Parametro1 = SUCClave
                    .NombreParametro2 = "Fase"
                    .Parametro2 = fase
                    .llenar()
                End With
            End If
        End If
    End Sub



    Private Sub BtnUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUsuario.Click

        If bCambiaUsuario Then
            bCambiaUsuario = False
            Me.Height = 300
            Lbluser.Visible = False
            LblPwd.Visible = False
            TxtLogin.Visible = False
            TxtPassword.Visible = False
        Else
            bCambiaUsuario = True
            Me.Height = 350
            Lbluser.Visible = True
            LblPwd.Visible = True
            TxtLogin.Visible = True
            TxtPassword.Visible = True
        End If

    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If sPDVClave = "" Then
            MessageBox.Show("No es posible abrir alguna caja o punto de venta ya que no se encuentra esta computadora asociada a alguno de ellos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If MessageBox.Show("El punto de venta o caja asociado a esta computadora se encuentra abierto, asegurese que no este siendo usado en otra computadora antes de continuar, ya que podria provocar conflictos con los consecutivos de los folios. Para continuar precione OK o Cancel para salir sin realizar cambios", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.OK Then

                ModPOS.Ejecuta("sp_actualiza_fase", "@Clave", sPDVClave, "@Tipo", Tipo)

                If FrmPadre = "Caja" Then
                    With cmbPuntodeVenta
                        .Conexion = ModPOS.BDConexion
                        .ProcedimientoAlmacenado = "sp_filtra_caja"
                        .NombreParametro1 = "Sucursal"
                        .Parametro1 = CmbSucursal.SelectedValue
                        .llenar()
                    End With
                    Tipo = 2
                Else
                    With cmbPuntodeVenta
                        .Conexion = ModPOS.BDConexion
                        .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                        .NombreParametro1 = "Sucursal"
                        .Parametro1 = CmbSucursal.SelectedValue
                        .NombreParametro2 = "Fase"
                        .Parametro2 = fase
                        .llenar()
                    End With
                    Tipo = 1
                End If
            End If

            cmbPuntodeVenta.SelectedValue = sPDVClave
        End If

    End Sub
End Class


