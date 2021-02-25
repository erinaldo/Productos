Imports System.Data.SqlServerCe

Public Class FormasEncuestas
    Implements ERM.Dia.Agenda.Visita.Encuestas

    Public oEnc As cEncuesta
    Dim aVisitadas As New ArrayList
    Dim nPregActual As Long = -1
    Dim oCliente As Cliente
    Dim sVisitaClave As String
    Dim bGrabada As Boolean

#If SO_WCE = 0 Then
    Private WithEvents oGPS As Microsoft.WindowsMobile.Samples.Location.Gps
#End If

    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property

    Public Function Encuestar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.Encuestas.Encuestar
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        Dim oFormEncuestasAplicadas As New FormEncuestasAplicadas(paroCliente, parsVisitaClave)
        oFormEncuestasAplicadas.ShowDialog()
        oFormEncuestasAplicadas.Dispose()
        oFormEncuestasAplicadas = Nothing
    End Function

    Public Function EjecutarEncuesta(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal pvCENClave As String, ByVal pvCENPuntos As Integer, ByVal pvCECPuntos As Integer, ByVal pvHabilitarSalir As Boolean, Optional ByVal pvEstadoIni As Integer = 0, Optional ByVal nueva As Boolean = False, Optional ByVal _ENCID As String = "") As Boolean
        bGrabada = False
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        'Me.Transaccion = oDBVen.oConexion.BeginTransaction()
        oEnc = New cEncuesta(pvCENClave, pvCENPuntos, pvCECPuntos, sVisitaClave, oCliente.ClienteClave, pvEstadoIni, pvHabilitarSalir, _ENCID, nueva)

        oEnc.EjecutarEncuesta()
        'oEnc.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        oEnc.Grabar(True)
        bGrabada = True
        'oEnc.EstadoFin = cEncuesta.EstadoFinalizar.Cancelada
        oEnc.Preguntas.PreguntaActual.OrdenAplicacion = 1
        Dim gps As Boolean = False
        If oVendedor.GPS Then
            For Each p As cPregunta In oEnc.Preguntas
                If p.TipoRespuesta = 8 Then
                    gps = True
                    Exit For
                End If
            Next
            If gps Then
#If SO_WCE = 0 Then
                oGPS = New Microsoft.WindowsMobile.Samples.Location.Gps()
#End If
            End If
        End If
        If gps Then
            ConectarGps()
        End If
        MostrarPregunta()
        If gps Then
            DesconectarGps()
        End If
        'Me.Transaccion.Commit()
        'Me.Transaccion.Dispose()
        'Me.Transaccion = Nothing
        If oDBVen.oConexion.State = ConnectionState.Open Then
            oDBVen.oConexion.Close()
        End If
        oEnc.Dispose()
        oEnc = Nothing
        Return bGrabada
    End Function

    Private Sub ConectarGps()
        Try
#If SO_WCE = 1 And MOD_TERM = "HHP" Then

#Else
            If Not oGPS.Opened Then
                oGPS.OpenSinH()
                oGPS.GetPosition(New TimeSpan(0, 1, 0))
            End If
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub DesconectarGps()
        Try
#If SO_WCE = 1 And MOD_TERM = "HHP" Then

#Else
            If oGPS.Opened Then
                Application.DoEvents()
                oGPS.Close()
            End If
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MostrarPregunta()
        Dim oForma As Form

        With oEnc.Preguntas
            'If oEnc.Preguntas.PreguntaActual.TipoRespuesta <> 7 Then
            If oEnc.Preguntas.aVisitadas.IndexOf(oEnc.Preguntas.nPreguntaActual) = -1 Then
                oEnc.Preguntas.aVisitadas.Add(oEnc.Preguntas.PreguntaActual.CEPNumero)
                oEnc.Preguntas.PreguntaActual.Visitada = True
            End If
            'End If
            'If aVisitadas.IndexOf(nPregActual) = -1 Then aVisitadas.Add(nPregActual)
            Select Case .PreguntaActual.TipoRespuesta
                Case 1 'Texto
                    oForma = New FormPreguntaTexto(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                Case 2 'Numero
                    oForma = New FormPreguntaNumero(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                Case 3 'Opcional
                    Select Case CType(.PreguntaActual, cPreguntaOpcional).TipoSeleccion
                        Case 1 'Seleccion
                            oForma = New FormPreguntaOpcionalSeleccion(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                        Case 2, 3 'Texto, Numero
                            oForma = New FormPreguntaOpcionalCaptura(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                    End Select
                Case 4 'Codigo
                    oForma = New FormPreguntaCodigo(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                Case 5 'Imagen
                    Select Case oApp.ModeloTerminal
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70", "SymbolMC35", "HHPWM6", "SymbolMC55"
                            oForma = New FormPreguntaImagen(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                        Case "HHP7600", "HHP7900"
                            oForma = New FormPreguntaImagenHHP(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                    End Select
                Case 6 'Matricial
                    oForma = New FormPreguntaMatricial(oCliente, sVisitaClave, oEnc, .PreguntaActual)
                Case 7 'Salto
                    oForma = Nothing
                    .PreguntaActual.ENCId = oEnc.ENCId
                    If .bIrAnterior Then
                        .AnteriorPregunta()
                    Else
                        .SiguientePregunta()
                    End If
                Case 8 'GPS
                    oForma = New FormPreguntaGPS(oCliente, sVisitaClave, oEnc, .PreguntaActual)
#If SO_WCE = 0 Then
                    DirectCast(oForma, FormPreguntaGPS).oGPS = oGPS
#End If

            End Select
        End With

        Try
            If Not oForma Is Nothing Then
                oForma.ShowDialog()
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                Application.DoEvents()
                oForma.Dispose()
                oForma = Nothing
            End If
        Catch ex As Exception
           
        End Try

        If Not oEnc.Preguntas.bFinEncuesta Then
            If oEnc.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                oEnc.Grabar()
                bGrabada = True
                Cursor.Current = System.Windows.Forms.Cursors.Default
            Else
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                MostrarPregunta()
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End If
        Else
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            oEnc.EstadoFin = cEncuesta.EstadoFinalizar.Aplicada
            oEnc.Grabar()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            bGrabada = True
        End If
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

End Class
