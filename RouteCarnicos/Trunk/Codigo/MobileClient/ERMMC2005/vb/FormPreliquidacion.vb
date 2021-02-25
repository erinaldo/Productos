Public Class FormPreliquidacion
#Region "Variables"
    Private refaVista As Vista
    Private htDenominacion As Hashtable
    Private nTotalPreliquidacion As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Private nRestoPreliquidacion As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Private nMontoPreliquidacion As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Private nTotalDeposito As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Private nTotalEfectivo As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Private nTotalAnterior As Decimal
    Private nCantAnterior As Integer
    Private sDenominacionIDAnterior As String = ""
    Private sTipoAnterior As String
    Private dFechaPreliquidacion As Date
    Private bNuevaPreliquidacion As Boolean
    Private bHayCambios As Boolean
    Private lDetalle As System.Collections.Generic.List(Of String)
    Private bCargando As Boolean
    Private bActualizar As Boolean
    Private nRowActualizar As Integer
    Private nColActualizar As Integer
    Private bEliminando As Boolean
    Private nDiferenciaPreliquiMon As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Private sPLIId As New System.Collections.Generic.Dictionary(Of String, String)
    Private bValidar As Boolean = True
    Private bValidarCambiarTab As Boolean = True
#End Region

#Region "Propiedades"
    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub FormPreliquidacion_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormPreliquidacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not MobileClient.Vista.Buscar("FormPreliquidacion", refaVista) Then
            Exit Sub
        End If
        bCargando = True
        ConfiguraGridDeposito()
        ConfiguraGridEfectivo()
        TextBoxTotalDeposito.Visible = False

        TextBoxTotalEfectivo.Visible = False

        ConfiguraGridMoneda(C1FlexGridDepositoMoneda)
        ConfiguraGridMoneda(C1FlexGridEfectivoMoneda)

        refaVista.ColocarEtiquetasForma(Me)
        If ValidarExistePreliquidacion() Then
            htDenominacion = New Hashtable
            lDetalle = New System.Collections.Generic.List(Of String)
            LlenarGridDeposito()
            CrearNuevaFila(C1FlexGridDeposito)

            LlenarGridEfectivo5()

            CrearNuevaFila(C1FlexGridEfectivo, 1)
            ActualizarRestoPreliquidacion()
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Transaccion = oDBVen.oConexion.BeginTransaction
            If bNuevaPreliquidacion Then
                GuardaPreliquidacion(True)
            End If
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select MonedaId, PLIMargen from Moneda", "Moneda")
            For Each fila As DataRow In dt.Rows
                nDiferenciaPreliquiMon.Add(fila("MonedaId"), fila("PLIMargen"))
            Next
            'nDiferenciaPreliqui = IIf(IsDBNull(oConHist.Campos("DiferenciaPreliqui")), 0, oConHist.Campos("DiferenciaPreliqui"))
            bCargando = False
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "I0156"), MsgBoxStyle.Information)
            Me.Close()
        End If

    End Sub

    Private Sub ButtonRegresarDep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarDep.Click
        Regresar(True)
    End Sub

    Private Sub ButtonRegresarEfe_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Regresar(False)
    End Sub

    Private Sub ButtonContinuarDep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarDep.Click
        If TabControlPreliq.SelectedIndex = 0 Then


            Try
                If bActualizar Then
                    If Not ActualizarDepositos() Then
                        Exit Sub
                    End If
                End If
                TabControlPreliq.SelectedIndex = 1
                C1FlexGridEfectivo.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            Terminar()
        End If
    End Sub

    Private Sub Terminar()
        Try
            If bActualizar Then
                If Not ActualizarEfectivos() Then
                    Exit Sub
                End If
            End If
            If Not VerificarInformacion() Then
                Exit Sub
            End If
            GuardaPreliquidacion(False)
            HabilitarBotones(False)
            Transaccion.Commit()
            Transaccion.Dispose()
            Transaccion = Nothing
            'If oVendedor.motconfiguracion.MensajeImpresion Then
            '    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            '        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.SinVisita, sPLIId, 13, 13)
            '    End If
            'End If
            HabilitarBotones(True)

        Catch ex As Exception
            Transaccion.Rollback()
            Transaccion.Dispose()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Me.Close()
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        'Me.ButtonContinuarEfe.Enabled = bHabilitar
        'Me.ButtonRegresarEfe.Enabled = bHabilitar
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Regresar(True)
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            Dim idxFila As Integer
            Dim sPBEId As String
            bEliminando = True
            If TabControlPreliq.SelectedIndex = 0 Then
                'Deposito

                If C1FlexGridDeposito.Row > 0 Then
                    idxFila = C1FlexGridDeposito.Row
                    If Not EsNuevaFila(C1FlexGridDeposito, idxFila) Then
                        sPBEId = C1FlexGridDeposito.GetData(idxFila, "PBEId")
                        Eliminar(sPBEId)
                    End If
                    C1FlexGridDeposito.Col = 0
                    C1FlexGridDeposito.Rows.Remove(idxFila)
                    CalcularTotales()
                    LLenarDepositadoDep()
                    'Me.TextBoxTotalDeposito.Text = nTotalDeposito.ToString("#,##0.00")
                    ActualizarRestoPreliquidacion()
                End If
            Else
                'Efectivo
                If C1FlexGridEfectivo.Row > 0 Then 'And C1FlexGridEfectivo.Row < C1FlexGridEfectivo.Rows.Count - 1 Then
                    idxFila = C1FlexGridEfectivo.Row
                    If Not EsNuevaFila(C1FlexGridEfectivo, idxFila) Then
                        sPBEId = C1FlexGridEfectivo.GetData(idxFila, "PBEId")
                        Eliminar(sPBEId)
                    End If
                    Dim sMoneda As String = ""
                    C1FlexGridEfectivo.Col = 0


                    C1FlexGridEfectivo.Rows.Remove(idxFila)
                    CalcularTotales()

                    LLenarDepositadoEfe()
                    'Me.TextBoxTotalEfectivo.Text = nTotalEfectivo(sMoneda).ToString("#,##0.00")





                    ActualizarRestoPreliquidacion()
            End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If TabControlPreliq.SelectedIndex = 0 Then
            If C1FlexGridDeposito.Rows.Count <= 1 Then
                CrearNuevaFila(C1FlexGridDeposito)
            End If
        Else
            If C1FlexGridEfectivo.Rows.Count <= 1 Then
                CrearNuevaFila(C1FlexGridEfectivo)
            End If
        End If
        bEliminando = False
    End Sub

    Private Sub C1FlexGridEfectivo_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridEfectivo.AfterEdit
        If bCargando Then Exit Sub
        bActualizar = True
        bHayCambios = True
        Try
            If e.Col = 1 Then ' Tipo MOneda O billete
                If Not (IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Denominacion")) OrElse C1FlexGridEfectivo.GetDataDisplay(e.Row, "Denominacion") = "") Then
                    If Not IsNothing(C1FlexGridEfectivo.Item(e.Row, "Tipo")) Then
                        If sTipoAnterior <> C1FlexGridEfectivo.Item(e.Row, "Tipo") Then
                            LimpiarRegistroEfectivo()
                        End If
                    End If
                End If

            ElseIf e.Col = 2 Then 'DenominacionID
                If IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Denominacion")) OrElse C1FlexGridEfectivo.GetDataDisplay(e.Row, "Denominacion") = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XDenominacion")), MsgBoxStyle.Information)
                    e.Cancel = True
                Else
                    Dim sValor As String = C1FlexGridEfectivo.GetDataDisplay(e.Row, e.Col)
                    Dim sLlave As String = C1FlexGridEfectivo.GetData(e.Row, "PBEId")
                    Dim sId As String = C1FlexGridEfectivo.GetData(e.Row, "Denominacion") ' Es el id
                    Dim nValor As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select valor from denominacion where denominacionid='" & sId & "'")
                    C1FlexGridEfectivo.Item(e.Row, e.Col) = Nothing
                    C1FlexGridEfectivo.Item(e.Row, e.Col) = sValor
                    C1FlexGridEfectivo.Item(e.Row, "DenominacionID") = sId
                    If htDenominacion.Contains(sLlave) Then
                        htDenominacion(sLlave) = C1FlexGridEfectivo.Item(e.Row, "Tipo")
                    Else
                        htDenominacion.Add(sLlave, C1FlexGridEfectivo.Item(e.Row, "Tipo"))
                    End If
                    If Not IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Cantidad")) Then
                        If Not CalcularEfectivo(C1FlexGridEfectivo.GetData(e.Row, "Cantidad")) Then
                            e.Cancel = True
                        End If
                    End If
                End If

            ElseIf e.Col = 3 Then
                If IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Denominacion")) OrElse C1FlexGridEfectivo.GetData(e.Row, "Denominacion").ToString() = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XDenominacion")), MsgBoxStyle.Information)
                    e.Cancel = True
                    Exit Sub
                End If

                If IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Cantidad")) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XCantidad")), MsgBoxStyle.Information)
                    e.Cancel = True
                Else
                    Dim nCantidad As Integer = C1FlexGridEfectivo.GetData(e.Row, "Cantidad")
                    If nCantidad <= 0 Then
                        C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "Cantidad") = nCantAnterior
                        C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "Total") = nTotalAnterior
                        CalcularTotales()
                        e.Cancel = True
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.Information)
                    Else
                        If Not CalcularEfectivo(nCantidad) Then
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub C1FlexGridEfectivo_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridEfectivo.BeforeEdit
        If Not bCargando Then
            If e.Col = 1 Then
                If Not IsNothing(C1FlexGridEfectivo.Item(e.Row, "Tipo")) Then
                    sTipoAnterior = C1FlexGridEfectivo.Item(e.Row, "Tipo")
                Else
                    sTipoAnterior = ""
                End If
            ElseIf e.Col = 2 Or e.Col = 3 Then
                If e.Col = 2 Then
                    If IsNothing(C1FlexGridEfectivo.Item(e.Row, "Tipo")) Then
                        e.Cancel = True
                    End If
                End If
                sDenominacionIDAnterior = ""
                nCantAnterior = 0
                nTotalAnterior = 0
                If Not (IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Denominacion")) OrElse C1FlexGridEfectivo.GetDataDisplay(e.Row, "Denominacion") = "") Then

                    sDenominacionIDAnterior = C1FlexGridEfectivo.GetData(e.Row, "DenominacionID")
                End If
                If Not IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Cantidad")) Then
                    nCantAnterior = Decimal.Parse(C1FlexGridEfectivo.GetData(e.Row, "Cantidad"))
                End If
                If Not IsNothing(C1FlexGridEfectivo.GetData(e.Row, "Total")) Then
                    nTotalAnterior = Decimal.Parse(C1FlexGridEfectivo.GetData(e.Row, "Total"))
                End If
            End If
        End If
    End Sub

    Private Sub C1FlexGridEfectivo_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGridEfectivo.EnterCell
        Dim iCol As Integer = C1FlexGridEfectivo.Col
        Dim iRow As Integer = C1FlexGridEfectivo.Row
        If iCol = 2 Then
            If IsNothing(C1FlexGridEfectivo.Item(iRow, "Tipo")) Then
                Exit Sub
            End If

            Dim ValoresDenominacion As New Hashtable
            Dim aGrupos As New ArrayList

            Dim dtDenominaciones As DataTable = oDBVen.RealizarConsultaSQL("select DenominacionID,Descripcion from Denominacion where grupo='" & C1FlexGridEfectivo.Item(iRow, "Tipo").ToString & "'", "Denominacion")

            For Each refDesc As DataRow In dtDenominaciones.Rows
                ValoresDenominacion.Add(refDesc!DenominacionID, refDesc!Descripcion)
            Next

            C1FlexGridEfectivo.Cols("Denominacion").DataMap = ValoresDenominacion



        End If
    End Sub

    Private Sub C1FlexGridDeposito_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridDeposito.AfterEdit
        Try
            If e.Row <= 0 Then Exit Sub
            bValidar = True
            bActualizar = True
            bHayCambios = True
            If e.Col = 1 Then 'FECHA
                Dim dFecha As Date
                If IsNothing(C1FlexGridDeposito.GetData(e.Row, "Fecha")) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "DEPFechaDeposito")), MsgBoxStyle.Information)
                    e.Cancel = True
                    bValidar = False
                Else
                    dFecha = Date.Parse(C1FlexGridDeposito.GetData(e.Row, "Fecha"))
                    If dFecha.Date > Today.Date Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0087").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "DEPFechaDeposito")), MsgBoxStyle.Information)
                        e.Cancel = True
                        bValidar = False
                    Else
                        nRowActualizar = e.Row
                    End If
                End If
            ElseIf e.Col = 2 Then 'BANCO
                If IsNothing(C1FlexGridDeposito.GetData(e.Row, "Banco")) OrElse C1FlexGridDeposito.GetData(e.Row, "Banco") = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "DEPBanco")), MsgBoxStyle.Information)
                    e.Cancel = True
                    bValidar = False
                Else
                    nRowActualizar = e.Row
                End If
            ElseIf e.Col = 3 Then 'Refrencia
                If IsNothing(C1FlexGridDeposito.GetData(e.Row, "Referencia")) OrElse C1FlexGridDeposito.GetData(e.Row, "Referencia").ToString.Trim = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XReferencia")), MsgBoxStyle.Information)
                    e.Cancel = True
                    bValidar = False
                Else
                    nRowActualizar = e.Row
                End If

            ElseIf e.Col = 4 Then
                If Not IsNothing(C1FlexGridDeposito.GetData(e.Row, "Total")) Then
                    Dim nCantidad As Decimal
                    nCantidad = Decimal.Parse(C1FlexGridDeposito.GetData(e.Row, "Total"))
                    If Math.Round((nCantidad - (nRestoPreliquidacion(C1FlexGridDeposito.GetData(e.Row, "Moneda")))), 2) > nDiferenciaPreliquiMon(C1FlexGridDeposito.GetData(e.Row, "Moneda")) Then
                        C1FlexGridDeposito.Item(e.Row, "Total") = nTotalAnterior
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0589").Replace("$0$", nDiferenciaPreliquiMon(C1FlexGridDeposito.GetData(e.Row, "Moneda")).ToString("#,##0.00")), MsgBoxStyle.Information)
                        e.Cancel = True
                        bValidar = False
                    Else
                        nRowActualizar = e.Row
                    End If

                    If Math.Round((nCantidad - (nRestoPreliquidacion(C1FlexGridDeposito.GetData(e.Row, "Moneda")) + nTotalAnterior)), 2) > nDiferenciaPreliquiMon(C1FlexGridDeposito.GetData(e.Row, "Moneda")) Then
                        C1FlexGridDeposito.Item(e.Row, "Total") = nTotalAnterior
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0589").Replace("$0$", nDiferenciaPreliquiMon(C1FlexGridDeposito.GetData(e.Row, "Moneda")) & " " & ValorReferencia.BuscarEquivalente("CDGOMON", oDBVen.EjecutarCmdScalarStrSQL("select TipoCodigo from Moneda Where MonedaID ='" & C1FlexGridDeposito.GetData(e.Row, "Moneda") & "'"))), MsgBoxStyle.Exclamation)
                        e.Cancel = True
                        bValidar = False
                    Else
                        nRowActualizar = e.Row
                    End If

                    CalcularTotales()
                    LLenarDepositadoDep()
                    'Me.TextBoxTotalDeposito.Text = nTotalDeposito.ToString("#,##0.00")
                    ActualizarRestoPreliquidacion()
                End If
            ElseIf e.Col = 5 Then
                If IsNothing(C1FlexGridDeposito.GetData(e.Row, "Total")) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XTotalMin")), MsgBoxStyle.Information)
                    e.Cancel = True
                    bValidar = False
                Else
                    Dim nCantidad As Decimal
                    nCantidad = Decimal.Parse(C1FlexGridDeposito.GetData(e.Row, "Total"))
                    If nCantidad <= 0 Then
                        C1FlexGridDeposito.Item(e.Row, "Total") = nTotalAnterior
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.Information)
                        e.Cancel = True
                        bValidar = False
                    Else

                        If IsNothing(C1FlexGridDeposito.GetData(e.Row, "Moneda")) Then

                            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", "Moneda"), MsgBoxStyle.Information)
                            e.Cancel = True
                            bValidar = False
                            Exit Sub
                        End If

                        If Math.Round((nCantidad - (nRestoPreliquidacion(C1FlexGridDeposito.GetData(e.Row, "Moneda")) + nTotalAnterior)), 2) > nDiferenciaPreliquiMon(C1FlexGridDeposito.GetData(e.Row, "Moneda")) Then
                            C1FlexGridDeposito.Item(e.Row, "Total") = nTotalAnterior
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0589").Replace("$0$", nDiferenciaPreliquiMon(C1FlexGridDeposito.GetData(e.Row, "Moneda")) & " " & ValorReferencia.BuscarEquivalente("CDGOMON", oDBVen.EjecutarCmdScalarStrSQL("select TipoCodigo from Moneda Where MonedaID ='" & C1FlexGridDeposito.GetData(e.Row, "Moneda") & "'"))), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            bValidar = False
                        Else
                            nRowActualizar = e.Row
                        End If
                    End If
                    CalcularTotales()
                    LLenarDepositadoDep()
                    'Me.TextBoxTotalDeposito.Text = nTotalDeposito.ToString("#,##0.00")
                    ActualizarRestoPreliquidacion()
                End If
            ElseIf e.Col = 7 Then
                nRowActualizar = e.Row
                If e.Row = C1FlexGridDeposito.Rows.Count - 1 Then
                    If ValidarRequeridosDeposito(e.Row) Then
                        CrearNuevaFila(C1FlexGridDeposito)
                    Else
                        e.Cancel = True
                        bValidar = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CalcularTotales()

        Dim totalPreD As New System.Collections.Generic.Dictionary(Of String, Decimal)
        Dim totalPreE As New System.Collections.Generic.Dictionary(Of String, Decimal)
        For Each llave As String In sPLIId.Keys
            totalPreD(llave) = 0
            totalPreE(llave) = 0
        Next
        For Each llave As String In sPLIId.Keys
            For i As Integer = 1 To C1FlexGridDeposito.Rows.Count - 1
                If llave = C1FlexGridDeposito.GetData(i, "MONEDA") Then
                    Dim aObj As Object = C1FlexGridDeposito.GetData(i, "Total")
                    If IsNothing(aObj) = False Then
                        If totalPreD.ContainsKey(llave) Then
                            totalPreD(llave) += Convert.ToDecimal(aObj)
                        Else
                            totalPreD.Add(llave, Convert.ToDecimal(aObj))
                        End If


                    End If
                End If
            Next
            For i As Integer = 1 To C1FlexGridEfectivo.Rows.Count - 1
                If llave = oDBVen.EjecutarCmdScalarStrSQL("select monedaid from denominacion where denominacionid='" & C1FlexGridEfectivo.GetData(i, "DenominacionID") & "'") Then
                    Dim aObj As Object = C1FlexGridEfectivo.GetData(i, "Total")
                    If IsNothing(aObj) = False Then
                        If totalPreE.ContainsKey(llave) Then
                            totalPreE(llave) += Convert.ToDecimal(aObj)
                        Else
                            totalPreE.Add(llave, Convert.ToDecimal(aObj))
                        End If

                    End If
                End If
            Next
            If totalPreD.ContainsKey(llave) Then


                If nTotalDeposito.ContainsKey(llave) Then
                    nTotalDeposito(llave) = totalPreD(llave)
                Else
                    nTotalDeposito.Add(llave, totalPreD(llave))
                End If
            End If

            If totalPreE.ContainsKey(llave) Then
                If nTotalDeposito.ContainsKey(llave) Then
                    nTotalEfectivo(llave) = totalPreE(llave)
                Else
                    nTotalEfectivo.Add(llave, totalPreE(llave))
                End If
            End If
            Dim dresto As Decimal = 0
            dresto = nTotalPreliquidacion(llave)
            If totalPreD.ContainsKey(llave) Then dresto -= totalPreD(llave)


            If totalPreE.ContainsKey(llave) Then dresto -= totalPreE(llave)


            nRestoPreliquidacion(llave) = dresto
        Next

    End Sub

    Private Sub C1FlexGridDeposito_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles C1FlexGridDeposito.AfterRowColChange

        If Not bCargando And Not bEliminando Then
            If e.OldRange.r1 > 0 Then
                If e.OldRange.r1 <> e.NewRange.r1 And bActualizar And bValidar Then
                    If nRowActualizar <= 0 Or nRowActualizar > C1FlexGridDeposito.Rows.Count - 1 Then Exit Sub
                    If Not ValidarRequeridosDeposito(nRowActualizar) Then
                        '    ActualizaDeposito()
                        'Else
                        e.Cancel = True
                        bValidar = False
                        C1FlexGridDeposito.Row = nRowActualizar
                        C1FlexGridDeposito.Focus()
                        Exit Sub
                    End If
                Else
                    If nRowActualizar <= 0 Then Exit Sub
                    If nRowActualizar > C1FlexGridDeposito.Rows.Count - 1 Then
                        Exit Sub
                    End If
                    C1FlexGridDeposito.Row = nRowActualizar
                End If
            End If
        End If
        bValidar = True
    End Sub

    Private Sub C1FlexGridDeposito_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridDeposito.BeforeEdit
        bValidar = True
        If Not bCargando And Not bEliminando Then
            If e.Col = 5 Then
                nTotalAnterior = 0
                If IsNothing(C1FlexGridDeposito.GetData(e.Row, "Total")) Then Exit Sub
                nTotalAnterior = Decimal.Parse(C1FlexGridDeposito.GetData(e.Row, "Total"))
            End If
        End If
    End Sub

