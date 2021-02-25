Public Class FormPreguntaMatricial
    Inherits System.Windows.Forms.Form

#Region "Buttons ShortCuts"
    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125
    Public Const BTN_BACK = 126

    Private Sub Mapeo_Teclas(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case BTN_CONTINUAR
                ButtonContinuar_Click(Me, Nothing)
            Case BTN_BACK
                ButtonRegresar_Click(Me, Nothing)
        End Select
    End Sub
#End Region

#Region "Variables"
    Private oCliente As Cliente
    Private sVisitaClave As String
    Private refaVista As Vista
    Private oEncuesta As cEncuesta
    Private oPregunta As cPreguntaMatricial
    Private bCargando As Boolean
#End Region

#Region "Forma"
    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        ButtonContinuar.Enabled = bHabilitar
        MenuItemSalir.Enabled = bHabilitar And oEncuesta.HabilitarSalir
        If bHabilitar Then
            ButtonRegresar.Enabled = (bHabilitar And Not (oEncuesta.Preguntas.bPrimerPregunta))
        Else
            ButtonRegresar.Enabled = bHabilitar
        End If
        ButtonSalir.Enabled = bHabilitar
    End Sub

    Private Sub FormPreguntaMatricial_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.Mapeo_Teclas(e)
    End Sub

    Private Sub FormPreguntaMatricial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPreguntaMatricial", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        'application.DoEvents()
        MostrarPregunta()
        Me.KeyPreview = True
        'HabilitarBotones(True)
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub FormPreguntaMatricial_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                oPregunta.ValidarRespuesta()
                If oPregunta.Confirmacion Then
                    bCont = (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0049"), MsgBoxStyle.YesNo, refaVista.BuscarMensaje("MsgBox", "XMensajeP")) = MsgBoxResult.Yes)
                End If
                If bCont Then
                    oEncuesta.Preguntas.PreguntaActual.Insertar(oEncuesta.ENCId, oEncuesta.Preguntas.nOrdenActual, 1)
                    oEncuesta.Preguntas.SiguientePregunta()
                Else
                    Cursor.Current = Cursors.Default
                    e.Cancel = True
                    HabilitarBotones(True)
                End If
            ElseIf Me.DialogResult = Windows.Forms.DialogResult.No Or Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
                oEncuesta.Preguntas.AnteriorPregunta()
            End If
        Catch ex As CEstado
            Cursor.Current = Cursors.Default
            If Not oEncuesta.Preguntas.bFinEncuesta Then
                If ex.sCVEMensaje = "E0712" Then
                    MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.CantidadRequerida}), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                Else
                    MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                End If
                e.Cancel = True
                HabilitarBotones(True)
            End If
        End Try
    End Sub
#End Region

