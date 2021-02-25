
Imports FieldSoftware.PrinterCE_NetCF
Module ModuleMain

    Public FormProcesando As ClassProceso
    Public oFormCargando As ClassCargando
    Public bMostrarLista As Boolean = False
    Public _ReIniciarRoute As Boolean = False
    Public _BorrarArchivo As String = ""
    Public WithEvents msgWin As HANDHELD.CHOTKey
    Private fse As FSEngine

    Public Sub Main()
        'Esto se agrego para que no diera error en la 7900
        Dim AsciiCE As AsciiCE
        AsciiCE = New AsciiCE("139H9P113M")
        AsciiCE = Nothing

        'Para que el resco control se pueda navegar con las teclas de up/down
        Resco.Controls.DetailView.DetailView.KeyNavigation = True

        'Iniciar el fullscreen
        '--Declarar el objeto para abrir el fullscreen
        fse = New FSEngine
        '--Inicializar el objeto
        fse.InitFullScreen()

        If fse.DoFullScreen(True) = 0 Then
        End If


        Dim AppPath As String = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        AppPath &= "\Imagenes"
        Dim sImagen As String = String.Empty
        Dim sFileName As String = String.Empty
        Dim lista1() As String

        If Not System.IO.Directory.Exists(AppPath) Then
            MsgBox("[E0624] No existe el directorio $0$ donde se almacenan las imágenes ".Replace("$0$", AppPath), MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not System.IO.File.Exists(AppPath & "\MG0.gif") Then
            MsgBox("El archivo $0$ que contiene la imagen default, no ha sido encontrado".Replace("$0$", "MG0.gif"), MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Imagenes
        lista1 = System.IO.Directory.GetFileSystemEntries(AppPath)
        htImagenes = New Hashtable
        For Each sImagen In lista1
            sFileName = sImagen.Replace(AppPath & "\", "")
            If sFileName.Length > 6 Then
                htImagenes.Add(sFileName.Substring(0, sFileName.Length - 4), New System.Drawing.Bitmap(sImagen))
            End If
        Next

        ' Crear la instancia de la forma que muestra el avance del proceso y los rótulos
        FormProcesando = New ClassProceso
        oFormCargando = New ClassCargando

        ' Crear el objeto principal
        oApp = New Config
        ' Recuperar la configuración local
        If oApp.RecuperarConfiguracion() Then

            If oApp.CalendarioMovil Then
                ActualizarFechaTerminal()
            Else
                oFormCargando.Informar(1, "GR", "Amesol ROUTE")
            End If

            Dim ERM As New AplicacionERM
            ' Entrar al sistema
            Do
                _ReIniciarRoute = False
                If ERM.Iniciar() Then

                    g_SO = ObtenerSistemaOperativo(System.Environment.OSVersion.Version.Major, System.Environment.OSVersion.Version.Minor)

                    'oRouteLogging = New AMESOLLogging.AMESOLLog()
                    If oApp.ModeloTerminal <> "SymbolMC35" Then
                        msgWin = New HANDHELD.CHOTKey

                    End If


                    Select Case oApp.ModeloTerminal
                        Case "Generico", "SymbolMC50", "HHP7600", "SymbolMC70", "HHP7900", "SymbolMC55"
                            msgWin.SetUpKeyBoard(HANDHELD.SO.PocketPC)
                        Case "SymbolC9090"
                            msgWin.SetUpKeyBoard(HANDHELD.SO.SymbolWMobile5_MC9090)
                        Case "SymbolMC35"
                            Process.Start("\Program Files\CamWedge\CamWedge.exe", "/ENABLE")
                            Dim regKey As Microsoft.Win32.RegistryKey '= Microsoft.Win32.Registry.CurrentUser
                            'regKey.GetValue("\Software\Symbol\BarCodeDecoder\Profiler")
                            regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Symbol\CamWedge\Barcode")
                            If (Not IsNothing(regKey)) Then
                                regKey.SetValue("AutoEnter", 1)
                            End If
                            regKey.Close()
                            regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Symbol\BarCodeDecoder\")
                            If (Not IsNothing(regKey)) Then
                                regKey.SetValue("Profile", "All 1D/2D")
                            End If
                            regKey.Close()
                            regKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\Microsoft\Shell\Keys\40C3")
                            If (Not IsNothing(regKey)) Then
                                regKey.SetValue("Flags", 9)
                            End If
                            regKey.Close()
                            'regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Shell\Keys\40C6", True)
                            'If (Not IsNothing(regKey)) Then
                            '    regKey.SetValue("Flags", 9)
                            'End If
                            'regKey.Close()

                            'msgWin.SetUpKeyBoard(HANDHELD.SO.PocketPC)
                            Dim phone As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
                            phone.PhoneSwitchOff()
                            phone.BlueToothEstado(PhoneRadio.RadioMode.Off)
                            phone.Dispose()
                        Case "IntermecCN3"
#If MOD_TERM <> "PALM" Then
                            Dim cScanner As New HANDHELD.CScanner()
                            cScanner.Terminal = HANDHELD.SO.IntermecCN3
                            cScanner.ApagarLector()
                            cScanner.Dispose()
                            cScanner = Nothing
#End If
                            msgWin.SetUpKeyBoard(HANDHELD.SO.PocketPC)
                    End Select

                    '--Verificar la fecha hora correcta en la terminal
                    'ActualizarFechaTerminal()

                    '--Verificar si existen una nueva version para la applicacion de la terminal
                    '--JPacheco 
                    If (Not oApp.ProbarServicioR(3)) Then
                        oApp.ActivarWiFi()
                        oApp.conectarRAS()
                    End If
                    If Not Revisar_Version() Then
                        oApp.DesactivarWiFi()
                        ' Ciclo principal de ERM
                        If ERM.AbrirDB Then
                            ERM.CicloPrincipal()
                            ERM.CerrarDB()
                        End If

                    End If
                    Try
                        If ((_ReIniciarRoute) And (_BorrarArchivo <> "")) Then
                            System.IO.File.Delete(_BorrarArchivo & ".sdf")
                            System.IO.File.Delete(_BorrarArchivo & ".xml")
                            _BorrarArchivo = ""
                        End If
                    Catch ex As Exception
                        MsgBox(ex.GetBaseException.GetType.ToString & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Exclamation, "Main")
                    End Try
                End If

            Loop While _ReIniciarRoute

        End If
        '--Se termina la applicacion volver al estado original
        '--Quitar el fullscreen
        '--JPacheco 16-Nov-06
        If fse.DoFullScreen(False) = 0 Then
        End If

        If oApp.ModeloTerminal <> "SymbolMC35" And Not IsNothing(msgWin) Then
            If Not msgWin Is Nothing Then
                msgWin.DesRegistrar()
                msgWin = Nothing
            End If
        End If
    End Sub

    Private Sub msgWin_HotKeyPressed() Handles msgWin.HotKeyPressed
        'Memoria.ShowMemory()
        If Not vListaPreciosCargada Then
            MostrarLista()
             'tbMemo.Text+="Hibernate sent!"+res.ToString()+"\r\n"; 
            'Dim sAppPath As String = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
            'EjecutarApp(String.Format("{0}\Hibernate.exe", sAppPath))
        End If
    End Sub

    Public Sub MostrarLista()
        '--Bandera para deshabilitar la lista de precios hasta que entre al dia
        If Not bMostrarLista Then Exit Sub

        Dim oFormListasPrecios As FormListasPrecios

        If CTEActual <> String.Empty Then
            oFormListasPrecios = New FormListasPrecios(CTEActual)
        Else
            oFormListasPrecios = New FormListasPrecios
        End If

        oFormListasPrecios.ShowDialog()
        oFormListasPrecios.fgDetalles.Dispose()
        oFormListasPrecios.ListViewListas.Dispose()
        oFormListasPrecios.Dispose()
        oFormListasPrecios = Nothing
    End Sub

    Public Function Revisar_Version() As Boolean
        '--Verificar si existen una nueva version para la applicacion de la terminal
        '--Jpacheco 06-Feb-07
        Try
            Dim oVersion As String = String.Empty
            Dim oDevice As New CDevice
            Dim timeou As Integer = oServicioWeb.Timeout
            oServicioWeb.Timeout = 5000
            oVersion = oServicioWeb.WSUltimaVersionTerminal()
            oServicioWeb.Timeout = timeou

            If Not oVersion = PubsVersion And Not oVersion Is Nothing Then

                'TODO: Revisar que ya se hayan bajado todos los registros
                'y marcar el error

                If HayDatoSinDescargar() Then

                    MsgBox(String.Format("Se encontro una nueva actualización ver: {0} sin embargo se encontro que no se han descargado los datos de la terminal, es necesario descargar para actualizar a la nueva versión", oVersion), MsgBoxStyle.Exclamation)

                Else

                    If MsgBox(String.Format("Se encontro una nueva actualización ver: {0}, desea actualizar la versión actual {1}", oVersion, PubsVersion), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Application.DoEvents()
                        'Informar del procedo                    

                        FormProcesando.PubSubTitulo("Descargando Actualización ROUTE")
                        FormProcesando.PubSubInformar("Descargando...", "Espere..")
                        Application.DoEvents()

                        '--Descargar la version correcta del CAB
                        Dim byteArchivo As Byte()

                        byteArchivo = oServicioWeb.WSObtenerUltimoCAB(System.Environment.OSVersion.Version.Major, System.Environment.OSVersion.Version.Minor)

                        If byteArchivo Is Nothing Then
                            MsgBox("Error al descargar el archivo", MsgBoxStyle.Critical)
                            Exit Function
                        End If

                        If System.IO.File.Exists("\AmesolRoute.CAB") Then
                            System.IO.File.Delete("\AmesolRoute.CAB")
                        End If

                        Dim fsBD As IO.FileStream
                        fsBD = New IO.FileStream("\AmesolRoute.CAB", IO.FileMode.CreateNew, IO.FileAccess.Write)
                        fsBD.Write(byteArchivo, 0, byteArchivo.Length)
                        fsBD.Close()

                        'TODO:Cerrar el route y cargar la aplicacion para correr el CAB                    
                        Dim AppPath As String = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
                        EjecutarApp(String.Format("{0}\RouteUpdater.exe", AppPath))
                        Return True

                    End If


                End If



            End If

        Catch ex As Exception
            FormProcesando.PubSubTitulo("Welcome to Amesol Route")
            FormProcesando.PubSubInformar("Starting...", "Loading program")
            '--No se tiene conexion no es necesario validar la version....
            Return False
        End Try
        FormProcesando.PubSubTitulo("Welcome to Amesol Route")
        FormProcesando.PubSubInformar("Starting...", "Loading program")

        Return False

    End Function

    Public Function ValidarKilometraje() As Boolean
        If oVendedor.Kilometraje Then
            Dim sConsulta As String
            Dim nCapturados As Integer
            Dim nTerminados As Integer
            sConsulta = "select count(CAMVENId) from CamionVendedor where Enviado = 0"
            nCapturados = oDBVen.EjecutarCmdScalarIntSQL(sConsulta)
            sConsulta = "select count(CAMVENId) from CamionVendedor where KmFinal is not null and Enviado = 0"
            nTerminados = oDBVen.EjecutarCmdScalarIntSQL(sConsulta)
            If (nCapturados > nTerminados) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Class AplicacionERM
        Implements ERM.Aplicacion

        Private Sub cargarCtrlMenuSeguimiento()
            If oVendedor.motconfiguracion.Secuencia = False Then Exit Sub
            ctrlSeguimiento = New CtrlMenuSeguimiento
            ctrlSeguimiento.MOTConfiguracion = oVendedor.motconfiguracion.Clone
            ctrlSeguimiento.CargarImagenes("MM")
            ctrlSeguimiento.Name = "CtrlMenuSeguimiento1"

        End Sub

        Public Function CicloPrincipal() As Boolean Implements ERM.Aplicacion.CicloPrincipal
            ' Objeto Vendedor
            ' Ciclo principal

            While oApp.Usuario.Pedir
                ' Crear el objeto vendedor
                oVendedor = New Vendedor(oApp.Usuario)
                If oVendedor.AbrirDB() Then
                    oApp.DesactivarWiFi()
                    oApp.desconectarRAS()
                    If oVendedor.RecuperarParametros(False) Then
                        While oVendedor.MostrarMenu()
                            Select Case oVendedor.OpcionSeleccionada
                                Case ServicesCentral.TiposOpcionesMenuVendedor.DiasDeTrabajo
                                    cargarCtrlMenuSeguimiento()
                                    oVendedor.OpcionDiasDeTrabajo()
                                    If oVendedor.motconfiguracion.Secuencia Then
                                        ctrlSeguimiento.Dispose()
                                        ctrlSeguimiento = Nothing
                                    End If
                                Case ServicesCentral.TiposOpcionesMenuVendedor.ConfigurarTerminal
                                    oVendedor.OpcionConfigurarTerminal()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.TransmitirInformacion
                                    oVendedor.OpcionTransferirInformacion()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.InformacionSistema
                                    oVendedor.OpcionInformacionSistema()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.UtileriasSistema
                                    oVendedor.OpcionUtileriasSistema()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.IniciarJornada
                                    oVendedor.OpcionIniciarJornada()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.FinalizarJornada
                                    oVendedor.OpcionFinalizarJornada()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.Preliquidacion
                                    If oConHist.Campos("Preliquidacion") Then
                                        oVendedor.OpcionPreliquidacion()
                                    End If
                                Case ServicesCentral.TiposOpcionesMenuVendedor.Reportes
                                    oVendedor.OpcionReportes()
                                Case ServicesCentral.TiposOpcionesMenuVendedor.Kilometraje
                                    oVendedor.OpcionKilometraje()
                            End Select
                        End While
                    End If
                    oVendedor.CerrarDB()

                End If
            End While

        End Function

        Public Function Iniciar() As Boolean Implements ERM.Aplicacion.Iniciar

            Try
                ' Cambios 08 Mayo 2006
                'FormProcesando.PubSubTitulo("Welcome to Amesol Route")
                'FormProcesando.PubSubInformar("Starting...", "Loading program")
                ' / Cambios 08 Mayo 2006

                'Dim FormIniciando As New FormInicio
                ' Mostrar la ventana de "Iniciando"
                'FormIniciando.Show()

                'FormIniciando.Refresh()

                '' Crear el objeto principal
                'oApp = New Config
                '' Recuperar la configuración local
                'If oApp.RecuperarConfiguracion() Then


                oApp.ClaveTerminal = CDevice.GetDeviceID()

                '--Fix para apagar el bluetooth
                If oApp.ModeloTerminal = "SymbolMC50" Or oApp.ModeloTerminal = "SymbolC9090" Then
                    'Apagar/Encender el bluetooth
                    Symbol_Bluetooth.Bluetooth_Off()
                ElseIf oApp.ModeloTerminal = "SymbolMC35" Then
                    Dim phone As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
                    phone.BlueToothEstado(PhoneRadio.RadioMode.Off)
                    phone.Dispose()
                End If

                ' Crear los objetos globales
                oServicioWeb = New ServicesCentral.ServiceMobileClient
                [Global].ActualizarURLWebService()

                'oServicioWeb.WSTerminal_Valida("")

                'With FormIniciando
                '    .Close()
                '    .Dispose()
                '    .PictureBox1.Dispose()
                '    .PictureBox1 = Nothing
                '    FormIniciando = Nothing
                'End With
                Return True
                'End If

            Catch ex As Exception
                MsgBox(ex.GetBaseException.GetType.ToString & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Exclamation, "Iniciar")
            End Try
            Return False
        End Function

        Public Function AbrirDB() As Boolean Implements ERM.Aplicacion.AbrirDB
            Try

                oDBApp = New Conexion(oApp.ClaveTerminal & ".sdf", ServicesCentral.TiposBase.Aplicacion)
                ' Verificar la base de datos del sistema
                Dim bSalir As Boolean = False
                While Not bSalir
                    If Not oDBApp.Abrir(True) Then
                        bSalir = Not PedirDatosServidor()
                        If bSalir Then
                            Return False
                        Else
                            ActualizarURLWebService()
                        End If
                    Else
                        bSalir = True
                    End If
                End While

                ' Cargar los valores por referencia
                If Not ValorReferencia.Llenar() Then
                    Return False
                End If
                ' Cargar las vistas a memoria
                If Not Vista.Llenar() Then
                    Return False
                End If
                If Not Vista.Buscar("FormGlobal", gVista) Then
                    Return False
                End If
                Return True
            Catch ex As System.Net.Sockets.SocketException
                MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico.", MsgBoxStyle.Information, "AbrirBD")
                Return False
            Catch ex As System.FormatException
                MsgBox("[I0167] Se perdió la conexión con el servidor. Intentelo nuevamente", MsgBoxStyle.Information, "AbrirBD")
                Return False
            Catch ex As System.InvalidCastException
                MsgBox("[I0167] Se perdió la conexión con el servidor. Intentelo nuevamente", MsgBoxStyle.Information, "AbrirBD")
                Return False
            Catch ex As Exception
                MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Exclamation, "AbrirBD")
                Return False
            End Try
        End Function

        Public Function CerrarDB() As Boolean Implements ERM.Aplicacion.CerrarDB
            ' Guardar archivo de configuración antes de salir
            oApp.GuardarConfiguracion()
            ' Cerrar la conexión de la aplicacion
            oDBApp.Cerrar()
        End Function

        Public Sub New()

        End Sub
    End Class

End Module

