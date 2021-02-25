Imports System.Data.SqlServerCe
Imports OpenNETCF.Win32
Imports System.Reflection

Module [Global]

    ' Constantes globales

    '--JPacheco 11 Jul 07, Cambio el XML se crea en IPSM 
    '--para que en el coolboot no se pierda, IPSM a petición de JL
    '--hasta que no este el configurador de la terminal
    Public Const PubcArchivoConfig = "\IPSM\MobileClientConfig.xml"
    'Public Const PubcArchivoDatosApp = "MobileDBApp.sdf"
    Public Const PubcArchivoEsquema = "MobileDBConfig.xml"

    Public Const PubcServiceMobileClient = "ServiceMobileClient.asmx"
    Public Const PubcImagenHHP = "\IPSM\ImagenEncuesta.jpg"
    Public Const PubcMarcaSaltos = "<*>"
#If MOD_TERM = "HHP9700" Or MOD_TERM = "IPAQ" Then
    Public Const PubcAlturaItemsDetailView = 36
#Else
    Public Const PubcAlturaItemsDetailView = 18
#End If
    Public Const PubsVersion = "1.5.0.0"
    Public CTEActual As String
    Public vListaPreciosCargada As Boolean

    ' Configuracion local
    Public oApp As Config
    ' Vendedor actual
    Public oVendedor As Vendedor
    ' Dia de trabajo actual0
    Public oDia As Dia
    Public oAgenda As Agenda
    Public oConHist As CONHist

    ' Servicio web global
    Public oServicioWeb As ServicesCentral.ServiceMobileClient
    Public gWSUrl As Uri

    ' Conexiones globales
    Public oDBApp As Conexion
    Public oDBVen As Conexion

    Public gVista As Vista

    Public g_dtProductos As DataTable
    Public g_SO As SO

    'Variable para contar las visitas para el reset
    Public g_NumeroVisitas As Integer
    'Public oRouteLogging As AMESOLLogging.AMESOLLog

    'HashTables para guardar las imagenes
    Public htImagenes As Hashtable

    Public nFactorW As Single
    Public nFactorH As Single
    Public nFactorFont As Single
    Public nFactorImg As Single
    Public bEscalarDV As Boolean
    Public ctrlSeguimiento As CtrlMenuSeguimiento
    Public sNombreActividad As String

    'Control Imagen
#If MOD_TERM = "HHP" Then
#If SO_WCE = 0 Then
    Public WithEvents HHPImager As HHP.DataCollection.PDTImaging.ImageControl
#Else
    Public WithEvents HHPImager As HHP.DataCollection.WinCE.Imaging.ImageControl
#End If
#Else
    Public WithEvents oImaging As HANDHELD.CImaging 
#End If

    Public ReadOnly Property ImagenEncuesta() As String
        Get
            Return oApp.RutaTrabajo & "\ImagenEncuesta"
        End Get
    End Property

#Region "Escalar formas"
    Public Sub ObtenerFactores(ByVal prForma As Form)
        Dim nHeightR As Integer
#If SO_WCE = 1 Then
        nHeightR = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
#ElseIf MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        nHeightR = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - IIf(prForma.Menu Is Nothing, 0, 50)
#Else
        nHeightR = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - IIf(prForma.Menu Is Nothing, 0, IIf(prForma.Height = 295, 25, 30))
#End If


        Dim nWidthR As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Dim nHeightF As Integer = prForma.Height
        Dim nWidthF As Integer = prForma.Width
        nFactorW = nWidthR / nWidthF
        nFactorH = nHeightR / nHeightF
        nFactorImg = nWidthR / 242
        nFactorFont = nFactorH

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        nFactorFont = nFactorH / 1.1
#End If


#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        bEscalarDV = True
#Else
        bEscalarDV = (prForma.Height = 295)
