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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnUsuario = New Janus.Windows.EditControls.UIButton()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.GrpSucursal = New System.Windows.Forms.GroupBox()
        Me.GrpVenta = New System.Windows.Forms.GroupBox()
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton()
        Me.GrpUsuario = New System.Windows.Forms.GroupBox()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Lbluser = New System.Windows.Forms.Label()
        Me.LblPwd = New System.Windows.Forms.Label()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.cmbPuntodeVenta = New Selling.StoreCombo()
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
        Me.BtnUsuario.Icon = CType(resources.GetObject("BtnUsuario.Icon"), System.Drawing.Icon)
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
        'CmbSucursal
        '
        resources.ApplyResources(Me.CmbSucursal, "CmbSucursal")
        Me.CmbSucursal.Name = "CmbSucursal"
        '
        'cmbPuntodeVenta
        '
        resources.ApplyResources(Me.cmbPuntodeVenta, "cmbPuntodeVenta")
        Me.cmbPuntodeVenta.Name = "cmbPuntodeVenta"
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
    Private Compartir As Integer

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

            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Compartir"
                        Compartir = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Exit For
                End Select
            Next


            If Compartir = 1 Then

                With cmbPuntodeVenta
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                    .NombreParametro1 = "Sucursal"
                    .Parametro1 = CmbSucursal.SelectedValue
                    .NombreParametro2 = "Fase"
                    .Parametro2 = fase
                    .llenar()
                End With

            Else
                With cmbPuntodeVenta
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "st_filtra_tpdv"
                    .NombreParametro1 = "Sucursal"
                    .Parametro1 = CmbSucursal.SelectedValue
                    .NombreParametro2 = "Usuario"
                    .Parametro2 = ModPOS.UsuarioActual
                    .llenar()
                End With
            End If
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

            If dt.Rows(0)("Tipo") = 1 OrElse dt.Rows(0)("Tipo") = 2 Then 'Venta
                Dim a As New FrmConsultaPrecio
                a.SUCClave = SUCClave
                a.ClienteActual = dt.Rows(0)("CTEClave")
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


                        'pwd 12345
                        Dim dtUsuario As DataTable

                        dtUsuario = ModPOS.SiExisteRecupera("sp_valida_Usr", "@Login", UCase(Trim(Me.TxtLogin.Text.Replace("'", "''"))))
                        If Not dtUsuario Is Nothing Then

                            If EW.Encrypt.HashPass.ValidatePassword(TxtPassword.Text.Trim, dtUsuario.Rows(0)("Password")) Then
                                ModPOS.UsuarioLogin = UCase(Trim(Me.TxtLogin.Text))

                                dt = ModPOS.Recupera_Tabla("sp_load_usuario", "@Login", ModPOS.UsuarioLogin)
                                ModPOS.UsuarioActual = dt.Rows(0)("USRClave")
                                MPrincipal.StUsuario.Text = dt.Rows(0)("Nombre")
                                dt.Dispose()

                                If FrmPadre = "Venta" Then
                                    If Compartir = 0 Then

                                        With cmbPuntodeVenta
                                            .Conexion = ModPOS.BDConexion
                                            .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                                            .NombreParametro1 = "Sucursal"
                                            .Parametro1 = CmbSucursal.SelectedValue
                                            .NombreParametro2 = "Fase"
                                            .Parametro2 = fase
                                            .llenar()
                                        End With
                                        MessageBox.Show("Se realizo el cambio de usuario correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If
                                End If

                            Else
                                Beep()
                                MessageBox.Show("El Usuario o la Contraseña no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            dtUsuario.Dispose()
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
                        Dim CorteDetallado, ConfirmarAbono, reciboTicket, muestraNotas As Integer
                        Dim NumCopias As Integer
                        Dim MaxEfectivo As Double
                        Dim Transferencia As Integer
                        Dim FormatoCorte As String
                        Dim ClaveCaja As String
                        Dim Bloqueo As String
                        Dim Stage, StageCancelacion, Mostrador As String

                        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", cmbPuntodeVenta.SelectedValue)

                        Fase = dt.Rows(0)("Fase")
                        ClaveCaja = dt.Rows(0)("Clave")
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
                        MaxEfectivo = dt.Rows(0)("LimiteEfectivo")
                        Manual = IIf(dt.Rows(0)("Manual").GetType.Name <> "DBNull", dt.Rows(0)("Manual"), 0)
                        Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name <> "DBNull", dt.Rows(0)("Cajon"), False)
                        Aplicacion = IIf(dt.Rows(0)("url_aplicacion").GetType.Name <> "DBNull", dt.Rows(0)("url_aplicacion"), "")
                        PRNClavePic = IIf(dt.Rows(0)("PRNClavePic").GetType.Name <> "DBNull", dt.Rows(0)("PRNClavePic"), "")
                        CorteDetallado = (IIf(dt.Rows(0)("CorteDetallado").GetType.Name <> "DBNull", dt.Rows(0)("CorteDetallado"), 0))
                        NumCopias = IIf(dt.Rows(0)("copiaCredito").GetType.Name <> "DBNull", dt.Rows(0)("copiaCredito"), 0)
                        Stage = IIf(dt.Rows(0)("Stage").GetType.Name <> "DBNull", dt.Rows(0)("Stage"), "")
                        StageCancelacion = IIf(dt.Rows(0)("StageCancelacion").GetType.Name <> "DBNull", dt.Rows(0)("StageCancelacion"), "")
                        Transferencia = IIf(dt.Rows(0)("Transferencia").GetType.Name <> "DBNull", dt.Rows(0)("Transferencia"), 0)
                        FormatoCorte = IIf(dt.Rows(0)("FormatoCorte").GetType.Name <> "DBNull", dt.Rows(0)("FormatoCorte"), "Resumen")
                        Bloqueo = IIf(dt.Rows(0)("Bloqueo").GetType.Name <> "DBNull", dt.Rows(0)("Bloqueo"), "0|0|0|0|0")
                        ConfirmarAbono = IIf(dt.Rows(0)("ConfirmaAbono").GetType.Name <> "DBNull", dt.Rows(0)("ConfirmaAbono"), 0)
                        reciboTicket = IIf(dt.Rows(0)("reciboTicket").GetType.Name <> "DBNull", dt.Rows(0)("reciboTicket"), 0)
                        muestraNotas = IIf(dt.Rows(0)("muestraNotas").GetType.Name <> "DBNull", dt.Rows(0)("muestraNotas"), 0)
                        Mostrador = IIf(dt.Rows(0)("Mostrador").GetType.Name <> "DBNull", dt.Rows(0)("Mostrador"), "")

                        dt.Dispose()


                        If Fase = 0 Then
                            ModPOS.Ejecuta("sp_act_caja", "@CAJClave", cmbPuntodeVenta.SelectedValue, "@Fase", 1)

                            If ModPOS.MtoCXC Is Nothing Then
                                ModPOS.MtoCXC = New FrmTCaja
                                ModPOS.MtoCXC.ClaveCaja = ClaveCaja
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
                                ModPOS.MtoCXC.Stage = Stage
                                ModPOS.MtoCXC.StageCancelacion = StageCancelacion
                                ModPOS.MtoCXC.Manual = Manual
                                ModPOS.MtoCXC.Cajon = Cajon
                                ModPOS.MtoCXC.Aplicacion = Aplicacion
                                ModPOS.MtoCXC.PRNClavePic = PRNClavePic
                                ModPOS.MtoCXC.CorteDetallado = CorteDetallado
                                ModPOS.MtoCXC.ConfirmarAbono = ConfirmarAbono
                                ModPOS.MtoCXC.reciboTicket = reciboTicket
                                ModPOS.MtoCXC.muestraNotas = muestraNotas
                                ModPOS.MtoCXC.NumCopias = NumCopias
                                ModPOS.MtoCXC.MaxEfectivo = MaxEfectivo
                                ModPOS.MtoCXC.Transferencia = Transferencia
                                ModPOS.MtoCXC.FormatoCorte = FormatoCorte
                                ModPOS.MtoCXC.Bloqueo = Bloqueo
                                ModPOS.MtoCXC.Mostrador = Mostrador

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
                            Dim dtVenta As DataTable

                            Dim bVentasOpen As Boolean = False

                            If ModPOS.numMostrador_Open = 0 Then
                                'Verifica si hay ventas abiertas
                                dtVenta = Recupera_Tabla("sp_recupera_ventaopen", "@PDVClave", dt.Rows(0)("PDVClave"))
                                If dtVenta.Rows.Count > 0 Then
                                    bVentasOpen = True
                                    Dim y As Integer = 0
                                    For y = 0 To dtVenta.Rows.Count - 1
                                        NuevoMostrador(dt, y, dtVenta)
                                    Next
                                End If
                                dtVenta.Dispose()
                            End If

                            If bVentasOpen = False Then
                                NuevoMostrador(dt, -1)
                            End If

                          
                        ElseIf dt.Rows(0)("Tipo") = 2 Then 'Preventa

                            If ModPOS.MtoVenta Is Nothing Then
                                ModPOS.MtoVenta = New FrmMtoVenta
                                With ModPOS.MtoVenta
                                    .StartPosition = FormStartPosition.CenterScreen
                                    .ActivarCaja = dt.Rows(0)("Caja") = True
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
                                    .CajeroClave = ModPOS.UsuarioActual
                                    .CajeroNombre = ModPOS.UsuarioLogin

                                    .MeseroClave = ModPOS.UsuarioActual
                                    .MeseroNombre = ModPOS.UsuarioLogin

                                    '.USRCambiaPrecio = dt.Rows(0)("USRCambiaPrecio")
                                    ' .PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")
                                    .CambiaPrecio = dt.Rows(0)("CambiaPrecio")

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

                        ElseIf dt.Rows(0)("Tipo") = 6 Then ' Afiliado
                            If ModPOS.Afiliado Is Nothing Then
                                ModPOS.Afiliado = New FrmAfiliado
                                With ModPOS.Afiliado
                                    .StartPosition = FormStartPosition.CenterScreen
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
                                    .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                                    .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")

                                    .Agotamiento = dt.Rows(0)("Agotamiento")
                                    .SolicitaVendedor = False
                                    .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
                                    .LblFolio.Text = .Referencia & "- 0"
                                    .PrintGeneric = dt.Rows(0)("Generic")
                                    .sFrase = dt.Rows(0)("Frase")
                                    .ActivaDevolucion = dt.Rows(0)("Devolucion")
                                    .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
                                    .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

                                    .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))
                                   .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
                                    .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))
                                    .ActivarCotizacion = IIf(dt.Rows(0)("ActivarCotizacion").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ActivarCotizacion"))))

                                    If dt.Rows(0)("Remoto").GetType.Name = "DBNull" Then
                                        .Remoto = 0
                                    Else
                                        .Remoto = Math.Abs(CInt(dt.Rows(0)("Remoto")))
                                    End If

                                    .BloquearPrecio = IIf(dt.Rows(0)("BloquearPrecio").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("BloquearPrecio"))))
                                    .ImprimirRemoto = IIf(dt.Rows(0)("ImprimirRemoto").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ImprimirRemoto"))))

                                    .SucursalSurtido = dt.Rows(0)("SUCClave")
                                  
                                   
                                    .Text = "Mostrador: " & .Referencia

                                    dt.Dispose()

                                End With
                            End If

                            ModPOS.Afiliado.Width = Screen.PrimaryScreen.Bounds.Width
                            ModPOS.Afiliado.Height = Screen.PrimaryScreen.Bounds.Height
                            ModPOS.Afiliado.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Afiliado.ShowDialog()
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
                                    '.CajeroClave = dt.Rows(0)("USRClave")
                                    '.CajeroNombre = dt.Rows(0)("Usuario")

                                    '.MeseroClave = dt.Rows(0)("USRClave")
                                    '.MeseroNombre = dt.Rows(0)("Usuario")

                                    '.USRCambiaPrecio = dt.Rows(0)("USRCambiaPrecio")
                                    ' .PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")
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
                                        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", .CTEClaveActual)
                                        .ListaPrecio = dtCliente.Rows(0)("PREClave")
                                        .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                                        dtCliente.Dispose()


                                        'Recupera los descuentos de cliente
                                        .DescuentoCliente = -1
                                        .PorcDescCliente = 0

                                        If .CambiarCliente = False Then

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

                If Compartir = 1 Then

                    With cmbPuntodeVenta
                        .Conexion = ModPOS.BDConexion
                        .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                        .NombreParametro1 = "Sucursal"
                        .Parametro1 = CmbSucursal.SelectedValue
                        .NombreParametro2 = "Fase"
                        .Parametro2 = fase
                        .llenar()
                    End With

                Else
                    With cmbPuntodeVenta
                        .Conexion = ModPOS.BDConexion
                        .ProcedimientoAlmacenado = "st_filtra_tpdv"
                        .NombreParametro1 = "Sucursal"
                        .Parametro1 = CmbSucursal.SelectedValue
                        .NombreParametro2 = "Usuario"
                        .Parametro2 = ModPOS.UsuarioActual
                        .llenar()
                    End With
                End If

              
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

        If sPDVClave = "" AndAlso (FrmPadre = "Caja" OrElse Compartir = 1) Then
            MessageBox.Show("No es posible abrir alguna caja o punto de venta ya que no se encuentra esta computadora asociada a alguno de ellos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
           
                If FrmPadre = "Caja" Then
                    ModPOS.Ejecuta("sp_actualiza_fase", "@Clave", sPDVClave, "@Tipo", Tipo)

                    With cmbPuntodeVenta
                        .Conexion = ModPOS.BDConexion
                        .ProcedimientoAlmacenado = "sp_filtra_caja"
                        .NombreParametro1 = "Sucursal"
                        .Parametro1 = CmbSucursal.SelectedValue
                        .llenar()
                    End With
                    Tipo = 2
                    cmbPuntodeVenta.SelectedValue = sPDVClave

                Else
                    Dim dt As DataTable
                    Dim numAbiertos As Integer
                    dt = Recupera_Tabla("st_recupera_abiertos", "@USRClave", ModPOS.UsuarioActual)
                    numAbiertos = dt.Rows.Count
                    dt.Dispose()
                    If numAbiertos > 0 Then
                        Dim a As New FrmConsulta
                        a.Text = "Seleccione el Punto de Venta que desea Liberar"
                        a.Intro = False
                        a.Campo = "PDVClave"
                        a.AutoSizeForm = False
                        a.BtnPicking.Visible = True
                        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_abiertos", "@USRClave", ModPOS.UsuarioActual)
                        a.GridConsultaGen.RootTable.Columns("PDVClave").Visible = False
                        a.GridConsultaGen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal
                        a.GridConsultaGen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
                        a.GridConsultaGen.GroupByBoxVisible = False
                        a.BtnPicking.Visible = False
                        a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then

                        If a.ID <> "" Then
                            ''
                            Dim Liberar As Integer

                            dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", a.ID)
                            If dt.Rows(0)("Liberar").GetType.Name = "DBNull" Then
                                Liberar = 0
                            Else
                                Liberar = Math.Abs(CInt(dt.Rows(0)("Liberar")))
                            End If
                            dt.Dispose()

                            If Liberar = 1 Then
                                If MessageBox.Show("Esta apunto de liberar el punto de venta,asegurese que no este siendo usado en otra por usted mismo en otra ventana del programa o  en otra computadora antes de continuar, ya que podria provocar conflictos con los consecutivos de los folios. Para continuar precione OK o Cancel para salir sin realizar cambios", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.OK Then

                                    ModPOS.Ejecuta("sp_actualiza_fase", "@Clave", a.ID, "@Tipo", Tipo)

                                    If Compartir = 1 Then

                                        With cmbPuntodeVenta
                                            .Conexion = ModPOS.BDConexion
                                            .ProcedimientoAlmacenado = "sp_filtra_tpdv"
                                            .NombreParametro1 = "Sucursal"
                                            .Parametro1 = CmbSucursal.SelectedValue
                                            .NombreParametro2 = "Fase"
                                            .Parametro2 = fase
                                            .llenar()
                                        End With

                                    Else
                                        With cmbPuntodeVenta
                                            .Conexion = ModPOS.BDConexion
                                            .ProcedimientoAlmacenado = "st_filtra_tpdv"
                                            .NombreParametro1 = "Sucursal"
                                            .Parametro1 = CmbSucursal.SelectedValue
                                            .NombreParametro2 = "Usuario"
                                            .Parametro2 = ModPOS.UsuarioActual
                                            .llenar()
                                        End With
                                    End If
                                    Tipo = 1
                                    cmbPuntodeVenta.SelectedValue = a.ID
                                End If
                            Else
                                MessageBox.Show("El punto de venta seleccionado no permite liberación por parte del usuario. Favor de contactar a soporte tecnico", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                    End If
                Else
                    MessageBox.Show("No se encontraron Puntos de Venta Abiertos asociados al Vendedor Actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                End If

        End If

    End Sub
End Class


