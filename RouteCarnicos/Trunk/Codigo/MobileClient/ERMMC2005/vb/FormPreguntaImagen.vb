Public Class FormPreguntaImagen
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
    Private oPregunta As cPreguntaImagen
    Private bCargando As Boolean
#If MOD_TERM = "SYMBOL" Then
    Private WithEvents oImaging As New HANDHELD.CImaging
#End If
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


#If MOD_TERM <> "PALM" And MOD_TERM <> "HHP" Then
    Private Sub FormPreguntaImagen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Try
            If oApp.ModeloTerminal = "SymbolMC70" OrElse oApp.ModeloTerminal = "SymbolMC55" Then
                If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
                    Try
                        oImaging.MostrarImaging()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                    Try
                        oImaging.Imagen()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End If

#If MOD_TERM <> "PALM" And MOD_TERM <> "HHP" Then
    Private Sub FormPreguntaImagen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If oApp.ModeloTerminal = "HHP7600" Or oApp.ModeloTerminal = "HHPWM6" Then
                If e.KeyCode = CType(42, Keys) Then
                    Try
                        oImaging.MostrarImaging()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End If

#If MOD_TERM <> "PALM" And MOD_TERM <> "HHP" Then
    Private Sub FormPreguntaCodigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Try
            If e.KeyCode = CType(42, Keys) Then
                If oApp.ModeloTerminal = "HHP7600" Or oApp.ModeloTerminal = "HHPWM6" Then
                    Try
                        oImaging.Imagen()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                Me.Mapeo_Teclas(e)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End If

    Private Sub FormPreguntaCodigo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        GC.Collect()
        'AgregarLogging("FormPreguntaCodigo_Load", "FormPreguntaCodigo_Load", AMESOLLogging.AMESOLLog.TipoLog.Funciones)

#If MOD_TERM = "HHPWM6" OrElse MOD_TERM = "HHP9700" Then
        If IsNothing([Global].oImaging) Then
            [Global].oImaging = New HANDHELD.CImaging
        End If
#End If

        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPreguntaImagen", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        'Application.DoEvents()
        MostrarPregunta()
        Me.KeyPreview = True
        'HabilitarBotones(True)
        Cursor.Current = System.Windows.Forms.Cursors.Default
        'AgregarLogging("Termina FormPreguntaCodigo_Load", "FormPreguntaCodigo_Load", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
    End Sub

    Private Sub FormPreguntaCodigo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                oPregunta.ValidarRespuesta()
                If oPregunta.Confirmacion Then
                    bCont = (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0049"), MsgBoxStyle.YesNo, refaVista.BuscarMensaje("MsgBox", "XMensajeP")) = MsgBoxResult.Yes)
                End If
                If bCont Then
                    Try
                        oPregunta.Respuesta = Guid.NewGuid.ToString("N")
                        If Not pcbImagen.Image Is Nothing Then
                            'AgregarLogging("GuardarImagen", "GuardarImagen", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
                            If Not System.IO.Directory.Exists(ImagenEncuesta) Then
                                System.IO.Directory.CreateDirectory(ImagenEncuesta)
                            End If
                            pcbImagen.Image.Save(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                            'AgregarLogging("Termina GuardarImagen", "GuardarImagen", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
                        End If
                        oEncuesta.Preguntas.PreguntaActual.Insertar(oEncuesta.ENCId, oEncuesta.Preguntas.nOrdenActual, 1)
                        oEncuesta.Preguntas.SiguientePregunta()
                        oPregunta.Respuesta = Nothing
                    Catch ex As Exception
                        Cursor.Current = Cursors.Default
                        MsgBox(ex.Message)
                        oEncuesta.Preguntas.SiguientePregunta()
                        oPregunta.Respuesta = Nothing
                    End Try
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
                MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                e.Cancel = True
                HabilitarBotones(True)
            End If
        End Try
    End Sub

    Private Sub FormPreguntaCodigo_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ActivarInactivarImager(False)
    End Sub
#End Region

#Region "Metodos"
    Public Sub MostrarPregunta()
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height

        oPregunta.RecuperarRespuesta()

        If Not oPregunta.Respuesta Is Nothing AndAlso System.IO.File.Exists(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg") Then
            pcbImagen.Image = New System.Drawing.Bitmap(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg")
            ActivarInactivarImager(True, False)
        Else
            ActivarInactivarImager(True)
        End If
        'If Not oPregunta.Respuesta Is Nothing Then
        '    Dim msImagen As New System.IO.MemoryStream(oPregunta.Respuesta)
        '    Me.pcbImagen.Image = New System.Drawing.Bitmap(msImagen)
        '    ActivarInactivarImager(True, False)
        'Else
        '    ActivarInactivarImager(True)
        'End If
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
        Me.ButtonContinuar.Focus()
    End Sub

    Private Sub ActivarInactivarImager(ByVal parbActivar As Boolean, Optional ByVal parbIniciar As Boolean = True)
#If MOD_TERM <> "PALM" And MOD_TERM <> "HHP" Then
        If parbActivar Then
            Select Case oApp.ModeloTerminal
                Case "Generico"
                Case "SymbolC9090", "SymbolMC50", "SymbolMC70", "SymbolMC55", "SymbolPPT8800"
                    Try
                        oImaging.Inicialize_Imaging(HANDHELD.SO.SymbolPCMC50, oPregunta.Calidad, parbIniciar, pcbImagen)
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try

                Case "HHP7600"
                    Try
                        oImaging.Inicialize_Imaging(HANDHELD.SO.HHP7600, oPregunta.Calidad, parbIniciar, pcbImagen)
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try

                Case "HHPWM6"
                    Try
                        oImaging.Inicialize_Imaging(HANDHELD.SO.HHPWM6, oPregunta.Calidad, parbIniciar, pcbImagen)
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
            End Select
        Else
            Select Case oApp.ModeloTerminal
                Case "Generico"
                Case "SymbolC9090", "SymbolMC50", "SymbolMC70", "HHP7600", "HHPWM6", "SymbolMC55", "SymbolPPT8800"
                    Try
                        oImaging.Terminate_Imaging()
                    Catch ex As Exception
                        MsgBox("Error while ending the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
            End Select
        End If
#End If
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

#If MOD_TERM = "SYMBOL" Then

    Private Sub oImaging_Image_Scanned(ByVal ImageStream As System.IO.MemoryStream) Handles oImaging.Image_Scanned
        Try
            pcbImagen.Image.Dispose()
            pcbImagen.Image = New System.Drawing.Bitmap(ImageStream)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'oPregunta.Respuesta = ImageStream.GetBuffer
    End Sub

    'Private Sub oImaging_Image_Scanned(ByVal Image As System.Drawing.Image) Handles oImaging.Image_Scanned
    '    Try
    '        'pcbImagen.Image.Dispose()
    '        pcbImagen.Image = Image
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    'oPregunta.Respuesta = ImageStream.GetBuffer
    'End Sub
#End If

End Class