#End If
    End Sub

    Public Sub EscalarForma(ByRef prForma As Form)
        Try
            prForma.Scale(New Drawing.SizeF(nFactorW, nFactorH))
            For Each oControl As Control In prForma.Controls
                EscalarHijo(oControl, nFactorW, nFactorH)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub EscalarHijo(ByRef pvControl As Control, ByVal nFactorW As Single, ByVal nFactorH As Single)
        If pvControl.GetType.Name <> "CtrlMenuImagen" Then
            pvControl.Scale(New Drawing.SizeF(nFactorW, nFactorH))
        End If
    End Sub

    Public Sub EscalarDetailView(ByRef pvDetailView As Resco.Controls.DetailView.DetailView)
        pvDetailView.Size = New System.Drawing.Size(pvDetailView.Width * nFactorW, pvDetailView.Height * nFactorH)
    End Sub

    Public Sub EscalarFuente(ByRef pvControl As Control)
        Try
            If pvControl.GetType.Name <> "CtrlMenuImagen" Or pvControl.GetType.Name <> "DetailView" AndAlso pvControl.GetType.Name.ToUpper <> "PANEL" AndAlso pvControl.GetType.Name.ToUpper <> "PICTUREBOX" AndAlso pvControl.GetType.Name.ToUpper <> "PROGRESSBAR" AndAlso pvControl.GetType.Name.ToUpper <> "VSCROLLBAR" AndAlso pvControl.GetType.Name.ToUpper <> "TABPAGE" AndAlso pvControl.GetType.Name.ToUpper <> "HSCROLLBAR" Then
                If Not pvControl.GetType.GetProperty("Font") Is Nothing Then
                    pvControl.Font = New System.Drawing.Font(pvControl.Font.Name, IIf(pvControl.Font.Size * nFactorFont < 7.0, 7.0, pvControl.Font.Size * nFactorFont), pvControl.Font.Style)
                End If
            End If
        Catch ex As Exception
        End Try
        For Each oControl As Control In pvControl.Controls
            EscalarFuente(oControl)
        Next
    End Sub

    Public Sub EscalarMenuImagen(ByRef prCtrMenuImagen As MobileClient.CtrlMenuImagen)
        Try
            For Each oControl As Control In prCtrMenuImagen.Controls
                oControl.Scale(New Drawing.SizeF(nFactorW, nFactorH))
            Next
            prCtrMenuImagen.Scale(New Drawing.SizeF(nFactorW, nFactorH))
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region " Funciones globales "
    Public Function RedondeoAritmetico(ByVal d As Decimal, ByVal decimals As Integer) As Decimal
        Dim power As Decimal = CDec(Math.Pow(10, decimals))
        ' Note: converting to positive number before calculating rounding, so that we don't need separate logic for negative number handling 
        Dim result As Decimal = Decimal.Floor((Math.Abs(d) * power) + 0.5D) / power
        Return result * Math.Sign(d)
    End Function

    'Public Sub AgregarLogging(ByVal parsDescripcion As String, ByVal parsFuncion As String, ByVal pariTipoLog As AMESOLLogging.AMESOLLog.TipoLog, Optional ByVal parsParametro As String = "")
    '    'If oApp.LogActivo Then

    '    Dim dato As New AMESOLLogging.AMESOLLog.DatosAInsertar
    '    dato.Aplicacion = "ROUTE"
    '    dato.Descripcion = parsDescripcion
    '    dato.FechaHora = DateTime.Now
    '    dato.Funcion = parsFuncion
    '    dato.Parametro = parsParametro
    '    oRouteLogging.insertarValor(dato, pariTipoLog)
    '    'End If
    'End Sub

    'Public Sub MemoriaTexto(ByVal sForma As String)
    '    Dim oArchivo As IO.FileStream
    '    If Not IO.File.Exists("\IPSM\Memoria.txt") Then
    '        oArchivo = IO.File.Create("\IPSM\Memoria.txt")
    '    Else
    '        oArchivo = IO.File.Open("\IPSM\Memoria.txt", IO.FileMode.Append)
    '    End If
    '    Dim w As IO.StreamWriter = New IO.StreamWriter(oArchivo)
    '    w.Write(sForma & ": " & Memoria.MemoriaFree & vbCrLf)
    '    w.Flush()
    '    oArchivo.Close()
    'End Sub

    Public Sub MensajeAArchivo(ByVal sMensaje As String)
        Dim oFile As New IO.FileStream("IPSM/Route/Coordenadas.txt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
        Dim w As IO.StreamWriter = New IO.StreamWriter(oFile)
        w.BaseStream.Seek(0, IO.SeekOrigin.End)
        'w.Write("Log Entry : {0}", vbCrLf)
        'w.WriteLine("{0} {1}{2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), vbCrLf)
        w.WriteLine("{0}{1}", sMensaje, vbCrLf)
        w.Flush()
        oFile.Close()
    End Sub

    Public Function FechaALetra(ByVal dFecha As Date) As String
        Dim sFecha As String = ""
        Dim sMensaje As String = ""
        Select Case dFecha.Month
            Case 1
                sMensaje = "XFechaEnero"
            Case 2
                sMensaje = "XFechaFebrero"
            Case 3
                sMensaje = "XFechaMarzo"
            Case 4
                sMensaje = "XFechaAbril"
            Case 5
                sMensaje = "XFechaMayo"
            Case 6
                sMensaje = "XFechaJunio"
            Case 7
                sMensaje = "XFechaJulio"
            Case 8
                sMensaje = "XFechaAgosto"
            Case 9
                sMensaje = "XFechaSeptiembre"
            Case 10
                sMensaje = "XFechaOctubre"
            Case 11
                sMensaje = "XFechaNoviembre"
            Case 12
                sMensaje = "XFechaDiciembre"
        End Select
        sFecha = gVista.BuscarMensaje("MsgBoxGeneral", sMensaje).Replace("$0$", dFecha.Day.ToString).Replace("$1$", dFecha.Year.ToString)
        Return sFecha
    End Function

    Public Function MesALetra(ByVal Mes As Integer) As String
        Select Case Mes
            Case 1
                Return "Enero"
            Case 2
                Return "Febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "Mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Septiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
        End Select
        Return String.Empty
    End Function

    Public Function PedirDatosServidor() As Boolean
        Dim sUrl As String = ""
        Try
            FormProcesando.PubSubInformar("Preparing connection", "Creating connection screen")

            Dim FormVerificacion As New FormVerificacion
            Dim sRespuesta As String = ""
            Dim wsServicioGeneral As New ServicesCentral.ServiceMobileClient
            ' Presentar la forma y solicitar los datos para conectarse al servidor

            While FormVerificacion.ShowDialog() = DialogResult.Yes
                ' Usar un dataset para recibir la información desde el servicio web
                'FormProcesando.PubSubInformar("Conectándose al servidor", oApp.Servidor)
                ' Cambios 08 Mayo 2006
                FormProcesando.PubSubInformar("Connecting to server", oApp.Servidor)

                ' / Cambios 08 Mayo 2006
                Try
                    wsServicioGeneral.Url = "http://" & oApp.Servidor & "/" & oApp.URL & "/" & PubcServiceMobileClient
                    'wsServicioGeneral.Timeout = 15000
                    wsServicioGeneral.Timeout = (oApp.TimeOut * 60) * 1000
                    sUrl = wsServicioGeneral.Url

                    Dim bDisponible As Boolean = True
                    If (Not oApp.ProbarServicioR(3)) Then
                        bDisponible = False
                        If oApp.UsarWireless Then
                            bDisponible = oApp.RevisarServidor()
                        End If
                        If Not bDisponible Then
                            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico", MsgBoxStyle.Critical, "PedirDatosServidor")
                            FormVerificacion.PanelConexion.Visible = True
                            Continue While
                        End If
                    End If

                    If Not wsServicioGeneral.WSVendedorObtenerAcceso(oApp.Usuario.Clave, oApp.Contrasena, oApp.ClaveTerminal, sRespuesta) Then
                        'MsgBox("Error: " & sRespuesta, MsgBoxStyle.Exclamation Or MsgBoxStyle.SystemModal)
                        ' Cambios 08 Mayo 2006
                        MsgBox(sRespuesta, MsgBoxStyle.Exclamation Or MsgBoxStyle.SystemModal)
                        ' / Cambios 08 Mayo 2006
                        FormVerificacion.PanelConexion.Visible = True
                        'Else
                        ' Llamar el web service para recuperar el dataset con la información de la base de datos
                        'If RecuperarEstructura() Then
                        ' Se recuperó la estructura desde el servidor 
                        'Return True
                        'End If
                    Else
                        oApp.GuardarConfiguracion()
                        FormVerificacion.Dispose()
                        Return True
                    End If
                Catch ExcA As Exception
                    If MsgBox(ExcA.Message & ": " & sUrl, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel Or MsgBoxStyle.SystemModal) <> MsgBoxResult.Retry Then
                        Exit While
                        'Exit Function
                    End If
                    FormVerificacion.PanelConexion.Visible = True
                End Try
            End While
            With FormVerificacion
                .DetailViewDatosConexion = Nothing
                .PictureBoxLogoERM.Dispose()
                .PictureBoxLogoERM = Nothing
                .Dispose()
                FormVerificacion = Nothing
            End With
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sUrl, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "PedirDatosConexion")
        End Try
        ' No desea conectarse con ServicesCentral, continuar
        Return False
    End Function

    Public Function PrimeraHora(ByVal parFecha As Date) As Date
        Dim f1 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 0, 0, 0)
        Return f1
    End Function
    Public Function UltimaHora(ByVal parFecha As Date) As Date
        Dim f2 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 23, 59, 59)
        Return f2
    End Function
    Public Function FormatearFecha(ByVal pardValorFecha As Date, Optional ByVal parsFormato As String = "") As String
        Dim sFechaRetorno As String = "*** Error "
        Try
            Dim sFormato As String = ""
            If parsFormato = "" Then
                sFormato = oApp.FormatoFecha
            Else
                sFormato = parsFormato
            End If
            sFechaRetorno = Format(pardValorFecha, sFormato)
        Catch ExcA As Exception
            sFechaRetorno &= ExcA.Message & ": " & pardValorFecha
        End Try
        Return sFechaRetorno
    End Function

    Public Function AplicarFuncion(ByVal parsNombreColumna As String, ByVal parsValorColumna As String, ByRef refparsNuevoValorColumna As String, ByRef refpariIndiceImagen As Integer, Optional ByRef optrefparoDetailViewItem As Resco.Controls.DetailView.Item = Nothing) As Boolean
        Dim sFuncion As String = ""
        If Mid(parsNombreColumna, 1, 1) = "#" Then
            If InStr(parsNombreColumna, "(") = 0 Then
                sFuncion = Mid(parsNombreColumna, 2)
            Else
                sFuncion = Mid(parsNombreColumna, 2, InStr(parsNombreColumna, "(") - 2)
            End If
        End If

        refparsNuevoValorColumna = parsValorColumna
        If sFuncion <> "" Then
            Dim sContenido As String = ""
            ' Recuperar los valores para cada campo
            Dim i As Integer = InStr(parsNombreColumna, "(")
            If i <> 0 Then
                sContenido = Mid(parsNombreColumna, i + 1, Len(parsNombreColumna) - i - 1)
            End If
            Select Case UCase(sFuncion)
                Case "DATE"
                    ' Variables para recuperar el contenido en varios campos
                    Dim sDelimitadores As String = ","
                    Dim cDelimitador As Char() = sDelimitadores.ToCharArray()
                    Dim asParams As String() = Nothing
                    asParams = sContenido.Split(cDelimitador)
                    If asParams.Length() = 1 Then
                        If parsValorColumna <> String.Empty Then
                            refparsNuevoValorColumna = FormatearFecha(parsValorColumna)
                        End If
                    Else
                        refparsNuevoValorColumna = FormatearFecha(parsValorColumna, asParams(1))
                    End If
                Case "FORMATNUM"
                    Dim sDelimitadores As String = ","
                    Dim cDelimitador As Char() = sDelimitadores.ToCharArray()
                    Dim asParams As String() = Nothing
                    asParams = sContenido.Split(cDelimitador)
                    If parsValorColumna = "" Then
                        parsValorColumna = "0"
                    End If
                    Dim nValor As Single = parsValorColumna
                    If asParams.Length() = 1 Then
                        refparsNuevoValorColumna = Format(nValor, oApp.FormatoDinero)
                    Else
                        asParams(1) = Replace(asParams(1), "_", ",")
                        refparsNuevoValorColumna = Format(nValor, asParams(1))
                    End If
                Case "TYPE"
                    refparsNuevoValorColumna = ValorReferencia.BuscarEquivalente(sContenido, parsValorColumna)

                Case "TYPE2"
                    refparsNuevoValorColumna = ValorReferencia.BuscarEquivalente2(sContenido, parsValorColumna)

                Case "COMBO" ' Solo para los DetailViews cuando son de tipo ConsultaSQL
                    If Not optrefparoDetailViewItem Is Nothing Then
                        Dim refComboResco As Resco.Controls.DetailView.ItemComboBox = optrefparoDetailViewItem
                        If refComboResco.ValueMember = "" Then
                            Dim oArregloValores As ArrayList
                            If sContenido.IndexOf(",") > -1 Then
                                Dim sDelimitadores As String = ","
                                Dim cDelimitador As Char() = sDelimitadores.ToCharArray()
                                Dim asParams As String() = Nothing
                                asParams = sContenido.Split(cDelimitador)
                                If asParams.Length > 0 Then
                                    'TODO: Solo se implemento la funcionalidad de requerir los valores por referencia que tengan algun grupo. 
                                    'Falta implementar la solicitud de algun grupo especifico, y de que aquellos que no pertenezcan a algun grupo.
                                    If asParams(1) = "*" Then
                                        oArregloValores = ValorReferencia.RecuperarListaArraySoloConGrupo(asParams(0))
                                    End If
                                End If
                            Else
                                oArregloValores = ValorReferencia.RecuperarListaArray(sContenido)
                            End If
                            refComboResco.DataSource = oArregloValores
                            refComboResco.ValueMember = "Id"
                            refComboResco.DisplayMember = "Cadena"
                        End If
                        refComboResco.Value = ValorReferencia.BuscarEquivalente(sContenido, parsValorColumna)

                    End If
                Case "ICON"
                    refpariIndiceImagen = CInt(parsValorColumna)
                    Return False
            End Select
        End If
        Return True
    End Function

    Public Sub ActualizarURLWebService()
        If IsNothing(oServicioWeb) Then
            oServicioWeb = New ServicesCentral.ServiceMobileClient()
        End If

        oServicioWeb.Url = "http://" & oApp.Servidor & "/" & oApp.URL & "/" & PubcServiceMobileClient
        'oServicioWeb.Timeout = 5000
        'oServicioWeb.Timeout = 50000000
        oServicioWeb.Timeout = (oApp.TimeOut * 60) * 1000

        If gWSUrl Is Nothing Then
            gWSUrl = New Uri(oServicioWeb.Url)
        End If
    End Sub

    Public Sub IniciarWS()
        gWSUrl = Nothing
        ActualizarURLWebService()
    End Sub

    Public Function ConvertirElementosListaAString(ByRef refparLista As ArrayList) As String
        Dim sCadena As String = ""
        Dim i As Integer
        For i = 0 To refparLista.Count - 1
            sCadena &= "'" & refparLista(i) & "',"
        Next
        sCadena = Mid(sCadena, 1, Len(sCadena) - 1)
        Return sCadena
    End Function

    Public Function ObtenerAlineacion(ByVal eTipoAlineacion As ServicesCentral.TiposAlineacion) As Windows.Forms.HorizontalAlignment
        Dim TextAlignRetorno As HorizontalAlignment
        Select Case eTipoAlineacion
            Case ServicesCentral.TiposAlineacion.Izquierda
                TextAlignRetorno = HorizontalAlignment.Left
            Case ServicesCentral.TiposAlineacion.Centro
                TextAlignRetorno = HorizontalAlignment.Center
            Case ServicesCentral.TiposAlineacion.Derecha
                TextAlignRetorno = HorizontalAlignment.Right
        End Select
        Return TextAlignRetorno
    End Function



    Public Sub LimpiarDetailView(ByRef refparDetailView As Resco.Controls.DetailView.DetailView)
        Dim refDetailViewItem As Resco.Controls.DetailView.Item
        For Each refDetailViewItem In refparDetailView.Items
            If refDetailViewItem.Tag <> PubcMarcaSaltos Then
                refDetailViewItem.Text = ""
            End If
        Next
    End Sub

    Public Function RevisarElementoMarcado(ByRef refListView As ListView) As Boolean
        Dim refListViewItem As ListViewItem
        Dim refListViewItemSel As ListViewItem = Nothing
        Dim refListViewItemChk As ListViewItem = Nothing
        If refListView.SelectedIndices.Count <> 0 Then
            refListViewItemSel = refListView.Items(refListView.SelectedIndices(0))
        End If
        For Each refListViewItem In refListView.Items
            If refListViewItem.Checked Then
                refListViewItemChk = refListViewItem
                Exit For
            End If
        Next
        If refListViewItemSel Is Nothing Then
            If refListViewItemChk Is Nothing Then
                Return False
            Else
                refListViewItemChk.Selected = True
                refListViewItemSel = refListViewItemChk
            End If
        End If
        MarcarElemento(refListView, CheckState.Checked, refListViewItemSel.Index)
        Return True
    End Function



    Public Function RevisarElementoMarcado2(ByRef refListView As ListView) As Boolean
        Dim refListViewItem As ListViewItem
        Dim intTotal As Integer = 0

        For Each refListViewItem In refListView.Items
            If refListViewItem.Checked Then
                intTotal += 1
            End If
        Next
        Return intTotal > 0
    End Function

    Public Sub MarcarElemento(ByRef refListView As ListView, ByVal eValor As CheckState, ByVal iIndex As Integer)
        Dim i As Integer
        If eValor = CheckState.Checked Then
            For i = 0 To refListView.Items.Count - 1
                If i = iIndex Then
                    refListView.Items(i).Checked = CheckState.Checked
                    refListView.Items(i).Selected = True
                Else
                    refListView.Items(i).Checked = False
                End If
            Next
        End If
    End Sub

    Public Sub MarcarElementoIncluyente(ByRef refListView As ListView, ByVal eValor As CheckState, ByVal iIndex As Integer)
        If eValor = CheckState.Checked Then
            refListView.Items(iIndex).Checked = CheckState.Checked
            refListView.Items(iIndex).Selected = True
        Else
            refListView.Items(iIndex).Selected = False
        End If
    End Sub

    Public Function BuscarIndiceElemento(ByRef refparListView As ListView, ByVal pariIndice As Short) As Short
        Dim refListViewItem As ListViewItem
        For Each refListViewItem In refparListView.Items
            If refListViewItem.ImageIndex = pariIndice Then
                Return refListViewItem.Index
            End If
        Next
        Return 0
    End Function

    Public Function UniFechaSQL(ByVal pardFecha As Date, Optional ByVal optsTipoDatoDestino As String = "DATETIME", Optional ByVal optsFormato As String = "dd/MM/yyyy HH:mm:ss", Optional ByVal optsEstilo As String = "103") As String
        'Return "CONVERT(" & optsTipoDatoDestino & ",'" & Fecha24Horas(pardFecha, optsFormato) & "'," & optsEstilo & ")"
        Return "'" & IIf(pardFecha.Year < 1900, pardFecha.AddYears(1900 - pardFecha.Year).ToString("s"), pardFecha.ToString("s")) & "'"
    End Function

    Public Function Fecha24Horas(ByVal pardFecha As Date, Optional ByVal optsFormato As String = "dd/MM/yyyy HH:mm:ss") As String
        Return Format(pardFecha, optsFormato)
    End Function

    Public Function ObtenerSistemaOperativo(ByVal OSMajor As Integer, ByVal OSMinor As Integer) As SO
        If OSMajor = 5 And OSMinor = 0 Then
            '--Se trata de una version para windows CE                
            Return SO.WindowsCE
        ElseIf OSMajor = 5 And OSMinor > 0 Then
            '--Se trata de una version para Windows Mobile 5
            Return SO.WindowsMobile2005
        ElseIf OSMajor = 4 Then
            '--Se trata de una version para Pocket PC 2003
            Return SO.WindowsMobile2003
        End If
    End Function
    Public Function Operador(ByVal VAVClave As Integer, ByVal ValorIni As Object, ByVal ValorFin As Object, ByVal parTipoDato As TipoDato) As String
        Select Case VAVClave
            Case 1 'Igual
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico
                        Return " = " & ValorIni
                    Case TipoDato.Cadena
                        Return " = '" & ValorIni & "'"
                End Select
            Case 2 'Diferente
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " not between " & UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico
                        Return " <> " & ValorIni
                    Case TipoDato.Cadena
                        Return " <> '" & ValorIni & "'"
                End Select
            Case 3
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Mayor que
                        Return " > " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico 'Mayor que
                        Return " > " & ValorIni
                    Case TipoDato.Cadena  'Empiece con
                        Return " like '" & ValorIni & "%'"
                End Select
            Case 4
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Menor que
                        Return " < " & UniFechaSQL(PrimeraHora(ValorIni))
                    Case TipoDato.Numerico 'Menor que
                        Return " < " & ValorIni
                    Case TipoDato.Cadena 'Termine con
                        Return " like '%" & ValorIni & "'"
                End Select
            Case 5
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Mayor igual que
                        Return " >= " & UniFechaSQL(PrimeraHora(ValorIni))
                    Case TipoDato.Numerico 'Mayor igual que
                        Return " >= " & ValorIni
                    Case TipoDato.Cadena 'Contenga
                        Return " like '%" & ValorIni & "%'"
                End Select
            Case 6
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Menor igual que
                        Return " <= " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico 'Menor igual que
                        Return " <= " & ValorIni
                    Case TipoDato.Cadena 'No contenga
                        Return " not like '%" & ValorIni & "%'"
                End Select
            Case 7 'Entre
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " and " & UniFechaSQL(UltimaHora(ValorFin))
                    Case TipoDato.Numerico
                        Return " between " & ValorIni & " and " & ValorFin
                End Select
        End Select
        Return String.Empty
    End Function
    Public Function BuscarAgregarNodo(ByVal parsTag As String, _
                                             ByRef refparTreeNodeCollection As TreeNodeCollection, _
                                             ByRef paroClaveBusqueda() As Object, _
                                             ByRef refparDataView As DataView, _
                                             ByVal parsCampoDescripcion As String) _
                                             As TreeNode
        Dim refTreeNode As TreeNode = Nothing
        Try
            Dim refTreeNodePadre As TreeNode = Nothing
            For Each refTreeNode In refparTreeNodeCollection
                If refTreeNode.Tag = parsTag Then
                    refTreeNodePadre = refTreeNode
                    Exit For
                End If
            Next
            If (refTreeNodePadre Is Nothing) Then
                ' Buscar la descripción para agregarlo
                Dim sDescripcion As String = parsTag & "=?"
                Dim iRowIndex As Integer = refparDataView.Find(paroClaveBusqueda)
                If iRowIndex <> -1 Then
                    sDescripcion = refparDataView(iRowIndex).Item(parsCampoDescripcion)
                End If
                refTreeNode = refparTreeNodeCollection.Add(sDescripcion)
                refTreeNode.Tag = parsTag
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarAgregarNodo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarAgregarNodo")
        End Try
        Return refTreeNode
    End Function

    Public Function BuscarNodo(ByVal refparTreeNodeCollection As TreeNodeCollection, ByVal parsTexto As String, ByVal parsTag As Object, ByVal bAgregar As Boolean) As TreeNode
        Dim refTreeNodeBuscado As TreeNode = Nothing
        Try
            Dim refTreeNode As TreeNode = Nothing

            For Each refTreeNode In refparTreeNodeCollection
                If refTreeNode.Tag = parsTag Then
                    refTreeNodeBuscado = refTreeNode
                    Exit For
                End If
            Next
            If (refTreeNodeBuscado Is Nothing) And bAgregar Then
                ' Buscar la descripción para agregarlo
                refTreeNodeBuscado = refparTreeNodeCollection.Add(parsTexto)
                refTreeNodeBuscado.Tag = parsTag
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarNodo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarNodo")
        End Try
        Return refTreeNodeBuscado
    End Function

    Public Function SustituirValoresMensaje(ByVal sMensaje As String, ByVal sValores As String()) As String
        Dim i As Integer = 0
        For Each sValor As String In sValores
            sMensaje = sMensaje.Replace("$" & i & "$", sValor)
            i += 1
        Next
        Return sMensaje
    End Function


    Public Function SustituyeCampo(ByVal msg As String, ByVal campo As String) As String
        Return msg.Replace("$0$", campo)
    End Function

    Public Function ObtenerDiasSurtido() As Integer
        Return oConHist.Campos("DiasSurtido")
    End Function


    Public Structure SYSTEMTIME
        Public wYear As UInt16
        Public wMonth As UInt16
        Public wDayOfWeek As UInt16
        Public wDay As UInt16
        Public wHour As UInt16
        Public wMinute As UInt16
        Public wSecond As UInt16
        Public wMilliseconds As UInt16
    End Structure

    Declare Function GetSystemTime Lib "CoreDll.dll" _
    (ByRef lpSystemTime As SYSTEMTIME) As UInt32

    Declare Function SetSystemTime Lib "CoreDll.dll" _
        (ByRef lpSystemTime As SYSTEMTIME) As UInt32

    Public Function ActualizarFechaTerminal() As Boolean

        Dim oDateTime As DateTime

        Dim oFormaPedirFechaActual As New FormPedirFechaActual
        oFormaPedirFechaActual.ShowDialog()
        oDateTime = oFormaPedirFechaActual.FechaActual
        oFormaPedirFechaActual.Dispose()

        If oDateTime <> Now Then

            '--Cambiar la Fecha Actual
            Dim dFechaServidor As Date
            Dim lValorFecha As Long
            Dim res As UInt32

            Dim tsDif As TimeSpan
            Dim iNumHoras As Integer

            Dim st As New SYSTEMTIME
            Try
                tsDif = TimeZone.CurrentTimeZone.GetUtcOffset(oDateTime)

                iNumHoras = tsDif.Negate.Hours
                lValorFecha = oDateTime.ToFileTimeUtc
                dFechaServidor = Date.FromFileTimeUtc(lValorFecha)

                dFechaServidor = dFechaServidor.AddHours(iNumHoras)

                st.wYear = Convert.ToInt16(dFechaServidor.Year)
                st.wMonth = Convert.ToInt16(dFechaServidor.Month)
                st.wDay = Convert.ToInt16(dFechaServidor.Day)
                st.wHour = Convert.ToInt16(dFechaServidor.Hour)
                st.wMinute = Convert.ToInt16(dFechaServidor.Minute)
                st.wSecond = Convert.ToInt16(dFechaServidor.Second)

                res = SetSystemTime(st)

                Return (Not res.Equals(0))

            Catch ex As Exception
                Return False
            End Try

        End If
    End Function
    Public Sub EliminarDatosEnviados()
        Dim falla As Boolean = False
        If (oDBVen.oConexion.State = ConnectionState.Closed) Then
            oDBVen.oConexion.Open()
            oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()
        End If
        Dim strSQL As String = ""

        Try

            strSQL = "DELETE FROM ProductoPrestamoCli "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            'strSQL = "DELETE FROM ProductoPrestamoCli "
            'strSQL &= "WHERE Enviado = 1"
            'oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TpdDes "
            strSQL &= "WHERE TransProdId in( "
            strSQL &= "SELECT TransProdId "
            strSQL &= "FROM TransProd "
            strSQL &= "WHERE Enviado = 1 and Tipo = 21)"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TpdDesVendedor "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TrpPrp "
            strSQL &= "WHERE TransProdId in( "
            strSQL &= "SELECT TransProdId "
            strSQL &= "FROM TransProd "
            strSQL &= "WHERE Enviado = 1 and Tipo = 21)"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TPDImpuesto "
            strSQL &= "WHERE TransProdId in( "
            strSQL &= "SELECT TransProdId "
            strSQL &= "FROM TransProd "
            strSQL &= "WHERE Enviado = 1 and Tipo = 21)"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TransProdDetalle "
            strSQL &= "WHERE TransProdId in( "
            strSQL &= "SELECT TransProdId "
            strSQL &= "FROM TransProd "
            strSQL &= "WHERE Enviado = 1 and ((Tipo = 3) OR (Tipo = 9) OR (Tipo = 16) OR (Tipo = 15) OR (Tipo = 20) OR (Tipo = 21)))"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TRPDatoFiscal "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM TransProd "
            strSQL &= "WHERE Enviado = 1 and ((Tipo = 3) OR (Tipo = 9) OR (Tipo = 16) OR (Tipo = 15) OR (Tipo = 20) OR (Tipo = 21)) "
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ImproductividadVenta "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ImproductividadVenta "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ImproductividadProd "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM Solicitud "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM Gasto "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ProductoNegado "
            strSQL &= "WHERE Enviado = 1 AND (PromocionClave IS NULL OR TipoFasePRP <> 1)"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM MerCli "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM MerDetalle "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM MercadeoProducto "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM MercadeoProveedor "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM Mercadeo "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespOpcional "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespCodigo "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespMatricial "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespImagen "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespNumero "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespTexto "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENPRespGPS "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM ENCPregunta "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM Encuesta "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM PLBPLE "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM PreLiquidacion "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            strSQL = "DELETE FROM CamionVendedor "
            strSQL &= "WHERE Enviado = 1"
            oDBVen.EjecutarComandoSQL(strSQL)

            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                Try
                    If falla Then
                        oDBVen.Transaccion.Rollback()
                    Else
                        oDBVen.Transaccion.Commit()
                    End If
                    If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                    oDBVen.Transaccion = Nothing
                Catch ex As Exception
                End Try
                oDBVen.oConexion.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Function HayDatoSinDescargar() As Boolean

        Dim strSQL As New Text.StringBuilder

        strSQL.Append("SELECT Count(*) as NoRegistros FROM Gasto WHERE Enviado is null or Enviado=0,")
        strSQL.Append("SELECT Count(*) FROM Deposito WHERE Enviado is null or Enviado=0,")
        strSQL.Append("SELECT Count(*) FROM VendedorJornada WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM Cliente WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ClienteDomicilio WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ClienteEsquema WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CLIFormaVenta WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CFVHist WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from ClienteMensaje WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CliCap WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from punto WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM Activo WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ActivoServicio WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ActivoClienteHist WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM MercadeoProveedor WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM MercadeoProducto WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM Visita WHERE (Enviado is null or Enviado =0) AND TipoEstado<>0,")
        strSQL.Append("SELECT Count(*) FROM Encuesta WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENCPregunta WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespNumero WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespOpcional WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespTexto WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespCodigo WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespImagen WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespMatricial WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ENPRespGPS WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM Mercadeo WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM MerCli WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM MerDetalle WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from transprod WHERE (Enviado=0 or Enviado is null) and (Escritorio = 0 or Escritorio is null) and (Tipo <> 14),")
        strSQL.Append("SELECT Count(*) FROM TRPPrp WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM TPDImpuesto WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM TpdDes WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM TpdDesVendedor WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM TransProdDetalle WHERE (Enviado=0 or Enviado is null) and not TransProdID in (Select TransProdID from TransProd where Escritorio = 1 or Tipo = 14),")
        strSQL.Append("SELECT Count(*) FROM ProductoPrestamoCli WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from abono WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from ABNDetalle WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from ABNTrp WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from AbdDep WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) from AbonoProgramado WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ImproductividadVenta WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ImproductividadProd WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM Solicitud WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM ProductoNegado WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CuotaCumplida WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CucCcu WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CupCcu WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CueCcu WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM Preliquidacion WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM PLBPLE WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM FolioFiscal WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM TRPDatoFiscal WHERE Enviado=0 or Enviado is null,")
        strSQL.Append("SELECT Count(*) FROM CamionVendedor WHERE Enviado=0 or Enviado is null")

        strSQL.Replace(",", vbCrLf + " Union" + vbCrLf)

        Dim oTabla As DataTable
        Dim countObject As Object
        Dim sUsuario As String
        Dim DataTableDatos As DataTable

        Dim oAppVer As New VersionesLicencias

        '--Fix nunca se ejecutaba el query
        If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & oApp.ClaveTerminal & ".sdf") Then
            'Verificar que existe el archivo de applicacion
            Return False
        End If

        ' Ejecutar la consulta para verificar el usuario y contraseña
        DataTableDatos = oAppVer.RealizarConsultaSQL("SELECT USUId,Clave,Nombre,PERClave FROM Usuario WHERE Clave='" & oApp.Usuario.Clave & "'", "Usuario", oApp.ClaveTerminal & ".sdf")

        If DataTableDatos.Rows.Count = 1 Then
            With DataTableDatos.Rows(0)
                sUsuario = .Item("USUId")
            End With
            DataTableDatos.Dispose()
        End If
        DataTableDatos.Dispose()
        DataTableDatos = Nothing

        If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & sUsuario & ".sdf") Then

            '--Verificar que no exista la base de datos vendedor
            Return False

        End If

        oTabla = oAppVer.RealizarConsultaSQL(strSQL.ToString, "DatosCarga", sUsuario + ".sdf")
        countObject = oTabla.Compute("Count(NoRegistros)", "NoRegistros>0")
        oTabla.Dispose()
        oTabla = Nothing

        Return countObject > 0
    End Function

    'Public Function Revisar_Licencia() As Boolean

    '    Try
    '        Dim oLicencia As New ServicesCentral.Registro
    '        Dim oDevice As New CDevice

    '        oLicencia = oServicioWeb.WSTipo_Licencia(CDevice.GetDeviceID, oDevice.DeviceName)

    '        If Not oLicencia = ServicesCentral.Registro.Definitivo Then
    '            MsgBox("El dispositivo no tiene una licencia válida", MsgBoxStyle.Critical)
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error al leer la licencia", MsgBoxStyle.Critical)
    '        Return False

    '    End Try

    '    Return True

    'End Function

    Public Function EsNumerico(ByVal pvDato As String) As Boolean
        For Each cDato As Char In pvDato.ToCharArray
            If Not Char.IsDigit(cDato) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function PosicionarControl() As Boolean

