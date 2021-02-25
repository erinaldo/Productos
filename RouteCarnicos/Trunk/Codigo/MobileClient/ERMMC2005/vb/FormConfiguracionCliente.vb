Imports System.Data.SqlServerCe

Public Class FormConfiguracionCliente

    Public Sub New(ByVal pvClienteClave As String, ByVal pvOpcion As OpcionAVer, Optional ByVal pvblnEdicion As Boolean = False)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sClienteClave = pvClienteClave
        eOpcion = pvOpcion
        blnEdicion = pvblnEdicion
    End Sub

#Region "VARIABLES"
    Private eOpcion As OpcionAVer
    Private refaVista As Vista
    Private sClienteClave As String = String.Empty
    Private oArreglo As String()
    Private oArregloIndex As ArrayList
    Private oVista As Vista
    Private odtEsquemas As DataTable
    Private blnOrdenando As Boolean = False
    Private blnCambios As Boolean = False
    Private blnEdicion As Boolean = False
#End Region

#Region "ENUMS"
    Public Enum OpcionAVer
        ActivosPrestados = 1
        PrestamoDeEnvase = 2
        PromedioDeCompra = 3
        EsquemasDeCliente = 4
        'DepositosGarantia = 5
    End Enum
#End Region
#Region "Propiedades"
    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region