#End Region

#Region "Metodos"
    Private Sub Regresar(ByVal bSalir As Boolean)
        If bSalir Then
            'Deposito 
            If bHayCambios Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Transaccion.Rollback()
            Transaccion.Dispose()
            Me.Close()
        Else
            'Efectivo
            TabControlPreliq.SelectedIndex = 0
            C1FlexGridDeposito.Focus()
        End If
    End Sub

    Private Sub ConfiguraGridDeposito()
        With C1FlexGridDeposito
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 8

            .Cols(0).Name = "PBEId"
            .Cols("PBEId").Visible = False

            .Cols(1).Name = "Fecha"
            .Cols("Fecha").DataType = GetType(Date)
            .Cols("Fecha").EditMask = "99/99/9999"
            .Cols("Fecha").Width = 75
            .Cols("Fecha").Caption = refaVista.BuscarMensaje("MsgBox", "XFecha")

            .Cols(2).Name = "Banco"
            .Cols("Banco").Width = 110
            Dim ValoresTipoBanco As New Hashtable
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("TBANCO")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    If refDesc.Id <> 0 Then
                        ValoresTipoBanco.Add(refDesc.Id, refDesc.Cadena)
                    End If
                Next
                .Cols("Banco").DataMap = ValoresTipoBanco
            End If
            aValores = Nothing
            .Cols("Banco").Caption = refaVista.BuscarMensaje("MsgBox", "DEPBanco")

            .Cols(3).Name = "Referencia"
            .Cols("Referencia").Width = 110
            .Cols("Referencia").Caption = refaVista.BuscarMensaje("MsgBox", "XReferencia")

            .Cols(4).Name = "Moneda"
            .Cols("Moneda").Width = 65
            .Cols("Moneda").AllowEditing = True
            .Cols("Moneda").Caption = "Moneda" 'gVista.BuscarMensaje("GridCobranzaPagos", "Moneda")
            Dim ValoresMoneda As New Hashtable
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select M.MonedaId, substring(Nombre,1,8) as Nombre, TipoCodigo from Moneda m Inner Join Preliquidacion P on P.MonedaId=M.MonedaID where enviado =0", "Moneda")
            Dim sTipoCodigo As String = ""
            For Each fila As DataRow In dt.Rows
                sTipoCodigo = ValorReferencia.BuscarEquivalente("CDGOMON", fila("TipoCodigo").ToString)
                ValoresMoneda.Add(fila("MonedaId"), fila("Nombre").ToString() & " " & sTipoCodigo)
            Next
            .Cols("Moneda").DataMap = ValoresMoneda

            .Cols(5).Name = "Total"
            .Cols("Total").DataType = GetType(Decimal)
            .Cols("Total").Format = "c"
            .Cols("Total").Width = 110
            .Cols("Total").Caption = refaVista.BuscarMensaje("MsgBox", "XTotalMin")

            .Cols(6).Name = "TipoCambio"
            .Cols("TipoCambio").DataType = GetType(Decimal)
            .Cols("TipoCambio").Format = "c"
            .Cols("TipoCambio").Width = 70
            .Cols("TipoCambio").Caption = "TipoCambio" 'refaVista.BuscarMensaje("MsgBox", "XTotalMin")



            .Cols(7).Name = "Ficha"
            .Cols("Ficha").Width = 110
            .Cols("Ficha").Caption = refaVista.BuscarMensaje("MsgBox", "XFicha")

            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Redraw = True

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            For Each col As C1.Win.C1FlexGrid.Column In .Cols
                col.Width = col.Width * 2
            Next
