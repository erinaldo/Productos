Imports System.IO

Public Class cRepMensualHacienda

    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia

#Region "VARIABLES"
    Private vgExtension As String = ".txt"
    Private vgTipo As String = "Documento de Texto"
    Private vgNumeroEsquema As Integer = 1
    Private vgRFCEmisor As String
    Private vgMes, vgAnio As String
    Private vgDirectorio As String
    Public vgColeccion As ArrayList
#End Region

#Region "PROPIEDADES"
    Public ReadOnly Property DIRECTORIO() As String
        Get
            Return PATH & "\" & FILE_NAME
        End Get

    End Property
    Public ReadOnly Property FILE_NAME() As String
        Get
            Return numeroEsquema & RFCEmisor & vgMes & vgAnio & vgExtension
        End Get
    End Property
    Public Property PATH() As String
        Get
            Return vgDirectorio
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                vgDirectorio = "C:\"
            Else
                vgDirectorio = Value
            End If

        End Set
    End Property

    Public ReadOnly Property Tipo() As String
        Get
            Dim enmemoria As New MemoryStream

            Try

                Dim vlValor As String
                Dim sw As New StreamWriter(enmemoria)
                If Not Me.vgColeccion Is Nothing Then

                    For Each vlRen As cRepMensualRenglones In Me.vgColeccion
                        sw.WriteLine(vlRen.dameRenglon)
                    Next

                End If

                vlValor = vgTipo & ", " & Math.Round((enmemoria.Length / 1024), 2).ToString() & " KB"
                sw.Close()
                enmemoria.Close()
                Return vlValor

            Catch ex As IOException
                MsgBox(ex.Message())
            Catch ExcB As Exception
                MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "GenerarXML")
            End Try

            enmemoria.Close()
            Return ""
        End Get
    End Property

    Public Property numeroEsquema() As Integer
        Get
            Return Me.vgNumeroEsquema
        End Get
        Set(ByVal Value As Integer)
            vgNumeroEsquema = Value
        End Set
    End Property
    Public Property RFCEmisor() As String
        Get
            Return Me.vgRFCEmisor
        End Get
        Set(ByVal Value As String)
            vgRFCEmisor = Value
        End Set
    End Property
    Public ReadOnly Property Coleccion() As ArrayList
        Get
            Return vgColeccion
        End Get
    End Property