#Region "METODOS"
    Private Sub PonerTitulo(ByVal pvOpcion As OpcionAVer)
        Select Case pvOpcion
            Case OpcionAVer.ActivosPrestados
                Me.lbTitulo.Text = Me.refaVista.BuscarMensaje("MsgBox", "lbTitActivos")
            Case OpcionAVer.PrestamoDeEnvase
                Me.lbTitulo.Text = Me.refaVista.BuscarMensaje("MsgBox", "lbTitEnvase")
            Case OpcionAVer.PromedioDeCompra
                Me.lbTitulo.Text = Me.refaVista.BuscarMensaje("MsgBox", "lbTitCompra")
            Case OpcionAVer.EsquemasDeCliente
                Me.lbTitulo.Text = Me.refaVista.BuscarMensaje("MsgBox", "lbTitEsquemas")
                'Case OpcionAVer.DepositosGarantia
                '    Me.lbTitulo.Text = Me.refaVista.BuscarMensaje("MsgBox", "lbTitDepositos")
        End Select

        If oVendedor.ActualizaEsquema And pvOpcion = OpcionAVer.EsquemasDeCliente And blnEdicion Then
            Me.btRegresar.Location = New System.Drawing.Point(86, 262)
            Me.btContinuar.Visible = True
        Else
            Me.btRegresar.Location = Me.btContinuar.Location
            Me.btContinuar.Visible = False
        End If
    End Sub

    Private Sub ConfigurarGrid(ByVal pvOpcion As OpcionAVer)
        With Me.FG
            .DataSource = Nothing
            .ClipSeparators = vbTab + vbLf
            .Cols.Count = 0
            .Cols.Fixed = 0
            .Rows.Count = 1
            .Rows.Fixed = 1
            Select Case pvOpcion
                Case OpcionAVer.ActivosPrestados
                    Dim oDataMap As New Hashtable
                    Dim aValores As ArrayList = ValorReferencia.RecuperarLista("ACIFASE")
                    If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                        For Each refDesc As ValorReferencia.Descripcion In aValores
                            oDataMap.Add(refDesc.Id, refDesc.Cadena)
                        Next
                    End If
                    aValores = Nothing
                    'For Each oDr As DataRow In ValorReferencia.RecuperarLista("ACIFASE").Rows
                    '    oDataMap.Add(oDr(0), oDr(1))
                    'Next
                    .Cols.Count = 2
                    .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "XActivo")
                    .Cols(0).Width = 116
                    .Cols(0).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop
                    .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "XEstado")
                    .Cols(1).Width = 116
                    .Cols(1).DataMap = oDataMap
                    .Cols(1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop
                Case OpcionAVer.PrestamoDeEnvase
                    .Cols.Count = 5
                    '.Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "XEnvase")
                    .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre2")
                    .Cols(0).Width = 70
                    .Cols(0).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop

                    .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Cargo")
                    .Cols(1).Width = 40
                    .Cols(1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop

                    .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "Abono")
                    .Cols(2).Width = 40
                    .Cols(2).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop

                    .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Venta")
                    .Cols(3).Width = 40
                    .Cols(3).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop

                    .Cols(4).Caption = refaVista.BuscarMensaje("MsgBox", "Saldo")
                    .Cols(4).Width = 40
                    .Cols(4).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterTop



                Case OpcionAVer.PromedioDeCompra
                    Me.ConfiguraGrid()
                Case OpcionAVer.EsquemasDeCliente
                    If Not oVendedor.ActualizaEsquema Or Not blnEdicion Then
                        .Cols.Count = 2
                        .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "Clave")
                        .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "ESQNombre")
                    End If
                    'Case OpcionAVer.DepositosGarantia
                    '    .Cols.Count = 7
                    '    .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "Tipo")
                    '    .Cols(0).Width = 100
                    '    .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "FechaVencimiento")
                    '    .Cols(1).Width = 80
                    '    .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "Total")
                    '    .Cols(2).Width = 80
                    '    .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Cuotas")
                    '    .Cols(3).Width = 70
                    '    .Cols(4).Caption = refaVista.BuscarMensaje("MsgBox", "CuotasPagadas")
                    '    .Cols(4).Width = 70
                    '    .Cols(5).Caption = refaVista.BuscarMensaje("MsgBox", "Saldo")
                    '    .Cols(5).Width = 70
                    '    .Cols(6).Caption = refaVista.BuscarMensaje("MsgBox", "NivelCredito")
                    '    .Cols(6).Width = 70
            End Select
        End With
    End Sub

    Private Sub LlenarGrid(ByVal pvOpcion As OpcionAVer)
        Dim oDt As DataTable
        Dim sQuery As String = String.Empty
        Select Case pvOpcion
            Case OpcionAVer.ActivosPrestados
                sQuery = "SELECT A.Nombre, A.TipoFase FROM Activo A INNER JOIN ActivoClienteHist ACH ON A.ActivoClave=ACH.ActivoClave AND ACH.ClienteClave='" & sClienteClave & "' AND ACH.TipoEstado=1"
                oDt = oDBVen.RealizarConsultaSQL(sQuery, "Activos")
                For Each oDr As DataRow In oDt.Rows
                    Me.FG.AddItem(oDr("Nombre").ToString + vbTab + oDr("TipoFase").ToString)
                Next
            Case OpcionAVer.PrestamoDeEnvase
                sQuery = "SELECT P.Nombre,PPC.Cargo as Cantidad,ppc.Abono,ppc.Venta,ppc.Saldo  from ProductoPrestamoCLI PPC "
                sQuery &= "INNER JOIN Producto P ON PPC.ProductoClave=P.ProductoClave "
                sQuery &= "where PPC.ClienteClave='" & sClienteClave & "'"
                oDt = oDBVen.RealizarConsultaSQL(sQuery, "Envase")

             

                For Each oDr As DataRow In oDt.Rows
                    Me.FG.AddItem(oDr("Nombre").ToString + vbTab + oDr("Cantidad").ToString + vbTab + oDr("Abono").ToString + vbTab + oDr("Venta").ToString + vbTab + oDr("Saldo").ToString)
                Next

            Case OpcionAVer.PromedioDeCompra

                Me.PoblarGridMovimientos()
            Case OpcionAVer.EsquemasDeCliente
                If oVendedor.ActualizaEsquema And blnEdicion Then
                    sQuery = "select case When ClienteEsquema.ClienteClave is null Then convert(bit,0) else convert(bit,1) End as Agregado, Esquema.Clave, Esquema.Nombre,Esquema.EsquemaID from esquema left join ClienteEsquema on Esquema.EsquemaID = ClienteEsquema.EsquemaID and  ClienteEsquema.ClienteClave = '" & sClienteClave & "' and ClienteEsquema.Baja = 0  where Esquema.Tipo = 1  order by Agregado desc,Clave "
                    odtEsquemas = oDBVen.RealizarConsultaSQL(sQuery, "Esquemas")
                    Me.FG.DataSource = odtEsquemas
                    FG.AllowEditing = True
                    FG.Cols(0).Caption = String.Empty
                    FG.Cols(0).Width = 20
                    FG.Cols(1).AllowEditing = False
                    FG.Cols(2).AllowEditing = False
                    FG.Cols(3).Visible = False
                    FG.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor

                    FG.Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Clave")
                    FG.Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "ESQNombre")
                Else
                    sQuery = "SELECT E.Clave, E.Nombre FROM Esquema E INNER JOIN ClienteEsquema CE ON E.EsquemaId=CE.EsquemaId AND CE.ClienteClave='" & sClienteClave & "' and Baja = 0"
                    oDt = oDBVen.RealizarConsultaSQL(sQuery, "Esquemas")
                    For Each oDr As DataRow In oDt.Rows
                        Me.FG.AddItem(oDr("Clave").ToString & vbTab & oDr("Nombre").ToString)
                    Next
                End If
                'Case OpcionAVer.DepositosGarantia
                '    sQuery = "SELECT TipoDEG, case TipoDeg when 3 then FechaVencimiento else '' end as FechaVencimiento, Total, case TipoDeg when 4 then Cuotas else '' end as Cuotas, case TipoDeg when 4 then CuotasPagadas else '' end as CuotasPagadas, Saldo, NivelCredito FROM DepositoGarantiaBase WHERE ClienteClave='" & sClienteClave & "'"
                '    oDt = oDBVen.RealizarConsultaSQL(sQuery, "Depositos")
                '    If oDt.Rows.Count > 0 Then
                '        Dim htValores As New Hashtable
                '        For Each oDr As DataRow In ValorReferencia.RecuperarLista("TDEPGAR").Rows
                '            htValores.Add(oDr(0), oDr(1))
                '        Next
                '        For Each odr As DataRow In oDt.Rows
                '            Me.FG.AddItem(odr("TipoDEG").ToString & "-" & htValores(odr("TipoDEG")).ToString & vbTab & Format(odr("FechaVencimiento"), "dd/MM/yyyy") & vbTab & FormatNumber(odr("Total"), 2, , , TriState.True) & vbTab & odr("Cuotas").ToString & vbTab & odr("CuotasPagadas").ToString & vbTab & FormatNumber(odr("Saldo"), 2, , , TriState.True) & vbTab & odr("NivelCredito").ToString)
                '        Next
                '    End If

        End Select
        If Not oDt Is Nothing Then
            oDt.Dispose()
        End If
    End Sub



