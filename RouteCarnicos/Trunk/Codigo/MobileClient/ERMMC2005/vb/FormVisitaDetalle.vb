Imports System.Collections.Generic

Public Class FormVisitaDetalle
    Public Sub New(ByVal pvVisitaClave As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sVisitaClave = pvVisitaClave
    End Sub

#Region "VARIABLES"
    Private sVisitaClave As String = String.Empty
    Private sClienteClave As String = String.Empty
    Private refaVista As Vista
    Private bIniciando As Boolean = True
    Private oArrIndicesMov(1, 0) As String
    Private oArrIndicesMovDet(1, 0) As String
#End Region

#Region "METODOS"
    Private Sub RecuerparNombresModuloMovDetalle()
        Dim oDt As DataTable = oDBApp.RealizarConsultaSQL("select vavclave, descripcion from vavdescripcion where varcodigo='TINDMMD' order by vavclave", "Indices")
        Dim n As Integer = 0
        For Each oDr As DataRow In oDt.Rows
            ReDim Preserve oArrIndicesMovDet(1, n)
            oArrIndicesMovDet(0, n) = oDr("VAVClave")
            oArrIndicesMovDet(1, n) = oDr("Descripcion")
            n += 1
        Next
        oDt.Dispose()
    End Sub

    Private Sub RecuerparNombresModuloMov()
        Dim oDt As DataTable = oDBApp.RealizarConsultaSQL("select vavclave, descripcion from vavdescripcion where varcodigo='TINDM' order by vavclave", "Indices")
        Dim n As Integer = 0
        For Each oDr As DataRow In oDt.Rows
            ReDim Preserve oArrIndicesMov(1, n)
            oArrIndicesMov(0, n) = oDr("VAVClave")
            oArrIndicesMov(1, n) = oDr("Descripcion")
            n += 1
        Next
        oDt.Dispose()
    End Sub

    Private Sub LlenarGridMovimientos()
        Me.LimpiarGridMovimientos()
        Dim sQuery As New System.Text.StringBuilder
        sQuery.Append("SELECT DISTINCT MM.Nombre as NombreMM, MMD.Nombre as NombreMMD, MM.TipoIndice as TIMM, MMD.TipoIndice as TIMMD, 'TINDMMD' as VR ")
        sQuery.Append("FROM TransProd TP INNER JOIN ModuloMovDetalle MMD ON TP.PCEModuloMovDetClave=MMD.ModuloMovDetalleClave ")
        sQuery.Append("INNER JOIN ModuloMov MM ON MMD.ModuloMovClave=MM.ModuloMovClave AND TP.Folio IS NOT NULL AND TP.VisitaClave='" & sVisitaClave & "' and TP.Tipo=" & ServicesCentral.TiposTransProd.Pedido)
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TransProd")
        'Pagos
        If oDBVen.RealizarConsultaSQL("SELECT Folio FROM Abono WHERE VisitaClave='" & sVisitaClave & "'", "Pago").Rows.Count > 0 Then
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT DISTINCT MM.Nombre as NombreMM, MMD.Nombre as NombreMMD, MM.TipoIndice as TIMM, MMD.TipoIndice as TIMMD, 'TINDMMD' as VR ")
            sQuery.Append("FROM ModuloMovDetalle MMD INNER JOIN ModuloMov MM ON MMD.ModuloMovClave=MM.ModuloMovClave AND MMD.TipoIndice=6")
            oDt.Merge(oDBVen.RealizarConsultaSQL(sQuery.ToString, "Abono"))
        End If
        'Improductividad
        If oDBVen.RealizarConsultaSQL("SELECT ProductoClave FROM ImproductividadProd WHERE VisitaClave='" & sVisitaClave & "'", "ImprodProd").Rows.Count > 0 OrElse oDBVen.RealizarConsultaSQL("SELECT TipoMotivo FROM ImproductividadVenta WHERE VisitaClave='" & sVisitaClave & "'", "ImprodVenta").Rows.Count > 0 Then
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT DISTINCT MM.Nombre as NombreMM, MMD.Nombre as NombreMMD, MM.TipoIndice as TIMM, MMD.TipoIndice as TIMMD, 'TINDMMD' as VR ")
            sQuery.Append("FROM ModuloMovDetalle MMD INNER JOIN ModuloMov MM ON MMD.ModuloMovClave=MM.ModuloMovClave AND MMD.TipoIndice=1")
            oDt.Merge(oDBVen.RealizarConsultaSQL(sQuery.ToString, "Improductividad"))
        End If
        'Solicitudes
        If oDBVen.RealizarConsultaSQL("SELECT Folio FROM Solicitud WHERE VisitaClave='" & sVisitaClave & "'", "Solicitud").Rows.Count > 0 Then
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT DISTINCT MM.Nombre as NombreMM, MMD.Nombre as NombreMMD, MM.TipoIndice as TIMM, MMD.TipoIndice as TIMMD, 'TINDMMD' as VR ")
            sQuery.Append("FROM ModuloMovDetalle MMD INNER JOIN ModuloMov MM ON MMD.ModuloMovClave=MM.ModuloMovClave AND MMD.TipoIndice=2")
            oDt.Merge(oDBVen.RealizarConsultaSQL(sQuery.ToString, "Solicitud"))
        End If
        'Mercadeo
        If oDBVen.RealizarConsultaSQL("SELECT Merid FROM MerDetalle WHERE VisitaClave='" & sVisitaClave & "'", "Mercadeo").Rows.Count > 0 Then
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT DISTINCT MM.Nombre as NombreMM, MMD.Nombre as NombreMMD, MM.TipoIndice as TIMM, MMD.TipoIndice as TIMMD, 'TINDMMD' as VR ")
            sQuery.Append("FROM ModuloMovDetalle MMD INNER JOIN ModuloMov MM ON MMD.ModuloMovClave=MM.ModuloMovClave AND MMD.TipoIndice=19")
            oDt.Merge(oDBVen.RealizarConsultaSQL(sQuery.ToString, "Mercadeo"))
        End If
        'Encuestas
        If oDBVen.RealizarConsultaSQL("SELECT CENClave FROM Encuesta WHERE VisitaClave='" & sVisitaClave & "'", "Mercadeo").Rows.Count > 0 Then
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT DISTINCT Nombre as NombreMM, Nombre as NombreMMD, TipoIndice as TIMM, TipoIndice as TIMMD, 'TINDM' as VR FROM ModuloMov WHERE TipoIndice=2")
            oDt.Merge(oDBVen.RealizarConsultaSQL(sQuery.ToString, "Encuestas"))
        End If
        oDt.AcceptChanges()
        Try
            For Each oDr As DataRow In oDt.Rows
                If oDr("VR") = "TINDMMD" Then
                    'Nombres de los movimientos
                    For i As Integer = 0 To oArrIndicesMovDet.GetLength(1) - 1
                        If oArrIndicesMovDet(0, i) = oDr("TIMMD") Then
                            oDr("NombreMMD") = oArrIndicesMovDet(1, i)
                            Exit For
                        End If
                    Next
                    'Nombres de los módulos
                    For i As Integer = 0 To oArrIndicesMov.GetLength(1) - 1
                        If oArrIndicesMov(0, i) = oDr("TIMM") Then
                            oDr("NombreMM") = oArrIndicesMov(1, i)
                            Exit For
                        End If
                    Next
                Else
                    For i As Integer = 0 To oArrIndicesMov.GetLength(1) - 1
                        If oArrIndicesMov(0, i) = oDr("TIMM") Then
                            oDr("NombreMM") = oArrIndicesMov(1, i)
                            oDr("NombreMMD") = oArrIndicesMov(1, i)
                            Exit For
                        End If
                    Next
                End If
            Next
            oDt.AcceptChanges()
            Me.GridMovimientos.DataSource = oDt
            Me.GridMovimientos.Cols(0).Width = 105
            Me.GridMovimientos.Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "XModulo")
            Me.GridMovimientos.Cols(0).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            Me.GridMovimientos.Cols(1).Width = 125
            Me.GridMovimientos.Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "XMovimiento")
            Me.GridMovimientos.Cols(1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            Me.GridMovimientos.Cols(2).Visible = False
            Me.GridMovimientos.Cols(3).Visible = False
            Me.GridMovimientos.Cols(4).Visible = False
            Me.GridMovimientos.Row = -1
            Me.bIniciando = False
            If oDt.Rows.Count > 0 Then
                Me.GridMovimientos.Row = 1
            End If
        Catch ex As Exception
            Me.bIniciando = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Amesol Route")
        End Try
    End Sub

    Private Sub LimpiarGridMovimientos()
        With Me.GridMovimientos
            .DataSource = Nothing
            .Cols.Count = 2
            .Cols.Fixed = 0
            .Rows.Count = 1
            .Rows.Fixed = 1
        End With
    End Sub

    Private Sub LimpiarGridDetalles()
        With Me.GridDetalles
            .DataSource = Nothing
            .Cols.Count = 1
            .Cols.Fixed = 0
            .Rows.Count = 1
            .Rows.Fixed = 1
        End With
    End Sub

    Private Sub LlenarGridDetalles()
        Try
            Me.LimpiarGridDetalles()
            Dim sTipo As String = Me.GridMovimientos.Item(Me.GridMovimientos.RowSel, 4).ToString
            Dim iIndice As Integer
            Dim oDt, oDtTmp As DataTable
            oDt = New DataTable
            If sTipo = "TINDMMD" Then
                iIndice = Me.GridMovimientos.Item(Me.GridMovimientos.RowSel, 3)
                Select Case iIndice
                    Case 1 'Improductividad
                        'oDt = oDBVen.RealizarConsultaSQL("SELECT DISTINCT TipoMotivo FROM ImproductividadProd WHERE VisitaClave='" & sVisitaClave & "' UNION SELECT DISTINCT TipoMotivo FROM ImproductividadVenta WHERE VisitaClave='" & sVisitaClave & "' AND TipoMotivo NOT IN(SELECT DISTINCT TipoMotivo FROM ImproductividadProd WHERE VisitaClave='" & sVisitaClave & "')", "Improd")
                        oDt = oDBVen.RealizarConsultaSQL("SELECT DISTINCT TipoMotivo FROM ImproductividadProd WHERE VisitaClave='" & sVisitaClave & "' UNION SELECT DISTINCT TipoMotivo FROM ImproductividadVenta WHERE VisitaClave='" & sVisitaClave & "'", "Improd")
                        oDt.Columns.Add("TipoMotivo2", GetType(String))
                        'Dim oValRef As New ValorReferencia
                        For Each oDr As DataRow In oDt.Rows
                            oDr("TipoMotivo2") = ValorReferencia.BuscarEquivalente("MOTIMPRO", oDr("TipoMotivo"))
                        Next
                        oDt.Columns.Remove("TipoMotivo")
                        oDt.AcceptChanges()
                    Case 2 'Solicitudes
                        oDtTmp = oDBVen.RealizarConsultaSQL("SELECT Folio, TipoArea FROM Solicitud WHERE VisitaClave='" & sVisitaClave & "'", "Solicitud")
                        oDt.Columns.Add("Folio", GetType(String))
                        oDt.Columns.Add("TipoArea", GetType(String))
                        For Each oDr As DataRow In oDtTmp.Rows
                            'Dim oDr2 As DataRow = oDtTmp.NewRow
                            'oDr2(0) = oDr("Folio")
                            'oDr2(1) = ValorReferencia.BuscarEquivalente("SOLTAREA", oDr("TipoArea"))
                            oDt.Rows.Add(New Object() {oDr("Folio"), ValorReferencia.BuscarEquivalente("SOLTAREA", oDr("TipoArea"))})
                        Next
                        oDt.AcceptChanges()
                        oDtTmp.Dispose()
                    Case 6 'Abonos
                        oDt = oDBVen.RealizarConsultaSQL("SELECT Folio, Total FROM Abono WHERE VisitaClave='" & sVisitaClave & "'", "Pago")
                    Case 19
                        oDt = oDBVen.RealizarConsultaSQL("SELECT Tipo FROM MerDetalle WHERE VisitaClave='" & sVisitaClave & "'", "Mercadeo")
                    Case Else 'Transprod
                        oDt = oDBVen.RealizarConsultaSQL("SELECT Folio, Total FROM TransProd WHERE VisitaClave='" & sVisitaClave & "' AND Folio IS NOT NULL AND PCEModuloMovDetClave in (SELECT ModuloMovDetalleClave FROM ModuloMovDetalle WHERE TipoIndice=" & iIndice & ")", "TransProd")
                End Select
            Else
                oDt = oDBVen.RealizarConsultaSQL("SELECT CENClave FROM Encuesta WHERE VisitaClave='" & sVisitaClave & "'", "Encuesta")
            End If
            Me.GridDetalles.DataSource = oDt
            Me.GridDetalles.Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "XActividad")
            Me.GridDetalles.Cols(0).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            If sTipo = "TINDMMD" AndAlso iIndice <> 1 AndAlso iIndice <> 19 Then
                Me.GridDetalles.Cols(0).Width = 105
                Me.GridDetalles.Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "XConcepto")
                Me.GridDetalles.Cols(1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                Me.GridDetalles.Cols(1).Width = 125
                If iIndice <> 2 Then
                    Me.GridDetalles.Cols(1).Format = "c"
                End If
            Else
                Me.GridDetalles.Cols(0).Width = Me.GridDetalles.Width
            End If
            Me.GridDetalles.Row = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Amesol Route")
        End Try
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function ObtieneClaveCliente() As String
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("select clienteclave from visita where visitaclave='" & sVisitaClave & "'", "ObtieneClienteClave")
        If oDt.Rows.Count > 0 Then
            oDt.Dispose()
            Return oDt.Rows(0)(0)
        Else
            oDt.Dispose()
            Return ""
        End If
    End Function
#End Region

#Region "EVENTOS"
    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub FormVisitaDetalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormVisitaDetalle", refaVista) Then
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.LabelDetalleVisita.Text = refaVista.BuscarMensaje("MsgBox", "XVisita") & " " & oDBVen.RealizarConsultaSQL("SELECT Numero From Visita WHERE VisitaClave='" & sVisitaClave & "'", "NumeroVisita").Rows(0)(0).ToString
        'sClienteClave = Me.ObtieneClaveCliente
        Me.RecuerparNombresModuloMovDetalle()
        Me.RecuerparNombresModuloMov()
        Me.LimpiarGridDetalles()
        Me.LlenarGridMovimientos()
        'Me.GridMovimientos.RowSel = 0

        Me.GridMovimientos.Focus()

    End Sub

    Private Sub GridMovimientos_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMovimientos.SelChange
        If Not bIniciando Then
            Me.LlenarGridDetalles()
        End If
    End Sub
#End Region
   
End Class