#End Region

    Public Function cargarDatos(ByVal pvAnio As Integer, ByVal pvMes As String, ByVal pvSubEmpresaid As String) As Boolean
        vgMes = pvMes
        vgAnio = pvAnio

        RFCEmisor = vcConexion.EjecutarComandoScalar("select RFC from CentroExpedicion  where tipo=0 and TipoEstado <>0 and SubEmpresaId='" + pvSubEmpresaid + "' ")
        Dim vlFIni As String = "Convert(datetime,'" & vgAnio & "-" & vgMes & "-" & 1 & " 00:00:00',102)"
        Dim vlFFin As String = "Convert(datetime,'" & vgAnio & "-" & vgMes & "-" & Date.DaysInMonth(vgAnio, vgMes) & " 23:59:59',102)"

        Dim vlConsulta As String = "(select TDF.RFC as idFiscal,  " & _
            "Folio, Fechahoraalta, cast (round(total,2)as real) as total,cast (round(impuesto,2)as real) as impuesto, 1 as tipofase, RFCEm, isnull(Serie, '') as Serie, AnioAprobacion, Aprobacion, (case Tipo when 8 then 'I' else 'E' end) as Tipo " & _
            "from transprod TRP " & _
            "inner join TRPDatoFiscal TDF on TRP.transprodid = TDF.transprodid " & _
            "where subempresaid='" + pvSubEmpresaid + "' and tipo in (8, 10) and  ((tipomotivo <> 10 and tipomotivo <> 11)  or (tipomotivo is null)) and fechahoraalta between " & vlFIni & " and " & vlFFin & " union " & _
            "select TDF.RFC as idFiscal, " & _
            "Folio, FechaCancelacion as Fechahoraalta, cast (round(total,2)as real) as total, cast (round(impuesto,2)as real) as impuesto, tipofase, RFCEm, isnull(Serie, '') as Serie, AnioAprobacion, Aprobacion, (case Tipo when 8 then 'I' else 'E' end) as Tipo  " & _
            "from transprod TRP " & _
            "inner join TRPDatoFiscal TDF on TRP.transprodid = TDF.transprodid " & _
            "where subempresaid='" + pvSubEmpresaid + "' and tipo in (8, 10) and tipofase = 0 and ((tipomotivo <> 10 and tipomotivo <> 11)  or (tipomotivo is null)) and Fechacancelacion between  " & vlFIni & " and " & vlFFin & " " & _
            ") order by serie, folio,Fechahoraalta"
        Dim vlDt As DataTable
        vlDt = vcConexion.EjecutarConsulta(vlConsulta)

        vlConsulta = "Select top 1 DirRepMensual from SemHist where subempresaid='" + pvSubEmpresaid + "' order by mfechahora desc"
        PATH = CType(vcConexion.EjecutarConsulta(vlConsulta), DataTable).Rows(0).Item(0).ToString()

        If vlDt Is Nothing OrElse vlDt.Rows.Count <= 0 Then Return False

        validarInformacion(vlDt)
        RFCEmisor = vlDt.Rows(0).Item("RFCEm")
        Return generarArreglo(vlDt)

    End Function

    Public Sub validarInformacion(ByVal pvDt As DataTable)
        Dim pipe As String = "|"

        For Each row As DataRow In pvDt.Rows
            If row("idFiscal").ToString.Length >= 14 Then
                Throw New LbControlError.cError("E0663", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("RFC del cliente", False), New LbControlError.cParametroMSG(row("Serie"), False), New LbControlError.cParametroMSG(row("Folio"), False)})
            End If
            If row("Total").ToString.Length >= 14 Then
                Throw New LbControlError.cError("E0663", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Total", False), New LbControlError.cParametroMSG(row("Serie"), False), New LbControlError.cParametroMSG(row("Folio"), False)})
            End If
            If row("Impuesto").ToString.Length >= 14 Then
                Throw New LbControlError.cError("E0663", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Impuesto", False), New LbControlError.cParametroMSG(row("Serie"), False), New LbControlError.cParametroMSG(row("Folio"), False)})
            End If

            If row("idFiscal").ToString.Contains(pipe) Then
                Throw New LbControlError.cError("E0662", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("RFC del cliente", False), New LbControlError.cParametroMSG(pipe, False)})
            End If
            If row("Serie").ToString.Contains(pipe) Then
                Throw New LbControlError.cError("E0662", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Serie", False), New LbControlError.cParametroMSG(pipe, False)})
            End If
            If row("Folio").ToString.Contains(pipe) Then
                Throw New LbControlError.cError("E0662", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("Folio", False), New LbControlError.cParametroMSG(pipe, False)})
            End If
        Next
    End Sub

    Private Function generarArreglo(ByVal pvDt As DataTable) As Boolean
        vgColeccion = New ArrayList
        For Each row As DataRow In pvDt.Rows
            Dim vlRen As New cRepMensualRenglones
            vlRen.RFCCliente = row("idFiscal")
            vlRen.Serie = row("Serie").ToString.ToUpper
            Dim folio As String = row("Folio")
            If row("folio").ToString.Contains(row("serie")) Then
                folio = row("folio").ToString.Substring(row("serie").ToString.Length, row("folio").ToString.Length - row("serie").ToString.Length)
            End If
            vlRen.Folio = folio
            vlRen.numeroAprobacion = row("anioAprobacion") & row("Aprobacion")
            vlRen.fechaExpedicion = row("fechahoraalta")
            vlRen.dMontoFactura = row("total")
            vlRen.dMontoImpuesto = row("impuesto")
            vlRen.estadoComprobante = row("tipoFase")
            vlRen.Tipo = row("tipo")
            vgColeccion.Add(vlRen)
        Next

        Return True
    End Function

    Public Function generarArchivo() As Boolean
        Dim oMensaje As New BASMENLOG.CMensaje

        If File.Exists(DIRECTORIO) Then
            If MsgBox(oMensaje.RecuperarDescripcion("I0182", New String() {FILE_NAME}), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If

            Dim Permiso As New FileInfo(DIRECTORIO)
            If Permiso.IsReadOnly = True Then
                MsgBox(oMensaje.RecuperarDescripcion("E0682", New String() {PATH}))
                Return False
            End If
        End If

        If Not Directory.Exists(PATH) Then
            MsgBox(oMensaje.RecuperarDescripcion("E0682", New String() {PATH}))
            Return False
        End If

        Try

            Dim sw As StreamWriter = New StreamWriter(DIRECTORIO, False)
            If Not Me.vgColeccion Is Nothing Then
                For Each vlRen As cRepMensualRenglones In Me.vgColeccion
                    sw.WriteLine(vlRen.dameRenglon)
                Next
            End If
            sw.Close()

        Catch ex As UnauthorizedAccessException
            MsgBox(oMensaje.RecuperarDescripcion("E0682", New String() {PATH}))
            Return False
        Catch ex As Security.SecurityException
            MsgBox(oMensaje.RecuperarDescripcion("E0682", New String() {PATH}))
            Return False
        Catch ex As Exception
            MsgBox(oMensaje.RecuperarDescripcion("E0682", New String() {PATH}))
            Return False
        End Try

        Return True
    End Function


End Class

Public Class cRepMensualRenglones
#Region "VARIABLES"
    Private pipe As String = "|"
    Private vgRFCCliente As String
    Private vgSerie As String
    Private vgFolio As String
    Private vgNumeroAprobacion As String
    Private vgFechaExpedicion As DateTime
    Private vgMontoFactura As Double
    Private vgMontoImpuesto As Double
    Private vgEstadoComprobante As Int16
    Private vgTipo As String
#End Region

#Region "PROPIEDADES"
    Public ReadOnly Property dameRenglon() As String
        Get
            Return pipe & RFCCliente & pipe & Serie & pipe & Folio & pipe & numeroAprobacion & pipe & _
            sFechaExpedicion & pipe & sMontoFactura & pipe & sMontoImpuesto & pipe & estadoComprobante & pipe & Tipo & pipe & pipe & pipe & pipe
        End Get
    End Property
    Public Property Tipo() As String
        Get
            Return vgTipo
        End Get
        Set(ByVal Value As String)
            vgTipo = value
        End Set
    End Property

    Public Property RFCCliente() As String
        Get
            Return vgRFCCliente
        End Get
        Set(ByVal Value As String)
            vgRFCCliente = Value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return vgSerie
        End Get
        Set(ByVal Value As String)
            vgSerie = Value
        End Set
    End Property
    Public Property Folio() As String
        Get
            Return vgFolio
        End Get
        Set(ByVal Value As String)
            vgFolio = Value
        End Set
    End Property
    Public Property numeroAprobacion() As String
        Get
            Return vgNumeroAprobacion
        End Get
        Set(ByVal Value As String)
            vgNumeroAprobacion = Value
        End Set
    End Property
    Public ReadOnly Property sFechaExpedicion() As String
        Get
            Return Format(vgFechaExpedicion, "dd/MM/yyyy hh:mm:ss")
        End Get
    End Property
    Public Property fechaExpedicion() As DateTime
        Get
            Return vgFechaExpedicion
        End Get
        Set(ByVal Value As DateTime)
            vgFechaExpedicion = Value
        End Set
    End Property
    Private ReadOnly Property sMontoFactura() As String
        Get
            Return Format(Me.vgMontoFactura, "####0.00")
        End Get
    End Property
    Public Property dMontoFactura() As Double
        Get
            Return Me.vgMontoFactura
        End Get
        Set(ByVal Value As Double)
            vgMontoFactura = Value
        End Set
    End Property
    Private ReadOnly Property sMontoImpuesto() As String
        Get
            Return Format(vgMontoImpuesto, "####0.00")
        End Get
    End Property
    Public Property dMontoImpuesto() As Double
        Get
            Return vgMontoImpuesto
        End Get
        Set(ByVal Value As Double)
            vgMontoImpuesto = Value
        End Set
    End Property
    Public Property estadoComprobante() As Int16
        Get
            Return Me.vgEstadoComprobante
        End Get
        Set(ByVal Value As Int16)
            vgEstadoComprobante = Value
        End Set
    End Property
#End Region

End Class