#End Region

#Region "FUNCIONES"



    Private Function CadenaParaFG(ByVal pvArreglo As String()) As String
        Dim sCadena As String = String.Empty
        Dim iFin As Integer = pvArreglo.Length - 1
        For i As Integer = 0 To iFin
            If i <> iFin Then
                sCadena &= pvArreglo(i) + vbTab
            Else
                sCadena &= pvArreglo(i)
            End If
        Next
        Return sCadena
    End Function

    Private Function CantidadTransProdIds(ByVal pvArr As DataRow()) As Integer
        Dim oArr As New ArrayList
        For Each oDr As DataRow In pvArr
            If Not oArr.Contains(oDr("TransProdId")) Then
                oArr.Add(oDr("TransProdId"))
            End If
        Next
        Return oArr.Count
    End Function
#End Region

#Region "EVENTOS"
    Private Sub FormConfiguracionCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormConfiguracionCliente", refaVista) Then
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.PonerTitulo(eOpcion)
        Me.ConfigurarGrid(eOpcion)
        Me.LlenarGrid(eOpcion)
    End Sub

    Private Sub btRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRegresar.Click
        If eOpcion = OpcionAVer.EsquemasDeCliente And oVendedor.ActualizaEsquema And blnEdicion And blnCambios Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub
#End Region

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        btRegresar_Click(Nothing, Nothing)
    End Sub