#End If

        End With
    End Sub

    Private Sub ConfiguraGridEfectivo()
        With C1FlexGridEfectivo
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 6

            .Cols(0).Name = "PBEId"
            .Cols("PBEId").Visible = False

          
            .Cols(1).Name = "Tipo"
            Dim ValoresDenominacion As New Hashtable
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("DENOMINA")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresDenominacion.Add(refDesc.Id, refDesc.Cadena)
                Next
                .Cols("Tipo").DataMap = ValoresDenominacion.Clone()
            End If
            aValores = Nothing
            .Cols("Tipo").Caption = refaVista.BuscarMensaje("MsgBox", "XTipo") 'refaVista.BuscarMensaje("MsgBox", "XDenominacion")
            .Cols("Tipo").Width = 60


            .Cols(2).Name = "Denominacion"
            ValoresDenominacion.Clear()
            Dim dtDenominaciones As DataTable = oDBVen.RealizarConsultaSQL("select DenominacionID,Descripcion from Denominacion ", "Denominacion")
            For Each refDesc As DataRow In dtDenominaciones.Rows
                ValoresDenominacion.Add(refDesc!DenominacionID, refDesc!Descripcion)
            Next
            .Cols("Denominacion").DataMap = ValoresDenominacion
            aValores = Nothing
            .Cols("Denominacion").Caption = refaVista.BuscarMensaje("MsgBox", "XDenominacion")
            .Cols("Denominacion").Width = 100


            .Cols(3).Name = "Cantidad"
            .Cols("Cantidad").DataType = GetType(Integer)
            '.Cols("Cantidad").Format = "c"
            .Cols("Cantidad").Width = 60
            .Cols("Cantidad").Caption = refaVista.BuscarMensaje("MsgBox", "XCantidad")

            .Cols(4).Name = "Total"
            .Cols("Total").DataType = GetType(Decimal)
            .Cols("Total").Format = "c"
            .Cols("Total").Width = 110
            .Cols("Total").Caption = refaVista.BuscarMensaje("MsgBox", "XTotalMin")
            .Cols("Total").AllowEditing = False

            .Cols(5).Name = "DenominacionID"
            .Cols("DenominacionID").Visible = False


            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .AutoResize = True
            .Redraw = True

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            For Each col As C1.Win.C1FlexGrid.Column In .Cols
                col.Width = col.Width * 2
            Next
