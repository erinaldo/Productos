#If SO_WCE = 1 And MOD_TERM = "HHP" Then
Imports GeoFramework
Imports GeoFramework.Gps
Imports GeoFramework.IO
#Else
Imports Microsoft.WindowsMobile.Samples.Location
#End If

Public Class FormPreguntaGPS
#Region "Buttons ShortCuts"
    Public Const BTN_CONTINUAR = 125
    Public Const BTN_BACK = 126       'SoftKey 2 (Tecla de un punto rojo)

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
    Private oEncuesta As cEncuesta
    Private oPregunta As cPreguntaGPS
    Private refaVista As Vista
    Private bCargando As Boolean
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
    'Private WithEvents oGPS As Nmea.NmeaInterpreter
#Else
    'Private updateDataHandler As EventHandler
    Private device As GpsDeviceState = Nothing
    Private position As GpsPosition = Nothing
    Public WithEvents oGPS As Microsoft.WindowsMobile.Samples.Location.Gps
#End If
#End Region

#Region "Funciones"
    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        ButtonContinuar.Enabled = bHabilitar
        MenuItemSalir.Enabled = bHabilitar And oEncuesta.HabilitarSalir
        MenuItemGPS.Enabled = bHabilitar
        If bHabilitar Then
            ButtonRegresar.Enabled = (bHabilitar And Not (oEncuesta.Preguntas.bPrimerPregunta))
        Else
            ButtonRegresar.Enabled = bHabilitar
        End If
        ButtonSalir.Enabled = bHabilitar
        'If Not oGPS Is Nothing Then
        '    MenuItemConectar.Enabled = False
        'Else
        '    MenuItemConectar.Enabled = False
        '    MenuItemConectar.Enabled = False
        'End If
    End Sub

    Public Sub MostrarPregunta()
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        'Mostrar respuesta
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
        'Dim oRadian As New GeoFramework.Radian(oPregunta.RespLatitud)
        'TextBoxLatitud.Text = oGPS.Position.Latitude.FromRadians(oRadian).ToString
        'oRadian = New GeoFramework.Radian(oPregunta.RespLongitud)
        'TextBoxLongitud.Text = oGPS.Position.Longitude.FromRadians(oRadian).ToString
        'Dim oDistance As New GeoFramework.Distance(oPregunta.RespAltitud, DistanceUnit.Meters)
        'TextBoxAltitud.Text = oDistance.ToString
        'TextBoxFechaHora.Text = oPregunta.RespHora.ToString("dd/MM/yyyy hh:mm:ss")
        'LabelSatelites.Text = refaVista.BuscarMensaje("MsgBox", "XSatelites") & oGPS.Satellites.FixedSatellites.Count & "/" & oGPS.Satellites.Count
#Else
        Dim x As New Microsoft.WindowsMobile.Samples.Location.DegreesMinutesSeconds(oPregunta.RespLatitud)
        TextBoxLatitud.Text = x.ToString
        x = New DegreesMinutesSeconds(oPregunta.RespLongitud)
        TextBoxLongitud.Text = x.ToString
        TextBoxAltitud.Text = oPregunta.RespAltitud
        TextBoxFechaHora.Text = oPregunta.RespHora.ToString("dd/MM/yyyy hh:mm:ss")
        'position = G
        'position = New GpsPosition
        'position.LatitudeInDegreesMinutesSeconds.ToString()