#Region "Con Arbolito"
    Private Sub PoblarGridMovimientos()
        FG.Rows.Count = 1
        Dim sQuery As String = String.Empty
        'Dim conf As New CONHist()
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Then
            sQuery = "SELECT TPD.ProductoClave, P.Nombre, TPD.TipoUnidad, SUM(TPD.Cantidad) as Cantidad FROM TransProd TP INNER JOIN TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId INNER JOIN Producto P ON TPD.ProductoClave=P.ProductoClave INNER JOIN Visita V ON TP.VisitaClave=V.VisitaClave AND V.ClienteClave='" & sClienteClave & "' AND TP.Tipo=1 AND TP.TipoFase=1 GROUP BY TPD.ProductoClave, P.Nombre, TPD.TipoUnidad order by TPD.ProductoClave "
        Else
            If Not (oConHist.Campos("CobrarVentas")) Then
                sQuery = "SELECT TPD.ProductoClave, P.Nombre, TPD.TipoUnidad, SUM(TPD.Cantidad) as Cantidad FROM TransProd TP INNER JOIN TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId INNER JOIN Producto P ON TPD.ProductoClave=P.ProductoClave AND TP.FacturaId IN (SELECT sTP.TransProdId FROM TransProd sTP INNER JOIN Visita V ON sTP.VisitaClave=V.VisitaClave AND V.ClienteClave='" & sClienteClave & "' AND sTP.Tipo=8 AND sTP.TipoFase=1) GROUP BY TPD.ProductoClave, P.Nombre, TPD.TipoUnidad,TPD.ProductoClave "
            Else
                sQuery = "SELECT TPD.ProductoClave, P.Nombre, TPD.TipoUnidad, SUM(TPD.Cantidad) as Cantidad FROM TransProd TP INNER JOIN TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId INNER JOIN Producto P ON TPD.ProductoClave=P.ProductoClave AND TP.TransProdId IN (SELECT sTP.TransProdId FROM TransProd sTP INNER JOIN Visita V ON sTP.VisitaClave=V.VisitaClave AND V.ClienteClave='" & sClienteClave & "' AND sTP.Tipo=1 AND sTP.TipoFase=1) GROUP BY TPD.ProductoClave, P.Nombre, TPD.TipoUnidad,TPD.ProductoClave "
            End If
        End If
        '    oDt = oDBVen.RealizarConsultaSQL(sQuery, "Compra")
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "ConfiguracionCliente")
        Dim sProductoClave As String = ""
        FG.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sProductoClave <> dr("ProductoClave").ToString Then
                sProductoClave = dr("ProductoClave").ToString
                r = FG.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With FG
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = FG.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With FG
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
            End With
        Next
        FG.Redraw = True
        dt.Dispose()
    End Sub
    Private Sub ConfiguraGrid()
        With FG
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 2
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "Clave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None

            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub
#End Region

    Private Sub btContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btContinuar.Click
        If eOpcion = OpcionAVer.EsquemasDeCliente And oVendedor.ActualizaEsquema And blnEdicion Then
            Cursor.Current = Cursors.WaitCursor
            If odtEsquemas.Select("Agregado = 1").Length = 0 Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0006"))
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Me.Transaccion = oDBVen.oConexion.BeginTransaction()

            Dim dtCambios As DataTable
            dtCambios = odtEsquemas.GetChanges()
            If Not IsNothing(dtCambios) Then
                For Each dr As DataRow In dtCambios.Rows
                    If dr("Agregado") = False Then
                        oDBVen.EjecutarComandoSQL(String.Format("Update ClienteEsquema set Baja = 1, MFechaHora = getdate(), MUsuarioID='{0}',Enviado = 0 where ClienteClave ='{1}' and EsquemaID='{2}'", oVendedor.UsuarioId, sClienteClave, dr("EsquemaID")))
                    Else
                        If oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from ClienteEsquema where ClienteClave='" & sClienteClave & "' and EsquemaID='" & dr("EsquemaID") & "'") > 0 Then
                            oDBVen.EjecutarComandoSQL(String.Format("Update ClienteEsquema set Baja = 0, MFechaHora = getdate(), MUsuarioID='{0}',Enviado = 0 where ClienteClave ='{1}' and EsquemaID='{2}'", oVendedor.UsuarioId, sClienteClave, dr("EsquemaID")))
                        Else
                            oDBVen.EjecutarComandoSQL(String.Format("Insert into ClienteEsquema values('{0}','{1}',getdate(),'{2}',0,0)", sClienteClave, dr("EsquemaID"), oVendedor.UsuarioId))
                        End If
                    End If
                Next
            End If
            Me.Transaccion.Commit()
            Me.Transaccion.Dispose()
            Me.Transaccion = Nothing
            dtCambios.Dispose()
            If oDBVen.oConexion.State = ConnectionState.Open Then
                oDBVen.oConexion.Close()
            End If
            Cursor.Current = Cursors.Default
        End If
        Me.Close()
    End Sub

    Private Sub FG_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FG.AfterEdit
        blnCambios = True
    End Sub

End Class