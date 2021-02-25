#If SO_WCE = 1 And MOD_TERM = "HHP" Then
Imports GeoFramework
Imports GeoFramework.Gps
Imports GeoFramework.IO
#Else
Imports Microsoft.WindowsMobile.Samples.Location
#End If

Public Class FormPuntoGPS

    Public Event AlmacenarLecturaGPS()

#Region "Variables"
    Private refaVista As Vista
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
    'Private WithEvents oGPS As Nmea.NmeaInterpreter
#Else
    Private updateDataHandler As EventHandler
    Private device As GpsDeviceState = Nothing
    Private position As GpsPosition = Nothing
    Public WithEvents oGPS As Microsoft.WindowsMobile.Samples.Location.Gps
#End If
    Private bGPSLeido As Boolean = False
    Private bLatitudLeido As Boolean = False
    Private bLongitudLeido As Boolean = False
    Private bDesconectando As Boolean = False
    Private nLatitudGPS As Double
    Private nLongitudGPS As Double
    Private nContador As Integer
    Private oRutaActual As Ruta
#End Region

    Public Property RutaActual() As Ruta
        Get
            Return oRutaActual
        End Get
        Set(ByVal Value As Ruta)
            oRutaActual = Value
        End Set
    End Property

#Region "Funciones"

    Private Sub Terminar()
        'System.Threading.Thread.Sleep(2000)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub AlmacenaLectura()
        Try
            Dim sComando As String = ""
            Dim sPuntoGPSId As String = ""
            If bGPSLeido Then
                'System.Threading.Thread.Sleep(2000)
                sPuntoGPSId = oApp.KEYGEN(1)
                sComando = String.Format("insert into PuntoGPS (PuntoGPSId, CoordenadaX, CoordenadaY, RUTClave, DiaClave, MFechaHora, MUsuarioId, Enviado) values('{0}',{1},{2},'{3}','{4}',{5},'{6}',{7})", sPuntoGPSId, nLongitudGPS, nLatitudGPS, oRutaActual.RUTClave, oDia.DiaActual, UniFechaSQL(Now), oVendedor.UsuarioId, 0)
                oDBVen.EjecutarComandoSQL(sComando)
                Terminar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub ObtenerDatosGPS()
        'Falta agregar validacion de Vendedor.GPS

        'Cursor.Current = Cursors.WaitCursor 
        bLatitudLeido = False
        bLongitudLeido = False

        'FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XPuntoGPS"))
        'FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "XConectando"), refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS"))

        LabelStatus.Text = refaVista.BuscarMensaje("MsgBox", "XConectando")
        TimerGPS.Enabled = True
        nContador = 0
#If SO_WCE = 0 Then
        updateDataHandler = New EventHandler(AddressOf UpdateData)
#End If
        '#If SO_WCE = 0 Then
        '        If oGPS Is Nothing Then
        '            oGPS = New Gps
        '            updateDataHandler = New EventHandler(AddressOf UpdateData)
        '        End If
        '#End If
        '        ConectarGps()
    End Sub

#If SO_WCE = 0 Then
    Private Sub UpdateData(ByVal sender As Object, ByVal args As System.EventArgs)
        If bDesconectando Then Exit Sub
        If (oGPS.Opened) Then
            Dim status As String = ""
            Dim datastr As String = ""
            If (Not IsNothing(device)) Then
                'status = device.FriendlyName & " " & device.ServiceState & ", " & device.DeviceState
            End If

            If (Not IsNothing(position)) Then
                If (position.TimeValid) Then
                    datastr = position.Time.ToString("dd/MM/yyyy hh:mm:ss")
                    LabelFechaHora.Text = datastr
                End If

                If (position.SatellitesInSolutionValid And position.SatellitesInViewValid And position.SatelliteCountValid) Then
                    Dim sats As Integer = position.GetSatellitesInSolution().Length
                    datastr = refaVista.BuscarMensaje("MsgBox", "XSatelites") & sats.ToString() & "/" & position.GetSatellitesInView().Length & " (" & position.SatelliteCount & ")" & vbCrLf
                    LabelSatelites.Text = datastr
                    If sats >= 3 Then

                        If (position.LatitudeValid) Then
                            'datastr = "(DD):  " & position.Latitude & vbCrLf
                            bLatitudLeido = True
                            nLatitudGPS = position.Latitude
                            datastr = position.LatitudeInDegreesMinutesSeconds.ToString
                            TextBoxLatitud.Text = datastr
                        End If

                        If (position.LongitudeValid) Then
                            'datastr = "(DD):  " & position.Longitude & vbCrLf
                            bLongitudLeido = True
                            nLongitudGPS = position.Longitude
                            datastr = position.LongitudeInDegreesMinutesSeconds.ToString
                            TextBoxLongitud.Text = datastr
                        End If

                        'FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XPuntoGPS"))
                        'FormProcesando.PubSubInformar(datastr, refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS"))

                        bGPSLeido = bLatitudLeido And bLongitudLeido

                        If (bGPSLeido) Then
                            If PosDif(nLatitudGPS, nLongitudGPS) Or (nContador > 30) Then
                                nContador = 0
                                TimerGPS.Enabled = False
                                RaiseEvent AlmacenarLecturaGPS()
                            Else
                                nContador += 1
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Function PosDif(ByVal pardLatitud As Double, ByVal pardLongitud As Double) As Boolean
        Dim bRes As Boolean = False
        Try
            bRes = IIf(oDBVen.EjecutarCmdScalarIntSQL("SELECT COUNT(*) FROM PuntoGPS WHERE CoordenadaX=" + pardLongitud + " AND CoordenadaY = " + pardLatitud.ToString()) = 0, True, False)
        Catch ex As Exception

        End Try
        Return bRes
    End Function
#End If

#If SO_WCE = 0 Then
    Private Sub oGPS_LocationChanged(ByVal sender As Object, ByVal args As Microsoft.WindowsMobile.Samples.Location.LocationChangedEventArgs)
        If bDesconectando Then Exit Sub
        position = args.Position

        ' call the UpdateData method via the updateDataHandler so that we
        ' update the UI on the UI thread
        Invoke(updateDataHandler)
    End Sub
#End If

    Private Sub TimerGPS_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerGPS.Tick
        TimerGPS.Enabled = False
        If Not bGPSLeido Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0206"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, refaVista.BuscarMensaje("MsgBox", "XPuntoGPS")) = MsgBoxResult.Yes Then
                ObtenerDatosGPS()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.No
            End If
        End If
    End Sub
#End Region

    Private Sub FormPuntoGPS_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        RemoveHandler AlmacenarLecturaGPS, AddressOf AlmacenaLectura
#If SO_WCE = 0 Then
        If Not oGPS Is Nothing Then
            RemoveHandler oGPS.LocationChanged, AddressOf oGPS_LocationChanged
            oGPS = Nothing
        End If
#End If
    End Sub

    Private Sub FormPuntoGPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        LabelFechaHora.Text = ""
        LabelSatelites.Text = ""
        LabelStatus.Text = ""
        TimerGPS.Interval = oApp.TimeOutGPS * 1000

        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        If Not Vista.Buscar("FormPuntoGPS", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.Close()
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.Panel2.Width = Me.Panel3.Width
        AddHandler AlmacenarLecturaGPS, AddressOf AlmacenaLectura
        Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.LabelEstado.Text = refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS")
        Application.DoEvents()
        ObtenerDatosGPS()
#If SO_WCE = 0 Then
        If oGPS Is Nothing Then
            oGPS = New Gps
        End If

        AddHandler oGPS.LocationChanged, AddressOf oGPS_LocationChanged
#End If
    End Sub
End Class