#If SO_WCE = 1 Then
        Return True
#End If

        Return False
    End Function

    Public Function Posicionar(ByVal pvControl As Control.ControlCollection, ByRef pvPosicion As Integer) As Boolean
        Dim val As Boolean = False
        If PosicionarControl() Then
            For Each ctrl As Control In pvControl
                If ctrl.Controls.Count > 0 Then
                    val = Posicionar(ctrl.Controls, pvPosicion)
                    If val Then
                        pvPosicion = ctrl.Location.Y + 23
                        val = True
                        Exit For
                    End If
                End If

                If ctrl.GetType.Name = "TabControl" Then
                    Return True
                End If
            Next
        End If

        Return val
    End Function

    Public Sub UbicarTitulo(ByRef pvLabel As Label, ByVal pvControl As Control.ControlCollection)
        Dim posicion As Integer
        If Posicionar(pvControl, posicion) Then
            pvLabel.Dock = DockStyle.None
            pvLabel.Location = New System.Drawing.Point(2, posicion)
        Else
            pvLabel.Dock = DockStyle.Top
        End If
    End Sub

    Public Sub HabilitarMenuItem(ByRef parMenuItem As MainMenu, ByVal pvHabilitar As Boolean)
        For Each mi As MenuItem In parMenuItem.MenuItems
            mi.Enabled = pvHabilitar
        Next
    End Sub