#End If

        End With
    End Sub

    Private Sub ConfiguraGridMoneda(ByVal Grid As C1.Win.C1FlexGrid.C1FlexGrid)
        With Grid

            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 3

            .Cols(0).Name = "Moneda"
            .Cols("Moneda").Width = 65
            .Cols("Moneda").AllowEditing = False
            .Cols("Moneda").Caption = "Moneda" 'gVista.BuscarMensaje("GridEfectivoMoneda", "Moneda")
            Dim ValoresMoneda As New Hashtable
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select MonedaId, substring(Nombre,1,8) as Nombre, TipoCodigo from Moneda", "Moneda")
            Dim sTipoCodigo As String = ""
            For Each fila As DataRow In dt.Rows
                sTipoCodigo = ValorReferencia.BuscarEquivalente("CDGOMON", fila("TipoCodigo").ToString)
                ValoresMoneda.Add(fila("MonedaId"), fila("Nombre").ToString() & " " & sTipoCodigo)
            Next
            .Cols("Moneda").DataMap = ValoresMoneda


            .Cols(1).Name = "TotalDepositar"
            .Cols("TotalDepositar").DataType = GetType(Decimal)
            .Cols("TotalDepositar").Width = 80
            .Cols("TotalDepositar").Caption = "Total a Depositar" 'refaVista.BuscarMensaje("MsgBox", "XCantidad")
            .Cols("TotalDepositar").AllowEditing = False
            .Cols("TotalDepositar").Format = "c"

            .Cols(2).Name = "TotalDespositado"
            .Cols("TotalDespositado").DataType = GetType(Decimal)
            .Cols("TotalDespositado").Width = 80
            .Cols("TotalDespositado").Caption = "Total Depositado" 'refaVista.BuscarMensaje("MsgBox", "XCantidad")
            .Cols("TotalDespositado").AllowEditing = False
            .Cols("TotalDespositado").Format = "c"


            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .AutoResize = True
            .Redraw = True
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            For Each col As C1.Win.C1FlexGrid.Column In .Cols
                col.Width = col.Width * 2
            Next
