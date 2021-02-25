Imports System.Data.SqlServerCe

Public Class FormResumen
    Inherits System.Windows.Forms.Form

    Protected oCliente As Cliente
    Protected sVisitaClave As String
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListViewResumen As System.Windows.Forms.ListView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonTerminar As System.Windows.Forms.Button
    Friend WithEvents LabelResumen As System.Windows.Forms.Label
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    Private Property Cliente() As Cliente
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
        End Set
    End Property
    Private Property VisitaClave() As String
        Get
            Return sVisitaClave
        End Get
        Set(ByVal Value As String)
            sVisitaClave = Value
        End Set
    End Property

    Private refaVista As Vista
    Private bVentaSinSurtir As Boolean

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef refparoCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        Me.Cliente = New Cliente
        Me.Cliente = refparoCliente
        Me.VisitaClave = parsVisitaClave
        Me.ListViewResumen.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.mainMenu1) Then mainMenu1.Dispose()
        If Not IsNothing(Me.ListViewResumen) Then
            If Me.ListViewResumen.Columns.Count > 0 Then
                Me.ListViewResumen.Columns.Clear()
            End If
            ListViewResumen.Dispose()
        End If
        If Not IsNothing(Me.Timer1) Then Timer1.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListViewResumen = New System.Windows.Forms.ListView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonTerminar = New System.Windows.Forms.Button
        Me.LabelResumen = New System.Windows.Forms.Label
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListViewResumen)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonTerminar)
        Me.Panel1.Controls.Add(Me.LabelResumen)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ListViewResumen
        '
        Me.ListViewResumen.FullRowSelect = True
        Me.ListViewResumen.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewResumen.Location = New System.Drawing.Point(6, 28)
        Me.ListViewResumen.Name = "ListViewResumen"
        Me.ListViewResumen.Size = New System.Drawing.Size(228, 228)
        Me.ListViewResumen.TabIndex = 4
        Me.ListViewResumen.View = System.Windows.Forms.View.Details
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Enabled = False
        Me.ButtonRegresar.Location = New System.Drawing.Point(6, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 5
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonTerminar
        '
        Me.ButtonTerminar.Enabled = False
        Me.ButtonTerminar.Location = New System.Drawing.Point(87, 262)
        Me.ButtonTerminar.Name = "ButtonTerminar"
        Me.ButtonTerminar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonTerminar.TabIndex = 6
        Me.ButtonTerminar.Text = "ButtonTerminar"
        '
        'LabelResumen
        '
        Me.LabelResumen.Location = New System.Drawing.Point(8, 6)
        Me.LabelResumen.Name = "LabelResumen"
        Me.LabelResumen.Size = New System.Drawing.Size(230, 23)
        Me.LabelResumen.Text = "LabelResumen"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Enabled = False
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'FormResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormResumen"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Eventos generales de la forma "

    Private Sub FormVisitas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ButtonTerminar.Enabled = False
        Me.MenuItemRegresar.Enabled = False
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormResumen", refaVista) Then
            MenuItemRegresar.Enabled = True
            ButtonRegresar.Enabled = True
            ButtonTerminar.Enabled = True
            Exit Sub
        End If
        refaVista.CrearListView(Me.ListViewResumen, "ListViewResumen")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        System.Windows.Forms.Application.DoEvents()
        Me.LlenarResumen()
        Me.ListViewResumen.Focus()

        MenuItemRegresar.Enabled = True
        ButtonRegresar.Enabled = True
        ButtonTerminar.Enabled = True
        If Not oVendedor.motconfiguracion.ResumenMovimientos Then
            FormProcesando.PubSubProceso(refaVista.BuscarMensaje("MsgBox", "I0188"))
            ButtonContinuar_Click(ButtonTerminar, New System.EventArgs)
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        With ListViewResumen
            If .Items.Count > 0 Then
                Me.ButtonRegresar.Enabled = True
                Me.ButtonTerminar.Enabled = True
                .Items(0).Selected = True
                .Focus()
                Cursor.Current = Cursors.Default
                ButtonTerminar.Enabled = True
                Me.MenuItemRegresar.Enabled = True
            Else
                'ButtonRegresar.Focus()
                FormProcesando.PubSubProceso(refaVista.BuscarMensaje("MsgBox", "I0188"))
                Cursor.Current = Cursors.Default
                ButtonContinuar_Click(ButtonTerminar, New System.EventArgs)
            End If
        End With
    End Sub

#End Region

#Region " TabPage Visitas "

    Private Function ValidarLimiteCredito() As Boolean
        Dim res As Boolean = True
        Dim dtCFV As DataTable = oDBVen.RealizarConsultaSQL("SELECT ValidaLimite, LimiteCredito FROM CLIFormaVenta WHERE CFVTipo = 2 AND ClienteClave = '" + oCliente.ClienteClave + "'", "CLIFormaVenta")
        If (dtCFV.Rows.Count > 0) Then
            Dim filaCFV As DataRow = dtCFV.Rows(0)
            Dim limiteC As Double = Convert.ToDouble(filaCFV("LimiteCredito"))
            If CBool(filaCFV("ValidaLimite")) Then
                Dim strSQL = ""
                Dim valor As Double
                If oCliente.CriterioCredito <> 0 Then
                    If (CBool(oConHist.Campos("CobrarVentas"))) Then
                        valor = oDBVen.RealizarScalarSQL("SELECT case when sum(saldo * TipoCambio) is null then 0 else sum(saldo * TipoCambio) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0 ")
                        'Else
                        'valor = Convert.ToDouble(oDBVen.RealizarScalarSQL("SELECT case when sum(saldo * TipoCambio) is null then 0 else sum(saldo * TipoCambio) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 8 AND CFVTipo = 2 AND TipoFase > 0 and (TRP.VisitaClave1 is null and TRP.DiaClave1 is null) "))
                        'valor += Convert.ToDouble(oDBVen.RealizarScalarSQL("SELECT case when sum(saldo * TipoCambio) is null then 0 else sum(saldo * TipoCambio) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0 AND FacturaId is null and (TRP.VisitaClave1 is null and TRP.DiaClave1 is null) "))
                    End If
                    If Not oCliente.ActualizaSaldoCheque Then
                        Dim aGrupo As New ArrayList()
                        aGrupo.Add("EB")
                        Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
                        If sVarCodigos.Length > 0 Then
                            strSQL = "select case when sum(ad.importe * TRP.TipoCambio) is null then 0 else sum(ad.importe  * TRP.TipoCambio) end  from  abndetalle AD "
                            strSQL &= "inner join abntrp A on A.abnId = AD.ABNId "
                            strSQL &= "inner join transprod TRP on TRP.TransProdId = A.TransProdId "
                            strSQL &= "inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave "
                            strSQL &= "WHERE AD.TipoPago in(" & sVarCodigos & ") AND v.ClienteClave = '" + oCliente.ClienteClave
                            strSQL &= "' and TRP.CFVTipo = 2 and TRP.tipo = " & IIf(CBool(oConHist.Campos("CobrarVentas")), "1", "8")
                            strSQL &= " and TRP.tipofase >0"
                            valor += oDBVen.RealizarScalarSQL(strSQL)

                            strSQL = "select case when sum(abn.saldo * TRP.TipoCambio) is null then 0 else sum(abn.saldo * TRP.TipoCambio) end  from  abono ABN "
                            strSQL &= "inner join visita v on v.visitaclave = ABN.visitaclave and v.diaclave = ABN.diaclave inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId inner join TransProd TRP on TRP.TransProdID = ABT.TransProdID "
                            strSQL &= "WHERE v.ClienteClave = '" & oCliente.ClienteClave & "' AND ABN.ABNid not in("
                            strSQL &= "SELECT distinct abn1.abnid FROM abono abn1 "
                            strSQL &= "inner join abndetalle ad1 on abn1.abnid = ad1.abnid "
                            strSQL &= "inner join visita v1 on v1.visitaclave = ABN1.visitaclave and v1.diaclave = ABN1.diaclave "
                            strSQL &= "where v.ClienteClave = '" & oCliente.ClienteClave & "' and ad1.TipoPago in(" & sVarCodigos & ")) "
                            valor -= oDBVen.RealizarScalarSQL(strSQL)
                        End If
                    Else
                        strSQL = "select case when sum(abn.saldo * TRP.TipoCambio) is null then 0 else sum(abn.saldo * TRP.TipoCambio) end  from  abono ABN "
                        strSQL &= "inner join visita v on v.visitaclave = ABN.visitaclave and v.diaclave = ABN.diaclave inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId inner join TransProd TRP on TRP.TransProdID = ABT.TransProdID "
                        strSQL &= "WHERE v.ClienteClave = '" & oCliente.ClienteClave & "'"
                        valor -= oDBVen.RealizarScalarSQL(strSQL)
                    End If
                ElseIf oCliente.CriterioCredito = 0 Then
                    'valor = oDBVen.RealizarScalarSQL("SELECT case when sum(total) is null then 0 else sum(total) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase = 1")
                    valor = valor + oDBVen.RealizarScalarSQL("SELECT saldoefectivo FROM Cliente WHERE ClienteClave = '" + oCliente.ClienteClave + "';")
                End If

                valor = limiteC - valor
                If (valor < 0) Then
                    Dim porcentajeRiesgo As Double = Convert.ToDouble(oConHist.Campos("PorcentajeRiesgo"))
                    Dim Riesgo As Double = (limiteC * porcentajeRiesgo) / 100
                    If (Math.Abs(valor) > Riesgo) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0530").Replace("$0$", Math.Abs(valor).ToString()))
                        res = False
                    End If
                End If
            End If
        End If
        Return res
    End Function
    Private Function ValidacionVencimientoVenta() As Boolean
        Dim res As Boolean = True
        If oCliente.VencimientoVenta Then

            Dim valor As Double = 0
            Dim tipoMov As String = IIf(CBool(oConHist.Campos("CobrarVentas")), "1", "8")
            Dim strSQL As String = "select Count(*) from TransProd TRP "
            strSQL &= "inner join visita v on v.visitaclave = TRP.visitaclave and v.diaClave = TRP.Diaclave where "
            strSQL &= "v.ClienteClave = '" & oCliente.ClienteClave
            strSQL &= "' and TRP.Tipo = " + tipoMov + " AND TRP.tipofase <> 0 AND (TRP.VisitaClave = '" + sVisitaClave + "' OR TRP.VisitaClave1 = '" + sVisitaClave + "')"
            valor = oDBVen.EjecutarCmdScalarObjSQL(strSQL)
            If (Convert.ToUInt32(valor) > 0) Then
                strSQL = "select case when sum(saldo) is null then 0 else sum(saldo) end From transprod tr "
                strSQL &= "inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave "
                strSQL &= "where tr.FechaCobranza < dateadd(day,(- " & oCliente.DiasVencimiento.ToString() & "),getdate()) and "
                strSQL &= "v.clienteclave = '" & oCliente.ClienteClave & "' and "
                strSQL &= "(tr.tipo =" & tipoMov & ") and tr.VisitaClave <> '" & sVisitaClave & "' and tr.TipoFase <>0 "
                valor = oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                If (Not oCliente.ActualizaSaldoCheque) Then
                    'TODO: Probar Cambio TipoPago
                    Dim aGrupo As New ArrayList()
                    aGrupo.Add("EB")
                    Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
                    If sVarCodigos.Length > 0 Then
                        strSQL = "SELECT case when sum(ad.importe) is null then 0 else sum(ad.importe) end FROM Abntrp at "
                        strSQL &= "inner join abndetalle ad on ad.abnid = at.abnid "
                        strSQL &= "where ad.tipopago in(" & sVarCodigos & ") and at.transprodid in"
                        strSQL &= "(select tr.transprodid From transprod tr "
                        strSQL &= "inner join visita v on v.visitaclave = tr.visitaclave and v.diaclave = tr.diaclave "
                        strSQL &= "where tr.FechaCobranza < dateadd(day,(- " & oCliente.DiasVencimiento.ToString() & "),getdate()) and "
                        strSQL &= "v.clienteclave = '" & oCliente.ClienteClave & "' "
                        strSQL &= "and  (tr.tipo = " & tipoMov & ") and tr.VisitaClave <> '" & sVisitaClave & "' and tr.TipoFase <>0 )"
                        valor += oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                    End If
                End If

                If (valor > 0) Then
                    strSQL = "select count(*) From transprod tr "
                    strSQL &= "inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave "
                    strSQL &= "where tr.FechaCobranza < dateadd(day,(- " & oCliente.DiasVencimiento.ToString() & "),getdate()) and "
                    strSQL &= "v.clienteclave = '" & oCliente.ClienteClave & "' and "
                    strSQL &= "(tr.tipo =" & tipoMov & ") and tr.VisitaClave <> '" & sVisitaClave & "' and tr.TipoFase <>0 and tr.saldo>0"
                    valor = oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0531").Replace("$0$", valor.ToString()))
                    Return False
                ElseIf (Not CBool(oConHist.Campos("CobrarVentas"))) Then
                    strSQL = "SELECT count(*) FechaFactura FROM Cliente WHERE ClienteClave = '" & oCliente.ClienteClave & "' AND FechaFactura < dateadd(day,(- " & oCliente.DiasVencimiento.ToString() & "),getdate())"
                    valor = oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                    If (valor > 0) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0531").Replace("$0$", valor.ToString()))
                        Return False
                    End If
                End If
            End If

        End If
        Return res
    End Function

    Private Function ValidaContado() As Boolean
        Dim Regresa As Boolean = True
        Dim res As Object
        Dim limiteC As Double
        Dim strSQL As String
        Dim valor As Double
        Dim tipotrp As Integer = IIf(Convert.ToInt32(oConHist.Campos("CobrarVentas")) = 1, 1, 8)
        res = oDBVen.RealizarScalarSQL("select sum(saldo) from transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave where v.ClienteClave = '" + oCliente.ClienteClave + "' and TRP.CFVTipo = 1 and TRP.tipo = " + tipotrp.ToString() + " and TRP.tipofase >0")
        limiteC = Convert.ToDouble(res)
        res = oDBVen.EjecutarCmdScalarObjSQL("select ValidaPago from cliformaventa where ClienteClave = '" + oCliente.ClienteClave + "' and CFVTipo = 1")
        If (Not IsDBNull(res)) Then
            If (Convert.ToInt32(res) = 1) Then
                If (limiteC > 0) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0532"))
                    Return False
                End If
            End If
        End If
        Return Regresa
    End Function

    Private Function TerminarVisita() As Boolean
        bVentaSinSurtir = False
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            If Not (oConHist.Campos("VentaSinSurtir")) Then
                Dim dtVentasSinSurtir As DataTable = oDBVen.RealizarConsultaSQL("Select Folio from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase = 1 and TRP.ClienteClave ='" & oCliente.ClienteClave & "'", "VentasSinSurtir")
                If dtVentasSinSurtir.Rows.Count > 0 Then
                    Dim sFolios As String = String.Empty
                    For Each dr As DataRow In dtVentasSinSurtir.Rows
                        sFolios &= "'" & dr("Folio") & "',"
                    Next

                    If Len(sFolios) > 0 Then
                        sFolios = Microsoft.VisualBasic.Left(sFolios, sFolios.Length - 1)
                    End If
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0214").Replace("$0$", sFolios), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        bVentaSinSurtir = True
                        Return False
                    End If
                End If
            End If
        End If

        If (oConHist.Campos("TipoLimiteCredito") = 1) Then
            If (Not ValidarLimiteCredito()) Then
                Return False
            End If
            If (Not ValidaContado()) Then
                Return False
            End If

            If (Not ValidacionVencimientoVenta()) Then
                Return False
            End If
        End If

        g_NumeroVisitas += 1
        Try
            Dim sQuery As New System.Text.StringBuilder
            Dim blnMovimientos As Boolean = False
            sQuery.Append("select count(*) as Cantidad from TransProd Where (VisitaClave ='" & Me.VisitaClave & "' or VisitaClave1 ='" & Me.VisitaClave & "') and Tipo<>" & ServicesCentral.TiposTransProd.FondoCristal & " UNION ")
            sQuery.Append("select count(*) as Cantidad from Abono Where VisitaClave ='" & Me.VisitaClave & "' UNION ")
            sQuery.Append("select count(*) as Cantidad from AbonoProgramado Where VisitaClave ='" & Me.VisitaClave & "' UNION ")
            sQuery.Append("select count(*) as Cantidad from Encuesta Where VisitaClave ='" & Me.VisitaClave & "' UNION ")
            sQuery.Append("select count(*) as Cantidad from ImproductividadProd Where VisitaClave ='" & Me.VisitaClave & "' UNION ")
            sQuery.Append("select count(*) as Cantidad from ImproductividadVenta Where VisitaClave ='" & Me.VisitaClave & "' UNION ")
            sQuery.Append("select count(*) as Cantidad from MERDetalle Where VisitaClave ='" & Me.VisitaClave & "' UNION ")
            sQuery.Append("select count(*) as Cantidad from Solicitud Where VisitaClave ='" & Me.VisitaClave & "' ")
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Movimientos")

            If dt Is Nothing Then Return False
            For Each dr As DataRow In dt.Rows
                If dr("Cantidad") > 0 Then
                    blnMovimientos = True
                    Exit For
                End If
            Next
            dt.Dispose()

            If blnMovimientos Then
                oDBVen.EjecutarComandoSQL("UPDATE Visita SET FechaHoraFinal=" & UniFechaSQL(Now) & ",Enviado=0,MfechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE VisitaClave='" & Me.VisitaClave & "' AND DiaClave='" & oDia.DiaActual & "' and ClienteClave='" & Me.Cliente.ClienteClave & "'")
            Else
                oDBVen.EjecutarComandoSQL("DELETE FROM Visita WHERE VisitaClave='" & Me.VisitaClave & "' AND DiaClave='" & oDia.DiaActual & "' and ClienteClave='" & Me.Cliente.ClienteClave & "'")
            End If

            Dim iVisitas As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from visita where ClienteClave = '" & Me.Cliente.ClienteClave & "' and DiaClave ='" & oDia.DiaActual & "' and RUTClave='" & oAgenda.RutaActual.RUTClave & "'")

            If iVisitas <= 0 Then
                oDBVen.EjecutarComandoSQL("UPDATE Agenda SET Visitado=" & Cliente.TiposEstadosClientes.ClienteNoVisitado & " WHERE ClienteClave='" & Me.Cliente.ClienteClave & "' and DiaClave='" & oDia.DiaActual & "' and RUTClave='" & oAgenda.RutaActual.RUTClave & "'")
            Else
                oDBVen.EjecutarComandoSQL("UPDATE Agenda SET Visitado=" & Cliente.TiposEstadosClientes.ClienteVisitado & " WHERE ClienteClave='" & Me.Cliente.ClienteClave & "' and DiaClave='" & oDia.DiaActual & "' and RUTClave='" & oAgenda.RutaActual.RUTClave & "'")
            End If

            Dim grupos As New ArrayList
            grupos.Add("TerminarVisita")
            If ValorReferencia.RecuperaVARVGrupoConSinGrupo("REPORTEM", grupos).Count > 0 Then
                Dim oFormaReportes As New FormReportes(oDia, "REPORTEM", Me.VisitaClave)
                oFormaReportes.ImprimirTerminarVisita(Me.VisitaClave, oDia.DiaActual, Me.Cliente)
                oFormaReportes.Dispose()
                oFormaReportes = Nothing

            End If
            grupos = Nothing

        Catch ex As Exception
            Return False
        End Try

        If g_NumeroVisitas = oApp.MaximoVisitas Then
            Timer1.Enabled = True
            MsgBox(refaVista.BuscarMensaje("MsgBox", "I0125"), MsgBoxStyle.OkOnly)
            CDevice.SoftReset()
        End If

        Return True
    End Function

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTerminar.Click
        If Me.TerminarVisita() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            If bVentaSinSurtir Then
                ButtonRegresar_Click(Nothing, Nothing)
            Else
                Me.ButtonRegresar.Enabled = True
                Me.ButtonTerminar.Enabled = True
            End If
        End If
    End Sub

    Private Class ElementoResumen
        Protected sNombreModulo As String
        Protected sModuloMovDetalleClave As String
        Protected sFolio As String
        Protected sDescripcion As String
        Protected sFase As String

        Public Property NombreModulo() As String
            Get
                Return sNombreModulo
            End Get
            Set(ByVal Value As String)
                sNombreModulo = Value
            End Set
        End Property

        Public Property ModuloMovDetalleClave() As String
            Get
                Return sModuloMovDetalleClave
            End Get
            Set(ByVal Value As String)
                sModuloMovDetalleClave = Value
            End Set
        End Property
        Public Property Folio() As String
            Get
                Return sFolio
            End Get
            Set(ByVal Value As String)
                sFolio = Value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property Fase() As String
            Get
                Return sFase
            End Get
            Set(ByVal Value As String)
                sFase = Value
            End Set
        End Property
    End Class

    Private Event EventAgregarElementoResumen(ByRef refparoDataRow As DataRow, ByRef refparoElementoResumen As ElementoResumen)

    Public Function LlenarResumen() As Boolean
        Try
            ' Tabla de visitas del cliente en el dia
            Dim oModuloMovDet As New Modulos.GrupoModuloMovDetalle
            Dim aFoliosTransProd As New ArrayList
            ' Agregar aqui las funciones que obtienen movimientos
            Me.RecuperarFoliosTransProd(aFoliosTransProd)

            AddHandler EventAgregarElementoResumen, AddressOf LlenarElementoAbonos
            Me.RecuperarFoliosMovimiento(aFoliosTransProd, ServicesCentral.TiposModulosMovDet.Pagos, "Abono")
            RemoveHandler EventAgregarElementoResumen, AddressOf LlenarElementoAbonos

            AddHandler EventAgregarElementoResumen, AddressOf LlenarElementoImproductivos
            Me.RecuperarFoliosMovimiento(aFoliosTransProd, ServicesCentral.TiposModulosMovDet.Improductivo, "ImproductividadProd")
            Me.RecuperarFoliosMovimiento(aFoliosTransProd, ServicesCentral.TiposModulosMovDet.Improductivo, "ImproductividadVenta")
            RemoveHandler EventAgregarElementoResumen, AddressOf LlenarElementoImproductivos

            AddHandler EventAgregarElementoResumen, AddressOf LlenarElementoSolicitudes
            Me.RecuperarFoliosMovimiento(aFoliosTransProd, ServicesCentral.TiposModulosMovDet.Solicitudes, "Solicitud")
            RemoveHandler EventAgregarElementoResumen, AddressOf LlenarElementoSolicitudes

            ' Para cada visita/movimiento del dia/cliente
            Dim refListViewItem As ListViewItem
            For Each refElementoResumen As ElementoResumen In aFoliosTransProd
                With refElementoResumen
                    If .NombreModulo = String.Empty Then
                        oModuloMovDet.Recuperar(.ModuloMovDetalleClave)
                        refListViewItem = New ListViewItem(oModuloMovDet.Nombre)
                    Else
                        refListViewItem = New ListViewItem(.NombreModulo)
                    End If
                    refListViewItem.SubItems.Add(.Folio)
                    refListViewItem.SubItems.Add(.Descripcion)
                    refListViewItem.SubItems.Add(.Fase)
                    Me.ListViewResumen.Items.Add(refListViewItem)
                End With
            Next
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "LlenarResumen")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "LlenarResumen")
        End Try
        Return False
    End Function

    Private Function RecuperarFoliosTransProd(ByRef refparaVisitas As ArrayList) As Boolean
        ' Buscar el modulo
        Dim sConsultaSQL As New System.Text.StringBuilder
        sConsultaSQL.Append("SELECT TransProd.PCEModuloMovDetClave, TransProd.Folio, TransProd.Total, TransProd.Tipo,TransProd.TipoFase FROM TransProd ")
        sConsultaSQL.Append("INNER JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave AND TransProd.DiaClave = Visita.DiaClave ")
        sConsultaSQL.Append("WHERE Visita.ClienteClave = '" & Me.Cliente.ClienteClave & "' AND Visita.DiaClave='" & oDia.DiaActual & "' AND Visita.VisitaClave = '" & Me.VisitaClave & "' and not TransProd.Tipo in(" & ServicesCentral.TiposTransProd.FondoCristal & "," & ServicesCentral.TiposTransProd.BonificacionPorDetalle & ") ")
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            sConsultaSQL.Append(" UNION ")
            sConsultaSQL.Append("SELECT '' AS PCEModuloMovDetClave, TransProd.Folio, TransProd.Total, TransProd.Tipo,TransProd.TipoFase FROM TransProd ")
            sConsultaSQL.Append("INNER JOIN Visita ON TransProd.VisitaClave1 = Visita.VisitaClave AND TransProd.DiaClave1 = Visita.DiaClave ")
            sConsultaSQL.Append("WHERE Visita.ClienteClave = '" & Me.Cliente.ClienteClave & "' AND TransProd.DiaClave1='" & oDia.DiaActual & "' AND TransProd.VisitaClave1 = '" & Me.VisitaClave & "' and not TransProd.Tipo in(" & ServicesCentral.TiposTransProd.FondoCristal & "," & ServicesCentral.TiposTransProd.BonificacionPorDetalle & ") " & " and TransProd.VisitaClave1 <> TransProd.VisitaClave  ")
        End If
        sConsultaSQL.Append("ORDER BY TransProd.Folio")

        Dim DataTable As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "TransProd")
        If DataTable.Rows.Count = 0 Then
            DataTable.Dispose()
            Return False
        End If
        For Each refDataRow As DataRow In DataTable.Rows
            With refDataRow
                If Not .IsNull("PCEModuloMovDetClave") Then
                    Dim oElementoResumen As New ElementoResumen
                    oElementoResumen.Folio = IIf(.IsNull("Folio"), "", .Item("Folio"))
                    If .Item("PCEModuloMovDetClave") = "" Then
                        oElementoResumen.NombreModulo = refaVista.BuscarMensaje("MsgBox", "XReparto")
                    Else
                        oElementoResumen.ModuloMovDetalleClave = .Item("PCEModuloMovDetClave")
                    End If
                    oElementoResumen.Fase = ValorReferencia.BuscarEquivalente("TRPFASE", .Item("TipoFase"))
                    oElementoResumen.Descripcion = Format(.Item("Total"), oApp.FormatoDinero)
                    refparaVisitas.Add(oElementoResumen)
                ElseIf .Item("Tipo") = ServicesCentral.TiposTransProd.DevolucionDePrestamo Then
                    Dim oModuloMovDet As New Modulos.GrupoModuloMovDetalle
                    If oModuloMovDet.Recuperar(ServicesCentral.TiposModulosMovDet.DevolucionPrestamos) Then
                        Dim oElementoResumen As New ElementoResumen
                        oElementoResumen.Folio = IIf(.IsNull("Folio"), "", .Item("Folio"))
                        oElementoResumen.ModuloMovDetalleClave = oModuloMovDet.ModuloMovDetalleClave
                        oElementoResumen.Descripcion = Format(.Item("Total"), oApp.FormatoDinero)
                        oElementoResumen.Fase = ValorReferencia.BuscarEquivalente("TRPFASE", .Item("TipoFase"))
                        refparaVisitas.Add(oElementoResumen)
                    End If
                End If
            End With
        Next
        DataTable.Dispose()
        Return refparaVisitas.Count <> 0
    End Function

    Private Function RecuperarFoliosMovimiento(ByRef refparaVisitas As ArrayList, _
                                                            ByVal partTipoModuloMovDet As ServicesCentral.TiposModulosMovDet, _
                                                            ByVal parsNombreTabla As String) As Boolean
        Dim sConsultaSQL As String = "SELECT " & parsNombreTabla & ".* FROM " & parsNombreTabla & " "
        sConsultaSQL &= "INNER JOIN Visita ON " & parsNombreTabla & ".VisitaClave = Visita.VisitaClave AND " & parsNombreTabla & ".DiaClave = Visita.DiaClave "
        sConsultaSQL &= "WHERE (Visita.ClienteClave = '" & Me.Cliente.ClienteClave & "' AND Visita.DiaClave='" & oDia.DiaActual & "' AND Visita.VisitaClave = '" & Me.VisitaClave & "')"
        Dim DataTable As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL, "Movtos")
        If DataTable.Rows.Count = 0 Then
            DataTable.Dispose()
            Return False
        End If
        Dim sNombreModulo As String = String.Empty
        Dim sModuloMovDetalle As String = String.Empty
        If partTipoModuloMovDet = ServicesCentral.TiposModulosMovDet.Pagos Then
            sNombreModulo = refaVista.BuscarMensaje("MsgBox", "XAbonos")
        Else
            Dim oModuloMovDet As New Modulos.GrupoModuloMovDetalle
            oModuloMovDet.Recuperar(partTipoModuloMovDet)
            sModuloMovDetalle = oModuloMovDet.ModuloMovDetalleClave()
        End If
        For Each refDataRow As DataRow In DataTable.Rows
            With refDataRow
                Dim oElementoResumen As New ElementoResumen
                oElementoResumen.NombreModulo = sNombreModulo
                oElementoResumen.ModuloMovDetalleClave = sModuloMovDetalle
                RaiseEvent EventAgregarElementoResumen(refDataRow, oElementoResumen)
                refparaVisitas.Add(oElementoResumen)
            End With
        Next
        DataTable.Dispose()
        Return refparaVisitas.Count <> 0
    End Function

    Private Sub LlenarElementoImproductivos(ByRef refparoDataRow As DataRow, ByRef refparoElementoResumen As ElementoResumen)
        refparoElementoResumen.Folio = "N/A"
        refparoElementoResumen.Descripcion = ValorReferencia.BuscarEquivalente("MOTIMPRO", refparoDataRow("TipoMotivo"))
        refparoElementoResumen.Fase = refaVista.BuscarMensaje("MsgBox", "XActivo")
    End Sub

    Private Sub LlenarElementoSolicitudes(ByRef refparoDataRow As DataRow, ByRef refparoElementoResumen As ElementoResumen)
        refparoElementoResumen.Folio = refparoDataRow.Item("Folio")
        refparoElementoResumen.Descripcion = ValorReferencia.BuscarEquivalente("SOLTAREA", refparoDataRow("TipoArea"))
        refparoElementoResumen.Fase = ValorReferencia.BuscarEquivalente("EDOREG", refparoDataRow.Item("TipoEstado"))
    End Sub

    Private Sub LlenarElementoAbonos(ByRef refparoDataRow As DataRow, ByRef refparoElementoResumen As ElementoResumen)
        refparoElementoResumen.Folio = refparoDataRow.Item("Folio")
        refparoElementoResumen.Descripcion = Format(refparoDataRow("Total"), oApp.FormatoDinero)
        refparoElementoResumen.Fase = refaVista.BuscarMensaje("MsgBox", "XActivo")
    End Sub

#End Region


    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonContinuar_Click(Nothing, Nothing)
        'ButtonRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        CDevice.SoftReset()
    End Sub
End Class