#End Region

    Public Enum TipoDato
        Cadena = 1
        Numerico = 2
        Fecha = 3
    End Enum

    Public Enum SO
        WindowsMobile2005
        WindowsMobile2003
        WindowsCE
    End Enum

    Public Enum TipoPapel
        ExtechTermica2 = 1
        ExtechTermica3
        ExtechImpacto2
        ZebraTermica2
        TecTermica2
        ExtechApex2
    End Enum

End Module

Module modControls
    Friend Function CloneControl(ByVal c As Control) As Control
        ' instantiate another instance of the given control and
        ' clone the common properties
        Dim newControl As Control = CType(NewAs(c), Control)
        CloneProperties(newControl, c, "Visible", "Size", "Font", _
            "Text", "Location", "BackColor", "ForeColor", "Enabled")

        ' clone properties unique to specific controls
        If TypeOf newControl Is ButtonBase Then
            CloneProperties(newControl, c, "DialogResult", _
                "BackgroundImage", "FlatStyle", "TextAlign", "Image", _
                "ImageAlign", "ImageIndex", "ImageList")
        ElseIf TypeOf newControl Is LinkLabel Then
            CloneProperties(newControl, c, "VisitedLinkColor", _
                "LinkVisited", "LinkColor", "LinkBehavior", "LinkArea", _
                "FlatStyle", "BorderStyle", "DisabledLinkColor", _
                "ActiveLinkColor", "Image", "ImageAlign", "ImageIndex", _
                "ImageList")
        ElseIf TypeOf newControl Is ListView Then
            CloneProperties(newControl, c, "FullRowSelect", "HeaderStyle", "View", "CheckBoxes")
        End If
        Return newControl
    End Function
