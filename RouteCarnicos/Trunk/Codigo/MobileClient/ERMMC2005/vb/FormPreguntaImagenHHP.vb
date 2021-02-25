Imports System.Runtime.InteropServices

Public Class FormPreguntaImagenHHP
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
    Private bCapturada As Boolean
    'Private iptImagen As IntPtr = IntPtr.Zero
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


    Private Sub FormPreguntaImagen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 42 Then 'HHP.DataCollection.WinCE.Decoding.TriggerKeyEnum.TK_ONSCAN 
            '#If SO_WCE = 0 And MOD_TERM = "HHP" Then
#If MOD_TERM = "HHP" Then
            If HHPImager.EnableCapture Then
                bCapturada = True
                HHPImager.EnableCapture = False
            Else
                If Not HHPImager.Connected Then
                    HHPImager.Connect()
                End If
                pcbImagen.Visible = False
                HHPImager.Visible = True
                HHPImager.EnableCapture = True
            End If
#End If
        End If
    End Sub

    Private Sub FormPreguntaCodigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.Mapeo_Teclas(e)
    End Sub

    Private Sub FormPreguntaCodigo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Application.DoEvents()
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
            'HHPImager.SizeMode = HHP.DataCollection.Imaging.SizeModeEnum.StretchImage
            If Not System.IO.Directory.Exists(ImagenEncuesta) Then
                System.IO.Directory.CreateDirectory(ImagenEncuesta)
            End If
            MostrarPregunta()
            Me.KeyPreview = True
            'HabilitarBotones(True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

#If MOD_TERM = "HHP" Then
    Private Sub FormPreguntaCodigo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                If oPregunta.Confirmacion Then
                    bCont = (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0049"), MsgBoxStyle.YesNo, refaVista.BuscarMensaje("MsgBox", "XMensajeP")) = MsgBoxResult.Yes)
                End If
                If bCont Then
                    If bCapturada Then

#If SO_WCE = 0 Then
                        oPregunta.Respuesta = Guid.NewGuid.ToString("N")
                        HHPImager.ResizeImage(35)
                        HHPImager.SaveFile(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg", HHP.DataCollection.Imaging.SaveFormat.SF_JPG, oPregunta.Calidad)                        
#Else
                        oPregunta.Respuesta = Guid.NewGuid.ToString("N")
                        HHPImager.SaveFile(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg", HHP.DataCollection.Imaging.SaveFormat.SF_JPG, oPregunta.Calidad)
#End If
                    End If
                    oEncuesta.Preguntas.PreguntaActual.Insertar(oEncuesta.ENCId, oEncuesta.Preguntas.nOrdenActual, 1)
                    oEncuesta.Preguntas.SiguientePregunta()
                    oPregunta.Respuesta = Nothing
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
#End If

    Private Sub FormPreguntaCodigo_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ActivarInactivarImager(False)
    End Sub
#End Region

#Region "Metodos"
    Public Sub MostrarPregunta()
        '#If SO_WCE = 0 And MOD_TERM = "HHP" Then
#If MOD_TERM = "HHP" Then
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height

        oPregunta.RecuperarRespuesta()
        If Not oPregunta.Respuesta Is Nothing AndAlso System.IO.File.Exists(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg") Then
            pcbImagen.Visible = True
            HHPImager.Visible = False
            pcbImagen.Image = New System.Drawing.Bitmap(ImagenEncuesta & "\" & oPregunta.Respuesta & ".jpg")
        Else
            pcbImagen.Visible = False
            HHPImager.Visible = True
            ActivarInactivarImager(True)
        End If
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
#End If
    End Sub

    Private Sub ActivarInactivarImager(ByVal parbActivar As Boolean, Optional ByVal parbIniciar As Boolean = True)
        '#If SO_WCE = 0 And MOD_TERM = "HHP" Then
#If MOD_TERM = "HHP" Then
        If parbActivar Then
            If (Not HHPImager.Connected) Then
                HHPImager.Connect()
            End If
        End If
        HHPImager.EnableCapture = parbActivar
        If Not parbActivar Then
            Me.Panel1.Controls.Remove([Global].HHPImager)
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

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ButtonContinuar_Click(Me, Nothing)
    End Sub

    Private Sub ButtonSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub MenuItemOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ButtonRegresar_Click(Me, Nothing)
    End Sub

#End Region

End Class