#Region "Metodos"
    Public Sub MostrarPregunta()
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height

        LlenarGrid()
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    Private Sub LlenarGrid()
        Dim nRow As Integer = 2
        Dim nCol As Integer = 2
        grdMatricial.Rows.Count = oPregunta.PreguntasMat.Count + 2
        grdMatricial.Cols.Count = oPregunta.RespuestasMat.Count + 2
        grdMatricial.Rows.Fixed = 2 'Descripcion Pregunta
        grdMatricial.Cols.Fixed = 0 'Descripcion Respuesta
        grdMatricial.Rows(1).Visible = False 'CRMNumero
        grdMatricial.Cols(1).Visible = False 'CPMNumero
        For Each oPreg As cPreguntaMatricial.cPreguntaMat In oPregunta.PreguntasMat
            grdMatricial.SetData(nRow, 0, oPreg.MatDescripcion)
            grdMatricial.SetData(nRow, 1, oPreg.CPMNumero)
            nRow += 1
        Next
        grdMatricial.Cols(0).AllowEditing = False
        grdMatricial.Cols(1).AllowEditing = False
        Dim oStyle As C1.Win.C1FlexGrid.CellStyle = grdMatricial.Styles.Fixed
        grdMatricial.Cols(0).Style = oStyle
        oStyle = Nothing
        For Each oResp As cPreguntaMatricial.cRespuestaMat In oPregunta.RespuestasMat
            Select Case oResp.TipoValor
                Case 1 'Seleccion
                    grdMatricial.Cols(nCol).DataType = GetType(Boolean)
                    grdMatricial.Cols(nCol).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                Case 2 'Texto
                    grdMatricial.Cols(nCol).DataType = GetType(String)
                    grdMatricial.Cols(nCol).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                Case 3 'Numero
                    grdMatricial.Cols(nCol).DataType = GetType(Double)
                    grdMatricial.Cols(nCol).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            End Select
            grdMatricial.SetData(0, nCol, oResp.MatDescripcion)
            grdMatricial.SetData(1, nCol, oResp.CRMNumero)
            nCol += 1
        Next
        For Each oSel As cPreguntaMatricial.cSeleccionadoMat In oPregunta.SeleccionadosMat
            SeleccionarRespuesta(oSel.CPMNumero, oSel.CRMNumero, oSel.Valor)
        Next
        grdMatricial.AutoSizeCols()
    End Sub

    Private Sub SeleccionarRespuesta(ByVal pvCPMNumero As Integer, ByVal pvCRMNumero As Integer, ByVal pvValor As String)
        Dim nContCol As Integer
        Dim nContRow As Integer
        Dim nCol As Integer
        Dim nRow As Integer
        For nContRow = 2 To grdMatricial.Rows.Count - 1
            If grdMatricial.GetData(nContRow, 1) = pvCPMNumero Then
                nRow = nContRow
                Exit For
            End If
        Next
        For nContCol = 2 To grdMatricial.Cols.Count - 1
            If grdMatricial.GetData(1, nContCol) = pvCRMNumero Then
                nCol = nContCol
                Exit For
            End If
        Next
        If nRow <> 0 And nCol <> 0 Then
            If grdMatricial.Cols(nCol).DataType.Name = "Boolean" Then
                grdMatricial.SetData(nRow, nCol, True)
            Else
                grdMatricial.SetData(nRow, nCol, pvValor)
            End If
        End If
    End Sub
#End Region

#Region "Eventos"
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        HabilitarBotones(False)
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        HabilitarBotones(False)
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub DetailViewPregunta_ItemValidating(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ValidatingEventArgs) Handles DetailViewPregunta.ItemValidating
        If Not bCargando Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click, MenuItemSalir.Click
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
#End Region

    Private Sub grdMatricial_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdMatricial.AfterEdit
        If oPregunta.RespuestasMat(e.Col - 1).TipoValor = 3 Then
            grdMatricial.Cols(e.Col).DataType = GetType(Double)
            Try
                If grdMatricial.GetData(e.Row, e.Col) = "" Then
                    Exit Try
                End If
                Double.Parse(grdMatricial.GetData(e.Row, e.Col))
            Catch
                grdMatricial.SetData(e.Row, e.Col, 0)
            End Try

        End If

        Dim nCPMNumero As Integer
        Dim nCRMNumero As Integer
        nCPMNumero = grdMatricial.GetData(e.Row, 1)
        nCRMNumero = grdMatricial.GetData(1, e.Col)
        If grdMatricial.Cols(e.Col).DataType.Name = "Boolean" Then
            If grdMatricial.GetData(e.Row, e.Col) = True Then
                If Not oPregunta.SeleccionadosMat.Exists(nCPMNumero, nCRMNumero) Then
                    oPregunta.SeleccionadosMat.Add(nCPMNumero, nCRMNumero, "")
                End If
            Else
                oPregunta.SeleccionadosMat.Remove(nCPMNumero, nCRMNumero)
            End If
        Else
            If Not IsNothing(grdMatricial.GetData(e.Row, e.Col)) AndAlso grdMatricial.GetData(e.Row, e.Col).ToString <> "" Then
                If oPregunta.SeleccionadosMat.Exists(nCPMNumero, nCRMNumero) Then
                    oPregunta.SeleccionadosMat.Remove(nCPMNumero, nCRMNumero)
                End If
                oPregunta.SeleccionadosMat.Add(nCPMNumero, nCRMNumero, grdMatricial.GetData(e.Row, e.Col))
            Else
                oPregunta.SeleccionadosMat.Remove(nCPMNumero, nCRMNumero)
            End If
        End If
    End Sub

    Private Sub grdMatricial_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdMatricial.BeforeEdit
        If grdMatricial.Cols(e.Col).DataType.Name = "Double" Then
            grdMatricial.Cols(e.Col).DataType = GetType(String)
        End If
    End Sub
End Class