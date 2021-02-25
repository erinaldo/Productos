Public Class FrmAperturaSimple
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
    Friend WithEvents lbTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaSimple))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LbNombre = New System.Windows.Forms.Label()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.LBTitulo = New System.Windows.Forms.Label()
        Me.LbClave = New System.Windows.Forms.Label()
        Me.LbUsuario = New System.Windows.Forms.Label()
        Me.LbFecha = New System.Windows.Forms.Label()
        Me.lbTipoCambio = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.txtTipoCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
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
        'lbTipoCambio
        '
        resources.ApplyResources(Me.lbTipoCambio, "lbTipoCambio")
        Me.lbTipoCambio.Name = "lbTipoCambio"
        '
        'BtnCancelar
        '
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Name = "BtnCancelar"
        '
        'txtTipoCambio
        '
        resources.ApplyResources(Me.txtTipoCambio, "txtTipoCambio")
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTipoCambio.Value = 0.0R
        Me.txtTipoCambio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GridDetalle
        '
        resources.ApplyResources(Me.GridDetalle, "GridDetalle")
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmAperturaSimple
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.lbTipoCambio)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.LbUsuario)
        Me.Controls.Add(Me.LbClave)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.LbNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAperturaSimple"
        Me.ShowInTaskbar = False
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

    Public IDCorte As String

    Public Cajon As Boolean = False
    Private TallaColor As Integer = 0
    Private dtDetalle As DataTable
    Private Moneda, MonedaCambio, Descripcion As String
    Private dTipoCambio, dTipoCambioVenta As Decimal
    Private InterfazSalida As String
    Private bTipoCambio As Boolean

    Private Sub creaDetalle(ByVal Tipo As Integer)

        Dim i As Integer
        For i = 0 To dtDetalle.Rows.Count - 1

            ModPOS.Ejecuta("sp_inserta_corteDetalle", _
                            "@IDCorte", IDCorte, _
                            "@Tipo", Tipo, _
                            "@TipoImporte", 1, _
                            "@Cantidad", 1, _
                            "@Denominacion", 1, _
                            "@Importe", dtDetalle.Rows(i)("Efectivo") * dtDetalle.Rows(i)("TipoCambio"), _
                            "@MONClave", dtDetalle.Rows(i)("MONClave"), _
                            "@TipoCambio", dtDetalle.Rows(i)("TipoCambio"))

        Next






        'Otros = txtDocumentos.Text

        'If Otros > 0 Then

        '    ModPOS.Ejecuta("sp_inserta_corteDetalle", _
        '                    "@IDCorte", IDCorte, _
        '                    "@Tipo", Tipo, _
        '                    "@TipoImporte", 3, _
        '                    "@Cantidad", 1, _
        '                    "@Importe", Otros)

        'End If
    End Sub

    Private Sub FrmAperturaSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim TipoCambio As Decimal = 0

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


        dtDetalle = ModPOS.CrearTabla("Efectivo", _
                                        "MONClave", "System.String", _
                                        "TipoCambio", "System.Decimal", _
                                        "Moneda", "System.String", _
                                        "Efectivo", "System.Decimal")


        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("MONClave").Visible = False
        GridDetalle.RootTable.Columns("TipoCambio").Visible = False
        GridDetalle.CurrentTable.Columns("Moneda").Selectable = False
        GridDetalle.RootTable.Columns("Moneda").Width = 60
        GridDetalle.RootTable.Columns("Efectivo").Width = 100

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)

        If dt.Rows.Count > 0 Then
            Descripcion = dt.Rows(0)("Descripcion")
            TipoCambio = dt.Rows(0)("TipoCambio")

            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("MONClave") = Moneda
            row1.Item("TipoCambio") = TipoCambio
            row1.Item("Moneda") = Descripcion
            row1.Item("Efectivo") = 0
            dtDetalle.Rows.Add(row1)
        End If
        dt.Dispose()


        If Moneda <> MonedaCambio Then
            lbTipoCambio.Visible = True
            txtTipoCambio.Visible = True

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)

            If dt.Rows.Count > 0 Then
                lbTipoCambio.Text = "Tipo de Cambio (" & dt.Rows(0)("Referencia") & ")"
                Descripcion = dt.Rows(0)("Descripcion")
                dTipoCambio = dt.Rows(0)("TipoCambio")
                dTipoCambioVenta = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", dt.Rows(0)("TipoCambio"), dt.Rows(0)("TipoCambioVenta"))
            Else
                lbTipoCambio.Text = "Tipo de Cambio"
                Descripcion = ""
                dTipoCambio = 1
                dTipoCambioVenta = 1
                txtTipoCambio.Enabled = False
            End If



            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("MONClave") = MonedaCambio
            row1.Item("TipoCambio") = dTipoCambio
            row1.Item("Moneda") = Descripcion
            row1.Item("Efectivo") = 0
            dtDetalle.Rows.Add(row1)

            dt.Dispose()
        Else
            dTipoCambio = TipoCambio
        End If

        txtTipoCambio.Text = dTipoCambio

        If Accion <> "Apertura" Then
            txtTipoCambio.Enabled = False
        End If

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



        Dim dtAutoriza As DataTable = ModPOS.Recupera_Tabla("sp_valida_autorizacion", "@SUCClave", SUCClave, "@Usuario", ModPOS.UsuarioActual)
        If dtAutoriza.Rows.Count = 1 Then
            bTipoCambio = IIf(dtAutoriza.Rows(0)("TipoCambio").GetType.Name <> "DBNull", dtAutoriza.Rows(0)("TipoCambio"), False)
        Else

            bTipoCambio = False
        End If
        dtAutoriza.Dispose()




        If Cajon = True Then
            AbrirCajon(Impresora)
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim TotalRegistrado As Double = 0
        Dim ExisteDiferencias As Boolean = False
        Dim i As Integer

        For i = 0 To dtDetalle.Rows.Count - 1
            TotalRegistrado += dtDetalle.Rows(i)("Efectivo") * dtDetalle.Rows(i)("TipoCambio")
        Next

        If Accion = "Apertura" Then
            If IDCorte <> "" Then
                ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", TotalRegistrado, "@Usuario", ModPOS.UsuarioActual)
                creaDetalle(2)
            End If

            If dTipoCambio <> Math.Abs(CDbl(txtTipoCambio.Text)) AndAlso Math.Abs(CDbl(txtTipoCambio.Text)) > 0 Then

                If bTipoCambio = False Then
                    Dim bAutorizado As Boolean = False
                    Dim bSalir As Boolean = False
                    Dim sAutoriza As String = ModPOS.UsuarioActual
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
            ModPOS.Ejecuta("sp_crea_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", TotalRegistrado, "@Usuario", ModPOS.UsuarioActual, "@TipoCambio", dTipoCambio)
            creaDetalle(1)


            If Cajon = True Then
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
            Dim sAutoriza As String = ""

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

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Efectivo" Then
            If IsNumeric(GridDetalle.GetValue("Efectivo")) Then
                If CDbl(GridDetalle.GetValue("Efectivo")) < 0 Then
                    MessageBox.Show("¡La cantidad de efectivo no debe ser menor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Efectivo", 0)
                End If
            Else
                GridDetalle.SetValue("Efectivo", 0)
            End If
        End If
    End Sub

    Private Sub txtTipoCambio_Leave(sender As Object, e As EventArgs) Handles txtTipoCambio.Leave
        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("MONClave = '" & MonedaCambio & "'")
        If foundRows.Length >= 1 Then
            If dTipoCambio <> Math.Abs(CDbl(txtTipoCambio.Text)) AndAlso Math.Abs(CDbl(txtTipoCambio.Text)) > 0 Then
                foundRows(0)("TipoCambio") = Math.Abs(CDbl(txtTipoCambio.Text))
            End If
        End If

    End Sub

  
End Class