#End If
        End With
    End Sub

    Private Function ValidarExistePreliquidacion() As Boolean
        Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, FechaPreLiquidacion, MontoTotal,MonedaID FROM PreLiquidacion where Enviado = 0", "Preliq")
        If oDT.Rows.Count = 0 Then
            Return False
        Else
            Dim fila As DataRow

            For Each fila In oDT.Rows


                sPLIId.Add(fila("MonedaID"), fila("PLIId"))
                nRestoPreliquidacion.Add(fila("MonedaID"), Math.Round(Decimal.Parse(fila("MontoTotal")), 2))
                nTotalPreliquidacion.Add(fila("MonedaID"), Math.Round(Decimal.Parse(fila("MontoTotal")), 2))

                Me.C1FlexGridEfectivoMoneda.AddItem(fila("MonedaID").ToString() & vbTab & "0.0" & vbTab & "0.0")
                Me.C1FlexGridDepositoMoneda.AddItem(fila("MonedaID").ToString() & vbTab & "0.0" & vbTab & "0.0")
                'Me.C1FlexGridDeposito.AddItem(oDr("PBEId").ToString & vbTab & Date.Parse(oDr("FechaDeposito")).ToShortDateString & vbTab & oDr("TipoBanco").ToString & vbTab & oDr("Referencia").ToString & vbTab & oDr("Total").ToString & vbTab & oDr("Ficha").ToString)

            Next

            dFechaPreliquidacion = Date.Parse(oDT.Rows(0)("FechaPreliquidacion"))

            If oDBVen.RealizarScalarSQL("SELECT count(*) FROM PLBPLE where Enviado = 0") = 0 Then
                dFechaPreliquidacion = Now
                bNuevaPreliquidacion = True
            End If
            TextBoxFecha.Text = dFechaPreliquidacion.Date.ToString("dd/MM/yyyy")
            Return True
        End If
    End Function

    Private Sub ActualizarRestoPreliquidacion()
        For Each llave As String In nRestoPreliquidacion.Keys
            For i As Integer = 1 To C1FlexGridDepositoMoneda.Rows.Count - 1
                If C1FlexGridDepositoMoneda.GetData(i, "Moneda") = llave Then
                    C1FlexGridDepositoMoneda.SetData(i, 1, nRestoPreliquidacion(llave).ToString("#,##0.00"))
                    C1FlexGridEfectivoMoneda.SetData(i, 1, nRestoPreliquidacion(llave).ToString("#,##0.00"))
                End If
                
            Next
        Next

        'TextBoxTotalDepD.Text = nRestoPreliquidacion.ToString("#,##0.00")
        'TextBoxTotalDepE.Text = nRestoPreliquidacion.ToString("#,##0.00")
    End Sub

    Private Sub LlenarGridDeposito()
        Dim nTotalDep As New System.Collections.Generic.Dictionary(Of String, Decimal)

        For Each llave As String In sPLIId.Keys
            nTotalDep(llave) = 0
            Dim PliId As String = sPLIId(llave)

            Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PBEId, FechaDeposito, TipoBanco, Referencia, Total, TipoCambio,Ficha FROM PLBPLE WHERE PLIId = '" & PliId & "' and TipoBanco is not null", "LlenarGrid")
            For Each oDr As DataRow In oDT.Rows
                nTotalDep(llave) = nTotalDep(llave) + Decimal.Parse(oDr("Total"))

                Me.C1FlexGridDeposito.AddItem(oDr("PBEId").ToString & vbTab & Date.Parse(oDr("FechaDeposito")).ToShortDateString & vbTab & oDr("TipoBanco").ToString & vbTab & oDr("Referencia").ToString & vbTab & llave & vbTab & oDr("Total").ToString & vbTab & oDr("TipoCambio").ToString & vbTab & oDr("Ficha").ToString)
                lDetalle.Add(oDr("PBEId"))
            Next
            oDT.Dispose()

            nTotalDeposito(llave) = Math.Round(nTotalDep(llave), 2)
            nTotalPreliquidacion(llave) = nTotalPreliquidacion(llave) + nTotalDeposito(llave)

            For i As Integer = 1 To C1FlexGridDepositoMoneda.Rows.Count - 1
                If C1FlexGridDepositoMoneda.GetData(i, "Moneda") = llave Then
                    C1FlexGridDepositoMoneda.SetData(i, 2, nTotalDep(llave).ToString("#,##0.00"))
                    'C1FlexGridEfectivoMoneda.SetData(i, 2, nTotalEfectivo(llave).ToString("#,##0.00"))
                End If

            Next
            LLenarDepositadoDep()
            'Me.TextBoxTotalDeposito.Text = nTotalDep.ToString("#,##0.00")
        Next
    End Sub


    Private Sub CrearNuevaFila(ByRef FG As C1.Win.C1FlexGrid.C1FlexGrid, Optional ByVal pvSemilla As Integer = 0)
        Dim x As New Random
        FG.Rows.Count = FG.Rows.Count + 1
        FG.Row = FG.Rows.Count - 1
        FG.Item(FG.Row, 0) = oApp.KEYGEN(FG.Row + pvSemilla)
        FG.Col = 1
    End Sub

    Private Function CalcularEfectivo(ByVal pvCantidad As Integer) As Boolean

        Dim resul As Boolean = True
        For Each llave As String In sPLIId.Keys
            Dim sDenominaID As String = C1FlexGridEfectivo.GetData(C1FlexGridEfectivo.Row, "DenominacionID")
            If llave = oDBVen.EjecutarCmdScalarStrSQL("Select MonedaId from denominacion where denominacionid='" & sDenominaID & "'") Then


                Dim nValor As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select valor from denominacion where denominacionid='" & sDenominaID & "'")
                Dim nCantidadEfe As Decimal = nValor * pvCantidad

                If Math.Round((nCantidadEfe - (nRestoPreliquidacion(llave) + nTotalAnterior)), 2) > nDiferenciaPreliquiMon(llave) Then
                    If IsNothing(C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "DenominacionID")) OrElse C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "DenominacionID") = "" Then
                        C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "DenominacionID") = IIf(sDenominacionIDAnterior = "", Nothing, sDenominacionIDAnterior)
                    End If

                    C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "Cantidad") = nCantAnterior
                    C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "Total") = nTotalAnterior
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0589").Replace("$0$", nDiferenciaPreliquiMon(llave) & " " & ValorReferencia.BuscarEquivalente("CDGOMON", oDBVen.EjecutarCmdScalarStrSQL("select TipoCodigo from Moneda Where MonedaID ='" & llave & "'"))), MsgBoxStyle.Exclamation)
                    resul = False
                Else
                    C1FlexGridEfectivo.Item(C1FlexGridEfectivo.Row, "Total") = nCantidadEfe

                    bActualizar = True
                    nRowActualizar = C1FlexGridEfectivo.Row
                    If C1FlexGridEfectivo.Row = C1FlexGridEfectivo.Rows.Count - 1 Then
                        If ValidarRequeridosEfectivo(nRowActualizar) Then
                            CrearNuevaFila(C1FlexGridEfectivo)
                        Else
                            resul = False
                        End If
                    End If

                    resul = True
                End If
            End If

        Next
        CalcularTotales()

      
        LLenarDepositadoEfe()

        'Me.TextBoxTotalEfectivo.Text = nTotalEfectivo.ToString("#,##0.00")
        ActualizarRestoPreliquidacion()
        Return resul
    End Function

    Public Function LLenarDepositadoEfe()


        For Each llave As String In nRestoPreliquidacion.Keys


            For i As Integer = 1 To C1FlexGridEfectivoMoneda.Rows.Count - 1
                If C1FlexGridEfectivoMoneda.GetData(i, "Moneda") = llave Then

                    If Not nTotalEfectivo.ContainsKey(llave) Then nTotalEfectivo.Add(llave, 0)

                    C1FlexGridEfectivoMoneda.SetData(i, 2, nTotalEfectivo(llave).ToString("#,##0.00"))

                End If

            Next
        Next
    End Function
    Public Function LLenarDepositadoDep()

        For Each llave As String In nRestoPreliquidacion.Keys


            For i As Integer = 1 To C1FlexGridDepositoMoneda.Rows.Count - 1
                If C1FlexGridDepositoMoneda.GetData(i, "Moneda") = llave Then

                    If Not nTotalDeposito.ContainsKey(llave) Then nTotalDeposito.Add(llave, 0)

                    C1FlexGridDepositoMoneda.SetData(i, 2, nTotalDeposito(llave).ToString("#,##0.00"))

                End If

            Next
        Next
    End Function


    Private Function HayNuevaFila(ByVal pvGrid As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        If pvGrid.Rows.Count > 1 Then
            Dim sPBEId As String = pvGrid.GetData(pvGrid.Rows.Count - 1, "PBEId")
            Return Not lDetalle.Contains(sPBEId)
        Else
            Return False
        End If
    End Function

    Private Function EsNuevaFila(ByVal pvGrid As C1.Win.C1FlexGrid.C1FlexGrid, ByVal pvRow As Integer) As Boolean
        Dim sPBEId As String = pvGrid.GetData(pvRow, "PBEId")
        Return Not lDetalle.Contains(sPBEId)
    End Function

    Private Function ValidarRequeridosDeposito(ByVal pvRow As Integer) As Boolean
        If pvRow <= 0 Then
            Return False
        End If
        If IsNothing(C1FlexGridDeposito.GetData(pvRow, "Fecha")) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "DEPFechaDeposito")), MsgBoxStyle.Information)
            nColActualizar = 1
            Return False
        Else
            If Not IsDate(C1FlexGridDeposito.GetData(pvRow, "Fecha")) Then
                Return False
            End If
            Dim dFecha As Date = Date.Parse(C1FlexGridDeposito.GetData(pvRow, "Fecha"))
            If dFecha.Date > Today.Date Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0087").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "DEPFechaDeposito")), MsgBoxStyle.Information)
                nColActualizar = 1
                Return False
            End If
        End If
        If IsNothing(C1FlexGridDeposito.GetData(pvRow, "Banco")) OrElse C1FlexGridDeposito.GetData(pvRow, "Banco") = "" Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "DEPBanco")), MsgBoxStyle.Information)
            nColActualizar = 2
            Return False
        End If
        If IsNothing(C1FlexGridDeposito.GetData(pvRow, "Referencia")) OrElse C1FlexGridDeposito.GetData(pvRow, "Referencia").ToString.Trim = "" Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XReferencia")), MsgBoxStyle.Information)
            nColActualizar = 3
            Return False
        End If
        If IsNothing(C1FlexGridDeposito.GetData(pvRow, "Moneda")) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", "Moneda"), MsgBoxStyle.Information)
            nColActualizar = 4
            Return False

        ElseIf C1FlexGridDeposito.GetData(pvRow, "Moneda") <> oConHist.Campos("MonedaID") AndAlso (IsNothing(C1FlexGridDeposito.GetData(pvRow, "TipoCambio")) OrElse C1FlexGridDeposito.GetData(pvRow, "TipoCambio").ToString.Trim = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", "TipoCambio"), MsgBoxStyle.Information)
            nColActualizar = 6
            Return False
        End If
        If IsNothing(C1FlexGridDeposito.GetData(pvRow, "Total")) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XTotalMin")), MsgBoxStyle.Information)
            nColActualizar = 5
            Return False
        ElseIf Convert.ToDecimal(C1FlexGridDeposito.GetData(pvRow, "Total")) <= 0 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0334").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XTotalMin")), MsgBoxStyle.Information)
            nColActualizar = 5
            Return False
        End If
        Return True
    End Function

    Private Function ValidarRequeridosEfectivo(ByVal pvRow As Integer) As Boolean
        If IsNothing(C1FlexGridEfectivo.GetData(pvRow, "Denominacion")) OrElse C1FlexGridEfectivo.GetDataDisplay(pvRow, "Denominacion") = "" Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XDenominacion")), MsgBoxStyle.Information)
            nColActualizar = 2
            Return False
        End If
        If IsNothing(C1FlexGridEfectivo.GetData(pvRow, "Cantidad")) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XCantidad")), MsgBoxStyle.Information)
            nColActualizar = 3
            Return False
        ElseIf Convert.ToDecimal(C1FlexGridEfectivo.GetData(pvRow, "Cantidad")) <= 0 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0334").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XCantidad")), MsgBoxStyle.Information)
            nColActualizar = 4
            Return False
        End If
        Return True
    End Function

    Private Sub GuardaPreliquidacion(ByVal bNuevo As Boolean)
        Try
            For Each llave As String In sPLIId.Keys
                Dim sComando As String
                If bNuevo Then
                    sComando = "update PreLiquidacion set FechaPreLiquidacion = " & UniFechaSQL(dFechaPreliquidacion) & " where PLIId = '" & sPLIId(llave) & "'"
                Else
                    sComando = "update PreLiquidacion set MontoTotal = Round(" & nRestoPreliquidacion(llave) & ",2) where PLIId = '" & sPLIId(llave) & "'"
                End If
                oDBVen.EjecutarComandoSQL(sComando)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function TieneDatos(ByVal pvGrid As C1.Win.C1FlexGrid.C1FlexGrid, ByVal nRow As Integer) As Boolean
        For nCol As Integer = 1 To pvGrid.Cols.Count - 1
            If Not (IsNothing(pvGrid.GetData(nRow, nCol)) OrElse pvGrid.GetData(nRow, nCol).ToString = "") Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ActualizarDepositos() As Boolean
        For Each llave As String In sPLIId.Keys

            Dim nTotalDepAnterior As New System.Collections.Generic.Dictionary(Of String, Decimal)
            nTotalDepAnterior.Add(llave, Math.Round(nTotalDeposito(llave), 2))
            CalcularTotales()
            For i As Integer = 1 To C1FlexGridDeposito.Rows.Count - 1
                nRowActualizar = i
                If TieneDatos(C1FlexGridDeposito, nRowActualizar) Then
                    If ValidarRequeridosDeposito(nRowActualizar) Then
                        ActualizaDeposito()
                    Else
                        C1FlexGridDeposito.Focus()
                        C1FlexGridDeposito.Select(nRowActualizar, nColActualizar)
                        nTotalDeposito(llave) = nTotalDepAnterior(llave)
                        Return False
                    End If
                End If
            Next


        Next
        LLenarDepositadoDep()
        'TextBoxTotalDeposito.Text = nTotalDeposito.ToString("#,##0.00")
        ActualizarRestoPreliquidacion()
        bActualizar = False
        Return True
    End Function

    Private Sub ActualizaDeposito()
        Dim sPBEId As String = C1FlexGridDeposito.GetData(nRowActualizar, "PBEId").ToString
        Dim bNuevo As Boolean = Not lDetalle.Contains(sPBEId)
        Dim dFechaDeposito As Date = Date.Parse(C1FlexGridDeposito.GetData(nRowActualizar, "Fecha"))
        Dim nTipoBanco As Integer = Integer.Parse(C1FlexGridDeposito.GetData(nRowActualizar, "Banco"))
        Dim sReferencia As String = C1FlexGridDeposito.GetData(nRowActualizar, "Referencia").ToString
        Dim nTotal As Decimal = Decimal.Parse(C1FlexGridDeposito.GetData(nRowActualizar, "Total"))
        Dim sFicha As String = ""
        Dim sMoneda = C1FlexGridDeposito.GetData(nRowActualizar, "Moneda")

        If Not IsNothing(C1FlexGridDeposito.GetData(nRowActualizar, "Ficha")) Then
            sFicha = C1FlexGridDeposito.GetData(nRowActualizar, "Ficha").ToString
        End If


        For Each llave As String In sPLIId.Keys

            If llave = sMoneda Then
                If sMoneda = oConHist.Campos("MonedaID") Then
                    GuardaDeposito(sPLIId(C1FlexGridDeposito.GetData(nRowActualizar, "Moneda")), sPBEId, dFechaDeposito, nTipoBanco, sReferencia, nTotal, sFicha, bNuevo)
                Else
                    GuardaDeposito(sPLIId(C1FlexGridDeposito.GetData(nRowActualizar, "Moneda")), sPBEId, dFechaDeposito, nTipoBanco, sReferencia, nTotal, sFicha, bNuevo, C1FlexGridDeposito.GetData(nRowActualizar, "TipoCambio"))
                End If


            End If

        Next


    End Sub

    Private Sub GuardaDeposito(ByVal pvPLIId As String, ByVal pvPBEId As String, ByVal pvFechaDeposito As Date, ByVal pvTipoBanco As Integer, ByVal pvReferencia As String, ByVal pvTotal As Decimal, ByVal pvFicha As String, ByVal pvNuevo As Boolean, Optional ByVal pvTipoCambio As Decimal = 1)
        Try
            Dim sComando As String
            If pvNuevo Then
                sComando = "insert into PLBPLE (PLIId, PBEId, FechaDeposito, TipoBanco, Referencia, Total, TipoCambio,Ficha, MFechaHora, Enviado) values "
                sComando &= "('" & pvPLIId & "','" & pvPBEId & "'," & UniFechaSQL(pvFechaDeposito) & ","
                sComando &= pvTipoBanco & ",'" & pvReferencia & "'," & pvTotal & "," & pvTipoCambio & ",'" & pvFicha & "'," & UniFechaSQL(Now) & ", 0)"
                lDetalle.Add(pvPBEId)
            Else
                sComando = "update PLBPLE set TipoCambio = " & pvTipoCambio & ", FechaDeposito = " & UniFechaSQL(pvFechaDeposito) & ", TipoBanco = " & pvTipoBanco & ", "
                sComando &= "Referencia = '" & pvReferencia & "', Total = " & pvTotal & ", Ficha = '" & pvFicha & "', "
                sComando &= "MFechaHora = " & UniFechaSQL(Now) & ", Enviado = 0 where PBEId = '" & pvPBEId & "'"
            End If
            oDBVen.EjecutarComandoSQL(sComando)
            bHayCambios = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ActualizarEfectivos() As Boolean
        For Each llave As String In sPLIId.Keys
            Dim nTotalEfeAnterior As New System.Collections.Generic.Dictionary(Of String, Decimal)

            nTotalEfeAnterior.Add(llave, Math.Round(nTotalEfectivo(llave), 2))
            nTotalEfectivo(llave) = 0
            For i As Integer = 1 To C1FlexGridEfectivo.Rows.Count - 1
                nRowActualizar = i
                If TieneDatos(C1FlexGridEfectivo, nRowActualizar) Then
                    If ValidarRequeridosEfectivo(nRowActualizar) Then
                        If llave = oDBVen.EjecutarCmdScalarStrSQL("select monedaid from denominacion where denominacionid='" & C1FlexGridEfectivo.GetData(nRowActualizar, "DenominacionID") & "'") Then
                            nTotalEfectivo(llave) += Decimal.Parse(C1FlexGridEfectivo.GetData(nRowActualizar, "Total"))
                            ActualizaEfectivo()
                        End If
                    Else
                        C1FlexGridEfectivo.Focus()
                        C1FlexGridEfectivo.Select(nRowActualizar, nColActualizar)
                        nTotalEfectivo(llave) = nTotalEfeAnterior(llave)
                        Return False
                    End If
                End If
            Next


            nRestoPreliquidacion(llave) += Math.Round(nTotalEfeAnterior(llave), 2)
            nRestoPreliquidacion(llave) -= Math.Round(nTotalEfectivo(llave), 2)

        Next
        LLenarDepositadoEfe()
        'TextBoxTotalEfectivo.Text = nTotalEfectivo.ToString("#,##0.00")
            ActualizarRestoPreliquidacion()
            bActualizar = False
            Return True
    End Function

    Private Sub ActualizaEfectivo()
        Dim sPBEId As String = C1FlexGridEfectivo.GetData(nRowActualizar, "PBEId").ToString
        Dim bNuevo As Boolean = Not lDetalle.Contains(sPBEId)
        Dim nTipoEfectivo As Integer = htDenominacion(sPBEId)
        Dim nTotal As Integer = Integer.Parse(C1FlexGridEfectivo.GetData(nRowActualizar, "Cantidad"))
        Dim sMoneda = oDBVen.EjecutarCmdScalarStrSQL("select monedaid from denominacion where denominacionid='" & C1FlexGridEfectivo.GetData(nRowActualizar, "DenominacionID") & "'")
        For Each llave As String In sPLIId.Keys

            If llave = sMoneda Then
                GuardaEfectivo(sPLIId(llave), sPBEId, nTipoEfectivo, C1FlexGridEfectivo.GetData(nRowActualizar, "DenominacionID"), nTotal, bNuevo)
            End If

        Next

    End Sub

    Private Sub GuardaEfectivo(ByVal pvPLIId As String, ByVal pvPBEId As String, ByVal pvTipoEfectivo As String, ByVal pvDenominacion As String, ByVal pvTotal As Integer, ByVal pvNuevo As Boolean)
        Try
            Dim sComando As String
            If pvNuevo Then
                sComando = "insert into PLBPLE (PLIId, PBEId,TipoEfectivo, DenominacionID, Total, MFechaHora, Enviado) values "
                sComando &= "('" & pvPLIId & "','" & pvPBEId & "','" & pvTipoEfectivo & "','" & pvDenominacion & "'," & pvTotal & "," & UniFechaSQL(Now) & ", 0)"
                lDetalle.Add(pvPBEId)
            Else
                sComando = "update PLBPLE set TipoEfectivo = '" & pvTipoEfectivo & "', DenominacionID = '" & pvDenominacion & "', Total = " & pvTotal & ", "
                sComando &= "MFechaHora = " & UniFechaSQL(Now) & ", Enviado = 0 where PBEId = '" & pvPBEId & "'"
            End If
            oDBVen.EjecutarComandoSQL(sComando)
            bHayCambios = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Eliminar(ByVal pvPBEId As String)
        Try
            Dim sQuery As String = "DELETE FROM PLBPLE WHERE PBEId='" & pvPBEId & "'"
            oDBVen.EjecutarComandoSQL(sQuery)
            lDetalle.Remove(pvPBEId)
            If htDenominacion.Contains(pvPBEId) Then
                htDenominacion.Remove(pvPBEId)
            End If
            bHayCambios = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function VerificarInformacion() As Boolean
        Dim sError As String = ""

        For Each llave As String In sPLIId.Keys


            If Math.Abs(Math.Round(nRestoPreliquidacion(llave), 2)) > nDiferenciaPreliquiMon(llave) Then

                If sError <> "" Then
                    sError += vbCrLf
                End If
                If Math.Round(nRestoPreliquidacion(llave)) < 0 Then
                    sError += refaVista.BuscarMensaje("MsgBox", "E0589").Replace("$0$", nDiferenciaPreliquiMon(llave).ToString("#,##0.00")) & " " & ValorReferencia.BuscarEquivalente("CDGOMON", oDBVen.EjecutarCmdScalarStrSQL("select TipoCodigo from Moneda Where MonedaID ='" & llave & "'"))
                Else
                    sError += refaVista.BuscarMensaje("MsgBox", "E0585").Replace("$0$", (nRestoPreliquidacion(llave) - nDiferenciaPreliquiMon(llave)).ToString("#,##0.00")) & " " & ValorReferencia.BuscarEquivalente("CDGOMON", oDBVen.EjecutarCmdScalarStrSQL("select TipoCodigo from Moneda Where MonedaID ='" & llave & "'"))

                End If

            End If



        Next

        If sError <> "" Then
            MsgBox(sError, MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function

    Private Sub LimpiarRegistroEfectivo()
        Dim nCantidad As Integer
        Dim sPBEId As String
        Dim sMonedaID As String
        If Not EsNuevaFila(C1FlexGridEfectivo, C1FlexGridEfectivo.Row) Then
            nCantidad = Decimal.Parse(C1FlexGridEfectivo.GetData(C1FlexGridEfectivo.Row, "Total"))
            sPBEId = C1FlexGridEfectivo.GetData(C1FlexGridEfectivo.Row, "PBEId")
            sMonedaID = oDBVen.EjecutarCmdScalarStrSQL("select monedaid from denominacion where denominacionid='" & C1FlexGridEfectivo.GetData(C1FlexGridEfectivo.Row, "DenominacionID") & "'")
            For Each llave As String In sPLIId.Keys
                If sMonedaID = llave Then
                    nTotalEfectivo(llave) -= nCantidad
                    nRestoPreliquidacion(llave) += nCantidad
                End If
            Next



            C1FlexGridEfectivo.SetData(C1FlexGridEfectivo.Row, 2, Nothing) 'Denominacion
            C1FlexGridEfectivo.SetData(C1FlexGridEfectivo.Row, 3, Nothing) 'Cantidad
            C1FlexGridEfectivo.SetData(C1FlexGridEfectivo.Row, 4, Nothing) 'Total
            LLenarDepositadoEfe()
            'Me.TextBoxTotalEfectivo.Text = nTotalEfectivo.ToString("#,##0.00")
            ActualizarRestoPreliquidacion()
            Eliminar(sPBEId)
        Else
            C1FlexGridEfectivo.SetData(C1FlexGridEfectivo.Row, 2, Nothing) 'Denominacion
            C1FlexGridEfectivo.SetData(C1FlexGridEfectivo.Row, 3, Nothing) 'Cantidad
            C1FlexGridEfectivo.SetData(C1FlexGridEfectivo.Row, 4, Nothing) 'Total
        End If
    End Sub

#End Region

    Private Sub TabControlPreliq_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlPreliq.SelectedIndexChanged
        'Se selecciono el tab de efectivo
        If bValidarCambiarTab Then
            Select Case TabControlPreliq.SelectedIndex
                Case 0 'Depositos
                    If bActualizar Then
                        If Not ActualizarEfectivos() Then
                            bValidarCambiarTab = False
                            TabControlPreliq.SelectedIndex = 1
                        End If
                    End If
                Case 1 'Efectivo
                    If bActualizar Then
                        If Not ActualizarDepositos() Then
                            bValidarCambiarTab = False
                            TabControlPreliq.SelectedIndex = 0
                        End If
                    End If
            End Select
            nRowActualizar = 0
            bValidarCambiarTab = True
        End If
    End Sub

    Private Sub LlenarGridEfectivo5()

        Dim nTotalEfe As New System.Collections.Generic.Dictionary(Of String, Decimal)
        For Each llave As String In sPLIId.Keys
            nTotalEfe(llave) = 0
            Dim PliId As String = sPLIId(llave)

            Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PBEId, TipoEfectivo,P.DenominacionID,Total ,D.Descripcion,D.Valor FROM PLBPLE P inner join Denominacion D on D.DenominacionID = P.DenominacionID WHERE PLIId = '" & PliId & "' and TipoEfectivo is not null", "LlenarGrid")
            Dim ValoresDenominacion As New Hashtable
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("DENOMINA")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresDenominacion.Add(refDesc.Id, refDesc.Cadena)
                Next
            End If
            aValores = Nothing

   
            Dim nTotal As Decimal = 0

            For Each oDr As DataRow In oDT.Rows
               
                nTotal = Decimal.Parse(oDr("Total")) * oDr("Valor").ToString
                nTotalEfe(llave) += Math.Round(nTotal, 2)
                Me.C1FlexGridEfectivo.AddItem(oDr("PBEId").ToString & vbTab & oDr("TipoEfectivo").ToString & vbTab & oDr("Descripcion").ToString & vbTab & oDr("Total").ToString & vbTab & nTotal & vbTab & oDr("DenominacionID").ToString)
                htDenominacion.Add(oDr("PBEId").ToString, oDr("TipoEfectivo"))
                lDetalle.Add(oDr("PBEId"))
            Next
            oDT.Dispose()

            For i As Integer = 1 To C1FlexGridEfectivo.Rows.Count - 1
                Dim sValor As String = C1FlexGridEfectivo.GetDataDisplay(i, "Denominacion")
                C1FlexGridEfectivo.Item(i, "Denominacion") = Nothing
                C1FlexGridEfectivo.Item(i, "Denominacion") = sValor
            Next
            nTotalEfectivo(llave) = Math.Round(nTotalEfe(llave), 2)
            nTotalPreliquidacion(llave) = nTotalPreliquidacion(llave) + nTotalEfectivo(llave)
            For i As Integer = 1 To C1FlexGridDepositoMoneda.Rows.Count - 1
                If C1FlexGridDepositoMoneda.GetData(i, "Moneda") = llave Then
                    'C1FlexGridDepositoMoneda.SetData(i, 2, nTotalDep(llave).ToString("#,##0.00"))
                    C1FlexGridEfectivoMoneda.SetData(i, 2, nTotalEfe(llave).ToString("#,##0.00"))
                End If

            Next
            'Me.TextBoxTotalEfectivo.Text = nTotalEfe.ToString("#,##0.00")
        Next
    End Sub


    
    Private Sub C1FlexGridDeposito_SetupEditor(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridDeposito.SetupEditor
        With C1FlexGridDeposito
            If e.Col = 3 AndAlso TypeOf .Editor Is TextBox Then 'Referencia
                Dim tb As TextBox = .Editor
                tb.MaxLength = 16
            End If
            If e.Col = 7 AndAlso TypeOf .Editor Is TextBox Then 'Ficha
                Dim tb As TextBox = .Editor
                tb.MaxLength = 16
            End If
        End With
    End Sub
End Class


