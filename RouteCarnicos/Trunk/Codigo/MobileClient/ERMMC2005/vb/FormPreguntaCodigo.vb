Public Class FormPreguntaCodigo

    Inherits System.Windows.Forms.Form
    'Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu
    'Friend WithEvents MenuItemSalir As System.Windows.Forms.MenuItem

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
    Private oPregunta As cPreguntaCodigo
    Private bCargando As Boolean
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Private bLectorActivo As Boolean = False
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

    Private Sub FormPreguntaCodigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.Mapeo_Teclas(e)
    End Sub

    Private Sub FormPreguntaCodigo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPreguntaCodigo", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        'Application.DoEvents()
        MostrarPregunta()
        Me.KeyPreview = True
        'Me.HabilitarBotones(True)
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub FormPreguntaCodigo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                oPregunta.Respuesta = txtRespuesta.Text
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
                MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                e.Cancel = True
                HabilitarBotones(True)
            End If
        End Try
    End Sub

    Private Sub FormPreguntaCodigo_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ActivarInactivarLector(False)
    End Sub
#End Region

#Region "Metodos"
    Public Sub MostrarPregunta()
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height

        Me.txtRespuesta.Text = oPregunta.Respuesta
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        ActivarInactivarLector(True)
        Me.txtRespuesta.Focus()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    Private Sub ActivarInactivarLector(ByVal parbActivar As Boolean)
#If MOD_TERM <> "PALM" Then
        If parbActivar Then
            If Not bLectorActivo Then
                Select Case oApp.ModeloTerminal
                    Case "Generico"

                    Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                        Try
                            bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                            bLectorActivo = True
                        Catch ex As Exception
                            MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                        End Try
                    Case "HHP7600"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600, oPregunta.CodigoEquivalente)
                        bLectorActivo = True
                    Case "HHP7900"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900, oPregunta.CodigoEquivalente)
                        bLectorActivo = True
                    Case "HHPWM6"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                        bLectorActivo = True
                    Case "IntermecCN3"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                        bLectorActivo = True
                    Case "SymbolMC55"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                        bLectorActivo = True
                End Select
            End If
        Else
            Select Case oApp.ModeloTerminal
                Case "Generico"

                Case "SymbolC9090", "SymbolMC50", "SymbolMC70", "IntermecCN3", "SymbolMC55"
                    Try
                        bScanner.Terminate_Scanner()
                        bLectorActivo = False
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
                Case "HHP7600", "HHP7900", "HHPWM6"
                    bScanner.Terminate_Scanner()
                    bLectorActivo = False
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

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        Select Case oApp.ModeloTerminal
            Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                oPregunta.CodigoLeido = bScanner.TipoCodigoLeido
        End Select
        txtRespuesta.Text = Data
        If txtRespuesta.Text <> "" Then
            ButtonContinuar_Click(Me, Nothing)
        End If
    End Sub
#End If
#End Region

End Class