#End If
        'me.TextBoxAltitud = ogps.
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    '    Private Sub ConectarGps()
    '        Try
    '#If SO_WCE = 1 And MOD_TERM = "HHP" Then
    '            TimerGPS.Enabled = True
    '            'If oGPS.State = ExecutionState.Stopped Then
    '            '    oGPS.Reset()
    '            '    oGPS.BaseStream = New GpsStream()
    '            '    oGPS.Restart()
    '            '    MenuItemConectar.Enabled = False
    '            '    MenuItemDesconectar.Enabled = True
    '            'End If
    '#Else
    '            If Not oGPS.Opened Then
    '                oGPS.OpenSinH()
    '                position = oGPS.GetPosition()
    '                UpdateData(Nothing, EventArgs.Empty)
    '                TimerGPS.Enabled = True
    '                MenuItemConectar.Enabled = False
    '                MenuItemDesconectar.Enabled = True
    '                LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XConectado")
    '            End If
    '#End If
    '        Catch ex As Exception
    '#If SO_WCE = 1 And MOD_TERM = "HHP" Then
    '            TimerGPS.Enabled = False
    '#End If
    '            MsgBox(ex.Message)
    '            Cursor.Current = Cursors.Default
    '        End Try
    '        TimerBloquear.Enabled = True
    '    End Sub

    '    Private Sub DesconectarGps()
    '        Try
    '#If SO_WCE = 1 And MOD_TERM = "HHP" Then
    '            TimerGPS.Enabled = False
    '            'If oGPS.State <> ExecutionState.Stopped Then
    '            '    oGPS.Stop()
    '            '    oGPS.Reset()
    '            '    MenuItemConectar.Enabled = True
    '            '    MenuItemDesconectar.Enabled = False
    '            'End If
    '#Else
    '            'Dim x As GpsDeviceState = oGPS.GetDeviceState
    '            TimerGPS.Enabled = False
    '            If oGPS.Opened Then
    '                oGPS.Close()
    '                MenuItemConectar.Enabled = True
    '                MenuItemDesconectar.Enabled = False
    '                LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XDesconectado")
    '            End If
    '#End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

#End Region

#Region "Eventos Forma"
    Private Sub FormPreguntaGPS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Mapeo_Teclas(e)
    End Sub

    Private Sub FormPreguntaGPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Application.DoEvents()

            LabelSatelites.Text = ""
            LabelStatus.Text = ""
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
            'oGPS = New Nmea.NmeaInterpreter
            'oGPS.ReadTimeout = System.TimeSpan.Parse("00:00:05")
            'oGPS.WriteTimeout = System.TimeSpan.Parse("00:00:05")
#Else
            If oGPS Is Nothing Then
                oGPS = New Gps
            End If
#End If
            TimerGPS.Interval = 1000 ' oApp.TimeOutGPS * 1000
            TimerBloquear.Interval = oApp.TimeOutGPS * 1000

            [Global].ObtenerFactores(Me)
            [Global].EscalarFuente(Me)
            [Global].EscalarForma(Me)
            ' Recuperar los demás componentes de la forma
            If Not Vista.Buscar("FormPreguntaGPS", refaVista) Then
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
            refaVista.ColocarEtiquetasForma(Me)
            'Application.DoEvents()
            MostrarPregunta()
            'Me.KeyPreview = True
            Me.HabilitarBotones(False)
            If oPregunta.ENCId = "" And oPregunta.ENPId = "" Then
                Me.HabilitarBotones(False)
#If SO_WCE = 0 Then
                position = oGPS.GetPosition(New TimeSpan(0, 1, 0))
                UpdateData(Nothing, EventArgs.Empty)
                TimerGPS.Enabled = True
