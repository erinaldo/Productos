Public Class FrmMenu
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
    Friend WithEvents BtnBarMain As Janus.Windows.ButtonBar.ButtonBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenu))
        Me.BtnBarMain = New Janus.Windows.ButtonBar.ButtonBar
        CType(Me.BtnBarMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnBarMain
        '
        Me.BtnBarMain.BackColor = System.Drawing.Color.White
        Me.BtnBarMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnBarMain.KeepSelection = False
        Me.BtnBarMain.Location = New System.Drawing.Point(0, 0)
        Me.BtnBarMain.Name = "BtnBarMain"
        Me.BtnBarMain.ScrollLocation = Janus.Windows.ButtonBar.ScrollLocation.GroupsLevel
        Me.BtnBarMain.SelectionArea = Janus.Windows.ButtonBar.SelectionArea.FullItem
        Me.BtnBarMain.Size = New System.Drawing.Size(168, 666)
        Me.BtnBarMain.TabIndex = 0
        Me.BtnBarMain.VisualStyle = Janus.Windows.ButtonBar.VisualStyle.Office2007
        '
        'FrmMenu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(168, 666)
        Me.Controls.Add(Me.BtnBarMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Barra de Menu"
        CType(Me.BtnBarMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public sPerfil As String


    Private Sub FrmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_load_usuario", "@Login", ModPOS.UsuarioLogin)

        ModPOS.UsuarioActual = dt.Rows(0)("USRClave")
        Me.sPerfil = dt.Rows(0)("PERClave")
        MyProfile = sPerfil
        ModPOS.SucursalPredeterminada = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))

        MPrincipal.StUsuario.Text = dt.Rows(0)("Nombre")
        MPrincipal.StFecha.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
        MPrincipal.Text = ModPOS.TituloMain

        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_valida_sucursal", "@SUCClave", ModPOS.SucursalPredeterminada, "@COMClave", ModPOS.CompanyActual)

        If dt.Rows.Count = 0 Then
            ModPOS.SucursalPredeterminada = ""
        End If

        dt.Dispose()

        If ModPOS.SucursalPredeterminada <> "" Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_suc_alm", "@SUCClave", ModPOS.SucursalPredeterminada)

            If dt.Rows.Count > 0 Then
                ModPOS.AlmacenPredeterminado = dt.Rows(0)("ALMClave")
            Else
                ModPOS.AlmacenPredeterminado = ""
            End If
        Else
            ModPOS.AlmacenPredeterminado = ""
        End If

        dt.Dispose()

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand


        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        myCommand = New System.Data.SqlClient.SqlCommand("sp_activa_grupo", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = sPerfil

        dr = myCommand.ExecuteReader()

        While dr.Read
            Dim btn As Janus.Windows.ButtonBar.ButtonBarGroup
            btn = New Janus.Windows.ButtonBar.ButtonBarGroup(dr("Nombre"))
            btn.Key = dr("GRPKey")
            If Not dr("Imagen") Is System.DBNull.Value Then
                btn.Image = ModPOS.RecuperaIcono(CType(dr("Imagen"), Byte()))
            End If
            Me.BtnBarMain.Groups.Add(btn)
        End While

        myCommand.Dispose()
        dr.Close()

        myCommand = New System.Data.SqlClient.SqlCommand("sp_activa_item", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = sPerfil

        dr = myCommand.ExecuteReader()

        While dr.Read
            Dim btnItem As Janus.Windows.ButtonBar.ButtonBarItem
            btnItem = New Janus.Windows.ButtonBar.ButtonBarItem(dr("Nombre"))
            btnItem.Key = dr("ITMKey")
            If Not dr("Imagen") Is System.DBNull.Value Then
                btnItem.Image = ModPOS.RecuperaIcono(CType(dr("Imagen"), Byte()))
            End If
            Me.BtnBarMain.Groups(dr("GRPKey")).items.add(btnItem)

        End While

        myCommand.Dispose()
        dr.Close()
        Cnx.Close()


    End Sub

    Private Sub BtnBarMain_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ButtonBar.ItemEventArgs) Handles BtnBarMain.ItemClick
        Select Case e.Item.Key
            Case "101"
                If ModPOS.MtoCompania Is Nothing Then
                    ModPOS.MtoCompania = New FrmMtoCompania
                    ModPOS.MtoCompania.MdiParent = MPrincipal
                End If
                ModPOS.MtoCompania.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoCompania.Show()
                ModPOS.MtoCompania.BringToFront()


            Case "102"
                If ModPOS.MtoModulos Is Nothing Then
                    ModPOS.MtoModulos = New FrmMtoModulos
                    ModPOS.MtoModulos.MdiParent = MPrincipal
                End If
                ModPOS.MtoModulos.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoModulos.Show()
                ModPOS.MtoModulos.BringToFront()


            Case "104"
                If ModPOS.MtoPrinter Is Nothing Then
                    ModPOS.MtoPrinter = New FrmMtoPrinter
                    ModPOS.MtoPrinter.MdiParent = MPrincipal

                End If
                ModPOS.MtoPrinter.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoPrinter.Show()
                ModPOS.MtoPrinter.BringToFront()


            Case "105"
                If ModPOS.MtoImp Is Nothing Then
                    ModPOS.MtoImp = New FrmMtoImp
                    ModPOS.MtoImp.MdiParent = MPrincipal

                End If
                ModPOS.MtoImp.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoImp.Show()
                ModPOS.MtoImp.BringToFront()


            Case "106"
                If ModPOS.MtoBancos Is Nothing Then
                    ModPOS.MtoBancos = New FrmMtoBank
                    ModPOS.MtoBancos.MdiParent = MPrincipal
                End If
                ModPOS.MtoBancos.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoBancos.Show()
                ModPOS.MtoBancos.BringToFront()

            Case "107"
                If ModPOS.MtoMon Is Nothing Then
                    ModPOS.MtoMon = New FrmMtoMon
                    ModPOS.MtoMon.MdiParent = MPrincipal

                End If
                ModPOS.MtoMon.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoMon.Show()
                ModPOS.MtoMon.BringToFront()

            Case "108"
                If ModPOS.MtoPDV Is Nothing Then
                    ModPOS.MtoPDV = New FrmMtoPDV
                    ModPOS.MtoPDV.MdiParent = MPrincipal

                End If
                ModPOS.MtoPDV.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoPDV.Show()
                ModPOS.MtoPDV.BringToFront()

            Case "109"
                If ModPOS.MtoGeografia Is Nothing Then
                    ModPOS.MtoGeografia = New FrmMtoGeografia
                    ModPOS.MtoGeografia.MdiParent = MPrincipal

                End If
                ModPOS.MtoGeografia.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoGeografia.Show()
                ModPOS.MtoGeografia.BringToFront()

            Case "110"
                If ModPOS.MtoUnidades Is Nothing Then
                    ModPOS.MtoUnidades = New FrmMtoUnidades
                    ModPOS.MtoUnidades.MdiParent = MPrincipal

                End If
                ModPOS.MtoUnidades.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoUnidades.Show()
                ModPOS.MtoUnidades.BringToFront()

            Case "111"
                If ModPOS.MtoTicket Is Nothing Then
                    ModPOS.MtoTicket = New FrmMtoTicket
                    ModPOS.MtoTicket.MdiParent = MPrincipal

                End If
                ModPOS.MtoTicket.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoTicket.Show()
                ModPOS.MtoTicket.BringToFront()

            Case "112"
                If ModPOS.MtoCajas Is Nothing Then
                    ModPOS.MtoCajas = New FrmMtoCaja
                    ModPOS.MtoCajas.MdiParent = MPrincipal

                End If
                ModPOS.MtoCajas.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoCajas.Show()
                ModPOS.MtoCajas.BringToFront()

            Case "113"
                If ModPOS.MtoLabelSheet Is Nothing Then
                    ModPOS.MtoLabelSheet = New FrmMtoLabelSheet
                    ModPOS.MtoLabelSheet.MdiParent = MPrincipal

                End If
                ModPOS.MtoLabelSheet.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoLabelSheet.Show()
                ModPOS.MtoLabelSheet.BringToFront()


            Case "114"
                If ModPOS.MtoSucursales Is Nothing Then
                    ModPOS.MtoSucursales = New FrmMtoSucursales
                    ModPOS.MtoSucursales.MdiParent = MPrincipal
                End If
                ModPOS.MtoSucursales.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoSucursales.Show()
                ModPOS.MtoSucursales.BringToFront()

            Case "115"
                If ModPOS.MtoFolios Is Nothing Then
                    ModPOS.MtoFolios = New FrmMtoFolios
                    ModPOS.MtoFolios.MdiParent = MPrincipal
                End If
                ModPOS.MtoFolios.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoFolios.Show()
                ModPOS.MtoFolios.BringToFront()

            Case "116"
                If ModPOS.MtoCertificado Is Nothing Then
                    ModPOS.MtoCertificado = New FrmMtoCertificado
                    ModPOS.MtoCertificado.MdiParent = MPrincipal

                End If
                ModPOS.MtoCertificado.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoCertificado.Show()
                ModPOS.MtoCertificado.BringToFront()

            Case "117"
                If ModPOS.MtoAddenda Is Nothing Then
                    ModPOS.MtoAddenda = New FrmMtoAddenda
                    ModPOS.MtoAddenda.MdiParent = MPrincipal

                End If
                ModPOS.MtoAddenda.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoAddenda.Show()
                ModPOS.MtoAddenda.BringToFront()

            Case "118"
                If ModPOS.MtoValor Is Nothing Then
                    ModPOS.MtoValor = New FrmMtoValor
                    ModPOS.MtoValor.MdiParent = MPrincipal

                End If
                ModPOS.MtoValor.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoValor.Show()
                ModPOS.MtoValor.BringToFront()

            Case "201"
                If ModPOS.MtoPerfil Is Nothing Then
                    ModPOS.MtoPerfil = New FrmMtoPerfil
                    ModPOS.MtoPerfil.MdiParent = MPrincipal

                End If
                ModPOS.MtoPerfil.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoPerfil.Show()
                ModPOS.MtoPerfil.BringToFront()

            Case "202"
                If ModPOS.MtoUsuario Is Nothing Then
                    ModPOS.MtoUsuario = New FrmMtoUsuario
                    ModPOS.MtoUsuario.MdiParent = MPrincipal

                End If
                ModPOS.MtoUsuario.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoUsuario.Show()
                ModPOS.MtoUsuario.BringToFront()

            Case "301"
                If ModPOS.MtoClass Is Nothing Then
                    ModPOS.MtoClass = New FrmMtoClass
                    ModPOS.MtoClass.MdiParent = MPrincipal
                End If
                ModPOS.MtoClass.Show()
                ModPOS.MtoClass.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoClass.BringToFront()


            Case "302"
                If ModPOS.MtoProductos Is Nothing Then
                    ModPOS.MtoProductos = New FrmMtoProducto
                    ModPOS.MtoProductos.MdiParent = MPrincipal

                End If
                ModPOS.MtoProductos.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoProductos.Show()
                ModPOS.MtoProductos.BringToFront()

            Case "303"
                If ModPOS.MtoCliente Is Nothing Then
                    ModPOS.MtoCliente = New FrmMtoCliente
                    ModPOS.MtoCliente.MdiParent = MPrincipal

                End If
                ModPOS.MtoCliente.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoCliente.Show()
                ModPOS.MtoCliente.BringToFront()

            Case "304"
                If ModPOS.MtoProveedor Is Nothing Then
                    ModPOS.MtoProveedor = New FrmMtoProveedor
                    ModPOS.MtoProveedor.MdiParent = MPrincipal

                End If
                ModPOS.MtoProveedor.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoProveedor.Show()
                ModPOS.MtoProveedor.BringToFront()

            Case "305"
                If ModPOS.MtoPortafolio Is Nothing Then
                    ModPOS.MtoPortafolio = New FrmMtoPortafolio
                    ModPOS.MtoPortafolio.MdiParent = MPrincipal

                End If
                ModPOS.MtoPortafolio.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoPortafolio.Show()
                ModPOS.MtoPortafolio.BringToFront()

            Case "306"
                If ModPOS.MtoClaves Is Nothing Then
                    ModPOS.MtoClaves = New FrmMtoClaves
                    ModPOS.MtoClaves.MdiParent = MPrincipal

                End If
                ModPOS.MtoClaves.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MtoClaves.Show()
                ModPOS.MtoClaves.BringToFront()

                'Reportes
            Case "329"
                Dim a As New MeFiltroAlm
                a.Titulo = "Reporte de Notas de Crédito Diarias"
                a.textolbl = "Sucursal"
                a.StoreProcedure = "sp_filtra_sucursal"
                a.ShowDialog()
                If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                    Dim OpenReport As New Report
                    Dim pvtaDataSet As New DataSet
                    pvtaDataSet.DataSetName = "reportDataSet"
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_nc_diaria", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                    OpenReport.PrintPreview("Reporte de Notas de Crédito Diarias", "CRNCDiaria.rpt", pvtaDataSet, "")
                End If
                a.Dispose()
            Case "330"
                Dim a As New MeFiltroDiaria
                a.Titulo = "Reporte de Compras Diarias"
                a.textolbl = "Sucursal"
                a.StoreProcedure = "sp_filtra_sucursal"
                a.ShowDialog()
                If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                    Dim OpenReport As New Report
                    Dim pvtaDataSet As New DataSet
                    pvtaDataSet.DataSetName = "reportDataSet"
                    If a.IncluirDetalle = False Then
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_compra_diaria", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Compras Diarias", "CRCompraDiaria.rpt", pvtaDataSet, "")
                    Else
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_compra_diaria_det", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Compras Diarias Detallado", "crCompraDiariaDet.rpt", pvtaDataSet, "")

                    End If
                End If
                    a.Dispose()

            Case "331"
                    Dim a As New MeFiltroDiaria
                    a.Titulo = "Reporte de Ventas Diarias"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ChkVtas.Visible = True
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        If a.IncluirDetalle = False Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_venta_diaria", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@IncluirVts", a.IncluirVentas))
                            OpenReport.PrintPreview("Reporte de Ventas Diarias", "CRVentaDiaria.rpt", pvtaDataSet, "")

                        Else
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_venta_diaria_det", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@IncluirVts", a.IncluirVentas))
                            OpenReport.PrintPreview("Reporte de Ventas Diarias Detallado", "crVentaDiariaDet.rpt", pvtaDataSet, "")

                        End If
                    End If
                    a.Dispose()

            Case "332"
                    Dim a As New MeFiltroEmp
                    a.Text = "Reporte de Pedidos por Chofer"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_pedidos_chofer", "@EMPClave", a.Empleado, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Pedidos por Chofer", "CRPedidosChofer.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()
            Case "333"
                    Dim a As New MeFiltroVenta
                    a.Titulo = "Reporte de Pedidos"
                    a.ChkTodos.Visible = False
                    a.lblTipo.Visible = False
                    a.CmbVenta.Visible = False
                    a.ChkCanceladas.Visible = False
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_venta", "@Todos", a.VentasTodos, "@Tipo", a.VentaTipo, "@Canceladas", a.VentaEstado, "@SUCClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@USRClave", a.USRClave, "@CTEClave", a.CTEClave, "@PROClave", a.PROClave))
                        OpenReport.PrintPreview("Reporte de Pedidos", "CRPedidos.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "334"
                    Dim a As New MeFiltroEmp
                    a.Text = "Reporte de Estado de Cuenta Empleado"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_edo_empleado", "@EMPClave", a.Empleado, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Estado de Cuenta Empleado", "CREdoEmpleado.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "335"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Saldos de Proveedor"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.GroupBox1.Visible = False
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_saldos_proveedor", "@SUCClave", a.Origen, "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Saldos de Proveedor", "CRSaldosProveedor.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "336"
                    Dim a As New MeFiltro
                    a.Text = "Reporte de Avance Surtido/Recibo"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_avance_det", "@Inicio", CDate(a.FechaInicio), "@Fin", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Avance Surtido/Recibo", "CRAvance.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()
            Case "337"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas Surtidas Pendientes de Facturar"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_pendiente_facturar", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Ventas Surtidas Pendientes de Facturar", "CRPendientesFacturar.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()
            Case "338"
                    Dim a As New MeFiltro
                    a.Text = "Reporte Surtidos Asignados"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_surtido_asignado", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Surtidos Asignados", "CRSurtidoAsignado.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()
            Case "339"
                    Dim a As New MeFiltroVenta
                    a.Titulo = "Reporte de Ventas Canceladas"
                    a.ChkTodos.Visible = False
                    a.lblTipo.Visible = False
                    a.CmbVenta.Visible = False
                    a.ChkCanceladas.Visible = False
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        '   pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_cancelados", "@SUCClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@USRClave", a.USRClave, "@CTEClave", a.CTEClave, "@PROClave", a.PROClave))
                        OpenReport.PrintPreview("Reporte de Ventas Canceladas", "CRCancelados.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "340"
                    Dim a As New MeFiltroEmp
                    a.Text = "Reporte Relación de Reparto"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_reparto", "@COMClave", ModPOS.CompanyActual, "@EMPClave", a.Empleado, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Relación de Reparto", "CRReparto.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "341"
                    Dim a As New MeFiltroFac
                    a.ChkAgrupado.Visible = False
                    a.Titulo = "Reporte de Desglose de Facturación"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_facturacion_desglosada", "@Tipo", a.FacturacionTipo, "@Canceladas", a.FacturacionEstado, "@ALMClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Facturación Desglosada", "CRFacturacionDesglosada.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "342"
                    Dim a As New MeFiltroEmp
                    a.Text = "Reporte de Relación de Gastos"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_gastos", "@EMPClave", a.Empleado, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Relación de Gastos", "CRGastos.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()



            Case "343"
                    Dim a As New MeFiltroTrans
                    a.Text = "Reporte de Rendimientos de Combustible"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rendimiento", "@TRAClave", a.Transporte, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Rendimientos de Combustible", "CRRendimiento.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()


            Case "344"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Rechazos en Traspaso"
                    a.textolbl = "Destino"
                    a.StoreProcedure = "sp_filtra_almacen"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rechazotraspaso", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Rechazos de Traspaso", "CRRechazoTraspaso.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "345"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Producto en Transito"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_productotransito", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Producto en Transito", "CRProductoTransito.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "346"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Apartados"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_apartados", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Producto Apartado", "CRApartadoDetallado.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()




            Case "347"
                    Dim a As New MeFiltroCobra
                    a.GrpVencimiento.Text = "Días sin Ventas"
                    a.Titulo = "Reporte de Clientes Sin Venta"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_cte_sinvta", "@SUCClave", a.SucursalOrigen, "@Dias", a.VencimientoDias))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Clientes Sin Venta", "CRClienteSinVta.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "348"
                    Dim a As New MeFiltroCobra
                    a.Titulo = "Reporte de Clientes con Saldo por Vencer "
                    a.chkUsuario.Visible = True
                    a.lblUsuario.Visible = True
                    a.txtUsuario.Visible = True
                    a.btnUsuario.Visible = True
                    a.GrpVencimiento.Visible = False
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_saldos_porvencer", "@SUCClave", a.SucursalOrigen, "@USRClave", a.Usuario))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Clientes con Saldo por Vencer", "CRSaldosPorVencer.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()


            Case "349"
                    Dim a As New MeFiltroUsr
                    a.Text = "Reporte de Producto Negado"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_productonegado", "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@USRClave", a.Usuario))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Producto Negado", "CRProductoNegado.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "350"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Pedidos Pendientes por Surtir"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_pendientesurtir", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Pedidos Pendientes por Surtir", "CRPendienteSurtir.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "351"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas Mensuales por Cliente"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"

                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ventcliente", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas Mensuales por Cliente", "CRClienteMensual.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "352"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas por Cliente"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ventcliente", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas por Cliente", "CRClientePeriodo.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "353"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas Mensuales por Producto"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_rep_ventprod", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(dt)
                        OpenReport.PrintPreview("Reporte de Ventas Mensuales por Producto", "CRProductoMensual.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "354"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas por Producto"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ventprod", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas por Producto", "CRProductoPeriodo.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()


            Case "355"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas por Linea"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ventclas", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas por Linea", "CRClasificacionPeriodo.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()

            Case "356"
                    Dim a As New MeFiltroTic
                    a.Titulo = "Reporte de Tickets"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_tickets", "@Cotizacion", IIf(a.Cotizacion = False, 0, 1), "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Tickets", "CRTickets.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()


            Case "357"


                    Dim a As New MeFiltroCorte
                    a.Titulo = "Reporte de Corte de Caja"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        If a.ChkTicket.Checked = True Then
                            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_corte_caja", "@CAJClave", a.CajaOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal))
                            Dim dtCaja As DataTable = ModPOS.SiExisteRecupera("sp_recupera_caja", "@Caja", a.CajaOrigen)
                            If Not dtCaja Is Nothing Then
                                Dim i As Integer
                                If dt.Rows.Count > 0 Then
                                    For i = 0 To dt.Rows.Count - 1
                                        ModPOS.imprimeTicketCierre(dt.Rows(i)("ID"), dtCaja.Rows(0)("Referencia"), dtCaja.Rows(0)("Generic"), dtCaja.Rows(0)("TIKClave"), dtCaja.Rows(0)("FormatoCorte"), dtCaja.Rows(0)("SUCClave"))
                                    Next
                                Else
                                    MessageBox.Show("No se encontraron Cortes de Caja en el rango de fechas solicitado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                                dt.Dispose()
                                dtCaja.Dispose()
                            End If
                        Else

                            Dim B As New FrmBuscaCorte
                            B.CAJClave = a.CajaOrigen
                            B.inicio = CDate(a.FechaInicio)
                            B.fin = CDate(a.FechaFinal)
                            B.ShowDialog()
                            If B.DialogResult = DialogResult.OK Then
                                If B.IdCorte <> "" Then
                                    Dim OpenReport As New Report
                                    Dim pvtaDataSet As New DataSet
                                    pvtaDataSet.DataSetName = "reportDataSet"


                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", B.IdCorte))
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", B.IdCorte))
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_creditos", "@IdCorte", B.IdCorte))

                                    OpenReport.PrintPreview("Reporte de Corte de Caja", "CRCorteCaja.rpt", pvtaDataSet, "")
                                End If
                            End If
                            B.Dispose()

                        End If
                    End If
                    a.Dispose()


            Case "358"
                    Dim a As New MeFiltroFac
                    a.Titulo = "Reporte de Facturación"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        If a.FacturacionAgrupar = 1 Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_facturacion", "@Tipo", a.FacturacionTipo, "@Canceladas", a.FacturacionEstado, "@ALMClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            OpenReport.PrintPreview("Reporte de Facturación", "CRFacturacion.rpt", pvtaDataSet, "")
                        Else
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_facturacion", "@Tipo", a.FacturacionTipo, "@Canceladas", a.FacturacionEstado, "@ALMClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            OpenReport.PrintPreview("Reporte de Facturación", "CRFacturacionConsec.rpt", pvtaDataSet, "")
                        End If
                    End If
                    a.Dispose()

            Case "359"
                    Dim a As New MeFiltroCobra
                    a.Titulo = "Reporte de Cobranza"


                    a.chkCliente.Visible = True
                    a.lblCliente.Visible = True
                    a.txtCliente.Visible = True
                    a.btnCliente.Visible = True

                    a.chkUsuario.Visible = True
                    a.lblUsuario.Visible = True
                    a.txtUsuario.Visible = True
                    a.btnUsuario.Visible = True


                    a.ChkZona.Visible = True
                    a.lblZona.Visible = True
                    a.txtZona.Visible = True
                    a.btnZona.Visible = True
                    a.ShowDialog()

                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_cobranza", "@ALMClave", a.SucursalOrigen, "@Dias", a.VencimientoDias, "@USRClave", a.Usuario, "@Zona", a.Zona, "@CTEClave", a.Cliente))
                        OpenReport.PrintPreview("Reporte de Cobranza", "CRCobranza.rpt", pvtaDataSet, IIf(a.Zona = -1, " ", a.lblZona.Text))

                    End If
                    a.Dispose()

            Case "360"

                    Dim a As New MeFiltroMov
                    a.Titulo = "Reporte de Movimientos de Inventario"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        If a.VerDetallado = 1 Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_movimientos", "@ALMClave", a.AlmacenOrigen, "@Linea", a.Grupo, "@Sublinea", a.Subgrupo, "@Todos", a.MostrarTodos, "@PROClave", a.ClaveProducto, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            OpenReport.PrintPreview("Reporte de Movimientos de Inventario Detallado", "CRMovimientos.rpt", pvtaDataSet, "")
                        Else
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_movimientos", "@ALMClave", a.AlmacenOrigen, "@Linea", a.Grupo, "@Sublinea", a.Subgrupo, "@Todos", a.MostrarTodos, "@PROClave", a.ClaveProducto, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                            OpenReport.PrintPreview("Reporte de Movimientos de Inventario General", "CRMovimientosGral.rpt", pvtaDataSet, "")

                        End If

                    End If
                    a.Dispose()

            Case "361"


                    Dim a As New MeFiltroPrice
                    a.Titulo = "Lista de Precios"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        Dim frmstatusmessage As frmStatus = New frmStatus
                        frmstatusmessage.Show("Estamos haciendo magia...")
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_precios", "@SUCClave", a.Origen, "@CTEClave", a.Cliente, "@Lista", a.ListaPrecio, "@Clasificacion", a.Segmento))
                        frmstatusmessage.Close()
                        OpenReport.PrintPreview("Lista de Precios", "CRListaPrecio.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()



            Case "362"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas Mensuales por Vendedor"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ventvendedor", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas Mensuales por Vendedor", "CRVendedorMensual.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "363"
                    Dim a As New MeFiltroLot
                    a.Titulo = "Reporte de Movimientos por Lote"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_muestra_lote", "@ALMClave", a.AlmacenOrigen, "@Lote", a.Lotes, "@PROClave", a.ClaveProducto))
                        OpenReport.PrintPreview("Reporte de Movimientos por Lote", "CRLotes.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "364"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Importe Acumulado por Redondeo"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_redondeo", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Importe Acumulado por Redondeo", "CRRedondeo.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "365"
                    Dim a As New MeFiltroAlmHist
                    a.Titulo = "Reporte Historico de Facturación por Producto"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_venta_hist", "@Periodo", a.Año, "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Historico de Facturación por Producto", "CRProductoMensualHist.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "366"
                    Dim a As New MeFiltro
                    a.Text = "Reporte Mensual de Ventas por Sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_venta_alm", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Mensual de Ventas por Sucursal", "CRVentaSucursal.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "367"
                    Dim a As New MeFiltroHist
                    a.Text = "Reporte Historico Mensual de Facturación por Sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_venta_alm_hist", "@Periodo", a.Año, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Historico Mensual de Facturación por Sucursal", "CRVentaSucursalHist.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "368"
                    Dim a As New MeFiltroExist
                    a.Titulo = "Reporte de Existencias por Almacén"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_existencias", _
                        "@ALMClave", a.AlmacenOrigen, _
                        "@Linea", a.Clasificacion, _
                        "@Agotados", a.MostrarAgotados, _
                        "@Todos", a.MostrarTodos, _
                        "@Existencia", a.MostrarSoloConExistencia, _
                        "@PROClave", a.ClaveProducto))
                        OpenReport.PrintPreview("Reporte de Existencias por Almacén", "CRExistencias.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "369"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Comisiones por Producto"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_comision_producto", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas Mensuales por Vendedor", "CRComisionProducto.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "370"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Comisiones por Venta (Acumulado)"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_comision_venta", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas Mensuales por Vendedor (Acumulado)", "CRComisionVenta.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()
            Case "371"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Pedidos o Cotizaciones por Vendedor"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_pedido_vendedor", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Pedidos o Cotizaciones por Vendedor", "CRPedidosVendedor.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "372"
                    Dim a As New MeFiltroValor
                    a.Titulo = "Reporte de Valor de Inventario"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_valorInventario", "@Linea", a.LineaCVE, "@Sublinea", a.SublineaCVE, "@ALMClave", a.AlmacenOrigen))
                        OpenReport.PrintPreview("Reporte de Valor de Inventario", "CRValorInventario.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "373"
                    Dim a As New MeFiltroVenta
                    a.Titulo = "Reporte de Ventas"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_venta", "@Todos", a.VentasTodos, "@Tipo", a.VentaTipo, "@Canceladas", a.VentaEstado, "@SUCClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@USRClave", a.USRClave, "@CTEClave", a.CTEClave, "@PROClave", a.PROClave))
                        OpenReport.PrintPreview("Reporte de Ventas", "CRVentas.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "374"

                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Rechazos de Picking"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rechazopicking", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Rechazos de Picking", "CRRechazoPicking.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "375"
                    Dim a As New MeFiltroUsr
                    a.Text = "Reporte de Comisiones por Venta"
                    a.ShowDialog()

                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_comision_vta", "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@USRClave", a.Usuario))
                        OpenReport.PrintPreview("Reporte de Comisiones por Venta", "CRComisionVta.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "376"
                    Dim a As New MeFiltroVtaLinea
                    a.Titulo = "Reporte de Ventas por Linea Detallado"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_ventlinea", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@Linea", a.LineaCVE, "@Sublinea", a.SublineaCVE, "@SUCClave", a.Sucursal))
                        OpenReport.PrintPreview("Reporte de Ventas por Linea Detallado", "CRLineaDetallado.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "377"
                    Dim a As New MeFiltroCteUsrFolio
                    a.Text = "Reporte de Notas de Crédito"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_notacredito", "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@Folio", a.Folio, "@CTEClave", a.Cliente, "@USRClave", a.Usuario))
                        OpenReport.PrintPreview("Reporte de Notas de Crédito", "CRNotasCredito.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "378"
                    Dim a As New MeFiltroValor
                    a.Titulo = "Pedido Sugerido"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_sugerido", "@Linea", a.LineaCVE, "@Sublinea", a.SublineaCVE, "@ALMClave", a.AlmacenOrigen))
                        OpenReport.PrintPreview("Pedido Sugerido", "CRPedidoSugerido.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "379"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Ventas Detalladas por Vendedor"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_vent_vend_det", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Ventas Detalladas por Vendedor", "CRVentVendDet.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()


            Case "380"
                    Dim a As New MeFiltroVtaLinea
                    a.Titulo = "Reporte de Ventas vs Existencia"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_vent_exist", "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@Linea", a.LineaCVE, "@Sublinea", a.SublineaCVE))
                        OpenReport.PrintPreview("Reporte de Ventas vs Existencia", "CRVentaExistencia.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()



            Case "381"
                    Dim a As New MeFiltroVtaLinea
                    a.Titulo = "Reporte de No Ventas vs Existencia"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_novent_exist", "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@Linea", a.LineaCVE, "@Sublinea", a.SublineaCVE))
                        OpenReport.PrintPreview("Reporte de No Ventas vs Existencia", "CRNoVentaExistencia.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "382"

                    Dim a As New MeFiltroExcel
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then

                    End If
                    a.Dispose()

            Case "383"
                    Dim a As New MeFiltroVen
                    a.Titulo = "Reporte de Facturas Detallado"
                    a.bFactura = True
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_factura", "@Todos", a.VentasTodos, "@Tipo", a.VentaTipo, "@Canceladas", a.VentaEstado, "@SUCClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Facturas Detallado", "CRFacturaDetallado.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "384"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Salida de Ruta"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_ruta", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Salida de Ruta", "CRRuta.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "385"

                    Dim a As New MeFiltroCteTodos
                    a.Text = "Reporte de Resumen de Facturas"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"

                        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", a.Sucursal)
                        Dim Picking As Boolean = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
                        dt.Dispose()

                        If Picking = False Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_factura_cte", "@CTEClave", a.Cliente, "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@Todos", a.TodosClientes, "@CAJClave", a.Caja))
                            OpenReport.PrintPreview("Reporte de Resumen de Facturas", "CRFacturaResumen.rpt", pvtaDataSet, "")
                        Else
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_factura_cte_radec", "@CTEClave", a.Cliente, "@SUCClave", a.Sucursal, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@Todos", a.TodosClientes, "@CAJClave", a.Caja))
                            OpenReport.PrintPreview("Reporte de Resumen de Facturas", "CRFacturaResumenPicking.rpt", pvtaDataSet, "")
                        End If
                    End If
                    a.Dispose()

            Case "386"
                    Dim CAJClave As String
                    Dim inicio, fin As Date
                    Dim b As New MeFiltroCorte
                    b.Titulo = "Reporte de Corte de Caja"
                    b.ChkTicket.Visible = False
                    b.ShowDialog()
                    If b.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        CAJClave = b.CajaOrigen
                        inicio = CDate(b.FechaInicio)
                        fin = CDate(b.FechaFinal)
                    Else
                        CAJClave = ""
                    End If
                    b.Dispose()

                    If CAJClave <> "" Then
                        Dim a As New FrmBuscaCorte
                        a.inicio = inicio
                        a.fin = fin
                        a.CAJClave = CAJClave
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.IdCorte <> "" Then
                                Dim OpenReport As New Report
                                Dim pvtaDataSet As New DataSet
                                pvtaDataSet.DataSetName = "pvtaDataSet"
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", a.IdCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", a.IdCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_creditos", "@IdCorte", a.IdCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_otrospagos", "@IdCorte", a.IdCorte))


                                OpenReport.PrintPreview("Corte de Caja Detallado", "CRCorte.rpt", pvtaDataSet, "")
                            End If
                        End If
                        a.Dispose()
                    End If

            Case "387"
                    Dim b As New MeFiltroCorte
                    b.Titulo = "Reporte de Acumulado de Caja"
                    b.ChkTicket.Visible = False
                    b.GrpRango.Visible = False
                    b.ShowDialog()
                    If b.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", b.CajaOrigen)

                        Dim IDCorte As String = ""

                        If Not dt Is Nothing Then
                            If dt.Rows.Count > 0 Then
                                IDCorte = dt.Rows(0)("ID")

                                Dim OpenReport As New Report
                                Dim pvtaDataSet As New DataSet
                                pvtaDataSet.DataSetName = "pvtaDataSet"
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_reembolso", "@IdCorte", IDCorte))
                                OpenReport.PrintPreview("Acumulado", "CRAcumulado.rpt", pvtaDataSet, "")

                            Else
                                MessageBox.Show("No se encontro algun Corte de Caja pendiente de Cierre para la caja seleccionada")
                            End If
                            dt.Dispose()
                        End If

                    End If

            Case "388"
                    Dim b As New MeFiltroCobros
                    b.Titulo = "Reporte de Anticipos y Cobros"

                    b.ShowDialog()
                    If b.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_abonos", "@CAJClave", b.CajaOrigen, "@Todos", b.TodosMetodos, "@Metodo", b.MetodoPago, "@Inicio", CDate(b.FechaInicio), "@Fin", CDate(b.FechaFinal)))
                        OpenReport.PrintPreview("Anticipos y Cobros", "CRCobros.rpt", pvtaDataSet, "")

                    End If

            Case "389"
                    Dim a As New MeFiltroAlmUbc
                    a.Titulo = "Reporte de Movimientos por Producto"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_Mov", "@ALMClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@PROClave", a.Producto, "@Origen", a.UBCOrigen, "@Destino", a.UBCDestino))
                        OpenReport.PrintPreview("Reporte de Movimientos por Producto", "CRMovMat.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "390"
                    Dim a As New MeFiltro
                    a.Text = "Reporte Mensual por Vendedor"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_VtaMensual", "@Inicio", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte  Mensual por Vendedor", "CRVtaVENMen.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "391"
                    Dim a As New MeFiltroAlm
                    a.Titulo = "Reporte de Sobrantes / Faltantes en Recibo"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_sobrantefaltante", "@SUCClave", a.Origen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.DataSetName = "reportDataSet"
                        OpenReport.PrintPreview("Reporte de Sobrantes / Faltantes en Recibo", "CRSobrante.rpt", pvtaDataSet, "")

                    End If
                    a.Dispose()


            Case "392"
                    Dim a As New MeFiltro
                    a.Text = "Reporte Relacion Ventas"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_RelacionVentasAYA", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Relacion de Ventas", "CRRelacionVentas.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "393"
                    Dim a As New MeFiltro
                    a.Text = "Reporte Relacion Cobranza"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_RelacionCobranzaAYA", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Relacion de Cobranza", "CRRelacionCobranzaAYA.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "394"
                    Dim a As New MeFiltroProd
                    a.Titulo = "Reporte de Compra por Producto"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_ComprasPRO", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal), "@PROClave", a.Producto))
                        OpenReport.PrintPreview("Reporte de Compra por Producto", "CRCompraMat.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "395"
                    Dim a As New MeFiltro
                    a.Text = "Reporte Pedidos sin Facturar"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_PedXFAC", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte Pedidos sin Facturar", "CRPedidosXFAC.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "396"
                    Dim a As New MeFiltroVen
                    a.Titulo = "Reporte de Notas de Crédito Detallado"
                    a.Tabla = "NC"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_nc", "@Todos", a.VentasTodos, "@Tipo", a.VentaTipo, "@Canceladas", a.VentaEstado, "@SUCClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Notas de Crédito Detallado", "CRNotaCreditoDet.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "397"
                    Dim a As New MeFiltroVen
                    a.Titulo = "Reporte de Notas de Cargo Detallado"
                    a.CmbVenta.Visible = False
                    a.ChkTodos.Visible = False
                    a.lblTipo.Visible = False
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "reportDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_notacargo", "@Canceladas", a.VentaEstado, "@SUCClave", a.SucursalOrigen, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                        OpenReport.PrintPreview("Reporte de Notas de Cargo Detallado", "CRNotaCargoDet.rpt", pvtaDataSet, "")
                    End If
                    a.Dispose()

            Case "398"

                    Dim a As New MeFiltroCostoExcel
                    a.Text = "Analitica de Costos"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then

                    End If
                    a.Dispose()


            Case "401"
                    If ModPOS.SplashVenta Is Nothing Then
                        ModPOS.SplashVenta = New FrmSplashVenta
                        ModPOS.SplashVenta.MdiParent = MPrincipal
                        ModPOS.SplashVenta.FrmPadre = "Venta"
                    End If
                    ModPOS.SplashVenta.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.SplashVenta.Show()
                    ModPOS.SplashVenta.BringToFront()

            Case "402"
                    If ModPOS.MtoFacturas Is Nothing Then
                        ModPOS.MtoFacturas = New FrmMtoFacturas
                        ModPOS.MtoFacturas.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoFacturas.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoFacturas.Show()
                    ModPOS.MtoFacturas.BringToFront()

            Case "403"
                    If ModPOS.SplashVenta Is Nothing Then
                        ModPOS.SplashVenta = New FrmSplashVenta
                        ModPOS.SplashVenta.FrmPadre = "Caja"
                        ModPOS.SplashVenta.Label5.Text = "Abrir Caja"
                        ModPOS.SplashVenta.GrpVenta.Text = "Caja"
                        ModPOS.SplashVenta.MdiParent = MPrincipal
                    End If
                    ModPOS.SplashVenta.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.SplashVenta.Show()
                    ModPOS.SplashVenta.BringToFront()


            Case "404"
                    If ModPOS.MtoPrecio Is Nothing Then
                        ModPOS.MtoPrecio = New FrmMtoPrecio
                        ModPOS.MtoPrecio.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoPrecio.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoPrecio.Show()
                    ModPOS.MtoPrecio.BringToFront()

            Case "405"
                    If ModPOS.MtoDesCte Is Nothing Then
                        ModPOS.MtoDesCte = New FrmMtoDescuento
                        ModPOS.MtoDesCte.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoDesCte.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoDesCte.Show()
                    ModPOS.MtoDesCte.BringToFront()

            Case "406"
                    If ModPOS.MtoPromocion Is Nothing Then
                        ModPOS.MtoPromocion = New FrmMtoPromocion
                        ModPOS.MtoPromocion.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoPromocion.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoPromocion.Show()
                    ModPOS.MtoPromocion.BringToFront()


            Case "407"
                    If ModPOS.MtoComision Is Nothing Then
                        ModPOS.MtoComision = New FrmMtoComision
                        ModPOS.MtoComision.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoComision.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoComision.Show()
                    ModPOS.MtoComision.BringToFront()

            Case "408"
                    If ModPOS.Apartados Is Nothing Then
                        ModPOS.Apartados = New FrmCancelApartado
                        ModPOS.Apartados.MdiParent = MPrincipal
                    End If
                    ModPOS.Apartados.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Apartados.Show()
                    ModPOS.Apartados.BringToFront()

            Case "409"
                    If ModPOS.MtoNC Is Nothing Then
                        ModPOS.MtoNC = New FrmMtoNC
                        ModPOS.MtoNC.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoNC.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoNC.Show()
                    ModPOS.MtoNC.BringToFront()


            Case "410"
                    If ModPOS.actCosto Is Nothing Then
                        ModPOS.actCosto = New FrmActCosto
                        ModPOS.actCosto.MdiParent = MPrincipal

                    End If
                    ModPOS.actCosto.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.actCosto.Show()
                    ModPOS.actCosto.BringToFront()

            Case "411"
                    If ModPOS.SplashVenta Is Nothing Then
                        ModPOS.SplashVenta = New FrmSplashVenta
                        ModPOS.SplashVenta.MdiParent = MPrincipal
                        ModPOS.SplashVenta.FrmPadre = "Verificar"
                        ModPOS.SplashVenta.Label5.Text = "Iniciar Verificador de Precios"
                    End If
                    ModPOS.SplashVenta.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.SplashVenta.Show()
                    ModPOS.SplashVenta.BringToFront()


            Case "412"
                    If ModPOS.MtoNotaCargo Is Nothing Then
                        ModPOS.MtoNotaCargo = New FrmMtoNotaCargo
                        ModPOS.MtoNotaCargo.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoNotaCargo.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoNotaCargo.Show()
                    ModPOS.MtoNotaCargo.BringToFront()


            Case "413"
                    If ModPOS.ComplementoPago Is Nothing Then
                        ModPOS.ComplementoPago = New FrmComplementoPago
                        ModPOS.ComplementoPago.MdiParent = MPrincipal

                    End If
                    ModPOS.ComplementoPago.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.ComplementoPago.Show()
                    ModPOS.ComplementoPago.BringToFront()


            Case "414"
                    If ModPOS.LiberaPOS Is Nothing Then
                        ModPOS.LiberaPOS = New FrmLiberarPOS
                        ModPOS.LiberaPOS.MdiParent = MPrincipal

                    End If
                    ModPOS.LiberaPOS.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.LiberaPOS.Show()
                    ModPOS.LiberaPOS.BringToFront()


            Case "415"
                    If ModPOS.MtoRegValores Is Nothing Then
                        ModPOS.MtoRegValores = New FrmMtoRegValores
                        ModPOS.MtoRegValores.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoRegValores.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoRegValores.Show()
                ModPOS.MtoRegValores.BringToFront()

            Case "416"
                If ModPOS.Rechazos Is Nothing Then
                    ModPOS.Rechazos = New FrmRechazos
                    ModPOS.Rechazos.MdiParent = MPrincipal
                End If
                ModPOS.Rechazos.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Rechazos.Show()
                ModPOS.Rechazos.BringToFront()

            Case "500"
                    If ModPOS.MtoOrdenes Is Nothing Then
                        ModPOS.MtoOrdenes = New FrmMtoOrdenes
                        ModPOS.MtoOrdenes.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoOrdenes.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoOrdenes.Show()
                    ModPOS.MtoOrdenes.BringToFront()

            Case "501"
                    If ModPOS.MtoCompras Is Nothing Then
                        ModPOS.MtoCompras = New FrmMtoCompras
                        ModPOS.MtoCompras.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoCompras.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoCompras.Show()
                    ModPOS.MtoCompras.BringToFront()

            Case "502"
                    If ModPOS.CxP Is Nothing Then
                        ModPOS.CxP = New FrmPagoCXP
                        ModPOS.CxP.MdiParent = MPrincipal
                    End If
                    ModPOS.CxP.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.CxP.Show()
                    ModPOS.CxP.BringToFront()

            Case "503"
                    If ModPOS.MtoDevCompra Is Nothing Then
                        ModPOS.MtoDevCompra = New FrmMtoDevCompra
                        ModPOS.MtoDevCompra.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoDevCompra.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoDevCompra.Show()
                    ModPOS.MtoDevCompra.BringToFront()

            Case "504"
                    If ModPOS.NCProveedor Is Nothing Then
                        ModPOS.NCProveedor = New FrmNCProvedor
                        ModPOS.NCProveedor.MdiParent = MPrincipal

                    End If
                    ModPOS.NCProveedor.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.NCProveedor.Show()
                    ModPOS.NCProveedor.BringToFront()

            Case "601"
                    If ModPOS.Principal Is Nothing Then
                        ModPOS.Principal = New FrmLayout

                    End If
                    ModPOS.Principal.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Principal.Show()
                    ModPOS.Principal.BringToFront()

            Case "602"
                    If ModPOS.Reubicacion Is Nothing Then
                        ModPOS.Reubicacion = New FrmReubicacion
                        ModPOS.Reubicacion.MdiParent = MPrincipal
                    End If
                    ModPOS.Reubicacion.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Reubicacion.Show()
                    ModPOS.Reubicacion.BringToFront()

            Case "603"
                    If ModPOS.MtoConteo Is Nothing Then
                        ModPOS.MtoConteo = New FrmMtoConteo
                        ModPOS.MtoConteo.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoConteo.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoConteo.Show()
                    ModPOS.MtoConteo.BringToFront()

            Case "604"
                    If ModPOS.MtoExistencia Is Nothing Then
                        ModPOS.MtoExistencia = New FrmMtoExistencia
                        ModPOS.MtoExistencia.MdiParent = MPrincipal

                    End If
                    ModPOS.MtoExistencia.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoExistencia.Show()
                    ModPOS.MtoExistencia.BringToFront()

            Case "605"
                    If ModPOS.MtoTraslados Is Nothing Then
                        ModPOS.MtoTraslados = New FrmMtoTraslados
                        ModPOS.MtoTraslados.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoTraslados.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoTraslados.Show()
                    ModPOS.MtoTraslados.BringToFront()

            Case "606"
                    If ModPOS.MtoIngresos Is Nothing Then
                        ModPOS.MtoIngresos = New FrmMtoIngreso
                        ModPOS.MtoIngresos.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoIngresos.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoIngresos.Show()
                    ModPOS.MtoIngresos.BringToFront()

            Case "607"
                    If ModPOS.Surtido Is Nothing Then
                        ModPOS.Surtido = New FrmSurtido
                        ModPOS.Surtido.MdiParent = MPrincipal
                    End If
                    ModPOS.Surtido.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Surtido.Show()
                    ModPOS.Surtido.BringToFront()


            Case "608"
                    If ModPOS.MtoAcondicionado Is Nothing Then
                        ModPOS.MtoAcondicionado = New FrmMtoAcondicionado
                        ModPOS.MtoAcondicionado.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoAcondicionado.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoAcondicionado.Show()
                    ModPOS.MtoAcondicionado.BringToFront()
            Case "609"
                    If ModPOS.Pedidos Is Nothing Then
                        ModPOS.Pedidos = New FrmPedidos
                        ModPOS.Pedidos.MdiParent = MPrincipal
                    End If
                    ModPOS.Pedidos.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Pedidos.Show()
                    ModPOS.Pedidos.BringToFront()


            Case "610"
                    If ModPOS.Recibo Is Nothing Then
                        ModPOS.Recibo = New FrmRecibo
                        ModPOS.Recibo.MdiParent = MPrincipal
                    End If
                    ModPOS.Recibo.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Recibo.Show()
                    ModPOS.Recibo.BringToFront()


            Case "611"
                    If ModPOS.MtoTransferencia Is Nothing Then
                        ModPOS.MtoTransferencia = New FrmMtoMOVALM
                        ModPOS.MtoTransferencia.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoTransferencia.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoTransferencia.Show()
                    ModPOS.MtoTransferencia.BringToFront()
            Case "612"
                    If ModPOS.MtoSalida Is Nothing Then
                        ModPOS.MtoSalida = New FrmMtoSalida
                        ModPOS.MtoSalida.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoSalida.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoSalida.Show()
                    ModPOS.MtoSalida.BringToFront()

            Case "701"
                    If ModPOS.Backup Is Nothing Then
                        Cursor.Current = Cursors.WaitCursor
                        ModPOS.Backup = New FrmBackUp
                        ModPOS.Backup.MdiParent = MPrincipal
                        Cursor.Current = Cursors.Default
                    End If
                    ModPOS.Backup.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Backup.Show()
                    ModPOS.Backup.BringToFront()

            Case "702"
                    If ModPOS.Corte Is Nothing Then
                        ModPOS.Corte = New FrmCorte
                        ModPOS.Corte.MdiParent = MPrincipal

                    End If
                    ModPOS.Corte.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Corte.Show()
                    ModPOS.Corte.BringToFront()

            Case "703"
                    If ModPOS.Restaurar Is Nothing Then
                        ModPOS.Restaurar = New FrmRestaurar
                        ModPOS.Restaurar.MdiParent = MPrincipal
                    End If
                    ModPOS.Restaurar.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Restaurar.Show()
                    ModPOS.Restaurar.BringToFront()

            Case "704"
                    Dim a As New Licencia
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Pass Then
                            MessageBox.Show("Licencia Actualizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                    a.Dispose()

            Case "705"
                    If ModPOS.RepMensual Is Nothing Then
                        ModPOS.RepMensual = New FrmRepMensual
                        ModPOS.RepMensual.MdiParent = MPrincipal

                    End If
                    ModPOS.RepMensual.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.RepMensual.Show()
                    ModPOS.RepMensual.BringToFront()

            Case "706"
                    Dim Inicio As Date
                    Dim Fin As Date
                    Dim SUCClave As String

                    Dim a As New MeFiltroAlm
                    a.Titulo = "Regenerar Comprobantes Fiscales Digitales"
                    a.textolbl = "Sucursal"
                    a.StoreProcedure = "sp_filtra_sucursal"
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Inicio = CDate(a.FechaInicio)
                        Fin = CDate(a.FechaFinal)
                        SUCClave = a.Origen


                    Else
                        Exit Sub
                    End If
                    a.Dispose()

                    If ModPOS.RegeneraCFD Is Nothing Then
                        ModPOS.RegeneraCFD = New FrmRegeneraCFD
                        ModPOS.RegeneraCFD.MdiParent = MPrincipal
                        ModPOS.RegeneraCFD.Inicio = Inicio
                        ModPOS.RegeneraCFD.Fin = Fin
                        ModPOS.RegeneraCFD.SUCClave = SUCClave
                    End If
                    ModPOS.RegeneraCFD.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.RegeneraCFD.Show()
                    ModPOS.RegeneraCFD.BringToFront()

            Case "707"
                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.Show("Reindexando la Base de Datos...")
                    ModPOS.Ejecuta("SPReindexarBD", Nothing)
                    frmStatusMessage.Dispose()

            Case "708"
                    If ModPOS.ReiniciaInv Is Nothing Then
                        ModPOS.ReiniciaInv = New FrmReiniciaInv
                        ModPOS.ReiniciaInv.MdiParent = MPrincipal
                    End If
                    ModPOS.ReiniciaInv.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.ReiniciaInv.Show()
                    ModPOS.ReiniciaInv.BringToFront()

            Case "709"
                    If ModPOS.Sync Is Nothing Then
                        ModPOS.Sync = New FrmSync
                        ModPOS.Sync.MdiParent = MPrincipal
                    End If
                    ModPOS.Sync.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Sync.Show()
                    ModPOS.Sync.BringToFront()

            Case "710"
                    Dim a As New FrmInterfaz
                    a.ShowDialog()
                    a.Dispose()

            Case "711"
                    If ModPOS.PrintServer Is Nothing Then
                        ModPOS.PrintServer = New FrmPrintServer
                        ModPOS.PrintServer.MdiParent = MPrincipal
                    End If
                    ModPOS.PrintServer.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.PrintServer.Show()
                    ModPOS.PrintServer.BringToFront()

            Case "712"
                    If ModPOS.LogError Is Nothing Then
                        ModPOS.LogError = New FrmLog
                        ModPOS.LogError.MdiParent = MPrincipal
                    End If
                    ModPOS.LogError.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.LogError.Show()
                    ModPOS.LogError.BringToFront()

            Case "713"
                    If ModPOS.InvoiceServer Is Nothing Then
                        ModPOS.InvoiceServer = New FrmInvoiceServer
                        ModPOS.InvoiceServer.MdiParent = MPrincipal
                    End If
                    ModPOS.InvoiceServer.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.InvoiceServer.Show()
                    ModPOS.InvoiceServer.BringToFront()

            Case "801"
                    If ModPOS.MtoLiquid Is Nothing Then
                        ModPOS.MtoLiquid = New FrmMtoLiquid
                        ModPOS.MtoLiquid.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoLiquid.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoLiquid.Show()
                    ModPOS.MtoLiquid.BringToFront()

            Case "802"
                    If ModPOS.MtoContenedor Is Nothing Then
                        ModPOS.MtoContenedor = New FrmMtoContenedor
                        ModPOS.MtoContenedor.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoContenedor.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoContenedor.Show()
                    ModPOS.MtoContenedor.BringToFront()

            Case "803"
                    If ModPOS.MtoTransporte Is Nothing Then
                        ModPOS.MtoTransporte = New FrmMtoTransporte
                        ModPOS.MtoTransporte.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoTransporte.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoTransporte.Show()
                    ModPOS.MtoTransporte.BringToFront()

            Case "804"
                    If ModPOS.MtoTarifa Is Nothing Then
                        ModPOS.MtoTarifa = New FrmMtoTarifa
                        ModPOS.MtoTarifa.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoTarifa.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoTarifa.Show()
                    ModPOS.MtoTarifa.BringToFront()


            Case "805"
                    If ModPOS.MtoViaje Is Nothing Then
                        ModPOS.MtoViaje = New FrmMtoViaje
                        ModPOS.MtoViaje.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoViaje.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoViaje.Show()
                    ModPOS.MtoViaje.BringToFront()

            Case "806"
                    If ModPOS.MtoGasto Is Nothing Then
                        ModPOS.MtoGasto = New FrmMtoGasto
                        ModPOS.MtoGasto.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoGasto.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoGasto.Show()
                    ModPOS.MtoGasto.BringToFront()


            Case "901"
                    If ModPOS.MtoPisos Is Nothing Then
                        ModPOS.MtoPisos = New FrmMtoPisos
                        ModPOS.MtoPisos.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoPisos.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoPisos.Show()
                    ModPOS.MtoPisos.BringToFront()



            Case "902"
                    If ModPOS.MtoModificadores Is Nothing Then
                        ModPOS.MtoModificadores = New FrmMtoModificadores
                        ModPOS.MtoModificadores.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoModificadores.Show()
                    ModPOS.MtoModificadores.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoModificadores.BringToFront()

            Case "1001"
                    If ModPOS.MtoEmpleados Is Nothing Then
                        ModPOS.MtoEmpleados = New FrmMtoEmpleados
                        ModPOS.MtoEmpleados.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoEmpleados.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoEmpleados.Show()
                    ModPOS.MtoEmpleados.BringToFront()

            Case "1002"
                    If ModPOS.MtoConceptos Is Nothing Then
                        ModPOS.MtoConceptos = New FrmMtoConceptos
                        ModPOS.MtoConceptos.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoConceptos.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoConceptos.Show()
                    ModPOS.MtoConceptos.BringToFront()


            Case "1003"
                    If ModPOS.MtoNomina Is Nothing Then
                        ModPOS.MtoNomina = New FrmMtoNomina
                        ModPOS.MtoNomina.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoNomina.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoNomina.Show()
                    ModPOS.MtoNomina.BringToFront()

            Case "1004"
                    If ModPOS.MtoMovEmpleado Is Nothing Then
                        ModPOS.MtoMovEmpleado = New FrmMtoMovEmpleado
                        ModPOS.MtoMovEmpleado.MdiParent = MPrincipal
                    End If
                    ModPOS.MtoMovEmpleado.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.MtoMovEmpleado.Show()
                    ModPOS.MtoMovEmpleado.BringToFront()
        End Select
    End Sub

    Private Sub FrmMenu_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Barra.Dispose()
        ModPOS.Barra = Nothing
    End Sub

End Class
