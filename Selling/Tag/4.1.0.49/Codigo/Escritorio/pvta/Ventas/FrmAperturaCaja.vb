Public Class FrmAperturaCaja
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
    Friend WithEvents LbNombre As System.Windows.Forms.Label
    Friend WithEvents LBTitulo As System.Windows.Forms.Label
    Friend WithEvents LbClave As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtTipoCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblOtros As System.Windows.Forms.Label
    Friend WithEvents GridCaja As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaCaja))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LbNombre = New System.Windows.Forms.Label()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.LBTitulo = New System.Windows.Forms.Label()
        Me.LbClave = New System.Windows.Forms.Label()
        Me.LbUsuario = New System.Windows.Forms.Label()
        Me.LbFecha = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridCaja = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTipoCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblOtros = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        'LbNombre
        '
        resources.ApplyResources(Me.LbNombre, "LbNombre")
        Me.LbNombre.Name = "LbNombre"
        '
        'BtnOk
        '
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Name = "BtnOk"
        '
        'LBTitulo
        '
        Me.LBTitulo.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LBTitulo, "LBTitulo")
        Me.LBTitulo.ForeColor = System.Drawing.Color.White
        Me.LBTitulo.Name = "LBTitulo"
        '
        'LbClave
        '
        resources.ApplyResources(Me.LbClave, "LbClave")
        Me.LbClave.Name = "LbClave"
        '
        'LbUsuario
        '
        resources.ApplyResources(Me.LbUsuario, "LbUsuario")
        Me.LbUsuario.Name = "LbUsuario"
        '
        'LbFecha
        '
        resources.ApplyResources(Me.LbFecha, "LbFecha")
        Me.LbFecha.Name = "LbFecha"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.GridCaja)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'GridCaja
        '
        resources.ApplyResources(Me.GridCaja, "GridCaja")
        Me.GridCaja.ColumnAutoResize = True
        Me.GridCaja.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCaja.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCaja.Name = "GridCaja"
        Me.GridCaja.RecordNavigator = True
        Me.GridCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox2.Controls.Add(Me.lblOtros)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'txtTipoCambio
        '
        resources.ApplyResources(Me.txtTipoCambio, "txtTipoCambio")
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTipoCambio.Value = 0.0R
        Me.txtTipoCambio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblOtros
        '
        resources.ApplyResources(Me.lblOtros, "lblOtros")
        Me.lblOtros.Name = "lblOtros"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'BtnCancelar
        '
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Name = "BtnCancelar"
        '
        'FrmAperturaCaja
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.LbUsuario)
        Me.Controls.Add(Me.LbClave)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.LbNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAperturaCaja"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    Public FormatoCorte As String
    Public reciboTicket As Integer = 1
    Public Impresora As String
    Public Generic As Boolean
    Public Recibo As String
    Public Accion As String
    Public CAJClave As String
    Public Referencia As String
    Public TotalRegistrado As Decimal
    Public IDCorte As String
    Public Cajon As Boolean = False
    Private TallaColor As Integer = 0
    Private dtMonto As DataTable
    Private Moneda, MonedaCambio, Descripcion As String
    Private dTipoCambio, dTipoCambioVenta As Decimal
    Private InterfazSalida As String
    Private bTipoCambio As Boolean


    Private Sub creaDetalle(ByVal Tipo As Integer)

        TotalRegistrado = GridCaja.GetTotal(GridCaja.CurrentTable.Columns("Monto"), Janus.Windows.GridEX.AggregateFunction.Sum)

        Dim i As Integer
        Dim foundRows() As DataRow

        If TotalRegistrado > 0 Then

            foundRows = dtMonto.Select("Monto > 0")
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)

                    ModPOS.Ejecuta("sp_inserta_corteDetalle", _
                                    "@IDCorte", IDCorte, _
                                    "@Tipo", Tipo, _
                                    "@TipoImporte", 1, _
                                    "@Cantidad", CInt(foundRows(i)("Cantidad")), _
                                    "@Denominacion", CDbl(foundRows(i)("Valor")), _
                                    "@Importe", CDbl(foundRows(i)("Monto")), _
                                    "@MONClave", Moneda, _
                                    "@TipoCambio", 1)
                Next
            End If

        End If

     
       
    End Sub

    Private Sub FrmAperturaCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LbFecha.Text = DateTime.Today.ToLongDateString

        Dim dtCaja As DataTable = ModPOS.SiExisteRecupera("sp_recupera_caja", "@Caja", Me.CAJClave)

        If Not dtCaja Is Nothing Then
            LbClave.Text = "Clave: " & dtCaja.Rows(0)("Clave")
            LbNombre.Text = "Nombre: " & dtCaja.Rows(0)("Nombre")
        End If

        Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

        If Not dtUsuario Is Nothing Then
            LbUsuario.Text = "Usuario: " & dtUsuario.Rows(0)("Nombre")
        End If

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))


                End Select
            Next
        End With
        dt.Dispose()

        If Moneda <> MonedaCambio Then
            lblOtros.Visible = True
            txtTipoCambio.Visible = True

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)

            If dt.Rows.Count > 0 Then
                lblOtros.Text = "Tipo de Cambio (" & dt.Rows(0)("Referencia") & ")"
                Descripcion = dt.Rows(0)("Descripcion")
                dTipoCambio = dt.Rows(0)("TipoCambio")
                dTipoCambioVenta = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", dt.Rows(0)("TipoCambio"), dt.Rows(0)("TipoCambioVenta"))
            Else
                lblOtros.Text = "Tipo de Cambio"
                Descripcion = ""
                dTipoCambio = 1
                dTipoCambioVenta = 1
                txtTipoCambio.Enabled = False
            End If





            dt.Dispose()
        Else
            dTipoCambio = 1
        End If

        txtTipoCambio.Text = dTipoCambio

        If Accion <> "Apertura" Then
            txtTipoCambio.Enabled = False
        End If


        dtMonto = ModPOS.Recupera_Tabla("sp_recupera_monto")

        GridCaja.DataSource = dtMonto
        GridCaja.RetrieveStructure(True)
        GridCaja.GroupByBoxVisible = False
        GridCaja.RootTable.Columns(0).Visible = False
        GridCaja.CurrentTable.Columns(1).Selectable = False
        GridCaja.CurrentTable.Columns(3).Selectable = False

       
        If Cajon = True Then
            AbrirCajon(Impresora)
        End If

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim ExisteDiferencias As Boolean = False

        If Accion = "Apertura" Then
            If IDCorte <> "" Then
                ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", TotalRegistrado, "@Usuario", ModPOS.UsuarioActual)
                creaDetalle(2)
            End If

            If dTipoCambio <> Math.Abs(CDbl(txtTipoCambio.Text)) AndAlso Math.Abs(CDbl(txtTipoCambio.Text)) > 0 Then

                If bTipoCambio = False Then
                    Dim bAutorizado As Boolean = False
                    Dim bSalir As Boolean = False
                    Dim sAutoriza As String = ""
                    Do

                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.sp = "st_filtra_tipocambio"
                        a.MontodeAutorizacion = 0
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            bAutorizado = a.Autorizado
                            sAutoriza = a.Autoriza
                        Else
                            bSalir = True
                        End If

                    Loop While bAutorizado = False AndAlso bSalir = False

                    If bAutorizado = True Then
                        dTipoCambio = Math.Abs(CDbl(txtTipoCambio.Text))
                        ModPOS.Ejecuta("sp_actualiza_moneda", "@MONClave", MonedaCambio, "@Descripcion", Descripcion, "@Estado", 1, "@TipoCambio", dTipoCambio, "@TipoCambioVenta", dTipoCambioVenta, "@Usuario", sAutoriza)
                    ElseIf bTipoCambio = False AndAlso bAutorizado = False Then
                        MessageBox.Show("El tipo de cambio No fue actualizado debido a que la operación no ha sido autorizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    dTipoCambio = Math.Abs(CDbl(txtTipoCambio.Text))
                    ModPOS.Ejecuta("sp_actualiza_moneda", "@MONClave", MonedaCambio, "@Descripcion", Descripcion, "@Estado", 1, "@TipoCambio", dTipoCambio, "@TipoCambioVenta", dTipoCambioVenta, "@Usuario", ModPOS.UsuarioActual)
                End If

            End If


            IDCorte = ModPOS.obtenerLlave
            ModPOS.Ejecuta("sp_crea_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", TotalRegistrado, "@Usuario", ModPOS.UsuarioActual)
            creaDetalle(1)

            If reciboTicket = 1 OrElse Cajon = True Then
                Dim StopPrint As Boolean = False

                Dim sPrintMessage As String = "¿Desea Imprimir la Apertura de Caja?"
                Do
                    Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            imprimeTicketApertura(IDCorte, Impresora, Generic, Recibo)
                            sPrintMessage = "¿Desea Reimprimir la Apertura de Caja?"
                        Case Else
                            StopPrint = True
                    End Select
                Loop While Not StopPrint
            End If

        Else

            ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", TotalRegistrado, "@Usuario", ModPOS.UsuarioActual)
            creaDetalle(2)

            Dim dt As DataTable
            dt = Recupera_Tabla("st_recupera_efectivo", "@IDCorte", IDCorte)
            Dim MontoEfectivo As Decimal = 0
            Dim FondoCaja As Decimal = 0
            Dim sAutoriza As String = ModPOS.UsuarioActual

            If dt.Rows.Count > 0 Then
                MontoEfectivo = CDec(dt.Rows(0)("Efectivo"))
                FondoCaja = CDec(dt.Rows(0)("FondoCaja"))

                If TotalRegistrado < Redondear(MontoEfectivo, 2) AndAlso Redondear(Math.Abs(TotalRegistrado - MontoEfectivo), 2) >= 0.01 Then
                    MessageBox.Show("Se identifico un faltante de Efectivo en el corte de: " & Strings.Format(Redondear(TotalRegistrado - MontoEfectivo, 2).ToString, "Currency"), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'solicita autorizacion y motivo 

                    Dim bmotivo As Boolean = False
                    Dim MotDiferencia As Integer



                    Dim bAutorizado As Boolean = False
                    Do

                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.sp = "st_filtra_precorte"
                        a.MontodeAutorizacion = 0
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            bAutorizado = a.Autorizado
                            sAutoriza = a.Autoriza
                        End If

                    Loop While bAutorizado = False


                    If bAutorizado Then
                        Do
                            Dim m As New FrmMotivo
                            m.Tabla = "CorteCaja"
                            m.Campo = "Diferencia"
                            m.Text = "Motivos de Diferencia"
                            m.ShowDialog()
                            If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                bmotivo = True
                                MotDiferencia = m.Motivo
                                ExisteDiferencias = True
                            End If
                            m.Dispose()
                        Loop While bmotivo = False
                    End If

                    ModPOS.Ejecuta("st_act_cortecaja", "@IDCorte", IDCorte, "@Importe", Redondear(TotalRegistrado - MontoEfectivo, 2), "@Motivo", MotDiferencia, "@Autoriza", sAutoriza)

                ElseIf TotalRegistrado > Redondear(MontoEfectivo, 2) AndAlso Redondear(Math.Abs(TotalRegistrado - MontoEfectivo), 2) >= 0.01 Then

                    MessageBox.Show("Se identifico un sobrante de Efectivo en el corte de: " & Strings.Format(Redondear(TotalRegistrado - MontoEfectivo, 2).ToString, "Currency"), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'solicita autorizacion y motivo 

                    Dim bmotivo As Boolean = False
                    Dim MotDiferencia As Integer

                    Dim bAutorizado As Boolean = False
                    Do
                        Dim a As New MeAutorizacion
                        a.Sucursal = SUCClave
                        a.sp = "st_filtra_precorte"
                        a.MontodeAutorizacion = Redondear(TotalRegistrado - MontoEfectivo, 2)
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            bAutorizado = a.Autorizado
                            sAutoriza = a.Autoriza
                        End If

                    Loop While bAutorizado = False


                    If bAutorizado Then
                        Do
                            Dim m As New FrmMotivo
                            m.Tabla = "CorteCaja"
                            m.Campo = "Diferencia"
                            m.Text = "Motivos de Diferencia"
                            m.ShowDialog()
                            If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                bmotivo = True
                                MotDiferencia = m.Motivo
                                ExisteDiferencias = True
                            End If
                            m.Dispose()
                        Loop While bmotivo = False
                    End If

                    ModPOS.Ejecuta("st_act_cortecaja", "@IDCorte", IDCorte, "@Importe", Redondear(Math.Abs(TotalRegistrado - MontoEfectivo), 2), "@Motivo", MotDiferencia, "@Autoriza", sAutoriza)



                End If
            End If
            dt.Dispose()

            If InterfazSalida <> "" AndAlso ExisteDiferencias Then
                Dim dtInterfaz As DataTable = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Gastos", "@COMClave", ModPOS.CompanyActual)
                If dtInterfaz.Rows.Count > 0 Then
                    Dim sFecha As String = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", IDCorte, "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", -1)
                End If
            End If

            Dim Folio As String = ObtenerFolioRetiro(CAJClave, Referencia)

           
            If TotalRegistrado > FondoCaja Then
                ModPOS.Ejecuta("sp_inserta_retiro", _
                         "@CAJClave", CAJClave, _
                         "@Folio", Folio, _
                         "@Usuario", sAutoriza, _
                         "@Importe", TotalRegistrado - FondoCaja, _
                         "@MONClave", Moneda, _
                         "@TipoCambio", 1, _
                         "@Motivo", "CORTE DE CAJA", _
                         "@Tipo", 1, _
                         "@TipoMotivo", 3)

            End If
            'Valida si existen cuentas Beneficiarias para la sucursal

            dt = ModPOS.Recupera_Tabla("st_muestra_sucursalpago", "@SUCClave", SUCClave)
            If dt.Rows.Count > 0 Then
                'Realiza la transferencia a Bancos

                Dim dtTransf As DataTable = ModPOS.Recupera_Tabla("st_detalle_transbanco", "@IdCorte", IDCorte, "@SUCClave", SUCClave, "@CAJClave", CAJClave)
                Cursor.Current = Cursors.WaitCursor
                Dim fila As Integer

                For fila = 0 To dtTransf.Rows.Count - 1
                    ModPOS.Ejecuta("st_transferencia_banco", _
                                 "@IdCorte", IDCorte, _
                                 "@TipoPago", dtTransf.Rows(fila)("TipoPago"), _
                                 "@MONClave", dtTransf.Rows(fila)("Moneda"), _
                                 "@Importe", dtTransf.Rows(fila)("Importe"), _
                                 "@TERClave", dtTransf.Rows(fila)("Terminal"), _
                                 "@Emisor", dtTransf.Rows(fila)("Emisor"), _
                                 "@BNKClave", dtTransf.Rows(fila)("BNKClave"), _
                                 "@CtaBeneficiario", dtTransf.Rows(fila)("CtaBeneficiario"), _
                                 "@Anticipo", 0, _
                                 "@Usuario", ModPOS.UsuarioActual)



                Next

                Cursor.Current = Cursors.Default

            End If
            dt.Dispose()



            Dim StopPrint As Boolean = False

            Dim sPrintMessage As String = "¿Desea Imprimir el Corte de Caja?"

            If reciboTicket = 0 Then

                dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
                Impresora = dt.Rows(0)("ImpresoraFac")
                dt.Dispose()

                dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
                Impresora = dt.Rows(0)("Referencia")
                dt.Dispose()
            End If

            Do
                Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        If reciboTicket = 1 Then
                            imprimeTicketCierre(IDCorte, Impresora, Generic, Recibo, FormatoCorte, SUCClave)
                        Else


                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "reportDataSet"

                            If TallaColor = 0 Then
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_creditos", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_tarjetaAmiga_det", "@IdCorte", IDCorte))
                                OpenReport.Print(1, "CRCorteCaja.rpt", pvtaDataSet, "", Impresora)


                            Else
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_cklass_det", "@IdCorte", IDCorte))
                                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_cklass", "@IdCorte", IDCorte))

                                OpenReport.Print(1, "crCorteTicket.rpt", pvtaDataSet, "", Impresora)


                            End If



                        End If
                        sPrintMessage = "¿Desea Reimprimir el Corte de Caja?"
                    Case Else
                        StopPrint = True
                End Select
            Loop While Not StopPrint


            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
    End Sub


    Private Sub GridCaja_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCaja.CellEdited
        If GridCaja.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridCaja.GetValue("Cantidad")) Then
                Dim Actual As Double
                Actual = GridCaja.GetValue("Valor") * Math.Abs(CDbl(GridCaja.GetValue("Cantidad")))
                GridCaja.SetValue("Monto", Actual)
            Else
                GridCaja.SetValue("Cantidad", 0)
            End If
        End If
    End Sub

    
  

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    
    Private Sub GridCaja_RecordUpdated(sender As Object, e As EventArgs) Handles GridCaja.RecordUpdated
        TotalRegistrado = GridCaja.GetTotal(GridCaja.CurrentTable.Columns(3), Janus.Windows.GridEX.AggregateFunction.Sum)
        lblTotal.Text = "Total " & Format(CStr(ModPOS.Redondear(TotalRegistrado, 2)), "Currency")

    End Sub

   
End Class