#End If

                Me.TimerBloquear.Enabled = True
            Else
                Me.HabilitarBotones(True)
                MenuItemConectar.Enabled = True
                MenuItemDesconectar.Enabled = False
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End If
            'ConectarGps()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormPreguntaGPS_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            'DesconectarGps()
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                'AsignarRespuestas
                oPregunta.ValidarRespuesta()
                If oPregunta.Confirmacion Then
                    bCont = (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0049"), MsgBoxStyle.YesNo, refaVista.BuscarMensaje("MsgBox", "XMensajeP")) = MsgBoxResult.Yes)
                End If
                If bCont Then
                    TimerGPS.Enabled = False
                    oEncuesta.Preguntas.PreguntaActual.Insertar(oEncuesta.ENCId, oEncuesta.Preguntas.nOrdenActual, 1)
                    oEncuesta.Preguntas.SiguientePregunta()
                Else
                    Cursor.Current = Cursors.Default
                    e.Cancel = True
                    HabilitarBotones(True)
                    'ConectarGps()
                End If
            ElseIf Me.DialogResult = Windows.Forms.DialogResult.No Or Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
                TimerGPS.Enabled = False
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
#End Region

#Region "Eventos"
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        TimerGPS.Enabled = False
        HabilitarBotones(False)
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        TimerGPS.Enabled = False
        HabilitarBotones(False)
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click, MenuItemSalir.Click
        TimerGPS.Enabled = False
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub DetailViewPregunta_ItemValidating(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ValidatingEventArgs) Handles DetailViewPregunta.ItemValidating
        If Not bCargando Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "GPS"
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
    'Sub oGPS_Disconnected(ByVal sender As Object, ByVal e As EventArgs) Handles oGPS.Disconnected
    '    LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XDesconectado")
    '    Cursor.Current = Cursors.Default
    'End Sub

    'Sub oGPS_Disconnecting(ByVal sender As Object, ByVal e As EventArgs) Handles oGPS.Disconnecting
    '    LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XDesconectando")
    '    Cursor.Current = Cursors.WaitCursor
    'End Sub

    'Sub oGPS_Connected(ByVal sender As Object, ByVal e As EventArgs) Handles oGPS.Connected
    '    TimerGPS.Enabled = False
    '    LabelSatelites.Text = refaVista.BuscarMensaje("MsgBox", "XSatelites") & oGPS.Satellites.FixedSatellites.Count & "/" & oGPS.Satellites.Count
    '    LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XConectado")
    '    Cursor.Current = Cursors.Default
    'End Sub

    'Sub oGPS_Connecting(ByVal sender As Object, ByVal e As CancelableEventArgs) Handles oGPS.Connecting
    '    Cursor.Current = Cursors.WaitCursor
    '    LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XConectando")
    'End Sub

    'Sub oGPS_TimeoutOccurred(ByVal sender As Object, ByVal e As ExceptionEventArgs) Handles oGPS.TimeoutOccurred
    '    LabelStatus.Text = "The device stopped.  Restarting..."
    'End Sub

    'Private Sub oGPS_PositionChanged(ByVal sender As Object, ByVal e As GeoFramework.PositionEventArgs) Handles oGPS.PositionChanged
    '    ' Update the latitude and longitude
    '    Try

    '        oPregunta.RespLatitud = e.Position.Latitude.ToRadians
    '        oPregunta.RespLongitud = e.Position.Longitude.ToRadians
    '        TextBoxLatitud.Text = e.Position.Latitude.ToString()
    '        TextBoxLongitud.Text = e.Position.Longitude.ToString()
    '        LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XPosicionCambio")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub oGPS_AltitudeChanged(ByVal sender As Object, ByVal e As GeoFramework.DistanceEventArgs) Handles oGPS.AltitudeChanged
    '    ' Update the current altitude
    '    Try
    '        oPregunta.RespAltitud = e.Distance.ToMeters
    '        TextBoxAltitud.Text = e.Distance.ToMeters.ToString()
    '        LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XAltitudCambio")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub oGPS_UtcDateTimeChanged(ByVal sender As Object, ByVal e As GeoFramework.DateTimeEventArgs) Handles oGPS.UtcDateTimeChanged
    '    ' Update the current satellite-derived time
    '    oPregunta.RespFecha = e.DateTime.Date
    '    oPregunta.RespHora = e.DateTime
    '    TextBoxFechaHora.Text = e.DateTime.ToString("dd/MM/yyyy hh:mm:ss")
    'End Sub

    'Sub oGPS_DeviceResumed(ByVal sender As Object, ByVal e As EventArgs) Handles oGPS.DeviceResumed
    '    Cursor.Current = Cursors.Default
    '    LabelStatus.Text = "Device is no longer suspended!  Restarting..."
    'End Sub

    'Sub oGPS_DeviceSuspended(ByVal sender As Object, ByVal e As EventArgs) Handles oGPS.DeviceSuspended
    '    LabelStatus.Text = "Device was powered off!"
    '    Cursor.Current = Cursors.WaitCursor
    'End Sub
    'Private Sub oGPS_SatelliteFixObtained(ByVal sender As Object, ByVal e As GeoFramework.Gps.SatelliteEventArgs) Handles oGPS.SatelliteFixObtained
    '    LabelSatelites.Text = refaVista.BuscarMensaje("MsgBox", "XSatelites") & oGPS.Satellites.FixedSatellites.Count & "/" & oGPS.Satellites.Count
    'End Sub

    'Private Sub oGPS_SatelliteFixLost(ByVal sender As Object, ByVal e As GeoFramework.Gps.SatelliteEventArgs) Handles oGPS.SatelliteFixLost
    '    LabelSatelites.Text = refaVista.BuscarMensaje("MsgBox", "XSatelites") & oGPS.Satellites.FixedSatellites.Count & "/" & oGPS.Satellites.Count
    'End Sub
#Else
    Private Sub UpdateData(ByVal sender As Object, ByVal args As System.EventArgs)
        If (oGPS.Opened) Then
            'Dim status As String = ""
            Dim datastr As String = ""
            'If (Not IsNothing(Device)) Then
            '    'status = device.FriendlyName & " " & device.ServiceState & ", " & device.DeviceState
            'End If
            If (Not IsNothing(position)) Then
                If (position.TimeValid) Then
                    oPregunta.RespFecha = position.Time.Date
                    oPregunta.RespHora = position.Time
                    datastr = position.Time.ToString("dd/MM/yyyy hh:mm:ss")
                    TextBoxFechaHora.Text = datastr
                End If
                If (position.SatellitesInSolutionValid And position.SatellitesInViewValid And position.SatelliteCountValid) Then
                    Dim sat As Integer = position.GetSatellitesInSolution().Length
                    datastr = refaVista.BuscarMensaje("MsgBox", "XSatelites") & sat & "/" & position.GetSatellitesInView().Length & " (" & position.SatelliteCount & ")"
                    LabelSatelites.Text = datastr
                    If sat >= 3 Then
                        Try
                            If (position.LatitudeValid) Then
                                'datastr = "(DD):  " & position.Latitude & vbCrLf
                                oPregunta.RespLatitud = position.Latitude
                                datastr = position.LatitudeInDegreesMinutesSeconds.ToString
                                TextBoxLatitud.Text = datastr
                            End If
                        Catch ex As Exception

                        End Try


                        Try
                            If (position.LongitudeValid) Then
                                'datastr = "(DD):  " & position.Longitude & vbCrLf
                                oPregunta.RespLongitud = position.Longitude
                                datastr = position.LongitudeInDegreesMinutesSeconds.ToString
                                TextBoxLongitud.Text = datastr
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            If position.SeaLevelAltitudeValid Then
                                oPregunta.RespAltitud = position.SeaLevelAltitude
                                datastr = position.SeaLevelAltitude
                                TextBoxAltitud.Text = datastr
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If TimerBloquear.Interval = oApp.TimeOutGPS * 1000 Then
                                TimerBloquear.Enabled = False
                                Application.DoEvents()
                                TimerBloquear.Interval = 10000
                                TimerBloquear.Enabled = True
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If


            'LabelStatus.Text = status
        End If
    End Sub

    'Private Sub oGPS_DeviceStateChanged(ByVal sender As Object, ByVal args As Microsoft.WindowsMobile.Samples.Location.DeviceStateChangedEventArgs)
    '    device = args.DeviceState

    '    ' call the UpdateData method via the updateDataHandler so that we
    '    ' update the UI on the UI thread
    '    Invoke(updateDataHandler)
    'End Sub

    'Private Sub oGPS_LocationChanged(ByVal sender As Object, ByVal args As Microsoft.WindowsMobile.Samples.Location.LocationChangedEventArgs) Handles oGPS.LocationChanged
    '    position = args.Position

    '    ' call the UpdateData method via the updateDataHandler so that we
    '    ' update the UI on the UI thread
    '    Invoke(updateDataHandler)
    'End Sub
#End If
#End Region

    Private Sub MenuItemConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemConectar.Click
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        TimerGPS.Enabled = True
        HabilitarBotones(False)
        TimerBloquear.Interval = oApp.TimeOutGPS * 1000
        TimerBloquear.Enabled = True
        'ConectarGps()
    End Sub

    Private Sub MenuItemDesconectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDesconectar.Click
        TimerGPS.Enabled = False
    End Sub

    Private Sub TimerGPS_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerGPS.Tick
        'If oGPS.State <> ExecutionState.Stopped Then
        TimerGPS.Enabled = False
#If SO_WCE = 0 Then
        If oGPS.Opened Then
            Application.DoEvents()
            position = oGPS.GetPosition(New TimeSpan(0, 1, 0))
            UpdateData(Nothing, EventArgs.Empty)
            TimerGPS.Enabled = True
        End If
#End If
        'End If
    End Sub
    Private Sub TimerBloquear_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerBloquear.Tick
        HabilitarBotones(True)
        TimerBloquear.Enabled = False
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

End Class