End Module

Public Module ObjectFactory
    Public Function NewAs(ByVal t As Type) As Object
        Return t.Assembly.CreateInstance(t.FullName)
    End Function

    Public Function NewAs(ByVal x As Object) As Object
        Return ObjectFactory.NewAs(x.GetType())
    End Function

    Public Sub CloneProperties(ByVal target As Object, ByVal source As _
        Object, ByVal ParamArray propertyNames() As String)

        Dim sourceProperties As New PropertyAccessor(source)
        Dim targetProperties As New PropertyAccessor(target)
        Dim p As String
        For Each p In propertyNames
            targetProperties(p) = sourceProperties(p)
        Next
    End Sub
End Module

Public Class PropertyAccessor
    Public Sub New(ByVal target As Object)
        Me.target_ = target
    End Sub
    Public ReadOnly Property Target() As Object
        Get
            Return Me.target_
        End Get
    End Property

    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Dim prop As PropertyInfo = _
                Me.Target.GetType().GetProperty(propertyName)
            If IsNothing(prop) Then

            Else
                Return prop.GetValue(Me.Target, Nothing)
            End If

        End Get
        Set(ByVal value As Object)
            Dim prop As PropertyInfo = _
                Me.Target.GetType().GetProperty(propertyName)
            prop.SetValue(Me.Target, value, Nothing)
        End Set
    End Property

#Region " Private State "
    Private target_ As Object
#End Region
End Class
